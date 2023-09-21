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
    public partial class Inventario_InventarioAlvarado : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_Buscar_NET);
        }

        private string _menu = "10000"; private string _opcion = "100001";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"]; String Opcion = Request.QueryString["Op"];
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
            //P_Inicializar_GrillaVacia();
            Session["datos"] = true;
        }

        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";

            String str_grv_consultaarticulo_html = "";
            String str_ddlFamiliaConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Controles_Inicializar(obj_parametros, ref ddlFamiliaConsulta);
               // P_Buscar(obj_parametros, ref grvConsultaArticulo);
               // if (grvConsultaArticulo.Rows.Count == 0)
                //P_Inicializar_GrillaVacia();
                Session["Excel"] = grvConsultaArticulo;
                str_grv_consultaarticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvConsultaArticulo);
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
                str_grv_consultaarticulo_html
                + "~" +
                str_ddlFamiliaConsulta_html;

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
                P_Buscar(obj_parametros, ref grvConsultaArticulo);
                if (grvConsultaArticulo.Rows.Count == 0)
                    P_Inicializar_GrillaVacia();
                Session["Excel"] = grvConsultaArticulo;
                str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvConsultaArticulo);
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
                str_grvConsulta_html;


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

        public void P_Inicializar_GrillaVacia()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();

            dta_consultaarticulo.Columns.Add("ID", typeof(string));
            dta_consultaarticulo.Columns.Add("Marca", typeof(string));
            dta_consultaarticulo.Columns.Add("Medida", typeof(string));
            dta_consultaarticulo.Columns.Add("Modelo", typeof(string));
            dta_consultaarticulo.Columns.Add("Año", typeof(string));
            dta_consultaarticulo.Columns.Add("Posicion", typeof(string));
            dta_consultaarticulo.Columns.Add("CodigoProducto", typeof(string));
            dta_consultaarticulo.Columns.Add("DscProducto", typeof(string));
            dta_consultaarticulo.Columns.Add("Stock", typeof(string));
            dta_consultaarticulo.Columns.Add("UM", typeof(string));
            dta_consultaarticulo.Columns.Add("Costo", typeof(string));
            dta_consultaarticulo.Columns.Add("Moneda", typeof(string));
            dta_consultaarticulo.Columns.Add("P1", typeof(string));
            dta_consultaarticulo.Columns.Add("P2", typeof(string));
            dta_consultaarticulo.Columns.Add("P3", typeof(string));
            dta_consultaarticulo.Columns.Add("Familia", typeof(string));
            dta_consultaarticulo.Columns.Add("Codigo2", typeof(string));
            dta_consultaarticulo.Columns.Add("Inventario", typeof(string));

            dtr_consultafila = dta_consultaarticulo.NewRow();

            dtr_consultafila[0] = "";
            dtr_consultafila[1] = "";
            dtr_consultafila[2] = "";
            dtr_consultafila[3] = "";
            dtr_consultafila[4] = "";
            dtr_consultafila[5] = "";
            dtr_consultafila[6] = "";
            dtr_consultafila[7] = "";
            dtr_consultafila[8] = "";
            dtr_consultafila[9] = "";
            dtr_consultafila[10] = "";
            dtr_consultafila[11] = "";
            dtr_consultafila[12] = "";
            dtr_consultafila[13] = "";
            dtr_consultafila[14] = "";
            dtr_consultafila[15] = "";
            dtr_consultafila[16] = "";
            dtr_consultafila[17] = "";
        
            dta_consultaarticulo.Rows.Add(dtr_consultafila);

            grvConsultaArticulo.DataSource = dta_consultaarticulo;
            grvConsultaArticulo.DataBind();
        }

        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {
            LGProductosCE objEntidad = null;
            LGProductosCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new LGProductosCE();

            objEntidad.CodAlmacen =  Convert.ToInt32(Session["CodSede"]);
            objEntidad.IdFamilia =   Convert.ToInt32(objTablaFiltro["Filtro_IdFamilia"]);
            objEntidad.DscProducto = Convert.ToString(objTablaFiltro["Filtro_DscProducto"]);

            objOperacion = new LGProductosCN();

            dta_consulta = objOperacion.F_LGProductos_Inventario_StockActual(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();
        }
    }
}