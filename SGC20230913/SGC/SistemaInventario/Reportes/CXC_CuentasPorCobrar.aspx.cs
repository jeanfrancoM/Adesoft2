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
    public partial class CXC_CuentasPorCobrar : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {


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

    }
}