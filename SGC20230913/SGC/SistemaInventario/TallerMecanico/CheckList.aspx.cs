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
using CapaDatos;

namespace SistemaInventario.Maestros
{
    public partial class CheckList : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_GrabarDocumento_NET);
            CallbackManager.Register(F_Nuevo_NET);
            CallbackManager.Register(F_Buscar_NET);
            CallbackManager.Register(F_BuscarComponentesVehiculo_NET);
            CallbackManager.Register(F_AnularRegistro_Net);
            CallbackManager.Register(F_TipoCambio_NET);
            CallbackManager.Register(F_EdicionRegistro_NET);
            CallbackManager.Register(F_Auditoria_NET);
            CallbackManager.Register(F_LimpiarGrillaComponentes_NET);
            CallbackManager.Register(F_ReemplazarCheckList_NET);
            CallbackManager.Register(F_LlenarGridDetalle_NET);
            CallbackManager.Register(F_Observacion_NET);
            
            
            
        }

        private string _menu = "9000"; private string _opcion = "3";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"]; String Opcion = Request.QueryString["Op"];
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
            P_Inicializar_GrillaVacia_Componentes();
            P_Inicializar_GrillaVacia_Consulta();
            
            Session["datos"] = true;
        }

        protected void grvConsulta_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView grvDetalle = null;
                HiddenField hfCodigo = null;
                HiddenField hfPrincipal = null;
                HiddenField hfCodEstado = null;
                ImageButton imgBtnPrincipal = null;
                ImageButton imgBtnEstado = null;
                GridView grvDetalleObservacion = null;
                GridView grvDetalleAuditoria = null;



                grvDetalleObservacion = (GridView)(e.Row.FindControl("grvDetalleObservacion"));
                grvDetalleAuditoria = (GridView)(e.Row.FindControl("grvDetalleAuditoria"));
                grvDetalle = (GridView)(e.Row.FindControl("grvDetalle"));
                hfCodigo = (HiddenField)(e.Row.FindControl("hfCodigo"));
                hfPrincipal = (HiddenField)(e.Row.FindControl("hfPrincipal"));
                hfCodEstado = (HiddenField)(e.Row.FindControl("hfCodEstado"));
                imgBtnPrincipal = (ImageButton)(e.Row.FindControl("imgPrincipal"));
                imgBtnEstado    = (ImageButton)(e.Row.FindControl("imgActivarRegistro"));

                if (hfCodigo.Value != "")
                {

                    DataTable dta_consultaarticulo = null;
                    DataRow dtr_consultafila = null;
                    dta_consultaarticulo = new DataTable();

                    dta_consultaarticulo.Columns.Add("Codigo", typeof(string));
                    dta_consultaarticulo.Columns.Add("Placa", typeof(string));
                    dta_consultaarticulo.Columns.Add("Cliente", typeof(string));
                    dta_consultaarticulo.Columns.Add("ClienteRes", typeof(string));
                    dta_consultaarticulo.Columns.Add("Empleado", typeof(string));
                    dta_consultaarticulo.Columns.Add("ClienteDNI", typeof(string));
                    dta_consultaarticulo.Columns.Add("Color", typeof(string));
                    dta_consultaarticulo.Columns.Add("Anio", typeof(string));
                    dta_consultaarticulo.Columns.Add("Marca", typeof(string));
                    dta_consultaarticulo.Columns.Add("Modelo", typeof(string));
                    dta_consultaarticulo.Columns.Add("Estado", typeof(string));

                    dta_consultaarticulo = null;
                    dtr_consultafila = null;
                    dta_consultaarticulo = new DataTable();

                    dta_consultaarticulo.Columns.Add("Observacion", typeof(string));

                    dtr_consultafila = dta_consultaarticulo.NewRow();

                    dtr_consultafila[0] = "";
                    dta_consultaarticulo.Rows.Add(dtr_consultafila);

                    grvDetalleObservacion.DataSource = dta_consultaarticulo;
                    grvDetalleObservacion.DataBind();

                    dta_consultaarticulo = null;
                    dtr_consultafila = null;
                    dta_consultaarticulo = new DataTable();

                    dta_consultaarticulo.Columns.Add("Auditoria", typeof(string));

                    dtr_consultafila = dta_consultaarticulo.NewRow();

                    dtr_consultafila[0] = "";
                    dta_consultaarticulo.Rows.Add(dtr_consultafila);

                    grvDetalleAuditoria.DataSource = dta_consultaarticulo;
                    grvDetalleAuditoria.DataBind();


                    dta_consultaarticulo = null;
                    dtr_consultafila = null;
                    dta_consultaarticulo = new DataTable();

                    dta_consultaarticulo.Columns.Add("Tipo", typeof(string));
                    dta_consultaarticulo.Columns.Add("Componente", typeof(string));
                    dta_consultaarticulo.Columns.Add("Cantidad", typeof(string));
                    dta_consultaarticulo.Columns.Add("EstadoComponente", typeof(string));
                    dtr_consultafila = dta_consultaarticulo.NewRow();

                    dtr_consultafila[0] = "";
                    dta_consultaarticulo.Rows.Add(dtr_consultafila);

                    grvDetalle.DataSource = dta_consultaarticulo;
                    grvDetalle.DataBind();


                   
                }

            }
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

                CheckListCN objOperacion = new CheckListCN();
                CheckListCE objEntidad = new CheckListCE();

                objEntidad.CodVehiculoCheckListCab = Codigo;
                grvDetalle.DataSource = objOperacion.F_VEHICULOCHECKLIST_OBSERVACION(objEntidad);
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

        public String F_Auditoria_NET(String arg)
        {
            int int_resultado_operacion = 0;
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String grvNombre = "";
            String str_grv_Auditoria_html = "";
            int Col = 0;
            int CodVehiculoCheckListCab = 0;
            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                grvNombre = Convert.ToString(obj_parametros["Filtro_grvNombre"]);
                Col = Convert.ToInt32(obj_parametros["Filtro_Col"]);
                CodVehiculoCheckListCab = Convert.ToInt32(obj_parametros["Filtro_Codigo"]);

                GridView grvAuditoria = (GridView)grvConsulta.Rows[0].FindControl("grvDetalleAuditoria");

                CheckListCN objOperacion = new CheckListCN();
                CheckListCE objEntidad = new CheckListCE();

                objEntidad.CodVehiculoCheckListCab = CodVehiculoCheckListCab;
                grvAuditoria.DataSource = objOperacion.F_VEHICULOCHECKLIST_AUDITORIA(objEntidad);
                grvAuditoria.DataBind();

                str_grv_Auditoria_html = Mod_Utilitario.F_GetHtmlForControl(grvAuditoria);
            }
            catch (Exception exxx)
            {
                str_resultado = "ERROR AL BUSCAR DETALLE: " + exxx;
                int_resultado_operacion = 1;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion) + "~" +
                str_mensaje_operacion + "~" +
                str_grv_Auditoria_html + "~" +
                grvNombre;

            return str_resultado;
        }

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

                //Obtengo el Grid para llenarlo y dibujarlo
                GridView grvDetalle = (GridView)grvConsulta.Rows[0].FindControl("grvDetalle");

                //Consulta
                CheckListCN objOperacion = new CheckListCN();
                CheckListCE objEntidad = new CheckListCE();

                //consulta a la base de datos y se llena grid
                objEntidad.CodVehiculoCheckListCab = Codigo;
                grvDetalle.DataSource = objOperacion.F_CheckListDet_Listar(objEntidad);
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

        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";

            String str_ddl_responsableempleado_html = "";
            String str_ddl_estado_html = "";
            String str_ddl_estadoconsulta_html = "";
            String str_ddl_serieConsulta_html = "";
          
            Hashtable obj_parametros = null;
            int int_resultado_operacion = 0;


            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlResponsableEmpleado,
                      ref ddlEstado, ref ddlEstadoConsulta, ref ddlSerieConsulta);

                str_ddl_responsableempleado_html = Mod_Utilitario.F_GetHtmlForControl(ddlResponsableEmpleado);
                str_ddl_estado_html = Mod_Utilitario.F_GetHtmlForControl(ddlEstado);
                str_ddl_estadoconsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlEstadoConsulta);
                str_ddl_serieConsulta_html = Mod_Utilitario.F_GetHtmlForControl(ddlSerieConsulta);
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
                str_ddl_responsableempleado_html + "~" + //2
                str_ddl_estado_html + "~" +//3
                str_ddl_estadoconsulta_html + "~" +//4
                str_ddl_serieConsulta_html;//5

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
               // P_Buscar(obj_parametros, ref grvConsulta);
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

        public String F_ReemplazarCheckList_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvTablaComponentes_html = "";
            int int_resultado_operacion = 0;
            String Placa = "";
            String ClienteResponsableDNI = "";
            int CodResponsableEmpleado = 0;
            String ClienteResponsable = "";
            String Color = "";
            String Marca = "";
            String Modelo = "";
            String Estado = "";
            String Observacion = "";
            String Cliente = "";
            int Anio = 0;
            int Codigo = 0;
            
            int CodEstado = 0;
            int GasolinaNivel = 0;
            int CodCliente = 0;
            int CodVehiculo = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_ValidarCheckList(obj_parametros, ref str_mensaje_operacion);

                if (str_mensaje_operacion == "")
                {
                    P_ReemplazarCheckList(obj_parametros, ref  Placa, ref ClienteResponsableDNI, ref CodResponsableEmpleado, ref ClienteResponsable,
                        ref Color, ref Anio, ref Marca, ref Modelo, ref Estado,ref CodEstado, ref GasolinaNivel, ref Observacion,
            ref  Cliente, ref  CodCliente, ref  CodVehiculo);

               P_CargarGrillaTemporal(obj_parametros, Codigo, ref grvTablaComponentes);



                    str_grvTablaComponentes_html = Mod_Utilitario.F_GetHtmlForControl(grvTablaComponentes);
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
                 Convert.ToString(int_resultado_operacion) + "~" + //0
                 str_mensaje_operacion + "~" + //1
                 str_grvTablaComponentes_html + "~" +//2
                 Placa + "~" + //3
                 ClienteResponsableDNI + "~" + //4
                 CodResponsableEmpleado.ToString() + "~" +//5 
                 ClienteResponsable + "~" + //6
                 Color + "~" + //7
                 Anio.ToString() + "~" + //8
                 Marca + "~" + //9
                 Estado + "~" +  //10
                 CodEstado + "~" +//11
                 GasolinaNivel + "~" + //12
                 Observacion + "~" + //13
                 Cliente + "~" + //14
                 CodCliente + "~" + //15
                 CodVehiculo + "~" + //16
                  Modelo+ "~" + //17
                  Codigo ;//18
                  

            return str_resultado;
        }

        public void P_ValidarCheckList(Hashtable objTablaFiltro, ref String Mensaje)
        {
            CheckListCE objEntidad = null;
            CheckListCN objOperacion = null;

            objEntidad = new CheckListCE();

            objEntidad.CodVehiculoCheckListCab = Convert.ToInt32(objTablaFiltro["Filtro_CodVehiculoCheckListCab"]);

            objOperacion = new CheckListCN();

            Mensaje = objOperacion.F_VehiculoCheckListCab_Validar_CheckListC(objEntidad).MsgError;
        }
        public void P_CargarGrillaTemporal(Hashtable objTablaFiltro, Int32 Codigo, ref GridView grvComponentesDetalle)
        {

           

            CheckListCE objEntidad = null;
            CheckListCN objOperacion = null;
            objEntidad = new CheckListCE();
            objOperacion = new CheckListCN();

            Codigo = Convert.ToInt32(objTablaFiltro["Filtro_CodVehiculoCheckListCab"]);

            DataTable dta_consulta = null;
            if (Codigo != 0)
            {
               
                objEntidad.CodVehiculoCheckListCab = Codigo;

                dta_consulta = objOperacion.F_VehiculoCheckListCabDetalleEdicion_Listar(objEntidad);
            }

            grvComponentesDetalle.DataSource = dta_consulta;
            grvComponentesDetalle.DataBind();
        }

        public void P_ReemplazarCheckList(Hashtable objTablaFiltro,
         ref String Placa, ref String ClienteResponsableDNI, ref Int32 CodResponsableEmpleado,
         ref String ClienteResponsable, ref String Color, ref Int32 Anio, ref String Marca,
         ref String Modelo, ref String Estado, ref Int32 CodEstado, ref Int32 GasolinaNivel, ref String Observacion,
            ref String Cliente, ref Int32 CodCliente, ref Int32 CodVehiculo
     )
        {
            CheckListCE objEntidad = null;
            CheckListCN objOperacion = null;

            objEntidad = new CheckListCE();

            objEntidad.CodVehiculoCheckListCab = Convert.ToInt32(objTablaFiltro["Filtro_CodVehiculoCheckListCab"]);

            objOperacion = new CheckListCN();
            DataTable dtTabla = null;

            dtTabla = objOperacion.F_CheckList_Reemplazar(objEntidad);

            if (dtTabla.Rows.Count > 0)
            {
                Placa = dtTabla.Rows[0]["Placa"].ToString();
                ClienteResponsableDNI = Convert.ToString(dtTabla.Rows[0]["ClienteResponsableDNI"]);
                CodResponsableEmpleado = Convert.ToInt32(dtTabla.Rows[0]["CodResponsableEmpleado"]);
                ClienteResponsable = Convert.ToString(dtTabla.Rows[0]["ClienteResponsable"]);
                Color = Convert.ToString(dtTabla.Rows[0]["Color"]);
                Anio = Convert.ToInt32(dtTabla.Rows[0]["Anio"]);
                Marca = Convert.ToString(dtTabla.Rows[0]["Marca"]);
                Modelo = Convert.ToString(dtTabla.Rows[0]["Modelo"]);
                Estado = Convert.ToString(dtTabla.Rows[0]["Estado"]);
                CodEstado = Convert.ToInt32(dtTabla.Rows[0]["CodEstado"]);
                GasolinaNivel = Convert.ToInt32(dtTabla.Rows[0]["GasolinaNivel"]);
                Observacion = Convert.ToString(dtTabla.Rows[0]["Observacion"]);
                CodCliente = Convert.ToInt32(dtTabla.Rows[0]["CodCliente"]);
                CodVehiculo = Convert.ToInt32(dtTabla.Rows[0]["CodVehiculo"]);
                Cliente = Convert.ToString(dtTabla.Rows[0]["Cliente"]);
                
            }
        }








        public String F_Nuevo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvComponentes_html = "";
            int int_resultado_operacion = 0;


            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                //str_grvFactura_html = Mod_Utilitario.F_GetHtmlForControl(grvFactura);
                P_Inicializar_GrillaVacia_Componentes();
                int_resultado_operacion = 1;
                str_mensaje_operacion = MsgError;
                str_grvComponentes_html = Mod_Utilitario.F_GetHtmlForControl(grvTablaComponentes);
            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)//0
                + "~" +
                str_mensaje_operacion//1
                + "~" +
                str_grvComponentes_html; //2


            return str_resultado;

        }

        public String F_LimpiarGrillaComponentes_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvComponentes_html = "";
            int int_resultado_operacion = 0;


            String MsgError = "";
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                //str_grvFactura_html = Mod_Utilitario.F_GetHtmlForControl(grvFactura);
                P_Inicializar_GrillaVacia_Componentes();
                int_resultado_operacion = 1;
                str_mensaje_operacion = MsgError;
                str_grvComponentes_html = Mod_Utilitario.F_GetHtmlForControl(grvTablaComponentes);
            }
            catch (Exception ex)
            {

                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;

            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)//0
                + "~" +
                str_mensaje_operacion//1
                + "~" +
                str_grvComponentes_html; //2


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

        public String F_BuscarComponentesVehiculo_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String str_grvTablaComponentes_html = "";
            int int_resultado_operacion = 0;

            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_BuscarComponentes(obj_parametros, ref grvTablaComponentes);
                if (grvTablaComponentes.Rows.Count == 0)
                {
                    P_Inicializar_GrillaVacia_Componentes();
                    str_mensaje_operacion = "No se encontraron registros.";
                }
                else
                {
                    str_mensaje_operacion = "";
                }

                str_grvTablaComponentes_html = Mod_Utilitario.F_GetHtmlForControl(grvTablaComponentes);
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
                str_grvTablaComponentes_html;


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


        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_responsableEmpleado, ref DropDownList ddl_estado, ref DropDownList ddl_estadoConsulta, ref DropDownList ddl_serieConsulta)
        {
            DataTable dta_consulta = null;


            int iCodEmpresa = 3;

            TCCorrelativoCE objEntidad = new TCCorrelativoCE();

            objEntidad.CodTipoDoc = Convert.ToInt32(objTablaFiltro["Filtro_CodDoc"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodEmpresa = iCodEmpresa;

            TCCorrelativoCN objOperacion = new TCCorrelativoCN();

            dta_consulta = objOperacion.F_TCCorrelativo_Serie_Select(objEntidad);

            ddl_serieConsulta.Items.Clear();

            ddl_serieConsulta.DataSource = dta_consulta;
            ddl_serieConsulta.DataTextField = "SerieDoc";
            ddl_serieConsulta.DataValueField = "CodSerie";
            ddl_serieConsulta.DataBind();


            TCConceptosDetCE objEntidadConceptosDet = new TCConceptosDetCE();
            TCConceptosDetCN objOperacionConceptosDet = new TCConceptosDetCN();

            ddl_estado.Items.Clear();

            objEntidadConceptosDet.CodConcepto = 16;

            dta_consulta = objOperacionConceptosDet.F_TCConceptosDet_ListarEstadoCheckList(objEntidadConceptosDet);

            ddl_estado.DataSource = dta_consulta;
            ddl_estado.DataTextField = "DscAbvConcepto";
            ddl_estado.DataValueField = "CodConcepto";
            ddl_estado.DataBind();

            ddl_estadoConsulta.DataSource = dta_consulta;
            ddl_estadoConsulta.DataTextField = "DscAbvConcepto";
            ddl_estadoConsulta.DataValueField = "CodConcepto";
            ddl_estadoConsulta.DataBind();
            ddl_estadoConsulta.Items.Insert(0, new ListItem("TODOS", "0"));

            TCCuentaCorrienteCE objModeloVehiculo = new TCCuentaCorrienteCE();
            //codcargo de mecanico
            objModeloVehiculo.CodCargo = 7;
            dta_consulta = (new TCCuentaCorrienteCN()).F_listar_EmpleadosxCargo(objModeloVehiculo);

            ddl_responsableEmpleado.Items.Clear();

            ddl_responsableEmpleado.DataSource = dta_consulta;
            ddl_responsableEmpleado.DataTextField = "NombreCompleto";
            ddl_responsableEmpleado.DataValueField = "CodEmpleado";
            ddl_responsableEmpleado.DataBind();

        }

        public void P_Inicializar_GrillaVacia_Consulta()
        {
            DataTable dta_consultaarticulo = null;
            DataRow dtr_consultafila = null;

            dta_consultaarticulo = new DataTable();
            dta_consultaarticulo.Columns.Add("Codigo", typeof(string));
            dta_consultaarticulo.Columns.Add("Placa", typeof(string));
            dta_consultaarticulo.Columns.Add("Cliente", typeof(string));
            dta_consultaarticulo.Columns.Add("Empleado", typeof(string));
            dta_consultaarticulo.Columns.Add("ClienteDNI", typeof(string));
            dta_consultaarticulo.Columns.Add("ClienteRes", typeof(string));
            dta_consultaarticulo.Columns.Add("Color", typeof(string));
            dta_consultaarticulo.Columns.Add("Anio", typeof(string));
            dta_consultaarticulo.Columns.Add("Marca", typeof(string));
            dta_consultaarticulo.Columns.Add("Modelo", typeof(string));
            dta_consultaarticulo.Columns.Add("Estado", typeof(string));
            dta_consultaarticulo.Columns.Add("Numero", typeof(string));
            dta_consultaarticulo.Columns.Add("FechaEmision", typeof(string));
            dta_consultaarticulo.Columns.Add("CodTipoCliente", typeof(string));
            

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

            grvConsulta.DataSource = dta_consultaarticulo;
            grvConsulta.DataBind();
        }

        public void P_Inicializar_GrillaVacia_Componentes()
        {
            DataTable dta_consultacomponente = null;
            DataRow dtr_consultafila2 = null;

            dta_consultacomponente = new DataTable();
            dta_consultacomponente.Columns.Add("Componente", typeof(string));
            dta_consultacomponente.Columns.Add("TipoComponente", typeof(string));
            dta_consultacomponente.Columns.Add("Cantidad", typeof(string));
            dta_consultacomponente.Columns.Add("Estado", typeof(string));
            dta_consultacomponente.Columns.Add("CodVehiculoComponente", typeof(string));
            dta_consultacomponente.Columns.Add("CodEstadoComponente", typeof(string));
            


            dtr_consultafila2 = dta_consultacomponente.NewRow();

            dtr_consultafila2[0] = "";
            dtr_consultafila2[1] = "";
            dtr_consultafila2[2] = "";
            dtr_consultafila2[3] = "";

            dta_consultacomponente.Rows.Add(dtr_consultafila2);

            grvTablaComponentes.DataSource = dta_consultacomponente;
            grvTablaComponentes.DataBind();
        }
        public void P_GrabarDocumento(Hashtable objTablaFiltro, ref String MsgError)
        {
            CheckListCE objEntidad = null;
            CheckListCN objOperacion = null;

            objEntidad = new CheckListCE();

            String XmlDetalle = "";
            int iCodEmpresa = 3;
            objEntidad.CodEmpresa = iCodEmpresa;

            objEntidad.CodVehiculoCheckListCab = Convert.ToInt32(objTablaFiltro["Filtro_CodVehiculoCheckListCab"]);
            objEntidad.CodVehiculo = Convert.ToInt32(objTablaFiltro["Filtro_CodVehiculo"]);
            objEntidad.CodCtaCte = Convert.ToInt32(objTablaFiltro["Filtro_CodCtaCte"]);
            objEntidad.ResponsableClienteDni = Convert.ToString(objTablaFiltro["Filtro_ResponsableClienteDni"]);
            objEntidad.ResponsableCliente = Convert.ToString(objTablaFiltro["Filtro_ResponsableCliente"]);
            objEntidad.NivelGasolina = Convert.ToInt32(objTablaFiltro["Filtro_NivelGasolina"]);
            objEntidad.Observacion = Convert.ToString(objTablaFiltro["Filtro_Observacion"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            objEntidad.CodEmpleadoResponsable = Convert.ToInt32(objTablaFiltro["Filtro_CodEmpleadoResponsable"]);

            objEntidad.CodAlmacen =  Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);
           
            dynamic jArr2 = Newtonsoft.Json.JsonConvert.DeserializeObject(objTablaFiltro["Filtro_XmlDetalle"].ToString());

            foreach (dynamic item in jArr2)
            {
                XmlDetalle = XmlDetalle + "<D ";
                XmlDetalle = XmlDetalle + " CodVehiculoComponente = '" + item.CodVehiculoComponente + "'";
                XmlDetalle = XmlDetalle + " Cantidad = '" + item.Cantidad + "'";
                XmlDetalle = XmlDetalle + " CodEstadoComponente  = '" + item.CodEstadoComponente + "'";
                XmlDetalle = XmlDetalle + " />";
            }

            XmlDetalle = "<R><XmlLC> " + XmlDetalle.Replace("&", "&amp;").Replace("”", "&quot;") + "</XmlLC></R>";
            XmlDetalle = "<?xml version=" + '\u0022' + "1.0" + '\u0022' + " encoding=" + '\u0022' + "iso-8859-1" + '\u0022' + "?>" + XmlDetalle;

            objEntidad.XmlDetalle = XmlDetalle;
            objOperacion = new CheckListCN();

            objOperacion.F_CheckList_Insert(objEntidad);

            MsgError = objEntidad.MsgError;
        }


      

        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {
            CheckListCE objEntidad = null;
            CheckListCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new CheckListCE();

            objEntidad.Descripcion = Convert.ToString(objTablaFiltro["Filtro_Descripcion"]);
            objEntidad.Placa = Convert.ToString(objTablaFiltro["Filtro_Placa"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);

            objEntidad.SerieDoc = Convert.ToString(objTablaFiltro["Filtro_Serie"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);

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


            objOperacion = new CheckListCN();

            dta_consulta = objOperacion.F_CheckList_Listar(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();
        }



        public void P_BuscarComponentes(Hashtable objTablaFiltro, ref GridView GrillaBuscarComponente)
        {
            CheckListCE objEntidad = null;
            CheckListCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new CheckListCE();

            objEntidad.CodTipoVehiculo = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoVehiculo"]);

            objOperacion = new CheckListCN();

            dta_consulta = objOperacion.F_VehiculoComponentesDetalle_Listar(objEntidad);

            GrillaBuscarComponente.DataSource = dta_consulta;
            GrillaBuscarComponente.DataBind();
        }

        public void P_AnularRegistro(Hashtable objTablaFiltro, ref String Mensaje)
        {
            CheckListCE objEntidad = null;
            CheckListCN objOperacion = null;

            objEntidad = new CheckListCE();

            objEntidad.CodVehiculoCheckListCab = Convert.ToInt32(objTablaFiltro["Filtro_Codigo"]);
            objEntidad.CodUsuarioAnulacion = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new CheckListCN();

            objOperacion.F_VehiculoCheckListAnular_Eliminar(objEntidad);

            Mensaje = objEntidad.MsgError;

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



        public void P_EditarRegistro(Hashtable objTablaFiltro, ref String MsgError)
        {
            VehiculoCE objEntidad = null;
            VehiculoCN objOperacion = null;

            objEntidad = new VehiculoCE();

            int iCodEmpresa = 3;
            objEntidad.CodEmpresa = iCodEmpresa;
            objEntidad.Placa = Convert.ToString(objTablaFiltro["Filtro_Placa"]);
            objEntidad.Chasis = Convert.ToString(objTablaFiltro["Filtro_Chasis"]);
            objEntidad.CodCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodCliente"]);
            objEntidad.Anio = Convert.ToInt32(objTablaFiltro["Filtro_Anio"]);
            objEntidad.NroMotor = Convert.ToString(objTablaFiltro["Filtro_NroMotor"]);
            objEntidad.CodVehiculo = Convert.ToInt32(objTablaFiltro["Filtro_CodVehiculo"]);

            if (Convert.ToString(objTablaFiltro["Filtro_NroFlota"]) != "")
            objEntidad.NroFlota = Convert.ToInt32(objTablaFiltro["Filtro_NroFlota"]);


            if (Convert.ToString(objTablaFiltro["Filtro_Revision"]) != "")
                objEntidad.FechaRevisionTecnica = Convert.ToDateTime(objTablaFiltro["Filtro_Revision"]);
            else
                objEntidad.FechaRevisionTecnica = Convert.ToDateTime("1/1/1900");

            if (Convert.ToString(objTablaFiltro["Filtro_VencimientoSoat"]) != "")
                objEntidad.FechaVctoSoat = Convert.ToDateTime(objTablaFiltro["Filtro_VencimientoSoat"]);
            else
                objEntidad.FechaVctoSoat = Convert.ToDateTime("1/1/1900");


            objEntidad.Observacion = Convert.ToString(objTablaFiltro["Filtro_Observacion"]);

            objEntidad.CodColor = Convert.ToInt32(objTablaFiltro["Filtro_CodColor"]);
            objEntidad.CodModeloVehiculo = Convert.ToInt32(objTablaFiltro["Filtro_CodModelo"]);
            objEntidad.CodMarca = Convert.ToInt32(objTablaFiltro["Filtro_CodMarca"]);
            objEntidad.CodTipoVehiculo = Convert.ToInt32(objTablaFiltro["Filtro_CodTipo"]);
            objEntidad.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);

            objEntidad.Direccion = Convert.ToString(objTablaFiltro["Filtro_Direccion"]);
            objEntidad.RazonSocial = Convert.ToString(objTablaFiltro["Filtro_RazonSocial"]);
            objEntidad.NroRuc = Convert.ToString(objTablaFiltro["Filtro_NroRuc"]);
            objEntidad.NroDni = Convert.ToString(objTablaFiltro["Filtro_NroDni"]);

            objEntidad.CodDepartamento = Convert.ToInt32(objTablaFiltro["Filtro_CodDepartamento"]);
            objEntidad.CodProvincia = Convert.ToInt32(objTablaFiltro["Filtro_CodProvincia"]);
            objEntidad.CodDistrito = Convert.ToInt32(objTablaFiltro["Filtro_CodDistrito"]);
            objEntidad.CodTipoCliente = Convert.ToInt32(objTablaFiltro["Filtro_CodTipoCliente"]);
            objEntidad.CodDireccion = Convert.ToInt32(objTablaFiltro["Filtro_CodDireccion"]);

            objEntidad.CodUsuarioModificacion = Convert.ToInt32(Session["CodUsuario"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
          



            objOperacion = new VehiculoCN();

            objOperacion.F_Vehiculo_Update(objEntidad);

            MsgError = objEntidad.MsgError;
        }

    
    }
}