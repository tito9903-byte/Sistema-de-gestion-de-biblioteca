using SistemaDeGestionDeBiblioteca.Conexion;
using SistemaDeGestionDeBiblioteca.Presentacion;

namespace SistemaDeGestionDeBiblioteca
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            if (!BaseDeDatosLista())
                return;

            Application.Run(new frmLogin());
        }


        // Primera ejecución (o base de datos no disponible): abre la ventana
        // de configuración, que crea la base y las tablas si hace falta.
        private static bool BaseDeDatosLista()
        {
            if (PreparadorBD.EstaLista(out string? motivo))
                return true;

            using (FrmConfigurarBD ventana = new FrmConfigurarBD(motivo))
            {
                return ventana.ShowDialog() == DialogResult.OK;
            }
        }
    }
}
