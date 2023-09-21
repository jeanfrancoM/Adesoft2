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
using SistemaInventario.Clases;
using EasyCallback;
using Newtonsoft.Json;
using System.Web.Services;
namespace SistemaInventario.CuentasPorCobrar
{
    public partial class LetrasVentas : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_Buscar_Factura_NET);
            CallbackManager.Register(F_AgregarTemporal_NET);
            CallbackManager.Register(F_EliminarTemporal_Factura_NET);
            CallbackManager.Register(F_GrabarDocumento_NET);
            CallbackManager.Register(F_Nuevo_NET);
            CallbackManager.Register(F_Buscar_NET);
            CallbackManager.Register(F_AnularRegistro_Net);
            CallbackManager.Register(F_CargarGrillaVaciaConsultaArticulo_NET);
            CallbackManager.Register(F_AgregarLetraTemporal_NET);
            CallbackManager.Register(F_EliminarTemporal_Letra_NET);
            CallbackManager.Register(F_TipoCambio_NET);
            CallbackManager.Register(F_Mostrar_Correlativo_NET);
            CallbackManager.Register(F_ActualizarLetra_NET);
            CallbackManager.Register(F_EliminarRegistro_Net);
            CallbackManager.Register(F_GrabarCodigo_NET);
            CallbackManager.Register(F_ValidarUsuario_NET);
            CallbackManager.Register(F_Buscar_Eliminados_NET);
            CallbackManager.Register(F_LlenarGridEliminar_NET);
            CallbackManager.Register(F_Observacion_Eliminados_NET);
            CallbackManager.Register(F_ObservacionesEliminados_NET);
            CallbackManager.Register(F_Auditoria_Eliminados_NET);
            CallbackManager.Register(F_Detalle_NET);
            CallbackManager.Register(F_Auditoria_NET);
        }

        private string _menu = "5000"; private string _opcion = "3";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"]; String Opcion = Request.QueryString["Op"];
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
            P_LlenarGrillaVacia_ConsultaFactura();
            P_Inicializar_GrillaVacia_Consulta();
            P_Inicializar_GrillaVacia_Factura();
            P_Inicializar_GrillaVacia_Letra();
            P_Inicializar_GrillaEmpresa();
            P_LlenarGrillaVacia_Eliminado();
            Session["datos"] = true;
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

        public void P_Obtener_NumeroCorrelativo(Hashtable objTablaFiltro, ref String Numero)
        {
            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new TCCorrelativoCE();

            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodEmpresa"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_SerieDoc"]);

            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Numero_Select(objEntidad);

            if (dta_consulta.Rows.Count > 0)
                Numero = Convert.ToString(dta_consulta.Rows[0]["NumDoc"]);
        }
        protected void grvConsulta_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LetrasDetCN objOperacion = new LetrasDetCN();
                LetrasDetCE objEntidad = new LetrasDetCE();
                GridView grvDetalle = null;
                GridView grvDetalleAuditoria = null;
                HiddenField hfCodigo = null;
                grvDetalle = (GridView)(e.Row.FindControl("grvDetalle"));
                grvDetalleAuditoria = (GridView)(e.Row.FindControl("grvDetalleAuditoria"));
                hfCodigo = (HiddenField)(e.Row.FindControl("hfCodigo"));
                if (hfCodigo.Value != "")
                {
                    //objEntidad.CodLetra = Convert.ToInt32(hfCodigo.Value);
                    //objEntidad.CodTipoOperacion = 1;
                    //grvDetalle.DataSource = objOperacion.F_LetrasDet_Select(objEntidad);
                    //grvDetalle.DataBind();

                    DataTable dta_consultaarticulo = null;
                    DataRow dtr_consultafila = null;
                    dta_consultaarticulo = new DataTable();

                    dta_consultaarticulo.Columns.Add("Auditoria", typeof(string));

                    dtr_consultafila = dta_consultaarticulo.NewRow();

                    dtr_consultafila[0] = "";
                    dta_consultaarticulo.Rows.Add(dtr_consultafila);

                    grvDetalleAuditoria.DataSource = dta_consultaarticulo;
                    grvDetalleAuditoria.DataBind();

                    dta_consultaarticulo = null;
                    dtr_consultafila = null;
                    dta_consultaarticulo = new DataTable();

                    dta_consultaarticulo.Columns.Add("ID", typeof(string));
                    dta_consultaarticulo.Columns.Add("Factura", typeof(string));
                    dta_consultaarticulo.Columns.Add("Emision", typeof(string));
                    dta_consultaarticulo.Columns.Add("Total", typeof(string));
                    dta_consultaarticulo.Columns.Add("Moneda", typeof(string));
                
                    dtr_consultafila = dta_consultaarticulo.NewRow();

                    dtr_consultafila[0] = "";
                    dtr_consultafila[1] = "";
                    dtr_consultafila[2] = "";
                    dtr_consultafila[3] = "";
                    dtr_consultafila[4] = "";

                    dta_consultaarticulo.Rows.Add(dtr_consultafila);

                    grvDetalle.DataSource = dta_consultaarticulo;
                    grvDetalle.DataBind();
                }
            }
        }

        protected void grvEliminado_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView grvDetalleEliminado = null;
                GridView grvDetalleObservacionEliminado = null;
                GridView grvDetalleAuditoriaEliminado = null;
                GridView grvObservacionesEliminados = null;

                HiddenField lblCodigo = null;
                grvDetalleEliminado = (GridView)(e.Row.FindControl("grvDetalleEliminado"));
                grvDetalleObservacionEliminado = (GridView)(e.Row.FindControl("grvDetalleObservacionE"));
                grvDetalleAuditoriaEliminado = (GridView)(e.Row.FindControl("grvDetalleAuditoriaEliminado"));
                grvObservacionesEliminados = (GridView)(e.Row.FindControl("grvObservacionesEliminados"));
                lblCodigo = (HiddenField)(e.Row.FindControl("hfCodigo"));
                if (lblCodigo.Value.ToString() != "")
                {
                    DataTable dta_consultaarticuloEliminado = null;
                    DataRow dtr_consultafilaEliminada = null;
                    dta_consultaarticuloEliminado = new DataTable();

                    dta_consultaarticuloEliminado.Columns.Add("ID", typeof(string));
                    dta_consultaarticuloEliminado.Columns.Add("DOCUMENTO", typeof(string));
                    dta_consultaarticuloEliminado.Columns.Add("NUMERODOC", typeof(string));
                    dta_consultaarticuloEliminado.Columns.Add("MONTO", typeof(string));
                    dta_consultaarticuloEliminado.Columns.Add("OPERACION", typeof(string));

                    dtr_consultafilaEliminada = dta_consultaarticuloEliminado.NewRow();

                    dtr_consultafilaEliminada[0] = "";
                    dta_consultaarticuloEliminado.Rows.Add(dtr_consultafilaEliminada);

                    grvDetalleEliminado.DataSource = dta_consultaarticuloEliminado;
                    grvDetalleEliminado.DataBind();

                    dta_consultaarticuloEliminado = null;
                    dtr_consultafilaEliminada = null;
                    dta_consultaarticuloEliminado = new DataTable();

                    dta_consultaarticuloEliminado.Columns.Add("Observaciones", typeof(string));

                    dtr_consultafilaEliminada = dta_consultaarticuloEliminado.NewRow();

                    dtr_consultafilaEliminada[0] = "";
                    dta_consultaarticuloEliminado.Rows.Add(dtr_consultafilaEliminada);

                    grvDetalleObservacionEliminado.DataSource = dta_consultaarticuloEliminado;
                    grvDetalleObservacionEliminado.DataBind();

                    dta_consultaarticuloEliminado = null;
                    dtr_consultafilaEliminada = null;
                    dta_consultaarticuloEliminado = new DataTable();

                    dta_consultaarticuloEliminado.Columns.Add("Auditoria", typeof(string));

                    dtr_consultafilaEliminada = dta_consultaarticuloEliminado.NewRow();

                    dtr_consultafilaEliminada[0] = "";
                    dta_consultaarticuloEliminado.Rows.Add(dtr_consultafilaEliminada);

                    grvDetalleAuditoriaEliminado.DataSource = dta_consultaarticuloEliminado;
                    grvDetalleAuditoriaEliminado.DataBind();

                    dta_consultaarticuloEliminado = null;
                    dtr_consultafilaEliminada = null;
                    dta_consultaarticuloEliminado = new DataTable();

                    dta_consultaarticuloEliminado.Columns.Add("Observaciones", typeof(string));

                    dtr_consultafilaEliminada = dta_consultaarticuloEliminado.NewRow();

                    dtr_consultafilaEliminada[0] = "";
                    dta_consultaarticuloEliminado.Rows.Add(dtr_consultafilaEliminada);

                    grvObservacionesEliminados.DataSource = dta_consultaarticuloEliminado;
                    grvObservacionesEliminados.DataBind();
                }
            }
        }

        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddl_moneda_html = "";
            String str_ddl_formapago_html = "";
            String Correlativo = "";
            String str_ddlBanco_html = "";
            String str_ddlEmpresa_html = "";
            String str_ddlEmpresaConsulta_html = "";
            String str_ddlEstado_html = "";
            decimal TC = 0;
            int int_resultado_operacion = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlMoneda, ref ddlFormaPago, ref ddlBanco, ref ddlEmpresa, ref ddlEmpresaConsulta,ref ddlEstado);
                P_Obtener_TipoCambio(obj_parametros, ref TC);
              
                str_ddl_formapago_html = Mod_Utilitario.F_GetHtmlForControl(ddlFormaPago);
                str_ddl_moneda_html = Mod_Utilitario.F_GetHtmlForControl(ddlMoneda);
                str_ddlBanco_html = Mod_Utilitario.F_GetHtmlForControl(ddlBanco);
                str_ddlEmpresa_html = Mod_Utilitario.F_GetHtmlForControl(ddlEmpresa);
                str_ddlEmpresaConsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlEmpresaConsulta);
                str_ddlEstado_html = Mod_Utilitario.F_GetHtmlForControl(ddlEstado); 

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
                str_ddl_moneda_html
                   + "~" +
                TC.ToString()
                + "~" +
                str_ddl_formapago_html
                   + "~" +
                Correlativo
                 + "~" +
                str_ddlBanco_html
                + "~" +
                str_ddlEmpresa_html
                + "~" +
                str_ddlEmpresaConsulta_html
                + "~" +
                Session["CodEmpresa"].ToString()
                + "~" +
                str_ddlEstado_html; //9

            return str_resultado;
        }

        public String F_Buscar_Factura_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsultaFactura_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Cargar_Grilla(obj_parametros, ref grvConsultaFactura);
                if (grvConsultaFactura.Rows.Count == 0)
                    P_LlenarGrillaVacia_ConsultaFactura();

                str_grvConsultaFactura_html = Mod_Utilitario.F_GetHtmlForControl(grvConsultaFactura);


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
                str_grvConsultaFactura_html;

            return str_resultado;

        }

        public String F_AgregarTemporal_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleFactura_html = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            Decimal Total = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_AgregarTemporal(obj_parametros, ref Codigo, ref MsgError);
                P_CargarGrillaTemporal_Factura(obj_parametros, Codigo, ref grvFactura, ref Total);
                if (grvFactura.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Factura();

                str_grvDetalleFactura_html = Mod_Utilitario.F_GetHtmlForControl(grvFactura);

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
                str_grvDetalleFactura_html
                 + "~" +
                Math.Round(Total, 2).ToString();

            return str_resultado;

        }

        public String F_EliminarTemporal_Factura_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvFactura_html = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            Decimal Total = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EliminarTemporal_Factura(obj_parametros, ref MsgError);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_CodigoTemporal"]);
                P_CargarGrillaTemporal_Factura(obj_parametros, Codigo, ref grvFactura, ref Total);
                if (grvFactura.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Factura();
                str_grvFactura_html = Mod_Utilitario.F_GetHtmlForControl(grvFactura);

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
                str_grvFactura_html
                 + "~" +
               Math.Round(Total, 2).ToString();

            return str_resultado;

        }

        public String F_GrabarDocumento_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
           
            int int_resultado_operacion = 0;
            int Codigo = 0;

            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_GrabarDocumento(obj_parametros, ref MsgError);
                P_Inicializar_GrillaVacia_Factura();
                P_Inicializar_GrillaVacia_Letra();
                

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
                Codigo.ToString();
                


            return str_resultado;

        }

        public String F_Nuevo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvFactura_html = "";
            String str_grvLetra_html = "";
            String Correlativo = "";
            int int_resultado_operacion = 0;


            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Inicializar_GrillaVacia_Letra();
                P_Inicializar_GrillaVacia_Factura();
                P_Obtener_NumeroCorrelativo(obj_parametros, ref Correlativo);
                str_grvLetra_html = Mod_Utilitario.F_GetHtmlForControl(grvLetra);
                str_grvFactura_html = Mod_Utilitario.F_GetHtmlForControl(grvFactura);
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
                str_grvLetra_html
                + "~" +
                str_grvFactura_html
                + "~" +
                Correlativo;


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
                    P_Inicializar_GrillaVacia_Consulta();

                str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvConsulta);
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

        public String F_CargarGrillaVaciaConsultaArticulo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsuArticulo_html = "";
            int int_resultado_operacion = 0;

            try
            {

                P_LlenarGrillaVacia_ConsultaFactura();
                str_grvConsuArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvConsultaFactura);
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

        public String F_AgregarLetraTemporal_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvLetra_html = "";
            Decimal Total = 0;
            int int_resultado_operacion = 0;
            int Codigo = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_AgregarLetraTemporal(obj_parametros, ref MsgError, ref Codigo);
                P_Cargar_Grilla_Letras(obj_parametros, ref grvLetra, ref Total, ref Codigo);
                if (grvLetra.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Letra();

                str_grvLetra_html = Mod_Utilitario.F_GetHtmlForControl(grvLetra);
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
                str_grvLetra_html
                + "~" +
                Total.ToString();

            return str_resultado;
        }

        public String F_EliminarTemporal_Letra_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvLetra_html = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            Decimal Total = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EliminarTemporal_Letra(obj_parametros, ref MsgError);
                P_Cargar_Grilla_Letras(obj_parametros, ref grvLetra, ref Total, ref Codigo);
                if (grvLetra.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Letra();
                str_grvLetra_html = Mod_Utilitario.F_GetHtmlForControl(grvLetra);

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
                str_grvLetra_html
                 + "~" +
               Math.Round(Total, 2).ToString();

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

        public String F_ActualizarLetra_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            String MsgError = "";
            Decimal Total = 0;
            int Codigo = 0;
            Hashtable obj_parametros = null;
            String str_grvLetra_html = "";

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_ActualizarLetra(obj_parametros, ref MsgError,ref Codigo);
                P_Cargar_Grilla_Letras(obj_parametros, ref grvLetra, ref Total,ref Codigo);
                if (grvLetra.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Letra();

                str_grvLetra_html = Mod_Utilitario.F_GetHtmlForControl(grvLetra);
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
                str_grvLetra_html
                  + "~" +
                Total.ToString();
            
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

        public String F_GrabarCodigo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;
        

            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_GrabarCodigo(obj_parametros, ref MsgError);
                P_Buscar(obj_parametros, ref grvConsulta);
                if (grvConsulta.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Consulta();

                str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvConsulta);
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
                str_grvConsulta_html;

            return str_resultado;
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

        public void P_Inicializar_GrillaEmpresa()
        {
            grvEmpresas.DataSource = new TCEmpresaCN().Listar();
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

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_combomoneda,ref DropDownList ddl_comboformapago,
             ref DropDownList ddl_combobanco, ref DropDownList ddl_comboempresa, ref DropDownList ddl_comboempresaconsulta, ref DropDownList ddl_comboestado)
        {

            DataTable dta_consulta = null;
         
            TCConceptosDetCE objEntidadConceptosDet = new TCConceptosDetCE();

            objEntidadConceptosDet.CodConcepto = 4;

            TCConceptosDetCN objOperacionConceptosDet = new TCConceptosDetCN();
            dta_consulta = null;
            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);

            ddl_combomoneda.Items.Clear();

            ddl_combomoneda.DataSource = dta_consulta;
            ddl_combomoneda.DataTextField = "DscAbvConcepto";
            ddl_combomoneda.DataValueField = "CodConcepto";
            ddl_combomoneda.DataBind();

            dta_consulta = null;

            objEntidadConceptosDet.CodConcepto = 5;

            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);

            ddl_comboformapago.Items.Clear();

            ddl_comboformapago.DataSource = dta_consulta;
            ddl_comboformapago.DataTextField = "DscAbvConcepto";
            ddl_comboformapago.DataValueField = "CodConcepto";
            ddl_comboformapago.DataBind();

            BancosCN objOperacionBancos = new BancosCN();
            BancosCE objEntidadBancos = new BancosCE();

            dta_consulta = null;

            objEntidadBancos.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);
            objEntidadBancos.FlagCaja = Convert.ToInt32(objTablaFiltro["Filtro_FlagCaja"]);

            dta_consulta = objOperacionBancos.F_Listar_Bancos(objEntidadBancos);

            ddl_combobanco.Items.Clear();

            ddl_combobanco.DataSource = dta_consulta;
            ddl_combobanco.DataTextField = "DscBanco";
            ddl_combobanco.DataValueField = "CodBanco";
            ddl_combobanco.DataBind();

            ddl_combobanco.Items.Insert(0, new ListItem("SIN BANCO", "0"));

            dta_consulta = null;

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

            dta_consulta = null;
            objEntidadConceptosDet.Flag = 1;
            dta_consulta = objOperacionConceptosDet.F_TCConceptosDet_ListarEstadoFactura(objEntidadConceptosDet);

            ddl_comboestado.Items.Clear();

            ddl_comboestado.DataSource = dta_consulta;
            ddl_comboestado.DataTextField = "Descripcion";
            ddl_comboestado.DataValueField = "Codigo";
            ddl_comboestado.DataBind();
            ddl_comboestado.Items.Insert(0, new ListItem("TODOS", "0"));
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

        public void P_Inicializar_GrillaVacia_Consulta()
        {
            DataTable dta_consulta = null;
            DataRow dtr_filaconsulta = null;

            dta_consulta = new DataTable();

            dta_consulta.Columns.Add("Codigo", typeof(string));
            dta_consulta.Columns.Add("RazonSocial", typeof(string));
            dta_consulta.Columns.Add("Numero", typeof(string));
            dta_consulta.Columns.Add("Emision", typeof(string));
            dta_consulta.Columns.Add("Vcto", typeof(string));
            dta_consulta.Columns.Add("Moneda", typeof(string));
            dta_consulta.Columns.Add("Total", typeof(string));
            dta_consulta.Columns.Add("TipoCambio", typeof(string));
            dta_consulta.Columns.Add("Estado", typeof(string));
            dta_consulta.Columns.Add("FechaCancelacion", typeof(string));
            dta_consulta.Columns.Add("Saldo", typeof(string));
            dta_consulta.Columns.Add("CodigoUnico", typeof(string));
            dta_consulta.Columns.Add("Banco", typeof(string));
            dta_consulta.Columns.Add("IngresoBanco", typeof(string));
            dta_consulta.Columns.Add("CodBanco", typeof(string));
            dta_consulta.Columns.Add("Empresa", typeof(string));

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
            dtr_filaconsulta[13] = "";
            dtr_filaconsulta[14] = "";

            dta_consulta.Rows.Add(dtr_filaconsulta);

            grvConsulta.DataSource = dta_consulta;
            grvConsulta.DataBind();
        }

        public void P_Inicializar_GrillaVacia_Factura()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();

            dta_consultaarticulo.Columns.Add("Detalle", typeof(string));
            dta_consultaarticulo.Columns.Add("Codigo", typeof(string));
            dta_consultaarticulo.Columns.Add("Factura", typeof(string));
            dta_consultaarticulo.Columns.Add("Emision", typeof(string));
            dta_consultaarticulo.Columns.Add("Soles", typeof(string));
            dta_consultaarticulo.Columns.Add("Dolares", typeof(string));
            dta_consultaarticulo.Columns.Add("xSoles", typeof(string));
            dta_consultaarticulo.Columns.Add("xDolares", typeof(string));
            dta_consultaarticulo.Columns.Add("TC", typeof(string));
            dta_consultaarticulo.Columns.Add("CodTipoDoc", typeof(string));

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

            dta_consultaarticulo.Rows.Add(dtr_consultafila);

            grvFactura.DataSource = dta_consultaarticulo;
            grvFactura.DataBind();
        }

        public void P_Inicializar_GrillaVacia_Letra()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();

            dta_consultaarticulo.Columns.Add("Detalle", typeof(string));
            dta_consultaarticulo.Columns.Add("Codigo", typeof(string));
            dta_consultaarticulo.Columns.Add("Letra", typeof(string));
            dta_consultaarticulo.Columns.Add("Emision", typeof(string));
            dta_consultaarticulo.Columns.Add("Vencimiento", typeof(string));
            dta_consultaarticulo.Columns.Add("Total", typeof(string));
            dta_consultaarticulo.Columns.Add("Moneda", typeof(string));

            dtr_consultafila = dta_consultaarticulo.NewRow();

            dtr_consultafila[0] = "";
            dtr_consultafila[1] = "";
            dtr_consultafila[2] = "";
            dtr_consultafila[3] = "";
            dtr_consultafila[4] = "";
            dtr_consultafila[5] = "";

            dta_consultaarticulo.Rows.Add(dtr_consultafila);

            grvLetra.DataSource = dta_consultaarticulo;
            grvLetra.DataBind();

        }

        public void P_Cargar_Grilla(Hashtable objTablaFiltro, ref GridView grvConsulta)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.FlagRenovar = Convert.ToInt32(objTablaFiltro["Filtro_FlagRenovar"]);
            objEntidad.NotaVenta = Convert.ToInt32(objTablaFiltro["Filtro_NotaVenta"]);
            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);

            objOperacion = new DocumentoVentaCabCN();

            grvConsulta.DataSource = objOperacion.F_DocumentoVentaCab_Letras(objEntidad);
            grvConsulta.DataBind();
        }

        public void P_AgregarTemporal(Hashtable objTablaFiltro, ref Int32 Codigo, ref String MsgError)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            String XmlDetalle = "";

            objEntidad = new DocumentoVentaCabCE();

            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_XmlDetalle"].ToString());

            foreach (dynamic item in jArr2)
            {
                XmlDetalle = XmlDetalle + "<D ";
                XmlDetalle = XmlDetalle + " CodigoFactura = '" + item.CodigoFactura + "'";
                XmlDetalle = XmlDetalle + " Factura = '" + item.Factura + "'";
                XmlDetalle = XmlDetalle + " Emision = '" + item.Emision + "'";
                XmlDetalle = XmlDetalle + " Soles = '" + item.Soles + "'";
                XmlDetalle = XmlDetalle + " Dolares = '" + item.Dolares + "'";
                XmlDetalle = XmlDetalle + " xSoles = '" + item.xSoles + "'";
                XmlDetalle = XmlDetalle + " xDolares = '" + item.xDolares + "'";
                XmlDetalle = XmlDetalle + " TC = '" + item.TC + "'";
                XmlDetalle = XmlDetalle + " CodMoneda = '" + item.CodMoneda + "'";
                XmlDetalle = XmlDetalle + " CodEmpresa = '" + item.CodEmpresa + "'";
                XmlDetalle = XmlDetalle + " CodTipoDoc = '" + item.CodTipoDoc + "'";
                XmlDetalle = XmlDetalle + " CodCtaCte = '" + item.CodCtaCte + "'";
                XmlDetalle = XmlDetalle + " />";
            }

            XmlDetalle = "<R><XmlLC> " + XmlDetalle + "</XmlLC></R>";
            
            objEntidad.XmlDetalle = XmlDetalle;
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));

            objOperacion = new DocumentoVentaCabCN();

            if (Convert.ToInt32(objTablaFiltro["Filtro_CodigoTemporal"]) == 0)
            {
                objOperacion.F_TemporalCodigoFacturaCab_Insert(objEntidad);
                Codigo = objEntidad.CodDocumentoVenta;
            }
            else
            {
                objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodigoTemporal"]);
                objOperacion.F_TemporalCodigoFacturaDet_Insert(objEntidad);
                Codigo = Convert.ToInt32(objTablaFiltro["Filtro_CodigoTemporal"]);
            }

            MsgError = objEntidad.MsgError;
        }

        public void P_EliminarTemporal_Factura(Hashtable objTablaFiltro, ref String MsgError)
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

            objOperacion.F_TemporalCodigoFacturaDet_Eliminar(objEntidad);

            MsgError = objEntidad.MsgError;

        }

        public void P_CargarGrillaTemporal_Factura(Hashtable objTablaFiltro, Int32 Codigo, ref GridView grvDetalle,
           ref Decimal TotalFactura)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();
            objOperacion = new DocumentoVentaCabCN();

            DataTable dta_consulta = null;
            if (Codigo != 0)
            {
                objEntidad.CodDocumentoVenta = Codigo;
                objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]); 
                dta_consulta = objOperacion.F_TemporalCodigoFacturaDet_Listar(objEntidad);
            }
            if (dta_consulta.Rows.Count > 0)
            {
                if (Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]) == 1)
                {
                    for (int j = 0; j < dta_consulta.Rows.Count; j++)
                        TotalFactura += Convert.ToDecimal(dta_consulta.Rows[j]["Soles"]);
                }
                else
                {
                    for (int j = 0; j < dta_consulta.Rows.Count; j++)
                        TotalFactura += Convert.ToDecimal(dta_consulta.Rows[j]["Dolares"]);
                }
            }
            grvDetalle.DataSource = dta_consulta;
            grvDetalle.DataBind();
        }

        public void P_GrabarDocumento(Hashtable objTablaFiltro, ref String MsgError)
        {
            LetrasCabCE objEntidad = null;
            LetrasCabCN objOperacion = null;

            objEntidad = new LetrasCabCE();
            String XmlDetalle = "";

            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);
            objEntidad.CodAlmacen = Convert.ToInt32((Session["CodSede"]));
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
            objEntidad.CodMoneda  = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
            objEntidad.CodTipoOperacion = 1;
            objEntidad.AvalPermanente = Convert.ToString(objTablaFiltro["Filtro_AvalPermanente"]);
            objEntidad.Domicilio = Convert.ToString(objTablaFiltro["Filtro_Domicilio"]);
            objEntidad.Localidad = Convert.ToString(objTablaFiltro["Filtro_Localidad"]);
            objEntidad.Telefono = Convert.ToString(objTablaFiltro["Filtro_Telefono"]);
            objEntidad.DOIRUC = Convert.ToString(objTablaFiltro["Filtro_DOIRUC"]);

            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_XmlDetalle"].ToString());

            foreach (dynamic item in jArr2)
            {
                    XmlDetalle = XmlDetalle + "<D ";
                    XmlDetalle = XmlDetalle + " CodLetraCab = '" + item.CodLetraCab + "'";      
                    XmlDetalle = XmlDetalle + " />";
            }

            XmlDetalle = "<R><XmlLC> " + XmlDetalle + "</XmlLC></R>";

            objEntidad.XmlDetalle = XmlDetalle;
            objOperacion = new LetrasCabCN();

            objOperacion.F_LetraCab_Insert(objEntidad);

            MsgError = objEntidad.MsgError;

            TCCuentaCorrienteCE EntidadClienteAzure = new TCCuentaCorrienteCE();
            EntidadClienteAzure.CodCtaCte = 0;
            TCCuentaCorrienteLineaCreditoCN ActualizacionSaldosClientesAzure = new TCCuentaCorrienteLineaCreditoCN();
            ActualizacionSaldosClientesAzure.Async_F_TCCuentaCorriente_LineaCredito_Actualizar_Saldos(EntidadClienteAzure);
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

            //grvDetalleArticulo.DataSource = dta_consultadetalle;
            //grvDetalleArticulo.DataBind();

        }

        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {
            LetrasCabCE objEntidad = null;
            LetrasCabCN objOperacion = null;
            DataTable dta_consulta = null;

            objEntidad = new LetrasCabCE();

            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);
            objEntidad.CodTipoOperacion = 1;
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_Estado"]);

            if (Convert.ToInt32(objTablaFiltro["Filtro_ChkNumero"]) == 1)
                objEntidad.Numero = Convert.ToString(objTablaFiltro["Filtro_Numero"]);
            else
                objEntidad.Numero = "";
       
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

            objOperacion = new LetrasCabCN();

            dta_consulta = objOperacion.F_LetraCab_Select(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();
        }

        public void P_AnularRegistro(Hashtable objTablaFiltro, ref String Mensaje)
        {

            LetrasCabCE objEntidad = null;
            LetrasCabCN objOperacion = null;

            objEntidad = new LetrasCabCE();


            objEntidad.CodLetra = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);
            objEntidad.Observacion = Convert.ToString(objTablaFiltro["Filtro_Observacion"]);
            objEntidad.CodUsuario = int.Parse(Session["CodUsuario"].ToString());
            objEntidad.CodTipoOperacion = 1;

            objOperacion = new LetrasCabCN();

            objOperacion.F_Anulacion_Letras(objEntidad);

            Mensaje = objEntidad.MsgError;

            TCCuentaCorrienteCE EntidadClienteAzure = new TCCuentaCorrienteCE();
            EntidadClienteAzure.CodCtaCte = 0;
            TCCuentaCorrienteLineaCreditoCN ActualizacionSaldosClientesAzure = new TCCuentaCorrienteLineaCreditoCN();
            ActualizacionSaldosClientesAzure.Async_F_TCCuentaCorriente_LineaCredito_Actualizar_Saldos(EntidadClienteAzure);

        }

        public void P_LlenarGrillaVacia_ConsultaFactura()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();

            dta_consultaarticulo.Columns.Add("Codigo", typeof(string));
            dta_consultaarticulo.Columns.Add("Factura", typeof(string));
            dta_consultaarticulo.Columns.Add("Emision", typeof(string));
            dta_consultaarticulo.Columns.Add("Total", typeof(string));
            dta_consultaarticulo.Columns.Add("Moneda", typeof(string));
            dta_consultaarticulo.Columns.Add("CodMoneda", typeof(string));
            dta_consultaarticulo.Columns.Add("CodEmpresa", typeof(string));
            dta_consultaarticulo.Columns.Add("CodTipoDoc", typeof(string));

            dtr_consultafila = dta_consultaarticulo.NewRow();

            dtr_consultafila[0] = "";
            dtr_consultafila[1] = "";
            dtr_consultafila[2] = "";
            dtr_consultafila[3] = "";
            dtr_consultafila[4] = "";
            dtr_consultafila[5] = "";
            dtr_consultafila[6] = "";
            dtr_consultafila[7] = "";

            dta_consultaarticulo.Rows.Add(dtr_consultafila);

            grvConsultaFactura.DataSource = dta_consultaarticulo;
            grvConsultaFactura.DataBind();
        }

        public void P_AgregarLetraTemporal(Hashtable objTablaFiltro, ref String MsgError, ref Int32 Codigo)
        {
            LetrasCabCE objEntidad = null;
            LetrasCabCN objOperacion = null;

            objEntidad = new LetrasCabCE();

            String XmlDetalle = "";

            objEntidad.CodCtaCte = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);
            objEntidad.Numero = Convert.ToString(objTablaFiltro["Filtro_Numero"]);
            objEntidad.FechaEmision = Convert.ToDateTime(objTablaFiltro["Filtro_Emision"]);
            objEntidad.FechaVencimiento = Convert.ToDateTime(objTablaFiltro["Filtro_Emision"]);
            objEntidad.TotalFactura = Convert.ToDecimal(objTablaFiltro["Filtro_TotalFactura"]);
            objEntidad.Moneda = Convert.ToString(objTablaFiltro["Filtro_Moneda"]);
            objEntidad.CodFormaPago = Convert.ToInt32(objTablaFiltro["Filtro_CodFormaPago"]);
            objEntidad.Dias = Convert.ToInt32(objTablaFiltro["Filtro_Dias"]);
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.TipoCambio = Convert.ToDecimal(objTablaFiltro["Filtro_TipoCambio"]);
            objEntidad.CantidadLetra = Convert.ToInt32(objTablaFiltro["Filtro_CantidadLetra"]);

            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_XmlDetalle"].ToString());

            foreach (dynamic item in jArr2)
            {
                XmlDetalle = XmlDetalle + "<D ";
                XmlDetalle = XmlDetalle + " CodFactura = '" + item.CodFactura + "'";
                XmlDetalle = XmlDetalle + " Total = '" + item.Total + "'";
                XmlDetalle = XmlDetalle + " CodTipoDoc = '" + item.CodTipoDoc + "'";
                XmlDetalle = XmlDetalle + " />";
            }

            XmlDetalle = "<R><XmlLC> " + XmlDetalle + "</XmlLC></R>";

            objEntidad.XmlDetalle = XmlDetalle;

            objOperacion = new LetrasCabCN();

            objOperacion.F_TemporalLetraCab_Insert(objEntidad);

            MsgError = objEntidad.MsgError;
            Codigo = objEntidad.CodLetra;
        }

        public void P_Cargar_Grilla_Letras(Hashtable objTablaFiltro, ref GridView grvConsulta, ref Decimal Totalletra, ref Int32 Codigo)
        {
            LetrasCabCE objEntidad = null;
            LetrasCabCN objOperacion = null;

            String XmlDetalle = "";
            objEntidad = new LetrasCabCE();

            if (Codigo==0)
                Codigo = Convert.ToInt32(objTablaFiltro["Filtro_CodLetra"]);

            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_XmlConsulta"].ToString());

            foreach (dynamic item in jArr2)
            {
                XmlDetalle = XmlDetalle + "<D ";
                XmlDetalle = XmlDetalle + " CodFactura = '"  + item.CodFactura + "'";
                XmlDetalle = XmlDetalle + " CodLetraCab = '" + Codigo + "'";
                XmlDetalle = XmlDetalle + " />";
            }

            XmlDetalle = "<R><XmlLC> " + XmlDetalle + "</XmlLC></R>";

            objEntidad.XmlDetalle = XmlDetalle;

            objOperacion = new LetrasCabCN();
            DataTable dtTabla = null;
            dtTabla  = objOperacion.F_TemporalLetraCab_Listar(objEntidad);

            grvConsulta.DataSource = dtTabla;
            grvConsulta.DataBind();

            if (dtTabla.Rows.Count > 0)
            {
                for (int j = 0; j < grvConsulta.Rows.Count; j++)
                    Totalletra += Convert.ToDecimal(dtTabla.Rows[j][4]);
            }
        }

        public void P_EliminarTemporal_Letra(Hashtable objTablaFiltro, ref String MsgError)
        {

            LetrasCabCE objEntidad = null;
            LetrasCabCN objOperacion = null;

            String XmlDetalle = "";

            objEntidad = new LetrasCabCE();

            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_XmlDetalle"].ToString());

            foreach (dynamic item in jArr2)
            {
                XmlDetalle = XmlDetalle + "<D ";
                XmlDetalle = XmlDetalle + " CodLetraCab = '" + item.CodLetraCab + "'";
                XmlDetalle = XmlDetalle + " />";
            }

            XmlDetalle = "<R><XmlLC> " + XmlDetalle + "</XmlLC></R>";

            objEntidad.XmlDetalle = XmlDetalle;

            objOperacion = new LetrasCabCN();

            objOperacion.F_TemporalLetra_Eliminar(objEntidad);

            MsgError = objEntidad.MsgError;

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

        public void P_ActualizarLetra(Hashtable objTablaFiltro, ref String MsgError, ref Int32 Codigo)
        {
            LetrasCabCE objEntidad = null;
            LetrasCabCN objOperacion = null;

            objEntidad = new LetrasCabCE();

            String XmlDetalle = "";

            objEntidad.CodLetraCab = Convert.ToInt32(objTablaFiltro["Filtro_CodLetra"]);
            objEntidad.Numero = Convert.ToString(objTablaFiltro["Filtro_Numero"]);
            objEntidad.FechaEmision = Convert.ToDateTime(objTablaFiltro["Filtro_FechaEmision"]);
            objEntidad.FechaVencimiento = Convert.ToDateTime(objTablaFiltro["Filtro_FechaVencimiento"]);
            objEntidad.Total = Convert.ToDecimal(objTablaFiltro["Filtro_Total"]);
                   
            objEntidad.XmlDetalle = XmlDetalle;
            objOperacion = new LetrasCabCN();

            objOperacion.F_TemporalLetraCab_UPDATE(objEntidad);

            MsgError = objEntidad.MsgError;
            Codigo = objEntidad.CodLetra;
        }

        public void P_EliminarRegistro(Hashtable objTablaFiltro, ref String Mensaje)
        {
            LetrasCabCE objEntidad = null;
            LetrasCabCN objOperacion = null;

            objEntidad = new LetrasCabCE();

            objEntidad.CodLetra = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);
            objEntidad.Observacion = Convert.ToString(objTablaFiltro["Filtro_Observacion"]);
            objEntidad.Observaciones = Convert.ToString(objTablaFiltro["Filtro_Observaciones"]);
            objEntidad.CodUsuario = int.Parse(Session["CodUsuario"].ToString());
            objEntidad.CodTipoOperacion = 1;

            objOperacion = new LetrasCabCN();

            objOperacion.F_Eliminacion_Letras(objEntidad);

            Mensaje = objEntidad.MsgError;

            TCCuentaCorrienteCE EntidadClienteAzure = new TCCuentaCorrienteCE();
            EntidadClienteAzure.CodCtaCte = 0;
            TCCuentaCorrienteLineaCreditoCN ActualizacionSaldosClientesAzure = new TCCuentaCorrienteLineaCreditoCN();
            ActualizacionSaldosClientesAzure.Async_F_TCCuentaCorriente_LineaCredito_Actualizar_Saldos(EntidadClienteAzure);
        }

        public void P_GrabarCodigo(Hashtable objTablaFiltro, ref String MsgError)
        {
            LetrasCabCE objEntidad = null;
            LetrasCabCN objOperacion = null;

            objEntidad = new LetrasCabCE();
        
            objEntidad.CodLetra = Convert.ToInt32(objTablaFiltro["Filtro_CodLetra"]);
            objEntidad.CodigoUnico = Convert.ToString(objTablaFiltro["Filtro_CodigoUnico"]);
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
            objEntidad.CodBanco = Convert.ToInt32(objTablaFiltro["Filtro_CodBanco"]);
            objEntidad.IngresoBanco = Convert.ToDateTime(objTablaFiltro["Filtro_IngresoBanco"]);
            objEntidad.FechaEmision = Convert.ToDateTime(objTablaFiltro["Filtro_FechaEmision"]);
            objEntidad.FechaVencimiento = Convert.ToDateTime(objTablaFiltro["Filtro_FechaVencimiento"]);
            objEntidad.Numero = Convert.ToString(objTablaFiltro["Filtro_Numero"]);
            objOperacion = new LetrasCabCN();

            objOperacion.F_LETRASCAB_CODIGOUNICO(objEntidad);

            MsgError = objEntidad.MsgError;
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

        //Eliminado

        public String F_Buscar_Eliminados_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvEliminado_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Buscar_Eliminados(obj_parametros, ref grvEliminado);
                if (grvEliminado.Rows.Count == 0)
                {
                    P_LlenarGrillaVacia_Eliminado();
                    str_mensaje_operacion = "No se encontraron registros.";
                }
                else
                {
                    str_mensaje_operacion = "";
                }

                str_grvEliminado_html = Mod_Utilitario.F_GetHtmlForControl(grvEliminado);
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
                str_grvEliminado_html;


            return str_resultado;

        }

        public void P_Buscar_Eliminados(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {
            LetrasCabCE objEntidad = null;
            LetrasCabCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new LetrasCabCE();

            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);
            objEntidad.CodTipoOperacion = 1;
            if (Convert.ToInt32(objTablaFiltro["Filtro_ChkNumero"]) == 1)
                objEntidad.Numero = Convert.ToString(objTablaFiltro["Filtro_Numero"]);
            else
                objEntidad.Numero = "";

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

            objOperacion = new LetrasCabCN();

            dta_consulta = objOperacion.F_LetraCab_Select_Eliminados(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();
        }

        public void P_LlenarGrillaVacia_Eliminado()
        {
            DataTable dta_consulta = null;
            DataRow dtr_filaconsulta = null;

            dta_consulta = new DataTable();

            dta_consulta.Columns.Add("Codigo", typeof(string));
            dta_consulta.Columns.Add("RazonSocial", typeof(string));
            dta_consulta.Columns.Add("Numero", typeof(string));
            dta_consulta.Columns.Add("Emision", typeof(string));
            dta_consulta.Columns.Add("Vcto", typeof(string));
            dta_consulta.Columns.Add("Moneda", typeof(string));
            dta_consulta.Columns.Add("Total", typeof(string));
            dta_consulta.Columns.Add("TipoCambio", typeof(string));
            dta_consulta.Columns.Add("Estado", typeof(string));
            dta_consulta.Columns.Add("FechaCancelacion", typeof(string));
            dta_consulta.Columns.Add("Saldo", typeof(string));
            dta_consulta.Columns.Add("CodigoUnico", typeof(string));
            dta_consulta.Columns.Add("Banco", typeof(string));
            dta_consulta.Columns.Add("IngresoBanco", typeof(string));
            dta_consulta.Columns.Add("CodBanco", typeof(string));
            dta_consulta.Columns.Add("Empresa", typeof(string));

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
            dtr_filaconsulta[13] = "";
            dtr_filaconsulta[14] = "";

            dta_consulta.Rows.Add(dtr_filaconsulta);

            grvEliminado.DataSource = dta_consulta;
            grvEliminado.DataBind();

        }

        public String F_LlenarGridEliminar_NET(String arg)
        {
            int int_resultado_operacion = 0;
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String grvNombre = "";
            String str_grvDetalleEliminado_html = "";
            int Col = 0;
            int Codigo = 0;
            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                //Necesarios para que busque el sistema
                grvNombre = Convert.ToString(obj_parametros["Filtro_grvNombre"]);
                Col = Convert.ToInt32(obj_parametros["Filtro_Col"]);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_Codigo"]);

                LetrasCabCN objOperacion = new LetrasCabCN();
                LetrasCabCE objEntidad = new LetrasCabCE();
                //Obtengo el Grid para llenarlo y dibujarlo
                GridView grvEliminar = (GridView)grvEliminado.Rows[0].FindControl("grvDetalleEliminado");

                objEntidad.CodLetra = Convert.ToInt32(Codigo);
                grvEliminar.DataSource = objOperacion.F_LetrasDet_Eliminar_Listar(objEntidad);
                grvEliminar.DataBind();

                //se crea el html a partir del grid llenado
                str_grvDetalleEliminado_html = Mod_Utilitario.F_GetHtmlForControl(grvEliminar);
            }
            catch (Exception exxx)
            {
                str_resultado = "ERROR AL BUSCAR DETALLE: " + exxx;
                int_resultado_operacion = 1;
            }
            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" +
                str_mensaje_operacion + "~" +
                str_grvDetalleEliminado_html + "~" +
                grvNombre;

            return str_resultado;
        }

        //observacion eliminacion

        public String F_Observacion_Eliminados_NET(String arg)
        {
            int int_resultado_operacion = 0;
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String grvNombre = "";
            String str_grv_DetalleObservacionE_html = "";
            int Col = 0;
            int Codigo = 0;
            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                grvNombre = Convert.ToString(obj_parametros["Filtro_grvNombre"]);
                Col = Convert.ToInt32(obj_parametros["Filtro_Col"]);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_Codigo"]);

                GridView grvDetalleObservacionE = (GridView)grvEliminado.Rows[0].FindControl("grvDetalleObservacionE");

                LetrasCabCN objOperacion = new LetrasCabCN();
                LetrasCabCE objEntidad = new LetrasCabCE();

                objEntidad.CodLetra = Codigo;
                grvDetalleObservacionE.DataSource = objOperacion.F_LETRASCAB_ELIMINADOS_OBSERVACION(objEntidad);
                grvDetalleObservacionE.DataBind();

                str_grv_DetalleObservacionE_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleObservacionE);
            }
            catch (Exception exxx)
            {
                str_resultado = "ERROR AL BUSCAR DETALLE: " + exxx;
                int_resultado_operacion = 1;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" +
                str_mensaje_operacion + "~" +
                str_grv_DetalleObservacionE_html + "~" +
                grvNombre;

            return str_resultado;
        }

        public String F_ObservacionesEliminados_NET(String arg)
        {
            int int_resultado_operacion = 0;
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String grvNombre = "";
            String str_grv_DetalleObservacionE_html = "";
            int Col = 0;
            int Codigo = 0;
            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                grvNombre = Convert.ToString(obj_parametros["Filtro_grvNombre"]);
                Col = Convert.ToInt32(obj_parametros["Filtro_Col"]);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_Codigo"]);

                GridView grvDetalleObservacionE = (GridView)grvEliminado.Rows[0].FindControl("grvObservacionesEliminados");

                LetrasCabCN objOperacion = new LetrasCabCN();
                LetrasCabCE objEntidad = new LetrasCabCE();

                objEntidad.CodLetra = Codigo;
                grvDetalleObservacionE.DataSource = objOperacion.F_LetrasCAB_Eliminadas_OBSERVACIONes(objEntidad);
                grvDetalleObservacionE.DataBind();

                str_grv_DetalleObservacionE_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleObservacionE);
            }
            catch (Exception exxx)
            {
                str_resultado = "ERROR AL BUSCAR DETALLE: " + exxx;
                int_resultado_operacion = 1;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" +
                str_mensaje_operacion + "~" +
                str_grv_DetalleObservacionE_html + "~" +
                grvNombre;

            return str_resultado;
        }

        //auditoria ELIMINADOS

        public String F_Auditoria_Eliminados_NET(String arg)
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

                GridView grvAuditoria = (GridView)grvEliminado.Rows[0].FindControl("grvDetalleAuditoriaEliminado");

                LetrasCabCN objOperacion = new LetrasCabCN();
                LetrasCabCE objEntidad = new LetrasCabCE();

                objEntidad.CodLetra = Codigo;
                grvAuditoria.DataSource = objOperacion.F_LetraCab_ELIMINADOS_AUDITORIA(objEntidad);
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

                LetrasCabCN objOperacion = new LetrasCabCN();
                LetrasCabCE objEntidad = new LetrasCabCE();

                objEntidad.CodLetra = Codigo;
                grvAuditoria.DataSource = objOperacion.F_LetraCab_AUDITORIA(objEntidad);
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

        public String F_Detalle_NET(String arg)
        {
            int int_resultado_operacion = 0;
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String grvNombre = "";
            String str_grvDetalle_html = "";
            int Col = 0;
            int Codigo = 0;
            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                grvNombre = Convert.ToString(obj_parametros["Filtro_grvNombre"]);
                Col = Convert.ToInt32(obj_parametros["Filtro_Col"]);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_Codigo"]);

                GridView grvDetalle = (GridView)grvConsulta.Rows[0].FindControl("grvDetalle");

                LetrasDetCN objOperacion = new LetrasDetCN();
                LetrasDetCE objEntidad = new LetrasDetCE();

                objEntidad.CodLetra = Codigo;
                objEntidad.CodTipoOperacion = 1;
                grvDetalle.DataSource = objOperacion.F_LetrasDet_Select(objEntidad);
                grvDetalle.DataBind();

                str_grvDetalle_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalle);
            }
            catch (Exception exxx)
            {
                str_resultado = "ERROR AL BUSCAR DETALLE: " + exxx;
                int_resultado_operacion = 1;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" +
                str_mensaje_operacion + "~" +
                str_grvDetalle_html + "~" +
                grvNombre;

            return str_resultado;
        }
    }
}