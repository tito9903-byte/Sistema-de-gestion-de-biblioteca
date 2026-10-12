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
            Permisos.RequerirAdministrador();
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
            Permisos.RequerirAdministrador();
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
            Permisos.RequerirAdministrador();
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
            Permisos.RequerirAdministrador();
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
            Permisos.RequerirAdministrador();
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
            Permisos.RequerirAdministrador();
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
            Permisos.RequerirAdministrador();
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
                        r.nombre_rol,
                        u.password_hash
                    FROM usuarios u
                    INNER JOIN roles r ON u.id_rol = r.id_rol
                    WHERE u.usuario = @usuario
                    AND u.estado = true";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@usuario", usuario);

                    NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando);
                    adaptador.Fill(tabla);
                }


                // La contraseña se verifica en la aplicación (el hash lleva sal).
                if (tabla.Rows.Count == 0 ||
                    !VerificarPassword(
                        password,
                        tabla.Rows[0]["password_hash"]?.ToString() ?? ""))
                {
                    tabla.Clear();
                    tabla.Columns.Remove("password_hash");

                    return tabla;
                }


                // Cuentas con el hash antiguo (SHA-256 sin sal): se actualizan
                // al formato nuevo en el primer inicio de sesión correcto.
                string hashGuardado =
                    tabla.Rows[0]["password_hash"]?.ToString() ?? "";

                if (!hashGuardado.StartsWith(PrefijoHash))
                {
                    using (NpgsqlCommand actualizar = new NpgsqlCommand(
                        "UPDATE usuarios SET password_hash = @hash WHERE id_usuario = @id",
                        conexion))
                    {
                        actualizar.Parameters.AddWithValue(
                            "@hash",
                            EncriptarPassword(password));

                        actualizar.Parameters.AddWithValue(
                            "@id",
                            Convert.ToInt32(tabla.Rows[0]["id_usuario"]));

                        actualizar.ExecuteNonQuery();
                    }
                }

                tabla.Columns.Remove("password_hash");
            }

            return tabla;
        }


        // Formato guardado: PBKDF2$iteraciones$sal(base64)$hash(base64).
        // Se usa PBKDF2-HMAC-SHA256 con una sal aleatoria por contraseña.
        private const string PrefijoHash = "PBKDF2$";
        private const int IteracionesHash = 600000;
        private const int TamanoSal = 16;
        private const int TamanoHash = 32;


        private string EncriptarPassword(string password)
        {
            byte[] sal = RandomNumberGenerator.GetBytes(TamanoSal);

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                sal,
                IteracionesHash,
                HashAlgorithmName.SHA256,
                TamanoHash);

            return PrefijoHash + IteracionesHash + "$" +
                   Convert.ToBase64String(sal) + "$" +
                   Convert.ToBase64String(hash);
        }


        private static bool VerificarPassword(string password, string guardado)
        {
            if (guardado.StartsWith(PrefijoHash))
            {
                string[] partes = guardado.Split('$');

                if (partes.Length != 4 ||
                    !int.TryParse(partes[1], out int iteraciones))
                    return false;

                byte[] sal = Convert.FromBase64String(partes[2]);
                byte[] esperado = Convert.FromBase64String(partes[3]);

                byte[] calculado = Rfc2898DeriveBytes.Pbkdf2(
                    password,
                    sal,
                    iteraciones,
                    HashAlgorithmName.SHA256,
                    esperado.Length);

                return CryptographicOperations.FixedTimeEquals(
                    calculado,
                    esperado);
            }


            // Formato antiguo: SHA-256 en hexadecimal, sin sal.
            using (SHA256 sha = SHA256.Create())
            {
                byte[] datos = Encoding.UTF8.GetBytes(password);

                string hashAntiguo =
                    Convert.ToHexString(sha.ComputeHash(datos));

                return CryptographicOperations.FixedTimeEquals(
                    Encoding.ASCII.GetBytes(hashAntiguo),
                    Encoding.ASCII.GetBytes(guardado.ToUpperInvariant()));
            }
        }
    }
}
