using SistemaDeGestionDeBiblioteca.Clases;
using System.Data;

namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    public partial class FrmReservas : Form
    {
        ReservaDAO reservaDAO = new ReservaDAO();

        bool puedeAdministrar;

        Font? fuenteNegrita;


        // puedeAdministrar = true para Administrador y Bibliotecario.
        // Con false (rol Usuario) solo ve y gestiona sus propias reservas.
        public FrmReservas(bool puedeAdministrar)
        {
            InitializeComponent();

            this.puedeAdministrar = puedeAdministrar;
        }


        // null = todas las reservas; con valor, solo las del lector.
        private int? FiltroUsuario()
        {
            if (puedeAdministrar)
                return null;

            return Sesion.IdUsuario;
        }


        private void FrmReservas_Load(
            object? sender,
            EventArgs e)
        {
            btnConfirmar.Visible = puedeAdministrar;
            btnNotificar.Visible = puedeAdministrar;

            Actualizar();
        }


        private void Actualizar()
        {
            CargarResumen();
            CargarReservas();
        }


        private void CargarResumen()
        {
            try
            {
                ReservaDAO.ResumenReservas resumen =
                    reservaDAO.ObtenerResumen(FiltroUsuario());

                tarjetaActivas.Valor =
                    resumen.Activas.ToString("N0");

                tarjetaPorVencer.Valor =
                    resumen.PorVencer.ToString("N0");

                tarjetaCanceladas.Valor =
                    resumen.Canceladas.ToString("N0");
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


        private void CargarReservas()
        {
            try
            {
                dgvReservas.DataSource =
                    reservaDAO.ListarReservas(
                        txtBuscar.Text.Trim(),
                        FiltroUsuario()
                    );

                dgvReservas.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar las reservas.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private DataRowView? ObtenerReservaSeleccionada()
        {
            if (dgvReservas.CurrentRow == null ||
                !dgvReservas.CurrentRow.Selected)
            {
                MessageBox.Show(
                    "Seleccione una reserva.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return null;
            }

            return dgvReservas.CurrentRow.DataBoundItem as DataRowView;
        }


        // Colorea el estado de cada reserva.
        private void dgvReservas_CellFormatting(
            object? sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.ColumnIndex != colEstado.Index)
            {
                return;
            }

            fuenteNegrita ??=
                new Font(dgvReservas.DefaultCellStyle.Font ?? Font, FontStyle.Bold);

            e.CellStyle.Font = fuenteNegrita;

            switch (e.Value?.ToString())
            {
                case "Activa":
                    e.CellStyle.ForeColor = Color.FromArgb(20, 150, 50);
                    break;

                case "Por vencer":
                    e.CellStyle.ForeColor = Color.FromArgb(235, 125, 10);
                    break;

                case "Confirmada":
                    e.CellStyle.ForeColor = Color.FromArgb(0, 100, 200);
                    break;

                case "Cancelada":
                case "Vencida":
                    e.CellStyle.ForeColor = Color.FromArgb(210, 20, 30);
                    break;

                case "Cumplida":
                    e.CellStyle.ForeColor = Color.FromArgb(90, 100, 115);
                    break;
            }
        }


        private void txtBuscar_TextChanged(
            object? sender,
            EventArgs e)
        {
            CargarReservas();
        }


        private void btnNuevaReserva_Click(
            object? sender,
            EventArgs e)
        {
            // El lector solo puede reservar para sí mismo.
            FrmNuevaReserva formulario =
                new FrmNuevaReserva(FiltroUsuario());

            if (formulario.ShowDialog(Centrado.Ventana()) ==
                DialogResult.OK)
            {
                Actualizar();
            }
        }


        private void btnConfirmar_Click(
            object? sender,
            EventArgs e)
        {
            DataRowView? reserva =
                ObtenerReservaSeleccionada();

            if (reserva == null)
                return;

            EjecutarAccion(
                reservaDAO.Confirmar(
                    Convert.ToInt32(reserva["id_reserva"])
                ),
                "Reserva " + reserva["codigo"] + " confirmada."
            );
        }


        private void btnCancelar_Click(
            object? sender,
            EventArgs e)
        {
            DataRowView? reserva =
                ObtenerReservaSeleccionada();

            if (reserva == null)
                return;


            DialogResult respuesta =
                MessageBox.Show(
                    "¿Cancelar la reserva " + reserva["codigo"] + " de \"" +
                    reserva["libro"] + "\"?",
                    "Cancelar reserva",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (respuesta != DialogResult.Yes)
                return;


            EjecutarAccion(
                reservaDAO.Cancelar(
                    Convert.ToInt32(reserva["id_reserva"])
                ),
                "Reserva " + reserva["codigo"] + " cancelada."
            );
        }


        private void btnNotificar_Click(
            object? sender,
            EventArgs e)
        {
            DataRowView? reserva =
                ObtenerReservaSeleccionada();

            if (reserva == null)
                return;

            // Por ahora solo se registra; no se envía correo ni mensaje.
            EjecutarAccion(
                reservaDAO.Notificar(
                    Convert.ToInt32(reserva["id_reserva"])
                ),
                "Notificación registrada para " + reserva["usuario"] + ".\n\n" +
                "Nota: el sistema todavía no envía correos ni mensajes; " +
                "solo deja constancia de la notificación."
            );
        }


        private void EjecutarAccion(
            string? error,
            string mensajeExito)
        {
            if (error != null)
            {
                MessageBox.Show(
                    error,
                    "No se pudo completar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            MessageBox.Show(
                mensajeExito,
                "Reservas",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            Actualizar();
        }
    }
}
