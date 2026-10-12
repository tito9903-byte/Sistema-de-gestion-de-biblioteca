using Npgsql;
using SistemaDeGestionDeBiblioteca.Conexion;

namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    // Ventana de primer uso: pide los datos de PostgreSQL y deja la base de
    // datos lista (la crea y carga las tablas si hace falta).
    public class FrmConfigurarBD : Form
    {
        static readonly Color ColorPrimario = Color.FromArgb(0, 108, 214);

        TextBox txtServidor = new TextBox();
        TextBox txtPuerto = new TextBox();
        TextBox txtUsuario = new TextBox();
        TextBox txtPassword = new TextBox();
        TextBox txtBase = new TextBox();
        Label lblEstado = new Label();
        Button btnAceptar = new Button();
        Button btnCancelar = new Button();


        public FrmConfigurarBD(string? motivo)
        {
            Text = "Configurar la base de datos";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(460, 470);
            Font = new Font("Segoe UI", 10F);
            BackColor = Color.White;
            AcceptButton = btnAceptar;
            CancelButton = btnCancelar;


            Label titulo = new Label
            {
                Text = "Conexión a PostgreSQL",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                Location = new Point(24, 18),
                AutoSize = true
            };

            Label ayuda = new Label
            {
                Text = "Escriba los datos de su PostgreSQL. Si la base de datos " +
                       "no existe, el sistema la crea y carga las tablas y los " +
                       "datos de ejemplo. Solo se pide la primera vez.",
                Location = new Point(24, 58),
                Size = new Size(412, 66),
                ForeColor = Color.FromArgb(80, 90, 105)
            };

            Controls.Add(titulo);
            Controls.Add(ayuda);


            AgregarCampo("Servidor", txtServidor, 132);
            AgregarCampo("Puerto", txtPuerto, 188);
            AgregarCampo("Usuario", txtUsuario, 244);
            AgregarCampo("Contraseña", txtPassword, 300);
            AgregarCampo("Base de datos", txtBase, 356);

            txtPassword.UseSystemPasswordChar = true;


            lblEstado.Location = new Point(24, 414);
            lblEstado.Size = new Size(412, 24);
            lblEstado.ForeColor = Color.FromArgb(200, 30, 40);
            Controls.Add(lblEstado);


            btnAceptar.Text = "Conectar";
            btnAceptar.Size = new Size(120, 34);
            btnAceptar.Location = new Point(196, 428);
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.BackColor = ColorPrimario;
            btnAceptar.ForeColor = Color.White;
            btnAceptar.FlatAppearance.BorderSize = 0;
            btnAceptar.Click += btnAceptar_Click;
            Controls.Add(btnAceptar);

            btnCancelar.Text = "Salir";
            btnCancelar.Size = new Size(110, 34);
            btnCancelar.Location = new Point(326, 428);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.DialogResult = DialogResult.Cancel;
            Controls.Add(btnCancelar);


            CargarValoresIniciales();

            if (!string.IsNullOrEmpty(motivo))
                lblEstado.Text = motivo;

            lblEstado.AutoSize = false;
            lblEstado.Height = 22;
        }


        private void AgregarCampo(string etiqueta, TextBox caja, int y)
        {
            Controls.Add(new Label
            {
                Text = etiqueta,
                Location = new Point(24, y),
                AutoSize = true
            });

            caja.Location = new Point(24, y + 22);
            caja.Size = new Size(412, 27);
            Controls.Add(caja);
        }


        // Si ya había una configuración, se muestra (sin la contraseña).
        private void CargarValoresIniciales()
        {
            txtServidor.Text = "localhost";
            txtPuerto.Text = "5432";
            txtUsuario.Text = "postgres";
            txtBase.Text = "BibliotecaDB";

            string? actual = ConexionBD.CadenaConfigurada();

            if (actual == null)
                return;

            try
            {
                NpgsqlConnectionStringBuilder datos =
                    new NpgsqlConnectionStringBuilder(actual);

                txtServidor.Text = datos.Host ?? "localhost";
                txtPuerto.Text = datos.Port.ToString();
                txtUsuario.Text = datos.Username ?? "postgres";
                txtBase.Text = datos.Database ?? "BibliotecaDB";
            }
            catch (ArgumentException)
            {
            }
        }


        private async void btnAceptar_Click(object? sender, EventArgs e)
        {
            if (txtServidor.Text.Trim() == "" ||
                txtUsuario.Text.Trim() == "" ||
                txtBase.Text.Trim() == "" ||
                !int.TryParse(txtPuerto.Text.Trim(), out int puerto) ||
                puerto < 1 || puerto > 65535)
            {
                lblEstado.ForeColor = Color.FromArgb(200, 30, 40);
                lblEstado.Text = "Complete servidor, puerto, usuario y base de datos.";

                return;
            }


            string servidor = txtServidor.Text.Trim();
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text;
            string baseDatos = txtBase.Text.Trim();

            btnAceptar.Enabled = false;
            lblEstado.ForeColor = Color.FromArgb(60, 70, 85);
            lblEstado.Text = "Conectando y preparando la base de datos...";
            Cursor = Cursors.WaitCursor;

            string? error = await Task.Run(() =>
                PreparadorBD.Preparar(
                    servidor, puerto, usuario, password, baseDatos));

            Cursor = Cursors.Default;
            btnAceptar.Enabled = true;

            if (error != null)
            {
                lblEstado.ForeColor = Color.FromArgb(200, 30, 40);
                lblEstado.Height = 58;
                lblEstado.Text = error;

                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
