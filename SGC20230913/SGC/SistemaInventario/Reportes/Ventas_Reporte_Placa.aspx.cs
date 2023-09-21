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
using System.Web.Services;
using SistemaInventario.Clases;
using EasyCallback;
using Newtonsoft.Json;

namespace SistemaInventario.Reportes
{
    public partial class Ventas_Reporte_Placa : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_Mostrar_Serie_NET);
        }

        private string _menu = "10000"; private string _opcion = "200002";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"]; String Opcion = Request.QueryString["Op"];
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
        }

        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddlTipoDocumento_html = "";
            String str_ddl_serie_html = "";
            String str_ddlEmpresa_html = "";
            String str_ddlVendedor_html = "";
            String str_ddlSucursal_html = "";
            int int_resultado_operacion = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlTipoDocumento, ref ddlSerie, ref ddlEmpresa, ref ddlVendedor, ref ddlSucursal);

                str_ddlTipoDocumento_html = Mod_Utilitario.F_GetHtmlForControl(ddlTipoDocumento);
                str_ddlEmpresa_html = Mod_Utilitario.F_GetHtmlForControl(ddlEmpresa);
                str_ddl_serie_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerie);
                str_ddlVendedor_html = Mod_Utilitario.F_GetHtmlForControl(ddlVendedor);
                str_ddlSucursal_html = Mod_Utilitario.F_GetHtmlForControl(ddlSucursal);

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
                str_ddlTipoDocumento_html
                + "~" +
                str_ddl_serie_html
                + "~" +
                str_ddlEmpresa_html
                + "~" +
                str_ddlVendedor_html
                + "~" +
                str_ddlSucursal_html;

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

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_combodocumento,ref DropDownList ddl_combofactura,
                     ref DropDownList ddl_comboempresa, ref DropDownList ddl_empleado, ref DropDownList ddl_comboAlmacen)
        {
            DataTable dta_consulta = null;

            dta_consulta = null;

            TCDocumentosCN objOperacionDocumento = new TCDocumentosCN();
            dta_consulta = objOperacionDocumento.F_TCDocumentos_ListarVentas_FacturaBoleta();

            ddl_combodocumento.Items.Clear();

            ddl_combodocumento.DataSource = dta_consulta;

            ddl_combodocumento.DataTextField = "Descripcion";
            ddl_combodocumento.DataValueField = "CodTipoDoc";
            ddl_combodocumento.DataBind();
            ddl_combodocumento.Items.Insert(0, new ListItem("TODOS", "0"));

            dta_consulta = null;

            dta_consulta = objOperacionDocumento.F_TCEmpresa_Listar();

            ddl_comboempresa.Items.Clear();

            ddl_comboempresa.DataSource = dta_consulta;

            ddl_comboempresa.DataTextField = "T_NombreComercial";
            ddl_comboempresa.DataValueField = "CodEmpresa";
            ddl_comboempresa.DataBind();
            ddl_comboempresa.Items.Insert(0, new ListItem("TODOS", "0"));

            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;

            int iCodEmpresa = 3;

            objEntidad = new TCCorrelativoCE();

            objEntidad.CodTipoDoc = 1;
            objEntidad.CodEstado = 1;
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodEmpresa = iCodEmpresa;

            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_combofactura.Items.Clear();

            ddl_combofactura.DataSource = dta_consulta;
            ddl_combofactura.DataTextField = "SerieDoc";
            ddl_combofactura.DataValueField = "CodSerie";
            ddl_combofactura.DataBind();
            ddl_combofactura.Items.Insert(0, new ListItem("TODOS", "0"));

            EmpleadoCE objEmpleado = new EmpleadoCE();

            objEmpleado.CodCargo = Convert.ToInt32(objTablaFiltro["Filtro_CodCargo"]);
            objEmpleado.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            dta_consulta = (new EmpleadoCN()).F_Empleado_Listar(objEmpleado);
            ddl_empleado.Items.Clear();

            ddl_empleado.DataSource = dta_consulta;
            ddl_empleado.DataTextField = "NombreCompleto";
            ddl_empleado.DataValueField = "CodEmpleado";
            ddl_empleado.DataBind();
            ddl_empleado.Items.Insert(0, new ListItem("TODOS", "0"));

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

        public void P_Mostrar_Serie(Hashtable objTablaFiltro, ref DropDownList comboserie)
        {
            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;
            int iCodEmpresa = 3;
            DataTable dta_consulta = null;

            objEntidad = new TCCorrelativoCE();

            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodDoc"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodEmpresa = iCodEmpresa;

            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            comboserie.Items.Clear();

            comboserie.DataSource = dta_consulta;
            comboserie.DataTextField = "SerieDoc";
            comboserie.DataValueField = "CodSerie";
            comboserie.DataBind();
            comboserie.Items.Insert(0, new ListItem("TODOS", "0"));
        }
    }
}