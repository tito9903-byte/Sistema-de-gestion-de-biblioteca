using SistemaDeGestionDeBiblioteca.Clases;

namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    public partial class FrmNuevaReserva : Form
    {
        ReservaDAO reservaDAO = new ReservaDAO();

        PrestamoDAO prestamoDAO = new PrestamoDAO();

        // Si tiene valor, el lector queda fijo (un lector reserva para sí mismo).
        int? idLectorFijo;


        public FrmNuevaReserva(int? idLectorFijo)
        {
            InitializeComponent();

            this.idLectorFijo = idLectorFijo;
        }


        private void FrmNuevaReserva_Load(
            object? sender,
            EventArgs e)
        {
            nudDias.Value = ReservaDAO.DiasReservaPorDefecto;

            cmbPrioridad.Items.Clear();
            cmbPrioridad.Items.Add("Alta");
            cmbPrioridad.Items.Add("Normal");
            cmbPrioridad.Items.Add("Baja");
            cmbPrioridad.SelectedItem = "Normal";

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

                if (idLectorFijo.HasValue)
                {
                    cmbLector.SelectedValue = idLectorFijo.Value;
                    cmbLector.Enabled = false;
                }
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
                    reservaDAO.ObtenerLibros();

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


            try
            {
                string? error =
                    reservaDAO.RegistrarReserva(
                        Convert.ToInt32(cmbLector.SelectedValue),
                        Convert.ToInt32(cmbLibro.SelectedValue),
                        Convert.ToInt32(nudDias.Value),
                        cmbPrioridad.Text
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
                    "Reserva registrada correctamente.",
                    "Reservas",
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
