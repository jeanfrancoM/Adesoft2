using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocios;
using EasyCallback;
using Newtonsoft.Json;
using SistemaInventario.Clases;

namespace SistemaInventario.Inventario
{
    public partial class NotaIngresoSalidaUnitario : System.Web.UI.Page
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
            CallbackManager.Register(F_Serie_NET);
            CallbackManager.Register(F_SerieConsulta_NET);
            CallbackManager.Register(F_ReemplazarFactura_NET);
            CallbackManager.Register(F_Ventas_NET);
            CallbackManager.Register(F_StockAlmacenes_NET);
            CallbackManager.Register(F_ProductoDetalle_NET);
            CallbackManager.Register(F_AgregarTemporal_GuiaExterna_NET);
            CallbackManager.Register(F_Series_Documentos_NET);
            CallbackManager.Register(F_ConfirmarRegistro_Net);
            CallbackManager.Register(F_Auditoria_NET);
            CallbackManager.Register(F_Observacion_NET);
            CallbackManager.Register(F_EliminarRegistro_Net);
            CallbackManager.Register(F_Abrir_NET);
        }

        private string _menu = "2000"; private string _opcion = "7";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"]; String Opcion = Request.QueryString["Op"];
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
            P_Inicializar_GrillaVacia_DetalleArticulo();
            P_Inicializar_GrillaVacia_ConsultaFactura();
            P_Inicializar_GrillaVacia_DetalleOC();
            P_Inicializar_GrillaVacia_Ventas();
            Session["datos"] = true;
        }

        protected void grvConsulta_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                NotaIngresoSalidaDetCN objOperacion = new NotaIngresoSalidaDetCN();
                NotaIngresoSalidaDetCE objEntidad = new NotaIngresoSalidaDetCE();
                GridView grvDetalle = null;
                GridView grvDetalleAuditoria = null;
                GridView grvDetalleObservacion = null;
                HiddenField lblCodigo = null;
                grvDetalle = (GridView)(e.Row.FindControl("grvDetalle"));
                lblCodigo = (HiddenField)(e.Row.FindControl("hfCodigo"));
                grvDetalleObservacion = (GridView)(e.Row.FindControl("grvDetalleObservacion"));
                grvDetalleAuditoria = (GridView)(e.Row.FindControl("grvDetalleAuditoria"));
                if (lblCodigo.Value.ToString() != "")
                {
                    objEntidad.CodMovimiento = Convert.ToInt32(lblCodigo.Value.ToString());
                    grvDetalle.DataSource = objOperacion.F_NotaIngresoSalidaDet_Select(objEntidad);
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

        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddl_serie_html = "";
            String str_ddlSerieConsulta_html = "";
            String str_ddl_moneda_html = "";
            String str_ddl_igv_html = "";
            String str_ddlMotivoTrabajo_html = "";
            String str_numerofactura = "";
            String str_direccion = "";
            String str_ddlPartida_html = "";
            String str_ddlDestino_html = "";
            String str_ddlMotivoInterno_html = "";
            String str_grvDetalleArticulo_html = "";
            String str_ddlTipoDoc_html = "";
            String str_ddlTipoDocConsulta_html = "";
            decimal TC = 0;
            int int_resultado_operacion = 0;
            String str_ddlSerieDocVentas_html = "";
            String str_ddlEmpleadoConsulta_html = "";
            String str_ddlTipoDocumento_html = "";
            Hashtable obj_parametros = null;
            String str_grvConsuArticulo_html = "";

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlMoneda, ref ddlIgv, ref ddlSerie, ref ddlMotivoTrabajo, ref str_direccion,
                                         ref ddlSerieConsulta, ref ddlTipoDocConsulta, ref ddlDestino, ref  ddlSerieDocVentas, ref ddlEmpleadoConsulta,
                                         ref ddlTipoDocumento);
                P_Obtener_TipoCambio(obj_parametros, ref TC);
                P_Obtener_NumeroCorrelativo(obj_parametros, ref str_numerofactura);
                P_Inicializar_GrillaVacia_DetalleArticulo();
                P_Inicializar_GrillaVacia_ConsultaFactura();
                P_LlenarGrillaVacia_ConsultaArticulo();

                str_ddl_moneda_html = Mod_Utilitario.F_GetHtmlForControl(ddlMoneda);
                str_ddl_serie_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerie);
                str_ddlSerieConsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieConsulta);
                str_ddl_igv_html = Mod_Utilitario.F_GetHtmlForControl(ddlIgv);
                str_ddlMotivoTrabajo_html = Mod_Utilitario.F_GetHtmlForControl(ddlMotivoTrabajo);
                str_ddlSerieDocVentas_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieDocVentas);
                str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);
                str_ddlEmpleadoConsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlEmpleadoConsulta);
                str_ddlTipoDocConsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlTipoDocConsulta);
                str_ddlDestino_html = Mod_Utilitario.F_GetHtmlForControl(ddlDestino);
                str_ddlTipoDocumento_html = Mod_Utilitario.F_GetHtmlForControl(ddlTipoDocumento);
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
                Convert.ToString(int_resultado_operacion) + "~" + //0
                str_mensaje_operacion + "~" + //1
                str_ddlMotivoTrabajo_html + "~" + //2
                str_ddl_serie_html + "~" + //3
                str_ddl_moneda_html + "~" + //4
                str_ddl_igv_html + "~" + //5
                TC.ToString() + "~" + //6
                str_numerofactura + "~" + //7
                str_direccion + "~" + //8
                str_ddlSerieConsulta_html + "~" + //9
                str_ddlPartida_html + "~" + //10
                str_ddlDestino_html + "~" + //11
                str_ddlMotivoInterno_html + "~" + //12
                str_grvDetalleArticulo_html + "~" + //13
                str_ddlTipoDoc_html + "~" + //14
                str_ddlTipoDocConsulta_html + "~" + //15
                str_ddlSerieDocVentas_html + "~" + //16
                str_ddlEmpleadoConsulta_html + "~" + //17
                str_ddlTipoDocumento_html + "~" + //18
                str_grvConsuArticulo_html + "~" + //19
                Session["CodSede"].ToString(); //20

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

        public String F_AgregarTemporal_GuiaExterna_NET(String arg)
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

            string NroRuc = "";
            string RazonSocial = "";
            int CodCtaCTe = 0;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_AgregarTemporal_GuiaExterna(obj_parametros, ref Codigo, ref MsgError, ref NroRuc);


                if (NroRuc != "")
                {

                    List<TCCuentaCorrienteCE> proveedor = Utilitarios.OtrasFunciones.F_ListarClientes_AutoComplete_toList("", NroRuc, 2, 0);

                    if (proveedor.Count == 0)
                    {
                        MsgError = "PROVEEDOR NO ENCONTRADO";
                    }
                    else
                    {
                        RazonSocial = proveedor[0].RazonSocial;
                        CodCtaCTe = proveedor[0].CodCtaCte;
                    }
                }

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
                Convert.ToString(int_resultado_operacion) + "~" + //0
                str_mensaje_operacion + "~" + //1
                MsgError + "~" + //2
                Codigo.ToString() + "~" + //3
                str_grvDetalleArticulo_html + "~" + //4
                Math.Round(Total, 2).ToString() + "~" + //5
                Math.Round(Igv, 2).ToString() + "~" + //6
                Math.Round(SubTotal, 2).ToString() + "~" + //7
                Math.Round(Dscto, 2).ToString() + "~" + //8
                Math.Round(Acuenta, 2).ToString() + "~" + //9
                NroRuc + "~" + //10
                CodCtaCTe + "~" + //11
                RazonSocial; //12

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
            Int32 CodigoMov = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_GrabarDocumento(obj_parametros, ref MsgError, ref CodTraslado, ref CodigoMov);
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
                CodigoMov.ToString()
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
                str_numerofactura;



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
                if (str_mensaje_operacion == "SE ELIMINO CORRECTAMENTE")
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

        public String F_Serie_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            String str_ddlSerie_html = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                //P_Serie(obj_parametros, ref ddlSerie);

                //str_ddlSerie_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerie);

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
                str_ddlSerie_html;

            return str_resultado;
        }

        public String F_SerieConsulta_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            String str_ddlSerie_html = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Serie(obj_parametros, ref ddlSerieConsulta);

                str_ddlSerie_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieConsulta);

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
                str_ddlSerie_html;

            return str_resultado;
        }

        public String F_ReemplazarFactura_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            Int32 int_resultado_operacion;

            int Codigo = 0;
            int CodFacturaAnterior = 0;
            string FechaEmision = "";
            string SerieDoc = "";
            string NumeroDoc = "";
            int CodTipoDoc = 0;
            int CodCtaCte = 0;
            string RazonSocial = "";
            int CodDireccion = 0;
            int CodAlmacen = 0;
            string Observacion = "";
            int CodTipoOperacion = 0;
            int CodMotivoTraslado = 0;
            Decimal Total = 1;
            Decimal SubTotal = 1;
            Decimal Igv = 1;
            Decimal Acuenta = 1;
            Decimal Dscto = 1;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

               // P_ValidarFactura(obj_parametros, ref str_mensaje_operacion);

                if (str_mensaje_operacion == "")
                {
                    P_ReemplazarFactura(
                        obj_parametros,
                        ref Codigo, ref CodFacturaAnterior,
                        ref FechaEmision, ref SerieDoc, ref NumeroDoc, ref CodTipoDoc,
                        ref CodCtaCte, ref RazonSocial, ref CodDireccion,
                        ref CodAlmacen, ref Observacion, ref CodTipoOperacion, ref CodMotivoTraslado
                        );

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
                CodFacturaAnterior.ToString() + "~" + //4
                SerieDoc + "~" + //5
                NumeroDoc + "~" + //6
                CodTipoDoc + "~" + //7
                FechaEmision + "~" + //8
                RazonSocial + "~" + //9
                CodCtaCte + "~" + //10
                CodDireccion + "~" + //11
                CodAlmacen + "~" + //12
                Observacion + "~" + //13
                CodTipoOperacion.ToString() + "~" +  //14
                CodMotivoTraslado.ToString(); //15

            return str_resultado;
        }

        public String F_Ventas_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            String str_grvDetalleOC_html = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Ventas(obj_parametros, ref grvVentas);

                if (grvVentas.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_Ventas();
                    str_mensaje_operacion = "No se encontraron registros.";
                }
                else
                    str_mensaje_operacion = "";

                str_grvDetalleOC_html = Mod_Utilitario.F_GetHtmlForControl(grvVentas);

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

                NotaIngresoSalidaCabCN objOperacion = new NotaIngresoSalidaCabCN();
                NotaIngresoSalidaCabCE objEntidad = new NotaIngresoSalidaCabCE();

                objEntidad.CodMovimiento = Codigo;
                grvDetalle.DataSource = objOperacion.F_NOTAINGRESO_OBSERVACION(objEntidad);
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

                NotaIngresoSalidaCabCN objOperacion = new NotaIngresoSalidaCabCN();
                NotaIngresoSalidaCabCE objEntidad = new NotaIngresoSalidaCabCE();

                objEntidad.CodMovimiento = Codigo;
                grvAuditoria.DataSource = objOperacion.F_NOTAINGRESO_AUDITORIA(objEntidad);                
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

        public String F_Series_Documentos_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddl_serie_html = "";
            String str_ddl_serieconsulta_html = "";
            String str_ddl_serieguia_html = "";
            String str_ddlSerieNV_html = "";
            String str_ddlSerieCT_html = "";

            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Series_Documentos(obj_parametros, ref ddlSerie, ref ddlSerieConsulta, ref ddlTipoDocumento);

                str_ddl_serie_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerie);
                str_ddl_serieconsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieConsulta);
                str_ddl_serieguia_html = Mod_Utilitario.F_GetHtmlForControl(ddlTipoDocumento); 
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
                str_ddl_serieguia_html
                + "~" +
                str_ddl_serieconsulta_html
                + "~" +
                str_ddlSerieNV_html
                + "~" +
                str_ddlSerieCT_html;

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
            }
            catch (Exception exx) { }
        }

        protected void grvDetalleArticulo_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField hfFlagGratuito = null;
                    Label lblGratuito = null;

                    hfFlagGratuito = (HiddenField)(e.Row.FindControl("hfFlagGratuito"));
                    lblGratuito = (Label)(e.Row.FindControl("lblGratuito"));

                    try
                    {
                        if (hfFlagGratuito.Value == "1")
                        {
                            lblGratuito.ForeColor = Color.White;
                            lblGratuito.BackColor = Color.Red;

                        }
                    }
                    catch (Exception exx) { }

                }
            }
            catch (Exception exx) { }
        }

        public void P_Series_Documentos(Hashtable objTablaFiltro, ref DropDownList ddl_serie, ref DropDownList ddl_serieconsulta,
                                       ref DropDownList ddlTipoDocumento)
        {

            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;

            DataTable dta_consulta = null;


            int iCodEmpresa = 3;

            objEntidad = new TCCorrelativoCE();

            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodDoc"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodEmpresa = iCodEmpresa;
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);

            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_serie.Items.Clear();

            ddl_serie.DataSource = dta_consulta;
            ddl_serie.DataTextField = "SerieDoc";
            ddl_serie.DataValueField = "CodSerie";
            ddl_serie.DataBind();

            ddl_serieconsulta.Items.Clear();

            objEntidad.CodEstado = 0;

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);
            ddl_serieconsulta.DataSource = dta_consulta;
            ddl_serieconsulta.DataTextField = "SerieDoc";
            ddl_serieconsulta.DataValueField = "CodSerie";
            ddl_serieconsulta.DataBind();


            dta_consulta = null;
            objEntidad.CodTipoDoc = 10;
            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);
           
        }
        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_combomoneda, ref DropDownList ddl_comboigv,
             ref DropDownList ddl_comboserie, ref DropDownList ddl_combomotivotrabajo, ref String Direccion, ref DropDownList ddl_comboserieconsulta,
             ref DropDownList ddl_TipoDocConsulta, ref DropDownList ddl_destino, ref DropDownList ddl_comboserieventas, ref DropDownList ddl_empleadoconsulta,
             ref DropDownList ddl_TipoDocumento)
        {
            DataTable dta_consulta = null;

            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;

            int iCodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);

            objEntidad = new TCCorrelativoCE();

            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.CodEmpresa = iCodEmpresa;

            objOperacion = new TCCorrelativoCN();

            ddl_comboserie.Items.Clear();

            ddl_comboserie.DataSource = dta_consulta;
            ddl_comboserie.DataTextField = "SerieDoc";
            ddl_comboserie.DataValueField = "CodSerie";
            ddl_comboserie.DataBind();

            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodTipoDoc = 7;
            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_comboserieconsulta.Items.Clear();

            ddl_comboserieconsulta.DataSource = dta_consulta;
            ddl_comboserieconsulta.DataTextField = "SerieDoc";
            ddl_comboserieconsulta.DataValueField = "CodSerie";
            ddl_comboserieconsulta.DataBind();

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
            TCTasasCE objEntidadTasa = new TCTasasCE();
            objEntidadTasa.CodTipoTasa = 1;
            objEntidadTasa.CodEstado = 0;
            TCTasasCN objOperacionTasa = new TCTasasCN();
            dta_consulta = objOperacionTasa.F_TCTasas_ListarXTipoTasa(objEntidadTasa);

            ddl_comboigv.Items.Clear();

            ddl_comboigv.DataSource = dta_consulta;
            ddl_comboigv.DataTextField = "Valor";
            ddl_comboigv.DataValueField = "CodTasa";
            ddl_comboigv.DataBind();

            dta_consulta = null;
            TipoOperacionesCN objOperacionOperaciones = new TipoOperacionesCN();
            dta_consulta = objOperacionOperaciones.F_Motivo_Traslado_Listar();

            ddl_combomotivotrabajo.Items.Clear();
            ddl_combomotivotrabajo.DataSource = dta_consulta;
            ddl_combomotivotrabajo.DataTextField = "DscTraslado";
            ddl_combomotivotrabajo.DataValueField = "CodMotivoTraslado";
            ddl_combomotivotrabajo.DataBind();

            ddlDestino.Items.Clear();
            dta_consulta = null;
            TCAlmacenCN objOperacionAlmacenes = new TCAlmacenCN();
            TCAlmacenCE objEntidadAlmacenes = new TCAlmacenCE();
            objEntidadAlmacenes.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);
            objEntidadAlmacenes.CodEstado = 1;
            dta_consulta = objOperacionAlmacenes.F_TCAlmacen_Listar(objEntidadAlmacenes);

            ddl_destino.DataSource = dta_consulta;
            ddl_destino.DataTextField = "DscAlmacen";
            ddl_destino.DataValueField = "CodAlmacen";
            ddl_destino.DataBind();

            objEntidad.CodTipoDoc = 1;
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_comboserieventas.Items.Clear();

            ddl_comboserieventas.DataSource = dta_consulta;
            ddl_comboserieventas.DataTextField = "SerieDoc";
            ddl_comboserieventas.DataValueField = "CodSerie";
            ddl_comboserieventas.DataBind();

            EmpleadoCE objEmpleado = new EmpleadoCE();

            objEmpleado.CodCargo = Convert.ToInt32(objTablaFiltro["Filtro_CodCargo"]);
            objEmpleado.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            dta_consulta = (new EmpleadoCN()).F_Empleado_Listar(objEmpleado);

            ddl_empleadoconsulta.Items.Clear();

            ddl_empleadoconsulta.DataSource = dta_consulta;
            ddl_empleadoconsulta.DataTextField = "NombreCompleto";
            ddl_empleadoconsulta.DataValueField = "CodEmpleado";
            ddl_empleadoconsulta.DataBind();
            ddl_empleadoconsulta.Items.Insert(0, new ListItem("TODOS", "0"));


            NotaIngresoSalidaCabCN objOperacionTCDocumentos = new NotaIngresoSalidaCabCN();
            NotaIngresoSalidaCabCE objEntidadTCDocumentos = new NotaIngresoSalidaCabCE();
            dta_consulta = objOperacionTCDocumentos.F_NotaIngresoSalida_Documentos(objEntidadTCDocumentos);
            ddl_TipoDocumento.Items.Clear();
            ddl_TipoDocumento.DataSource = dta_consulta;
            ddl_TipoDocumento.DataTextField = "Descripcion";
            ddl_TipoDocumento.DataValueField = "CodTipoDoc";
            ddl_TipoDocumento.DataBind();

            ddl_TipoDocConsulta.Items.Clear();
            ddl_TipoDocConsulta.DataSource = dta_consulta;
            ddl_TipoDocConsulta.DataTextField = "Descripcion";
            ddl_TipoDocConsulta.DataValueField = "CodTipoDoc";
            ddl_TipoDocConsulta.DataBind();
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

        public void P_Inicializar_GrillaVacia_Ventas()
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
            dta_consultadetalleoc.Columns.Add("CodTipoDoc", typeof(string));

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

            grvVentas.DataSource = dta_consultadetalleoc;
            grvVentas.DataBind();
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

            dta_consulta.Columns.Add("Codigo", typeof(string));
            dta_consulta.Columns.Add("Usuario", typeof(string));
            dta_consulta.Columns.Add("Numero", typeof(string));
            dta_consulta.Columns.Add("RazonSocial", typeof(string));
            dta_consulta.Columns.Add("Emision", typeof(string));
            dta_consulta.Columns.Add("Estado", typeof(string));
            dta_consulta.Columns.Add("Partida", typeof(string));
            dta_consulta.Columns.Add("Destino", typeof(string));
            dta_consulta.Columns.Add("Operacion", typeof(string));
            dta_consulta.Columns.Add("TipoDocumento", typeof(string));
            dta_consulta.Columns.Add("CodTipoDoc", typeof(string));
            dta_consulta.Columns.Add("Automatico", typeof(string));
            dta_consulta.Columns.Add("Origen", typeof(string));
            dta_consulta.Columns.Add("Proforma", typeof(string));
            dta_consulta.Columns.Add("CodProforma", typeof(string));

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

            objEntidad.CodMoneda = 1;
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodTipoProducto = 2;
            objEntidad.FlagProductosConStock = Convert.ToInt32(objTablaFiltro["Filtro_FlagProductosConStock"]);

            objOperacion = new LGProductosCN();

            grvConsulta.DataSource = objOperacion.F_LGProductos_Select_Ventas(objEntidad);
            grvConsulta.DataBind();
        }

        public void P_AgregarTemporal_GuiaExterna(Hashtable objTablaFiltro, ref Int32 Codigo, ref String MsgError, ref string NroRucProeedor)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            String XmlDetalle = "";
            int iCodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodEmpresa = iCodEmpresa;
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
            objEntidad.Descuento = Convert.ToInt32(objTablaFiltro["Filtro_Descuento"]);

            objEntidad.FlagFormulario = Convert.ToInt32(objTablaFiltro["Filtro_FlagFormulario"]);

            NotaIngresoSalidaDetCE nd_externa = new NotaIngresoSalidaDetCE();
            nd_externa.CodAlmacen = Convert.ToInt32(objTablaFiltro["Filtro_CodAlmacenRemoto"]);
            nd_externa.CodAlmacenLlegada = Convert.ToInt32(Session["CodSede"]);
            nd_externa.ConexionNombre = Convert.ToString(objTablaFiltro["Filtro_ConexionNombre"]);
            nd_externa.CodTipoDocSust = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            nd_externa.SerieDocSust = Convert.ToString(objTablaFiltro["Filtro_SerieDoc"]);
            nd_externa.NumeroDocSust = Convert.ToString(objTablaFiltro["Filtro_NumeroDoc"]);

            bool existe = false;
            P_Buscar_Documento(Convert.ToString(objTablaFiltro["Filtro_SerieDoc"]), Convert.ToString(objTablaFiltro["Filtro_NumeroDoc"]), 7, Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]), 7, ref existe);

            if (existe == true)
            {
                MsgError = "EL DOCUMENTO YA SE ENCUENTRA REGISTRADO";

            }
            else
            {
                NotaIngresoSalidaDetCN nd_operacion = new NotaIngresoSalidaDetCN();
                DataTable dt = nd_operacion.F_TrasladosDet_Select_GuiaExterna(nd_externa);

                if (dt.Rows.Count == 0)
                {
                    MsgError = "NO SE ENCONTRO EL DOCUMENTO";
                }
                else
                {

                    if (dt.Rows[0]["Estado"].ToString() != "ENVIADO")
                    {

                        MsgError = "EL ESTADO DEL DOCUMENTO YA HA SIDO USADO";

                    }
                    else
                    {

                        NroRucProeedor = dt.Rows[0]["NroRuc"].ToString();

                        foreach (DataRow item in dt.Rows)
                        {

                            XmlDetalle = XmlDetalle + "<D ";
                            XmlDetalle = XmlDetalle + " CodArticulo = '" + item["CodProducto"].ToString() + "'";
                            XmlDetalle = XmlDetalle + " Cantidad = '" + item["Cantidad"].ToString() + "'";
                            XmlDetalle = XmlDetalle + " Precio = '" + "0" + "'";
                            XmlDetalle = XmlDetalle + " PrecioDscto = '" + "0" + "'";
                            XmlDetalle = XmlDetalle + " Costo = '" + "0" + "'";
                            XmlDetalle = XmlDetalle + " CodUm = '" + item["CodUm"].ToString() + "'";
                            XmlDetalle = XmlDetalle + " CodDetalle = '" + "0" + "'";
                            XmlDetalle = XmlDetalle + " OC = '" + "" + "'";
                            XmlDetalle = XmlDetalle + " Descripcion = '" + item["Producto"].ToString().Replace("'", "&apos;") + "'";
                            XmlDetalle = XmlDetalle + " Acuenta = '" + "0" + "'";
                            XmlDetalle = XmlDetalle + " CodTipoDoc = '" + "" + "'";
                            XmlDetalle = XmlDetalle + " />";
                        }

                        XmlDetalle = "<R><XmlLC> " + XmlDetalle.Replace("&", "&amp;").Replace("”", "&quot;") + "</XmlLC></R>";
                        XmlDetalle = "<?xml version=" + '\u0022' + "1.0" + '\u0022' + " encoding=" + '\u0022' + "iso-8859-1" + '\u0022' + "?>" + XmlDetalle;

                        objEntidad.XmlDetalle = XmlDetalle;

                        objOperacion = new DocumentoVentaCabCN();

                        if (Convert.ToInt32(objTablaFiltro["Filtro_CodigoTemporal"]) == 0)
                        {
                            objOperacion.F_TemporalFacturacionDet_Insert(objEntidad);
                            Codigo = objEntidad.CodDocumentoVenta;
                        }
                        else
                        {
                            objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodigoTemporal"]);
                            objOperacion.F_TemporalFacturacionDetalle_Insert(objEntidad);
                            Codigo = Convert.ToInt32(objTablaFiltro["Filtro_CodigoTemporal"]);
                        }

                        MsgError = objEntidad.MsgError;
                    }

                }
            }




        }

        public void P_ActualizarGuiaExterna(Hashtable objTablaFiltro, ref Int32 Codigo, ref String MsgError)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            int iCodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodEmpresa = iCodEmpresa;
            objEntidad.Conexion = Convert.ToString(objTablaFiltro["Filtro_ConexionNombre"]);
            objEntidad.CodAlmacen = Convert.ToInt32(objTablaFiltro["Filtro_CodAlmacenRemoto"]);
            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_SerieDoc"]);
            objEntidad.NumeroDoc = Convert.ToString(objTablaFiltro["Filtro_NumeroDoc"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.Usuario = Session["Nombre"].ToString().Trim() + ' ' + Session["Apellidos"].ToString().Trim();

            MsgError = objOperacion.F_ActualizaTrasladoExterno(objEntidad).MsgError;
        }

        public void P_AgregarTemporal(Hashtable objTablaFiltro, ref Int32 Codigo, ref String MsgError)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            String XmlDetalle = "";
            int iCodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodEmpresa = iCodEmpresa;
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
            objEntidad.Descuento = Convert.ToInt32(objTablaFiltro["Filtro_Descuento"]);

            objEntidad.FlagFormulario = Convert.ToInt32(objTablaFiltro["Filtro_FlagFormulario"]);

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
                objOperacion.F_TemporalFacturacionDet_Insert(objEntidad);
                Codigo = objEntidad.CodDocumentoVenta;
            }
            else
            {
                objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodigoTemporal"]);
                objOperacion.F_TemporalFacturacionDetalle_Insert(objEntidad);
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

        public void P_GrabarDocumento(Hashtable objTablaFiltro, ref String MsgError, ref Int32 CodTraslado, ref Int32 CodigoMov)
        {
            TrasladosCabCE objEntidad = null;
            TrasladosCabCN objOperacion = null;

            objEntidad = new TrasladosCabCE();

            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);
            objEntidad.CodAlmacen = Convert.ToInt32(objTablaFiltro["Filtro_CodAlmacen"]);
            objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodigoTemporal"]);
            objEntidad.FechaEmision = Convert.ToDateTime(objTablaFiltro["Filtro_FechaEmision"]);
            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_SerieDoc"]);
            objEntidad.NumeroDoc = Convert.ToString(objTablaFiltro["Filtro_NumeroDoc"]);
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
            objEntidad.CodMotivoTraslado = Convert.ToInt32(objTablaFiltro["Filtro_CodMotivoTraslado"]);
            objEntidad.Responsable = "";
            objEntidad.Observacion = Convert.ToString(objTablaFiltro["Filtro_Observacion"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.CodTipoOperacion = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoOperacion"]);
            objEntidad.CodCtaCte = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);
            objEntidad.CodDireccion = Convert.ToInt32(objTablaFiltro["Filtro_CodDireccion"]);
            objEntidad.CodFacturaAnterior = Convert.ToInt32(objTablaFiltro["Filtro_CodFacturaAnterior"]);
            objEntidad.CodTipoFormato = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoFormato"]);
          
            objOperacion = new TrasladosCabCN();

            objOperacion.F_Transferencias_Insert(objEntidad);

            MsgError = objEntidad.MsgError;
            CodigoMov = objEntidad.CodDocumentoVenta;
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
            NotaIngresoSalidaCabCE objEntidad = null;
            NotaIngresoSalidaCabCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new NotaIngresoSalidaCabCE();

            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_SerieDoc"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.CodTipoDocSust = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDocSust"]);
            objEntidad.CodClasificacion = 1;
            objEntidad.CodTipoOperacion = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoOperacion"]);

            if (Convert.ToInt32(objTablaFiltro["Filtro_ChkNumero"]) == 1)
                objEntidad.NumeroDoc = Convert.ToString(objTablaFiltro["Filtro_Numero"]);
            else
                objEntidad.NumeroDoc = "";

            if (Convert.ToInt32(objTablaFiltro["Filtro_chkserie"]) == 1)
                objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_SerieDoc"]);
            else
                objEntidad.SerieDoc = "";

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

            objOperacion = new NotaIngresoSalidaCabCN();

            dta_consulta = objOperacion.F_NotaIngresoSalidaCab_Select_Compras(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();

        }

        public void P_Buscar_Documento(string SerieDoc, string NumeroDoc, int CodTipoDoc, int CodTipoDocSust, int CodTipoOperacion,
           ref bool existe)
        {
            existe = false;
            NotaIngresoSalidaCabCE objEntidad = null;
            NotaIngresoSalidaCabCN objOperacion = null;

            DataTable dta_consulta = null;

            int iCodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);

            objEntidad = new NotaIngresoSalidaCabCE();

            objEntidad.CodEmpresa = iCodEmpresa;
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.SerieDoc = SerieDoc;
            objEntidad.NumeroDoc = NumeroDoc;
            objEntidad.CodTipoDoc = CodTipoDoc;
            objEntidad.CodTipoDocSust = CodTipoDocSust;
            objEntidad.CodClasificacion = 1;
            objEntidad.Desde = Convert.ToDateTime("01/01/1990");
            objEntidad.Hasta = Convert.ToDateTime("01/01/1990");

            objOperacion = new NotaIngresoSalidaCabCN();

            dta_consulta = objOperacion.F_NotaIngresoSalidaCab_Select_Compras(objEntidad);

            //if (dta_consulta.Rows.Count > 0)
            //    existe = true;
        }

        public void P_AnularRegistro(Hashtable objTablaFiltro, ref String Mensaje)
        {
            NotaIngresoSalidaCabCE objEntidad = null;
            NotaIngresoSalidaCabCN objOperacion = null;

            objEntidad = new NotaIngresoSalidaCabCE();

            objEntidad.CodMovimiento = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
            objEntidad.ObservacionAnulacion = Convert.ToString(objTablaFiltro["Filtro_ObservacionAnulacion"]);

            objOperacion = new NotaIngresoSalidaCabCN();
             
            objOperacion.F_Anulacion_NotaIngreso_Inventario(objEntidad);

            Mensaje = objEntidad.MsgError;
        }

        public void P_ConfirmarRegistro(Hashtable objTablaFiltro, ref String Mensaje)
        {
            NotaIngresoSalidaCabCE objEntidad = null;
            NotaIngresoSalidaCabCN objOperacion = null;

            objEntidad = new NotaIngresoSalidaCabCE();

            objEntidad.CodMovimiento = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));

            objOperacion = new NotaIngresoSalidaCabCN();

            objOperacion.F_Confirmacion_NotaIngreso_Traslados(objEntidad);

            Mensaje = objEntidad.MsgError;
        }

        public void P_LlenarGrillaVacia_ConsultaArticulo()
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

            //objEntidad.CodAlmacen = Convert.ToInt32(objTablaFiltro["Filtro_CodAlmacen"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodDoc"]);
            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_SerieDoc"]);

            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Numero_Select(objEntidad);

            if (dta_consulta.Rows.Count > 0)
                Numero = Convert.ToString(dta_consulta.Rows[0]["NumDoc"]);
        }

        public void P_ActualizarPrecios(Hashtable objTablaFiltro, ref String MsgError)
        {
            DocumentoVentaDetCE objEntidad = null;
            DocumentoVentaDetCN objOperacion = null;

            objEntidad = new DocumentoVentaDetCE();

            objEntidad.CodDetDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodDetDocumentoVenta"]);
            objEntidad.Precio = Convert.ToDecimal(objTablaFiltro["Filtro_Precio"]);
            objEntidad.Cantidad = Convert.ToDecimal(objTablaFiltro["Filtro_Cantidad"]);
            objEntidad.Descripcion = Convert.ToString(objTablaFiltro["Filtro_Descripcion"]);
            objEntidad.Flag = Convert.ToInt32(objTablaFiltro["Filtro_Flag"]);
            objEntidad.PrecioOriginal = Convert.ToDecimal(objTablaFiltro["Filtro_Precio"]);
            objEntidad.Descuento = Convert.ToDecimal(objTablaFiltro["Filtro_Descuento"]);
            objEntidad.SolicitudDescuento = Convert.ToInt32(objTablaFiltro["Filtro_SolicitudDescuento"]);
            //objEntidad.CodAlmacenHasta = Convert.ToInt32(objTablaFiltro["Filtro_CodAlmacenHasta"]);

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

        public void P_Serie(Hashtable objTablaFiltro, ref DropDownList ddl_comboserie)
        {
            DataTable dta_consulta = null;

            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;

            objEntidad = new TCCorrelativoCE();

            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            //objEntidad.FlagNotaSalida = Convert.ToInt32(objTablaFiltro["Filtro_FlagNotaSalida"]);                 
            //objEntidad.CodAlmacen = Convert.ToInt32(objTablaFiltro["Filtro_CodAlmacen"]);

            objOperacion = new TCCorrelativoCN();
            //dta_consulta = objOperacion.F_TCCorrelativo_Serie_Almacen_Select(objEntidad);

            ddl_comboserie.Items.Clear();

            ddl_comboserie.DataSource = dta_consulta;
            ddl_comboserie.DataTextField = "SerieDoc";
            ddl_comboserie.DataValueField = "CodSerie";
            ddl_comboserie.DataBind();
        }

        public void P_ReemplazarFactura(Hashtable objTablaFiltro,
            ref int Codigo, ref int CodFacturaAnterior,
            ref string FechaEmision, ref string SerieDoc, ref string NumeroDoc, ref int CodTipoDoc,
            ref int CodCtaCte, ref string RazonSocial, ref int CodDireccion,
            ref int CodAlmacen, ref string Observacion, ref int CodTipoOperacion, ref int CodMotivoTraslado
           )
        {
            NotaIngresoSalidaCabCE objEntidad = null;
            NotaIngresoSalidaCabCN objOperacion = null;

            objEntidad = new NotaIngresoSalidaCabCE();

            objEntidad.CodMovimiento = Convert.ToInt32(objTablaFiltro["Filtro_CodMovimiento"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new NotaIngresoSalidaCabCN();
            DataTable dtTabla = null;

            dtTabla = objOperacion.F_NotaIngresoSalidaCab_Reemplazar(objEntidad);

            if (dtTabla.Rows.Count > 0)
            {
                Codigo = Convert.ToInt32(dtTabla.Rows[0]["Codigo"]);
                CodFacturaAnterior = Convert.ToInt32(dtTabla.Rows[0]["CodFacturaAnterior"]);
                SerieDoc = Convert.ToString(dtTabla.Rows[0]["SerieDoc"]);
                NumeroDoc = Convert.ToString(dtTabla.Rows[0]["NumeroDoc"]);
                CodTipoDoc = Convert.ToInt32(dtTabla.Rows[0]["CodTipoDoc"]);
                FechaEmision = Convert.ToString(dtTabla.Rows[0]["FechaEmision"]);
                CodCtaCte = Convert.ToInt32(dtTabla.Rows[0]["CodCtaCte"]);
                RazonSocial = Convert.ToString(dtTabla.Rows[0]["Proveedor"]);
                CodDireccion = Convert.ToInt32(dtTabla.Rows[0]["CodDireccion"]);
                CodAlmacen = Convert.ToInt32(dtTabla.Rows[0]["CodAlmacen"]);
                Observacion = Convert.ToString(dtTabla.Rows[0]["Observacion"]);
                CodTipoOperacion = Convert.ToInt32(dtTabla.Rows[0]["CodTipoOperacion"]);
                CodMotivoTraslado = Convert.ToInt32(dtTabla.Rows[0]["CodMotivoTraslado"]);
            }
        }

        public void P_Ventas(Hashtable objTablaFiltro, ref GridView GrillaOC)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.CodVendedor = Convert.ToInt32(objTablaFiltro["Filtro_CodVendedor"]);
            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_SerieDoc"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);

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

            objOperacion = new DocumentoVentaCabCN();
            DataTable dta_consulta = null;

            dta_consulta = objOperacion.F_DocumentoVentaCab_OCXFacturar(objEntidad);

            GrillaOC.DataSource = dta_consulta;
            GrillaOC.DataBind();
        }

        public void P_EliminarRegistro(Hashtable objTablaFiltro, ref String Mensaje)
        {
            NotaIngresoSalidaCabCE objEntidad = null;
            NotaIngresoSalidaCabCN objOperacion = null;

            objEntidad = new NotaIngresoSalidaCabCE();

            objEntidad.CodMovimiento = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));

            objOperacion = new NotaIngresoSalidaCabCN();

            objOperacion.F_Eliminacion_NotaIngreso_Inventario(objEntidad);

            Mensaje = objEntidad.MsgError;
        }

        public void P_Abrir(Hashtable objTablaFiltro, ref String MsgError)
        {
            NotaIngresoSalidaCabCE objEntidad = null;
            NotaIngresoSalidaCabCN objOperacion = null;

            objEntidad = new NotaIngresoSalidaCabCE();

            objEntidad.CodMovimiento = Convert.ToInt32(objTablaFiltro["Filtro_CodMovimiento"]);
        
            objOperacion = new NotaIngresoSalidaCabCN();

            objOperacion.F_NOTAINGRESOSALIDACAB_ABRIR(objEntidad);
            MsgError = objEntidad.MsgError;
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
        //lista los almacenes que se van a mostrar en el grid de stocks
        public static jqTCAlmacenResult F_Inicializar_Combo_Almacenes_Stocks_NET()
        {
            jqTCAlmacenResult data = new jqTCAlmacenResult();
            data.rows = new List<TCAlmacenCE>();
            TCAlmacenCE objEntidad = new TCAlmacenCE();
            TCAlmacenCN objOperacion = new TCAlmacenCN();

            objEntidad.Clave = "";
            try
            {
                DataTable dtb = objOperacion.F_TCAlmacenesExternos_Listar(0);
                foreach (DataRow i in dtb.Rows)
                {
                    //if (int.Parse(i["CodEmpresa"].ToString()) == 3 & int.Parse(i["CodAlmacen"].ToString()) == 2)
                    //{ } else
                    {
                        TCAlmacenCE newpr = new TCAlmacenCE();
                        newpr.CodAlmacenRemoto = Convert.ToInt32(i["CodAlmacenRemoto"].ToString());
                        newpr.ConexionNombre = i["ConexionNombre"].ToString();
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