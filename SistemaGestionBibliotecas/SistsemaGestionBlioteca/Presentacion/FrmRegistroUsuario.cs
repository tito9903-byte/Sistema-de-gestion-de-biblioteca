using SistemaDeGestionDeBiblioteca.Clases;
using System.Data;

namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    public partial class FrmRegistroUsuario : Form
    {
        UsuarioDAO usuarioDAO = new UsuarioDAO();

        int idUsuario = 0;


        // Cuando el formulario se muestra dentro de FrmUsuarios, avisa que
        // terminó (true = se guardó). Si nadie escucha, se cierra como diálogo.
        public event Action<bool>? Finalizado;


        public FrmRegistroUsuario()
        {
            InitializeComponent();

            ConectarEventos();
        }


        public FrmRegistroUsuario(int id)
        {
            InitializeComponent();

            idUsuario = id;

            ConectarEventos();
        }


        private void ConectarEventos()
        {
            Load -= FrmRegistroUsuario_Load;
            Load += FrmRegistroUsuario_Load;

            btnGuardar.Click -= btnGuardar_Click;
            btnGuardar.Click += btnGuardar_Click;

            btnCancelar.Click -= btnCancelar_Click;
            btnCancelar.Click += btnCancelar_Click;

            txtPassword.UseSystemPasswordChar = true;
            txtPassword2.UseSystemPasswordChar = true;
        }


        private void FrmRegistroUsuario_Load(
            object? sender,
            EventArgs e)
        {
            CargarRoles();


            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Inactivo");

            cmbEstado.SelectedIndex = 0;


            if (idUsuario > 0)
            {
                CargarUsuario();
            }
        }


        private void CargarRoles()
        {
            try
            {
                cmbRol.DataSource =
                    usuarioDAO.ObtenerRoles();

                cmbRol.DisplayMember =
                    "nombre_rol";

                cmbRol.ValueMember =
                    "id_rol";

                cmbRol.SelectedIndex = -1;
                cmbRol.Text = "Seleccione el rol";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los roles.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void CargarUsuario()
        {
            try
            {
                DataTable tabla =
                    usuarioDAO.ObtenerUsuario(idUsuario);


                if (tabla.Rows.Count == 0)
                    return;


                DataRow fila =
                    tabla.Rows[0];


                txtUsuario.Text =
                    fila["usuario"]?.ToString() ?? "";

                txtNombre.Text =
                    fila["nombre"]?.ToString() ?? "";


                cmbRol.SelectedValue =
                    Convert.ToInt32(
                        fila["id_rol"]
                    );


                bool estado =
                    Convert.ToBoolean(
                        fila["estado"]
                    );


                if (estado)
                    cmbEstado.Text = "Activo";
                else
                    cmbEstado.Text = "Inactivo";


                txtPassword.Clear();
                txtPassword2.Clear();


                txtPassword.Enabled = true;
                txtPassword2.Enabled = true;


                txtPassword.PlaceholderText =
                    "Dejar vacío para conservar";

                txtPassword2.PlaceholderText =
                    "Confirmar nueva contraseña";


                Text = "Editar Usuario";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo cargar el usuario.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void btnGuardar_Click(
            object? sender,
            EventArgs e)
        {
            if (txtUsuario.Text.Trim() == "" ||
                txtNombre.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Complete los datos del usuario.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }


            if (cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione un rol.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }


            if (cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione el estado.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }


            string usuario =
                txtUsuario.Text.Trim();

            string nombre =
                txtNombre.Text.Trim();

            int idRol =
                Convert.ToInt32(
                    cmbRol.SelectedValue
                );

            bool estado =
                cmbEstado.Text == "Activo";


            try
            {
                // Usuario nuevo
                if (idUsuario == 0)
                {
                    if (txtPassword.Text == "" ||
                        txtPassword2.Text == "")
                    {
                        MessageBox.Show(
                            "Ingrese la contraseña.",
                            "Aviso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        return;
                    }


                    if (txtPassword.Text !=
                        txtPassword2.Text)
                    {
                        MessageBox.Show(
                            "Las contraseñas no coinciden.",
                            "Aviso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        return;
                    }


                    if (usuarioDAO.UsuarioExiste(usuario))
                    {
                        MessageBox.Show(
                            "Ese usuario ya está registrado.",
                            "Aviso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        return;
                    }


                    bool guardado =
                        usuarioDAO.GuardarUsuario(
                            usuario,
                            nombre,
                            txtPassword.Text,
                            idRol,
                            estado
                        );


                    if (guardado)
                    {
                        MessageBox.Show(
                            "Usuario registrado correctamente.",
                            "Usuarios",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );


                        Terminar(true);
                    }
                }

                // Editar
                else
                {
                    if (usuarioDAO.UsuarioExisteOtro(
                        usuario,
                        idUsuario))
                    {
                        MessageBox.Show(
                            "Ese nombre de usuario ya está siendo utilizado.",
                            "Aviso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        return;
                    }


                    if (txtPassword.Text != "" ||
                        txtPassword2.Text != "")
                    {
                        if (txtPassword.Text == "" ||
                            txtPassword2.Text == "")
                        {
                            MessageBox.Show(
                                "Complete los dos campos de contraseña.",
                                "Aviso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );

                            return;
                        }


                        if (txtPassword.Text !=
                            txtPassword2.Text)
                        {
                            MessageBox.Show(
                                "Las contraseñas no coinciden.",
                                "Aviso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );

                            return;
                        }
                    }


                    bool actualizado =
                        usuarioDAO.ActualizarUsuario(
                            idUsuario,
                            usuario,
                            nombre,
                            idRol,
                            estado,
                            txtPassword.Text
                        );


                    if (actualizado)
                    {
                        MessageBox.Show(
                            "Usuario actualizado correctamente.",
                            "Usuarios",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );


                        Terminar(true);
                    }
                }
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
            Terminar(false);
        }
        private void Terminar(bool guardado)
        {
            if (Finalizado != null)
            {
                Finalizado(guardado);

                return;
            }

            if (guardado)
                DialogResult = DialogResult.OK;

            Close();
        }


        // Nuevo usuario: vacía los campos. Edición: vuelve a cargar los datos.
        private void btnLimpiar_Click(
            object? sender,
            EventArgs e)
        {
            if (idUsuario > 0)
            {
                CargarUsuario();

                return;
            }

            txtUsuario.Clear();
            txtNombre.Clear();
            txtPassword.Clear();
            txtPassword2.Clear();

            cmbRol.SelectedIndex = -1;
            cmbEstado.SelectedIndex = 0;

            txtNombre.Focus();
        }


        private void lblMostrarPassword_Click(
            object? sender,
            EventArgs e)
        {
            bool ocultar = !txtPassword.UseSystemPasswordChar;

            txtPassword.UseSystemPasswordChar = ocultar;
            txtPassword2.UseSystemPasswordChar = ocultar;

            // Ojo tachado = contraseña oculta.
            lblMostrarPassword.Font =
                new Font(
                    lblMostrarPassword.Font,
                    ocultar ? FontStyle.Strikeout : FontStyle.Regular
                );
        }
    }
}