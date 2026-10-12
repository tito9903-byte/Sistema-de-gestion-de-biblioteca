using SistemaDeGestionDeBiblioteca.Clases;

namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    public partial class FrmNuevoPrestamo : Form
    {
        PrestamoDAO prestamoDAO = new PrestamoDAO();


        public FrmNuevoPrestamo()
        {
            InitializeComponent();
        }


        private void FrmNuevoPrestamo_Load(
            object? sender,
            EventArgs e)
        {
            nudDias.Value = PrestamoDAO.DiasPrestamoPorDefecto;

            ActualizarVencimiento();
            CargarLectores();
            CargarLibros();
        }


        private void CargarLectores()
        {
            try
            {
                cmbLector.DataSource =
                    prestamoDAO.ObtenerLectores();

                cmbLector.DisplayMember =
                    "descripcion";

                cmbLector.ValueMember =
                    "id_usuario";

                cmbLector.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los lectores.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void CargarLibros()
        {
            try
            {
                cmbLibro.DataSource =
                    prestamoDAO.ObtenerLibrosDisponibles();

                cmbLibro.DisplayMember =
                    "descripcion";

                cmbLibro.ValueMember =
                    "id_libro";

                cmbLibro.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los libros.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void ActualizarVencimiento()
        {
            lblVence.Text =
                "Vence el " +
                DateTime.Today
                    .AddDays((double)nudDias.Value)
                    .ToString("dd/MM/yyyy");
        }


        private void nudDias_ValueChanged(
            object? sender,
            EventArgs e)
        {
            ActualizarVencimiento();
        }


        private void btnGuardar_Click(
            object? sender,
            EventArgs e)
        {
            if (cmbLector.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione el lector.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }


            if (cmbLibro.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione el libro.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }


            string? observacion =
                txtObservacion.Text.Trim() == ""
                    ? null
                    : txtObservacion.Text.Trim();


            try
            {
                string? error =
                    prestamoDAO.RegistrarPrestamo(
                        Convert.ToInt32(cmbLector.SelectedValue),
                        Convert.ToInt32(cmbLibro.SelectedValue),
                        Convert.ToInt32(nudDias.Value),
                        observacion,
                        Sesion.IdUsuario
                    );

                if (error != null)
                {
                    MessageBox.Show(
                        error,
                        "No se pudo registrar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }


                MessageBox.Show(
                    "Préstamo registrado correctamente.",
                    "Préstamos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                DialogResult =
                    DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void btnCancelar_Click(
            object? sender,
            EventArgs e)
        {
            Close();
        }
    }
}
