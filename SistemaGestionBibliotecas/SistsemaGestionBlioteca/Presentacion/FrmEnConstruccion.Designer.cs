namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    partial class FrmEnConstruccion
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
            lblTitulo = new Label();
            lblMensaje = new Label();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(20, 20, 30);
            lblTitulo.Location = new Point(24, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(110, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Sección";
            //
            // lblMensaje
            //
            lblMensaje.AutoSize = true;
            lblMensaje.Font = new Font("Segoe UI", 11F);
            lblMensaje.ForeColor = Color.FromArgb(80, 100, 130);
            lblMensaje.Location = new Point(28, 68);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(282, 20);
            lblMensaje.TabIndex = 1;
            lblMensaje.Text = "Esta sección todavía está en desarrollo.";
            //
            // FrmEnConstruccion
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 248);
            ClientSize = new Size(1060, 720);
            Controls.Add(lblMensaje);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmEnConstruccion";
            Text = "FrmEnConstruccion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblMensaje;
    }
}
