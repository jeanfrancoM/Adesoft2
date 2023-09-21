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

namespace SistemaInventario.Planilla
{
    public partial class SalarioConsultasMensual : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_ValidarUsuario_NET);
            CallbackManager.Register(F_Buscar_NET);
            CallbackManager.Register(F_AnularRegistro_Net);
            CallbackManager.Register(F_LlenarGridDetalle_NET);
            CallbackManager.Register(F_ExportarDetalle_NET);
        }

        private string _menu = "3000"; private string _opcion = "6";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"]; String Opcion = Request.QueryString["Op"];
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
            if (!IsPostBack)
            {
                P_Inicializar_GrillaVacia_ConsultaFactura();
            }
        }

        protected void grvConsulta_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //NotaIngresoSalidaDetCN objOperacion = new NotaIngresoSalidaDetCN();
                //NotaIngresoSalidaDetCE objEntidad = new NotaIngresoSalidaDetCE();
                //GridView grvDetalle = null;
                //HiddenField lblCodigo = null;
                //grvDetalle = (GridView)(e.Row.FindControl("grvDetalle"));
                //lblCodigo = (HiddenField)(e.Row.FindControl("hfCodigo"));
                //if (lblCodigo.Value.ToString() != "")
                //{
                //    DataTable dta_consultaarticulo = null;
                //    DataRow dtr_consultafila = null;
                //    dta_consultaarticulo = new DataTable();
                //
                //    dta_consultaarticulo.Columns.Add("ID", typeof(string));
                //    dta_consultaarticulo.Columns.Add("CodigoInterno", typeof(string));
                //    dta_consultaarticulo.Columns.Add("Producto", typeof(string));
                //    dta_consultaarticulo.Columns.Add("Cantidad", typeof(string));
                //    dta_consultaarticulo.Columns.Add("Costo", typeof(string));
                //    dta_consultaarticulo.Columns.Add("P1", typeof(string));
                //    dta_consultaarticulo.Columns.Add("P2", typeof(string));
                //    dta_consultaarticulo.Columns.Add("P3", typeof(string));
                //    dta_consultaarticulo.Columns.Add("CostoGO", typeof(string));
                //
                //    dtr_consultafila = dta_consultaarticulo.NewRow();
                //
                //    dtr_consultafila[0] = "";
                //    dta_consultaarticulo.Rows.Add(dtr_consultafila);
                //
                //    grvDetalle.DataSource = dta_consultaarticulo;
                //    grvDetalle.DataBind();
                //}
            }
        }

        public void P_Inicializar_GrillaVacia_ConsultaFactura()
        {
            DataTable dta_consulta = null;
            DataRow dtr_filaconsulta = null;

            dta_consulta = new DataTable();

            dta_consulta.Columns.Add("Estado", typeof(string));
            dta_consulta.Columns.Add("IDExcel", typeof(string));
            dta_consulta.Columns.Add("CodRegimenLaboral", typeof(string));
            dta_consulta.Columns.Add("RegimenLaboral", typeof(string));
            dta_consulta.Columns.Add("CodCategoria", typeof(string));
            dta_consulta.Columns.Add("Categoria", typeof(string));
            dta_consulta.Columns.Add("CodProyecto", typeof(string));
            dta_consulta.Columns.Add("Proyecto", typeof(string));
            dta_consulta.Columns.Add("CodPeriodo", typeof(string));
            dta_consulta.Columns.Add("AñoPeriodo", typeof(string));
            dta_consulta.Columns.Add("Fecha", typeof(string));
            dta_consulta.Columns.Add("NombreCompleto", typeof(string));
            dta_consulta.Columns.Add("CodTrabajador", typeof(string));
            dta_consulta.Columns.Add("ApellidosNombres", typeof(string));
            dta_consulta.Columns.Add("CodEstado", typeof(string));
            
            dtr_filaconsulta = dta_consulta.NewRow();

            dtr_filaconsulta[0] = "";
            dtr_filaconsulta[1] = "";
            dtr_filaconsulta[2] = "";
            dtr_filaconsulta[3] = "";
            dtr_filaconsulta[4] = "";
            dtr_filaconsulta[5] = "";
            dtr_filaconsulta[6] = "";
            dtr_filaconsulta[7] = "";
            dtr_filaconsulta[8] = "";
            dtr_filaconsulta[9] = "";
            dtr_filaconsulta[10] = "";

            dta_consulta.Rows.Add(dtr_filaconsulta);

            grvConsulta.DataSource = dta_consulta;
            grvConsulta.DataBind();
        }

        /// <summary>
        /// Nuevo Procedimiento para consultar detalles
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public String F_LlenarGridDetalle_NET(String arg)
        {
            int int_resultado_operacion = 0;
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String grvNombre = "";
            String str_grv_Detalle_html = "";
            int Col = 0;
            long IDExcel = 0;
            int CodTrabajador = 0;

            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                //Necesarios para que busque el sistema
                grvNombre = Convert.ToString(obj_parametros["Filtro_grvNombre"]);
                Col = Convert.ToInt32(obj_parametros["Filtro_Col"]);
                IDExcel = Convert.ToInt64(obj_parametros["Filtro_IDExcel"]);
                CodTrabajador = Convert.ToInt32(obj_parametros["Filtro_CodTrabajador"]);

                Planilla_SalarioCN objOperacion = new Planilla_SalarioCN();
                Planilla_SalarioCE objEntidad = new Planilla_SalarioCE();
                //Obtengo el Grid para llenarlo y dibujarlo
                GridView grvDetalle = (GridView)grvConsulta.Rows[0].FindControl("grvDetalle");

                objEntidad.IDExcel = IDExcel;
                objEntidad.CodTrabajador = CodTrabajador;

                grvDetalle.DataSource = objOperacion.F_Planilla_Salario_Consulta_Construccion_General_Detalle(objEntidad);
                grvDetalle.DataBind();

                //se crea el html a partir del grid llenado
                str_grv_Detalle_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalle);

            }
            catch (Exception exxx)
            {
                str_resultado = "ERROR AL BUSCAR DETALLE: " + exxx;
                int_resultado_operacion = 1;
            }


            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" +
                str_mensaje_operacion + "~" +
                str_grv_Detalle_html + "~" +
                grvNombre;

            return str_resultado;
        }

        /// <summary>
        /// Nuevo Procedimiento para consultar detalles
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public String F_ExportarDetalle_NET(String arg)
        {
            int int_resultado_operacion = 0;
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String grvNombre = "";
            String str_grv_Detalle_html = "";
            int Col = 0;
            int Codigo = 0;
            int CodTipoDoc = 0;

            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                Codigo = Convert.ToInt32(obj_parametros["Filtro_Codigo"]);
                ExportarExcelDetalle(Codigo);

            }
            catch (Exception exxx)
            {
                str_resultado = "ERROR AL BUSCAR DETALLE: " + exxx;
                int_resultado_operacion = 1;
            }


            str_resultado = "";
            return str_resultado;
        }


        protected void ExportarExcelDetalle(int CodMovimiento)
        {
            NotaIngresoSalidaDetCN objOperacion = new NotaIngresoSalidaDetCN();
            NotaIngresoSalidaDetCE objEntidad = new NotaIngresoSalidaDetCE();
            objEntidad.CodMovimiento = CodMovimiento;
            DataTable ds = objOperacion.F_NotaIngresoSalidaDet_Select_Importaciones(objEntidad);

            if (ds.Rows.Count > 0)
            {
                FileInfo newFile = new FileInfo(Server.MapPath("Importaciones.xlsx"));

                ExcelPackage pck = new ExcelPackage(newFile);
                var ws = pck.Workbook.Worksheets["IMPORTACION"];

                for (int i = 2; i < 50000; i++)
                    ws.DeleteRow(2);

                ws.Cells["A2"].LoadFromDataTable(ds, true);
                ws.DeleteRow(2);

                //for (int i = 2; i < ds.Rows.Count + 2; i++)
                //{
                //    try
                //    {
                //        var Valor = ws.Cells["H" + i.ToString()].Value.ToString();
                //        if (Valor != "")
                //        {
                //            if (Valor == "1")
                //            {
                //                ws.Cells["A" + i.ToString() + ":G" + i.ToString()].Style.Fill.PatternType = ExcelFillStyle.Solid;
                //                ws.Cells["A" + i.ToString() + ":G" + i.ToString()].Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                //            }
                //        }
                //    }
                //    catch (Exception exxxx)
                //    { }
                //}

                ws.DeleteColumn(8); //elimino la columna M que no va...

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=Importaciones.xlsx");

                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    pck.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }


        public String F_ValidarUsuario_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;
            int CodUsuarioAuxiliar = 0;
            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_ValidarUsuario(obj_parametros, ref MsgError, ref CodUsuarioAuxiliar);
                int_resultado_operacion = 1;
                str_mensaje_operacion = MsgError;
            }
            catch (Exception ex)
            {
                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                CodUsuarioAuxiliar.ToString();

            return str_resultado;
        }

        public String F_AnularRegistro_Net(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_AnularRegistro(obj_parametros, ref str_mensaje_operacion);
                //P_Buscar(obj_parametros, ref grvConsulta);
                if (grvConsulta.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_ConsultaFactura();                    
                str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvConsulta);
                int_resultado_operacion = 1;

            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                str_grvConsulta_html;                
                

            return str_resultado;

        }

        public String F_Buscar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            String str_estado = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Buscar(obj_parametros, ref grvConsulta, ref str_estado);
                if (grvConsulta.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_ConsultaFactura();
                    str_mensaje_operacion = "No se encontro registros.";
                    str_estado = "";
                }
                else
                str_mensaje_operacion = "";                

                str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvConsulta);
                int_resultado_operacion = 1;


            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                str_grvConsulta_html
                + "~" +
                str_estado;


            return str_resultado;

        }

        public void P_AnularRegistro(Hashtable objTablaFiltro, ref String Mensaje)
        {
            NotaIngresoSalidaCabCE objEntidad = null;
            NotaIngresoSalidaCabCN objOperacion = null;

            objEntidad = new NotaIngresoSalidaCabCE();


            objEntidad.CodMovimiento = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new NotaIngresoSalidaCabCN();

            objOperacion.F_Anulacion_NotaIngreso(objEntidad);

            Mensaje = objEntidad.MsgError;

            if (Mensaje.Trim() == "Se anulo correctamente.")
            {
                LGProductosCE objEntidadProductos = new LGProductosCE();
                objEntidadProductos.CodProducto = 0;
                LGProductosCN objOperacionesProductos = new LGProductosCN();
                objOperacionesProductos.Async_F_LGProductos_ActualizarProductos_Azure(objEntidadProductos);

                LGStockAlmacenCN ActualizacionAzure = new LGStockAlmacenCN();
                ActualizacionAzure.Async_F_LGProductos_ActualizarStocks_Lotes_Azure();
            }
        }

        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar, ref string txtEstado)
        {
            Planilla_SalarioCE objEntidad = new Planilla_SalarioCE();


            objEntidad.CodRegimenLaboral = Convert.ToInt32(objTablaFiltro["Filtro_CodRegimenLaboral"]);
            //objEntidad.CodCategoria = Convert.ToInt32(objTablaFiltro["Filtro_CodCategoria"]);
            objEntidad.CodPeriodo = Convert.ToInt32(objTablaFiltro["Filtro_CodPeriodo"]);

            if (Convert.ToInt32(objTablaFiltro["Filtro_ChkFecha"]) == 1)
            {
                objEntidad.Desde = Convert.ToDateTime(objTablaFiltro["Filtro_Desde"]);
                objEntidad.Hasta = Convert.ToDateTime(objTablaFiltro["Filtro_Hasta"]);
            }
            else
            {
                objEntidad.Desde = Convert.ToDateTime("01/01/1990");
                objEntidad.Hasta = Convert.ToDateTime("01/01/1990");
            }


            if (Convert.ToInt32(objTablaFiltro["Filtro_ChkTrabajador"]) == 1)
                objEntidad.CodTrabajador = Convert.ToInt32(objTablaFiltro["Filtro_CodTrabajador"]);
            else
                objEntidad.CodTrabajador = 0;

            DataTable dtabla = (new Planilla_SalarioCN()).F_Planilla_Salario_Consulta_General(objEntidad);
            GrillaBuscar.DataSource = dtabla;
            if (dtabla.Rows.Count > 0)
            {
                txtEstado = dtabla.Rows[0][0].ToString();
            }
            else
            {
                txtEstado = "";
            }
            
            GrillaBuscar.DataBind();
        }
        [WebMethod]
        public static Planilla_SalarioCE P_Eliminar_Carga_Excel_PlanillaRG(int CodPeriodo)
        {
            Planilla_SalarioCE objEntidad = new Planilla_SalarioCE();
            objEntidad.CodPeriodo = CodPeriodo;
            return (new Planilla_SalarioCN()).F_Eliminar_Carga_Excel_PlanillaRG(objEntidad);

        }
        [WebMethod]
        public static Planilla_SalarioCE P_Confirmar_Pago_PlanillaRG(int CodPeriodo)
        {
            Planilla_SalarioCE objEntidad = new Planilla_SalarioCE();
            objEntidad.CodPeriodo = CodPeriodo;
            return (new Planilla_SalarioCN()).F_Confirmar_Pago_PlanillaRG(objEntidad);

        }
        public void P_ValidarUsuario(Hashtable objTablaFiltro, ref String MsgError, ref Int32 CodUsuarioAuxiliar)
        {
            UsuarioCE objEntidad = null;
            UsuarioCN objOperacion = null;

            objEntidad = new UsuarioCE();

            objEntidad.NombreUsuario = Convert.ToString(objTablaFiltro["Filtro_Usuario"]);
            objEntidad.Clave = Convert.ToString(objTablaFiltro["Filtro_NvClave"]);
            objEntidad.Pagina = Convert.ToString(objTablaFiltro["Filtro_Pagina"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new UsuarioCN();
            objOperacion.F_Usuario_Login_Modulo(objEntidad);
            MsgError = objEntidad.Mensaje;
            CodUsuarioAuxiliar = objEntidad.CodUsuarioAuxiliar;
        }


    }
}
