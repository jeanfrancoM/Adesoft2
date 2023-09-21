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

namespace SistemaInventario.Inventario
{
    public partial class GuiaInternaCodigo : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Buscar_NET);
            CallbackManager.Register(F_GrabarDocumento_NET);
            CallbackManager.Register(F_Controles_Inicializar_NET);
        }

        private string _menu = "2000"; private string _opcion = "4";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"]; String Opcion = Request.QueryString["Op"];
            //if (Menu == null | (_menu != Menu | _opcion != Opcion) | Utilitarios.Menu.F_PermisoOpcion(_menu, _opcion) == false)
            //{
            //    Response.Redirect("../Maestros/TipoCambio.aspx");
            //    return;
            //}
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
            P_Inicializar_GrillaVacia_Consulta();
            Session["datos"] = true;
        }

        protected void grvConsulta_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TrasladosDetCN objOperacion = new TrasladosDetCN();
                TrasladosDetCE objEntidad = new TrasladosDetCE();
                GridView grvDetalle = null;
                Label lblCodigo = null;
                grvDetalle = (GridView)(e.Row.FindControl("grvDetalle"));
                lblCodigo = (Label)(e.Row.FindControl("lblcodigo"));
                if (lblCodigo.Text != "")
                {
                    objEntidad.CodTraslado = Convert.ToInt32(lblCodigo.Text);
                    grvDetalle.DataSource = objOperacion.F_TrasladosDet_Listar(objEntidad);
                    grvDetalle.DataBind();
                }

                //Convert.ToInt32(e.Row.Cells[1].Text);
            }
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

                P_Controles_Inicializar(obj_parametros, ref ddlSerieConsulta, ref ddlSucursal);

                str_ddl_serieconsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieConsulta);
                str_ddl_sucursal_html = Mod_Utilitario.F_GetHtmlForControl(ddlSucursal);

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
                    str_mensaje_operacion = "No se encontraron registros";
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
                
        public String F_GrabarDocumento_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            int int_resultado_operacion = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_GrabarDocumento(obj_parametros, ref MsgError);
            
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
                str_grvDetalleArticulo_html;
            
            return str_resultado;
        }

        public void P_Inicializar_GrillaVacia_Consulta()
        {
            DataTable dta_consulta = null;
            DataRow dtr_filaconsulta = null;

            dta_consulta = new DataTable();

            dta_consulta.Columns.Add("Codigo", typeof(string));
            dta_consulta.Columns.Add("Numero", typeof(string));
            dta_consulta.Columns.Add("Cliente", typeof(string));
            dta_consulta.Columns.Add("Emision", typeof(string));
            dta_consulta.Columns.Add("Estado", typeof(string));
            dta_consulta.Columns.Add("Destino", typeof(string));
            dta_consulta.Columns.Add("Operacion", typeof(string));

            dtr_filaconsulta = dta_consulta.NewRow();

            dtr_filaconsulta[0] = "";
            dtr_filaconsulta[1] = "";
            dtr_filaconsulta[2] = "";
            dtr_filaconsulta[3] = "";
            dtr_filaconsulta[4] = "";
            dtr_filaconsulta[5] = "";
            dtr_filaconsulta[6] = "";

            dta_consulta.Rows.Add(dtr_filaconsulta);

            grvConsulta.DataSource = dta_consulta;
            grvConsulta.DataBind();
        }

        public void P_CargarGrillaTemporal(Hashtable objTablaFiltro, Int32 Codigo, ref GridView grvDetalle)
        {

            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodSerializacionCab = Codigo;

            objOperacion = new DocumentoVentaCabCN();

            DataTable dta_consulta = null;

            dta_consulta = objOperacion.F_TemporalSerializacionCab_Listar(objEntidad);

            grvDetalle.DataSource = dta_consulta;
            grvDetalle.DataBind();
        }
        
        public void P_GrabarDocumento(Hashtable objTablaFiltro, ref String MsgError)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
            objEntidad.CodAlmacen = Convert.ToInt32((Session["CodSede"]));
            objEntidad.CodProducto = Convert.ToInt32(objTablaFiltro["Filtro_CodProducto"]);
            objEntidad.Cantidad = Convert.ToInt32(objTablaFiltro["Filtro_Cantidad"]);
            objEntidad.CodAlterno = Convert.ToString(objTablaFiltro["Filtro_CodAlterno"]);
            objEntidad.CodAlmacenDestino = Convert.ToInt32(objTablaFiltro["Filtro_CodAlmacenDestino"]);

            objOperacion = new DocumentoVentaCabCN();

            objOperacion.F_TrasladosCab_GuiaInterna_Producto_Insert(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {
            TrasladosCabCE objEntidad = null;
            TrasladosCabCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new TrasladosCabCE();

            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_Serie"]);
            objEntidad.CodDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.CodAlmacenPartida = Convert.ToInt32(Session["CodSede"]);
            if (Convert.ToInt32(objTablaFiltro["Filtro_ChkNumero"]) == 1)
                objEntidad.NumeroDoc = Convert.ToString(objTablaFiltro["Filtro_Numero"]);
            else
                objEntidad.NumeroDoc = "";

            if (Convert.ToInt32(objTablaFiltro["Filtro_ChkFecha"]) == 1)
            {
                objEntidad.Desde = Convert.ToDateTime(objTablaFiltro["Filtro_Desde"]);
                objEntidad.Hasta = Convert.ToDateTime(objTablaFiltro["Filtro_Hasta"]);
            }
            else
            {
                objEntidad.Desde = Convert.ToDateTime("01/01/1990");
                objEntidad.Hasta = Convert.ToDateTime("01/01/1990");
            }

            if (Convert.ToInt32(objTablaFiltro["Filtro_ChkCliente"]) == 1)
                objEntidad.CodCtaCte = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);
            else
                objEntidad.CodCtaCte = 0;

            objOperacion = new TrasladosCabCN();

            dta_consulta = objOperacion.F_TrasladosCab_Listar_GuiaInterna(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();
        }

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_comboguia, ref DropDownList combosucursal)
        {
            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;

            DataTable dta_consulta = null;

            int iCodEmpresa = 3;

            objEntidad = new TCCorrelativoCE();

            objEntidad.CodTipoDoc = 4;
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodEmpresa = iCodEmpresa;
            objEntidad.CodEstado = 1;

            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_comboguia.Items.Clear();

            ddl_comboguia.DataSource = dta_consulta;
            ddl_comboguia.DataTextField = "SerieDoc";
            ddl_comboguia.DataValueField = "CodSerie";
            ddl_comboguia.DataBind();

            TCAlmacenCE objEntidadAlmacen = null;
            TCAlmacenCN objOperacionAlmacen = null;

            objEntidadAlmacen = new TCAlmacenCE();

            objEntidadAlmacen.CodEmpresa = iCodEmpresa;
            objEntidadAlmacen.CodAlmacen = Convert.ToInt32(Session["CodSede"]);

            objOperacionAlmacen = new TCAlmacenCN();

            combosucursal.Items.Clear();

            dta_consulta = objOperacionAlmacen.F_TCAlmacen_Listar(objEntidadAlmacen);

            combosucursal.DataSource = dta_consulta;
            combosucursal.DataTextField = "DscAlmacen";
            combosucursal.DataValueField = "CodAlmacen";
            combosucursal.DataBind();
        }                
    }
}