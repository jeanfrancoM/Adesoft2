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
//using System.Web.Helpers;
using SistemaInventario.Clases;
using EasyCallback; 
using Newtonsoft.Json;
using System.Web.Services;

namespace SistemaInventario.Inventario
{
    public partial class KardexSalcedo : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Buscar_NET);
            CallbackManager.Register(F_Nuevo_NET);
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_LlenarGridDetalle_NET);
            CallbackManager.Register(F_EliminarRegistro_Net);
            CallbackManager.Register(F_EdicionSaldoInicial_NET);
            CallbackManager.Register(F_Auditoria_NET);
        }

        private string _menu = "2000"; private string _opcion = "1";
        public bool PermisoVerCosto = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"]; String Opcion = Request.QueryString["Op"];
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
            if (Utilitarios.Menu.F_ValidarPermisoOpcion(2000, 2000102, "") == "1")
                PermisoVerCosto = true;
            P_Inicializar_GrillaVacia();
            Session["datos"] = true;
        }

        protected void grvConsulta_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView grvDetalle = null;
                GridView grvAuditoria = null;
                HiddenField lblCodigo = null;
                HiddenField hfCodTipoOperacion = null;
                ImageButton btnEliminar = null;
                ImageButton btnEditar = null;

                grvDetalle = (GridView)(e.Row.FindControl("grvDetalle"));
                lblCodigo = (HiddenField)(e.Row.FindControl("hfCodigo"));
                hfCodTipoOperacion = (HiddenField)(e.Row.FindControl("hfCodTipoOperacion"));
                btnEliminar = (ImageButton)(e.Row.FindControl("imgAnularDocumento"));
                btnEditar = (ImageButton)(e.Row.FindControl("imgEditarDocumento"));
                grvAuditoria = (GridView)(e.Row.FindControl("grvAuditoria"));

                if (lblCodigo.Value != "")
                {                    

                    switch (hfCodTipoOperacion.Value.ToString()) {
                        case "16":
                            btnEditar.Visible = true;
                            btnEliminar.Visible = false;
                            btnEditar.ToolTip = "EDITAR SALDO INICIAL";
                            break;
                        case "17":                            
                            btnEliminar.Visible = true;
                            btnEditar.Visible = true;
                            btnEditar.ToolTip = "EDITAR AJUSTE";
                            break;                       
                        default:
                            btnEliminar.Visible = false;
                            btnEditar.Visible = false;
                            break;
                    }

                    DataTable dta_consultaarticulo = null;
                    DataRow dtr_consultafila = null;
                    dta_consultaarticulo = new DataTable();

                    dta_consultaarticulo.Columns.Add("Observacion", typeof(string));

                    dtr_consultafila = dta_consultaarticulo.NewRow();

                    dtr_consultafila[0] = "";
                    dta_consultaarticulo.Rows.Add(dtr_consultafila);

                    grvDetalle.DataSource = dta_consultaarticulo;
                    grvDetalle.DataBind();

                    dta_consultaarticulo = null;
                    dtr_consultafila = null;
                    dta_consultaarticulo = new DataTable();

                    dta_consultaarticulo.Columns.Add("Auditoria", typeof(string));

                    dtr_consultafila = dta_consultaarticulo.NewRow();

                    dtr_consultafila[0] = "";
                    dta_consultaarticulo.Rows.Add(dtr_consultafila);

                    grvAuditoria.DataSource = dta_consultaarticulo;
                    grvAuditoria.DataBind();
                }

            }
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
            int Codigo = 0;
            int CodTipoDoc = 0;
            string Observacion = "";

            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                //Necesarios para que busque el sistema
                grvNombre = Convert.ToString(obj_parametros["Filtro_grvNombre"]);
                Col = Convert.ToInt32(obj_parametros["Filtro_Col"]);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_Codigo"]);
                //CodTipoDoc = Convert.ToInt32(obj_parametros["Filtro_CodTipoDoc"]);
                Observacion = Convert.ToString(obj_parametros["Filtro_Observacion"]);


                //Obtengo el Grid para llenarlo y dibujarlo
                GridView grvDetalle = (GridView)grvKardex.Rows[0].FindControl("grvDetalle");

                DataTable dta_consultadetalle = null;
                DataRow dtr_filadetalle = null;

                dta_consultadetalle = new DataTable();
                dta_consultadetalle.Columns.Add("Observacion", typeof(string));
                dtr_filadetalle = dta_consultadetalle.NewRow();

                dtr_filadetalle[0] = Observacion;
                dta_consultadetalle.Rows.Add(dtr_filadetalle);

                grvDetalle.DataSource = dta_consultadetalle;
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

        public String F_EliminarRegistro_Net(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;
            decimal StockActual = 0;
            decimal CostoUniOriginal = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EliminarRegistro(obj_parametros, ref str_mensaje_operacion);
                P_Buscar(obj_parametros, ref grvKardex, ref StockActual);
                if (grvKardex.Rows.Count == 0)
                    P_Inicializar_GrillaVacia();
                str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvKardex);
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
                StockActual;

            return str_resultado;
        }

        /// <summary>
        /// Nuevo Procedimiento para consultar detalles
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public String F_EdicionSaldoInicial_NET(String arg)
        {
            string str_resultado = "";
            string str_mensaje_operacion = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                //Necesarios para que busque el sistema
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                F_EdicionSaldoInicial(obj_parametros, ref str_mensaje_operacion);

                int_resultado_operacion = 1;
            }
            catch (Exception exxx)
            {
                str_mensaje_operacion = "ERROR AL BUSCAR DETALLE: " + exxx;
                int_resultado_operacion = 0;
            }


            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" +
                str_mensaje_operacion;

            return str_resultado;
        }

        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_ddlOperacion_html = "";
            String str_ddlSucursal_html = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlOperacion, ref ddlSucursal);

                str_ddlSucursal_html = Mod_Utilitario.F_GetHtmlForControl(ddlSucursal);
                str_ddlOperacion_html = Mod_Utilitario.F_GetHtmlForControl(ddlOperacion);
            }
            catch (Exception ex)
            {


            }

            str_resultado =
               Session["CodSede"].ToString()
                  + "~" +
               str_ddlSucursal_html
                     + "~" +
               str_ddlOperacion_html
               + "~" +
                Session["FechaInicio"].ToString();

            return str_resultado;
        }
        
        public String F_Buscar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;
            decimal StockActual = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Buscar(obj_parametros, ref grvKardex, ref StockActual);

                if (grvKardex.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia();
                    str_mensaje_operacion = "No se encontraron registros.";
                }
                else
                    str_mensaje_operacion = "";


                str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvKardex);
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
                StockActual;


            return str_resultado;

        }

        public String F_Nuevo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Inicializar_GrillaVacia();

                str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvKardex);
                int_resultado_operacion = 1;
                str_mensaje_operacion = "";

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

        public void P_Inicializar_GrillaVacia()
        {

            DataTable dta_consultadetalle = null;
            DataRow dtr_filadetalle = null;

            dta_consultadetalle = new DataTable();

            dta_consultadetalle.Columns.Add("Codigo", typeof(string));            
            dta_consultadetalle.Columns.Add("Producto", typeof(string));
            dta_consultadetalle.Columns.Add("Operacion", typeof(string));
            dta_consultadetalle.Columns.Add("Registro", typeof(string));            
            dta_consultadetalle.Columns.Add("RazonSocial", typeof(string));
            dta_consultadetalle.Columns.Add("Numero", typeof(string));            
            dta_consultadetalle.Columns.Add("Moneda", typeof(string));
            dta_consultadetalle.Columns.Add("TC", typeof(string));
            dta_consultadetalle.Columns.Add("Precio", typeof(string));
            dta_consultadetalle.Columns.Add("Inicial", typeof(string));
            dta_consultadetalle.Columns.Add("Ingreso", typeof(string));
            dta_consultadetalle.Columns.Add("Costo", typeof(string));
            dta_consultadetalle.Columns.Add("CostoS", typeof(string));
            dta_consultadetalle.Columns.Add("CostoSoles", typeof(string));
            dta_consultadetalle.Columns.Add("CostoDolares", typeof(string));
            dta_consultadetalle.Columns.Add("UBsoles", typeof(string));
            dta_consultadetalle.Columns.Add("UBDolares", typeof(string));
            dta_consultadetalle.Columns.Add("Salida", typeof(string));
            dta_consultadetalle.Columns.Add("Final", typeof(string));
            dta_consultadetalle.Columns.Add("UM", typeof(string));
            dta_consultadetalle.Columns.Add("Anexo", typeof(string));
            dta_consultadetalle.Columns.Add("FechaAnexo", typeof(string));
            dta_consultadetalle.Columns.Add("CodTipoOperacion", typeof(string));
            dta_consultadetalle.Columns.Add("Observacion", typeof(string));
            dta_consultadetalle.Columns.Add("Auditoria", typeof(string));
            dta_consultadetalle.Columns.Add("Almacen", typeof(string));
            dta_consultadetalle.Columns.Add("CodTipoDoc", typeof(string));
            dta_consultadetalle.Columns.Add("CodDoc", typeof(string));
            dta_consultadetalle.Columns.Add("CodTipoDocNota", typeof(string));
            
            
            

            dtr_filadetalle = dta_consultadetalle.NewRow();

            dtr_filadetalle[0] = "";
            dtr_filadetalle[1] = "";
            dtr_filadetalle[2] = "";
            dtr_filadetalle[3] = "";
            dtr_filadetalle[4] = "";
            dtr_filadetalle[5] = "";
            dtr_filadetalle[6] = "";
            dtr_filadetalle[7] = "";
            dtr_filadetalle[8] = "";
            dtr_filadetalle[9] = "";
            dtr_filadetalle[10] = "";
            dtr_filadetalle[11] = "";
            dtr_filadetalle[12] = "";
            dtr_filadetalle[13] = "";
            dtr_filadetalle[14] = "";
            dtr_filadetalle[15] = "";
            dtr_filadetalle[16] = "";
            dtr_filadetalle[17] = "";
            dtr_filadetalle[18] = "";             

            dta_consultadetalle.Rows.Add(dtr_filadetalle);

            if (!PermisoVerCosto)
            { 
                 grvKardex.Columns[11].Visible = false;
                 grvKardex.Columns[12].Visible = false;
                 grvKardex.Columns[13].Visible = false;
                 grvKardex.Columns[14].Visible = false;
                 grvKardex.Columns[15].Visible = false;
                 grvKardex.Columns[16].Visible = false;
            }               

            grvKardex.DataSource = dta_consultadetalle;
            grvKardex.DataBind();
        }

        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar, ref decimal StockActual)
        {
            MovimientosCE objEntidad = null;
            MovimientosCN objOperacion = null;

            DataTable dta_consulta = null;
            
            int iCodEmpresa = 3;

            objEntidad = new MovimientosCE();

            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]); 
            objEntidad.CodAlmacen = Convert.ToInt32(objTablaFiltro["Filtro_CodAlmacen"]);
            objEntidad.CodTipoOperacion = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoOperacion"]);
            objEntidad.Desde = Convert.ToDateTime(objTablaFiltro["Filtro_Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(objTablaFiltro["Filtro_Hasta"]);
            objEntidad.CodAlterno = Convert.ToString(objTablaFiltro["Filtro_CodAlterno"]);
            objEntidad.CodCtaCte = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new MovimientosCN();

            dta_consulta = objOperacion.F_Movimientos_Kardex_Salcedo(objEntidad);

            if (!PermisoVerCosto)
            {
                grvKardex.Columns[11].Visible = false;
                grvKardex.Columns[12].Visible = false;
                grvKardex.Columns[13].Visible = false;
                grvKardex.Columns[14].Visible = false;
                grvKardex.Columns[15].Visible = false;
                grvKardex.Columns[16].Visible = false;
            }  

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();
            
            LGStockAlmacenCN objEntidadST = new LGStockAlmacenCN();
            DataTable dtStock = objEntidadST.F_LGStockAlmacen_StockActual_Producto_CA(objEntidad.CodAlterno, objEntidad.CodAlmacen);
            if (dtStock.Rows.Count > 0)
                StockActual = Convert.ToDecimal(dtStock.Rows[0][0].ToString());
        }

        public void P_EliminarRegistro(Hashtable objTablaFiltro, ref String Mensaje)
        {
            NotaIngresoSalidaCabCE objEntidad = null;
            NotaIngresoSalidaCabCN objOperacion = null;

            objEntidad = new NotaIngresoSalidaCabCE();

            objEntidad.CodMovimiento = Convert.ToInt32(objTablaFiltro["Filtro_CodMovimiento"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new NotaIngresoSalidaCabCN();

            objOperacion.F_MOVIMIENTOS_ELIMINARAJUSTES_SALCEDO(objEntidad);

            Mensaje = objEntidad.MsgError;
        }

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_combooperacion, ref DropDownList ddl_comboAlmacen)
        {
            DataTable dta_consulta = null;

            dta_consulta = null;

            TCDocumentosCN objOperacionDocumento = new TCDocumentosCN();
            dta_consulta = objOperacionDocumento.F_TIPOOPERACION_KARDEX();

            ddl_combooperacion.Items.Clear();
            
            ddl_combooperacion.DataSource = dta_consulta;

            ddl_combooperacion.DataTextField = "DscOperacion";
            ddl_combooperacion.DataValueField = "CodTipoOperacion";
            ddl_combooperacion.DataBind();
            ddl_combooperacion.Items.Insert(0, new ListItem("TODOS", "0"));

            dta_consulta = null;

            TCAlmacenCN objOperacionAlmacen = new TCAlmacenCN();
            TCAlmacenCE objEntidadAlmacen = new TCAlmacenCE();

            objEntidadAlmacen.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstadoAlmacen"]);

            dta_consulta = (new TCAlmacenCN()).F_TCALMACEN_LISTAR_TODOS(objEntidadAlmacen);
            ddl_comboAlmacen.Items.Clear();
            ddl_comboAlmacen.DataSource = dta_consulta;
            ddl_comboAlmacen.DataTextField = "DscAlmacen";
            ddl_comboAlmacen.DataValueField = "CodAlmacen";
            ddl_comboAlmacen.DataBind();
            ddl_comboAlmacen.Items.Insert(0, new ListItem("TODOS", "0"));
        }

        public void F_EdicionSaldoInicial(Hashtable objTablaFiltro, ref String Mensaje)
        {
            MovimientosCE objEntidad = null;
            MovimientosCN objOperacion = null;

            objEntidad = new MovimientosCE();

            objEntidad.CodMovimiento = Convert.ToInt32(objTablaFiltro["Filtro_CodMovimiento"]);
            objEntidad.CantidadIng = Convert.ToDecimal(objTablaFiltro["Filtro_CantidadIngreso"]);
            objEntidad.CostoCompra = Convert.ToDecimal(objTablaFiltro["Filtro_Costo"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new MovimientosCN();

            objOperacion.F_Movimientos_Kardex_SaldoInicial_Modificar_Salcedo(objEntidad);

            Mensaje = objEntidad.MsgError;
        }

        [WebMethod]
        public static MovimientosCE F_InicialAjusteModificar(int CodMovimiento, decimal CantIng, decimal CantSalida, string FechaIngreso, int TipoOperacion, string Observacion)
        {
            MovimientosCE objEntidad = null;
            MovimientosCN objOperacion = null;

            objEntidad = new MovimientosCE();
            objOperacion = new MovimientosCN();

            objEntidad.CodUsuario = Convert.ToInt32(HttpContext.Current.Session["CodUsuario"].ToString());
            objEntidad.CodMovimiento = CodMovimiento;            
            objEntidad.CantidadIng = CantIng;
            objEntidad.CantidadSal = CantSalida;
            objEntidad.FechaIngreso = Convert.ToDateTime(FechaIngreso);
            objEntidad.CodTipoOperacion = TipoOperacion;
            objEntidad.Observacion = Observacion;

            return objOperacion.F_Movimientos_Kardex_InicialAjuste_Modificar_Salcedo(objEntidad);

        }
        public string F_Auditoria_NET(string arg) {
            int int_resultado_operacion = 0;
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String grvNombre = "";
            String str_grv_Observacion_html = "";
            int Col = 0;
            int Codigo = 0;
            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                grvNombre = Convert.ToString(obj_parametros["Filtro_grvNombre"]);
                Col = Convert.ToInt32(obj_parametros["Filtro_Col"]);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_Codigo"]);

                GridView grvDetalleAuditoria = (GridView)grvKardex.Rows[0].FindControl("grvAuditoria");

                MovimientosCN objOperacion = new MovimientosCN();
                MovimientosCE objEntidad = new MovimientosCE();

                objEntidad.CodMovimiento = Codigo;

                grvDetalleAuditoria.DataSource = objOperacion.F_Movimientos_Kardex_Auditoria_Salcedo(objEntidad);
                grvDetalleAuditoria.DataBind();

                str_grv_Observacion_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleAuditoria);
            }
            catch (Exception exxx)
            {
                str_resultado = "ERROR AL BUSCAR DETALLE: " + exxx;
                int_resultado_operacion = 1;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" +
                str_mensaje_operacion + "~" +
                str_grv_Observacion_html + "~" +
                grvNombre;

            return str_resultado;
        }
    }
}