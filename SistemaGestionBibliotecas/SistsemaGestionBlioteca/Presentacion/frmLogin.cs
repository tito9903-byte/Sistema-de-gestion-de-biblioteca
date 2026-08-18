using SistemaDeGestionDeBiblioteca.Clases;
using System.Data;

namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    public partial class frmLogin : Form
    {
        UsuarioDAO usuarioDAO = new UsuarioDAO();


        public frmLogin()
        {
            InitializeComponent();

            txtUser.Text = "";
            txtUser.PlaceholderText = "Usuario";
            txtUser.ForeColor = Color.Black;

            txtPass.Text = "";
            txtPass.PlaceholderText = "Contraseña";
            txtPass.ForeColor = Color.Black;
            txtPass.UseSystemPasswordChar = true;
        }


        private void btnLogin_Click(object? sender, EventArgs e)
        {
            if (txtUser.Text.Trim() == "" ||
                txtPass.Text == "")
            {
                MessageBox.Show(
                    "Ingrese el usuario y la contraseña.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }


            try
            {
                string usuario =
                    txtUser.Text.Trim();

                string password =
                    txtPass.Text;


                DataTable resultado =
                    usuarioDAO.ValidarLogin(
                        usuario,
                        password
                    );


                if (resultado.Rows.Count > 0)
                {
                    string nombre =
                        resultado.Rows[0]["nombre"]?.ToString() ?? "";

                    string rol =
                        resultado.Rows[0]["nombre_rol"]?.ToString() ?? "";


                    frmMain principal =
                        new frmMain(nombre, rol);


                    Hide();

                    principal.ShowDialog();


                    txtPass.Clear();
                    txtUser.Focus();

                    Show();
                }
                else
                {
                    MessageBox.Show(
                        "Usuario o contraseña incorrectos.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtPass.Clear();
                    txtPass.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al iniciar sesión.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void pbMostrarPass_Click(object? sender, EventArgs e)
        {
            if (txtPass.UseSystemPasswordChar)
            {
                txtPass.UseSystemPasswordChar = false;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
            }
        }


        private void lnkOlvideClave_LinkClicked(
            object? sender,
            LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(
                "La recuperación de contraseña todavía no está disponible.",
                "Información",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }


        private void pictureBox3_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}