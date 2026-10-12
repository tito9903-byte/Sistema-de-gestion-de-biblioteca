using Npgsql;
using System.Reflection;
using System.Text.RegularExpressions;

namespace SistemaDeGestionDeBiblioteca.Conexion
{
    // Deja la base de datos lista la primera vez que se ejecuta la aplicación:
    // crea la base si no existe y ejecuta los scripts de la carpeta Database,
    // que van incluidos dentro del programa.
    public static class PreparadorBD
    {
        // Se ejecutan en este orden cuando la base está vacía. Son
        // repetibles: no duplican datos si se ejecutan otra vez.
        private static readonly string[] Scripts =
        {
            "tablas_base",
            "schema",
            "usuarios_equipo",
            "datos_ejemplo"
        };


        // true si la base configurada existe y tiene las tablas principales.
        // Si no, error explica por qué (null cuando solo falta configurarla).
        public static bool EstaLista(out string? error)
        {
            error = null;

            string? cadena = ConexionBD.CadenaConfigurada();

            if (cadena == null)
                return false;

            try
            {
                using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
                {
                    conexion.Open();

                    if (!TieneTablas(conexion))
                        return false;

                    AsegurarAdministrador(conexion);

                    return true;
                }
            }
            catch (Exception ex)
            {
                error = Traducir(ex, cadena);

                return false;
            }
        }


        // Crea la base y las tablas si hace falta y guarda la configuración.
        // Devuelve null si todo salió bien, o el mensaje de error.
        public static string? Preparar(
            string servidor,
            int puerto,
            string usuario,
            string password,
            string baseDatos)
        {
            if (!Regex.IsMatch(baseDatos, "^[A-Za-z_][A-Za-z0-9_]*$"))
            {
                return "El nombre de la base de datos solo puede tener " +
                       "letras, números y guion bajo.";
            }


            NpgsqlConnectionStringBuilder cadena =
                new NpgsqlConnectionStringBuilder
                {
                    Host = servidor,
                    Port = puerto,
                    Username = usuario,
                    Password = password,
                    Database = "postgres",
                    Timeout = 8
                };

            try
            {
                using (NpgsqlConnection admin =
                    new NpgsqlConnection(cadena.ConnectionString))
                {
                    admin.Open();

                    using (NpgsqlCommand existe = new NpgsqlCommand(
                        "SELECT 1 FROM pg_database WHERE datname = @nombre",
                        admin))
                    {
                        existe.Parameters.AddWithValue("@nombre", baseDatos);

                        if (existe.ExecuteScalar() == null)
                        {
                            using (NpgsqlCommand crear = new NpgsqlCommand(
                                "CREATE DATABASE \"" + baseDatos + "\"",
                                admin))
                            {
                                crear.ExecuteNonQuery();
                            }
                        }
                    }
                }


                cadena.Database = baseDatos;

                NpgsqlConnection.ClearAllPools();

                using (NpgsqlConnection conexion =
                    new NpgsqlConnection(cadena.ConnectionString))
                {
                    conexion.Open();

                    if (!TieneTablas(conexion))
                    {
                        foreach (string script in Scripts)
                            EjecutarScript(conexion, script);
                    }

                    AsegurarAdministrador(conexion);
                }


                ConexionBD.GuardarConfiguracion(cadena.ConnectionString);
                ConexionBD.Establecer(cadena.ConnectionString);

                return null;
            }
            catch (Exception ex)
            {
                return Traducir(ex, cadena.ConnectionString);
            }
        }


        // Si la base no tiene ningún usuario con rol Administrador (por
        // ejemplo, una base que ya existía con otros usuarios), crea el
        // administrador inicial "admin" (contraseña inicial en tablas_base.sql;
        // pasa al formato seguro en el primer inicio de sesión). Si ya hay
        // algún administrador, no hace nada. Es una ayuda: si falla, no
        // impide abrir la aplicación.
        private static void AsegurarAdministrador(NpgsqlConnection conexion)
        {
            try
            {
                using (NpgsqlCommand comando = new NpgsqlCommand(
                    @"INSERT INTO roles (nombre_rol) VALUES ('Administrador')
                      ON CONFLICT (nombre_rol) DO NOTHING;

                      INSERT INTO usuarios (usuario, nombre, password_hash, id_rol, estado)
                      SELECT CASE WHEN EXISTS (SELECT 1 FROM usuarios WHERE usuario = 'admin')
                                  THEN 'admin_inicial' ELSE 'admin' END,
                             'Administrador',
                             upper(encode(sha256(convert_to('Admin123', 'UTF8')), 'hex')),
                             r.id_rol,
                             true
                      FROM roles r
                      WHERE r.nombre_rol = 'Administrador'
                        AND NOT EXISTS (SELECT 1 FROM usuarios u WHERE u.id_rol = r.id_rol)
                        AND NOT EXISTS (SELECT 1 FROM usuarios WHERE usuario = 'admin_inicial');",
                    conexion))
                {
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
            }
        }


        private static bool TieneTablas(NpgsqlConnection conexion)
        {
            using (NpgsqlCommand comando = new NpgsqlCommand(
                @"SELECT to_regclass('public.roles') IS NOT NULL
                      AND to_regclass('public.usuarios') IS NOT NULL
                      AND to_regclass('public.categorias') IS NOT NULL
                      AND to_regclass('public.libros') IS NOT NULL
                      AND to_regclass('public.prestamos') IS NOT NULL
                      AND to_regclass('public.devoluciones') IS NOT NULL
                      AND to_regclass('public.reservas') IS NOT NULL
                      AND to_regclass('public.vw_actividad_reciente') IS NOT NULL",
                conexion))
            {
                return (bool)comando.ExecuteScalar()!;
            }
        }


        private static void EjecutarScript(
            NpgsqlConnection conexion,
            string nombre)
        {
            Assembly ensamblado = Assembly.GetExecutingAssembly();

            using (Stream? flujo = ensamblado.GetManifestResourceStream(
                "Database." + nombre + ".sql"))
            {
                if (flujo == null)
                {
                    throw new InvalidOperationException(
                        "No se encontró el script " + nombre + ".sql.");
                }

                using (StreamReader lector = new StreamReader(flujo))
                using (NpgsqlCommand comando = new NpgsqlCommand(
                    lector.ReadToEnd(), conexion))
                {
                    comando.CommandTimeout = 120;
                    comando.ExecuteNonQuery();
                }
            }
        }


        private static string Traducir(Exception ex, string cadena)
        {
            NpgsqlConnectionStringBuilder datos =
                new NpgsqlConnectionStringBuilder(cadena);

            if (ex is PostgresException pg)
            {
                if (pg.SqlState == "28P01" || pg.SqlState == "28000")
                {
                    return "Usuario o contraseña de PostgreSQL incorrectos " +
                           "(usuario: " + datos.Username + ").";
                }

                if (pg.SqlState == "3D000")
                {
                    return "La base de datos \"" + datos.Database +
                           "\" no existe todavía.";
                }

                if (pg.SqlState == "42501")
                {
                    return "El usuario \"" + datos.Username +
                           "\" no tiene permiso para crear la base de datos.";
                }
            }

            if (ex is NpgsqlException && ex.InnerException is not PostgresException)
            {
                return "No se pudo conectar al servidor PostgreSQL en " +
                       datos.Host + ":" + datos.Port + ".\n" +
                       "Verifique que PostgreSQL esté instalado e iniciado.";
            }

            return ex.Message;
        }
    }
}
