using Npgsql;
using System.Data;
using SistemaDeGestionDeBiblioteca.Conexion;

namespace SistemaDeGestionDeBiblioteca.Clases
{
    public class InicioDAO
    {
        public record ResumenInicio(
            int TotalLibros,
            int UsuariosRegistrados,
            int PrestamosActivos,
            int ReservasPendientes);


        public ResumenInicio ObtenerResumen()
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = @"
                    SELECT
                        (SELECT COALESCE(SUM(ejemplares_total), 0) FROM libros WHERE estado = true),
                        (SELECT COUNT(*) FROM usuarios WHERE estado = true),
                        (SELECT COUNT(*) FROM prestamos WHERE estado = 'Activo'),
                        (SELECT COUNT(*) FROM reservas WHERE estado = 'Activa')";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                using (NpgsqlDataReader lector = comando.ExecuteReader())
                {
                    lector.Read();

                    return new ResumenInicio(
                        Convert.ToInt32(lector[0]),
                        Convert.ToInt32(lector[1]),
                        Convert.ToInt32(lector[2]),
                        Convert.ToInt32(lector[3])
                    );
                }
            }
        }


        public DataTable ObtenerActividadReciente(int cantidad)
        {
            DataTable tabla = new DataTable();

            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = @"
                    SELECT fecha, tipo, usuario, detalle
                    FROM vw_actividad_reciente
                    ORDER BY fecha DESC
                    LIMIT @cantidad";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@cantidad", cantidad);

                    NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando);
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }
    }
}
