//using CSharpAndExcel.DAL;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using System;
using System.Drawing;
using System.IO;
using System.Data;
using CapaEntidad;
using CapaNegocios;
using System.Linq;
namespace SistemaInventario.Reportes
{
    public partial class Web_Pagina_ConstruirExcel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(Request["CodMenu"]))
            {

                case 1:
                    P_RegistroVentas();
                    break;
                case 2:
                    P_CobranzasExcel();
                    break;
                case 3:
                    P_ListaPedidos();
                    break;
                case 4:
                    P_ReporteVentas();
                    break;
                case 5:
                    P_ReporteVentasDetallado();
                    break;
                case 6:
                    P_ReporteCompras();
                    break;
                case 7:
                    P_ReporteComprasDetallado();
                    break;
                case 8:
                    P_ReporteComprasDetallado();
                    break;
                case 9:
                    ExportarExcelDetalle();
                    break;
                case 10:
                    P_RankingVenta();
                    break;
                case 11:
                    P_ReporteVentasPorPeriodoPorFamilia();
                    break;
                case 12:
                    P_ReporteVentasPorPeriodoCompleto();
                    break;
                case 13:
                    P_ReporteNotaSalidaSinenlazar();
                    break;
                case 202:
                    P_Ventas_VentasNetas();
                    break;
                case 203:
                    P_Ventas_ServiciosPorFacturar();
                    break;
                case 204:
                    P_Ventas_VentasDiarias();
                    break;
                case 300:
                    P_Compras_ComprasPlaza();
                    break;
                case 301:
                    P_Contabilidad_RegistroCompras();
                    break;
                case 302:
                    P_Contabilidad_RegistroCompras_Concar_Roman();
                    break;
                case 303:
                    P_Compras_FacturaCompras_Reporte_Salcedo();
                    break;
                case 400:
                    P_PROFORMACAB_LISTAR();
                    break;
                case 401:
                    P_CobranzasPeriodo();
                    break;
                case 600:
                    P_Contabilidad_RegistroVentas_Roman();
                    break;
                case 601:
                    P_Contabilidad_RegistroVentas_Concar_Roman();
                    break;
                case 801:
                    P_Planilla_RegimenConstruccionCivil();
                    break;                
                case 802:
                    P_Planilla_RegimenGeneral();
                    break;
                case 3000:
                    ExportarExcelDetalleREEIM();
                    break;
                case 3001:
                    P_Registro_RPH();
                    break;
                case 709:
                    P_ListadoPrecio_Povis();
                    break;
                case 710:
                    P_Inventario_StockActual();
                    break;
                case 711:
                    P_Reporte_Ventas_Mes();
                    break;                
                case 712:
                    P_Reporte_Caja_Chica();
                    break;
                case 713:
                    P_Reporte_Caja_Chica_Grupal();
                    break;
                case 714:
                    P_Inventario_StockActual_Salcedo();
                    break;
                case 715:
                    P_Reporte_CP();
                    break;
                case 716:
                    P_Contabilidad_Registrocobranzas();
                    break;
                case 717:
                    P_Contabilidad_ClientesNuevos();
                    break;
                case 718:
                    P_CajaBanco_ReporteTarjetaDeposito();
                    break;
                case 719:
                    P_CajaBanco_LiquidacionCaja();
                    break;
                case 1000:
                    P_Reporte_Cobranzas();
                    break;
                case 1001:
                    P_Reporte_Cobranzas_Hasta();
                    break;
            }
        }

        public void P_Contabilidad_RegistroCompras()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 500000; i++)
                ws.DeleteRow(1);

            NotaIngresoSalidaCabCE objEntidad = new NotaIngresoSalidaCabCE();
            NotaIngresoSalidaCabCN objOperacion = new NotaIngresoSalidaCabCN();

            objEntidad.CodAlmacen = Convert.ToInt32(Request["CodAlmacen"]);
            objEntidad.Desde = Convert.ToDateTime(Request["Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(Request["Hasta"]);

            DataTable dtTabla = null;

            dtTabla = objOperacion.F_NOTAINGRESOSALIDACAB_REPORTE_CONTABILIDAD_REGISTROCOMPRA(objEntidad);

            ws.Cells["A1"].LoadFromDataTable(dtTabla, true);

            ws.Cells["h:h"].Style.Numberformat.Format = null;
            ws.Cells["h:h"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["i:i"].Style.Numberformat.Format = null;
            ws.Cells["i:i"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["j:j"].Style.Numberformat.Format = null;
            ws.Cells["j:j"].Style.Numberformat.Format = "#,##0.00";
            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }
        
        public void P_Contabilidad_RegistroVentas_Roman()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 500000; i++)
                ws.DeleteRow(1);

            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            objEntidad.CodAlmacen = Convert.ToInt32(Request["CodAlmacen"]);
            objEntidad.Desde = Convert.ToDateTime(Request["Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(Request["Hasta"]);

            DataTable dtTabla = null;

            dtTabla = objOperacion.F_DOCUMENTOVENTACAB_REPORTE_CONTABILIDAD_REGISTROVENTA(objEntidad);

            ws.Cells["A1"].LoadFromDataTable(dtTabla, true);

            ws.Cells["h:h"].Style.Numberformat.Format = null;
            ws.Cells["h:h"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["i:i"].Style.Numberformat.Format = null;
            ws.Cells["i:i"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["j:j"].Style.Numberformat.Format = null;
            ws.Cells["j:j"].Style.Numberformat.Format = "#,##0.00";
            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_Contabilidad_RegistroVentas_Concar_Roman()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 4; i < 50000; i++)
                ws.DeleteRow(4);

            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            objEntidad.CodAlmacen = Convert.ToInt32(Request["CodAlmacen"]);
            objEntidad.Desde = Convert.ToDateTime(Request["Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(Request["Hasta"]);
            objEntidad.Numero = Convert.ToInt32(Request["Numero"]);

            DataTable dtTabla = null;

            dtTabla = objOperacion.F_DOCUMENTOVENTACAB_REPORTE_CONTABILIDAD_REGISTROVENTA_CONCAR(objEntidad);

            ws.Cells["A4"].LoadFromDataTable(dtTabla, true);
            ws.DeleteRow(4);  
            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_Contabilidad_RegistroCompras_Concar_Roman()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 4; i < 50000; i++)
                ws.DeleteRow(4);

            NotaIngresoSalidaCabCE objEntidad = new NotaIngresoSalidaCabCE();
            NotaIngresoSalidaCabCN objOperacion = new NotaIngresoSalidaCabCN();

            objEntidad.CodAlmacen = Convert.ToInt32(Request["CodAlmacen"]);
            objEntidad.Desde = Convert.ToDateTime(Request["Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(Request["Hasta"]);
            objEntidad.Numero = Convert.ToInt32(Request["Numero"]);

            DataTable dtTabla = null;

            dtTabla = objOperacion.F_NOTAINGRESOSALIDACAB_REPORTE_CONTABILIDAD_REGISTROCOMPRA_CONCAR(objEntidad);

            ws.Cells["A4"].LoadFromDataTable(dtTabla, true);
            ws.DeleteRow(4);
            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_Compras_FacturaCompras_Reporte_Salcedo()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 50000; i++)
                ws.DeleteRow(1);

            NotaIngresoSalidaCabCE objEntidad = new NotaIngresoSalidaCabCE();
            NotaIngresoSalidaCabCN objOperacion = new NotaIngresoSalidaCabCN();

            objEntidad.CodMovimiento = Convert.ToInt32(Request["CodMovimiento"]);

            DataTable dtTabla = null;

            dtTabla = objOperacion.F_NOTAINGRESOSALIDACAB_REPORTE_EXCEL(objEntidad);

            ws.Cells["A1"].LoadFromDataTable(dtTabla, true);

            ws.Cells["m:m"].Style.Numberformat.Format = null;
            ws.Cells["m:m"].Style.Numberformat.Format = "#,##0.00";

            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }
        
        public void P_RegistroVentas()
        {
            FileInfo newFile = new FileInfo(Server.MapPath("RegistroVentas.xlsx"));

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets["VENTAS"];

            for (int i = 2; i < 500000; i++)
                ws.DeleteRow(2);

            //ws.DeleteRow(i);
            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            objEntidad.CodEmpresa = 3;
            objEntidad.CodAlmacen = Convert.ToInt32(Request["CodSede"]);
            objEntidad.Desde = Convert.ToDateTime(Request["Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(Request["Hasta"]);
            objEntidad.DesdeInt = int.Parse(objEntidad.Desde.ToString("yyyyMMdd"));
            objEntidad.HastaInt = int.Parse(objEntidad.Hasta.ToString("yyyyMMdd"));

            DataTable dtTabla = null;

            dtTabla = objOperacion.F_DocumentoVentaCab_RegistroVentas_Excel(objEntidad);

            ws.Cells["A2"].LoadFromDataTable(dtTabla, true);
            ws.DeleteRow(2);

            //Ejemplos de como se deben manipular algunos campos
            //ws.DeleteRow(8);
            //ws.DeleteColumn(20);
            //ws.Cells["B2"].Value = dtTabla.Rows[0]["Periodo"].ToString();
            //object BaseImponibleSuma;
            //BaseImponibleSuma = dtTabla.Compute("Sum(BaseImponible)", "");
            //ws.Cells["L" + Convert.ToString(dtTabla.Rows.Count + 8)].Value = BaseImponibleSuma.ToString();
            //ws.Cells["L" + Convert.ToString(dtTabla.Rows.Count + 8)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

            ws.Cells["l:l"].Style.Numberformat.Format = null;
            ws.Cells["l:l"].Style.Numberformat.Format = "#,##0.00";

            //String Cadena = "";
            //Cadena ="A8:S8," +  "A" + Convert.ToString(dtTabla.Rows.Count + 8) + ":" + "S" + Convert.ToString(dtTabla.Rows.Count + 8);

            //using (ExcelRange rng = ws.Cells[Cadena])
            //{
            //    rng.Style.Font.Bold = true;
            //    rng.Style.Font.SetFromFont(new Font("Arial", 10));
            //    rng.AutoFitColumns();
            //}

            pck.Save();

            //System.Diagnostics.Process.Start(Server.MapPath("RegistroVentas.xlsx"));
            MemoryStream msMemoria = null;
            //msMemoria = (MemoryStream)pck.ExportToStream(ExportFormatType.PortableDocFormat);

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=RegistroVentas.xlsx");
            Response.TransmitFile(Server.MapPath("RegistroVentas.xlsx"));
            Response.End();
        }

        public void P_CobranzasExcel()
        {
            FileInfo newFile = new FileInfo(Server.MapPath("Cobranzas.xlsx"));

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets["COBRANZAS"];

            for (int i = 2; i < 10000; i++)
                ws.DeleteRow(4);

            //ws.DeleteRow(i);
            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            objEntidad.CodCobranza = Convert.ToInt32(Request["CodCobranza"]);


            DataTable dtTabla = null;

            dtTabla = objOperacion.F_Cobranzas_RegistroCobranzas_Listar_Excel(objEntidad);

            ws.Cells["A4"].LoadFromDataTable(dtTabla, true);
            ws.DeleteRow(4);

            //Ejemplos de como se deben manipular algunos campos
            //ws.DeleteRow(8);
            //ws.DeleteColumn(20);
            //ws.Cells["B2"].Value = dtTabla.Rows[0]["Periodo"].ToString();
            //object BaseImponibleSuma;
            //BaseImponibleSuma = dtTabla.Compute("Sum(BaseImponible)", "");
            //ws.Cells["L" + Convert.ToString(dtTabla.Rows.Count + 8)].Value = BaseImponibleSuma.ToString();
            //ws.Cells["L" + Convert.ToString(dtTabla.Rows.Count + 8)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

            //ws.Cells["l:l"].Style.Numberformat.Format = null;
            //ws.Cells["l:l"].Style.Numberformat.Format = "#,##0.00";

            //String Cadena = "";
            //Cadena ="A8:S8," +  "A" + Convert.ToString(dtTabla.Rows.Count + 8) + ":" + "S" + Convert.ToString(dtTabla.Rows.Count + 8);

            //using (ExcelRange rng = ws.Cells[Cadena])
            //{
            //    rng.Style.Font.Bold = true;
            //    rng.Style.Font.SetFromFont(new Font("Arial", 10));
            //    rng.AutoFitColumns();
            //}

            object MontoCobranzas;
            MontoCobranzas = dtTabla.Compute("Sum(MontoCobranzas)", "");
            string m = MontoCobranzas.ToString(); if (m.Trim() == "") m = "0";

            ws.Cells["F" + Convert.ToString(dtTabla.Rows.Count + 4)].Value = "Total Cobranzas";
            ws.Cells["G" + Convert.ToString(dtTabla.Rows.Count + 4)].Value = decimal.Parse(m);

            object MontoPagos;
            MontoPagos = dtTabla.Compute("Sum(MontoPagos)", "");
            string m2 = MontoPagos.ToString(); if (m2.Trim() == "") m2 = "0";
            ws.Cells["H" + Convert.ToString(dtTabla.Rows.Count + 4)].Value = "Total Pagos";
            ws.Cells["I" + Convert.ToString(dtTabla.Rows.Count + 4)].Value = decimal.Parse(m2);

            ws.Cells["B2"].Value = DateTime.Now.ToString();

            pck.Save();

            //System.Diagnostics.Process.Start(Server.MapPath("RegistroVentas.xlsx"));
            MemoryStream msMemoria = null;
            //msMemoria = (MemoryStream)pck.ExportToStream(ExportFormatType.PortableDocFormat);

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Cobranzas.xlsx");
            Response.TransmitFile(Server.MapPath("Cobranzas.xlsx"));
            Response.End();
        }

        public void P_ListaPedidos()
        {
            FileInfo newFile = new FileInfo(Server.MapPath("Xls_ListaPedidos.xlsx"));

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets["CODIGOS"];

            for (int i = 2; i < 10000; i++)
                ws.DeleteRow(2);

       
            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            objEntidad.CodDocumentoVenta = Convert.ToInt32(Request["Codigo"]);
            objEntidad.Igv = 1;
            objEntidad.CodMoneda = 1;
            objEntidad.Tasa = 1;

            DataTable dtTabla = objOperacion.F_TemporalFacturacionDet_Listar(objEntidad);
            DataTable dtFinal = new DataTable();
            DataColumn cCodigo = new DataColumn("Codigo");
            dtFinal.Columns.Add(cCodigo);
            if (dtTabla.Rows.Count > 0)
            {
                foreach (DataRow cod in dtTabla.Rows)
                {
                    DataRow dr = dtFinal.NewRow();
                    dr["Codigo"] = cod["CodigoProducto"];
                    dtFinal.Rows.Add(dr);
                }
            }

            ws.Cells["A1"].LoadFromDataTable(dtFinal, true);

            pck.Save();

            MemoryStream msMemoria = null;
   
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Xls_ListaPedidos.xlsx");
            Response.TransmitFile(Server.MapPath("Xls_ListaPedidos.xlsx"));
            Response.End();
        }

        public void P_CrearRegistroVentas()
        {
            using (ExcelPackage pck = new ExcelPackage())
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Ventas");

                ws.Cells["A1"].Value = "FORMATO 14.1: REGISTRO DE VENTAS E INGRESOS";

                if (Convert.ToInt32(Request["FlagReporte"]) == 1)
                {
                    using (ExcelRange rng = ws.Cells["A1:V1"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Merge = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        rng.Style.Font.SetFromFont(new Font("Arial", 14));

                    }
                }
                else
                {
                    using (ExcelRange rng = ws.Cells["A1:S1"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Merge = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        rng.Style.Font.SetFromFont(new Font("Arial", 14));

                    }
                }

                ws.Cells["A3"].Value = "PERIODO:";
                ws.Cells["A4"].Value = "RUC:";
                ws.Cells["A5"].Value = "APELLIDOS Y NOMBRES, DENOMINACIÓN O RAZÓN SOCIAL:";

                using (ExcelRange rng = ws.Cells["A3:A4"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    rng.Style.Font.SetFromFont(new Font("Arial", 12));
                }

                using (ExcelRange rng = ws.Cells["A5:E5"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Merge = true;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    rng.Style.Font.SetFromFont(new Font("Arial", 12));
                    rng.AutoFitColumns();
                }

                ws.Cells["A7"].Value = "NÚMERO";
                ws.Cells["A8"].Value = "CORRELATIVO";
                ws.Cells["A9"].Value = "DEL REGISTRO O";
                ws.Cells["A10"].Value = "CÓDIGO UNICO";
                ws.Cells["A11"].Value = "DE LA OPERACIÓN";

                ws.Cells["B7"].Value = " FECHA DE";
                ws.Cells["B8"].Value = "EMISIÓN DEL";
                ws.Cells["B9"].Value = "COMPROBANTE";
                ws.Cells["B10"].Value = "DE PAGO";
                ws.Cells["B11"].Value = "O DOCUMENTO";

                ws.Cells["C7"].Value = "FECHA";
                ws.Cells["C8"].Value = "DE";
                ws.Cells["C9"].Value = "VENCIMIENTO";
                ws.Cells["C10"].Value = "Y/O PAGO";
                ws.Cells["C11"].Value = "";

                ws.Cells["D7"].Value = "COMPROBANTE DE PAGO";
                ws.Cells["D8"].Value = "O DOCUMENTO";

                ws.Cells["D9 "].Value = "";
                ws.Cells["D10"].Value = "TIPO";
                ws.Cells["D11"].Value = "(TABLA 10)";

                ws.Cells["E9"].Value = "N° SERIE O";
                ws.Cells["E10"].Value = "N° DE SERIE DE LA";
                ws.Cells["E11"].Value = "MAQUINA REGISTRADORA";

                ws.Cells["F9"].Value = "";
                ws.Cells["F10"].Value = "NÚMERO";
                ws.Cells["F11"].Value = "";

                ws.Cells["G7"].Value = "INFORMACIÓN DEL CLIENTE";
                ws.Cells["G8"].Value = "";
                ws.Cells["G9"].Value = "DOCUMENTO DE IDENTIDAD";
                ws.Cells["G10"].Value = "TIPO";
                ws.Cells["G11"].Value = "(TABLA 2)";

                ws.Cells["H10"].Value = "NÚMERO";
                ws.Cells["H11"].Value = "";

                ws.Cells["I9"].Value = "APELLIDOS Y NOMBRES,";
                ws.Cells["I10"].Value = "DENOMINACIÓN";
                ws.Cells["I11"].Value = "O RAZÓN SOCIAL";

                ws.Cells["J7"].Value = "VALOR";
                ws.Cells["J8"].Value = "FACTURADO";
                ws.Cells["J9"].Value = "DE LA";
                ws.Cells["J10"].Value = "EXPORTACIÓN";
                ws.Cells["J11"].Value = "";

                if (Convert.ToInt32(Request["FlagReporte"]) == 1)
                {
                    ws.Cells["K7"].Value = "BASE";
                    ws.Cells["K8"].Value = "IMPONIBLE";
                    ws.Cells["K9"].Value = "DE LA";
                    ws.Cells["K10"].Value = "OPERACIÓN";
                    ws.Cells["K11"].Value = "GRAVADA";

                    ws.Cells["L7"].Value = "IMPORTE TOTAL DE LA OPERACIÓN";
                    ws.Cells["L8"].Value = "EXONERADA O INAFECTA";
                    ws.Cells["L9"].Value = "";
                    ws.Cells["L10"].Value = "EXONERADA";
                    ws.Cells["L11"].Value = "";

                    ws.Cells["M9"].Value = "";
                    ws.Cells["M10"].Value = "INAFECTA";
                    ws.Cells["M11"].Value = "";

                    ws.Cells["N9"].Value = "ISC";
                    ws.Cells["O9"].Value = "IGV Y/O IPM";

                    ws.Cells["P7"].Value = "OTROS TRIBUTOS";
                    ws.Cells["P8"].Value = "Y CARGOS QUE";
                    ws.Cells["P9"].Value = "NO FORMAN PARTE";
                    ws.Cells["P10"].Value = "DE LA";
                    ws.Cells["P11"].Value = " BASE IMPONIBLE";

                    ws.Cells["Q7"].Value = "IMPORTE";
                    ws.Cells["Q8"].Value = "TOTAL";
                    ws.Cells["Q9"].Value = "DEL";
                    ws.Cells["Q10"].Value = "COMPROBANTE";
                    ws.Cells["Q11"].Value = "DE PAGO";

                    ws.Cells["R7"].Value = "";
                    ws.Cells["R8"].Value = "TIPO";
                    ws.Cells["R9"].Value = "DE";
                    ws.Cells["R10"].Value = "CAMBIO";
                    ws.Cells["R11"].Value = "";

                    ws.Cells["S7"].Value = "REFERENCIA DEL COMPROBANTE DE PAGO";
                    ws.Cells["S8"].Value = "O DOCUMENTO ORIGINAL QUE SE MODIFICA";
                    ws.Cells["S9"].Value = "";
                    ws.Cells["S10"].Value = "FECHA";
                    ws.Cells["S11"].Value = "";

                    ws.Cells["T9"].Value = "";
                    ws.Cells["T10"].Value = "TIPO";
                    ws.Cells["T11"].Value = "TABLA (10)";

                    ws.Cells["U9"].Value = "";
                    ws.Cells["U10"].Value = "SERIE";
                    ws.Cells["U11"].Value = "";

                    ws.Cells["V9"].Value = "N° DEL";
                    ws.Cells["V10"].Value = "COMPROBANTE";
                    ws.Cells["V11"].Value = "DE PAGO O DOCUMENTO";

                }
                else
                {
                    ws.Cells["K7"].Value = "";
                    ws.Cells["K8"].Value = "";
                    ws.Cells["K9"].Value = "CTA";
                    ws.Cells["K10"].Value = "";
                    ws.Cells["K11"].Value = "";

                    ws.Cells["L7"].Value = "BASE";
                    ws.Cells["L8"].Value = "IMPONIBLE";
                    ws.Cells["L9"].Value = "DE LA";
                    ws.Cells["L10"].Value = "OPERACIÓN";
                    ws.Cells["L11"].Value = "GRAVADA";

                    ws.Cells["M7"].Value = "IMPORTE TOTAL DE LA OPERACIÓN";
                    ws.Cells["M8"].Value = "EXONERADA O INAFECTA";
                    ws.Cells["M9"].Value = "";
                    ws.Cells["M10"].Value = "EXONERADA";
                    ws.Cells["M11"].Value = "";

                    ws.Cells["N9"].Value = "";
                    ws.Cells["N10"].Value = "INAFECTA";
                    ws.Cells["N11"].Value = "";

                    ws.Cells["O9"].Value = "ISC";
                    ws.Cells["P9"].Value = "IGV Y/O IPM";

                    ws.Cells["Q7"].Value = "OTROS TRIBUTOS";
                    ws.Cells["Q8"].Value = "Y CARGOS QUE";
                    ws.Cells["Q9"].Value = "NO FORMAN PARTE";
                    ws.Cells["Q10"].Value = "DE LA";
                    ws.Cells["Q11"].Value = " BASE IMPONIBLE";

                    ws.Cells["R7"].Value = "IMPORTE";
                    ws.Cells["R8"].Value = "TOTAL";
                    ws.Cells["R9"].Value = "DEL";
                    ws.Cells["R10"].Value = "COMPROBANTE";
                    ws.Cells["R11"].Value = "DE PAGO";

                    ws.Cells["S7"].Value = "";
                    ws.Cells["S8"].Value = "TIPO";
                    ws.Cells["S9"].Value = "DE";
                    ws.Cells["S10"].Value = "CAMBIO";
                    ws.Cells["S11"].Value = "";

                    ws.Cells["T7"].Value = "REFERENCIA DEL COMPROBANTE DE PAGO";
                    ws.Cells["T8"].Value = "O DOCUMENTO ORIGINAL QUE SE MODIFICA";
                    ws.Cells["T9"].Value = "";
                    ws.Cells["T10"].Value = "FECHA";
                    ws.Cells["T11"].Value = "";

                    ws.Cells["U9"].Value = "";
                    ws.Cells["U10"].Value = "TIPO";
                    ws.Cells["U11"].Value = "TABLA (10)";

                    ws.Cells["V9"].Value = "";
                    ws.Cells["V10"].Value = "SERIE";
                    ws.Cells["V11"].Value = "";

                    ws.Cells["W9"].Value = "N° DEL";
                    ws.Cells["W10"].Value = "COMPROBANTE";
                    ws.Cells["W11"].Value = "DE PAGO O DOCUMENTO";
                }


                using (ExcelRange rng = ws.Cells["D7:F7"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    rng.Style.Font.SetFromFont(new Font("Arial", 12));
                    rng.Merge = true;
                }

                using (ExcelRange rng = ws.Cells["D8:F8"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    rng.Style.Font.SetFromFont(new Font("Arial", 12));
                    rng.Merge = true;
                }

                if (Convert.ToInt32(Request["FlagReporte"]) == 1)
                {
                    using (ExcelRange rng = ws.Cells["A7:V7"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                        rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                        rng.Style.Font.Color.SetColor(Color.White);
                        rng.AutoFitColumns();
                    }
                    using (ExcelRange rng = ws.Cells["A8:V8"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                        rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                        rng.Style.Font.Color.SetColor(Color.White);
                        rng.AutoFitColumns();
                    }
                    using (ExcelRange rng = ws.Cells["A9:V9"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                        rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                        rng.Style.Font.Color.SetColor(Color.White);
                        rng.AutoFitColumns();
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                        rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                        rng.Style.Font.Color.SetColor(Color.White);
                        rng.AutoFitColumns();
                    }
                    using (ExcelRange rng = ws.Cells["A10:V10"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                        rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                        rng.Style.Font.Color.SetColor(Color.White);
                        rng.AutoFitColumns();
                    }
                    using (ExcelRange rng = ws.Cells["A11:V11"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                        rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                        rng.Style.Font.Color.SetColor(Color.White);
                        rng.AutoFitColumns();
                    }
                }
                else
                {
                    using (ExcelRange rng = ws.Cells["A7:S7"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                        rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                        rng.Style.Font.Color.SetColor(Color.White);
                        rng.AutoFitColumns();
                    }
                    using (ExcelRange rng = ws.Cells["A8:S8"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                        rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                        rng.Style.Font.Color.SetColor(Color.White);
                        rng.AutoFitColumns();
                    }
                    using (ExcelRange rng = ws.Cells["A9:S9"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                        rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                        rng.Style.Font.Color.SetColor(Color.White);
                        rng.AutoFitColumns();
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                        rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                        rng.Style.Font.Color.SetColor(Color.White);
                        rng.AutoFitColumns();
                    }
                    using (ExcelRange rng = ws.Cells["A10:S10"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                        rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                        rng.Style.Font.Color.SetColor(Color.White);
                        rng.AutoFitColumns();
                    }
                    using (ExcelRange rng = ws.Cells["A11:S11"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                        rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                        rng.Style.Font.Color.SetColor(Color.White);
                        rng.AutoFitColumns();
                    }
                }



                using (ExcelRange rng = ws.Cells["G7:I7"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    rng.Style.Font.SetFromFont(new Font("Arial", 10));
                    rng.Merge = true;
                }

                using (ExcelRange rng = ws.Cells["G9:H9"])
                {
                    rng.Merge = true;
                    rng.Style.Font.Bold = true;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    rng.Style.Font.SetFromFont(new Font("Arial", 10));
                    rng.AutoFitColumns();
                }
                if (Convert.ToInt32(Request["FlagReporte"]) == 1)
                {
                    using (ExcelRange rng = ws.Cells["L7:M7"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Merge = true;
                    }

                    using (ExcelRange rng = ws.Cells["L8:M8"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Merge = true;
                    }

                    using (ExcelRange rng = ws.Cells["S7:V7"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Merge = true;
                    }

                    using (ExcelRange rng = ws.Cells["S8:V8"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Merge = true;
                    }

                }
                else
                {
                    using (ExcelRange rng = ws.Cells["M7:N7"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Merge = true;
                    }

                    using (ExcelRange rng = ws.Cells["M8:N8"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));
                        rng.Merge = true;
                    }

                    using (ExcelRange rng = ws.Cells["S7:V7"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));

                    }

                    using (ExcelRange rng = ws.Cells["S8:V8"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.SetFromFont(new Font("Arial", 10));

                    }
                }

                ws.Column(7).Width = 180;
                ws.Column(8).Width = 180;
                for (int i = 1; i <= ws.Dimension.End.Column; i++)
                { ws.Column(i).AutoFit(); }

                DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
                DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

                objEntidad.CodEmpresa = 3;
                objEntidad.Periodo = Convert.ToInt32(Request["Periodo"]);
                DataTable dtTabla = null;

                dtTabla = objOperacion.F_DocumentoVentaCab_RegistroVentas_Excel(objEntidad);

                ws.Cells["B3"].Value = dtTabla.Rows[0]["Periodo"].ToString();
                ws.Cells["B4"].Value = dtTabla.Rows[0]["Nroruc"].ToString();
                ws.Cells["F5"].Value = dtTabla.Rows[0]["RazonSocial"].ToString();

                using (ExcelRange rng = ws.Cells["B3:B4"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    rng.Style.Font.SetFromFont(new Font("Arial", 12));

                }

                using (ExcelRange rng = ws.Cells["F5:M5"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    rng.Style.Font.SetFromFont(new Font("Arial", 12));
                    rng.Merge = true;
                }

                ws.Cells["A12"].LoadFromDataTable(dtTabla, true);
                ws.DeleteRow(12);
                object BaseImponibleSuma;
                object IGVSuma;
                object TotalSuma;
                object OtrosTributos;
                if (Convert.ToInt32(Request["FlagReporte"]) == 1)
                {
                    ws.DeleteColumn(11);
                    ws.DeleteColumn(20);
                    ws.DeleteColumn(23);
                    ws.DeleteColumn(24);
                    ws.DeleteColumn(25);



                    BaseImponibleSuma = dtTabla.Compute("Sum(BaseImponible)", "");
                    IGVSuma = dtTabla.Compute("Sum(IGV)", "");
                    TotalSuma = dtTabla.Compute("Sum(Total)", "");
                    OtrosTributos = dtTabla.Compute("Sum(OtrosTributos)", "");

                    ws.Cells["I" + Convert.ToString(dtTabla.Rows.Count + 12)].Value = "TOTALES";
                    ws.Cells["K" + Convert.ToString(dtTabla.Rows.Count + 12)].Value = BaseImponibleSuma.ToString();
                    ws.Cells["O" + Convert.ToString(dtTabla.Rows.Count + 12)].Value = IGVSuma.ToString();
                    ws.Cells["P" + Convert.ToString(dtTabla.Rows.Count + 12)].Value = OtrosTributos.ToString();
                    ws.Cells["Q" + Convert.ToString(dtTabla.Rows.Count + 12)].Value = TotalSuma.ToString();
                    ws.Cells["K" + Convert.ToString(dtTabla.Rows.Count + 12)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells["O" + Convert.ToString(dtTabla.Rows.Count + 12)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells["P" + Convert.ToString(dtTabla.Rows.Count + 12)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells["Q" + Convert.ToString(dtTabla.Rows.Count + 12)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    ws.Cells["k:k"].Style.Numberformat.Format = null;
                    ws.Cells["k:k"].Style.Numberformat.Format = "#,##0.00";
                    ws.Cells["o:o"].Style.Numberformat.Format = null;
                    ws.Cells["o:o"].Style.Numberformat.Format = "#,##0.00";
                    ws.Cells["p:p"].Style.Numberformat.Format = null;
                    ws.Cells["p:p"].Style.Numberformat.Format = "#,##0.00";
                    ws.Cells["q:q"].Style.Numberformat.Format = null;
                    ws.Cells["q:q"].Style.Numberformat.Format = "#,##0.00";
                    ws.Cells["r:r"].Style.Numberformat.Format = null;
                    ws.Cells["r:r"].Style.Numberformat.Format = "#,##0.00";
                }
                else
                {

                    ws.DeleteColumn(20);
                    ws.DeleteColumn(21);
                    ws.DeleteColumn(22);
                    ws.DeleteColumn(23);
                    ws.DeleteColumn(24);
                    ws.DeleteColumn(25);
                    ws.DeleteColumn(26);


                    BaseImponibleSuma = dtTabla.Compute("Sum(BaseImponible)", "");
                    IGVSuma = dtTabla.Compute("Sum(IGV)", "");
                    TotalSuma = dtTabla.Compute("Sum(Total)", "");
                    OtrosTributos = dtTabla.Compute("Sum(OtrosTributos)", "");

                    ws.Cells["J" + Convert.ToString(dtTabla.Rows.Count + 12)].Value = "TOTALES";
                    ws.Cells["L" + Convert.ToString(dtTabla.Rows.Count + 12)].Value = BaseImponibleSuma.ToString();
                    ws.Cells["P" + Convert.ToString(dtTabla.Rows.Count + 12)].Value = IGVSuma.ToString();
                    ws.Cells["Q" + Convert.ToString(dtTabla.Rows.Count + 12)].Value = OtrosTributos.ToString();
                    ws.Cells["R" + Convert.ToString(dtTabla.Rows.Count + 12)].Value = TotalSuma.ToString();
                    ws.Cells["L" + Convert.ToString(dtTabla.Rows.Count + 12)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells["P" + Convert.ToString(dtTabla.Rows.Count + 12)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells["Q" + Convert.ToString(dtTabla.Rows.Count + 12)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    ws.Cells["R" + Convert.ToString(dtTabla.Rows.Count + 12)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                    ws.Cells["l:l"].Style.Numberformat.Format = null;
                    ws.Cells["l:l"].Style.Numberformat.Format = "#,##0.00";
                    ws.Cells["p:p"].Style.Numberformat.Format = null;
                    ws.Cells["p:p"].Style.Numberformat.Format = "#,##0.00";
                    ws.Cells["q:q"].Style.Numberformat.Format = null;
                    ws.Cells["q:q"].Style.Numberformat.Format = "#,##0.00";
                    ws.Cells["r:r"].Style.Numberformat.Format = null;
                    ws.Cells["r:r"].Style.Numberformat.Format = "#,##0.00";
                    ws.Cells["s:s"].Style.Numberformat.Format = null;
                    ws.Cells["s:s"].Style.Numberformat.Format = "#,##0.000";

                    String Cadena = "";
                    Cadena = "A" + Convert.ToString(dtTabla.Rows.Count + 12) + ":" + "S" + Convert.ToString(dtTabla.Rows.Count + 12);
                    using (ExcelRange rng = ws.Cells[Cadena])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                        rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                        rng.Style.Font.Color.SetColor(Color.White);
                        rng.AutoFitColumns();
                    }

                }

                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=RegistroVentas.xlsx");
                Response.BinaryWrite(pck.GetAsByteArray());
                Response.End();
            }
        }

        public void P_ReporteVentas()
        {
            DocumentoVentaCabCE objEntidadVenta = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacionVenta = new DocumentoVentaCabCN();
            objEntidadVenta.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
            objEntidadVenta.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
            objEntidadVenta.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);
            objEntidadVenta.SerieDoc = Convert.ToString(Request.QueryString["SerieDoc"]);
            objEntidadVenta.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidadVenta.CodCliente = Convert.ToInt32(Request.QueryString["CodCliente"]);
            objEntidadVenta.CodEmpresa = Convert.ToInt32(Request.QueryString["CodEmpresa"]);
            objEntidadVenta.CodVendedor = Convert.ToInt32(Request.QueryString["CodVendedor"]);
            String Tipo = Convert.ToString(Request.QueryString["Tipo"]);
            DataTable dtTabla = null;
            String fmtoExcel = "";
            String Empresa = "";
            String Sucursal = "";
            String Subtitulo = "Desde " + Request.QueryString["Desde"].ToString() + " Hasta " + Request.QueryString["Hasta"].ToString();

            dtTabla = objOperacionVenta.F_DOCUMENTOVENTACAB_REPORTE_VENTA_TIPODOCUMENTO(objEntidadVenta);
            dtTabla.TableName = "VentasReporte";
            fmtoExcel = "Ventas.xlsx";
            if (dtTabla.Rows.Count > 0)
            {
                Empresa = dtTabla.Rows[0][15].ToString();
                Sucursal = "SUCURSAL " + dtTabla.Rows[0][14].ToString();

                dtTabla.Columns.RemoveAt(18); dtTabla.Columns.RemoveAt(17);
                dtTabla.Columns.RemoveAt(16); dtTabla.Columns.RemoveAt(15);
                dtTabla.Columns.RemoveAt(14); dtTabla.Columns.RemoveAt(13);
                dtTabla.Columns.RemoveAt(12); dtTabla.Columns.RemoveAt(11);
            }

            FileInfo newFile = new FileInfo(Server.MapPath(fmtoExcel));
            ExcelPackage pck = new ExcelPackage(newFile);
            var ws = pck.Workbook.Worksheets["VENTAS"];

            for (int i = 2; i < 10000; i++)
                ws.DeleteRow(9);

            ws.Cells["A1"].Value = Empresa;
            ws.Cells["A2"].Value = Sucursal;
            ws.Cells["A3"].Value = "FECHA: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm");
            ws.Cells["A6"].Value = Subtitulo;



            ws.Cells["A9"].LoadFromDataTable(dtTabla, true);
            ws.DeleteRow(9);

            //Ejemplos de como se deben manipular algunos campos
            //ws.DeleteRow(8);
            //ws.DeleteColumn(20);
            //ws.Cells["B2"].Value = dtTabla.Rows[0]["Periodo"].ToString();
            //object BaseImponibleSuma;
            //BaseImponibleSuma = dtTabla.Compute("Sum(BaseImponible)", "");
            //ws.Cells["L" + Convert.ToString(dtTabla.Rows.Count + 8)].Value = BaseImponibleSuma.ToString();
            //ws.Cells["L" + Convert.ToString(dtTabla.Rows.Count + 8)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

            ws.Cells["E:E"].Style.Numberformat.Format = null;
            ws.Cells["E:E"].Style.Numberformat.Format = "#,##0.00";

            ws.Cells["F:F"].Style.Numberformat.Format = null;
            ws.Cells["F:F"].Style.Numberformat.Format = "#,##0.00";

            ws.Cells["G:G"].Style.Numberformat.Format = null;
            ws.Cells["G:G"].Style.Numberformat.Format = "#,##0.00";

            //String Cadena = "";
            //Cadena ="A8:S8," +  "A" + Convert.ToString(dtTabla.Rows.Count + 8) + ":" + "S" + Convert.ToString(dtTabla.Rows.Count + 8);

            //using (ExcelRange rng = ws.Cells[Cadena])
            //{
            //    rng.Style.Font.Bold = true;
            //    rng.Style.Font.SetFromFont(new Font("Arial", 10));
            //    rng.AutoFitColumns();
            //}

            //if (dtTabla.Rows.Count > 0)
            //{
            //    object MontoSoles;
            //    MontoSoles = dtTabla.Compute("Sum(Soles)", "");
            //    string m = MontoSoles.ToString(); if (m.Trim() == "") m = "0";

            //    object MontoDolares;
            //    MontoDolares = dtTabla.Compute("Sum(Dolares)", "");
            //    string m2 = MontoDolares.ToString(); if (m2.Trim() == "") m2 = "0";

            //    ws.Cells["D" + Convert.ToString(dtTabla.Rows.Count + 9)].Value = "VENTA TOTAL";
            //    ws.Cells["E" + Convert.ToString(dtTabla.Rows.Count + 9)].Value = Math.Round(decimal.Parse(m), 2);
            //    ws.Cells["F" + Convert.ToString(dtTabla.Rows.Count + 9)].Value = Math.Round(decimal.Parse(m2), 2);
            //    ws.Cells["D" + Convert.ToString(dtTabla.Rows.Count + 10)].Value = "SUBTOTAL";
            //    ws.Cells["E" + Convert.ToString(dtTabla.Rows.Count + 10)].Value = Math.Round(decimal.Parse(m), 2) / decimal.Parse("1.18");
            //    ws.Cells["F" + Convert.ToString(dtTabla.Rows.Count + 10)].Value = Math.Round(decimal.Parse(m2), 2) / decimal.Parse("1.18");
            //    ws.Cells["D" + Convert.ToString(dtTabla.Rows.Count + 11)].Value = "IGV";
            //    ws.Cells["E" + Convert.ToString(dtTabla.Rows.Count + 11)].Value = Math.Round(decimal.Parse(m), 2) / decimal.Parse("1.18") * decimal.Parse("0.18");
            //    ws.Cells["F" + Convert.ToString(dtTabla.Rows.Count + 11)].Value = Math.Round(decimal.Parse(m2), 2) / decimal.Parse("1.18") * decimal.Parse("0.18");

            //    using (ExcelRange rng = ws.Cells["D" + Convert.ToString(dtTabla.Rows.Count + 9) + ":F" + Convert.ToString(dtTabla.Rows.Count + 11)])
            //    {
            //        rng.Style.Font.Bold = true;
            //        //rng.Style.Font.SetFromFont(new Font("Arial", 14));
            //        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //        rng.Style.Fill.BackgroundColor.SetColor(Color.Silver);
            //    }

            //}


            pck.Save();

            //System.Diagnostics.Process.Start(Server.MapPath("RegistroVentas.xlsx"));
            MemoryStream msMemoria = null;
            //msMemoria = (MemoryStream)pck.ExportToStream(ExportFormatType.PortableDocFormat);

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Ventas.xlsx");
            Response.TransmitFile(Server.MapPath("Ventas.xlsx"));
            Response.End();
        }

        public void P_ReporteVentasDetallado()
        {
            DocumentoVentaCabCE objEntidadVenta = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacionVenta = new DocumentoVentaCabCN();
            objEntidadVenta.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
            objEntidadVenta.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
            objEntidadVenta.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);
            objEntidadVenta.SerieDoc = Convert.ToString(Request.QueryString["SerieDoc"]);
            objEntidadVenta.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidadVenta.CodCliente = Convert.ToInt32(Request.QueryString["CodCliente"]);
            objEntidadVenta.CodEmpresa = Convert.ToInt32(Request.QueryString["CodEmpresa"]);
            String Tipo = Convert.ToString(Request.QueryString["Tipo"]);
            DataTable dtTabla = null;
            String fmtoExcel = "";
            String Empresa = "";
            String Sucursal = "";
            String Subtitulo = "Desde " + Request.QueryString["Desde"].ToString() + " Hasta " + Request.QueryString["Hasta"].ToString();

            dtTabla = objOperacionVenta.F_DOCUMENTOVENTACAB_REPORTE_VENTA_TIPODOCUMENTO_DETALLADO(objEntidadVenta);
            dtTabla.TableName = "VentasReporte";
            fmtoExcel = "VentasDetallado.xlsx";
            if (dtTabla.Rows.Count > 0)
            {
                Empresa = dtTabla.Rows[0][19].ToString();
                Sucursal = "SUCURSAL " + dtTabla.Rows[0][18].ToString();
            }

            FileInfo newFile = new FileInfo(Server.MapPath(fmtoExcel));
            ExcelPackage pck = new ExcelPackage(newFile);
            var ws = pck.Workbook.Worksheets["VENTAS"];

            for (int i = 2; i < 10000; i++)
                ws.DeleteRow(9);

            ws.Cells["A1"].Value = Empresa;
            ws.Cells["A2"].Value = Sucursal;
            ws.Cells["A3"].Value = "FECHA: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm");
            ws.Cells["E6"].Value = Subtitulo;

            if (dtTabla.Rows.Count > 0)
            {

                //VARIABLES DE TRABAJO
                int pos = 10;
                string Clientev = "";
                decimal ImpSOL = 0; decimal ImpSOLC = 0;
                decimal ImpUSD = 0; decimal ImpUSDC = 0;


                foreach (DataRow R in dtTabla.Rows)
                {
                    //Obtengo el cliente a tratar
                    string Cliente = Convert.ToString(R["Cliente"]);


                    //SUBTOTAL POR CLIENTE
                    if (Cliente != Clientev & Clientev != "")
                    {
                        //asigna campos
                        ws.Cells["F" + pos.ToString()].Value = "TOTAL " + Cliente;
                        ws.Cells["J" + pos.ToString()].Value = ImpSOLC;
                        ws.Cells["K" + pos.ToString()].Value = ImpUSDC;
                        //aplica estilos
                        using (ExcelRange rng = ws.Cells["F" + pos.ToString() + ":K" + pos.ToString()])
                        {
                            rng.Style.Font.Bold = true;
                            //rng.Style.Font.SetFromFont(new Font("Arial", 14));
                            rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rng.Style.Fill.BackgroundColor.SetColor(Color.Silver);
                        }

                        ImpSOLC = 0; ImpUSDC = 0; //limpia totales por cliente
                        pos++; pos++; //da espacios
                    }

                    //NUEVO CLIENTE
                    if (Cliente != Clientev)
                    {
                        //escribo cliente en el excel
                        ws.Cells["A" + pos.ToString()].Value = Cliente;
                        using (ExcelRange rng = ws.Cells["A" + pos.ToString() + ":D" + pos.ToString()])
                        {
                            rng.Style.Font.Bold = true;
                            //rng.Style.Font.SetFromFont(new Font("Arial", 14));
                            rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rng.Style.Fill.BackgroundColor.SetColor(Color.Silver);
                        }
                        ImpSOLC = 0; ImpUSDC = 0; //limpia totales por cliente
                        //asigna el nuevo cliente
                        Clientev = Cliente;
                        pos++;
                    }

                    ImpSOL = Convert.ToDecimal(R["ImporteSoles"]); ImpSOLC += ImpSOL;
                    ImpUSD = Convert.ToDecimal(R["ImporteDolares"]); ImpUSDC += ImpUSD;

                    ws.Cells["A" + pos.ToString()].Value = Convert.ToString(R["CodEmpresa"]); //E
                    ws.Cells["B" + pos.ToString()].Value = Convert.ToDateTime(R["Emision"]); //Emision
                    ws.Cells["C" + pos.ToString()].Value = Convert.ToString(R["Numero"]); //Numero
                    ws.Cells["D" + pos.ToString()].Value = Convert.ToString(R["Codigo"]); //Codigo
                    ws.Cells["E" + pos.ToString()].Value = Convert.ToString(R["Producto"]); //Producto
                    ws.Cells["F" + pos.ToString()].Value = Convert.ToString(R["Marca"]); //Marca
                    ws.Cells["G" + pos.ToString()].Value = Convert.ToDecimal(R["Cantidad"]); //Cantidad
                    ws.Cells["H" + pos.ToString()].Value = Convert.ToDecimal(R["PUSINSoles"]); //PU S
                    ws.Cells["I" + pos.ToString()].Value = Convert.ToDecimal(R["PUSINDolares"]); //PU $
                    ws.Cells["J" + pos.ToString()].Value = ImpSOL;  //IMP S
                    ws.Cells["K" + pos.ToString()].Value = ImpUSD; //IMP $     
                    pos++;

                }

                //TOTALES DEL ULTIMO CLIENTE
                //asigna campos
                ws.Cells["F" + pos.ToString()].Value = "TOTAL " + Clientev;
                ws.Cells["J" + pos.ToString()].Value = ImpSOL;
                ws.Cells["K" + pos.ToString()].Value = ImpUSD;
                //aplica estilos
                using (ExcelRange rng = ws.Cells["F" + pos.ToString() + ":K" + pos.ToString()])
                {
                    rng.Style.Font.Bold = true;
                    //rng.Style.Font.SetFromFont(new Font("Arial", 14));
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.Silver);
                }

                ImpUSDC = 0; ImpUSDC = 0; //limpia totales por cliente
                pos++; pos++; //da espacios

                //TOTALES FINALES
                object MontoSoles;
                MontoSoles = dtTabla.Compute("Sum(ImporteSoles)", "");
                string m = MontoSoles.ToString(); if (m.Trim() == "") m = "0";

                object MontoDolares;
                MontoDolares = dtTabla.Compute("Sum(ImporteDolares)", "");
                string m2 = MontoDolares.ToString(); if (m2.Trim() == "") m2 = "0";
                int posi = pos;
                ws.Cells["F" + Convert.ToString(pos)].Value = "VENTA TOTAL";
                ws.Cells["J" + Convert.ToString(pos)].Value = Math.Round(decimal.Parse(m), 2) * decimal.Parse("1.18");
                ws.Cells["K" + Convert.ToString(pos)].Value = Math.Round(decimal.Parse(m2), 2) * decimal.Parse("1.18");
                pos++;
                ws.Cells["F" + Convert.ToString(pos)].Value = "SUBTOTAL";
                ws.Cells["J" + Convert.ToString(pos)].Value = Math.Round(decimal.Parse(m), 2);
                ws.Cells["K" + Convert.ToString(pos)].Value = Math.Round(decimal.Parse(m2), 2);
                pos++; int posf = pos;
                ws.Cells["F" + Convert.ToString(pos)].Value = "IGV";
                ws.Cells["J" + Convert.ToString(pos)].Value = Math.Round(decimal.Parse(m), 2) * decimal.Parse("0.18");
                ws.Cells["K" + Convert.ToString(pos)].Value = Math.Round(decimal.Parse(m2), 2) * decimal.Parse("0.18");


                using (ExcelRange rng = ws.Cells["F" + posi.ToString() + ":K" + posf.ToString()])
                {
                    rng.Style.Font.Bold = true;
                    //rng.Style.Font.SetFromFont(new Font("Arial", 14));
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.Silver);
                }

            }

            pck.Save();

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=VentasDetallado.xlsx");
            Response.TransmitFile(Server.MapPath("VentasDetallado.xlsx"));
            Response.End();
        }

        public void P_ReporteCompras()
        {
            NotaIngresoSalidaCabCE objEntidadCompra = new NotaIngresoSalidaCabCE();
            NotaIngresoSalidaCabCN objOperacionCompra = new NotaIngresoSalidaCabCN();
            objEntidadCompra.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
            objEntidadCompra.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
            objEntidadCompra.CodCtaCte = Convert.ToInt32(Request.QueryString["CodCtaCte"]);
            objEntidadCompra.CodEmpresa = Convert.ToInt32(Request.QueryString["CodEmpresa"]);
            String Tipo = Convert.ToString(Request.QueryString["Tipo"]);
            DataTable dtTabla = null;
            String fmtoExcel = "";
            String Empresa = "";
            String Sucursal = "";
            String Subtitulo = "Desde " + Request.QueryString["Desde"].ToString() + " Hasta " + Request.QueryString["Hasta"].ToString();

            dtTabla = objOperacionCompra.F_NotaIngresoSalidaCab_Compras(objEntidadCompra);
            dtTabla.TableName = "ComprasReporte";
            fmtoExcel = "Compras.xlsx";

            if (dtTabla.Rows.Count > 0)
            {
                Empresa = dtTabla.Rows[0][8].ToString();
                Sucursal = "SUCURSAL " + dtTabla.Rows[0][11].ToString();
                try
                {
                    dtTabla.Columns.RemoveAt(12);
                }
                catch (Exception)
                {
                }
                try
                {
                    dtTabla.Columns.RemoveAt(11); dtTabla.Columns.RemoveAt(10);
                }
                catch (Exception)
                {
                }
                try
                {
                    dtTabla.Columns.RemoveAt(9); dtTabla.Columns.RemoveAt(8);
                }
                catch (Exception)
                {
                }
            }

            FileInfo newFile = new FileInfo(Server.MapPath(fmtoExcel));
            ExcelPackage pck = new ExcelPackage(newFile);
            var ws = pck.Workbook.Worksheets["COMPRAS"];

            for (int i = 2; i < 10000; i++)
                ws.DeleteRow(9);

            ws.Cells["A1"].Value = Empresa;
            ws.Cells["A2"].Value = Sucursal;
            ws.Cells["A3"].Value = "FECHA: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm");
            ws.Cells["D6"].Value = Subtitulo;
            ws.Cells["A9"].LoadFromDataTable(dtTabla, true);
            ws.DeleteRow(9);

            if (dtTabla.Rows.Count > 0)
            {
                object MontoSoles;
                MontoSoles = dtTabla.Compute("Sum(Soles)", "");
                string m = MontoSoles.ToString(); if (m.Trim() == "") m = "0";

                object MontoDolares;
                MontoDolares = dtTabla.Compute("Sum(Dolares)", "");
                string m2 = MontoDolares.ToString(); if (m2.Trim() == "") m2 = "0";

                ws.Cells["D" + Convert.ToString(dtTabla.Rows.Count + 9)].Value = "COMPRA TOTAL";
                ws.Cells["E" + Convert.ToString(dtTabla.Rows.Count + 9)].Value = Math.Round(decimal.Parse(m), 2);
                ws.Cells["F" + Convert.ToString(dtTabla.Rows.Count + 9)].Value = Math.Round(decimal.Parse(m2), 2);
                ws.Cells["D" + Convert.ToString(dtTabla.Rows.Count + 10)].Value = "SUBTOTAL";
                ws.Cells["E" + Convert.ToString(dtTabla.Rows.Count + 10)].Value = Math.Round(decimal.Parse(m), 2) / decimal.Parse("1.18");
                ws.Cells["F" + Convert.ToString(dtTabla.Rows.Count + 10)].Value = Math.Round(decimal.Parse(m2), 2) / decimal.Parse("1.18");
                ws.Cells["D" + Convert.ToString(dtTabla.Rows.Count + 11)].Value = "IGV";
                ws.Cells["E" + Convert.ToString(dtTabla.Rows.Count + 11)].Value = Math.Round(decimal.Parse(m), 2) / decimal.Parse("1.18") * decimal.Parse("0.18");
                ws.Cells["F" + Convert.ToString(dtTabla.Rows.Count + 11)].Value = Math.Round(decimal.Parse(m2), 2) / decimal.Parse("1.18") * decimal.Parse("0.18");

                using (ExcelRange rng = ws.Cells["D" + Convert.ToString(dtTabla.Rows.Count + 9) + ":F" + Convert.ToString(dtTabla.Rows.Count + 11)])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.Silver);
                }

            }
            pck.Save();

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Compras.xlsx");
            Response.TransmitFile(Server.MapPath("Compras.xlsx"));
            Response.End();
        }

        public void P_ReporteComprasDetallado()
        {
            NotaIngresoSalidaCabCE objEntidadCompra = new NotaIngresoSalidaCabCE();
            NotaIngresoSalidaCabCN objOperacionCompra = new NotaIngresoSalidaCabCN();
            objEntidadCompra.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
            objEntidadCompra.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
            objEntidadCompra.CodCtaCte = Convert.ToInt32(Request.QueryString["CodCtaCte"]);
            objEntidadCompra.CodEmpresa = Convert.ToInt32(Request.QueryString["CodEmpresa"]);
            String Tipo = Convert.ToString(Request.QueryString["Tipo"]);
            DataTable dtTabla = null;
            String fmtoExcel = "";
            String Empresa = "";
            String Sucursal = "";
            String Subtitulo = "Desde " + Request.QueryString["Desde"].ToString() + " Hasta " + Request.QueryString["Hasta"].ToString();

            dtTabla = objOperacionCompra.F_NotaIngresoSalidaCab_Compras_Detallado(objEntidadCompra);
            dtTabla.TableName = "VentasReporte";
            fmtoExcel = "ComprasDetallado.xlsx";

            if (dtTabla.Rows.Count > 0)
            {
                Empresa = dtTabla.Rows[0][17].ToString();
                Sucursal = "SUCURSAL " + dtTabla.Rows[0][20].ToString();
            }

            FileInfo newFile = new FileInfo(Server.MapPath(fmtoExcel));
            ExcelPackage pck = new ExcelPackage(newFile);
            var ws = pck.Workbook.Worksheets["COMPRAS"];

            for (int i = 2; i < 10000; i++)
                ws.DeleteRow(9);

            ws.Cells["A1"].Value = Empresa;
            ws.Cells["A2"].Value = Sucursal;
            ws.Cells["A3"].Value = "FECHA: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm");
            ws.Cells["E6"].Value = Subtitulo;

            if (dtTabla.Rows.Count > 0)
            {

                //VARIABLES DE TRABAJO
                int pos = 10;
                string Clientev = "";
                decimal ImpSOL = 0; decimal ImpSOLC = 0;
                decimal ImpUSD = 0; decimal ImpUSDC = 0;


                foreach (DataRow R in dtTabla.Rows)
                {
                    //Obtengo el cliente a tratar
                    string Cliente = Convert.ToString(R["Cliente"]);


                    //SUBTOTAL POR CLIENTE
                    if (Cliente != Clientev & Clientev != "")
                    {
                        //asigna campos
                        ws.Cells["F" + pos.ToString()].Value = "TOTAL " + Cliente;
                        ws.Cells["J" + pos.ToString()].Value = ImpSOLC;
                        ws.Cells["K" + pos.ToString()].Value = ImpUSDC;
                        //aplica estilos
                        using (ExcelRange rng = ws.Cells["F" + pos.ToString() + ":K" + pos.ToString()])
                        {
                            rng.Style.Font.Bold = true;
                            //rng.Style.Font.SetFromFont(new Font("Arial", 14));
                            rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rng.Style.Fill.BackgroundColor.SetColor(Color.Silver);
                        }

                        ImpSOLC = 0; ImpUSDC = 0; //limpia totales por cliente
                        pos++; pos++; //da espacios
                    }

                    //NUEVO CLIENTE
                    if (Cliente != Clientev)
                    {
                        //escribo cliente en el excel
                        ws.Cells["A" + pos.ToString()].Value = Cliente;
                        using (ExcelRange rng = ws.Cells["A" + pos.ToString() + ":D" + pos.ToString()])
                        {
                            rng.Style.Font.Bold = true;
                            //rng.Style.Font.SetFromFont(new Font("Arial", 14));
                            rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rng.Style.Fill.BackgroundColor.SetColor(Color.Silver);
                        }
                        ImpSOLC = 0; ImpUSDC = 0; //limpia totales por cliente
                        //asigna el nuevo cliente
                        Clientev = Cliente;
                        pos++;
                    }

                    ImpSOL = Convert.ToDecimal(R["ImporteSoles"]); ImpSOLC += ImpSOL;
                    ImpUSD = Convert.ToDecimal(R["ImporteDolares"]); ImpUSDC += ImpUSD;

                    ws.Cells["A" + pos.ToString()].Value = Convert.ToString(R["CodEmpresa"]); //E
                    ws.Cells["B" + pos.ToString()].Value = Convert.ToDateTime(R["Emision"]); //Emision
                    ws.Cells["C" + pos.ToString()].Value = Convert.ToString(R["Numero"]); //Numero
                    ws.Cells["D" + pos.ToString()].Value = Convert.ToString(R["Codigo"]); //Codigo
                    ws.Cells["E" + pos.ToString()].Value = Convert.ToString(R["Producto"]); //Producto
                    ws.Cells["F" + pos.ToString()].Value = Convert.ToString(R["Marca"]); //Marca
                    ws.Cells["G" + pos.ToString()].Value = Convert.ToDecimal(R["Cantidad"]); //Cantidad
                    ws.Cells["H" + pos.ToString()].Value = Convert.ToDecimal(R["PUSINSoles"]); //PU S
                    ws.Cells["I" + pos.ToString()].Value = Convert.ToDecimal(R["PUSINDolares"]); //PU $
                    ws.Cells["J" + pos.ToString()].Value = ImpSOL;  //IMP S
                    ws.Cells["K" + pos.ToString()].Value = ImpUSD; //IMP $     
                    pos++;

                }

                //TOTALES DEL ULTIMO CLIENTE
                //asigna campos
                ws.Cells["F" + pos.ToString()].Value = "TOTAL " + Clientev;
                ws.Cells["J" + pos.ToString()].Value = ImpSOL;
                ws.Cells["K" + pos.ToString()].Value = ImpUSD;
                //aplica estilos
                using (ExcelRange rng = ws.Cells["F" + pos.ToString() + ":K" + pos.ToString()])
                {
                    rng.Style.Font.Bold = true;
                    //rng.Style.Font.SetFromFont(new Font("Arial", 14));
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.Silver);
                }

                ImpUSDC = 0; ImpUSDC = 0; //limpia totales por cliente
                pos++; pos++; //da espacios

                //TOTALES FINALES
                object MontoSoles;
                MontoSoles = dtTabla.Compute("Sum(ImporteSoles)", "");
                string m = MontoSoles.ToString(); if (m.Trim() == "") m = "0";

                object MontoDolares;
                MontoDolares = dtTabla.Compute("Sum(ImporteDolares)", "");
                string m2 = MontoDolares.ToString(); if (m2.Trim() == "") m2 = "0";
                int posi = pos;
                ws.Cells["F" + Convert.ToString(pos)].Value = "COMPRA TOTAL";
                ws.Cells["J" + Convert.ToString(pos)].Value = Math.Round(decimal.Parse(m), 2) * decimal.Parse("1.18");
                ws.Cells["K" + Convert.ToString(pos)].Value = Math.Round(decimal.Parse(m2), 2) * decimal.Parse("1.18");
                pos++;
                ws.Cells["F" + Convert.ToString(pos)].Value = "SUBTOTAL";
                ws.Cells["J" + Convert.ToString(pos)].Value = Math.Round(decimal.Parse(m), 2);
                ws.Cells["K" + Convert.ToString(pos)].Value = Math.Round(decimal.Parse(m2), 2);
                pos++; int posf = pos;
                ws.Cells["F" + Convert.ToString(pos)].Value = "IGV";
                ws.Cells["J" + Convert.ToString(pos)].Value = Math.Round(decimal.Parse(m), 2) * decimal.Parse("0.18");
                ws.Cells["K" + Convert.ToString(pos)].Value = Math.Round(decimal.Parse(m2), 2) * decimal.Parse("0.18");

                using (ExcelRange rng = ws.Cells["F" + posi.ToString() + ":K" + posf.ToString()])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.Silver);
                }
            }

            pck.Save();

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=ComprasDetallado.xlsx");
            Response.TransmitFile(Server.MapPath("ComprasDetallado.xlsx"));
            Response.End();
        }

        public void ExportarExcelDetalle()
        {
            NotaIngresoSalidaDetCN objOperacion = new NotaIngresoSalidaDetCN();
            NotaIngresoSalidaDetCE objEntidad = new NotaIngresoSalidaDetCE();
            objEntidad.CodMovimiento = Convert.ToInt32(Request.QueryString["Codigo"]); ;
            DataTable ds = objOperacion.F_NotaIngresoSalidaDet_Select_Importaciones(objEntidad);

            if (ds.Rows.Count > 0)
            {           
                FileInfo newFile = new FileInfo(Server.MapPath("Xls_Importaciones.xlsx"));

                ExcelPackage pck = new ExcelPackage(newFile);
                var ws = pck.Workbook.Worksheets["IMPORTACION"];

                for (int i = 2; i < 50000; i++)
                    ws.DeleteRow(2);

                ws.Cells["A2"].LoadFromDataTable(ds, true);
                ws.DeleteRow(2);
                        
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=Xls_Importaciones.xlsx");

                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    pck.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }

        public void ExportarExcelDetalleREEIM()
        {
            NotaIngresoSalidaDetCN objOperacion = new NotaIngresoSalidaDetCN();
            NotaIngresoSalidaDetCE objEntidad = new NotaIngresoSalidaDetCE();
            objEntidad.CodMovimiento = Convert.ToInt32(Request.QueryString["Codigo"]); ;
            DataTable ds = objOperacion.F_NotaIngresoSalidaDet_Select_Importaciones(objEntidad);

            if (ds.Rows.Count > 0)
            {
                FileInfo newFile = new FileInfo(Server.MapPath("Xls_Importaciones_REEIM.xlsx"));

                ExcelPackage pck = new ExcelPackage(newFile);
                var ws = pck.Workbook.Worksheets["IMPORTACION"];

                for (int i = 2; i < 50000; i++)
                    ws.DeleteRow(2);

                ws.Cells["A2"].LoadFromDataTable(ds, true);
                ws.DeleteRow(2);

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=Xls_Importaciones_REEIM.xlsx");

                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    pck.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }

        public void P_RankingVenta()
        {
            DocumentoVentaCabCE objEntidadVenta = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacionVenta = new DocumentoVentaCabCN();
            objEntidadVenta.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
            objEntidadVenta.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
            objEntidadVenta.Ranking = Convert.ToInt32(Request.QueryString["Ranking"]);
            String Tipo = Convert.ToString(Request.QueryString["Tipo"]);
            DataTable dtTabla = null;
            String fmtoExcel = "";
            String Empresa = "";
            String Sucursal = "";
            String Subtitulo = "Desde " + Request.QueryString["Desde"].ToString() + " Hasta " + Request.QueryString["Hasta"].ToString();

            dtTabla = objOperacionVenta.F_DOCUMENTOVENTACAB_RANKINGVENTAS_REPORTE(objEntidadVenta);
            dtTabla.TableName = "RankingVentaReporte";
            fmtoExcel = "RankingVenta.xlsx";
            if (dtTabla.Rows.Count > 0)
            {
                Empresa = dtTabla.Rows[0][4].ToString();
                Sucursal = "SUCURSAL " + dtTabla.Rows[0][5].ToString();
                dtTabla.Columns.RemoveAt(5); dtTabla.Columns.RemoveAt(4);
            }

            FileInfo newFile = new FileInfo(Server.MapPath(fmtoExcel));
            ExcelPackage pck = new ExcelPackage(newFile);
            var ws = pck.Workbook.Worksheets["VENTAS"];

            for (int i = 2; i < 10000; i++)
                ws.DeleteRow(9);

            ws.Cells["A1"].Value = Empresa;
            ws.Cells["A2"].Value = Sucursal;
            ws.Cells["A3"].Value = "FECHA: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm");
            ws.Cells["A6"].Value = Subtitulo;

            ws.Cells["A9"].LoadFromDataTable(dtTabla, true);
            ws.DeleteRow(9);

            ws.Cells["D:D"].Style.Numberformat.Format = null;
            ws.Cells["D:D"].Style.Numberformat.Format = "#,##0.00";

            pck.Save();
            pck.Dispose();

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=RankingVenta.xlsx");
            Response.TransmitFile(Server.MapPath("RankingVenta.xlsx"));
            Response.End();
        }

        public void P_ReporteVentasPorPeriodoPorFamilia()
        {


            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            //filtros
            objEntidad.DesdeInt = Convert.ToInt32(Convert.ToDateTime(Request["Desde"]).ToString("yyyyMMdd"));
            objEntidad.HastaInt = Convert.ToInt32(Convert.ToDateTime(Request["Hasta"]).ToString("yyyyMMdd"));
            objEntidad.CodMoneda = Convert.ToInt32(Request["CodMoneda"]);
            if (Convert.ToString(Request["CodAlmacen"]) == "T")
                objEntidad.CodAlmacen = 0;
            else
                objEntidad.CodAlmacen = Convert.ToInt32(Request["CodAlmacen"]);
            objEntidad.TipoReporte = Convert.ToInt32(Request["TipoReporte"]);


            //filtros de combos multiples
            //FAMILIAS-----------------------------------------
            objEntidad.xmlFamilias = "";
            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Request["Familias"]);
            foreach (dynamic item in jArr2)
            {
                objEntidad.xmlFamilias = objEntidad.xmlFamilias + "<D ";
                objEntidad.xmlFamilias = objEntidad.xmlFamilias + " IdFamilia = '" + item.IdFamilia + "'";
                objEntidad.xmlFamilias = objEntidad.xmlFamilias + " />";
            }
            objEntidad.xmlFamilias = "<R><XmlLC> " + objEntidad.xmlFamilias + "</XmlLC></R>";

            //filtros de combos multiples
            //LINEAS-----------------------------------------
            objEntidad.xmlLineas = "";
            jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Request["Lineas"]);
            foreach (dynamic item in jArr2)
            {
                objEntidad.xmlLineas = objEntidad.xmlLineas + "<D ";
                objEntidad.xmlLineas = objEntidad.xmlLineas + " IdLinea = '" + item.IdLinea + "'";
                objEntidad.xmlLineas = objEntidad.xmlLineas + " />";
            }
            objEntidad.xmlLineas = "<R><XmlLC> " + objEntidad.xmlLineas + "</XmlLC></R>";

            //MARCAS-----------------------------------------
            objEntidad.xmlMarcas = "";
            dynamic jArr3 = Newtonsoft.Json.JsonConvert.DeserializeObject(Request["Marcas"]);
            foreach (dynamic item in jArr3)
            {
                objEntidad.xmlMarcas = objEntidad.xmlMarcas + "<D ";
                objEntidad.xmlMarcas = objEntidad.xmlMarcas + " Marca = '" + item.Marca + "'";
                objEntidad.xmlMarcas = objEntidad.xmlMarcas + " />";
            }
            objEntidad.xmlMarcas = "<R><XmlLC> " + objEntidad.xmlMarcas + "</XmlLC></R>";

            DataTable dtTabla = objOperacion.F_DocumentoVentaCab_VentasArticulos_Periodo(objEntidad);

            if (dtTabla.Rows.Count > 0)
            {
                P_CambioNombreColumnasPeriodos(ref dtTabla);

                FileInfo newFile = new FileInfo(Server.MapPath("Xls_Excel.xlsx"));

                ExcelPackage pck = new ExcelPackage(newFile);
                var ws = pck.Workbook.Worksheets["Hoja1"];

                for (int i = 1; i < 100000; i++)
                    ws.DeleteRow(1);

                for (int i = 1; i < 50; i++)
                    ws.DeleteColumn(1);

                //Cabecera
                DateTime fi = Convert.ToDateTime(Request["Desde"].ToString()); DateTime ff = Convert.ToDateTime(Request["Hasta"].ToString());
                string PeriodoDesde = fi.ToString("dd/MM/yyyy");
                string PeriodoHasta = ff.ToString("dd/MM/yyyy");
                string Familias = dtTabla.Rows[0]["Familias"].ToString(); if (Familias == "") Familias = "TODAS";
                string Marcas = dtTabla.Rows[0]["Marcas"].ToString(); if (Marcas == "") Marcas = "TODAS";
                string Almacen = "TODOS";
                if (objEntidad.CodAlmacen > 0)
                    Almacen = ((new TCAlmacenCN()).F_TCAlmacen_Actual(new TCAlmacenCE() { CodEmpresa = 3, CodAlmacen = Convert.ToInt32(objEntidad.CodAlmacen) })).Rows[0]["DscAlmacen"].ToString();

                ws.Cells["A1"].Value = "REPORTE DE UNIDADES VENDIDAS POR PERIODO"; ws.Row(1).Style.Font.Size = 18; ws.Row(1).Style.Font.Bold = true;
                ws.Cells["A2"].Value = "PERIODO: DEL " + PeriodoDesde + " AL " + PeriodoHasta; ws.Row(2).Style.Font.Bold = true;
                ws.Cells["A3"].Value = "FAMILIAS: " + Familias; ws.Row(3).Style.Font.Bold = true;
                ws.Cells["A4"].Value = "MARCAS: " + Marcas; ws.Row(4).Style.Font.Bold = true;
                ws.Cells["A5"].Value = "ALMACEN: " + Almacen; ws.Row(5).Style.Font.Bold = true;

                dtTabla.Columns.RemoveAt(0);
                dtTabla.Columns.RemoveAt(0);

                string FamBuff = ""; int co = 7;
                foreach (DataRow r in dtTabla.Rows)
                {
                    if (r["Familia"].ToString() != FamBuff)
                    {
                        FamBuff = r["Familia"].ToString();

                        //copia de rows necesarias
                        DataTable dt = dtTabla.Clone();
                        dtTabla.Select("Familia = '" + FamBuff + "'").CopyToDataTable(dt, LoadOption.OverwriteChanges);

                        //estilo de cabecera familia
                        ws.Cells["A" + co].Value = "FAMILIA: " + FamBuff;
                        ws.Row(co).Style.Font.Bold = true; ws.Row(co).Style.Font.Size = 16;
                        //estilo de cabecera titulos
                        co++; ws.Row(co).Style.Font.Bold = true;
                        ws.Row(co).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        //carga de productos
                        dt.Columns.RemoveAt(0); ws.Cells["A" + co].LoadFromDataTable(dt, true);
                        co = co + dt.Rows.Count + 1;
                    }
                }

                ws.Column(1).Width = 15;
                ws.Column(2).Width = 40;
                ws.Column(3).Width = 15;


                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=Xls_Excel.xlsx");

                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    pck.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }

        public void P_ReporteVentasPorPeriodoCompleto()
        {
            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            //filtros
            objEntidad.DesdeInt = Convert.ToInt32(Convert.ToDateTime(Request["Desde"]).ToString("yyyyMMdd"));
            objEntidad.HastaInt = Convert.ToInt32(Convert.ToDateTime(Request["Hasta"]).ToString("yyyyMMdd"));
            objEntidad.CodMoneda = Convert.ToInt32(Request["CodMoneda"]);
            objEntidad.Descripcion = Convert.ToString(Request["Descripcion"]);
            if (Convert.ToString(Request["CodAlmacen"]) == "T")
                objEntidad.CodAlmacen = 0;
            else
                objEntidad.CodAlmacen = Convert.ToInt32(Request["CodAlmacen"]);
            objEntidad.TipoReporte = Convert.ToInt32(Request["TipoReporte"]);

            //filtros de combos multiples
            objEntidad.xmlFamilias = "";
            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Request["Familias"]);
            foreach (dynamic item in jArr2)
            {
                objEntidad.xmlFamilias = objEntidad.xmlFamilias + "<D ";
                objEntidad.xmlFamilias = objEntidad.xmlFamilias + " IdFamilia = '" + item.IdFamilia + "'";
                objEntidad.xmlFamilias = objEntidad.xmlFamilias + " />";
            }
            objEntidad.xmlFamilias = "<R><XmlLC> " + objEntidad.xmlFamilias + "</XmlLC></R>";


            //filtros de combos multiples
            //LINEAS-----------------------------------------
            objEntidad.xmlLineas = "";
            jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Request["Lineas"]);
            foreach (dynamic item in jArr2)
            {
                objEntidad.xmlLineas = objEntidad.xmlLineas + "<D ";
                objEntidad.xmlLineas = objEntidad.xmlLineas + " IdLinea = '" + item.IdLinea + "'";
                objEntidad.xmlLineas = objEntidad.xmlLineas + " />";
            }
            objEntidad.xmlLineas = "<R><XmlLC> " + objEntidad.xmlLineas + "</XmlLC></R>";


            objEntidad.xmlMarcas = "";
            dynamic jArr3 = Newtonsoft.Json.JsonConvert.DeserializeObject(Request["Marcas"]);
            foreach (dynamic item in jArr3)
            {
                objEntidad.xmlMarcas = objEntidad.xmlMarcas + "<D ";
                objEntidad.xmlMarcas = objEntidad.xmlMarcas + " Marca = '" + item.Marca + "'";
                objEntidad.xmlMarcas = objEntidad.xmlMarcas + " />";
            }
            objEntidad.xmlMarcas = "<R><XmlLC> " + objEntidad.xmlMarcas + "</XmlLC></R>";

            DataTable dtTabla = objOperacion.F_DocumentoVentaCab_VentasArticulos_Periodo(objEntidad);

            if (dtTabla.Rows.Count > 0)
            {
                P_CambioNombreColumnasPeriodos(ref dtTabla);

                FileInfo newFile = new FileInfo(Server.MapPath("Xls_Excel.xlsx"));

                ExcelPackage pck = new ExcelPackage(newFile);
                var ws = pck.Workbook.Worksheets["Hoja1"];

                for (int i = 1; i < 100000; i++)
                    ws.DeleteRow(1);

                for (int i = 1; i < 50; i++)
                    ws.DeleteColumn(1);

                //Cabecera
                DateTime fi = Convert.ToDateTime(Request["Desde"].ToString()); DateTime ff = Convert.ToDateTime(Request["Hasta"].ToString());
                string PeriodoDesde = fi.ToString("dd/MM/yyyy");
                string PeriodoHasta = ff.ToString("dd/MM/yyyy");
                string Familias = dtTabla.Rows[0]["Familias"].ToString(); if (Familias == "") Familias = "TODAS";
                string Marcas = dtTabla.Rows[0]["Marcas"].ToString(); if (Marcas == "") Marcas = "TODAS";
                string Almacen = "TODOS";
                if (objEntidad.CodAlmacen > 0)
                    Almacen = ((new TCAlmacenCN()).F_TCAlmacen_Actual(new TCAlmacenCE() { CodEmpresa = 3, CodAlmacen = Convert.ToInt32(objEntidad.CodAlmacen) })).Rows[0]["DscAlmacen"].ToString();

                ws.Cells["A1"].Value = "REPORTE DE UNIDADES VENDIDAS POR PERIODO"; ws.Row(1).Style.Font.Size = 18; ws.Row(1).Style.Font.Bold = true;
                ws.Cells["A2"].Value = "PERIODO: DEL " + PeriodoDesde + " AL " + PeriodoHasta; ws.Row(2).Style.Font.Bold = true;
                ws.Cells["A3"].Value = "FAMILIAS: " + Familias; ws.Row(3).Style.Font.Bold = true;
                ws.Cells["A4"].Value = "MARCAS: " + Marcas; ws.Row(4).Style.Font.Bold = true;
                ws.Cells["A5"].Value = "ALMACEN: " + Almacen; ws.Row(5).Style.Font.Bold = true;

                dtTabla.Columns.RemoveAt(0);
                dtTabla.Columns.RemoveAt(0);
                dtTabla.Columns.RemoveAt(0);


                //estilo de cabecera titulos
                ws.Row(7).Style.Font.Bold = true;
                ws.Row(7).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells["A" + 8].LoadFromDataTable(dtTabla, true);

                ws.Column(1).Width = 15;
                ws.Column(2).Width = 40;
                ws.Column(3).Width = 15;


                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=Xls_Excel.xlsx");

                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    pck.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }

        public void P_ReporteNotaSalidaSinenlazar()
        {
            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            //filtros
            objEntidad.DesdeInt = Convert.ToInt32(Convert.ToDateTime(Request["Desde"]).ToString("yyyyMMdd"));
            objEntidad.HastaInt = Convert.ToInt32(Convert.ToDateTime(Request["Hasta"]).ToString("yyyyMMdd"));
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);



            DataTable dtTabla = objOperacion.F_NotaINgresoSalidaSinEnlazar(objEntidad);

            if (dtTabla.Rows.Count > 0)
            {


                FileInfo newFile = new FileInfo(Server.MapPath("Xls_NotaIngresoSinEnlazar.xlsx"));

                ExcelPackage pck = new ExcelPackage(newFile);
                var ws = pck.Workbook.Worksheets["Notaingreso"];

                for (int i = 1; i < 100000; i++)
                    ws.DeleteRow(1);

                for (int i = 1; i < 50; i++)
                    ws.DeleteColumn(1);

                //Cabecera
                DateTime fi = Convert.ToDateTime(Request["Desde"].ToString()); DateTime ff = Convert.ToDateTime(Request["Hasta"].ToString());
                string PeriodoDesde = fi.ToString("dd/MM/yyyy");
                string PeriodoHasta = ff.ToString("dd/MM/yyyy");
                string Almacen = "TODOS";
                if (objEntidad.CodAlmacen > 0)
                    Almacen = ((new TCAlmacenCN()).F_TCAlmacen_Actual(new TCAlmacenCE() { CodEmpresa = 3, CodAlmacen = Convert.ToInt32(objEntidad.CodAlmacen) })).Rows[0]["DscAlmacen"].ToString();

                ws.Cells["A1"].Value = "REPORTE DE NOTA INGRESO SIN ENLAZAR"; ws.Row(1).Style.Font.Size = 18; ws.Row(1).Style.Font.Bold = true;
                ws.Cells["A2"].Value = "PERIODO: DEL " + PeriodoDesde + " AL " + PeriodoHasta; ws.Row(2).Style.Font.Bold = true;
                ws.Cells["A3"].Value = "ALMACEN: " + Almacen; ws.Row(3).Style.Font.Bold = true;

                ws.Cells["A" + 4].LoadFromDataTable(dtTabla, true);

                ws.Column(1).Width = 15;
                ws.Column(2).Width = 40;
                ws.Column(3).Width = 15;


                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=Xls_Excel.xlsx");

                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    pck.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }

        private void P_CambioNombreColumnasPeriodos(ref DataTable dtTabla)
        {
            //renombro las tablas
            foreach (DataColumn c in dtTabla.Columns)
            {
                try
                {
                    if (Convert.ToInt32(c.ColumnName.Substring(0, 4).ToString()) > 1900)
                    {
                        string año = c.ColumnName.Substring(2, 2).ToString();
                        string mes = c.ColumnName.Substring(4, 2).ToString();

                        switch (mes)
                        {
                            case "01": mes = "Ene"; break;
                            case "02": mes = "Feb"; break;
                            case "03": mes = "Mar"; break;
                            case "04": mes = "Abr"; break;
                            case "05": mes = "May"; break;
                            case "06": mes = "Jun"; break;
                            case "07": mes = "Jul"; break;
                            case "08": mes = "Ago"; break;
                            case "09": mes = "sep"; break;
                            case "10": mes = "Oct"; break;
                            case "11": mes = "Nov"; break;
                            case "12": mes = "Dic"; break;
                        }

                        string añomes = mes + "-" + año;
                        c.ColumnName = añomes;
                    }
                }
                catch (Exception ex)
                { }
            }

        }

        public void P_PROFORMACAB_LISTAR()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 500000; i++)
                ws.DeleteRow(1);

            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            objEntidad.SerieDoc = Convert.ToString(Request["Filtro_Serie"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodEstado = Convert.ToInt32(Request["CodEstado"]);
            objEntidad.CodVendedor = Convert.ToInt32(Request["CodEmpleado"]);
            objEntidad.Desde = Convert.ToDateTime(Request["Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(Request["Hasta"]);
            objEntidad.NumeroDoc = Convert.ToString(Request["NumeroDoc"]);
            objEntidad.CodCliente = Convert.ToInt32(Request["CodCtaCte"]);
      
            DataTable dtTabla = null;

            dtTabla = objOperacion.F_PROFORMACAB_LISTAR(objEntidad);
    dtTabla.Columns.RemoveAt(15); dtTabla.Columns.RemoveAt(14);
            dtTabla.Columns.RemoveAt(13); dtTabla.Columns.RemoveAt(12);
            dtTabla.Columns.RemoveAt(11);
            ws.Cells["A1"].LoadFromDataTable(dtTabla, true);

      
            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_Ventas_VentasNetas()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 500000; i++)
                ws.DeleteRow(2);

            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            objEntidad.CodAlmacen = Convert.ToInt32(Request["CodAlmacen"]);
            objEntidad.Desde = Convert.ToDateTime(Request["Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(Request["Hasta"]);

            DataTable dtTabla = null;

            dtTabla = objOperacion.F_DOCUMENTOVENTACAB_REPORTE_VENTAS(objEntidad);

            dtTabla.Columns.RemoveAt(12); dtTabla.Columns.RemoveAt(11);
            dtTabla.Columns.RemoveAt(10); 

            ws.Cells["A2"].LoadFromDataTable(dtTabla, true);

            ws.Cells["h:h"].Style.Numberformat.Format = null;
            ws.Cells["h:h"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["G:G"].Style.Numberformat.Format = null;
            ws.Cells["G:G"].Style.Numberformat.Format = "#,##0.00";

            if (dtTabla.Rows.Count > 0)
            {
                decimal Soles = (decimal)dtTabla.Compute("SUM([Soles])", null);
                decimal Dolares = (decimal)dtTabla.Compute("SUM([Dolares])", null);

                ws.Cells["G" + (dtTabla.Rows.Count + 3).ToString()].Value = Soles;
                ws.Cells["H" + (dtTabla.Rows.Count + 3).ToString()].Value = Dolares;    
            }

            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_Planilla_RegimenConstruccionCivil()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 500000; i++)
                ws.DeleteRow(8);


            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            objEntidad.CodSemanaInicio = Convert.ToInt32(Request["CodSemanaInicio"].ToString());
            objEntidad.CodSemanaFinal = Convert.ToInt32(Request["CodSemanaFin"].ToString());
            objEntidad.CodPeriodo = Convert.ToInt32(Request["CodPeriodo"].ToString());

            DataTable dtTabla = null;

            dtTabla = objOperacion.F_Planilla_Salario_Cab_REPORTE_RCC(objEntidad);

            for (int i = 1; i < dtTabla.Rows.Count; i++)
            {
                ws.InsertRow(8, i);
                if (i == 1)
                {
                    ws.Cells["A" + (i + 7) + ":" + "AY" + (i + 7)].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    ws.Cells["A" + (i + 7) + ":" + "AY" + (i + 7)].Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                    ws.Cells["A" + (i + 7) + ":" + "AY" + (i + 7)].Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                    ws.Cells["A" + (i + 7) + ":" + "AY" + (i + 7)].Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                }
                else
                {
                    ws.Cells["A" + (i + 7) + ":" + "AY" + (i + 7)].Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                    ws.Cells["A" + (i + 7) + ":" + "AY" + (i + 7)].Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                    ws.Cells["A" + (i + 7) + ":" + "AY" + (i + 7)].Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                    ws.Cells["A" + (i + 7) + ":" + "AY" + (i + 7)].Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                }

            }
            string periodo = dtTabla.Rows[0][0].ToString();
            string rango = dtTabla.Rows[0][1].ToString();
            dtTabla.Columns.RemoveAt(0);
            dtTabla.Columns.RemoveAt(0);

            ws.Cells["A8"].LoadFromDataTable(dtTabla, true);
            ws.Cells["A3"].Value = periodo;
            ws.Cells["A4"].Value = rango;

            ws.DeleteRow(8);

            ws.Cells["A" + 8 + ":" + "AY" + 8].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            ws.Cells["A" + 8 + ":" + "AY" + 8].Style.Border.Right.Style = ExcelBorderStyle.Dotted;
            ws.Cells["A" + 8 + ":" + "AY" + 8].Style.Border.Left.Style = ExcelBorderStyle.Dotted;
            ws.Cells["A" + 8 + ":" + "AY" + 8].Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;

            ws.Cells["p:p"].Style.Numberformat.Format = null;
            ws.Cells["p:p"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["q:q"].Style.Numberformat.Format = null;
            ws.Cells["q:q"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["r:r"].Style.Numberformat.Format = null;
            ws.Cells["r:r"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["s:s"].Style.Numberformat.Format = null;
            ws.Cells["s:s"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["t:t"].Style.Numberformat.Format = null;
            ws.Cells["t:t"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["u:u"].Style.Numberformat.Format = null;
            ws.Cells["u:u"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["v:v"].Style.Numberformat.Format = null;
            ws.Cells["v:v"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["w:w"].Style.Numberformat.Format = null;
            ws.Cells["w:w"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["x:x"].Style.Numberformat.Format = null;
            ws.Cells["x:x"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["y:y"].Style.Numberformat.Format = null;
            ws.Cells["y:y"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["z:z"].Style.Numberformat.Format = null;
            ws.Cells["z:z"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["aa:aa"].Style.Numberformat.Format = null;
            ws.Cells["aa:aa"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["ab:ab"].Style.Numberformat.Format = null;
            ws.Cells["ab:ab"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["ac:ac"].Style.Numberformat.Format = null;
            ws.Cells["ac:ac"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["ad:ad"].Style.Numberformat.Format = null;
            ws.Cells["ad:ad"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["ae:ae"].Style.Numberformat.Format = null;
            ws.Cells["ae:ae"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["af:af"].Style.Numberformat.Format = null;
            ws.Cells["af:af"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["ag:ag"].Style.Numberformat.Format = null;
            //ws.Cells["ag:ag"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["ah:ah"].Style.Numberformat.Format = null;
            ws.Cells["ah:ah"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["ai:ai"].Style.Numberformat.Format = null;
            ws.Cells["ai:ai"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["aj:aj"].Style.Numberformat.Format = null;
            ws.Cells["aj:aj"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["ak:ak"].Style.Numberformat.Format = null;
            ws.Cells["ak:ak"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["al:al"].Style.Numberformat.Format = null;
            ws.Cells["al:al"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["am:am"].Style.Numberformat.Format = null;
            ws.Cells["am:am"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["an:an"].Style.Numberformat.Format = null;
            ws.Cells["an:an"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["ao:ao"].Style.Numberformat.Format = null;
            ws.Cells["ao:ao"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["ap:ap"].Style.Numberformat.Format = null;
            ws.Cells["ap:ap"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["aq:aq"].Style.Numberformat.Format = null;
            ws.Cells["aq:aq"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["ar:ar"].Style.Numberformat.Format = null;
            ws.Cells["ar:ar"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["as:as"].Style.Numberformat.Format = null;
            ws.Cells["as:as"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["at:at"].Style.Numberformat.Format = null;
            ws.Cells["at:at"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["au:au"].Style.Numberformat.Format = null;
            ws.Cells["au:au"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["av:av"].Style.Numberformat.Format = null;
            ws.Cells["av:av"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["aw:aw"].Style.Numberformat.Format = null;
            ws.Cells["aw:aw"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["ax:ax"].Style.Numberformat.Format = null;
            ws.Cells["ax:ax"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["ay:ay"].Style.Numberformat.Format = null;
            ws.Cells["ay:ay"].Style.Numberformat.Format = "#,##0.00";
            if (dtTabla.Rows.Count > 0)
            {
                decimal Brutos = (decimal)dtTabla.Compute("SUM([SalarioBruto])", null);
                decimal RSemanal = (decimal)dtTabla.Compute("SUM([RemuneracionSemanal])", null);
                decimal DOM = (decimal)dtTabla.Compute("SUM([JornalDominical])", null);
                decimal DOM2 = (decimal)dtTabla.Compute("SUM([DOM])", null);
                decimal FER = (decimal)dtTabla.Compute("SUM([FER])", null);
                decimal BUC = (decimal)dtTabla.Compute("SUM([BUC])", null);
                decimal Movilidad = (decimal)dtTabla.Compute("SUM([Movilidad])", null);
                decimal Escolaridad = (decimal)dtTabla.Compute("SUM([Escolaridad])", null);
                decimal CTS = (decimal)dtTabla.Compute("SUM([CTS])", null);
                decimal Vacaciones = (decimal)dtTabla.Compute("SUM([Vacaciones])", null);
                decimal Gratificacion = (decimal)dtTabla.Compute("SUM([Gratificacion])", null);
                decimal BonoGrati = (decimal)dtTabla.Compute("SUM([BonoGrati])", null);
                decimal MensualBruto = (decimal)dtTabla.Compute("SUM([MensualBruto])", null);
                decimal MensualRemuneracion = (decimal)dtTabla.Compute("SUM([MensualRemuneracion])", null);
                decimal Aporte = (decimal)dtTabla.Compute("SUM([Aporte])", null);
                decimal Comision = (decimal)dtTabla.Compute("SUM([Comision])", null);
                decimal Prima = (decimal)dtTabla.Compute("SUM([Prima])", null);
                decimal ONP = (decimal)dtTabla.Compute("SUM([ONP])", null);
                decimal Conaf = (decimal)dtTabla.Compute("SUM([Conaf])", null);
                decimal RentaQuinta = (decimal)dtTabla.Compute("SUM([RentaQuinta])", null);
                decimal Sindicato = (decimal)dtTabla.Compute("SUM([Sindicato])", null);
                decimal Idem = (decimal)dtTabla.Compute("SUM([Idem])", null);
                decimal TotalDescuento = (decimal)dtTabla.Compute("SUM([TotalDescuento])", null);
                decimal PagoNeto = (decimal)dtTabla.Compute("SUM([PagoNeto])", null);
                decimal Essalud = (decimal)dtTabla.Compute("SUM([Essalud])", null);
                decimal EssaludSCRT = (decimal)dtTabla.Compute("SUM([EssaludSCRT])", null);
                decimal EssaludVida = (decimal)dtTabla.Compute("SUM([EssaludVida])", null);
                decimal EssaludVidaD = (decimal)dtTabla.Compute("SUM([EssaludVidaD])", null);
                decimal Segvley = (decimal)dtTabla.Compute("SUM([Segvley])", null);
                decimal TotalEmpleador = (decimal)dtTabla.Compute("SUM([TotalEmpleador])", null);
                decimal Otrafe = (decimal)dtTabla.Compute("SUM([OTRAFE])", null);
                decimal Otrafepro = (decimal)dtTabla.Compute("SUM([OTRAFEPRO])", null);
                decimal Desjudicial = (decimal)dtTabla.Compute("SUM([DESJUDICIAL])", null);
                decimal Adelanto = (decimal)dtTabla.Compute("SUM([ADELANTO])", null);
                decimal Otrosdesc = (decimal)dtTabla.Compute("SUM([OTROSDESC])", null);
                string f1 = "A" + (dtTabla.Rows.Count + 8).ToString() + ":" + "O" + (dtTabla.Rows.Count + 8).ToString();
                ws.Cells["A" + (dtTabla.Rows.Count + 8).ToString()].Value = "TOTALES";
                ws.Cells[f1].Merge = true;
                ws.Cells[f1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[f1].Style.Font.Bold = true;
                ws.Cells[f1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                ws.Cells[f1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                ws.Cells[f1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells[f1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells["P" + (dtTabla.Rows.Count + 8).ToString()].Value = Brutos;
                ws.Cells["Q" + (dtTabla.Rows.Count + 8).ToString()].Value = RSemanal;
                ws.Cells["R" + (dtTabla.Rows.Count + 8).ToString()].Value = DOM;
                ws.Cells["S" + (dtTabla.Rows.Count + 8).ToString()].Value = BUC;
                ws.Cells["T" + (dtTabla.Rows.Count + 8).ToString()].Value = Movilidad;
                ws.Cells["U" + (dtTabla.Rows.Count + 8).ToString()].Value = Escolaridad;
                ws.Cells["V" + (dtTabla.Rows.Count + 8).ToString()].Value = DOM2;
                ws.Cells["W" + (dtTabla.Rows.Count + 8).ToString()].Value = FER;
                ws.Cells["X" + (dtTabla.Rows.Count + 8).ToString()].Value = CTS;
                ws.Cells["Y" + (dtTabla.Rows.Count + 8).ToString()].Value = Vacaciones;
                ws.Cells["Z" + (dtTabla.Rows.Count + 8).ToString()].Value = Gratificacion;
                ws.Cells["AA" + (dtTabla.Rows.Count + 8).ToString()].Value = Otrafe;
                ws.Cells["AB" + (dtTabla.Rows.Count + 8).ToString()].Value = Otrafepro;
                ws.Cells["AC" + (dtTabla.Rows.Count + 8).ToString()].Value = BonoGrati;
                ws.Cells["AD" + (dtTabla.Rows.Count + 8).ToString()].Value = EssaludVida;
                ws.Cells["AE" + (dtTabla.Rows.Count + 8).ToString()].Value = MensualBruto;
                ws.Cells["AF" + (dtTabla.Rows.Count + 8).ToString()].Value = MensualRemuneracion;                
                ws.Cells["AH" + (dtTabla.Rows.Count + 8).ToString()].Value = Aporte;
                ws.Cells["AI" + (dtTabla.Rows.Count + 8).ToString()].Value = Comision;
                ws.Cells["AJ" + (dtTabla.Rows.Count + 8).ToString()].Value = Prima;
                ws.Cells["AK" + (dtTabla.Rows.Count + 8).ToString()].Value = ONP;
                ws.Cells["AL" + (dtTabla.Rows.Count + 8).ToString()].Value = Conaf;
                ws.Cells["AM" + (dtTabla.Rows.Count + 8).ToString()].Value = RentaQuinta;
                ws.Cells["AN" + (dtTabla.Rows.Count + 8).ToString()].Value = Desjudicial;
                ws.Cells["AO" + (dtTabla.Rows.Count + 8).ToString()].Value = Adelanto;
                ws.Cells["AP" + (dtTabla.Rows.Count + 8).ToString()].Value = Otrosdesc;
                ws.Cells["AQ" + (dtTabla.Rows.Count + 8).ToString()].Value = Sindicato;
                ws.Cells["AR" + (dtTabla.Rows.Count + 8).ToString()].Value = Idem;
                ws.Cells["AS" + (dtTabla.Rows.Count + 8).ToString()].Value = EssaludVidaD;
                ws.Cells["AT" + (dtTabla.Rows.Count + 8).ToString()].Value = TotalDescuento;
                ws.Cells["AU" + (dtTabla.Rows.Count + 8).ToString()].Value = PagoNeto;
                ws.Cells["AV" + (dtTabla.Rows.Count + 8).ToString()].Value = Essalud;
                ws.Cells["AW" + (dtTabla.Rows.Count + 8).ToString()].Value = EssaludSCRT;
                ws.Cells["AX" + (dtTabla.Rows.Count + 8).ToString()].Value = Segvley;
                ws.Cells["AY" + (dtTabla.Rows.Count + 8).ToString()].Value = TotalEmpleador;
                string fila = "P" + (dtTabla.Rows.Count + 8).ToString() + ":" + "AY" + (dtTabla.Rows.Count + 8).ToString();
                ws.Cells[fila].Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                ws.Cells[fila].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                ws.Cells[fila].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells[fila].Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                ws.Cells["AY" + (dtTabla.Rows.Count + 8).ToString()].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells[f1].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                ws.Cells[ws.Dimension.Address].AutoFitColumns();
            }

            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_Planilla_RegimenGeneral()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 500000; i++)
                ws.DeleteRow(9);


            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            objEntidad.CodPeriodo = Convert.ToInt32(Request["CodPeriodo"]);

            DataTable dtTabla = null;

            dtTabla = objOperacion.F_Planilla_Salario_Cab_REPORTE_RG(objEntidad);

            for (int i = 1; i < dtTabla.Rows.Count; i++)
            {
                ws.InsertRow(9, i);
                if (i == 1)
                {
                    ws.Cells["A" + (i + 8) + ":" + "AJ" + (i + 8)].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    ws.Cells["A" + (i + 8) + ":" + "AJ" + (i + 8)].Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                    ws.Cells["A" + (i + 8) + ":" + "AJ" + (i + 8)].Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                    ws.Cells["A" + (i + 8) + ":" + "AJ" + (i + 8)].Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                }
                else
                {
                    ws.Cells["A" + (i + 8) + ":" + "AJ" + (i + 8)].Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                    ws.Cells["A" + (i + 8) + ":" + "AJ" + (i + 8)].Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                    ws.Cells["A" + (i + 8) + ":" + "AJ" + (i + 8)].Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                    ws.Cells["A" + (i + 8) + ":" + "AJ" + (i + 8)].Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                }

            }
            string periodo = dtTabla.Rows[0][0].ToString();
            dtTabla.Columns.RemoveAt(0);

            ws.Cells["A9"].LoadFromDataTable(dtTabla, true);
            ws.Cells["E2"].Value = periodo;

            ws.DeleteRow(9);

            ws.Cells["A" + 9 + ":" + "AJ" + 9].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            ws.Cells["A" + 9 + ":" + "AJ" + 9].Style.Border.Right.Style = ExcelBorderStyle.Dotted;
            ws.Cells["A" + 9 + ":" + "AJ" + 9].Style.Border.Left.Style = ExcelBorderStyle.Dotted;
            ws.Cells["A" + 9 + ":" + "AJ" + 9].Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;


            ws.Cells["n:n"].Style.Numberformat.Format = null;
            ws.Cells["n:n"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["o:o"].Style.Numberformat.Format = null;
            ws.Cells["o:o"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["p:p"].Style.Numberformat.Format = null;
            ws.Cells["p:p"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["q:q"].Style.Numberformat.Format = null;
            ws.Cells["q:q"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["r:r"].Style.Numberformat.Format = null;
            ws.Cells["r:r"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["s:s"].Style.Numberformat.Format = null;
            ws.Cells["s:s"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["t:t"].Style.Numberformat.Format = null;
            ws.Cells["t:t"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["u:u"].Style.Numberformat.Format = null;
            ws.Cells["u:u"].Style.Numberformat.Format = "#,##0.00";
            /*ws.Cells["v:v"].Style.Numberformat.Format = null;
            ws.Cells["v:v"].Style.Numberformat.Format = "#,##0.00";*/
            ws.Cells["w:w"].Style.Numberformat.Format = null;
            ws.Cells["w:w"].Style.Numberformat.Format = "#,##0.00";
            /*ws.Cells["x:x"].Style.Numberformat.Format = null;
            ws.Cells["x:x"].Style.Numberformat.Format = "#,##0.00";*/
            ws.Cells["y:y"].Style.Numberformat.Format = null;
            ws.Cells["y:y"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["z:z"].Style.Numberformat.Format = null;
            ws.Cells["z:z"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["aa:aa"].Style.Numberformat.Format = null;
            ws.Cells["aa:aa"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["ab:ab"].Style.Numberformat.Format = null;
            ws.Cells["ab:ab"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["ac:ac"].Style.Numberformat.Format = null;
            ws.Cells["ac:ac"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["ad:ad"].Style.Numberformat.Format = null;
            ws.Cells["ad:ad"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["ae:ae"].Style.Numberformat.Format = null;
            ws.Cells["ae:ae"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["af:af"].Style.Numberformat.Format = null;
            ws.Cells["af:af"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["ag:ag"].Style.Numberformat.Format = null;
            ws.Cells["ag:ag"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["ah:ah"].Style.Numberformat.Format = null;
            ws.Cells["ah:ah"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["ai:ai"].Style.Numberformat.Format = null;
            ws.Cells["ai:ai"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["aj:aj"].Style.Numberformat.Format = null;
            ws.Cells["aj:aj"].Style.Numberformat.Format = "#,##0.00";
            /*ws.Cells["ak:ak"].Style.Numberformat.Format = null;
            ws.Cells["ak:ak"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["al:al"].Style.Numberformat.Format = null;
            ws.Cells["al:al"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["am:am"].Style.Numberformat.Format = null;
            ws.Cells["am:am"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["an:an"].Style.Numberformat.Format = null;
            ws.Cells["an:an"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["ao:ao"].Style.Numberformat.Format = null;
            ws.Cells["ao:ao"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["ap:ap"].Style.Numberformat.Format = null;
            ws.Cells["ap:ap"].Style.Numberformat.Format = "#,##0.00";*/

            if (dtTabla.Rows.Count > 0)
            {
                decimal SueldoBasico = (decimal)dtTabla.Compute("SUM([SueldoBasico])", null);
                decimal AsignacionFamiliar2 = (decimal)dtTabla.Compute("SUM([AsignacionFamiliar2])", null);
                decimal BasicoLaborado = (decimal)dtTabla.Compute("SUM([BasicoLaborado])", null);
                decimal ONP2 = (decimal)dtTabla.Compute("SUM([ONP2])", null);
                decimal Otros = (decimal)dtTabla.Compute("SUM([Otros])", null);
                decimal OtrosIngresos = (decimal)dtTabla.Compute("SUM([OtrosIngresos])", null);
                decimal OtrosIngresosPro = (decimal)dtTabla.Compute("SUM([OtrosIngresosPro])", null);
                decimal Adelanto = (decimal)dtTabla.Compute("SUM([Adelanto])", null);
                //decimal CTS = (decimal)dtTabla.Compute("SUM([CTS])", null);                
                decimal MensualBruto = (decimal)dtTabla.Compute("SUM([MensualBruto])", null);
                decimal Aporte = (decimal)dtTabla.Compute("SUM([Aporte])", null);
                decimal Comision = (decimal)dtTabla.Compute("SUM([Comision])", null);
                decimal Prima = (decimal)dtTabla.Compute("SUM([Prima])", null);
                decimal QtaCategoria = (decimal)dtTabla.Compute("SUM([QtaCategoria])", null);
                decimal OtrosDesc = (decimal)dtTabla.Compute("SUM([OtrosDesc])", null);
                decimal TotalDescuento = (decimal)dtTabla.Compute("SUM([TotalDescuento])", null);
                decimal RNeta = (decimal)dtTabla.Compute("SUM([RNeta])", null);
                //EMPLEADOR
                decimal Essalud = (decimal)dtTabla.Compute("SUM([Essalud])", null);
                decimal EssaludSCRT = (decimal)dtTabla.Compute("SUM([EssaludSCRT])", null);
                decimal Segvley = (decimal)dtTabla.Compute("SUM([Segvley])", null);
                decimal TotalEmpleador = (decimal)dtTabla.Compute("SUM([TotalEmpleador])", null);

                string f1 = "A" + (dtTabla.Rows.Count + 9).ToString() + ":" + "M" + (dtTabla.Rows.Count + 9).ToString();
                ws.Cells["A" + (dtTabla.Rows.Count + 9).ToString()].Value = "TOTALES";
                ws.Cells[f1].Merge = true;
                ws.Cells[f1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[f1].Style.Font.Bold = true;
                ws.Cells[f1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                ws.Cells[f1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                ws.Cells[f1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells[f1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells["N" + (dtTabla.Rows.Count + 9).ToString()].Value = SueldoBasico;
                ws.Cells["O" + (dtTabla.Rows.Count + 9).ToString()].Value = AsignacionFamiliar2;
                ws.Cells["P" + (dtTabla.Rows.Count + 9).ToString()].Value = BasicoLaborado;
                ws.Cells["Q" + (dtTabla.Rows.Count + 9).ToString()].Value = Otros;
                ws.Cells["R" + (dtTabla.Rows.Count + 9).ToString()].Value = OtrosIngresos;
                ws.Cells["S" + (dtTabla.Rows.Count + 9).ToString()].Value = OtrosIngresosPro;
                // ws.Cells["T" + (dtTabla.Rows.Count + 9).ToString()].Value = MensualBruto;
                ws.Cells["U" + (dtTabla.Rows.Count + 9).ToString()].Value = MensualBruto;
                ws.Cells["W" + (dtTabla.Rows.Count + 9).ToString()].Value = ONP2;
                //ws.Cells["X" + (dtTabla.Rows.Count + 9).ToString()].Value = Aporte;
                ws.Cells["Y" + (dtTabla.Rows.Count + 9).ToString()].Value = Aporte;
                ws.Cells["Z" + (dtTabla.Rows.Count + 9).ToString()].Value = Comision;
                ws.Cells["AA" + (dtTabla.Rows.Count + 9).ToString()].Value = Prima;
                ws.Cells["AB" + (dtTabla.Rows.Count + 9).ToString()].Value = QtaCategoria;
                ws.Cells["AC" + (dtTabla.Rows.Count + 9).ToString()].Value = OtrosDesc;
                ws.Cells["AD" + (dtTabla.Rows.Count + 9).ToString()].Value = Adelanto;
                ws.Cells["AE" + (dtTabla.Rows.Count + 9).ToString()].Value = TotalDescuento;
                ws.Cells["AF" + (dtTabla.Rows.Count + 9).ToString()].Value = RNeta;
                ws.Cells["AG" + (dtTabla.Rows.Count + 9).ToString()].Value = Essalud;
                ws.Cells["AH" + (dtTabla.Rows.Count + 9).ToString()].Value = EssaludSCRT;
                ws.Cells["AI" + (dtTabla.Rows.Count + 9).ToString()].Value = Segvley;
                ws.Cells["AJ" + (dtTabla.Rows.Count + 9).ToString()].Value = TotalEmpleador;

                string fila = "N" + (dtTabla.Rows.Count + 9).ToString() + ":" + "AJ" + (dtTabla.Rows.Count + 9).ToString();
                ws.Cells[fila].Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                ws.Cells[fila].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                ws.Cells[fila].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells[fila].Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                ws.Cells["AJ" + (dtTabla.Rows.Count + 9).ToString()].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells[f1].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                ws.Cells[ws.Dimension.Address].AutoFitColumns();

            }

            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_Compras_ComprasPlaza()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 500000; i++)
                ws.DeleteRow(2);

            NotaIngresoSalidaCabCE objEntidad = new NotaIngresoSalidaCabCE();
            NotaIngresoSalidaCabCN objOperacion = new NotaIngresoSalidaCabCN();

            objEntidad.CodAlmacen = Convert.ToInt32(Request["CodAlmacen"]);
            objEntidad.CodCtaCte = Convert.ToInt32(Request["CodCtaCte"]);
            objEntidad.FlagServicios = Convert.ToInt32(Request["FlagServicios"]);
            objEntidad.Desde = Convert.ToDateTime(Request["Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(Request["Hasta"]);

            DataTable dtTabla = null;

         //   dtTabla = objOperacion.F_NOTAINGRESOSALIDACAB_CP_REPORTE(objEntidad);

        

            ws.Cells["A2"].LoadFromDataTable(dtTabla, true);

            //ws.Cells["h:h"].Style.Numberformat.Format = null;
            //ws.Cells["h:h"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["G:G"].Style.Numberformat.Format = null;
            //ws.Cells["G:G"].Style.Numberformat.Format = "#,##0.00";

            //if (dtTabla.Rows.Count > 0)
            //{
            //    decimal Soles = (decimal)dtTabla.Compute("SUM([Soles])", null);
            //    decimal Dolares = (decimal)dtTabla.Compute("SUM([Dolares])", null);

            //    ws.Cells["G" + (dtTabla.Rows.Count + 3).ToString()].Value = Soles;
            //    ws.Cells["H" + (dtTabla.Rows.Count + 3).ToString()].Value = Dolares;
            //}

            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_Ventas_ServiciosPorFacturar()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 500000; i++)
                ws.DeleteRow(2);

            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            objEntidad.CodAlmacen = Convert.ToInt32(Request["CodAlmacen"]);
            objEntidad.CodEmpleado = Convert.ToInt32(Request["CodEmpleado"]);
            objEntidad.Desde = Convert.ToDateTime(Request["Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(Request["Hasta"]);

            DataTable dtTabla = null;

            dtTabla = objOperacion.F_DOCUMENTOVENTACAB_SERVICIOSPORFACTURAR(objEntidad);

            //dtTabla.Columns.RemoveAt(12); dtTabla.Columns.RemoveAt(11);
            //dtTabla.Columns.RemoveAt(10);

            ws.Cells["A2"].LoadFromDataTable(dtTabla, true);

            //ws.Cells["h:h"].Style.Numberformat.Format = null;
            //ws.Cells["h:h"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["G:G"].Style.Numberformat.Format = null;
            //ws.Cells["G:G"].Style.Numberformat.Format = "#,##0.00";

            //if (dtTabla.Rows.Count > 0)
            //{
            //    decimal Soles = (decimal)dtTabla.Compute("SUM([Soles])", null);
            //    decimal Dolares = (decimal)dtTabla.Compute("SUM([Dolares])", null);

            //    ws.Cells["G" + (dtTabla.Rows.Count + 3).ToString()].Value = Soles;
            //    ws.Cells["H" + (dtTabla.Rows.Count + 3).ToString()].Value = Dolares;
            //}

            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_Ventas_VentasDiarias()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 500000; i++)
                ws.DeleteRow(11);

            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            objEntidad.CodAlmacen = Convert.ToInt32(Request["CodAlmacen"]);           
            objEntidad.Desde = Convert.ToDateTime(Request["Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(Request["Hasta"]);

            DataTable dtTabla = null;

            dtTabla = objOperacion.F_DOCUMENTOVENTACAB_VENTADIARIA(objEntidad);
                       
            ws.Cells["E2"].Value = DateTime.Now.ToString("dd/MM/yyyy") + ' ' + DateTime.Now.ToString("HH:mm:ss");
            ws.Cells["A3"].Value = dtTabla.Rows[0]["Empresa"].ToString();
            ws.Cells["A4"].Value = dtTabla.Rows[0]["Sucursal"].ToString();
            ws.Cells["A7"].Value = Request["SubTitulo"].ToString();

            ws.Cells["A11"].LoadFromDataTable(dtTabla, true);
            ws.DeleteRow(11);
            ws.Cells["C:C"].Style.Numberformat.Format = null;
            ws.Cells["C:C"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["D:D"].Style.Numberformat.Format = null;
            ws.Cells["D:D"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["E:E"].Style.Numberformat.Format = null;
            ws.Cells["E:E"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["F:F"].Style.Numberformat.Format = null;
            ws.Cells["F:F"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["B:B"].Style.Numberformat.Format = null;
            ws.Cells["B:B"].Style.Numberformat.Format = "#,##0.00";

            if (dtTabla.Rows.Count > 0)
            {
                ws.Cells["A" + (dtTabla.Rows.Count + 11).ToString()].Value = "TOTAL";
                ws.Cells["B" + (dtTabla.Rows.Count + 11).ToString()].Value = (decimal)dtTabla.Compute("SUM([FT])", null);
                ws.Cells["C" + (dtTabla.Rows.Count + 11).ToString()].Value = (decimal)dtTabla.Compute("SUM([BO])", null);
                ws.Cells["D" + (dtTabla.Rows.Count + 11).ToString()].Value = (decimal)dtTabla.Compute("SUM([NV])", null);
                ws.Cells["E" + (dtTabla.Rows.Count + 11).ToString()].Value = (decimal)dtTabla.Compute("SUM([NC])", null);
                ws.Cells["F" + (dtTabla.Rows.Count + 11).ToString()].Value = (decimal)dtTabla.Compute("SUM([TF])", null);

                ws.Cells["B" + (dtTabla.Rows.Count + 11).ToString()].Style.Font.Bold = true;
                ws.Cells["C" + (dtTabla.Rows.Count + 11).ToString()].Style.Font.Bold = true;
                ws.Cells["D" + (dtTabla.Rows.Count + 11).ToString()].Style.Font.Bold = true;
                ws.Cells["E" + (dtTabla.Rows.Count + 11).ToString()].Style.Font.Bold = true;
                ws.Cells["F" + (dtTabla.Rows.Count + 11).ToString()].Style.Font.Bold = true;
                ws.Cells["A" + (dtTabla.Rows.Count + 11).ToString()].Style.Font.Bold = true;
            }

            ws.DeleteColumn(8);
            ws.DeleteColumn(7);

            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_Registro_RPH()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 500000; i++)
                ws.DeleteRow(1);

            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            objEntidad.CodAlmacen = Convert.ToInt32(Request["CodAlmacen"]);
            objEntidad.Desde = Convert.ToDateTime(Request["Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(Request["Hasta"]);

            DataTable dtTabla = null;

            dtTabla = objOperacion.P_Registro_RPH(objEntidad);

            ws.Cells["A1"].LoadFromDataTable(dtTabla, true);

            ws.Cells["h:h"].Style.Numberformat.Format = null;
            ws.Cells["h:h"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["i:i"].Style.Numberformat.Format = null;
            ws.Cells["i:i"].Style.Numberformat.Format = "#,##0.00";
            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_ListadoPrecio_Povis()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 500000; i++)
                ws.DeleteRow(1);

            LGProductosCE objLGProductosCE = new LGProductosCE();
            LGProductosCN objLGProductosCN = new LGProductosCN();

            objLGProductosCE.IdFamilia = Convert.ToInt32(Request.QueryString["IdFamilia"]);
            objLGProductosCE.DscProducto = Convert.ToString(Request.QueryString["DscProducto"]);
            objLGProductosCE.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objLGProductosCE.CodMarca = Convert.ToInt32(Request.QueryString["CodMarca"]);
            objLGProductosCE.chkMarca = Convert.ToInt32(Request.QueryString["Marca"]);


            DataTable dtTabla = null;

            dtTabla = objLGProductosCN.F_LGProductos_ListarProductosPrecios_Reeim_Excel(objLGProductosCE);

            ws.Cells["A1"].LoadFromDataTable(dtTabla, true);
            ws.DeleteColumn(1);


            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_Inventario_StockActual()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 500000; i++)
                ws.DeleteRow(1);

            LGProductosCE objLGProductosCE = new LGProductosCE();
            LGProductosCN objLGProductosCN = new LGProductosCN();

            objLGProductosCE.IdFamilia = Convert.ToInt32(Request.QueryString["IdFamilia"]);
            objLGProductosCE.DscProducto = Convert.ToString(Request.QueryString["DscProducto"]);
            objLGProductosCE.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objLGProductosCE.CodMarca = Convert.ToInt32(Request.QueryString["CodMarca"]);
            objLGProductosCE.chkMarca = Convert.ToInt32(Request.QueryString["Marca"]);


            DataTable dtTabla = null;

            dtTabla = objLGProductosCN.pa_LGStockAlmacen_Inventario_StockActual_Povis_Excel(objLGProductosCE);

            ws.Cells["A1"].LoadFromDataTable(dtTabla, true);
            //ws.DeleteColumn(1);


            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_Inventario_StockActual_Salcedo()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 500000; i++)
                ws.DeleteRow(1);

            LGProductosCE objLGProductosCE = new LGProductosCE();
            LGProductosCN objLGProductosCN = new LGProductosCN();

            objLGProductosCE.IdFamilia = Convert.ToInt32(Request.QueryString["IdFamilia"]);          
            objLGProductosCE.CodTipo = Convert.ToInt32(Request.QueryString["CodTipo"]);
       
            DataTable dtTabla = null;

            dtTabla = objLGProductosCN.pa_LGStockAlmacen_Inventario_StockActual_Salcedo_Excel(objLGProductosCE);

            ws.Cells["A1"].LoadFromDataTable(dtTabla, true);

            ws.Cells["d:d"].Style.Numberformat.Format = null;
            ws.Cells["d:d"].Style.Numberformat.Format = "#,##0.00";
 
            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }
        
        public void P_Reporte_Ventas_Mes()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 500000; i++)
                ws.DeleteRow(1);

            DocumentoVentaCabCE objLGProductosCE = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objLGProductosCN = new DocumentoVentaCabCN();

            objLGProductosCE.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
            objLGProductosCE.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
            objLGProductosCE.CodAlmacen = Convert.ToInt32(Request.QueryString["Filtro_CodAlmacen"]);
            objLGProductosCE.Ruta = Convert.ToInt32(Request.QueryString["Ruta"]);
            objLGProductosCE.chkMarca = Convert.ToInt32(Request.QueryString["chkMarca"]);
            objLGProductosCE.codMarca = Convert.ToInt32(Request.QueryString["CodMarca"]);
            objLGProductosCE.chkCliente = Convert.ToInt32(Request.QueryString["chkCliente"]);
            objLGProductosCE.CodCliente = Convert.ToInt32(Request.QueryString["CodCliente"]);



            DataTable dtTabla = null;

            dtTabla = objLGProductosCN.F_DOCUMENTOVENTACAB_VENTAS_MENSUALES_VENDEDOR_POVIS(objLGProductosCE);

            ws.Cells["A1"].LoadFromDataTable(dtTabla, true);
            //ws.DeleteColumn(1);


            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_Reporte_Cobranzas()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 2; i < 500000; i++)
                ws.DeleteRow(2);

            DocumentoVentaCabCE objDocumentoVentaCabCE = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objDocumentoVentaCabCN = new DocumentoVentaCabCN();

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

            DataTable dtTabla = null;

            dtTabla = objDocumentoVentaCabCN.F_Cobranzas_Reporte(objDocumentoVentaCabCE);

            dtTabla.Columns.RemoveAt(23); dtTabla.Columns.RemoveAt(22);
            dtTabla.Columns.RemoveAt(21); dtTabla.Columns.RemoveAt(20); dtTabla.Columns.RemoveAt(19);
            dtTabla.Columns.RemoveAt(18); dtTabla.Columns.RemoveAt(17); dtTabla.Columns.RemoveAt(16);
            dtTabla.Columns.RemoveAt(15); dtTabla.Columns.RemoveAt(14); dtTabla.Columns.RemoveAt(13);
            dtTabla.Columns.RemoveAt(12); dtTabla.Columns.RemoveAt(11);

            ws.Cells["A2"].LoadFromDataTable(dtTabla, true);
            //ws.DeleteColumn(1);
            ws.DeleteRow(2);
            decimal SaldoDolares =0;
            if (dtTabla.Rows.Count > 0)
            {
                SaldoDolares = (decimal)dtTabla.Compute("SUM([SaldoDolares])", null);
            }
            ws.Cells["G" + (dtTabla.Rows.Count + 2).ToString()].Value = "TOTAL";
            ws.Cells["H" + (dtTabla.Rows.Count + 2).ToString()].Value = SaldoDolares;

            ws.Cells["f:f"].Style.Numberformat.Format = null;
            ws.Cells["f:f"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["g:g"].Style.Numberformat.Format = null;
            ws.Cells["g:g"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["h:h"].Style.Numberformat.Format = null;
            ws.Cells["h:h"].Style.Numberformat.Format = "#,##0.00";

            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void report() { }
        public void P_Reporte_Cobranzas_Hasta()
        {

            //SEGUNDO CAMBIO POR FRANCO
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 2; i < 50000; i++)
                ws.DeleteRow(2);

            DocumentoVentaCabCE objDocumentoVentaCabCE = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objDocumentoVentaCabCN = new DocumentoVentaCabCN();

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

            DataTable dtTabla = null;

            dtTabla = objDocumentoVentaCabCN.F_Cobranzas_Reporte_COBRADOS_HASTA(objDocumentoVentaCabCE);

            Int32 j = 1;

            string currentRUC = string.Empty;

            ws.Cells["f:f"].Style.Numberformat.Format = null;
            ws.Cells["f:f"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["g:g"].Style.Numberformat.Format = null;
            ws.Cells["g:g"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["h:h"].Style.Numberformat.Format = null;
            ws.Cells["h:h"].Style.Numberformat.Format = "#,##0.00";

            decimal totalMontoEmpresa = 0; // Variable para almacenar el monto total de cada empresa
            string monedaTotal = ""; // Variable para almacenar la moneda del total

            int Partida = 0; // Variable para almacenar la fila de inicio de la suma

            for (int c = 0; c < dtTabla.Rows.Count; c++)
            {
                string ruc = dtTabla.Rows[c]["Ruc"].ToString();

                // Si el RUC cambia, agrega una fila vacía
                if (ruc != currentRUC)
                {
                    currentRUC = ruc;
                    ws.InsertRow(c + j + 1, 1); // Inserta una fila vacía debajo de la empresa
                    j += 1;
                    Partida = c + j;
                }

                ws.Cells["A" + (c + j).ToString()].Value = dtTabla.Rows[c]["Ruc"].ToString();
                ws.Cells["B" + (c + j).ToString()].Value = dtTabla.Rows[c]["RazonSocial"].ToString();
                ws.Cells["C" + (c + j).ToString()].Value = dtTabla.Rows[c]["Numero"].ToString();
                ws.Cells["D" + (c + j).ToString()].Value = dtTabla.Rows[c]["Emision"].ToString();
                ws.Cells["E" + (c + j).ToString()].Value = dtTabla.Rows[c]["Vencimiento"].ToString();
                ws.Cells["F" + (c + j).ToString()].Value = Convert.ToDecimal(dtTabla.Rows[c]["TotalDolares"]);
                ws.Cells["G" + (c + j).ToString()].Value = Convert.ToDecimal(dtTabla.Rows[c]["AcuentaDolares"]);
                ws.Cells["H" + (c + j).ToString()].Value = Convert.ToDecimal(dtTabla.Rows[c]["SaldoDolares"]);
                ws.Cells["I" + (c + j).ToString()].Value = dtTabla.Rows[c]["Moneda"].ToString();
                ws.Cells["J" + (c + j).ToString()].Value = dtTabla.Rows[c]["Banco"].ToString();
                ws.Cells["K" + (c + j).ToString()].Value = dtTabla.Rows[c]["CodigoUnico"].ToString();

                // Actualiza la suma del monto total
                totalMontoEmpresa += Convert.ToDecimal(dtTabla.Rows[c]["SaldoDolares"]);

                // Almacena la moneda actual
                monedaTotal = dtTabla.Rows[c]["Moneda"].ToString();

                // Si este es el último registro de la empresa, agrega la fórmula de suma
                if (c == dtTabla.Rows.Count - 1 || ruc != dtTabla.Rows[c + 1]["Ruc"].ToString())
                {
                    ws.Cells["G" + (c + j + 1).ToString()].Value = "TOTAL:";

                    ws.Cells["H" + (c + j + 1).ToString()].Formula = "SUM(H" + (Partida).ToString() + ":H" + (c + j).ToString() + ")";
                    ws.Cells["I" + (c + j + 1).ToString()].Value = monedaTotal; // Agrega la moneda

                    j += 1; // Incrementa j para mantener un seguimiento de las filas adicionales
                    totalMontoEmpresa = 0; // Restablece la suma para la siguiente empresa
                }
            }

            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }
       

        public void P_Reporte_Caja_Chica()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 500000; i++)
                ws.DeleteRow(1);

            DocumentoVentaCabCE objLGProductosCE = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objLGProductosCN = new DocumentoVentaCabCN();

            objLGProductosCE.FechaEmision = Convert.ToDateTime(Request.QueryString["FechaEmision"]);
            objLGProductosCE.FechaSaldo = Convert.ToDateTime(Request.QueryString["FechaSaldo"]);
            objLGProductosCE.CodAlmacen = Convert.ToInt32(Request.QueryString["CodSede"]);
            objLGProductosCE.CodCajaFisica = Convert.ToInt32(Request.QueryString["CodCajaFisica"]);
            objLGProductosCE.CodEmpresa = Convert.ToInt32(Request.QueryString["CodEmpresa"]);
            objLGProductosCE.CodMedioPago = Convert.ToInt32(Request.QueryString["CodMedioPago"]);
            objLGProductosCE.CodDoc = Convert.ToInt32(Request.QueryString["CodDoc"]);



            DataTable dtTabla = null;

            dtTabla = objLGProductosCN.F_CajaChica_Detalle(objLGProductosCE);

            if (dtTabla.Rows.Count != 0)
            {
                string MedioPago = dtTabla.Rows[0]["MedioPago"].ToString();
                string Operacion = dtTabla.Rows[0]["Operacion"].ToString();
                int C = 12;
                int LIO = 12;
                string LMINICIAL = "8";
                String LMI = LMINICIAL;
                string SE = "";
                string SS = "";
                int INDICE = 1;

                ws.Cells["F1"].Value = DateTime.Now.ToString("dd/MM/yyyy");
                ws.Cells["F2"].Value = DateTime.Now.ToString("hh:mm:ss");

                ws.Cells["A1"].Value = dtTabla.Rows[0]["Empresa"].ToString();
                ws.Cells["A2"].Value = "SUCURSAL " + dtTabla.Rows[0]["Sede"].ToString();
                ws.Cells["B3"].Value = Request["Titulo"].ToString();
                ws.Cells["B4"].Value = dtTabla.Rows[0]["Fecha"].ToString();
                ws.Cells["A5"].Value = "Caja ";
                ws.Cells["B5"].Value = dtTabla.Rows[0]["Caja"].ToString();
                ws.Cells["A6"].Value = "Usuario Generación :";
                ws.Cells["B6"].Value = dtTabla.Rows[0]["UsuarioGeneracion"].ToString();
                ws.Cells["A7"].Value = "Usuario Cierre ";
                ws.Cells["B7"].Value = dtTabla.Rows[0]["UsuarioLiquidacion"].ToString();
                ws.Cells["A8"].Value = "Fecha Cierre ";
                ws.Cells["B8"].Value = dtTabla.Rows[0]["FechaLiquidacion"].ToString();
                ws.Cells["A9"].Value = "Emision";
                ws.Cells["B9"].Value = "RUC";
                ws.Cells["C9"].Value = "Razon Social";
                ws.Cells["D9"].Value = "T/D";
                ws.Cells["E9"].Value = "SERIE";
                ws.Cells["F9"].Value = "NUMERO";
                ws.Cells["G9"].Value = "S/.";
                ws.Cells["H9"].Value = "US$";
                ws.Cells["I9"].Value = "F/P";
                ws.Cells["J9"].Value = "OBSERVACION";
                ws.Cells["A10"].Value = MedioPago;
                ws.Cells["A10"].Style.Font.Color.SetColor(Color.Black);
                ws.Cells["A10"].Style.Font.Bold = true;
                ws.Cells["B11"].Value = Operacion;
                ws.Cells["B11"].Style.Font.Color.SetColor(Color.Black);
                ws.Cells["B11"].Style.Font.Bold = true;
                ws.Column(1).Width = 18.77;
                ws.Column(2).Width = 18.77;
                ws.Column(3).Width = 91.77;
                ws.Column(4).Width = 18.77;
                ws.Column(5).Width = 18.77;
                ws.Column(6).Width = 23.30;
                ws.Column(7).Width = 10.02;
                ws.Column(8).Width = 10.02;
                ws.Column(9).Width = 18.87;
                ws.Column(10).Width = 62.20;
                ws.Row(1).Height = 15;
                ws.Row(2).Height = 15;
                ws.Row(3).Height = 15;
                ws.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells["A1"].Style.Font.Size = 16;
                ws.Cells["A2"].Style.Font.Size = 16;
                ws.Cells["B3"].Style.Font.Size = 16;
                ws.Cells["B4"].Style.Font.Size = 12;
                ws.Cells["A5:B5"].Style.Font.Size = 10;
                ws.Cells["A6:B6"].Style.Font.Size = 10;
                ws.Cells["A7:B7"].Style.Font.Size = 10;
                ws.Cells["A8:B8"].Style.Font.Size = 10;
                ws.Cells["A9:J9"].Style.Font.Size = 12;
                ws.Cells["A9:J9"].Style.Font.Bold = true;
                ws.Row(9).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells["A5:A8"].Style.Font.Bold = true;
                ws.Cells["A1:G1000"].Style.Font.Name = "Arial";
                ws.Cells["B3"].Style.Font.Bold = true;
                ws.Cells["A1"].Style.Font.Bold = true;
                ws.Cells["A2"].Style.Font.Bold = true;
                ws.Cells["A12:A1000"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Row(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Row(4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells["D12:D1000"].Style.Numberformat.Format = "#,##0.00";
                ws.Cells["E12:E1000"].Style.Numberformat.Format = "#,##0.00";
                ///////////////////////////////////////////////////
                for (int I = 0; I < dtTabla.Rows.Count; I++)
                {
                    ///////////////////////////////////////////////
                    if (dtTabla.Rows[I]["MedioPago"].ToString() == MedioPago)
                    {
                        if (dtTabla.Rows[I]["Operacion"].ToString() == Operacion)
                        {
                            ws.Cells["A" + (I + C).ToString()].Value = dtTabla.Rows[I]["Emision"].ToString();
                            ws.Cells["B" + (I + C).ToString()].Value = dtTabla.Rows[I]["RUC"].ToString();
                            ws.Cells["C" + (I + C).ToString()].Value = dtTabla.Rows[I]["RazonSocial"].ToString();
                            ws.Cells["D" + (I + C).ToString()].Value = dtTabla.Rows[I]["AbvDdsc"].ToString();
                            ws.Cells["E" + (I + C).ToString()].Value = dtTabla.Rows[I]["Serie"].ToString();
                            ws.Cells["F" + (I + C).ToString()].Value = dtTabla.Rows[I]["Numero"].ToString();
                            ws.Cells["G" + (I + C).ToString()].Value = dtTabla.Rows[I]["TotalSoles"];
                            ws.Cells["H" + (I + C).ToString()].Value = dtTabla.Rows[I]["TotalDolares"];
                            ws.Cells["I" + (I + C).ToString()].Value = dtTabla.Rows[I]["FormaPago"].ToString();
                            ws.Cells["J" + (I + C).ToString()].Value = dtTabla.Rows[I]["NroOperacion"].ToString();

                            if (dtTabla.Rows.Count > I + 1)
                            {
                                if (dtTabla.Rows[I + 1]["Operacion"].ToString() != Operacion & dtTabla.Rows[I + 1]["MedioPago"].ToString() == MedioPago)
                                {
                                    C++;

                                    if (I == 0)
                                        INDICE = 0;

                                    ws.Cells["F" + (I + C).ToString()].Value = dtTabla.Rows[I - INDICE]["Operacion"].ToString() + " " + dtTabla.Rows[I - INDICE]["MedioPago"].ToString();
                                    ws.Cells["F" + (I + C).ToString()].Style.Font.Bold = true;
                                    ws.Cells["G" + (I + C).ToString()].Formula = "SUM(G" + LIO.ToString() + ":G" + (I + C - 1).ToString() + ")";
                                    ws.Cells["G" + (I + C).ToString()].Style.Font.Bold = true;
                                    ws.Cells["H" + (I + C).ToString()].Formula = "SUM(H" + LIO.ToString() + ":H" + (I + C - 1).ToString() + ")";
                                    ws.Cells["H" + (I + C).ToString()].Style.Font.Bold = true;
                                    INDICE = 1;

                                    if (I == 0)
                                    {
                                        LMI = (C).ToString();
                                    }
                                    else
                                    {
                                        LMI = (I + C).ToString();
                                    }

                                }
                                //EN CASO QUE SOLO SEA 1 VALOR DE ENTRADA
                                //else
                                //{
                                //    C++;
                                //    ws.Cells["C" + (I + C).ToString()].Value = dtTabla.Rows[I]["Operacion"].ToString() + "1 " + dtTabla.Rows[I]["MedioPago"].ToString();
                                //    ws.Cells["C" + (I + C).ToString()].Style.Font.Bold = true;
                                //    ws.Cells["D" + (I + C).ToString()].Formula = "SUM(D" + LIO.ToString() + ":D" + (I + C).ToString() + ")";
                                //    ws.Cells["D" + (I + C).ToString()].Style.Font.Bold = true;
                                //    ws.Cells["E" + (I + C).ToString()].Formula = "SUM(E" + LIO.ToString() + ":E" + (I + C).ToString() + ")";
                                //    ws.Cells["E" + (I + C).ToString()].Style.Font.Bold = true;
                                //    //aca guarda los valores de la entrada
                                //    //SE = (CS-2).ToString();
                                //    //SS = (CS-2).ToString();
                                //    LMI = (I + C).ToString();
                                //}

                            }

                            if (dtTabla.Rows.Count == I + 1)
                            {
                                ws.Cells["F" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["Operacion"].ToString() + " " + dtTabla.Rows[I]["MedioPago"].ToString();
                                ws.Cells["F" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["G" + (I + C + 1).ToString()].Formula = "SUM(G" + LIO.ToString() + ":G" + (I + C).ToString() + ")";
                                ws.Cells["G" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["H" + (I + C + 1).ToString()].Formula = "SUM(H" + LIO.ToString() + ":H" + (I + C).ToString() + ")";
                                ws.Cells["H" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                //aca muestras el total final
                                C++;

                                SE = (LIO - 2).ToString();
                                SS = (LIO - 2).ToString();

                                //    LMI = (LIO - 2).ToString();

                                //if (dtTabla.Rows[I]["Operacion"].ToString() != "SALIDA")
                                //{
                                //    SE=  (8).ToString();
                                //    SS = (8).ToString();
                                //}
                                ws.Cells["F" + (I + C + 1).ToString()].Value = "TOTAL  " + dtTabla.Rows[I]["MedioPago"].ToString();
                                ws.Cells["F" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["G" + (I + C + 1).ToString()].Formula = "=G" + LMI.ToString() + "+ G" + (I + C).ToString();
                                ws.Cells["G" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["H" + (I + C + 1).ToString()].Formula = "=H" + LMI.ToString() + "+ H" + (I + C).ToString();
                                ws.Cells["H" + (I + C + 1).ToString()].Style.Font.Bold = true;


                            }
                        }
                        else
                        {
                            ws.Cells["B" + (I + C).ToString()].Value = dtTabla.Rows[I]["Operacion"].ToString();
                            ws.Cells["B" + (I + C).ToString()].Style.Font.Color.SetColor(Color.Black);
                            ws.Cells["B" + (I + C).ToString()].Style.Font.Bold = true;
                            Operacion = dtTabla.Rows[I]["Operacion"].ToString();

                            C++;
                            LIO = I + C;

                            ws.Cells["A" + (I + C).ToString()].Value = dtTabla.Rows[I]["Emision"].ToString();
                            ws.Cells["B" + (I + C).ToString()].Value = dtTabla.Rows[I]["RUC"].ToString();
                            ws.Cells["C" + (I + C).ToString()].Value = dtTabla.Rows[I]["RazonSocial"].ToString();
                            ws.Cells["D" + (I + C).ToString()].Value = dtTabla.Rows[I]["AbvDdsc"].ToString();
                            ws.Cells["E" + (I + C).ToString()].Value = dtTabla.Rows[I]["Serie"].ToString();
                            ws.Cells["F" + (I + C).ToString()].Value = dtTabla.Rows[I]["Numero"].ToString();
                            ws.Cells["G" + (I + C).ToString()].Value = dtTabla.Rows[I]["TotalSoles"];
                            ws.Cells["H" + (I + C).ToString()].Value = dtTabla.Rows[I]["TotalDolares"];
                            ws.Cells["I" + (I + C).ToString()].Value = dtTabla.Rows[I]["FormaPago"].ToString();
                            ws.Cells["J" + (I + C).ToString()].Value = dtTabla.Rows[I]["NroOperacion"].ToString();

                            if (dtTabla.Rows.Count > I + 1)
                            {
                                if (dtTabla.Rows[I + 1]["Operacion"].ToString() != Operacion & dtTabla.Rows[I + 1]["MedioPago"].ToString() == MedioPago)
                                {
                                    C++;
                                    ws.Cells["F" + (I + C).ToString()].Value = dtTabla.Rows[I - 1]["Operacion"].ToString() + " " + dtTabla.Rows[I - 1]["MedioPago"].ToString();
                                    ws.Cells["F" + (I + C).ToString()].Style.Font.Bold = true;
                                    ws.Cells["G" + (I + C).ToString()].Formula = "SUM(G" + LIO.ToString() + ":G" + (I + C - 1).ToString() + ")";
                                    ws.Cells["G" + (I + C).ToString()].Style.Font.Bold = true;
                                    ws.Cells["H" + (I + C).ToString()].Formula = "SUM(H" + LIO.ToString() + ":H" + (I + C - 1).ToString() + ")";
                                    ws.Cells["H" + (I + C).ToString()].Style.Font.Bold = true;

                                }
                            }

                            if (dtTabla.Rows.Count == I + 1)
                            {
                                ws.Cells["F" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["Operacion"].ToString() + " " + dtTabla.Rows[I]["MedioPago"].ToString();
                                ws.Cells["F" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["G" + (I + C + 1).ToString()].Formula = "SUM(G" + LIO.ToString() + ":G" + (I + C).ToString() + ")";
                                ws.Cells["G" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["H" + (I + C + 1).ToString()].Formula = "SUM(H" + LIO.ToString() + ":H" + (I + C).ToString() + ")";
                                ws.Cells["H" + (I + C + 1).ToString()].Style.Font.Bold = true;


                                C++;
                                ws.Cells["F" + (I + C + 1).ToString()].Value = "TOTAL  " + dtTabla.Rows[I - 1]["MedioPago"].ToString();
                                ws.Cells["F" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["G" + (I + C + 1).ToString()].Formula = "=G" + LMI.ToString() + "+ G" + (I + C).ToString();
                                ws.Cells["G" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["H" + (I + C + 1).ToString()].Formula = "=H" + LMI.ToString() + "+ H" + (I + C).ToString();
                                ws.Cells["H" + (I + C + 1).ToString()].Style.Font.Bold = true;

                            }
                        }
                    }

     ///////////////////////////////////////////////////////////////////////////////////////////////////
                    else
                    {
                        //aca muestras los valores de la salida
                        ws.Cells["F" + (I + C).ToString()].Value = dtTabla.Rows[I - 1]["Operacion"].ToString() + " " + dtTabla.Rows[I - 1]["MedioPago"].ToString();
                        ws.Cells["F" + (I + C).ToString()].Style.Font.Bold = true;
                        ws.Cells["G" + (I + C).ToString()].Formula = "SUM(G" + LIO.ToString() + ":G" + (I + C - 1).ToString() + ")";
                        ws.Cells["G" + (I + C).ToString()].Style.Font.Bold = true;
                        ws.Cells["H" + (I + C).ToString()].Formula = "SUM(H" + LIO.ToString() + ":H" + (I + C - 1).ToString() + ")";
                        ws.Cells["H" + (I + C).ToString()].Style.Font.Bold = true;

                        //LMI = (I + C).ToString();

                        if (dtTabla.Rows[I - 1]["Operacion"].ToString() != "SALIDA")
                        {
                            SE = (8).ToString();
                            SS = (8).ToString();
                        }

                        //aca muestras los valores del total x medio de pago
                        C++;
                        ws.Cells["F" + (I + C).ToString()].Value = "TOTAL  " + dtTabla.Rows[I - 1]["MedioPago"].ToString();
                        ws.Cells["F" + (I + C).ToString()].Style.Font.Bold = true;
                        ws.Cells["G" + (I + C).ToString()].Formula = "=G" + LMI.ToString() + "+ G" + (I + C - 1).ToString();
                        ws.Cells["G" + (I + C).ToString()].Style.Font.Bold = true;
                        ws.Cells["H" + (I + C).ToString()].Formula = "=H" + LMI.ToString() + "+ H" + (I + C - 1).ToString();
                        ws.Cells["H" + (I + C).ToString()].Style.Font.Bold = true;
                        C++;
                        ws.Cells["A" + (I + C).ToString()].Value = dtTabla.Rows[I]["MedioPago"].ToString();
                        ws.Cells["A" + (I + C).ToString()].Style.Font.Bold = true;
                        MedioPago = dtTabla.Rows[I]["MedioPago"].ToString();
                        Operacion = dtTabla.Rows[I]["Operacion"].ToString();
                        LMI = LMINICIAL;
                        C++;
                        ws.Cells["B" + (I + C).ToString()].Value = dtTabla.Rows[I]["Operacion"].ToString();
                        ws.Cells["B" + (I + C).ToString()].Style.Font.Bold = true;

                        C++;
                        ws.Cells["A" + (I + C).ToString()].Value = dtTabla.Rows[I]["Emision"].ToString();
                        ws.Cells["B" + (I + C).ToString()].Value = dtTabla.Rows[I]["RUC"].ToString();
                        ws.Cells["C" + (I + C).ToString()].Value = dtTabla.Rows[I]["RazonSocial"].ToString();
                        ws.Cells["D" + (I + C).ToString()].Value = dtTabla.Rows[I]["AbvDdsc"].ToString();
                        ws.Cells["E" + (I + C).ToString()].Value = dtTabla.Rows[I]["Serie"].ToString();
                        ws.Cells["F" + (I + C).ToString()].Value = dtTabla.Rows[I]["Numero"].ToString();
                        ws.Cells["G" + (I + C).ToString()].Value = dtTabla.Rows[I]["TotalSoles"];
                        ws.Cells["H" + (I + C).ToString()].Value = dtTabla.Rows[I]["TotalDolares"];
                        ws.Cells["I" + (I + C).ToString()].Value = dtTabla.Rows[I]["FormaPago"].ToString();
                        ws.Cells["J" + (I + C).ToString()].Value = dtTabla.Rows[I]["NroOperacion"].ToString();


                        if (dtTabla.Rows.Count > I + 1)
                        {
                            if (dtTabla.Rows[I + 1]["Operacion"].ToString() != Operacion & dtTabla.Rows[I + 1]["MedioPago"].ToString() == MedioPago)
                            {
                                C++;
                                ws.Cells["F" + (I + C + 1).ToString()].Value = dtTabla.Rows[I - 1]["Operacion"].ToString() + " " + dtTabla.Rows[I - 1]["MedioPago"].ToString();
                                ws.Cells["F" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["G" + (I + C + 1).ToString()].Formula = "SUM(G" + LIO.ToString() + ":G" + (I + C - 1).ToString() + ")";
                                ws.Cells["G" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["H" + (I + C + 1).ToString()].Formula = "SUM(H" + LIO.ToString() + ":H" + (I + C - 1).ToString() + ")";
                                ws.Cells["H" + (I + C + 1).ToString()].Style.Font.Bold = true;
                            }
                        }

                        if (dtTabla.Rows.Count == I + 1)
                        {
                            ws.Cells["F" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["Operacion"].ToString() + " " + dtTabla.Rows[I]["MedioPago"].ToString();
                            ws.Cells["F" + (I + C + 1).ToString()].Style.Font.Bold = true;
                            ws.Cells["G" + (I + C + 1).ToString()].Formula = "SUM(G" + LIO.ToString() + ":G" + (I + C).ToString() + ")";
                            ws.Cells["G" + (I + C + 1).ToString()].Style.Font.Bold = true;
                            ws.Cells["H" + (I + C + 1).ToString()].Formula = "SUM(H" + LIO.ToString() + ":H" + (I + C).ToString() + ")";
                            ws.Cells["H" + (I + C + 1).ToString()].Style.Font.Bold = true;

                        }
                        //C++;
                        LIO = I + C;
                    }
                }

            }
            else
            {
                ws.Cells["A1"].LoadFromDataTable(dtTabla, true);
            }



            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_Reporte_Caja_Chica_Grupal()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 500000; i++)
                ws.DeleteRow(1);

            DocumentoVentaCabCE objLGProductosCE = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objLGProductosCN = new DocumentoVentaCabCN();

            String XmlDetalle = "";

            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(Request.QueryString["Codigos_Caja"]);

            foreach (dynamic item in jArr2)
            {
                XmlDetalle = XmlDetalle + "<D ";
                XmlDetalle = XmlDetalle + " Codigos_Caja = '" + item.Codigos_Caja + "'";
                XmlDetalle = XmlDetalle + " />";
            }

            XmlDetalle = "<R><XmlLC> " + XmlDetalle + "</XmlLC></R>";


            objLGProductosCE.CodAlmacen = Convert.ToInt32(Request.QueryString["CodSede"]);
            objLGProductosCE.Codigos = XmlDetalle;
            objLGProductosCE.CodEmpresa = Convert.ToInt32(Request.QueryString["CodEmpresa"]);
            objLGProductosCE.CodMedioPago = Convert.ToInt32(Request.QueryString["CodMedioPago"]);
            objLGProductosCE.coddoc = Convert.ToInt32(Request.QueryString["coddoc"]);



            DataTable dtTabla = null;

            dtTabla = objLGProductosCN.F_CajaChica_Detalle_Grupal_Excel(objLGProductosCE);

            if (dtTabla.Rows.Count != 0)
            {

                string MedioPago = dtTabla.Rows[0]["MedioPago"].ToString();
                string Operacion = dtTabla.Rows[0]["Operacion"].ToString();
                int C = 12;
                int LIO = 12;
                string LMINICIAL = "8";
                String LMI = LMINICIAL;
                string SE = "";
                string SS = "";
                int INDICE = 1;

                ws.Cells["F1"].Value = DateTime.Now.ToString("dd/MM/yyyy");
                ws.Cells["F2"].Value = DateTime.Now.ToString("hh:mm:ss");

                ws.Cells["A1"].Value = dtTabla.Rows[0]["Empresa"].ToString();
                ws.Cells["A2"].Value = "SUCURSAL " + dtTabla.Rows[0]["Sede"].ToString();
                ws.Cells["B3"].Value = Request["Titulo"].ToString();
                ws.Cells["B4"].Value = dtTabla.Rows[0]["Fecha"].ToString();
                ws.Cells["A5"].Value = "Caja ";
                ws.Cells["B5"].Value = dtTabla.Rows[0]["Caja"].ToString();
                ws.Cells["A6"].Value = "Usuario Generación :";
                ws.Cells["B6"].Value = dtTabla.Rows[0]["UsuarioGeneracion"].ToString();
                ws.Cells["A7"].Value = "Usuario Cierre ";
                ws.Cells["B7"].Value = dtTabla.Rows[0]["UsuarioLiquidacion"].ToString();
                ws.Cells["A8"].Value = "Fecha Cierre ";
                ws.Cells["B8"].Value = dtTabla.Rows[0]["FechaLiquidacion"].ToString();
                ws.Cells["A9"].Value = "Emision";
                ws.Cells["B9"].Value = "Razon Social";
                ws.Cells["C9"].Value = "T/D";
                ws.Cells["D9"].Value = "S/.";
                ws.Cells["E9"].Value = "US$";
                ws.Cells["F9"].Value = "F/P";
                ws.Cells["G9"].Value = "OBSERVACION";
                ws.Cells["A10"].Value = MedioPago;
                ws.Cells["A10"].Style.Font.Color.SetColor(Color.Black);
                ws.Cells["A10"].Style.Font.Bold = true;
                ws.Cells["B11"].Value = Operacion;
                ws.Cells["B11"].Style.Font.Color.SetColor(Color.Black);
                ws.Cells["B11"].Style.Font.Bold = true;
                ws.Column(1).Width = 18.77;
                ws.Column(2).Width = 91.77;
                ws.Column(3).Width = 23.30;
                ws.Column(4).Width = 10.02;
                ws.Column(5).Width = 10.02;
                ws.Column(6).Width = 18.87;
                ws.Column(7).Width = 62.20;
                ws.Row(1).Height = 15;
                ws.Row(2).Height = 15;
                ws.Row(3).Height = 15;
                ws.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                ws.Cells["A1"].Style.Font.Size = 16;
                ws.Cells["A2"].Style.Font.Size = 16;
                ws.Cells["B3"].Style.Font.Size = 16;
                ws.Cells["B4"].Style.Font.Size = 12;
                ws.Cells["A5:B5"].Style.Font.Size = 10;
                ws.Cells["A6:B6"].Style.Font.Size = 10;
                ws.Cells["A7:B7"].Style.Font.Size = 10;
                ws.Cells["A8:B8"].Style.Font.Size = 10;
                ws.Cells["A9:G9"].Style.Font.Size = 12;
                ws.Cells["A9:G9"].Style.Font.Bold = true;
                ws.Row(9).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells["A5:A8"].Style.Font.Bold = true;
                ws.Cells["A1:G1000"].Style.Font.Name = "Arial";
                ws.Cells["B3"].Style.Font.Bold = true;
                ws.Cells["A1"].Style.Font.Bold = true;
                ws.Cells["A2"].Style.Font.Bold = true;
                ws.Cells["A12:A1000"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Row(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Row(4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells["D12:D1000"].Style.Numberformat.Format = "#,##0.00";
                ws.Cells["E12:E1000"].Style.Numberformat.Format = "#,##0.00";
                ///////////////////////////////////////////////////
                for (int I = 0; I < dtTabla.Rows.Count; I++)
                {
                    ///////////////////////////////////////////////
                    if (dtTabla.Rows[I]["MedioPago"].ToString() == MedioPago)
                    {
                        if (dtTabla.Rows[I]["Operacion"].ToString() == Operacion)
                        {
                            ws.Cells["A" + (I + C).ToString()].Value = dtTabla.Rows[I]["Emision"].ToString();
                            ws.Cells["B" + (I + C).ToString()].Value = dtTabla.Rows[I]["RazonSocial"].ToString();
                            ws.Cells["C" + (I + C).ToString()].Value = dtTabla.Rows[I]["Documento"].ToString();
                            ws.Cells["D" + (I + C).ToString()].Value = dtTabla.Rows[I]["TotalSoles"];
                            ws.Cells["E" + (I + C).ToString()].Value = dtTabla.Rows[I]["TotalDolares"];
                            ws.Cells["F" + (I + C).ToString()].Value = dtTabla.Rows[I]["FormaPago"].ToString();
                            ws.Cells["G" + (I + C).ToString()].Value = dtTabla.Rows[I]["NroOperacion"].ToString();

                            if (dtTabla.Rows.Count > I + 1)
                            {
                                if (dtTabla.Rows[I + 1]["Operacion"].ToString() != Operacion & dtTabla.Rows[I + 1]["MedioPago"].ToString() == MedioPago)
                                {
                                    C++;

                                    if (I == 0)
                                        INDICE = 0;

                                    ws.Cells["C" + (I + C).ToString()].Value = dtTabla.Rows[I - INDICE]["Operacion"].ToString() + " " + dtTabla.Rows[I - INDICE]["MedioPago"].ToString();
                                    ws.Cells["C" + (I + C).ToString()].Style.Font.Bold = true;
                                    ws.Cells["D" + (I + C).ToString()].Formula = "SUM(D" + LIO.ToString() + ":D" + (I + C - 1).ToString() + ")";
                                    ws.Cells["D" + (I + C).ToString()].Style.Font.Bold = true;
                                    ws.Cells["E" + (I + C).ToString()].Formula = "SUM(E" + LIO.ToString() + ":E" + (I + C - 1).ToString() + ")";
                                    ws.Cells["E" + (I + C).ToString()].Style.Font.Bold = true;
                                    INDICE = 1;

                                    if (I == 0)
                                    {
                                        LMI = (C).ToString();
                                    }
                                    else
                                    {
                                        LMI = (I + C).ToString();
                                    }

                                }
                                //EN CASO QUE SOLO SEA 1 VALOR DE ENTRADA
                                //else
                                //{
                                //    C++;
                                //    ws.Cells["C" + (I + C).ToString()].Value = dtTabla.Rows[I]["Operacion"].ToString() + "1 " + dtTabla.Rows[I]["MedioPago"].ToString();
                                //    ws.Cells["C" + (I + C).ToString()].Style.Font.Bold = true;
                                //    ws.Cells["D" + (I + C).ToString()].Formula = "SUM(D" + LIO.ToString() + ":D" + (I + C).ToString() + ")";
                                //    ws.Cells["D" + (I + C).ToString()].Style.Font.Bold = true;
                                //    ws.Cells["E" + (I + C).ToString()].Formula = "SUM(E" + LIO.ToString() + ":E" + (I + C).ToString() + ")";
                                //    ws.Cells["E" + (I + C).ToString()].Style.Font.Bold = true;
                                //    //aca guarda los valores de la entrada
                                //    //SE = (CS-2).ToString();
                                //    //SS = (CS-2).ToString();
                                //    LMI = (I + C).ToString();
                                //}

                            }

                            if (dtTabla.Rows.Count == I + 1)
                            {
                                ws.Cells["C" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["Operacion"].ToString() + " " + dtTabla.Rows[I]["MedioPago"].ToString();
                                ws.Cells["C" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["D" + (I + C + 1).ToString()].Formula = "SUM(D" + LIO.ToString() + ":D" + (I + C).ToString() + ")";
                                ws.Cells["D" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["E" + (I + C + 1).ToString()].Formula = "SUM(E" + LIO.ToString() + ":E" + (I + C).ToString() + ")";
                                ws.Cells["E" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                //aca muestras el total final
                                C++;

                                SE = (LIO - 2).ToString();
                                SS = (LIO - 2).ToString();

                                //    LMI = (LIO - 2).ToString();

                                //if (dtTabla.Rows[I]["Operacion"].ToString() != "SALIDA")
                                //{
                                //    SE=  (8).ToString();
                                //    SS = (8).ToString();
                                //}
                                ws.Cells["C" + (I + C + 1).ToString()].Value = "TOTAL  " + dtTabla.Rows[I]["MedioPago"].ToString();
                                ws.Cells["C" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["D" + (I + C + 1).ToString()].Formula = "=D" + LMI.ToString() + "+ D" + (I + C).ToString();
                                ws.Cells["D" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["E" + (I + C + 1).ToString()].Formula = "=E" + LMI.ToString() + "+ E" + (I + C).ToString();
                                ws.Cells["E" + (I + C + 1).ToString()].Style.Font.Bold = true;


                            }
                        }
                        else
                        {
                            ws.Cells["B" + (I + C).ToString()].Value = dtTabla.Rows[I]["Operacion"].ToString();
                            ws.Cells["B" + (I + C).ToString()].Style.Font.Color.SetColor(Color.Black);
                            ws.Cells["B" + (I + C).ToString()].Style.Font.Bold = true;
                            Operacion = dtTabla.Rows[I]["Operacion"].ToString();

                            C++;
                            LIO = I + C;

                            ws.Cells["A" + (I + C).ToString()].Value = dtTabla.Rows[I]["Emision"].ToString();
                            ws.Cells["B" + (I + C).ToString()].Value = dtTabla.Rows[I]["RazonSocial"].ToString();
                            ws.Cells["C" + (I + C).ToString()].Value = dtTabla.Rows[I]["Documento"].ToString();
                            ws.Cells["D" + (I + C).ToString()].Value = dtTabla.Rows[I]["TotalSoles"];
                            ws.Cells["E" + (I + C).ToString()].Value = dtTabla.Rows[I]["TotalDolares"];
                            ws.Cells["F" + (I + C).ToString()].Value = dtTabla.Rows[I]["FormaPago"].ToString();
                            ws.Cells["G" + (I + C).ToString()].Value = dtTabla.Rows[I]["NroOperacion"].ToString();

                            if (dtTabla.Rows.Count > I + 1)
                            {
                                if (dtTabla.Rows[I + 1]["Operacion"].ToString() != Operacion & dtTabla.Rows[I + 1]["MedioPago"].ToString() == MedioPago)
                                {
                                    C++;
                                    ws.Cells["C" + (I + C).ToString()].Value = dtTabla.Rows[I - 1]["Operacion"].ToString() + " " + dtTabla.Rows[I - 1]["MedioPago"].ToString();
                                    ws.Cells["C" + (I + C).ToString()].Style.Font.Bold = true;
                                    ws.Cells["D" + (I + C).ToString()].Formula = "SUM(D" + LIO.ToString() + ":D" + (I + C - 1).ToString() + ")";
                                    ws.Cells["D" + (I + C).ToString()].Style.Font.Bold = true;
                                    ws.Cells["E" + (I + C).ToString()].Formula = "SUM(E" + LIO.ToString() + ":E" + (I + C - 1).ToString() + ")";
                                    ws.Cells["E" + (I + C).ToString()].Style.Font.Bold = true;

                                }
                            }

                            if (dtTabla.Rows.Count == I + 1)
                            {
                                ws.Cells["C" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["Operacion"].ToString() + " " + dtTabla.Rows[I]["MedioPago"].ToString();
                                ws.Cells["C" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["D" + (I + C + 1).ToString()].Formula = "SUM(D" + LIO.ToString() + ":D" + (I + C).ToString() + ")";
                                ws.Cells["D" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["E" + (I + C + 1).ToString()].Formula = "SUM(E" + LIO.ToString() + ":E" + (I + C).ToString() + ")";
                                ws.Cells["E" + (I + C + 1).ToString()].Style.Font.Bold = true;


                                C++;
                                ws.Cells["C" + (I + C + 1).ToString()].Value = "TOTAL  " + dtTabla.Rows[I - 1]["MedioPago"].ToString();
                                ws.Cells["C" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["D" + (I + C + 1).ToString()].Formula = "=D" + LMI.ToString() + "+ D" + (I + C).ToString();
                                ws.Cells["D" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["E" + (I + C + 1).ToString()].Formula = "=E" + LMI.ToString() + "+ E" + (I + C).ToString();
                                ws.Cells["E" + (I + C + 1).ToString()].Style.Font.Bold = true;

                            }
                        }
                    }

     ///////////////////////////////////////////////////////////////////////////////////////////////////
                    else
                    {
                        //aca muestras los valores de la salida
                        ws.Cells["C" + (I + C).ToString()].Value = dtTabla.Rows[I - 1]["Operacion"].ToString() + " " + dtTabla.Rows[I - 1]["MedioPago"].ToString();
                        ws.Cells["C" + (I + C).ToString()].Style.Font.Bold = true;
                        ws.Cells["D" + (I + C).ToString()].Formula = "SUM(D" + LIO.ToString() + ":D" + (I + C - 1).ToString() + ")";
                        ws.Cells["D" + (I + C).ToString()].Style.Font.Bold = true;
                        ws.Cells["E" + (I + C).ToString()].Formula = "SUM(E" + LIO.ToString() + ":E" + (I + C - 1).ToString() + ")";
                        ws.Cells["E" + (I + C).ToString()].Style.Font.Bold = true;

                        //LMI = (I + C).ToString();

                        if (dtTabla.Rows[I - 1]["Operacion"].ToString() != "SALIDA")
                        {
                            SE = (8).ToString();
                            SS = (8).ToString();
                        }

                        //aca muestras los valores del total x medio de pago
                        C++;
                        ws.Cells["C" + (I + C).ToString()].Value = "TOTAL  " + dtTabla.Rows[I - 1]["MedioPago"].ToString();
                        ws.Cells["C" + (I + C).ToString()].Style.Font.Bold = true;
                        ws.Cells["D" + (I + C).ToString()].Formula = "=D" + LMI.ToString() + "+ D" + (I + C - 1).ToString();
                        ws.Cells["D" + (I + C).ToString()].Style.Font.Bold = true;
                        ws.Cells["E" + (I + C).ToString()].Formula = "=E" + LMI.ToString() + "+ E" + (I + C - 1).ToString();
                        ws.Cells["E" + (I + C).ToString()].Style.Font.Bold = true;
                        C++;
                        ws.Cells["A" + (I + C).ToString()].Value = dtTabla.Rows[I]["MedioPago"].ToString();
                        ws.Cells["A" + (I + C).ToString()].Style.Font.Bold = true;
                        MedioPago = dtTabla.Rows[I]["MedioPago"].ToString();
                        Operacion = dtTabla.Rows[I]["Operacion"].ToString();
                        LMI = LMINICIAL;
                        C++;
                        ws.Cells["B" + (I + C).ToString()].Value = dtTabla.Rows[I]["Operacion"].ToString();
                        ws.Cells["B" + (I + C).ToString()].Style.Font.Bold = true;


                        ws.Cells["A" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["Emision"].ToString();
                        ws.Cells["B" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["RazonSocial"].ToString();
                        ws.Cells["C" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["Documento"].ToString();
                        ws.Cells["D" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["TotalSoles"];
                        ws.Cells["E" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["TotalDolares"];
                        ws.Cells["F" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["FormaPago"].ToString();
                        ws.Cells["G" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["NroOperacion"].ToString();


                        if (dtTabla.Rows.Count > I + 1)
                        {
                            if (dtTabla.Rows[I + 1]["Operacion"].ToString() != Operacion & dtTabla.Rows[I + 1]["MedioPago"].ToString() == MedioPago)
                            {
                                C++;
                                ws.Cells["C" + (I + C + 1).ToString()].Value = dtTabla.Rows[I - 1]["Operacion"].ToString() + " " + dtTabla.Rows[I - 1]["MedioPago"].ToString();
                                ws.Cells["C" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["D" + (I + C + 1).ToString()].Formula = "SUM(D" + LIO.ToString() + ":D" + (I + C - 1).ToString() + ")";
                                ws.Cells["D" + (I + C + 1).ToString()].Style.Font.Bold = true;
                                ws.Cells["E" + (I + C + 1).ToString()].Formula = "SUM(E" + LIO.ToString() + ":E" + (I + C - 1).ToString() + ")";
                                ws.Cells["E" + (I + C + 1).ToString()].Style.Font.Bold = true;
                            }
                        }

                        if (dtTabla.Rows.Count == I + 1)
                        {
                            ws.Cells["C" + (I + C + 1).ToString()].Value = dtTabla.Rows[I]["Operacion"].ToString() + " " + dtTabla.Rows[I]["MedioPago"].ToString();
                            ws.Cells["C" + (I + C + 1).ToString()].Style.Font.Bold = true;
                            ws.Cells["D" + (I + C + 1).ToString()].Formula = "SUM(D" + LIO.ToString() + ":D" + (I + C).ToString() + ")";
                            ws.Cells["D" + (I + C + 1).ToString()].Style.Font.Bold = true;
                            ws.Cells["E" + (I + C + 1).ToString()].Formula = "SUM(E" + LIO.ToString() + ":E" + (I + C).ToString() + ")";
                            ws.Cells["E" + (I + C + 1).ToString()].Style.Font.Bold = true;

                        }
                        C++;
                        LIO = I + C;
                    }
                }

            }
            else
            {
                ws.Cells["A1"].LoadFromDataTable(dtTabla, true);
            }

            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_Reporte_CP()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());
            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 10000; i++)
                ws.DeleteRow(1);

            NotaIngresoSalidaCabCE objEntidad = new NotaIngresoSalidaCabCE();
            NotaIngresoSalidaCabCN objOperacion = new NotaIngresoSalidaCabCN();
            
            objEntidad.Desde = Convert.ToDateTime(Request["Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(Request["Hasta"]);
            objEntidad.chkDevolucion = Convert.ToInt32(Request["ChkDevolucion"]);

            DataTable dtTabla = null;

            dtTabla = objOperacion.F_DOCUMENTOVENTACAB_LISTAR_CP(objEntidad);
                 
            ws.Cells["A1"].LoadFromDataTable(dtTabla, true);

            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_Contabilidad_Registrocobranzas()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 4; i < 50000; i++)
                ws.DeleteRow(4);

            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            objEntidad.CodAlmacen = Convert.ToInt32(Request["CodAlmacen"]);
            objEntidad.Desde = Convert.ToDateTime(Request["Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(Request["Hasta"]);
            objEntidad.Numero = Convert.ToInt32(Request["Numero"]);

            DataTable dtTabla = null;

            dtTabla = objOperacion.P_Contabilidad_Registrocobranzas(objEntidad);

            ws.Cells["A4"].LoadFromDataTable(dtTabla, true);
            ws.DeleteRow(4);
            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_CobranzasPeriodo()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 500; i++)
                ws.DeleteRow(1);

            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            objEntidad.CodCliente = Convert.ToInt32(Request["CodCliente"]);
            objEntidad.CodMoneda = Convert.ToInt32(Request["CodMoneda"]);
            objEntidad.Desde = Convert.ToDateTime(Request["Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(Request["Hasta"]);
            objEntidad.FlagTodo = Convert.ToInt32(Request["FlagTodo"]);

            DataTable dtTabla = null;

            dtTabla = objOperacion.F_COBRANZAS_POR_PERIODO(objEntidad);

            ws.Cells["A1"].LoadFromDataTable(dtTabla, true);
          
            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_Contabilidad_ClientesNuevos()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 2; i < 50000; i++)
                ws.DeleteRow(1);

            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            objEntidad.Periodo = Convert.ToInt32(Request["Periodo"]);
      
            DataTable dtTabla = null;

            dtTabla = objOperacion.F_Contabilidad_ClientesNuevos(objEntidad);

            ws.Cells["A1"].LoadFromDataTable(dtTabla, true);
            //ws.DeleteRow(4);
            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_CajaBanco_ReporteTarjetaDeposito()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 500000; i++)
                ws.DeleteRow(12);

            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            objEntidad.CodAlmacen = Convert.ToInt32(Request.QueryString["CodAlmacen"]);
            objEntidad.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
            objEntidad.CodMedioPago = Convert.ToInt32(Request.QueryString["CodMedioPago"]);
            objEntidad.CodCtaBancaria = Convert.ToInt32(Request.QueryString["CodCtaBancaria"]);
            objEntidad.CodCajaFisica = Convert.ToInt32(Request.QueryString["CodCajaFisica"]);

            DataTable dtTabla = null;

            dtTabla = objOperacion.F_COBRANZASCAB_CUENTABANCARIA(objEntidad);

            ws.Cells["F2"].Value = DateTime.Now.ToString("dd/MM/yyyy") + ' ' + DateTime.Now.ToString("HH:mm:ss");
            ws.Cells["A3"].Value = dtTabla.Rows[0]["Empresa"].ToString();
            ws.Cells["A4"].Value = dtTabla.Rows[0]["Sucursal"].ToString();
            ws.Cells["A7"].Value = Request["SubTitulo"].ToString();
            ws.Cells["C9"].Value = dtTabla.Rows[0]["CuentaBancaria"].ToString(); 

            ws.Cells["A11"].LoadFromDataTable(dtTabla, true);
            ws.Cells["E11"].Value = "TOTAL + " + dtTabla.Rows[0]["ComisionTarjeta"].ToString() + '%';       
            ws.Cells["D:D"].Style.Numberformat.Format = null;
            ws.Cells["D:D"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["E:E"].Style.Numberformat.Format = null;
            ws.Cells["E:E"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["F:F"].Style.Numberformat.Format = null;
            ws.Cells["F:F"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["G:G"].Style.Numberformat.Format = null;
            ws.Cells["G:G"].Style.Numberformat.Format = "#,##0.00";   
     
            if (dtTabla.Rows.Count > 0)
            {                 
                ws.Cells["C" + (dtTabla.Rows.Count + 12).ToString()].Value = "TOTAL";       
                ws.Cells["D" + (dtTabla.Rows.Count + 12).ToString()].Value = (decimal)dtTabla.Compute("SUM([TOTAL])", null);
                ws.Cells["E" + (dtTabla.Rows.Count + 12).ToString()].Value = (decimal)dtTabla.Compute("SUM([TOTAL3])", null);
                ws.Cells["F" + (dtTabla.Rows.Count + 12).ToString()].Value = (decimal)dtTabla.Compute("SUM([VOUCHER])", null);
                ws.Cells["G" + (dtTabla.Rows.Count + 12).ToString()].Value = (decimal)dtTabla.Compute("SUM([DEPOSITO])", null);
                                                     
                ws.Cells["C" + (dtTabla.Rows.Count + 12).ToString()].Style.Font.Bold = true;
                ws.Cells["D" + (dtTabla.Rows.Count + 12).ToString()].Style.Font.Bold = true;
                ws.Cells["E" + (dtTabla.Rows.Count + 12).ToString()].Style.Font.Bold = true;
                ws.Cells["F" + (dtTabla.Rows.Count + 12).ToString()].Style.Font.Bold = true;
                ws.Cells["G" + (dtTabla.Rows.Count + 12).ToString()].Style.Font.Bold = true;
            }

            ws.DeleteColumn(12); ws.DeleteColumn(11);
            ws.DeleteColumn(10); ws.DeleteColumn(9);
        
            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }

        public void P_CajaBanco_LiquidacionCaja()
        {
            FileInfo newFile = new FileInfo(Server.MapPath(Request["NombreArchivo"]).ToString());

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[Request["NombreHoja"].ToString()];

            for (int i = 1; i < 500000; i++)
                ws.DeleteRow(11);

            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            objEntidad.CodMoneda = Convert.ToInt32(Request["CodMoneda"]);
            objEntidad.Desde = Convert.ToDateTime(Request["Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(Request["Hasta"]);

            DataTable dtTabla = null;

            dtTabla = objOperacion.F_LiquidacionCajaCab_REPORTE(objEntidad);

            ws.Cells["F2"].Value = DateTime.Now.ToString("dd/MM/yyyy") + ' ' + DateTime.Now.ToString("HH:mm:ss");
            ws.Cells["A3"].Value = dtTabla.Rows[0]["Empresa"].ToString();
            ws.Cells["A4"].Value ="SUCURSAL : " + dtTabla.Rows[0]["Sucursal"].ToString();
            ws.Cells["A7"].Value = Request["SubTitulo"].ToString();

            if (Convert.ToInt32(Request["CodMoneda"])==1)
                ws.Cells["A9"].Value = "MONEDA EN SOLES";
            else
                ws.Cells["A9"].Value = "MONEDA EN DOLARES";

            ws.Cells["A11"].LoadFromDataTable(dtTabla, true);
            ws.DeleteRow(11);         
            ws.Cells["D:D"].Style.Numberformat.Format = null;
            ws.Cells["D:D"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["E:E"].Style.Numberformat.Format = null;
            ws.Cells["E:E"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["F:F"].Style.Numberformat.Format = null;
            ws.Cells["F:F"].Style.Numberformat.Format = "#,##0.00";
            ws.Cells["G:G"].Style.Numberformat.Format = null;
            ws.Cells["G:G"].Style.Numberformat.Format = "#,##0.00";

            if (dtTabla.Rows.Count > 0)
            {
                ws.Cells["C" + (dtTabla.Rows.Count + 11).ToString()].Value = "TOTAL";
                ws.Cells["D" + (dtTabla.Rows.Count + 11).ToString()].Value = (decimal)dtTabla.Compute("SUM([EFECTIVO])", null);
                ws.Cells["E" + (dtTabla.Rows.Count + 11).ToString()].Value = (decimal)dtTabla.Compute("SUM([FACTURA])", null);
                ws.Cells["F" + (dtTabla.Rows.Count + 11).ToString()].Value = (decimal)dtTabla.Compute("SUM([NOTAVENTA])", null);
                ws.Cells["G" + (dtTabla.Rows.Count + 11).ToString()].Value = (decimal)dtTabla.Compute("SUM([TOTAL])", null);

                ws.Cells["C" + (dtTabla.Rows.Count + 11).ToString()].Style.Font.Bold = true;
                ws.Cells["D" + (dtTabla.Rows.Count + 11).ToString()].Style.Font.Bold = true;
                ws.Cells["E" + (dtTabla.Rows.Count + 11).ToString()].Style.Font.Bold = true;
                ws.Cells["F" + (dtTabla.Rows.Count + 11).ToString()].Style.Font.Bold = true;
                ws.Cells["G" + (dtTabla.Rows.Count + 11).ToString()].Style.Font.Bold = true;
            }

            ws.DeleteColumn(9);
            ws.DeleteColumn(8);

            pck.Save();

            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["NombreArchivo"].ToString());
            Response.TransmitFile(Server.MapPath(Request["NombreArchivo"].ToString()));
            Response.End();
        }
    }
}