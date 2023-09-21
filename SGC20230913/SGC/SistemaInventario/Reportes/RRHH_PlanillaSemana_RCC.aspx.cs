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
    public partial class RRHH_PlanillaSemana_RCC : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {    
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
            String str_ddlRegimenLaboral_html = "";
            String str_ddlProyecto_html = "";
            int int_resultado_operacion = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlRegimenLaboral, ref ddlProyecto);

                str_ddlRegimenLaboral_html = Mod_Utilitario.F_GetHtmlForControl(ddlRegimenLaboral);
                str_ddlProyecto_html = Mod_Utilitario.F_GetHtmlForControl(ddlProyecto);

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
                str_ddlRegimenLaboral_html
                + "~" +
                str_ddlProyecto_html;

            return str_resultado;
        }

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_RegimenLaboral, ref DropDownList ddl_Proyecto)
        {
            
        }
      
    }
}