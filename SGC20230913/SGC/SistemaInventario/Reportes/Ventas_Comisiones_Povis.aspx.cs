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
using SistemaInventario.Clases;
using EasyCallback;
using Newtonsoft.Json;

namespace SistemaInventario.Reportes
{
    public partial class Ventas_Comisiones_Povis : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
        }

        private string _menu = ""; private string _opcion = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"];
            String Opcion = Request.QueryString["Op"];

            //if (Menu == null | (_menu != Menu | _opcion != Opcion) | Utilitarios.Menu.F_PermisoOpcion(_menu, _opcion) == false)
            //{
            //    Response.Redirect("../Maestros/TipoCambio.aspx");
            //    return;
            //}

            //Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Session["datos"] = true;
        }

        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddlEmpresa_html = "";
            String str_ddlRuta_html = "";
            String str_ddlVendedor_html = "";
            String str_ddl_moneda_html = "";
            int int_resultado_operacion = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlVendedor, ref ddlRuta);

                str_ddlVendedor_html = Mod_Utilitario.F_GetHtmlForControl(ddlVendedor);
                str_ddlRuta_html = Mod_Utilitario.F_GetHtmlForControl(ddlRuta);

                int_resultado_operacion = 1;
                str_mensaje_operacion = "";
            }
            catch (Exception ex)
            {
                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" +
                str_mensaje_operacion + "~" +
                str_ddlEmpresa_html + "~" +
                str_ddlRuta_html + "~" +
                str_ddlVendedor_html + "~" +
                str_ddl_moneda_html;

            return str_resultado;
        }


        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_Vendedor, ref DropDownList ddl_Ruta)
        {
            DataTable dta_consulta = null;
            TCConceptosDetCE objEntidadConceptosDet = new TCConceptosDetCE();

            objEntidadConceptosDet.CodConcepto = 4;

            TCConceptosDetCN objOperacionConceptosDet = new TCConceptosDetCN();
            dta_consulta = null;
            dta_consulta = objOperacionConceptosDet.F_RUTA_LISTAR_COMBO();

            ddl_Ruta.Items.Clear();

            ddl_Ruta.DataSource = dta_consulta;
            ddl_Ruta.DataTextField = "Ruta";
            ddl_Ruta.DataValueField = "CodTerritorio";
            ddl_Ruta.DataBind();


            ddl_Ruta.Items.Insert(0, new ListItem() { Text = "--TODOS--", Value = "0" });

            EmpleadoCE objEmpleado = new EmpleadoCE();

            objEmpleado.CodCargo = Convert.ToInt32(objTablaFiltro["Filtro_CodCargo"]);
            objEmpleado.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            dta_consulta = (new EmpleadoCN()).F_Empleado_Listar(objEmpleado);
            ddl_Vendedor.Items.Clear();

            ddl_Vendedor.DataSource = dta_consulta;
            ddl_Vendedor.DataTextField = "NombreCompleto";
            ddl_Vendedor.DataValueField = "CodEmpleado";
            ddl_Vendedor.DataBind();

        }

    }
}