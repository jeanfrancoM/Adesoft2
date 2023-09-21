using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Services;
using CapaEntidad;
using CapaNegocios;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;
using KeepAutomation.Barcode.Crystal;
using CrystalDecisions.CrystalReports.Engine;

namespace SistemaInventario.Servicios
{
    /// <summary>
    /// Descripción breve de Stocks
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]

    public class Stocks : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public csDescarga DescargarDocumentosSunat(int CodDocumentoVenta, string TipoDocumento)
        {
            csDescarga datos = new csDescarga();
            datos.Mensaje = "";

            long RucEmisor = 0;
            long RucReceptor = 0;
            string Tipo = "";
            string Serie = "";
            string Numero = "";
            string Fecha = "";
            string Guia = "";
            string nombreBase = "";
            string CodDoc = "";
            int CodEmpresa = 0;

            DataTable dtDatos = (new TCEmpresaCN()).F_DatosDocumento_Descarga(CodDocumentoVenta);
            
            if (dtDatos.Rows.Count > 0)
            {
                RucEmisor = Convert.ToInt64(dtDatos.Rows[0]["RucEmisor"].ToString());
                RucReceptor = Convert.ToInt64(dtDatos.Rows[0]["RucReceptor"].ToString());
                Tipo = dtDatos.Rows[0]["Tipo"].ToString();
                Serie = dtDatos.Rows[0]["Serie"].ToString();
                Numero = dtDatos.Rows[0]["Numero"].ToString();
                Fecha = dtDatos.Rows[0]["Fecha"].ToString();
                Guia = dtDatos.Rows[0]["Guia"].ToString();
                CodEmpresa = Convert.ToInt32(dtDatos.Rows[0]["CodEmpresa"].ToString());

                F_RutaEmpresa_Respuesta rpta = new F_RutaEmpresa_Respuesta(CodEmpresa);
                datos.Mensaje = rpta.MsgError;
                if (rpta.MsgError == null & rpta.Ruta != null)
                {

                    datos.ArchivoPdfNombre = RucEmisor.ToString() + "-" + Tipo + "-" + Serie + "-" + Numero + "-" + Convert.ToDateTime(Fecha).ToString("yyyyMMdd") + "-" + RucReceptor.ToString() + ".pdf";
                    datos.ArchivoXmlNombre = RucEmisor.ToString() + "-" + Tipo + "-" + Serie + "-" + Numero + ".xml";
                    datos.ArchivoCdrNombre = "R-" + RucEmisor.ToString() + "-" + Tipo + "-" + Serie + "-" + Numero + ".xml";
                    datos.NombreDocumento = Serie + "-" + Numero;
                    datos.Mensaje = "";
                    datos.MensajePdf = "";
                    datos.MensajeXml = "";
                    datos.MensajeCdr = "";
                    datos.Anulada = 0;
                    string rutaArchivo;

                    //------------------------
                    //Pregunto si esta anulada
                    //------------------------
                    rutaArchivo = rpta.Ruta + "PDF\\" + datos.ArchivoPdfNombre;
                    nombreBase = datos.ArchivoPdfNombre.ToString();
                    CodDoc = Convert.ToString(CodDocumentoVenta);

                    try
                    {
                        if (System.IO.File.Exists(rutaArchivo.Replace(".pdf", "_ANULADA.pdf")))
                        {
                            datos.Mensaje = "DOCUMENTO ANULADO";
                            datos.Anulada = 1;
                        }
                    }
                    catch (Exception ex)
                    {
                        datos.MensajePdf = "Error en Verificacion Anulada: " + (char)13 + ex.Message;
                    }

                    if (datos.Anulada == 0)
                    {
                        switch (TipoDocumento)
                        {
                            case "PDF":

                                // CREACION DE PDF
                                //--------------------------------
                                F_Facturas_Guia_Lote2_PDF(CodDoc, Guia, nombreBase, rutaArchivo);
                                //---------
                                System.IO.FileStream fs1 = null;
                                fs1 = System.IO.File.Open(rutaArchivo, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                                datos.ArchivoPdf = new byte[fs1.Length];
                                fs1.Read(datos.ArchivoPdf, 0, (int)fs1.Length);
                                fs1.Close();
                                break;
                            case "ENVIO":
                                rutaArchivo = rpta.Ruta + "ENVIO\\" + datos.ArchivoXmlNombre;
                                if (!System.IO.File.Exists(rutaArchivo))
                                {
                                    rutaArchivo = rutaArchivo.Replace("xml", "zip");
                                    datos.ArchivoXmlNombre = datos.ArchivoXmlNombre.Replace("xml", "zip");
                                }

                                System.IO.FileStream fs2 = null;
                                fs2 = System.IO.File.Open(rutaArchivo, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                                datos.ArchivoXml = new byte[fs2.Length];
                                fs2.Read(datos.ArchivoXml, 0, (int)fs2.Length);
                                fs2.Close();
                                break;
                            case "RPTA":
                                rutaArchivo = rpta.Ruta + "RPTA\\" + datos.ArchivoCdrNombre;
                                if (!System.IO.File.Exists(rutaArchivo))
                                {
                                    rutaArchivo = rutaArchivo.Replace("xml", "zip").Replace("R-", "R");
                                    datos.ArchivoCdrNombre = datos.ArchivoCdrNombre.Replace("xml", "zip").Replace("R-", "R");
                                }

                                System.IO.FileStream fs3 = null;
                                fs3 = System.IO.File.Open(rutaArchivo, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                                datos.ArchivoCdr = new byte[fs3.Length];
                                fs3.Read(datos.ArchivoCdr, 0, (int)fs3.Length);
                                fs3.Close();
                                break;
                        }

                        //if (TipoDocumento == "PDF")
                        //{
                        //    //Archivo pdf
                        //    try
                        //    {
                        //        System.IO.FileStream fs1 = null;
                        //        fs1 = System.IO.File.Open(rutaArchivo, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        //        datos.ArchivoPdf = new byte[fs1.Length];
                        //        fs1.Read(datos.ArchivoPdf, 0, (int)fs1.Length);
                        //        fs1.Close();
                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        datos.MensajePdf = "Error en PDF: " + "No se pudo encontrar el documento: " + datos.NombreDocumento;
                        //    }
                        //}
                        //if (TipoDocumento == "ENVIO")
                        //{
                        //    //Archivo xml
                        //    try
                        //    {

                        //        rutaArchivo = rpta.Ruta + "ENVIO\\" + datos.ArchivoXmlNombre;
                        //        if (!System.IO.File.Exists(rutaArchivo))
                        //        {
                        //            rutaArchivo = rutaArchivo.Replace("xml", "zip");
                        //            datos.ArchivoXmlNombre = datos.ArchivoXmlNombre.Replace("xml", "zip");
                        //        }

                        //        System.IO.FileStream fs1 = null;
                        //        fs1 = System.IO.File.Open(rutaArchivo, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        //        datos.ArchivoXml = new byte[fs1.Length];
                        //        fs1.Read(datos.ArchivoXml, 0, (int)fs1.Length);
                        //        fs1.Close();
                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        datos.MensajeXml = "Error en XML: " + "No se pudo encontrar el XML del documento" + datos.NombreDocumento;
                        //    }
                        
                        //}
                        //if (TipoDocumento == "RPTA")
                        //{

                        //    //Archivo CDR
                        //    try
                        //    {

                        //        rutaArchivo = rpta.Ruta + "RPTA\\" + datos.ArchivoCdrNombre;
                        //        if (!System.IO.File.Exists(rutaArchivo))
                        //        {
                        //            rutaArchivo = rutaArchivo.Replace("xml", "zip").Replace("R-", "R");
                        //            datos.ArchivoCdrNombre = datos.ArchivoCdrNombre.Replace("xml", "zip").Replace("R-", "R");
                        //        }

                        //        System.IO.FileStream fs1 = null;
                        //        fs1 = System.IO.File.Open(rutaArchivo, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        //        datos.ArchivoCdr = new byte[fs1.Length];
                        //        fs1.Read(datos.ArchivoCdr, 0, (int)fs1.Length);
                        //        fs1.Close();
                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        datos.MensajeCdr = "Error en CDR: " + "No se pudo encontrar el CDR del documento" + datos.NombreDocumento;
                        //    }
                        
                        //}








                    }
                }
                else
                {
                    datos.Mensaje = "Ruc Emisor No Encontrado";
                }
            }



            return datos;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string F_Facturas_Guia_Lote2_PDF(string Codigos, string Guia, string nombreBase, string rutaArchivo)
        {
            PdfReader reader = null;
            Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage;
            string outputPdfPath = null;
            string DomainNameOutPut = null;
            List<string> pdfs = F_Facturas_GUIA_PDF(Codigos, nombreBase, Guia);


            outputPdfPath = rutaArchivo;


            DomainNameOutPut = rutaArchivo;



            sourceDocument = new Document();


            return DomainNameOutPut;
        }

        private List<string> F_Facturas_GUIA_PDF(string Codigos, string nombreBase, string Guia)
        {
            List<string> lista = new List<string>();

            var Facturas = Codigos.Split(',');

            try
            {
                //genero todos los pdf y los guardo

                int CodigoDocumento = Convert.ToInt32(Codigos);
                if (CodigoDocumento > 0)
                {
                    string nombreRutaDocumentoTemp = nombreBase;
                    cGeneraPDF pdf = new cGeneraPDF();
                    string pdfNuevo = pdf.GenerarFACTURASNC(CodigoDocumento, nombreRutaDocumentoTemp);
                    lista.Add(pdfNuevo);
                    pdf = null;
                }

                int Guias = Convert.ToInt32(Guia);
                if (Guias > 0)
                {
                    string nombreRutaDocumentoTemp = nombreBase + "_" + Guia + ".pdf";
                    cGeneraPDF pdf = new cGeneraPDF();
                    string pdfNuevoG = pdf.GenerarGUIAS(Guias, nombreRutaDocumentoTemp);
                    lista.Add(pdfNuevoG);
                    pdf = null;
                }
            }
            catch (Exception)
            {

            }


            return lista;
        }


        public class csDescarga
        {
            public int Anulada { get; set; }
            
            public byte[] ArchivoPdf { get; set; }
            public string ArchivoPdfNombre { get; set; }
            public string MensajePdf { get; set; }

            public byte[] ArchivoXml { get; set; }
            public string ArchivoXmlNombre { get; set; }
            public string MensajeXml { get; set; }

            public byte[] ArchivoCdr { get; set; }
            public string ArchivoCdrNombre { get; set; }
            public string MensajeCdr { get; set; }


            public string Mensaje { get; set; }
            public string NombreDocumento { get; set; }
        }


        public class F_RutaEmpresa_Respuesta
        {
            public string Ruta { get; set; }
            public string MsgError { get; set; }

            public F_RutaEmpresa_Respuesta()
            {

            }

            public F_RutaEmpresa_Respuesta(int CodEmprea)
            {
                try
                {
                    this.Ruta = (new TCEmpresaCN()).RutaFacturadorPorCodEmpresa(CodEmprea);
                }
                catch (Exception ex)
                {
                    this.MsgError = "Error al buscar ruta: " + (char)13 + ex.Message;
                }
            }

        }

        private class cGeneraPDF
        {

            public string GenerarFACTURASNC(int CodDocumentoVenta, string nombreRutaDocumentoTemp)
            {
                ReportDocument rpt = new ReportDocument();
                try
                {
                    DocumentoVentaCabCE objEntidadFactura = new DocumentoVentaCabCE();
                    DocumentoVentaCabCN objOperacionFactura = new DocumentoVentaCabCN();
                    objEntidadFactura.CodDocumentoVenta = Convert.ToInt32(CodDocumentoVenta);
                    DataTable dtTabla = objOperacionFactura.F_DocumentoVentaCab_Impresion_Factura_Electronica(objEntidadFactura);
                    int CodTipoDoc = Convert.ToInt32(dtTabla.Rows[0]["CodTipoDocumento"].ToString());

                    dtTabla.Columns.Add("QR", typeof(byte[]));
                    dtTabla.Columns.Add("PIE_PAGINA", typeof(string));
                    dtTabla.TableName = "Electronica";

                    BarCode qrcode = new BarCode();
                    qrcode.Symbology = KeepAutomation.Barcode.Symbology.QRCode;
                    qrcode.X = 6;
                    qrcode.Y = 6;
                    qrcode.LeftMargin = 6;
                    qrcode.RightMargin = 6;
                    qrcode.TopMargin = 6;
                    qrcode.BottomMargin = 6;
                    qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;

                    foreach (DataRow dr in dtTabla.Rows)
                    {
                        string cadenaQR = dr["RucEmpresa"].ToString().Replace("R.U.C. : ", "") + "|" + dr["T_Codigo_Tipo_Documento_Sunat"] +
                                        "|" + dr["SerieDoc"] + "|" + dr["NumeroDoc"] + "|" + dr["Igv"] + "|" + dr["Total"] +
                                        "|" + dr["F_Fecha_Emision"] + "|" + dr["T_Codigo_Doc_Identidad_Sunat"] + "|" + dr["Ruc"];
                        qrcode.CodeToEncode = cadenaQR; byte[] imageData = qrcode.generateBarcodeToByteArray(); dr["QR"] = imageData;
                    }

                    string ArchivoRpt = dtTabla.Rows[0]["FormatoRPT"].ToString();
                    string Ruta = dtTabla.Rows[0]["RutaOneDriveSunatMultiEmpresa"].ToString();

                    rpt.Load(System.Web.HttpContext.Current.Server.MapPath("../Reportes/" + ArchivoRpt));
                    rpt.SetDataSource(dtTabla);

                    string tempDirectory = Ruta + nombreRutaDocumentoTemp; //sFile = @"../files/download/" + nombre_doc; //PUBLICACION
                    rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, tempDirectory);
                    return tempDirectory;
                }
                catch (Exception e)
                {
                    rpt.Dispose();
                    throw e;
                }

            }

            public string GenerarGUIAS(int CodTraslado, string nombreRutaDocumentoTemp)
            {
                TrasladosCabCE objEntidadTraslados = new TrasladosCabCE();
                TrasladosCabCN objOperacionTraslados = new TrasladosCabCN();
                objEntidadTraslados.CodTraslado = Convert.ToInt32(CodTraslado);

                DataTable dtTabla = objOperacionTraslados.F_TrasladosCab_Impresion(objEntidadTraslados);

                dtTabla.Columns.Add("OR", typeof(byte[]));
                dtTabla.Columns.Add("PIE_PAGINA", typeof(string));
                dtTabla.TableName = "Electronica";

                BarCode qrcode = new BarCode();
                qrcode.Symbology = KeepAutomation.Barcode.Symbology.QRCode;
                qrcode.X = 6;
                qrcode.Y = 6;
                qrcode.LeftMargin = 6;
                qrcode.RightMargin = 6;
                qrcode.TopMargin = 6;
                qrcode.BottomMargin = 6;
                qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;

                foreach (DataRow dr in dtTabla.Rows)
                {
                    string cadenaQR = dr["RucEmpresa"].ToString().Replace("R.U.C. : ", "") + "|" + dr["T_Codigo_Tipo_Documento_Sunat"] +
                                    "|" + dr["SerieDoc"] + "|" + dr["NumeroDoc"] + "|" + dr["Igv"] + "|" + dr["Total"] +
                                    "|" + dr["F_Fecha_Emision"] + "|" + dr["T_Codigo_Doc_Identidad_Sunat"] + "|" + dr["Ruc"];
                    qrcode.CodeToEncode = cadenaQR; byte[] imageData = qrcode.generateBarcodeToByteArray(); dr["OR"] = imageData;
                }


                string FORMATO = dtTabla.Rows[0]["Archivo"].ToString();

                if (FORMATO == "rptElectronicaGE.rpt")
                    dtTabla.TableName = "Electronica";
                else
                    dtTabla.TableName = "GuiaImpresion";

                ReportDocument rpt = new ReportDocument();
                rpt.Load(System.Web.HttpContext.Current.Server.MapPath("../Reportes/" + FORMATO));
                rpt.SetDataSource(dtTabla);

                string tempDirectory = System.Web.HttpContext.Current.Server.MapPath(@"..\files\temp\") + nombreRutaDocumentoTemp; //sFile = @"../files/download/" + nombre_doc; //PUBLICACION
                rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, tempDirectory);

                return tempDirectory;
            }

        }

    }
}
