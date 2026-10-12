using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace SistemaDeGestionDeBiblioteca.Presentacion.Controles
{
    // Gráfico de barras sencillo dibujado con GDI+ (sin paquetes externos).
    // Los datos se asignan con Cargar(); en el diseñador muestra datos de muestra.
    public class GraficoBarras : Control
    {
        string[] etiquetas = Array.Empty<string>();
        int[] valores = Array.Empty<int>();

        Color colorBarras = Color.FromArgb(74, 150, 228);
        string tituloEjeY = "Cantidad";


        public GraficoBarras()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
            BackColor = Color.White;
            Font = new Font("Segoe UI", 9.5F);
        }


        [Category("Gráfico")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Color de las barras.")]
        public Color ColorBarras
        {
            get { return colorBarras; }
            set
            {
                colorBarras = value;
                Invalidate();
            }
        }


        [Category("Gráfico")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Texto del eje vertical.")]
        public string TituloEjeY
        {
            get { return tituloEjeY; }
            set
            {
                tituloEjeY = value;
                Invalidate();
            }
        }


        public void Cargar(IList<string> nuevasEtiquetas, IList<int> nuevosValores)
        {
            etiquetas = nuevasEtiquetas.ToArray();
            valores = nuevosValores.ToArray();

            Invalidate();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            string[] et = etiquetas;
            int[] val = valores;

            if (DesignMode && et.Length == 0)
            {
                et = new[] { "Ene", "Feb", "Mar", "Abr", "May", "Jun" };
                val = new[] { 28, 34, 42, 37, 51, 46 };
            }

            int izquierda = 70;
            int derecha = 16;
            int arriba = 28;
            int abajo = 34;

            Rectangle area = new Rectangle(
                izquierda,
                arriba,
                Width - izquierda - derecha,
                Height - arriba - abajo
            );

            if (area.Width < 40 || area.Height < 40)
                return;


            if (et.Length == 0)
            {
                using (Brush gris = new SolidBrush(Color.FromArgb(110, 120, 140)))
                using (StringFormat centro = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                })
                {
                    g.DrawString("Sin datos para mostrar", Font, gris, ClientRectangle, centro);
                }

                return;
            }


            int maximo = val.Length == 0 ? 0 : val.Max();
            int paso = PasoAgradable(maximo);
            int tope = Math.Max(paso, (int)Math.Ceiling(maximo / (double)paso) * paso);

            using (Pen rejilla = new Pen(Color.FromArgb(226, 229, 234)))
            using (Pen ejes = new Pen(Color.FromArgb(150, 155, 165)))
            using (Brush texto = new SolidBrush(Color.FromArgb(50, 55, 70)))
            using (StringFormat derechaVCentro = new StringFormat
            {
                Alignment = StringAlignment.Far,
                LineAlignment = StringAlignment.Center
            })
            {
                // Rejilla y valores del eje vertical.
                for (int v = 0; v <= tope; v += paso)
                {
                    float y = area.Bottom - (float)v / tope * area.Height;

                    g.DrawLine(rejilla, area.Left, y, area.Right, y);

                    g.DrawString(
                        v.ToString(),
                        Font,
                        texto,
                        new RectangleF(area.Left - 40, y - 10, 36, 20),
                        derechaVCentro
                    );
                }

                g.DrawLine(ejes, area.Left, area.Top, area.Left, area.Bottom);
                g.DrawLine(ejes, area.Left, area.Bottom, area.Right, area.Bottom);


                // Título del eje vertical, girado.
                GraphicsState estado = g.Save();
                g.TranslateTransform(14, area.Top + area.Height / 2f);
                g.RotateTransform(-90);

                using (StringFormat centro = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                })
                {
                    g.DrawString(tituloEjeY, Font, texto, 0, 0, centro);
                }

                g.Restore(estado);


                // Barras, valores y etiquetas.
                float ancho = area.Width / (float)et.Length;
                float anchoBarra = Math.Min(ancho * 0.6f, 72f);

                using (Brush barra = new SolidBrush(colorBarras))
                using (Font negrita = new Font(Font, FontStyle.Bold))
                using (Font pequena = new Font(Font.FontFamily, ancho < 48 ? 8F : Font.Size))
                using (StringFormat arribaCentro = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Far
                })
                using (StringFormat abajoCentro = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Near
                })
                {
                    for (int i = 0; i < et.Length; i++)
                    {
                        float centroX = area.Left + ancho * i + ancho / 2f;
                        float alto = (float)val[i] / tope * area.Height;

                        RectangleF rectBarra = new RectangleF(
                            centroX - anchoBarra / 2f,
                            area.Bottom - alto,
                            anchoBarra,
                            alto
                        );

                        if (alto > 0)
                            g.FillRectangle(barra, rectBarra);

                        g.DrawString(
                            val[i].ToString(),
                            negrita,
                            texto,
                            new RectangleF(centroX - ancho / 2f, rectBarra.Top - 22, ancho, 20),
                            arribaCentro
                        );

                        g.DrawString(
                            et[i],
                            pequena,
                            texto,
                            new RectangleF(centroX - ancho / 2f, area.Bottom + 6, ancho, 22),
                            abajoCentro
                        );
                    }
                }
            }
        }


        // Paso de la rejilla: 1, 2, 5, 10, 20, 50... para ~5 divisiones.
        private static int PasoAgradable(int maximo)
        {
            if (maximo <= 5)
                return 1;

            double bruto = maximo / 5.0;
            double potencia = Math.Pow(10, Math.Floor(Math.Log10(bruto)));
            double fraccion = bruto / potencia;

            double paso =
                fraccion <= 1 ? 1 :
                fraccion <= 2 ? 2 :
                fraccion <= 5 ? 5 : 10;

            return (int)(paso * potencia);
        }
    }
}
