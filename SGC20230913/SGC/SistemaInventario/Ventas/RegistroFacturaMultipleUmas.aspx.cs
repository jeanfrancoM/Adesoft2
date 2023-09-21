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
using System.Drawing;

namespace SistemaInventario.Ventas
{
    public partial class RegistroFacturaMultipleUmas : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_Mostrar_Correlativo_NET);
            CallbackManager.Register(F_Buscar_Productos_NET);
            CallbackManager.Register(F_AgregarTemporal_NET);
            CallbackManager.Register(F_EliminarTemporal_NET);
            CallbackManager.Register(F_GrabarDocumento_NET);
            CallbackManager.Register(F_Nuevo_NET);
            CallbackManager.Register(F_Buscar_NET);
            CallbackManager.Register(F_AnularRegistro_Net);
            CallbackManager.Register(F_CargarGrillaVaciaConsultaArticulo_NET);
            CallbackManager.Register(F_TipoCambio_NET);
            CallbackManager.Register(F_VerUltimoPrecio_NET);
            CallbackManager.Register(F_PrecioMoneda_NET);
            CallbackManager.Register(F_ActualizarPrecio_Net);
            CallbackManager.Register(F_EliminarRegistro_Net);
            CallbackManager.Register(F_FacturacionOC_NET);
            CallbackManager.Register(F_Devolucion_NET);
            CallbackManager.Register(F_ImprimirFacturaTicket_NET);
            CallbackManager.Register(F_ReenvioMail_NET);
            CallbackManager.Register(F_ActualizarDetalle_NET);
            CallbackManager.Register(F_FacturacionNV_NET);
            CallbackManager.Register(F_Inicializar_GrillaVacia_DetalleNV_NET);
            CallbackManager.Register(F_Observacion_NET);
            CallbackManager.Register(F_FacturacionCT_NET);
            CallbackManager.Register(F_Inicializar_GrillaVacia_DetalleCT_NET);
            CallbackManager.Register(F_ReemplazarFactura_NET);
            CallbackManager.Register(F_Series_Documentos_NET);
            CallbackManager.Register(F_DatosFactura_NET);
            CallbackManager.Register(F_EdicionFactura_NET);
            CallbackManager.Register(F_LlenarGridDetalle_NET);
            CallbackManager.Register(F_KardexDetalle_NET);
            CallbackManager.Register(F_FlagGratuito_Net);
            CallbackManager.Register(F_StockAlmacenes_NET);
        }

        private string _menu = "4000"; private string _opcion = "2";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"]; String Opcion = Request.QueryString["Op"];
            //if (Menu == null | (_menu != Menu | _opcion != Opcion) | Utilitarios.Menu.F_PermisoOpcion(_menu, _opcion) == false)
            //{
            //    Response.Redirect("../Maestros/TipoCambio.aspx");
            //    return;
            //}
            //Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));

            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));

            P_Inicializar_GrillaVacia_Articulo();
            P_Inicializar_GrillaVacia_Detalle();
            P_Inicializar_GrillaVacia_Consulta();
            P_Inicializar_GrillaVacia_DetalleOC();
            P_Inicializar_GrillaVacia_DetalleGuia();
            P_Inicializar_GrillaVacia_PrecioMoneda();
            P_Inicializar_GrillaVacia_DetalleNV();
            Session["datos"] = true;
        }

        protected void grvConsulta_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DocumentoVentaDetCN objOperacion = new DocumentoVentaDetCN();
                DocumentoVentaDetCE objEntidad = new DocumentoVentaDetCE();
                GridView grvDetalle = null;
                HiddenField lblCodigo = null;
                HiddenField hfCodTipoDoc = null;
                Label lblNumero = null;
                Label lblEstado = null;
                GridView grvDetalleObservacion = null;

                grvDetalle = (GridView)(e.Row.FindControl("grvDetalle"));
                lblCodigo = (HiddenField)(e.Row.FindControl("lblcodigo"));
                lblNumero = (Label)(e.Row.FindControl("lblnumero"));
                hfCodTipoDoc = (HiddenField)(e.Row.FindControl("hfCodTipoDoc"));
                lblEstado = (Label)(e.Row.FindControl("lblEstado"));
                grvDetalleObservacion = (GridView)(e.Row.FindControl("grvDetalleObservacion"));

                ImageButton Eliminar = (ImageButton)(e.Row.FindControl("imgEliminarDocumento"));
                ImageButton Anular = (ImageButton)(e.Row.FindControl("imgAnularDocumento"));
                ImageButton Ticket = (ImageButton)(e.Row.FindControl("imgTCK"));
                ImageButton Imprimir = (ImageButton)(e.Row.FindControl("imgPdf"));
                ImageButton Pdf = (ImageButton)(e.Row.FindControl("imgPdf2"));
                ImageButton Mail = (ImageButton)(e.Row.FindControl("imgMail"));
                ImageButton Reemplazar = (ImageButton)(e.Row.FindControl("imgReemplazar"));
                try
                {

                    switch (lblEstado.Text)
                    {
                        case "PENDIENTE":
                            lblEstado.ForeColor = System.Drawing.Color.Red;
                            break;
                        case "CANCELADO":
                            lblEstado.ForeColor = System.Drawing.Color.Green;
                            break;
                    }

                    switch (Convert.ToString(hfCodTipoDoc.Value))
                    {
                        case "1":
                            Eliminar.Visible = true;
                            Anular.Visible = true;
                            Ticket.Visible = true;
                            Imprimir.Visible = true;
                            Pdf.Visible = true;
                            Mail.Visible = true;
                            Reemplazar.Visible = false;
                            break;
                        case "2":
                            Eliminar.Visible = true;
                            Anular.Visible = true;
                            Ticket.Visible = true;
                            Imprimir.Visible = true;
                            Pdf.Visible = true;
                            Mail.Visible = true;
                            Reemplazar.Visible = false;
                            break;
                        case "15":
                            Eliminar.Visible = false;
                            Anular.Visible = false;
                            Ticket.Visible = false;
                            Imprimir.Visible = true;
                            Pdf.Visible = true;
                            Mail.Visible = false;
                            Reemplazar.Visible = false;
                            break;
                    }
                }
                catch (Exception exx) { }

                try
                {
                    if (lblNumero.Text == "F" | lblNumero.Text == "B")
                    {
                        Eliminar.Visible = false;
                        Anular.Visible = true;
                    }
                    else
                    {
                        Eliminar.Visible = true;
                        Anular.Visible = true;
                    }
                }
                catch (Exception exxx)
                { }


                if (lblCodigo.Value != "")
                {
                    //YA NO SE CONSULTA EN LA BASE DE DATOS Y SE LLENA EN BLANCO

                    DataTable dta_consultaarticulo = null;
                    DataRow dtr_consultafila = null;
                    dta_consultaarticulo = new DataTable();

                    dta_consultaarticulo.Columns.Add("ID", typeof(string));
                    dta_consultaarticulo.Columns.Add("Codigo", typeof(string));
                    dta_consultaarticulo.Columns.Add("Descripcion", typeof(string));
                    dta_consultaarticulo.Columns.Add("Cantidad", typeof(string));
                    dta_consultaarticulo.Columns.Add("UM", typeof(string));
                    dta_consultaarticulo.Columns.Add("Precio", typeof(string));
                    dta_consultaarticulo.Columns.Add("Importe", typeof(string));
                    dta_consultaarticulo.Columns.Add("OV", typeof(string));
                    dta_consultaarticulo.Columns.Add("Costo", typeof(string));
                    dta_consultaarticulo.Columns.Add("Anexo2", typeof(string));

                    dtr_consultafila = dta_consultaarticulo.NewRow();

                    dtr_consultafila[0] = "";
                    dta_consultaarticulo.Rows.Add(dtr_consultafila);

                    grvDetalle.DataSource = dta_consultaarticulo;
                    grvDetalle.DataBind();

                    //observacion

                    dta_consultaarticulo = null;
                    dtr_consultafila = null;
                    dta_consultaarticulo = new DataTable();

                    dta_consultaarticulo.Columns.Add("ObservacionesCliente", typeof(string));

                    dtr_consultafila = dta_consultaarticulo.NewRow();

                    dtr_consultafila[0] = "";
                    dta_consultaarticulo.Rows.Add(dtr_consultafila);

                    grvDetalleObservacion.DataSource = dta_consultaarticulo;
                    grvDetalleObservacion.DataBind();
                }

                //Convert.ToInt32(e.Row.Cells[1].Text);
            }
        }

        /// <summary>
        /// Nuevo Procedimiento para consultar detalles
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public String F_LlenarGridDetalle_NET(String arg)
        {
            int int_resultado_operacion = 0;
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String grvNombre = "";
            String str_grv_Detalle_html = "";
            int Col = 0;
            int Codigo = 0;
            int CodTipoDoc = 0;

            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                //Necesarios para que busque el sistema
                grvNombre = Convert.ToString(obj_parametros["Filtro_grvNombre"]);
                Col = Convert.ToInt32(obj_parametros["Filtro_Col"]);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_Codigo"]);
                CodTipoDoc = Convert.ToInt32(obj_parametros["Filtro_CodTipoDoc"]);

                //Obtengo el Grid para llenarlo y dibujarlo
                GridView grvDetalle = (GridView)grvConsulta.Rows[0].FindControl("grvDetalle");

                //Consulta
                DocumentoVentaDetCN objOperacion = new DocumentoVentaDetCN();
                DocumentoVentaDetCE objEntidad = new DocumentoVentaDetCE();

                //consulta a la base de datos y se llena grid
                objEntidad.CodDocumentoVenta = Codigo; objEntidad.CodTipoDoc = CodTipoDoc;
                grvDetalle.DataSource = objOperacion.F_DocumentoVentaDet_Listar(objEntidad);
                grvDetalle.DataBind();

                //se crea el html a partir del grid llenado
                str_grv_Detalle_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalle);

            }
            catch (Exception exxx)
            {
                str_resultado = "ERROR AL BUSCAR DETALLE: " + exxx;
                int_resultado_operacion = 1;
            }


            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" +
                str_mensaje_operacion + "~" +
                str_grv_Detalle_html + "~" +
                grvNombre;

            return str_resultado;
        }

        protected void grvConsultaArticulo_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField hfPrecio1 = null;
                    HiddenField hfPrecio2 = null;
                    HiddenField hfPrecio3 = null;
                    DropDownList ddlPrecio = null;

                    hfPrecio1 = (HiddenField)(e.Row.FindControl("lblPrecio1"));
                    hfPrecio2 = (HiddenField)(e.Row.FindControl("lblPrecio2"));
                    hfPrecio3 = (HiddenField)(e.Row.FindControl("lblPrecio3"));
                    ddlPrecio = (DropDownList)(e.Row.FindControl("ddlPrecio"));

                    ddlPrecio.DataSource = new List<string>() { hfPrecio1.Value.ToString(), hfPrecio2.Value.ToString(), hfPrecio3.Value.ToString() };
                    ddlPrecio.DataBind();
                    ddlPrecio.Enabled = false;

                    GridView grvDetalle = null;
                    HiddenField lblCodigo = null;

                    grvDetalle = (GridView)(e.Row.FindControl("grvDetalleKardex"));
                    lblCodigo = (HiddenField)(e.Row.FindControl("lblcodproducto"));

                    if (lblCodigo.Value != "")
                    {
                        DataTable dta_consultaarticulo = null;
                        DataRow dtr_consultafila = null;
                        dta_consultaarticulo = new DataTable();

                        dta_consultaarticulo.Columns.Add("Fecha", typeof(string));
                        dta_consultaarticulo.Columns.Add("Ruc", typeof(string));
                        dta_consultaarticulo.Columns.Add("RazonSocial", typeof(string));
                        dta_consultaarticulo.Columns.Add("Numero", typeof(string));
                        dta_consultaarticulo.Columns.Add("Cantidad", typeof(string));
                        dta_consultaarticulo.Columns.Add("Precio", typeof(string));
                        dta_consultaarticulo.Columns.Add("Moneda", typeof(string));

                        dtr_consultafila = dta_consultaarticulo.NewRow();

                        dtr_consultafila[0] = "";
                        dta_consultaarticulo.Rows.Add(dtr_consultafila);

                        grvDetalle.DataSource = dta_consultaarticulo;
                        grvDetalle.DataBind();
                    }
                }
            }
            catch (Exception exx) { }
        }

        protected void grvDetalleArticulo_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField hfFlagGratuito = null;
                    Label lblGratuito = null;

                    hfFlagGratuito = (HiddenField)(e.Row.FindControl("hfFlagGratuito"));
                    lblGratuito = (Label)(e.Row.FindControl("lblGratuito"));

                    try
                    {
                        if (hfFlagGratuito.Value == "1")
                        {
                            lblGratuito.ForeColor = Color.White;
                            lblGratuito.BackColor = Color.Red;

                        }
                    }
                    catch (Exception exx) { }

                }
            }
            catch (Exception exx) { }
        }

        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddl_serie_html = "";
            String str_ddl_serieguia_html = "";
            String str_ddl_serieguia_edicion_html = "";
            String str_ddl_moneda_html = "";
            String str_ddl_formapago_html = "";
            String str_ddl_formapago_edicion_html = "";
            String str_ddl_serieconsulta_html = "";
            String str_ddl_igv_html = "";
            String str_ddl_tipodoc_html = "";
            String str_ddl_tipodoc2_html = "";
            String str_ddlSerieNV_html = "";
            String str_ddlSerieCT_html = "";
            String str_numerofactura = "";
            String str_direccion = "";
            String str_ddlEstado_html = "";
            Int32 Usuario = 0;
            Int32 CantidadPlacas = 0;
            String str_ddlEmpleado_html = "";
            decimal TC = 0;
            int int_resultado_operacion = 0;
            String str_grvConsuArticulo_html = "";
            String str_ddlEmpleadoConsulta_html = "";
            String str_ddlVendedorEdicion_html = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlSerie, ref ddlSerieConsulta, ref ddlSerieGuia, ref ddlFormaPago, ref ddlMoneda, ref ddlIgv, ref str_direccion,
                                        ref ddlTipoDoc, ref ddlTipoDoc2, ref CantidadPlacas, ref ddlSerieNV, ref ddlSerieCT, ref ddlEstado, ref ddlFormaPagoEdicion, ref ddlSerieGuiaEdicion,
                                        ref ddlVendedor, ref ddlEmpleadoConsulta, ref ddlVendedorEdicion);
                P_Obtener_TipoCambio(obj_parametros, ref TC);
                P_Obtener_NumeroCorrelativo(obj_parametros, ref str_numerofactura);
                P_Inicializar_GrillaVacia_Articulo();

                str_ddl_serie_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerie);
                str_ddl_serieconsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieConsulta);
                str_ddl_serieguia_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieGuia);
                str_ddl_serieguia_edicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieGuiaEdicion);
                str_ddl_formapago_html = Mod_Utilitario.F_GetHtmlForControl(ddlFormaPago);
                str_ddl_formapago_edicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlFormaPagoEdicion);
                str_ddl_moneda_html = Mod_Utilitario.F_GetHtmlForControl(ddlMoneda);
                str_ddl_igv_html = Mod_Utilitario.F_GetHtmlForControl(ddlIgv);
                str_ddl_tipodoc_html = Mod_Utilitario.F_GetHtmlForControl(ddlTipoDoc);
                str_ddl_tipodoc2_html = Mod_Utilitario.F_GetHtmlForControl(ddlTipoDoc2);
                str_ddlSerieNV_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieNV);
                str_ddlSerieCT_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieCT);
                str_ddlEstado_html = Mod_Utilitario.F_GetHtmlForControl(ddlEstado);
                str_ddlEmpleado_html = Mod_Utilitario.F_GetHtmlForControl(ddlVendedor);
                str_grvConsuArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvConsultaArticulo);
                str_ddlEmpleadoConsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlEmpleadoConsulta);
                str_ddlVendedorEdicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlVendedorEdicion);
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
                Convert.ToString(int_resultado_operacion) + "~" + //0
                str_mensaje_operacion + "~" + //1
                str_ddl_serie_html + "~" + //2
                str_ddl_serieguia_html + "~" + //3
                str_ddl_formapago_html + "~" + //4
                str_ddl_moneda_html + "~" + //5
                TC.ToString() + "~" + //6
                str_numerofactura + "~" + //7
                str_ddl_igv_html + "~" + //8
                str_ddl_serieconsulta_html + "~" + //9
                Usuario.ToString() + "~" + //10
                str_direccion + "~" + //11
                Session["CodSede"].ToString() + "~" + //12
                str_ddl_tipodoc_html + "~" + //13
                str_ddl_tipodoc2_html + "~" + //14
                CantidadPlacas.ToString() + "~" + //15
                str_ddlSerieNV_html + "~" + //16
                str_ddlSerieCT_html + "~" + //17
                str_ddlEstado_html + "~" + //18
                str_ddl_formapago_edicion_html + "~" + //19
                str_ddl_serieguia_edicion_html + "~" + //20
                Session["CodEmpleado"].ToString() + "~" + //21
                str_ddlEmpleado_html + "~" + //22
                str_grvConsuArticulo_html + "~" + //23
                str_ddlEmpleadoConsulta_html + "~" + //24
                str_ddlVendedorEdicion_html; //25

            return str_resultado;
        }

        public String F_Series_Documentos_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_ddl_serie_html = "";
            String str_ddl_serieconsulta_html = "";
            String str_ddl_serieguia_html = "";
            String str_ddlSerieNV_html = "";
            String str_ddlSerieCT_html = "";

            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Series_Documentos(obj_parametros, ref ddlSerie, ref ddlSerieConsulta, ref ddlSerieGuia, ref ddlSerieNV, ref ddlSerieCT);

                str_ddl_serie_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerie);
                str_ddl_serieconsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieConsulta);
                str_ddl_serieguia_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieGuia);
                str_ddlSerieNV_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieNV);
                str_ddlSerieCT_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieCT);

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
                str_ddl_serie_html
                 + "~" +
                str_ddl_serieguia_html
                + "~" +
                str_ddl_serieconsulta_html
                + "~" +
                str_ddlSerieNV_html
                + "~" +
                str_ddlSerieCT_html;

            return str_resultado;
        }

        public String F_Mostrar_Correlativo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_numero = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);


                P_Obtener_NumeroCorrelativo(obj_parametros, ref str_numero);

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
                str_numero;


            return str_resultado;

        }

        public String F_Buscar_Productos_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsultaArticulo_html = "";
            int int_resultado_operacion = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Cargar_Grilla(obj_parametros, ref grvConsultaArticulo);
                if (grvConsultaArticulo.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_Articulo();
                    str_mensaje_operacion = "No se encontraron registros.";
                }
                else
                    str_mensaje_operacion = "";

                str_grvConsultaArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvConsultaArticulo);
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
                str_grvConsultaArticulo_html;

            return str_resultado;
        }

        public String F_AgregarTemporal_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            Decimal Total = 0;
            Decimal SubTotal = 0;
            Decimal Igv = 0;
            Decimal Acuenta = 0;
            String MsgError = "";
            Int32 NotaPedido = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_AgregarTemporal(obj_parametros, ref Codigo, ref MsgError);
                P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref Acuenta, ref NotaPedido);
                str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);

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
                MsgError
                + "~" +
                Codigo.ToString()
                + "~" +
                str_grvDetalleArticulo_html
                 + "~" +
                Math.Round(Total, 2).ToString()
                + "~" +
                Math.Round(Igv, 2).ToString()
                 + "~" +
                Math.Round(SubTotal, 2).ToString()
                 + "~" +
                Math.Round(Acuenta, 2).ToString()
                + "~" +
                Convert.ToInt32(NotaPedido);

            return str_resultado;
        }

        public String F_EliminarTemporal_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            Decimal Total = 0;
            Decimal SubTotal = 0;
            Decimal Igv = 0;
            Decimal Acuenta = 0;
            String MsgError = "";
            Int32 NotaPedido = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EliminarTemporal(obj_parametros, ref MsgError);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_CodigoTemporal"]);
                P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref Acuenta, ref NotaPedido);
                if (grvDetalleArticulo.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Detalle();
                str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);

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
                MsgError
                + "~" +
                Codigo.ToString()
                + "~" +
                str_grvDetalleArticulo_html
                 + "~" +
               Math.Round(Total, 2).ToString()
                + "~" +
                Math.Round(Igv, 2).ToString()
                 + "~" +
                Math.Round(SubTotal, 2).ToString()
                 + "~" +
                Math.Round(Acuenta, 2).ToString()
                + "~" +
                Convert.ToInt32(NotaPedido);

            return str_resultado;

        }

        public String F_ActualizarDetalle_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            Decimal Total = 0;
            Decimal SubTotal = 0;
            Decimal Igv = 0;
            Decimal Dscto = 0;
            String MsgError = "";
            Int32 NotaPedido = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_ActualizarDetalle(obj_parametros, ref str_mensaje_operacion);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_CodDocumentoVenta"]);
                P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref Dscto, ref NotaPedido);
                if (grvDetalleArticulo.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Detalle(); //P_Inicializar_GrillaVacia_DetalleArticulo();
                str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);

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
                MsgError
                + "~" +
                Codigo.ToString()
                + "~" +
                str_grvDetalleArticulo_html
                 + "~" +
               Math.Round(Total, 2).ToString()
                + "~" +
                Math.Round(Igv, 2).ToString()
                 + "~" +
                Math.Round(SubTotal, 2).ToString()
                 + "~" +
                Math.Round(Dscto, 2).ToString()
                + "~" +
                Convert.ToInt32(NotaPedido);

            return str_resultado;

        }

        public String F_GrabarDocumento_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_numerofactura = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_GrabarDocumento(obj_parametros, ref str_mensaje_operacion, ref Codigo);

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
                Codigo.ToString()
                + "~" +
                str_numerofactura;


            return str_resultado;

        }

        public String F_Nuevo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_numerofactura = "";
            String str_grvDetalleArticulo_html = "";
            String str_numeroguia = "";

            int int_resultado_operacion = 1;

            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_Obtener_NumeroCorrelativo(obj_parametros, ref str_numerofactura);
                //P_Obtener_Correlativo(obj_parametros, ref str_numeroguia);
                P_LlenarGrillaVacia_Detalle();
                str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);
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
                str_grvDetalleArticulo_html
                + "~" +
                str_numerofactura
                + "~" +
                str_numeroguia;


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

        public String F_AnularRegistro_Net(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsulta_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_AnularRegistro(obj_parametros, ref str_mensaje_operacion);
                P_Buscar(obj_parametros, ref grvConsulta);
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

        public String F_CargarGrillaVaciaConsultaArticulo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvConsuArticulo_html = "";
            int int_resultado_operacion = 0;

            try
            {
                P_Inicializar_GrillaVacia_Articulo();
                str_grvConsuArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvConsultaArticulo);
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
                str_grvConsuArticulo_html;


            return str_resultado;

        }

        public String F_TipoCambio_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            Decimal TipoCambio = 0;
            int int_resultado_operacion = 0;


            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_TipoCambio(obj_parametros, ref TipoCambio);
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
                TipoCambio.ToString();


            return str_resultado;

        }

        public String F_VerUltimoPrecio_NET(String arg)
        {
            String str_resultado = "";
            String str_grvConsultaUltimosPrecios = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                //Agutierrez: se hizo la modificacion, debido a que ahora se mostrar un top y no el ultimo precio
                //P_VerUltimoPrecio(obj_parametros, ref Precio, ref Moneda, ref Fecha, ref Cantidad);
                P_VerUltimoPrecio(obj_parametros, ref grvConsultaUltimosPrecios);
                if (grvConsultaUltimosPrecios.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_UltimoPrecio();
                }
                else
                {
                    int_resultado_operacion = 1;
                    str_mensaje_operacion = MsgError;
                }
            }
            catch (Exception ex)
            {
                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;
            }

            str_grvConsultaUltimosPrecios = Mod_Utilitario.F_GetHtmlForControl(grvConsultaUltimosPrecios);

            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" +
                str_mensaje_operacion + "~" +
                str_grvConsultaUltimosPrecios;

            return str_resultado;
        }

        public String F_ActualizarPrecio_Net(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            Decimal Total = 0;
            Decimal SubTotal = 0;
            Decimal Igv = 0;
            Decimal Acuenta = 0;
            String MsgError = "";
            Int32 NotaPedido = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_ActualizarPrecios(obj_parametros, ref MsgError);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_CodigoTemporal"]);
                P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref Acuenta, ref NotaPedido);
                if (grvDetalleArticulo.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Detalle();
                str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);

                int_resultado_operacion = 1;

                if (MsgError != "")
                {
                    int_resultado_operacion = 0;
                    str_mensaje_operacion = MsgError;
                }

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
                MsgError
                + "~" +
                Codigo.ToString()
                + "~" +
                str_grvDetalleArticulo_html
                 + "~" +
               Math.Round(Total, 2).ToString()
                + "~" +
                Math.Round(Igv, 2).ToString()
                 + "~" +
                Math.Round(SubTotal, 2).ToString()
                      + "~" +
                Math.Round(Acuenta, 2).ToString()
                + "~" +
                Convert.ToInt32(NotaPedido);

            return str_resultado;

        }

        public String F_PrecioMoneda_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvPrecioMoneda_html = "";

            int int_resultado_operacion = 0;

            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_PrecioMoneda(obj_parametros, ref grvPrecioMoneda);
                if (grvPrecioMoneda.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_PrecioMoneda();

                str_grvPrecioMoneda_html = Mod_Utilitario.F_GetHtmlForControl(grvPrecioMoneda);
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
                str_grvPrecioMoneda_html;


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

        public String F_FacturacionOC_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            String str_grvDetalleOC_html = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_FacturacionOC(obj_parametros, ref grvDetalleOC);

                if (grvDetalleOC.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_DetalleOC();
                    str_mensaje_operacion = "No se encontraron registros.";
                }
                else
                    str_mensaje_operacion = "";

                str_grvDetalleOC_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleOC);

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
                str_grvDetalleOC_html;

            return str_resultado;

        }

        public String F_Devolucion_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleOC_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Devolucion(obj_parametros, ref str_mensaje_operacion);
                P_FacturacionOC(obj_parametros, ref grvDetalleOC);

                if (grvDetalleOC.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_DetalleOC();
                    str_mensaje_operacion = "No se encontraron registros.";
                }



                str_grvDetalleOC_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleOC);

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
                str_grvDetalleOC_html;

            return str_resultado;

        }

        public String F_FacturacionNV_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            String str_grvDetalleNV_html = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_FacturacionNV(obj_parametros, ref grvDetalleNV);

                if (grvDetalleNV.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_DetalleNV();
                    str_mensaje_operacion = "No se encontraron registros.";
                }
                else
                    str_mensaje_operacion = "";

                str_grvDetalleNV_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleNV);
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
                str_grvDetalleNV_html;

            return str_resultado;
        }

        public string F_Inicializar_GrillaVacia_DetalleNV_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 1;
            String str_grvDetalleNV_html = "";
            Hashtable obj_parametros = null;

            try
            {
                //obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                //P_FacturacionNV(obj_parametros, ref grvDetalleNV);

                //if (grvDetalleNV.Rows.Count == 0)
                //{
                P_Inicializar_GrillaVacia_DetalleNV();
                //    str_mensaje_operacion = "No se encontraron registros.";
                //}
                //else
                //    str_mensaje_operacion = "";

                str_grvDetalleNV_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleNV);
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
                str_grvDetalleNV_html;

            return str_resultado;
        }

        public String F_FacturacionCT_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            String str_grvDetalleCT_html = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_FacturacionCT(obj_parametros, ref grvDetalleCT);

                if (grvDetalleCT.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_DetalleCT();
                    str_mensaje_operacion = "No se encontraron registros.";
                }
                else
                    str_mensaje_operacion = "";

                str_grvDetalleCT_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleCT);
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
                str_grvDetalleCT_html;

            return str_resultado;
        }

        public string F_Inicializar_GrillaVacia_DetalleCT_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 1;
            String str_grvDetalleCT_html = "";
            Hashtable obj_parametros = null;

            try
            {
                //obj_parametros = SistemaICTentario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                //P_FacturacionCT(obj_parametros, ref grvDetalleCT);

                //if (grvDetalleCT.Rows.Count == 0)
                //{
                P_Inicializar_GrillaVacia_DetalleCT();
                //    str_mensaje_operacion = "No se encontraron registros.";
                //}
                //else
                //    str_mensaje_operacion = "";

                str_grvDetalleCT_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleCT);
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
                str_grvDetalleCT_html;

            return str_resultado;
        }

        public String F_ReemplazarFactura_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            String NroRuc = "";
            String Direccion = "";
            String Distrito = "";
            String Cliente = "";
            String FechaTraslado = "";
            String Transportista = "";
            String Placa = "";
            String NroLicencia = "";
            String NumGuia = "";
            String Destino = "";
            String SerieDoc = "";
            String NumeroDoc = "";
            String FechaEmision = "";
            String FechaVencimiento = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            int CodCliente = 0;
            int CodMoneda = 0;
            int CodDepartamento = 0;
            int CodProvincia = 0;
            int CodDistrito = 0;
            int CodFormaPago = 0;
            int CodFacturaAnterior = 0;
            int CodTransportista = 0;
            int CodVendedor = 0;
            int NotaPedido = 0;
            Decimal Total = 0;
            Decimal SubTotal = 0;
            Decimal Igv = 0;
            Decimal AcuentaNV = 0;

            String MarcaVehiculo = "";
            String DireccionTrans = "";
            String NroBultos = "";
            String Peso = "";
            String PlacaVehiculo = "";

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_ValidarFactura(obj_parametros, ref str_mensaje_operacion);

                if (str_mensaje_operacion == "")
                {
                    P_ReemplazarFactura(obj_parametros, ref NroRuc, ref Codigo, ref CodCliente, ref CodMoneda, ref CodDepartamento,
                    ref CodProvincia, ref CodDistrito, ref Direccion, ref Distrito, ref Cliente, ref CodFormaPago, ref CodFacturaAnterior,
                    ref CodTransportista, ref Transportista, ref Placa, ref NroLicencia, ref NumGuia, ref Destino, ref FechaTraslado,
                    ref NumeroDoc, ref CodVendedor, ref FechaEmision, ref FechaVencimiento, ref SerieDoc,
                    ref MarcaVehiculo, ref DireccionTrans, ref NroBultos, ref Peso, ref PlacaVehiculo);

                    //P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref AcuentaNV, ref NotaPedido);
                    P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref AcuentaNV);

                    str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);
                    int_resultado_operacion = 1;
                }
                else
                    int_resultado_operacion = 0;
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
                Codigo.ToString()
                + "~" +
                str_grvDetalleArticulo_html
                 + "~" +
                Math.Round(Total, 2).ToString()
                + "~" +
                Math.Round(Igv, 2).ToString()
                 + "~" +
                Math.Round(SubTotal, 2).ToString()
                 + "~" +
                Math.Round(AcuentaNV, 2).ToString()
                + "~" +
                NroRuc
                + "~" +
                Cliente
                + "~" +
                CodMoneda.ToString()
                + "~" +
                Distrito
                + "~" +
                Direccion
                + "~" +
                CodFormaPago.ToString()
                + "~" +
                CodCliente.ToString()
                + "~" +
                CodDepartamento.ToString()
                + "~" +
                CodProvincia.ToString()
                + "~" +
                CodDistrito.ToString()
                + "~" +
                CodFacturaAnterior.ToString()
                + "~" +
                CodTransportista.ToString()
                 + "~" +
                Transportista
                + "~" +
                Placa
                + "~" +
                NroLicencia
                + "~" +
                NumGuia
                + "~" +
                Destino
                + "~" +
                FechaTraslado
                + "~" +
                NumeroDoc
                + "~" +
                CodVendedor.ToString()
                + "~" +
                FechaEmision
                + "~" +
                FechaVencimiento
                + "~" +
                SerieDoc
                + "~" +
                MarcaVehiculo
                + "~" +
                DireccionTrans
                + "~" +
                NroBultos
                + "~" +
                Peso
                + "~" +
                PlacaVehiculo;

            return str_resultado;
        }

        public String F_DatosFactura_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String Emision = "";
            String Vencimiento = "";
            Int32 FormaPago = 0;
            String Placa1 = "";
            String Placa2 = "";
            String Placa3 = "";
            String Placa4 = "";
            String KM = "";
            Int32 CodTraslado = 0;
            String SerieGuia = "";
            String NumeroGuia = "";
            String Fecha = "";
            String Destino = "";
            String DireccionTrans = "";
            String DireccionFactura = "";
            Int32 CodTransportista = 0;
            Int32 CodDireccionTransportista = 0;
            String Transportista = "";
            String OrdenCompra = "";
            String Recepcion = "";
            Int32 FlagComisionable = 0;
            Int32 CodEmpresa = 0;
            Int32 FlagKM = 0;
            Int32 FlagPlaca = 0;
            Int32 FlagOC = 0;
            int int_resultado_operacion = 0;
            String str_ddlSerieGuiaEdicion_html = "";
            String observacionCliente = "";
            String MsgError = "";
            Int32 CodCtaCte = 0;

            String DistritoTrans = "";
            String Placa = "";
            String Marca = "";
            String Licencia = "";
            Int32 Peso = 0;
            String NroConductor = "";
            String Conductor = "";
            Int32 CodConductor = 0;
            String NombreAgencia = "";
            String ClaveAgencia = "";
            String GuiaAgencia = "";
            Int32 Motorizado = 0;
            Int32 Bulto = 0;
            Int32 CodVendedor = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_DatosFactura(obj_parametros, ref Emision, ref Vencimiento, ref FormaPago, ref Placa1, ref Placa2, ref Placa3, ref Placa4,
                                               ref CodTraslado, ref SerieGuia, ref NumeroGuia, ref Fecha, ref Destino, ref DireccionTrans,
                                               ref CodTransportista, ref Transportista, ref DireccionFactura, ref CodDireccionTransportista,
                                               ref KM, ref OrdenCompra, ref Recepcion, ref FlagComisionable, ref CodEmpresa,
                                               ref FlagOC, ref FlagPlaca, ref FlagKM, ref observacionCliente, ref CodCtaCte, ref CodVendedor, 
                                               ref DistritoTrans, ref Placa, ref Marca, ref Licencia, ref Bulto, ref Peso, ref NroConductor,
                                               ref Conductor, ref CodConductor, ref NombreAgencia, ref GuiaAgencia, ref ClaveAgencia, ref Motorizado);

                P_Series_Guia(obj_parametros, ref  ddlSerieGuiaEdicion);

                str_ddlSerieGuiaEdicion_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieGuiaEdicion);

                int_resultado_operacion = 1;
                str_mensaje_operacion = MsgError;
            }
            catch (Exception ex)
            {
                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" + //0
                str_mensaje_operacion + "~" + //1 
                Emision + "~" + //2
                Vencimiento + "~" + //3
                FormaPago.ToString() + "~" + //4
                Placa1 + "~" + //5
                Placa2 + "~" + //6
                Placa3 + "~" + //7
                Placa4 + "~" + //8               
                CodTraslado + "~" + //9
                SerieGuia + "~" + //10
                NumeroGuia + "~" + //11
                Fecha + "~" + //12
                Destino + "~" + //13
                DireccionTrans + "~" + //14
                CodTransportista + "~" + //15
                Transportista + "~" + //16
                DireccionFactura + "~" + //17
                CodDireccionTransportista + "~" + //18
                KM + "~" +  //19
                OrdenCompra + "~" + //20
                Recepcion + "~" + //21
                FlagComisionable.ToString() + "~" + //22
                str_ddlSerieGuiaEdicion_html + "~" + //23
                CodEmpresa + "~" +//24
                FlagOC + "~" + //25
                FlagPlaca + "~" + //26
                FlagKM + "~" +//27
                observacionCliente + "~" +//28
                CodCtaCte.ToString() + "~" +  //29
               
               CodVendedor.ToString() + "~" +  //30
               DistritoTrans + "~" +  //31
               Placa + "~" +  //32
               Marca + "~" +  //33
               Licencia + "~" +  //34
               Bulto.ToString() + "~" +  //35
               Peso.ToString() + "~" +  //36
               NroConductor + "~" +  //37
               Conductor + "~" +  //38
               CodConductor.ToString() + "~" +  //39
               NombreAgencia + "~" +  //40
               GuiaAgencia + "~" +  //41
               ClaveAgencia + "~" +  //42
               Motorizado.ToString(); //43

            return str_resultado;
        }

        public String F_EdicionFactura_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            Hashtable obj_parametros = null;
            String MsgError = "";

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EdicionFactura(obj_parametros, ref MsgError);

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
                str_mensaje_operacion;

            return str_resultado;

        }

        public String F_KardexDetalle_NET(String arg)
        {
            int int_resultado_operacion = 0;
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String grvNombre = "";
            String str_grv_Detalle_html = "";
            int Col = 0;
            int Codigo = 0;
            int CodTipoDoc = 0;
            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                //Necesarios para que busque el sistema
                grvNombre = Convert.ToString(obj_parametros["Filtro_grvNombre"]);
                Col = Convert.ToInt32(obj_parametros["Filtro_Col"]);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_Codigo"]);
                CodTipoDoc = Convert.ToInt32(obj_parametros["Filtro_CodTipoDoc"]);

                //Obtengo el Grid para llenarlo y dibujarlo
                GridView grvDetalle = (GridView)grvConsultaArticulo.Rows[0].FindControl("grvDetalleKardex");

                //Consulta
                DocumentoVentaDetCN objOperacion = new DocumentoVentaDetCN();
                DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();

                //consulta a la base de datos y se llena grid
                objEntidad.Desde = Convert.ToDateTime(obj_parametros["Filtro_Desde"]);
                objEntidad.Hasta = Convert.ToDateTime(obj_parametros["Filtro_Hasta"]);
                objEntidad.CodProducto = Convert.ToInt32(obj_parametros["Filtro_CodProducto"]);
                objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
                objEntidad.CodCliente = Convert.ToInt32(obj_parametros["Filtro_CodCtaCte"]);
                objEntidad.CodTipoOperacion = Convert.ToInt32(obj_parametros["Filtro_CodTipoOperacion"]);

                grvDetalle.DataSource = objOperacion.F_DOCUMENTOVENTACAB_KARDEX(objEntidad);
                grvDetalle.DataBind();

                //se crea el html a partir del grid llenado
                str_grv_Detalle_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalle);
            }
            catch (Exception exxx)
            {
                str_resultado = "ERROR AL BUSCAR DETALLE: " + exxx;
                int_resultado_operacion = 1;
            }
            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" +
                str_mensaje_operacion + "~" +
                str_grv_Detalle_html + "~" +
                grvNombre;

            return str_resultado;
        }
        
        public String F_FlagGratuito_Net(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvDetalleArticulo_html = "";
            int int_resultado_operacion = 0;
            int Codigo = 0;
            Decimal Total = 0;
            Decimal SubTotal = 0;
            Decimal Igv = 0;
            Decimal Acuenta = 0;
            String MsgError = "";
            Int32 NotaPedido = 0;
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_FlagGratuito(obj_parametros, ref MsgError);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_CodigoTemporal"]);
                P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvDetalleArticulo, ref SubTotal, ref Igv, ref Total, ref Acuenta, ref NotaPedido);
                if (grvDetalleArticulo.Rows.Count == 0)
                    P_Inicializar_GrillaVacia_Detalle();
                str_grvDetalleArticulo_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalleArticulo);

                int_resultado_operacion = 1;

                if (MsgError != "")
                {
                    int_resultado_operacion = 0;
                    str_mensaje_operacion = MsgError;
                }

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
                MsgError
                + "~" +
                Codigo.ToString()
                + "~" +
                str_grvDetalleArticulo_html
                 + "~" +
               Math.Round(Total, 2).ToString()
                + "~" +
                Math.Round(Igv, 2).ToString()
                 + "~" +
                Math.Round(SubTotal, 2).ToString()
                      + "~" +
                Math.Round(Acuenta, 2).ToString()
                + "~" +
                Convert.ToInt32(NotaPedido);

            return str_resultado;

        }
        
        public String F_StockAlmacenes_NET(String arg)
        {
            int int_resultado_operacion = 0;
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String grvNombre = "";
            String str_grv_Detalle_html = "";
            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                grvNombre = Convert.ToString(obj_parametros["Filtro_grvNombre"]);
                GridView grvDetalle = (GridView)grvConsultaArticulo.Rows[0].FindControl("grvDetalleKardex");

                DocumentoVentaDetCN objOperacion = new DocumentoVentaDetCN();
                DocumentoVentaDetCE objEntidad = new DocumentoVentaDetCE();

                objEntidad.CodProducto = Convert.ToInt32(obj_parametros["Filtro_CodProducto"]);
                objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);

                grvDetalle.DataSource = objOperacion.F_LGPRODUCTOS_STOCKDETALLE(objEntidad);
                grvDetalle.DataBind();

                str_grv_Detalle_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalle);
            }
            catch (Exception exxx)
            {
                str_resultado = "ERROR AL BUSCAR DETALLE: " + exxx;
                int_resultado_operacion = 1;
            }
            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" +
                str_mensaje_operacion + "~" +
                str_grv_Detalle_html + "~" +
                grvNombre;

            return str_resultado;
        }

        public String F_Observacion_NET(String arg)
        {
            int int_resultado_operacion = 0;
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String grvNombre = "";
            String str_grv_Detalle_html = "";
            int Col = 0;
            int Codigo = 0;
            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                grvNombre = Convert.ToString(obj_parametros["Filtro_grvNombre"]);
                Col = Convert.ToInt32(obj_parametros["Filtro_Col"]);
                Codigo = Convert.ToInt32(obj_parametros["Filtro_Codigo"]);

                GridView grvDetalle = (GridView)grvConsulta.Rows[0].FindControl("grvDetalleObservacion");

                DocumentoVentaDetCN objOperacion = new DocumentoVentaDetCN();
                DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();

                objEntidad.CodDocumentoVenta = Codigo;
                grvDetalle.DataSource = objOperacion.F_DOCUMENTOVENTACAB_OBSERVACIONCLEVER(objEntidad);
                grvDetalle.DataBind();

                str_grv_Detalle_html = Mod_Utilitario.F_GetHtmlForControl(grvDetalle);
            }
            catch (Exception exxx)
            {
                str_resultado = "ERROR AL BUSCAR DETALLE: " + exxx;
                int_resultado_operacion = 1;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" +
                str_mensaje_operacion + "~" +
                str_grv_Detalle_html + "~" +
                grvNombre;

            return str_resultado;
        }

        public void P_CargarGrillaTemporal(Hashtable objTablaFiltro, Int32 Codigo, ref GridView grvDetalle,
                                          ref Decimal SubTotalFactura, ref Decimal IgvFactura, ref Decimal TotalFactura, ref Decimal Acuenta)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();
            objOperacion = new DocumentoVentaCabCN();

            DataTable dta_consulta = null;

            objEntidad.Igv = Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]);
            objEntidad.CodDocumentoVenta = Codigo;

            dta_consulta = objOperacion.F_TemporalFacturacionDet_Listar(objEntidad);

            if (dta_consulta.Rows.Count > 0)
            {
                if (Convert.ToInt32(objTablaFiltro["Filtro_NotaPedido"]) == 1)
                {
                    for (int j = 0; j < dta_consulta.Rows.Count; j++)
                    {
                        if (Convert.ToDecimal(dta_consulta.Rows[j]["CodTipoProducto"]) == 1)
                            TotalFactura += Convert.ToDecimal(dta_consulta.Rows[j]["Importe"]);
                    }
                }
                else
                {
                    for (int j = 0; j < dta_consulta.Rows.Count; j++)
                    {
                        TotalFactura += Convert.ToDecimal(dta_consulta.Rows[j]["Importe"]);
                        Acuenta += Convert.ToDecimal(dta_consulta.Rows[j]["Acuenta"]);
                    }
                }

                SubTotalFactura = TotalFactura / Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]);
                IgvFactura = SubTotalFactura * (Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]) - 1);
            }
            grvDetalle.DataSource = dta_consulta;
            grvDetalle.DataBind();
        }

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_combofactura, ref DropDownList ddl_combofacturaconsulta,
            ref DropDownList ddl_comboguia, ref DropDownList ddl_comboformapago, ref DropDownList ddl_combomoneda, ref DropDownList ddl_comboigv,
            ref String Direccion, ref DropDownList ddl_tipodoc, ref DropDownList ddl_tipodoc2, ref Int32 CantidadPlacas, ref DropDownList ddl_comboserienv,
            ref DropDownList ddl_comboseriect, ref DropDownList ddl_comboestado, ref DropDownList ddl_comboformapagoedicion, ref DropDownList ddl_comboguiaedicion,
            ref DropDownList ddl_empleado, ref DropDownList ddl_empleadoconsulta, ref DropDownList ddl_VendedorEdicion)
        {
            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;

            DataTable dta_consulta = null;
            
            int iCodEmpresa = 3;

            objEntidad = new TCCorrelativoCE();

            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodDoc"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodEmpresa = iCodEmpresa;
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);

            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_combofactura.Items.Clear();

            ddl_combofactura.DataSource = dta_consulta;
            ddl_combofactura.DataTextField = "SerieDoc";
            ddl_combofactura.DataValueField = "CodSerie";
            ddl_combofactura.DataBind();

            objEntidad.CodEstado = 0;

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_combofacturaconsulta.Items.Clear();

            ddl_combofacturaconsulta.DataSource = dta_consulta;
            ddl_combofacturaconsulta.DataTextField = "SerieDoc";
            ddl_combofacturaconsulta.DataValueField = "CodSerie";
            ddl_combofacturaconsulta.DataBind();


            dta_consulta = null;
            objEntidad.CodTipoDoc = 10;
            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_comboguia.Items.Clear();

            ddl_comboguia.DataSource = dta_consulta;
            ddl_comboguia.DataTextField = "SerieDoc";
            ddl_comboguia.DataValueField = "CodSerie";
            ddl_comboguia.DataBind();

            ddl_comboguiaedicion.Items.Clear();

            ddl_comboguiaedicion.DataSource = dta_consulta;
            ddl_comboguiaedicion.DataTextField = "SerieDoc";
            ddl_comboguiaedicion.DataValueField = "CodSerie";
            ddl_comboguiaedicion.DataBind();


            TCConceptosDetCE objEntidadConceptosDet = new TCConceptosDetCE();

            objEntidadConceptosDet.CodConcepto = 4;

            TCConceptosDetCN objOperacionConceptosDet = new TCConceptosDetCN();
            dta_consulta = null;
            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);

            ddl_combomoneda.Items.Clear();

            ddl_combomoneda.DataSource = dta_consulta;
            ddl_combomoneda.DataTextField = "DscAbvConcepto";
            ddl_combomoneda.DataValueField = "CodConcepto";
            ddl_combomoneda.DataBind();


            dta_consulta = null;
            objEntidadConceptosDet.CodConcepto = 5;
            dta_consulta = objOperacionConceptosDet.F_TCConceptos_Select(objEntidadConceptosDet);

            ddl_comboformapago.Items.Clear();

            ddl_comboformapago.DataSource = dta_consulta;
            ddl_comboformapago.DataTextField = "DscAbvConcepto";
            ddl_comboformapago.DataValueField = "CodConcepto";
            ddl_comboformapago.DataBind();

            ddl_comboformapagoedicion.Items.Clear();

            ddl_comboformapagoedicion.DataSource = dta_consulta;
            ddl_comboformapagoedicion.DataTextField = "DscAbvConcepto";
            ddl_comboformapagoedicion.DataValueField = "CodConcepto";
            ddl_comboformapagoedicion.DataBind();

            dta_consulta = null;
            TCTasasCE objEntidadTasa = new TCTasasCE();
            objEntidadTasa.CodTipoTasa = 1;
            objEntidadTasa.CodEstado = 0;
            TCTasasCN objOperacionTasa = new TCTasasCN();
            dta_consulta = objOperacionTasa.F_TCTasas_ListarXTipoTasa(objEntidadTasa);

            ddl_comboigv.Items.Clear();

            ddl_comboigv.DataSource = dta_consulta;
            ddl_comboigv.DataTextField = "Valor";
            ddl_comboigv.DataValueField = "CodTasa";
            ddl_comboigv.DataBind();

            dta_consulta = null;

            TCAlmacenCE objEntidadAlmacen = new TCAlmacenCE();
            TCAlmacenCN objOperacionAlmacen = new TCAlmacenCN();

            objEntidadAlmacen.CodAlmacen = Convert.ToInt32(Session["CodSede"]);

            Direccion = "";

            TCDocumentosCN objOperacionTCDocumentos = new TCDocumentosCN();
            TCDocumentosCE objEntidadTCDocumentos = new TCDocumentosCE();
            dta_consulta = objOperacionTCDocumentos.F_TCDocumentos_ListarFacturacion();
            ddlTipoDoc.Items.Clear();
            ddlTipoDoc.DataSource = dta_consulta;
            ddlTipoDoc.DataTextField = "Descripcion";
            ddlTipoDoc.DataValueField = "CodTipoDoc";
            ddlTipoDoc.DataBind();

            ddlTipoDoc2.Items.Clear();
            ddlTipoDoc2.DataSource = dta_consulta;
            ddlTipoDoc2.DataTextField = "Descripcion";
            ddlTipoDoc2.DataValueField = "CodTipoDoc";
            ddlTipoDoc2.DataBind();

            dta_consulta = null;
            TCEmpresaCN objOperacionTCEmpresa = new TCEmpresaCN();
            dta_consulta = objOperacionTCEmpresa.F_TCEmpresa_Listar(new TCEmpresaCE() { CodEmpresa = iCodEmpresa });
            try { CantidadPlacas = (int)dta_consulta.Rows[0]["P_CantidadPlacas"]; }
            catch (Exception exx) { CantidadPlacas = 1; }


            objEntidad.CodTipoDoc = 16;
            objEntidad.CodEstado = 0;
            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_comboserienv.Items.Clear();

            ddl_comboserienv.DataSource = dta_consulta;
            ddl_comboserienv.DataTextField = "SerieDoc";
            ddl_comboserienv.DataValueField = "CodSerie";
            ddl_comboserienv.DataBind();
            ddl_comboserienv.Items.Insert(0, new ListItem("TODOS", "0"));
            
            objEntidad.CodTipoDoc = 15;
            objEntidad.CodEstado = 0;
            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_comboseriect.Items.Clear();

            ddl_comboseriect.DataSource = dta_consulta;
            ddl_comboseriect.DataTextField = "SerieDoc";
            ddl_comboseriect.DataValueField = "CodSerie";
            ddl_comboseriect.DataBind();
            ddl_comboseriect.Items.Insert(0, new ListItem("TODOS", "0"));

            dta_consulta = null;
            objEntidadConceptosDet.Flag = 1;
            dta_consulta = objOperacionConceptosDet.F_TCConceptosDet_ListarEstadoFactura(objEntidadConceptosDet);

            ddl_comboestado.Items.Clear();

            ddl_comboestado.DataSource = dta_consulta;
            ddl_comboestado.DataTextField = "Descripcion";
            ddl_comboestado.DataValueField = "Codigo";
            ddl_comboestado.DataBind();
            ddl_comboestado.Items.Insert(0, new ListItem("TODOS", "0"));

            //VENDEDORES
            EmpleadoCE objEmpleado = new EmpleadoCE();

            objEmpleado.CodCargo = Convert.ToInt32(objTablaFiltro["Filtro_CodCargo"]);
            objEmpleado.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            dta_consulta = (new EmpleadoCN()).F_Empleado_Listar(objEmpleado);
            ddl_empleado.Items.Clear();

            ddl_empleado.DataSource = dta_consulta;
            ddl_empleado.DataTextField = "NombreCompleto";
            ddl_empleado.DataValueField = "CodEmpleado";
            ddl_empleado.DataBind();

            ddl_empleadoconsulta.Items.Clear();

            ddl_empleadoconsulta.DataSource = dta_consulta;
            ddl_empleadoconsulta.DataTextField = "NombreCompleto";
            ddl_empleadoconsulta.DataValueField = "CodEmpleado";
            ddl_empleadoconsulta.DataBind();
            ddl_empleadoconsulta.Items.Insert(0, new ListItem("TODOS", "0"));

            ddl_VendedorEdicion.Items.Clear();

            ddl_VendedorEdicion.DataSource = dta_consulta;
            ddl_VendedorEdicion.DataTextField = "NombreCompleto";
            ddl_VendedorEdicion.DataValueField = "CodEmpleado";
            ddl_VendedorEdicion.DataBind();
        }

        public void P_Series_Documentos(Hashtable objTablaFiltro, ref DropDownList ddl_serie, ref DropDownList ddl_serieconsulta,
                                        ref DropDownList ddl_serieguia, ref DropDownList ddl_comboserienv, ref DropDownList ddl_comboseriect)
        {

            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;

            DataTable dta_consulta = null;


            int iCodEmpresa = 3;

            objEntidad = new TCCorrelativoCE();

            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodDoc"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodEmpresa = iCodEmpresa;
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);

            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_serie.Items.Clear();

            ddl_serie.DataSource = dta_consulta;
            ddl_serie.DataTextField = "SerieDoc";
            ddl_serie.DataValueField = "CodSerie";
            ddl_serie.DataBind();

            ddl_serieconsulta.Items.Clear();

            objEntidad.CodEstado = 0;

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);
            ddl_serieconsulta.DataSource = dta_consulta;
            ddl_serieconsulta.DataTextField = "SerieDoc";
            ddl_serieconsulta.DataValueField = "CodSerie";
            ddl_serieconsulta.DataBind();


            dta_consulta = null;
            objEntidad.CodTipoDoc = 10;
            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_serieguia.Items.Clear();

            ddl_serieguia.DataSource = dta_consulta;
            ddl_serieguia.DataTextField = "SerieDoc";
            ddl_serieguia.DataValueField = "CodSerie";
            ddl_serieguia.DataBind();

            objEntidad.CodTipoDoc = 16;
            objEntidad.CodEstado = 0;
            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_comboserienv.Items.Clear();

            ddl_comboserienv.DataSource = dta_consulta;
            ddl_comboserienv.DataTextField = "SerieDoc";
            ddl_comboserienv.DataValueField = "CodSerie";
            ddl_comboserienv.DataBind();
            ddl_comboserienv.Items.Insert(0, new ListItem("TODOS", "0"));

            objEntidad.CodTipoDoc = 15;
            objEntidad.CodEstado = 0;
            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_comboseriect.Items.Clear();

            ddl_comboseriect.DataSource = dta_consulta;
            ddl_comboseriect.DataTextField = "SerieDoc";
            ddl_comboseriect.DataValueField = "CodSerie";
            ddl_comboseriect.DataBind();
            ddl_comboseriect.Items.Insert(0, new ListItem("TODOS", "0"));
        }
        
        public void P_Obtener_TipoCambio(Hashtable objTablaFiltro, ref Decimal TipoCambio)
        {

            TCTipoCambioCE objEntidad = null;
            TCTipoCambioCN objOperacion = null;

            DataTable dta_consulta = null;

            //
            //int iCodEmpresa = 3;

            objEntidad = new TCTipoCambioCE();

            objEntidad.Fecha = Convert.ToDateTime(objTablaFiltro["Filtro_Fecha"]);

            objOperacion = new TCTipoCambioCN();

            dta_consulta = objOperacion.F_TCTipoCambio_Select(objEntidad);

            if (dta_consulta.Rows.Count > 0)
                TipoCambio = Convert.ToDecimal(dta_consulta.Rows[0]["TC_Venta"]);



        }

        public void P_Obtener_NumeroCorrelativo(Hashtable objTablaFiltro, ref String Numero)
        {
            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new TCCorrelativoCE();

            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodDoc"]);
            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_SerieDoc"]);
            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);

            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Numero_Select(objEntidad);

            if (dta_consulta.Rows.Count > 0)
                Numero = Convert.ToString(dta_consulta.Rows[0]["NumeroDoc"]);
        }

        public void P_Inicializar_GrillaVacia_Articulo()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();

            dta_consultaarticulo.Columns.Add("CodProducto", typeof(string));
            dta_consultaarticulo.Columns.Add("CodUnidadVenta", typeof(string));
            dta_consultaarticulo.Columns.Add("Costo", typeof(string));
            dta_consultaarticulo.Columns.Add("CodigoInterno", typeof(string));
            dta_consultaarticulo.Columns.Add("CodigoProducto", typeof(string));
            dta_consultaarticulo.Columns.Add("Producto", typeof(string));
            dta_consultaarticulo.Columns.Add("Stock", typeof(string));
            dta_consultaarticulo.Columns.Add("UM", typeof(string));
            dta_consultaarticulo.Columns.Add("Precio1", typeof(string));
            dta_consultaarticulo.Columns.Add("Precio2", typeof(string));
            dta_consultaarticulo.Columns.Add("Precio3", typeof(string));
            dta_consultaarticulo.Columns.Add("Moneda", typeof(string));

            dta_consultaarticulo.Columns.Add("Medida", typeof(string));
            dta_consultaarticulo.Columns.Add("Marca", typeof(string));
            dta_consultaarticulo.Columns.Add("Modelo", typeof(string));
            dta_consultaarticulo.Columns.Add("Posicion", typeof(string));
            dta_consultaarticulo.Columns.Add("Descripcion", typeof(string));
            dta_consultaarticulo.Columns.Add("Anio", typeof(string));
            dta_consultaarticulo.Columns.Add("Codigo2", typeof(string));
            dta_consultaarticulo.Columns.Add("FlagProductoInicial", typeof(string));
            dta_consultaarticulo.Columns.Add("CodProductoAzure", typeof(string));
            dta_consultaarticulo.Columns.Add("CostoConIgv", typeof(string));

            dta_consultaarticulo.Columns.Add("FlagGratuito", typeof(string));
            dta_consultaarticulo.Columns.Add("Gratuito", typeof(string));


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


            dta_consultaarticulo.Rows.Add(dtr_consultafila);

            //display none a la columna de costo, en el caso de que ese esté excluido segun lamda de abajo
            if (Utilitarios.Menu.ModulosExcluidos.Find(m => m.CodigoMenu == "4000" & m.Codigo == "777001") != null)
                grvConsultaArticulo.Columns[5].Visible = false;

            grvConsultaArticulo.DataSource = dta_consultaarticulo;
            grvConsultaArticulo.DataBind();
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
            dta_consulta.Columns.Add("Condicion", typeof(string));
            dta_consulta.Columns.Add("Vencimiento", typeof(string));
            dta_consulta.Columns.Add("Moneda", typeof(string));
            dta_consulta.Columns.Add("TC", typeof(string));
            dta_consulta.Columns.Add("SubTotal", typeof(string));
            dta_consulta.Columns.Add("Igv", typeof(string));
            dta_consulta.Columns.Add("Total", typeof(string));
            dta_consulta.Columns.Add("Guia", typeof(string));
            dta_consulta.Columns.Add("Estado", typeof(string));
            dta_consulta.Columns.Add("CodGuia", typeof(string));
            dta_consulta.Columns.Add("Documento", typeof(string));
            dta_consulta.Columns.Add("Saldo", typeof(string));
            dta_consulta.Columns.Add("FechaCancelacion", typeof(string));
            dta_consulta.Columns.Add("EstadoSunat", typeof(string));
            dta_consulta.Columns.Add("EstadoCorreoSunat", typeof(string));
            dta_consulta.Columns.Add("CodTipoDoc", typeof(string));
            dta_consulta.Columns.Add("Placa", typeof(string));

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

        public void P_Inicializar_GrillaVacia_Detalle()
        {
            DataTable dta_consultadetalle = null;
            DataRow dtr_filadetalle = null;

            dta_consultadetalle = new DataTable();

            dta_consultadetalle.Columns.Add("CodDetalle", typeof(string));
            dta_consultadetalle.Columns.Add("CodArticulo", typeof(string));
            dta_consultadetalle.Columns.Add("CodigoProducto", typeof(string));
            dta_consultadetalle.Columns.Add("Producto", typeof(string));
            dta_consultadetalle.Columns.Add("Cantidad", typeof(string));
            dta_consultadetalle.Columns.Add("UM", typeof(string));
            dta_consultadetalle.Columns.Add("Precio", typeof(string));
            dta_consultadetalle.Columns.Add("Importe", typeof(string));
            dta_consultadetalle.Columns.Add("CodDetalleOC", typeof(string));
            dta_consultadetalle.Columns.Add("Acuenta", typeof(string));
            dta_consultadetalle.Columns.Add("CodTipoDoc", typeof(string));
            dta_consultadetalle.Columns.Add("P1", typeof(string));
            dta_consultadetalle.Columns.Add("P2", typeof(string));
            dta_consultadetalle.Columns.Add("P3", typeof(string));
            dta_consultadetalle.Columns.Add("FlagGratuito", typeof(string));
            dta_consultadetalle.Columns.Add("Gratuito", typeof(string));



            dtr_filadetalle = dta_consultadetalle.NewRow();

            dtr_filadetalle[0] = "";
            dtr_filadetalle[1] = "";
            dtr_filadetalle[2] = "";
            dtr_filadetalle[3] = "";
            dtr_filadetalle[4] = "";
            dtr_filadetalle[5] = "";
            dtr_filadetalle[6] = "";
            dtr_filadetalle[7] = "";
            dtr_filadetalle[8] = "";
            dtr_filadetalle[9] = "";
            dtr_filadetalle[10] = "";

            dta_consultadetalle.Rows.Add(dtr_filadetalle);

            grvDetalleArticulo.DataSource = dta_consultadetalle;
            grvDetalleArticulo.DataBind();
        }

        public void P_Inicializar_GrillaVacia_DetalleOC()
        {
            DataTable dta_consultadetalleoc = null;
            DataRow dtr_filadetalle = null;

            dta_consultadetalleoc = new DataTable();

            dta_consultadetalleoc.Columns.Add("CodDetalle", typeof(string));
            dta_consultadetalleoc.Columns.Add("CodArticulo", typeof(string));
            dta_consultadetalleoc.Columns.Add("Codigo", typeof(string));
            dta_consultadetalleoc.Columns.Add("Producto", typeof(string));
            dta_consultadetalleoc.Columns.Add("Cantidad", typeof(string));
            dta_consultadetalleoc.Columns.Add("UM", typeof(string));
            dta_consultadetalleoc.Columns.Add("CodUndMedida", typeof(string));
            dta_consultadetalleoc.Columns.Add("Precio", typeof(string));
            dta_consultadetalleoc.Columns.Add("Numero", typeof(string));
            dta_consultadetalleoc.Columns.Add("CodMovimiento", typeof(string));
            dta_consultadetalleoc.Columns.Add("SerieDoc", typeof(string));
            dta_consultadetalleoc.Columns.Add("NumeroDoc", typeof(string));
            dta_consultadetalleoc.Columns.Add("CostoUnitario", typeof(string));
            dta_consultadetalleoc.Columns.Add("Fecha", typeof(string));
            dta_consultadetalleoc.Columns.Add("FechaAnexo", typeof(string));

            dtr_filadetalle = dta_consultadetalleoc.NewRow();

            dtr_filadetalle[0] = "";
            dtr_filadetalle[1] = "";
            dtr_filadetalle[2] = "";
            dtr_filadetalle[3] = "";
            dtr_filadetalle[4] = "";
            dtr_filadetalle[5] = "";
            dtr_filadetalle[6] = "";
            dtr_filadetalle[7] = "";
            dtr_filadetalle[8] = "";
            dtr_filadetalle[9] = "";
            dtr_filadetalle[10] = "";
            dtr_filadetalle[11] = "";
            dtr_filadetalle[12] = "";
            dtr_filadetalle[13] = "";
            dtr_filadetalle[14] = "";

            dta_consultadetalleoc.Rows.Add(dtr_filadetalle);

            grvDetalleOC.DataSource = dta_consultadetalleoc;
            grvDetalleOC.DataBind();
        }

        public void P_Inicializar_GrillaVacia_DetalleGuia()
        {
            DataTable dta_consultadetalleoc = null;
            DataRow dtr_filadetalle = null;

            dta_consultadetalleoc = new DataTable();

            dta_consultadetalleoc.Columns.Add("CodDetalle", typeof(string));
            dta_consultadetalleoc.Columns.Add("CodArticulo", typeof(string));
            dta_consultadetalleoc.Columns.Add("Codigo", typeof(string));
            dta_consultadetalleoc.Columns.Add("Producto", typeof(string));
            dta_consultadetalleoc.Columns.Add("Cantidad", typeof(string));
            dta_consultadetalleoc.Columns.Add("UM", typeof(string));
            dta_consultadetalleoc.Columns.Add("CodUndMedida", typeof(string));
            dta_consultadetalleoc.Columns.Add("Precio", typeof(string));
            dta_consultadetalleoc.Columns.Add("Numero", typeof(string));
            dta_consultadetalleoc.Columns.Add("CodMovimiento", typeof(string));
            dta_consultadetalleoc.Columns.Add("SerieDoc", typeof(string));
            dta_consultadetalleoc.Columns.Add("NumeroDoc", typeof(string));
            dta_consultadetalleoc.Columns.Add("CostoUnitario", typeof(string));
            dta_consultadetalleoc.Columns.Add("Almacen", typeof(string));
            dta_consultadetalleoc.Columns.Add("CodDepartamento", typeof(string));
            dta_consultadetalleoc.Columns.Add("FechaEmision", typeof(string));
            dta_consultadetalleoc.Columns.Add("Marca", typeof(string));

            dtr_filadetalle = dta_consultadetalleoc.NewRow();

            dtr_filadetalle[0] = "";
            dtr_filadetalle[1] = "";
            dtr_filadetalle[2] = "";
            dtr_filadetalle[3] = "";
            dtr_filadetalle[4] = "";
            dtr_filadetalle[5] = "";
            dtr_filadetalle[6] = "";
            dtr_filadetalle[7] = "";
            dtr_filadetalle[8] = "";
            dtr_filadetalle[9] = "";
            dtr_filadetalle[10] = "";
            dtr_filadetalle[11] = "";
            dtr_filadetalle[12] = "";
            dtr_filadetalle[13] = "";
            dtr_filadetalle[14] = "";
            dtr_filadetalle[15] = "";

            dta_consultadetalleoc.Rows.Add(dtr_filadetalle);

            grvFacturacionGuia.DataSource = dta_consultadetalleoc;
            grvFacturacionGuia.DataBind();

        }

        public void P_Inicializar_GrillaVacia_PrecioMoneda()
        {
            DataTable dta_consultapreciomoneda = null;
            DataRow dtr_filadetalle = null;

            dta_consultapreciomoneda = new DataTable();

            dta_consultapreciomoneda.Columns.Add("CodProducto", typeof(string));
            dta_consultapreciomoneda.Columns.Add("Precio1", typeof(string));
            dta_consultapreciomoneda.Columns.Add("Precio2", typeof(string));
            dta_consultapreciomoneda.Columns.Add("Precio3", typeof(string));
            dta_consultapreciomoneda.Columns.Add("Moneda", typeof(string));

            dtr_filadetalle = dta_consultapreciomoneda.NewRow();

            dtr_filadetalle[0] = "";
            dtr_filadetalle[1] = "";
            dtr_filadetalle[2] = "";
            dtr_filadetalle[3] = "";
            dtr_filadetalle[4] = "";

            dta_consultapreciomoneda.Rows.Add(dtr_filadetalle);

            grvPrecioMoneda.DataSource = dta_consultapreciomoneda;
            grvPrecioMoneda.DataBind();

        }

        public void P_Inicializar_GrillaVacia_DetalleNV()
        {
            DataTable dta_consultadetallenv = null;
            DataRow dtr_filadetalle = null;

            dta_consultadetallenv = new DataTable();

            dta_consultadetallenv.Columns.Add("CodDetalle", typeof(string));
            dta_consultadetallenv.Columns.Add("CodProducto", typeof(string));
            dta_consultadetallenv.Columns.Add("Codigo", typeof(string));
            dta_consultadetallenv.Columns.Add("Producto", typeof(string));
            dta_consultadetallenv.Columns.Add("Cantidad", typeof(string));
            dta_consultadetallenv.Columns.Add("UM", typeof(string));
            dta_consultadetallenv.Columns.Add("CodUndMedida", typeof(string));
            dta_consultadetallenv.Columns.Add("Precio", typeof(string));
            dta_consultadetallenv.Columns.Add("Numero", typeof(string));
            dta_consultadetallenv.Columns.Add("CodMovimiento", typeof(string));
            dta_consultadetallenv.Columns.Add("SerieDoc", typeof(string));
            dta_consultadetallenv.Columns.Add("NumeroDoc", typeof(string));
            dta_consultadetallenv.Columns.Add("CostoUnitario", typeof(string));
            dta_consultadetallenv.Columns.Add("Fecha", typeof(string));
            dta_consultadetallenv.Columns.Add("Cliente", typeof(string));
            dta_consultadetallenv.Columns.Add("Acuenta", typeof(string));
            dta_consultadetallenv.Columns.Add("Importe", typeof(string));
            dta_consultadetallenv.Columns.Add("FechaAnexo", typeof(string));
            dta_consultadetallenv.Columns.Add("NroRuc", typeof(string));
            dta_consultadetallenv.Columns.Add("PrecioSinIgv", typeof(string));

            dtr_filadetalle = dta_consultadetallenv.NewRow();

            dtr_filadetalle[0] = "";
            dtr_filadetalle[1] = "";
            dtr_filadetalle[2] = "";
            dtr_filadetalle[3] = "";
            dtr_filadetalle[4] = "";
            dtr_filadetalle[5] = "";
            dtr_filadetalle[6] = "";
            dtr_filadetalle[7] = "";
            dtr_filadetalle[8] = "";
            dtr_filadetalle[9] = "";
            dtr_filadetalle[10] = "";
            dtr_filadetalle[11] = "";
            dtr_filadetalle[12] = "";
            dtr_filadetalle[13] = "";
            dtr_filadetalle[14] = "";
            dtr_filadetalle[15] = "";
            dtr_filadetalle[16] = "";
            dtr_filadetalle[17] = "";
            dtr_filadetalle[18] = "";

            dta_consultadetallenv.Rows.Add(dtr_filadetalle);

            grvDetalleNV.DataSource = dta_consultadetallenv;
            grvDetalleNV.DataBind();
        }

        public void P_Inicializar_GrillaVacia_DetalleCT()
        {
            DataTable dta_consultadetalleCT = null;
            DataRow dtr_filadetalle = null;

            dta_consultadetalleCT = new DataTable();

            dta_consultadetalleCT.Columns.Add("CodDetalle", typeof(string));
            dta_consultadetalleCT.Columns.Add("CodArticulo", typeof(string));
            dta_consultadetalleCT.Columns.Add("Codigo", typeof(string));
            dta_consultadetalleCT.Columns.Add("Producto", typeof(string));
            dta_consultadetalleCT.Columns.Add("Cantidad", typeof(string));
            dta_consultadetalleCT.Columns.Add("UM", typeof(string));
            dta_consultadetalleCT.Columns.Add("CodUndMedida", typeof(string));
            dta_consultadetalleCT.Columns.Add("Precio", typeof(string));
            dta_consultadetalleCT.Columns.Add("Numero", typeof(string));
            dta_consultadetalleCT.Columns.Add("CodMovimiento", typeof(string));
            dta_consultadetalleCT.Columns.Add("SerieDoc", typeof(string));
            dta_consultadetalleCT.Columns.Add("NumeroDoc", typeof(string));
            dta_consultadetalleCT.Columns.Add("CostoUnitario", typeof(string));
            dta_consultadetalleCT.Columns.Add("Fecha", typeof(string));
            dta_consultadetalleCT.Columns.Add("Cliente", typeof(string));
            dta_consultadetalleCT.Columns.Add("Acuenta", typeof(string));
            dta_consultadetalleCT.Columns.Add("Importe", typeof(string));
            dta_consultadetalleCT.Columns.Add("FechaAnexo", typeof(string));

            dtr_filadetalle = dta_consultadetalleCT.NewRow();

            dtr_filadetalle[0] = "";
            dtr_filadetalle[1] = "";
            dtr_filadetalle[2] = "";
            dtr_filadetalle[3] = "";
            dtr_filadetalle[4] = "";
            dtr_filadetalle[5] = "";
            dtr_filadetalle[6] = "";
            dtr_filadetalle[7] = "";
            dtr_filadetalle[8] = "";
            dtr_filadetalle[9] = "";
            dtr_filadetalle[10] = "";
            dtr_filadetalle[11] = "";
            dtr_filadetalle[12] = "";
            dtr_filadetalle[13] = "";
            dtr_filadetalle[14] = "";
            dtr_filadetalle[15] = "";
            dtr_filadetalle[16] = "";
            dtr_filadetalle[17] = "";

            dta_consultadetalleCT.Rows.Add(dtr_filadetalle);

            grvDetalleCT.DataSource = dta_consultadetalleCT;
            grvDetalleCT.DataBind();
        }

        public void P_Inicializar_GrillaVacia_UltimoPrecio()
        {
            DataTable dta_consultadetallenv = null;
            DataRow dtr_filadetalle = null;

            dta_consultadetallenv = new DataTable();

            dta_consultadetallenv.Columns.Add("Precio", typeof(string));
            dta_consultadetallenv.Columns.Add("Moneda", typeof(string));
            dta_consultadetallenv.Columns.Add("Cantidad", typeof(string));
            dta_consultadetallenv.Columns.Add("Fecha", typeof(string));
            dta_consultadetallenv.Columns.Add("Factura", typeof(string));

            dtr_filadetalle = dta_consultadetallenv.NewRow();

            dtr_filadetalle[0] = "";
            dtr_filadetalle[1] = "";
            dtr_filadetalle[2] = "";
            dtr_filadetalle[3] = "";
            dtr_filadetalle[4] = "";

            dta_consultadetallenv.Rows.Add(dtr_filadetalle);

            grvConsultaUltimosPrecios.DataSource = dta_consultadetallenv;
            grvConsultaUltimosPrecios.DataBind();
        }
        
        public void P_Cargar_Grilla(Hashtable objTablaFiltro, ref GridView grvConsulta)
        {

            LGProductosCE objEntidad = null;
            LGProductosCN objOperacion = null;


            int iCodEmpresa = 3;
            int CodTipoProducto = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoProducto"]);

            if (iCodEmpresa == 3 && Convert.ToInt32(objTablaFiltro["Filtro_Servicio"]) == 1)
                CodTipoProducto = 1;

            if (iCodEmpresa == 2)
                CodTipoProducto = 2;

            objEntidad = new LGProductosCE();
            objOperacion = new LGProductosCN();
            if (Convert.ToInt32(objTablaFiltro["Filtro_Servicio"]) == 1 && Convert.ToInt32(objTablaFiltro["Filtro_NotaPedido"]) == 0)
            {
                objEntidad.CodEmpresa = iCodEmpresa;
                objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
                objEntidad.CodTipoProducto = CodTipoProducto;
                objEntidad.DscProducto = Convert.ToString(objTablaFiltro["Filtro_DscProducto"]);
                objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);
                objEntidad.CodigoProducto = "";
                objOperacion.F_LGProductosServicios_Update(objEntidad);
            }

            string Descripcion = Convert.ToString(objTablaFiltro["Filtro_DscProducto"]);
          
            objEntidad.DscProducto = Convert.ToString(objTablaFiltro["Filtro_DscProducto"]).Trim().ToUpper();
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            if (Convert.ToInt32(objTablaFiltro["Filtro_NotaPedido"]) == 1)
                objEntidad.CodTipoProducto = 2;
            else
                objEntidad.CodTipoProducto = CodTipoProducto;

            //display none a la columna de costo, en el caso de que ese esté excluido segun lamda de abajo
            if (Utilitarios.Menu.ModulosExcluidos.Find(m => m.CodigoMenu == "4000" & m.Codigo == "777001") != null)
                grvConsulta.Columns[5].Visible = false;

            grvConsulta.DataSource = objOperacion.F_LGProductos_Select_Ventas(objEntidad);
            grvConsulta.DataBind();


        }

        public void P_AgregarTemporal(Hashtable objTablaFiltro, ref Int32 Codigo, ref String MsgError)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            String XmlDetalle = "";
            int iCodEmpresa = 3;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodEmpresa = iCodEmpresa;
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_SerieDoc"]); ;

            objEntidad.NumeroDoc = Convert.ToString(objTablaFiltro["Filtro_NumeroDoc"]);
            objEntidad.FechaEmision = Convert.ToDateTime(objTablaFiltro["Filtro_FechaEmision"]);
            objEntidad.FechaVencimiento = Convert.ToDateTime(objTablaFiltro["Filtro_Vencimiento"]);
            objEntidad.CodCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodCliente"]);

            objEntidad.CodFormaPago = Convert.ToInt32(objTablaFiltro["Filtro_CodFormaPago"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
            objEntidad.TipoCambio = Convert.ToDecimal(objTablaFiltro["Filtro_TipoCambio"]);
            objEntidad.SubTotal = Convert.ToDecimal(objTablaFiltro["Filtro_SubTotal"]);

            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
            objEntidad.CodProforma = Convert.ToInt32(objTablaFiltro["Filtro_CodProforma"]);
            objEntidad.Igv = Convert.ToDecimal(objTablaFiltro["Filtro_Igv"]);
            objEntidad.Total = Convert.ToDecimal(objTablaFiltro["Filtro_Total"]);

            objEntidad.CodGuia = Convert.ToInt32(objTablaFiltro["Filtro_CodGuia"]);
            objEntidad.Descuento = Convert.ToInt32(objTablaFiltro["Filtro_Descuento"]);

            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_XmlDetalle"].ToString());

            foreach (dynamic item in jArr2)
            {
                XmlDetalle = XmlDetalle + "<D ";
                XmlDetalle = XmlDetalle + " CodArticulo = '" + item.CodArticulo + "'";
                XmlDetalle = XmlDetalle + " Cantidad = '" + item.Cantidad + "'";
                XmlDetalle = XmlDetalle + " Precio = '" + item.Precio + "'";
                XmlDetalle = XmlDetalle + " PrecioDscto = '" + item.PrecioDscto + "'";
                XmlDetalle = XmlDetalle + " Costo = '" + item.Costo + "'";
                XmlDetalle = XmlDetalle + " CodUm = '" + item.CodUm + "'";
                XmlDetalle = XmlDetalle + " CodDetalle = '" + item.CodDetalle + "'";
                XmlDetalle = XmlDetalle + " OC = '" + item.OC + "'";
                XmlDetalle = XmlDetalle + " Descripcion = '" + item.Descripcion + "'";
                XmlDetalle = XmlDetalle + " Acuenta = '" + item.Acuenta + "'";
                XmlDetalle = XmlDetalle + " CodTipoDoc = '" + item.CodTipoDoc + "'";
                XmlDetalle = XmlDetalle + " Fecha = '" + item.Fecha + "'";
                XmlDetalle = XmlDetalle + " Codigo = '" + item.Codigo + "'";
                XmlDetalle = XmlDetalle + " />";
            }

            XmlDetalle = "<R><XmlLC> " + XmlDetalle + "</XmlLC></R>";
            XmlDetalle = "<?xml version=" + '\u0022' + "1.0" + '\u0022' + " encoding=" + '\u0022' + "iso-8859-1" + '\u0022' + "?>" + XmlDetalle;

            objEntidad.XmlDetalle = XmlDetalle;

            objOperacion = new DocumentoVentaCabCN();

            if (Convert.ToInt32(objTablaFiltro["Filtro_CodigoTemporal"]) == 0)
            {
                objOperacion.F_TemporalFacturacionDet_Insert(objEntidad);
                Codigo = objEntidad.CodDocumentoVenta;
            }
            else
            {
                objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodigoTemporal"]);
                objOperacion.F_TemporalFacturacionDetalle_Insert(objEntidad);
                Codigo = Convert.ToInt32(objTablaFiltro["Filtro_CodigoTemporal"]);
            }
            MsgError = objEntidad.MsgError;
        }

        public void P_EliminarTemporal(Hashtable objTablaFiltro, ref String MsgError)
        {

            DocumentoVentaDetCE objEntidad = null;
            DocumentoVentaDetCN objOperacion = null;

            String XmlDetalle = "";

            objEntidad = new DocumentoVentaDetCE();

            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_XmlDetalle"].ToString());

            foreach (dynamic item in jArr2)
            {
                XmlDetalle = XmlDetalle + "<D ";
                XmlDetalle = XmlDetalle + " CodDetalle = '" + item.CodDetalle + "'";
                XmlDetalle = XmlDetalle + " />";
            }

            XmlDetalle = "<R><XmlLC> " + XmlDetalle + "</XmlLC></R>";

            objEntidad.XmlDetalle = XmlDetalle;

            objOperacion = new DocumentoVentaDetCN();

            objOperacion.F_TemporalFacturacionDet_Eliminar(objEntidad);

            MsgError = objEntidad.MsgError;

        }
        
        public void P_CargarGrillaTemporal(Hashtable objTablaFiltro, Int32 Codigo, ref GridView grvDetalle,
            ref Decimal SubTotalFactura, ref Decimal IgvFactura, ref Decimal TotalFactura, ref Decimal Acuenta, ref Int32 NotaPedido)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();
            objOperacion = new DocumentoVentaCabCN();

            DataTable dta_consulta = null;
            if (Codigo != 0)
            {

                objEntidad.Igv = Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]);
                objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
                objEntidad.Tasa = Convert.ToDecimal(objTablaFiltro["Filtro_Tasa"]);
                objEntidad.CodDocumentoVenta = Codigo;

                dta_consulta = objOperacion.F_TemporalFacturacionDet_Listar(objEntidad);
            }
            if (dta_consulta.Rows.Count > 0)
            {
                if (Convert.ToInt32(objTablaFiltro["Filtro_NotaPedido"]) == 1)
                {
                    for (int j = 0; j < dta_consulta.Rows.Count; j++)
                    {
                        if (Convert.ToDecimal(dta_consulta.Rows[j]["CodTipoProducto"]) == 1)
                            TotalFactura += Convert.ToDecimal(dta_consulta.Rows[j]["Importe"]);
                    }
                }
                else
                {
                    for (int j = 0; j < dta_consulta.Rows.Count; j++)
                    {
                        TotalFactura += Convert.ToDecimal(dta_consulta.Rows[j]["Importe"]);
                        Acuenta += Convert.ToDecimal(dta_consulta.Rows[j]["Acuenta"]);
                    }
                }
                if (Convert.ToInt32(objTablaFiltro["Filtro_FlagIgv"]) == 1)
                {
                    SubTotalFactura = TotalFactura / Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgvDscto"]);
                    IgvFactura = SubTotalFactura * (Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgvDscto"]) - 1);
                }
                else
                {
                    SubTotalFactura = TotalFactura;
                    IgvFactura = TotalFactura * (Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgvDscto"]) - 1);
                    TotalFactura = SubTotalFactura + IgvFactura;
                }

            }
            grvDetalle.DataSource = dta_consulta;
            grvDetalle.DataBind();

            try { NotaPedido = Convert.ToInt32(dta_consulta.Rows[0]["NotaPedido"]); }
            catch (Exception exxx) { NotaPedido = 0; };
        }

        public void P_GrabarDocumento(Hashtable objTablaFiltro, ref String MsgError, ref Int32 Codigo)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();
            int iCodEmpresa = 3;

            objEntidad.CodEmpresa = iCodEmpresa;
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_SerieDoc"]);
            objEntidad.NumeroDoc = Convert.ToString(objTablaFiltro["Filtro_NumeroDoc"]);

            objEntidad.FechaEmision = Convert.ToDateTime(objTablaFiltro["Filtro_FechaEmision"]);
            objEntidad.FechaVencimiento = Convert.ToDateTime(objTablaFiltro["Filtro_Vencimiento"]);
            objEntidad.CodCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodCliente"]);
            //objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            objEntidad.CodFormaPago = Convert.ToInt32(objTablaFiltro["Filtro_CodFormaPago"]);

            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
            objEntidad.TipoCambio = Convert.ToDecimal(objTablaFiltro["Filtro_TipoCambio"]);
            objEntidad.SubTotal = Convert.ToDecimal(objTablaFiltro["Filtro_SubTotal"]);
            objEntidad.Igv = Convert.ToDecimal(objTablaFiltro["Filtro_Igv"]);
            objEntidad.Total = Convert.ToDecimal(objTablaFiltro["Filtro_Total"]);

            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
            objEntidad.CodTraslado = Convert.ToInt32(objTablaFiltro["Filtro_CodTraslado"]);
            objEntidad.CodProforma = Convert.ToInt32(objTablaFiltro["Filtro_CodProforma"]);
            objEntidad.FlagGuia = Convert.ToInt32(objTablaFiltro["Filtro_FlagGuia"]);
            objEntidad.SerieGuia = Convert.ToString(objTablaFiltro["Filtro_SerieGuia"]);

            objEntidad.NumeroGuia = Convert.ToString(objTablaFiltro["Filtro_NumeroGuia"]);
            objEntidad.FechaTraslado = Convert.ToDateTime(objTablaFiltro["Filtro_FechaTraslado"]);
            objEntidad.CodTipoCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoCliente"]);
            objEntidad.CodClaseCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodClaseCliente"]);
            objEntidad.CodDepartamento = Convert.ToInt32(objTablaFiltro["Filtro_CodDepartamento"]);

            objEntidad.CodProvincia = Convert.ToInt32(objTablaFiltro["Filtro_CodProvincia"]);
            objEntidad.CodDistrito = Convert.ToInt32(objTablaFiltro["Filtro_CodDistrito"]);
            objEntidad.ApePaterno = Convert.ToString(objTablaFiltro["Filtro_ApePaterno"]);
            objEntidad.ApeMaterno = Convert.ToString(objTablaFiltro["Filtro_ApeMaterno"]);
            objEntidad.Nombres = Convert.ToString(objTablaFiltro["Filtro_Nombres"]);

            objEntidad.RazonSocial = Convert.ToString(objTablaFiltro["Filtro_RazonSocial"]);
            objEntidad.NroDni = Convert.ToString(objTablaFiltro["Filtro_NroDni"]);
            objEntidad.NroRuc = Convert.ToString(objTablaFiltro["Filtro_NroRuc"]);
            objEntidad.Direccion = Convert.ToString(objTablaFiltro["Filtro_Direccion"]);
            objEntidad.Destino = Convert.ToString(objTablaFiltro["Filtro_Destino"]);

            objEntidad.FlagIgv = Convert.ToInt32(objTablaFiltro["Filtro_FlagIgv"]);
            objEntidad.Placa = Convert.ToString(objTablaFiltro["Filtro_Placa"]);
            objEntidad.Placa2 = Convert.ToString(objTablaFiltro["Filtro_Placa2"]);
            objEntidad.Placa3 = Convert.ToString(objTablaFiltro["Filtro_Placa3"]);
            objEntidad.Placa4 = Convert.ToString(objTablaFiltro["Filtro_Placa4"]);
            objEntidad.KM = Convert.ToString(objTablaFiltro["Filtro_KM"]);
            objEntidad.PlacaTraslado = Convert.ToString(objTablaFiltro["Filtro_PlacaTraslado"]);
            objEntidad.Cliente = Convert.ToString(objTablaFiltro["Filtro_Cliente"]);
            objEntidad.CodTasa = Convert.ToInt32(objTablaFiltro["Filtro_CodTasa"]);

            objEntidad.CodDetalle = Convert.ToInt32(objTablaFiltro["Filtro_CodDetalle"]);
            objEntidad.CodTipoOperacion = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoOperacion"]);
            objEntidad.Partida = Convert.ToString(objTablaFiltro["Filtro_Partida"]);
            objEntidad.DireccionCompleta = Convert.ToString(objTablaFiltro["Filtro_DireccionCompleta"]);

            objEntidad.FlagRetencion = Convert.ToInt32(objTablaFiltro["Filtro_FlagRetencion"]);
            objEntidad.FlagLetra = Convert.ToInt32(objTablaFiltro["Filtro_FlagLetra"]);
            objEntidad.NotaPedido = Convert.ToInt32(objTablaFiltro["Filtro_NotaPedido"]);
            objEntidad.TasaIgv = Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]);
            objEntidad.Placa = Convert.ToString(objTablaFiltro["Filtro_Placa"]);
            objEntidad.FlagPlaca = Convert.ToInt32(objTablaFiltro["Filtro_FlagPlaca"]);
            objEntidad.FlagKM = Convert.ToInt32(objTablaFiltro["Filtro_FlagKM"]);
            objEntidad.CodDireccion = Convert.ToInt32(objTablaFiltro["Filtro_CodDireccion"]);
            objEntidad.FlagOC = Convert.ToInt32(objTablaFiltro["Filtro_FlagOC"]);
            objEntidad.Transportista = Convert.ToString(objTablaFiltro["Filtro_Transportista"]);
            objEntidad.Marca = Convert.ToString(objTablaFiltro["Filtro_Marca"]);
            objEntidad.Licencia = Convert.ToString(objTablaFiltro["Filtro_Licencia"]);
            objEntidad.NuBultos = Convert.ToString(objTablaFiltro["Filtro_NuBultos"]);
            objEntidad.Peso = Convert.ToString(objTablaFiltro["Filtro_Peso"]);
            objEntidad.CodTransportista = Convert.ToInt32(objTablaFiltro["Filtro_CodTransportista"]);
            objEntidad.CodDireccionTransportista = Convert.ToInt32(objTablaFiltro["Filtro_CodDireccionTransportista"]);
            objEntidad.DireccionTransportista = Convert.ToString(objTablaFiltro["Filtro_DireccionTrans"]);
            objEntidad.Acuenta = Convert.ToDecimal(objTablaFiltro["Filtro_Acuenta"]);
            objEntidad.AcuentaNV = Convert.ToDecimal(objTablaFiltro["Filtro_AcuentaNV"]);
            objEntidad.FlagCSIgv = Convert.ToInt32(objTablaFiltro["Filtro_FlagCSIgv"]);
            objEntidad.CodFacturaAnterior = Convert.ToInt32(objTablaFiltro["Filtro_CodFacturaAnterior"]);
            objEntidad.Correo = Convert.ToString(objTablaFiltro["Filtro_Correo"]);
            objEntidad.NroOC = Convert.ToString(objTablaFiltro["Filtro_NroOC"]);
            objEntidad.NroOperacion = Convert.ToString(objTablaFiltro["Filtro_NroOperacion"]);
            objEntidad.CodEmpleado = Convert.ToInt32(objTablaFiltro["Filtro_CodVendedor"]);
            objEntidad.FlagNotaVentaANTIGUA = Convert.ToInt32(objTablaFiltro["Filtro_NotaVentaANTIGUA"]);
            objEntidad.FlagFacturaANTIGUA = Convert.ToInt32(objTablaFiltro["Filtro_FlagFacturaANTIGUA"]);
            objEntidad.Observacion = Convert.ToString(objTablaFiltro["Filtro_Observacion"]);


            objEntidad.CodTransportista = Convert.ToInt32(objTablaFiltro["Filtro_CodTransportista"]);
            objEntidad.CodDireccionTransportista = Convert.ToInt32(objTablaFiltro["Filtro_CodDireccionTransportista"]);
            objEntidad.NroRucTransportista = Convert.ToString(objTablaFiltro["Filtro_NroRucTransportista"]);
            objEntidad.DireccionTransportista = Convert.ToString(objTablaFiltro["Filtro_DireccionTransportista"]);
            objEntidad.CodDepartamentoTransportista = Convert.ToInt32(objTablaFiltro["Filtro_CodDepartamentoTransportista"]);

            objEntidad.Transportista = Convert.ToString(objTablaFiltro["Filtro_Transportista"]);
            objEntidad.CodProvinciaTransportista = Convert.ToInt32(objTablaFiltro["Filtro_CodProvinciaTransportista"]);
            objEntidad.CodDistritoTransportista = Convert.ToInt32(objTablaFiltro["Filtro_CodDistritoTransportista"]);

            objEntidad.CodDireccionTransportista = Convert.ToInt32(objTablaFiltro["Filtro_CodDireccionTransportista"]);
            objEntidad.DireccionTransportista = Convert.ToString(objTablaFiltro["Filtro_DireccionTrans"]);


            objEntidad.CodConductor = Convert.ToInt32(objTablaFiltro["Filtro_CodConductor"]);
            objEntidad.DniConductor = Convert.ToString(objTablaFiltro["Filtro_DniConductor"]).ToUpper().Trim();
            objEntidad.NombreConductor = Convert.ToString(objTablaFiltro["Filtro_NombreConductor"]).ToUpper().Trim();

            objEntidad.UsuarioPermiso = Convert.ToString(objTablaFiltro["Filtro_UsuarioPermiso"]);
            objEntidad.ClavePermiso = Convert.ToString(objTablaFiltro["Filtro_ClavePermiso"]);
            objEntidad.ObservacionPermiso = Convert.ToString(objTablaFiltro["Filtro_ObservacionPermiso"]);
            objEntidad.ObservacionesCliente = Convert.ToString(objTablaFiltro["Filtro_ObservacionesCliente"]);
            



            objOperacion = new DocumentoVentaCabCN();

            //Inserts por tipos de documentos
            switch (objEntidad.CodTipoDoc)
            {
                case 5: //Orden de Compra
                    objEntidad.CodTipoCliente = 1; objEntidad.CodClaseCliente = 1;
                    objOperacion.F_DocumentoVentaCab_Insert_NV_OC_Clever(objEntidad); //objOperacion.F_DocumentoVentaCab_Insert_Factura_NV(objEntidad); //objOperacion.F_DocumentoVentaCab_Insert_NP_OC(objEntidad);
                    MsgError = objEntidad.MsgError; Codigo = objEntidad.CodDocumentoVenta;
                    break;
                case 16: //Nota de Venta
                    objOperacion.F_DocumentoVentaCab_Insert_NV_OC_Clever(objEntidad); //objOperacion.F_DocumentoVentaCab_Insert_Factura_NV(objEntidad); //objOperacion.F_DocumentoVentaCab_Insert_NP_OC(objEntidad);
                    MsgError = objEntidad.MsgError; Codigo = objEntidad.CodDocumentoVenta;
                    break;
                default: //Facturas y Boletas                  
                    if (objEntidad.NotaPedido == 0)
                        objOperacion.F_DocumentoVentaCab_Insert_Factura_NONV_Clever(objEntidad); //Insert Normal                           
                    else //Insert con NOTAPEDIDO NOTA VENTA, COTIZACION
                        objOperacion.F_DocumentoVentaCab_Insert_Factura_NV_Clever(objEntidad);
                 
                    MsgError = objEntidad.MsgError; Codigo = objEntidad.CodDocumentoVenta;
                    break;
            }

            //LGStockAlmacenCN ActualizacionAzure = new LGStockAlmacenCN();
            //ActualizacionAzure.Async_F_LGProductos_ActualizarStocks_Lotes_Azure();

            ////Actualiza LineaCredito Azure
            //TCCuentaCorrienteCE EntidadClienteAzure = new TCCuentaCorrienteCE();
            //EntidadClienteAzure.CodCtaCte = objEntidad.CodCliente;
            //TCCuentaCorrienteLineaCreditoCN ActualizacionSaldosClientesAzure = new TCCuentaCorrienteLineaCreditoCN();
            //ActualizacionSaldosClientesAzure.Async_F_TCCuentaCorriente_LineaCredito_Actualizar_Saldos(EntidadClienteAzure);
        }

        public void P_LlenarGrillaVacia_Detalle()
        {
            DataTable dta_consultadetalle = null;
            DataRow dtr_filadetalle = null;

            dta_consultadetalle = new DataTable();

            dta_consultadetalle.Columns.Add("CodDetalle", typeof(string));
            dta_consultadetalle.Columns.Add("CodArticulo", typeof(string));
            dta_consultadetalle.Columns.Add("CodigoProducto", typeof(string));
            dta_consultadetalle.Columns.Add("Producto", typeof(string));
            dta_consultadetalle.Columns.Add("Cantidad", typeof(string));
            dta_consultadetalle.Columns.Add("UM", typeof(string));
            dta_consultadetalle.Columns.Add("Precio", typeof(string));
            dta_consultadetalle.Columns.Add("Importe", typeof(string));
            dta_consultadetalle.Columns.Add("CodDetalleOC", typeof(string));
            dta_consultadetalle.Columns.Add("Acuenta", typeof(string));
            dta_consultadetalle.Columns.Add("CodTipoDoc", typeof(string));
            dta_consultadetalle.Columns.Add("P1", typeof(string));
            dta_consultadetalle.Columns.Add("P2", typeof(string));
            dta_consultadetalle.Columns.Add("P3", typeof(string));
            dta_consultadetalle.Columns.Add("FlagGratuito", typeof(string));
            dta_consultadetalle.Columns.Add("Gratuito", typeof(string));
            

            dtr_filadetalle = dta_consultadetalle.NewRow();

            dtr_filadetalle[0] = "";
            dtr_filadetalle[1] = "";
            dtr_filadetalle[2] = "";
            dtr_filadetalle[3] = "";
            dtr_filadetalle[4] = "";
            dtr_filadetalle[5] = "";
            dtr_filadetalle[6] = "";
            dtr_filadetalle[7] = "";
            dtr_filadetalle[8] = "";
            dtr_filadetalle[9] = "";
            dtr_filadetalle[10] = "";

            dta_consultadetalle.Rows.Add(dtr_filadetalle);

            grvDetalleArticulo.DataSource = dta_consultadetalle;
            grvDetalleArticulo.DataBind();
        }

        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_Serie"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            objEntidad.CodVendedor = Convert.ToInt32(objTablaFiltro["Filtro_CodVendedor"]);

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
                objEntidad.CodCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);
            else
                objEntidad.CodCliente = 0;

            if (Convert.ToInt32(objTablaFiltro["Filtro_chkPlaca"]) == 1)
                objEntidad.Placa = Convert.ToString(objTablaFiltro["Filtro_Placa"]);
            else
                objEntidad.Placa = "";

            objOperacion = new DocumentoVentaCabCN();

            dta_consulta = objOperacion.F_DocumentoVentaCab_Listar(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();
        }

        public void P_AnularRegistro(Hashtable objTablaFiltro, ref String Mensaje)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.ObservacionAnulacion = Convert.ToString(objTablaFiltro["Filtro_ObservacionAnulacion"]);

            objOperacion = new DocumentoVentaCabCN();

            objOperacion.F_DocumentoVentaCab_Anulacion(objEntidad);

            Mensaje = objEntidad.MsgError;

            LGStockAlmacenCN ActualizacionAzure = new LGStockAlmacenCN();
            ActualizacionAzure.Async_F_LGProductos_ActualizarStocks_Lotes_Azure();

            TCCuentaCorrienteCE EntidadClienteAzure = new TCCuentaCorrienteCE();
            EntidadClienteAzure.CodCtaCte = objEntidad.CodCliente;
            TCCuentaCorrienteLineaCreditoCN ActualizacionSaldosClientesAzure = new TCCuentaCorrienteLineaCreditoCN();
            ActualizacionSaldosClientesAzure.Async_F_TCCuentaCorriente_LineaCredito_Actualizar_Saldos(EntidadClienteAzure);
        }

        public void P_TipoCambio(Hashtable objTablaFiltro, ref Decimal TC)
        {

            TCTipoCambioCE objEntidad = null;
            TCTipoCambioCN objOperacion = null;

            objEntidad = new TCTipoCambioCE();
            objEntidad.Fecha = Convert.ToDateTime(objTablaFiltro["Filtro_Emision"]);

            objOperacion = new TCTipoCambioCN();

            DataTable dta_consulta = null;

            dta_consulta = objOperacion.F_TCTipoCambio_Select(objEntidad);

            if (dta_consulta.Rows.Count == 0)
                TC = 0;
            else
                TC = Convert.ToDecimal(dta_consulta.Rows[0][0]);


        }

        public void P_VerUltimoPrecio(Hashtable objTablaFiltro, ref GridView GrillaUltimosPrecios)
        {

            LGProductosCE objEntidad = null;
            LGProductosCN objOperacion = null;

            objEntidad = new LGProductosCE();
            objEntidad.CodProducto = Convert.ToInt32(objTablaFiltro["Filtro_CodProducto"]);
            objEntidad.CodTipoOperacion = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoOperacion"]);
            objEntidad.CodCtaCte = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            int MaxRows = Convert.ToInt32(objTablaFiltro["Filtro_Top"]); //Agutierrez

            objOperacion = new LGProductosCN();

            DataTable dta_consulta = null;

            dta_consulta = objOperacion.F_LGProductos_UltimoPrecio(objEntidad, MaxRows);
            GrillaUltimosPrecios.DataSource = dta_consulta;
            GrillaUltimosPrecios.DataBind();
        }

        public void P_ActualizarPrecios(Hashtable objTablaFiltro, ref String MsgError)
        {
            DocumentoVentaDetCE objEntidad = null;
            DocumentoVentaDetCN objOperacion = null;

            objEntidad = new DocumentoVentaDetCE();

            objEntidad.CodDetDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodDetDocumentoVenta"]);
            objEntidad.Precio = Convert.ToDecimal(objTablaFiltro["Filtro_Precio"]);
            objEntidad.Cantidad = Convert.ToDecimal(objTablaFiltro["Filtro_Cantidad"]);
            objEntidad.Descripcion = Convert.ToString(objTablaFiltro["Filtro_Descripcion"]);
            objEntidad.Flag = Convert.ToInt32(objTablaFiltro["Filtro_Flag"]);

            objOperacion = new DocumentoVentaDetCN();

            objOperacion.F_TemporalFacturacionDet_Update(objEntidad);

            MsgError = objEntidad.MsgError;
        }
        
        public void P_PrecioMoneda(Hashtable objTablaFiltro, ref GridView grillaPrecioMoneda)
        {

            LGProductosCE objEntidad = null;
            LGProductosCN objOperacion = null;

            objEntidad = new LGProductosCE();
            objEntidad.CodProducto = Convert.ToInt32(objTablaFiltro["Filtro_CodProducto"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
            objEntidad.FechaRegistro = Convert.ToDateTime(objTablaFiltro["Filtro_Fecha"]);

            objOperacion = new LGProductosCN();

            grillaPrecioMoneda.DataSource = objOperacion.F_LGProductos_VerPrecio_Moneda(objEntidad);
            grillaPrecioMoneda.DataBind();

        }

        public void P_EliminarRegistro(Hashtable objTablaFiltro, ref String Mensaje)
        {

            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();


            objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);

            objOperacion = new DocumentoVentaCabCN();

            objOperacion.F_DocumentoVentaCab_Eliminacion(objEntidad);

            Mensaje = objEntidad.MsgError;

            LGStockAlmacenCN ActualizacionAzure = new LGStockAlmacenCN();
            ActualizacionAzure.Async_F_LGProductos_ActualizarStocks_Lotes_Azure();

            TCCuentaCorrienteCE EntidadClienteAzure = new TCCuentaCorrienteCE();
            EntidadClienteAzure.CodCtaCte = objEntidad.CodCliente;
            TCCuentaCorrienteLineaCreditoCN ActualizacionSaldosClientesAzure = new TCCuentaCorrienteLineaCreditoCN();
            ActualizacionSaldosClientesAzure.Async_F_TCCuentaCorriente_LineaCredito_Actualizar_Saldos(EntidadClienteAzure);
        }

        public void P_FacturacionOC(Hashtable objTablaFiltro, ref GridView GrillaOC)
        {

            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.SerieDoc = "";
            objEntidad.NumeroDoc = "";

            objOperacion = new DocumentoVentaCabCN();
            DataTable dta_consulta = null;

            dta_consulta = objOperacion.F_DocumentoVentaCab_OCXFacturar(objEntidad);

            GrillaOC.DataSource = dta_consulta;
            GrillaOC.DataBind();
        }

        public void P_Devolucion(Hashtable objTablaFiltro, ref String MsgError)
        {

            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            String XmlDetalle = "";

            objEntidad = new DocumentoVentaCabCE();

            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_XmlDetalle"].ToString());

            foreach (dynamic item in jArr2)
            {
                XmlDetalle = XmlDetalle + "<D ";
                XmlDetalle = XmlDetalle + " CodDetalle = '" + item.CodDetalle + "'";
                XmlDetalle = XmlDetalle + " CodArticulo = '" + item.CodArticulo + "'";
                XmlDetalle = XmlDetalle + " Cantidad = '" + item.Cantidad + "'";
                XmlDetalle = XmlDetalle + " CodUndMedida = '" + item.CodUndMedida + "'";
                XmlDetalle = XmlDetalle + " Costo = '" + item.Costo + "'";
                XmlDetalle = XmlDetalle + " CostoUnitario = '" + item.CostoUnitario + "'";
                XmlDetalle = XmlDetalle + " SerieDoc = '" + item.SerieDoc + "'";
                XmlDetalle = XmlDetalle + " NumeroDoc = '" + item.NumeroDoc + "'";
                XmlDetalle = XmlDetalle + " />";
            }

            XmlDetalle = "<R><XmlLC> " + XmlDetalle + "</XmlLC></R>";

            objEntidad.XmlDetalle = XmlDetalle;

            objEntidad.CodEmpresa = 3;
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.TasaIgv = Convert.ToDecimal(objTablaFiltro["Filtro_TasaIgv"]);
            objEntidad.CodTasa = Convert.ToInt32(objTablaFiltro["Filtro_CodTasa"]);
            objEntidad.TipoCambio = Convert.ToDecimal(objTablaFiltro["Filtro_TipoCambio"]);
            objEntidad.CodMoneda = Convert.ToInt32(objTablaFiltro["Filtro_CodMoneda"]);
            objEntidad.CodCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);
            objEntidad.CodUsuario = Convert.ToInt32((Session["CodUsuario"]));
            objEntidad.CodTipoOperacion = 1;

            objOperacion = new DocumentoVentaCabCN();

            objOperacion.F_DocumentoVentaCab_DevolucionOC(objEntidad);

            MsgError = objEntidad.MsgError;

        }

        public String F_ImprimirFacturaTicket_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_json_factura = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                str_json_factura = P_ImprimirFacturaTicket(obj_parametros, ref str_mensaje_operacion);
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
                str_json_factura;


            return str_resultado;

        }

        public string P_ImprimirFacturaTicket(Hashtable objTablaFiltro, ref String Mensaje)
        {
            DocumentoVentaCabCE objEntidadFactura = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacionFactura = new DocumentoVentaCabCN();

            objEntidadFactura.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);
            objEntidadFactura.IP = GetIP().Trim();
            DataTable dtTabla = objOperacionFactura.F_DocumentoVentaCab_ImpresionFlagTicket_Insert(objEntidadFactura);

            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dtTabla);
            return JSONresult;
        }

        public void P_FacturacionNV(Hashtable objTablaFiltro, ref GridView GrillaOC)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);   
            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_SerieDoc"]);

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

            objOperacion = new DocumentoVentaCabCN();
            DataTable dta_consulta = null;

            dta_consulta = objOperacion.F_DocumentoVentaCab_NVXFacturar(objEntidad);

            GrillaOC.DataSource = dta_consulta;
            GrillaOC.DataBind();
        }

        public void P_FacturacionCT(Hashtable objTablaFiltro, ref GridView GrillaOC)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.Desde = Convert.ToDateTime(objTablaFiltro["Filtro_Desde"]);
            objEntidad.Hasta = Convert.ToDateTime(objTablaFiltro["Filtro_Hasta"]);
            objEntidad.NumeroDoc = Convert.ToString(objTablaFiltro["Filtro_NumeroDoc"]);
            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_SerieDoc"]);

            objOperacion = new DocumentoVentaCabCN();
            DataTable dta_consulta = null;

            dta_consulta = objOperacion.F_DocumentoVentaCab_CTXFacturar(objEntidad);

            GrillaOC.DataSource = dta_consulta;
            GrillaOC.DataBind();
        }
        
        public String F_ReenvioMail_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_json_factura = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                str_mensaje_operacion = F_ReenvioMail(obj_parametros, ref str_mensaje_operacion);
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

        public string F_ReenvioMail(Hashtable objTablaFiltro, ref String Mensaje)
        {
            DocumentoVentaCabCE objEntidadFactura = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacionFactura = new DocumentoVentaCabCN();

            objEntidadFactura.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);
            objEntidadFactura = objOperacionFactura.F_DocumentoVentaCab_ReenvioMail(objEntidadFactura);

            Mensaje = objEntidadFactura.MsgError;

            return Mensaje;
        }
        
        public void P_ActualizarDetalle(Hashtable objTablaFiltro, ref String MsgError)
        {
            DocumentoVentaDetCE objEntidad = null;
            DocumentoVentaDetCN objOperacion = null;

            objEntidad = new DocumentoVentaDetCE();

            objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodDocumentoVenta"]);
            objEntidad.FlagIgv = Convert.ToInt32(objTablaFiltro["Filtro_FlagIgv"]);

            objOperacion = new DocumentoVentaDetCN();

            objOperacion.F_TemporalFacturacionDet_Actualizar(objEntidad);

            MsgError = objEntidad.MsgError;
        }

        public void P_ReemplazarCotizacion(Hashtable objTablaFiltro, ref String SerieDoc, ref Int32 Codigo, ref Int32 CodCliente,
                    ref Int32 CodMoneda, ref String Emision, ref String Vencimiento, ref String Atencion, ref String Referencia,
                    ref String Cliente, ref String NumeroDoc, ref Int32 CodProformaAnterior, ref Int32 FlagConCodigo,ref Int32 FlagOC,
                     ref Int32 FlagPlaca, ref Int32 FlagKM)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodProforma = Convert.ToInt32(objTablaFiltro["Filtro_CodProforma"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new DocumentoVentaCabCN();
            DataTable dtTabla = null;

            dtTabla = objOperacion.F_ProformaCab_Reemplazar(objEntidad);

            if (dtTabla.Rows.Count > 0)
            {
                Atencion = dtTabla.Rows[0]["Atencion"].ToString();
                Codigo = Convert.ToInt32(dtTabla.Rows[0]["Codigo"]);
                CodCliente = Convert.ToInt32(dtTabla.Rows[0]["CodCliente"]);
                CodMoneda = Convert.ToInt32(dtTabla.Rows[0]["CodMoneda"]);
                Referencia = Convert.ToString(dtTabla.Rows[0]["Referencia"]);
                NumeroDoc = Convert.ToString(dtTabla.Rows[0]["NumeroDoc"]);
                Emision = Convert.ToString(dtTabla.Rows[0]["Emision"]);
                Vencimiento = Convert.ToString(dtTabla.Rows[0]["Vencimiento"]);
                SerieDoc = Convert.ToString(dtTabla.Rows[0]["SerieDoc"]);
                Cliente = Convert.ToString(dtTabla.Rows[0]["Cliente"]);
                CodProformaAnterior = Convert.ToInt32(dtTabla.Rows[0]["CodProformaAnterior"]);
                FlagOC = Convert.ToInt32(dtTabla.Rows[0]["FlagOC"]);
                FlagPlaca = Convert.ToInt32(dtTabla.Rows[0]["FlagPlaca"]);
                FlagKM = Convert.ToInt32(dtTabla.Rows[0]["FlagKM"]);
            }
        }

        public void P_DatosFactura(Hashtable objTablaFiltro, ref String Emision, ref String Vencimiento,
                            ref Int32 FormaPago, ref String Placa1, ref String Placa2, ref String Placa3, ref String Placa4,
                            ref Int32 CodTraslado, ref String SerieGuia, ref String NumeroGuia, ref String Fecha,
                            ref String Destino, ref String DireccionTrans, ref Int32 CodTransportista, ref String Transportista,
                            ref String DireccionFactura, ref Int32 CodDireccionTransportista, ref String KM,
                            ref String OrdenCompra, ref String Recepcion, ref Int32 FlagComisionable, ref Int32 CodEmpresa,
                            ref Int32 FlagOC, ref Int32 FlagPlaca, ref Int32 FlagKM, ref String observacionCliente, ref Int32 CodCtaCte, ref Int32 CodVendedor,
            ref String DistritoTrans, ref String Placa, ref String Marca, ref String Licencia, ref Int32 Bulto, ref Int32 Peso,
                ref String NroConductor, ref String Conductor, ref Int32 CodConductor, ref String NombreAgencia, ref String GuiaAgencia, ref String ClaveAgencia, ref Int32 Motorizado)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();
            objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodDocumentoventa"]);
            
            objOperacion = new DocumentoVentaCabCN();

            DataTable dta_consulta = null;

            dta_consulta = objOperacion.F_DocumentoVentaCab_Datos(objEntidad);

            if (dta_consulta.Rows.Count > 0)
            {
                Emision = Convert.ToString(dta_consulta.Rows[0]["FechaEmision"]);
                Vencimiento = Convert.ToString(dta_consulta.Rows[0]["FechaVencimiento"]);
                FormaPago = Convert.ToInt32(dta_consulta.Rows[0]["CodFormaPago"]);
                Placa1 = Convert.ToString(dta_consulta.Rows[0]["Placa"]);
                Placa2 = Convert.ToString(dta_consulta.Rows[0]["Placa2"]);
                Placa3 = Convert.ToString(dta_consulta.Rows[0]["Placa3"]);
                Placa4 = Convert.ToString(dta_consulta.Rows[0]["Placa4"]);
                KM = Convert.ToString(dta_consulta.Rows[0]["KM"]);
                DireccionFactura = Convert.ToString(dta_consulta.Rows[0]["DireccionFactura"]);
                OrdenCompra = Convert.ToString(dta_consulta.Rows[0]["OrdenCompra"]);
                Recepcion = Convert.ToString(dta_consulta.Rows[0]["Recepcion"]);
                FlagComisionable = Convert.ToInt32(dta_consulta.Rows[0]["FlagComisionable"]);
                CodEmpresa = Convert.ToInt32(dta_consulta.Rows[0]["CodEmpresa"]);
                FlagOC = Convert.ToInt32(dta_consulta.Rows[0]["FlagOC"]);
                FlagPlaca = Convert.ToInt32(dta_consulta.Rows[0]["FlagPlaca"]);
                FlagKM = Convert.ToInt32(dta_consulta.Rows[0]["FlagKM"]);
                observacionCliente = Convert.ToString(dta_consulta.Rows[0]["ObservacionesCliente"]);
                CodCtaCte = Convert.ToInt32(dta_consulta.Rows[0]["CodCtaCte"]);
                CodVendedor = Convert.ToInt32(dta_consulta.Rows[0]["CodVendedor"]);
                NombreAgencia = Convert.ToString(dta_consulta.Rows[0]["NombreAgencia"]);
                GuiaAgencia = Convert.ToString(dta_consulta.Rows[0]["GuiaAgencia"]);
                ClaveAgencia = Convert.ToString(dta_consulta.Rows[0]["ClaveAgencia"]);
                Motorizado = Convert.ToInt32(dta_consulta.Rows[0]["Motorizado"]);
                try
                {
                    CodTraslado = Convert.ToInt32(dta_consulta.Rows[0]["CodTraslado"]);
                    SerieGuia = Convert.ToString(dta_consulta.Rows[0]["SerieDoc"]);
                    NumeroGuia = Convert.ToString(dta_consulta.Rows[0]["NumeroDoc"]);
                    Fecha = Convert.ToString(dta_consulta.Rows[0]["Fecha"]);
                    Destino = Convert.ToString(dta_consulta.Rows[0]["Destino"]);
                    try { DireccionTrans = Convert.ToString(dta_consulta.Rows[0]["DireccionTransportista"]); }
                    catch (Exception) { }
                    try { CodTransportista = Convert.ToInt32(dta_consulta.Rows[0]["CodTransportista"]); }
                    catch (Exception) { }
                    try { CodDireccionTransportista = Convert.ToInt32(dta_consulta.Rows[0]["CodDireccionTrans"]); }
                    catch (Exception) { }
                    try { Transportista = Convert.ToString(dta_consulta.Rows[0]["Transportista"]); }
                    catch (Exception) { }

                    try { DistritoTrans = Convert.ToString(dta_consulta.Rows[0]["DistritoTrans"]); }
                    catch (Exception) { }
                    try { Placa = Convert.ToString(dta_consulta.Rows[0]["PlacaTransportista"]); }
                    catch (Exception) { }
                    try { Marca = Convert.ToString(dta_consulta.Rows[0]["Marca"]); }
                    catch (Exception) { }
                    try { CodConductor = Convert.ToInt32(dta_consulta.Rows[0]["CodConductor"]); }
                    catch (Exception) { }
                    try { Conductor = Convert.ToString(dta_consulta.Rows[0]["Conductor"]); }
                    catch (Exception) { }
                    try { NroConductor = Convert.ToString(dta_consulta.Rows[0]["NroConductor"]); }
                    catch (Exception) { }
                    try { Peso = Convert.ToInt32(dta_consulta.Rows[0]["Peso"]); }
                    catch (Exception) { }
                    try { Bulto = Convert.ToInt32(dta_consulta.Rows[0]["NroBultos"]); }
                    catch (Exception) { }
                    try { Licencia = Convert.ToString(dta_consulta.Rows[0]["Licencia"]); }
                    catch (Exception) { }
                }
                catch (Exception exxx)
                { }

            }
        }

        public void P_EdicionFactura(Hashtable objTablaFiltro, ref String MsgError)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodDocumentoVenta"]);
            objEntidad.CodCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodCliente"]);
            objEntidad.FechaEmision = Convert.ToDateTime(objTablaFiltro["Filtro_Emision"]);
            objEntidad.FechaVencimiento = Convert.ToDateTime(objTablaFiltro["Filtro_Vencimiento"]);
            objEntidad.CodFormaPago = Convert.ToInt32(objTablaFiltro["Filtro_CodFormaPago"]);
            objEntidad.Placa = Convert.ToString(objTablaFiltro["Filtro_Placa1"]);
            objEntidad.Placa2 = Convert.ToString(objTablaFiltro["Filtro_Placa2"]);
            objEntidad.Placa3 = Convert.ToString(objTablaFiltro["Filtro_Placa3"]);
            objEntidad.Placa4 = Convert.ToString(objTablaFiltro["Filtro_Placa4"]);
            objEntidad.KM = Convert.ToString(objTablaFiltro["Filtro_KM"]);
            objEntidad.NroOperacion = Convert.ToString(objTablaFiltro["Filtro_NroOperacion"]);
            objEntidad.FlagGuia = Convert.ToInt32(objTablaFiltro["Filtro_FlagGuia"]);
            objEntidad.CodTraslado = Convert.ToInt32(objTablaFiltro["Filtro_CodTraslado"]);
            objEntidad.SerieGuia = Convert.ToString(objTablaFiltro["Filtro_SerieGuia"]);
            objEntidad.NumeroGuia = Convert.ToString(objTablaFiltro["Filtro_NumeroGuia"]);
            objEntidad.FechaTraslado = Convert.ToDateTime(objTablaFiltro["Filtro_FechaTraslado"]);
            objEntidad.Destino = Convert.ToString(objTablaFiltro["Filtro_Destino"]);
            objEntidad.DireccionTraslado = Convert.ToString(objTablaFiltro["Filtro_DireccionTraslado"]);
            objEntidad.DireccionTransportista = Convert.ToString(objTablaFiltro["Filtro_DireccionTransportista"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);
            objEntidad.Recepcion = Convert.ToDateTime(objTablaFiltro["Filtro_Recepcion"]);
            objEntidad.FlagComisionable = Convert.ToInt32(objTablaFiltro["Filtro_FlagComisionable"]);
            objEntidad.Observacion = Convert.ToString(objTablaFiltro["Filtro_Observacion"]);
            objEntidad.FlagPlaca = Convert.ToInt32(objTablaFiltro["Filtro_FlagPlaca"]);
            objEntidad.FlagKM = Convert.ToInt32(objTablaFiltro["Filtro_FlagKM"]);
            objEntidad.FlagOC = Convert.ToInt32(objTablaFiltro["Filtro_FlagOC"]);
            objEntidad.NroOC = Convert.ToString(objTablaFiltro["Filtro_NroOC"]);

            objEntidad.CodVendedor = Convert.ToInt32(objTablaFiltro["Filtro_CodEmpleado"]);


            objEntidad.CodTransportista = Convert.ToInt32(objTablaFiltro["Filtro_CodTransportista"]);
            objEntidad.CodDireccionTransportista = Convert.ToInt32(objTablaFiltro["Filtro_CodDireccionTransportista"]);
            objEntidad.DireccionTransportista = Convert.ToString(objTablaFiltro["Filtro_DireccionTransportista"]);
            objEntidad.NroRucTransportista = Convert.ToString(objTablaFiltro["Filtro_NroRucTransportista"]);
            objEntidad.Transportista = Convert.ToString(objTablaFiltro["Filtro_Transportista"]);
            objEntidad.CodDepartamentoTransportista = Convert.ToInt32(objTablaFiltro["Filtro_CodDepartamentoTransportista"]);
            objEntidad.CodProvinciaTransportista = Convert.ToInt32(objTablaFiltro["Filtro_CodProvinciaTransportista"]);
            objEntidad.CodDistritoTransportista = Convert.ToInt32(objTablaFiltro["Filtro_CodDistritoTransportista"]);
           
            objEntidad.Recepcion = Convert.ToDateTime(objTablaFiltro["Filtro_Recepcion"]);
            objEntidad.FlagComisionable = Convert.ToInt32(objTablaFiltro["Filtro_FlagComisionable"]);
            objEntidad.Observacion = Convert.ToString(objTablaFiltro["Filtro_Observacion"]);
            objEntidad.FlagPlaca = Convert.ToInt32(objTablaFiltro["Filtro_FlagPlaca"]);
            objEntidad.FlagKM = Convert.ToInt32(objTablaFiltro["Filtro_FlagKM"]);
            objEntidad.FlagOC = Convert.ToInt32(objTablaFiltro["Filtro_FlagOC"]);
            objEntidad.NuBultos = Convert.ToString(objTablaFiltro["Filtro_Bulto"]);
            objEntidad.Motorizado = Convert.ToInt32(objTablaFiltro["Filtro_Motorizado"]);
            objEntidad.NombreAgencia = Convert.ToString(objTablaFiltro["Filtro_NombreAgencia"]);
            objEntidad.GuiaAgencia = Convert.ToString(objTablaFiltro["Filtro_GuiaAgencia"]);
            objEntidad.ClaveAgencia = Convert.ToString(objTablaFiltro["Filtro_ClaveAgencia"]);
            objEntidad.PlacaTraslado = Convert.ToString(objTablaFiltro["Filtro_PlacaTraslado"]);
            objEntidad.Marca = Convert.ToString(objTablaFiltro["Filtro_Marca"]);
            objEntidad.Licencia = Convert.ToString(objTablaFiltro["Filtro_Licencia"]);
            objEntidad.Peso = Convert.ToString(objTablaFiltro["Filtro_Peso"]);
            objEntidad.CodConductor = Convert.ToInt32(objTablaFiltro["Filtro_CodConductor"]);
            objEntidad.CodEmpleado = Convert.ToInt32(objTablaFiltro["Filtro_CodEmpleado"]);

            objOperacion = new DocumentoVentaCabCN();

            objOperacion.F_EdicionFactura_Clever(objEntidad);

            MsgError = objEntidad.MsgError;
        }
        
        public void P_ValidarFactura(Hashtable objTablaFiltro, ref String Mensaje)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodDocumentoVenta"]);

            objOperacion = new DocumentoVentaCabCN();

            Mensaje = objOperacion.F_DocumentoVentaCab_Validar_Factura(objEntidad).MsgError;
        }

        public void P_ReemplazarFactura(Hashtable objTablaFiltro, ref String NroRuc, ref Int32 Codigo, ref Int32 CodCliente,
        ref Int32 CodMoneda, ref Int32 CodDepartamento, ref Int32 CodProvincia, ref Int32 CodDistrito, ref String Direccion,
        ref String Distrito, ref String Cliente, ref Int32 CodFormaPago, ref Int32 CodFacturaAnterior, ref Int32 CodTransportista,
        ref String Transportista, ref String Placa, ref String NroLicencia, ref String NumGuia, ref String Destino,
        ref String FechaTraslado, ref String NumeroDoc, ref Int32 CodVendedor, ref String FechaEmision, ref String FechaVencimiento, ref String SerieDoc,
        ref String MarcaVehiculo, ref String DireccionTrans, ref String NroBultos, ref String Peso, ref String PlacaVehiculo)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            objEntidad = new DocumentoVentaCabCE();

            objEntidad.CodDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);
            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoDoc"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new DocumentoVentaCabCN();
            DataTable dtTabla = null;

            dtTabla = objOperacion.F_DocumentoVentaCab_Reemplazar(objEntidad);

            if (dtTabla.Rows.Count > 0)
            {
                NroRuc = dtTabla.Rows[0]["NroRuc"].ToString();
                Codigo = Convert.ToInt32(dtTabla.Rows[0]["Codigo"]);
                CodCliente = Convert.ToInt32(dtTabla.Rows[0]["CodCtaCte"]);
                CodMoneda = Convert.ToInt32(dtTabla.Rows[0]["CodMoneda"]);
                CodDepartamento = Convert.ToInt32(dtTabla.Rows[0]["CodDepartamento"]);
                CodProvincia = Convert.ToInt32(dtTabla.Rows[0]["CodProvincia"]);
                CodDistrito = Convert.ToInt32(dtTabla.Rows[0]["CodDistrito"]);
                Direccion = Convert.ToString(dtTabla.Rows[0]["Direccion"]);
                Distrito = Convert.ToString(dtTabla.Rows[0]["Distrito"]);
                Cliente = Convert.ToString(dtTabla.Rows[0]["Cliente"]);
                CodFormaPago = Convert.ToInt32(dtTabla.Rows[0]["CodFormaPago"]);
                CodFacturaAnterior = Convert.ToInt32(dtTabla.Rows[0]["CodFacturaAnterior"]);
                FechaTraslado = Convert.ToString(dtTabla.Rows[0]["FechaTraslado"]);
                CodTransportista = Convert.ToInt32(dtTabla.Rows[0]["CodTransportista"]);
                Transportista = Convert.ToString(dtTabla.Rows[0]["Transportista"]);
                Placa = Convert.ToString(dtTabla.Rows[0]["Placa"]);
                NroLicencia = Convert.ToString(dtTabla.Rows[0]["NroLicencia"]);
                NumGuia = Convert.ToString(dtTabla.Rows[0]["NumGuia"]);
                Destino = Convert.ToString(dtTabla.Rows[0]["Destino"]);
                SerieDoc = Convert.ToString(dtTabla.Rows[0]["SerieDoc"]);
                NumeroDoc = Convert.ToString(dtTabla.Rows[0]["NumeroDoc"]);
                CodVendedor = Convert.ToInt32(dtTabla.Rows[0]["CodVendedor"]);
                FechaEmision = Convert.ToString(dtTabla.Rows[0]["FechaEmision"]);
                FechaVencimiento = Convert.ToString(dtTabla.Rows[0]["FechaVencimiento"]);
                MarcaVehiculo = Convert.ToString(dtTabla.Rows[0]["MarcaVehiculo"]);
                DireccionTrans = Convert.ToString(dtTabla.Rows[0]["DireccionTraslado"]);
                NroBultos = Convert.ToString(dtTabla.Rows[0]["NroBultos"]);
                Peso = Convert.ToString(dtTabla.Rows[0]["Peso"]);
                PlacaVehiculo = Convert.ToString(dtTabla.Rows[0]["PlacaVehiculo"]);
            }
        }
        
        public void P_FlagGratuito(Hashtable objTablaFiltro, ref String MsgError)
        {
            DocumentoVentaDetCE objEntidad = null;
            DocumentoVentaDetCN objOperacion = null;

            objEntidad = new DocumentoVentaDetCE();

            objEntidad.CodDetDocumentoVenta = Convert.ToInt32(objTablaFiltro["Filtro_CodDetDocumentoVenta"]);

            objOperacion = new DocumentoVentaDetCN();

            objOperacion.F_FlagGratuito_Update(objEntidad);

            MsgError = objEntidad.MsgError;
        }


        public void P_Series_Guia(Hashtable objTablaFiltro, ref DropDownList ddl_serieguia)
        {
            TCCorrelativoCE objEntidad = null;
            TCCorrelativoCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new TCCorrelativoCE();

            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodDoc"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);

            objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_serieguia.Items.Clear();

            ddl_serieguia.DataSource = dta_consulta;
            ddl_serieguia.DataTextField = "SerieDoc";
            ddl_serieguia.DataValueField = "CodSerie";
            ddl_serieguia.DataBind();
        }
                
        private string GetIP()
        {
            string visitorIPAddress = "";
            string IPHost = Dns.GetHostName();
            string IP = Dns.GetHostByName(IPHost).AddressList[0].ToString();
            return IP;
        }
        
        [WebMethod]
        //lista los almacenes que se van a mostrar en el grid de stocks
        public static jqTCAlmacenResult F_Inicializar_Tabla_Almacenes_Stocks_NET()
        {
            jqTCAlmacenResult data = new jqTCAlmacenResult();
            data.rows = new List<TCAlmacenCE>();
            TCAlmacenCE objEntidad = new TCAlmacenCE();
            TCAlmacenCN objOperacion = new TCAlmacenCN();
            objEntidad.Clave = "";
            try
            {
                DataTable dtb = objOperacion.F_TCAlmacenesExternos_Listar(1);
                foreach (DataRow i in dtb.Rows)
                {
                    //if (int.Parse(i["CodEmpresa"].ToString()) == 3 & int.Parse(i["CodAlmacen"].ToString()) == 2)
                    //{ } else
                    {
                        TCAlmacenCE newpr = new TCAlmacenCE();
                        newpr.Clave = i["Clave"].ToString();
                        newpr.Empresa = i["DscEmpresa"].ToString();
                        newpr.DscAlmacen = i["DscAlmacen"].ToString();
                        data.rows.Add(newpr);
                    }
                }
            }
            catch (Exception ex)
            { }
            finally
            { objOperacion = null; }

            return data;
        }
        public class jqTCAlmacenResult
        {
            public String msg { get; set; }
            public String ID_Imagen { get; set; }
            public int total { get; set; }
            public List<TCAlmacenCE> rows { get; set; }
        }

        [WebMethod]
        //busca el stock del almacen especificado //LOGICA VIEJA
        public static jqTCAlmacenStockResult F_Consulta_Stock_NET(string CodigoProducto, string Marca)
        {
            jqTCAlmacenStockResult data = new jqTCAlmacenStockResult();
            data.rows = new List<TCAlmacenCE>();
            TCAlmacenCE objEntidad = new TCAlmacenCE();
            TCAlmacenCN objOperacion = new TCAlmacenCN();

            //primero se buscan los datos de conexion faltantes
            try
            {
                TCAlmacenCE par = new TCAlmacenCE();
                par.CodigoProducto = CodigoProducto;
                par.Marca = Marca;
                DataTable dtDatos = (new TCAlmacenCN()).F_Consulta_Stock_Almacen_Externo(par);


                foreach (DataRow i in dtDatos.Rows)
                {
                    TCAlmacenCE newpr = new TCAlmacenCE();
                    newpr.Empresa = i["Empresa"].ToString();
                    newpr.Almacen = i["Almacen"].ToString();
                    newpr.Clave = newpr.Empresa.Replace(" ", "") + "_" + newpr.Almacen.Replace(" ", "");
                    newpr.Stock = decimal.Parse(i["Stock"].ToString());
                    data.rows.Add(newpr);
                }


            }
            catch (Exception ex)
            { }
            finally
            { objOperacion = null; }

            return data;
        }

        [WebMethod]
        public static jqTCAlmacenStockResult F_Consulta_Stock_Azure_NET(int CodProductoAzure, string CodigoInterno)
        {
            jqTCAlmacenStockResult data = new jqTCAlmacenStockResult();
            data.rows = new List<TCAlmacenCE>();
            TCAlmacenCE objEntidad = new TCAlmacenCE();
            TCAlmacenCN objOperacion = new TCAlmacenCN();

            //primero se buscan los datos de conexion faltantes
            try
            {
                TCAlmacenCE par = new TCAlmacenCE();
                DataTable dtAlmacenes = (new TCAlmacenCN()).F_TCAlmacenesExternos_Listar(0);
                DataTable dtStocksAzure = (new TCAlmacenCN()).F_Consulta_Stock_Azure(CodProductoAzure, CodigoInterno);
                foreach (DataRow i in dtAlmacenes.Rows)
                {
                    if (i["FlagAlmacenLocal"].ToString() == "0")
                    {
                        TCAlmacenCE newpr = new TCAlmacenCE();
                        newpr.Empresa = i["DscEmpresa"].ToString();
                        newpr.Almacen = i["DscAlmacen"].ToString();
                        newpr.Clave = newpr.Empresa.Replace(" ", "") + "_" + newpr.Almacen.Replace(" ", "");
                        newpr.ConsultadoSN = 0;
                        newpr.Stock = 0;
                        if (dtStocksAzure.Rows.Count > 0)
                        {
                            newpr.ConsultadoSN = 1;
                            newpr.Stock = decimal.Parse(dtStocksAzure.Rows[0][i["NombreClaveAzure"].ToString()].ToString());
                        }
                        data.rows.Add(newpr);
                    }
                }


            }
            catch (Exception ex)
            { }
            finally
            { objOperacion = null; }

            return data;
        }
        public class jqTCAlmacenStockResult
        {
            public String msg { get; set; }
            public String ID_Imagen { get; set; }
            public int total { get; set; }
            public List<TCAlmacenCE> rows { get; set; }
        }

        [WebMethod]
        //busca el stock del almacen especificado
        public static jqProformasResult F_Consulta_Cotizaciones_Pendientes_NET(int CodAlmacen)
        {
            jqProformasResult data = new jqProformasResult();
            ProformaCabCE par = new ProformaCabCE() { CodEmpresa = 3, CodAlmacen = CodAlmacen, CodEstado = 6 };
            data.rows = (new ProformaCabCN()).F_ProformaCab_ListarXEstado(par);
            return data;
        }
        public class jqProformasResult
        {
            public String msg { get; set; }
            public String ID_Imagen { get; set; }
            public int total { get; set; }
            public List<ProformaCabCE> rows { get; set; }
        }

        [WebMethod]
        public static ProformaCabCE F_ObtenerCotizacion_PorNumero_Net(int NumeroCotizacion)
        {
            ProformaCabCE objEntidad = new ProformaCabCE();
            ProformaCabCN objOperacion = new ProformaCabCN();
            objEntidad.Numero = NumeroCotizacion.ToString();
            return objOperacion.F_ProformaCab_ObtenerXNumero(objEntidad);
        }

        [WebMethod]
        public static ProformaCabCE F_ObtenerCotizacion_PorID_Net(int CodCotizacion)
        {
            ProformaCabCE objEntidad = new ProformaCabCE();
            ProformaCabCN objOperacion = new ProformaCabCN();
            objEntidad.CodProforma = CodCotizacion;
            return objOperacion.F_ProformaCab_ObtenerXID(objEntidad);
        }

        [WebMethod]
        //busca el stock del almacen especificado
        public static jqProformaDetResult F_Listar_Detalle_Proforma_NET(int CodProforma)
        {
            jqProformaDetResult data = new jqProformaDetResult();
            data.rows = new List<ProformaDetCE>();
            ProformaCabCE objEntidad = new ProformaCabCE();
            ProformaCabCN objOperacion = new ProformaCabCN();


            //primero se buscan los datos de conexion faltantes
            try
            {
                ProformaCabCE par = new ProformaCabCE();
                par.CodProforma = CodProforma;
                DataTable dtDatos = (new ProformaCabCN()).F_ProformaDet_ListarXCodigo(par);

                foreach (DataRow i in dtDatos.Rows)
                {
                    ProformaDetCE newpr = new ProformaDetCE();
                    newpr.CodDetalleProforma = int.Parse(i["CodDetalleProforma"].ToString());
                    newpr.CodProforma = int.Parse(i["CodProforma"].ToString());
                    newpr.CodArticulo = int.Parse(i["CodArticulo"].ToString());
                    newpr.Cantidad = decimal.Parse(i["Cantidad"].ToString());
                    newpr.Precio = decimal.Parse(i["Precio"].ToString());
                    newpr.Descripcion = i["Descripcion"].ToString();
                    newpr.CodUnidadMedida = int.Parse(i["CodUnidadVenta"].ToString());
                    data.rows.Add(newpr);
                }


            }
            catch (Exception ex)
            { }
            finally
            { objOperacion = null; }

            return data;
        }
        public class jqProformaDetResult
        {
            public String msg { get; set; }
            public String ID_Imagen { get; set; }
            public int total { get; set; }
            public List<ProformaDetCE> rows { get; set; }
        }

        [WebMethod]
        public static DocumentoVentaCabCE F_ObtenerArchivoCDR_NET(int CodDocumentoVenta)
        {
            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE()
            {
                CodDocumentoVenta = CodDocumentoVenta
            };
            return (new DocumentoVentaCabCN()).F_Tst_ArchivoCDR_FactElectronica(objEntidad);
        }

        [WebMethod]
        public static UsuarioCE F_Usuario_ObtenerXNombreUsuario_NET(string NombreUsuario)
        {
            UsuarioCN objOperacion = new UsuarioCN();
            return objOperacion.F_Usuario_ObtenerXNombreUsuario(NombreUsuario, Convert.ToInt32(HttpContext.Current.Session["CodSede"]));
        }        
    }
}
