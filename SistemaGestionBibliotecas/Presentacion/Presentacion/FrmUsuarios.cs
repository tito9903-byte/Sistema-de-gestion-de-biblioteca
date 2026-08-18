using SistemaDeGestionDeBiblioteca.Clases;

namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    public partial class FrmUsuarios : Form
    {
        UsuarioDAO usuarioDAO = new UsuarioDAO();


        public FrmUsuarios()
        {
            InitializeComponent();
        }


        private void FrmUsuarios_Load(
            object? sender,
            EventArgs e)
        {
            ConfigurarTabla();
            CargarUsuarios();
        }


        private void ConfigurarTabla()
        {
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.MultiSelect = false;

            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;

            dgvUsuarios.RowHeadersVisible = false;

            dgvUsuarios.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvUsuarios.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;


            dgvUsuarios.ColumnHeadersVisible = true;
            dgvUsuarios.ColumnHeadersHeight = 35;

            dgvUsuarios.RowTemplate.Height = 30;


            dgvUsuarios.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10F
                );


            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold
                );
        }


        private void CargarUsuarios()
        {
            try
            {
                dgvUsuarios.DataSource =
                    usuarioDAO.ListarUsuarios();

                OrganizarColumnas();

                dgvUsuarios.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los usuarios.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void OrganizarColumnas()
        {
            DataGridViewColumn? columna;


            columna =
                dgvUsuarios.Columns["id_usuario"];

            if (columna != null)
                columna.Visible = false;


            columna =
                dgvUsuarios.Columns["estado_valor"];

            if (columna != null)
                columna.Visible = false;


            columna =
                dgvUsuarios.Columns["usuario"];

            if (columna != null)
                columna.HeaderText = "Usuario";


            columna =
                dgvUsuarios.Columns["nombre"];

            if (columna != null)
                columna.HeaderText = "Nombre";


            columna =
                dgvUsuarios.Columns["nombre_rol"];

            if (columna != null)
                columna.HeaderText = "Rol";


            columna =
                dgvUsuarios.Columns["estado"];

            if (columna != null)
                columna.HeaderText = "Estado";


            columna =
                dgvUsuarios.Columns["fecha_creacion"];

            if (columna != null)
            {
                columna.HeaderText =
                    "Fecha de creación";

                columna.DefaultCellStyle.Format =
                    "dd/MM/yyyy HH:mm";
            }
        }


        private int ObtenerIdUsuario()
        {
            if (dgvUsuarios.CurrentRow == null)
                return 0;


            object? valor =
                dgvUsuarios
                    .CurrentRow
                    .Cells["id_usuario"]
                    .Value;


            if (valor == null)
                return 0;


            return Convert.ToInt32(valor);
        }


        private void txtBuscar_TextChanged(
            object? sender,
            EventArgs e)
        {
            try
            {
                string texto =
                    txtBuscar.Text.Trim();


                if (texto == "")
                {
                    CargarUsuarios();
                }
                else
                {
                    dgvUsuarios.DataSource =
                        usuarioDAO.BuscarUsuarios(texto);

                    OrganizarColumnas();

                    dgvUsuarios.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo realizar la búsqueda.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void btnNuevo_Click(
            object? sender,
            EventArgs e)
        {
            FrmRegistroUsuario formulario =
                new FrmRegistroUsuario();


            if (formulario.ShowDialog() ==
                DialogResult.OK)
            {
                CargarUsuarios();
            }
        }


        private void btnEditar_Click(
            object? sender,
            EventArgs e)
        {
            int idUsuario =
                ObtenerIdUsuario();


            if (idUsuario == 0)
            {
                MessageBox.Show(
                    "Seleccione un usuario.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }


            FrmRegistroUsuario formulario =
                new FrmRegistroUsuario(idUsuario);


            if (formulario.ShowDialog() ==
                DialogResult.OK)
            {
                CargarUsuarios();
            }
        }


        private void btnEliminar_Click(
            object? sender,
            EventArgs e)
        {
            int idUsuario =
                ObtenerIdUsuario();


            if (idUsuario == 0)
            {
                MessageBox.Show(
                    "Seleccione un usuario.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }


            DialogResult respuesta =
                MessageBox.Show(
                    "¿Seguro que desea eliminar este usuario?",
                    "Eliminar usuario",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );


            if (respuesta != DialogResult.Yes)
                return;


            try
            {
                bool eliminado =
                    usuarioDAO.EliminarUsuario(
                        idUsuario
                    );


                if (eliminado)
                {
                    MessageBox.Show(
                        "Usuario eliminado correctamente.",
                        "Usuarios",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );


                    CargarUsuarios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo eliminar el usuario.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void btnActivarDesactivar_Click(
            object? sender,
            EventArgs e)
        {
            int idUsuario =
                ObtenerIdUsuario();


            if (idUsuario == 0 ||
                dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione un usuario.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }


            object? valor =
                dgvUsuarios
                    .CurrentRow
                    .Cells["estado_valor"]
                    .Value;


            if (valor == null)
                return;


            bool estadoActual =
                Convert.ToBoolean(valor);

            bool nuevoEstado =
                !estadoActual;


            string accion;


            if (nuevoEstado)
                accion = "activar";
            else
                accion = "desactivar";


            DialogResult respuesta =
                MessageBox.Show(
                    "¿Desea " + accion + " este usuario?",
                    "Cambiar estado",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );


            if (respuesta != DialogResult.Yes)
                return;


            try
            {
                bool cambiado =
                    usuarioDAO.CambiarEstado(
                        idUsuario,
                        nuevoEstado
                    );


                if (cambiado)
                {
                    CargarUsuarios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo cambiar el estado.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}