namespace SistemaDeGestionDeBiblioteca.Presentacion.Controles
{
    partial class TarjetaResumen
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblIcono = new Label();
            lblTitulo = new Label();
            lblValor = new Label();
            lblDescripcion = new Label();
            SuspendLayout();
            //
            // lblIcono
            //
            lblIcono.BackColor = Color.Transparent;
            lblIcono.Font = new Font("Segoe MDL2 Assets", 22F);
            lblIcono.ForeColor = Color.FromArgb(21, 85, 170);
            lblIcono.Location = new Point(14, 16);
            lblIcono.Name = "lblIcono";
            lblIcono.Size = new Size(56, 56);
            lblIcono.TabIndex = 0;
            lblIcono.Text = "";
            lblIcono.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Segoe UI", 10F);
            lblTitulo.ForeColor = Color.FromArgb(30, 30, 30);
            lblTitulo.Location = new Point(76, 16);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(48, 20);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Título";
            //
            // lblValor
            //
            lblValor.AutoSize = true;
            lblValor.BackColor = Color.Transparent;
            lblValor.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblValor.ForeColor = Color.FromArgb(21, 85, 170);
            lblValor.Location = new Point(72, 32);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(46, 47);
            lblValor.TabIndex = 2;
            lblValor.Text = "0";
            //
            // lblDescripcion
            //
            lblDescripcion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDescripcion.BackColor = Color.Transparent;
            lblDescripcion.AutoEllipsis = true;
            lblDescripcion.Font = new Font("Segoe UI", 9.5F);
            lblDescripcion.ForeColor = Color.FromArgb(95, 110, 135);
            lblDescripcion.Location = new Point(14, 88);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(222, 22);
            lblDescripcion.TabIndex = 3;
            lblDescripcion.Text = "Descripción";
            //
            // TarjetaResumen
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblDescripcion);
            Controls.Add(lblValor);
            Controls.Add(lblTitulo);
            Controls.Add(lblIcono);
            Name = "TarjetaResumen";
            Size = new Size(250, 124);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIcono;
        private Label lblTitulo;
        private Label lblValor;
        private Label lblDescripcion;
    }
}
