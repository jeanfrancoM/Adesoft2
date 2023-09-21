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
    public partial class MaestroCategoriaValores : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Buscar_NET);
            CallbackManager.Register(F_BuscarNoAsignados_NET);
            CallbackManager.Register(F_Planilla_Buscar_Nominas_Reintegros_NET);
        }

        private string _menu = "8000"; private string _opcion = "80";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"]; String Opcion = Request.QueryString["Op"];
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
            P_Inicializar_GrillaVacia_Consulta();
            P_Inicializar_GrillaVacia_Consulta_NoAsignados();
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

        public String F_BuscarNoAsignados_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_BuscarNoAsignados(obj_parametros, ref grvConceptosNoAsignados);
                if (grvConceptosNoAsignados.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_Consulta_NoAsignados();
                    str_mensaje_operacion = "No se encontraron registros.";
                }
                else
                {
                    str_mensaje_operacion = "";
                }

                str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvConceptosNoAsignados);
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


        public String F_Planilla_Buscar_Nominas_Reintegros_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            int int_resultado_operacion = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Planilla_Buscar_Nominas_Reintegros(obj_parametros, ref grvReintegros);
                str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvReintegros);

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
                str_grvDetalleArticulo_html;

            return str_resultado;
        }


        public void P_Inicializar_GrillaVacia_Consulta()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();

            dta_consultaarticulo.Columns.Add("CodCodCategoriaValores", typeof(string));
            dta_consultaarticulo.Columns.Add("CodCodCategoria", typeof(string));
            dta_consultaarticulo.Columns.Add("CodConceptoRemuneracion", typeof(string));
            dta_consultaarticulo.Columns.Add("CategoriaValores", typeof(string));
            dta_consultaarticulo.Columns.Add("Concepto", typeof(string));
            dta_consultaarticulo.Columns.Add("Valor", typeof(string));
            dta_consultaarticulo.Columns.Add("Observacion", typeof(string));
            dta_consultaarticulo.Columns.Add("Valor2", typeof(string));
            dta_consultaarticulo.Columns.Add("TopeDiferencia", typeof(string));
            dta_consultaarticulo.Columns.Add("Tipo", typeof(string));
            dta_consultaarticulo.Columns.Add("Clasificacion", typeof(string));
            dta_consultaarticulo.Columns.Add("FechaInicial", typeof(string));
            dta_consultaarticulo.Columns.Add("FechaFinal", typeof(string));

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

        public void P_Inicializar_GrillaVacia_Consulta_NoAsignados()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();

            dta_consultaarticulo.Columns.Add("CodConceptoRemuneracion", typeof(string));
            dta_consultaarticulo.Columns.Add("Concepto", typeof(string));
            dta_consultaarticulo.Columns.Add("Tipo", typeof(string));
            dta_consultaarticulo.Columns.Add("Clasificacion", typeof(string));


            dtr_consultafila = dta_consultaarticulo.NewRow();

            dtr_consultafila[0] = "";
            dtr_consultafila[1] = "";
            dtr_consultafila[2] = "";

            dta_consultaarticulo.Rows.Add(dtr_consultafila);

            grvConceptosNoAsignados.DataSource = dta_consultaarticulo;
            grvConceptosNoAsignados.DataBind();
        }

        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {
            Planilla_CategoriaValoresCE objEntidad = null;
            Planilla_CategoriaValoresCN objOperacion = null;

            DataTable dta_consulta = null;

            objOperacion = new Planilla_CategoriaValoresCN();
            objEntidad = new Planilla_CategoriaValoresCE();
            objEntidad.CodCodCategoria = Convert.ToInt32(objTablaFiltro["Filtro_CodCategoria"]);

            dta_consulta = objOperacion.F_Planilla_CategoriaValores_Listar(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();
        }

        public void P_BuscarNoAsignados(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {
            Planilla_CategoriaValoresCE objEntidad = null;
            Planilla_CategoriaValoresCN objOperacion = null;

            DataTable dta_consulta = null;

            objOperacion = new Planilla_CategoriaValoresCN();
            objEntidad = new Planilla_CategoriaValoresCE();
            objEntidad.CodCodCategoria = Convert.ToInt32(objTablaFiltro["Filtro_CodCategoria"]);

            dta_consulta = objOperacion.F_Planilla_Concepto_Categoria_Listar_SinAsignacion(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();
        }


        public void P_Planilla_Buscar_Nominas_Reintegros(Hashtable objTablaFiltro, ref GridView grvDetalle)
        {
            Planilla_CategoriaValoresCE objEntidad = null;
            Planilla_CategoriaValoresCN objOperacion = null;

            DataTable dta_consulta = null;

            objOperacion = new Planilla_CategoriaValoresCN();
            objEntidad = new Planilla_CategoriaValoresCE();
            objEntidad.CodCodCategoria = Convert.ToInt32(objTablaFiltro["Filtro_CodCategoria"]);
            objEntidad.flagTodos = Convert.ToInt32(objTablaFiltro["Filtro_flagTodos"]);

            dta_consulta = objOperacion.F_Planilla_Salario_Reintegros_Pendientes(objEntidad);

            grvDetalle.DataSource = dta_consulta;
            grvDetalle.DataBind();
        }


    }
}