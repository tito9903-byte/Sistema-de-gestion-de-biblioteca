namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    partial class FrmRegistroLibro
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
            lblEncabezado = new Label();
            lblTitulo = new Label();
            txtTitulo = new TextBox();
            lblAutor = new Label();
            txtAutor = new TextBox();
            lblIsbn = new Label();
            txtIsbn = new TextBox();
            lblEditorial = new Label();
            txtEditorial = new TextBox();
            lblCategoria = new Label();
            cmbCategoria = new ComboBox();
            lblAnio = new Label();
            nudAnio = new NumericUpDown();
            lblEjemplares = new Label();
            nudEjemplares = new NumericUpDown();
            lblEstado = new Label();
            cmbEstado = new ComboBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudAnio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudEjemplares).BeginInit();
            SuspendLayout();
            //
            // lblEncabezado
            //
            lblEncabezado.AutoSize = true;
            lblEncabezado.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblEncabezado.ForeColor = Color.FromArgb(20, 20, 30);
            lblEncabezado.Location = new Point(28, 20);
            lblEncabezado.Name = "lblEncabezado";
            lblEncabezado.Size = new Size(188, 32);
            lblEncabezado.TabIndex = 0;
            lblEncabezado.Text = "Registrar libro";
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTitulo.Location = new Point(30, 80);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(41, 19);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Título";
            //
            // txtTitulo
            //
            txtTitulo.Font = new Font("Segoe UI", 11F);
            txtTitulo.Location = new Point(30, 102);
            txtTitulo.MaxLength = 200;
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(460, 27);
            txtTitulo.TabIndex = 0;
            //
            // lblAutor
            //
            lblAutor.AutoSize = true;
            lblAutor.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAutor.Location = new Point(30, 146);
            lblAutor.Name = "lblAutor";
            lblAutor.Size = new Size(44, 19);
            lblAutor.TabIndex = 2;
            lblAutor.Text = "Autor";
            //
            // txtAutor
            //
            txtAutor.Font = new Font("Segoe UI", 11F);
            txtAutor.Location = new Point(30, 168);
            txtAutor.MaxLength = 150;
            txtAutor.Name = "txtAutor";
            txtAutor.Size = new Size(460, 27);
            txtAutor.TabIndex = 1;
            //
            // lblIsbn
            //
            lblIsbn.AutoSize = true;
            lblIsbn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblIsbn.Location = new Point(30, 212);
            lblIsbn.Name = "lblIsbn";
            lblIsbn.Size = new Size(36, 19);
            lblIsbn.TabIndex = 3;
            lblIsbn.Text = "ISBN";
            //
            // txtIsbn
            //
            txtIsbn.Font = new Font("Segoe UI", 11F);
            txtIsbn.Location = new Point(30, 234);
            txtIsbn.MaxLength = 20;
            txtIsbn.Name = "txtIsbn";
            txtIsbn.PlaceholderText = "Opcional";
            txtIsbn.Size = new Size(220, 27);
            txtIsbn.TabIndex = 2;
            //
            // lblEditorial
            //
            lblEditorial.AutoSize = true;
            lblEditorial.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEditorial.Location = new Point(270, 212);
            lblEditorial.Name = "lblEditorial";
            lblEditorial.Size = new Size(61, 19);
            lblEditorial.TabIndex = 4;
            lblEditorial.Text = "Editorial";
            //
            // txtEditorial
            //
            txtEditorial.Font = new Font("Segoe UI", 11F);
            txtEditorial.Location = new Point(270, 234);
            txtEditorial.MaxLength = 100;
            txtEditorial.Name = "txtEditorial";
            txtEditorial.PlaceholderText = "Opcional";
            txtEditorial.Size = new Size(220, 27);
            txtEditorial.TabIndex = 3;
            //
            // lblCategoria
            //
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCategoria.Location = new Point(30, 278);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(70, 19);
            lblCategoria.TabIndex = 5;
            lblCategoria.Text = "Categoría";
            //
            // cmbCategoria
            //
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.Font = new Font("Segoe UI", 11F);
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(30, 300);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(460, 28);
            cmbCategoria.TabIndex = 4;
            //
            // lblAnio
            //
            lblAnio.AutoSize = true;
            lblAnio.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAnio.Location = new Point(30, 344);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new Size(34, 19);
            lblAnio.TabIndex = 6;
            lblAnio.Text = "Año";
            //
            // nudAnio
            //
            nudAnio.Font = new Font("Segoe UI", 11F);
            nudAnio.Location = new Point(30, 366);
            nudAnio.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            nudAnio.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudAnio.Name = "nudAnio";
            nudAnio.Size = new Size(140, 27);
            nudAnio.TabIndex = 5;
            nudAnio.Value = new decimal(new int[] { 2020, 0, 0, 0 });
            //
            // lblEjemplares
            //
            lblEjemplares.AutoSize = true;
            lblEjemplares.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEjemplares.Location = new Point(190, 344);
            lblEjemplares.Name = "lblEjemplares";
            lblEjemplares.Size = new Size(76, 19);
            lblEjemplares.TabIndex = 7;
            lblEjemplares.Text = "Ejemplares";
            //
            // nudEjemplares
            //
            nudEjemplares.Font = new Font("Segoe UI", 11F);
            nudEjemplares.Location = new Point(190, 366);
            nudEjemplares.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            nudEjemplares.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudEjemplares.Name = "nudEjemplares";
            nudEjemplares.Size = new Size(140, 27);
            nudEjemplares.TabIndex = 6;
            nudEjemplares.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // lblEstado
            //
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEstado.Location = new Point(350, 344);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(48, 19);
            lblEstado.TabIndex = 8;
            lblEstado.Text = "Estado";
            //
            // cmbEstado
            //
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Font = new Font("Segoe UI", 11F);
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(350, 366);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(140, 28);
            cmbEstado.TabIndex = 7;
            //
            // btnGuardar
            //
            btnGuardar.BackColor = Color.FromArgb(0, 120, 235);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 140, 250);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(30, 436);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(220, 46);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            //
            // btnCancelar
            //
            btnCancelar.BackColor = Color.FromArgb(176, 196, 222);
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(195, 212, 232);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 11F);
            btnCancelar.ForeColor = Color.Black;
            btnCancelar.Location = new Point(270, 436);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(220, 46);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            //
            // FrmRegistroLibro
            //
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 248);
            CancelButton = btnCancelar;
            ClientSize = new Size(520, 510);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(cmbEstado);
            Controls.Add(lblEstado);
            Controls.Add(nudEjemplares);
            Controls.Add(lblEjemplares);
            Controls.Add(nudAnio);
            Controls.Add(lblAnio);
            Controls.Add(cmbCategoria);
            Controls.Add(lblCategoria);
            Controls.Add(txtEditorial);
            Controls.Add(lblEditorial);
            Controls.Add(txtIsbn);
            Controls.Add(lblIsbn);
            Controls.Add(txtAutor);
            Controls.Add(lblAutor);
            Controls.Add(txtTitulo);
            Controls.Add(lblTitulo);
            Controls.Add(lblEncabezado);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmRegistroLibro";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Registrar libro";
            Load += FrmRegistroLibro_Load;
            ((System.ComponentModel.ISupportInitialize)nudAnio).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudEjemplares).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEncabezado;
        private Label lblTitulo;
        private TextBox txtTitulo;
        private Label lblAutor;
        private TextBox txtAutor;
        private Label lblIsbn;
        private TextBox txtIsbn;
        private Label lblEditorial;
        private TextBox txtEditorial;
        private Label lblCategoria;
        private ComboBox cmbCategoria;
        private Label lblAnio;
        private NumericUpDown nudAnio;
        private Label lblEjemplares;
        private NumericUpDown nudEjemplares;
        private Label lblEstado;
        private ComboBox cmbEstado;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}
