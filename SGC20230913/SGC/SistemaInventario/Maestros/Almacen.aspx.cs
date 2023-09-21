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

namespace SistemaInventario.Maestros
{
    public partial class Almacen : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_GrabarDocumento_NET);
            CallbackManager.Register(F_Nuevo_NET);
            CallbackManager.Register(F_Buscar_NET);
            CallbackManager.Register(F_EliminarRegistro_Net);
            CallbackManager.Register(F_EdicionRegistro_NET);      
        }

        private string _menu = "1000"; private string _opcion = "7";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"]; String Opcion = Request.QueryString["Op"];
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
            P_Inicializar_GrillaVacia_Consulta();
            Session["datos"] = true;
        }

        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddlEstado_html = "";
            String str_ddlEstadoEdicion_html = "";
            int int_resultado_operacion = 0;
            String str_ddlEmpresa_html = "";
            String str_ddlEmpresaEdicion_html = "";
            String str_ddlEmpresaConsulta_html = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlEstado, ref ddlEstadoEdicion
                    , ref ddlEmpresa, ref ddlEmpresaEdicion, ref ddlEmpresaConsulta);

                str_ddlEstado_html = Mod_Utilitario.F_GetHtmlForControl(ddlEstado);
                str_ddlEstadoEdicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlEstadoEdicion);

                str_ddlEmpresa_html = Mod_Utilitario.F_GetHtmlForControl(ddlEmpresa);
                str_ddlEmpresaEdicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlEmpresaEdicion);
                str_ddlEmpresaConsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlEmpresaConsulta);

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
            str_ddlEstado_html + "~" + //2
            str_ddlEstadoEdicion_html + "~" + //3
            str_ddlEmpresa_html + "~" + //4
            str_ddlEmpresaEdicion_html + "~" + //5
            str_ddlEmpresaConsulta_html; //6

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

        public String F_Nuevo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvFactura_html = "";
            String str_grvLetra_html = "";
            int int_resultado_operacion = 0;


            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                //str_grvFactura_html = Mod_Utilitario.F_GetHtmlForControl(grvFactura);
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
                str_mensaje_operacion
                + "~" +
                str_grvLetra_html
                + "~" +
                str_grvFactura_html;


            return str_resultado;

        }

        public String F_Buscar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Buscar(obj_parametros, ref grvConsulta);
                if (grvConsulta.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_Consulta();
                    str_mensaje_operacion = "No se encontraron registros.";
                }
                else
                {
                    str_mensaje_operacion = "";
                }

                str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvConsulta);
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
                + "~" +
                str_grvConsulta_html;


            return str_resultado;

        }

        public String F_EliminarRegistro_Net(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EliminarRegistro(obj_parametros, ref str_mensaje_operacion);
                P_Buscar(obj_parametros, ref grvConsulta);
                if (grvConsulta.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Consulta();

                str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvConsulta);
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
                + "~" +
                str_grvConsulta_html;


            return str_resultado;

        }

        public String F_EdicionRegistro_NET(String arg)
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
                P_EditarRegistro(obj_parametros, ref MsgError);
                P_Buscar(obj_parametros, ref grvConsulta);
                if (grvConsulta.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Consulta();
                str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvConsulta);
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
                str_mensaje_operacion
                + "~" +
                str_grvConsulta_html;


            return str_resultado;

        }

        public void F_ActivarRegistroDireccion(Hashtable objTablaFiltro, ref String MsgError)
        {

            TCDistritoCN objOperacion = null;
            objOperacion = new TCDistritoCN();

            bool respuesta = objOperacion.F_TCDireccion_ActivarDesactivar(Convert.ToInt32(objTablaFiltro["Filtro_CodDireccion"]), Convert.ToInt32(objTablaFiltro["Filtro_NuevoEstado"]), out MsgError);
        }

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_comboestado, ref DropDownList ddl_comboestadoedicion,
                ref DropDownList ddl_comboempresa, ref DropDownList ddl_comboempresaedicion, ref DropDownList ddl_comboempresaconsulta)
        {
            DataTable dta_consulta = null;

            TCConceptosDetCE objEntidadConceptosDet = new TCConceptosDetCE();
            TCConceptosDetCN objOperacionConceptosDet = new TCConceptosDetCN();

            ddl_comboestado.Items.Clear();

            objEntidadConceptosDet.CodConcepto = 27;

            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);

            ddl_comboestado.Items.Clear();

            ddl_comboestado.DataSource = dta_consulta;
            ddl_comboestado.DataTextField = "DscAbvConcepto";
            ddl_comboestado.DataValueField = "CodConcepto";
            ddl_comboestado.DataBind();

            ddl_comboestadoedicion.Items.Clear();

            ddl_comboestadoedicion.DataSource = dta_consulta;
            ddl_comboestadoedicion.DataTextField = "DscAbvConcepto";
            ddl_comboestadoedicion.DataValueField = "CodConcepto";
            ddl_comboestadoedicion.DataBind();



            TCDocumentosCN objOperacionDocumento = new TCDocumentosCN();
            dta_consulta = objOperacionDocumento.F_TCEMPRESA_LISTAR_COMBO();

            ddl_comboempresa.Items.Clear();

            ddl_comboempresa.DataSource = dta_consulta;
            ddl_comboempresa.DataTextField = "T_NombreComercial";
            ddl_comboempresa.DataValueField = "CodEmpresa";
            ddl_comboempresa.DataBind();

            ddl_comboempresaedicion.Items.Clear();

            ddl_comboempresaedicion.DataSource = dta_consulta;
            ddl_comboempresaedicion.DataTextField = "T_NombreComercial";
            ddl_comboempresaedicion.DataValueField = "CodEmpresa";
            ddl_comboempresaedicion.DataBind();

            ddl_comboempresaconsulta.Items.Clear();

            ddl_comboempresaconsulta.DataSource = dta_consulta;
            ddl_comboempresaconsulta.DataTextField = "T_NombreComercial";
            ddl_comboempresaconsulta.DataValueField = "CodEmpresa";
            ddl_comboempresaconsulta.DataBind();
            ddl_comboempresaconsulta.Items.Insert(0, new ListItem("TODOS", "0"));
        }

        public void P_Inicializar_GrillaVacia_Consulta()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();

            dta_consultaarticulo.Columns.Add("CodAlmacen", typeof(string));
            dta_consultaarticulo.Columns.Add("IdAlmacen", typeof(string));
            dta_consultaarticulo.Columns.Add("DscAlmacen", typeof(string));
            dta_consultaarticulo.Columns.Add("Direccion", typeof(string));
            dta_consultaarticulo.Columns.Add("CodDepartamento", typeof(string));
            dta_consultaarticulo.Columns.Add("CodProvincia", typeof(string));
            dta_consultaarticulo.Columns.Add("CodDistrito", typeof(string));
            dta_consultaarticulo.Columns.Add("Estado", typeof(string));
            dta_consultaarticulo.Columns.Add("CodEstado", typeof(string));
            dta_consultaarticulo.Columns.Add("CodEmpresa", typeof(string));
            dta_consultaarticulo.Columns.Add("Empresa", typeof(string));
            dta_consultaarticulo.Columns.Add("Telefono", typeof(string));
            dta_consultaarticulo.Columns.Add("FlagPrincipal", typeof(string));
            dta_consultaarticulo.Columns.Add("Distrito", typeof(string));

            dtr_consultafila = dta_consultaarticulo.NewRow();

            dtr_consultafila[0] = "";
            dtr_consultafila[1] = "";
            dtr_consultafila[2] = "";
            dtr_consultafila[3] = "";
            dtr_consultafila[4] = "";

            dta_consultaarticulo.Rows.Add(dtr_consultafila);

            grvConsulta.DataSource = dta_consultaarticulo;
            grvConsulta.DataBind();
        }

        public void F_ElegirPrincipalDireccion(Hashtable objTablaFiltro, ref String MsgError)
        {

            TCDistritoCN objOperacion = null;
            objOperacion = new TCDistritoCN();

            bool respuesta = objOperacion.F_ElegirPrincipalDireccion(Convert.ToInt32(objTablaFiltro["Filtro_CodDireccion"]), out MsgError);
        }
        //joel 20/02/21 grabar
        public void P_GrabarDocumento(Hashtable objTablaFiltro, ref String MsgError)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.CodEmpresa = Convert.ToInt32(objTablaFiltro["Filtro_CodEmpresa"]);
            objEntidad.dscAlmacen = Convert.ToString(objTablaFiltro["Filtro_DscAlmacen"]);
            objEntidad.Direccion = Convert.ToString(objTablaFiltro["Filtro_Direccion"]);
            objEntidad.CodDepartamento = Convert.ToInt32(objTablaFiltro["Filtro_CodDepartamento"]);
            objEntidad.CodProvincia = Convert.ToInt32(objTablaFiltro["Filtro_CodProvincia"]);
            objEntidad.CodDistrito = Convert.ToInt32(objTablaFiltro["Filtro_CodDistrito"]);
            objEntidad.FlagPrincipal = Convert.ToInt32(objTablaFiltro["Filtro_FlagPrincipal"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            objEntidad.NroTelefono = Convert.ToString(objTablaFiltro["Filtro_Telefono"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_TCAlmacen_Insert(objEntidad);

            MsgError = objEntidad.MsgError;
        }
        //joel 20/02/21 buscar
        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            DataTable dta_consulta = null;

            objOperacion = new TCCuentaCorrienteCN();
            objEntidad = new TCCuentaCorrienteCE();
            objEntidad.dscAlmacen = Convert.ToString(objTablaFiltro["Filtro_DscAlmacen"]);

            dta_consulta = objOperacion.F_TCAlmacen_Listado(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();
        }

        public void P_EliminarRegistro(Hashtable objTablaFiltro, ref String Mensaje)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.CodAlmacen = Convert.ToInt32(objTablaFiltro["Filtro_CodAlmacen"]);

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_TCAlmacen_Delete(objEntidad);

            Mensaje = objEntidad.MsgError;
        }
        //joel 20/02/21 editar
        public void P_EditarRegistro(Hashtable objTablaFiltro, ref String MsgError)
        {
            TCCuentaCorrienteCE objEntidad = null;
            TCCuentaCorrienteCN objOperacion = null;

            objEntidad = new TCCuentaCorrienteCE();

            objEntidad.CodEmpresa =                 Convert.ToInt32(objTablaFiltro["Filtro_CodEmpresa"]);
            objEntidad.CodAlmacen =                 Convert.ToInt32(objTablaFiltro["Filtro_CodAlmacen"]);
            objEntidad.dscAlmacen =                 Convert.ToString(objTablaFiltro["Filtro_DscAlmacen"]);
            objEntidad.Direccion =                  Convert.ToString(objTablaFiltro["Filtro_Direccion"]);
            objEntidad.CodEstado =                  Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            objEntidad.NroTelefono =                Convert.ToString(objTablaFiltro["Filtro_Telefono"]);
            objEntidad.CodDepartamento =            Convert.ToInt32(objTablaFiltro["Filtro_CodDepartamento"]);
            objEntidad.CodProvincia =               Convert.ToInt32(objTablaFiltro["Filtro_CodProvincia"]);
            objEntidad.CodDistrito =                Convert.ToInt32(objTablaFiltro["Filtro_CodDistrito"]);
            objEntidad.FlagPrincipal =              Convert.ToInt32(objTablaFiltro["Filtro_FlagPrincipal"]);
            objEntidad.CodUsuario =                 Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new TCCuentaCorrienteCN();

            objOperacion.F_TCAlmacen_Update(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_BuscarDireccion(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {

            TCDistritoCE objEntidad = null;
            TCDistritoCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new TCDistritoCE();

            objEntidad.CodAlmacen = Convert.ToInt32(objTablaFiltro["Filtro_CodALmacen"]);

            objOperacion = new TCDistritoCN();

            dta_consulta = objOperacion.F_TCDireccion_ListarXCodCtaCte(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();

        }

       
    }
}