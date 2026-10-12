using Npgsql;
using NpgsqlTypes;
using System.Data;
using SistemaDeGestionDeBiblioteca.Conexion;

namespace SistemaDeGestionDeBiblioteca.Clases
{
    public class DevolucionDAO
    {
        public record ResumenDevoluciones(
            int DevolucionesHoy,
            int ConRetraso,
            decimal MultasPendientes);


        // idUsuario = null para ver todas; con valor, solo las de ese lector.
        public ResumenDevoluciones ObtenerResumen(int? idUsuario)
        {
            idUsuario = Permisos.Limitar(idUsuario);
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = @"
                    SELECT
                        COUNT(*) FILTER (WHERE d.fecha_devolucion::date = CURRENT_DATE),
                        COUNT(*) FILTER (WHERE d.dias_retraso > 0),
                        COALESCE(SUM(d.multa) FILTER (WHERE d.multa_pagada = false), 0)
                    FROM devoluciones d
                    INNER JOIN prestamos p ON p.id_prestamo = d.id_prestamo
                    WHERE (@usuario IS NULL OR p.id_usuario = @usuario)";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    AgregarUsuario(comando, idUsuario);

                    using (NpgsqlDataReader lector = comando.ExecuteReader())
                    {
                        lector.Read();

                        return new ResumenDevoluciones(
                            Convert.ToInt32(lector[0]),
                            Convert.ToInt32(lector[1]),
                            Convert.ToDecimal(lector[2])
                        );
                    }
                }
            }
        }


        // "A tiempo" / "Con retraso" no se guarda: se deduce de dias_retraso.
        public DataTable ListarDevoluciones(string texto, int? idUsuario)
        {
            idUsuario = Permisos.Limitar(idUsuario);
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
                        d.id_devolucion,
                        d.codigo,
                        u.nombre AS usuario,
                        l.titulo AS libro,
                        p.codigo AS codigo_prestamo,
                        p.fecha_prestamo,
                        p.fecha_vencimiento,
                        d.fecha_devolucion,
                        d.dias_retraso,
                        d.multa,
                        d.multa_pagada,
                        CASE
                            WHEN d.dias_retraso > 0 THEN 'Con retraso'
                            ELSE 'A tiempo'
                        END AS estado
                    FROM devoluciones d
                    INNER JOIN prestamos p ON p.id_prestamo = d.id_prestamo
                    INNER JOIN usuarios u ON u.id_usuario = p.id_usuario
                    INNER JOIN libros l ON l.id_libro = p.id_libro
                    WHERE (@usuario IS NULL OR p.id_usuario = @usuario)
                      AND (d.codigo ILIKE @patron
                           OR p.codigo ILIKE @patron
                           OR u.nombre ILIKE @patron
                           OR u.usuario ILIKE @patron
                           OR l.titulo ILIKE @patron)
                    ORDER BY d.id_devolucion DESC";

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


        // Solo marca como pagada si la devolución tiene multa.
        public bool MarcarMultaPagada(int idDevolucion)
        {
            Permisos.RequerirGestion();
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = @"
                    UPDATE devoluciones
                    SET multa_pagada = true
                    WHERE id_devolucion = @id
                      AND multa > 0";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@id", idDevolucion);

                    return comando.ExecuteNonQuery() > 0;
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
