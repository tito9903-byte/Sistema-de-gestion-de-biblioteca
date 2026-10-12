using SistemaDeGestionDeBiblioteca.Clases;

namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    public partial class FrmInicio : Form
    {
        InicioDAO inicioDAO = new InicioDAO();


        // Lo usa frmMain para abrir la sección pedida desde las acciones rápidas.
        public event Action<string>? Navegar;


        public FrmInicio()
        {
            InitializeComponent();
        }


        private void FrmInicio_Load(
            object? sender,
            EventArgs e)
        {
            CargarResumen();
            CargarActividad();
        }


        private void CargarResumen()
        {
            try
            {
                InicioDAO.ResumenInicio resumen =
                    inicioDAO.ObtenerResumen();

                tarjetaLibros.Valor =
                    resumen.TotalLibros.ToString("N0");

                tarjetaUsuarios.Valor =
                    resumen.UsuariosRegistrados.ToString("N0");

                tarjetaPrestamos.Valor =
                    resumen.PrestamosActivos.ToString("N0");

                tarjetaReservas.Valor =
                    resumen.ReservasPendientes.ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo cargar el resumen.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void CargarActividad()
        {
            try
            {
                dgvActividad.DataSource =
                    inicioDAO.ObtenerActividadReciente(10);

                dgvActividad.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo cargar la actividad reciente.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void lnkVerTodas_LinkClicked(
            object? sender,
            LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(
                "El historial completo todavía no está disponible.",
                "Información",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }


        private void tarjetaRegistrarLibro_Click(
            object? sender,
            EventArgs e)
        {
            Navegar?.Invoke("Libros");
        }


        private void tarjetaNuevoPrestamo_Click(
            object? sender,
            EventArgs e)
        {
            Navegar?.Invoke("Prestamos");
        }


        private void tarjetaNuevaReserva_Click(
            object? sender,
            EventArgs e)
        {
            Navegar?.Invoke("Reservas");
        }
    }
}
