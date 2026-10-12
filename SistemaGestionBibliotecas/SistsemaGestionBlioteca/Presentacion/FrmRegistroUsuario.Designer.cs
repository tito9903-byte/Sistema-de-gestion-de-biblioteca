namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    partial class FrmRegistroUsuario
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
            tlpFormulario = new TableLayoutPanel();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblRol = new Label();
            lblEstado = new Label();
            cmbRol = new ComboBox();
            cmbEstado = new ComboBox();
            lblContraseña = new Label();
            panelPassword = new Controles.PanelTarjeta();
            txtPassword = new TextBox();
            lblMostrarPassword = new Label();
            lblConfirmar = new Label();
            txtPassword2 = new TextBox();
            tlpBotones = new TableLayoutPanel();
            btnGuardar = new Button();
            btnLimpiar = new Button();
            btnCancelar = new Button();
            tlpFormulario.SuspendLayout();
            panelPassword.SuspendLayout();
            tlpBotones.SuspendLayout();
            SuspendLayout();
            //
            // tlpFormulario
            //
            tlpFormulario.ColumnCount = 2;
            tlpFormulario.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpFormulario.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpFormulario.Controls.Add(lblNombre, 0, 0);
            tlpFormulario.Controls.Add(txtNombre, 0, 1);
            tlpFormulario.Controls.Add(lblUsuario, 0, 2);
            tlpFormulario.Controls.Add(txtUsuario, 0, 3);
            tlpFormulario.Controls.Add(lblRol, 0, 4);
            tlpFormulario.Controls.Add(lblEstado, 1, 4);
            tlpFormulario.Controls.Add(cmbRol, 0, 5);
            tlpFormulario.Controls.Add(cmbEstado, 1, 5);
            tlpFormulario.Controls.Add(lblContraseña, 0, 6);
            tlpFormulario.Controls.Add(panelPassword, 0, 7);
            tlpFormulario.Controls.Add(lblConfirmar, 0, 8);
            tlpFormulario.Controls.Add(txtPassword2, 0, 9);
            tlpFormulario.Controls.Add(tlpBotones, 0, 10);
            tlpFormulario.Dock = DockStyle.Fill;
            tlpFormulario.Location = new Point(0, 0);
            tlpFormulario.Margin = new Padding(0);
            tlpFormulario.Name = "tlpFormulario";
            tlpFormulario.RowCount = 12;
            tlpFormulario.RowStyles.Add(new RowStyle());
            tlpFormulario.RowStyles.Add(new RowStyle());
            tlpFormulario.RowStyles.Add(new RowStyle());
            tlpFormulario.RowStyles.Add(new RowStyle());
            tlpFormulario.RowStyles.Add(new RowStyle());
            tlpFormulario.RowStyles.Add(new RowStyle());
            tlpFormulario.RowStyles.Add(new RowStyle());
            tlpFormulario.RowStyles.Add(new RowStyle());
            tlpFormulario.RowStyles.Add(new RowStyle());
            tlpFormulario.RowStyles.Add(new RowStyle());
            tlpFormulario.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tlpFormulario.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpFormulario.Size = new Size(380, 520);
            tlpFormulario.TabIndex = 0;
            //
            // lblNombre
            //
            lblNombre.AutoSize = true;
            tlpFormulario.SetColumnSpan(lblNombre, 2);
            lblNombre.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(20, 20, 30);
            lblNombre.Location = new Point(0, 0);
            lblNombre.Margin = new Padding(0, 0, 0, 4);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(70, 19);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre *";
            //
            // txtNombre
            //
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            tlpFormulario.SetColumnSpan(txtNombre, 2);
            txtNombre.Dock = DockStyle.Fill;
            txtNombre.Font = new Font("Segoe UI", 11F);
            txtNombre.Location = new Point(0, 23);
            txtNombre.Margin = new Padding(0, 0, 0, 12);
            txtNombre.MaxLength = 100;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(380, 27);
            txtNombre.TabIndex = 0;
            //
            // lblUsuario
            //
            lblUsuario.AutoSize = true;
            tlpFormulario.SetColumnSpan(lblUsuario, 2);
            lblUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUsuario.ForeColor = Color.FromArgb(20, 20, 30);
            lblUsuario.Location = new Point(0, 62);
            lblUsuario.Margin = new Padding(0, 0, 0, 4);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(68, 19);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario *";
            //
            // txtUsuario
            //
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            tlpFormulario.SetColumnSpan(txtUsuario, 2);
            txtUsuario.Dock = DockStyle.Fill;
            txtUsuario.Font = new Font("Segoe UI", 11F);
            txtUsuario.Location = new Point(0, 85);
            txtUsuario.Margin = new Padding(0, 0, 0, 12);
            txtUsuario.MaxLength = 50;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(380, 27);
            txtUsuario.TabIndex = 1;
            //
            // lblRol
            //
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRol.ForeColor = Color.FromArgb(20, 20, 30);
            lblRol.Location = new Point(0, 124);
            lblRol.Margin = new Padding(0, 0, 0, 4);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(36, 19);
            lblRol.TabIndex = 2;
            lblRol.Text = "Rol *";
            //
            // lblEstado
            //
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEstado.ForeColor = Color.FromArgb(20, 20, 30);
            lblEstado.Location = new Point(198, 124);
            lblEstado.Margin = new Padding(8, 0, 0, 4);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(58, 19);
            lblEstado.TabIndex = 3;
            lblEstado.Text = "Estado *";
            //
            // cmbRol
            //
            cmbRol.Dock = DockStyle.Fill;
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.Font = new Font("Segoe UI", 11F);
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(0, 147);
            cmbRol.Margin = new Padding(0, 0, 0, 12);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(190, 28);
            cmbRol.TabIndex = 2;
            //
            // cmbEstado
            //
            cmbEstado.Dock = DockStyle.Fill;
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Font = new Font("Segoe UI", 11F);
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(198, 147);
            cmbEstado.Margin = new Padding(8, 0, 0, 12);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(182, 28);
            cmbEstado.TabIndex = 3;
            //
            // lblContraseña
            //
            lblContraseña.AutoSize = true;
            tlpFormulario.SetColumnSpan(lblContraseña, 2);
            lblContraseña.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblContraseña.ForeColor = Color.FromArgb(20, 20, 30);
            lblContraseña.Location = new Point(0, 187);
            lblContraseña.Margin = new Padding(0, 0, 0, 4);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(84, 19);
            lblContraseña.TabIndex = 4;
            lblContraseña.Text = "Contraseña";
            //
            // panelPassword
            //
            panelPassword.BackColor = Color.White;
            panelPassword.ColorBorde = Color.FromArgb(120, 120, 120);
            panelPassword.Controls.Add(txtPassword);
            panelPassword.Controls.Add(lblMostrarPassword);
            tlpFormulario.SetColumnSpan(panelPassword, 2);
            panelPassword.Dock = DockStyle.Fill;
            panelPassword.Location = new Point(0, 210);
            panelPassword.Margin = new Padding(0, 0, 0, 12);
            panelPassword.Name = "panelPassword";
            panelPassword.Padding = new Padding(6, 4, 0, 0);
            panelPassword.Size = new Size(380, 28);
            panelPassword.TabIndex = 4;
            //
            // txtPassword
            //
            txtPassword.BackColor = Color.White;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Dock = DockStyle.Fill;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(6, 4);
            txtPassword.MaxLength = 100;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(334, 20);
            txtPassword.TabIndex = 0;
            txtPassword.UseSystemPasswordChar = true;
            //
            // lblMostrarPassword
            //
            lblMostrarPassword.BackColor = Color.Transparent;
            lblMostrarPassword.Cursor = Cursors.Hand;
            lblMostrarPassword.Dock = DockStyle.Right;
            lblMostrarPassword.Font = new Font("Segoe MDL2 Assets", 12F, FontStyle.Strikeout);
            lblMostrarPassword.ForeColor = Color.FromArgb(70, 90, 125);
            lblMostrarPassword.Location = new Point(340, 4);
            lblMostrarPassword.Name = "lblMostrarPassword";
            lblMostrarPassword.Size = new Size(40, 24);
            lblMostrarPassword.TabIndex = 1;
            lblMostrarPassword.Text = "";
            lblMostrarPassword.TextAlign = ContentAlignment.TopCenter;
            lblMostrarPassword.Click += lblMostrarPassword_Click;
            //
            // lblConfirmar
            //
            lblConfirmar.AutoSize = true;
            tlpFormulario.SetColumnSpan(lblConfirmar, 2);
            lblConfirmar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblConfirmar.ForeColor = Color.FromArgb(20, 20, 30);
            lblConfirmar.Location = new Point(0, 250);
            lblConfirmar.Margin = new Padding(0, 0, 0, 4);
            lblConfirmar.Name = "lblConfirmar";
            lblConfirmar.Size = new Size(142, 19);
            lblConfirmar.TabIndex = 5;
            lblConfirmar.Text = "Confirmar contraseña";
            //
            // txtPassword2
            //
            txtPassword2.BorderStyle = BorderStyle.FixedSingle;
            tlpFormulario.SetColumnSpan(txtPassword2, 2);
            txtPassword2.Dock = DockStyle.Fill;
            txtPassword2.Font = new Font("Segoe UI", 11F);
            txtPassword2.Location = new Point(0, 273);
            txtPassword2.Margin = new Padding(0, 0, 0, 18);
            txtPassword2.MaxLength = 100;
            txtPassword2.Name = "txtPassword2";
            txtPassword2.Size = new Size(380, 27);
            txtPassword2.TabIndex = 5;
            txtPassword2.UseSystemPasswordChar = true;
            //
            // tlpBotones
            //
            tlpBotones.ColumnCount = 3;
            tlpFormulario.SetColumnSpan(tlpBotones, 2);
            tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tlpBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tlpBotones.Controls.Add(btnGuardar, 0, 0);
            tlpBotones.Controls.Add(btnLimpiar, 1, 0);
            tlpBotones.Controls.Add(btnCancelar, 2, 0);
            tlpBotones.Dock = DockStyle.Fill;
            tlpBotones.Location = new Point(0, 318);
            tlpBotones.Margin = new Padding(0);
            tlpBotones.Name = "tlpBotones";
            tlpBotones.RowCount = 1;
            tlpBotones.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpBotones.Size = new Size(380, 48);
            tlpBotones.TabIndex = 6;
            //
            // btnGuardar
            //
            btnGuardar.BackColor = Color.FromArgb(0, 120, 235);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.Dock = DockStyle.Fill;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 140, 250);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(0, 0);
            btnGuardar.Margin = new Padding(0, 0, 6, 0);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(123, 48);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "💾 Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            //
            // btnLimpiar
            //
            btnLimpiar.BackColor = Color.White;
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.Dock = DockStyle.Fill;
            btnLimpiar.FlatAppearance.BorderColor = Color.FromArgb(200, 205, 214);
            btnLimpiar.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 243, 248);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI", 10.5F);
            btnLimpiar.ForeColor = Color.FromArgb(30, 40, 60);
            btnLimpiar.Location = new Point(129, 0);
            btnLimpiar.Margin = new Padding(0, 0, 6, 0);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(119, 48);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "↻ Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            //
            // btnCancelar
            //
            btnCancelar.BackColor = Color.White;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Dock = DockStyle.Fill;
            btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(225, 80, 90);
            btnCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(254, 240, 241);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 10.5F);
            btnCancelar.ForeColor = Color.FromArgb(200, 30, 45);
            btnCancelar.Location = new Point(254, 0);
            btnCancelar.Margin = new Padding(0);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(126, 48);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "✖ Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            //
            // FrmRegistroUsuario
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(380, 520);
            Controls.Add(tlpFormulario);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmRegistroUsuario";
            Text = "Nuevo usuario";
            tlpFormulario.ResumeLayout(false);
            tlpFormulario.PerformLayout();
            panelPassword.ResumeLayout(false);
            panelPassword.PerformLayout();
            tlpBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpFormulario;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblRol;
        private Label lblEstado;
        private ComboBox cmbRol;
        private ComboBox cmbEstado;
        private Label lblContraseña;
        private Controles.PanelTarjeta panelPassword;
        private TextBox txtPassword;
        private Label lblMostrarPassword;
        private Label lblConfirmar;
        private TextBox txtPassword2;
        private TableLayoutPanel tlpBotones;
        private Button btnGuardar;
        private Button btnLimpiar;
        private Button btnCancelar;
    }
}
