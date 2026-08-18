using SistemaDeGestionDeBiblioteca.Presentacion;

namespace SistemaDeGestionDeBiblioteca
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmLogin());
        }
    }
}