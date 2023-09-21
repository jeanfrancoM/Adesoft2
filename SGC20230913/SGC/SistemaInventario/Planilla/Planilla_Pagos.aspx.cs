using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocios;
using EasyCallback;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using SistemaInventario.Clases;
using System.Web.Services;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using SistemaInventario.Clases;

namespace SistemaInventario.Planilla
{
    public partial class Planilla_Pagos : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            
            CallbackManager.Register(F_Buscar_NET);
            CallbackManager.Register(F_Buscar_NET2);
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"]; String Opcion = Request.QueryString["Op"];
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
            if (!IsPostBack)
            {
                P_Inicializar_GrillaVacia_ConsultaFactura();
                P_Inicializar_GrillaVacia_ConsultaFactura2();
            }
        }
        protected void grvConsulta_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //NotaIngresoSalidaDetCN objOperacion = new NotaIngresoSalidaDetCN();
                //NotaIngresoSalidaDetCE objEntidad = new NotaIngresoSalidaDetCE();
                //GridView grvDetalle = null;
                //HiddenField lblCodigo = null;
                //grvDetalle = (GridView)(e.Row.FindControl("grvDetalle"));
                //lblCodigo = (HiddenField)(e.Row.FindControl("hfCodigo"));
                //if (lblCodigo.Value.ToString() != "")
                //{
                //    DataTable dta_consultaarticulo = null;
                //    DataRow dtr_consultafila = null;
                //    dta_consultaarticulo = new DataTable();
                //
                //    dta_consultaarticulo.Columns.Add("ID", typeof(string));
                //    dta_consultaarticulo.Columns.Add("CodigoInterno", typeof(string));
                //    dta_consultaarticulo.Columns.Add("Producto", typeof(string));
                //    dta_consultaarticulo.Columns.Add("Cantidad", typeof(string));
                //    dta_consultaarticulo.Columns.Add("Costo", typeof(string));
                //    dta_consultaarticulo.Columns.Add("P1", typeof(string));
                //    dta_consultaarticulo.Columns.Add("P2", typeof(string));
                //    dta_consultaarticulo.Columns.Add("P3", typeof(string));
                //    dta_consultaarticulo.Columns.Add("CostoGO", typeof(string));
                //
                //    dtr_consultafila = dta_consultaarticulo.NewRow();
                //
                //    dtr_consultafila[0] = "";
                //    dta_consultaarticulo.Rows.Add(dtr_consultafila);
                //
                //    grvDetalle.DataSource = dta_consultaarticulo;
                //    grvDetalle.DataBind();
                //}
            }
        }
        protected void grvConsulta2_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //NotaIngresoSalidaDetCN objOperacion = new NotaIngresoSalidaDetCN();
                //NotaIngresoSalidaDetCE objEntidad = new NotaIngresoSalidaDetCE();
                //GridView grvDetalle = null;
                //HiddenField lblCodigo = null;
                //grvDetalle = (GridView)(e.Row.FindControl("grvDetalle"));
                //lblCodigo = (HiddenField)(e.Row.FindControl("hfCodigo"));
                //if (lblCodigo.Value.ToString() != "")
                //{
                //    DataTable dta_consultaarticulo = null;
                //    DataRow dtr_consultafila = null;
                //    dta_consultaarticulo = new DataTable();
                //
                //    dta_consultaarticulo.Columns.Add("ID", typeof(string));
                //    dta_consultaarticulo.Columns.Add("CodigoInterno", typeof(string));
                //    dta_consultaarticulo.Columns.Add("Producto", typeof(string));
                //    dta_consultaarticulo.Columns.Add("Cantidad", typeof(string));
                //    dta_consultaarticulo.Columns.Add("Costo", typeof(string));
                //    dta_consultaarticulo.Columns.Add("P1", typeof(string));
                //    dta_consultaarticulo.Columns.Add("P2", typeof(string));
                //    dta_consultaarticulo.Columns.Add("P3", typeof(string));
                //    dta_consultaarticulo.Columns.Add("CostoGO", typeof(string));
                //
                //    dtr_consultafila = dta_consultaarticulo.NewRow();
                //
                //    dtr_consultafila[0] = "";
                //    dta_consultaarticulo.Rows.Add(dtr_consultafila);
                //
                //    grvDetalle.DataSource = dta_consultaarticulo;
                //    grvDetalle.DataBind();
                //}
            }
        }
        public void P_Inicializar_GrillaVacia_ConsultaFactura()
        {
            DataTable dta_consulta = null;
            DataRow dtr_filaconsulta = null;

            dta_consulta = new DataTable();
            dta_consulta.Columns.Add("Fecha", typeof(string));
            dta_consulta.Columns.Add("CodPagoCab", typeof(string));
            dta_consulta.Columns.Add("CodSalarioCab", typeof(string));
            dta_consulta.Columns.Add("CodTrabajador", typeof(string));            
            dta_consulta.Columns.Add("CodRegimenLaboral", typeof(string));
            dta_consulta.Columns.Add("Descripcion", typeof(string));
            dta_consulta.Columns.Add("NombreCompleto", typeof(string));
            dta_consulta.Columns.Add("DscBanco", typeof(string));
            dta_consulta.Columns.Add("NumeroCuenta", typeof(string));
            dta_consulta.Columns.Add("CCI", typeof(string));
            dta_consulta.Columns.Add("PorPagar", typeof(string));
            dta_consulta.Columns.Add("Cancelado", typeof(string));
            dta_consulta.Columns.Add("MontoPago", typeof(string));
            dta_consulta.Columns.Add("Estado", typeof(string));
            dta_consulta.Columns.Add("CodEstado", typeof(string));
            dta_consulta.Columns.Add("CodProyecto", typeof(string));
            dta_consulta.Columns.Add("CodPeriodo", typeof(string));
            dta_consulta.Columns.Add("CodSemana", typeof(string));
            dta_consulta.Columns.Add("DNI", typeof(string));

            dtr_filaconsulta = dta_consulta.NewRow();

            dtr_filaconsulta[0] = "";
            dtr_filaconsulta[1] = "";
            dtr_filaconsulta[2] = "";
            dtr_filaconsulta[3] = "";
            dtr_filaconsulta[4] = "";
            dtr_filaconsulta[5] = "";
            dtr_filaconsulta[6] = "";
            dtr_filaconsulta[7] = "";
            dtr_filaconsulta[8] = "";
            dtr_filaconsulta[9] = "";
            dtr_filaconsulta[10] = "";
            dtr_filaconsulta[11] = "";
            dtr_filaconsulta[12] = "";
            dtr_filaconsulta[13] = "";
            dtr_filaconsulta[14] = "";
            dtr_filaconsulta[15] = "";
            dtr_filaconsulta[16] = ""; 
            dta_consulta.Rows.Add(dtr_filaconsulta);

            grvConsulta.DataSource = dta_consulta;
            grvConsulta.DataBind();
        }
        public void P_Inicializar_GrillaVacia_ConsultaFactura2()
        {
            DataTable dta_consulta = null;
            DataRow dtr_filaconsulta = null;

            dta_consulta = new DataTable();
            dta_consulta.Columns.Add("CodSalarioCab", typeof(string));
            dta_consulta.Columns.Add("CodPagoCab", typeof(string));
            dta_consulta.Columns.Add("CodPagoDet", typeof(string));
            dta_consulta.Columns.Add("FechaPago", typeof(string));
            dta_consulta.Columns.Add("Saldo", typeof(string));
            dta_consulta.Columns.Add("Total", typeof(string)); 
            dta_consulta.Columns.Add("CodTrabajador", typeof(string));
            dta_consulta.Columns.Add("CodRegimenLaboral", typeof(string));
            dta_consulta.Columns.Add("Descripcion", typeof(string));
            dta_consulta.Columns.Add("NombreCompleto", typeof(string));
            dta_consulta.Columns.Add("DscBanco", typeof(string));
            dta_consulta.Columns.Add("NumeroCuenta", typeof(string));
            dta_consulta.Columns.Add("CCI", typeof(string));
            dta_consulta.Columns.Add("Acuenta", typeof(string));                        
            dta_consulta.Columns.Add("Estado", typeof(string));                        
            dta_consulta.Columns.Add("CodPeriodo", typeof(string));
            dta_consulta.Columns.Add("CodSemana", typeof(string));
            dta_consulta.Columns.Add("Periodo", typeof(string));
            dta_consulta.Columns.Add("FechaPagoInt", typeof(string));
            dta_consulta.Columns.Add("DNI", typeof(string));
            dtr_filaconsulta = dta_consulta.NewRow();

            dtr_filaconsulta[0] = "";
            dtr_filaconsulta[1] = "";
            dtr_filaconsulta[2] = "";
            dtr_filaconsulta[3] = "";
            dtr_filaconsulta[4] = "";
            dtr_filaconsulta[5] = "";
            dtr_filaconsulta[6] = "";
            dtr_filaconsulta[7] = "";
            dtr_filaconsulta[8] = "";
            dtr_filaconsulta[9] = "";
            dtr_filaconsulta[10] = "";
            dtr_filaconsulta[11] = "";
            dtr_filaconsulta[12] = "";
            dtr_filaconsulta[13] = "";
            dtr_filaconsulta[14] = "";
            dtr_filaconsulta[15] = "";
            dtr_filaconsulta[16] = "";
            dtr_filaconsulta[17] = "";
            dta_consulta.Rows.Add(dtr_filaconsulta);

            grvConsulta2.DataSource = dta_consulta;
            grvConsulta2.DataBind();
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
                    P_Inicializar_GrillaVacia_ConsultaFactura();
                    str_mensaje_operacion = "No se encontro registros.";
                }
                else
                    str_mensaje_operacion = "";


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
        public String F_Buscar_NET2(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Buscar2(obj_parametros, ref grvConsulta2);
                if (grvConsulta2.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_ConsultaFactura2();
                    str_mensaje_operacion = "No se encontro registros.";
                }
                else
                    str_mensaje_operacion = "";


                str_grvConsulta_html = Mod_Utilitario.F_GetHtmlForControl(grvConsulta2);
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

        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {
            Planilla_PagoCabCE objEntidad = new Planilla_PagoCabCE();


            objEntidad.CodRegimenLaboral = Convert.ToInt32(objTablaFiltro["Filtro_CodRegimenLaboral"]);
            //objEntidad.CodCategoria = Convert.ToInt32(objTablaFiltro["Filtro_CodCategoria"]);            
            if (objEntidad.CodRegimenLaboral == 1)
            {
                objEntidad.CodSemana = Convert.ToInt32(objTablaFiltro["Filtro_CodSemanaPeriodo"]);
                //objEntidad.CodProyecto = Convert.ToInt32(objTablaFiltro["Filtro_CodProyecto"]);
            }
            else
            {
                objEntidad.CodPeriodo = Convert.ToInt32(objTablaFiltro["Filtro_CodSemanaPeriodo"]);           
            }
            

            if (Convert.ToInt32(objTablaFiltro["Filtro_ChkTrabajador"]) == 1)
                objEntidad.CodTrabajador = Convert.ToInt32(objTablaFiltro["Filtro_CodTrabajador"]);
            else
                objEntidad.CodTrabajador = 0;

            DataTable dtabla = (new Planilla_PagosCabCN()).F_Planilla_Salario_Listar(objEntidad);
            GrillaBuscar.DataSource = dtabla;           
            GrillaBuscar.DataBind();
        }
        public void P_Buscar2(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {
            Planilla_PagoCabCE objEntidad = new Planilla_PagoCabCE();


            objEntidad.CodRegimenLaboral = Convert.ToInt32(objTablaFiltro["Filtro_CodRegimenLaboral"]);
            //objEntidad.CodCategoria = Convert.ToInt32(objTablaFiltro["Filtro_CodCategoria"]);            
            if (objEntidad.CodRegimenLaboral == 1)
            {
                objEntidad.CodSemana = Convert.ToInt32(objTablaFiltro["Filtro_CodSemanaPeriodo"]);
                //objEntidad.CodProyecto = Convert.ToInt32(objTablaFiltro["Filtro_CodProyecto"]);
            }
            else
            {
                objEntidad.CodPeriodo = Convert.ToInt32(objTablaFiltro["Filtro_CodSemanaPeriodo"]);
            }


            if (Convert.ToInt32(objTablaFiltro["Filtro_ChkTrabajador"]) == 1)
            {
                objEntidad.CodTrabajador = Convert.ToInt32(objTablaFiltro["Filtro_CodTrabajador"]);
            }
            else
            {
                objEntidad.CodTrabajador = 0;
            }
             
            if (Convert.ToInt32(objTablaFiltro["Filtro_ChkFecha"]) == 1)
            {
                objEntidad.DesdeInt = Convert.ToInt32(Convert.ToDateTime(objTablaFiltro["Filtro_Desde"]).ToString("yyyyMMdd"));
                objEntidad.HastaInt = Convert.ToInt32(Convert.ToDateTime(objTablaFiltro["Filtro_Hasta"]).ToString("yyyyMMdd"));
            }
            else
            {
                objEntidad.DesdeInt = 0;
                objEntidad.HastaInt = 0;
            }
            DataTable dtabla = (new Planilla_PagosCabCN()).F_Planilla_Salario_ListarDet(objEntidad);
            GrillaBuscar.DataSource = dtabla;
            GrillaBuscar.DataBind();
        }
    }
}