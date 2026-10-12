using Npgsql;
using NpgsqlTypes;
using System.Data;
using SistemaDeGestionDeBiblioteca.Conexion;

namespace SistemaDeGestionDeBiblioteca.Clases
{
    public class ReservaDAO
    {
        // Reglas de negocio de ejemplo. Se pueden ajustar aquí.
        public const int DiasReservaPorDefecto = 7;
        public const int MaxReservasActivas = 3;
        public const int DiasPorVencer = 3;


        public record ResumenReservas(
            int Activas,
            int PorVencer,
            int Canceladas);


        // idUsuario = null para ver todas; con valor, solo las de ese lector.
        public ResumenReservas ObtenerResumen(int? idUsuario)
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = @"
                    SELECT
                        COUNT(*) FILTER (WHERE estado IN ('Activa', 'Confirmada')
                                         AND fecha_vencimiento >= CURRENT_DATE),
                        COUNT(*) FILTER (WHERE estado = 'Activa'
                                         AND fecha_vencimiento >= CURRENT_DATE
                                         AND fecha_vencimiento <= CURRENT_DATE + @dias),
                        COUNT(*) FILTER (WHERE estado = 'Cancelada')
                    FROM reservas
                    WHERE (@usuario IS NULL OR id_usuario = @usuario)";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@dias", DiasPorVencer);
                    AgregarUsuario(comando, idUsuario);

                    using (NpgsqlDataReader lector = comando.ExecuteReader())
                    {
                        lector.Read();

                        return new ResumenReservas(
                            Convert.ToInt32(lector[0]),
                            Convert.ToInt32(lector[1]),
                            Convert.ToInt32(lector[2])
                        );
                    }
                }
            }
        }


        // "Por vencer" y "Vencida" no se guardan: se calculan por la fecha.
        public DataTable ListarReservas(string texto, int? idUsuario)
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
                        r.id_reserva,
                        r.codigo,
                        u.nombre AS usuario,
                        l.titulo AS libro,
                        r.fecha_reserva,
                        r.fecha_vencimiento,
                        r.prioridad,
                        r.notificado,
                        CASE
                            WHEN r.estado = 'Activa'
                                 AND r.fecha_vencimiento < CURRENT_DATE THEN 'Vencida'
                            WHEN r.estado = 'Activa'
                                 AND r.fecha_vencimiento <= CURRENT_DATE + @dias THEN 'Por vencer'
                            ELSE r.estado
                        END AS estado
                    FROM reservas r
                    INNER JOIN usuarios u ON u.id_usuario = r.id_usuario
                    INNER JOIN libros l ON l.id_libro = r.id_libro
                    WHERE (@usuario IS NULL OR r.id_usuario = @usuario)
                      AND (r.codigo ILIKE @patron
                           OR u.nombre ILIKE @patron
                           OR u.usuario ILIKE @patron
                           OR l.titulo ILIKE @patron
                           OR r.estado ILIKE @patron)
                    ORDER BY r.id_reserva DESC";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@patron", patron);
                    comando.Parameters.AddWithValue("@dias", DiasPorVencer);
                    AgregarUsuario(comando, idUsuario);

                    NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando);
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }


        // Todos los libros activos (se puede reservar aunque haya ejemplares).
        public DataTable ObtenerLibros()
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
        public string? RegistrarReserva(
            int idUsuario,
            int idLibro,
            int dias,
            string prioridad)
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                using (NpgsqlTransaction transaccion = conexion.BeginTransaction())
                {
                    using (NpgsqlCommand comando = new NpgsqlCommand(
                        @"SELECT 1
                          FROM usuarios u
                          INNER JOIN roles r ON r.id_rol = u.id_rol
                          WHERE u.id_usuario = @usuario
                            AND u.estado = true
                            AND r.nombre_rol = 'Usuario'",
                        conexion,
                        transaccion))
                    {
                        comando.Parameters.AddWithValue("@usuario", idUsuario);

                        if (comando.ExecuteScalar() == null)
                        {
                            return "El usuario seleccionado no es un lector activo.";
                        }
                    }


                    using (NpgsqlCommand comando = new NpgsqlCommand(
                        @"SELECT 1 FROM libros
                          WHERE id_libro = @libro AND estado = true",
                        conexion,
                        transaccion))
                    {
                        comando.Parameters.AddWithValue("@libro", idLibro);

                        if (comando.ExecuteScalar() == null)
                        {
                            return "El libro no está disponible en el catálogo.";
                        }
                    }


                    using (NpgsqlCommand comando = new NpgsqlCommand(
                        @"SELECT COUNT(*) FROM reservas
                          WHERE id_usuario = @usuario
                            AND estado IN ('Activa', 'Confirmada')
                            AND fecha_vencimiento >= CURRENT_DATE",
                        conexion,
                        transaccion))
                    {
                        comando.Parameters.AddWithValue("@usuario", idUsuario);

                        int vigentes = Convert.ToInt32(comando.ExecuteScalar());

                        if (vigentes >= MaxReservasActivas)
                        {
                            return "El lector ya tiene " + vigentes +
                                   " reservas vigentes (máximo " + MaxReservasActivas + ").";
                        }
                    }


                    using (NpgsqlCommand comando = new NpgsqlCommand(
                        @"SELECT COUNT(*) FROM reservas
                          WHERE id_usuario = @usuario
                            AND id_libro = @libro
                            AND estado IN ('Activa', 'Confirmada')
                            AND fecha_vencimiento >= CURRENT_DATE",
                        conexion,
                        transaccion))
                    {
                        comando.Parameters.AddWithValue("@usuario", idUsuario);
                        comando.Parameters.AddWithValue("@libro", idLibro);

                        if (Convert.ToInt32(comando.ExecuteScalar()) > 0)
                        {
                            return "El lector ya tiene una reserva vigente de este libro.";
                        }
                    }


                    using (NpgsqlCommand comando = new NpgsqlCommand(
                        @"INSERT INTO reservas
                          (id_usuario, id_libro, fecha_vencimiento, prioridad)
                          VALUES
                          (@usuario, @libro, CURRENT_DATE + @dias, @prioridad)",
                        conexion,
                        transaccion))
                    {
                        comando.Parameters.AddWithValue("@usuario", idUsuario);
                        comando.Parameters.AddWithValue("@libro", idLibro);
                        comando.Parameters.AddWithValue("@dias", dias);
                        comando.Parameters.AddWithValue("@prioridad", prioridad);

                        comando.ExecuteNonQuery();
                    }

                    transaccion.Commit();

                    return null;
                }
            }
        }


        public string? Confirmar(int idReserva)
        {
            return Actualizar(
                @"UPDATE reservas
                  SET estado = 'Confirmada'
                  WHERE id_reserva = @id
                    AND estado = 'Activa'
                    AND fecha_vencimiento >= CURRENT_DATE",
                idReserva,
                "Solo se pueden confirmar reservas activas y vigentes."
            );
        }


        public string? Cancelar(int idReserva)
        {
            return Actualizar(
                @"UPDATE reservas
                  SET estado = 'Cancelada'
                  WHERE id_reserva = @id
                    AND estado IN ('Activa', 'Confirmada')",
                idReserva,
                "Solo se pueden cancelar reservas activas o confirmadas."
            );
        }


        // Solo deja registrado que se notificó; no envía correo ni mensaje.
        public string? Notificar(int idReserva)
        {
            return Actualizar(
                @"UPDATE reservas
                  SET notificado = true
                  WHERE id_reserva = @id
                    AND estado IN ('Activa', 'Confirmada')
                    AND fecha_vencimiento >= CURRENT_DATE",
                idReserva,
                "Solo se puede notificar reservas vigentes."
            );
        }


        private static string? Actualizar(
            string sql,
            int idReserva,
            string errorSinCambios)
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@id", idReserva);

                    return comando.ExecuteNonQuery() > 0
                        ? null
                        : errorSinCambios;
                }
            }
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
    }
}
