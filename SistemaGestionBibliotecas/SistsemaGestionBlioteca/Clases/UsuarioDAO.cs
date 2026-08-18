using Npgsql;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using SistemaDeGestionDeBiblioteca.Conexion;

namespace SistemaDeGestionDeBiblioteca.Clases
{
    public class UsuarioDAO
    {
        public DataTable ObtenerRoles()
        {
            DataTable tabla = new DataTable();

            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = "SELECT id_rol, nombre_rol FROM roles ORDER BY id_rol";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando);
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }


        public DataTable ListarUsuarios()
        {
            DataTable tabla = new DataTable();

            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = @"
                    SELECT
                        u.id_usuario,
                        u.usuario,
                        u.nombre,
                        r.nombre_rol,
                        u.estado AS estado_valor,
                        CASE
                            WHEN u.estado = true THEN 'Activo'
                            ELSE 'Inactivo'
                        END AS estado,
                        u.fecha_creacion
                    FROM usuarios u
                    INNER JOIN roles r ON u.id_rol = r.id_rol
                    ORDER BY u.id_usuario";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando);
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }


        public DataTable BuscarUsuarios(string texto)
        {
            DataTable tabla = new DataTable();

            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = @"
                    SELECT
                        u.id_usuario,
                        u.usuario,
                        u.nombre,
                        r.nombre_rol,
                        u.estado AS estado_valor,
                        CASE
                            WHEN u.estado = true THEN 'Activo'
                            ELSE 'Inactivo'
                        END AS estado,
                        u.fecha_creacion
                    FROM usuarios u
                    INNER JOIN roles r ON u.id_rol = r.id_rol
                    WHERE LOWER(u.usuario) LIKE LOWER(@texto)
                       OR LOWER(u.nombre) LIKE LOWER(@texto)
                       OR LOWER(r.nombre_rol) LIKE LOWER(@texto)
                    ORDER BY u.id_usuario";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@texto", "%" + texto + "%");

                    NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando);
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }


        public DataTable ObtenerUsuario(int idUsuario)
        {
            DataTable tabla = new DataTable();

            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = @"
                    SELECT
                        id_usuario,
                        usuario,
                        nombre,
                        id_rol,
                        estado
                    FROM usuarios
                    WHERE id_usuario = @id";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@id", idUsuario);

                    NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando);
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }


        public bool UsuarioExiste(string usuario)
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql =
                    "SELECT COUNT(*) FROM usuarios WHERE usuario = @usuario";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@usuario", usuario);

                    int cantidad = Convert.ToInt32(comando.ExecuteScalar());

                    return cantidad > 0;
                }
            }
        }


        public bool UsuarioExisteOtro(string usuario, int idUsuario)
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = @"
                    SELECT COUNT(*)
                    FROM usuarios
                    WHERE usuario = @usuario
                    AND id_usuario <> @id";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@id", idUsuario);

                    int cantidad = Convert.ToInt32(comando.ExecuteScalar());

                    return cantidad > 0;
                }
            }
        }


        public bool GuardarUsuario(
            string usuario,
            string nombre,
            string password,
            int idRol,
            bool estado)
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = @"
                    INSERT INTO usuarios
                    (usuario, nombre, password_hash, id_rol, estado)
                    VALUES
                    (@usuario, @nombre, @password, @rol, @estado)";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@nombre", nombre);

                    comando.Parameters.AddWithValue(
                        "@password",
                        EncriptarPassword(password)
                    );

                    comando.Parameters.AddWithValue("@rol", idRol);
                    comando.Parameters.AddWithValue("@estado", estado);

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }


        public bool ActualizarUsuario(
            int idUsuario,
            string usuario,
            string nombre,
            int idRol,
            bool estado,
            string password)
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql;

                if (password == "")
                {
                    sql = @"
                        UPDATE usuarios
                        SET usuario = @usuario,
                            nombre = @nombre,
                            id_rol = @rol,
                            estado = @estado
                        WHERE id_usuario = @id";
                }
                else
                {
                    sql = @"
                        UPDATE usuarios
                        SET usuario = @usuario,
                            nombre = @nombre,
                            id_rol = @rol,
                            estado = @estado,
                            password_hash = @password
                        WHERE id_usuario = @id";
                }

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@rol", idRol);
                    comando.Parameters.AddWithValue("@estado", estado);
                    comando.Parameters.AddWithValue("@id", idUsuario);

                    if (password != "")
                    {
                        comando.Parameters.AddWithValue(
                            "@password",
                            EncriptarPassword(password)
                        );
                    }

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }


        public bool EliminarUsuario(int idUsuario)
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql =
                    "DELETE FROM usuarios WHERE id_usuario = @id";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@id", idUsuario);

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }


        public bool CambiarEstado(int idUsuario, bool estado)
        {
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = @"
                    UPDATE usuarios
                    SET estado = @estado
                    WHERE id_usuario = @id";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@estado", estado);
                    comando.Parameters.AddWithValue("@id", idUsuario);

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }


        public DataTable ValidarLogin(string usuario, string password)
        {
            DataTable tabla = new DataTable();

            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = @"
                    SELECT
                        u.id_usuario,
                        u.usuario,
                        u.nombre,
                        r.nombre_rol
                    FROM usuarios u
                    INNER JOIN roles r ON u.id_rol = r.id_rol
                    WHERE u.usuario = @usuario
                    AND u.password_hash = @password
                    AND u.estado = true";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@usuario", usuario);

                    comando.Parameters.AddWithValue(
                        "@password",
                        EncriptarPassword(password)
                    );

                    NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando);
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }


        private string EncriptarPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] datos = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha.ComputeHash(datos);

                return Convert.ToHexString(hash);
            }
        }
    }
}