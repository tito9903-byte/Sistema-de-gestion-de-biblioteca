using SistemaDeGestionDeBiblioteca.Clases;
using System.Data;

namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    public partial class FrmRegistroLibro : Form
    {
        LibroDAO libroDAO = new LibroDAO();

        int idLibro = 0;


        public FrmRegistroLibro()
        {
            InitializeComponent();
        }


        public FrmRegistroLibro(int id)
        {
            InitializeComponent();

            idLibro = id;
        }


        private void FrmRegistroLibro_Load(
            object? sender,
            EventArgs e)
        {
            CargarCategorias();

            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Inactivo");
            cmbEstado.SelectedIndex = 0;

            nudAnio.Value = DateTime.Now.Year;

            if (idLibro > 0)
            {
                CargarLibro();
            }
        }


        private void CargarCategorias()
        {
            try
            {
                cmbCategoria.DataSource =
                    libroDAO.ObtenerCategorias();

                cmbCategoria.DisplayMember =
                    "nombre";

                cmbCategoria.ValueMember =
                    "id_categoria";

                cmbCategoria.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar las categorías.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void CargarLibro()
        {
            try
            {
                DataTable tabla =
                    libroDAO.ObtenerLibro(idLibro);

                if (tabla.Rows.Count == 0)
                    return;


                DataRow fila =
                    tabla.Rows[0];

                txtTitulo.Text =
                    fila["titulo"]?.ToString() ?? "";

                txtAutor.Text =
                    fila["autor"]?.ToString() ?? "";

                txtIsbn.Text =
                    fila["isbn"]?.ToString() ?? "";

                txtEditorial.Text =
                    fila["editorial"]?.ToString() ?? "";

                cmbCategoria.SelectedValue =
                    Convert.ToInt32(fila["id_categoria"]);

                if (fila["anio_publicacion"] != DBNull.Value)
                {
                    nudAnio.Value =
                        Convert.ToInt32(fila["anio_publicacion"]);
                }

                nudEjemplares.Value =
                    Convert.ToInt32(fila["ejemplares_total"]);

                cmbEstado.Text =
                    Convert.ToBoolean(fila["estado"])
                        ? "Activo"
                        : "Inactivo";


                Text = "Editar libro";
                lblEncabezado.Text = "Editar libro";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo cargar el libro.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void btnGuardar_Click(
            object? sender,
            EventArgs e)
        {
            if (txtTitulo.Text.Trim() == "" ||
                txtAutor.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Complete el título y el autor.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }


            if (cmbCategoria.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione una categoría.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }


            string titulo =
                txtTitulo.Text.Trim();

            string autor =
                txtAutor.Text.Trim();

            string? isbn =
                txtIsbn.Text.Trim() == ""
                    ? null
                    : txtIsbn.Text.Trim();

            string? editorial =
                txtEditorial.Text.Trim() == ""
                    ? null
                    : txtEditorial.Text.Trim();

            int idCategoria =
                Convert.ToInt32(cmbCategoria.SelectedValue);

            int anio =
                Convert.ToInt32(nudAnio.Value);

            int ejemplares =
                Convert.ToInt32(nudEjemplares.Value);

            bool estado =
                cmbEstado.Text == "Activo";


            try
            {
                if (isbn != null &&
                    libroDAO.IsbnExisteOtro(isbn, idLibro))
                {
                    MessageBox.Show(
                        "Ya existe un libro con ese ISBN.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }


                bool correcto;

                if (idLibro == 0)
                {
                    correcto =
                        libroDAO.GuardarLibro(
                            titulo,
                            autor,
                            isbn,
                            editorial,
                            idCategoria,
                            anio,
                            ejemplares,
                            estado
                        );
                }
                else
                {
                    correcto =
                        libroDAO.ActualizarLibro(
                            idLibro,
                            titulo,
                            autor,
                            isbn,
                            editorial,
                            idCategoria,
                            anio,
                            ejemplares,
                            estado
                        );

                    if (!correcto)
                    {
                        MessageBox.Show(
                            "Los ejemplares no pueden ser menos que los que están " +
                            "prestados actualmente.",
                            "Aviso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        return;
                    }
                }


                if (correcto)
                {
                    MessageBox.Show(
                        idLibro == 0
                            ? "Libro registrado correctamente."
                            : "Libro actualizado correctamente.",
                        "Libros",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    DialogResult =
                        DialogResult.OK;

                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void btnCancelar_Click(
            object? sender,
            EventArgs e)
        {
            Close();
        }
    }
}
