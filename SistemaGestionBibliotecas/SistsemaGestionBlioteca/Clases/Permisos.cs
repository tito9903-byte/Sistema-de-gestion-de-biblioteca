namespace SistemaDeGestionDeBiblioteca.Clases
{
    // Permisos por rol aplicados en la capa de acceso a datos, además de los
    // botones que oculta la interfaz. Los DAO llaman a estos métodos antes de
    // modificar o consultar datos, usando el rol de la sesión iniciada.
    //   Administrador: todo.
    //   Bibliotecario: todo excepto la gestión de usuarios.
    //   Usuario (lector): solo lo suyo (préstamos, devoluciones y reservas).
    public static class Permisos
    {
        public static bool EsAdministrador
        {
            get { return Sesion.Rol == "Administrador"; }
        }


        public static bool PuedeGestionar
        {
            get
            {
                return Sesion.Rol == "Administrador" ||
                       Sesion.Rol == "Bibliotecario";
            }
        }


        public static void RequerirAdministrador()
        {
            if (!EsAdministrador)
                throw new UnauthorizedAccessException(
                    "No tiene permiso para realizar esta operación.");
        }


        public static void RequerirGestion()
        {
            if (!PuedeGestionar)
                throw new UnauthorizedAccessException(
                    "No tiene permiso para realizar esta operación.");
        }


        // El lector solo puede actuar sobre sus propios registros.
        public static void RequerirPropioOGestion(int idUsuario)
        {
            if (PuedeGestionar)
                return;

            if (Sesion.Rol == "Usuario" && idUsuario == Sesion.IdUsuario)
                return;

            throw new UnauthorizedAccessException(
                "No tiene permiso para realizar esta operación.");
        }


        // null = todos (solo Administrador/Bibliotecario); el lector queda
        // limitado a sus propios registros.
        public static int? Limitar(int? idUsuario)
        {
            if (PuedeGestionar)
                return idUsuario;

            return Sesion.IdUsuario;
        }
    }
}
