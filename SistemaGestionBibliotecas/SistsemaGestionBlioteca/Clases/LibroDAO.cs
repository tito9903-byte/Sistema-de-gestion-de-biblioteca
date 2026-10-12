using Npgsql;
using System.Data;
using SistemaDeGestionDeBiblioteca.Conexion;

namespace SistemaDeGestionDeBiblioteca.Clases
{
    public class LibroDAO
    {
        public record ResumenLibros(
            int Total,
            int Disponibles,
            int Prestados);


        public DataTable ObtenerCategorias()
        {
            DataTable tabla = new DataTable();

            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql =
                    "SELECT id_categoria, nombre FROM categorias ORDER BY nombre";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando);
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }


        // Cuenta ejemplares (copias) de los libros activos.
        public ResumenLibros ObtenerResumen()
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = @"
                    SELECT
                        COALESCE(SUM(ejemplares_total), 0),
                        COALESCE(SUM(ejemplares_disponibles), 0)
                    FROM libros
                    WHERE estado = true";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                using (NpgsqlDataReader lector = comando.ExecuteReader())
                {
                    lector.Read();

                    int total = Convert.ToInt32(lector[0]);
                    int disponibles = Convert.ToInt32(lector[1]);

                    return new ResumenLibros(
                        total,
                        disponibles,
                        total - disponibles
                    );
                }
            }
        }


        // texto vacío = todos los libros.
        public DataTable ListarLibros(string texto)
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
                        l.id_libro,
                        l.codigo,
                        l.titulo,
                        l.autor,
                        c.nombre AS categoria,
                        l.anio_publicacion,
                        l.isbn,
                        l.editorial,
                        l.ejemplares_total,
                        l.ejemplares_disponibles,
                        l.estado AS estado_valor,
                        CASE
                            WHEN l.estado = true THEN 'Activo'
                            ELSE 'Inactivo'
                        END AS estado,
                        CASE
                            WHEN l.estado = false THEN 'No disponible'
                            WHEN l.ejemplares_disponibles > 0 THEN 'Disponible'
                            ELSE 'Prestado'
                        END AS disponibilidad
                    FROM libros l
                    INNER JOIN categorias c ON l.id_categoria = c.id_categoria
                    WHERE l.titulo ILIKE @patron
                       OR l.autor ILIKE @patron
                       OR c.nombre ILIKE @patron
                       OR l.isbn ILIKE @patron
                       OR l.codigo ILIKE @patron
                    ORDER BY l.id_libro";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@patron", patron);

                    NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando);
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }


        public DataTable ObtenerLibro(int idLibro)
        {
            DataTable tabla = new DataTable();

            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = @"
                    SELECT
                        id_libro,
                        titulo,
                        autor,
                        isbn,
                        editorial,
                        id_categoria,
                        anio_publicacion,
                        ejemplares_total,
                        estado
                    FROM libros
                    WHERE id_libro = @id";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@id", idLibro);

                    NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando);
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }


        // idLibro = 0 cuando es un libro nuevo.
        public bool IsbnExisteOtro(string isbn, int idLibro)
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = @"
                    SELECT COUNT(*)
                    FROM libros
                    WHERE isbn = @isbn
                    AND id_libro <> @id";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@isbn", isbn);
                    comando.Parameters.AddWithValue("@id", idLibro);

                    return Convert.ToInt32(comando.ExecuteScalar()) > 0;
                }
            }
        }


        public bool GuardarLibro(
            string titulo,
            string autor,
            string? isbn,
            string? editorial,
            int idCategoria,
            int anio,
            int ejemplares,
            bool estado)
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = @"
                    INSERT INTO libros
                    (titulo, autor, isbn, editorial, id_categoria,
                     anio_publicacion, ejemplares_total,
                     ejemplares_disponibles, estado)
                    VALUES
                    (@titulo, @autor, @isbn, @editorial, @categoria,
                     @anio, @ejemplares, @ejemplares, @estado)";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@titulo", titulo);
                    comando.Parameters.AddWithValue("@autor", autor);

                    comando.Parameters.AddWithValue(
                        "@isbn",
                        (object?)isbn ?? DBNull.Value
                    );

                    comando.Parameters.AddWithValue(
                        "@editorial",
                        (object?)editorial ?? DBNull.Value
                    );

                    comando.Parameters.AddWithValue("@categoria", idCategoria);
                    comando.Parameters.AddWithValue("@anio", (short)anio);
                    comando.Parameters.AddWithValue("@ejemplares", ejemplares);
                    comando.Parameters.AddWithValue("@estado", estado);

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }


        // Devuelve false si el libro no existe o si los ejemplares nuevos
        // son menos que los que están prestados actualmente.
        public bool ActualizarLibro(
            int idLibro,
            string titulo,
            string autor,
            string? isbn,
            string? editorial,
            int idCategoria,
            int anio,
            int ejemplares,
            bool estado)
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = @"
                    UPDATE libros
                    SET titulo = @titulo,
                        autor = @autor,
                        isbn = @isbn,
                        editorial = @editorial,
                        id_categoria = @categoria,
                        anio_publicacion = @anio,
                        ejemplares_total = @ejemplares,
                        ejemplares_disponibles = @ejemplares - (
                            SELECT COUNT(*) FROM prestamos
                            WHERE id_libro = @id AND estado = 'Activo'),
                        estado = @estado
                    WHERE id_libro = @id
                    AND @ejemplares >= (
                            SELECT COUNT(*) FROM prestamos
                            WHERE id_libro = @id AND estado = 'Activo')";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@titulo", titulo);
                    comando.Parameters.AddWithValue("@autor", autor);

                    comando.Parameters.AddWithValue(
                        "@isbn",
                        (object?)isbn ?? DBNull.Value
                    );

                    comando.Parameters.AddWithValue(
                        "@editorial",
                        (object?)editorial ?? DBNull.Value
                    );

                    comando.Parameters.AddWithValue("@categoria", idCategoria);
                    comando.Parameters.AddWithValue("@anio", (short)anio);
                    comando.Parameters.AddWithValue("@ejemplares", ejemplares);
                    comando.Parameters.AddWithValue("@estado", estado);
                    comando.Parameters.AddWithValue("@id", idLibro);

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }


        public bool TieneHistorial(int idLibro)
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = @"
                    SELECT
                        EXISTS (SELECT 1 FROM prestamos WHERE id_libro = @id)
                        OR EXISTS (SELECT 1 FROM reservas WHERE id_libro = @id)";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@id", idLibro);

                    return Convert.ToBoolean(comando.ExecuteScalar());
                }
            }
        }


        public bool EliminarLibro(int idLibro)
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql =
                    "DELETE FROM libros WHERE id_libro = @id";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@id", idLibro);

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }


        public bool CambiarEstado(int idLibro, bool estado)
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = @"
                    UPDATE libros
                    SET estado = @estado
                    WHERE id_libro = @id";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@estado", estado);
                    comando.Parameters.AddWithValue("@id", idLibro);

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
