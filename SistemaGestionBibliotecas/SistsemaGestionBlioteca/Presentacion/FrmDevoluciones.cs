using SistemaDeGestionDeBiblioteca.Clases;
using System.Data;

namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    public partial class FrmDevoluciones : Form
    {
        DevolucionDAO devolucionDAO = new DevolucionDAO();

        bool puedeAdministrar;


        // puedeAdministrar = true para Administrador y Bibliotecario.
        // Con false (rol Usuario) solo ve sus propias devoluciones.
        public FrmDevoluciones(bool puedeAdministrar)
        {
            InitializeComponent();

            this.puedeAdministrar = puedeAdministrar;
        }


        // null = todas las devoluciones; con valor, solo las del lector.
        private int? FiltroUsuario()
        {
            if (puedeAdministrar)
                return null;

            return Sesion.IdUsuario;
        }


        private void FrmDevoluciones_Load(
            object? sender,
            EventArgs e)
        {
            btnRegistrarDevolucion.Visible = puedeAdministrar;
            btnVerHistorial.Visible = puedeAdministrar;

            Actualizar();
        }


        private void Actualizar()
        {
            CargarResumen();
            CargarDevoluciones();
        }


        private void CargarResumen()
        {
            try
            {
                DevolucionDAO.ResumenDevoluciones resumen =
                    devolucionDAO.ObtenerResumen(FiltroUsuario());

                tarjetaHoy.Valor =
                    resumen.DevolucionesHoy.ToString("N0");

                tarjetaConRetraso.Valor =
                    resumen.ConRetraso.ToString("N0");

                tarjetaMultas.Valor =
                    "$" + resumen.MultasPendientes.ToString("N2");
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


        private void CargarDevoluciones()
        {
            try
            {
                dgvDevoluciones.DataSource =
                    devolucionDAO.ListarDevoluciones(
                        txtBuscar.Text.Trim(),
                        FiltroUsuario()
                    );

                dgvDevoluciones.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar las devoluciones.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private DataRowView? ObtenerDevolucionSeleccionada()
        {
            if (dgvDevoluciones.CurrentRow == null ||
                !dgvDevoluciones.CurrentRow.Selected)
            {
                MessageBox.Show(
                    "Seleccione una devolución.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return null;
            }

            return dgvDevoluciones.CurrentRow.DataBoundItem as DataRowView;
        }


        // Pinta el estado: A tiempo en verde y Con retraso en rojo.
        private void dgvDevoluciones_CellFormatting(
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

            if (estado == "Con retraso")
            {
                e.CellStyle.BackColor = Color.FromArgb(252, 205, 205);
                e.CellStyle.ForeColor = Color.FromArgb(170, 20, 30);
            }
            else if (estado == "A tiempo")
            {
                e.CellStyle.BackColor = Color.FromArgb(200, 236, 206);
                e.CellStyle.ForeColor = Color.FromArgb(20, 110, 40);
            }
        }


        private void txtBuscar_TextChanged(
            object? sender,
            EventArgs e)
        {
            CargarDevoluciones();
        }


        private void btnRegistrarDevolucion_Click(
            object? sender,
            EventArgs e)
        {
            FrmRegistrarDevolucion formulario =
                new FrmRegistrarDevolucion();

            if (formulario.ShowDialog() ==
                DialogResult.OK)
            {
                Actualizar();
            }
        }


        // Muestra cómo se calculó la multa y permite registrar su pago.
        private void btnCalcularMulta_Click(
            object? sender,
            EventArgs e)
        {
            DataRowView? devolucion =
                ObtenerDevolucionSeleccionada();

            if (devolucion == null)
                return;


            int diasRetraso =
                Convert.ToInt32(devolucion["dias_retraso"]);

            decimal multa =
                Convert.ToDecimal(devolucion["multa"]);

            bool pagada =
                Convert.ToBoolean(devolucion["multa_pagada"]);


            string estadoPago =
                multa == 0
                    ? "Sin multa"
                    : pagada ? "Pagada" : "Pendiente de pago";

            string detalle =
                "Devolución: " + devolucion["codigo"] + "\n" +
                "Préstamo: " + devolucion["codigo_prestamo"] + "\n" +
                "Libro: " + devolucion["libro"] + "\n" +
                "Fecha límite: " +
                    ((IFormattable)devolucion["fecha_vencimiento"]).ToString("dd/MM/yyyy", null) + "\n" +
                "Devuelto el: " +
                    Convert.ToDateTime(devolucion["fecha_devolucion"])
                        .ToString("dd/MM/yyyy HH:mm") + "\n\n" +
                "Días de retraso: " + diasRetraso + "\n" +
                "Tarifa por día: $" +
                    PrestamoDAO.TarifaMultaPorDia.ToString("N2") + "\n" +
                "Multa: $" + multa.ToString("N2") + "\n" +
                "Estado: " + estadoPago;


            bool puedeCobrar =
                puedeAdministrar && multa > 0 && !pagada;

            if (!puedeCobrar)
            {
                MessageBox.Show(
                    detalle,
                    "Cálculo de multa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }


            DialogResult respuesta =
                MessageBox.Show(
                    detalle + "\n\n¿Desea registrar el pago de esta multa?",
                    "Cálculo de multa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (respuesta != DialogResult.Yes)
                return;


            try
            {
                devolucionDAO.MarcarMultaPagada(
                    Convert.ToInt32(devolucion["id_devolucion"])
                );

                Actualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo registrar el pago.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        // Filtra la lista por el usuario de la devolución seleccionada.
        private void btnVerHistorial_Click(
            object? sender,
            EventArgs e)
        {
            DataRowView? devolucion =
                ObtenerDevolucionSeleccionada();

            if (devolucion == null)
                return;

            txtBuscar.Text =
                devolucion["usuario"].ToString() ?? "";
        }


        private void btnActualizar_Click(
            object? sender,
            EventArgs e)
        {
            txtBuscar.Clear();

            Actualizar();
        }
    }
}
