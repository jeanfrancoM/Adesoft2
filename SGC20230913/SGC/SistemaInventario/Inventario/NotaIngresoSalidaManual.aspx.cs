using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using CapaNegocios;
using CapaEntidad;
using SistemaInventario.Clases;
using EasyCallback;
using Newtonsoft.Json;
using System.Web.Services;
using System.Net;

namespace SistemaInventario.Inventario
{
    public partial class NotaIngresoSalidaManual : System.Web.UI.Page
    {
        private string _menu = ""; private string _opcion = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"];
            String Opcion = Request.QueryString["Op"];
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
        }

        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_Envio_NET);
        }

        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddl_moneda_html = "";
            int int_resultado_operacion = 0;
            String str_ddlVendedor_html = "";
            String str_ddl_Empresa_html = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlEmpresa);

                str_ddl_Empresa_html = Mod_Utilitario.F_GetHtmlForControl(ddlEmpresa);


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
                str_ddl_Empresa_html; //2

            return str_resultado;
        }

        public String F_Envio_NET(String arg)
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
                P_Envio(obj_parametros, ref MsgError);
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
                str_mensaje_operacion;


            return str_resultado;

        }

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddlEmpresa)
        {
            DataTable dta_consulta = null;

            int iCodEmpresa = Convert.ToInt32(Session["CodSede"]);

            TCAlmacenCE objEntidadAlmacen = null;
            TCAlmacenCN objOperacionAlmacen = null;

            objEntidadAlmacen = new TCAlmacenCE();

            objEntidadAlmacen.CodEmpresa = iCodEmpresa;
            objEntidadAlmacen.CodAlmacen = 0;

            objOperacionAlmacen = new TCAlmacenCN();

            ddlEmpresa.Items.Clear();

            dta_consulta = objOperacionAlmacen.F_Empresa_Destino(objEntidadAlmacen);

            ddlEmpresa.Items.Clear();

            ddlEmpresa.DataSource = dta_consulta;
            ddlEmpresa.DataTextField = "empresa";
            ddlEmpresa.DataValueField = "IdAlmacen";
            ddlEmpresa.DataBind();


            //ddlEmpresa.Items.Insert(0, new ListItem() { Text = "--TODOS--", Value = "0" });
        }

        public void P_Envio(Hashtable objTablaFiltro, ref String MsgError)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new DocumentoVentaCabCE();


            objEntidad.Desde = Convert.ToDateTime(objTablaFiltro["Filtro_Desde"]);
            objEntidad.CodEmpresa = Convert.ToInt32(objTablaFiltro["Filtro_Empresa"]);

            objOperacion = new DocumentoVentaCabCN();

            objOperacion.F_NotaIngreso_Manual(objEntidad);

            MsgError = objEntidad.MsgError;
        }
    }
}