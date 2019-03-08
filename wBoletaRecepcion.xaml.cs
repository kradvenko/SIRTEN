using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using iTextSharp.text;
using iTextSharp.text.pdf;


namespace SIRTEN
{
    /// <summary>
    /// Lógica de interacción para wBoletaRecepcion.xaml
    /// </summary>
    public partial class wBoletaRecepcion : Window
    {
        cPrelacion prelacion;
        public wBoletaRecepcion(cPrelacion pre)
        {
            InitializeComponent();
            prelacion = pre;

            CrearPDF();
        }

        public void CrearPDF()
        {
            System.IO.Directory.CreateDirectory(@"C:\RPP\PDF");
            String fileName = @"C:\RPP\PDF\Prelacion_" + prelacion.IdPrelacion + ".pdf";

            //Comienza la creación del PDF de la prelación.
            Document document = new Document(PageSize.LETTER, -70, -70, 0, 0);
            PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));
            document.Open();

            iTextSharp.text.Paragraph parrafo = new iTextSharp.text.Paragraph();
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(@"C:\RPP\Images\Escudo.png");

            img.ScalePercent(35);

            PdfPTable tabla = new PdfPTable(10);
            PdfPCell celda;

            Font font1 = new Font();
            font1.Size = 16;
            font1.SetStyle(Font.BOLD);

            Font font2 = new Font();
            font2.Size = 12;
            font2.SetStyle(Font.BOLD);

            Font font3 = new Font();
            font3.Size = 10;

            BaseColor borderColor = new BaseColor(200, 202, 204);
            BaseColor backColor = new BaseColor(217, 218, 220);

            tabla.SetWidths(new float[] { 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f });

            celda = new PdfPCell(img);
            celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.TOP_BORDER | PdfPCell.RIGHT_BORDER;
            celda.BorderColor = borderColor;
            celda.PaddingTop = 10;
            celda.PaddingBottom = 10;
            celda.Colspan = 2;
            celda.Rowspan = 3;
            tabla.AddCell(celda);

            celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk("GOBIERNO DEL ESTADO DE NAYARIT", font1)));
            celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            celda.Border = PdfPCell.TOP_BORDER;
            celda.BorderColor = borderColor;
            celda.PaddingTop = 10;
            celda.Colspan = 6;
            celda.BackgroundColor = new BaseColor(217, 218, 220);
            tabla.AddCell(celda);

            celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk("PRELACION: " + prelacion.IdPrelacion, font2)));
            celda.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            celda.Border = PdfPCell.TOP_BORDER | PdfPCell.RIGHT_BORDER;
            celda.BorderColor = borderColor;
            celda.PaddingTop = 10;
            celda.Colspan = 2;
            celda.Rowspan = 1;
            celda.BackgroundColor = new BaseColor(217, 218, 220);
            tabla.AddCell(celda);

            celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk("Registro Público de la Propiedad y Comercio")));
            celda.Border = 0;
            celda.Colspan = 6;
            celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            celda.BackgroundColor = new BaseColor(217, 218, 220);
            tabla.AddCell(celda);

            celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk("Fecha: " + prelacion.FechaCaptura)));
            celda.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            celda.Border = PdfPCell.RIGHT_BORDER;
            celda.BorderColor = borderColor;
            celda.Colspan = 2;
            celda.BackgroundColor = new BaseColor(217, 218, 220);
            tabla.AddCell(celda);

            celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk("BOLETA DE INGRESO")));
            celda.Border = PdfPCell.BOTTOM_BORDER;
            celda.BorderColor = borderColor;
            celda.PaddingBottom = 10;
            celda.Colspan = 6;
            celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            celda.BackgroundColor = new BaseColor(217, 218, 220);
            tabla.AddCell(celda);

            celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk("Hora: " + prelacion.HoraCaptura)));
            celda.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.RIGHT_BORDER;
            celda.BorderColor = borderColor;
            celda.PaddingBottom = 10;
            celda.Colspan = 2;
            celda.BackgroundColor = new BaseColor(217, 218, 220);
            tabla.AddCell(celda);

            //Sección 2: Datos de quien recibe y quien tramita.

            celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk("Recibe")));
            celda.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER;
            celda.BorderColor = borderColor;
            celda.Colspan = 1;
            celda.BackgroundColor = new BaseColor(217, 218, 220);
            tabla.AddCell(celda);

            celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk(prelacion.UsuarioCaptura)));
            celda.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            celda.Border = PdfPCell.BOTTOM_BORDER;
            celda.BorderColor = borderColor;
            celda.Colspan = 3;            
            tabla.AddCell(celda);

            celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk("Tramita")));
            celda.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            celda.Border = PdfPCell.BOTTOM_BORDER;
            celda.BorderColor = borderColor;
            celda.Colspan = 1;
            celda.BackgroundColor = new BaseColor(217, 218, 220);
            tabla.AddCell(celda);

            celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk(prelacion.NombreTramitante)));
            celda.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.RIGHT_BORDER;
            celda.BorderColor = borderColor;
            celda.Colspan = 5;
            tabla.AddCell(celda);

            //Separador

            ObservableCollection<cConfiguracion> config = new ObservableCollection<cConfiguracion>();
            config = cConfiguracion.ObtenerConfiguracion();

            celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk(config[0].NombreOficina, font1)));
            celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
            celda.BorderColor = borderColor;
            celda.Colspan = 5;
            celda.BackgroundColor = BaseColor.WHITE;
            tabla.AddCell(celda);

            celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk("COPIA CONTRIBUYENTE", font1)));
            celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
            celda.BorderColor = borderColor;
            celda.Colspan = 5;
            celda.BackgroundColor = BaseColor.WHITE;
            tabla.AddCell(celda);

            //Sección 3: Antecedentes.

            celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk("Antecedentes")));
            celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            celda.PaddingTop = 5;
            celda.PaddingBottom = 5;
            celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
            celda.BorderColor = borderColor;
            celda.Colspan = 10;
            celda.BackgroundColor = backColor;
            tabla.AddCell(celda);

            celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk("Libro", font2)));
            celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
            celda.BorderColor = borderColor;
            celda.Colspan = 1;
            celda.BackgroundColor = backColor;
            tabla.AddCell(celda);

            celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk("Tomo", font2)));
            celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
            celda.BorderColor = borderColor;
            celda.Colspan = 1;
            celda.BackgroundColor = backColor;
            tabla.AddCell(celda);

            celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk("Sección", font2)));
            celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
            celda.BorderColor = borderColor;
            celda.Colspan = 1;
            celda.BackgroundColor = backColor;
            tabla.AddCell(celda);

            celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk("Serie", font2)));
            celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
            celda.BorderColor = borderColor;
            celda.Colspan = 1;
            celda.BackgroundColor = backColor;
            tabla.AddCell(celda);

            celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk("Semestre", font2)));
            celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
            celda.BorderColor = borderColor;
            celda.Colspan = 1;
            celda.BackgroundColor = backColor;
            tabla.AddCell(celda);

            celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk("Año", font2)));
            celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
            celda.BorderColor = borderColor;
            celda.Colspan = 1;
            celda.BackgroundColor = backColor;
            tabla.AddCell(celda);

            celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk("Partida", font2)));
            celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
            celda.BorderColor = borderColor;
            celda.Colspan = 1;
            celda.BackgroundColor = backColor;
            tabla.AddCell(celda);

            celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk("Notas", font2)));
            celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
            celda.BorderColor = borderColor;
            celda.Colspan = 3;
            celda.BackgroundColor = backColor;
            tabla.AddCell(celda);

            foreach (cAntecedente antecedente in prelacion.AntecedentesPrelacion)
            {
                celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk(antecedente.Libro)));
                celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
                celda.BorderColor = borderColor;
                celda.Colspan = 1;
                celda.BackgroundColor = BaseColor.WHITE;
                tabla.AddCell(celda);

                celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk(antecedente.Tomo)));
                celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
                celda.BorderColor = borderColor;
                celda.Colspan = 1;
                celda.BackgroundColor = BaseColor.WHITE;
                tabla.AddCell(celda);

                celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk(antecedente.Seccion)));
                celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
                celda.BorderColor = borderColor;
                celda.Colspan = 1;
                celda.BackgroundColor = BaseColor.WHITE;
                tabla.AddCell(celda);

                celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk(antecedente.Serie)));
                celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
                celda.BorderColor = borderColor;
                celda.Colspan = 1;
                celda.BackgroundColor = BaseColor.WHITE;
                tabla.AddCell(celda);

                celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk(antecedente.Semestre)));
                celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
                celda.BorderColor = borderColor;
                celda.Colspan = 1;
                celda.BackgroundColor = BaseColor.WHITE;
                tabla.AddCell(celda);

                celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk(antecedente.AnioSemestre)));
                celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
                celda.BorderColor = borderColor;
                celda.Colspan = 1;
                celda.BackgroundColor = BaseColor.WHITE;
                tabla.AddCell(celda);

                celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk(antecedente.Partida)));
                celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
                celda.BorderColor = borderColor;
                celda.Colspan = 1;
                celda.BackgroundColor = BaseColor.WHITE;
                tabla.AddCell(celda);

                celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk(antecedente.Notas)));
                celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
                celda.BorderColor = borderColor;
                celda.Colspan = 3;
                celda.BackgroundColor = BaseColor.WHITE;
                tabla.AddCell(celda);
            }

            //Separador

            celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk(" ")));
            celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;            
            celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
            celda.BorderColor = borderColor;
            celda.Colspan = 10;
            celda.BackgroundColor = BaseColor.WHITE;
            tabla.AddCell(celda);

            //Sección 4: Actos y Movimientos.

            celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk("Descripción del tramite")));
            celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            celda.PaddingTop = 5;
            celda.PaddingBottom = 5;
            celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
            celda.BorderColor = borderColor;
            celda.Colspan = 10;
            celda.BackgroundColor = backColor;
            tabla.AddCell(celda);

            celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk("Clave", font2)));
            celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
            celda.BorderColor = borderColor;
            celda.Colspan = 1;
            celda.BackgroundColor = backColor;
            tabla.AddCell(celda);

            celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk("Acto", font2)));
            celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
            celda.BorderColor = borderColor;
            celda.Colspan = 3;
            celda.BackgroundColor = backColor;
            tabla.AddCell(celda);

            celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk("Movimiento", font2)));
            celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
            celda.BorderColor = borderColor;
            celda.Colspan = 3;
            celda.BackgroundColor = backColor;
            tabla.AddCell(celda);

            celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk("Valor base", font2)));
            celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
            celda.BorderColor = borderColor;
            celda.Colspan = 2;
            celda.BackgroundColor = backColor;
            tabla.AddCell(celda);

            celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk("Importe", font2)));
            celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
            celda.BorderColor = borderColor;
            celda.Colspan = 1;
            celda.BackgroundColor = backColor;
            tabla.AddCell(celda);

            foreach (cMovimientoPrelacion movimientoPrelacion in prelacion.MovimientosPrelacion)
            {
                celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk(movimientoPrelacion.ClaveActo, font3)));
                celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                celda.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
                celda.BorderColor = borderColor;
                celda.Colspan = 1;
                celda.BackgroundColor = BaseColor.WHITE;
                tabla.AddCell(celda);

                celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk(movimientoPrelacion.NombreActo, font3)));
                celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                celda.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
                celda.BorderColor = borderColor;
                celda.Colspan = 3;
                celda.BackgroundColor = BaseColor.WHITE;
                tabla.AddCell(celda);

                celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk(movimientoPrelacion.NombreMovimiento, font3)));
                celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                celda.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
                celda.BorderColor = borderColor;
                celda.Colspan = 3;
                celda.BackgroundColor = BaseColor.WHITE;
                tabla.AddCell(celda);

                celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk("$ " + movimientoPrelacion.ValorBase, font3)));
                celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                celda.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
                celda.BorderColor = borderColor;
                celda.Colspan = 2;
                celda.BackgroundColor = BaseColor.WHITE;
                tabla.AddCell(celda);

                celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk("$ " + movimientoPrelacion.Importe, font3)));
                celda.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                celda.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
                celda.BorderColor = borderColor;
                celda.Colspan = 1;
                celda.BackgroundColor = BaseColor.WHITE;
                tabla.AddCell(celda);
            }

            celda = new PdfPCell(new iTextSharp.text.Paragraph(new Chunk("Total $ " + prelacion.Total, font3)));
            celda.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            celda.PaddingTop = 5;
            celda.PaddingBottom = 5;
            celda.Border = PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
            celda.BorderColor = borderColor;
            celda.Colspan = 10;
            celda.BackgroundColor = backColor;
            tabla.AddCell(celda);

            document.Add(tabla);

            document.Close();

            System.Diagnostics.Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = fileName;
            prc.Start();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CrearPDF();
        }
    }
}
