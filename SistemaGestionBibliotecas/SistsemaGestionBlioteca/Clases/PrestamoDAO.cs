using Npgsql;
using NpgsqlTypes;
using System.Data;
using SistemaDeGestionDeBiblioteca.Conexion;

namespace SistemaDeGestionDeBiblioteca.Clases
{
    public class PrestamoDAO
    {
        // Reglas de negocio de ejemplo. Se pueden ajustar aquí.
        public const int DiasPrestamoPorDefecto = 14;
        public const int MaxPrestamosActivos = 3;
        public const int MaxRenovaciones = 2;
        public const int DiasRenovacion = 14;
        public const decimal TarifaMultaPorDia = 1.00m;


        public record ResumenPrestamos(
            int Activos,
            int Vencidos,
            int DevueltosHoy);


        // Error = null cuando la devolución se registró correctamente.
        public record ResultadoDevolucion(
            string? Error,
            int DiasRetraso,
            decimal Multa);


        // idUsuario = null para ver todos; con valor, solo los de ese lector.
        public ResumenPrestamos ObtenerResumen(int? idUsuario)
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = @"
                    SELECT
                        COUNT(*) FILTER (WHERE estado = 'Activo'),
                        COUNT(*) FILTER (WHERE estado = 'Activo'
                                         AND fecha_vencimiento < CURRENT_DATE),
                        COUNT(*) FILTER (WHERE estado = 'Devuelto'
                                         AND fecha_devolucion::date = CURRENT_DATE)
                    FROM prestamos
                    WHERE (@usuario IS NULL OR id_usuario = @usuario)";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    AgregarUsuario(comando, idUsuario);

                    using (NpgsqlDataReader lector = comando.ExecuteReader())
                    {
                        lector.Read();

                        return new ResumenPrestamos(
                            Convert.ToInt32(lector[0]),
                            Convert.ToInt32(lector[1]),
                            Convert.ToInt32(lector[2])
                        );
                    }
                }
            }
        }


        // "Vencido" no se guarda: se calcula por la fecha de vencimiento.
        public DataTable ListarPrestamos(string texto, int? idUsuario)
        {
            DataTable tabla = new DataTable();

            string patron =
                "%" +
                texto
                    .Replace("\\", "\\\\")
                    .Replace("%", "\\%")
                    .Replace("_", "\\_") +
                "%";

            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = @"
                    SELECT
                        p.id_prestamo,
                        p.codigo,
                        u.nombre AS usuario,
                        l.titulo AS libro,
                        p.fecha_prestamo,
                        p.fecha_vencimiento,
                        p.fecha_devolucion,
                        p.renovaciones,
                        r.nombre AS registrado_por,
                        CASE
                            WHEN p.estado = 'Devuelto' THEN 'Devuelto'
                            WHEN p.fecha_vencimiento < CURRENT_DATE THEN 'Vencido'
                            ELSE 'Activo'
                        END AS estado,
                        CASE
                            WHEN p.estado = 'Devuelto'
                                THEN 'Devuelto el ' || to_char(p.fecha_devolucion, 'DD/MM/YYYY')
                            WHEN p.fecha_vencimiento < CURRENT_DATE
                                THEN (CURRENT_DATE - p.fecha_vencimiento)::text ||
                                     CASE WHEN CURRENT_DATE - p.fecha_vencimiento = 1
                                          THEN ' día de retraso'
                                          ELSE ' días de retraso' END
                            ELSE COALESCE(NULLIF(p.observacion, ''), '-')
                        END AS observacion
                    FROM prestamos p
                    INNER JOIN usuarios u ON u.id_usuario = p.id_usuario
                    INNER JOIN libros l ON l.id_libro = p.id_libro
                    LEFT JOIN usuarios r ON r.id_usuario = p.id_usuario_registro
                    WHERE (@usuario IS NULL OR p.id_usuario = @usuario)
                      AND (p.codigo ILIKE @patron
                           OR u.nombre ILIKE @patron
                           OR u.usuario ILIKE @patron
                           OR l.titulo ILIKE @patron)
                    ORDER BY p.id_prestamo DESC";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@patron", patron);
                    AgregarUsuario(comando, idUsuario);

                    NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando);
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }


        // Usuarios con rol "Usuario" que están activos.
        public DataTable ObtenerLectores()
        {
            DataTable tabla = new DataTable();

            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = @"
                    SELECT
                        u.id_usuario,
                        u.nombre || ' (' || u.usuario || ')' AS descripcion
                    FROM usuarios u
                    INNER JOIN roles r ON r.id_rol = u.id_rol
                    WHERE r.nombre_rol = 'Usuario'
                      AND u.estado = true
                    ORDER BY u.nombre";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando);
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }


        public DataTable ObtenerLibrosDisponibles()
        {
            DataTable tabla = new DataTable();

            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = @"
                    SELECT
                        id_libro,
                        titulo || ' - ' || autor ||
                            ' (' || ejemplares_disponibles || ' disp.)' AS descripcion
                    FROM libros
                    WHERE estado = true
                      AND ejemplares_disponibles > 0
                    ORDER BY titulo";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando);
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }


        // Devuelve null si todo salió bien, o el motivo por el que no se pudo.
        public string? RegistrarPrestamo(
            int idUsuario,
            int idLibro,
            int dias,
            string? observacion,
            int idUsuarioRegistro)
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                using (NpgsqlTransaction transaccion = conexion.BeginTransaction())
                {
                    // El préstamo es solo para lectores activos.
                    if (!EjecutarExiste(conexion, transaccion, @"
                            SELECT 1
                            FROM usuarios u
                            INNER JOIN roles r ON r.id_rol = u.id_rol
                            WHERE u.id_usuario = @id
                              AND u.estado = true
                              AND r.nombre_rol = 'Usuario'", idUsuario))
                    {
                        return "El usuario seleccionado no es un lector activo.";
                    }


                    int activos;

                    using (NpgsqlCommand comando = new NpgsqlCommand(
                        @"SELECT COUNT(*) FROM prestamos
                          WHERE id_usuario = @usuario AND estado = 'Activo'",
                        conexion,
                        transaccion))
                    {
                        comando.Parameters.AddWithValue("@usuario", idUsuario);
                        activos = Convert.ToInt32(comando.ExecuteScalar());
                    }

                    if (activos >= MaxPrestamosActivos)
                    {
                        return "El lector ya tiene " + activos +
                               " préstamos activos (máximo " + MaxPrestamosActivos + ").";
                    }


                    using (NpgsqlCommand comando = new NpgsqlCommand(
                        @"SELECT COUNT(*) FROM prestamos
                          WHERE id_usuario = @usuario
                            AND id_libro = @libro
                            AND estado = 'Activo'",
                        conexion,
                        transaccion))
                    {
                        comando.Parameters.AddWithValue("@usuario", idUsuario);
                        comando.Parameters.AddWithValue("@libro", idLibro);

                        if (Convert.ToInt32(comando.ExecuteScalar()) > 0)
                        {
                            return "El lector ya tiene prestado este libro.";
                        }
                    }


                    // Descuenta un ejemplar solo si hay disponible.
                    using (NpgsqlCommand comando = new NpgsqlCommand(
                        @"UPDATE libros
                          SET ejemplares_disponibles = ejemplares_disponibles - 1
                          WHERE id_libro = @libro
                            AND estado = true
                            AND ejemplares_disponibles > 0",
                        conexion,
                        transaccion))
                    {
                        comando.Parameters.AddWithValue("@libro", idLibro);

                        if (comando.ExecuteNonQuery() == 0)
                        {
                            return "El libro no tiene ejemplares disponibles.";
                        }
                    }


                    using (NpgsqlCommand comando = new NpgsqlCommand(
                        @"INSERT INTO prestamos
                          (id_usuario, id_libro, fecha_vencimiento,
                           observacion, id_usuario_registro)
                          VALUES
                          (@usuario, @libro, CURRENT_DATE + @dias,
                           @observacion, @registro)",
                        conexion,
                        transaccion))
                    {
                        comando.Parameters.AddWithValue("@usuario", idUsuario);
                        comando.Parameters.AddWithValue("@libro", idLibro);
                        comando.Parameters.AddWithValue("@dias", dias);

                        comando.Parameters.AddWithValue(
                            "@observacion",
                            (object?)observacion ?? DBNull.Value
                        );

                        comando.Parameters.AddWithValue(
                            "@registro",
                            idUsuarioRegistro > 0
                                ? idUsuarioRegistro
                                : DBNull.Value
                        );

                        comando.ExecuteNonQuery();
                    }

                    // Si el lector tenía reservado este libro, la reserva queda cumplida.
                    using (NpgsqlCommand comando = new NpgsqlCommand(
                        @"UPDATE reservas
                          SET estado = 'Cumplida'
                          WHERE id_usuario = @usuario
                            AND id_libro = @libro
                            AND estado IN ('Activa', 'Confirmada')",
                        conexion,
                        transaccion))
                    {
                        comando.Parameters.AddWithValue("@usuario", idUsuario);
                        comando.Parameters.AddWithValue("@libro", idLibro);

                        comando.ExecuteNonQuery();
                    }

                    transaccion.Commit();

                    return null;
                }
            }
        }


        public string? Renovar(int idPrestamo)
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                using (NpgsqlTransaction transaccion = conexion.BeginTransaction())
                {
                    string estado;
                    bool vencido;
                    int renovaciones;
                    int idLibro;
                    int idUsuario;

                    using (NpgsqlCommand comando = new NpgsqlCommand(
                        @"SELECT estado,
                                 fecha_vencimiento < CURRENT_DATE,
                                 renovaciones,
                                 id_libro,
                                 id_usuario
                          FROM prestamos
                          WHERE id_prestamo = @id
                          FOR UPDATE",
                        conexion,
                        transaccion))
                    {
                        comando.Parameters.AddWithValue("@id", idPrestamo);

                        using (NpgsqlDataReader lector = comando.ExecuteReader())
                        {
                            if (!lector.Read())
                                return "El préstamo no existe.";

                            estado = lector.GetString(0);
                            vencido = lector.GetBoolean(1);
                            renovaciones = lector.GetInt16(2);
                            idLibro = lector.GetInt32(3);
                            idUsuario = lector.GetInt32(4);
                        }
                    }


                    if (estado == "Devuelto")
                        return "El préstamo ya fue devuelto.";

                    if (vencido)
                        return "El préstamo está vencido. Registre la devolución.";

                    if (renovaciones >= MaxRenovaciones)
                    {
                        return "El préstamo ya se renovó el máximo de veces (" +
                               MaxRenovaciones + ").";
                    }


                    using (NpgsqlCommand comando = new NpgsqlCommand(
                        @"SELECT COUNT(*) FROM reservas
                          WHERE id_libro = @libro
                            AND id_usuario <> @usuario
                            AND estado IN ('Activa', 'Confirmada')",
                        conexion,
                        transaccion))
                    {
                        comando.Parameters.AddWithValue("@libro", idLibro);
                        comando.Parameters.AddWithValue("@usuario", idUsuario);

                        if (Convert.ToInt32(comando.ExecuteScalar()) > 0)
                        {
                            return "El libro tiene reservas de otros usuarios; no se puede renovar.";
                        }
                    }


                    using (NpgsqlCommand comando = new NpgsqlCommand(
                        @"UPDATE prestamos
                          SET fecha_vencimiento = fecha_vencimiento + @dias,
                              renovaciones = renovaciones + 1
                          WHERE id_prestamo = @id",
                        conexion,
                        transaccion))
                    {
                        comando.Parameters.AddWithValue("@dias", DiasRenovacion);
                        comando.Parameters.AddWithValue("@id", idPrestamo);

                        comando.ExecuteNonQuery();
                    }

                    transaccion.Commit();

                    return null;
                }
            }
        }


        // Marca el préstamo como devuelto, crea la devolución con su multa
        // y devuelve el ejemplar al inventario, todo en una transacción.
        public ResultadoDevolucion RegistrarDevolucion(
            int idPrestamo,
            int idUsuarioRegistro)
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                using (NpgsqlTransaction transaccion = conexion.BeginTransaction())
                {
                    string estado;
                    int idLibro;

                    using (NpgsqlCommand comando = new NpgsqlCommand(
                        @"SELECT estado, id_libro
                          FROM prestamos
                          WHERE id_prestamo = @id
                          FOR UPDATE",
                        conexion,
                        transaccion))
                    {
                        comando.Parameters.AddWithValue("@id", idPrestamo);

                        using (NpgsqlDataReader lector = comando.ExecuteReader())
                        {
                            if (!lector.Read())
                            {
                                return new ResultadoDevolucion(
                                    "El préstamo no existe.", 0, 0);
                            }

                            estado = lector.GetString(0);
                            idLibro = lector.GetInt32(1);
                        }
                    }


                    if (estado == "Devuelto")
                    {
                        return new ResultadoDevolucion(
                            "El préstamo ya fue devuelto.", 0, 0);
                    }


                    using (NpgsqlCommand comando = new NpgsqlCommand(
                        @"UPDATE prestamos
                          SET estado = 'Devuelto',
                              fecha_devolucion = CURRENT_TIMESTAMP
                          WHERE id_prestamo = @id",
                        conexion,
                        transaccion))
                    {
                        comando.Parameters.AddWithValue("@id", idPrestamo);
                        comando.ExecuteNonQuery();
                    }


                    int diasRetraso;
                    decimal multa;

                    using (NpgsqlCommand comando = new NpgsqlCommand(
                        @"INSERT INTO devoluciones
                          (id_prestamo, fecha_devolucion, dias_retraso,
                           multa, id_usuario_registro)
                          SELECT
                              p.id_prestamo,
                              p.fecha_devolucion,
                              GREATEST(p.fecha_devolucion::date - p.fecha_vencimiento, 0),
                              GREATEST(p.fecha_devolucion::date - p.fecha_vencimiento, 0)
                                  * @tarifa,
                              @registro
                          FROM prestamos p
                          WHERE p.id_prestamo = @id
                          RETURNING dias_retraso, multa",
                        conexion,
                        transaccion))
                    {
                        comando.Parameters.AddWithValue("@tarifa", TarifaMultaPorDia);
                        comando.Parameters.AddWithValue("@id", idPrestamo);

                        comando.Parameters.AddWithValue(
                            "@registro",
                            idUsuarioRegistro > 0
                                ? idUsuarioRegistro
                                : DBNull.Value
                        );

                        using (NpgsqlDataReader lector = comando.ExecuteReader())
                        {
                            lector.Read();

                            diasRetraso = lector.GetInt32(0);
                            multa = lector.GetDecimal(1);
                        }
                    }


                    using (NpgsqlCommand comando = new NpgsqlCommand(
                        @"UPDATE libros
                          SET ejemplares_disponibles = ejemplares_disponibles + 1
                          WHERE id_libro = @libro",
                        conexion,
                        transaccion))
                    {
                        comando.Parameters.AddWithValue("@libro", idLibro);
                        comando.ExecuteNonQuery();
                    }

                    transaccion.Commit();

                    return new ResultadoDevolucion(null, diasRetraso, multa);
                }
            }
        }


        // Préstamos pendientes de devolver (para el formulario de devolución).
        public DataTable ObtenerPrestamosActivos()
        {
            DataTable tabla = new DataTable();

            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = @"
                    SELECT
                        p.id_prestamo,
                        p.codigo || ' - ' || u.nombre || ' - ' || l.titulo AS descripcion,
                        p.fecha_vencimiento,
                        GREATEST(CURRENT_DATE - p.fecha_vencimiento, 0) AS dias_retraso
                    FROM prestamos p
                    INNER JOIN usuarios u ON u.id_usuario = p.id_usuario
                    INNER JOIN libros l ON l.id_libro = p.id_libro
                    WHERE p.estado = 'Activo'
                    ORDER BY p.id_prestamo DESC";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando);
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }


        private static void AgregarUsuario(
            NpgsqlCommand comando,
            int? idUsuario)
        {
            NpgsqlParameter parametro =
                comando.Parameters.Add("@usuario", NpgsqlDbType.Integer);

            parametro.Value =
                idUsuario.HasValue
                    ? idUsuario.Value
                    : DBNull.Value;
        }


        private static bool EjecutarExiste(
            NpgsqlConnection conexion,
            NpgsqlTransaction transaccion,
            string sql,
            int id)
        {
            using (NpgsqlCommand comando =
                new NpgsqlCommand(sql, conexion, transaccion))
            {
                comando.Parameters.AddWithValue("@id", id);

                return comando.ExecuteScalar() != null;
            }
        }
    }
}
