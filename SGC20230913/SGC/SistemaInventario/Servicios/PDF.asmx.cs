using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using CapaNegocios;
using CapaEntidad;
using System.Data;
using System.Linq;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;
using KeepAutomation.Barcode.Crystal;
using CrystalDecisions.CrystalReports.Engine;

namespace SistemaInventario.Servicios
{
    /// <summary>
    /// Descripción breve de PDF
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]

    public class PDF : System.Web.Services.WebService
    {
        /*[WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string F_Facturas_Pedido_Lote_PDF(int CodNotaPedido, int tipo)
        {
            string nombreBase = DateTime.Now.ToString("yyyyMMddhhmmss");

            List<string> pdfs = F_DocumentosGeneradosPorNotaPedido(CodNotaPedido, nombreBase);

            PdfReader reader = null;
            Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage;
            string outputPdfPath = System.Web.HttpContext.Current.Server.MapPath(@"..\files\temp\") + nombreBase + "_FACTURAS.pdf"; //sFile = @"../files/download/" + nombre_doc; //PUBLICACION
            string DomainNameOutPut = @"../files/temp/" + nombreBase + "_FACTURAS.pdf";

            sourceDocument = new Document();
            pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));

            //Open the output file
            sourceDocument.Open();

            try
            {


                foreach (string pdf in pdfs)
                {
                    int pages = get_pageCcount(pdf);

                    reader = new PdfReader(pdf);
                    //Add pages of current file
                    for (int i = 1; i <= pages; i++)
                    {
                        importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                        pdfCopyProvider.AddPage(importedPage);
                    }

                    reader.Close();
                }

                //At the end save the output file
                sourceDocument.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return DomainNameOutPut;
        }

        /// <summary>
        /// Genera lote de facturas pasandole los codigos en cadena
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="Codigos">CodDocumentoVenta: 1430, 1431, 1444</param>
        /// <returns></returns>
         * */
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string F_Facturas_Pedido_Lote2_PDF(string Codigos, int CodTipoDoc)
        {
            PdfReader reader = null;
            Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage;
            string nombreBase = DateTime.Now.ToString("yyyyMMddhhmmss");             
            string outputPdfPath = null;
            string DomainNameOutPut=null;
            List<string> pdfs = F_DocumentosFacturasGeneradas(Codigos, nombreBase, CodTipoDoc);
            switch (CodTipoDoc)
            {
                case 1:                    
                    outputPdfPath = System.Web.HttpContext.Current.Server.MapPath(@"..\files\temp\") + nombreBase + "_FACTURAS.pdf"; //sFile = @"../files/download/" + nombre_doc; //PUBLICACION
                    DomainNameOutPut = @"../files/temp/" + nombreBase + "_FACTURAS.pdf";
                    break;
                case 3:
                    outputPdfPath = System.Web.HttpContext.Current.Server.MapPath(@"..\files\temp\") + nombreBase + "_NOTACREDITO.pdf"; //sFile = @"../files/download/" + nombre_doc; //PUBLICACION
                    DomainNameOutPut = @"../files/temp/" + nombreBase + "_NOTACREDITO.pdf";
                    break;
                case 15:
                    outputPdfPath = System.Web.HttpContext.Current.Server.MapPath(@"..\files\temp\") + nombreBase + "_COTIZACIONES.pdf"; //sFile = @"../files/download/" + nombre_doc; //PUBLICACION
                    DomainNameOutPut = @"../files/temp/" + nombreBase + "_COTIZACIONES.pdf";
                    break;
                case 23:
                    outputPdfPath = System.Web.HttpContext.Current.Server.MapPath(@"..\files\temp\") + nombreBase + "_BOLETASPAGORG.pdf"; //sFile = @"../files/download/" + nombre_doc; //PUBLICACION
                    DomainNameOutPut = @"../files/temp/" + nombreBase + "_BOLETASPAGORG.pdf";
                    break;
                case 24:
                    outputPdfPath = System.Web.HttpContext.Current.Server.MapPath(@"..\files\temp\") + nombreBase + "_BOLETASPAGORCC.pdf"; //sFile = @"../files/download/" + nombre_doc; //PUBLICACION
                    DomainNameOutPut = @"../files/temp/" + nombreBase + "_BOLETASPAGORCC.pdf";
                    break;
                case 25:
                    outputPdfPath = System.Web.HttpContext.Current.Server.MapPath(@"..\files\temp\") + nombreBase + "_NOTAINGRESO.pdf"; //sFile = @"../files/download/" + nombre_doc; //PUBLICACION
                    DomainNameOutPut = @"../files/temp/" + nombreBase + "_NOTAINGRESO.pdf";
                    break;


            }            

            sourceDocument = new Document();
            pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));

            //Open the output file
            sourceDocument.Open();

            try
            {


                foreach (string pdf in pdfs)
                {
                    int pages = get_pageCcount(pdf);

                    reader = new PdfReader(pdf);
                    //Add pages of current file
                    for (int i = 1; i <= pages; i++)
                    {
                        importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                        pdfCopyProvider.AddPage(importedPage);
                    }

                    reader.Close();
                }

                //At the end save the output file
                sourceDocument.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return DomainNameOutPut;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string F_Facturas_Guia_Lote2_PDF(string Codigos, string Guia, string TipoImp)
        {
            PdfReader reader = null;
            Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage;
            string nombreBase = DateTime.Now.ToString("yyyyMMddhhmmss");
            string outputPdfPath = null;
            string DomainNameOutPut = null;
            List<string> pdfs = F_Facturas_GUIA_PDF(Codigos, nombreBase, Guia);


            outputPdfPath = System.Web.HttpContext.Current.Server.MapPath(@"..\files\temp\") + nombreBase + "_FACTURAS.pdf";


            DomainNameOutPut = @"../files/temp/" + nombreBase + "_FACTURAS.pdf";



            sourceDocument = new Document();
            pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));

            //Open the output file
            sourceDocument.Open();

            try
            {


                foreach (string pdf in pdfs)
                {
                    int pages = get_pageCcount(pdf);

                    reader = new PdfReader(pdf);
                    //Add pages of current file
                    for (int i = 1; i <= pages; i++)
                    {
                        importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                        pdfCopyProvider.AddPage(importedPage);
                    }

                    reader.Close();
                }

                //At the end save the output file
                sourceDocument.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

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
                    string nombreRutaDocumentoTemp = nombreBase + "_" + Codigos + "_FT_" + ".pdf";
                    cGeneraPDF pdf = new cGeneraPDF();
                    string pdfNuevo = pdf.GenerarFACTURASNC(CodigoDocumento, nombreRutaDocumentoTemp);
                    lista.Add(pdfNuevo);
                    pdf = null;
                }

                int Guias = Convert.ToInt32(Guia);
                if (Guias > 0)
                {
                    string nombreRutaDocumentoTemp = nombreBase + "_" + Guia + "_GR_" + ".pdf";
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

        /*/// <summary>
        /// Genera lote de facturas pasandole los codigos en cadena
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="Codigos">CodDocumentoVenta: 1430, 1431, 1444</param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string F_Facturas_Pedido_Lote3_PDF(string Codigos)
        {
            string nombreBase = DateTime.Now.ToString("yyyyMMddhhmmss");

            List<string> pdfs = F_DocumentosFacturasGeneradas(Codigos, nombreBase);

            PdfReader reader = null;
            Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage;
            string outputPdfPath = System.Web.HttpContext.Current.Server.MapPath(@"..\files\temp\") + nombreBase + "_FACTURAS.pdf"; //sFile = @"../files/download/" + nombre_doc; //PUBLICACION
            string DomainNameOutPut = @"../files/temp/" + nombreBase + "_FACTURAS.pdf";

            sourceDocument = new Document();
            pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));

            //Open the output file
            sourceDocument.Open();

            try
            {


                foreach (string pdf in pdfs)
                {
                    int pages = get_pageCcount(pdf);

                    reader = new PdfReader(pdf);
                    //Add pages of current file
                    for (int i = 1; i <= pages; i++)
                    {
                        importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                        pdfCopyProvider.AddPage(importedPage);
                    }

                    reader.Close();
                }

                //At the end save the output file
                sourceDocument.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            string baseURL = "/files/temp/" + nombreBase + "_FACTURAS.pdf";

            return baseURL;
        }

        /// <summary>
        /// Genera lote de Guias de Facturas pasandole los codigos de las guias
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="Codigos">CodTraslado: 4555, 4556, 45555</param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string F_Guias_Facturas_Pedido_Lote_PDF(string Codigos)
        {
            string nombreBase = DateTime.Now.ToString("yyyyMMddhhmmss");

            List<string> pdfs = F_DocumentosGuiasGeneradas(Codigos, nombreBase);

            PdfReader reader = null;
            Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage;
            string outputPdfPath = System.Web.HttpContext.Current.Server.MapPath(@"..\files\temp\") + nombreBase + "_NOTASPEDIDOS.pdf"; //sFile = @"../files/download/" + nombre_doc; //PUBLICACION
            string DomainNameOutPut = @"../files/temp/" + nombreBase + "_NOTASPEDIDOS.pdf";

            sourceDocument = new Document();
            pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));

            //Open the output file
            sourceDocument.Open();

            try
            {


                foreach (string pdf in pdfs)
                {
                    int pages = get_pageCcount(pdf);

                    reader = new PdfReader(pdf);
                    //Add pages of current file
                    for (int i = 1; i <= pages; i++)
                    {
                        importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                        pdfCopyProvider.AddPage(importedPage);
                    }

                    reader.Close();
                }

                //At the end save the output file
                sourceDocument.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return DomainNameOutPut;
        }

        /// <summary>
        /// Genera lote de facturas pasandole los codigos en cadena
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="Codigos">CodDocumentoVenta: 1430, 1431, 1444</param>
        /// <returns></returns>*/
       /* [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string F_Facturas_y_GuiasRemision_Pedido_Lote_PDF(string codigoFacturas, int copiasFT, string codigoGUIAS, int copiasGR)
        {
            string nombreBase = DateTime.Now.ToString("yyyyMMddhhmmss");
            List<string> pdfsFINAL = new List<string>();

            List<string> pdfsFT = F_DocumentosFacturasGeneradas(codigoFacturas, nombreBase);
            List<string> pdfsGR = F_DocumentosGuiasGeneradas(codigoGUIAS, nombreBase);

            if (pdfsFT.Count > 0)
            {
                for (int i = 0; i < copiasFT; i++)
                {
                    pdfsFINAL.AddRange(pdfsFT);
                }
            }

            if (pdfsGR.Count > 0)
            {
                for (int i = 0; i < copiasGR; i++)
                {
                    pdfsFINAL.AddRange(pdfsGR);
                }
            }
            
            


            PdfReader reader = null;
            Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage;
            string outputPdfPath = System.Web.HttpContext.Current.Server.MapPath(@"..\files\temp\") + nombreBase + "_FACTURAS.pdf"; //sFile = @"../files/download/" + nombre_doc; //PUBLICACION
            string DomainNameOutPut = @"../files/temp/" + nombreBase + "_FACTURAS.pdf";

            sourceDocument = new Document();
            pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));

            //Open the output file
            sourceDocument.Open();

            try
            {


                foreach (string pdf in pdfsFINAL)
                {
                    int pages = get_pageCcount(pdf);

                    reader = new PdfReader(pdf);
                    //Add pages of current file
                    for (int i = 1; i <= pages; i++)
                    {
                        importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                        pdfCopyProvider.AddPage(importedPage);
                    }

                    reader.Close();
                }

                //At the end save the output file
                sourceDocument.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            string baseURL = "/files/temp/" + nombreBase + "_FACTURAS.pdf";

            return baseURL;
        }
        */

        /// <summary>
        /// Genera lote de Guias de Facturas pasandole los codigos de las guias
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="Codigos">CodTraslado: 4555, 4556, 45555</param>
        /// <returns></returns>
        /*[WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string F_NotaPedido_Lote_PDF(string Codigos)
        {
            string nombreBase = DateTime.Now.ToString("yyyyMMddhhmmss");

            List<string> pdfs = F_DocumentosNotasPedidosGeneradas(Codigos, nombreBase);

            PdfReader reader = null;
            Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage;
            string outputPdfPath = System.Web.HttpContext.Current.Server.MapPath(@"..\files\temp\") + nombreBase + "_GUIAS.pdf"; //sFile = @"../files/download/" + nombre_doc; //PUBLICACION
            string DomainNameOutPut = @"../files/temp/" + nombreBase + "_GUIAS.pdf";

            sourceDocument = new Document();
            pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));

            //Open the output file
            sourceDocument.Open();

            try
            {


                foreach (string pdf in pdfs)
                {
                    int pages = get_pageCcount(pdf);

                    reader = new PdfReader(pdf);
                    //Add pages of current file
                    for (int i = 1; i <= pages; i++)
                    {
                        importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                        pdfCopyProvider.AddPage(importedPage);
                    }

                    reader.Close();
                }

                //At the end save the output file
                sourceDocument.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return DomainNameOutPut;
        }

        */
        private int get_pageCcount(string file)
        {
            using (StreamReader sr = new StreamReader(File.OpenRead(file)))
            {
                Regex regex = new Regex(@"/Type\s*/Page[^s]");
                MatchCollection matches = regex.Matches(sr.ReadToEnd());

                return matches.Count;
            }
        }


        /*private List<string> F_DocumentosGeneradosPorNotaPedido(int CodNotaPedido, string nombreBase)
        {
            List<string> lista = new List<string>();

            //busco el lote de documentos
            NotaPedidoCabCE objEntidadPedido = new NotaPedidoCabCE();
            objEntidadPedido.CodNotaPedido = CodNotaPedido;
            DataTable dtFacturas = (new NotaPedidoCabCN()).F_NotaPedido_SituacionCliente_Documentos(objEntidadPedido);

            //genero todos los pdf y los guardo
            foreach (DataRow r in dtFacturas.Rows)
            {
                int CodDocumentoVenta = Convert.ToInt32(r["ID"].ToString());
                string Factura = r["NroDocumento2"].ToString();
                string nombreRutaDocumentoTemp = nombreBase + "_" + Factura + ".pdf";
                int CodTipoDoc = Convert.ToInt32(r["CodTipoDoc"].ToString());
                string ArchivoRpt = "";

                switch (CodTipoDoc)
                {
                    case 1: //FACTURA
                        ArchivoRpt = "rptElectronica.rpt";
                        break;
                    case 2: //BOLETA
                        ArchivoRpt = "rptElectronicaBO.rpt";
                        break;
                    case 16: //BOLETA
                        ArchivoRpt = "rptElectronica.rpt";
                        break;
                    case 3: //NOTA CREDITO
                        ArchivoRpt = "rptElectronicaNC.rpt";
                        break;
                }

                cGeneraPDF pdf = new cGeneraPDF();
                string pdfNuevo = pdf.GenerarFACTURAS(CodDocumentoVenta, nombreRutaDocumentoTemp);
                lista.Add(pdfNuevo);
                pdf = null;
            }

            return lista;
        }
        */
        private List<string> F_DocumentosFacturasGeneradas(string Codigos, string nombreBase, int CodTipoDoc)
        {
            List<string> lista = new List<string>();
            var Facturas = Codigos.Split(',');
            Facturas = Facturas.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string nombreRutaDocumentoTemp = null;
            cGeneraPDF pdf = null;
            string pdfNuevo = null;
            try
            {
                //DOCUMENTOS
                if (CodTipoDoc != 23 && CodTipoDoc!=24)
                {
                    //genero todos los pdf y los guardo
                    foreach (string CodDocumentoVenta in Facturas)
                    {
                        int CodigoDocumento = Convert.ToInt32(CodDocumentoVenta);
                        if (CodigoDocumento > 0)
                        {
                            nombreRutaDocumentoTemp = nombreBase + "_" + CodDocumentoVenta + ".pdf";
                            pdf = new cGeneraPDF();
                            pdfNuevo = null;
                            switch (CodTipoDoc)
                            {
                                case 1:
                                    pdfNuevo = pdf.GenerarFACTURASNC(CodigoDocumento, nombreRutaDocumentoTemp);
                                    break;
                                case 3:
                                    pdfNuevo = pdf.GenerarFACTURASNC(CodigoDocumento, nombreRutaDocumentoTemp);
                                    break;
                                case 15:
                                    pdfNuevo = pdf.GenerarCOTIZACIONES(CodigoDocumento, nombreRutaDocumentoTemp);
                                    break;
                                case 25:
                                    pdfNuevo = pdf.GenerarNOTAINGRESOASOC(CodigoDocumento, nombreRutaDocumentoTemp);
                                    break;

                            }

                            lista.Add(pdfNuevo);
                            pdf = null;
                        }

                    }
                }
                //BOLETAS PLANILLA
                else
                {
                    foreach (string CodDocumentoVenta in Facturas)
                    {
                        string[] arr = CodDocumentoVenta.Split('-');
                        nombreRutaDocumentoTemp = nombreBase + "_" + CodDocumentoVenta + ".pdf";
                        pdf = new cGeneraPDF();
                        switch (CodTipoDoc)
                        {
                            case 23:
                                pdfNuevo = pdf.GenerarBOLETASRG(int.Parse(arr[0]), long.Parse(arr[1]), nombreRutaDocumentoTemp);
                                break;
                            case 24:
                                pdfNuevo = pdf.GenerarBOLETASRCC(int.Parse(arr[0]), long.Parse(arr[1]), int.Parse(arr[2]), nombreRutaDocumentoTemp);
                                break;
                        }
                        
                        lista.Add(pdfNuevo);
                        pdf = null;
                    }
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        private List<string> F_DocumentosGuiasGeneradas(string Codigos, string nombreBase)
        {
            List<string> lista = new List<string>();

            var Facturas = Codigos.Split(',');

            try
            {
                //genero todos los pdf y los guardo
                foreach (string CodDocumentoVenta in Facturas)
                {
                    int CodigoDocumento = Convert.ToInt32(CodDocumentoVenta);
                    if (CodigoDocumento > 0)
                    {
                        string nombreRutaDocumentoTemp = nombreBase + "_" + CodDocumentoVenta + ".pdf";
                        cGeneraPDF pdf = new cGeneraPDF();
                        string pdfNuevo = pdf.GenerarGUIAS(CodigoDocumento, nombreRutaDocumentoTemp);
                        lista.Add(pdfNuevo);
                        pdf = null;
                    }

                }
            }
            catch (Exception)
            {

            }


            return lista;
        }

        /*private List<string> F_DocumentosNotasPedidosGeneradas(string Codigos, string nombreBase)
        {
            List<string> lista = new List<string>();

            var Facturas = Codigos.Split(',');

            //genero todos los pdf y los guardo
            foreach (string CodDocumentoVenta in Facturas)
            {
                string nombreRutaDocumentoTemp = nombreBase + "_" + CodDocumentoVenta + ".pdf";
                cGeneraPDF pdf = new cGeneraPDF();
                string pdfNuevo = pdf.GenerarNOTASPEDIDOS(Convert.ToInt32(CodDocumentoVenta), nombreRutaDocumentoTemp);
                lista.Add(pdfNuevo);
                pdf = null;
            }

            return lista;
        }

        */

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

                    
                    rpt.Load(System.Web.HttpContext.Current.Server.MapPath("../Reportes/" + ArchivoRpt));
                    rpt.SetDataSource(dtTabla);

                    string tempDirectory = System.Web.HttpContext.Current.Server.MapPath(@"..\files\temp\") + nombreRutaDocumentoTemp; //sFile = @"../files/download/" + nombre_doc; //PUBLICACION
                    rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, tempDirectory);
                    return tempDirectory;               
                }
                catch (Exception e)
                {
                    rpt.Dispose();
                    throw e;
                }
                                     
            }

            public string GenerarCOTIZACIONES(int CodDocumentoVenta, string nombreRutaDocumentoTemp)
            {
                ReportDocument rpt = new ReportDocument();
                try
                {
                    ProformaCabCE objEntidadCotizacion = new ProformaCabCE();
                    ProformaCabCN objOperacionCotizacion = new ProformaCabCN();
                    objEntidadCotizacion.CodProforma = Convert.ToInt32(CodDocumentoVenta);
                    DataTable dtTabla = objOperacionCotizacion.F_ProformaCab_VistaPreliminar(objEntidadCotizacion);
                    int CodTipoDoc = Convert.ToInt32(dtTabla.Rows[0]["CodTipoDoc"].ToString());

                    string ArchivoRpt = dtTabla.Rows[0]["NombreArchivo"].ToString();

                    
                    rpt.Load(System.Web.HttpContext.Current.Server.MapPath("../Reportes/" + ArchivoRpt));
                    rpt.SetDataSource(dtTabla);

                    string tempDirectory = System.Web.HttpContext.Current.Server.MapPath(@"..\files\temp\") + nombreRutaDocumentoTemp; //sFile = @"../files/download/" + nombre_doc; //PUBLICACION
                    rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, tempDirectory);
                    return tempDirectory;               
                }
                catch (Exception e)
                {
                    rpt.Dispose();
                    throw e;
                }
                                     
            }

            public string GenerarNOTAINGRESOASOC(int CodDocumentoVenta, string nombreRutaDocumentoTemp)
            {
                ReportDocument rpt = new ReportDocument();
                try
                {
                    NotaIngresoSalidaCabCE objNotaIngresoSalidaCabCE = new NotaIngresoSalidaCabCE();
                    NotaIngresoSalidaCabCN objNotaIngresoSalidaCabCN = new NotaIngresoSalidaCabCN();
                    objNotaIngresoSalidaCabCE.CodMovimiento = Convert.ToInt32(CodDocumentoVenta);
                    DataTable dtTabla = objNotaIngresoSalidaCabCN.F_NotaIngresoSalidaCab_Impresion_Factura(objNotaIngresoSalidaCabCE);                    

                    string ArchivoRpt = dtTabla.Rows[0]["NombreArchivo"].ToString();


                    rpt.Load(System.Web.HttpContext.Current.Server.MapPath("../Reportes/" + ArchivoRpt));
                    rpt.SetDataSource(dtTabla);

                    string tempDirectory = System.Web.HttpContext.Current.Server.MapPath(@"..\files\temp\") + nombreRutaDocumentoTemp; //sFile = @"../files/download/" + nombre_doc; //PUBLICACION
                    rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, tempDirectory);
                    return tempDirectory;
                }
                catch (Exception e)
                {
                    rpt.Dispose();
                    throw e;
                }

            }

            public string GenerarBOLETASRG(int CodigoTrabajdor, long idExcel, string nombreRutaDocumentoTemp)
            {
                ReportDocument rpt = new ReportDocument();
                try
                {
                    Planilla_SalarioCE objSalario = new Planilla_SalarioCE();
                    objSalario.CodTrabajador = CodigoTrabajdor;
                    objSalario.IDExcel = idExcel;

                    DataTable dtTabla = (new Planilla_SalarioCN()).F_Planilla_Salario_Construccion_General_Boleta(objSalario);                    

                    string ArchivoRpt = "Web_rptPlanilla_Salario_Boleta_General.rpt";


                    rpt.Load(System.Web.HttpContext.Current.Server.MapPath("../Reportes/" + ArchivoRpt));
                    rpt.SetDataSource(dtTabla);

                    string tempDirectory = System.Web.HttpContext.Current.Server.MapPath(@"..\files\temp\") + nombreRutaDocumentoTemp; //sFile = @"../files/download/" + nombre_doc; //PUBLICACION
                    rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, tempDirectory);
                    return tempDirectory;
                }
                catch (Exception e)
                {
                    rpt.Dispose();
                    throw e;
                }
            }

            public string GenerarBOLETASRCC(int CodigoTrabajdor, long idExcel, int EsReintegro, string nombreRutaDocumentoTemp)
            {
                ReportDocument rpt = new ReportDocument();
                try
                {
                    Planilla_SalarioCE objSalario = new Planilla_SalarioCE();
                    objSalario.CodTrabajador = CodigoTrabajdor;
                    objSalario.IDExcel = idExcel;
                    objSalario.EsReintegro = EsReintegro;

                    DataTable dtTabla = (new Planilla_SalarioCN()).F_Planilla_Salario_Construccion_Civil_Boleta(objSalario);

                    string ArchivoRpt = "Web_rptPlanilla_Salario_Boleta_Operario.rpt";


                    rpt.Load(System.Web.HttpContext.Current.Server.MapPath("../Reportes/" + ArchivoRpt));
                    rpt.SetDataSource(dtTabla);

                    string tempDirectory = System.Web.HttpContext.Current.Server.MapPath(@"..\files\temp\") + nombreRutaDocumentoTemp; //sFile = @"../files/download/" + nombre_doc; //PUBLICACION
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

            /*public string GenerarNOTASPEDIDOS(int CodNotaPedido, string nombreRutaDocumentoTemp)
            {
                NotaPedidoCabCE objEntidadNotaPedido = new NotaPedidoCabCE();
                NotaPedidoCabCN objOperacionNotaPedido = new NotaPedidoCabCN();
                objEntidadNotaPedido.CodNotaPedido = Convert.ToInt32(CodNotaPedido);

                DataTable dtTabla = objOperacionNotaPedido.F_NotaPedidoCab_ORIGINA_VistaPreliminar(objEntidadNotaPedido);
                dtTabla.TableName = "Cotizacion";

                ReportDocument rpt = new ReportDocument();
                rpt.Load(System.Web.HttpContext.Current.Server.MapPath("../Reportes/" + "rptCotizacionSimple.rpt"));
                rpt.SetDataSource(dtTabla);

                string tempDirectory = System.Web.HttpContext.Current.Server.MapPath(@"..\files\temp\") + nombreRutaDocumentoTemp; //sFile = @"../files/download/" + nombre_doc; //PUBLICACION
                rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, tempDirectory);

                return tempDirectory;
            }*/

        }
    }
}
