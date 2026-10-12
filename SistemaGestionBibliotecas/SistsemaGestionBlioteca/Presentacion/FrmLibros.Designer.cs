namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    partial class FrmLibros
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
            lblTitulo = new Label();
            txtBuscar = new TextBox();
            tlpTarjetas = new TableLayoutPanel();
            tarjetaTotal = new Controles.TarjetaResumen();
            tarjetaDisponibles = new Controles.TarjetaResumen();
            tarjetaPrestados = new Controles.TarjetaResumen();
            tlpContenido = new TableLayoutPanel();
            dgvLibros = new DataGridView();
            colCodigo = new DataGridViewTextBoxColumn();
            colTitulo = new DataGridViewTextBoxColumn();
            colAutor = new DataGridViewTextBoxColumn();
            colCategoria = new DataGridViewTextBoxColumn();
            colAnio = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            colDisponibilidad = new DataGridViewTextBoxColumn();
            panelBotones = new FlowLayoutPanel();
            btnNuevo = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnVerDetalle = new Button();
            tlpPrincipal.SuspendLayout();
            tlpTarjetas.SuspendLayout();
            tlpContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).BeginInit();
            panelBotones.SuspendLayout();
            SuspendLayout();
            //
            // tlpPrincipal
            //
            tlpPrincipal.BackColor = Color.Transparent;
            tlpPrincipal.ColumnCount = 1;
            tlpPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpPrincipal.Controls.Add(lblTitulo, 0, 0);
            tlpPrincipal.Controls.Add(txtBuscar, 0, 1);
            tlpPrincipal.Controls.Add(tlpTarjetas, 0, 2);
            tlpPrincipal.Controls.Add(tlpContenido, 0, 3);
            tlpPrincipal.Dock = DockStyle.Fill;
            tlpPrincipal.Location = new Point(24, 16);
            tlpPrincipal.Margin = new Padding(0);
            tlpPrincipal.Name = "tlpPrincipal";
            tlpPrincipal.RowCount = 4;
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpPrincipal.Size = new Size(1098, 732);
            tlpPrincipal.TabIndex = 0;
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(20, 20, 30);
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Margin = new Padding(0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(97, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Libros";
            //
            // txtBuscar
            //
            txtBuscar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Segoe UI", 11F);
            txtBuscar.Location = new Point(0, 4);
            txtBuscar.Margin = new Padding(0, 0, 0, 12);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar por título, autor, categoría o ISBN...";
            txtBuscar.Size = new Size(1098, 27);
            txtBuscar.TabIndex = 0;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            //
            // tlpTarjetas
            //
            tlpTarjetas.BackColor = Color.Transparent;
            tlpTarjetas.ColumnCount = 3;
            tlpTarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpTarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpTarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            tlpTarjetas.Controls.Add(tarjetaTotal, 0, 0);
            tlpTarjetas.Controls.Add(tarjetaDisponibles, 1, 0);
            tlpTarjetas.Controls.Add(tarjetaPrestados, 2, 0);
            tlpTarjetas.Dock = DockStyle.Fill;
            tlpTarjetas.Location = new Point(0, 116);
            tlpTarjetas.Margin = new Padding(0);
            tlpTarjetas.Name = "tlpTarjetas";
            tlpTarjetas.Padding = new Padding(0, 0, 0, 16);
            tlpTarjetas.RowCount = 1;
            tlpTarjetas.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpTarjetas.Size = new Size(1098, 140);
            tlpTarjetas.TabIndex = 1;
            //
            // tarjetaTotal
            //
            tarjetaTotal.BackColor = Color.White;
            tarjetaTotal.ColorBorde = Color.FromArgb(222, 226, 232);
            tarjetaTotal.ColorCirculo = Color.FromArgb(209, 230, 252);
            tarjetaTotal.ColorValor = Color.FromArgb(21, 85, 170);
            tarjetaTotal.Descripcion = "Libros registrados en el sistema";
            tarjetaTotal.Dock = DockStyle.Fill;
            tarjetaTotal.Icono = "";
            tarjetaTotal.Location = new Point(0, 0);
            tarjetaTotal.Margin = new Padding(0, 0, 16, 0);
            tarjetaTotal.Name = "tarjetaTotal";
            tarjetaTotal.Size = new Size(350, 124);
            tarjetaTotal.TabIndex = 0;
            tarjetaTotal.Titulo = "Total de libros";
            tarjetaTotal.Valor = "0";
            //
            // tarjetaDisponibles
            //
            tarjetaDisponibles.BackColor = Color.White;
            tarjetaDisponibles.ColorBorde = Color.FromArgb(222, 226, 232);
            tarjetaDisponibles.ColorCirculo = Color.FromArgb(203, 232, 208);
            tarjetaDisponibles.ColorValor = Color.FromArgb(24, 110, 40);
            tarjetaDisponibles.Descripcion = "Libros disponibles para préstamo";
            tarjetaDisponibles.Dock = DockStyle.Fill;
            tarjetaDisponibles.Icono = "";
            tarjetaDisponibles.Location = new Point(366, 0);
            tarjetaDisponibles.Margin = new Padding(0, 0, 16, 0);
            tarjetaDisponibles.Name = "tarjetaDisponibles";
            tarjetaDisponibles.Size = new Size(350, 124);
            tarjetaDisponibles.TabIndex = 1;
            tarjetaDisponibles.Titulo = "Disponibles";
            tarjetaDisponibles.Valor = "0";
            //
            // tarjetaPrestados
            //
            tarjetaPrestados.BackColor = Color.White;
            tarjetaPrestados.ColorBorde = Color.FromArgb(222, 226, 232);
            tarjetaPrestados.ColorCirculo = Color.FromArgb(253, 222, 190);
            tarjetaPrestados.ColorValor = Color.FromArgb(240, 120, 10);
            tarjetaPrestados.Descripcion = "Libros actualmente prestados";
            tarjetaPrestados.Dock = DockStyle.Fill;
            tarjetaPrestados.Icono = "";
            tarjetaPrestados.Location = new Point(732, 0);
            tarjetaPrestados.Margin = new Padding(0);
            tarjetaPrestados.Name = "tarjetaPrestados";
            tarjetaPrestados.Size = new Size(366, 124);
            tarjetaPrestados.TabIndex = 2;
            tarjetaPrestados.Titulo = "Prestados";
            tarjetaPrestados.Valor = "0";
            //
            // tlpContenido
            //
            tlpContenido.BackColor = Color.Transparent;
            tlpContenido.ColumnCount = 2;
            tlpContenido.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpContenido.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 176F));
            tlpContenido.Controls.Add(dgvLibros, 0, 0);
            tlpContenido.Controls.Add(panelBotones, 1, 0);
            tlpContenido.Dock = DockStyle.Fill;
            tlpContenido.Location = new Point(0, 256);
            tlpContenido.Margin = new Padding(0);
            tlpContenido.Name = "tlpContenido";
            tlpContenido.RowCount = 1;
            tlpContenido.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpContenido.Size = new Size(1098, 476);
            tlpContenido.TabIndex = 2;
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
            estiloEncabezado.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            estiloEncabezado.ForeColor = Color.Black;
            estiloEncabezado.SelectionBackColor = Color.FromArgb(205, 228, 250);
            estiloEncabezado.SelectionForeColor = Color.Black;
            estiloEncabezado.WrapMode = DataGridViewTriState.True;
            dgvLibros.ColumnHeadersDefaultCellStyle = estiloEncabezado;
            dgvLibros.ColumnHeadersHeight = 36;
            dgvLibros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvLibros.Columns.AddRange(new DataGridViewColumn[] { colCodigo, colTitulo, colAutor, colCategoria, colAnio, colEstado, colDisponibilidad });
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
            dgvLibros.Location = new Point(0, 0);
            dgvLibros.Margin = new Padding(0, 0, 16, 0);
            dgvLibros.MultiSelect = false;
            dgvLibros.Name = "dgvLibros";
            dgvLibros.ReadOnly = true;
            dgvLibros.RowHeadersVisible = false;
            dgvLibros.RowTemplate.Height = 32;
            dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibros.Size = new Size(906, 476);
            dgvLibros.TabIndex = 0;
            //
            // colCodigo
            //
            colCodigo.DataPropertyName = "codigo";
            colCodigo.FillWeight = 11F;
            colCodigo.HeaderText = "Código";
            colCodigo.Name = "colCodigo";
            colCodigo.ReadOnly = true;
            //
            // colTitulo
            //
            colTitulo.DataPropertyName = "titulo";
            colTitulo.FillWeight = 26F;
            colTitulo.HeaderText = "Título";
            colTitulo.Name = "colTitulo";
            colTitulo.ReadOnly = true;
            //
            // colAutor
            //
            colAutor.DataPropertyName = "autor";
            colAutor.FillWeight = 22F;
            colAutor.HeaderText = "Autor";
            colAutor.Name = "colAutor";
            colAutor.ReadOnly = true;
            //
            // colCategoria
            //
            colCategoria.DataPropertyName = "categoria";
            colCategoria.FillWeight = 14F;
            colCategoria.HeaderText = "Categoría";
            colCategoria.Name = "colCategoria";
            colCategoria.ReadOnly = true;
            //
            // colAnio
            //
            colAnio.DataPropertyName = "anio_publicacion";
            colAnio.FillWeight = 7F;
            colAnio.HeaderText = "Año";
            colAnio.Name = "colAnio";
            colAnio.ReadOnly = true;
            //
            // colEstado
            //
            colEstado.DataPropertyName = "estado";
            colEstado.FillWeight = 9F;
            colEstado.HeaderText = "Estado";
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            //
            // colDisponibilidad
            //
            colDisponibilidad.DataPropertyName = "disponibilidad";
            colDisponibilidad.FillWeight = 14F;
            colDisponibilidad.HeaderText = "Disponibilidad";
            colDisponibilidad.Name = "colDisponibilidad";
            colDisponibilidad.ReadOnly = true;
            //
            // panelBotones
            //
            panelBotones.Controls.Add(btnNuevo);
            panelBotones.Controls.Add(btnEditar);
            panelBotones.Controls.Add(btnEliminar);
            panelBotones.Controls.Add(btnVerDetalle);
            panelBotones.Dock = DockStyle.Fill;
            panelBotones.FlowDirection = FlowDirection.TopDown;
            panelBotones.Location = new Point(922, 0);
            panelBotones.Margin = new Padding(0);
            panelBotones.Name = "panelBotones";
            panelBotones.Size = new Size(176, 476);
            panelBotones.WrapContents = false;
            panelBotones.TabIndex = 1;
            //
            // btnNuevo
            //
            btnNuevo.BackColor = Color.FromArgb(0, 120, 235);
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.Margin = new Padding(0, 0, 0, 12);
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 140, 250);
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI", 11F);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(0, 0);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(176, 50);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "＋   Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            //
            // btnEditar
            //
            btnEditar.BackColor = Color.FromArgb(0, 120, 235);
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.Margin = new Padding(0, 0, 0, 12);
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 140, 250);
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 11F);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(0, 50);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(176, 50);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "✎   Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            //
            // btnEliminar
            //
            btnEliminar.BackColor = Color.FromArgb(250, 120, 110);
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.Margin = new Padding(0, 0, 0, 12);
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatAppearance.MouseOverBackColor = Color.FromArgb(252, 140, 130);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 11F);
            btnEliminar.ForeColor = Color.Black;
            btnEliminar.Location = new Point(0, 100);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(176, 50);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "🗑   Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            //
            // btnVerDetalle
            //
            btnVerDetalle.BackColor = Color.FromArgb(176, 196, 222);
            btnVerDetalle.Cursor = Cursors.Hand;
            btnVerDetalle.Margin = new Padding(0, 0, 0, 12);
            btnVerDetalle.FlatAppearance.BorderSize = 0;
            btnVerDetalle.FlatAppearance.MouseOverBackColor = Color.FromArgb(195, 212, 232);
            btnVerDetalle.FlatStyle = FlatStyle.Flat;
            btnVerDetalle.Font = new Font("Segoe UI", 11F);
            btnVerDetalle.ForeColor = Color.Black;
            btnVerDetalle.Location = new Point(0, 150);
            btnVerDetalle.Name = "btnVerDetalle";
            btnVerDetalle.Size = new Size(176, 50);
            btnVerDetalle.TabIndex = 3;
            btnVerDetalle.Text = "📄   Ver detalle";
            btnVerDetalle.UseVisualStyleBackColor = false;
            btnVerDetalle.Click += btnVerDetalle_Click;
            //
            // FrmLibros
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 248);
            ClientSize = new Size(1146, 768);
            Controls.Add(tlpPrincipal);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmLibros";
            Padding = new Padding(24, 16, 24, 20);
            Text = "FrmLibros";
            Load += FrmLibros_Load;
            tlpPrincipal.ResumeLayout(false);
            tlpPrincipal.PerformLayout();
            tlpTarjetas.ResumeLayout(false);
            tlpContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLibros).EndInit();
            panelBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpPrincipal;
        private Label lblTitulo;
        private TextBox txtBuscar;
        private TableLayoutPanel tlpTarjetas;
        private Controles.TarjetaResumen tarjetaTotal;
        private Controles.TarjetaResumen tarjetaDisponibles;
        private Controles.TarjetaResumen tarjetaPrestados;
        private TableLayoutPanel tlpContenido;
        private DataGridView dgvLibros;
        private DataGridViewTextBoxColumn colCodigo;
        private DataGridViewTextBoxColumn colTitulo;
        private DataGridViewTextBoxColumn colAutor;
        private DataGridViewTextBoxColumn colCategoria;
        private DataGridViewTextBoxColumn colAnio;
        private DataGridViewTextBoxColumn colEstado;
        private DataGridViewTextBoxColumn colDisponibilidad;
        private FlowLayoutPanel panelBotones;
        private Button btnNuevo;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnVerDetalle;
    }
}
