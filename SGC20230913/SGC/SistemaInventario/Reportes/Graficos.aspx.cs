using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Collections;
using System.Configuration;
using CapaNegocios;
using CapaEntidad;
using SistemaInventario.Clases;
using EasyCallback;
using Newtonsoft.Json;
using System.Web.Services;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;

namespace SistemaInventario
{
    public partial class Graficos : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_CrearPDF_NET);
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddlEmpresa_html = "";
            String str_ddlRuta_html = "";
            String str_ddlVendedor_html = "";
            String str_ddl_moneda_html = "";
            int int_resultado_operacion = 0;
            Hashtable obj_parametros = null;
            DataTable dttable = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref dttable);

                int_resultado_operacion = 1;
                str_mensaje_operacion = "";
            }
            catch (Exception ex)
            {
                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" +
                str_mensaje_operacion + "~" +
                str_ddlEmpresa_html + "~" +
                str_ddlRuta_html + "~" +
                str_ddlVendedor_html + "~" +
                str_ddl_moneda_html;

            return str_resultado;
        }



        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DataTable dtTabla)
        {
            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            //filtros
            objEntidad.DesdeInt = 20200101;
            objEntidad.HastaInt = 20200131;
            objEntidad.CodMoneda = 0;
            objEntidad.TipoReporte = 1;

            //filtros de combos multiples
            objEntidad.xmlFamilias = "<R><XmlLC> </XmlLC></R>";
            objEntidad.xmlMarcas = "<R><XmlLC> </XmlLC></R>";
            dtTabla = objOperacion.F_DocumentoVentaCab_VentasArticulos_Periodo(objEntidad);


         
        }

        //public static List<VentasUnidades> F_CrearPDF(HttpPostedFileBase imagen, string texto)
        public String F_CrearPDF_NET(String arg)
        {
            String xxx = "";

            //guardo la imagen en un directorio local
            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            //filtros
            objEntidad.DesdeInt = Convert.ToInt32(obj_parametros["Filtro_Desde"]); ;
            objEntidad.HastaInt = Convert.ToInt32(obj_parametros["Filtro_Hasta"]); ;
            objEntidad.CodMoneda = 0;
            objEntidad.TipoReporte = 1;

            //filtros de combos multiples
            objEntidad.xmlFamilias = "<R><XmlLC> </XmlLC></R>";
            objEntidad.xmlMarcas = "<R><XmlLC> </XmlLC></R>";

            string NombrePDF = "GRAFICOS_VENTAS_" + objEntidad.DesdeInt.ToString() + "_" + objEntidad.HastaInt.ToString() + ".pdf";
            string DirectorioArchivo = System.Web.HttpContext.Current.Server.MapPath(@"~\files\pdf\") + NombrePDF;

            if (!File.Exists(DirectorioArchivo))
                try
                {
                    //busco los datos en la datetable
                    DataTable dtTabla = objOperacion.F_DocumentoVentaCab_VentasDocumentos_Periodo(objEntidad);
                    dtTabla.Columns.RemoveAt(1);

                    // Creamos el documento con el tamaño de página tradicional
                    Document doc = new Document(PageSize.LETTER);
                    // Indicamos donde vamos a guardar el documento
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(DirectorioArchivo, FileMode.Create));
                    //PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@"C:\pdf\prueba.pdf", FileMode.Create));

                    // Le colocamos el título y el autor
                    // **Nota: Esto no será visible en el documento
                    doc.AddTitle("Mi primer PDF");
                    doc.AddCreator("Adrian");

                    // Abrimos el archivo
                    doc.Open();

                    // Creamos el tipo de Font que vamos utilizar
                    iTextSharp.text.Font _headFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 6, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                    iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 6, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);


                    // Escribimos el encabezamiento en el documento
                    doc.Add(new Paragraph("IMPORTACIONES KARINA"));
                    doc.Add(new Paragraph("Reporte de Ventas por Periodo"));
                    doc.Add(Chunk.NEWLINE);

                    //IMAGEN DE GRAFICO
                    //---------------------------------------------------
                    //imagen desde el html
                    String Img = Convert.ToString(obj_parametros["Filtro_Img"]);
                    //transformar a imagen
                    System.Drawing.Image GRAFICO1 = Utilitarios.OtrasFunciones.getStrToImagen(Img);
                    //agregar imagen al pdf 
                    iTextSharp.text.Image imggraf = iTextSharp.text.Image.GetInstance(GRAFICO1, System.Drawing.Imaging.ImageFormat.Png);
                    imggraf.ScalePercent(50f);
                    doc.Add(imggraf);
                    //---------------------------------------------------


                    //DATOS DE TABLA
                    //---------------------------------------------------
                    // Creamos una tabla que contendrá el nombre, apellido y país
                    // de nuestros visitante.
                    PdfPTable tblPrueba = new PdfPTable(dtTabla.Columns.Count);
                    tblPrueba.WidthPercentage = 100;

                    Utilitarios.OtrasFunciones.P_CambioNombreColumnasPeriodos(ref dtTabla); //combierto el formato de los nombres de columnas en formato Mon-YY
                    P_DataTable_To_PDFTable(ref tblPrueba, ref dtTabla, ref _headFont, ref _standardFont);

                    float[] medidaCeldas = { 1f, 2.25f, 2.25f, 2.25f, 2.25f, 2.25f, 2.25f, 2.25f, 2.25f, 2.25f, 2.25f, 2.25f, 2.25f, 2.25f };

                    // ASIGNAS LAS MEDIDAS A LA TABLA (ANCHO)
                    tblPrueba.SetWidths(medidaCeldas);

                    // Finalmente, añadimos la tabla al documento PDF y cerramos el documento
                    doc.Add(tblPrueba);





                    doc.Close();
                    writer.Close();
                }
                catch (Exception)
                {


                }

            //Session("RutaPdf") = sPdfFilePath : Session("Descarga") = 1
            //Response.Redirect ("Crystal.aspx?txt=" + DirectorioArchivo, false);


            return DirectorioArchivo;
        }

        public void P_DataTable_To_PDFTable(ref PdfPTable tblPrueba, ref DataTable dtTable, ref iTextSharp.text.Font _HeadFont, ref iTextSharp.text.Font _StandardFont)
        {

            //-------------------------------------Cabecera

            foreach (DataColumn c in dtTable.Columns) {
                // Configuramos el título de las columnas de la tabla
                PdfPCell clHead = new PdfPCell(new Phrase(c.ColumnName, _HeadFont));
                clHead.BorderWidth = 0.5f;
                clHead.BorderWidthBottom = 0.20f;
                clHead.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                clHead.HorizontalAlignment = Element.ALIGN_CENTER;
                tblPrueba.AddCell(clHead);
            }

            foreach (DataRow r in dtTable.Rows) {
                foreach (DataColumn c in dtTable.Columns) {
                    string dato = r[c.ColumnName].ToString();

                    // Configuramos el título de las columnas de la tabla
                    PdfPCell clHead = new PdfPCell(new Phrase( dato, _StandardFont));
                    clHead.BorderWidth = 0.5f;
                    clHead.BorderWidthBottom = 0.20f;

                    if (dtTable.Columns[c.ColumnName].DataType == typeof(String))
                        clHead.HorizontalAlignment = Element.ALIGN_CENTER;

                    if (dtTable.Columns[c.ColumnName].DataType == typeof(decimal))
                        clHead.HorizontalAlignment = Element.ALIGN_RIGHT;
                    
                    tblPrueba.AddCell(clHead);
                }            

            }
        
        }



        [WebMethod(EnableSession = true)]
        public static List<VentasDocumentos> F_VentasUnidades(int Desde, int Hasta)
        {
            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            //filtros
            objEntidad.DesdeInt = Desde;
            objEntidad.HastaInt = Hasta;
            objEntidad.CodMoneda = 0;
            objEntidad.TipoReporte = 1;

            //filtros de combos multiples
            objEntidad.xmlFamilias = "<R><XmlLC> </XmlLC></R>";
            objEntidad.xmlMarcas = "<R><XmlLC> </XmlLC></R>";
            DataTable dtTabla = objOperacion.F_DocumentoVentaCab_VentasDocumentos_Periodo(objEntidad);

            //Armo Listas
            List<VentasDocumentos> lUnidades = new List<VentasDocumentos>();
            foreach (DataRow r in dtTabla.Rows)
            {

                //detalle de venta del articulo
                VentasDocumentos Documentos = new VentasDocumentos();
                Documentos.Doc = r["Doc"].ToString();
                Documentos.Documento = r["Documento"].ToString();
                Documentos.Total = Convert.ToDecimal(r["Total"].ToString());

                //detalle de las ventas
                Documentos.VentasPeriodos = new List<VentasPeriodo>();
                foreach (DataColumn c in dtTabla.Columns)
                {
                    try
                    {
                        if (Convert.ToInt32(c.ColumnName.ToString()) >= Convert.ToInt32(objEntidad.DesdeInt.ToString().Substring(0, 6)) &
                            Convert.ToInt32(c.ColumnName.ToString()) <= Convert.ToInt32(objEntidad.HastaInt.ToString().Substring(0, 6)))
                        {
                            Documentos.VentasPeriodos.Add(new VentasPeriodo()
                            {
                                Periodo = c.ColumnName,
                                PeriodoStr = Utilitarios.OtrasFunciones.F_PeriodoFormatoText(c.ColumnName),
                                TotalPeriodo = Convert.ToDecimal(r[c.ColumnName.ToString()].ToString())
                            });
                        }

                    }
                    catch (Exception) { }
                }

                lUnidades.Add(Documentos);

            }


            return lUnidades;
        }
        public class VentasDocumentos
        {
            public string Doc { get; set; }
            public string Documento { get; set; }
            public decimal Total { get; set; }

            public virtual List<VentasPeriodo> VentasPeriodos { get; set; }
        }
        public class VentasPeriodo
        {
            public string Periodo { get; set; }
            public string PeriodoStr { get; set; }
            public decimal TotalPeriodo { get; set; }
        }

        [WebMethod(EnableSession = true)]
        public static List<VentasPeriodo2> F_VentasUnidades2(int Desde, int Hasta)
        {
            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            //filtros
            objEntidad.DesdeInt = Desde;
            objEntidad.HastaInt = Hasta;
            objEntidad.CodMoneda = 0;
            objEntidad.TipoReporte = 1;

            //filtros de combos multiples
            objEntidad.xmlFamilias = "<R><XmlLC> </XmlLC></R>";
            objEntidad.xmlMarcas = "<R><XmlLC> </XmlLC></R>";
            DataTable dtTabla = objOperacion.F_DocumentoVentaCab_VentasDocumentos_Periodo(objEntidad);

            //Armo Listas
            List<VentasPeriodo2> lUnidades = new List<VentasPeriodo2>();

            foreach (DataColumn c in dtTabla.Columns)
            {
                VentasPeriodo2 VentasPeriodo = new VentasPeriodo2();


                try
                {
                    if (Convert.ToInt32(c.ColumnName.ToString()) >= Convert.ToInt32(objEntidad.DesdeInt.ToString().Substring(0, 6)) &
                        Convert.ToInt32(c.ColumnName.ToString()) <= Convert.ToInt32(objEntidad.HastaInt.ToString().Substring(0, 6)))
                    {
                        VentasPeriodo.Periodo = c.ColumnName;
                        VentasPeriodo.PeriodoStr = Utilitarios.OtrasFunciones.F_PeriodoFormatoText(c.ColumnName);

                        VentasPeriodo.VentasDocumentos = new List<VentasDocumentos2>();
                        decimal TotalPeriodo = 0;
                        for (int i = 0; i < dtTabla.Rows.Count; i++)
                        {
                            VentasDocumentos2 doc = new VentasDocumentos2();
                            doc.Documento = dtTabla.Rows[i]["DOCUMENTO"].ToString();
                            doc.Doc = dtTabla.Rows[i]["DOC"].ToString();
                            doc.TotalDocumento = Convert.ToDecimal(dtTabla.Rows[i][c.ColumnName].ToString());
                            TotalPeriodo += Convert.ToDecimal(dtTabla.Rows[i][c.ColumnName].ToString());
                            VentasPeriodo.VentasDocumentos.Add(doc);
                        }

                        VentasPeriodo.TotalPeriodo = TotalPeriodo;

                    }
                lUnidades.Add(VentasPeriodo);
                }
                catch (Exception)
                {

                }

            }

            return lUnidades;
        }
        public class VentasPeriodo2
        {
            public string Periodo { get; set; }
            public string PeriodoStr { get; set; }
            public decimal TotalPeriodo { get; set; }

            public virtual List<VentasDocumentos2> VentasDocumentos { get; set; }
        }
        public class VentasDocumentos2
        {
            public string Doc { get; set; }
            public string Documento { get; set; }
            public decimal TotalDocumento { get; set; }
        }
    }

}