using SistemaDeGestionDeBiblioteca.Clases;
using System.Data;

namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    public partial class FrmPrestamos : Form
    {
        PrestamoDAO prestamoDAO = new PrestamoDAO();

        bool puedeAdministrar;


        // puedeAdministrar = true para Administrador y Bibliotecario.
        // Con false (rol Usuario) solo ve sus propios préstamos.
        public FrmPrestamos(bool puedeAdministrar)
        {
            InitializeComponent();

            this.puedeAdministrar = puedeAdministrar;
        }


        // null = todos los préstamos; con valor, solo los del lector.
        private int? FiltroUsuario()
        {
            if (puedeAdministrar)
                return null;

            return Sesion.IdUsuario;
        }


        private void FrmPrestamos_Load(
            object? sender,
            EventArgs e)
        {
            btnNuevoPrestamo.Visible = puedeAdministrar;
            btnRenovar.Visible = puedeAdministrar;
            btnRegistrarDevolucion.Visible = puedeAdministrar;

            CargarResumen();
            CargarPrestamos();
        }


        private void CargarResumen()
        {
            try
            {
                PrestamoDAO.ResumenPrestamos resumen =
                    prestamoDAO.ObtenerResumen(FiltroUsuario());

                tarjetaActivos.Valor =
                    resumen.Activos.ToString("N0");

                tarjetaVencidos.Valor =
                    resumen.Vencidos.ToString("N0");

                tarjetaDevueltosHoy.Valor =
                    resumen.DevueltosHoy.ToString("N0");
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


        private void CargarPrestamos()
        {
            try
            {
                dgvPrestamos.DataSource =
                    prestamoDAO.ListarPrestamos(
                        txtBuscar.Text.Trim(),
                        FiltroUsuario()
                    );

                dgvPrestamos.ClearSelection();
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


        private void Actualizar()
        {
            CargarResumen();
            CargarPrestamos();
        }


        private DataRowView? ObtenerPrestamoSeleccionado()
        {
            if (dgvPrestamos.CurrentRow == null ||
                !dgvPrestamos.CurrentRow.Selected)
            {
                MessageBox.Show(
                    "Seleccione un préstamo.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return null;
            }

            return dgvPrestamos.CurrentRow.DataBoundItem as DataRowView;
        }


        // Colorea el estado: Vencido en rojo y Devuelto en verde.
        private void dgvPrestamos_CellFormatting(
            object? sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.ColumnIndex != colEstado.Index)
            {
                return;
            }

            string estado =
                e.Value?.ToString() ?? "";

            if (estado == "Vencido")
                e.CellStyle.ForeColor = Color.FromArgb(200, 20, 30);
            else if (estado == "Devuelto")
                e.CellStyle.ForeColor = Color.FromArgb(20, 140, 40);
        }


        private void txtBuscar_TextChanged(
            object? sender,
            EventArgs e)
        {
            CargarPrestamos();
        }


        private void btnNuevoPrestamo_Click(
            object? sender,
            EventArgs e)
        {
            FrmNuevoPrestamo formulario =
                new FrmNuevoPrestamo();

            if (formulario.ShowDialog(Centrado.Ventana()) ==
                DialogResult.OK)
            {
                Actualizar();
            }
        }


        private void btnRenovar_Click(
            object? sender,
            EventArgs e)
        {
            DataRowView? prestamo =
                ObtenerPrestamoSeleccionado();

            if (prestamo == null)
                return;


            DialogResult respuesta =
                MessageBox.Show(
                    "¿Renovar el préstamo " + prestamo["codigo"] + " por " +
                    PrestamoDAO.DiasRenovacion + " días más?",
                    "Renovar préstamo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (respuesta != DialogResult.Yes)
                return;


            try
            {
                string? error =
                    prestamoDAO.Renovar(
                        Convert.ToInt32(prestamo["id_prestamo"])
                    );

                if (error != null)
                {
                    MessageBox.Show(
                        error,
                        "No se pudo renovar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                MessageBox.Show(
                    "Préstamo renovado correctamente.",
                    "Préstamos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                Actualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo renovar el préstamo.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void btnRegistrarDevolucion_Click(
            object? sender,
            EventArgs e)
        {
            DataRowView? prestamo =
                ObtenerPrestamoSeleccionado();

            if (prestamo == null)
                return;


            DialogResult respuesta =
                MessageBox.Show(
                    "¿Registrar la devolución de \"" + prestamo["libro"] +
                    "\" (" + prestamo["codigo"] + ")?",
                    "Registrar devolución",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (respuesta != DialogResult.Yes)
                return;


            try
            {
                PrestamoDAO.ResultadoDevolucion resultado =
                    prestamoDAO.RegistrarDevolucion(
                        Convert.ToInt32(prestamo["id_prestamo"]),
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

                Actualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo registrar la devolución.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void btnVerDetalle_Click(
            object? sender,
            EventArgs e)
        {
            DataRowView? prestamo =
                ObtenerPrestamoSeleccionado();

            if (prestamo == null)
                return;


            string devuelto =
                prestamo["fecha_devolucion"] == DBNull.Value
                    ? "-"
                    : Convert.ToDateTime(prestamo["fecha_devolucion"])
                        .ToString("dd/MM/yyyy HH:mm");

            string registradoPor =
                prestamo["registrado_por"] == DBNull.Value
                    ? "-"
                    : prestamo["registrado_por"].ToString() ?? "-";


            MessageBox.Show(
                "Código: " + prestamo["codigo"] + "\n" +
                "Usuario: " + prestamo["usuario"] + "\n" +
                "Libro: " + prestamo["libro"] + "\n" +
                "Fecha de préstamo: " +
                    Convert.ToDateTime(prestamo["fecha_prestamo"])
                        .ToString("dd/MM/yyyy HH:mm") + "\n" +
                "Fecha de devolución (límite): " +
                    ((IFormattable)prestamo["fecha_vencimiento"]).ToString("dd/MM/yyyy", null) + "\n" +
                "Devuelto el: " + devuelto + "\n" +
                "Renovaciones: " + prestamo["renovaciones"] + "\n" +
                "Estado: " + prestamo["estado"] + "\n" +
                "Observación: " + prestamo["observacion"] + "\n" +
                "Registrado por: " + registradoPor,
                "Detalle del préstamo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
