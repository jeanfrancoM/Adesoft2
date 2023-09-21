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

namespace SistemaInventario.Reportes
{
    public partial class Ventas_VentaXVendedorDetallado : System.Web.UI.Page
    {
        private string _menu = ""; private string _opcion = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"];
            String Opcion = Request.QueryString["Op"];
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
        }

        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_Controles_Inicializar_NET);
            CallbackManager.Register(F_Buscar_NET);
        }

        public String F_Controles_Inicializar_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";      
            String str_ddl_moneda_html = "";        
            int int_resultado_operacion = 0;
            String str_ddlVendedor_html = "";
            String str_ddl_sucursal_html = "";      
            Hashtable obj_parametros = null;

            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

                P_Controles_Inicializar(obj_parametros, ref ddlMoneda, ref ddlVendedor, ref ddlSucursal);

                str_ddl_sucursal_html = Mod_Utilitario.F_GetHtmlForControl(ddlSucursal);        
                str_ddl_moneda_html = Mod_Utilitario.F_GetHtmlForControl(ddlMoneda);
                str_ddlVendedor_html = Mod_Utilitario.F_GetHtmlForControl(ddlVendedor);
               
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
                str_ddl_moneda_html  + "~" +
                str_ddlVendedor_html + "~" +
                str_ddl_sucursal_html; //2

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
                  //  P_Inicializar_GrillaVacia_Consulta();
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

        public void P_Controles_Inicializar(Hashtable objTablaFiltro, ref DropDownList ddl_combomoneda,
            ref DropDownList ddl_empleado, ref DropDownList combosucursal)
        {
            DataTable dta_consulta = null;

            int iCodEmpresa = 3;

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
                       
            EmpleadoCE objEmpleado = new EmpleadoCE();

            objEmpleado.CodCargo = Convert.ToInt32(objTablaFiltro["Filtro_CodCargo"]);
            objEmpleado.CodEstado = Convert.ToInt32(objTablaFiltro["Filtro_CodEstado"]);
            dta_consulta = (new EmpleadoCN()).F_Empleado_Listar(objEmpleado);
            ddl_empleado.Items.Clear();

            ddl_empleado.DataSource = dta_consulta;
            ddl_empleado.DataTextField = "NombreCompleto";
            ddl_empleado.DataValueField = "CodEmpleado";
            ddl_empleado.DataBind();

            ddl_empleado.Items.Insert(0, new ListItem("TODOS", "0"));

            TCAlmacenCE objEntidadAlmacen = null;
            TCAlmacenCN objOperacionAlmacen = null;

            objEntidadAlmacen = new TCAlmacenCE();

            objEntidadAlmacen.CodEmpresa = iCodEmpresa;
            objEntidadAlmacen.CodAlmacen = 0;

            objOperacionAlmacen = new TCAlmacenCN();

            combosucursal.Items.Clear();

            dta_consulta = objOperacionAlmacen.F_TCAlmacen_Listar(objEntidadAlmacen);

            combosucursal.DataSource = dta_consulta;
            combosucursal.DataTextField = "DscAlmacen";
            combosucursal.DataValueField = "CodAlmacen";
            combosucursal.DataBind();

            ListItem iTodos = new ListItem("--TODOS--", "0");
            combosucursal.Items.Add(iTodos);
        }

        public void P_Buscar(Hashtable objTablaFiltro, ref GridView GrillaBuscar)
        {
            DocumentoVentaCabCE objEntidad = null;
            DocumentoVentaCabCN objOperacion = null;

            DataTable dta_consulta = null;

            objEntidad = new DocumentoVentaCabCE();

            
            objEntidad.DesdeInt = Convert.ToInt32(objTablaFiltro["Filtro_Desde"]);
            objEntidad.HastaInt = Convert.ToInt32(objTablaFiltro["Filtro_Hasta"]);
            objEntidad.CodAlmacen = Convert.ToInt32(objTablaFiltro["Filtro_CodAlmacen"]);
            objEntidad.CodFormaPago = Convert.ToInt32(objTablaFiltro["Filtro_CodFormaPago"]);
            objEntidad.CodVendedor = Convert.ToInt32(objTablaFiltro["Filtro_CodEmpleado"]);

            objOperacion = new DocumentoVentaCabCN();

            dta_consulta = objOperacion.F_DOCUMENTOVENTACAB_VENTAS_MENSUALES_VENDEDOR(objEntidad);

            GrillaBuscar.DataSource = dta_consulta;
            GrillaBuscar.DataBind();
        }
    }
}