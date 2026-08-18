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
            txtNombre = new TextBox();
            lblNombre = new Label();
            cmbEstado = new ComboBox();
            lblEstado = new Label();
            cmbRol = new ComboBox();
            txtPassword2 = new TextBox();
            txtPassword = new TextBox();
            txtUsuario = new TextBox();
            lblRol = new Label();
            lblConfirmar = new Label();
            lblContraseña = new Label();
            lblUsuario = new Label();
            btnCancelar = new Button();
            btnGuardar = new Button();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(109, 54);
            txtNombre.Margin = new Padding(3, 2, 3, 2);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(401, 23);
            txtNombre.TabIndex = 17;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9F);
            lblNombre.Location = new Point(31, 59);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 25;
            lblNombre.Text = "Nombre";
            // 
            // cmbEstado
            // 
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Items.AddRange(new object[] { "Activo", "Inactivo" });
            cmbEstado.Location = new Point(109, 206);
            cmbEstado.Margin = new Padding(3, 2, 3, 2);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(401, 23);
            cmbEstado.TabIndex = 23;
            cmbEstado.Text = "Selecione el estado ";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 9F);
            lblEstado.Location = new Point(31, 212);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(42, 15);
            lblEstado.TabIndex = 24;
            lblEstado.Text = "Estado";
            // 
            // cmbRol
            // 
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(109, 172);
            cmbRol.Margin = new Padding(3, 2, 3, 2);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(401, 23);
            cmbRol.TabIndex = 22;
            cmbRol.Text = "Selecione el rol";
            // 
            // txtPassword2
            // 
            txtPassword2.Location = new Point(109, 136);
            txtPassword2.Margin = new Padding(3, 2, 3, 2);
            txtPassword2.Name = "txtPassword2";
            txtPassword2.Size = new Size(401, 23);
            txtPassword2.TabIndex = 21;
            txtPassword2.UseSystemPasswordChar = true;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(109, 96);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(401, 23);
            txtPassword.TabIndex = 19;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(109, 16);
            txtUsuario.Margin = new Padding(3, 2, 3, 2);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(401, 23);
            txtUsuario.TabIndex = 15;
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Segoe UI", 9F);
            lblRol.Location = new Point(31, 178);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(24, 15);
            lblRol.TabIndex = 20;
            lblRol.Text = "Rol";
            // 
            // lblConfirmar
            // 
            lblConfirmar.AutoSize = true;
            lblConfirmar.Font = new Font("Segoe UI", 9F);
            lblConfirmar.Location = new Point(31, 141);
            lblConfirmar.Name = "lblConfirmar";
            lblConfirmar.Size = new Size(61, 15);
            lblConfirmar.TabIndex = 18;
            lblConfirmar.Text = "Confirmar";
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.Font = new Font("Segoe UI", 9F);
            lblContraseña.Location = new Point(31, 101);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(67, 15);
            lblContraseña.TabIndex = 16;
            lblContraseña.Text = "Contraseña";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 9F);
            lblUsuario.Location = new Point(31, 21);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(47, 15);
            lblUsuario.TabIndex = 14;
            lblUsuario.Text = "Usuario";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(309, 259);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(133, 34);
            btnCancelar.TabIndex = 27;
            btnCancelar.Text = "❌ Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.Highlight;
            btnGuardar.Location = new Point(139, 259);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(133, 34);
            btnGuardar.TabIndex = 26;
            btnGuardar.Text = "💾 Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // FrmRegistroUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(545, 356);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(cmbEstado);
            Controls.Add(lblEstado);
            Controls.Add(cmbRol);
            Controls.Add(txtPassword2);
            Controls.Add(txtPassword);
            Controls.Add(txtUsuario);
            Controls.Add(lblRol);
            Controls.Add(lblConfirmar);
            Controls.Add(lblContraseña);
            Controls.Add(lblUsuario);
            Name = "FrmRegistroUsuario";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FrmRegistroUsuario";
            Load += FrmRegistroUsuario_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private Label lblNombre;
        private ComboBox cmbEstado;
        private Label lblEstado;
        private ComboBox cmbRol;
        private TextBox txtPassword2;
        private TextBox txtPassword;
        private TextBox txtUsuario;
        private Label lblRol;
        private Label lblConfirmar;
        private Label lblContraseña;
        private Label lblUsuario;
        private Button btnCancelar;
        private Button btnGuardar;
    }
}