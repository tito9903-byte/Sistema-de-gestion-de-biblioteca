using Npgsql;

namespace SistemaDeGestionDeBiblioteca.Conexion
{
    public class ConexionBD
    {
        // La cadena de conexión no se guarda en el código (contiene la
        // contraseña). Se busca, en este orden:
        //   1. Variable de entorno BIBLIOTECA_CONEXION.
        //   2. Archivo conexion.local.txt junto al ejecutable (no se sube a
        //      Git; use conexion.ejemplo.txt como plantilla).
        //   3. Archivo conexion.local.txt de la carpeta del usuario
        //      (%LOCALAPPDATA%\SistemaGestionBiblioteca), que crea la
        //      configuración inicial de la aplicación.
        private const string Variable = "BIBLIOTECA_CONEXION";
        private const string Archivo = "conexion.local.txt";

        private static string? cadenaConexion;


        public static string RutaConfiguracionUsuario
        {
            get
            {
                return Path.Combine(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.LocalApplicationData),
                    "SistemaGestionBiblioteca",
                    Archivo);
            }
        }


        public static NpgsqlConnection ObtenerConexion()
        {
            cadenaConexion ??= LeerCadena();

            return new NpgsqlConnection(cadenaConexion);
        }


        // Cadena en uso, o null si todavía no hay ninguna configurada.
        public static string? CadenaConfigurada()
        {
            try
            {
                cadenaConexion ??= LeerCadena();
            }
            catch (InvalidOperationException)
            {
                return null;
            }

            return cadenaConexion;
        }


        public static void Establecer(string cadena)
        {
            cadenaConexion = cadena;
        }


        public static void GuardarConfiguracion(string cadena)
        {
            string ruta = RutaConfiguracionUsuario;

            Directory.CreateDirectory(Path.GetDirectoryName(ruta)!);

            File.WriteAllText(
                ruta,
                "# Configuración de la base de datos (generada por la aplicación)." +
                Environment.NewLine +
                cadena +
                Environment.NewLine);
        }


        private static string LeerCadena()
        {
            string? deEntorno =
                Environment.GetEnvironmentVariable(Variable);

            if (!string.IsNullOrWhiteSpace(deEntorno))
                return deEntorno.Trim();


            string? deArchivo =
                LeerArchivo(Path.Combine(AppContext.BaseDirectory, Archivo)) ??
                LeerArchivo(RutaConfiguracionUsuario);

            if (deArchivo != null)
                return deArchivo;


            throw new InvalidOperationException(
                "No se encontró la configuración de la base de datos.");
        }


        private static string? LeerArchivo(string ruta)
        {
            if (!File.Exists(ruta))
                return null;

            foreach (string linea in File.ReadAllLines(ruta))
            {
                string texto = linea.Trim();

                if (texto != "" && !texto.StartsWith("#"))
                    return texto;
            }

            return null;
        }
    }
}
