namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    partial class FrmReportes
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
            tlpPrincipal = new TableLayoutPanel();
            panelEncabezado = new Panel();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            panelFiltros = new Controles.PanelTarjeta();
            panelAccionesFiltro = new Panel();
            btnExportarPdf = new Button();
            btnGenerar = new Button();
            cmbTipo = new ComboBox();
            lblTipo = new Label();
            dtpHasta = new DateTimePicker();
            lblHasta = new Label();
            dtpDesde = new DateTimePicker();
            lblDesde = new Label();
            tlpTarjetas = new TableLayoutPanel();
            tarjetaPrestados = new Controles.TarjetaResumen();
            tarjetaUsuarios = new Controles.TarjetaResumen();
            tarjetaReservas = new Controles.TarjetaResumen();
            tarjetaMorosidad = new Controles.TarjetaResumen();
            tlpInferior = new TableLayoutPanel();
            panelGrafico = new Controles.PanelTarjeta();
            graficoBarras = new Controles.GraficoBarras();
            lblGraficoTitulo = new Label();
            panelTabla = new Controles.PanelTarjeta();
            dgvLibros = new DataGridView();
            colTitulo = new DataGridViewTextBoxColumn();
            colVeces = new DataGridViewTextBoxColumn();
            colCategoria = new DataGridViewTextBoxColumn();
            lblTablaTitulo = new Label();
            tlpPrincipal.SuspendLayout();
            panelEncabezado.SuspendLayout();
            panelFiltros.SuspendLayout();
            panelAccionesFiltro.SuspendLayout();
            tlpTarjetas.SuspendLayout();
            tlpInferior.SuspendLayout();
            panelGrafico.SuspendLayout();
            panelTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).BeginInit();
            SuspendLayout();
            //
            // tlpPrincipal
            //
            tlpPrincipal.BackColor = Color.Transparent;
            tlpPrincipal.ColumnCount = 1;
            tlpPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpPrincipal.Controls.Add(panelEncabezado, 0, 0);
            tlpPrincipal.Controls.Add(panelFiltros, 0, 1);
            tlpPrincipal.Controls.Add(tlpTarjetas, 0, 2);
            tlpPrincipal.Controls.Add(tlpInferior, 0, 3);
            tlpPrincipal.Dock = DockStyle.Fill;
            tlpPrincipal.Location = new Point(24, 16);
            tlpPrincipal.Margin = new Padding(0);
            tlpPrincipal.Name = "tlpPrincipal";
            tlpPrincipal.RowCount = 4;
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 92F));
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
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
            lblSubtitulo.Size = new Size(430, 20);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Consulta estadísticas e información general del sistema de biblioteca.";
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(20, 20, 30);
            lblTitulo.Location = new Point(0, 4);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(139, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Reportes";
            //
            // panelFiltros
            //
            panelFiltros.BackColor = Color.White;
            panelFiltros.ColorBorde = Color.FromArgb(222, 226, 232);
            panelFiltros.Controls.Add(panelAccionesFiltro);
            panelFiltros.Controls.Add(cmbTipo);
            panelFiltros.Controls.Add(lblTipo);
            panelFiltros.Controls.Add(dtpHasta);
            panelFiltros.Controls.Add(lblHasta);
            panelFiltros.Controls.Add(dtpDesde);
            panelFiltros.Controls.Add(lblDesde);
            panelFiltros.Dock = DockStyle.Fill;
            panelFiltros.Location = new Point(0, 88);
            panelFiltros.Margin = new Padding(0, 0, 0, 16);
            panelFiltros.Name = "panelFiltros";
            panelFiltros.Size = new Size(1098, 76);
            panelFiltros.TabIndex = 1;
            //
            // lblDesde
            //
            lblDesde.AutoSize = true;
            lblDesde.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDesde.ForeColor = Color.FromArgb(20, 20, 30);
            lblDesde.Location = new Point(20, 8);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(52, 19);
            lblDesde.TabIndex = 0;
            lblDesde.Text = "Desde:";
            //
            // dtpDesde
            //
            dtpDesde.CustomFormat = "dd/MM/yyyy";
            dtpDesde.Font = new Font("Segoe UI", 11F);
            dtpDesde.Format = DateTimePickerFormat.Custom;
            dtpDesde.Location = new Point(20, 32);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(180, 27);
            dtpDesde.TabIndex = 0;
            //
            // lblHasta
            //
            lblHasta.AutoSize = true;
            lblHasta.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblHasta.ForeColor = Color.FromArgb(20, 20, 30);
            lblHasta.Location = new Point(220, 8);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(48, 19);
            lblHasta.TabIndex = 1;
            lblHasta.Text = "Hasta:";
            //
            // dtpHasta
            //
            dtpHasta.CustomFormat = "dd/MM/yyyy";
            dtpHasta.Font = new Font("Segoe UI", 11F);
            dtpHasta.Format = DateTimePickerFormat.Custom;
            dtpHasta.Location = new Point(220, 32);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(180, 27);
            dtpHasta.TabIndex = 1;
            //
            // lblTipo
            //
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTipo.ForeColor = Color.FromArgb(20, 20, 30);
            lblTipo.Location = new Point(420, 8);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(106, 19);
            lblTipo.TabIndex = 2;
            lblTipo.Text = "Tipo de reporte:";
            //
            // cmbTipo
            //
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.Font = new Font("Segoe UI", 11F);
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Items.AddRange(new object[] { "General", "Devoluciones", "Reservas" });
            cmbTipo.Location = new Point(420, 31);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(200, 28);
            cmbTipo.TabIndex = 2;
            //
            // panelAccionesFiltro
            //
            panelAccionesFiltro.BackColor = Color.Transparent;
            panelAccionesFiltro.Controls.Add(btnExportarPdf);
            panelAccionesFiltro.Controls.Add(btnGenerar);
            panelAccionesFiltro.Dock = DockStyle.Right;
            panelAccionesFiltro.Location = new Point(738, 1);
            panelAccionesFiltro.Name = "panelAccionesFiltro";
            panelAccionesFiltro.Size = new Size(359, 74);
            panelAccionesFiltro.TabIndex = 6;
            //
            // btnGenerar
            //
            btnGenerar.BackColor = Color.FromArgb(0, 120, 235);
            btnGenerar.Cursor = Cursors.Hand;
            btnGenerar.FlatAppearance.BorderSize = 0;
            btnGenerar.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 140, 250);
            btnGenerar.FlatStyle = FlatStyle.Flat;
            btnGenerar.Font = new Font("Segoe UI", 11F);
            btnGenerar.ForeColor = Color.White;
            btnGenerar.Location = new Point(10, 13);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(160, 48);
            btnGenerar.TabIndex = 0;
            btnGenerar.Text = "🔍   Generar";
            btnGenerar.UseVisualStyleBackColor = false;
            btnGenerar.Click += btnGenerar_Click;
            //
            // btnExportarPdf
            //
            btnExportarPdf.BackColor = Color.FromArgb(200, 208, 220);
            btnExportarPdf.Cursor = Cursors.Hand;
            btnExportarPdf.FlatAppearance.BorderSize = 0;
            btnExportarPdf.FlatAppearance.MouseOverBackColor = Color.FromArgb(215, 222, 232);
            btnExportarPdf.FlatStyle = FlatStyle.Flat;
            btnExportarPdf.Font = new Font("Segoe UI", 11F);
            btnExportarPdf.ForeColor = Color.Black;
            btnExportarPdf.Location = new Point(182, 13);
            btnExportarPdf.Name = "btnExportarPdf";
            btnExportarPdf.Size = new Size(160, 48);
            btnExportarPdf.TabIndex = 1;
            btnExportarPdf.Text = "📄   Exportar PDF";
            btnExportarPdf.UseVisualStyleBackColor = false;
            btnExportarPdf.Click += btnExportarPdf_Click;
            //
            // tlpTarjetas
            //
            tlpTarjetas.BackColor = Color.Transparent;
            tlpTarjetas.ColumnCount = 4;
            tlpTarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpTarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpTarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpTarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpTarjetas.Controls.Add(tarjetaPrestados, 0, 0);
            tlpTarjetas.Controls.Add(tarjetaUsuarios, 1, 0);
            tlpTarjetas.Controls.Add(tarjetaReservas, 2, 0);
            tlpTarjetas.Controls.Add(tarjetaMorosidad, 3, 0);
            tlpTarjetas.Dock = DockStyle.Fill;
            tlpTarjetas.Location = new Point(0, 180);
            tlpTarjetas.Margin = new Padding(0);
            tlpTarjetas.Name = "tlpTarjetas";
            tlpTarjetas.Padding = new Padding(0, 0, 0, 16);
            tlpTarjetas.RowCount = 1;
            tlpTarjetas.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpTarjetas.Size = new Size(1098, 140);
            tlpTarjetas.TabIndex = 2;
            //
            // tarjetaPrestados
            //
            tarjetaPrestados.BackColor = Color.White;
            tarjetaPrestados.ColorBorde = Color.FromArgb(222, 226, 232);
            tarjetaPrestados.ColorCirculo = Color.FromArgb(209, 230, 252);
            tarjetaPrestados.ColorValor = Color.FromArgb(21, 85, 170);
            tarjetaPrestados.Descripcion = "Durante el período";
            tarjetaPrestados.Dock = DockStyle.Fill;
            tarjetaPrestados.Icono = "";
            tarjetaPrestados.Location = new Point(0, 0);
            tarjetaPrestados.Margin = new Padding(0, 0, 16, 0);
            tarjetaPrestados.Name = "tarjetaPrestados";
            tarjetaPrestados.Size = new Size(253, 124);
            tarjetaPrestados.TabIndex = 0;
            tarjetaPrestados.Titulo = "Libros prestados";
            tarjetaPrestados.Valor = "0";
            //
            // tarjetaUsuarios
            //
            tarjetaUsuarios.BackColor = Color.White;
            tarjetaUsuarios.ColorBorde = Color.FromArgb(222, 226, 232);
            tarjetaUsuarios.ColorCirculo = Color.FromArgb(203, 232, 208);
            tarjetaUsuarios.ColorValor = Color.FromArgb(24, 110, 40);
            tarjetaUsuarios.Descripcion = "Usuarios con actividad";
            tarjetaUsuarios.Dock = DockStyle.Fill;
            tarjetaUsuarios.Icono = "";
            tarjetaUsuarios.Location = new Point(269, 0);
            tarjetaUsuarios.Margin = new Padding(0, 0, 16, 0);
            tarjetaUsuarios.Name = "tarjetaUsuarios";
            tarjetaUsuarios.Size = new Size(253, 124);
            tarjetaUsuarios.TabIndex = 1;
            tarjetaUsuarios.Titulo = "Usuarios activos";
            tarjetaUsuarios.Valor = "0";
            //
            // tarjetaReservas
            //
            tarjetaReservas.BackColor = Color.White;
            tarjetaReservas.ColorBorde = Color.FromArgb(222, 226, 232);
            tarjetaReservas.ColorCirculo = Color.FromArgb(253, 222, 190);
            tarjetaReservas.ColorValor = Color.FromArgb(240, 120, 10);
            tarjetaReservas.Descripcion = "Reservas registradas";
            tarjetaReservas.Dock = DockStyle.Fill;
            tarjetaReservas.Icono = "";
            tarjetaReservas.Location = new Point(538, 0);
            tarjetaReservas.Margin = new Padding(0, 0, 16, 0);
            tarjetaReservas.Name = "tarjetaReservas";
            tarjetaReservas.Size = new Size(253, 124);
            tarjetaReservas.TabIndex = 2;
            tarjetaReservas.Titulo = "Reservas del período";
            tarjetaReservas.Valor = "0";
            //
            // tarjetaMorosidad
            //
            tarjetaMorosidad.BackColor = Color.White;
            tarjetaMorosidad.ColorBorde = Color.FromArgb(222, 226, 232);
            tarjetaMorosidad.ColorCirculo = Color.FromArgb(252, 206, 206);
            tarjetaMorosidad.ColorValor = Color.FromArgb(185, 20, 40);
            tarjetaMorosidad.Descripcion = "Préstamos con retraso";
            tarjetaMorosidad.Dock = DockStyle.Fill;
            tarjetaMorosidad.Icono = "";
            tarjetaMorosidad.Location = new Point(807, 0);
            tarjetaMorosidad.Margin = new Padding(0);
            tarjetaMorosidad.Name = "tarjetaMorosidad";
            tarjetaMorosidad.Size = new Size(291, 124);
            tarjetaMorosidad.TabIndex = 3;
            tarjetaMorosidad.Titulo = "Morosidad";
            tarjetaMorosidad.Valor = "0";
            //
            // tlpInferior
            //
            tlpInferior.BackColor = Color.Transparent;
            tlpInferior.ColumnCount = 2;
            tlpInferior.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 56F));
            tlpInferior.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44F));
            tlpInferior.Controls.Add(panelGrafico, 0, 0);
            tlpInferior.Controls.Add(panelTabla, 1, 0);
            tlpInferior.Dock = DockStyle.Fill;
            tlpInferior.Location = new Point(0, 320);
            tlpInferior.Margin = new Padding(0);
            tlpInferior.Name = "tlpInferior";
            tlpInferior.RowCount = 1;
            tlpInferior.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpInferior.Size = new Size(1098, 412);
            tlpInferior.TabIndex = 3;
            //
            // panelGrafico
            //
            panelGrafico.BackColor = Color.White;
            panelGrafico.ColorBorde = Color.FromArgb(222, 226, 232);
            panelGrafico.Controls.Add(graficoBarras);
            panelGrafico.Controls.Add(lblGraficoTitulo);
            panelGrafico.Dock = DockStyle.Fill;
            panelGrafico.Location = new Point(0, 0);
            panelGrafico.Margin = new Padding(0, 0, 16, 0);
            panelGrafico.Name = "panelGrafico";
            panelGrafico.Padding = new Padding(20, 14, 20, 16);
            panelGrafico.Size = new Size(598, 412);
            panelGrafico.TabIndex = 0;
            //
            // graficoBarras
            //
            graficoBarras.BackColor = Color.White;
            graficoBarras.ColorBarras = Color.FromArgb(74, 150, 228);
            graficoBarras.Dock = DockStyle.Fill;
            graficoBarras.Font = new Font("Segoe UI", 9.5F);
            graficoBarras.Location = new Point(20, 54);
            graficoBarras.Name = "graficoBarras";
            graficoBarras.Size = new Size(558, 342);
            graficoBarras.TabIndex = 1;
            graficoBarras.TituloEjeY = "Cantidad de préstamos";
            //
            // lblGraficoTitulo
            //
            lblGraficoTitulo.Dock = DockStyle.Top;
            lblGraficoTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblGraficoTitulo.ForeColor = Color.FromArgb(20, 20, 30);
            lblGraficoTitulo.Location = new Point(20, 14);
            lblGraficoTitulo.Name = "lblGraficoTitulo";
            lblGraficoTitulo.Size = new Size(558, 40);
            lblGraficoTitulo.TabIndex = 0;
            lblGraficoTitulo.Text = "Préstamos por mes";
            lblGraficoTitulo.TextAlign = ContentAlignment.MiddleLeft;
            //
            // panelTabla
            //
            panelTabla.BackColor = Color.White;
            panelTabla.ColorBorde = Color.FromArgb(222, 226, 232);
            panelTabla.Controls.Add(dgvLibros);
            panelTabla.Controls.Add(lblTablaTitulo);
            panelTabla.Dock = DockStyle.Fill;
            panelTabla.Location = new Point(614, 0);
            panelTabla.Margin = new Padding(0);
            panelTabla.Name = "panelTabla";
            panelTabla.Padding = new Padding(20, 14, 20, 16);
            panelTabla.Size = new Size(484, 412);
            panelTabla.TabIndex = 1;
            //
            // dgvLibros
            //
            dgvLibros.AllowUserToAddRows = false;
            dgvLibros.AllowUserToDeleteRows = false;
            dgvLibros.AllowUserToResizeRows = false;
            dgvLibros.AutoGenerateColumns = false;
            dgvLibros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLibros.BackgroundColor = Color.White;
            dgvLibros.BorderStyle = BorderStyle.FixedSingle;
            dgvLibros.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvLibros.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            estiloEncabezado.Alignment = DataGridViewContentAlignment.MiddleLeft;
            estiloEncabezado.BackColor = Color.FromArgb(205, 228, 250);
            estiloEncabezado.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            estiloEncabezado.ForeColor = Color.Black;
            estiloEncabezado.SelectionBackColor = Color.FromArgb(205, 228, 250);
            estiloEncabezado.SelectionForeColor = Color.Black;
            estiloEncabezado.WrapMode = DataGridViewTriState.False;
            dgvLibros.ColumnHeadersDefaultCellStyle = estiloEncabezado;
            dgvLibros.ColumnHeadersHeight = 34;
            dgvLibros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvLibros.Columns.AddRange(new DataGridViewColumn[] { colTitulo, colVeces, colCategoria });
            estiloCelda.Alignment = DataGridViewContentAlignment.MiddleLeft;
            estiloCelda.BackColor = Color.White;
            estiloCelda.Font = new Font("Segoe UI", 10F);
            estiloCelda.ForeColor = Color.FromArgb(30, 30, 30);
            estiloCelda.SelectionBackColor = Color.FromArgb(30, 120, 255);
            estiloCelda.SelectionForeColor = Color.White;
            estiloCelda.WrapMode = DataGridViewTriState.False;
            dgvLibros.DefaultCellStyle = estiloCelda;
            dgvLibros.Dock = DockStyle.Fill;
            dgvLibros.EnableHeadersVisualStyles = false;
            dgvLibros.GridColor = Color.FromArgb(120, 120, 120);
            dgvLibros.Location = new Point(20, 54);
            dgvLibros.MultiSelect = false;
            dgvLibros.Name = "dgvLibros";
            dgvLibros.ReadOnly = true;
            dgvLibros.RowHeadersVisible = false;
            dgvLibros.RowTemplate.Height = 30;
            dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibros.Size = new Size(444, 342);
            dgvLibros.TabIndex = 1;
            //
            // colTitulo
            //
            colTitulo.DataPropertyName = "titulo";
            colTitulo.FillWeight = 42F;
            colTitulo.HeaderText = "Título";
            colTitulo.Name = "colTitulo";
            colTitulo.ReadOnly = true;
            //
            // colVeces
            //
            colVeces.DataPropertyName = "veces";
            colVeces.FillWeight = 30F;
            colVeces.HeaderText = "Veces prestado";
            colVeces.Name = "colVeces";
            colVeces.ReadOnly = true;
            //
            // colCategoria
            //
            colCategoria.DataPropertyName = "categoria";
            colCategoria.FillWeight = 28F;
            colCategoria.HeaderText = "Categoría";
            colCategoria.Name = "colCategoria";
            colCategoria.ReadOnly = true;
            //
            // lblTablaTitulo
            //
            lblTablaTitulo.Dock = DockStyle.Top;
            lblTablaTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTablaTitulo.ForeColor = Color.FromArgb(20, 20, 30);
            lblTablaTitulo.Location = new Point(20, 14);
            lblTablaTitulo.Name = "lblTablaTitulo";
            lblTablaTitulo.Size = new Size(444, 40);
            lblTablaTitulo.TabIndex = 0;
            lblTablaTitulo.Text = "Libros más prestados";
            lblTablaTitulo.TextAlign = ContentAlignment.MiddleLeft;
            //
            // FrmReportes
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 248);
            ClientSize = new Size(1146, 768);
            Controls.Add(tlpPrincipal);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmReportes";
            Padding = new Padding(24, 16, 24, 20);
            Text = "FrmReportes";
            Load += FrmReportes_Load;
            tlpPrincipal.ResumeLayout(false);
            panelEncabezado.ResumeLayout(false);
            panelEncabezado.PerformLayout();
            panelFiltros.ResumeLayout(false);
            panelFiltros.PerformLayout();
            panelAccionesFiltro.ResumeLayout(false);
            tlpTarjetas.ResumeLayout(false);
            tlpInferior.ResumeLayout(false);
            panelGrafico.ResumeLayout(false);
            panelTabla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLibros).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpPrincipal;
        private Panel panelEncabezado;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Controles.PanelTarjeta panelFiltros;
        private Label lblDesde;
        private DateTimePicker dtpDesde;
        private Label lblHasta;
        private DateTimePicker dtpHasta;
        private Label lblTipo;
        private ComboBox cmbTipo;
        private Panel panelAccionesFiltro;
        private Button btnGenerar;
        private Button btnExportarPdf;
        private TableLayoutPanel tlpTarjetas;
        private Controles.TarjetaResumen tarjetaPrestados;
        private Controles.TarjetaResumen tarjetaUsuarios;
        private Controles.TarjetaResumen tarjetaReservas;
        private Controles.TarjetaResumen tarjetaMorosidad;
        private TableLayoutPanel tlpInferior;
        private Controles.PanelTarjeta panelGrafico;
        private Label lblGraficoTitulo;
        private Controles.GraficoBarras graficoBarras;
        private Controles.PanelTarjeta panelTabla;
        private Label lblTablaTitulo;
        private DataGridView dgvLibros;
        private DataGridViewTextBoxColumn colTitulo;
        private DataGridViewTextBoxColumn colVeces;
        private DataGridViewTextBoxColumn colCategoria;
    }
}
