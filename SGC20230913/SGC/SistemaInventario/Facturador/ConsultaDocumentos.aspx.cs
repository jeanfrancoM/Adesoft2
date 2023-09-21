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

namespace SistemaInventario.Facturador
{
    public partial class ConsultaDocumentos : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_Buscar_NET);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["datos"] = true;
        }

        protected void grvConsulta_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView grvDetalle = null;
                Label lblID = null;
                Label lblRespuesta = null;
                HiddenField hfMensajeSunat = null;
                
                lblID = (Label)(e.Row.FindControl("lblID"));
                lblRespuesta = (Label)(e.Row.FindControl("lblRespuesta"));
                hfMensajeSunat = (HiddenField)(e.Row.FindControl("hfMensajeSunat"));

                if (lblID.Text != "")
                {
                    lblRespuesta.ToolTip = hfMensajeSunat.Value.ToString();
                }


            }
        }
        
        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddl_empresa_html = "";
           
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;


            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlEmpresa);

                str_ddl_empresa_html = Mod_Utilitario.F_GetHtmlForControl(ddlEmpresa);

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
                str_ddl_empresa_html ; //8


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
                    //P_Inicializar_GrillaVacia_Consulta();
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

        public void P_Controles_Inicializar(Hashtable objTablaFiltro,ref DropDownList ddlEmpresa)
        {

            DataTable dta_consulta = null;

            dta_consulta = (new FacturadorCN()).PA_INTERFACE_LISTAR_EMPRESAS();

            ddlEmpresa.Items.Clear();

            ddlEmpresa.DataSource = dta_consulta;
            ddlEmpresa.DataTextField = "Empresa";
            ddlEmpresa.DataValueField = "CodEmpresa";
            ddlEmpresa.DataBind();

        }

        public void P_Inicializar_GrillaVacia_Consulta()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();

            dta_consultaarticulo.Columns.Add("CodArchivoSunatXML", typeof(string));
            dta_consultaarticulo.Columns.Add("RucEmpresa", typeof(string));
            dta_consultaarticulo.Columns.Add("Total", typeof(string));
            dta_consultaarticulo.Columns.Add("CodDocumentoOrigen", typeof(string));
            dta_consultaarticulo.Columns.Add("FechaRegistro", typeof(string));
            dta_consultaarticulo.Columns.Add("ENVIO_NroTicket", typeof(string));
            dta_consultaarticulo.Columns.Add("Cliente", typeof(string));
            dta_consultaarticulo.Columns.Add("EstadoProceso", typeof(string));
            dta_consultaarticulo.Columns.Add("FechaEnvio", typeof(string));
            dta_consultaarticulo.Columns.Add("FechaRespuesta", typeof(string));
            dta_consultaarticulo.Columns.Add("TipoEnvio", typeof(string));
            dta_consultaarticulo.Columns.Add("Doc", typeof(string));
            dta_consultaarticulo.Columns.Add("Serie", typeof(string));
            dta_consultaarticulo.Columns.Add("Numero", typeof(string));
            dta_consultaarticulo.Columns.Add("FechaDocumento", typeof(string));
            dta_consultaarticulo.Columns.Add("ENVIO_NombreArchivo", typeof(string));
            dta_consultaarticulo.Columns.Add("MensajeSunat", typeof(string));
            dta_consultaarticulo.Columns.Add("NroDocumentoCliente", typeof(string));

            dtr_consultafila = dta_consultaarticulo.NewRow();

            dtr_consultafila[0] = "";

            dta_consultaarticulo.Rows.Add(dtr_consultafila);

            grvConsulta.DataSource = dta_consultaarticulo;
            grvConsulta.DataBind();
        }


        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {
            FacturadorCE objEntidad = null;
            FacturadorCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new FacturadorCE();

            objEntidad.CodEmpresa = Convert.ToInt32(objTablaFiltro["Filtro_CodEmpresa"]);
            objEntidad.Serie = Convert.ToString(objTablaFiltro["Filtro_Serie"]);
            objEntidad.Desde = Convert.ToInt32(Convert.ToDateTime(objTablaFiltro["Filtro_Desde"].ToString()).ToString("yyyyMMdd"));
            objEntidad.Hasta = Convert.ToInt32(Convert.ToDateTime(objTablaFiltro["Filtro_Hasta"].ToString()).ToString("yyyyMMdd"));
            objEntidad.CodTipoDocumento =objTablaFiltro["Filtro_CodTipoDocumento"].ToString();
            objEntidad.CodEstadoProcesoSunat = Convert.ToInt32(objTablaFiltro["CodEstadoProcesoSunat"]);

            objOperacion = new FacturadorCN();

            dta_consulta = objOperacion.PA_INTERFACE_LISTA_DOCUMENTOS(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();
        }

    
    }
}