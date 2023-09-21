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
    public partial class VentasPorUnidades : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_Mostrar_Marcas_NET);
        }

        private string _menu = "10000"; private string _opcion = "200004";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"]; String Opcion = Request.QueryString["Op"];
            //if (Menu == null | (_menu != Menu | _opcion != Opcion) | Utilitarios.Menu.F_PermisoOpcion(_menu, _opcion) == false)
            //{
            //    Response.Redirect("../Maestros/TipoCambio.aspx");
            //    return;
            //}
            //Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
        }

        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddlTipoDocumento_html = "";
            String str_ddl_serie_html = "";
            int int_resultado_operacion = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlFamilia, ref ddlMarca);

                str_ddlTipoDocumento_html = Mod_Utilitario.F_GetHtmlForControl(ddlFamilia);
                str_ddl_serie_html = Mod_Utilitario.F_GetHtmlForControl(ddlMarca);

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
                str_ddl_serie_html;

            return str_resultado;
        }

        public String F_Mostrar_Marcas_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddlmarcas_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Mostrar_Marca(obj_parametros, ref ddlMarca);
                str_ddlmarcas_html = Mod_Utilitario.F_GetHtmlForControl(ddlMarca);
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
                str_ddlmarcas_html;

            return str_resultado;

        }

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_familias, ref DropDownList ddl_marca)
        {
            DataTable dta_consulta = null;

            dta_consulta = null;

            //llena familias
            LGFamiliasCN objFamiliasOperaciones = new LGFamiliasCN();
            LGFamiliasCE objFamilias = new LGFamiliasCE();
            ddl_familias.Items.Clear();
            dta_consulta = objFamiliasOperaciones.F_LGFamilias_Listar();
            ddl_familias.DataSource = dta_consulta;
            ddl_familias.DataTextField = "dscFamilia";
            ddl_familias.DataValueField = "CodFamilia";
            ddl_familias.DataBind();
            ddl_familias.Items.Insert(0, new ListItem("TODOS", "0"));

            //Marcas
            LGProductosCN ObjProductosOperaciones = new LGProductosCN();
            ddl_marca.Items.Clear();
            //dta_consulta = ObjProductosOperaciones.F_Marcas_Listar("0");
            //ddl_marca.DataSource = dta_consulta;
            //ddl_marca.DataTextField = "Marca";
            //ddl_marca.DataValueField = "Marca";
            //ddl_marca.DataBind();
            ddl_marca.Items.Insert(0, new ListItem("TODOS", "0"));

            




        }

        public void P_Mostrar_Marca(Hashtable objTablaFiltro, ref DropDownList ddl_marca)
        {
            DataTable dta_consulta = null;
            //Convert.ToInt32(objTablaFiltro["Filtro_CodDoc"])
            LGProductosCN ObjProductosOperaciones = new LGProductosCN();
            ddl_marca.Items.Clear();
            int idFamilia = Convert.ToInt32(objTablaFiltro["Filtro_CodFamilia"]);
            if (idFamilia != 0)
            {
            dta_consulta = ObjProductosOperaciones.F_Marcas_Listar(idFamilia);
            ddl_marca.DataSource = dta_consulta;
            ddl_marca.DataTextField = "Marca";
            ddl_marca.DataValueField = "Marca";
            ddl_marca.DataBind();
            }
            ddl_marca.Items.Insert(0, new ListItem("TODOS", "0"));
        }

    }
}