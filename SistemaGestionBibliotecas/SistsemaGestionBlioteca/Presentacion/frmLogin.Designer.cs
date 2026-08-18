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
            pictureBox3 = new PictureBox();
            pictureBox1 = new PictureBox();
            txtPass = new TextBox();
            btnLogin = new Button();
            txtUser = new TextBox();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(35, 160);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(39, 28);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 18;
            pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(35, 119);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(39, 27);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            // 
            // txtPass
            // 
            txtPass.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPass.ForeColor = Color.Black;
            txtPass.Location = new Point(80, 162);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(337, 27);
            txtPass.TabIndex = 13;
            txtPass.Text = "Contraseña";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.MediumPurple;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 192, 255);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(80, 218);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(337, 37);
            btnLogin.TabIndex = 14;
            btnLogin.Text = "Iniciar sesión";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtUser
            // 
            txtUser.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUser.ForeColor = Color.Black;
            txtUser.Location = new Point(80, 119);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(337, 27);
            txtUser.TabIndex = 12;
            txtUser.Text = "Usuario";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(148, 30);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(214, 45);
            lblTitulo.TabIndex = 11;
            lblTitulo.Text = "Iniciar sesión";
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(545, 335);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox1);
            Controls.Add(txtPass);
            Controls.Add(btnLogin);
            Controls.Add(txtUser);
            Controls.Add(lblTitulo);
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmLogin";
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox3;
        private PictureBox pictureBox1;
        private TextBox txtPass;
        private Button btnLogin;
        private TextBox txtUser;
        private Label lblTitulo;
    }
}