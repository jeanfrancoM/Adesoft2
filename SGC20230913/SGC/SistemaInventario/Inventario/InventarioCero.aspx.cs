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

namespace SistemaInventario.Inventario
{
    public partial class InventarioCero : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_GrabarDocumento_NET);
            CallbackManager.Register(F_Controles_Inicializar_NET);
        }

        private string _menu = "2000"; private string _opcion = "2";
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
            String str_ddl_serieconsulta_html = "";
            String str_ddl_sucursal_html = "";
            Int32 Usuario = 0;
            int int_resultado_operacion = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlAlmacen);

                str_ddl_sucursal_html = Mod_Utilitario.F_GetHtmlForControl(ddlAlmacen);

                Usuario = Convert.ToInt32(Session["CodUsuario"]);

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
                str_ddl_serieconsulta_html
                + "~" +
                Convert.ToString(Session["CodSede"])
                + "~" +
                str_ddl_sucursal_html;

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

        public void P_Controles_Inicializar(Hashtable objTablaFiltro,ref DropDownList combosucursal)
        {
            DataTable dta_consulta = null;

            TCAlmacenCE objEntidadAlmacen = null;
            TCAlmacenCN objOperacionAlmacen = null;

            objEntidadAlmacen = new TCAlmacenCE();

            objEntidadAlmacen.CodEmpresa = 3;
            objEntidadAlmacen.CodAlmacen = Convert.ToInt32(objTablaFiltro["Filtro_CodAlmacen"]);

            objOperacionAlmacen = new TCAlmacenCN();

            combosucursal.Items.Clear();

            dta_consulta = objOperacionAlmacen.F_TCAlmacen_Listar(objEntidadAlmacen);

            combosucursal.DataSource = dta_consulta;
            combosucursal.DataTextField = "DscAlmacen";
            combosucursal.DataValueField = "CodAlmacen";
            combosucursal.DataBind();
        }                

        public void P_GrabarDocumento(Hashtable objTablaFiltro, ref String MsgError)
        {
            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);
            objEntidad.CodAlmacen = Convert.ToInt32(objTablaFiltro["Filtro_CodAlmacen"]);
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
            objEntidad.Observacion = Convert.ToString(objTablaFiltro["Filtro_Observacion"]);

            objOperacion.F_MOVIMIENTOS_AJUSTE_CERO(objEntidad);

            MsgError = objEntidad.MsgError;
        }
    }
}