using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CapaEntidad;
using CapaNegocios;
using System.IO;
using System.Data;
using System.Globalization;
using KeepAutomation.Barcode.Crystal;
using System.Web.Services;
using System.Net;

namespace SistemaInventario.Reportes
{
    public partial class Web_Pagina_Crystal_Nuevo : System.Web.UI.Page
    {
        ReportDocument rpt = new ReportDocument();
        ReportDocument rpt2 = new ReportDocument();
        ReportDocument rpt3 = new ReportDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
                Reportes();
        }

        protected void Page_Unload(object sender, System.EventArgs e)
        {
            rpt.Close();
            rpt.Dispose();
            rpt2.Close();
            rpt2.Dispose();
            rpt3.Close();
            rpt3.Dispose();
        }

        private void Reportes()
        {
            MemoryStream msMemoria = null;
            DataSet ds = new DataSet();
            DataTable dtTabla = null;
            BarCode qrcode = new BarCode();
            String NombreTabla = Request.QueryString["NombreTabla"].ToString();
            String NombreArchivo = Request.QueryString["NombreArchivo"].ToString();
            ParameterDiscreteValue Parametro1 = new ParameterDiscreteValue();
            ParameterDiscreteValue Parametro2 = new ParameterDiscreteValue();
            ParameterDiscreteValue Parametro3 = new ParameterDiscreteValue();
            NotaIngresoSalidaCabCE objNotaIngresoSalidaCabCE = new NotaIngresoSalidaCabCE();
            NotaIngresoSalidaCabCN objNotaIngresoSalidaCabCN = new NotaIngresoSalidaCabCN();
            DocumentoVentaCabCE objDocumentoVentaCabCE = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objDocumentoVentaCabCN = new DocumentoVentaCabCN();
            TrasladosCabCE objTrasladosCabCE = new TrasladosCabCE();
            TrasladosCabCN objTrasladosCabCN = new TrasladosCabCN();
            ProformaCabCE objProformaCabCE = new ProformaCabCE();
            ProformaCabCN objProformaCabCN = new ProformaCabCN();
            LGProductosCE objLGProductosCE = new LGProductosCE();
            LGProductosCN objLGProductosCN = new LGProductosCN();
            CheckListCE objCheckListCE = new CheckListCE();
            CheckListCN objCheckListCN = new CheckListCN();
            switch (Convert.ToInt32(Request["CodMenu"]))
            {
                case 100:
                    objTrasladosCabCE.CodTraslado = Convert.ToInt32(Request.QueryString["Codigo"]);
                    objTrasladosCabCE.CodTipoFormato = Convert.ToInt32(Request.QueryString["CodTipoFormato"]);
                    //dtTabla = objTrasladosCabCN.F_TrasladosCab_Impresion_Factura(objTrasladosCabCE);
                    dtTabla = objTrasladosCabCN.F_TrasladosCab_Impresion(objTrasladosCabCE);
                    dtTabla.Columns.Add("OR", typeof(byte[]));
                     dtTabla.Columns.Add("PIE_PAGINA", typeof(string));

                     qrcode = new BarCode();
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
                    dtTabla.TableName = dtTabla.Rows[0]["Datatable"].ToString()??"";
                    rpt.Load(Server.MapPath(dtTabla.Rows[0]["NombreArchivo"].ToString()));
                    rpt.SetDataSource(dtTabla);
                    P_PDF(msMemoria);
                    break;
                case 101:
                    objNotaIngresoSalidaCabCE.CodMovimiento = Convert.ToInt32(Request.QueryString["Codigo"]);
                    objNotaIngresoSalidaCabCE.CodTipoFormato = Convert.ToInt32(Request.QueryString["CodTipoFormato"]);
                    dtTabla = objNotaIngresoSalidaCabCN.F_NotaIngresoSalidaCab_Impresion_Factura(objNotaIngresoSalidaCabCE);
                    dtTabla.TableName = dtTabla.Rows[0]["Datatable"].ToString();
                    rpt.Load(Server.MapPath(dtTabla.Rows[0]["NombreArchivo"].ToString()));
                    rpt.SetDataSource(dtTabla);
                    P_PDF(msMemoria);
                    break;
                case 102:
                    objTrasladosCabCE.CodTraslado = Convert.ToInt32(Request.QueryString["Codigo"]);
                    objTrasladosCabCE.CodTipoFormato = Convert.ToInt32(Request.QueryString["CodTipoFormato"]);
                    dtTabla = objTrasladosCabCN.F_TrasladosCab_Impresion(objTrasladosCabCE);
                    dtTabla.TableName = dtTabla.Rows[0]["Datatable"].ToString();
                    rpt.Load(Server.MapPath(dtTabla.Rows[0]["NombreArchivo"].ToString()));
                    rpt.PrintOptions.PrinterName = dtTabla.Rows[0]["Impresora"].ToString();
                    rpt.SetDataSource(dtTabla);
                    rpt.PrintToPrinter(1, true, 1, 1);

                    break;
                case 103:
                    objNotaIngresoSalidaCabCE.CodMovimiento = Convert.ToInt32(Request.QueryString["Codigo"]);

                    dtTabla = objNotaIngresoSalidaCabCN.F_NOTAINGRESOSALIDACAB_IMPRESION_TICKET(objNotaIngresoSalidaCabCE);
                    dtTabla.TableName = NombreTabla;

                    NombreArchivo = dtTabla.Rows[0]["Formato"].ToString();
                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.PrintOptions.PrinterName = dtTabla.Rows[0]["Impresora"].ToString(); ;
                    rpt.SetDataSource(dtTabla);
                    rpt.PrintToPrinter(1, true, 1, 1);
                    break;
                case 104:
                    objNotaIngresoSalidaCabCE.CodMovimiento = Convert.ToInt32(Request.QueryString["Codigo"]);
                    objNotaIngresoSalidaCabCE.CodTipoFormato = Convert.ToInt32(Request.QueryString["CodTipoFormato"]);
                    dtTabla = objNotaIngresoSalidaCabCN.F_NotaIngresoSalidaCab_Impresion_Factura(objNotaIngresoSalidaCabCE);
                    dtTabla.TableName = dtTabla.Rows[0]["Datatable"].ToString();                   
                    rpt.Load(Server.MapPath(dtTabla.Rows[0]["NombreArchivo"].ToString()));
                    rpt.SetDataSource(dtTabla);
                    rpt.PrintOptions.PrinterName = dtTabla.Rows[0]["Impresora"].ToString();
                    rpt.SetDataSource(dtTabla);
                    rpt.PrintToPrinter(1, true, 1, 1);
                    break;
                case 105:
                    objTrasladosCabCE.CodTraslado = Convert.ToInt32(Request.QueryString["Codigo"]);
                    objTrasladosCabCE.CodTipoFormato = Convert.ToInt32(Request.QueryString["CodTipoFormato"]);
                    
                    dtTabla = objTrasladosCabCN.F_TrasladosCab_Impresion(objTrasladosCabCE);
                    dtTabla.TableName = dtTabla.Rows[0]["Datatable"].ToString();
                    rpt.Load(Server.MapPath(dtTabla.Rows[0]["NombreArchivo"].ToString()));
                    rpt.SetDataSource(dtTabla);
                    rpt.PrintOptions.PrinterName = dtTabla.Rows[0]["Impresora"].ToString();
                    rpt.SetDataSource(dtTabla);
                    rpt.PrintToPrinter(1, true, 1, 1);                    
                    break;
                case 106:
                    objTrasladosCabCE.CodTraslado = Convert.ToInt32(Request.QueryString["Codigo"]);
                    objTrasladosCabCE.CodTipoFormato = Convert.ToInt32(Request.QueryString["CodTipoFormato"]);                   
                    dtTabla = objTrasladosCabCN.F_TrasladosCab_Impresion_Electronica(objTrasladosCabCE);
                    dtTabla.TableName = dtTabla.Rows[0]["Datatable"].ToString() ?? "";

                    if (dtTabla.Rows.Count > 0)
                    {
                        dtTabla.Columns.Add("OR", typeof(byte[])); dtTabla.Columns.Add("PIE_PAGINA", typeof(string));

                        qrcode = new BarCode();
                        qrcode.Symbology = KeepAutomation.Barcode.Symbology.QRCode; qrcode.X = 6; qrcode.Y = 6; qrcode.LeftMargin = 6; qrcode.RightMargin = 6;
                        qrcode.TopMargin = 6; qrcode.BottomMargin = 6; qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
                                               
                        foreach (DataRow dr in dtTabla.Rows)
                        {
                            string cadenaQR = dr["NroRuc"].ToString().Replace("R.U.C. : ", "") + "|" + dr["T_Codigo_Tipo_Documento_Sunat"] + "|" + dr["SerieDoc"] + "|" + dr["NumeroDoc"] + "|" + dr["F_Fecha_Emision"] + "|" + dr["T_Codigo_Doc_Identidad_Sunat"] + "|" + dr["RucDestinatario"];
                            qrcode.CodeToEncode = cadenaQR; 
                            byte[] imageData = qrcode.generateBarcodeToByteArray(); 
                            dr["OR"] = imageData;
                        }
                        
                    }

                    rpt.Load(Server.MapPath(dtTabla.Rows[0]["NombreArchivo"].ToString()));
                    rpt.SetDataSource(dtTabla);
                    P_PDF(msMemoria);
                    break;
                case 202:
                    Parametro1.Value = Request.QueryString["SubTitulo"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.CodAlmacen = Convert.ToInt32(Request.QueryString["CodAlmacen"]);
                    objDocumentoVentaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
                    objDocumentoVentaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);

                    dtTabla = objDocumentoVentaCabCN.F_DOCUMENTOVENTACAB_REPORTE_VENTAS(objDocumentoVentaCabCE);

                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);
                    rpt.ParameterFields["SubTitulo"].CurrentValues.Clear();
                    rpt.ParameterFields["SubTitulo"].CurrentValues.AddValue(Parametro1.Value);
                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;
                case 206:
                    Parametro1.Value = Request.QueryString["SubTitulo"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.CodAlmacen = Convert.ToInt32(Request.QueryString["CodAlmacen"]);
                    objDocumentoVentaCabCE.Ranking = Convert.ToInt32(Request.QueryString["Ranking"]);
                    objDocumentoVentaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
                    objDocumentoVentaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);

                    dtTabla = objDocumentoVentaCabCN.F_DOCUMENTOVENTACAB_RANKINGVENTAS_REPORTE(objDocumentoVentaCabCE);

                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);
                    rpt.ParameterFields["SubTitulo"].CurrentValues.Clear();
                    rpt.ParameterFields["SubTitulo"].CurrentValues.AddValue(Parametro1.Value);
                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;
                case 207:
                    Parametro1.Value = Request.QueryString["SubTitulo"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.CodAlmacen = Convert.ToInt32(Request.QueryString["CodAlmacen"]);
                    objDocumentoVentaCabCE.CodEmpleado = Convert.ToInt32(Request.QueryString["CodEmpleado"]);
                    objDocumentoVentaCabCE.CodMoneda = Convert.ToInt32(Request.QueryString["CodMoneda"]);
                    objDocumentoVentaCabCE.DesdeInt = Convert.ToInt32(Request.QueryString["Desde"]);
                    objDocumentoVentaCabCE.HastaInt = Convert.ToInt32(Request.QueryString["Hasta"]);

                    dtTabla = objDocumentoVentaCabCN.F_DOCUMENTOVENTACAB_REPORTE_VENTA_X_VENDEDOR(objDocumentoVentaCabCE);

                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);
                    rpt.ParameterFields["SubTitulo"].CurrentValues.Clear();
                    rpt.ParameterFields["SubTitulo"].CurrentValues.AddValue(Parametro1.Value);
                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;
                case 208:
                    Parametro1.Value = Request.QueryString["SubTitulo"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
                    objDocumentoVentaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
                    objDocumentoVentaCabCE.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);
                    objDocumentoVentaCabCE.SerieDoc = Convert.ToString(Request.QueryString["SerieDoc"]);
                    objDocumentoVentaCabCE.CodAlmacen = Convert.ToInt32(Request.QueryString["CodAlmacen"]);
                    objDocumentoVentaCabCE.CodCliente = Convert.ToInt32(Request.QueryString["CodCliente"]);
                    objDocumentoVentaCabCE.CodEmpresa = Convert.ToInt32(Request.QueryString["CodEmpresa"]);
                    objDocumentoVentaCabCE.CodEmpleado = Convert.ToInt32(Request.QueryString["CodEmpleado"]);

                    dtTabla = objDocumentoVentaCabCN.F_DOCUMENTOVENTACAB_REPORTE_VENTA_TIPODOCUMENTO(objDocumentoVentaCabCE);
                    dtTabla.TableName = NombreTabla;
                    rpt.Load(Server.MapPath(NombreArchivo));
                  
                    rpt.SetDataSource(dtTabla);
                    rpt.ParameterFields["SubTitulo"].CurrentValues.Clear();
                    rpt.ParameterFields["SubTitulo"].CurrentValues.AddValue(Parametro1.Value);
                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    msMemoria = (MemoryStream)rpt.ExportToStream(ExportFormatType.PortableDocFormat);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = Convert.ToString(Request.QueryString["TipoArchivo"]);
                    Response.BinaryWrite(msMemoria.ToArray());                    
                    HttpContext.Current.ApplicationInstance.CompleteRequest();                   
                    break;
                case 209:
                    objProformaCabCE.CodProforma = Convert.ToInt32(Request.QueryString["Codigo"]);
                    dtTabla = objProformaCabCN.F_ProformaCab_VistaPreliminar(objProformaCabCE);
                    dtTabla.TableName = NombreTabla;

                    if (dtTabla.Rows.Count > 0)
                        NombreArchivo = dtTabla.Rows[0]["NombreArchivo"].ToString();

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    P_PDF(msMemoria);
                    break;
                case 210:
                    objDocumentoVentaCabCE.CodDocumentoVenta = Convert.ToInt32(Request.QueryString["Codigo"]);

                    dtTabla = objDocumentoVentaCabCN.F_DocumentoVentaCab_Impresion_Factura_Electronica(objDocumentoVentaCabCE);
                    dtTabla.TableName = NombreTabla;

                    NombreArchivo = dtTabla.Rows[0]["FormatoDespacho"].ToString();
                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.PrintOptions.PrinterName = dtTabla.Rows[0]["ImpresoraDespacho"].ToString();
                    rpt.SetDataSource(dtTabla);
                    rpt.PrintToPrinter(1, true, 1, 1);

                    break;
                case 211:
                    objProformaCabCE.CodProforma = Convert.ToInt32(Request.QueryString["Codigo"]);
                    dtTabla = objProformaCabCN.F_ProformaCab_VistaPreliminar(objProformaCabCE);
                    dtTabla.TableName = NombreTabla;

                    if (dtTabla.Rows.Count > 0)
                        NombreArchivo = dtTabla.Rows[0]["NombreArchivo"].ToString();

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    P_PDF(msMemoria);
                    break;

                case 212:
                    objDocumentoVentaCabCE.CodDocumentoVenta = Convert.ToInt32(Request.QueryString["Codigo"]);
                    objDocumentoVentaCabCE.CodTipoFormato = Convert.ToInt32(Request.QueryString["CodTipoFormato"]);

                    dtTabla = objDocumentoVentaCabCN.F_DocumentoVentaCab_VistaPreliminar_Factura(objDocumentoVentaCabCE);
                    
                    dtTabla.TableName = dtTabla.Rows[0]["Datatable"].ToString();
                              
                    if (dtTabla.Rows.Count > 0)
                    {
                        dtTabla.Columns.Add("QR", typeof(byte[])); dtTabla.Columns.Add("PIE_PAGINA", typeof(string));
                      
                        qrcode = new BarCode();
                        qrcode.Symbology = KeepAutomation.Barcode.Symbology.QRCode; qrcode.X = 6; qrcode.Y = 6; qrcode.LeftMargin = 6; qrcode.RightMargin = 6;
                        qrcode.TopMargin = 6; qrcode.BottomMargin = 6; qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;

                        if (Convert.ToInt32(dtTabla.Rows[0]["CodTipoDoc"]) == 2)
                        {
                            foreach (DataRow dr in dtTabla.Rows)
                            {
                                string cadenaQR = dr["RucEmpresa"].ToString().Replace("R.U.C. : ", "") + "|" + dr["T_Codigo_Tipo_Documento_Sunat"] + "|" + dr["SerieDoc"] + "|" + dr["NumeroDoc"] + "|" + dr["Igv"] + "|" + dr["Total"] + "|" + dr["F_Fecha_Emision"] + "|" + dr["T_Codigo_Doc_Identidad_Sunat"] + "|" + dr["Ruc"];
                                qrcode.CodeToEncode = cadenaQR; byte[] imageData = qrcode.generateBarcodeToByteArray(); dr["QR"] = imageData;
                            }
                        }
                        else
                        {
                            foreach (DataRow dr in dtTabla.Rows)
                            {
                                string cadenaQR = dr["UrlXml"].ToString() + dr["RucEmpresa"].ToString().Replace("R.U.C. : ", "") + "|" + dr["T_Codigo_Tipo_Documento_Sunat"] + "|" + dr["SerieDoc"] + "|" + dr["NumeroDoc"] + "|" + dr["Igv"] + "|" + dr["Total"] + "|" + dr["F_Fecha_Emision"] + "|" + dr["T_Codigo_Doc_Identidad_Sunat"] + "|" + dr["Ruc"];
                                qrcode.CodeToEncode = cadenaQR; byte[] imageData = qrcode.generateBarcodeToByteArray(); dr["QR"] = imageData;
                            }
                        }                    
                    }

                    rpt.Load(Server.MapPath(dtTabla.Rows[0]["NombreArchivo"].ToString()));
                    rpt.SetDataSource(dtTabla);
              
                    P_PDF(msMemoria);

                    break;
                case 213:
                    objDocumentoVentaCabCE.CodDocumentoVenta = Convert.ToInt32(Request.QueryString["Codigo"]);
                    objDocumentoVentaCabCE.CodTipoFormato = Convert.ToInt32(Request.QueryString["CodTipoFormato"]);

                    dtTabla = objDocumentoVentaCabCN.F_DocumentoVentaCab_Impresion_Factura_Electronica(objDocumentoVentaCabCE);

                    string NombreArchivoDespacho = dtTabla.Rows[0]["NombreArchivoDespacho"].ToString();                    
                    int NroCopiasRPT = Convert.ToInt32(dtTabla.Rows[0]["NroCopias"]);
                    string ImpresoraRPT = dtTabla.Rows[0]["Impresora"].ToString();

                    dtTabla.TableName = dtTabla.Rows[0]["Datatable"].ToString();
                                        
                    if (dtTabla.Rows.Count > 0)
                    {
                        dtTabla.Columns.Add("QR", typeof(byte[])); dtTabla.Columns.Add("PIE_PAGINA", typeof(string));
                        //dtTabla.Columns.Add("OR", typeof(byte[]));

                        qrcode = new BarCode();
                        qrcode.Symbology = KeepAutomation.Barcode.Symbology.QRCode; qrcode.X = 6; qrcode.Y = 6; qrcode.LeftMargin = 6; qrcode.RightMargin = 6;
                        qrcode.TopMargin = 6; qrcode.BottomMargin = 6; qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;

                        if (Convert.ToInt32(dtTabla.Rows[0]["CodTipoDoc"]) == 2)
                        {
                            foreach (DataRow dr in dtTabla.Rows)
                            {
                                string cadenaQR = dr["RucEmpresa"].ToString().Replace("R.U.C. : ", "") + "|" + dr["T_Codigo_Tipo_Documento_Sunat"] + "|" + dr["SerieDoc"] +                                                     "|" + dr["NumeroDoc"] + "|" + dr["Igv"] + "|" + dr["Total"] + "|" + dr["F_Fecha_Emision"] + "|" + dr                                                                           ["T_Codigo_Doc_Identidad_Sunat"] + "|" + dr["Ruc"];
                                qrcode.CodeToEncode = cadenaQR; byte[] imageData = qrcode.generateBarcodeToByteArray(); dr["QR"] = imageData;
                            }
                        }
                        else
                        {
                            foreach (DataRow dr in dtTabla.Rows)
                            {
                                string cadenaQR = dr["UrlXml"].ToString() + dr["RucEmpresa"].ToString().Replace("R.U.C. : ", "") + "|" + dr["T_Codigo_Tipo_Documento_Sunat"] +                                                  "|" + dr["SerieDoc"] + "|" + dr["NumeroDoc"] + "|" + dr["Igv"] + "|" + dr["Total"] + "|" + dr["F_Fecha_Emision"] + "|" + dr                                                    ["T_Codigo_Doc_Identidad_Sunat"] + "|" + dr["Ruc"];
                                qrcode.CodeToEncode = cadenaQR; byte[] imageData = qrcode.generateBarcodeToByteArray(); dr["QR"] = imageData;
                            }
                        }                       
                    }

                    rpt.Load(Server.MapPath(dtTabla.Rows[0]["NombreArchivo"].ToString()));
                    rpt.SetDataSource(dtTabla);
                    rpt.PrintOptions.PrinterName = ImpresoraRPT;
                    rpt.PrintToPrinter(1, true, 1, 1);

                    if (NombreArchivoDespacho != "")
                    {
                        rpt2.Load(Server.MapPath(NombreArchivoDespacho));
                        rpt2.SetDataSource(dtTabla);
                        rpt2.PrintOptions.PrinterName = ImpresoraRPT;
                        rpt2.PrintToPrinter(1, true, 1, 1);                       
                    }

                    if (dtTabla.Rows[0]["GuiaRemision"].ToString() != "")
                    { 
                        if (dtTabla.Rows[0]["GuiaRemision"].ToString().Substring(0, 1) == "T")
                        {                        
                            objTrasladosCabCE.CodTraslado = Convert.ToInt32(dtTabla.Rows[0]["CodTraslado"]);
                            objTrasladosCabCE.CodTipoFormato = Convert.ToInt32(Request.QueryString["CodTipoFormato"]);

                            DataTable dtTablaGE = null;

                            dtTablaGE = objTrasladosCabCN.F_TrasladosCab_Impresion(objTrasladosCabCE);
                            dtTablaGE.TableName = dtTablaGE.Rows[0]["Datatable"].ToString();
                            dtTablaGE.Columns.Add("QR", typeof(byte[]));

                            qrcode = new BarCode();
                            qrcode.Symbology = KeepAutomation.Barcode.Symbology.QRCode; qrcode.X = 6; qrcode.Y = 6; qrcode.LeftMargin = 6; qrcode.RightMargin = 6;
                            qrcode.TopMargin = 6; qrcode.BottomMargin = 6; qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;

                            foreach (DataRow dr in dtTablaGE.Rows)
                            {
                                string cadenaQR = dr["NroRuc"].ToString().Replace("R.U.C. : ", "") + "|" + dr["T_Codigo_Tipo_Documento_Sunat"] + "|" +
                                                  dr["SerieDoc"] + "|" + dr["NumeroDoc"] + "|" + "|" + dr["Emision"] + "|" +
                                                  dr["T_Codigo_Doc_Identidad_Sunat"] + "|" + dr["RucDestinatario"];
                                qrcode.CodeToEncode = cadenaQR; byte[] imageData2 = qrcode.generateBarcodeToByteArray(); dr["QR"] = imageData2;
                            }

                            rpt3.Load(Server.MapPath(dtTablaGE.Rows[0]["NombreArchivo"].ToString()));
                            rpt3.SetDataSource(dtTablaGE);
                            rpt3.PrintOptions.PrinterName = dtTablaGE.Rows[0]["Impresora"].ToString();
                            rpt3.PrintToPrinter(1, true, 1, 1);  
                        }                      
                    }
                break;
                case 214:
                    Parametro1.Value = Request.QueryString["SubTitulo"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.CodCliente = Convert.ToInt32(Request.QueryString["CodCliente"]);
                    objDocumentoVentaCabCE.CodAlmacen = Convert.ToInt32(Request.QueryString["CodAlmacen"]);
                    objDocumentoVentaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
                    objDocumentoVentaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
                    objDocumentoVentaCabCE.Placa = Convert.ToString(Request.QueryString["Placa"]);

                    dtTabla = objDocumentoVentaCabCN.F_DOCUMENTOVENTACAB_PLACAS_REPORTE(objDocumentoVentaCabCE);
                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["SubTitulo"].CurrentValues.Clear();
                    rpt.ParameterFields["SubTitulo"].CurrentValues.AddValue(Parametro1.Value);
                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;
                case 215:
                    objProformaCabCE.CodOrdenPedido = Convert.ToInt32(Request.QueryString["Codigo"]);
                    dtTabla = objProformaCabCN.F_OrdenPedido_VistaPreliminar(objProformaCabCE);
                    dtTabla.TableName = NombreTabla;

                    if (dtTabla.Rows.Count > 0)
                        NombreArchivo = dtTabla.Rows[0]["NombreArchivo"].ToString();

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    P_PDF(msMemoria);
                    break;
                case 216:
                    objProformaCabCE.CodOrdenPedido = Convert.ToInt32(Request.QueryString["Codigo"]);
                    dtTabla = objProformaCabCN.F_OrdenPedido_VistaPreliminar(objProformaCabCE);
                    dtTabla.TableName = NombreTabla;

                    if (dtTabla.Rows.Count > 0)
                   rpt.Load(Server.MapPath(dtTabla.Rows[0]["NombreArchivo"].ToString()));
                    rpt.SetDataSource(dtTabla);

                    rpt.PrintOptions.PrinterName = dtTabla.Rows[0]["Impresora"].ToString();
                    rpt.SetDataSource(dtTabla);
                    rpt.PrintToPrinter(1, true, 1, 1);

                    break;
                case 217:
                    Parametro1.Value = Request.QueryString["SubTitulo"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();
                              
                    objDocumentoVentaCabCE.CodAlmacen = Convert.ToInt32(Request["CodAlmacen"]);           
                    objDocumentoVentaCabCE.Desde = Convert.ToDateTime(Request["Desde"]);
                    objDocumentoVentaCabCE.Hasta = Convert.ToDateTime(Request["Hasta"]);

                    dtTabla = objDocumentoVentaCabCN.F_DOCUMENTOVENTACAB_VENTADIARIA(objDocumentoVentaCabCE);
                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["SubTitulo"].CurrentValues.Clear();
                    rpt.ParameterFields["SubTitulo"].CurrentValues.AddValue(Parametro1.Value);
                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;
                case 299:
                    Parametro1.Value = Request.QueryString["SubTitulo"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.CodAlmacen = Convert.ToInt32(Request.QueryString["CodAlmacen"]);
                    objDocumentoVentaCabCE.IdFamilia = Convert.ToInt32(Request.QueryString["IdFamilia"]);
                    objDocumentoVentaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
                    objDocumentoVentaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);

                    dtTabla = objDocumentoVentaCabCN.F_PROFORMACAB_SUMATORIA(objDocumentoVentaCabCE);

                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);
                    rpt.ParameterFields["SubTitulo"].CurrentValues.Clear();
                    rpt.ParameterFields["SubTitulo"].CurrentValues.AddValue(Parametro1.Value);
                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;
                case 300:
                    Parametro1.Value = Request.QueryString["SubTitulo"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objNotaIngresoSalidaCabCE.CodAlmacen = Convert.ToInt32(Request.QueryString["CodAlmacen"]);
                    objNotaIngresoSalidaCabCE.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);
                    objNotaIngresoSalidaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
                    objNotaIngresoSalidaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
                    objNotaIngresoSalidaCabCE.FlagImportacion = Convert.ToInt32(Request.QueryString["FlagImportacion"]);

                    dtTabla = objNotaIngresoSalidaCabCN.F_NOTAINGRESOSALIDACAB_REPORTE_COMPRAS(objNotaIngresoSalidaCabCE);

                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);
                    rpt.ParameterFields["SubTitulo"].CurrentValues.Clear();
                    rpt.ParameterFields["SubTitulo"].CurrentValues.AddValue(Parametro1.Value);
                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;
                case 301:
                    objNotaIngresoSalidaCabCE.CodMovimiento = Convert.ToInt32(Request.QueryString["Codigo"]);
                    dtTabla = objNotaIngresoSalidaCabCN.F_NotaIngresoSalidaCab_Impresion_Factura(objNotaIngresoSalidaCabCE);
                    dtTabla.TableName = NombreTabla;
                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    P_PDF(msMemoria);
                    break;
                case 302:
                    objNotaIngresoSalidaCabCE.CodMovimiento = Convert.ToInt32(Request.QueryString["Codigo"]);
                    dtTabla = objNotaIngresoSalidaCabCN.F_NotaIngresoSalidaCab_Impresion_Factura(objNotaIngresoSalidaCabCE);
                    dtTabla.TableName = NombreTabla;
                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    P_PDF(msMemoria);
                    break;
                case 400:
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
                    objDocumentoVentaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
                    objDocumentoVentaCabCE.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);
                    objDocumentoVentaCabCE.CodMoneda = Convert.ToInt32(Request.QueryString["CodMoneda"]);
                    objDocumentoVentaCabCE.CodVendedor = Convert.ToInt32(Request.QueryString["CodVendedor"]);

                    objDocumentoVentaCabCE.XmlDetalle = "";
                    dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Request["XmlCliente"]);
                    foreach (dynamic item in jArr2)
                    {
                        objDocumentoVentaCabCE.XmlDetalle = objDocumentoVentaCabCE.XmlDetalle + "<D ";
                        objDocumentoVentaCabCE.XmlDetalle = objDocumentoVentaCabCE.XmlDetalle + " CodCtaCte = '" + item.CodCtaCte + "'";
                        objDocumentoVentaCabCE.XmlDetalle = objDocumentoVentaCabCE.XmlDetalle + " />";
                    }
                    objDocumentoVentaCabCE.XmlDetalle = "<R><XmlLC> " + objDocumentoVentaCabCE.XmlDetalle + "</XmlLC></R>";

                    dtTabla = objDocumentoVentaCabCN.F_Cobranzas_Reporte(objDocumentoVentaCabCE);
                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;
                case 401:
                    Parametro1.Value = Request.QueryString["SubTitulo"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.CodCliente = Convert.ToInt32(Request.QueryString["CodCliente"]);
                    objDocumentoVentaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
                    objDocumentoVentaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
                    objDocumentoVentaCabCE.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);
                    objDocumentoVentaCabCE.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
                    objDocumentoVentaCabCE.CodMoneda = Convert.ToInt32(Request.QueryString["CodMoneda"]);
                    objDocumentoVentaCabCE.CodVendedor = Convert.ToInt32(Request.QueryString["CodVendedor"]);

                    if (Request.QueryString["Resumido"].ToString().Equals("0"))
                        dtTabla = objDocumentoVentaCabCN.F_DOCUMENTOVENTACAB_REPORTECOBRANZARESUMIDO(objDocumentoVentaCabCE);
                    else
                        dtTabla = objDocumentoVentaCabCN.F_Cobranzas_Reporte_Cobrados(objDocumentoVentaCabCE);

                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["SubTitulo"].CurrentValues.Clear();
                    rpt.ParameterFields["SubTitulo"].CurrentValues.AddValue(Parametro1.Value);
                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;
                case 402:
                    Parametro1.Value = Request.QueryString["SubTitulo"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.CodCliente = Convert.ToInt32(Request.QueryString["CodCliente"]);
                    objDocumentoVentaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
                    objDocumentoVentaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
                    objDocumentoVentaCabCE.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);
                    objDocumentoVentaCabCE.CodAlmacen = Convert.ToInt32(Request.QueryString["CodAlmacen"]);

                    dtTabla = objDocumentoVentaCabCN.F_ObligacionesTributariasCab_REPORTE(objDocumentoVentaCabCE);

                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["SubTitulo"].CurrentValues.Clear();
                    rpt.ParameterFields["SubTitulo"].CurrentValues.AddValue(Parametro1.Value);
                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;
                case 403:
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objLGProductosCE.IdFamilia = Convert.ToInt32(Request.QueryString["IdFamilia"]);
                    objLGProductosCE.DscProducto = Convert.ToString(Request.QueryString["DscProducto"]);

                    dtTabla = objLGProductosCN.F_LGProductos_ListarProductosPrecios_Reporte_KARINA(objLGProductosCE);
                    dtTabla.TableName = NombreTabla;

                    if (dtTabla.Rows.Count > 0)
                        NombreArchivo = dtTabla.Rows[0]["NombreArchivo"].ToString();

                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;

                case 404:
                    Parametro1.Value = Request.QueryString["SubTitulo"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.CodAlmacen = Convert.ToInt32(Request["CodAlmacen"]);
                    objDocumentoVentaCabCE.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);
                    objDocumentoVentaCabCE.CodMedioPago = Convert.ToInt32(Request["CodMedioPago"]);
                    objDocumentoVentaCabCE.CodTipoDoc = Convert.ToInt32(Request["CodTipoDoc"]);
                    objDocumentoVentaCabCE.FlagAcuenta = Convert.ToInt32(Request["FlagAcuenta"]);
                    objDocumentoVentaCabCE.NumeroDoc = Convert.ToString(Request["Numero"]);
                    objDocumentoVentaCabCE.Desde = Convert.ToDateTime(Request["Desde"]);
                    objDocumentoVentaCabCE.Hasta = Convert.ToDateTime(Request["Hasta"]);
                    objDocumentoVentaCabCE.CodCliente = Convert.ToInt32(Request["CodCtaCte"]);

                    dtTabla = objDocumentoVentaCabCN.F_DOCUMENTOVENTACAB_LISTAR_COBRANZAS_DETALLADO_HISTORIAL(objDocumentoVentaCabCE);

                    if (dtTabla.Rows.Count > 0)
                        NombreArchivo = dtTabla.Rows[0]["NombreArchivo"].ToString();

                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);
                    rpt.ParameterFields["SubTitulo"].CurrentValues.Clear();
                    rpt.ParameterFields["SubTitulo"].CurrentValues.AddValue(Parametro1.Value);

                    P_PDF(msMemoria);
                    break;
                    
                case 405:
                    Parametro1.Value = Request.QueryString["SubTitulo"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.CodAlmacen = Convert.ToInt32(Request["CodAlmacen"]);
                    objDocumentoVentaCabCE.CodEmpleado = Convert.ToInt32(Request["CodEmpleado"]);
                    objDocumentoVentaCabCE.Desde = Convert.ToDateTime(Request["Desde"]);
                    objDocumentoVentaCabCE.Hasta = Convert.ToDateTime(Request["Hasta"]);

                    dtTabla = objDocumentoVentaCabCN.F_DocumentoVentaCab_VENTA_EMPLEADO_DETALLADO(objDocumentoVentaCabCE);

                    if (dtTabla.Rows.Count > 0)
                        NombreArchivo = dtTabla.Rows[0]["NombreArchivo"].ToString();

                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);
                    rpt.ParameterFields["SubTitulo"].CurrentValues.Clear();
                    rpt.ParameterFields["SubTitulo"].CurrentValues.AddValue(Parametro1.Value);

                    P_PDF(msMemoria);
                    break;
                case 406:
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
                    objDocumentoVentaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
                    objDocumentoVentaCabCE.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);
                    objDocumentoVentaCabCE.CodMoneda = Convert.ToInt32(Request.QueryString["CodMoneda"]);
                    objDocumentoVentaCabCE.CodVendedor = Convert.ToInt32(Request.QueryString["CodVendedor"]);

                    objDocumentoVentaCabCE.XmlDetalle = "";
                    dynamic jArr3 = Newtonsoft.Json.JsonConvert.DeserializeObject(Request["XmlCliente"]);
                    foreach (dynamic item in jArr3)
                    {
                        objDocumentoVentaCabCE.XmlDetalle = objDocumentoVentaCabCE.XmlDetalle + "<D ";
                        objDocumentoVentaCabCE.XmlDetalle = objDocumentoVentaCabCE.XmlDetalle + " CodCtaCte = '" + item.CodCtaCte + "'";
                        objDocumentoVentaCabCE.XmlDetalle = objDocumentoVentaCabCE.XmlDetalle + " />";
                    }
                    objDocumentoVentaCabCE.XmlDetalle = "<R><XmlLC> " + objDocumentoVentaCabCE.XmlDetalle + "</XmlLC></R>";

                    dtTabla = objDocumentoVentaCabCN.F_Cobranzas_Facturas_Vencidas_Reporte(objDocumentoVentaCabCE);
                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;
                case 407:
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
                    objDocumentoVentaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
                    objDocumentoVentaCabCE.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);
                    objDocumentoVentaCabCE.CodMoneda = Convert.ToInt32(Request.QueryString["CodMoneda"]);
                    objDocumentoVentaCabCE.CodVendedor = Convert.ToInt32(Request.QueryString["CodVendedor"]);

                    objDocumentoVentaCabCE.XmlDetalle = "";
                    dynamic jArr4 = Newtonsoft.Json.JsonConvert.DeserializeObject(Request["XmlCliente"]);
                    foreach (dynamic item in jArr4)
                    {
                        objDocumentoVentaCabCE.XmlDetalle = objDocumentoVentaCabCE.XmlDetalle + "<D ";
                        objDocumentoVentaCabCE.XmlDetalle = objDocumentoVentaCabCE.XmlDetalle + " CodCtaCte = '" + item.CodCtaCte + "'";
                        objDocumentoVentaCabCE.XmlDetalle = objDocumentoVentaCabCE.XmlDetalle + " />";
                    }
                    objDocumentoVentaCabCE.XmlDetalle = "<R><XmlLC> " + objDocumentoVentaCabCE.XmlDetalle + "</XmlLC></R>";

                    dtTabla = objDocumentoVentaCabCN.F_DOCUMENTOVENTACAB_FACTURAS_VENCIDAS_RESUMIDO(objDocumentoVentaCabCE);
                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;
                case 408:
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
                    objDocumentoVentaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
                    objDocumentoVentaCabCE.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);
                    objDocumentoVentaCabCE.CodMoneda = Convert.ToInt32(Request.QueryString["CodMoneda"]);
                    objDocumentoVentaCabCE.CodVendedor = Convert.ToInt32(Request.QueryString["CodVendedor"]);

                    objDocumentoVentaCabCE.XmlDetalle = "";
                    dynamic jArr5 = Newtonsoft.Json.JsonConvert.DeserializeObject(Request["XmlCliente"]);
                    foreach (dynamic item in jArr5)
                    {
                        objDocumentoVentaCabCE.XmlDetalle = objDocumentoVentaCabCE.XmlDetalle + "<D ";
                        objDocumentoVentaCabCE.XmlDetalle = objDocumentoVentaCabCE.XmlDetalle + " CodCtaCte = '" + item.CodCtaCte + "'";
                        objDocumentoVentaCabCE.XmlDetalle = objDocumentoVentaCabCE.XmlDetalle + " />";
                    }
                    objDocumentoVentaCabCE.XmlDetalle = "<R><XmlLC> " + objDocumentoVentaCabCE.XmlDetalle + "</XmlLC></R>";

                    dtTabla = objDocumentoVentaCabCN.F_Cobranzas_Reporte_COBRADOS_HASTA(objDocumentoVentaCabCE);
                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;
                case 409:
                    Parametro1.Value = Request.QueryString["SubTitulo"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
                    objDocumentoVentaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
                    objDocumentoVentaCabCE.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);
                    objDocumentoVentaCabCE.CodMotivo = Convert.ToInt32(Request.QueryString["CodMotivo"]);

                    dtTabla = objDocumentoVentaCabCN.F_ComprobanteCaja_COMISIONES(objDocumentoVentaCabCE);
                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    rpt.ParameterFields["SubTitulo"].CurrentValues.Clear();
                    rpt.ParameterFields["SubTitulo"].CurrentValues.AddValue(Parametro1.Value);

                    P_PDF(msMemoria);
                    break;

                case 410:
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
                    objDocumentoVentaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
                    objDocumentoVentaCabCE.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);
                    objDocumentoVentaCabCE.CodMoneda = Convert.ToInt32(Request.QueryString["CodMoneda"]);
                    objDocumentoVentaCabCE.CodVendedor = Convert.ToInt32(Request.QueryString["CodVendedor"]);

                    objDocumentoVentaCabCE.XmlDetalle = "";
                    dynamic jArr7 = Newtonsoft.Json.JsonConvert.DeserializeObject(Request["XmlCliente"]);
                    foreach (dynamic item in jArr7)
                    {
                        objDocumentoVentaCabCE.XmlDetalle = objDocumentoVentaCabCE.XmlDetalle + "<D ";
                        objDocumentoVentaCabCE.XmlDetalle = objDocumentoVentaCabCE.XmlDetalle + " CodCtaCte = '" + item.CodCtaCte + "'";
                        objDocumentoVentaCabCE.XmlDetalle = objDocumentoVentaCabCE.XmlDetalle + " />";
                    }
                    objDocumentoVentaCabCE.XmlDetalle = "<R><XmlLC> " + objDocumentoVentaCabCE.XmlDetalle + "</XmlLC></R>";

                    dtTabla = objDocumentoVentaCabCN.F_Cobranzas_Reporte_Credito(objDocumentoVentaCabCE);
                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;
                case 500:
                    Parametro1.Value = Request.QueryString["SubTitulo"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objNotaIngresoSalidaCabCE.CodEmpresa = Convert.ToInt32(Request.QueryString["CodEmpresa"]);
                    objNotaIngresoSalidaCabCE.CodCtaCte = Convert.ToInt32(Request.QueryString["CodCtaCte"]);
                    objNotaIngresoSalidaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
                    objNotaIngresoSalidaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
                    objNotaIngresoSalidaCabCE.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);

                    dtTabla = objNotaIngresoSalidaCabCN.F_FacturasXPagar_Reporte(objNotaIngresoSalidaCabCE);
                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["SubTitulo"].CurrentValues.Clear();
                    rpt.ParameterFields["SubTitulo"].CurrentValues.AddValue(Parametro1.Value);
                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;
                case 501:
                    Parametro1.Value = Request.QueryString["SubTitulo"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objNotaIngresoSalidaCabCE.CodEmpresa = Convert.ToInt32(Request.QueryString["CodEmpresa"]);
                    objNotaIngresoSalidaCabCE.CodCtaCte = Convert.ToInt32(Request.QueryString["CodCliente"]);
                    objNotaIngresoSalidaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
                    objNotaIngresoSalidaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
                    objNotaIngresoSalidaCabCE.CodMoneda = Convert.ToInt32(Request.QueryString["CodMoneda"]);

                    dtTabla = objNotaIngresoSalidaCabCN.F_Pagos_Reporte_Pagados(objNotaIngresoSalidaCabCE);
                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["SubTitulo"].CurrentValues.Clear();
                    rpt.ParameterFields["SubTitulo"].CurrentValues.AddValue(Parametro1.Value);
                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;
                case 700:
                    Parametro1.Value = Request.QueryString["Mensaje"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();
                    objDocumentoVentaCabCE.FechaEmision = Convert.ToDateTime(Request.QueryString["FechaEmision"]);
                    objDocumentoVentaCabCE.FechaSaldo = Convert.ToDateTime(Request.QueryString["FechaSaldo"]);
                    objDocumentoVentaCabCE.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
                    objDocumentoVentaCabCE.CodCajaFisica = Convert.ToInt32(Request.QueryString["CodCajaFisica"]);
                    objDocumentoVentaCabCE.CodUsuario = Convert.ToInt32(Request.QueryString["CodUsuario"]);
                    objDocumentoVentaCabCE.CodEmpresa = Convert.ToInt32(Request.QueryString["CodEmpresa"]);

                    dtTabla = objDocumentoVentaCabCN.F_CajaChica_Regenerar_VistaPreliminar(objDocumentoVentaCabCE);
                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["Mensaje"].CurrentValues.Clear();
                    rpt.ParameterFields["Mensaje"].CurrentValues.AddValue(Parametro1.Value);
                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;
                case 701:
                    Parametro1.Value = Request.QueryString["Mensaje"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.FechaEmision = Convert.ToDateTime(Request.QueryString["FechaEmision"]);
                    objDocumentoVentaCabCE.FechaSaldo = Convert.ToDateTime(Request.QueryString["FechaSaldo"]);
                    objDocumentoVentaCabCE.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
                    objDocumentoVentaCabCE.CodCajaFisica = Convert.ToInt32(Request.QueryString["CodCajaFisica"]);
                    objDocumentoVentaCabCE.CodEmpresa = Convert.ToInt32(Request.QueryString["CodEmpresa"]);
                    objDocumentoVentaCabCE.CodMedioPago = Convert.ToInt32(Request.QueryString["CodMedioPago"]);

                    dtTabla = objDocumentoVentaCabCN.F_CajaChica_Detalle(objDocumentoVentaCabCE);
                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["Mensaje"].CurrentValues.Clear();
                    rpt.ParameterFields["Mensaje"].CurrentValues.AddValue(Parametro1.Value);
                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;
                case 702:
                    Parametro1.Value = Request.QueryString["SubTitulo"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.CodAlmacen = Convert.ToInt32(Request.QueryString["CodAlmacen"]);
                    objDocumentoVentaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
                    objDocumentoVentaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
                    objDocumentoVentaCabCE.CodCliente = Convert.ToInt32(Request.QueryString["CodCliente"]);
                    objDocumentoVentaCabCE.CodCtaBancaria = Convert.ToInt32(Request.QueryString["CodCtaBancaria"]);
                    objDocumentoVentaCabCE.CodCajaFisica = Convert.ToInt32(Request.QueryString["CodCajaFisica"]);

                    dtTabla = objDocumentoVentaCabCN.F_COBRANZASCAB_CUENTABANCARIA(objDocumentoVentaCabCE);
                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["SubTitulo"].CurrentValues.Clear();
                    rpt.ParameterFields["SubTitulo"].CurrentValues.AddValue(Parametro1.Value);
                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;
                case 703:
                    objNotaIngresoSalidaCabCE.CodMovimiento = Convert.ToInt32(Request.QueryString["Codigo"]);
                    objNotaIngresoSalidaCabCE.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);
                    objNotaIngresoSalidaCabCE.CodTipoFormato = Convert.ToInt32(Request.QueryString["CodTipoFormato"]);
                    dtTabla = objNotaIngresoSalidaCabCN.F_NotaIngresoSalidaCab_ComprobanteEgreso_VistaPreliminar(objNotaIngresoSalidaCabCE);
                    dtTabla.TableName = NombreTabla;
                    NombreArchivo = dtTabla.Rows[0]["Formato"].ToString();
                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    P_PDF(msMemoria);
                    break;
                case 704:
                    objNotaIngresoSalidaCabCE.CodMovimiento = Convert.ToInt32(Request.QueryString["Codigo"]);
                    objNotaIngresoSalidaCabCE.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);

                    dtTabla = objNotaIngresoSalidaCabCN.F_NotaIngresoSalidaCab_ComprobanteEgreso_Imprimir(objNotaIngresoSalidaCabCE);
                    dtTabla.TableName = NombreTabla;

                    NombreArchivo = dtTabla.Rows[0]["FormatoReporte"].ToString();
                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.PrintOptions.PrinterName = dtTabla.Rows[0]["Impresora"].ToString(); ;
                    rpt.SetDataSource(dtTabla);
                    rpt.PrintToPrinter(1, true, 1, 1);
                    break;
                case 705:
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.FechaEmision = Convert.ToDateTime(Request.QueryString["FechaEmision"]);
                    objDocumentoVentaCabCE.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
                    objDocumentoVentaCabCE.CodCajaFisica = Convert.ToInt32(Request.QueryString["CodCajaFisica"]);

                    dtTabla = objDocumentoVentaCabCN.F_CAJACHICA_RESUMIDO(objDocumentoVentaCabCE);
                    dtTabla.TableName = NombreTabla;

                    objDocumentoVentaCabCE.NroOperacion = "CI";
                    DataTable dtCI = objDocumentoVentaCabCN.PA_CAJACHICA_RESUMIDO_DETALLE(objDocumentoVentaCabCE);
                    objDocumentoVentaCabCE.NroOperacion = "CE";
                    DataTable dtCE = objDocumentoVentaCabCN.PA_CAJACHICA_RESUMIDO_DETALLE(objDocumentoVentaCabCE);

                    NombreArchivo = dtTabla.Rows[0]["NombreArchivo"].ToString();
                    //NombreArchivo = "Web_Reporte_CajaBanco_rptCajaChicaResumido_Ticket3.rpt";
                    rpt.Load(Server.MapPath(NombreArchivo));

                    rpt.PrintOptions.PrinterName = dtTabla.Rows[0]["Impresora"].ToString();

                    rpt.SetDataSource(dtTabla);
                    rpt.Subreports[0].SetDataSource(dtCI);
                    rpt.Subreports[1].SetDataSource(dtCE);
                    //P_PDF(msMemoria);
                    rpt.PrintToPrinter(1, true, 1, 1);

                    break;
                case 706:
                    Parametro1.Value = Request.QueryString["SubTitulo"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.CodAlmacen = Convert.ToInt32(Request.QueryString["CodAlmacen"]);
                    objDocumentoVentaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
                    objDocumentoVentaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);

                    dtTabla = objDocumentoVentaCabCN.F_REPORTE_RXH(objDocumentoVentaCabCE);
                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["SubTitulo"].CurrentValues.Clear();
                    rpt.ParameterFields["SubTitulo"].CurrentValues.AddValue(Parametro1.Value);
                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;

                case 707:
                    ParameterDiscreteValue Parametro4 = new ParameterDiscreteValue();
                    ParameterDiscreteValue Parametro5 = new ParameterDiscreteValue();
                    ParameterDiscreteValue Parametro6 = new ParameterDiscreteValue();
                    ParameterDiscreteValue Parametro7 = new ParameterDiscreteValue();
                    ParameterDiscreteValue Parametro8 = new ParameterDiscreteValue();

                    Parametro1.Value = Request.QueryString["NombreVendedor"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();
                    Parametro3.Value = Request.QueryString["NombreRuta"].ToString();
                    Parametro4.Value = Request.QueryString["Desde"].ToString();
                    Parametro5.Value = Request.QueryString["Hasta"].ToString();
                    Parametro8.Value = Request.QueryString["chkFecha"].ToString();
                    
                        Parametro6.Value = Request.QueryString["DesdeCancelacion"].ToString();
                        Parametro7.Value = Request.QueryString["HastaCancelacion"].ToString();
                    
                    objDocumentoVentaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
                    objDocumentoVentaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
                    objDocumentoVentaCabCE.Ruta = Convert.ToInt32(Request.QueryString["Ruta"]);
                    objDocumentoVentaCabCE.CodVendedor = Convert.ToInt32(Request.QueryString["Vendedor"]);
                    if (Convert.ToInt32(Request.QueryString["chkFecha"]) == 1)
                    {
                        objDocumentoVentaCabCE.DesdeCancelacion = Convert.ToDateTime(Request.QueryString["DesdeCancelacion"]);
                        objDocumentoVentaCabCE.HastaCancelacion = Convert.ToDateTime(Request.QueryString["HastaCancelacion"]);
                    }
                    else
                    {
                        objDocumentoVentaCabCE.DesdeCancelacion = Convert.ToDateTime("01/01/1990");
                        objDocumentoVentaCabCE.HastaCancelacion = Convert.ToDateTime("01/01/1990");
                    }

                    dtTabla = objDocumentoVentaCabCN.F_COBRANZAS_REPORTE_VENTA_COMISION(objDocumentoVentaCabCE);
                    dtTabla.TableName = NombreTabla;



                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);
                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);
                    rpt.ParameterFields["NombreVendedor"].CurrentValues.Clear();
                    rpt.ParameterFields["NombreVendedor"].CurrentValues.AddValue(Parametro1.Value);
                    rpt.ParameterFields["NombreRuta"].CurrentValues.Clear();
                    rpt.ParameterFields["NombreRuta"].CurrentValues.AddValue(Parametro3.Value);
                    rpt.ParameterFields["Desde"].CurrentValues.Clear();
                    rpt.ParameterFields["Desde"].CurrentValues.AddValue(Parametro4.Value);
                    rpt.ParameterFields["Hasta"].CurrentValues.Clear();
                    rpt.ParameterFields["Hasta"].CurrentValues.AddValue(Parametro5.Value);
                    rpt.ParameterFields["DesdeCancelacion"].CurrentValues.Clear();
                    rpt.ParameterFields["DesdeCancelacion"].CurrentValues.AddValue(Parametro6.Value);
                    rpt.ParameterFields["HastaCancelacion"].CurrentValues.Clear();
                    rpt.ParameterFields["HastaCancelacion"].CurrentValues.AddValue(Parametro7.Value);
                    rpt.ParameterFields["chkFecha"].CurrentValues.Clear();
                    rpt.ParameterFields["chkFecha"].CurrentValues.AddValue(Parametro8.Value);


                    P_PDF(msMemoria);
                    break;

                case 708:
                    Parametro1.Value = Request.QueryString["SubTitulo"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.CodAlmacen = Convert.ToInt32(Request["CodAlmacen"]);
                    objDocumentoVentaCabCE.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);
                    objDocumentoVentaCabCE.CodMedioPago = Convert.ToInt32(Request["CodMedioPago"]);
                    objDocumentoVentaCabCE.CodTipoDoc = Convert.ToInt32(Request["CodTipoDoc"]);
                    objDocumentoVentaCabCE.FlagAcuenta = Convert.ToInt32(Request["FlagAcuenta"]);
                    objDocumentoVentaCabCE.NumeroDoc = Convert.ToString(Request["Numero"]);
                    objDocumentoVentaCabCE.Desde = Convert.ToDateTime(Request["Desde"]);
                    objDocumentoVentaCabCE.Hasta = Convert.ToDateTime(Request["Hasta"]);
                    objDocumentoVentaCabCE.CodCliente = Convert.ToInt32(Request["CodCtaCte"]);
                    objDocumentoVentaCabCE.Ruta = Convert.ToInt32(Request["Ruta"]);
                    objDocumentoVentaCabCE.CodVendedor = Convert.ToInt32(Request["CodVendedor"]);


                    dtTabla = objDocumentoVentaCabCN.F_DOCUMENTOVENTACAB_LISTAR_COBRANZAS(objDocumentoVentaCabCE);

                    if (dtTabla.Rows.Count > 0)
                        NombreArchivo = dtTabla.Rows[0]["NombreArchivo"].ToString();

                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);
                    rpt.ParameterFields["SubTitulo"].CurrentValues.Clear();
                    rpt.ParameterFields["SubTitulo"].CurrentValues.AddValue(Parametro1.Value);

                    P_PDF(msMemoria);
                    break;

                case 709:
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objLGProductosCE.IdFamilia = Convert.ToInt32(Request.QueryString["IdFamilia"]);
                    objLGProductosCE.DscProducto = Convert.ToString(Request.QueryString["DscProducto"]);
                    objLGProductosCE.CodMarca = Convert.ToInt32(Request.QueryString["CodMarca"]);
                    objLGProductosCE.chkMarca = Convert.ToInt32(Request.QueryString["Marca"]);

                    dtTabla = objLGProductosCN.F_LGProductos_ListarProductosPrecios_Reeim(objLGProductosCE);
                    dtTabla.TableName = NombreTabla;

                    if (dtTabla.Rows.Count > 0)
                        NombreArchivo = dtTabla.Rows[0]["NombreArchivo"].ToString();

                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;

                case 710:
                    Parametro1.Value = Request.QueryString["Mensaje"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.FechaEmision = Convert.ToDateTime(Request.QueryString["FechaEmision"]);
                    objDocumentoVentaCabCE.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
                    objDocumentoVentaCabCE.CodCajaFisica = Convert.ToInt32(Request.QueryString["CodCajaFisica"]);
                    objDocumentoVentaCabCE.CodEmpresa = Convert.ToInt32(Request.QueryString["CodEmpresa"]);
                    objDocumentoVentaCabCE.CodMedioPago = Convert.ToInt32(Request.QueryString["CodMedioPago"]);

                    dtTabla = objDocumentoVentaCabCN.F_CajaChica_Detalle_Efectivo(objDocumentoVentaCabCE);
                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["Mensaje"].CurrentValues.Clear();
                    rpt.ParameterFields["Mensaje"].CurrentValues.AddValue(Parametro1.Value);
                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;
                case 711:
                    Parametro1.Value = Request.QueryString["Mensaje"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    //objDocumentoVentaCabCE.FechaEmision = Convert.ToDateTime(Request.QueryString["FechaEmision"]);
                    //objDocumentoVentaCabCE.FechaSaldo = Convert.ToDateTime(Request.QueryString["FechaSaldo"]);
                    objDocumentoVentaCabCE.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
                    //objDocumentoVentaCabCE.CodCajaFisica = Convert.ToInt32(Request.QueryString["CodCajaFisica"]);
                    objDocumentoVentaCabCE.CodEmpresa = Convert.ToInt32(Request.QueryString["CodEmpresa"]);
                    objDocumentoVentaCabCE.Codliquidacion = Convert.ToInt32(Request.QueryString["lblCodigo"]);

                    dtTabla = objDocumentoVentaCabCN.F_CajaChica_Detalle_liquidacion(objDocumentoVentaCabCE);
                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["Mensaje"].CurrentValues.Clear();
                    rpt.ParameterFields["Mensaje"].CurrentValues.AddValue(Parametro1.Value);
                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;

                case 712:
                    Parametro1.Value = Request.QueryString["Mensaje"].ToString();
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objNotaIngresoSalidaCabCE.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);
                    objNotaIngresoSalidaCabCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
                    objNotaIngresoSalidaCabCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
                    objNotaIngresoSalidaCabCE.CodProducto = Convert.ToInt32(Request.QueryString["CodProducto"]);
                    if (Convert.ToString(Request["CodAlmacen"]) == "T")
                        objNotaIngresoSalidaCabCE.CodAlmacen = 0;
                    else
                        objNotaIngresoSalidaCabCE.CodAlmacen = Convert.ToInt32(Request["CodAlmacen"]);



                    dtTabla = objNotaIngresoSalidaCabCN.F_Utilidad_Bruta(objNotaIngresoSalidaCabCE);
                    dtTabla.TableName = NombreTabla;

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    rpt.ParameterFields["Mensaje"].CurrentValues.Clear();
                    rpt.ParameterFields["Mensaje"].CurrentValues.AddValue(Parametro1.Value);
                    rpt.ParameterFields["Titulo"].CurrentValues.Clear();
                    rpt.ParameterFields["Titulo"].CurrentValues.AddValue(Parametro2.Value);

                    P_PDF(msMemoria);
                    break;

                case 713:
                    objCheckListCE.CodVehiculoCheckListCab = Convert.ToInt32(Request.QueryString["Codigo"]);
                    dtTabla = objCheckListCN.F_CHECKLIST_VistaPreliminar(objCheckListCE);
                    dtTabla.TableName = NombreTabla;

                    if (dtTabla.Rows.Count > 0)
                        NombreArchivo = dtTabla.Rows[0]["NombreArchivo"].ToString();

                    rpt.Load(Server.MapPath(NombreArchivo));
                    rpt.SetDataSource(dtTabla);

                    P_PDF(msMemoria);
                    break;
                case 716:
                   Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.FechaEmision = Convert.ToDateTime(Request.QueryString["FechaEmision"]);
                    objDocumentoVentaCabCE.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
                    objDocumentoVentaCabCE.CodCajaFisica = Convert.ToInt32(Request.QueryString["CodCajaFisica"]);

                    dtTabla = objDocumentoVentaCabCN.F_CAJACHICA_RESUMIDO(objDocumentoVentaCabCE);
                    dtTabla.TableName = NombreTabla;

                    objDocumentoVentaCabCE.NroOperacion = "CI";
                    dtCI = objDocumentoVentaCabCN.PA_CAJACHICA_RESUMIDO_DETALLE(objDocumentoVentaCabCE);
                    objDocumentoVentaCabCE.NroOperacion = "CE";
                    dtCE = objDocumentoVentaCabCN.PA_CAJACHICA_RESUMIDO_DETALLE(objDocumentoVentaCabCE);

                    NombreArchivo = dtTabla.Rows[0]["NombreArchivo"].ToString();
                    //NombreArchivo = "Web_Reporte_CajaBanco_rptCajaChicaResumido_Ticket3.rpt";
                    rpt.Load(Server.MapPath(NombreArchivo));

                    //rpt.PrintOptions.PrinterName = dtTabla.Rows[0]["Impresora"].ToString();

                    rpt.SetDataSource(dtTabla);
                    //rpt.Subreports[0].SetDataSource(dtCI);
                    //rpt.Subreports[1].SetDataSource(dtCE);
                    P_PDF(msMemoria);
                    //rpt.PrintToPrinter(1, true, 1, 1);

                    break;
                case 717:
                    Parametro2.Value = Request.QueryString["Titulo"].ToString();

                    objDocumentoVentaCabCE.FechaEmision = Convert.ToDateTime(Request.QueryString["FechaEmision"]);
                    objDocumentoVentaCabCE.FechaSaldo = Convert.ToDateTime(Request.QueryString["FechaSaldo"]);
                    objDocumentoVentaCabCE.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
                    objDocumentoVentaCabCE.CodCajaFisica = Convert.ToInt32(Request.QueryString["CodCajaFisica"]);

                    dtTabla = objDocumentoVentaCabCN.F_CAJACHICA_RESUMIDO_TICKET(objDocumentoVentaCabCE);
                    dtTabla.TableName = NombreTabla;

                    NombreArchivo = dtTabla.Rows[0]["NombreArchivo"].ToString();
                    //NombreArchivo = "Web_Reporte_CajaBanco_rptCajaChicaResumido_Ticket3.rpt";
                    rpt.Load(Server.MapPath(NombreArchivo));

                    //rpt.PrintOptions.PrinterName = dtTabla.Rows[0]["Impresora"].ToString();

                    rpt.SetDataSource(dtTabla);
                    //rpt.Subreports[0].SetDataSource(dtCI);
                    //rpt.Subreports[1].SetDataSource(dtCE);
                    P_PDF(msMemoria);
                    //rpt.PrintToPrinter(1, true, 1, 1);

                    break;

            }
        }

        private string GetIP()
        {
            string visitorIPAddress = "";
            string IPHost = Dns.GetHostName();
            string IP = Dns.GetHostByName(IPHost).AddressList[0].ToString();
            return IP;
        }

        public void P_PDF(MemoryStream msMemoria)
        {

            System.IO.Stream tempStream = rpt.ExportToStream(ExportFormatType.PortableDocFormat);
            msMemoria = new MemoryStream();
            tempStream.CopyTo(msMemoria);
            tempStream = null;

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = Convert.ToString(Request.QueryString["TipoArchivo"]);
            Response.BinaryWrite(msMemoria.ToArray());
            msMemoria = null;
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
}
