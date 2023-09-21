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

namespace SistemaInventario.Reportes
{
    public partial class CajaBanco_CuentaBancaria : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_ListarNroCuenta_NET);
        }

        private string _menu = "10000"; private string _opcion = "200001";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"]; String Opcion = Request.QueryString["Op"];
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
            Session["datos"] = true;
        }

        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddl_sucursal_html = "";
            String str_ddl_moneda_html = "";
            String str_ddl_banco_html = "";
            String str_ddl_nrocuenta_html = "";
            String str_ddlCajaFisica_html = "";
            String str_ddlMedioPago_html = "";     
            int int_resultado_operacion = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlSucursal, ref ddlMoneda, ref ddlBanco, ref ddlCajaFisica, ref ddlMedioPago);
                P_ListarNroCuenta(obj_parametros, ref ddlCuenta);
                             
                str_ddl_moneda_html = Mod_Utilitario.F_GetHtmlForControl(ddlMoneda);             
                str_ddl_banco_html = Mod_Utilitario.F_GetHtmlForControl(ddlBanco);         
                str_ddl_nrocuenta_html = Mod_Utilitario.F_GetHtmlForControl(ddlCuenta);           
                str_ddlCajaFisica_html = Mod_Utilitario.F_GetHtmlForControl(ddlCajaFisica);       
                str_ddl_sucursal_html = Mod_Utilitario.F_GetHtmlForControl(ddlSucursal);
                str_ddlMedioPago_html = Mod_Utilitario.F_GetHtmlForControl(ddlMedioPago);

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
                str_ddl_sucursal_html + "~" +      //2             
                str_ddl_moneda_html  +"~" + //3              
                str_ddl_banco_html + "~" + //4
                str_ddl_nrocuenta_html + "~" + //5      
                str_ddlCajaFisica_html + "~" +  //6
                str_ddlMedioPago_html; //7

            return str_resultado;
        }

        public String F_ListarNroCuenta_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            String str_ddl_nrocuenta_html = "";        
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_ListarNroCuenta(obj_parametros, ref ddlCuenta);
                str_ddl_nrocuenta_html = Mod_Utilitario.F_GetHtmlForControl(ddlCuenta);
       
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
                str_ddl_nrocuenta_html;

            return str_resultado;
        }

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList combosucursal, ref DropDownList ddl_combomoneda,
            ref DropDownList ddl_combobanco, ref DropDownList ddl_CajaFisica, ref DropDownList ddl_combomediopago)
        {
            DataTable dta_consulta = null;

            int iCodEmpresa = 3;

            TCAlmacenCE objEntidadAlmacen = null;
            TCAlmacenCN objOperacionAlmacen = null;

            objEntidadAlmacen = new TCAlmacenCE();

            objEntidadAlmacen.CodEmpresa = iCodEmpresa;
            objEntidadAlmacen.CodAlmacen = 0;

            objOperacionAlmacen = new TCAlmacenCN();

            combosucursal.Items.Clear();

            dta_consulta = objOperacionAlmacen.F_TCAlmacen_Listar(objEntidadAlmacen);

            combosucursal.DataSource = dta_consulta;
            combosucursal.DataTextField = "DscAlmacen";
            combosucursal.DataValueField = "CodAlmacen";
            combosucursal.DataBind();

            ListItem iTodos = new ListItem("--TODOS--", "0");
            combosucursal.Items.Add(iTodos);


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

            ddl_combomoneda.Items.Add(new ListItem() { Value = "0", Text = "TODOS" });

            BancosCN objOperacionBancos = new BancosCN();

            dta_consulta = null;

            dta_consulta = objOperacionBancos.F_Listar_Bancos();

            ddl_combobanco.Items.Clear();

            ddl_combobanco.DataSource = dta_consulta;
            ddl_combobanco.DataTextField = "DscBanco";
            ddl_combobanco.DataValueField = "CodBanco";
            ddl_combobanco.DataBind();

            dta_consulta = null;

            dta_consulta = (new CajaFisicaCN()).F_dtCajaFisica_Listar(1,0, Convert.ToInt32(objTablaFiltro["Filtro_CodEmpresa"]));
            ddl_CajaFisica.Items.Clear();
            ddl_CajaFisica.DataSource = dta_consulta;
            ddl_CajaFisica.DataTextField = "Descripcion";
            ddl_CajaFisica.DataValueField = "CodCajaFisica";
            ddl_CajaFisica.DataBind();

            dta_consulta = null;

            objEntidadConceptosDet.CodPrincipal = 23;

            dta_consulta = objOperacionConceptosDet.F_TCConceptosDet_MEDIOPAGO_TARJETA_DEPOSITO(objEntidadConceptosDet);

            ddl_combomediopago.Items.Clear();

            ddl_combomediopago.DataSource = dta_consulta;
            ddl_combomediopago.DataTextField = "DscAbvConcepto";
            ddl_combomediopago.DataValueField = "CodConcepto";
            ddl_combomediopago.DataBind();

            ddl_combomediopago.Items.Add(new ListItem() { Value = "0", Text = "TODOS" });
        }

        public void P_ListarNroCuenta(Hashtable objTablaFiltro,ref DropDownList ddl_combonrocuenta)
        {
            BancosCE objEntidad = null;
            BancosCN objOperacion = null;
            DataTable dta_consulta = null;
            objEntidad = new BancosCE();

            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
            objEntidad.CodBanco = Convert.ToInt32(objTablaFiltro["Filtro_CodBanco"]);

            objOperacion = new BancosCN();

            dta_consulta = null;

            dta_consulta = objOperacion.F_Listar_NroCuenta(objEntidad);

            ddl_combonrocuenta.Items.Clear();

            ddl_combonrocuenta.DataSource = dta_consulta;
            ddl_combonrocuenta.DataTextField = "NumeroCuenta";
            ddl_combonrocuenta.DataValueField = "CodCuenta";
            ddl_combonrocuenta.DataBind();
        }
    }
}