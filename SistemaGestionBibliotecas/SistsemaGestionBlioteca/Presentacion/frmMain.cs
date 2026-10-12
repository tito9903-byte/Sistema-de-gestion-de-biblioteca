namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    public partial class frmMain : Form
    {
        string rolUsuario;

        Button? botonActivo;

        static readonly Color ColorBotonActivo =
            Color.FromArgb(30, 144, 255);

        static readonly Color ColorBotonHover =
            Color.FromArgb(124, 146, 177);


        public frmMain(string nombre, string rol)
        {
            InitializeComponent();

            rolUsuario = rol;

            AplicarPermisos();
        }


        private void frmMain_Load(
            object? sender,
            EventArgs e)
        {
            MostrarInicio();
        }


        // Administrador y Bibliotecario gestionan; el rol Usuario (lector)
        // solo consulta el catálogo y lo suyo.
        private bool PuedeAdministrar
        {
            get
            {
                return rolUsuario == "Administrador" ||
                       rolUsuario == "Bibliotecario";
            }
        }


        private void AplicarPermisos()
        {
            // Los reportes son globales: el rol Usuario (lector) no los ve.
            btnReportes.Visible = PuedeAdministrar;


            if (rolUsuario == "Administrador")
            {
                btnUsuarios.Visible = true;
            }
            else
            {
                btnUsuarios.Visible = false;
            }
        }


        private void MostrarInicio()
        {
            FrmInicio inicio =
                new FrmInicio();

            inicio.Navegar += Navegar;

            AbrirSeccion(btnInicio, inicio);
        }


        // Atajos de FrmInicio hacia las demás secciones.
        private void Navegar(string seccion)
        {
            switch (seccion)
            {
                case "Libros":
                    btnLibros.PerformClick();
                    break;

                case "Prestamos":
                    btnPrestamos.PerformClick();
                    break;

                case "Reservas":
                    btnReservas.PerformClick();
                    break;
            }
        }


        private void btnInicio_Click(
            object? sender,
            EventArgs e)
        {
            MostrarInicio();
        }


        private void btnUsuarios_Click(
            object? sender,
            EventArgs e)
        {
            if (rolUsuario != "Administrador")
            {
                MessageBox.Show(
                    "No tiene permiso para administrar usuarios.",
                    "Acceso denegado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }


            AbrirSeccion(
                btnUsuarios,
                new FrmUsuarios()
            );
        }


        private void btnLibros_Click(
            object? sender,
            EventArgs e)
        {
            AbrirSeccion(
                btnLibros,
                new FrmLibros(PuedeAdministrar)
            );
        }


        private void btnPrestamos_Click(
            object? sender,
            EventArgs e)
        {
            AbrirSeccion(
                btnPrestamos,
                new FrmPrestamos(PuedeAdministrar)
            );
        }


        private void btnDevoluciones_Click(
            object? sender,
            EventArgs e)
        {
            AbrirSeccion(
                btnDevoluciones,
                new FrmDevoluciones(PuedeAdministrar)
            );
        }


        private void btnReservas_Click(
            object? sender,
            EventArgs e)
        {
            AbrirSeccion(
                btnReservas,
                new FrmReservas(PuedeAdministrar)
            );
        }


        private void btnReportes_Click(
            object? sender,
            EventArgs e)
        {
            if (!PuedeAdministrar)
            {
                MessageBox.Show(
                    "No tiene permiso para ver los reportes.",
                    "Acceso denegado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }


            AbrirSeccion(
                btnReportes,
                new FrmReportes()
            );
        }


        private void AbrirSeccion(
            Button boton,
            Form formulario)
        {
            MarcarActivo(boton);

            AbrirFormulario(formulario);
        }


        private void MarcarActivo(Button boton)
        {
            if (botonActivo != null)
            {
                botonActivo.BackColor = panelMenu.BackColor;
                botonActivo.FlatAppearance.MouseOverBackColor =
                    ColorBotonHover;
            }

            boton.BackColor = ColorBotonActivo;
            boton.FlatAppearance.MouseOverBackColor =
                ColorBotonActivo;

            botonActivo = boton;
        }


        private void AbrirFormulario(Form formulario)
        {
            foreach (Control anterior in
                panelContenedor.Controls.Cast<Control>().ToList())
            {
                panelContenedor.Controls.Remove(anterior);

                anterior.Dispose();
            }

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
