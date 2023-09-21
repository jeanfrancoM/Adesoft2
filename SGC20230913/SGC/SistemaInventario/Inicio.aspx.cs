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

namespace SistemaInventario
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_Buscar_NET);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //valido que una session no sea abierta
     
            Master.FindControl("NavigationMenu").Visible = false;
            Session["datos"] = true;
        }

        
        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddl_sucursal_html = "";
            int int_resultado_operacion = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlSucursal);                

                str_ddl_sucursal_html = Mod_Utilitario.F_GetHtmlForControl(ddlSucursal);

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
                str_ddl_sucursal_html;

            return str_resultado;

        }

        public String F_Buscar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Buscar(obj_parametros, ref str_mensaje_operacion);

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
               ;
            
            return str_resultado;
        }

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList combosucursal)
        {
            TCAlmacenCE objEntidad = null;
            TCAlmacenCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new TCAlmacenCE();

            objEntidad.CodEstado = 1;

            objOperacion = new TCAlmacenCN();

            combosucursal.Items.Clear();

            dta_consulta = objOperacion.F_TCALMACEN_LISTAR_TODOS(objEntidad);

            combosucursal.DataSource = dta_consulta;
            combosucursal.DataTextField = "DscAlmacen";
            combosucursal.DataValueField = "CodAlmacen";
            combosucursal.DataBind();
        }

        public void P_Buscar(Hashtable objTablaFiltro, ref String Mensaje)
        {
            UsuarioCE objEntidad = null;
            UsuarioCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new UsuarioCE();

            objEntidad.NombreUsuario = Convert.ToString(objTablaFiltro["Filtro_Usuario"]);
            objEntidad.Clave = Convert.ToString(objTablaFiltro["Filtro_Contraseña"]);
            objEntidad.CodAlmacen = Convert.ToInt32(objTablaFiltro["Filtro_CodSede"]);

            objOperacion = new UsuarioCN();

            dta_consulta = objOperacion.F_Usuario_Login(objEntidad);

            Mensaje = "Los Datos son incorrectos";

            if (dta_consulta.Rows.Count > 0)
            {
                Mensaje = "";
                Session["CodUsuario"] = dta_consulta.Rows[0][0].ToString();
                Session["CodEmpresa"] = dta_consulta.Rows[0]["CodEmpresa"].ToString();
                Session["IdAlmacen"] = dta_consulta.Rows[0]["IdAlmacen"].ToString();
                Session["Empresa"] = dta_consulta.Rows[0]["Empresa"].ToString();
                Session["CodSede"] = Convert.ToInt32(objTablaFiltro["Filtro_CodSede"]);
                Session["Almacen"] = Convert.ToString(objTablaFiltro["Filtro_Almacen"]);
                Session["Usuario"] = dta_consulta.Rows[0][1].ToString();
                Session["Apellidos"] = dta_consulta.Rows[0]["Apellidos"].ToString();
                Session["Nombre"] = dta_consulta.Rows[0]["Nombre"].ToString();
                Session["Perfil"] = dta_consulta.Rows[0][2].ToString();
                Session["CodEmpleado"] = dta_consulta.Rows[0]["CodEmpleado"].ToString();
                Session["CodCajaFisica"] = dta_consulta.Rows[0]["CodCajaFisica"].ToString();
                Session["CajaFisica"] = dta_consulta.Rows[0]["CajaFisica"].ToString();
                Session["FechaInicio"] = dta_consulta.Rows[0]["FechaInicio"].ToString();
                Session["NroRuc"] = dta_consulta.Rows[0]["NroRuc"].ToString();
                Session["NombreClaveAzure"] = dta_consulta.Rows[0]["NombreClaveAzure"].ToString();
                Session["ComisionTarjeta"] = dta_consulta.Rows[0]["ComisionTarjeta"].ToString();

                if (!Convert.IsDBNull(dta_consulta.Rows[0]["ImagenUsuario"]))
                {
                    Session["ImagenUsuario"] = dta_consulta.Rows[0]["ImagenUsuario"];
                    Utilitarios.Menu.ImagenUsuario = (byte[])dta_consulta.Rows[0]["ImagenUsuario"];
                    Utilitarios.Menu.ImagenUsuarioNombre = objEntidad.NombreUsuario + ".jpg";
                    Utilitarios.Menu.F_ImagenUsuario();
                }
                else {
                    Utilitarios.Menu.ImagenUsuario = null;
                    Utilitarios.Menu.ImagenUsuarioNombre = "../Asset/images/mainuser.png";
                }
                Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            }
        }
    }
}