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
using System.Web.Services;
using CapaNegocios;
using CapaEntidad;
//using System.Web.Helpers;
using SistemaInventario.Clases;
using EasyCallback;
using Newtonsoft.Json;

namespace SistemaInventario.Inventario
{
    public partial class GuiaRemision : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_Buscar_Productos_NET);
            CallbackManager.Register(F_AgregarTemporal_NET);
            CallbackManager.Register(F_EliminarTemporal_NET);
            CallbackManager.Register(F_GrabarDocumento_NET);
            CallbackManager.Register(F_Nuevo_NET);
            CallbackManager.Register(F_Buscar_NET);
            CallbackManager.Register(F_AnularRegistro_Net);
            CallbackManager.Register(F_CargarGrillaVaciaConsultaArticulo_NET);
            CallbackManager.Register(F_TipoCambio_NET);
            CallbackManager.Register(F_Mostrar_Correlativo_NET);
            CallbackManager.Register(F_ActualizarPrecio_Net);
            CallbackManager.Register(F_FacturacionOC_NET);
            CallbackManager.Register(F_Consulta_Series_Net);
            CallbackManager.Register(F_DireccionTransportista_NET);
            CallbackManager.Register(F_DireccionProveedor_NET);
            CallbackManager.Register(F_ReemplazarFactura_NET);
            CallbackManager.Register(F_ProductoDetalle_NET);
            CallbackManager.Register(F_Mostrar_Serie_NET);
            CallbackManager.Register(F_Mostrar_Serie_Consulta_NET);
            CallbackManager.Register(F_Series_Documentos_NET);
            CallbackManager.Register(F_Series_Documentos_Consulta_NET);
            CallbackManager.Register(F_BUSCAR_ALMACEN_NET);
            CallbackManager.Register(F_Auditoria_NET);
            CallbackManager.Register(F_Observacion_NET);
            CallbackManager.Register(F_ConfirmarRegistro_Net);
            CallbackManager.Register(F_EliminarRegistro_Net);
            CallbackManager.Register(F_Abrir_NET);
        }

        private string _menu = "2000"; private string _opcion = "5";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"]; String Opcion = Request.QueryString["Op"];
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
            P_Inicializar_GrillaVacia_DetalleArticulo();
            P_Inicializar_GrillaVacia_ConsultaFactura();
            P_Inicializar_GrillaVacia_DetalleOC();
            P_Inicializar_GrillaEmpresa();
            Session["datos"] = true;
        }

        protected void grvConsulta_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TrasladosDetCN objOperacion = new TrasladosDetCN();
                TrasladosDetCE objEntidad = new TrasladosDetCE();
                GridView grvDetalle = null;
                GridView grvDetalleAuditoria = null;
                GridView grvDetalleObservacion = null;
                HiddenField lblID = null;
                grvDetalle = (GridView)(e.Row.FindControl("grvDetalle"));
                lblID = (HiddenField)(e.Row.FindControl("hfCodigo"));
                grvDetalleObservacion = (GridView)(e.Row.FindControl("grvDetalleObservacion"));
                grvDetalleAuditoria = (GridView)(e.Row.FindControl("grvDetalleAuditoria"));
                if (lblID.Value != "")
                {
                    objEntidad.CodTraslado = Convert.ToInt32(lblID.Value);
                    grvDetalle.DataSource = objOperacion.F_TrasladosDet_Listar(objEntidad);
                    grvDetalle.DataBind();

                    DataTable dta_consulta = null;
                    DataRow dtr_filaconsulta = null;

                    dta_consulta = null;
                    dtr_filaconsulta = null;
                    dta_consulta = new DataTable();

                    dta_consulta.Columns.Add("Observacion", typeof(string));

                    dtr_filaconsulta = dta_consulta.NewRow();

                    dtr_filaconsulta[0] = "";
                    dta_consulta.Rows.Add(dtr_filaconsulta);

                    grvDetalleObservacion.DataSource = dta_consulta;
                    grvDetalleObservacion.DataBind();

                    dta_consulta = null;
                    dtr_filaconsulta = null;
                    dta_consulta = new DataTable();

                    dta_consulta.Columns.Add("Auditoria", typeof(string));

                    dtr_filaconsulta = dta_consulta.NewRow();

                    dtr_filaconsulta[0] = "";
                    dta_consulta.Rows.Add(dtr_filaconsulta);

                    grvDetalleAuditoria.DataSource = dta_consulta;
                    grvDetalleAuditoria.DataBind();
                }
            }
        }

        protected void grvConsultaArticulo_RowDataBound(Object sender, GridViewRowEventArgs e)
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

                try
                {
                    ddlPrecio.DataSource = new List<string>() { hfPrecio1.Value.ToString(), hfPrecio2.Value.ToString(), hfPrecio3.Value.ToString() };
                    ddlPrecio.DataBind();
                    ddlPrecio.Enabled = false;


                    GridView grvDetalle = null;
                    HiddenField lblCodigo = null;

                    grvDetalle = (GridView)(e.Row.FindControl("grvDetalleProducto"));
                    lblCodigo = (HiddenField)(e.Row.FindControl("lblcodproducto"));

                    if (lblCodigo.Value != "")
                    {
                        DataTable dta_consultaarticulo = null;
                        DataRow dtr_consultafila = null;
                        dta_consultaarticulo = new DataTable();

                        dta_consultaarticulo.Columns.Add("Linea", typeof(string));
                        dta_consultaarticulo.Columns.Add("Modelo", typeof(string));
                        dta_consultaarticulo.Columns.Add("Año", typeof(string));
                        dta_consultaarticulo.Columns.Add("Motor", typeof(string));
                        dta_consultaarticulo.Columns.Add("CajaCambio", typeof(string));
                        dta_consultaarticulo.Columns.Add("Filtro", typeof(string));
                        dta_consultaarticulo.Columns.Add("Transmision", typeof(string));

                        dtr_consultafila = dta_consultaarticulo.NewRow();

                        dtr_consultafila[0] = "";
                        dta_consultaarticulo.Rows.Add(dtr_consultafila);

                        grvDetalle.DataSource = dta_consultaarticulo;
                        grvDetalle.DataBind();
                    }
                }
                catch (Exception exx) { }
            }
        }

        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddl_serie_html = "";
            String str_ddlSerieConsulta_html = "";
            String str_ddlTipoDocumento_html = "";
            String str_ddlTipoDocConsulta_html = "";
            String str_ddl_igv_html = "";
            String str_ddlMotivoTrabajo_html = "";
            String str_numerofactura = "";
            String str_direccion = "";
            String str_ddlAlmacen_html = "";
            decimal TC = 0;
            int int_resultado_operacion = 0;
            String str_grvConsuArticulo_html = "";
            String str_grvDetalleArticulo_html = "";
            String str_ddlEmpresa_html = "";
            String str_ddlEmpresaConsulta_html = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlSerie, ref ddlMotivoTrabajo, ref str_direccion, ref ddlSerieConsulta,
                    ref ddlAlmacen, ref ddlTipoDocumento, ref ddlTipoDocConsulta, ref ddlEmpresa, ref ddlEmpresaConsulta);
                P_Obtener_TipoCambio(obj_parametros, ref TC);
                P_Obtener_NumeroCorrelativo(obj_parametros, ref str_numerofactura);

                P_Inicializar_GrillaVacia_DetalleArticulo();

                str_ddl_serie_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerie);
                str_ddlSerieConsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieConsulta);
                str_ddlMotivoTrabajo_html = Mod_Utilitario.F_GetHtmlForControl(ddlMotivoTrabajo);
                str_ddlAlmacen_html = Mod_Utilitario.F_GetHtmlForControl(ddlAlmacen);
                str_ddlTipoDocumento_html = Mod_Utilitario.F_GetHtmlForControl(ddlTipoDocumento);
                str_ddlTipoDocConsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlTipoDocConsulta);
                str_grvConsuArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvConsultaArticulo);
                str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);
                str_ddlEmpresa_html = Mod_Utilitario.F_GetHtmlForControl(ddlEmpresa);
                str_ddlEmpresaConsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlEmpresaConsulta);
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
                str_ddlMotivoTrabajo_html + "~" + //2
                str_ddl_serie_html + "~" + //3
                str_ddlAlmacen_html + "~" + //4
                str_ddl_igv_html + "~" + //5
                TC.ToString() + "~" + //6
                str_numerofactura + "~" + //7
                str_direccion + "~" + //8
                str_ddlSerieConsulta_html + "~" + //9
                str_ddlTipoDocumento_html + "~" + //10
                str_ddlTipoDocConsulta_html + "~" +  //11
                str_grvConsuArticulo_html + "~" +  //12
                str_grvDetalleArticulo_html + "~" + //13
                str_ddlEmpresa_html + "~" +//14
                str_ddlEmpresaConsulta_html + "~" +//15
                Session["CodEmpresa"].ToString() + "~" + //16; 
                Session["CodSede"].ToString(); //17; 

            return str_resultado;
        }

        public String F_Observacion_NET(String arg)
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
                grvNombre = Convert.ToString(obj_parametros["Filtro_grvNombre"]);
                Col = Convert.ToInt32(obj_parametros["Filtro_Col"]);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_Codigo"]);

                GridView grvDetalle = (GridView)grvConsulta.Rows[0].FindControl("grvDetalleObservacion");

                TrasladosCabCN objOperacion = new TrasladosCabCN();
                TrasladosCabCE objEntidad = new TrasladosCabCE();

                objEntidad.CodTraslado = Codigo;
                grvDetalle.DataSource = objOperacion.F_GUIAREMISION_OBSERVACION(objEntidad);
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

        public String F_Auditoria_NET(String arg)
        {
            int int_resultado_operacion = 0;
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String grvNombre = "";
            String str_grv_Auditoria_html = "";
            int Col = 0;
            int Codigo = 0;
            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                grvNombre = Convert.ToString(obj_parametros["Filtro_grvNombre"]);
                Col = Convert.ToInt32(obj_parametros["Filtro_Col"]);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_Codigo"]);

                GridView grvAuditoria = (GridView)grvConsulta.Rows[0].FindControl("grvDetalleAuditoria");

                TrasladosCabCN objOperacion = new TrasladosCabCN();
                TrasladosCabCE objEntidad = new TrasladosCabCE();

                objEntidad.CodTraslado = Codigo;
                grvAuditoria.DataSource = objOperacion.F_GUIAREMISION_AUDITORIA(objEntidad);
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
                    P_LlenarGrillaVacia_ConsultaArticulo();
                    str_mensaje_operacion = "No se encontraron registros";
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
            Decimal Dscto = 0;
            Decimal Total = 0;
            Decimal SubTotal = 0;
            Decimal Igv = 0;
            Decimal Acuenta = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_AgregarTemporal(obj_parametros, ref Codigo, ref MsgError);
                if (MsgError == "Los Producto(s) se han agregado con exito")
                    P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref Acuenta);

                str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);

                int_resultado_operacion = 1;
                if (MsgError != "Los Producto(s) se han agregado con exito") int_resultado_operacion = 0;
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
                Math.Round(Acuenta, 2).ToString();

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
            Decimal Dscto = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EliminarTemporal(obj_parametros, ref MsgError);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_CodigoTemporal"]);
                P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref Dscto);
                if (grvDetalleArticulo.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_DetalleArticulo();

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
                Math.Round(Dscto, 2).ToString();

            return str_resultado;

        }

        public String F_GrabarDocumento_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_numerofactura = "";
            int int_resultado_operacion = 0;
            int CodTraslado = 0;
            int CodProforma = 0;

            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_GrabarDocumento(obj_parametros, ref MsgError, ref CodTraslado, ref CodProforma);
                P_LlenarGrillaVacia_Detalle();

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
                CodTraslado.ToString()
                + "~" +
                str_numerofactura
                + "~" +
                CodProforma.ToString();

            return str_resultado;
        }

        public String F_Nuevo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            String str_numerofactura = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_LlenarGrillaVacia_Detalle();
                P_Obtener_NumeroCorrelativo(obj_parametros, ref str_numerofactura);
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
                str_grvDetalleArticulo_html
                 + "~" +
                str_numerofactura
                 + "~" +
                Session["CodEmpresa"].ToString();

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
                    P_Inicializar_GrillaVacia_ConsultaFactura();
                    str_mensaje_operacion = "No se encontro registros.";
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
                str_grvConsulta_html;

            return str_resultado;
        }

        public String F_ConfirmarRegistro_Net(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_ConfirmarRegistro(obj_parametros, ref str_mensaje_operacion);
                if (str_mensaje_operacion == "SE CONFIRMO CORRECTAMENTE")
                    //P_Buscar(obj_parametros, ref grvConsulta);
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
                if (str_mensaje_operacion == "Se anulo correctamente.")
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

                P_LlenarGrillaVacia_ConsultaArticulo();
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
            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_ActualizarPrecios(obj_parametros, ref MsgError);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_CodigoTemporal"]);
                P_CargarGrillaTemporal_Factura(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total);
                if (grvDetalleArticulo.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_DetalleArticulo();
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
                Math.Round(SubTotal, 2).ToString();

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

        public string F_Consulta_Series_Net(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddl_serie_html = "";
            String str_ddl_SerieConsulta_html = "";
            String str_ddl_serieguia_html = "";
            String str_ddlSerieNV_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                int codEmp = Convert.ToInt32(obj_parametros["Filtro_Empresa"]);
                int codSed = Convert.ToInt32(obj_parametros["Filtro_Sede"]);

                P_Controles_Serie(codEmp, codSed, ref ddlSerie, ref ddlSerieConsulta);
                str_ddl_SerieConsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieConsulta);
                str_ddl_serie_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerie);


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
                str_ddl_serie_html
                 + "~" +
                str_ddl_SerieConsulta_html
                + "~" +
                str_ddl_serieguia_html
                + "~" +
                str_ddlSerieNV_html;

            return str_resultado;
        }

        public String F_DireccionTransportista_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddlDireccionTransportista_html = "";
            int int_resultado_operacion = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_DireccionTransportista(obj_parametros);
                str_ddlDireccionTransportista_html = Mod_Utilitario.F_GetHtmlForControl(ddlDireccionTransportista);
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
                str_ddlDireccionTransportista_html;

            return str_resultado;
        }

        public String F_DireccionProveedor_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddlDireccionTransportista_html = "";
            String str_ddlDireccion_html = "";
            int int_resultado_operacion = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_DireccionProveedor(obj_parametros);
                str_ddlDireccionTransportista_html = Mod_Utilitario.F_GetHtmlForControl(ddlDestino);
                str_ddlDireccion_html = Mod_Utilitario.F_GetHtmlForControl(ddlDireccion);
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
                str_ddlDireccionTransportista_html
                + "~" +
                str_ddlDireccion_html;

            return str_resultado;
        }

        public String F_ReemplazarFactura_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            Int32 int_resultado_operacion;

            int CodTrasladoAnterior = 0;
            int Codigo = 0;
            int CodAlmacen = 0;
            int CodAlmacenLlegada = 0;
            string FechaEmision = "";
            string SerieDoc = "";
            string NumeroDoc = "";
            int CodMotivoTraslado = 0;
            int CodCtaCte = 0;
            string RazonSocial = "";
            string Direccion = "";
            string Destino = "";
            int CodDireccion = 0;
            int CodTipoDoc = 0;
            int CodEmpresa = 0;
            string Referencia = "";
            Decimal Total = 1; Decimal SubTotal = 1; Decimal Igv = 1;
            Decimal Acuenta = 1; Decimal Dscto = 1;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                if (str_mensaje_operacion == "")
                {
                    P_ReemplazarFactura(
                        obj_parametros,
                        ref CodTrasladoAnterior, ref Codigo, ref CodAlmacen, ref FechaEmision, ref SerieDoc, ref NumeroDoc,
                        ref CodMotivoTraslado, ref CodCtaCte, ref RazonSocial, ref Direccion, ref Destino, ref CodTipoDoc,
                        ref Referencia, ref CodAlmacenLlegada, ref CodDireccion, ref CodEmpresa);

                    P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref Acuenta);

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
                Convert.ToString(int_resultado_operacion) + "~" + //0
                str_mensaje_operacion + "~" + //1
                Codigo.ToString() + "~" + //2
                str_grvDetalleArticulo_html + "~" + //3
                CodTrasladoAnterior + "~" + //4
                CodAlmacen + "~" + //5
                FechaEmision + "~" + //6
                SerieDoc + "~" + //7
                NumeroDoc + "~" + //8
                CodMotivoTraslado + "~" + //9
                CodCtaCte + "~" + //10
                RazonSocial + "~" + //11
                Direccion + "~" + //12
                Destino + "~" + //13
                CodTipoDoc.ToString() + "~" + //14
                Referencia + "~" +  //15
                CodAlmacenLlegada + "~" +  //16
                CodDireccion + "~" +  //17
                CodEmpresa; //18

            return str_resultado;
        }

        public String F_ProductoDetalle_NET(String arg)
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
                grvNombre = Convert.ToString(obj_parametros["Filtro_grvNombre"]);
                Col = Convert.ToInt32(obj_parametros["Filtro_Col"]);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_Codigo"]);

                GridView grvDetalle = (GridView)grvConsultaArticulo.Rows[0].FindControl("grvDetalleProducto");

                LGProductosCE objEntidad = null;
                LGProductosCN objOperacion = null;

                objEntidad = new LGProductosCE();

                objEntidad.CodProducto = Codigo;
                objOperacion = new LGProductosCN();
                grvDetalle.DataSource = objOperacion.F_ProductoModelo_Listado(objEntidad);
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

        public String F_Mostrar_Serie_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddlserie_html = "";
            int int_resultado_operacion = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Mostrar_Serie(obj_parametros, ref ddlSerie);
                str_ddlserie_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerie);
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
                str_ddlserie_html;

            return str_resultado;
        }

        public String F_Mostrar_Serie_Consulta_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddlserie_html = "";
            int int_resultado_operacion = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Mostrar_Serie_Consulta(obj_parametros, ref ddlSerieConsulta);
                str_ddlserie_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieConsulta);
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
                str_ddlserie_html;

            return str_resultado;
        }

        public String F_Series_Documentos_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddl_serie_html = "";
            String str_ddl_serieconsulta_html = "";

            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Series_Documentos(obj_parametros, ref ddlSerie, ref ddlSerieConsulta);

                str_ddl_serie_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerie);
                str_ddl_serieconsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieConsulta);

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
                str_ddl_serie_html
                 + "~" +
                str_ddl_serieconsulta_html;

            return str_resultado;
        }

        public String F_Series_Documentos_Consulta_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddl_serieconsulta_html = "";
            int int_resultado_operacion = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Series_Documentos_Consulta(obj_parametros, ref ddlSerieConsulta);

                str_ddl_serieconsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieConsulta);

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
                str_ddl_serieconsulta_html;

            return str_resultado;
        }

        public String F_BUSCAR_ALMACEN_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddlAlmacen_html = "";
            int int_resultado_operacion = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_BUSCAR_ALMACEN(obj_parametros, ref ddlAlmacen);

                str_ddlAlmacen_html = Mod_Utilitario.F_GetHtmlForControl(ddlAlmacen);

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
                str_ddlAlmacen_html;

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

        public String F_Abrir_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_numerofactura = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Abrir(obj_parametros, ref MsgError);

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
                Codigo.ToString()
                + "~" +
                str_numerofactura;

            return str_resultado;
        }

        public void P_Inicializar_GrillaEmpresa()
        {
            DataTable dtEmpresa = new TCEmpresaCN().Listar();
            grvEmpresas.DataSource = dtEmpresa;
            grvEmpresas.DataBind();

            if (grvEmpresas.Rows.Count > 0)
            {
                foreach (GridViewRow fila in grvEmpresas.Rows)
                {
                    int id = Convert.ToInt32(((HiddenField)fila.FindControl("hfCodEmpresa")).Value);
                    DataTable dt = new TCAlmacenCN().F_TCAlmacen_Listar(id);
                    var ddl = ((DropDownList)fila.FindControl("ddlSede"));
                    ddl.DataSource = dt;
                    ddl.DataTextField = "DscAlmacen";
                    ddl.DataValueField = "CodAlmacen";
                    ddl.DataBind();
                }
            }
        }

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_combofactura, ref DropDownList ddl_combomotivotrabajo,
              ref String Direccion, ref DropDownList ddl_comboserieconsulta, ref DropDownList ddl_comboAlmacen, ref DropDownList ddl_TipoDocumento,
              ref DropDownList ddl_TipoDocumentoConsulta, ref DropDownList ddl_comboempresa, ref DropDownList ddl_comboempresaconsulta)
        {
            DataTable dta_consulta = null;

            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;

            objEntidad = new TCCorrelativoCE();

            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.CodEstado = 1;
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);

            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_combofactura.Items.Clear();

            ddl_combofactura.DataSource = dta_consulta;
            ddl_combofactura.DataTextField = "SerieDoc";
            ddl_combofactura.DataValueField = "CodSerie";
            ddl_combofactura.DataBind();

            objEntidad.CodEstado = 0;

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_comboserieconsulta.Items.Clear();

            ddl_comboserieconsulta.DataSource = dta_consulta;
            ddl_comboserieconsulta.DataTextField = "SerieDoc";
            ddl_comboserieconsulta.DataValueField = "CodSerie";
            ddl_comboserieconsulta.DataBind();

            dta_consulta = null;
            TipoOperacionesCN objOperacionOperaciones = new TipoOperacionesCN();
            dta_consulta = objOperacionOperaciones.F_Motivo_Traslado_Listar();

            ddl_combomotivotrabajo.Items.Clear();
            ddl_combomotivotrabajo.DataSource = dta_consulta;
            ddl_combomotivotrabajo.DataTextField = "DscTraslado";
            ddl_combomotivotrabajo.DataValueField = "CodMotivoTraslado";
            ddl_combomotivotrabajo.DataBind();

            dta_consulta = null;

            TCAlmacenCN objOperacionAlmacen = new TCAlmacenCN();
            TCAlmacenCE objEntidadAlmacen = new TCAlmacenCE();

            objEntidadAlmacen.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidadAlmacen.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);

            //almacen local
            dta_consulta = null;
            dta_consulta = (new TCAlmacenCN()).F_TCAlmacen_Listar_Excluyente(objEntidadAlmacen);
            ddl_comboAlmacen.Items.Clear();
            ddl_comboAlmacen.DataSource = dta_consulta;
            ddl_comboAlmacen.DataTextField = "DscAlmacen";
            ddl_comboAlmacen.DataValueField = "CodAlmacen";
            ddl_comboAlmacen.DataBind();

            NotaIngresoSalidaCabCN objOperacionTCDocumentos = new NotaIngresoSalidaCabCN();
            NotaIngresoSalidaCabCE objEntidadTCDocumentos = new NotaIngresoSalidaCabCE();
            dta_consulta = objOperacionTCDocumentos.F_NotaIngresoSalida_Documentos(objEntidadTCDocumentos);
            ddl_TipoDocumento.Items.Clear();
            ddl_TipoDocumento.DataSource = dta_consulta;
            ddl_TipoDocumento.DataTextField = "Descripcion";
            ddl_TipoDocumento.DataValueField = "CodTipoDoc";
            ddl_TipoDocumento.DataBind();

            ddl_TipoDocumentoConsulta.Items.Clear();
            ddl_TipoDocumentoConsulta.DataSource = dta_consulta;
            ddl_TipoDocumentoConsulta.DataTextField = "Descripcion";
            ddl_TipoDocumentoConsulta.DataValueField = "CodTipoDoc";
            ddl_TipoDocumentoConsulta.DataBind();


            TCDocumentosCN objOperacionDocumento = new TCDocumentosCN();

            dta_consulta = objOperacionDocumento.F_TCEMPRESA_LISTAR_COMBO();

            ddl_comboempresa.Items.Clear();

            ddl_comboempresa.DataSource = dta_consulta;
            ddl_comboempresa.DataTextField = "T_NombreComercial";
            ddl_comboempresa.DataValueField = "CodEmpresa";
            ddl_comboempresa.DataBind();

            ddl_comboempresaconsulta.Items.Clear();

            ddl_comboempresaconsulta.DataSource = dta_consulta;
            ddl_comboempresaconsulta.DataTextField = "T_NombreComercial";
            ddl_comboempresaconsulta.DataValueField = "CodEmpresa";
            ddl_comboempresaconsulta.DataBind();
            ddl_comboempresaconsulta.Items.Insert(0, new ListItem("TODOS", "0"));
        }

        public void P_Obtener_TipoCambio(Hashtable objTablaFiltro, ref Decimal TipoCambio)
        {
            TCTipoCambioCE objEntidad = null;
            TCTipoCambioCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new TCTipoCambioCE();

            objEntidad.Fecha = Convert.ToDateTime(objTablaFiltro["Filtro_Fecha"]);

            objOperacion = new TCTipoCambioCN();

            dta_consulta = objOperacion.F_TCTipoCambio_Select(objEntidad);

            if (dta_consulta.Rows.Count > 0)
                TipoCambio = Convert.ToDecimal(dta_consulta.Rows[0]["TC_Venta"]);
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

            dta_consultadetalleoc.Rows.Add(dtr_filadetalle);

            grvDetalleOC.DataSource = dta_consultadetalleoc;
            grvDetalleOC.DataBind();

        }

        public void P_Inicializar_GrillaVacia_DetalleArticulo()
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

            dta_consultadetalle.Columns.Add("CodProducto", typeof(string));
            dta_consultadetalle.Columns.Add("CodUnidadVenta", typeof(string));
            dta_consultadetalle.Columns.Add("Costo", typeof(string));
            dta_consultadetalle.Columns.Add("CodigoInterno", typeof(string));
            dta_consultadetalle.Columns.Add("Stock", typeof(string));
            dta_consultadetalle.Columns.Add("Precio1", typeof(string));
            dta_consultadetalle.Columns.Add("Precio2", typeof(string));
            dta_consultadetalle.Columns.Add("Precio3", typeof(string));
            dta_consultadetalle.Columns.Add("Moneda", typeof(string));

            dta_consultadetalle.Columns.Add("Medida", typeof(string));
            dta_consultadetalle.Columns.Add("Marca", typeof(string));
            dta_consultadetalle.Columns.Add("Modelo", typeof(string));
            dta_consultadetalle.Columns.Add("Posicion", typeof(string));
            dta_consultadetalle.Columns.Add("Descripcion", typeof(string));
            dta_consultadetalle.Columns.Add("Anio", typeof(string));
            dta_consultadetalle.Columns.Add("Codigo2", typeof(string));
            dta_consultadetalle.Columns.Add("FlagProductoInicial", typeof(string));
            dta_consultadetalle.Columns.Add("CodProductoAzure", typeof(string));

            dtr_filadetalle = dta_consultadetalle.NewRow();

            dtr_filadetalle[0] = "";
            dtr_filadetalle[1] = "";
            dtr_filadetalle[2] = "";
            dtr_filadetalle[3] = "";
            dtr_filadetalle[4] = "";
            dtr_filadetalle[5] = "";
            dtr_filadetalle[6] = "";
            dtr_filadetalle[7] = "";

            dta_consultadetalle.Rows.Add(dtr_filadetalle);

            grvDetalleArticulo.DataSource = dta_consultadetalle;
            grvDetalleArticulo.DataBind();
        }

        public void P_Inicializar_GrillaVacia_ConsultaFactura()
        {
            DataTable dta_consulta = null;
            DataRow dtr_filaconsulta = null;
            
            dta_consulta = new DataTable();

            dta_consulta.Columns.Add("ID", typeof(string));
            dta_consulta.Columns.Add("Numero", typeof(string));
            dta_consulta.Columns.Add("RazonSocial", typeof(string));
            dta_consulta.Columns.Add("Emision", typeof(string));
            dta_consulta.Columns.Add("Operacion", typeof(string));
            dta_consulta.Columns.Add("Estado", typeof(string));
            dta_consulta.Columns.Add("Factura", typeof(string));
            dta_consulta.Columns.Add("MotivoTraslado", typeof(string));
            dta_consulta.Columns.Add("Usuario", typeof(string));
            dta_consulta.Columns.Add("Referencia", typeof(string));
            dta_consulta.Columns.Add("CodTipoDoc", typeof(string));
            dta_consulta.Columns.Add("Recepcion", typeof(string));
            dta_consulta.Columns.Add("RecibidoPor", typeof(string));
            dta_consulta.Columns.Add("Empresa", typeof(string));
            dta_consulta.Columns.Add("Automatico", typeof(string));
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
            dtr_filaconsulta[11] = "";
            dtr_filaconsulta[12] = "";

            dta_consulta.Rows.Add(dtr_filaconsulta);

            grvConsulta.DataSource = dta_consulta;
            grvConsulta.DataBind();

        }

        public void P_Cargar_Grilla(Hashtable objTablaFiltro, ref GridView grvConsulta)
        {
            //TIPO DE BUSQUEDA
            //SPLIT: divide la descripcion en sus espacios para buscar tipo LIKE '%PARTE1%PARTE2%PARTE3%'
            //EXACTA: line normal tipo LIKE '%BUSQUEDA%'
            DataTable dtPermisos = (new TCEmpresaCN()).F_ParametrosSistemas_Listar("P_TIPO_BUSQUEDA_CODIGO_PRODUCTO", Convert.ToInt32(_menu), Convert.ToInt32(_opcion));
            string TipoBusqueda = "SPLIT";
            if (dtPermisos.Rows.Count > 0)
                TipoBusqueda = dtPermisos.Rows[0]["Valor"].ToString();

            LGProductosCE objEntidad = null;
            LGProductosCN objOperacion = null;

            objEntidad = new LGProductosCE();

            string Descripcion = Convert.ToString(objTablaFiltro["Filtro_DscProducto"]);

            if (TipoBusqueda == "EXACTA")
            {
                objEntidad.DscProducto = Convert.ToString(objTablaFiltro["Filtro_DscProducto"]).Trim().ToUpper();
                objEntidad.DscProducto2 = "";
            }
            else
                if (Descripcion.Contains(" "))
                {
                    string[] Descripciones = Descripcion.Split(' ');
                    objEntidad.DscProducto = Descripciones[0].Trim().ToUpper();
                    objEntidad.DscProducto2 = Descripciones[1].Trim().ToUpper();
                }
                else
                {
                    objEntidad.DscProducto = Convert.ToString(objTablaFiltro["Filtro_DscProducto"]).Trim().ToUpper();
                    objEntidad.DscProducto2 = "";
                }

            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodTipoProducto = 2;
            objEntidad.FlagProductosConStock = Convert.ToInt32(objTablaFiltro["Filtro_FlagProductosConStock"]);

            objOperacion = new LGProductosCN();

            grvConsulta.DataSource = objOperacion.F_LGProductos_Select_Ventas(objEntidad);
            grvConsulta.DataBind();
        }

        public void P_AgregarTemporal(Hashtable objTablaFiltro, ref Int32 Codigo, ref String MsgError)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            String XmlDetalle = "";

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_SerieDoc"]); ;

            objEntidad.NumeroDoc = Convert.ToString(objTablaFiltro["Filtro_NumeroDoc"]);
            objEntidad.FechaEmision = Convert.ToDateTime(objTablaFiltro["Filtro_FechaEmision"]);
            objEntidad.FechaVencimiento = Convert.ToDateTime(objTablaFiltro["Filtro_FechaEmision"]);
            objEntidad.CodCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodCliente"]);

            objEntidad.CodFormaPago = Convert.ToInt32(objTablaFiltro["Filtro_CodFormaPago"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
            objEntidad.TipoCambio = Convert.ToDecimal(objTablaFiltro["Filtro_TipoCambio"]);
            objEntidad.DeudaSoles = Convert.ToDecimal(objTablaFiltro["Filtro_SubTotal"]);

            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
            objEntidad.CodProforma = Convert.ToInt32(objTablaFiltro["Filtro_CodProforma"]);
            objEntidad.Igv = Convert.ToDecimal(objTablaFiltro["Filtro_Igv"]);
            objEntidad.Total = Convert.ToDecimal(objTablaFiltro["Filtro_Total"]);

            objEntidad.CodTraslado = Convert.ToInt32(objTablaFiltro["Filtro_CodTraslado"]);
            objEntidad.FlagFormulario = Convert.ToInt32(objTablaFiltro["Filtro_FlagFormulario"]);
            objEntidad.CodAlmacenFisicoDesde = Convert.ToInt32(objTablaFiltro["Filtro_CodAlmacenFisicoDesde"]);
            objEntidad.CodAlmacenFisicoHasta = Convert.ToInt32(objTablaFiltro["Filtro_CodAlmacenFisicoHasta"]);
            objEntidad.Descuento = Convert.ToInt32(objTablaFiltro["Filtro_Descuento"]);
            objEntidad.SolicitarDescuento = Convert.ToInt32(objTablaFiltro["Filtro_SolicitarDescuento"]);

            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_XmlDetalle"].ToString());

            foreach (dynamic item in jArr2)
            {
                XmlDetalle = XmlDetalle + "<D ";
                XmlDetalle = XmlDetalle + " CodArticulo = '" + item.CodArticulo + "'";
                XmlDetalle = XmlDetalle + " Cantidad = '" + item.Cantidad + "'";
                XmlDetalle = XmlDetalle + " Precio = '" + item.Precio + "'";
                XmlDetalle = XmlDetalle + " PrecioDscto = '" + item.PrecioDscto + "'";
                XmlDetalle = XmlDetalle + " Costo = '" + item.Costo + "'";
                XmlDetalle = XmlDetalle + " CodUm = '" + item.CodUm + "'";
                XmlDetalle = XmlDetalle + " CodDetalle = '" + item.CodDetalle + "'";
                XmlDetalle = XmlDetalle + " OC = '" + item.OC + "'";
                XmlDetalle = XmlDetalle + " Descripcion = '" + Convert.ToString(item.Descripcion).Replace("'", "&apos;") + "'";
                XmlDetalle = XmlDetalle + " Acuenta = '" + item.Acuenta + "'";
                XmlDetalle = XmlDetalle + " CodTipoDoc = '" + item.CodTipoDoc + "'";
                XmlDetalle = XmlDetalle + " />";
            }

            XmlDetalle = "<R><XmlLC> " + XmlDetalle.Replace("&", "&amp;").Replace("”", "&quot;") + "</XmlLC></R>";
            XmlDetalle = "<?xml version=" + '\u0022' + "1.0" + '\u0022' + " encoding=" + '\u0022' + "iso-8859-1" + '\u0022' + "?>" + XmlDetalle;

            objEntidad.XmlDetalle = XmlDetalle;

            objOperacion = new DocumentoVentaCabCN();

            if (Convert.ToInt32(objTablaFiltro["Filtro_CodigoTemporal"]) == 0)
            {
                objOperacion.F_TemporalFacturacionDet_Insert_Yordan(objEntidad);
                Codigo = objEntidad.CodDocumentoVenta;
            }
            else
            {
                objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodigoTemporal"]);
                objOperacion.F_TemporalFacturacionDetalle_Insert_Yordan(objEntidad);
                Codigo = Convert.ToInt32(objTablaFiltro["Filtro_CodigoTemporal"]);
            }
            MsgError = objEntidad.MsgError;
        }

        public void P_EliminarTemporal(Hashtable objTablaFiltro, ref String MsgError)
        {

            DocumentoVentaDetCE objEntidad = null;
            DocumentoVentaDetCN objOperacion = null;

            String XmlDetalle = "";

            objEntidad = new DocumentoVentaDetCE();

            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_XmlDetalle"].ToString());

            foreach (dynamic item in jArr2)
            {
                XmlDetalle = XmlDetalle + "<D ";
                XmlDetalle = XmlDetalle + " CodDetalle = '" + item.CodDetalle + "'";
                XmlDetalle = XmlDetalle + " />";
            }

            XmlDetalle = "<R><XmlLC> " + XmlDetalle + "</XmlLC></R>";

            objEntidad.XmlDetalle = XmlDetalle;

            objOperacion = new DocumentoVentaDetCN();

            objOperacion.F_TemporalFacturacionDet_Eliminar(objEntidad);

            MsgError = objEntidad.MsgError;

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
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
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

        public void P_GrabarDocumento(Hashtable objTablaFiltro, ref String MsgError, ref Int32 CodTraslado, ref Int32 CodProforma)
        {
            TrasladosCabCE objEntidad = null;
            TrasladosCabCN objOperacion = null;

            objEntidad = new TrasladosCabCE();

            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);

            objEntidad.CodTipoFormato = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoFormato"]);
            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_SerieDoc"]);
            objEntidad.NumeroDoc = Convert.ToString(objTablaFiltro["Filtro_NumeroDoc"]);
            objEntidad.FechaEmision = Convert.ToDateTime(objTablaFiltro["Filtro_FechaEmision"]);
            objEntidad.FechaTraslado = Convert.ToDateTime(objTablaFiltro["Filtro_FechaEmision"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);

            objEntidad.CodTipoOperacion = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoOperacion"]);
            objEntidad.CodCtaCte = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);
            objEntidad.CodDireccion = Convert.ToInt32(objTablaFiltro["Filtro_CodDireccion"]);

            objEntidad.CodAlmacenPartida = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodAlmacenLlegada = Convert.ToInt32(objTablaFiltro["Filtro_CodAlmacenLlegada"]);
            objEntidad.Partida = Convert.ToString(objTablaFiltro["Filtro_Partida"]);
            objEntidad.Destino = Convert.ToString(objTablaFiltro["Filtro_Destino"]);
            objEntidad.CodMotivoTraslado = Convert.ToInt32(objTablaFiltro["Filtro_CodMotivoTraslado"]);

            objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodDocumentoVenta"]);
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
            objEntidad.CodDetalle = Convert.ToInt32(objTablaFiltro["Filtro_CodDocumentoVenta"]);

            objEntidad.CodDepartamento = 0;
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.TipoCambio = Convert.ToDecimal(objTablaFiltro["Filtro_TipoCambio"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
            objEntidad.CodTasa = Convert.ToInt32(objTablaFiltro["Filtro_CodTasa"]);            
            objEntidad.SubTotal = 0;
            objEntidad.Igv = 0;
            objEntidad.Total = 0;
            objEntidad.Cliente = Convert.ToString(objTablaFiltro["Filtro_Cliente"]);
            objEntidad.CodTrasladoAnterior = Convert.ToInt32(objTablaFiltro["Filtro_CodTrasladoAnterior"]);
            objEntidad.NroReferencia = Convert.ToString(objTablaFiltro["Filtro_NroReferencia"]);

            objEntidad.Observacion = Convert.ToString(objTablaFiltro["Filtro_Observacion"]);

            objOperacion = new TrasladosCabCN();

            objOperacion.F_TrasladosCab_Insert(objEntidad);

            MsgError = objEntidad.MsgError;
            CodTraslado = objEntidad.CodTraslado;
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

            dtr_filadetalle = dta_consultadetalle.NewRow();

            dtr_filadetalle[0] = "";
            dtr_filadetalle[1] = "";
            dtr_filadetalle[2] = "";
            dtr_filadetalle[3] = "";
            dtr_filadetalle[4] = "";
            dtr_filadetalle[5] = "";
            dtr_filadetalle[6] = "";
            dtr_filadetalle[7] = "";

            dta_consultadetalle.Rows.Add(dtr_filadetalle);

            grvDetalleArticulo.DataSource = dta_consultadetalle;
            grvDetalleArticulo.DataBind();

        }

        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {
            TrasladosCabCE objEntidad = null;
            TrasladosCabCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new TrasladosCabCE();

            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_SerieDoc"]);

            if (Convert.ToInt32(objTablaFiltro["Filtro_ChkNumero"]) == 1)
                objEntidad.NumeroDoc = Convert.ToString(objTablaFiltro["Filtro_Numero"]);
            else
                objEntidad.NumeroDoc = "";

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

            if (Convert.ToInt32(objTablaFiltro["Filtro_ChkCliente"]) == 1)
                objEntidad.CodCtaCte = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);
            else
                objEntidad.CodCtaCte = 0;

            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);
            objEntidad.CodTipoOperacion = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoOperacion"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);

            objOperacion = new TrasladosCabCN();

            dta_consulta = objOperacion.F_TrasladosCab_Listar(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();
        }

        public void P_AnularRegistro(Hashtable objTablaFiltro, ref String Mensaje)
        {
            TrasladosCabCE objEntidad = null;
            TrasladosCabCN objOperacion = null;

            objEntidad = new TrasladosCabCE();

            objEntidad.CodTraslado = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
            objEntidad.Observacion = Convert.ToString(objTablaFiltro["Filtro_Observacion"]);

            objOperacion = new TrasladosCabCN();

            objOperacion.F_TrasladosCab_Anulacion(objEntidad);

            Mensaje = objEntidad.MsgError;
        }

        public void P_LlenarGrillaVacia_ConsultaArticulo()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();

            dta_consultaarticulo.Columns.Add("Codigo", typeof(string));
            dta_consultaarticulo.Columns.Add("CodDetalle", typeof(string));
            dta_consultaarticulo.Columns.Add("CodArticulo", typeof(string));
            dta_consultaarticulo.Columns.Add("CodigoProducto", typeof(string));
            dta_consultaarticulo.Columns.Add("Producto", typeof(string));
            dta_consultaarticulo.Columns.Add("Cantidad", typeof(string));
            dta_consultaarticulo.Columns.Add("UM", typeof(string));
            dta_consultaarticulo.Columns.Add("Precio", typeof(string));
            dta_consultaarticulo.Columns.Add("Importe", typeof(string));

            dta_consultaarticulo.Columns.Add("CodProducto", typeof(string));
            dta_consultaarticulo.Columns.Add("CodUnidadVenta", typeof(string));
            dta_consultaarticulo.Columns.Add("Costo", typeof(string));
            dta_consultaarticulo.Columns.Add("CodigoInterno", typeof(string));
            dta_consultaarticulo.Columns.Add("Stock", typeof(string));
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

            dta_consultaarticulo.Rows.Add(dtr_consultafila);

            grvConsultaArticulo.DataSource = dta_consultaarticulo;
            grvConsultaArticulo.DataBind();
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

        public void P_Obtener_NumeroCorrelativo(Hashtable objTablaFiltro, ref String Numero)
        {
            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new TCCorrelativoCE();

            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodDoc"]);
            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_SerieDoc"]);
            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);

            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Numero_Select(objEntidad);

            if (dta_consulta.Rows.Count > 0)
                Numero = Convert.ToString(dta_consulta.Rows[0]["NumeroDoc"]);
        }

        public void P_ActualizarPrecios(Hashtable objTablaFiltro, ref String MsgError)
        {
            DocumentoVentaDetCE objEntidad = null;
            DocumentoVentaDetCN objOperacion = null;

            objEntidad = new DocumentoVentaDetCE();

            objEntidad.CodDetDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodDetDocumentoVenta"]);
            objEntidad.Precio = Convert.ToDecimal(objTablaFiltro["Filtro_Precio"]);
            objEntidad.PrecioOriginal = Convert.ToDecimal(objTablaFiltro["Filtro_Precio"]);
            objEntidad.Cantidad = Convert.ToDecimal(objTablaFiltro["Filtro_Cantidad"]);
            objEntidad.Descripcion = Convert.ToString(objTablaFiltro["Filtro_Descripcion"]);
            objEntidad.Flag = Convert.ToInt32(objTablaFiltro["Filtro_Flag"]);

            objOperacion = new DocumentoVentaDetCN();

            objOperacion.F_TemporalFacturacionDet_Update(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_CargarGrillaTemporal_Factura(Hashtable objTablaFiltro, Int32 Codigo, ref GridView grvDetalle,
      ref Decimal SubTotalFactura, ref Decimal IgvFactura, ref Decimal TotalFactura)
        {

            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();


            objOperacion = new DocumentoVentaCabCN();


            DataTable dta_consulta = null;
            if (Codigo != 0)
            {
                objEntidad.Igv = Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]);
                objEntidad.CodDocumentoVenta = Codigo;

                dta_consulta = objOperacion.F_TemporalFacturacionDet_Listar(objEntidad);
            }
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
                    }
                }

                SubTotalFactura = TotalFactura / Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]);
                IgvFactura = SubTotalFactura * (Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]) - 1);
            }
            grvDetalle.DataSource = dta_consulta;
            grvDetalle.DataBind();



        }

        public void P_FacturacionOC(Hashtable objTablaFiltro, ref GridView GrillaOC)
        {

            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);

            objOperacion = new DocumentoVentaCabCN();
            DataTable dta_consulta = null;

            dta_consulta = objOperacion.F_DocumentoVentaCab_OCXFacturar(objEntidad);

            grvDetalleOC.DataSource = dta_consulta;
            grvDetalleOC.DataBind();
        }

        public void P_Controles_Serie(int codEmpresa, int codSede, ref DropDownList ddl_comboserie, ref DropDownList ddl_comboserieconsulta)
        {
            DataTable dta_consulta = null;

            TCCorrelativoCE objEntidad = new TCCorrelativoCE();
            TCCorrelativoCN objOperacion = new TCCorrelativoCN();

            objEntidad.CodEmpresa = codEmpresa;
            objEntidad.CodAlmacen = codSede;
            objEntidad.CodTipoDoc = 10;

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_comboserie.Items.Clear();

            ddl_comboserie.DataSource = dta_consulta;
            ddl_comboserie.DataTextField = "SerieDoc";
            ddl_comboserie.DataValueField = "CodSerie";
            ddl_comboserie.DataBind();

            ddl_comboserieconsulta.Items.Clear();

            ddl_comboserieconsulta.DataSource = dta_consulta;
            ddl_comboserieconsulta.DataTextField = "SerieDoc";
            ddl_comboserieconsulta.DataValueField = "CodSerie";
            ddl_comboserieconsulta.DataBind();
        }

        public void P_DireccionTransportista(Hashtable objTablaFiltro)
        {
            DataTable dtTabla = null;

            //dtTabla = new DocumentoVentaCabCN().F_TCDireccion_LISTARXCLIENTE(Convert.ToInt32(objTablaFiltro["Filtro_CodTransportista"]));

            ddlDireccionTransportista.Items.Clear();

            ddlDireccionTransportista.DataSource = dtTabla;
            ddlDireccionTransportista.DataTextField = "Direccion";
            ddlDireccionTransportista.DataValueField = "CodDireccion";
            ddlDireccionTransportista.DataBind();
        }

        public void P_DireccionProveedor(Hashtable objTablaFiltro)
        {
            DataTable dtTabla = null;

            //dtTabla = new DocumentoVentaCabCN().F_TCDireccion_LISTARXCLIENTE(Convert.ToInt32(objTablaFiltro["Filtro_CodTransportista"]));

            ddlDestino.Items.Clear();

            ddlDestino.DataSource = dtTabla;
            ddlDestino.DataTextField = "Direccion";
            ddlDestino.DataValueField = "CodDireccion";
            ddlDestino.DataBind();

            ddlDireccion.Items.Clear();

            ddlDireccion.DataSource = dtTabla;
            ddlDireccion.DataTextField = "Direccion";
            ddlDireccion.DataValueField = "CodDireccion";
            ddlDireccion.DataBind();
        }

        public void P_ReemplazarFactura(Hashtable objTablaFiltro,
            ref int CodTrasladoAnterior, ref int Codigo, ref int CodAlmacen, ref string FechaEmision, ref string SerieDoc,
            ref string NumeroDoc, ref int CodMotivoTraslado, ref int CodCtaCte, ref string RazonSocial, ref string Direccion,
            ref string Destino, ref int CodTipoDoc, ref string Referencia, ref int CodAlmacenLlegada, ref int CodDireccion, ref int CodEmpresa)
        {
            TrasladosCabCE objEntidad = new TrasladosCabCE();
            TrasladosCabCN objOperacion = new TrasladosCabCN();

            objEntidad.CodTraslado = Convert.ToInt32(objTablaFiltro["Filtro_CodMovimiento"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            DataTable dtTabla = null;

            dtTabla = objOperacion.F_TrasladosCab_Reemplazar(objEntidad);

            if (dtTabla.Rows.Count > 0)
            {
                CodTrasladoAnterior = Convert.ToInt32(dtTabla.Rows[0]["CodTrasladoAnterior"]);
                Codigo = Convert.ToInt32(dtTabla.Rows[0]["Codigo"]);
                CodAlmacen = Convert.ToInt32(dtTabla.Rows[0]["CodAlmacen"]);
                CodAlmacenLlegada = Convert.ToInt32(dtTabla.Rows[0]["CodAlmacenLlegada"]);
                FechaEmision = Convert.ToString(dtTabla.Rows[0]["FechaEmision"]);
                SerieDoc = Convert.ToString(dtTabla.Rows[0]["SerieDoc"]);
                NumeroDoc = Convert.ToString(dtTabla.Rows[0]["NumeroDoc"]);
                CodMotivoTraslado = Convert.ToInt32(dtTabla.Rows[0]["CodMotivoTraslado"]);
                CodCtaCte = Convert.ToInt32(dtTabla.Rows[0]["CodCtaCte"]);
                RazonSocial = Convert.ToString(dtTabla.Rows[0]["RazonSocial"]);
                Direccion = Convert.ToString(dtTabla.Rows[0]["Direccion"]);
                Destino = Convert.ToString(dtTabla.Rows[0]["Destino"]);
                CodTipoDoc = Convert.ToInt32(dtTabla.Rows[0]["CodTipoDoc"]);
                Referencia = Convert.ToString(dtTabla.Rows[0]["NroReferencia"]);
                CodDireccion = Convert.ToInt32(dtTabla.Rows[0]["CodDireccion"]);
                CodEmpresa = Convert.ToInt32(dtTabla.Rows[0]["CodEmpresa"]);
            }
        }

        public void P_ConfirmarRegistro(Hashtable objTablaFiltro, ref String Mensaje)
        {
            NotaIngresoSalidaCabCE objEntidad = null;
            NotaIngresoSalidaCabCN objOperacion = null;

            objEntidad = new NotaIngresoSalidaCabCE();

            objEntidad.CodMovimiento = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));

            objOperacion = new NotaIngresoSalidaCabCN();

            //objOperacion.F_Eliminacion_NotaIngreso(objEntidad);
            objOperacion.F_Confirmacion_NotaIngreso_Inventario(objEntidad);

            Mensaje = objEntidad.MsgError;

        }

        public void P_Mostrar_Serie(Hashtable objTablaFiltro, ref DropDownList comboserie)
        {
            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;
            DataTable dta_consulta = null;

            objEntidad = new TCCorrelativoCE();

            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);

            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            comboserie.Items.Clear();

            comboserie.DataSource = dta_consulta;
            comboserie.DataTextField = "SerieDoc";
            comboserie.DataValueField = "CodSerie";
            comboserie.DataBind();
        }

        public void P_Mostrar_Serie_Consulta(Hashtable objTablaFiltro, ref DropDownList comboserie)
        {
            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;
            DataTable dta_consulta = null;

            objEntidad = new TCCorrelativoCE();

            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);

            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            comboserie.Items.Clear();

            comboserie.DataSource = dta_consulta;
            comboserie.DataTextField = "SerieDoc";
            comboserie.DataValueField = "CodSerie";
            comboserie.DataBind();
        }

        public void P_Series_Documentos(Hashtable objTablaFiltro, ref DropDownList ddl_serie, ref DropDownList ddl_serieconsulta)
        {
            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new TCCorrelativoCE();

            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodDoc"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);

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

        public void P_Series_Documentos_Consulta(Hashtable objTablaFiltro, ref DropDownList ddl_serieconsulta)
        {
            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new TCCorrelativoCE();

            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodDoc"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);

            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_serieconsulta.Items.Clear();

            ddl_serieconsulta.DataSource = dta_consulta;
            ddl_serieconsulta.DataTextField = "SerieDoc";
            ddl_serieconsulta.DataValueField = "CodSerie";
            ddl_serieconsulta.DataBind();

            ddl_serieconsulta.Items.Insert(0, new ListItem("TODOS", "0"));
        }

        public void P_BUSCAR_ALMACEN(Hashtable objTablaFiltro, ref DropDownList combosucursal)
        {
            TCAlmacenCE objEntidad = null;
            TCAlmacenCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new TCAlmacenCE();

            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);

            objOperacion = new TCAlmacenCN();

            combosucursal.Items.Clear();

            dta_consulta = objOperacion.F_TCAlmacen_Listar(objEntidad);

            combosucursal.DataSource = dta_consulta;
            combosucursal.DataTextField = "DscAlmacen";
            combosucursal.DataValueField = "CodAlmacen";
            combosucursal.DataBind();
        }

        public void P_EliminarRegistro(Hashtable objTablaFiltro, ref String Mensaje)
        {
            TrasladosCabCE objEntidad = null;
            TrasladosCabCN objOperacion = null;

            objEntidad = new TrasladosCabCE();

            objEntidad.CodTraslado = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new TrasladosCabCN();

            objOperacion.F_TrasladosCab_Eliminacion_Inventario(objEntidad);

            Mensaje = objEntidad.MsgError;
        }

        public void P_Abrir(Hashtable objTablaFiltro, ref String MsgError)
        {
            TrasladosCabCE objEntidad = null;
            TrasladosCabCN objOperacion = null;

            objEntidad = new TrasladosCabCE();

            objEntidad.CodTraslado = Convert.ToInt32(objTablaFiltro["Filtro_CodTraslado"]);

            objOperacion = new TrasladosCabCN();

            objOperacion.F_TrasladosCab_Abrir(objEntidad);
            MsgError = objEntidad.MsgError;
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

    }
}