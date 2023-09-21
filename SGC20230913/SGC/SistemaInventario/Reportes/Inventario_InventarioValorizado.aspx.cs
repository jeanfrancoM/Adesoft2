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
    public partial class Inventario_InventarioValorizado : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_Buscar_NET);
            CallbackManager.Register(F_Mostrar_Marcas_NET);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //P_Inicializar_GrillaVacia();
            Session["datos"] = true;
        }

        [WebMethod()]
        public static bool KeepActiveSession()
        {
            if (HttpContext.Current.Session["datos"] != null)
                return true;
            else
                return false;
        }

        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddlMarca_html = "";
            String str_grv_consultaarticulo_html = "";
            String str_ddlFamiliaConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                //P_Controles_Inicializar(obj_parametros, ref ddlFamilia, ref ddlMarca);
                //P_Buscar(obj_parametros, ref grvConsultaArticulo);
                //if (grvConsultaArticulo.Rows.Count == 0)
                    //P_Inicializar_GrillaVacia();

                Session["Excel"] = grvConsultaArticulo;
                str_grv_consultaarticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvConsultaArticulo);
                //str_ddlFamiliaConsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlFamilia);
                //str_ddlMarca_html = Mod_Utilitario.F_GetHtmlForControl(ddlMarca);
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
                str_ddlFamiliaConsulta_html
                + "~" +
                str_ddlMarca_html;

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
                //if (grvConsultaArticulo.Rows.Count == 0)
                    //P_Inicializar_GrillaVacia();
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

        public String F_Mostrar_Marcas_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddlmarcas_html = "";
            int int_resultado_operacion = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                //P_Mostrar_Marca(obj_parametros, ref ddlMarca);
                //str_ddlmarcas_html = Mod_Utilitario.F_GetHtmlForControl(ddlMarca);
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
                str_ddlmarcas_html;

            return str_resultado;
        }

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_combofamilia, ref DropDownList ddl_marca)
        {
            DataTable dta_consulta = null;

            LGFamiliasCN objOperacion = null;

            objOperacion = new LGFamiliasCN();

            dta_consulta = objOperacion.F_LGFamilias_Listar_Roman();

            ddl_combofamilia.Items.Clear();

            ddl_combofamilia.DataSource = dta_consulta;
            ddl_combofamilia.DataTextField = "DscFamilia";
            ddl_combofamilia.DataValueField = "CodFamilia";
            ddl_combofamilia.DataBind();
            ddl_combofamilia.Items.Insert(0, new ListItem("TODOS", "0"));

            //ddl_marca.Items.Clear();
            //ddl_marca.Items.Insert(0, new ListItem("TODOS", "0"));


            LGProductosCN ObjProductosOperaciones = new LGProductosCN();
            ddl_marca.Items.Clear();
            string codFamilia = "0";
            dta_consulta = ObjProductosOperaciones.F_Marcas_Listar_Roman(codFamilia);
            ddl_marca.DataSource = dta_consulta;
            ddl_marca.DataTextField = "Marca";
            ddl_marca.DataValueField = "Marca";
            ddl_marca.DataBind();
            ddl_marca.Items.Insert(0, new ListItem("TODOS", "0"));

        }

        public void P_Inicializar_GrillaVacia()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();

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
            dta_consultaarticulo.Columns.Add("Pais", typeof(string));
            dta_consultaarticulo.Columns.Add("Codigo2", typeof(string));
            dta_consultaarticulo.Columns.Add("Marca", typeof(string));

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

            //objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            //objEntidad.CodFamilia = Convert.ToString(objTablaFiltro["Filtro_CodFamilia"]);
            //objEntidad.Marca = Convert.ToString(objTablaFiltro["Filtro_Marca"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
            objEntidad.CodProcedencia = Convert.ToInt32(objTablaFiltro["Filtro_Procedencia"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);


            dynamic jArr2;

            //filtros de combos multiples
            objEntidad.xmlFamilias = "";
            jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_Familias"].ToString());
            foreach (dynamic item in jArr2)
            {
                objEntidad.xmlFamilias = objEntidad.xmlFamilias + "<D ";
                objEntidad.xmlFamilias = objEntidad.xmlFamilias + " IdFamilia = '" + item.IdFamilia + "'";
                objEntidad.xmlFamilias = objEntidad.xmlFamilias + " />";
            }
            objEntidad.xmlFamilias = "<R><XmlLC> " + objEntidad.xmlFamilias + "</XmlLC></R>";




            //filtros de combos multiples
            //LINEAS-----------------------------------------
            objEntidad.xmlLineas = "";
            jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_Lineas"].ToString());
            foreach (dynamic item in jArr2)
            {
                objEntidad.xmlLineas = objEntidad.xmlLineas + "<D ";
                objEntidad.xmlLineas = objEntidad.xmlLineas + " IdLinea = '" + item.IdLinea + "'";
                objEntidad.xmlLineas = objEntidad.xmlLineas + " />";
            }
            objEntidad.xmlLineas = "<R><XmlLC> " + objEntidad.xmlLineas + "</XmlLC></R>";





            objEntidad.xmlMarcas = "";
            dynamic jArr3 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_Marcas"].ToString());
            foreach (dynamic item in jArr3)
            {
                objEntidad.xmlMarcas = objEntidad.xmlMarcas + "<D ";
                objEntidad.xmlMarcas = objEntidad.xmlMarcas + " Marca = '" + item.Marca + "'";
                objEntidad.xmlMarcas = objEntidad.xmlMarcas + " />";
            }
            objEntidad.xmlMarcas = "<R><XmlLC> " + objEntidad.xmlMarcas + "</XmlLC></R>";

            //ALMACEN
            objEntidad.XmlAlmacen = "";
            jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_Almacenes"].ToString());
            foreach (dynamic item in jArr2)
            {
                objEntidad.XmlAlmacen = objEntidad.XmlAlmacen + "<D ";
                objEntidad.XmlAlmacen = objEntidad.XmlAlmacen + " CodAlmacen = '" + item.Almacen + "'";
                objEntidad.XmlAlmacen = objEntidad.XmlAlmacen + " DscAlmacen = '" + item.DscAlmacen + "'";
                objEntidad.XmlAlmacen = objEntidad.XmlAlmacen + " />";
            }
            objEntidad.XmlAlmacen = "<R><XmlLC> " + objEntidad.XmlAlmacen + "</XmlLC></R>";
            objEntidad.XmlAlmacen = "<?xml version=" + '\u0022' + "1.0" + '\u0022' + " encoding=" + '\u0022' + "iso-8859-1" + '\u0022' + "?>" + objEntidad.XmlAlmacen;
            objOperacion = new LGProductosCN();

            dta_consulta = objOperacion.F_Inventario_Valorizado(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();
        }

        public void P_Mostrar_Marca(Hashtable objTablaFiltro, ref DropDownList ddl_marca)
        {
            DataTable dta_consulta = null;
            LGProductosCN ObjProductosOperaciones = new LGProductosCN();
            ddl_marca.Items.Clear();
            string codFamilia = Convert.ToString(objTablaFiltro["Filtro_CodFamilia"]);
            dta_consulta = ObjProductosOperaciones.F_Marcas_Listar_Roman(codFamilia);
            ddl_marca.DataSource = dta_consulta;
            ddl_marca.DataTextField = "Marca";
            ddl_marca.DataValueField = "Marca";
            ddl_marca.DataBind();
            ddl_marca.Items.Insert(0, new ListItem("TODOS", "0"));
        }


    }
}