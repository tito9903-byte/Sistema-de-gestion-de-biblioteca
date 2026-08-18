namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    public partial class frmMain : Form
    {
        public frmMain(string nombre, string rol)
        {
            InitializeComponent();
        }


        private void btnUsuarios_Click(object? sender, EventArgs e)
        {
            AbrirFormulario(
                new FrmUsuarios()
            );
        }


        private void AbrirFormulario(Form formulario)
        {
            panelContenedor.Controls.Clear();

            formulario.TopLevel = false;
            formulario.FormBorderStyle =
                FormBorderStyle.None;

            formulario.Dock =
                DockStyle.Fill;


            panelContenedor.Controls.Add(
                formulario
            );


            formulario.Show();
        }


        private void btnCerrarSesión_Click(
            object? sender,
            EventArgs e)
        {
            DialogResult respuesta =
                MessageBox.Show(
                    "¿Desea cerrar sesión?",
                    "Cerrar sesión",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );


            if (respuesta == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}