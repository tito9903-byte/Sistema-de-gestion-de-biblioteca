namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    partial class FrmPrestamos
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
            DataGridViewCellStyle estiloEncabezado = new DataGridViewCellStyle();
            DataGridViewCellStyle estiloCelda = new DataGridViewCellStyle();
            DataGridViewCellStyle estiloFecha1 = new DataGridViewCellStyle();
            DataGridViewCellStyle estiloFecha2 = new DataGridViewCellStyle();
            tlpPrincipal = new TableLayoutPanel();
            panelEncabezado = new Panel();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            tlpTarjetas = new TableLayoutPanel();
            tarjetaActivos = new Controles.TarjetaResumen();
            tarjetaVencidos = new Controles.TarjetaResumen();
            tarjetaDevueltosHoy = new Controles.TarjetaResumen();
            txtBuscar = new TextBox();
            tlpContenido = new TableLayoutPanel();
            dgvPrestamos = new DataGridView();
            colCodigo = new DataGridViewTextBoxColumn();
            colUsuario = new DataGridViewTextBoxColumn();
            colLibro = new DataGridViewTextBoxColumn();
            colFechaPrestamo = new DataGridViewTextBoxColumn();
            colFechaDevolucion = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            colObservacion = new DataGridViewTextBoxColumn();
            panelBotones = new FlowLayoutPanel();
            btnNuevoPrestamo = new Button();
            btnRenovar = new Button();
            btnRegistrarDevolucion = new Button();
            btnVerDetalle = new Button();
            tlpPrincipal.SuspendLayout();
            panelEncabezado.SuspendLayout();
            tlpTarjetas.SuspendLayout();
            tlpContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).BeginInit();
            panelBotones.SuspendLayout();
            SuspendLayout();
            //
            // tlpPrincipal
            //
            tlpPrincipal.BackColor = Color.Transparent;
            tlpPrincipal.ColumnCount = 1;
            tlpPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpPrincipal.Controls.Add(panelEncabezado, 0, 0);
            tlpPrincipal.Controls.Add(tlpTarjetas, 0, 1);
            tlpPrincipal.Controls.Add(txtBuscar, 0, 2);
            tlpPrincipal.Controls.Add(tlpContenido, 0, 3);
            tlpPrincipal.Dock = DockStyle.Fill;
            tlpPrincipal.Location = new Point(24, 16);
            tlpPrincipal.Margin = new Padding(0);
            tlpPrincipal.Name = "tlpPrincipal";
            tlpPrincipal.RowCount = 4;
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpPrincipal.Size = new Size(1098, 732);
            tlpPrincipal.TabIndex = 0;
            //
            // panelEncabezado
            //
            panelEncabezado.Controls.Add(lblSubtitulo);
            panelEncabezado.Controls.Add(lblTitulo);
            panelEncabezado.Dock = DockStyle.Fill;
            panelEncabezado.Location = new Point(0, 0);
            panelEncabezado.Margin = new Padding(0);
            panelEncabezado.Name = "panelEncabezado";
            panelEncabezado.Size = new Size(1098, 88);
            panelEncabezado.TabIndex = 0;
            //
            // lblSubtitulo
            //
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 11F);
            lblSubtitulo.ForeColor = Color.FromArgb(80, 100, 130);
            lblSubtitulo.Location = new Point(4, 56);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(367, 20);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Gestiona los préstamos de libros a los usuarios de la biblioteca.";
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(20, 20, 30);
            lblTitulo.Location = new Point(0, 4);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(151, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Préstamos";
            //
            // tlpTarjetas
            //
            tlpTarjetas.BackColor = Color.Transparent;
            tlpTarjetas.ColumnCount = 3;
            tlpTarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpTarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpTarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            tlpTarjetas.Controls.Add(tarjetaActivos, 0, 0);
            tlpTarjetas.Controls.Add(tarjetaVencidos, 1, 0);
            tlpTarjetas.Controls.Add(tarjetaDevueltosHoy, 2, 0);
            tlpTarjetas.Dock = DockStyle.Fill;
            tlpTarjetas.Location = new Point(0, 88);
            tlpTarjetas.Margin = new Padding(0);
            tlpTarjetas.Name = "tlpTarjetas";
            tlpTarjetas.Padding = new Padding(0, 0, 0, 16);
            tlpTarjetas.RowCount = 1;
            tlpTarjetas.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpTarjetas.Size = new Size(1098, 140);
            tlpTarjetas.TabIndex = 1;
            //
            // tarjetaActivos
            //
            tarjetaActivos.BackColor = Color.White;
            tarjetaActivos.ColorBorde = Color.FromArgb(222, 226, 232);
            tarjetaActivos.ColorCirculo = Color.FromArgb(253, 222, 190);
            tarjetaActivos.ColorValor = Color.FromArgb(240, 120, 10);
            tarjetaActivos.Descripcion = "Libros actualmente prestados";
            tarjetaActivos.Dock = DockStyle.Fill;
            tarjetaActivos.Icono = "";
            tarjetaActivos.Location = new Point(0, 0);
            tarjetaActivos.Margin = new Padding(0, 0, 16, 0);
            tarjetaActivos.Name = "tarjetaActivos";
            tarjetaActivos.Size = new Size(350, 124);
            tarjetaActivos.TabIndex = 0;
            tarjetaActivos.Titulo = "Préstamos activos";
            tarjetaActivos.Valor = "0";
            //
            // tarjetaVencidos
            //
            tarjetaVencidos.BackColor = Color.White;
            tarjetaVencidos.ColorBorde = Color.FromArgb(222, 226, 232);
            tarjetaVencidos.ColorCirculo = Color.FromArgb(252, 206, 206);
            tarjetaVencidos.ColorValor = Color.FromArgb(185, 20, 40);
            tarjetaVencidos.Descripcion = "Préstamos con retraso";
            tarjetaVencidos.Dock = DockStyle.Fill;
            tarjetaVencidos.Icono = "";
            tarjetaVencidos.Location = new Point(366, 0);
            tarjetaVencidos.Margin = new Padding(0, 0, 16, 0);
            tarjetaVencidos.Name = "tarjetaVencidos";
            tarjetaVencidos.Size = new Size(350, 124);
            tarjetaVencidos.TabIndex = 1;
            tarjetaVencidos.Titulo = "Vencidos";
            tarjetaVencidos.Valor = "0";
            //
            // tarjetaDevueltosHoy
            //
            tarjetaDevueltosHoy.BackColor = Color.White;
            tarjetaDevueltosHoy.ColorBorde = Color.FromArgb(222, 226, 232);
            tarjetaDevueltosHoy.ColorCirculo = Color.FromArgb(203, 232, 208);
            tarjetaDevueltosHoy.ColorValor = Color.FromArgb(24, 110, 40);
            tarjetaDevueltosHoy.Descripcion = "Libros devueltos en el día";
            tarjetaDevueltosHoy.Dock = DockStyle.Fill;
            tarjetaDevueltosHoy.Icono = "";
            tarjetaDevueltosHoy.Location = new Point(732, 0);
            tarjetaDevueltosHoy.Margin = new Padding(0);
            tarjetaDevueltosHoy.Name = "tarjetaDevueltosHoy";
            tarjetaDevueltosHoy.Size = new Size(366, 124);
            tarjetaDevueltosHoy.TabIndex = 2;
            tarjetaDevueltosHoy.Titulo = "Devueltos hoy";
            tarjetaDevueltosHoy.Valor = "0";
            //
            // txtBuscar
            //
            txtBuscar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Segoe UI", 11F);
            txtBuscar.Location = new Point(0, 228);
            txtBuscar.Margin = new Padding(0, 0, 0, 0);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar por usuario, libro o código de préstamo...";
            txtBuscar.Size = new Size(1098, 27);
            txtBuscar.TabIndex = 0;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            //
            // tlpContenido
            //
            tlpContenido.BackColor = Color.Transparent;
            tlpContenido.ColumnCount = 2;
            tlpContenido.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpContenido.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 216F));
            tlpContenido.Controls.Add(dgvPrestamos, 0, 0);
            tlpContenido.Controls.Add(panelBotones, 1, 0);
            tlpContenido.Dock = DockStyle.Fill;
            tlpContenido.Location = new Point(0, 272);
            tlpContenido.Margin = new Padding(0);
            tlpContenido.Name = "tlpContenido";
            tlpContenido.RowCount = 1;
            tlpContenido.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpContenido.Size = new Size(1098, 460);
            tlpContenido.TabIndex = 2;
            //
            // dgvPrestamos
            //
            dgvPrestamos.AllowUserToAddRows = false;
            dgvPrestamos.AllowUserToDeleteRows = false;
            dgvPrestamos.AllowUserToResizeRows = false;
            dgvPrestamos.AutoGenerateColumns = false;
            dgvPrestamos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPrestamos.BackgroundColor = Color.White;
            dgvPrestamos.BorderStyle = BorderStyle.FixedSingle;
            dgvPrestamos.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvPrestamos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            estiloEncabezado.Alignment = DataGridViewContentAlignment.MiddleLeft;
            estiloEncabezado.BackColor = Color.FromArgb(205, 228, 250);
            estiloEncabezado.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            estiloEncabezado.ForeColor = Color.Black;
            estiloEncabezado.SelectionBackColor = Color.FromArgb(205, 228, 250);
            estiloEncabezado.SelectionForeColor = Color.Black;
            estiloEncabezado.WrapMode = DataGridViewTriState.False;
            dgvPrestamos.ColumnHeadersDefaultCellStyle = estiloEncabezado;
            dgvPrestamos.ColumnHeadersHeight = 36;
            dgvPrestamos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPrestamos.Columns.AddRange(new DataGridViewColumn[] { colCodigo, colUsuario, colLibro, colFechaPrestamo, colFechaDevolucion, colEstado, colObservacion });
            estiloCelda.Alignment = DataGridViewContentAlignment.MiddleLeft;
            estiloCelda.BackColor = Color.White;
            estiloCelda.Font = new Font("Segoe UI", 10F);
            estiloCelda.ForeColor = Color.FromArgb(30, 30, 30);
            estiloCelda.SelectionBackColor = Color.FromArgb(30, 120, 255);
            estiloCelda.SelectionForeColor = Color.White;
            estiloCelda.WrapMode = DataGridViewTriState.False;
            dgvPrestamos.DefaultCellStyle = estiloCelda;
            dgvPrestamos.Dock = DockStyle.Fill;
            dgvPrestamos.EnableHeadersVisualStyles = false;
            dgvPrestamos.GridColor = Color.FromArgb(120, 120, 120);
            dgvPrestamos.Location = new Point(0, 0);
            dgvPrestamos.Margin = new Padding(0, 0, 16, 0);
            dgvPrestamos.MultiSelect = false;
            dgvPrestamos.Name = "dgvPrestamos";
            dgvPrestamos.ReadOnly = true;
            dgvPrestamos.RowHeadersVisible = false;
            dgvPrestamos.RowTemplate.Height = 32;
            dgvPrestamos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrestamos.Size = new Size(866, 460);
            dgvPrestamos.TabIndex = 0;
            dgvPrestamos.CellFormatting += dgvPrestamos_CellFormatting;
            //
            // colCodigo
            //
            colCodigo.DataPropertyName = "codigo";
            colCodigo.FillWeight = 10F;
            colCodigo.HeaderText = "Código";
            colCodigo.Name = "colCodigo";
            colCodigo.ReadOnly = true;
            //
            // colUsuario
            //
            colUsuario.DataPropertyName = "usuario";
            colUsuario.FillWeight = 13F;
            colUsuario.HeaderText = "Usuario";
            colUsuario.Name = "colUsuario";
            colUsuario.ReadOnly = true;
            //
            // colLibro
            //
            colLibro.DataPropertyName = "libro";
            colLibro.FillWeight = 19F;
            colLibro.HeaderText = "Libro";
            colLibro.Name = "colLibro";
            colLibro.ReadOnly = true;
            //
            // colFechaPrestamo
            //
            estiloFecha1.Format = "dd/MM/yyyy";
            colFechaPrestamo.DataPropertyName = "fecha_prestamo";
            colFechaPrestamo.DefaultCellStyle = estiloFecha1;
            colFechaPrestamo.FillWeight = 15F;
            colFechaPrestamo.HeaderText = "Fecha préstamo";
            colFechaPrestamo.Name = "colFechaPrestamo";
            colFechaPrestamo.ReadOnly = true;
            //
            // colFechaDevolucion
            //
            estiloFecha2.Format = "dd/MM/yyyy";
            colFechaDevolucion.DataPropertyName = "fecha_vencimiento";
            colFechaDevolucion.DefaultCellStyle = estiloFecha2;
            colFechaDevolucion.FillWeight = 15F;
            colFechaDevolucion.HeaderText = "Fecha devolución";
            colFechaDevolucion.Name = "colFechaDevolucion";
            colFechaDevolucion.ReadOnly = true;
            //
            // colEstado
            //
            colEstado.DataPropertyName = "estado";
            colEstado.FillWeight = 8F;
            colEstado.HeaderText = "Estado";
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            //
            // colObservacion
            //
            colObservacion.DataPropertyName = "observacion";
            colObservacion.FillWeight = 20F;
            colObservacion.HeaderText = "Observación";
            colObservacion.Name = "colObservacion";
            colObservacion.ReadOnly = true;
            //
            // panelBotones
            //
            panelBotones.Controls.Add(btnNuevoPrestamo);
            panelBotones.Controls.Add(btnRenovar);
            panelBotones.Controls.Add(btnRegistrarDevolucion);
            panelBotones.Controls.Add(btnVerDetalle);
            panelBotones.Dock = DockStyle.Fill;
            panelBotones.FlowDirection = FlowDirection.TopDown;
            panelBotones.Location = new Point(882, 0);
            panelBotones.Margin = new Padding(0);
            panelBotones.Name = "panelBotones";
            panelBotones.Size = new Size(216, 460);
            panelBotones.TabIndex = 1;
            panelBotones.WrapContents = false;
            //
            // btnNuevoPrestamo
            //
            btnNuevoPrestamo.BackColor = Color.FromArgb(0, 120, 235);
            btnNuevoPrestamo.Cursor = Cursors.Hand;
            btnNuevoPrestamo.FlatAppearance.BorderSize = 0;
            btnNuevoPrestamo.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 140, 250);
            btnNuevoPrestamo.FlatStyle = FlatStyle.Flat;
            btnNuevoPrestamo.Font = new Font("Segoe UI", 10.5F);
            btnNuevoPrestamo.ForeColor = Color.White;
            btnNuevoPrestamo.Location = new Point(0, 0);
            btnNuevoPrestamo.Margin = new Padding(0, 0, 0, 12);
            btnNuevoPrestamo.Name = "btnNuevoPrestamo";
            btnNuevoPrestamo.Size = new Size(216, 52);
            btnNuevoPrestamo.TabIndex = 0;
            btnNuevoPrestamo.Text = "＋   Nuevo préstamo";
            btnNuevoPrestamo.UseVisualStyleBackColor = false;
            btnNuevoPrestamo.Click += btnNuevoPrestamo_Click;
            //
            // btnRenovar
            //
            btnRenovar.BackColor = Color.FromArgb(165, 214, 170);
            btnRenovar.Cursor = Cursors.Hand;
            btnRenovar.FlatAppearance.BorderSize = 0;
            btnRenovar.FlatAppearance.MouseOverBackColor = Color.FromArgb(185, 226, 190);
            btnRenovar.FlatStyle = FlatStyle.Flat;
            btnRenovar.Font = new Font("Segoe UI", 10.5F);
            btnRenovar.ForeColor = Color.Black;
            btnRenovar.Location = new Point(0, 64);
            btnRenovar.Margin = new Padding(0, 0, 0, 12);
            btnRenovar.Name = "btnRenovar";
            btnRenovar.Size = new Size(216, 52);
            btnRenovar.TabIndex = 1;
            btnRenovar.Text = "🔄   Renovar";
            btnRenovar.UseVisualStyleBackColor = false;
            btnRenovar.Click += btnRenovar_Click;
            //
            // btnRegistrarDevolucion
            //
            btnRegistrarDevolucion.BackColor = Color.FromArgb(255, 193, 70);
            btnRegistrarDevolucion.Cursor = Cursors.Hand;
            btnRegistrarDevolucion.FlatAppearance.BorderSize = 0;
            btnRegistrarDevolucion.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 208, 110);
            btnRegistrarDevolucion.FlatStyle = FlatStyle.Flat;
            btnRegistrarDevolucion.Font = new Font("Segoe UI", 10.5F);
            btnRegistrarDevolucion.ForeColor = Color.Black;
            btnRegistrarDevolucion.Location = new Point(0, 128);
            btnRegistrarDevolucion.Margin = new Padding(0, 0, 0, 12);
            btnRegistrarDevolucion.Name = "btnRegistrarDevolucion";
            btnRegistrarDevolucion.Size = new Size(216, 52);
            btnRegistrarDevolucion.TabIndex = 2;
            btnRegistrarDevolucion.Text = "↩   Registrar devolución";
            btnRegistrarDevolucion.UseVisualStyleBackColor = false;
            btnRegistrarDevolucion.Click += btnRegistrarDevolucion_Click;
            //
            // btnVerDetalle
            //
            btnVerDetalle.BackColor = Color.FromArgb(176, 196, 222);
            btnVerDetalle.Cursor = Cursors.Hand;
            btnVerDetalle.FlatAppearance.BorderSize = 0;
            btnVerDetalle.FlatAppearance.MouseOverBackColor = Color.FromArgb(195, 212, 232);
            btnVerDetalle.FlatStyle = FlatStyle.Flat;
            btnVerDetalle.Font = new Font("Segoe UI", 10.5F);
            btnVerDetalle.ForeColor = Color.Black;
            btnVerDetalle.Location = new Point(0, 192);
            btnVerDetalle.Margin = new Padding(0, 0, 0, 12);
            btnVerDetalle.Name = "btnVerDetalle";
            btnVerDetalle.Size = new Size(216, 52);
            btnVerDetalle.TabIndex = 3;
            btnVerDetalle.Text = "📄   Ver detalle";
            btnVerDetalle.UseVisualStyleBackColor = false;
            btnVerDetalle.Click += btnVerDetalle_Click;
            //
            // FrmPrestamos
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 248);
            ClientSize = new Size(1146, 768);
            Controls.Add(tlpPrincipal);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmPrestamos";
            Padding = new Padding(24, 16, 24, 20);
            Text = "FrmPrestamos";
            Load += FrmPrestamos_Load;
            tlpPrincipal.ResumeLayout(false);
            tlpPrincipal.PerformLayout();
            panelEncabezado.ResumeLayout(false);
            panelEncabezado.PerformLayout();
            tlpTarjetas.ResumeLayout(false);
            tlpContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).EndInit();
            panelBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpPrincipal;
        private Panel panelEncabezado;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private TableLayoutPanel tlpTarjetas;
        private Controles.TarjetaResumen tarjetaActivos;
        private Controles.TarjetaResumen tarjetaVencidos;
        private Controles.TarjetaResumen tarjetaDevueltosHoy;
        private TextBox txtBuscar;
        private TableLayoutPanel tlpContenido;
        private DataGridView dgvPrestamos;
        private DataGridViewTextBoxColumn colCodigo;
        private DataGridViewTextBoxColumn colUsuario;
        private DataGridViewTextBoxColumn colLibro;
        private DataGridViewTextBoxColumn colFechaPrestamo;
        private DataGridViewTextBoxColumn colFechaDevolucion;
        private DataGridViewTextBoxColumn colEstado;
        private DataGridViewTextBoxColumn colObservacion;
        private FlowLayoutPanel panelBotones;
        private Button btnNuevoPrestamo;
        private Button btnRenovar;
        private Button btnRegistrarDevolucion;
        private Button btnVerDetalle;
    }
}
