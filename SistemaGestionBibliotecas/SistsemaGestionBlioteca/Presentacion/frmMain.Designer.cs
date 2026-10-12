namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelContenedor = new Panel();
            panelMenu = new Panel();
            panelButtons = new Panel();
            panelBottom = new Panel();
            btnCerrarSesión = new Button();
            btnReportes = new Button();
            btnReservas = new Button();
            btnDevoluciones = new Button();
            btnPrestamos = new Button();
            btnLibros = new Button();
            btnUsuarios = new Button();
            btnInicio = new Button();
            panelMenu.SuspendLayout();
            panelButtons.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            //
            // panelContenedor
            //
            panelContenedor.BackColor = Color.FromArgb(245, 246, 248);
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(220, 0);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(1146, 768);
            panelContenedor.TabIndex = 1;
            //
            // panelMenu
            //
            panelMenu.BackColor = Color.FromArgb(108, 131, 164);
            panelMenu.Controls.Add(panelButtons);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(220, 768);
            panelMenu.TabIndex = 2;
            //
            // panelButtons
            //
            panelButtons.Controls.Add(panelBottom);
            panelButtons.Controls.Add(btnReportes);
            panelButtons.Controls.Add(btnReservas);
            panelButtons.Controls.Add(btnDevoluciones);
            panelButtons.Controls.Add(btnPrestamos);
            panelButtons.Controls.Add(btnLibros);
            panelButtons.Controls.Add(btnUsuarios);
            panelButtons.Controls.Add(btnInicio);
            panelButtons.Dock = DockStyle.Fill;
            panelButtons.Location = new Point(0, 0);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(0, 24, 0, 0);
            panelButtons.Size = new Size(220, 768);
            panelButtons.TabIndex = 0;
            //
            // panelBottom
            //
            panelBottom.Controls.Add(btnCerrarSesión);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 698);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(220, 70);
            panelBottom.TabIndex = 7;
            //
            // btnCerrarSesión
            //
            btnCerrarSesión.BackColor = Color.FromArgb(108, 131, 164);
            btnCerrarSesión.Cursor = Cursors.Hand;
            btnCerrarSesión.Dock = DockStyle.Fill;
            btnCerrarSesión.FlatAppearance.BorderSize = 0;
            btnCerrarSesión.FlatAppearance.MouseOverBackColor = Color.FromArgb(124, 146, 177);
            btnCerrarSesión.FlatStyle = FlatStyle.Flat;
            btnCerrarSesión.Font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold);
            btnCerrarSesión.ForeColor = Color.White;
            btnCerrarSesión.Location = new Point(0, 0);
            btnCerrarSesión.Name = "btnCerrarSesión";
            btnCerrarSesión.Padding = new Padding(22, 0, 0, 0);
            btnCerrarSesión.Size = new Size(220, 70);
            btnCerrarSesión.TabIndex = 7;
            btnCerrarSesión.Text = "🚪   Cerrar sesión";
            btnCerrarSesión.TextAlign = ContentAlignment.MiddleLeft;
            btnCerrarSesión.UseVisualStyleBackColor = false;
            btnCerrarSesión.Click += btnCerrarSesión_Click;
            //
            // btnReportes
            //
            btnReportes.BackColor = Color.FromArgb(108, 131, 164);
            btnReportes.Cursor = Cursors.Hand;
            btnReportes.Dock = DockStyle.Top;
            btnReportes.FlatAppearance.BorderSize = 0;
            btnReportes.FlatAppearance.MouseOverBackColor = Color.FromArgb(124, 146, 177);
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold);
            btnReportes.ForeColor = Color.White;
            btnReportes.Location = new Point(0, 340);
            btnReportes.Name = "btnReportes";
            btnReportes.Padding = new Padding(22, 0, 0, 0);
            btnReportes.Size = new Size(220, 52);
            btnReportes.TabIndex = 6;
            btnReportes.Text = "📊   Reportes";
            btnReportes.TextAlign = ContentAlignment.MiddleLeft;
            btnReportes.UseVisualStyleBackColor = false;
            btnReportes.Click += btnReportes_Click;
            //
            // btnReservas
            //
            btnReservas.BackColor = Color.FromArgb(108, 131, 164);
            btnReservas.Cursor = Cursors.Hand;
            btnReservas.Dock = DockStyle.Top;
            btnReservas.FlatAppearance.BorderSize = 0;
            btnReservas.FlatAppearance.MouseOverBackColor = Color.FromArgb(124, 146, 177);
            btnReservas.FlatStyle = FlatStyle.Flat;
            btnReservas.Font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold);
            btnReservas.ForeColor = Color.White;
            btnReservas.Location = new Point(0, 288);
            btnReservas.Name = "btnReservas";
            btnReservas.Padding = new Padding(22, 0, 0, 0);
            btnReservas.Size = new Size(220, 52);
            btnReservas.TabIndex = 5;
            btnReservas.Text = "📅   Reservas";
            btnReservas.TextAlign = ContentAlignment.MiddleLeft;
            btnReservas.UseVisualStyleBackColor = false;
            btnReservas.Click += btnReservas_Click;
            //
            // btnDevoluciones
            //
            btnDevoluciones.BackColor = Color.FromArgb(108, 131, 164);
            btnDevoluciones.Cursor = Cursors.Hand;
            btnDevoluciones.Dock = DockStyle.Top;
            btnDevoluciones.FlatAppearance.BorderSize = 0;
            btnDevoluciones.FlatAppearance.MouseOverBackColor = Color.FromArgb(124, 146, 177);
            btnDevoluciones.FlatStyle = FlatStyle.Flat;
            btnDevoluciones.Font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold);
            btnDevoluciones.ForeColor = Color.White;
            btnDevoluciones.Location = new Point(0, 236);
            btnDevoluciones.Name = "btnDevoluciones";
            btnDevoluciones.Padding = new Padding(22, 0, 0, 0);
            btnDevoluciones.Size = new Size(220, 52);
            btnDevoluciones.TabIndex = 4;
            btnDevoluciones.Text = "↩   Devoluciones";
            btnDevoluciones.TextAlign = ContentAlignment.MiddleLeft;
            btnDevoluciones.UseVisualStyleBackColor = false;
            btnDevoluciones.Click += btnDevoluciones_Click;
            //
            // btnPrestamos
            //
            btnPrestamos.BackColor = Color.FromArgb(108, 131, 164);
            btnPrestamos.Cursor = Cursors.Hand;
            btnPrestamos.Dock = DockStyle.Top;
            btnPrestamos.FlatAppearance.BorderSize = 0;
            btnPrestamos.FlatAppearance.MouseOverBackColor = Color.FromArgb(124, 146, 177);
            btnPrestamos.FlatStyle = FlatStyle.Flat;
            btnPrestamos.Font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold);
            btnPrestamos.ForeColor = Color.White;
            btnPrestamos.Location = new Point(0, 184);
            btnPrestamos.Name = "btnPrestamos";
            btnPrestamos.Padding = new Padding(22, 0, 0, 0);
            btnPrestamos.Size = new Size(220, 52);
            btnPrestamos.TabIndex = 3;
            btnPrestamos.Text = "🔁   Préstamos";
            btnPrestamos.TextAlign = ContentAlignment.MiddleLeft;
            btnPrestamos.UseVisualStyleBackColor = false;
            btnPrestamos.Click += btnPrestamos_Click;
            //
            // btnLibros
            //
            btnLibros.BackColor = Color.FromArgb(108, 131, 164);
            btnLibros.Cursor = Cursors.Hand;
            btnLibros.Dock = DockStyle.Top;
            btnLibros.FlatAppearance.BorderSize = 0;
            btnLibros.FlatAppearance.MouseOverBackColor = Color.FromArgb(124, 146, 177);
            btnLibros.FlatStyle = FlatStyle.Flat;
            btnLibros.Font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold);
            btnLibros.ForeColor = Color.White;
            btnLibros.Location = new Point(0, 132);
            btnLibros.Name = "btnLibros";
            btnLibros.Padding = new Padding(22, 0, 0, 0);
            btnLibros.Size = new Size(220, 52);
            btnLibros.TabIndex = 2;
            btnLibros.Text = "📖   Libros";
            btnLibros.TextAlign = ContentAlignment.MiddleLeft;
            btnLibros.UseVisualStyleBackColor = false;
            btnLibros.Click += btnLibros_Click;
            //
            // btnUsuarios
            //
            btnUsuarios.BackColor = Color.FromArgb(108, 131, 164);
            btnUsuarios.Cursor = Cursors.Hand;
            btnUsuarios.Dock = DockStyle.Top;
            btnUsuarios.FlatAppearance.BorderSize = 0;
            btnUsuarios.FlatAppearance.MouseOverBackColor = Color.FromArgb(124, 146, 177);
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.Font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold);
            btnUsuarios.ForeColor = Color.White;
            btnUsuarios.Location = new Point(0, 76);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Padding = new Padding(22, 0, 0, 0);
            btnUsuarios.Size = new Size(220, 52);
            btnUsuarios.TabIndex = 1;
            btnUsuarios.Text = "👤   Usuarios";
            btnUsuarios.TextAlign = ContentAlignment.MiddleLeft;
            btnUsuarios.UseVisualStyleBackColor = false;
            btnUsuarios.Click += btnUsuarios_Click;
            //
            // btnInicio
            //
            btnInicio.BackColor = Color.FromArgb(30, 144, 255);
            btnInicio.Cursor = Cursors.Hand;
            btnInicio.Dock = DockStyle.Top;
            btnInicio.FlatAppearance.BorderSize = 0;
            btnInicio.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 144, 255);
            btnInicio.FlatStyle = FlatStyle.Flat;
            btnInicio.Font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold);
            btnInicio.ForeColor = Color.White;
            btnInicio.Location = new Point(0, 24);
            btnInicio.Name = "btnInicio";
            btnInicio.Padding = new Padding(22, 0, 0, 0);
            btnInicio.Size = new Size(220, 52);
            btnInicio.TabIndex = 0;
            btnInicio.Text = "🏠   Inicio";
            btnInicio.TextAlign = ContentAlignment.MiddleLeft;
            btnInicio.UseVisualStyleBackColor = false;
            btnInicio.Click += btnInicio_Click;
            //
            // frmMain
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1366, 768);
            Controls.Add(panelContenedor);
            Controls.Add(panelMenu);
            MinimumSize = new Size(1000, 640);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Gestión de Biblioteca";
            Load += frmMain_Load;
            panelMenu.ResumeLayout(false);
            panelButtons.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panelContenedor;
        private Panel panelMenu;
        private Panel panelButtons;
        private Panel panelBottom;
        private Button btnCerrarSesión;
        private Button btnReportes;
        private Button btnReservas;
        private Button btnDevoluciones;
        private Button btnPrestamos;
        private Button btnLibros;
        private Button btnUsuarios;
        private Button btnInicio;
    }
}
