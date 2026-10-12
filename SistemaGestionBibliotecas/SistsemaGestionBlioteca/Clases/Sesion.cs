namespace SistemaDeGestionDeBiblioteca.Clases
{
    // Usuario que inició sesión. Lo llena frmLogin y lo usan los módulos
    // (por ejemplo, para saber quién registró un préstamo).
    public static class Sesion
    {
        public static int IdUsuario { get; private set; }

        public static string Nombre { get; private set; } = "";

        public static string Rol { get; private set; } = "";


        public static void Iniciar(int idUsuario, string nombre, string rol)
        {
            IdUsuario = idUsuario;
            Nombre = nombre;
            Rol = rol;
        }


        public static void Cerrar()
        {
            IdUsuario = 0;
            Nombre = "";
            Rol = "";
        }
    }
}
