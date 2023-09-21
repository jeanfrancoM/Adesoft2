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

namespace SistemaInventario.Reportes
{
    public partial class ConstruirExcel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(Request["CodMenu"]))
            {
                case 1:
                    P_RegistroVentas();
                    break;
                /*case 2:
                    P_RegistroVentasProformas();
                    break;
                case 3:
                    P_Comisiones();
                    break;
                case 4:
                    P_ConsultaProductos();
                    break;
                case 5:
                    P_Ventas();
                    break;
                case 6:
                    P_LetrasPorCobrarPorVencer();
                    break;
                case 7:
                    F_DocumentoVentaCab_Listar_NCSinAplicar();
                    break;
                case 8:
                    F_ListarClientes();
                    break;
                case 9:
                    F_DocumentoVentaCab_LetrasProtestadas();
                    break;*/
            }
        }
           
        public void P_RegistroVentas()
        {
            FileInfo newFile = new FileInfo(Server.MapPath("RegistroVentas.xlsx"));

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets["VENTAS"];

            for (int i = 2; i < 100000; i++)
                ws.DeleteRow(2);

            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            objEntidad.CodEmpresa = Convert.ToInt32(Request["CodEmpresa"]);
            objEntidad.Desde = Convert.ToDateTime(Request["Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(Request["Hasta"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(Request["CodTipoDoc"]);
            objEntidad.CodCliente = Convert.ToInt32(Request["CodCtaCte"]);
            objEntidad.DesdeInt = int.Parse(objEntidad.Desde.ToString("yyyyMMdd"));
            objEntidad.HastaInt = int.Parse(objEntidad.Hasta.ToString("yyyyMMdd"));
            int AsignarTotal = 0; try { AsignarTotal = Convert.ToInt32(Request.QueryString["AsignarTotal"]); }
            catch (Exception) { };

            DataTable dtTabla = null;

            dtTabla = objOperacion.F_DocumentoVentaCab_RegistroVentasContabilidad_Excel(objEntidad);

            ws.Cells["A1"].LoadFromDataTable(dtTabla, true);


            if (dtTabla.Rows.Count > 0) {
                if (AsignarTotal != 0) {

                    decimal monto = 0;
                    try {
                        monto = Convert.ToDecimal(dtTabla.Compute("Sum(Total)", ""));
                        ws.Cells["R" + (dtTabla.Rows.Count + 2).ToString()].Value = monto;
                    }
                    catch (Exception) { };
                    
                }
            }

            //ws.DeleteRow(2);
            //ws.Row(0).Style.Font.Bold = true;
            //Ejemplos de como se deben manipular algunos campos
            //ws.DeleteRow(8);
            //ws.DeleteColumn(20);
            //ws.Cells["B2"].Value = dtTabla.Rows[0]["Periodo"].ToString();
            //object BaseImponibleSuma;
            //BaseImponibleSuma = dtTabla.Compute("Sum(BaseImponible)", "");
            //ws.Cells["L" + Convert.ToString(dtTabla.Rows.Count + 8)].Value = BaseImponibleSuma.ToString();
            //ws.Cells["L" + Convert.ToString(dtTabla.Rows.Count + 8)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

            ws.Cells["g:g"].Style.Numberformat.Format = null;
            ws.Cells["g:g"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["o:o"].Style.Numberformat.Format = null;
            //ws.Cells["o:o"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["r:r"].Style.Numberformat.Format = null;
            //ws.Cells["r:r"].Style.Numberformat.Format = "#,##0.00";
            //ws.Cells["u:u"].Style.Numberformat.Format = null;

            //ws.Cells["c:c"].Style.Numberformat.Format = null;
            //ws.Cells["c:c"].Style.Numberformat.Format = "00/00/0000";


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
            // MemoryStream msMemoria = null;
            //msMemoria = (MemoryStream)pck.ExportToStream(ExportFormatType.PortableDocFormat);
            
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=RegistroVentas.xlsx");
            Response.TransmitFile(Server.MapPath("RegistroVentas.xlsx"));
            Response.End();
        }

        /*public void P_RegistroVentasProformas()
        {
            FileInfo newFile = new FileInfo(Server.MapPath("RegistroVentaProformas.xlsx"));

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets["VENTAS"];

            for (int i = 2; i < 100000; i++)
                ws.DeleteRow(2);

            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            objEntidad.CodEmpresa = Convert.ToInt32(Request["CodEmpresa"]);
            objEntidad.Desde = Convert.ToDateTime(Request["Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(Request["Hasta"]);
            objEntidad.CodCliente = Convert.ToInt32(Request["CodCtaCte"]);
            objEntidad.DesdeInt = int.Parse(objEntidad.Desde.ToString("yyyyMMdd"));
            objEntidad.HastaInt = int.Parse(objEntidad.Hasta.ToString("yyyyMMdd"));
            int AsignarTotal = 0; try { AsignarTotal = Convert.ToInt32(Request.QueryString["AsignarTotal"]); }
            catch (Exception) { };

            DataTable dtTabla = null;

            dtTabla = objOperacion.F_DocumentoVentaCab_RegistroVentas_Proformas_Excel(objEntidad);

            ws.Cells["A1"].LoadFromDataTable(dtTabla, true);
            //ws.DeleteRow(2);
            //ws.Row(0).Style.Font.Bold = true;
            //Ejemplos de como se deben manipular algunos campos
            //ws.DeleteRow(8);
            //ws.DeleteColumn(20);
            //ws.Cells["B2"].Value = dtTabla.Rows[0]["Periodo"].ToString();
            object BaseImponibleSuma;
            BaseImponibleSuma = dtTabla.Compute("Sum(Total)", "");
            //ws.Cells["L" + Convert.ToString(dtTabla.Rows.Count + 8)].Value = BaseImponibleSuma.ToString();
            //ws.Cells["L" + Convert.ToString(dtTabla.Rows.Count + 8)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

            ws.Cells["I:I"].Style.Numberformat.Format = null;
            ws.Cells["I:I"].Style.Numberformat.Format = "#,##0.00";

            //ws.Cells["c:c"].Style.Numberformat.Format = null;
            //ws.Cells["c:c"].Style.Numberformat.Format = "00/00/0000";


            //String Cadena = "";
            //Cadena ="A8:S8," +  "A" + Convert.ToString(dtTabla.Rows.Count + 8) + ":" + "S" + Convert.ToString(dtTabla.Rows.Count + 8);

            //using (ExcelRange rng = ws.Cells[Cadena])
            //{
            //    rng.Style.Font.Bold = true;
            //    rng.Style.Font.SetFromFont(new Font("Arial", 10));
            //    rng.AutoFitColumns();
            //}

            ws.Cells["G" + Convert.ToString(dtTabla.Rows.Count + 3)].Value = "TOTALES";
            ws.Cells["H" + Convert.ToString(dtTabla.Rows.Count + 3)].Value = "$";

            string m = BaseImponibleSuma.ToString();
            ws.Cells["I" + Convert.ToString(dtTabla.Rows.Count + 3)].Value = decimal.Parse(m);

            ws.Cells["I:I"].Style.Numberformat.Format = null;
            ws.Cells["I:I"].Style.Numberformat.Format = "#,##0.00";

            pck.Save();
            //System.Diagnostics.Process.Start(Server.MapPath("RegistroVentas.xlsx"));
            MemoryStream msMemoria = null;
            //msMemoria = (MemoryStream)pck.ExportToStream(ExportFormatType.PortableDocFormat);

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=RegistroVentaProformas.xlsx");
            Response.TransmitFile(Server.MapPath("RegistroVentaProformas.xlsx"));
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

                //dtTabla = objOperacion.F_DocumentoVentaCab_RegistroVentas_Excel(objEntidad);

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

        public void P_Comisiones()
        {
            FileInfo newFile = new FileInfo(Server.MapPath("Comisiones.xlsx"));

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets["COMISIONES"];
            
            for (int i = 2; i < 100000; i++)
                ws.DeleteRow(2);

            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            objEntidad.CodComisionCab = Convert.ToInt32(Request["CodComisionCab"]);
 
            DataTable dtTablaR = null;

            dtTablaR = objOperacion.F_COMISIONES_CONSULTA_LOTES(objEntidad);

            if (dtTablaR.Rows.Count > 0)
            {
                ws.Cells["A1"].Value = "CUADRE REALIZADO EL " + dtTablaR.Rows[0]["Operacion"] + " CON UN RANGO DE " + dtTablaR.Rows[0]["Desde"] + " A " + dtTablaR.Rows[0]["Hasta"];
                ws.Cells["A1"].Style.Font.Bold = true;
            }

            int iFila = 0;
            foreach (DataRow R in dtTablaR.Rows)
            {
                objEntidad.NroClasificacionLote = Convert.ToInt32(R["NroLote"]);
                DataTable dtTablaDetalles = objOperacion.F_DOCUMENTOVENTACAB_COMISIONES_DETALLE(objEntidad);

                if (dtTablaDetalles.Rows.Count > 0)
                {
                    //ENCABEZADO DE GRUPO
                    iFila += 3;
                    ws.Cells["A" + iFila.ToString()].Value = R["DescripcionLote"].ToString();
                    ws.Cells["A" + iFila.ToString()].Style.Font.Bold = true;
                    
                    //CUERPO DE GRUPO
                    iFila += 2;
                    ws.Cells["A" + iFila.ToString()].LoadFromDataTable(dtTablaDetalles, true);
                    
                    //TOTAL GRUPO
                    iFila += dtTablaDetalles.Rows.Count + 1;
                    object BaseImponibleSuma;
                    BaseImponibleSuma = dtTablaDetalles.Compute("Sum(VNVC)", "");
                    string m = BaseImponibleSuma.ToString();
                    ws.Cells["H" + iFila.ToString()].Value = decimal.Parse(m);
                    ws.Cells["H" + iFila.ToString()].Style.Font.Bold = true;

                    //PORCENTAJE
                    iFila += 1;
                    ws.Cells["G" + iFila.ToString()].Value = "PORCENTAJE";
                    ws.Cells["G" + iFila.ToString()].Style.Font.Bold = true;
                    ws.Cells["H" + iFila.ToString()].Value = (Convert.ToDecimal(m) * Convert.ToDecimal(dtTablaR.Rows[0]["PorcentajeComision"]));
                    ws.Cells["H" + iFila.ToString()].Style.Font.Bold = true;
                }                
            }
            ws.DeleteColumn(18);
            ws.DeleteColumn(19);

            pck.Save();
   
            MemoryStream msMemoria = null;

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Comisiones.xlsx");
            Response.TransmitFile(Server.MapPath("Comisiones.xlsx"));
            Response.End();
        }

        public void P_ConsultaProductos()
        {
            FileInfo newFile = new FileInfo(Server.MapPath("ListaProductos.xlsx"));

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets["PRODUCTOS"];

            for (int i = 2; i < 100000; i++)
                ws.DeleteRow(1);

            LGProductosCE objEntidad = null;
            LGProductosCN objOperacion = null;

            DataTable dtTabla = null;

            objEntidad = new LGProductosCE();

            objEntidad.CodAlmacen = Convert.ToInt32(Request["CodAlmacen"]);
            objEntidad.DscProducto = Convert.ToString(Request["DscProducto"]).Replace("--porcentaje--", "%");
            objEntidad.CodFamilia = Convert.ToString(Request["CodFamilia"]);

            objOperacion = new LGProductosCN();

            dtTabla = objOperacion.F_LGProductos_Listar_Mantenimiento(objEntidad);

            ws.Cells["A1"].LoadFromDataTable(dtTabla, true);
            ws.DeleteColumn(10);
            pck.Save();

            MemoryStream msMemoria = null;
  
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=ListaProductos.xlsx");
            Response.TransmitFile(Server.MapPath("ListaProductos.xlsx"));
            Response.End();
        }

        public void P_Ventas()
        {
            FileInfo newFile = new FileInfo(Server.MapPath("Ventas.xlsx"));

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets["VENTAS"];

            for (int i = 2; i < 100000; i++)
                ws.DeleteRow(2);

            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            objEntidad.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
            objEntidad.CodEmpresa = Convert.ToInt32(Request.QueryString["CodEmpresa"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);
            objEntidad.CodCliente = Convert.ToInt32(Request.QueryString["CodCtaCte"]);


            DataTable dtTabla = null;

            dtTabla = objOperacion.F_DocumentoVentaCab_Ventas(objEntidad);

            ws.Cells["A1"].LoadFromDataTable(dtTabla, true);

            ws.Cells["F:F"].Style.Numberformat.Format = null;
            ws.Cells["F:F"].Style.Numberformat.Format = "#,##0.00";


            pck.Save();
            //System.Diagnostics.Process.Start(Server.MapPath("RegistroVentas.xlsx"));
            MemoryStream msMemoria = null;
            //msMemoria = (MemoryStream)pck.ExportToStream(ExportFormatType.PortableDocFormat);

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Ventas.xlsx");
            Response.TransmitFile(Server.MapPath("Ventas.xlsx"));
            Response.End();
        }

        public void P_LetrasPorCobrarPorVencer()
        {
            FileInfo newFile = new FileInfo(Server.MapPath("ClientesLetrasPorCobrarPorVencer.xlsx"));

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets["LETRAS"];

            for (int i = 2; i < 100000; i++)
                ws.DeleteRow(2);

            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            //objEntidad.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
            //objEntidad.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
            //objEntidad.CodEmpresa = Convert.ToInt32(Request.QueryString["CodEmpresa"]);
            //objEntidad.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);
            //objEntidad.CodCliente = Convert.ToInt32(Request.QueryString["CodCtaCte"]);


            DataTable dtTabla = null;

            dtTabla = objOperacion.F_LetrasPorVencer(objEntidad);

            ws.Cells["A2"].LoadFromDataTable(dtTabla,false);

            ws.Cells["B:B"].Style.Numberformat.Format = null;
            ws.Cells["B:B"].Style.Numberformat.Format = "#,##0.00";


            pck.Save();
            //System.Diagnostics.Process.Start(Server.MapPath("RegistroVentas.xlsx"));
            MemoryStream msMemoria = null;
            //msMemoria = (MemoryStream)pck.ExportToStream(ExportFormatType.PortableDocFormat);

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=ClientesLetrasPorCobrarPorVencer.xlsx");
            Response.TransmitFile(Server.MapPath("ClientesLetrasPorCobrarPorVencer.xlsx"));
            Response.End();
        }

        public void F_DocumentoVentaCab_Listar_NCSinAplicar()
        {
            FileInfo newFile = new FileInfo(Server.MapPath("NCSinAplicar.xlsx"));

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets["NC"];

            for (int i = 2; i < 100000; i++)
                ws.DeleteRow(2);

            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            //objEntidad.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
            //objEntidad.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
            //objEntidad.CodEmpresa = Convert.ToInt32(Request.QueryString["CodEmpresa"]);
            //objEntidad.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);
            //objEntidad.CodCliente = Convert.ToInt32(Request.QueryString["CodCtaCte"]);


            DataTable dtTabla = null;

            dtTabla = objOperacion.F_DocumentoVentaCab_Listar_NCSinAplicar(objEntidad);

            ws.Cells["A2"].LoadFromDataTable(dtTabla, false);

            //ws.Cells["B:B"].Style.Numberformat.Format = null;
            //ws.Cells["B:B"].Style.Numberformat.Format = "#,##0.00";


            pck.Save();
            //System.Diagnostics.Process.Start(Server.MapPath("RegistroVentas.xlsx"));
            MemoryStream msMemoria = null;
            //msMemoria = (MemoryStream)pck.ExportToStream(ExportFormatType.PortableDocFormat);

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=NCSinAplicar.xlsx");
            Response.TransmitFile(Server.MapPath("NCSinAplicar.xlsx"));
            Response.End();
        }

        public void F_ListarClientes()
        {
            FileInfo newFile = new FileInfo(Server.MapPath("ExcelR.xlsx"));

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets["REPORTE"];

            for (int i = 2; i < 100000; i++)
                ws.DeleteRow(2);

            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.RazonSocial = Convert.ToString(Request.QueryString["Filtro_Descripcion"]);
            objEntidad.CodTipoCtacte = 1;

            objOperacion = new TCCuentaCorrienteCN();

            DataTable dtTabla = null;

            dtTabla = objOperacion.F_TCCuentaCorriente_Listar(objEntidad);

            ws.Cells["A1"].LoadFromDataTable(dtTabla, true);

            //ws.Cells["B:B"].Style.Numberformat.Format = null;
            //ws.Cells["B:B"].Style.Numberformat.Format = "#,##0.00";


            pck.Save();
            //System.Diagnostics.Process.Start(Server.MapPath("RegistroVentas.xlsx"));
            MemoryStream msMemoria = null;
            //msMemoria = (MemoryStream)pck.ExportToStream(ExportFormatType.PortableDocFormat);

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=ExcelR.xlsx");
            Response.TransmitFile(Server.MapPath("ExcelR.xlsx"));
            Response.End();
        }

        public void F_DocumentoVentaCab_LetrasProtestadas()
        {
            FileInfo newFile = new FileInfo(Server.MapPath("NCSinAplicar.xlsx"));

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets["NC"];

            for (int i = 2; i < 100000; i++)
                ws.DeleteRow(2);

            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            //objEntidad.Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
            //objEntidad.Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
            //objEntidad.CodEmpresa = Convert.ToInt32(Request.QueryString["CodEmpresa"]);
            //objEntidad.CodTipoDoc = Convert.ToInt32(Request.QueryString["CodTipoDoc"]);
            //objEntidad.CodCliente = Convert.ToInt32(Request.QueryString["CodCtaCte"]);


            DataTable dtTabla = null;

            dtTabla = objOperacion.F_DocumentoVentaCab_LetrasProtestadas (objEntidad);

            ws.Cells["A2"].LoadFromDataTable(dtTabla, false);

            //ws.Cells["B:B"].Style.Numberformat.Format = null;
            //ws.Cells["B:B"].Style.Numberformat.Format = "#,##0.00";


            pck.Save();
            //System.Diagnostics.Process.Start(Server.MapPath("RegistroVentas.xlsx"));
            MemoryStream msMemoria = null;
            //msMemoria = (MemoryStream)pck.ExportToStream(ExportFormatType.PortableDocFormat);

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=LetrasProtestadas.xlsx");
            Response.TransmitFile(Server.MapPath("NCSinAplicar.xlsx"));
            Response.End();
        }

*/
    }
        
}