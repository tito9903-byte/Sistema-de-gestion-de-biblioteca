namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            panelDerecho = new Panel();
            panelFormulario = new Panel();
            lnkOlvideClave = new LinkLabel();
            btnLogin = new Button();
            panelPass = new Controles.PanelTarjeta();
            txtPass = new TextBox();
            pbMostrarPass = new Label();
            lblIconoPass = new Label();
            lblPass = new Label();
            panelUsuario = new Controles.PanelTarjeta();
            txtUser = new TextBox();
            lblIconoUsuario = new Label();
            lblUsuario = new Label();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            panelIzquierdo = new Panel();
            pbIlustracion = new PictureBox();
            lblNombreSistema = new Label();
            lblLema = new Label();
            panelDerecho.SuspendLayout();
            panelFormulario.SuspendLayout();
            panelPass.SuspendLayout();
            panelUsuario.SuspendLayout();
            panelIzquierdo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbIlustracion).BeginInit();
            SuspendLayout();
            //
            // panelDerecho
            //
            panelDerecho.BackColor = Color.FromArgb(244, 245, 247);
            panelDerecho.Controls.Add(panelFormulario);
            panelDerecho.Dock = DockStyle.Fill;
            panelDerecho.Location = new Point(380, 0);
            panelDerecho.Name = "panelDerecho";
            panelDerecho.Size = new Size(580, 540);
            panelDerecho.TabIndex = 1;
            //
            // panelFormulario
            //
            panelFormulario.Anchor = AnchorStyles.None;
            panelFormulario.Controls.Add(lnkOlvideClave);
            panelFormulario.Controls.Add(btnLogin);
            panelFormulario.Controls.Add(panelPass);
            panelFormulario.Controls.Add(lblPass);
            panelFormulario.Controls.Add(panelUsuario);
            panelFormulario.Controls.Add(lblUsuario);
            panelFormulario.Controls.Add(lblSubtitulo);
            panelFormulario.Controls.Add(lblTitulo);
            panelFormulario.Location = new Point(70, 60);
            panelFormulario.Name = "panelFormulario";
            panelFormulario.Size = new Size(440, 420);
            panelFormulario.TabIndex = 0;
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(10, 20, 45);
            lblTitulo.Location = new Point(-2, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(247, 51);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Iniciar sesión";
            //
            // lblSubtitulo
            //
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 11.5F);
            lblSubtitulo.ForeColor = Color.FromArgb(75, 95, 130);
            lblSubtitulo.Location = new Point(0, 58);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(366, 21);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Ingrese sus credenciales para acceder al sistema.";
            //
            // lblUsuario
            //
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblUsuario.ForeColor = Color.FromArgb(10, 20, 45);
            lblUsuario.Location = new Point(0, 112);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(66, 21);
            lblUsuario.TabIndex = 2;
            lblUsuario.Text = "Usuario";
            //
            // panelUsuario
            //
            panelUsuario.BackColor = Color.FromArgb(252, 252, 253);
            panelUsuario.ColorBorde = Color.FromArgb(205, 210, 218);
            panelUsuario.Controls.Add(txtUser);
            panelUsuario.Controls.Add(lblIconoUsuario);
            panelUsuario.Location = new Point(0, 140);
            panelUsuario.Name = "panelUsuario";
            panelUsuario.Padding = new Padding(0, 14, 12, 0);
            panelUsuario.Size = new Size(440, 50);
            panelUsuario.TabIndex = 0;
            //
            // txtUser
            //
            txtUser.BackColor = Color.FromArgb(252, 252, 253);
            txtUser.BorderStyle = BorderStyle.None;
            txtUser.Dock = DockStyle.Fill;
            txtUser.Font = new Font("Segoe UI", 12F);
            txtUser.ForeColor = Color.Black;
            txtUser.Location = new Point(48, 14);
            txtUser.Name = "txtUser";
            txtUser.PlaceholderText = "Ingrese su usuario";
            txtUser.Size = new Size(380, 22);
            txtUser.TabIndex = 0;
            //
            // lblIconoUsuario
            //
            lblIconoUsuario.BackColor = Color.Transparent;
            lblIconoUsuario.Dock = DockStyle.Left;
            lblIconoUsuario.Font = new Font("Segoe MDL2 Assets", 15F);
            lblIconoUsuario.ForeColor = Color.FromArgb(70, 90, 125);
            lblIconoUsuario.Location = new Point(0, 14);
            lblIconoUsuario.Name = "lblIconoUsuario";
            lblIconoUsuario.Size = new Size(48, 36);
            lblIconoUsuario.TabIndex = 1;
            lblIconoUsuario.Text = "";
            lblIconoUsuario.TextAlign = ContentAlignment.TopCenter;
            //
            // lblPass
            //
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPass.ForeColor = Color.FromArgb(10, 20, 45);
            lblPass.Location = new Point(0, 208);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(94, 21);
            lblPass.TabIndex = 3;
            lblPass.Text = "Contraseña";
            //
            // panelPass
            //
            panelPass.BackColor = Color.FromArgb(252, 252, 253);
            panelPass.ColorBorde = Color.FromArgb(205, 210, 218);
            panelPass.Controls.Add(txtPass);
            panelPass.Controls.Add(pbMostrarPass);
            panelPass.Controls.Add(lblIconoPass);
            panelPass.Location = new Point(0, 236);
            panelPass.Name = "panelPass";
            panelPass.Padding = new Padding(0, 14, 0, 0);
            panelPass.Size = new Size(440, 50);
            panelPass.TabIndex = 1;
            //
            // txtPass
            //
            txtPass.BackColor = Color.FromArgb(252, 252, 253);
            txtPass.BorderStyle = BorderStyle.None;
            txtPass.Dock = DockStyle.Fill;
            txtPass.Font = new Font("Segoe UI", 12F);
            txtPass.ForeColor = Color.Black;
            txtPass.Location = new Point(48, 14);
            txtPass.Name = "txtPass";
            txtPass.PlaceholderText = "Ingrese su contraseña";
            txtPass.Size = new Size(344, 22);
            txtPass.TabIndex = 0;
            txtPass.UseSystemPasswordChar = true;
            //
            // pbMostrarPass
            //
            pbMostrarPass.BackColor = Color.Transparent;
            pbMostrarPass.Cursor = Cursors.Hand;
            pbMostrarPass.Dock = DockStyle.Right;
            pbMostrarPass.Font = new Font("Segoe MDL2 Assets", 15F, FontStyle.Strikeout);
            pbMostrarPass.ForeColor = Color.FromArgb(70, 90, 125);
            pbMostrarPass.Location = new Point(392, 14);
            pbMostrarPass.Name = "pbMostrarPass";
            pbMostrarPass.Size = new Size(48, 36);
            pbMostrarPass.TabIndex = 2;
            pbMostrarPass.Text = "";
            pbMostrarPass.TextAlign = ContentAlignment.TopCenter;
            pbMostrarPass.Click += pbMostrarPass_Click;
            //
            // lblIconoPass
            //
            lblIconoPass.BackColor = Color.Transparent;
            lblIconoPass.Dock = DockStyle.Left;
            lblIconoPass.Font = new Font("Segoe MDL2 Assets", 15F);
            lblIconoPass.ForeColor = Color.FromArgb(70, 90, 125);
            lblIconoPass.Location = new Point(0, 14);
            lblIconoPass.Name = "lblIconoPass";
            lblIconoPass.Size = new Size(48, 36);
            lblIconoPass.TabIndex = 1;
            lblIconoPass.Text = "";
            lblIconoPass.TextAlign = ContentAlignment.TopCenter;
            //
            // btnLogin
            //
            btnLogin.BackColor = Color.FromArgb(0, 108, 214);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 80, 170);
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 125, 230);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(0, 316);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(440, 54);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "➜   Iniciar sesión";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            //
            // lnkOlvideClave
            //
            lnkOlvideClave.ActiveLinkColor = Color.FromArgb(0, 80, 170);
            lnkOlvideClave.AutoSize = true;
            lnkOlvideClave.Font = new Font("Segoe UI", 10F);
            lnkOlvideClave.LinkColor = Color.FromArgb(0, 90, 190);
            lnkOlvideClave.Location = new Point(0, 386);
            lnkOlvideClave.Name = "lnkOlvideClave";
            lnkOlvideClave.Size = new Size(164, 19);
            lnkOlvideClave.TabIndex = 3;
            lnkOlvideClave.TabStop = true;
            lnkOlvideClave.Text = "¿Olvidó su contraseña?";
            lnkOlvideClave.LinkClicked += lnkOlvideClave_LinkClicked;
            //
            // panelIzquierdo
            //
            panelIzquierdo.BackColor = Color.FromArgb(183, 201, 222);
            panelIzquierdo.Controls.Add(pbIlustracion);
            panelIzquierdo.Controls.Add(lblNombreSistema);
            panelIzquierdo.Controls.Add(lblLema);
            panelIzquierdo.Dock = DockStyle.Left;
            panelIzquierdo.Location = new Point(0, 0);
            panelIzquierdo.Name = "panelIzquierdo";
            panelIzquierdo.Padding = new Padding(10, 10, 10, 24);
            panelIzquierdo.Size = new Size(380, 540);
            panelIzquierdo.TabIndex = 0;
            //
            // pbIlustracion
            //
            pbIlustracion.BackColor = Color.Transparent;
            pbIlustracion.Dock = DockStyle.Fill;
            pbIlustracion.Image = (Image)resources.GetObject("pbIlustracion.Image");
            pbIlustracion.Location = new Point(10, 10);
            pbIlustracion.Name = "pbIlustracion";
            pbIlustracion.Size = new Size(360, 316);
            pbIlustracion.SizeMode = PictureBoxSizeMode.Zoom;
            pbIlustracion.TabIndex = 0;
            pbIlustracion.TabStop = false;
            //
            // lblNombreSistema
            //
            lblNombreSistema.Dock = DockStyle.Bottom;
            lblNombreSistema.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            lblNombreSistema.ForeColor = Color.FromArgb(10, 20, 45);
            lblNombreSistema.Location = new Point(10, 326);
            lblNombreSistema.Name = "lblNombreSistema";
            lblNombreSistema.Size = new Size(360, 100);
            lblNombreSistema.TabIndex = 1;
            lblNombreSistema.Text = "Sistema de Gestión de Biblioteca";
            lblNombreSistema.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblLema
            //
            lblLema.Dock = DockStyle.Bottom;
            lblLema.Font = new Font("Segoe UI", 11.5F);
            lblLema.ForeColor = Color.FromArgb(55, 75, 110);
            lblLema.Location = new Point(10, 426);
            lblLema.Name = "lblLema";
            lblLema.Size = new Size(360, 90);
            lblLema.TabIndex = 2;
            lblLema.Text = "Gestión eficiente de libros, usuarios y préstamos.";
            lblLema.TextAlign = ContentAlignment.TopCenter;
            //
            // frmLogin
            //
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 540);
            Controls.Add(panelDerecho);
            Controls.Add(panelIzquierdo);
            MinimumSize = new Size(820, 520);
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Gestión de Biblioteca";
            panelDerecho.ResumeLayout(false);
            panelFormulario.ResumeLayout(false);
            panelFormulario.PerformLayout();
            panelPass.ResumeLayout(false);
            panelPass.PerformLayout();
            panelUsuario.ResumeLayout(false);
            panelUsuario.PerformLayout();
            panelIzquierdo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbIlustracion).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelDerecho;
        private Panel panelFormulario;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblUsuario;
        private Controles.PanelTarjeta panelUsuario;
        private TextBox txtUser;
        private Label lblIconoUsuario;
        private Label lblPass;
        private Controles.PanelTarjeta panelPass;
        private TextBox txtPass;
        private Label pbMostrarPass;
        private Label lblIconoPass;
        private Button btnLogin;
        private LinkLabel lnkOlvideClave;
        private Panel panelIzquierdo;
        private PictureBox pbIlustracion;
        private Label lblNombreSistema;
        private Label lblLema;
    }
}
