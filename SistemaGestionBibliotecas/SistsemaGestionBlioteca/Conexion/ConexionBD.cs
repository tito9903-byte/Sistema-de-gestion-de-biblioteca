using Npgsql;

namespace SistemaDeGestionDeBiblioteca.Conexion
{
    public class ConexionBD
    {
        private static readonly string cadenaConexion =
            "Host=localhost;" +
            "Port=5432;" +
            "Database=BibliotecaDB;" +
            "Username=postgres;" +
            "Password=sshcasa1212;";

        public static NpgsqlConnection ObtenerConexion()
        {
            return new NpgsqlConnection(cadenaConexion);
        }
    }
}