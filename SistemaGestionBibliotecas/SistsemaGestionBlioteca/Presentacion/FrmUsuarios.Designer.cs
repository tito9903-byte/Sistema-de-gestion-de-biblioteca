namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    partial class FrmUsuarios
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
            DataGridViewCellStyle estiloFecha = new DataGridViewCellStyle();
            tlpPrincipal = new TableLayoutPanel();
            panelEncabezado = new Panel();
            panelNuevo = new Panel();
            btnNuevo = new Button();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            panelFiltros = new Controles.PanelTarjeta();
            panelBuscar = new Panel();
            btnBuscar = new Button();
            cmbFiltroEstado = new ComboBox();
            lblFiltroEstado = new Label();
            cmbFiltroRol = new ComboBox();
            lblFiltroRol = new Label();
            txtBuscar = new TextBox();
            lblBuscar = new Label();
            tlpCuerpo = new TableLayoutPanel();
            panelLista = new Controles.PanelTarjeta();
            dgvUsuarios = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colUsuario = new DataGridViewTextBoxColumn();
            colFechaCreacion = new DataGridViewTextBoxColumn();
            colRol = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            colAcciones = new DataGridViewTextBoxColumn();
            panelTituloLista = new Panel();
            lblLista = new Label();
            lblTotal = new Label();
            panelDetalle = new Controles.PanelTarjeta();
            panelFormulario = new Panel();
            lblInformacion = new Label();
            tlpPrincipal.SuspendLayout();
            panelEncabezado.SuspendLayout();
            panelNuevo.SuspendLayout();
            panelFiltros.SuspendLayout();
            panelBuscar.SuspendLayout();
            tlpCuerpo.SuspendLayout();
            panelLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            panelTituloLista.SuspendLayout();
            panelDetalle.SuspendLayout();
            SuspendLayout();
            //
            // tlpPrincipal
            //
            tlpPrincipal.BackColor = Color.Transparent;
            tlpPrincipal.ColumnCount = 1;
            tlpPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpPrincipal.Controls.Add(panelEncabezado, 0, 0);
            tlpPrincipal.Controls.Add(panelFiltros, 0, 1);
            tlpPrincipal.Controls.Add(tlpCuerpo, 0, 2);
            tlpPrincipal.Dock = DockStyle.Fill;
            tlpPrincipal.Location = new Point(24, 16);
            tlpPrincipal.Margin = new Padding(0);
            tlpPrincipal.Name = "tlpPrincipal";
            tlpPrincipal.RowCount = 3;
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 92F));
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpPrincipal.Size = new Size(1098, 732);
            tlpPrincipal.TabIndex = 0;
            //
            // panelEncabezado
            //
            panelEncabezado.Controls.Add(panelNuevo);
            panelEncabezado.Controls.Add(lblSubtitulo);
            panelEncabezado.Controls.Add(lblTitulo);
            panelEncabezado.Dock = DockStyle.Fill;
            panelEncabezado.Location = new Point(0, 0);
            panelEncabezado.Margin = new Padding(0);
            panelEncabezado.Name = "panelEncabezado";
            panelEncabezado.Size = new Size(1098, 88);
            panelEncabezado.TabIndex = 0;
            //
            // panelNuevo
            //
            panelNuevo.Controls.Add(btnNuevo);
            panelNuevo.Dock = DockStyle.Right;
            panelNuevo.Location = new Point(878, 0);
            panelNuevo.Name = "panelNuevo";
            panelNuevo.Size = new Size(220, 88);
            panelNuevo.TabIndex = 2;
            //
            // btnNuevo
            //
            btnNuevo.BackColor = Color.FromArgb(0, 120, 235);
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 140, 250);
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI", 11F);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(10, 8);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(210, 52);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "＋   Nuevo Usuario";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            //
            // lblSubtitulo
            //
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 11F);
            lblSubtitulo.ForeColor = Color.FromArgb(80, 100, 130);
            lblSubtitulo.Location = new Point(4, 56);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(212, 20);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Gestión de usuarios del sistema";
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(20, 20, 30);
            lblTitulo.Location = new Point(0, 4);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(133, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Usuarios";
            //
            // panelFiltros
            //
            panelFiltros.BackColor = Color.White;
            panelFiltros.ColorBorde = Color.FromArgb(222, 226, 232);
            panelFiltros.Controls.Add(panelBuscar);
            panelFiltros.Controls.Add(cmbFiltroEstado);
            panelFiltros.Controls.Add(lblFiltroEstado);
            panelFiltros.Controls.Add(cmbFiltroRol);
            panelFiltros.Controls.Add(lblFiltroRol);
            panelFiltros.Controls.Add(txtBuscar);
            panelFiltros.Controls.Add(lblBuscar);
            panelFiltros.Dock = DockStyle.Fill;
            panelFiltros.Location = new Point(0, 88);
            panelFiltros.Margin = new Padding(0, 0, 0, 16);
            panelFiltros.Name = "panelFiltros";
            panelFiltros.Size = new Size(1098, 76);
            panelFiltros.TabIndex = 1;
            //
            // lblBuscar
            //
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBuscar.ForeColor = Color.FromArgb(20, 20, 30);
            lblBuscar.Location = new Point(20, 8);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(52, 19);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar";
            //
            // txtBuscar
            //
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Segoe UI", 11F);
            txtBuscar.Location = new Point(20, 32);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar por usuario, nombre o rol...";
            txtBuscar.Size = new Size(320, 27);
            txtBuscar.TabIndex = 0;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            //
            // lblFiltroRol
            //
            lblFiltroRol.AutoSize = true;
            lblFiltroRol.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFiltroRol.ForeColor = Color.FromArgb(20, 20, 30);
            lblFiltroRol.Location = new Point(360, 8);
            lblFiltroRol.Name = "lblFiltroRol";
            lblFiltroRol.Size = new Size(28, 19);
            lblFiltroRol.TabIndex = 1;
            lblFiltroRol.Text = "Rol";
            //
            // cmbFiltroRol
            //
            cmbFiltroRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroRol.Font = new Font("Segoe UI", 11F);
            cmbFiltroRol.FormattingEnabled = true;
            cmbFiltroRol.Location = new Point(360, 31);
            cmbFiltroRol.Name = "cmbFiltroRol";
            cmbFiltroRol.Size = new Size(220, 28);
            cmbFiltroRol.TabIndex = 1;
            cmbFiltroRol.SelectedIndexChanged += cmbFiltro_SelectedIndexChanged;
            //
            // lblFiltroEstado
            //
            lblFiltroEstado.AutoSize = true;
            lblFiltroEstado.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFiltroEstado.ForeColor = Color.FromArgb(20, 20, 30);
            lblFiltroEstado.Location = new Point(600, 8);
            lblFiltroEstado.Name = "lblFiltroEstado";
            lblFiltroEstado.Size = new Size(50, 19);
            lblFiltroEstado.TabIndex = 2;
            lblFiltroEstado.Text = "Estado";
            //
            // cmbFiltroEstado
            //
            cmbFiltroEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroEstado.Font = new Font("Segoe UI", 11F);
            cmbFiltroEstado.FormattingEnabled = true;
            cmbFiltroEstado.Location = new Point(600, 31);
            cmbFiltroEstado.Name = "cmbFiltroEstado";
            cmbFiltroEstado.Size = new Size(200, 28);
            cmbFiltroEstado.TabIndex = 2;
            cmbFiltroEstado.SelectedIndexChanged += cmbFiltro_SelectedIndexChanged;
            //
            // panelBuscar
            //
            panelBuscar.BackColor = Color.Transparent;
            panelBuscar.Controls.Add(btnBuscar);
            panelBuscar.Dock = DockStyle.Right;
            panelBuscar.Location = new Point(908, 1);
            panelBuscar.Name = "panelBuscar";
            panelBuscar.Size = new Size(189, 74);
            panelBuscar.TabIndex = 6;
            //
            // btnBuscar
            //
            btnBuscar.BackColor = Color.FromArgb(0, 120, 235);
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 140, 250);
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI", 11F);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(10, 26);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(160, 36);
            btnBuscar.TabIndex = 0;
            btnBuscar.Text = "🔍   Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            //
            // tlpCuerpo
            //
            tlpCuerpo.BackColor = Color.Transparent;
            tlpCuerpo.ColumnCount = 2;
            tlpCuerpo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66F));
            tlpCuerpo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tlpCuerpo.Controls.Add(panelLista, 0, 0);
            tlpCuerpo.Controls.Add(panelDetalle, 1, 0);
            tlpCuerpo.Dock = DockStyle.Fill;
            tlpCuerpo.Location = new Point(0, 180);
            tlpCuerpo.Margin = new Padding(0);
            tlpCuerpo.Name = "tlpCuerpo";
            tlpCuerpo.RowCount = 1;
            tlpCuerpo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpCuerpo.Size = new Size(1098, 552);
            tlpCuerpo.TabIndex = 2;
            //
            // panelLista
            //
            panelLista.BackColor = Color.White;
            panelLista.ColorBorde = Color.FromArgb(222, 226, 232);
            panelLista.Controls.Add(dgvUsuarios);
            panelLista.Controls.Add(panelTituloLista);
            panelLista.Dock = DockStyle.Fill;
            panelLista.Location = new Point(0, 0);
            panelLista.Margin = new Padding(0, 0, 16, 0);
            panelLista.Name = "panelLista";
            panelLista.Padding = new Padding(16, 12, 16, 16);
            panelLista.Size = new Size(664, 552);
            panelLista.TabIndex = 0;
            //
            // dgvUsuarios
            //
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AllowUserToResizeRows = false;
            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.BackgroundColor = Color.White;
            dgvUsuarios.BorderStyle = BorderStyle.None;
            dgvUsuarios.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUsuarios.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            estiloEncabezado.Alignment = DataGridViewContentAlignment.MiddleLeft;
            estiloEncabezado.BackColor = Color.FromArgb(243, 246, 250);
            estiloEncabezado.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            estiloEncabezado.ForeColor = Color.FromArgb(50, 60, 80);
            estiloEncabezado.SelectionBackColor = Color.FromArgb(243, 246, 250);
            estiloEncabezado.SelectionForeColor = Color.FromArgb(50, 60, 80);
            estiloEncabezado.WrapMode = DataGridViewTriState.False;
            dgvUsuarios.ColumnHeadersDefaultCellStyle = estiloEncabezado;
            dgvUsuarios.ColumnHeadersHeight = 40;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvUsuarios.Columns.AddRange(new DataGridViewColumn[] { colId, colNombre, colUsuario, colFechaCreacion, colRol, colEstado, colAcciones });
            estiloCelda.Alignment = DataGridViewContentAlignment.MiddleLeft;
            estiloCelda.BackColor = Color.White;
            estiloCelda.Font = new Font("Segoe UI", 10F);
            estiloCelda.ForeColor = Color.FromArgb(30, 30, 30);
            estiloCelda.SelectionBackColor = Color.FromArgb(222, 235, 253);
            estiloCelda.SelectionForeColor = Color.FromArgb(20, 20, 30);
            estiloCelda.WrapMode = DataGridViewTriState.False;
            dgvUsuarios.DefaultCellStyle = estiloCelda;
            dgvUsuarios.Dock = DockStyle.Fill;
            dgvUsuarios.EnableHeadersVisualStyles = false;
            dgvUsuarios.GridColor = Color.FromArgb(232, 235, 240);
            dgvUsuarios.Location = new Point(16, 52);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.RowTemplate.Height = 46;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(632, 484);
            dgvUsuarios.TabIndex = 1;
            dgvUsuarios.CellMouseClick += dgvUsuarios_CellMouseClick;
            dgvUsuarios.CellMouseMove += dgvUsuarios_CellMouseMove;
            dgvUsuarios.CellPainting += dgvUsuarios_CellPainting;
            dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged;
            //
            // colId
            //
            colId.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colId.DataPropertyName = "id_usuario";
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Width = 50;
            //
            // colNombre
            //
            colNombre.DataPropertyName = "nombre";
            colNombre.FillWeight = 22F;
            colNombre.HeaderText = "Nombre";
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            //
            // colUsuario
            //
            colUsuario.DataPropertyName = "usuario";
            colUsuario.FillWeight = 15F;
            colUsuario.HeaderText = "Usuario";
            colUsuario.Name = "colUsuario";
            colUsuario.ReadOnly = true;
            //
            // colFechaCreacion
            //
            estiloFecha.Format = "dd/MM/yyyy";
            colFechaCreacion.DataPropertyName = "fecha_creacion";
            colFechaCreacion.DefaultCellStyle = estiloFecha;
            colFechaCreacion.FillWeight = 16F;
            colFechaCreacion.HeaderText = "Creado";
            colFechaCreacion.Name = "colFechaCreacion";
            colFechaCreacion.ReadOnly = true;
            //
            // colRol
            //
            colRol.DataPropertyName = "nombre_rol";
            colRol.FillWeight = 27F;
            colRol.HeaderText = "Rol";
            colRol.Name = "colRol";
            colRol.ReadOnly = true;
            //
            // colEstado
            //
            colEstado.DataPropertyName = "estado";
            colEstado.FillWeight = 20F;
            colEstado.HeaderText = "Estado";
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            //
            // colAcciones
            //
            colAcciones.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colAcciones.HeaderText = "Acciones";
            colAcciones.Name = "colAcciones";
            colAcciones.ReadOnly = true;
            colAcciones.Width = 118;
            //
            // panelTituloLista
            //
            panelTituloLista.Controls.Add(lblLista);
            panelTituloLista.Controls.Add(lblTotal);
            panelTituloLista.Dock = DockStyle.Top;
            panelTituloLista.Location = new Point(16, 12);
            panelTituloLista.Name = "panelTituloLista";
            panelTituloLista.Size = new Size(632, 40);
            panelTituloLista.TabIndex = 0;
            //
            // lblTotal
            //
            lblTotal.Dock = DockStyle.Right;
            lblTotal.Font = new Font("Segoe UI", 10.5F);
            lblTotal.ForeColor = Color.FromArgb(90, 105, 130);
            lblTotal.Location = new Point(452, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(180, 40);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "Total: 0 usuarios";
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblLista
            //
            lblLista.Dock = DockStyle.Fill;
            lblLista.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblLista.ForeColor = Color.FromArgb(20, 20, 30);
            lblLista.Location = new Point(0, 0);
            lblLista.Name = "lblLista";
            lblLista.Size = new Size(452, 40);
            lblLista.TabIndex = 0;
            lblLista.Text = "Lista de Usuarios";
            lblLista.TextAlign = ContentAlignment.MiddleLeft;
            //
            // panelDetalle
            //
            panelDetalle.BackColor = Color.White;
            panelDetalle.ColorBorde = Color.FromArgb(222, 226, 232);
            panelDetalle.Controls.Add(panelFormulario);
            panelDetalle.Controls.Add(lblInformacion);
            panelDetalle.Dock = DockStyle.Fill;
            panelDetalle.Location = new Point(680, 0);
            panelDetalle.Margin = new Padding(0);
            panelDetalle.Name = "panelDetalle";
            panelDetalle.Padding = new Padding(20, 12, 20, 16);
            panelDetalle.Size = new Size(418, 552);
            panelDetalle.TabIndex = 1;
            //
            // panelFormulario
            //
            panelFormulario.Dock = DockStyle.Fill;
            panelFormulario.Location = new Point(20, 52);
            panelFormulario.Name = "panelFormulario";
            panelFormulario.Size = new Size(378, 484);
            panelFormulario.TabIndex = 1;
            //
            // lblInformacion
            //
            lblInformacion.Dock = DockStyle.Top;
            lblInformacion.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblInformacion.ForeColor = Color.FromArgb(20, 20, 30);
            lblInformacion.Location = new Point(20, 12);
            lblInformacion.Name = "lblInformacion";
            lblInformacion.Size = new Size(378, 40);
            lblInformacion.TabIndex = 0;
            lblInformacion.Text = "Nuevo usuario";
            lblInformacion.TextAlign = ContentAlignment.MiddleLeft;
            //
            // FrmUsuarios
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 248);
            ClientSize = new Size(1146, 768);
            Controls.Add(tlpPrincipal);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmUsuarios";
            Padding = new Padding(24, 16, 24, 20);
            Text = "Administración de Usuarios";
            Load += FrmUsuarios_Load;
            tlpPrincipal.ResumeLayout(false);
            panelEncabezado.ResumeLayout(false);
            panelEncabezado.PerformLayout();
            panelNuevo.ResumeLayout(false);
            panelFiltros.ResumeLayout(false);
            panelFiltros.PerformLayout();
            panelBuscar.ResumeLayout(false);
            tlpCuerpo.ResumeLayout(false);
            panelLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            panelTituloLista.ResumeLayout(false);
            panelDetalle.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpPrincipal;
        private Panel panelEncabezado;
        private Panel panelNuevo;
        private Button btnNuevo;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Controles.PanelTarjeta panelFiltros;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Label lblFiltroRol;
        private ComboBox cmbFiltroRol;
        private Label lblFiltroEstado;
        private ComboBox cmbFiltroEstado;
        private Panel panelBuscar;
        private Button btnBuscar;
        private TableLayoutPanel tlpCuerpo;
        private Controles.PanelTarjeta panelLista;
        private Panel panelTituloLista;
        private Label lblLista;
        private Label lblTotal;
        private DataGridView dgvUsuarios;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colUsuario;
        private DataGridViewTextBoxColumn colFechaCreacion;
        private DataGridViewTextBoxColumn colRol;
        private DataGridViewTextBoxColumn colEstado;
        private DataGridViewTextBoxColumn colAcciones;
        private Controles.PanelTarjeta panelDetalle;
        private Label lblInformacion;
        private Panel panelFormulario;
    }
}
