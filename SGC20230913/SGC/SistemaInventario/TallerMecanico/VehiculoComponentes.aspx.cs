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
using CapaDatos;

namespace SistemaInventario.Maestros
{
    public partial class VehiculoComponentes : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_AgregarTemporal_NET);
            CallbackManager.Register(F_GrabarDocumento_NET);
            CallbackManager.Register(F_Nuevo_NET);
            CallbackManager.Register(F_Buscar_NET);
            CallbackManager.Register(F_AnularRegistro_Net);
            CallbackManager.Register(F_TipoCambio_NET);
            CallbackManager.Register(F_EdicionRegistro_NET);
            CallbackManager.Register(F_Observacion_NET);
            CallbackManager.Register(F_Auditoria_NET);
        }

        private string _menu = "9000"; private string _opcion = "2";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"]; String Opcion = Request.QueryString["Op"];
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
            P_Inicializar_GrillaVacia_Consulta();
            Session["datos"] = true;
        }

        protected void grvConsulta_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hfCodVehiculoComponente = null;
               GridView grvDetalleAuditoria = null;

               grvDetalleAuditoria = (GridView)(e.Row.FindControl("grvDetalleAuditoria"));
               hfCodVehiculoComponente = (HiddenField)(e.Row.FindControl("hfCodVehiculoComponente"));

               if (hfCodVehiculoComponente.Value != "")
            {

                DataTable dta_consultaarticulo = null;
                DataRow dtr_consultafila = null;
                dta_consultaarticulo = new DataTable();

                dta_consultaarticulo = new DataTable();
                dta_consultaarticulo = new DataTable();
                dta_consultaarticulo.Columns.Add("Cantidad", typeof(string));
                dta_consultaarticulo.Columns.Add("Estado", typeof(string));
                dta_consultaarticulo.Columns.Add("TipoVehiculo", typeof(string));
                dta_consultaarticulo.Columns.Add("TipoConcepto", typeof(string));
                dta_consultaarticulo.Columns.Add("CodEstado", typeof(string));
                dta_consultaarticulo.Columns.Add("Descripcion", typeof(string));
                dta_consultaarticulo.Columns.Add("CodTipoComponente", typeof(string));
                dta_consultaarticulo.Columns.Add("CodTipoVehiculo", typeof(string));
                dta_consultaarticulo.Columns.Add("CodVehiculoComponente", typeof(string));

                dta_consultaarticulo = null;
                dtr_consultafila = null;
                dta_consultaarticulo = new DataTable();

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
            }
        }



        public String F_Auditoria_NET(String arg)
        {
            int int_resultado_operacion = 0;
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String grvNombre = "";
            String str_grv_Auditoria_html = "";
            int Col = 0;
            int CodVehiculo = 0;
            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                grvNombre = Convert.ToString(obj_parametros["Filtro_grvNombre"]);
                Col = Convert.ToInt32(obj_parametros["Filtro_Col"]);
                CodVehiculo = Convert.ToInt32(obj_parametros["Filtro_Codigo"]);

                GridView grvAuditoria = (GridView)grvConsulta.Rows[0].FindControl("grvDetalleAuditoria");

                VehiculoComponenteCN objOperacion = new VehiculoComponenteCN();
                VehiculoComponenteCE objEntidad = new VehiculoComponenteCE();

                objEntidad.CodVehiculoComponente = CodVehiculo;
                grvAuditoria.DataSource = objOperacion.F_VEHICULOCOMPONENTE_AUDITORIA(objEntidad);
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

                VehiculoCN objOperacion = new VehiculoCN();
                VehiculoCE objEntidad = new VehiculoCE();

                objEntidad.CodVehiculo = Codigo;
                grvDetalle.DataSource = objOperacion.F_VEHICULO_OBSERVACION(objEntidad);
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




        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";

            String str_ddl_componente_html = "";
            String str_ddl_vehiculo_html = "";

            String str_ddl_componenteEdicion_html = "";
            String str_ddl_vehiculoEdicion_html = "";

            String str_ddl_componenteConsulta_html = "";
            String str_ddl_vehiculoConsulta_html = "";

            String str_ddl_estado_html = "";
            String str_ddl_estadoEdicion_tml = "";
            String str_ddl_estadoConsulta_tml = "";


            Hashtable obj_parametros = null;
            int int_resultado_operacion = 0;
           

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros,  ref ddlTipoComponente, ref ddlTipoVehiculo, ref ddlEstado, ref ddlTipoComponenteEdicion, ref ddlTipoVehiculoEdicion,
                      ref ddlEstadoEdicion, ref ddlEstadoConsulta, ref ddlTipoComponenteConsulta, ref ddlTipoVehiculoConsulta);

                str_ddl_componente_html = Mod_Utilitario.F_GetHtmlForControl(ddlTipoComponente);
                str_ddl_componenteEdicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlTipoComponenteEdicion);
                str_ddl_componenteConsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlTipoComponenteConsulta);
                
                str_ddl_vehiculo_html = Mod_Utilitario.F_GetHtmlForControl(ddlTipoVehiculo);
                str_ddl_vehiculoEdicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlTipoVehiculoEdicion);
                str_ddl_vehiculoConsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlTipoVehiculoConsulta);

                str_ddl_estado_html = Mod_Utilitario.F_GetHtmlForControl(ddlEstado);
                str_ddl_estadoEdicion_tml = Mod_Utilitario.F_GetHtmlForControl(ddlEstadoEdicion);
                str_ddl_estadoConsulta_tml = Mod_Utilitario.F_GetHtmlForControl(ddlEstadoConsulta);

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
                str_ddl_componente_html + "~" + //2
                str_ddl_componenteEdicion_html + "~" + //3
                str_ddl_componenteConsulta_html + "~" + //4
                str_ddl_vehiculo_html + "~" + //5
                str_ddl_vehiculoEdicion_html + "~" + //6
                str_ddl_vehiculoConsulta_html + "~" + //6
                str_ddl_estado_html + "~" + //7
                str_ddl_estadoEdicion_tml + "~" + //8
                str_ddl_estadoConsulta_tml; //9

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
                //P_CargarGrillaTemporal_Factura(obj_parametros, Codigo, ref grvFactura, ref Total);
                //if (grvFactura.Rows.Count == 0)
                //P_Inicializar_GrillaVacia_Factura();

                //str_grvDetalleFactura_html = Mod_Utilitario.F_GetHtmlForControl(grvFactura);

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

        public String F_GrabarDocumento_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_GrabarDocumento(obj_parametros, ref str_mensaje_operacion);
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

        public String F_Nuevo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvFactura_html = "";
            String str_grvLetra_html = "";
            int int_resultado_operacion = 0;


            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                //str_grvFactura_html = Mod_Utilitario.F_GetHtmlForControl(grvFactura);
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
                str_grvFactura_html;


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
                    str_mensaje_operacion = "No se encontraron registros.";
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

        public String F_EdicionRegistro_NET(String arg)
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
                P_EditarRegistro(obj_parametros, ref MsgError);
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

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_TipoComponente, ref DropDownList ddl_TipoVehiculo, ref DropDownList ddl_Estado,
            ref DropDownList ddl_TipoComponenteEdicion, ref DropDownList ddl_TipoVehiculoEdicion, ref DropDownList ddl_EstadoEdicion, ref DropDownList ddl_EstadoConsulta, ref DropDownList ddl_TipoComponenteConsulta,
            ref DropDownList ddl_TipoVehiculoConsulta)
        {
            DataTable dta_consulta = null;

            TCConceptosDetCE objEntidadConceptosDet = new TCConceptosDetCE();
            TCConceptosDetCN objOperacionConceptosDet = new TCConceptosDetCN();

            ddl_TipoComponente.Items.Clear();

            objEntidadConceptosDet.CodConcepto = 14;

            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);

            ddl_TipoComponente.DataSource = dta_consulta;
            ddl_TipoComponente.DataTextField = "DscAbvConcepto";
            ddl_TipoComponente.DataValueField = "CodConcepto";
            ddl_TipoComponente.DataBind();

            ddl_TipoComponenteEdicion.Items.Clear();

            ddl_TipoComponenteEdicion.DataSource = dta_consulta;
            ddl_TipoComponenteEdicion.DataTextField = "DscAbvConcepto";
            ddl_TipoComponenteEdicion.DataValueField = "CodConcepto";
            ddl_TipoComponenteEdicion.DataBind();

            ddl_TipoComponenteConsulta.Items.Clear();

            ddl_TipoComponenteConsulta.DataSource = dta_consulta;
            ddl_TipoComponenteConsulta.DataTextField = "DscAbvConcepto";
            ddl_TipoComponenteConsulta.DataValueField = "CodConcepto";
            ddl_TipoComponenteConsulta.DataBind();
            
                        
            TCConceptosDetCE objEntidadConceptosDets = new TCConceptosDetCE();
            TCConceptosDetCN objOperacionConceptosDets = new TCConceptosDetCN();

            dta_consulta = null;

            objEntidadConceptosDets.CodConcepto = 22;
            
            dta_consulta = null;
            dta_consulta = objOperacionConceptosDets.F_TCConceptos_Select(objEntidadConceptosDets);

            ddl_TipoVehiculo.Items.Clear();

            ddl_TipoVehiculo.DataSource = dta_consulta;
            ddl_TipoVehiculo.DataTextField = "DscAbvConcepto";
            ddl_TipoVehiculo.DataValueField = "CodConcepto";
            ddl_TipoVehiculo.DataBind();

            ddl_TipoVehiculoEdicion.Items.Clear();

            ddl_TipoVehiculoEdicion.DataSource = dta_consulta;
            ddl_TipoVehiculoEdicion.DataTextField = "DscAbvConcepto";
            ddl_TipoVehiculoEdicion.DataValueField = "CodConcepto";
            ddl_TipoVehiculoEdicion.DataBind();

            ddl_TipoVehiculoConsulta.Items.Clear();

            ddl_TipoVehiculoConsulta.DataSource = dta_consulta;
            ddl_TipoVehiculoConsulta.DataTextField = "DscAbvConcepto";
            ddl_TipoVehiculoConsulta.DataValueField = "CodConcepto";
            ddl_TipoVehiculoConsulta.DataBind();

           // ddl_tipo.Items.Clear();

            objEntidadConceptosDets.CodConcepto = 27;

            dta_consulta = null;
            dta_consulta = objOperacionConceptosDets.F_TCConceptos_Select(objEntidadConceptosDets);

            ddl_Estado.Items.Clear();

            ddl_Estado.DataSource = dta_consulta;
            ddl_Estado.DataTextField = "DscAbvConcepto";
            ddl_Estado.DataValueField = "CodConcepto";
            ddl_Estado.DataBind();


            ddl_EstadoEdicion.Items.Clear();

            ddl_EstadoEdicion.DataSource = dta_consulta;
            ddl_EstadoEdicion.DataTextField = "DscAbvConcepto";
            ddl_EstadoEdicion.DataValueField = "CodConcepto";
            ddl_EstadoEdicion.DataBind();

            ddl_EstadoConsulta.Items.Clear();

            ddl_EstadoConsulta.DataSource = dta_consulta;
            ddl_EstadoConsulta.DataTextField = "DscAbvConcepto";
            ddl_EstadoConsulta.DataValueField = "CodConcepto";
            ddl_EstadoConsulta.DataBind();



        }

        public void P_Inicializar_GrillaVacia_Consulta()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();
            dta_consultaarticulo.Columns.Add("Cantidad", typeof(string));
            dta_consultaarticulo.Columns.Add("Estado", typeof(string));
            dta_consultaarticulo.Columns.Add("TipoVehiculo", typeof(string));
            dta_consultaarticulo.Columns.Add("TipoConcepto", typeof(string));
            dta_consultaarticulo.Columns.Add("CodEstado", typeof(string));
            dta_consultaarticulo.Columns.Add("Descripcion", typeof(string));
            dta_consultaarticulo.Columns.Add("CodTipoComponente", typeof(string));
            dta_consultaarticulo.Columns.Add("CodTipoVehiculo", typeof(string));
            dta_consultaarticulo.Columns.Add("CodVehiculoComponente", typeof(string));
            
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

            grvConsulta.DataSource = dta_consultaarticulo;
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
                XmlDetalle = XmlDetalle + " Total = '" + item.Total + "'";
                XmlDetalle = XmlDetalle + " Moneda = '" + item.Moneda + "'";
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

        public void P_ListarModelo(Hashtable objTablaFiltro,
         ref DropDownList ddl_combomodelo, ref DropDownList ddl_combomodelo_Edicion)
        {
            VehiculoCE objEntidad = null;
            VehiculoCN objOperacion = null;
            DataTable dta_consulta = null;
            objEntidad = new VehiculoCE();

            objEntidad.CodMarca = Convert.ToInt32(objTablaFiltro["Filtro_CodMarca"]);

            objOperacion = new VehiculoCN();

            dta_consulta = null;

            dta_consulta = objOperacion.F_Listar_Modelo(objEntidad);

            ddl_combomodelo.Items.Clear();

            ddl_combomodelo.DataSource = dta_consulta;
            ddl_combomodelo.DataTextField = "Descripcion";
            ddl_combomodelo.DataValueField = "CodModeloVehiculo";
            ddl_combomodelo.DataBind();

            ddl_combomodelo_Edicion.Items.Clear();

            ddl_combomodelo_Edicion.DataSource = dta_consulta;
            ddl_combomodelo_Edicion.DataTextField = "Descripcion";
            ddl_combomodelo_Edicion.DataValueField = "CodModeloVehiculo";
            ddl_combomodelo_Edicion.DataBind();
        }


        public void P_GrabarDocumento(Hashtable objTablaFiltro, ref String MsgError)
        {
            VehiculoComponenteCE objEntidad = null;
            VehiculoComponenteCN objOperacion = null;

            objEntidad = new VehiculoComponenteCE();

            int iCodEmpresa = 3;

            objEntidad.CodEmpresa = iCodEmpresa;

            objEntidad.CodTipoVehiculo = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoVehiculo"]);
            objEntidad.CodTipoComponente = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoComponente"]);
            objEntidad.Descripcion = Convert.ToString(objTablaFiltro["Filtro_Descripcion"]);
            objEntidad.Cantidad = Convert.ToInt32(objTablaFiltro["Filtro_Cantidad"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new VehiculoComponenteCN();

            objOperacion.F_VehiculoComponentes_Insert(objEntidad);

            MsgError = objEntidad.MsgError;
        }

      
    
        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {
            VehiculoComponenteCE objEntidad = null;
            VehiculoComponenteCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new VehiculoComponenteCE();

            objEntidad.Descripcion = Convert.ToString(objTablaFiltro["Filtro_Descripcion"]);
            objEntidad.CodTipoComponente = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoComponente"]);
            objEntidad.CodTipoVehiculo = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoVehiculo"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);

            objOperacion = new VehiculoComponenteCN();

            dta_consulta = objOperacion.F_VehiculoComponentes_Listar(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();
        }

        public void P_AnularRegistro(Hashtable objTablaFiltro, ref String Mensaje)
        {
            VehiculoComponenteCE objEntidad = null;
            VehiculoComponenteCN objOperacion = null;

            objEntidad = new VehiculoComponenteCE();

            objEntidad.CodVehiculoComponente = Convert.ToInt32(objTablaFiltro["Filtro_CodVehiculoComponente"]);

            objOperacion = new VehiculoComponenteCN();

            objOperacion.F_VehiculoComponentes_Eliminar(objEntidad);

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

        public void P_EditarRegistro(Hashtable objTablaFiltro, ref String MsgError)
        {
            VehiculoComponenteCE objEntidad = null;
            VehiculoComponenteCN objOperacion = null;

            objEntidad = new VehiculoComponenteCE();

            int iCodEmpresa = 3;
            objEntidad.CodEmpresa = iCodEmpresa;
            objEntidad.CodTipoVehiculo = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoVehiculo"]);
            objEntidad.CodTipoComponente = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoComponente"]);
            objEntidad.Descripcion = Convert.ToString(objTablaFiltro["Filtro_Descripcion"]);
            objEntidad.Cantidad = Convert.ToInt32(objTablaFiltro["Filtro_Cantidad"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);
            objEntidad.CodVehiculoComponente = Convert.ToInt32(objTablaFiltro["Filtro_CodVehiculoComponente"]);
           
        
            objEntidad.CodUsuarioModificacion = Convert.ToInt32(Session["CodUsuario"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);




            objOperacion = new VehiculoComponenteCN();

            objOperacion.F_VehiculoComponentes_Update(objEntidad);

            MsgError = objEntidad.MsgError;
        }

    
    }
}