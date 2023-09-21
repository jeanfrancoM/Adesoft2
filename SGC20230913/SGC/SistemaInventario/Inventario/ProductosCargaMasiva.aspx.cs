using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocios;
using EasyCallback;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using SistemaInventario.Clases;

namespace SistemaInventario.Inventario
{
    public partial class ProductosCargaMasiva : System.Web.UI.Page
    {
        private string _menu = "3000"; private string _opcion = "6";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"]; String Opcion = Request.QueryString["Op"];
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
        }
          
        protected string MSG;
        protected DataTable dtValidacionesProductos;
        protected void btnImport_Click(object sender, EventArgs e)
        {
            string Mensaje = ""; int CodMovimiento = 0;
            Label1.Text = "";
            hfCodTemporal.Value = DateTime.Now.ToString("yyyyMMddHHmmss");
            long IdExcel = long.Parse(hfCodTemporal.Value.ToString());
            MSG = "";
            dtValidacionesProductos = null;

            btnImport.Enabled = false;
            FileUpload1.Enabled = false;

            string MensajeErrorCarga;
            ImportarExcel(out MensajeErrorCarga);

            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();
            dtValidacionesProductos = objOperacion.F_ProductoCargaMasiva_VALIDACIONES_EXCEL(Convert.ToInt64(hfCodTemporal.Value));
            if (dtValidacionesProductos.Rows.Count > 0)
            {
                grvDetalleArticulo.DataSource = dtValidacionesProductos;
                grvDetalleArticulo.DataBind();

                Label3.Text = "SE ENCONTRARON DIFERENTES ERRORES";
                Label3.BackColor = Color.Black;
                Label3.BackColor = Color.Orange;

                return;
            }

            if (MensajeErrorCarga == "")
            {
                GrabarExcel(ref Mensaje);
                Label1.Text = Mensaje;

                if (Mensaje.ToUpper() == "SE GRABO CORRECTAMENTE")
                {
                    hfCodTemporal.Value = "0";
                    Label1.Text = Mensaje;
             
                    LGProductosCE objEntidadProductos = new LGProductosCE();
                    objEntidadProductos.CodProducto = 0;
                    LGProductosCN objOperacionesProductos = new LGProductosCN();
                    objOperacionesProductos.Async_F_LGProductos_ActualizarProductos_Azure(objEntidadProductos);

                    LGStockAlmacenCN ActualizacionAzure = new LGStockAlmacenCN();
                    ActualizacionAzure.Async_F_LGProductos_ActualizarStocks_Lotes_Azure();
                }
            }

            btnImport.Enabled = true;     
            FileUpload1.Enabled = true;
                        
            return;
        }

        private void ImportarExcel(out string MensajeError)
        {
            MensajeError = "";
            string ExcelContentType = "application/vnd.ms-excel";
            string Excel2010ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            if (FileUpload1.HasFile)
            {
                if (FileUpload1.PostedFile.ContentType == ExcelContentType || FileUpload1.PostedFile.ContentType == Excel2010ContentType)
                {
                    string path;
                    string excelConnectionString;
                    string Cadena;
                    try
                    {
                        path = string.Concat(Server.MapPath("~/Temporales/"), FileUpload1.FileName);
                        FileUpload1.SaveAs(path);

                        excelConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);
                        Cadena = string.Format("Select [Codigo],[Descripcion],[Precio],[Moneda],[UM]," + hfCodTemporal.Value + " AS IDPruebasExcelCab,'" + FileUpload1.FileName + "' AS NombreArchivo, " + Convert.ToInt32(Session["CodSede"]).ToString() + " as CodAlmacen FROM [{0}] ", "Productos$");

                        using (OleDbConnection connection = new OleDbConnection(excelConnectionString))
                        {
                            OleDbCommand command = new OleDbCommand(Cadena, connection);

                            connection.Open();

                            using (DbDataReader dr = command.ExecuteReader())
                            {
                                string sqlConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConnectionString))
                                {
                                    bulkCopy.DestinationTableName = "ProductoCargaMasiva";
                                    bulkCopy.ColumnMappings.Add("[Codigo]", "Codigo");
                                    bulkCopy.ColumnMappings.Add("[Descripcion]", "Descripcion");
                                    bulkCopy.ColumnMappings.Add("[Precio]", "Precio");
                                    bulkCopy.ColumnMappings.Add("[Moneda]", "Moneda");
                                    bulkCopy.ColumnMappings.Add("[UM]", "UM");
                                    bulkCopy.ColumnMappings.Add("[CodAlmacen]", "CodAlmacen");
                                    bulkCopy.ColumnMappings.Add("[IDPruebasExcelCab]", "IDPruebasExcelCab");
                                    bulkCopy.ColumnMappings.Add("[NombreArchivo]", "NombreArchivo");
                                    bulkCopy.WriteToServer(dr);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            MensajeError = "Error en la lectura del excel. <p></p> " +
                                            "Descripción: " + ex.Message.ToString() + " <p></p>  <p></p> " +
                                            " debe tener cuenta que el documento debe tener las siguientes especificaciones:  <p></p> " +
                                            " <b>Hoja: PRODUCTOS</b>" +
                                            " Columnas: <p></p>" +
                                            " <b>[A]=CODIGO, [B]=DESCRIPCION,[C]=PRECIO, [D]=MONEDA, [E]=UM</b>";
                            Label1.Text = MensajeError;
                            Label1.BackColor = Color.Black;
                            Label1.BackColor = Color.Orange;

                            btnImport.Enabled = false;
                            FileUpload1.Enabled = false;
                        }
                        catch (Exception exx)
                        { }
                    }
                }
            }
        }
        
        private void GrabarExcel(ref string Mensaje)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.IDPruebasExcelCab = Convert.ToInt64(hfCodTemporal.Value);
            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new DocumentoVentaCabCN();

            objOperacion.F_ProductoCargaMasiva_Excel_GRABAR(objEntidad);

            Mensaje = objEntidad.MsgError;
        }
                
    }
}
