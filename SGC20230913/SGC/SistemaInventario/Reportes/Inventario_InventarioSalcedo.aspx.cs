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
    public partial class Inventario_InventarioSalcedo : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);        
        }

        private string _menu = "10000"; private string _opcion = "100001";
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
            String str_ddlFamiliaConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Controles_Inicializar(obj_parametros, ref ddlFamiliaConsulta);
             
                str_ddlFamiliaConsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlFamiliaConsulta);

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
                str_ddlFamiliaConsulta_html;

            return str_resultado;
        }

       public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_combofamilia)
        {
            DataTable dta_consulta = null;

            LGFamiliasCN objOperacion = null;

            objOperacion = new LGFamiliasCN();

            dta_consulta = objOperacion.F_LGFamilias_Listar();

            ddl_combofamilia.Items.Clear();

            ddl_combofamilia.DataSource = dta_consulta;
            ddl_combofamilia.DataTextField = "DscFamilia";
            ddl_combofamilia.DataValueField = "IdFamilia";
            ddl_combofamilia.DataBind();
            ddl_combofamilia.Items.Insert(0, new ListItem("--Todos--", "0"));

        }

    }
}