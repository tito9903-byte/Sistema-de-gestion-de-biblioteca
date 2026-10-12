using SistemaDeGestionDeBiblioteca.Clases;
using System.Data;
using System.Drawing.Printing;
using System.Globalization;

namespace SistemaDeGestionDeBiblioteca.Presentacion
{
    public partial class FrmReportes : Form
    {
        static readonly CultureInfo Cultura = new CultureInfo("es-ES");

        ReporteDAO reporteDAO = new ReporteDAO();

        // Datos del último reporte generado (los usa la exportación a PDF).
        ReporteDAO.Indicadores? ultimosIndicadores;
        DataTable? ultimosLibros;
        DateOnly ultimoDesde;
        DateOnly ultimoHasta;
        string ultimoTipo = ReporteDAO.TipoGeneral;
        string tituloGrafico = "";
        string tituloTabla = "";
        string columnaVeces = "";


        public FrmReportes()
        {
            InitializeComponent();
        }


        private void FrmReportes_Load(
            object? sender,
            EventArgs e)
        {
            DateTime hoy = DateTime.Today;

            dtpDesde.Value = new DateTime(hoy.Year, hoy.Month, 1);
            dtpHasta.Value = hoy;

            cmbTipo.SelectedIndex = 0;

            Generar();
        }


        private void btnGenerar_Click(
            object? sender,
            EventArgs e)
        {
            Generar();
        }


        private bool Generar()
        {
            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show(
                    "La fecha \"Desde\" no puede ser posterior a la fecha \"Hasta\".",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }


            DateOnly desde = DateOnly.FromDateTime(dtpDesde.Value);
            DateOnly hasta = DateOnly.FromDateTime(dtpHasta.Value);
            string tipo = cmbTipo.Text;


            try
            {
                ReporteDAO.Indicadores indicadores =
                    reporteDAO.ObtenerIndicadores(desde, hasta);

                DataTable serie =
                    reporteDAO.ObtenerSerieMensual(tipo, desde, hasta);

                DataTable libros =
                    reporteDAO.ObtenerTopLibros(tipo, desde, hasta, 10);


                tarjetaPrestados.Valor = indicadores.LibrosPrestados.ToString("N0");
                tarjetaUsuarios.Valor = indicadores.UsuariosActivos.ToString("N0");
                tarjetaReservas.Valor = indicadores.Reservas.ToString("N0");
                tarjetaMorosidad.Valor = indicadores.Morosidad.ToString("N0");


                CargarGrafico(serie);

                AplicarTitulos(tipo);

                dgvLibros.DataSource = libros;
                dgvLibros.ClearSelection();


                ultimosIndicadores = indicadores;
                ultimosLibros = libros;
                ultimoDesde = desde;
                ultimoHasta = hasta;
                ultimoTipo = tipo;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo generar el reporte.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
        }


        private static DateTime ComoFecha(object valor)
        {
            if (valor is DateOnly fecha)
                return fecha.ToDateTime(TimeOnly.MinValue);

            return Convert.ToDateTime(valor);
        }


        private void CargarGrafico(DataTable serie)
        {
            bool variosAnios =
                serie.Rows.Count > 0 &&
                ComoFecha(serie.Rows[0]["mes"]).Year !=
                ComoFecha(serie.Rows[serie.Rows.Count - 1]["mes"]).Year;

            List<string> etiquetas = new List<string>();
            List<int> valores = new List<int>();

            foreach (DataRow fila in serie.Rows)
            {
                DateTime mes = ComoFecha(fila["mes"]);

                // Tres letras del mes (Ene, Feb... Sep) y el año si hay varios.
                string etiqueta =
                    mes.ToString("MMM", Cultura).TrimEnd('.');

                etiqueta =
                    char.ToUpper(etiqueta[0], Cultura) +
                    etiqueta.Substring(1, Math.Min(2, etiqueta.Length - 1));

                if (variosAnios)
                    etiqueta += " " + mes.ToString("yy");

                etiquetas.Add(etiqueta);

                valores.Add(Convert.ToInt32(fila["cantidad"]));
            }

            graficoBarras.Cargar(etiquetas, valores);
        }


        // Los títulos cambian según el tipo de reporte.
        private void AplicarTitulos(string tipo)
        {
            switch (tipo)
            {
                case ReporteDAO.TipoDevoluciones:
                    tituloGrafico = "Devoluciones por mes";
                    graficoBarras.TituloEjeY = "Cantidad de devoluciones";
                    tituloTabla = "Libros más devueltos";
                    columnaVeces = "Veces devuelto";
                    break;

                case ReporteDAO.TipoReservas:
                    tituloGrafico = "Reservas por mes";
                    graficoBarras.TituloEjeY = "Cantidad de reservas";
                    tituloTabla = "Libros más reservados";
                    columnaVeces = "Veces reservado";
                    break;

                default:
                    tituloGrafico = "Préstamos por mes";
                    graficoBarras.TituloEjeY = "Cantidad de préstamos";
                    tituloTabla = "Libros más prestados";
                    columnaVeces = "Veces prestado";
                    break;
            }

            lblGraficoTitulo.Text = tituloGrafico;
            lblTablaTitulo.Text = tituloTabla;
            colVeces.HeaderText = columnaVeces;
        }


        private void btnExportarPdf_Click(
            object? sender,
            EventArgs e)
        {
            if (ultimosIndicadores == null && !Generar())
                return;


            using (SaveFileDialog dialogo = new SaveFileDialog())
            {
                dialogo.Title = "Exportar reporte a PDF";
                dialogo.Filter = "Archivo PDF (*.pdf)|*.pdf";
                dialogo.FileName =
                    "Reporte_" + ultimoTipo + "_" +
                    DateTime.Today.ToString("yyyyMMdd") + ".pdf";

                if (dialogo.ShowDialog() != DialogResult.OK)
                    return;


                try
                {
                    ExportarPdf(dialogo.FileName);

                    MessageBox.Show(
                        "Reporte exportado correctamente:\n" + dialogo.FileName,
                        "Exportar PDF",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "No se pudo exportar el reporte.\n" + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }


        // Usa la impresora "Microsoft Print to PDF" que incluye Windows,
        // así no hace falta instalar ningún paquete.
        private void ExportarPdf(string ruta)
        {
            using (PrintDocument documento = new PrintDocument())
            {
                documento.DocumentName = "Reporte de biblioteca";
                documento.PrinterSettings.PrinterName = "Microsoft Print to PDF";

                if (!documento.PrinterSettings.IsValid)
                {
                    throw new InvalidOperationException(
                        "No se encontró la impresora \"Microsoft Print to PDF\" en este equipo."
                    );
                }

                documento.PrinterSettings.PrintToFile = true;
                documento.PrinterSettings.PrintFileName = ruta;

                documento.PrintPage += (s, e) => DibujarReporte(e);

                documento.Print();
            }
        }


        private void DibujarReporte(PrintPageEventArgs e)
        {
            Graphics g = e.Graphics!;
            Rectangle margenes = e.MarginBounds;

            float x = margenes.Left;
            float y = margenes.Top;

            using (Font titulo = new Font("Segoe UI", 22F, FontStyle.Bold))
            using (Font subtitulo = new Font("Segoe UI", 11F))
            using (Font seccion = new Font("Segoe UI", 13F, FontStyle.Bold))
            using (Font texto = new Font("Segoe UI", 10.5F))
            using (Font negrita = new Font("Segoe UI", 10.5F, FontStyle.Bold))
            using (Brush negro = new SolidBrush(Color.FromArgb(20, 20, 30)))
            using (Brush gris = new SolidBrush(Color.FromArgb(80, 100, 130)))
            {
                g.DrawString("Reporte de la biblioteca", titulo, negro, x, y);
                y += titulo.GetHeight(g) + 6;

                g.DrawString(
                    "Tipo: " + ultimoTipo + "     Período: " +
                    ultimoDesde.ToString("dd/MM/yyyy") + " al " +
                    ultimoHasta.ToString("dd/MM/yyyy"),
                    subtitulo, gris, x, y);
                y += subtitulo.GetHeight(g);

                string generado =
                    "Generado el " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");

                if (Sesion.Nombre != "")
                    generado += " por " + Sesion.Nombre;

                g.DrawString(generado, subtitulo, gris, x, y);
                y += subtitulo.GetHeight(g) + 24;


                g.DrawString("Indicadores", seccion, negro, x, y);
                y += seccion.GetHeight(g) + 6;

                if (ultimosIndicadores != null)
                {
                    string[] lineas =
                    {
                        "Libros prestados: " + ultimosIndicadores.LibrosPrestados,
                        "Usuarios activos: " + ultimosIndicadores.UsuariosActivos,
                        "Reservas del período: " + ultimosIndicadores.Reservas,
                        "Morosidad (préstamos con retraso): " + ultimosIndicadores.Morosidad
                    };

                    foreach (string linea in lineas)
                    {
                        g.DrawString(linea, texto, negro, x + 10, y);
                        y += texto.GetHeight(g) + 2;
                    }
                }

                y += 20;


                g.DrawString(tituloGrafico, seccion, negro, x, y);
                y += seccion.GetHeight(g) + 6;

                using (Bitmap imagen = new Bitmap(graficoBarras.Width, graficoBarras.Height))
                {
                    graficoBarras.DrawToBitmap(
                        imagen,
                        new Rectangle(0, 0, imagen.Width, imagen.Height)
                    );

                    float ancho = Math.Min(margenes.Width, 650);
                    float alto = ancho * imagen.Height / imagen.Width;

                    g.DrawImage(imagen, x, y, ancho, alto);
                    y += alto + 20;
                }


                g.DrawString(tituloTabla, seccion, negro, x, y);
                y += seccion.GetHeight(g) + 6;

                float colVecesX = x + 380;
                float colCategoriaX = x + 500;

                g.DrawString("Título", negrita, negro, x + 10, y);
                g.DrawString(columnaVeces, negrita, negro, colVecesX, y);
                g.DrawString("Categoría", negrita, negro, colCategoriaX, y);
                y += negrita.GetHeight(g) + 4;

                if (ultimosLibros != null)
                {
                    foreach (DataRow fila in ultimosLibros.Rows)
                    {
                        if (y > margenes.Bottom - 20)
                            break;

                        g.DrawString(
                            fila["titulo"].ToString(), texto, negro,
                            new RectangleF(x + 10, y, 360, texto.GetHeight(g) + 2),
                            new StringFormat { Trimming = StringTrimming.EllipsisCharacter, FormatFlags = StringFormatFlags.NoWrap });

                        g.DrawString(fila["veces"].ToString(), texto, negro, colVecesX, y);
                        g.DrawString(fila["categoria"].ToString(), texto, negro, colCategoriaX, y);

                        y += texto.GetHeight(g) + 2;
                    }
                }
            }

            e.HasMorePages = false;
        }
    }
}
