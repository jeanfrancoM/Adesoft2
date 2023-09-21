using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Services;
using CapaEntidad;
using CapaNegocios;
using System.Data;

namespace SistemaInventario.Servicios
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]

    public class DatosPlanilla_Trabajador : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Planilla_TrabajadorCE> F_Planilla_Trabajador_Listar_AutoComplete(string Nombres)
        {
            List<Planilla_TrabajadorCE> lista = new List<Planilla_TrabajadorCE>();
            Planilla_TrabajadorCE objEntidad = new Planilla_TrabajadorCE();
            objEntidad.ApellidosNombres = Nombres;
            DataTable dtTabla = (new Planilla_TrabajadorCN()).F_Planilla_Trabajador_Listar(objEntidad);


            foreach (DataRow r in dtTabla.Rows)
            {
                Planilla_TrabajadorCE item = new Planilla_TrabajadorCE();
                item.CodTrabajador = Convert.ToInt32(r["CodTrabajador"].ToString());
                item.ApellidosNombres = r["ApellidosNombres"].ToString();
                item.NombreCompleto = r["NombreCompleto"].ToString();
                lista.Add(item);
            }
            return lista;

        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<TCConceptosDetCE> F_Listar_Estados_Planilla_Pago()
        {
            TCConceptosDetCN objOperacion = new TCConceptosDetCN();
            TCConceptosDetCE objEntidad = new TCConceptosDetCE();
            objEntidad.Flag = 6;
            DataTable dtTabla = null;
            dtTabla = objOperacion.F_TCConceptosDet_ListarEstadoFactura(objEntidad);
            List<TCConceptosDetCE> conceptos = new List<TCConceptosDetCE>();
            for (int i = 0; i < dtTabla.Rows.Count; i++)
            {
                TCConceptosDetCE concepto = new TCConceptosDetCE();
                concepto.CodConcepto = int.Parse(dtTabla.Rows[i]["Codigo"].ToString());
                concepto.DscAbvConcepto = dtTabla.Rows[i]["Descripcion"].ToString();
                conceptos.Add(concepto);
            }
            return conceptos;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Planilla_TrabajadorCE F_Trabajador_Actualizar(
            int CodTrabajador, int CodCategoria, int CodProyecto, int CodAFP, int CodTipoDocumento, string NroDocumento, string CUSP,
            string FechaNacimiento, string PaisEmisor, string ApellidosNombres, int Sexo, int EstadoCivil, string Nacionalidad,
            string Direccion, int CodDistrito, string FechaIngreso, string FechaCese, int NroHijos, decimal Pensiones_AFP,
            decimal Prima_AFP, decimal Comision_AFP, decimal Anticipada_AFP, decimal DescuentoJudicial,
            int CodEstado, string RegistroOperacion,
            int RetencionAnteriorAño, int RetencionAnteriorCodRetencion, decimal RetencionAnteriorMonto,
            decimal RetencionAnteriorTotalRemuneraciones,
            decimal SalarioMensual,
            int CodSeguridadSocial, int CodBanco, string NumCuenta, string CCI, string AreaTrabajo, string CentroCostos, string Consorciado, int CodCargo
            )
        {
            Planilla_TrabajadorCE objEntidad = new Planilla_TrabajadorCE();
            objEntidad.CodTrabajador = CodTrabajador;
            objEntidad.CodCategoria = CodCategoria;
            objEntidad.CodProyecto = CodProyecto;
            objEntidad.CodAFP = CodAFP;
            objEntidad.CodTipoDocumento = CodTipoDocumento;
            objEntidad.NroDocumento = NroDocumento;
            objEntidad.CUSP = CUSP;
            objEntidad.FechaNacimiento = Convert.ToDateTime(FechaNacimiento);
            objEntidad.PaisEmisor = PaisEmisor;
            objEntidad.ApellidosNombres = ApellidosNombres;
            objEntidad.Sexo = Sexo;
            objEntidad.EstadoCivil = EstadoCivil;
            objEntidad.Nacionalidad = Nacionalidad;
            objEntidad.Direccion = Direccion;
            objEntidad.CodDistrito = CodDistrito;
            objEntidad.FechaIngreso = Convert.ToDateTime(FechaIngreso);
            objEntidad.FechaCese = Convert.ToDateTime(FechaCese);
            objEntidad.NroHijos = NroHijos;
            objEntidad.Pensiones_AFP = Pensiones_AFP;
            objEntidad.Prima_AFP = Prima_AFP;
            objEntidad.Comision_AFP = Comision_AFP;
            objEntidad.Anticipada_AFP = Anticipada_AFP;
            objEntidad.DescuentoJudicial = DescuentoJudicial;
            objEntidad.RegistroOperacion = RegistroOperacion;

            objEntidad.RetencionAnteriorAño = RetencionAnteriorAño;
            objEntidad.RetencionAnteriorCodRetencion = RetencionAnteriorCodRetencion;
            objEntidad.RetencionAnteriorMonto = RetencionAnteriorMonto;
            objEntidad.RetencionAnteriorTotalRemuneraciones = RetencionAnteriorTotalRemuneraciones;

            objEntidad.SalarioMensual = SalarioMensual;

            objEntidad.CodUsuario = int.Parse(Session["CodUsuario"].ToString());
            objEntidad.CodEstado = CodEstado;
            objEntidad.CodSeguridadSocial = CodSeguridadSocial;
            objEntidad.CodBanco = CodBanco;
            objEntidad.NumeroCuenta = NumCuenta;
            objEntidad.CCI = CCI;
            objEntidad.AreaTrabajo = AreaTrabajo;
            objEntidad.CentroCostos = CentroCostos;
            objEntidad.Consorciado = Consorciado;
            objEntidad.CodCargo = CodCargo;

            try
            {
                if (objEntidad.RegistroOperacion == "Insert")
                {
                    objEntidad = (new Planilla_TrabajadorCN()).F_Planilla_Trabajador_Insert(objEntidad);
                    if (objEntidad.MsgError != "SE GRABO CORRECTAMENTE")
                        objEntidad.CodEstadoProceso = -1;
                }
                else
                {
                    objEntidad = (new Planilla_TrabajadorCN()).F_Planilla_Trabajador_Update(objEntidad);
                    if (objEntidad.MsgError != "SE ACTUALIZO CORRECTAMENTE")
                        objEntidad.CodEstadoProceso = -1;
                }



            }
            catch (Exception ex)
            {
                objEntidad.MsgError = ex.Message;
            }

            return objEntidad;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Planilla_TrabajadorCE F_Trabajador_Eliminar(int CodTrabajador)
        {
            Planilla_TrabajadorCE objEntidad = new Planilla_TrabajadorCE();
            objEntidad.CodTrabajador = CodTrabajador;
            objEntidad.CodUsuario = int.Parse(Session["CodUsuario"].ToString());
            try
            {
                objEntidad = (new Planilla_TrabajadorCN()).F_Planilla_Trabajador_Eliminar(objEntidad);
                if (objEntidad.MsgError != "SE ELIMINO CORRECTAMENTE")
                    objEntidad.CodEstadoProceso = -1;
            }
            catch (Exception ex)
            {
                objEntidad.MsgError = ex.Message;
            }

            return objEntidad;
        }





















        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Planilla_TrabajadorCE F_Planilla_Trabajador_Retenciones_Anteriores_Actualizar(
            int IdRetencion, int CodTrabajador, int CodPeriodo, decimal MontoRetenido, decimal TotalIngresos, string Observacion,
            string RegistroOperacion, string FechaExacta

            )
        {
            Planilla_TrabajadorCE objEntidad = new Planilla_TrabajadorCE();
            objEntidad.RetencionAnteriorCodRetencion = IdRetencion;
            objEntidad.CodTrabajador = CodTrabajador;
            objEntidad.RetencionAnteriorCodPeriodo = CodPeriodo;
            objEntidad.RetencionAnteriorMonto = MontoRetenido;
            objEntidad.RetencionAnteriorTotalRemuneraciones = TotalIngresos;
            objEntidad.RetencionAnteriorObservacion = Observacion;
            objEntidad.RegistroOperacion = RegistroOperacion;
            objEntidad.CodUsuario = int.Parse(Session["CodUsuario"].ToString());
            objEntidad.FechaExactaRetencion = Convert.ToDateTime(FechaExacta);

            try
            {
                if (objEntidad.RegistroOperacion == "Insert")
                {
                    objEntidad = (new Planilla_TrabajadorCN()).F_Planilla_Trabajador_Retenciones_Anteriores_Insert(objEntidad);
                    if (objEntidad.MsgError != "SE GRABO CORRECTAMENTE")
                        objEntidad.CodEstadoProceso = -1;
                }
                else
                {
                    objEntidad = (new Planilla_TrabajadorCN()).F_Planilla_Trabajador_Retenciones_Anteriores_Update(objEntidad);
                    if (objEntidad.MsgError != "SE MODIFICACION CORRECTAMENTE")
                        objEntidad.CodEstadoProceso = -1;
                }



            }
            catch (Exception ex)
            {
                objEntidad.MsgError = ex.Message;
            }

            return objEntidad;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Planilla_TrabajadorCE F_Planilla_Trabajador_Retenciones_Anteriores_Eliminar(int Id)
        {
            Planilla_TrabajadorCE objEntidad = new Planilla_TrabajadorCE();
            objEntidad.RetencionAnteriorCodRetencion = Id;
            objEntidad.CodUsuario = int.Parse(Session["CodUsuario"].ToString());
            try
            {
                objEntidad = (new Planilla_TrabajadorCN()).F_Planilla_Trabajador_Retenciones_Anteriores_Eliminar(objEntidad);
                if (objEntidad.MsgError != "SE ELIMINO CORRECTAMENTE LA RETENCION")
                    objEntidad.CodEstadoProceso = -1;
            }
            catch (Exception ex)
            {
                objEntidad.MsgError = ex.Message;
            }

            return objEntidad;
        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Planilla_PagoCabCE F_Planilla_Grabar_Paga(int CodPagoCab, int CodSalarioCab, int CodRegimenLaboral, int CodTrabajador, int CodSemana, int CodPeriodo, int CodProyecto,
                                                            decimal Monto, string FechaPago)
        {
            Planilla_PagoCabCE objEntidad = new Planilla_PagoCabCE();
            Planilla_PagoDetCE objEntidad2 = new Planilla_PagoDetCE();
            objEntidad.CodPagoCab = CodPagoCab;
            objEntidad.CodSalarioCab = CodSalarioCab;
            objEntidad.CodRegimenLaboral = CodRegimenLaboral;
            objEntidad.CodTrabajador = CodTrabajador;
            objEntidad.CodSemana = CodSemana;
            objEntidad.CodPeriodo = CodPeriodo;
            objEntidad.CodProyecto = CodProyecto;
            objEntidad2.Total = Monto;
            objEntidad2.FechaPago = Convert.ToDateTime(FechaPago);
            objEntidad2.CodUsuario = int.Parse(Session["CodUsuario"].ToString());
            try
            {
                objEntidad = (new Planilla_PagosCabCN()).F_Planilla_Grabar_Pago(objEntidad, objEntidad2);

            }
            catch (Exception ex)
            {
                objEntidad.MsgError = ex.Message;
            }

            return objEntidad;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Planilla_PagoCabCE F_Planilla_ELIMINAR_Paga(int CodPagoCab, int CodSalarioCab, int CodPagoDet,int CodRegimenLaboral, int CodTrabajador, int CodSemana, int CodPeriodo)
        {
            Planilla_PagoCabCE objEntidad = new Planilla_PagoCabCE();
            Planilla_PagoDetCE objEntidad2 = new Planilla_PagoDetCE();
            objEntidad.CodPagoCab = CodPagoCab;
            objEntidad.CodSalarioCab = CodSalarioCab;
            objEntidad.CodRegimenLaboral = CodRegimenLaboral;
            objEntidad.CodTrabajador = CodTrabajador;
            objEntidad.CodSemana = CodSemana;
            objEntidad.CodPeriodo = CodPeriodo;
            objEntidad2.CodPagoDet = CodPagoDet;            
            try
            {
                objEntidad = (new Planilla_PagosCabCN()).F_Planilla_Eliminar_Pago(objEntidad, objEntidad2);

            }
            catch (Exception ex)
            {
                objEntidad.MsgError = ex.Message;
            }

            return objEntidad;
        }
    }
}
