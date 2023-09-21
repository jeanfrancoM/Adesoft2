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

namespace SistemaInventario.Planilla
{
    public partial class MaestroConceptos : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Buscar_NET);
        }

        private string _menu = "8000"; private string _opcion = "20";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"]; String Opcion = Request.QueryString["Op"];      
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
            P_Inicializar_GrillaVacia_Consulta();
            Session["datos"] = true;
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

        public void P_Inicializar_GrillaVacia_Consulta()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();

            dta_consultaarticulo.Columns.Add("CodConceptoRemuneracion", typeof(string));
            dta_consultaarticulo.Columns.Add("Descripcion", typeof(string));
            dta_consultaarticulo.Columns.Add("CodEstado", typeof(string));
            dta_consultaarticulo.Columns.Add("CodUsuario", typeof(string));
            dta_consultaarticulo.Columns.Add("Estado", typeof(string));
            dta_consultaarticulo.Columns.Add("RegimenLaboral", typeof(string));
            dta_consultaarticulo.Columns.Add("CodRegimenLaboral", typeof(string));
            dta_consultaarticulo.Columns.Add("Orden", typeof(string));
            dta_consultaarticulo.Columns.Add("CodTipo", typeof(string));
            dta_consultaarticulo.Columns.Add("Tipo", typeof(string));
            dta_consultaarticulo.Columns.Add("CodConceptoRemuneracion_Referencia", typeof(string));
            dta_consultaarticulo.Columns.Add("CodClasificacion", typeof(string));
            dta_consultaarticulo.Columns.Add("Clasificacion", typeof(string));
            dta_consultaarticulo.Columns.Add("CodNaturaleza", typeof(string));
            dta_consultaarticulo.Columns.Add("Naturaleza", typeof(string));
            dta_consultaarticulo.Columns.Add("Orden2", typeof(string));
                   
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

        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {
            Planilla_ConceptoRemuneracionCE objEntidad = null;
            Planilla_ConceptoRemuneracionCN objOperacion = null;

            DataTable dta_consulta = null;

            objOperacion = new Planilla_ConceptoRemuneracionCN();
            objEntidad = new Planilla_ConceptoRemuneracionCE();
            objEntidad.Descripcion = Convert.ToString(objTablaFiltro["Filtro_Descripcion"]);

            dta_consulta = objOperacion.F_Planilla_ConceptoRemuneracion_Listar(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();
        }

    }
}