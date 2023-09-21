using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using OfficeOpenXml;
using CapaNegocios;
using System.Data;  

namespace SistemaInventario.Reportes
{
    public partial class Web_Pagina_Excel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ExportGridToExcel(Request["Titulo"].ToString(), (GridView)Session["Excel"]);

            
        }

        private void ExportGridToExcel(String nameReport, GridView wControl)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = nameReport + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            wControl.GridLines = GridLines.Both;
            wControl.HeaderStyle.Font.Bold = true;
            wControl.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }

        public void p_ReporteVentasPorUnidades()
        {
            FileInfo newFile = new FileInfo(Server.MapPath("Excel.xlsx"));
            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets["Hoja1"];

            for (int i = 1; i < 10000; i++)
                ws.DeleteRow(1);

            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            objEntidad.Desde = Convert.ToDateTime(Request["Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(Request["Hasta"]);
            objEntidad.IdFamilia = Convert.ToInt32(Request["IdFamilia"]);
            objEntidad.Marca = Convert.ToString(Request["Marca"]);

            DataTable dtTabla = null;

            dtTabla = objOperacion.F_ReporteVentasPorUnidades(objEntidad);

            //renombro las tablas
            foreach (DataColumn c in dtTabla.Columns)
            { 
                try
                {
                    if (Convert.ToInt32(c.ColumnName.Substring(0, 4).ToString()) > 1900)
                    {
                        string año = c.ColumnName.Substring(0, 4).ToString();
                        string mes = c.ColumnName.Substring(4, 2).ToString();

                        switch (mes) {
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
                            case "12": mes = "Dic"; break; }

                        string añomes = mes + "-" + año;
                        c.ColumnName = añomes;
                    }
                }
                catch(Exception ex)
                {}
                

                
            
            }


            ws.Cells["A1"].LoadFromDataTable(dtTabla, true);

            pck.Save();

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Excel.xlsx");
            Response.TransmitFile(Server.MapPath("Excel.xlsx"));
            Response.End();
        }


        public void p_ReporteVentasPorUnidades_Povis()
        {
            FileInfo newFile = new FileInfo(Server.MapPath("Excel.xlsx"));
            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets["Hoja1"];

            for (int i = 1; i < 10000; i++)
                ws.DeleteRow(1);

            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            objEntidad.Desde = Convert.ToDateTime(Request["Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(Request["Hasta"]);
            objEntidad.IdFamilia = Convert.ToInt32(Request["IdFamilia"]);
            objEntidad.Marca = Convert.ToString(Request["Marca"]);

            DataTable dtTabla = null;

            dtTabla = objOperacion.F_ReporteVentasPorUnidades(objEntidad);

            //renombro las tablas
            foreach (DataColumn c in dtTabla.Columns)
            {
                try
                {
                    if (Convert.ToInt32(c.ColumnName.Substring(0, 4).ToString()) > 1900)
                    {
                        string año = c.ColumnName.Substring(0, 4).ToString();
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


            ws.Cells["A1"].LoadFromDataTable(dtTabla, true);

            pck.Save();

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Excel.xlsx");
            Response.TransmitFile(Server.MapPath("Excel.xlsx"));
            Response.End();
        }

        public void p_ReporteVentasPorPeriodo()
        {
            FileInfo newFile = new FileInfo(Server.MapPath("Excel.xlsx"));
            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets["Hoja1"];

            for (int i = 1; i < 10000; i++)
                ws.DeleteRow(1);

            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            //filtros
            objEntidad.DesdeInt = Convert.ToInt32(Request["Desde"]);
            objEntidad.HastaInt = Convert.ToInt32(Request["Hasta"]);
            objEntidad.CodMoneda = Convert.ToInt32(Request["CodMoneda"]);

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

            objEntidad.xmlMarcas = "";
            dynamic jArr3 = Newtonsoft.Json.JsonConvert.DeserializeObject(Request["Marcas"]);
            foreach (dynamic item in jArr3)
            {
                objEntidad.xmlMarcas = objEntidad.xmlMarcas + "<D ";
                objEntidad.xmlMarcas = objEntidad.xmlMarcas + " Marca = '" + item.Marca + "'";
                objEntidad.xmlMarcas = objEntidad.xmlMarcas + " />";
            }
            objEntidad.xmlMarcas = "<R><XmlLC> " + objEntidad.xmlMarcas + "</XmlLC></R>";

            DataTable dtTabla = null;

            dtTabla = objOperacion.F_ReporteVentasPorPeriodo(objEntidad);

            //renombro las tablas
            foreach (DataColumn c in dtTabla.Columns)
            {
                try
                {
                    if (Convert.ToInt32(c.ColumnName.Substring(0, 4).ToString()) > 1900)
                    {
                        string año = c.ColumnName.Substring(0, 4).ToString();
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

            ws.Cells["A1"].LoadFromDataTable(dtTabla, true);

            pck.Save();

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Excel.xlsx");
            Response.TransmitFile(Server.MapPath("Excel.xlsx"));
            Response.End();
        }


        public override void VerifyRenderingInServerForm(Control control)
        {
            
        }  
    }
}