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
    public partial class Vehiculos : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_GrabarDocumento_NET);
            CallbackManager.Register(F_Nuevo_NET);
            CallbackManager.Register(F_Buscar_NET);
            CallbackManager.Register(F_AnularRegistro_Net);
            CallbackManager.Register(F_ListarModelo_NET);
            CallbackManager.Register(F_TipoCambio_NET);
            CallbackManager.Register(F_EdicionRegistro_NET);
            CallbackManager.Register(F_Observacion_NET);
            CallbackManager.Register(F_Auditoria_NET);
        }

        private string _menu = "9000"; private string _opcion = "1";
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
                GridView grvDetalle = null;
                HiddenField hfCodVehiculo = null;
                HiddenField hfPrincipal = null;
                HiddenField hfCodEstado = null;
                ImageButton imgBtnPrincipal = null;
                ImageButton imgBtnEstado = null;
                GridView grvDetalleObservacion = null;
                GridView grvDetalleAuditoria = null;

                grvDetalleObservacion = (GridView)(e.Row.FindControl("grvDetalleObservacion"));
                grvDetalleAuditoria = (GridView)(e.Row.FindControl("grvDetalleAuditoria"));
                grvDetalle = (GridView)(e.Row.FindControl("grvDetalle"));
                hfCodVehiculo = (HiddenField)(e.Row.FindControl("hfCodVehiculo"));
                hfPrincipal = (HiddenField)(e.Row.FindControl("hfPrincipal"));
                hfCodEstado = (HiddenField)(e.Row.FindControl("hfCodEstado"));
                imgBtnPrincipal = (ImageButton)(e.Row.FindControl("imgPrincipal"));
                imgBtnEstado    = (ImageButton)(e.Row.FindControl("imgActivarRegistro"));

                if (hfCodVehiculo.Value != "")
                {
                  
                    DataTable dta_consultaarticulo = null;
                    DataRow dtr_consultafila = null;
                    dta_consultaarticulo = new DataTable();

                    dta_consultaarticulo.Columns.Add("Placa", typeof(string));
                    dta_consultaarticulo.Columns.Add("Chasis", typeof(string));
                    dta_consultaarticulo.Columns.Add("NroMotor", typeof(string));
                    dta_consultaarticulo.Columns.Add("Color", typeof(string));
                    dta_consultaarticulo.Columns.Add("Marca", typeof(string));
                    dta_consultaarticulo.Columns.Add("Modelo", typeof(string));
                    dta_consultaarticulo.Columns.Add("Anio", typeof(string));
                    dta_consultaarticulo.Columns.Add("FechaRevisionTecnica", typeof(string));
                    dta_consultaarticulo.Columns.Add("FechaVctoSoat", typeof(string));
                    dta_consultaarticulo.Columns.Add("Cliente", typeof(string));
                    dta_consultaarticulo.Columns.Add("TipoPlan", typeof(string));
                    dta_consultaarticulo = null;
                    dtr_consultafila = null;
                    dta_consultaarticulo = new DataTable();

                    dta_consultaarticulo.Columns.Add("Observacion", typeof(string));

                    dtr_consultafila = dta_consultaarticulo.NewRow();

                    dtr_consultafila[0] = "";
                    dta_consultaarticulo.Rows.Add(dtr_consultafila);

                    grvDetalleObservacion.DataSource = dta_consultaarticulo;
                    grvDetalleObservacion.DataBind();

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

        public String F_ListarModelo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            String str_ddl_modelo_html = "";
            String str_ddl_modeloEdicion_html = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_ListarModelo(obj_parametros, ref ddlModelo, ref ddlModeloEdicion);
                str_ddl_modelo_html = Mod_Utilitario.F_GetHtmlForControl(ddlModelo);
                str_ddl_modeloEdicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlModeloEdicion);
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
                str_ddl_modelo_html
                + "~" +
                str_ddl_modeloEdicion_html;

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
            int CodVehiculo = 0;
            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                grvNombre = Convert.ToString(obj_parametros["Filtro_grvNombre"]);
                Col = Convert.ToInt32(obj_parametros["Filtro_Col"]);
                CodVehiculo = Convert.ToInt32(obj_parametros["Filtro_Codigo"]);

                GridView grvAuditoria = (GridView)grvConsulta.Rows[0].FindControl("grvDetalleAuditoria");

                VehiculoCN objOperacion = new VehiculoCN();
                VehiculoCE objEntidad = new VehiculoCE();

                objEntidad.CodVehiculo = CodVehiculo;
                grvAuditoria.DataSource = objOperacion.F_VEHICULO_AUDITORIA(objEntidad);
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

            String str_ddl_color_html = "";
            String str_ddl_marca_html = "";
            String str_ddl_modelo_html = "";
            String str_ddl_tipo_html = "";
            String str_ddl_estado_html = "";
            String str_ddl_TipoPlan_html = "";
            String str_ddl_TipoPlanEdicion_html = "";

            String str_ddl_colorEdicion_html = "";
            String str_ddl_marcaEdicion_html = "";
            String str_ddl_modeloEdicion_html = "";
            String str_ddl_tipoEdicion_html = "";
            String str_ddl_estadoEdicion_html = "";
            String str_ddl_ddlEstadoConsulta_html = "";
            Hashtable obj_parametros = null;
            int int_resultado_operacion = 0;
           

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlColor, ref ddlMarca, ref ddlModelo, ref ddlTipo,
                      ref ddlEstado, ref ddlColorEdicion, ref ddlMarcaEdicion, ref ddlModeloEdicion, ref ddlTipoEdicion,
                      ref ddlEstadoEdicion, ref ddlEstadoConsulta, ref ddlTipoPlan, ref ddlTipoPlanEdicion);

                str_ddl_color_html = Mod_Utilitario.F_GetHtmlForControl(ddlColor);
                str_ddl_marca_html = Mod_Utilitario.F_GetHtmlForControl(ddlMarca);
                str_ddl_modelo_html = Mod_Utilitario.F_GetHtmlForControl(ddlModelo);
                str_ddl_tipo_html = Mod_Utilitario.F_GetHtmlForControl(ddlTipo);
                str_ddl_estado_html = Mod_Utilitario.F_GetHtmlForControl(ddlEstado);
                str_ddl_colorEdicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlColorEdicion);
                str_ddl_marcaEdicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlMarcaEdicion);
                str_ddl_modeloEdicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlModeloEdicion);
                str_ddl_tipoEdicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlTipoEdicion);
                str_ddl_estadoEdicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlEstadoEdicion);
                str_ddl_ddlEstadoConsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlEstadoConsulta);

                str_ddl_TipoPlan_html = Mod_Utilitario.F_GetHtmlForControl(ddlTipoPlan);
                str_ddl_TipoPlanEdicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlTipoPlanEdicion);

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
                str_ddl_color_html + "~" + //2
                str_ddl_marca_html + "~" + //3
                str_ddl_modelo_html + "~" + //4
                str_ddl_tipo_html + "~" + //5
                str_ddl_estado_html + "~" + //6

                str_ddl_colorEdicion_html + "~" + //7
                str_ddl_marcaEdicion_html + "~" + //8
                str_ddl_modeloEdicion_html + "~" + //9
                str_ddl_tipoEdicion_html + "~" + //10
                str_ddl_estadoEdicion_html + "~" + //11
                str_ddl_ddlEstadoConsulta_html   + "~" +//12
                str_ddl_TipoPlan_html  + "~" +//13
                str_ddl_TipoPlanEdicion_html; //14

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

        
        public void P_Controles_Inicializar(Hashtable objTablaFiltro,ref DropDownList ddl_color,ref DropDownList ddl_marca,ref DropDownList ddl_modelo,
            ref DropDownList ddl_tipo, ref DropDownList ddl_estado, ref DropDownList ddl_colorEdicion, ref DropDownList ddl_marcaEdicion, ref DropDownList ddl_modeloEdicion,
            ref DropDownList ddl_tipoEdicion, ref DropDownList ddl_estadoEdicion, ref DropDownList ddl_estadoConsulta, ref DropDownList ddl_TipoPlan, ref DropDownList ddl_TipoPlanEdicion)
        {
            DataTable dta_consulta = null;

            TCConceptosDetCE objEntidadConceptosDet = new TCConceptosDetCE();
            TCConceptosDetCN objOperacionConceptosDet = new TCConceptosDetCN();

            ddl_color.Items.Clear();

            objEntidadConceptosDet.CodConcepto = 17;

            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);

            ddl_color.DataSource = dta_consulta;
            ddl_color.DataTextField = "DscAbvConcepto";
            ddl_color.DataValueField = "CodConcepto";
            ddl_color.DataBind();

            ddl_colorEdicion.Items.Clear();

            ddl_colorEdicion.DataSource = dta_consulta;
            ddl_colorEdicion.DataTextField = "DscAbvConcepto";
            ddl_colorEdicion.DataValueField = "CodConcepto";
            ddl_colorEdicion.DataBind();

                        
            TCConceptosDetCE objEntidadConceptosDets = new TCConceptosDetCE();
           TCConceptosDetCN objOperacionConceptosDets = new TCConceptosDetCN();

            dta_consulta = null;

            objEntidadConceptosDets.CodConcepto = 22;
            
            dta_consulta = null;
            dta_consulta = objOperacionConceptosDets.F_TCConceptos_Select(objEntidadConceptosDets);

            ddl_tipo.Items.Clear();

            ddl_tipo.DataSource = dta_consulta;
            ddl_tipo.DataTextField = "DscAbvConcepto";
            ddl_tipo.DataValueField = "CodConcepto";
            ddl_tipo.DataBind();

            ddl_tipoEdicion.Items.Clear();

            ddl_tipoEdicion.DataSource = dta_consulta;
            ddl_tipoEdicion.DataTextField = "DscAbvConcepto";
            ddl_tipoEdicion.DataValueField = "CodConcepto";
            ddl_tipoEdicion.DataBind();
           // ddl_tipo.Items.Clear();

            objEntidadConceptosDets.CodConcepto = 27;

            dta_consulta = null;
            dta_consulta = objOperacionConceptosDets.F_TCConceptos_Select(objEntidadConceptosDets);

            ddl_estado.Items.Clear();

            ddl_estado.DataSource = dta_consulta;
            ddl_estado.DataTextField = "DscAbvConcepto";
            ddl_estado.DataValueField = "CodConcepto";
            ddl_estado.DataBind();


            ddl_estadoEdicion.Items.Clear();

            ddl_estadoEdicion.DataSource = dta_consulta;
            ddl_estadoEdicion.DataTextField = "DscAbvConcepto";
            ddl_estadoEdicion.DataValueField = "CodConcepto";
            ddl_estadoEdicion.DataBind();

            ddl_estadoConsulta.Items.Clear();

            ddl_estadoConsulta.DataSource = dta_consulta;
            ddl_estadoConsulta.DataTextField = "DscAbvConcepto";
            ddl_estadoConsulta.DataValueField = "CodConcepto";
            ddl_estadoConsulta.DataBind();


           //ddl_estado.Items.Clear();

            //MARCA
            TCCuentaCorrienteCE objMarca = new TCCuentaCorrienteCE();
            dta_consulta = (new TCCuentaCorrienteCN()).F_Linea_Listado(objMarca);
            ddl_marca.Items.Clear();

            ddl_marca.DataSource = dta_consulta;
            ddl_marca.DataTextField = "Descripcion";
            ddl_marca.DataValueField = "CodLinea";
            ddl_marca.DataBind();

            ddl_marcaEdicion.Items.Clear();

            ddl_marcaEdicion.DataSource = dta_consulta;
            ddl_marcaEdicion.DataTextField = "Descripcion";
            ddl_marcaEdicion.DataValueField = "CodLinea";
            ddl_marcaEdicion.DataBind();


            //MODELO VIENE DE UNA TABLA
            // dta_consulta = objOperacionConceptosDets.F_TCConceptos_Select(objEntidadConceptosDets);
            TCCuentaCorrienteCE objModeloVehiculo = new TCCuentaCorrienteCE();
            dta_consulta = (new TCCuentaCorrienteCN()).F_Modelo_Listado(objModeloVehiculo);

            ddl_modelo.Items.Clear();

            ddl_modelo.DataSource = dta_consulta;
            ddl_modelo.DataTextField = "Descripcion";
            ddl_modelo.DataValueField = "CodModeloVehiculo";
            ddl_modelo.DataBind();

            ddl_modeloEdicion.Items.Clear();

            ddl_modeloEdicion.DataSource = dta_consulta;
            ddl_modeloEdicion.DataTextField = "Descripcion";
            ddl_modeloEdicion.DataValueField = "CodModeloVehiculo";
            ddl_modeloEdicion.DataBind();


            VehiculoTipoPlanCE objEntidadDet = new VehiculoTipoPlanCE();
            VehiculoTipoPlanCN objOperacionDet = new VehiculoTipoPlanCN();
            dta_consulta = null;
            dta_consulta = objOperacionDet.F_VehiculoTipoPlan_Listar(objEntidadDet);

            ddl_TipoPlan.Items.Clear();

            ddl_TipoPlan.DataSource = dta_consulta;
            ddl_TipoPlan.DataTextField = "Descripcion";
            ddl_TipoPlan.DataValueField = "CodVehiculoTipoPlan";
            ddl_TipoPlan.DataBind();
            ddl_TipoPlan.Items.Insert(0, new ListItem("SIN PLAN", "0"));

            ddl_TipoPlanEdicion.DataSource = dta_consulta;
            ddl_TipoPlanEdicion.DataTextField = "Descripcion";
            ddl_TipoPlanEdicion.DataValueField = "CodVehiculoTipoPlan";
            ddl_TipoPlanEdicion.DataBind();

            ddl_TipoPlanEdicion.Items.Insert(0, new ListItem("SIN PLAN", "0"));

           // ddl_modelo.Items.Clear();

            //ddl_combomoneda_edicion.DataSource = dta_consulta;
            //ddl_combomoneda_edicion.DataTextField = "DscAbvConcepto";
            //ddl_combomoneda_edicion.DataValueField = "CodConcepto";
            //ddl_combomoneda_edicion.DataBind();

        }

        public void P_Inicializar_GrillaVacia_Consulta()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();
            dta_consultaarticulo.Columns.Add("Codigo", typeof(string));
            dta_consultaarticulo.Columns.Add("CodCliente", typeof(string));
            dta_consultaarticulo.Columns.Add("CodVehiculo", typeof(string));
            dta_consultaarticulo.Columns.Add("CodModeloVehiculo", typeof(string));
            dta_consultaarticulo.Columns.Add("RucCliente", typeof(string));
            dta_consultaarticulo.Columns.Add("NroFlota", typeof(string));
            dta_consultaarticulo.Columns.Add("Observacion", typeof(string));
            dta_consultaarticulo.Columns.Add("CodTipoVehiculo", typeof(string));
            dta_consultaarticulo.Columns.Add("CodColor", typeof(string));
            dta_consultaarticulo.Columns.Add("CodEstado", typeof(string));
            dta_consultaarticulo.Columns.Add("CodMarca", typeof(string));
            dta_consultaarticulo.Columns.Add("RazonSocial", typeof(string));
            dta_consultaarticulo.Columns.Add("Distrito", typeof(string));
            dta_consultaarticulo.Columns.Add("Direccion", typeof(string));
            dta_consultaarticulo.Columns.Add("Cliente", typeof(string));
            dta_consultaarticulo.Columns.Add("Placa", typeof(string));
            dta_consultaarticulo.Columns.Add("Chasis", typeof(string));
            dta_consultaarticulo.Columns.Add("NroMotor", typeof(string));
            dta_consultaarticulo.Columns.Add("Color", typeof(string));
            dta_consultaarticulo.Columns.Add("TipoVehiculo", typeof(string));
            dta_consultaarticulo.Columns.Add("Estado", typeof(string));
            dta_consultaarticulo.Columns.Add("Marca", typeof(string));
            dta_consultaarticulo.Columns.Add("CodDepartamento", typeof(string));
            dta_consultaarticulo.Columns.Add("CodDistrito", typeof(string));
            dta_consultaarticulo.Columns.Add("CodProvincia", typeof(string));
            dta_consultaarticulo.Columns.Add("Modelo", typeof(string));
            dta_consultaarticulo.Columns.Add("Anio", typeof(string));
            dta_consultaarticulo.Columns.Add("FechaRevisionTecnica", typeof(string));
            dta_consultaarticulo.Columns.Add("FechaVctoSoat", typeof(string));
            dta_consultaarticulo.Columns.Add("CodTipoPlan", typeof(string));
            dta_consultaarticulo.Columns.Add("TipoPlan", typeof(string));

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
            dtr_consultafila[11] = "";
            dtr_consultafila[12] = "";
            dtr_consultafila[13] = "";
            dtr_consultafila[14] = "";
            dtr_consultafila[15] = "";

            dta_consultaarticulo.Rows.Add(dtr_consultafila);

            grvConsulta.DataSource = dta_consultaarticulo;
            grvConsulta.DataBind();
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
            VehiculoCE objEntidad = null;
            VehiculoCN objOperacion = null;

            objEntidad = new VehiculoCE();

            int iCodEmpresa = 3;

            objEntidad.CodEmpresa = iCodEmpresa;

            objEntidad.Placa = Convert.ToString(objTablaFiltro["Filtro_Placa"]);
            objEntidad.Chasis = Convert.ToString(objTablaFiltro["Filtro_Chasis"]);
            objEntidad.CodCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodCliente"]);
            objEntidad.Anio = Convert.ToInt32(objTablaFiltro["Filtro_Anio"]);
            objEntidad.NroMotor = Convert.ToString(objTablaFiltro["Filtro_NroMotor"]);

            if (Convert.ToString(objTablaFiltro["Filtro_CodTipoPlan"]) != "")
                objEntidad.CodVehiculoTipoPlan = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoPlan"]);

            if (Convert.ToString(objTablaFiltro["Filtro_NroFlota"]) != "") 
            objEntidad.NroFlota = Convert.ToInt32(objTablaFiltro["Filtro_NroFlota"]);
           
            

            if (Convert.ToString(objTablaFiltro["Filtro_Revision"]) != "") 
                objEntidad.FechaRevisionTecnica = Convert.ToDateTime(objTablaFiltro["Filtro_Revision"]);
            else
                objEntidad.FechaRevisionTecnica = Convert.ToDateTime("1/1/1900");

            if (Convert.ToString(objTablaFiltro["Filtro_VencimientoSoat"]) != "")
                objEntidad.FechaVctoSoat = Convert.ToDateTime(objTablaFiltro["Filtro_VencimientoSoat"]);
            else
                objEntidad.FechaVctoSoat = Convert.ToDateTime("1/1/1900");


            objEntidad.Observacion = Convert.ToString(objTablaFiltro["Filtro_Observacion"]);

            objEntidad.CodColor = Convert.ToInt32(objTablaFiltro["Filtro_CodColor"]);
            objEntidad.CodModeloVehiculo = Convert.ToInt32(objTablaFiltro["Filtro_CodModelo"]);
            objEntidad.CodMarca = Convert.ToInt32(objTablaFiltro["Filtro_CodMarca"]);
            objEntidad.CodTipoVehiculo = Convert.ToInt32(objTablaFiltro["Filtro_CodTipo"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);

            objEntidad.Direccion = Convert.ToString(objTablaFiltro["Filtro_Direccion"]);
            objEntidad.RazonSocial = Convert.ToString(objTablaFiltro["Filtro_RazonSocial"]);
            objEntidad.NroRuc = Convert.ToString(objTablaFiltro["Filtro_NroRuc"]);
            objEntidad.NroDni = Convert.ToString(objTablaFiltro["Filtro_NroDni"]);

            objEntidad.CodDepartamento = Convert.ToInt32(objTablaFiltro["Filtro_CodDepartamento"]);
            objEntidad.CodProvincia = Convert.ToInt32(objTablaFiltro["Filtro_CodProvincia"]);
            objEntidad.CodDistrito = Convert.ToInt32(objTablaFiltro["Filtro_CodDistrito"]);
            objEntidad.CodTipoCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoCliente"]);
            objEntidad.CodDireccion = Convert.ToInt32(objTablaFiltro["Filtro_CodDireccion"]);

            objEntidad.CodUsuarioRegistro = Convert.ToInt32(Session["CodUsuario"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
          

            objOperacion = new VehiculoCN();

            objOperacion.F_VEHICULO_Insert(objEntidad);

            MsgError = objEntidad.MsgError;
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
            VehiculoCE objEntidad = null;
            VehiculoCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new VehiculoCE();

            objEntidad.Descripcion = Convert.ToString(objTablaFiltro["Filtro_Descripcion"]);
            objEntidad.Placa = Convert.ToString(objTablaFiltro["Filtro_Placa"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);

            objOperacion = new VehiculoCN();

            dta_consulta = objOperacion.F_Vehiculos_Listar(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();
        }

        public void P_AnularRegistro(Hashtable objTablaFiltro, ref String Mensaje)
        {
            VehiculoCE objEntidad = null;
            VehiculoCN objOperacion = null;

            objEntidad = new VehiculoCE();

            objEntidad.CodVehiculo = Convert.ToInt32(objTablaFiltro["Filtro_CodVehiculo"]);

            objOperacion = new VehiculoCN();

            objOperacion.F_Vehiculo_Eliminar(objEntidad);

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
            VehiculoCE objEntidad = null;
            VehiculoCN objOperacion = null;

            objEntidad = new VehiculoCE();

            int iCodEmpresa = 3;
            objEntidad.CodEmpresa = iCodEmpresa;
            objEntidad.Placa = Convert.ToString(objTablaFiltro["Filtro_Placa"]);
            objEntidad.Chasis = Convert.ToString(objTablaFiltro["Filtro_Chasis"]);
            objEntidad.CodCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodCliente"]);
            objEntidad.Anio = Convert.ToInt32(objTablaFiltro["Filtro_Anio"]);
            objEntidad.NroMotor = Convert.ToString(objTablaFiltro["Filtro_NroMotor"]);
            objEntidad.CodVehiculo = Convert.ToInt32(objTablaFiltro["Filtro_CodVehiculo"]);

            if (Convert.ToString(objTablaFiltro["Filtro_NroFlota"]) != "")
            objEntidad.NroFlota = Convert.ToInt32(objTablaFiltro["Filtro_NroFlota"]);
          
            if (Convert.ToString(objTablaFiltro["Filtro_CodTipoPlan"]) != "")
                objEntidad.CodVehiculoTipoPlan = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoPlan"]);

            if (Convert.ToString(objTablaFiltro["Filtro_Revision"]) != "")
                objEntidad.FechaRevisionTecnica = Convert.ToDateTime(objTablaFiltro["Filtro_Revision"]);
            else
                objEntidad.FechaRevisionTecnica = Convert.ToDateTime("1/1/1900");

            if (Convert.ToString(objTablaFiltro["Filtro_VencimientoSoat"]) != "")
                objEntidad.FechaVctoSoat = Convert.ToDateTime(objTablaFiltro["Filtro_VencimientoSoat"]);
            else
                objEntidad.FechaVctoSoat = Convert.ToDateTime("1/1/1900");


            objEntidad.Observacion = Convert.ToString(objTablaFiltro["Filtro_Observacion"]);

            objEntidad.CodColor = Convert.ToInt32(objTablaFiltro["Filtro_CodColor"]);
            objEntidad.CodModeloVehiculo = Convert.ToInt32(objTablaFiltro["Filtro_CodModelo"]);
            objEntidad.CodMarca = Convert.ToInt32(objTablaFiltro["Filtro_CodMarca"]);
            objEntidad.CodTipoVehiculo = Convert.ToInt32(objTablaFiltro["Filtro_CodTipo"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);

            objEntidad.Direccion = Convert.ToString(objTablaFiltro["Filtro_Direccion"]);
            objEntidad.RazonSocial = Convert.ToString(objTablaFiltro["Filtro_RazonSocial"]);
            objEntidad.NroRuc = Convert.ToString(objTablaFiltro["Filtro_NroRuc"]);
            objEntidad.NroDni = Convert.ToString(objTablaFiltro["Filtro_NroDni"]);

            objEntidad.CodDepartamento = Convert.ToInt32(objTablaFiltro["Filtro_CodDepartamento"]);
            objEntidad.CodProvincia = Convert.ToInt32(objTablaFiltro["Filtro_CodProvincia"]);
            objEntidad.CodDistrito = Convert.ToInt32(objTablaFiltro["Filtro_CodDistrito"]);
            objEntidad.CodTipoCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoCliente"]);
            objEntidad.CodDireccion = Convert.ToInt32(objTablaFiltro["Filtro_CodDireccion"]);

            objEntidad.CodUsuarioModificacion = Convert.ToInt32(Session["CodUsuario"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
          



            objOperacion = new VehiculoCN();

            objOperacion.F_Vehiculo_Update(objEntidad);

            MsgError = objEntidad.MsgError;
        }

    
    }
}