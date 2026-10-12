using SistemaDeGestionDeBiblioteca.Clases;
using System.Data;

namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    public partial class FrmRegistrarDevolucion : Form
    {
        PrestamoDAO prestamoDAO = new PrestamoDAO();


        public FrmRegistrarDevolucion()
        {
            InitializeComponent();
        }


        private void FrmRegistrarDevolucion_Load(
            object? sender,
            EventArgs e)
        {
            CargarPrestamos();
            MostrarResumen();
        }


        private void CargarPrestamos()
        {
            try
            {
                cmbPrestamo.DataSource =
                    prestamoDAO.ObtenerPrestamosActivos();

                cmbPrestamo.DisplayMember =
                    "descripcion";

                cmbPrestamo.ValueMember =
                    "id_prestamo";

                cmbPrestamo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los préstamos.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        // Muestra la fecha límite, los días de retraso y la multa estimada.
        private void MostrarResumen()
        {
            DataRowView? fila =
                cmbPrestamo.SelectedItem as DataRowView;

            if (fila == null)
            {
                lblVence.Text = "Fecha límite: -";
                lblRetraso.Text = "Días de retraso: -";
                lblMulta.Text = "Multa: -";

                return;
            }


            int diasRetraso =
                Convert.ToInt32(fila["dias_retraso"]);

            decimal multa =
                diasRetraso * PrestamoDAO.TarifaMultaPorDia;

            lblVence.Text =
                "Fecha límite: " +
                ((IFormattable)fila["fecha_vencimiento"]).ToString("dd/MM/yyyy", null);

            lblRetraso.Text =
                "Días de retraso: " + diasRetraso;

            lblMulta.Text =
                "Multa: $" + multa.ToString("N2");

            lblMulta.ForeColor =
                multa > 0
                    ? Color.FromArgb(185, 20, 40)
                    : Color.FromArgb(24, 110, 40);
        }


        private void cmbPrestamo_SelectedIndexChanged(
            object? sender,
            EventArgs e)
        {
            MostrarResumen();
        }


        private void btnGuardar_Click(
            object? sender,
            EventArgs e)
        {
            if (cmbPrestamo.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione el préstamo a devolver.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }


            try
            {
                PrestamoDAO.ResultadoDevolucion resultado =
                    prestamoDAO.RegistrarDevolucion(
                        Convert.ToInt32(cmbPrestamo.SelectedValue),
                        Sesion.IdUsuario
                    );

                if (resultado.Error != null)
                {
                    MessageBox.Show(
                        resultado.Error,
                        "No se pudo registrar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }


                string mensaje =
                    "Devolución registrada correctamente.";

                if (resultado.DiasRetraso > 0)
                {
                    mensaje +=
                        "\n\nDías de retraso: " + resultado.DiasRetraso +
                        "\nMulta: $" + resultado.Multa.ToString("N2");
                }

                MessageBox.Show(
                    mensaje,
                    "Devolución",
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
