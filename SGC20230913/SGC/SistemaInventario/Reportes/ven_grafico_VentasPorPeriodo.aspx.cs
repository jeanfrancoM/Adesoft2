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
using System.Web.Services;
using CapaNegocios;
using CapaEntidad;
using SistemaInventario.Clases;
using EasyCallback;
using Newtonsoft.Json;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
namespace SistemaInventario.Reportes
{
    public partial class ven_grafico_VentasPorPeriodo : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_CrearPDF_NET);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
        }

        [WebMethod(EnableSession = true)]
        public static List<LGFamiliasCE> F_Familias_Listar_NET(int pTodos)
        {
            return (new LGFamiliasCN()).F_Familias_Listar(pTodos);
        }

        [WebMethod(EnableSession = true)]
        public static List<TCAlmacenCE> F_Almacenes_Listar_NET(int pTodos)
        {
            return (new TCAlmacenCN()).F_TCAlmacen_Listar(3, pTodos);
        }

        [WebMethod(EnableSession = true)]
        public static List<MarcasCE> F_Marcas_Por_Familias_Listar_NET(string xml)
        {
            //xmldetalle
            String XmlDetalle = "";
            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(xml);

            foreach (dynamic item in jArr2)
            {
                XmlDetalle = XmlDetalle + "<D ";
                XmlDetalle = XmlDetalle + " IdFamilia = '" + item.IdFamilia + "'";
                XmlDetalle = XmlDetalle + " />";
            }

            XmlDetalle = "<R><XmlLC> " + XmlDetalle + "</XmlLC></R>";

            return (new LGFamiliasCN()).F_Marcas_Por_Familias_Listar(XmlDetalle);
        }


        //public static List<VentasUnidades> F_CrearPDF(HttpPostedFileBase imagen, string texto)
        public String F_CrearPDF_NET(String arg)
        {
            String xxx = "";

            //guardo la imagen en un directorio local
            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            //filtros
            int Desde = Convert.ToInt32(Convert.ToDateTime(obj_parametros["Filtro_Desde"]).ToString("yyyyMMdd"));
            int Hasta = Convert.ToInt32(Convert.ToDateTime(obj_parametros["Filtro_Hasta"]).ToString("yyyyMMdd"));
            int CodMoneda = Convert.ToInt32(obj_parametros["Filtro_CodMoneda"]);
            int TipoReporte = Convert.ToInt32(obj_parametros["Filtro_TipoReporte"]);
            int CodAlmacen = Convert.ToInt32(obj_parametros["Filtro_CodAlmacen"]);

            string NombrePDF = "GRAFICOS_VENTAS_" + Desde.ToString() + "_" + Hasta.ToString() + "_" + 
                    CodMoneda.ToString() + "_" +  TipoReporte + "_" + CodAlmacen + ".pdf";
            string DirectorioArchivo = System.Web.HttpContext.Current.Server.MapPath(@"~\files\pdf\") + NombrePDF;

            if (!File.Exists(DirectorioArchivo))
                try
                {
                    //BUSQUEDA DE DATOS
                    //----------------------------------------------------------
                    DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
                    DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

                    //filtrosF_CrearPDF_NET
                    objEntidad.DesdeInt = Desde;
                    objEntidad.HastaInt = Hasta;
                    objEntidad.CodMoneda = CodMoneda;
                    objEntidad.TipoReporte = TipoReporte;
                    objEntidad.CodAlmacen = CodAlmacen;

                    //filtros de combos multiples
                    objEntidad.xmlFamilias = "<R><XmlLC> </XmlLC></R>";
                    objEntidad.xmlMarcas = "<R><XmlLC> </XmlLC></R>";

                    DataTable dtTabla = objOperacion.F_DocumentoVentaCab_VentasDocumentos_Periodo_Grafico(objEntidad);

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
                    doc.Add(Chunk.NEWLINE);


                    //DATOS DE TABLA
                    //---------------------------------------------------
                    // Creamos una tabla que contendrá el nombre, apellido y país
                    // de nuestros visitante.
                    PdfPTable tblPrueba = new PdfPTable(dtTabla.Columns.Count);
                    tblPrueba.WidthPercentage = 100;

                    Utilitarios.OtrasFunciones.P_CambioNombreColumnasPeriodos(ref dtTabla); //combierto el formato de los nombres de columnas en formato Mon-YY
                    P_DataTable_To_PDFTable(ref tblPrueba, ref dtTabla, ref _headFont, ref _standardFont);

                    //float[] medidaCeldas = { 1f, 2.25f, 2.25f, 2.25f, 2.25f, 2.25f, 2.25f, 2.25f, 2.25f, 2.25f, 2.25f, 2.25f, 2.25f, 2.25f };

                    // ASIGNAS LAS MEDIDAS A LA TABLA (ANCHO)
                    //tblPrueba.SetWidths(medidaCeldas);

                    // Finalmente, añadimos la tabla al documento PDF y cerramos el documento
                    doc.Add(tblPrueba);





                    doc.Close();
                    writer.Close();
                }
                catch (Exception ex)
                {

                    var error = ex.Message;
                }

            //Session("RutaPdf") = sPdfFilePath : Session("Descarga") = 1
            //Response.Redirect ("Crystal.aspx?txt=" + DirectorioArchivo, false);


            return DirectorioArchivo;
        }

        public void P_DataTable_To_PDFTable(ref PdfPTable tblPrueba, ref DataTable dtTable, ref iTextSharp.text.Font _HeadFont, ref iTextSharp.text.Font _StandardFont)
        {

            //-------------------------------------Cabecera

            foreach (DataColumn c in dtTable.Columns)
            {
                // Configuramos el título de las columnas de la tabla
                PdfPCell clHead = new PdfPCell(new Phrase(c.ColumnName, _HeadFont));
                clHead.BorderWidth = 0.5f;
                clHead.BorderWidthBottom = 0.20f;
                clHead.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                clHead.HorizontalAlignment = Element.ALIGN_CENTER;
                tblPrueba.AddCell(clHead);
            }

            foreach (DataRow r in dtTable.Rows)
            {
                foreach (DataColumn c in dtTable.Columns)
                {
                    string dato = r[c.ColumnName].ToString();

                    // Configuramos el título de las columnas de la tabla
                    PdfPCell clHead = new PdfPCell(new Phrase(dato, _StandardFont));
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



    }
}