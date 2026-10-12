using SistemaDeGestionDeBiblioteca.Clases;
using System.Data;
using System.Drawing.Drawing2D;

namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    public partial class FrmUsuarios : Form
    {
        UsuarioDAO usuarioDAO = new UsuarioDAO();

        // Formulario de alta/edición que se muestra en el panel derecho.
        FrmRegistroUsuario? formularioActual;

        // true mientras se recarga la tabla, para ignorar los cambios de selección.
        bool actualizando;

        const int TamanoBoton = 30;
        const int SeparacionBotones = 6;

        static readonly Color ColorEditar = Color.FromArgb(30, 120, 240);
        static readonly Color ColorEstado = Color.FromArgb(240, 160, 20);
        static readonly Color ColorEliminar = Color.FromArgb(228, 55, 65);


        public FrmUsuarios()
        {
            InitializeComponent();
        }


        private void FrmUsuarios_Load(
            object? sender,
            EventArgs e)
        {
            ConfigurarFiltros();
            CargarUsuarios();
            MostrarFormulario(0);
        }


        private void ConfigurarFiltros()
        {
            actualizando = true;

            try
            {
                cmbFiltroRol.Items.Clear();
                cmbFiltroRol.Items.Add("Todos");

                foreach (DataRow fila in usuarioDAO.ObtenerRoles().Rows)
                {
                    cmbFiltroRol.Items.Add(fila["nombre_rol"].ToString() ?? "");
                }

                cmbFiltroRol.SelectedIndex = 0;

                cmbFiltroEstado.Items.Clear();
                cmbFiltroEstado.Items.Add("Todos");
                cmbFiltroEstado.Items.Add("Activo");
                cmbFiltroEstado.Items.Add("Inactivo");
                cmbFiltroEstado.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los roles.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                actualizando = false;
            }
        }


        // Aplica la búsqueda por texto (en la base de datos) y los filtros
        // de rol y estado (sobre los resultados).
        private void CargarUsuarios()
        {
            actualizando = true;

            try
            {
                string texto =
                    txtBuscar.Text.Trim();

                DataTable tabla =
                    texto == ""
                        ? usuarioDAO.ListarUsuarios()
                        : usuarioDAO.BuscarUsuarios(texto);

                DataView vista =
                    tabla.DefaultView;

                vista.RowFilter =
                    ConstruirFiltro();

                dgvUsuarios.DataSource =
                    vista;

                lblTotal.Text =
                    "Total: " + vista.Count + " usuarios";

                dgvUsuarios.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los usuarios.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                actualizando = false;
            }
        }


        private string ConstruirFiltro()
        {
            List<string> condiciones = new List<string>();

            if (cmbFiltroRol.SelectedIndex > 0)
            {
                condiciones.Add(
                    "nombre_rol = '" +
                    cmbFiltroRol.Text.Replace("'", "''") + "'"
                );
            }

            if (cmbFiltroEstado.SelectedIndex == 1)
                condiciones.Add("estado_valor = true");
            else if (cmbFiltroEstado.SelectedIndex == 2)
                condiciones.Add("estado_valor = false");

            return string.Join(" AND ", condiciones);
        }


        private int ObtenerIdUsuario()
        {
            if (dgvUsuarios.CurrentRow == null)
                return 0;


            object? valor =
                dgvUsuarios
                    .CurrentRow
                    .Cells[colId.Index]
                    .Value;


            if (valor == null)
                return 0;


            return Convert.ToInt32(valor);
        }


        // Muestra el formulario de usuario en el panel derecho.
        // idUsuario = 0 para un usuario nuevo.
        private void MostrarFormulario(int idUsuario)
        {
            if (formularioActual != null)
            {
                panelFormulario.Controls.Remove(formularioActual);
                formularioActual.Dispose();
            }

            FrmRegistroUsuario formulario =
                idUsuario > 0
                    ? new FrmRegistroUsuario(idUsuario)
                    : new FrmRegistroUsuario();

            formulario.Finalizado += Formulario_Finalizado;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            panelFormulario.Controls.Add(formulario);
            formulario.Show();

            formularioActual = formulario;

            lblInformacion.Text =
                idUsuario > 0
                    ? "Editar usuario"
                    : "Nuevo usuario";
        }


        private void Formulario_Finalizado(bool guardado)
        {
            // Se hace después, para no destruir el formulario dentro de su propio evento.
            BeginInvoke(new Action(() =>
            {
                if (guardado)
                    CargarUsuarios();
                else
                    dgvUsuarios.ClearSelection();

                MostrarFormulario(0);
            }));
        }


        private void dgvUsuarios_SelectionChanged(
            object? sender,
            EventArgs e)
        {
            if (actualizando ||
                dgvUsuarios.SelectedRows.Count == 0)
            {
                return;
            }

            // Se usa la fila seleccionada (CurrentRow todavía puede ser la anterior).
            object? valor =
                dgvUsuarios.SelectedRows[0].Cells[colId.Index].Value;

            if (valor != null)
                MostrarFormulario(Convert.ToInt32(valor));
        }


        private void txtBuscar_TextChanged(
            object? sender,
            EventArgs e)
        {
            CargarUsuarios();
        }


        private void cmbFiltro_SelectedIndexChanged(
            object? sender,
            EventArgs e)
        {
            if (actualizando)
                return;

            CargarUsuarios();
        }


        private void btnBuscar_Click(
            object? sender,
            EventArgs e)
        {
            CargarUsuarios();
        }


        private void btnNuevo_Click(
            object? sender,
            EventArgs e)
        {
            dgvUsuarios.ClearSelection();

            MostrarFormulario(0);
        }


        private void btnEditar_Click(
            object? sender,
            EventArgs e)
        {
            int idUsuario =
                ObtenerIdUsuario();


            if (idUsuario == 0)
            {
                MessageBox.Show(
                    "Seleccione un usuario.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            MostrarFormulario(idUsuario);
        }


        private void btnEliminar_Click(
            object? sender,
            EventArgs e)
        {
            int idUsuario =
                ObtenerIdUsuario();


            if (idUsuario == 0)
            {
                MessageBox.Show(
                    "Seleccione un usuario.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }


            DialogResult respuesta =
                MessageBox.Show(
                    "¿Seguro que desea eliminar este usuario?",
                    "Eliminar usuario",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );


            if (respuesta != DialogResult.Yes)
                return;


            try
            {
                bool eliminado =
                    usuarioDAO.EliminarUsuario(
                        idUsuario
                    );


                if (eliminado)
                {
                    MessageBox.Show(
                        "Usuario eliminado correctamente.",
                        "Usuarios",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );


                    CargarUsuarios();
                    MostrarFormulario(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo eliminar el usuario.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void btnActivarDesactivar_Click(
            object? sender,
            EventArgs e)
        {
            int idUsuario =
                ObtenerIdUsuario();


            if (idUsuario == 0 ||
                dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione un usuario.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }


            DataRowView? fila =
                dgvUsuarios.CurrentRow.DataBoundItem as DataRowView;

            if (fila == null)
                return;


            bool estadoActual =
                Convert.ToBoolean(fila["estado_valor"]);

            bool nuevoEstado =
                !estadoActual;


            string accion;


            if (nuevoEstado)
                accion = "activar";
            else
                accion = "desactivar";


            DialogResult respuesta =
                MessageBox.Show(
                    "¿Desea " + accion + " este usuario?",
                    "Cambiar estado",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );


            if (respuesta != DialogResult.Yes)
                return;


            try
            {
                bool cambiado =
                    usuarioDAO.CambiarEstado(
                        idUsuario,
                        nuevoEstado
                    );


                if (cambiado)
                {
                    CargarUsuarios();
                    MostrarFormulario(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo cambiar el estado.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        // ---------- Dibujo de las columnas Rol, Estado y Acciones ----------

        private void dgvUsuarios_CellPainting(
            object? sender,
            DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Graphics == null)
                return;


            if (e.ColumnIndex == colRol.Index ||
                e.ColumnIndex == colEstado.Index)
            {
                e.PaintBackground(e.CellBounds, true);

                string texto =
                    e.Value?.ToString() ?? "";

                (Color fondo, Color letra) =
                    ColoresPildora(texto);

                DibujarPildora(e.Graphics, e.CellBounds, texto, fondo, letra);

                e.Handled = true;
            }
            else if (e.ColumnIndex == colAcciones.Index)
            {
                e.PaintBackground(e.CellBounds, true);

                Rectangle[] botones =
                    RectangulosAcciones(e.CellBounds);

                DibujarBoton(e.Graphics, botones[0], ColorEditar, "");
                DibujarBoton(e.Graphics, botones[1], ColorEstado, "");
                DibujarBoton(e.Graphics, botones[2], ColorEliminar, "");

                e.Handled = true;
            }
        }


        private static (Color fondo, Color letra) ColoresPildora(string texto)
        {
            switch (texto)
            {
                case "Administrador":
                    return (Color.FromArgb(219, 234, 254), Color.FromArgb(30, 64, 175));

                case "Bibliotecario":
                    return (Color.FromArgb(237, 224, 254), Color.FromArgb(109, 40, 217));

                case "Activo":
                    return (Color.FromArgb(205, 238, 212), Color.FromArgb(20, 110, 40));

                case "Inactivo":
                    return (Color.FromArgb(253, 214, 214), Color.FromArgb(185, 28, 28));

                default:
                    return (Color.FromArgb(232, 234, 238), Color.FromArgb(70, 80, 95));
            }
        }


        private void DibujarPildora(
            Graphics g,
            Rectangle celda,
            string texto,
            Color fondo,
            Color letra)
        {
            using (Font fuente = new Font("Segoe UI", 9F, FontStyle.Bold))
            {
                Size medida =
                    TextRenderer.MeasureText(texto, fuente);

                Rectangle pildora =
                    new Rectangle(
                        celda.Left + 8,
                        celda.Top + (celda.Height - 24) / 2,
                        medida.Width + 14,
                        24
                    );

                g.SmoothingMode = SmoothingMode.AntiAlias;

                using (GraphicsPath ruta = RectanguloRedondeado(pildora, 12))
                using (SolidBrush pincel = new SolidBrush(fondo))
                {
                    g.FillPath(pincel, ruta);
                }

                TextRenderer.DrawText(
                    g,
                    texto,
                    fuente,
                    pildora,
                    letra,
                    TextFormatFlags.HorizontalCenter |
                    TextFormatFlags.VerticalCenter |
                    TextFormatFlags.NoPadding
                );
            }
        }


        private void DibujarBoton(
            Graphics g,
            Rectangle area,
            Color color,
            string icono)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath ruta = RectanguloRedondeado(area, 7))
            using (SolidBrush pincel = new SolidBrush(color))
            {
                g.FillPath(pincel, ruta);
            }

            using (Font fuente = new Font("Segoe MDL2 Assets", 11F))
            {
                TextRenderer.DrawText(
                    g,
                    icono,
                    fuente,
                    area,
                    Color.White,
                    TextFormatFlags.HorizontalCenter |
                    TextFormatFlags.VerticalCenter |
                    TextFormatFlags.NoPadding
                );
            }
        }


        // Editar, activar/desactivar y eliminar, de izquierda a derecha.
        private static Rectangle[] RectangulosAcciones(Rectangle celda)
        {
            int y = celda.Top + (celda.Height - TamanoBoton) / 2;
            int x = celda.Left + 8;

            Rectangle[] botones = new Rectangle[3];

            for (int i = 0; i < 3; i++)
            {
                botones[i] =
                    new Rectangle(
                        x + i * (TamanoBoton + SeparacionBotones),
                        y,
                        TamanoBoton,
                        TamanoBoton
                    );
            }

            return botones;
        }


        private static GraphicsPath RectanguloRedondeado(
            Rectangle area,
            int radio)
        {
            int d = radio * 2;

            GraphicsPath ruta = new GraphicsPath();

            ruta.AddArc(area.X, area.Y, d, d, 180, 90);
            ruta.AddArc(area.Right - d, area.Y, d, d, 270, 90);
            ruta.AddArc(area.Right - d, area.Bottom - d, d, d, 0, 90);
            ruta.AddArc(area.X, area.Bottom - d, d, d, 90, 90);
            ruta.CloseFigure();

            return ruta;
        }


        // Devuelve el botón de acciones (0, 1 o 2) bajo el punto, o -1.
        private int BotonAccionEn(int columna, int fila, Point punto)
        {
            Rectangle celda =
                dgvUsuarios.GetCellDisplayRectangle(columna, fila, false);

            Rectangle[] botones =
                RectangulosAcciones(new Rectangle(0, 0, celda.Width, celda.Height));

            for (int i = 0; i < botones.Length; i++)
            {
                if (botones[i].Contains(punto))
                    return i;
            }

            return -1;
        }


        private void dgvUsuarios_CellMouseMove(
            object? sender,
            DataGridViewCellMouseEventArgs e)
        {
            bool sobreBoton =
                e.RowIndex >= 0 &&
                e.ColumnIndex == colAcciones.Index &&
                BotonAccionEn(e.ColumnIndex, e.RowIndex, e.Location) >= 0;

            dgvUsuarios.Cursor =
                sobreBoton
                    ? Cursors.Hand
                    : Cursors.Default;
        }


        private void dgvUsuarios_CellMouseClick(
            object? sender,
            DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.ColumnIndex != colAcciones.Index)
            {
                return;
            }

            int boton =
                BotonAccionEn(e.ColumnIndex, e.RowIndex, e.Location);

            if (boton < 0)
                return;


            // Deja la fila como actual sin recargar el formulario de la derecha.
            actualizando = true;
            dgvUsuarios.CurrentCell = dgvUsuarios.Rows[e.RowIndex].Cells[colNombre.Index];
            actualizando = false;


            switch (boton)
            {
                case 0:
                    btnEditar_Click(null, EventArgs.Empty);
                    break;

                case 1:
                    btnActivarDesactivar_Click(null, EventArgs.Empty);
                    break;

                case 2:
                    btnEliminar_Click(null, EventArgs.Empty);
                    break;
            }
        }
    }
}
