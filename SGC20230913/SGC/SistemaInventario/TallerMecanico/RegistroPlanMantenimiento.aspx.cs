using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using CapaNegocios;
using CapaEntidad;
using SistemaInventario.Clases;
using EasyCallback;
using Newtonsoft.Json;
using System.Web.Services;
using System.Net;
using System.Drawing;

namespace SistemaInventario.TallerMecanico
{
    public partial class RegistroPlanMantenimiento : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_Mostrar_Correlativo_NET);
            CallbackManager.Register(F_Buscar_Productos_NET);
            CallbackManager.Register(F_AgregarTemporal_NET);
            CallbackManager.Register(F_EliminarTemporal_NET);
            CallbackManager.Register(F_GrabarDocumento_NET);
            CallbackManager.Register(F_Nuevo_NET);
            CallbackManager.Register(F_Buscar_NET);
            CallbackManager.Register(F_AnularRegistro_Net);
            CallbackManager.Register(F_ActivarVenta_Net);
            CallbackManager.Register(F_CargarGrillaVaciaConsultaArticulo_NET);
            CallbackManager.Register(F_TipoCambio_NET);
            CallbackManager.Register(F_VerUltimoPrecio_NET);
            CallbackManager.Register(F_PrecioMoneda_NET);
            CallbackManager.Register(F_ActualizarPrecio_Net);
            CallbackManager.Register(F_EliminarRegistro_Net);
            CallbackManager.Register(F_FacturacionOC_NET);
            CallbackManager.Register(F_Devolucion_NET);
            CallbackManager.Register(F_ImprimirFacturaTicket_NET);
            CallbackManager.Register(F_ReenvioMail_NET);
            CallbackManager.Register(F_ActualizarDetalle_NET);
            CallbackManager.Register(F_ReemplazarFactura_NET);
            CallbackManager.Register(F_LlenarGridDetalle_NET);
            CallbackManager.Register(F_KardexDetalle_NET);
            CallbackManager.Register(F_StockAlmacenes_NET);
            CallbackManager.Register(F_Auditoria_NET);
            


        }

        private string _menu = "4000"; private string _opcion = "1";
        public bool PermisoVerCosto = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"];
            String Opcion = Request.QueryString["Op"];
            
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
            if (Utilitarios.Menu.F_ValidarPermisoOpcion(4000, 777004, "") == "1")
                PermisoVerCosto = true;

            P_Inicializar_GrillaVacia_Articulo();
            P_Inicializar_GrillaVacia_Detalle();
            P_Inicializar_GrillaVacia_Consulta();
            P_Inicializar_GrillaVacia_DetalleOC();
            P_Inicializar_GrillaVacia_DetalleGuia();
            P_Inicializar_GrillaVacia_PrecioMoneda();
            Session["datos"] = true;
        }

        protected void grvConsulta_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DocumentoVentaDetCN objOperacion = new DocumentoVentaDetCN();
                DocumentoVentaDetCE objEntidad = new DocumentoVentaDetCE();
                GridView grvDetalle = null;
                HiddenField hfCodigo = null;
                HiddenField hfCodTipoDoc = null;
                Label lblEstado = null;
                Label lblNumero = null;
                HiddenField hfFlagVisibleFacturacion = null;
                GridView grvDetalleAuditoria = null;
                //Label lblVisualizacion = null;

                grvDetalleAuditoria = (GridView)(e.Row.FindControl("grvDetalleAuditoria"));
                grvDetalle = (GridView)(e.Row.FindControl("grvDetalle"));
                hfCodigo = (HiddenField)(e.Row.FindControl("hfCodigo"));
                lblEstado = (Label)(e.Row.FindControl("lblEstado"));
                lblNumero = (Label)(e.Row.FindControl("lblnumero"));
                hfFlagVisibleFacturacion = (HiddenField)(e.Row.FindControl("hfFlagVisibleFacturacion"));

                hfCodTipoDoc = (HiddenField)(e.Row.FindControl("hdCodigo"));

                if (hfCodigo.Value != "")
                {
                    DataTable dta_consultaarticulo = null;
                    DataRow dtr_consultafila = null;
                    dta_consultaarticulo = new DataTable();

                    dta_consultaarticulo.Columns.Add("CodDetalle", typeof(string));
                    dta_consultaarticulo.Columns.Add("CodigoProducto", typeof(string));
                    dta_consultaarticulo.Columns.Add("Producto", typeof(string));
                    dta_consultaarticulo.Columns.Add("CodArticulo", typeof(string));
                    dta_consultaarticulo.Columns.Add("UM", typeof(string));
                    dta_consultaarticulo.Columns.Add("Cantidad", typeof(string));
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

                    grvDetalleAuditoria.DataSource = dta_consultaarticulo;
                    grvDetalleAuditoria.DataBind();
                }

                //Convert.ToInt32(e.Row.Cells[1].Text);
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

            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                //Necesarios para que busque el sistema
                grvNombre = Convert.ToString(obj_parametros["Filtro_grvNombre"]);
                Col = Convert.ToInt32(obj_parametros["Filtro_Col"]);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_Codigo"]);

                //Obtengo el Grid para llenarlo y dibujarlo
                GridView grvDetalle = (GridView)grvConsulta.Rows[0].FindControl("grvDetalle");

                //Consulta
                VehiculoPlanMantenimientoDetCN objOperacion = new VehiculoPlanMantenimientoDetCN();
                VehiculoPlanMantenimientoDetCE objEntidad = new VehiculoPlanMantenimientoDetCE();

                //consulta a la base de datos y se llena grid
                objEntidad.CodVehiculoPlanMantenimientoCab = Codigo; 
                grvDetalle.DataSource = objOperacion.F_VehiculoPlanMantenimientoDet_Listar(objEntidad);
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
        public String F_Auditoria_NET(String arg)
        {
            int int_resultado_operacion = 0;
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String grvNombre = "";
            String str_grv_Auditoria_html = "";
            int Col = 0;
            int CodVehiculoPlanMantenimientoCab = 0;
            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                grvNombre = Convert.ToString(obj_parametros["Filtro_grvNombre"]);
                Col = Convert.ToInt32(obj_parametros["Filtro_Col"]);
                CodVehiculoPlanMantenimientoCab = Convert.ToInt32(obj_parametros["Filtro_Codigo"]);

                GridView grvAuditoria = (GridView)grvConsulta.Rows[0].FindControl("grvDetalleAuditoria");

                VehiculoPlanMantenimientoCN objOperacion = new VehiculoPlanMantenimientoCN();
                VehiculoPlanMantenimientoCE objEntidad = new VehiculoPlanMantenimientoCE();

                objEntidad.CodVehiculoPlanMantenimientoCab = CodVehiculoPlanMantenimientoCab;
                grvAuditoria.DataSource = objOperacion.F_VehiculoPlanMantenimiento_AUDITORIA(objEntidad);
                grvAuditoria.DataBind();

                str_grv_Auditoria_html = Mod_Utilitario.F_GetHtmlForControl(grvAuditoria);
            }
            catch (Exception exxx)
            {
                str_resultado = "ERROR AL BUSCAR DETALLE: " + exxx;
                int_resultado_operacion = 1;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" +
                str_mensaje_operacion + "~" +
                str_grv_Auditoria_html + "~" +
                grvNombre;

            return str_resultado;
        }
        public String F_KardexDetalle_NET(String arg)
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
                //Necesarios para que busque el sistema
                grvNombre = Convert.ToString(obj_parametros["Filtro_grvNombre"]);
                Col = Convert.ToInt32(obj_parametros["Filtro_Col"]);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_Codigo"]);
                CodTipoDoc = Convert.ToInt32(obj_parametros["Filtro_CodTipoDoc"]);

                //Obtengo el Grid para llenarlo y dibujarlo
                GridView grvDetalle = (GridView)grvConsultaArticulo.Rows[0].FindControl("grvDetalleKardex");

                //Consulta
                DocumentoVentaDetCN objOperacion = new DocumentoVentaDetCN();
                DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();

                //consulta a la base de datos y se llena grid
                objEntidad.Desde = Convert.ToDateTime(obj_parametros["Filtro_Desde"]);
                objEntidad.Hasta = Convert.ToDateTime(obj_parametros["Filtro_Hasta"]);
                objEntidad.CodProducto = Convert.ToInt32(obj_parametros["Filtro_CodProducto"]);
                objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
                objEntidad.CodCliente = Convert.ToInt32(obj_parametros["Filtro_CodCtaCte"]);
                objEntidad.CodTipoOperacion = Convert.ToInt32(obj_parametros["Filtro_CodTipoOperacion"]);

                grvDetalle.DataSource = objOperacion.F_DOCUMENTOVENTACAB_KARDEX(objEntidad);
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

        protected void grvConsultaArticulo_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField hfPrecio1 = null;
                    HiddenField hfPrecio2 = null;
                    HiddenField hfPrecio3 = null;
                    DropDownList ddlPrecio = null;
                    
                    hfPrecio1 = (HiddenField)(e.Row.FindControl("lblPrecio1"));
                    hfPrecio2 = (HiddenField)(e.Row.FindControl("lblPrecio2"));
                    hfPrecio3 = (HiddenField)(e.Row.FindControl("lblPrecio3"));
                    ddlPrecio = (DropDownList)(e.Row.FindControl("ddlPrecio"));
                    
                    ddlPrecio.DataSource = new List<string>() { hfPrecio1.Value.ToString(), hfPrecio2.Value.ToString(), hfPrecio3.Value.ToString() };
                    ddlPrecio.DataBind();
                    ddlPrecio.Enabled = false;
                    
                    GridView grvDetalle = null;
                    HiddenField lblCodigo = null;

                    grvDetalle = (GridView)(e.Row.FindControl("grvDetalleKardex"));
                    lblCodigo = (HiddenField)(e.Row.FindControl("lblcodproducto"));

                    if (lblCodigo.Value != "")
                    {
                        DataTable dta_consultaarticulo = null;
                        DataRow dtr_consultafila = null;
                        dta_consultaarticulo = new DataTable();

                        dta_consultaarticulo.Columns.Add("Fecha", typeof(string));
                        dta_consultaarticulo.Columns.Add("Ruc", typeof(string));
                        dta_consultaarticulo.Columns.Add("RazonSocial", typeof(string));
                        dta_consultaarticulo.Columns.Add("Numero", typeof(string));
                        dta_consultaarticulo.Columns.Add("Cantidad", typeof(string));
                        dta_consultaarticulo.Columns.Add("Precio", typeof(string));
                        dta_consultaarticulo.Columns.Add("Moneda", typeof(string));

                        dtr_consultafila = dta_consultaarticulo.NewRow();

                        dtr_consultafila[0] = "";
                        dta_consultaarticulo.Rows.Add(dtr_consultafila);

                        grvDetalle.DataSource = dta_consultaarticulo;
                        grvDetalle.DataBind();
                    }
                }
            }
            catch (Exception exx) { }            
        }
        
        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_ddlEstado_html = "";
            String str_ddlEstadoConsulta_html = "";
            String str_ddlTipoPlan_html = "";
            String str_resultado = "";
            String str_ddlTipoPlanConsulta_html = "";
            

            String str_mensaje_operacion = "";
          
            String str_grvDetalleArticulo_html = "";
            Int32 Usuario = 0;
            decimal TC = 0;
            int int_resultado_operacion = 0;
            String str_grvConsuArticulo_html = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlTipoPlan, ref ddlEstado, ref ddlEstadoConsulta, ref ddlTipoPlanConsulta);
                P_Obtener_TipoCambio(obj_parametros, ref TC);
                P_LlenarGrillaVacia_Detalle();
                P_Inicializar_GrillaVacia_Articulo();

                str_ddlEstado_html = Mod_Utilitario.F_GetHtmlForControl(ddlEstado);
                str_ddlEstadoConsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlEstadoConsulta);
                str_grvConsuArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvConsultaArticulo);
                str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);
                str_ddlTipoPlan_html = Mod_Utilitario.F_GetHtmlForControl(ddlTipoPlan);
                str_ddlTipoPlanConsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlTipoPlanConsulta);
                
                
                Usuario = Convert.ToInt32(Session["CodUsuario"]);

                int_resultado_operacion = 1;
                str_mensaje_operacion = "";
            }
            catch (Exception ex)
            {
                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" + //0
                str_mensaje_operacion + "~" + //1
                 str_ddlEstado_html + "~" + //2
                   str_ddlEstadoConsulta_html + "~" + //3
                 str_ddlTipoPlan_html + "~" + //4
                 str_grvConsuArticulo_html + "~" + //5
                 str_grvDetalleArticulo_html + "~" + //6
                  str_ddlTipoPlanConsulta_html; //7

            return str_resultado;
        }

        //public String F_Series_Documentos_NET(String arg)
        //{
        //    String str_resultado = "";
        //    String str_mensaje_operacion = "";
        //    String str_ddl_serie_html = "";
        //    String str_ddl_serieconsulta_html = "";

        //    int int_resultado_operacion = 0;

        //    Hashtable obj_parametros = null;

        //    try
        //    {
        //        obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

        //       // P_Series_Documentos(obj_parametros, ref ddlSerie, ref ddlSerieConsulta);

        //        //str_ddl_serie_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerie);
        //        str_ddl_serieconsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieConsulta);

        //        int_resultado_operacion = 1;
        //        str_mensaje_operacion = "";

        //    }
        //    catch (Exception ex)
        //    {

        //        str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
        //        int_resultado_operacion = 0;

        //    }

        //    str_resultado =
        //        Convert.ToString(int_resultado_operacion)
        //        + "~" +
        //        str_mensaje_operacion
        //        + "~" +
        //        str_ddl_serie_html
        //         + "~" +
        //        str_ddl_serieconsulta_html;

        //    return str_resultado;
        //}

        public String F_Mostrar_Correlativo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_numero = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);


                P_Obtener_NumeroCorrelativo(obj_parametros, ref str_numero);

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
                str_numero;


            return str_resultado;

        }

        public String F_Buscar_Productos_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsultaArticulo_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Cargar_Grilla(obj_parametros, ref grvConsultaArticulo);
                if (grvConsultaArticulo.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_Articulo();
                    str_mensaje_operacion = "No se encontraron registros.";
                }
                else
                    str_mensaje_operacion = "";

                str_grvConsultaArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvConsultaArticulo);
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
                str_grvConsultaArticulo_html;

            return str_resultado;
        }

        public String F_AgregarTemporal_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            Decimal Total = 0;
            Decimal SubTotal = 0;
            Decimal Igv = 0;
            Decimal Acuenta = 0;
            String MsgError = "";
            Int32 NotaPedido = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_AgregarTemporal(obj_parametros, ref Codigo, ref MsgError);
                P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref Acuenta, ref NotaPedido);
                str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);

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
                MsgError
                + "~" +
                Codigo.ToString()
                + "~" +
                str_grvDetalleArticulo_html
                 + "~" +
                Math.Round(Total, 2).ToString()
                + "~" +
                Math.Round(Igv, 2).ToString()
                 + "~" +
                Math.Round(SubTotal, 2).ToString()
                 + "~" +
                Math.Round(Acuenta, 2).ToString()
                + "~" +
                Convert.ToInt32(NotaPedido);

            return str_resultado;
        }

        public String F_EliminarTemporal_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            Decimal Total = 0;
            Decimal SubTotal = 0;
            Decimal Igv = 0;
            Decimal Acuenta = 0;
            String MsgError = "";
            Int32 NotaPedido = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EliminarTemporal(obj_parametros, ref MsgError);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_CodigoTemporal"]);
                P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref Acuenta, ref NotaPedido);
                if (grvDetalleArticulo.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Detalle();
                str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);

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
                MsgError
                + "~" +
                Codigo.ToString()
                + "~" +
                str_grvDetalleArticulo_html
                 + "~" +
               Math.Round(Total, 2).ToString()
                + "~" +
                Math.Round(Igv, 2).ToString()
                 + "~" +
                Math.Round(SubTotal, 2).ToString()
                 + "~" +
                Math.Round(Acuenta, 2).ToString()
                + "~" +
                Convert.ToInt32(NotaPedido);

            return str_resultado;

        }

        public String F_ActualizarDetalle_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            Decimal Total = 0;
            Decimal SubTotal = 0;
            Decimal Igv = 0;
            Decimal Dscto = 0;
            String MsgError = "";
            Int32 NotaPedido = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_ActualizarDetalle(obj_parametros, ref str_mensaje_operacion);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_CodDocumentoVenta"]);
                P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref Dscto, ref NotaPedido);
                if (grvDetalleArticulo.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Detalle(); //P_Inicializar_GrillaVacia_DetalleArticulo();
                str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);

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
                MsgError
                + "~" +
                Codigo.ToString()
                + "~" +
                str_grvDetalleArticulo_html
                 + "~" +
               Math.Round(Total, 2).ToString()
                + "~" +
                Math.Round(Igv, 2).ToString()
                 + "~" +
                Math.Round(SubTotal, 2).ToString()
                 + "~" +
                Math.Round(Dscto, 2).ToString()
                + "~" +
                Convert.ToInt32(NotaPedido);

            return str_resultado;

        }

        public String F_GrabarDocumento_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_numerofactura = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_GrabarDocumento(obj_parametros, ref str_mensaje_operacion, ref Codigo);

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
                Codigo.ToString()
                + "~" +
                str_numerofactura;


            return str_resultado;

        }

        public String F_Nuevo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_numerofactura = "";
            String str_grvDetalleArticulo_html = "";
            String str_numeroguia = "";

            int int_resultado_operacion = 1;

            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Obtener_NumeroCorrelativo(obj_parametros, ref str_numerofactura);
                //P_Obtener_Correlativo(obj_parametros, ref str_numeroguia);
                P_LlenarGrillaVacia_Detalle();
                str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);
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
                str_grvDetalleArticulo_html
                + "~" +
                str_numerofactura
                + "~" +
                str_numeroguia;


            return str_resultado;

        }

        public String F_Buscar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Buscar(obj_parametros, ref grvConsulta);
                if (grvConsulta.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_Consulta();
                    str_mensaje_operacion = "No se encontraron registros";
                }
                else
                {
                    str_mensaje_operacion = "";
                }

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
                P_Buscar(obj_parametros, ref grvConsulta);
                if (grvConsulta.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Consulta();

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

        public String F_ActivarVenta_Net(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                F_ActivarVenta(obj_parametros, ref str_mensaje_operacion);
                P_Buscar(obj_parametros, ref grvConsulta);
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
        
        public String F_CargarGrillaVaciaConsultaArticulo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsuArticulo_html = "";
            int int_resultado_operacion = 0;

            try
            {
                P_Inicializar_GrillaVacia_Articulo();
                str_grvConsuArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvConsultaArticulo);
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
                str_grvConsuArticulo_html;


            return str_resultado;

        }

        public String F_TipoCambio_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            Decimal TipoCambio = 0;
            int int_resultado_operacion = 0;


            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_TipoCambio(obj_parametros, ref TipoCambio);
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
                TipoCambio.ToString();


            return str_resultado;

        }

        public String F_VerUltimoPrecio_NET(String arg)
        {
            String str_resultado = "";
            String str_grvConsultaUltimosPrecios = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                //Agutierrez: se hizo la modificacion, debido a que ahora se mostrar un top y no el ultimo precio
                //P_VerUltimoPrecio(obj_parametros, ref Precio, ref Moneda, ref Fecha, ref Cantidad);
                P_VerUltimoPrecio(obj_parametros, ref grvConsultaUltimosPrecios);
                if (grvConsultaUltimosPrecios.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_UltimoPrecio();
                }
                else
                {
                    int_resultado_operacion = 1;
                    str_mensaje_operacion = MsgError;
                }
            }
            catch (Exception ex)
            {
                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;
            }

            str_grvConsultaUltimosPrecios = Mod_Utilitario.F_GetHtmlForControl(grvConsultaUltimosPrecios);

            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" +
                str_mensaje_operacion + "~" +
                str_grvConsultaUltimosPrecios;

            return str_resultado;
        }

        public String F_ActualizarPrecio_Net(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            Decimal Total = 0;
            Decimal SubTotal = 0;
            Decimal Igv = 0;
            Decimal Acuenta = 0;
            String MsgError = "";
            Int32 NotaPedido = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_ActualizarPrecios(obj_parametros, ref MsgError);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_CodigoTemporal"]);
                P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref Acuenta, ref NotaPedido);
                if (grvDetalleArticulo.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Detalle();
                str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);

                int_resultado_operacion = 1;

                if (MsgError != "")
                {
                    int_resultado_operacion = 0;
                    str_mensaje_operacion = MsgError;
                }

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
                MsgError
                + "~" +
                Codigo.ToString()
                + "~" +
                str_grvDetalleArticulo_html
                 + "~" +
               Math.Round(Total, 2).ToString()
                + "~" +
                Math.Round(Igv, 2).ToString()
                 + "~" +
                Math.Round(SubTotal, 2).ToString()
                      + "~" +
                Math.Round(Acuenta, 2).ToString()
                + "~" +
                Convert.ToInt32(NotaPedido);

            return str_resultado;

        }

        public String F_PrecioMoneda_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvPrecioMoneda_html = "";

            int int_resultado_operacion = 0;

            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_PrecioMoneda(obj_parametros, ref grvPrecioMoneda);
                if (grvPrecioMoneda.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_PrecioMoneda();

                str_grvPrecioMoneda_html = Mod_Utilitario.F_GetHtmlForControl(grvPrecioMoneda);
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
                str_grvPrecioMoneda_html;


            return str_resultado;

        }

        public String F_EliminarRegistro_Net(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EliminarRegistro(obj_parametros, ref str_mensaje_operacion);
                P_Buscar(obj_parametros, ref grvConsulta);
                if (grvConsulta.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Consulta();
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

        public String F_FacturacionOC_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            String str_grvDetalleOC_html = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_FacturacionOC(obj_parametros, ref grvDetalleOC);

                if (grvDetalleOC.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_DetalleOC();
                    str_mensaje_operacion = "No se encontraron registros.";
                }
                else
                    str_mensaje_operacion = "";

                str_grvDetalleOC_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleOC);

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
                str_grvDetalleOC_html;

            return str_resultado;

        }

        public String F_Devolucion_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleOC_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Devolucion(obj_parametros, ref str_mensaje_operacion);
                P_FacturacionOC(obj_parametros, ref grvDetalleOC);

                if (grvDetalleOC.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_DetalleOC();
                    str_mensaje_operacion = "No se encontraron registros.";
                }



                str_grvDetalleOC_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleOC);

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
                str_grvDetalleOC_html;

            return str_resultado;

        }

        public String F_ReemplazarFactura_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            String NroRuc = "";
            String Direccion = "";
            String Distrito = "";
            String Cliente = "";
            String FechaTraslado = "";
            String Transportista = "";
            String Placa = "";
            String NroLicencia = "";
            String NumGuia = "";
            String Destino = "";
            String SerieDoc = "";
            String NumeroDoc = "";
            String FechaEmision = "";
            String FechaVencimiento = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            int CodCliente = 0;
            int CodMoneda = 0;
            int CodDepartamento = 0;
            int CodProvincia = 0;
            int CodDistrito = 0;
            int CodFormaPago = 0;
            int CodFacturaAnterior = 0;
            int CodTransportista = 0;
            int CodVendedor = 0;
            int NotaPedido = 0;
            Decimal Total = 0;
            Decimal SubTotal = 0;
            Decimal Igv = 0;
            Decimal AcuentaNV = 0;

            String MarcaVehiculo = "";
            String DireccionTrans = "";
            String NroBultos = "";
            String Peso = "";
            String PlacaVehiculo = "";

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_ValidarFactura(obj_parametros, ref str_mensaje_operacion);

                if (str_mensaje_operacion == "")
                {
                    P_ReemplazarFactura(obj_parametros, ref NroRuc, ref Codigo, ref CodCliente, ref CodMoneda, ref CodDepartamento,
                    ref CodProvincia, ref CodDistrito, ref Direccion, ref Distrito, ref Cliente, ref CodFormaPago, ref CodFacturaAnterior,
                    ref CodTransportista, ref Transportista, ref Placa, ref NroLicencia, ref NumGuia, ref Destino, ref FechaTraslado,
                    ref NumeroDoc, ref CodVendedor, ref FechaEmision, ref FechaVencimiento, ref SerieDoc,
                    ref MarcaVehiculo, ref DireccionTrans, ref NroBultos, ref Peso, ref PlacaVehiculo);

                    //P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref AcuentaNV, ref NotaPedido);
                    P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref AcuentaNV);

                    str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);
                    int_resultado_operacion = 1;
                }
                else
                    int_resultado_operacion = 0;
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
                Codigo.ToString()
                + "~" +
                str_grvDetalleArticulo_html
                 + "~" +
                Math.Round(Total, 2).ToString()
                + "~" +
                Math.Round(Igv, 2).ToString()
                 + "~" +
                Math.Round(SubTotal, 2).ToString()
                 + "~" +
                Math.Round(AcuentaNV, 2).ToString()
                + "~" +
                NroRuc
                + "~" +
                Cliente
                + "~" +
                CodMoneda.ToString()
                + "~" +
                Distrito
                + "~" +
                Direccion
                + "~" +
                CodFormaPago.ToString()
                + "~" +
                CodCliente.ToString()
                + "~" +
                CodDepartamento.ToString()
                + "~" +
                CodProvincia.ToString()
                + "~" +
                CodDistrito.ToString()
                + "~" +
                CodFacturaAnterior.ToString()
                + "~" +
                CodTransportista.ToString()
                 + "~" +
                Transportista
                + "~" +
                Placa
                + "~" +
                NroLicencia
                + "~" +
                NumGuia
                + "~" +
                Destino
                + "~" +
                FechaTraslado
                + "~" +
                NumeroDoc
                + "~" +
                CodVendedor.ToString()
                + "~" +
                FechaEmision
                + "~" +
                FechaVencimiento
                + "~" +
                SerieDoc
                + "~" +
                MarcaVehiculo
                + "~" +
                DireccionTrans
                + "~" +
                NroBultos
                + "~" +
                Peso
                + "~" +
                PlacaVehiculo;

            return str_resultado;
        }
        
        public void P_CargarGrillaTemporal(Hashtable objTablaFiltro, Int32 Codigo, ref GridView grvDetalle,
                                          ref Decimal SubTotalFactura, ref Decimal IgvFactura, ref Decimal TotalFactura, ref Decimal Acuenta)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();
            objOperacion = new DocumentoVentaCabCN();

            DataTable dta_consulta = null;

            objEntidad.Igv = Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]);
            objEntidad.CodDocumentoVenta = Codigo;

            dta_consulta = objOperacion.F_TemporalFacturacionDet_Listar(objEntidad);

            if (dta_consulta.Rows.Count > 0)
            {
                if (Convert.ToInt32(objTablaFiltro["Filtro_NotaPedido"]) == 1)
                {
                    for (int j = 0; j < dta_consulta.Rows.Count; j++)
                    {
                        if (Convert.ToDecimal(dta_consulta.Rows[j]["CodTipoProducto"]) == 1)
                            TotalFactura += Convert.ToDecimal(dta_consulta.Rows[j]["Importe"]);
                    }
                }
                else
                {
                    for (int j = 0; j < dta_consulta.Rows.Count; j++)
                    {
                        TotalFactura += Convert.ToDecimal(dta_consulta.Rows[j]["Importe"]);
                        Acuenta += Convert.ToDecimal(dta_consulta.Rows[j]["Acuenta"]);
                    }
                }

                SubTotalFactura = TotalFactura / Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]);
                IgvFactura = SubTotalFactura * (Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]) - 1);
            }
            grvDetalle.DataSource = dta_consulta;
            grvDetalle.DataBind();
        }
       
        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_TipoPlan, ref DropDownList ddl_Estado,
            ref DropDownList ddl_EstadoConsulta, ref DropDownList ddl_TipoPlanConsulta)
        {
            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;

            DataTable dta_consulta = null;
            
            objEntidad = new TCCorrelativoCE();

            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodDoc"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);

            objOperacion = new TCCorrelativoCN();


            VehiculoTipoPlanCE objEntidadDet =  new VehiculoTipoPlanCE();
            VehiculoTipoPlanCN objOperacionDet = new VehiculoTipoPlanCN();
            dta_consulta = null;
            dta_consulta = objOperacionDet.F_VehiculoTipoPlan_Listar(objEntidadDet);

            ddl_TipoPlan.Items.Clear();

            ddl_TipoPlan.DataSource = dta_consulta;
            ddl_TipoPlan.DataTextField = "Descripcion";
            ddl_TipoPlan.DataValueField = "CodVehiculoTipoPlan";
            ddl_TipoPlan.DataBind();

            ddl_TipoPlanConsulta.Items.Clear();

            ddl_TipoPlanConsulta.DataSource = dta_consulta;
            ddl_TipoPlanConsulta.DataTextField = "Descripcion";
            ddl_TipoPlanConsulta.DataValueField = "CodVehiculoTipoPlan";
            ddl_TipoPlanConsulta.DataBind();

            ddl_TipoPlanConsulta.Items.Insert(0, new ListItem("TODOS", "0"));

            TCConceptosDetCE objEntidadConceptosDet = new TCConceptosDetCE();
            TCConceptosDetCN objOperacionConceptosDet = new TCConceptosDetCN();
            dta_consulta = null;
            objEntidadConceptosDet.CodConcepto = 27;
            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);

            ddl_Estado.Items.Clear();

            ddl_Estado.DataSource = dta_consulta;
            ddl_Estado.DataTextField = "DscAbvConcepto";
            ddl_Estado.DataValueField = "CodConcepto";
            ddl_Estado.DataBind();

            dta_consulta = null;
            objEntidadConceptosDet.CodConcepto = 27;
            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);

            ddl_EstadoConsulta.Items.Clear();

            ddl_EstadoConsulta.DataSource = dta_consulta;
            ddl_EstadoConsulta.DataTextField = "DscAbvConcepto";
            ddl_EstadoConsulta.DataValueField = "CodConcepto";
            ddl_EstadoConsulta.DataBind();
            ddl_EstadoConsulta.Items.Insert(0, new ListItem("TODOS", "0"));
           
        }

        public void P_Series_Documentos(Hashtable objTablaFiltro, ref DropDownList ddl_serie, ref DropDownList ddl_serieconsulta)
        {

            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;

            DataTable dta_consulta = null;


            int iCodEmpresa = 3;

            objEntidad = new TCCorrelativoCE();

            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodDoc"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodEmpresa = iCodEmpresa;

            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_serie.Items.Clear();

            ddl_serie.DataSource = dta_consulta;
            ddl_serie.DataTextField = "SerieDoc";
            ddl_serie.DataValueField = "CodSerie";
            ddl_serie.DataBind();

            ddl_serieconsulta.Items.Clear();

            ddl_serieconsulta.DataSource = dta_consulta;
            ddl_serieconsulta.DataTextField = "SerieDoc";
            ddl_serieconsulta.DataValueField = "CodSerie";
            ddl_serieconsulta.DataBind();
        }
        
        public void P_Obtener_TipoCambio(Hashtable objTablaFiltro, ref Decimal TipoCambio)
        {

            TCTipoCambioCE objEntidad = null;
            TCTipoCambioCN objOperacion = null;

            DataTable dta_consulta = null;

            //
            //int iCodEmpresa = 3;

            objEntidad = new TCTipoCambioCE();

            objEntidad.Fecha = Convert.ToDateTime(objTablaFiltro["Filtro_Fecha"]);

            objOperacion = new TCTipoCambioCN();

            dta_consulta = objOperacion.F_TCTipoCambio_Select(objEntidad);

            if (dta_consulta.Rows.Count > 0)
                TipoCambio = Convert.ToDecimal(dta_consulta.Rows[0]["TC_Venta"]);



        }

        public void P_Obtener_NumeroCorrelativo(Hashtable objTablaFiltro, ref String Numero)
        {
            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new TCCorrelativoCE();

            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodDoc"]);
            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_SerieDoc"]);
            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);

            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Numero_Select(objEntidad);

            if (dta_consulta.Rows.Count > 0)
                Numero = Convert.ToString(dta_consulta.Rows[0]["NumeroDoc"]);
        }

        public void P_Inicializar_GrillaVacia_Articulo()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();

            dta_consultaarticulo.Columns.Add("CodProducto", typeof(string));
            dta_consultaarticulo.Columns.Add("CodUnidadVenta", typeof(string));
            dta_consultaarticulo.Columns.Add("Costo", typeof(string));
            dta_consultaarticulo.Columns.Add("CodigoInterno", typeof(string));
            dta_consultaarticulo.Columns.Add("CodigoProducto", typeof(string));
            dta_consultaarticulo.Columns.Add("Producto", typeof(string));
            dta_consultaarticulo.Columns.Add("Stock", typeof(string));
            dta_consultaarticulo.Columns.Add("UM", typeof(string));
            dta_consultaarticulo.Columns.Add("Precio1", typeof(string));
            dta_consultaarticulo.Columns.Add("Precio2", typeof(string));
            dta_consultaarticulo.Columns.Add("Precio3", typeof(string));
            dta_consultaarticulo.Columns.Add("Moneda", typeof(string));

            dta_consultaarticulo.Columns.Add("Medida", typeof(string));
            dta_consultaarticulo.Columns.Add("Marca", typeof(string));
            dta_consultaarticulo.Columns.Add("Modelo", typeof(string));
            dta_consultaarticulo.Columns.Add("Posicion", typeof(string));
            dta_consultaarticulo.Columns.Add("Descripcion", typeof(string));
            dta_consultaarticulo.Columns.Add("Anio", typeof(string));
            dta_consultaarticulo.Columns.Add("Codigo2", typeof(string));
            dta_consultaarticulo.Columns.Add("FlagProductoInicial", typeof(string));
            dta_consultaarticulo.Columns.Add("CodProductoAzure", typeof(string));
            dta_consultaarticulo.Columns.Add("CostoConIgv", typeof(string));
          //  dta_consultaarticulo.Columns.Add("CodTipoProducto", typeof(string));   

            dtr_consultafila = dta_consultaarticulo.NewRow();

            dtr_consultafila[0] = "";
            dtr_consultafila[1] = "";
            dtr_consultafila[2] = "";
            dtr_consultafila[3] = "";
            dtr_consultafila[4] = "";
            dtr_consultafila[5] = "";
            dtr_consultafila[6] = "";
            dtr_consultafila[7] = "";
            dtr_consultafila[8] = "";
            dtr_consultafila[9] = "";
            dtr_consultafila[10] = "";


            dta_consultaarticulo.Rows.Add(dtr_consultafila);

            //display none a la columna de costo, en el caso de que ese esté excluido segun lamda de abajo
            if (PermisoVerCosto == false)
                    grvConsultaArticulo.Columns[6].Visible = false;

            grvConsultaArticulo.DataSource = dta_consultaarticulo;
            grvConsultaArticulo.DataBind();
        }

        public void P_Inicializar_GrillaVacia_Consulta()
        {
            DataTable dta_consulta = null;
            DataRow dtr_filaconsulta = null;

            dta_consulta = new DataTable();

            dta_consulta.Columns.Add("Descripcion", typeof(string));
            dta_consulta.Columns.Add("Codigo", typeof(string));
            dta_consulta.Columns.Add("CodEstado", typeof(string));
            dta_consulta.Columns.Add("CodVehiculoTipoPlan", typeof(string));
            dta_consulta.Columns.Add("Kilometraje", typeof(string));
            dta_consulta.Columns.Add("Recorrido", typeof(string));
            dta_consulta.Columns.Add("TiempoTrabajo", typeof(string));
            dta_consulta.Columns.Add("TipoPlan", typeof(string));
            dta_consulta.Columns.Add("Estado", typeof(string));


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

            dta_consulta.Rows.Add(dtr_filaconsulta);

            grvConsulta.DataSource = dta_consulta;
            grvConsulta.DataBind();
        }

        public void P_Inicializar_GrillaVacia_Detalle()
        {
            DataTable dta_consultadetalle = null;
            DataRow dtr_filadetalle = null;

            dta_consultadetalle = new DataTable();

            dta_consultadetalle.Columns.Add("CodDetalle", typeof(string));
            dta_consultadetalle.Columns.Add("CodArticulo", typeof(string));
            dta_consultadetalle.Columns.Add("CodigoProducto", typeof(string));
            dta_consultadetalle.Columns.Add("Producto", typeof(string));
            dta_consultadetalle.Columns.Add("Cantidad", typeof(string));
            dta_consultadetalle.Columns.Add("UM", typeof(string));

            dtr_filadetalle = dta_consultadetalle.NewRow();

            dtr_filadetalle[0] = "";
            dtr_filadetalle[1] = "";
            dtr_filadetalle[2] = "";
            dtr_filadetalle[3] = "";
            dtr_filadetalle[4] = "";
            dtr_filadetalle[5] = "";

            dta_consultadetalle.Rows.Add(dtr_filadetalle);

            grvDetalleArticulo.DataSource = dta_consultadetalle;
            grvDetalleArticulo.DataBind();
        }

        public void P_Inicializar_GrillaVacia_DetalleOC()
        {
            DataTable dta_consultadetalleoc = null;
            DataRow dtr_filadetalle = null;

            dta_consultadetalleoc = new DataTable();

            dta_consultadetalleoc.Columns.Add("CodDetalle", typeof(string));
            dta_consultadetalleoc.Columns.Add("CodArticulo", typeof(string));
            dta_consultadetalleoc.Columns.Add("Codigo", typeof(string));
            dta_consultadetalleoc.Columns.Add("Producto", typeof(string));
            dta_consultadetalleoc.Columns.Add("Cantidad", typeof(string));
            dta_consultadetalleoc.Columns.Add("UM", typeof(string));
            dta_consultadetalleoc.Columns.Add("CodUndMedida", typeof(string));
            dta_consultadetalleoc.Columns.Add("Precio", typeof(string));
            dta_consultadetalleoc.Columns.Add("Numero", typeof(string));
            dta_consultadetalleoc.Columns.Add("CodMovimiento", typeof(string));
            dta_consultadetalleoc.Columns.Add("SerieDoc", typeof(string));
            dta_consultadetalleoc.Columns.Add("NumeroDoc", typeof(string));
            dta_consultadetalleoc.Columns.Add("CostoUnitario", typeof(string));
            dta_consultadetalleoc.Columns.Add("Fecha", typeof(string));
            dta_consultadetalleoc.Columns.Add("FechaAnexo", typeof(string));

            dtr_filadetalle = dta_consultadetalleoc.NewRow();

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

            dta_consultadetalleoc.Rows.Add(dtr_filadetalle);

            grvDetalleOC.DataSource = dta_consultadetalleoc;
            grvDetalleOC.DataBind();
        }

        public void P_Inicializar_GrillaVacia_DetalleGuia()
        {
            DataTable dta_consultadetalleoc = null;
            DataRow dtr_filadetalle = null;

            dta_consultadetalleoc = new DataTable();

            dta_consultadetalleoc.Columns.Add("CodDetalle", typeof(string));
            dta_consultadetalleoc.Columns.Add("CodArticulo", typeof(string));
            dta_consultadetalleoc.Columns.Add("Codigo", typeof(string));
            dta_consultadetalleoc.Columns.Add("Producto", typeof(string));
            dta_consultadetalleoc.Columns.Add("Cantidad", typeof(string));
            dta_consultadetalleoc.Columns.Add("UM", typeof(string));
            dta_consultadetalleoc.Columns.Add("CodUndMedida", typeof(string));
            dta_consultadetalleoc.Columns.Add("Precio", typeof(string));
            dta_consultadetalleoc.Columns.Add("Numero", typeof(string));
            dta_consultadetalleoc.Columns.Add("CodMovimiento", typeof(string));
            dta_consultadetalleoc.Columns.Add("SerieDoc", typeof(string));
            dta_consultadetalleoc.Columns.Add("NumeroDoc", typeof(string));
            dta_consultadetalleoc.Columns.Add("CostoUnitario", typeof(string));
            dta_consultadetalleoc.Columns.Add("Almacen", typeof(string));
            dta_consultadetalleoc.Columns.Add("CodDepartamento", typeof(string));
            dta_consultadetalleoc.Columns.Add("FechaEmision", typeof(string));
            dta_consultadetalleoc.Columns.Add("Marca", typeof(string));

            dtr_filadetalle = dta_consultadetalleoc.NewRow();

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

            dta_consultadetalleoc.Rows.Add(dtr_filadetalle);

            grvFacturacionGuia.DataSource = dta_consultadetalleoc;
            grvFacturacionGuia.DataBind();

        }

        public void P_Inicializar_GrillaVacia_PrecioMoneda()
        {
            DataTable dta_consultapreciomoneda = null;
            DataRow dtr_filadetalle = null;

            dta_consultapreciomoneda = new DataTable();

            dta_consultapreciomoneda.Columns.Add("CodProducto", typeof(string));
            dta_consultapreciomoneda.Columns.Add("Precio1", typeof(string));
            dta_consultapreciomoneda.Columns.Add("Precio2", typeof(string));
            dta_consultapreciomoneda.Columns.Add("Precio3", typeof(string));
            dta_consultapreciomoneda.Columns.Add("Moneda", typeof(string));

            dtr_filadetalle = dta_consultapreciomoneda.NewRow();

            dtr_filadetalle[0] = "";
            dtr_filadetalle[1] = "";
            dtr_filadetalle[2] = "";
            dtr_filadetalle[3] = "";
            dtr_filadetalle[4] = "";

            dta_consultapreciomoneda.Rows.Add(dtr_filadetalle);

            grvPrecioMoneda.DataSource = dta_consultapreciomoneda;
            grvPrecioMoneda.DataBind();

        }

        public void P_Inicializar_GrillaVacia_UltimoPrecio()
        {
            DataTable dta_consultadetallenv = null;
            DataRow dtr_filadetalle = null;

            dta_consultadetallenv = new DataTable();

            dta_consultadetallenv.Columns.Add("Precio", typeof(string));
            dta_consultadetallenv.Columns.Add("Moneda", typeof(string));
            dta_consultadetallenv.Columns.Add("Cantidad", typeof(string));
            dta_consultadetallenv.Columns.Add("Fecha", typeof(string));
            dta_consultadetallenv.Columns.Add("Factura", typeof(string));

            dtr_filadetalle = dta_consultadetallenv.NewRow();

            dtr_filadetalle[0] = "";
            dtr_filadetalle[1] = "";
            dtr_filadetalle[2] = "";
            dtr_filadetalle[3] = "";
            dtr_filadetalle[4] = "";

            dta_consultadetallenv.Rows.Add(dtr_filadetalle);

            grvConsultaUltimosPrecios.DataSource = dta_consultadetallenv;
            grvConsultaUltimosPrecios.DataBind();
        }

        public void P_Cargar_Grilla(Hashtable objTablaFiltro, ref GridView grvConsulta)
        {
            LGProductosCE objEntidad = null;
            LGProductosCN objOperacion = null;
            
            int iCodEmpresa = 3;
            int CodTipoProducto = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoProducto"]);

            if (iCodEmpresa == 3 && Convert.ToInt32(objTablaFiltro["Filtro_Servicio"]) == 1)
                CodTipoProducto = 1;

            objEntidad = new LGProductosCE();
            objOperacion = new LGProductosCN();
            objEntidad.CodEmpresa = iCodEmpresa;
            objEntidad.DscProducto = Convert.ToString(objTablaFiltro["Filtro_DscProducto"]).Trim().ToUpper();
            objEntidad.CodTipoProducto = CodTipoProducto;
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);

            //display none a la columna de costo, en el caso de que ese esté excluido segun lamda de abajo
            if (PermisoVerCosto == false)
                grvConsultaArticulo.Columns[6].Visible = false;
            
            grvConsulta.DataSource = objOperacion.F_LGProductos_Select_MantenimientoPlan(objEntidad);
            grvConsulta.DataBind();
        }

        public void P_AgregarTemporal(Hashtable objTablaFiltro, ref Int32 Codigo, ref String MsgError)
        {
            VehiculoPlanMantenimientoCE objEntidad = null;
            VehiculoPlanMantenimientoCN objOperacion = null;

            String XmlDetalle = "";

            objEntidad = new VehiculoPlanMantenimientoCE();

           
            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_XmlDetalle"].ToString());

            foreach (dynamic item in jArr2)
            {
                XmlDetalle = XmlDetalle + "<D ";
                XmlDetalle = XmlDetalle + " CodProducto = '" + item.CodProducto + "'";
                XmlDetalle = XmlDetalle + " CodDetalle = '" + item.CodDetalle + "'";
                XmlDetalle = XmlDetalle + " CodTipoProducto = '" + item.CodTipoProducto + "'";
                XmlDetalle = XmlDetalle + " Cantidad = '" + item.Cantidad + "'";
                XmlDetalle = XmlDetalle + " CodEstado = '" + item.CodEstado + "'";
                XmlDetalle = XmlDetalle + " />";
            }

            XmlDetalle = "<R><XmlLC> " + XmlDetalle + "</XmlLC></R>";
            XmlDetalle = "<?xml version=" + '\u0022' + "1.0" + '\u0022' + " encoding=" + '\u0022' + "iso-8859-1" + '\u0022' + "?>" + XmlDetalle;

            objEntidad.XmlDetalle = XmlDetalle;

            objOperacion = new VehiculoPlanMantenimientoCN();

            if (Convert.ToInt32(objTablaFiltro["Filtro_CodigoTemporal"]) == 0)
            {
                objOperacion.F_TemporalVehiculoPlanMantenimientoDet_Insert(objEntidad);
                Codigo = objEntidad.CodVehiculoPlanMantenimientoCab;
            }
            else
            {
                objEntidad.CodVehiculoPlanMantenimientoCab = Convert.ToInt32(objTablaFiltro["Filtro_CodigoTemporal"]);
                objOperacion.F_TemporalVehiculoPlanMantenimientoDetalle_Insert(objEntidad);
                Codigo = Convert.ToInt32(objTablaFiltro["Filtro_CodigoTemporal"]);
            }
            MsgError = objEntidad.MsgError;
        }

        public void P_EliminarTemporal(Hashtable objTablaFiltro, ref String MsgError)
        {

            VehiculoPlanMantenimientoDetCE objEntidad = null;
            VehiculoPlanMantenimientoDetCN objOperacion = null;

            String XmlDetalle = "";

            objEntidad = new VehiculoPlanMantenimientoDetCE();

            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_XmlDetalle"].ToString());

            foreach (dynamic item in jArr2)
            {
                XmlDetalle = XmlDetalle + "<D ";
                XmlDetalle = XmlDetalle + " CodTemporalPlanMantenimientoDet = '" + item.CodDetalle + "'";
                XmlDetalle = XmlDetalle + " />";
            }

            XmlDetalle = "<R><XmlLC> " + XmlDetalle + "</XmlLC></R>";

            objEntidad.XmlDetalle = XmlDetalle;

            objOperacion = new VehiculoPlanMantenimientoDetCN();

            objOperacion.F_TemporalPlanMantenimientoDet_Eliminar(objEntidad);

            MsgError = objEntidad.MsgError;

        }
        
        public String F_StockAlmacenes_NET(String arg)
        {
            int int_resultado_operacion = 0;
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String grvNombre = "";
            String str_grv_Detalle_html = "";
            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                grvNombre = Convert.ToString(obj_parametros["Filtro_grvNombre"]);
                GridView grvDetalle = (GridView)grvConsultaArticulo.Rows[0].FindControl("grvDetalleKardex");

                DocumentoVentaDetCN objOperacion = new DocumentoVentaDetCN();
                DocumentoVentaDetCE objEntidad = new DocumentoVentaDetCE();

                objEntidad.CodProducto = Convert.ToInt32(obj_parametros["Filtro_CodProducto"]);
                objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);

                grvDetalle.DataSource = objOperacion.F_LGPRODUCTOS_STOCKDETALLE(objEntidad);
                grvDetalle.DataBind();

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
        
        public void P_CargarGrillaTemporal(Hashtable objTablaFiltro, Int32 Codigo, ref GridView grvDetalle,
            ref Decimal SubTotalFactura, ref Decimal IgvFactura, ref Decimal TotalFactura, ref Decimal Acuenta, ref Int32 NotaPedido)
        {
            VehiculoPlanMantenimientoCE objEntidad = null;
            VehiculoPlanMantenimientoCN objOperacion = null;

            objEntidad = new VehiculoPlanMantenimientoCE();
            objOperacion = new VehiculoPlanMantenimientoCN();

            DataTable dta_consulta = null;
            if (Codigo != 0)
            {

                objEntidad.CodVehiculoPlanMantenimientoCab = Codigo;

                dta_consulta = objOperacion.F_TemporalVehiculoPlanMantenimientoDet_Listar(objEntidad);
            }

            grvDetalle.DataSource = dta_consulta;
            grvDetalle.DataBind();

        }

        public void P_GrabarDocumento(Hashtable objTablaFiltro, ref String MsgError, ref Int32 Codigo)
        {
            VehiculoPlanMantenimientoCE objEntidad = new VehiculoPlanMantenimientoCE();
            VehiculoPlanMantenimientoCN objOperacion = new VehiculoPlanMantenimientoCN();

            objEntidad.CodEmpresa = 3;


            objEntidad.Descripcion = Convert.ToString(objTablaFiltro["Filtro_Descripcion"]);
            objEntidad.Kilometraje = Convert.ToDecimal(objTablaFiltro["Filtro_Kilometraje"]);
            //objEntidad.Recorrido = Convert.ToDecimal(objTablaFiltro["Filtro_Recorrido"]);
            objEntidad.TiempoTrabajo = Convert.ToDecimal(objTablaFiltro["Filtro_TiempoTrabajo"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            objEntidad.CodTipoPlan = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoPlan"]);
            objEntidad.CodDetalle = Convert.ToInt32(objTablaFiltro["Filtro_CodDetalle"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);
            objEntidad.CodVehiculoPlanMantenimientoAnterior = Convert.ToInt32(objTablaFiltro["Filtro_CodVehiculoPlanMantenimientoAnterior"]);

            if (objEntidad.CodVehiculoPlanMantenimientoAnterior > 0)
            {
                objOperacion.F_VehiculoPlanMantenimiento_Update(objEntidad);
            }
            else
            {
                objOperacion.F_VehiculoPlanMantenimiento_Insert(objEntidad);
            }

            MsgError = objEntidad.MsgError;
            Codigo = objEntidad.Codigo;
        }



        public void P_LlenarGrillaVacia_Detalle()
        {
            DataTable dta_consultadetalle = null;
            DataRow dtr_filadetalle = null;

            dta_consultadetalle = new DataTable();

            dta_consultadetalle.Columns.Add("CodDetalle", typeof(string));
            dta_consultadetalle.Columns.Add("CodArticulo", typeof(string));
            dta_consultadetalle.Columns.Add("CodigoProducto", typeof(string));
            dta_consultadetalle.Columns.Add("Producto", typeof(string));
            dta_consultadetalle.Columns.Add("Cantidad", typeof(string));
            dta_consultadetalle.Columns.Add("UM", typeof(string));
            dta_consultadetalle.Columns.Add("Precio", typeof(string));
            dta_consultadetalle.Columns.Add("Importe", typeof(string));
            dta_consultadetalle.Columns.Add("CodDetalleOC", typeof(string));
            dta_consultadetalle.Columns.Add("Acuenta", typeof(string));
            dta_consultadetalle.Columns.Add("CodTipoDoc", typeof(string));
            dta_consultadetalle.Columns.Add("Factura", typeof(string));
            dta_consultadetalle.Columns.Add("P1", typeof(string));
            dta_consultadetalle.Columns.Add("P2", typeof(string));
            dta_consultadetalle.Columns.Add("P3", typeof(string));

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

            dta_consultadetalle.Rows.Add(dtr_filadetalle);

            grvDetalleArticulo.DataSource = dta_consultadetalle;
            grvDetalleArticulo.DataBind();
        }

        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {
            
            VehiculoPlanMantenimientoCE objEntidad = null;
            VehiculoPlanMantenimientoCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new VehiculoPlanMantenimientoCE();
            objOperacion = new VehiculoPlanMantenimientoCN();
            objEntidad.Descripcion = Convert.ToString(objTablaFiltro["Filtro_Descripcion"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstadoConsulta"]);
            objEntidad.CodTipoPlan = Convert.ToInt32(objTablaFiltro["Filtro_TipoPlanConsulta"]);


            dta_consulta = objOperacion.F_VehiculoPlanMantenimiento_Listar(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();
        }

        public void P_AnularRegistro(Hashtable objTablaFiltro, ref String Mensaje)
        {
            ProformaCabCE objEntidad = new ProformaCabCE();
            ProformaCabCN objOperacion = new ProformaCabCN();
            
            objEntidad.CodProforma = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
                  
            objOperacion.F_Proformas_Anulacion(objEntidad);

            Mensaje = objEntidad.MsgError;
        }

        public void F_ActivarVenta(Hashtable objTablaFiltro, ref String Mensaje)
        {
            ProformaCabCE objEntidad = null;
            ProformaCabCN objOperacion = null;

            objEntidad = new ProformaCabCE();

            objEntidad.CodProforma = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);

            objOperacion = new ProformaCabCN();

            objOperacion.F_ProformaCabActivacion(objEntidad);

            Mensaje = objEntidad.MsgError;
        }

        public void P_TipoCambio(Hashtable objTablaFiltro, ref Decimal TC)
        {

            TCTipoCambioCE objEntidad = null;
            TCTipoCambioCN objOperacion = null;

            objEntidad = new TCTipoCambioCE();
            objEntidad.Fecha = Convert.ToDateTime(objTablaFiltro["Filtro_Emision"]);

            objOperacion = new TCTipoCambioCN();

            DataTable dta_consulta = null;

            dta_consulta = objOperacion.F_TCTipoCambio_Select(objEntidad);

            if (dta_consulta.Rows.Count == 0)
                TC = 0;
            else
                TC = Convert.ToDecimal(dta_consulta.Rows[0][0]);


        }

        public void P_VerUltimoPrecio(Hashtable objTablaFiltro, ref GridView GrillaUltimosPrecios)
        {

            LGProductosCE objEntidad = null;
            LGProductosCN objOperacion = null;

            objEntidad = new LGProductosCE();
            objEntidad.CodProducto = Convert.ToInt32(objTablaFiltro["Filtro_CodProducto"]);
            objEntidad.CodTipoOperacion = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoOperacion"]);
            objEntidad.CodCtaCte = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            int MaxRows = Convert.ToInt32(objTablaFiltro["Filtro_Top"]); //Agutierrez

            objOperacion = new LGProductosCN();

            DataTable dta_consulta = null;

            dta_consulta = objOperacion.F_LGProductos_UltimoPrecio(objEntidad, MaxRows);
            GrillaUltimosPrecios.DataSource = dta_consulta;
            GrillaUltimosPrecios.DataBind();
        }

        public void P_ActualizarPrecios(Hashtable objTablaFiltro, ref String MsgError)
        {
            VehiculoPlanMantenimientoDetCE objEntidad = null;
            VehiculoPlanMantenimientoDetCN objOperacion = null;

            objEntidad = new VehiculoPlanMantenimientoDetCE();

            objEntidad.CodVehiculoPlanMantenimientoDet = Convert.ToInt32(objTablaFiltro["Filtro_CodDetDocumentoVenta"]);
            objEntidad.Cantidad = Convert.ToInt32(objTablaFiltro["Filtro_Cantidad"]);

            objOperacion = new VehiculoPlanMantenimientoDetCN();

            objOperacion.F_TemporalPlanMantenimientoDet_Update(objEntidad);

            MsgError = objEntidad.MsgError;
        }
        
        public void P_PrecioMoneda(Hashtable objTablaFiltro, ref GridView grillaPrecioMoneda)
        {

            LGProductosCE objEntidad = null;
            LGProductosCN objOperacion = null;

            objEntidad = new LGProductosCE();
            objEntidad.CodProducto = Convert.ToInt32(objTablaFiltro["Filtro_CodProducto"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
            objEntidad.FechaRegistro = Convert.ToDateTime(objTablaFiltro["Filtro_Fecha"]);

            objOperacion = new LGProductosCN();

            grillaPrecioMoneda.DataSource = objOperacion.F_LGProductos_VerPrecio_Moneda(objEntidad);
            grillaPrecioMoneda.DataBind();

        }

        public void P_EliminarRegistro(Hashtable objTablaFiltro, ref String Mensaje)
        {
            VehiculoPlanMantenimientoCE objEntidad = new VehiculoPlanMantenimientoCE();
            VehiculoPlanMantenimientoCN objOperacion = new VehiculoPlanMantenimientoCN();


            objEntidad.CodVehiculoPlanMantenimientoCab = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);

            objOperacion.F_VehiculoPlanMantenimiento_Eliminar(objEntidad);

            Mensaje = objEntidad.MsgError;



        }

        public void P_FacturacionOC(Hashtable objTablaFiltro, ref GridView GrillaOC)
        {

            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);

            objOperacion = new DocumentoVentaCabCN();
            DataTable dta_consulta = null;

            dta_consulta = objOperacion.F_DocumentoVentaCab_OCXFacturar(objEntidad);

            GrillaOC.DataSource = dta_consulta;
            GrillaOC.DataBind();
        }

        public void P_Devolucion(Hashtable objTablaFiltro, ref String MsgError)
        {

            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            String XmlDetalle = "";

            objEntidad = new DocumentoVentaCabCE();

            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_XmlDetalle"].ToString());

            foreach (dynamic item in jArr2)
            {
                XmlDetalle = XmlDetalle + "<D ";
                XmlDetalle = XmlDetalle + " CodDetalle = '" + item.CodDetalle + "'";
                XmlDetalle = XmlDetalle + " CodArticulo = '" + item.CodArticulo + "'";
                XmlDetalle = XmlDetalle + " Cantidad = '" + item.Cantidad + "'";
                XmlDetalle = XmlDetalle + " CodUndMedida = '" + item.CodUndMedida + "'";
                XmlDetalle = XmlDetalle + " Costo = '" + item.Costo + "'";
                XmlDetalle = XmlDetalle + " CostoUnitario = '" + item.CostoUnitario + "'";
                XmlDetalle = XmlDetalle + " SerieDoc = '" + item.SerieDoc + "'";
                XmlDetalle = XmlDetalle + " NumeroDoc = '" + item.NumeroDoc + "'";
                XmlDetalle = XmlDetalle + " />";
            }

            XmlDetalle = "<R><XmlLC> " + XmlDetalle + "</XmlLC></R>";

            objEntidad.XmlDetalle = XmlDetalle;

            objEntidad.CodEmpresa = 3;
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.TasaIgv = Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]);
            objEntidad.CodTasa = Convert.ToInt32(objTablaFiltro["Filtro_CodTasa"]);
            objEntidad.TipoCambio = Convert.ToDecimal(objTablaFiltro["Filtro_TipoCambio"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
            objEntidad.CodCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
            objEntidad.CodTipoOperacion = 1;

            objOperacion = new DocumentoVentaCabCN();

            objOperacion.F_DocumentoVentaCab_DevolucionOC(objEntidad);

            MsgError = objEntidad.MsgError;

        }

        public String F_ImprimirFacturaTicket_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_json_factura = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                str_json_factura = P_ImprimirFacturaTicket(obj_parametros, ref str_mensaje_operacion);
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
                str_json_factura;


            return str_resultado;

        }

        public string P_ImprimirFacturaTicket(Hashtable objTablaFiltro, ref String Mensaje)
        {
            DocumentoVentaCabCE objEntidadFactura = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacionFactura = new DocumentoVentaCabCN();

            objEntidadFactura.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);
            objEntidadFactura.IP = GetIP().Trim();
            DataTable dtTabla = objOperacionFactura.F_DocumentoVentaCab_ImpresionFlagTicket_Insert(objEntidadFactura);

            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dtTabla);
            return JSONresult;
        }

        public String F_ReenvioMail_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_json_factura = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                str_mensaje_operacion = F_ReenvioMail(obj_parametros, ref str_mensaje_operacion);
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
                str_mensaje_operacion;


            return str_resultado;

        }

        public string F_ReenvioMail(Hashtable objTablaFiltro, ref String Mensaje)
        {
            DocumentoVentaCabCE objEntidadFactura = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacionFactura = new DocumentoVentaCabCN();

            objEntidadFactura.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);
            objEntidadFactura = objOperacionFactura.F_DocumentoVentaCab_ReenvioMail(objEntidadFactura);

            Mensaje = objEntidadFactura.MsgError;

            return Mensaje;
        }
        
        public void P_ActualizarDetalle(Hashtable objTablaFiltro, ref String MsgError)
        {
            DocumentoVentaDetCE objEntidad = null;
            DocumentoVentaDetCN objOperacion = null;

            objEntidad = new DocumentoVentaDetCE();

            objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodDocumentoVenta"]);
            objEntidad.FlagIgv = Convert.ToInt32(objTablaFiltro["Filtro_FlagIgv"]);

            objOperacion = new DocumentoVentaDetCN();

            objOperacion.F_TemporalFacturacionDet_Actualizar(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_ReemplazarCotizacion(Hashtable objTablaFiltro, ref String SerieDoc, ref Int32 Codigo, ref Int32 CodCliente,
    ref Int32 CodMoneda, ref String Emision, ref String Vencimiento, ref String Atencion, ref String Referencia,
    ref String Cliente, ref String NumeroDoc, ref Int32 CodProformaAnterior, ref Int32 FlagConCodigo)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodProforma = Convert.ToInt32(objTablaFiltro["Filtro_CodProforma"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new DocumentoVentaCabCN();
            DataTable dtTabla = null;

            dtTabla = objOperacion.F_ProformaCab_Reemplazar(objEntidad);

            if (dtTabla.Rows.Count > 0)
            {
                Atencion = dtTabla.Rows[0]["Atencion"].ToString();
                Codigo = Convert.ToInt32(dtTabla.Rows[0]["Codigo"]);
                CodCliente = Convert.ToInt32(dtTabla.Rows[0]["CodCliente"]);
                CodMoneda = Convert.ToInt32(dtTabla.Rows[0]["CodMoneda"]);
                Referencia = Convert.ToString(dtTabla.Rows[0]["Referencia"]);
                NumeroDoc = Convert.ToString(dtTabla.Rows[0]["NumeroDoc"]);
                Emision = Convert.ToString(dtTabla.Rows[0]["Emision"]);
                Vencimiento = Convert.ToString(dtTabla.Rows[0]["Vencimiento"]);
                SerieDoc = Convert.ToString(dtTabla.Rows[0]["SerieDoc"]);
                Cliente = Convert.ToString(dtTabla.Rows[0]["Cliente"]);
                CodProformaAnterior = Convert.ToInt32(dtTabla.Rows[0]["CodProformaAnterior"]);
            }
        }
        
        public void P_ValidarFactura(Hashtable objTablaFiltro, ref String Mensaje)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodDocumentoVenta"]);

            objOperacion = new DocumentoVentaCabCN();

            Mensaje = objOperacion.F_DocumentoVentaCab_Validar_Factura(objEntidad).MsgError;
        }

        public void P_ReemplazarFactura(Hashtable objTablaFiltro, ref String NroRuc, ref Int32 Codigo, ref Int32 CodCliente,
        ref Int32 CodMoneda, ref Int32 CodDepartamento, ref Int32 CodProvincia, ref Int32 CodDistrito, ref String Direccion,
        ref String Distrito, ref String Cliente, ref Int32 CodFormaPago, ref Int32 CodFacturaAnterior, ref Int32 CodTransportista,
        ref String Transportista, ref String Placa, ref String NroLicencia, ref String NumGuia, ref String Destino,
        ref String FechaTraslado, ref String NumeroDoc, ref Int32 CodVendedor, ref String FechaEmision, ref String FechaVencimiento, ref String SerieDoc,
        ref String MarcaVehiculo, ref String DireccionTrans, ref String NroBultos, ref String Peso, ref String PlacaVehiculo)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodDocumentoVenta"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new DocumentoVentaCabCN();
            DataTable dtTabla = null;

            dtTabla = objOperacion.F_DocumentoVentaCab_Reemplazar(objEntidad);

            if (dtTabla.Rows.Count > 0)
            {
                NroRuc = dtTabla.Rows[0]["NroRuc"].ToString();
                Codigo = Convert.ToInt32(dtTabla.Rows[0]["Codigo"]);
                CodCliente = Convert.ToInt32(dtTabla.Rows[0]["CodCliente"]);
                CodMoneda = Convert.ToInt32(dtTabla.Rows[0]["CodMoneda"]);
                CodDepartamento = Convert.ToInt32(dtTabla.Rows[0]["CodDepartamento"]);
                CodProvincia = Convert.ToInt32(dtTabla.Rows[0]["CodProvincia"]);
                CodDistrito = Convert.ToInt32(dtTabla.Rows[0]["CodDistrito"]);
                Direccion = Convert.ToString(dtTabla.Rows[0]["Direccion"]);
                Distrito = Convert.ToString(dtTabla.Rows[0]["Distrito"]);
                Cliente = Convert.ToString(dtTabla.Rows[0]["Cliente"]);
                CodFormaPago = Convert.ToInt32(dtTabla.Rows[0]["CodFormaPago"]);
                CodFacturaAnterior = Convert.ToInt32(dtTabla.Rows[0]["CodFacturaAnterior"]);
                FechaTraslado = Convert.ToString(dtTabla.Rows[0]["FechaTraslado"]);
                CodTransportista = Convert.ToInt32(dtTabla.Rows[0]["CodTransportista"]);
                Transportista = Convert.ToString(dtTabla.Rows[0]["Transportista"]);
                Placa = Convert.ToString(dtTabla.Rows[0]["Placa"]);
                NroLicencia = Convert.ToString(dtTabla.Rows[0]["NroLicencia"]);
                NumGuia = Convert.ToString(dtTabla.Rows[0]["NumGuia"]);
                Destino = Convert.ToString(dtTabla.Rows[0]["Destino"]);
                SerieDoc = Convert.ToString(dtTabla.Rows[0]["SerieDoc"]);
                NumeroDoc = Convert.ToString(dtTabla.Rows[0]["NumeroDoc"]);
                CodVendedor = Convert.ToInt32(dtTabla.Rows[0]["CodVendedor"]);
                FechaEmision = Convert.ToString(dtTabla.Rows[0]["FechaEmision"]);
                FechaVencimiento = Convert.ToString(dtTabla.Rows[0]["FechaVencimiento"]);
                MarcaVehiculo = Convert.ToString(dtTabla.Rows[0]["MarcaVehiculo"]);
                DireccionTrans = Convert.ToString(dtTabla.Rows[0]["DireccionTrans"]);
                NroBultos = Convert.ToString(dtTabla.Rows[0]["NroBultos"]);
                Peso = Convert.ToString(dtTabla.Rows[0]["Peso"]);
                PlacaVehiculo = Convert.ToString(dtTabla.Rows[0]["PlacaVehiculo"]);
            }
        }

        private string GetIP()
        {
            string visitorIPAddress = "";
            string IPHost = Dns.GetHostName();
            string IP = Dns.GetHostByName(IPHost).AddressList[0].ToString();
            return IP;
        }


        [WebMethod]
        //lista los almacenes que se van a mostrar en el grid de stocks
        public static jqTCAlmacenResult F_Inicializar_Tabla_Almacenes_Stocks_NET()
        {
            jqTCAlmacenResult data = new jqTCAlmacenResult();
            data.rows = new List<TCAlmacenCE>();
            TCAlmacenCE objEntidad = new TCAlmacenCE();
            TCAlmacenCN objOperacion = new TCAlmacenCN();
            objEntidad.Clave = "";
            try
            {
                DataTable dtb = objOperacion.F_TCAlmacenesExternos_Listar(1);
                foreach (DataRow i in dtb.Rows)
                {
                    //if (int.Parse(i["CodEmpresa"].ToString()) == 3 & int.Parse(i["CodAlmacen"].ToString()) == 2)
                    //{ } else
                    {
                        TCAlmacenCE newpr = new TCAlmacenCE();
                        newpr.Clave = i["Clave"].ToString();
                        newpr.Empresa = i["DscEmpresa"].ToString();
                        newpr.DscAlmacen = i["DscAlmacen"].ToString();
                        data.rows.Add(newpr);
                    }
                }
            }
            catch (Exception ex)
            { }
            finally
            { objOperacion = null; }

            return data;
        }
        public class jqTCAlmacenResult
        {
            public String msg { get; set; }
            public String ID_Imagen { get; set; }
            public int total { get; set; }
            public List<TCAlmacenCE> rows { get; set; }
        }

        [WebMethod]
        //busca el stock del almacen especificado //LOGICA VIEJA
        public static jqTCAlmacenStockResult F_Consulta_Stock_NET(string CodigoProducto, string Marca)
        {
            jqTCAlmacenStockResult data = new jqTCAlmacenStockResult();
            data.rows = new List<TCAlmacenCE>();
            TCAlmacenCE objEntidad = new TCAlmacenCE();
            TCAlmacenCN objOperacion = new TCAlmacenCN();

            //primero se buscan los datos de conexion faltantes
            try
            {
                TCAlmacenCE par = new TCAlmacenCE();
                par.CodigoProducto = CodigoProducto;
                par.Marca = Marca;
                DataTable dtDatos = (new TCAlmacenCN()).F_Consulta_Stock_Almacen_Externo(par);


                foreach (DataRow i in dtDatos.Rows)
                {
                    TCAlmacenCE newpr = new TCAlmacenCE();
                    newpr.Empresa = i["Empresa"].ToString();
                    newpr.Almacen = i["Almacen"].ToString();
                    newpr.Clave = newpr.Empresa.Replace(" ", "") + "_" + newpr.Almacen.Replace(" ", "");
                    newpr.Stock = decimal.Parse(i["Stock"].ToString());
                    data.rows.Add(newpr);
                }


            }
            catch (Exception ex)
            { }
            finally
            { objOperacion = null; }

            return data;
        }

        [WebMethod]
        public static jqTCAlmacenStockResult F_Consulta_Stock_Azure_NET(int CodProductoAzure, string CodigoInterno)
        {
            jqTCAlmacenStockResult data = new jqTCAlmacenStockResult();
            data.rows = new List<TCAlmacenCE>();
            TCAlmacenCE objEntidad = new TCAlmacenCE();
            TCAlmacenCN objOperacion = new TCAlmacenCN();

            //primero se buscan los datos de conexion faltantes
            try
            {
                TCAlmacenCE par = new TCAlmacenCE();
                DataTable dtAlmacenes = (new TCAlmacenCN()).F_TCAlmacenesExternos_Listar(0);
                DataTable dtStocksAzure = (new TCAlmacenCN()).F_Consulta_Stock_Azure(CodProductoAzure, CodigoInterno);
                foreach (DataRow i in dtAlmacenes.Rows)
                {
                    if (i["FlagAlmacenLocal"].ToString() == "0")
                    {
                        TCAlmacenCE newpr = new TCAlmacenCE();
                        newpr.Empresa = i["DscEmpresa"].ToString();
                        newpr.Almacen = i["DscAlmacen"].ToString();
                        newpr.Clave = newpr.Empresa.Replace(" ", "") + "_" + newpr.Almacen.Replace(" ", "");
                        newpr.ConsultadoSN = 0;
                        newpr.Stock = 0;
                        if (dtStocksAzure.Rows.Count > 0)
                        {
                            newpr.ConsultadoSN = 1;
                            newpr.Stock = decimal.Parse(dtStocksAzure.Rows[0][i["NombreClaveAzure"].ToString()].ToString());
                        }
                        data.rows.Add(newpr);
                    }
                }


            }
            catch (Exception ex)
            { }
            finally
            { objOperacion = null; }

            return data;
        }
        public class jqTCAlmacenStockResult
        {
            public String msg { get; set; }
            public String ID_Imagen { get; set; }
            public int total { get; set; }
            public List<TCAlmacenCE> rows { get; set; }
        }




        [WebMethod]
        //busca el stock del almacen especificado
        public static jqProformasResult F_Consulta_Cotizaciones_Pendientes_NET(int CodAlmacen)
        {
            jqProformasResult data = new jqProformasResult();
            ProformaCabCE par = new ProformaCabCE() { CodEmpresa = 3, CodAlmacen = CodAlmacen, CodEstado = 6 };
            data.rows = (new ProformaCabCN()).F_ProformaCab_ListarXEstado(par);
            return data;
        }
        public class jqProformasResult
        {
            public String msg { get; set; }
            public String ID_Imagen { get; set; }
            public int total { get; set; }
            public List<ProformaCabCE> rows { get; set; }
        }


        [WebMethod]
        //busca el stock del almacen especificado
        public static jqProformaDetResult F_Listar_Detalle_Proforma_NET(int CodProforma)
        {
            jqProformaDetResult data = new jqProformaDetResult();
            data.rows = new List<ProformaDetCE>();
            ProformaCabCE objEntidad = new ProformaCabCE();
            ProformaCabCN objOperacion = new ProformaCabCN();


            //primero se buscan los datos de conexion faltantes
            try
            {
                ProformaCabCE par = new ProformaCabCE();
                par.CodProforma = CodProforma;
                DataTable dtDatos = (new ProformaCabCN()).F_ProformaDet_ListarXCodigo(par);

                foreach (DataRow i in dtDatos.Rows)
                {
                    ProformaDetCE newpr = new ProformaDetCE();
                    newpr.CodDetalleProforma = int.Parse(i["CodDetalleProforma"].ToString());
                    newpr.CodProforma = int.Parse(i["CodProforma"].ToString());
                    newpr.CodArticulo = int.Parse(i["CodArticulo"].ToString());
                    newpr.Cantidad = decimal.Parse(i["Cantidad"].ToString());
                    newpr.Precio = decimal.Parse(i["Precio"].ToString());
                    newpr.Descripcion = i["Descripcion"].ToString();
                    newpr.CodUnidadMedida = int.Parse(i["CodUnidadVenta"].ToString());
                    data.rows.Add(newpr);
                }


            }
            catch (Exception ex)
            { }
            finally
            { objOperacion = null; }

            return data;
        }
        public class jqProformaDetResult
        {
            public String msg { get; set; }
            public String ID_Imagen { get; set; }
            public int total { get; set; }
            public List<ProformaDetCE> rows { get; set; }
        }

        [WebMethod]
        public static UsuarioCE F_Usuario_ObtenerXNombreUsuario_NET(string NombreUsuario)
        {
            UsuarioCN objOperacion = new UsuarioCN();
            return objOperacion.F_Usuario_ObtenerXNombreUsuario(NombreUsuario, Convert.ToInt32(HttpContext.Current.Session["CodSede"]));
        }

        [WebMethod]
        public static UsuarioCE F_Usuario_ObtenerXCodUsuario_NET(int CodUsuario)
        {
            UsuarioCN objOperacion = new UsuarioCN();
            UsuarioCE Usuario = objOperacion.F_Usuario_Obtener(CodUsuario);
            Usuario.ImagenUsuario = null;
            return Usuario;
        }

        [WebMethod]
        public static VehiculoPlanMantenimientoCE F_VehiculoPlanMantenimiento_PorID_Net(int CodVehiculoPlanMantenimiento)
        {
            VehiculoPlanMantenimientoCE objEntidad = new VehiculoPlanMantenimientoCE();
            VehiculoPlanMantenimientoCN objOperacion = new VehiculoPlanMantenimientoCN();
            objEntidad.CodVehiculoPlanMantenimientoCab = CodVehiculoPlanMantenimiento;
            return objOperacion.F_VehiculoPlanMantenimiento_ObtenerXID(objEntidad);
        }

    }
}
