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

    public class DatosPlanilla_Periodo : System.Web.Services.WebService
    {


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Planilla_PeriodoCE F_Planilla_Periodo_Obtener(string Fecha)
        {
            Planilla_PeriodoCE objEntidad = new Planilla_PeriodoCE();

            try
            {
                objEntidad.FechaInicial = Convert.ToDateTime(Fecha);

                DataTable table = (new Planilla_PeriodoCN()).F_Planilla_Periodo_Obtener(objEntidad);

                foreach (DataRow r in table.Rows)
                {
                    objEntidad.CodPeriodo = Convert.ToInt32(r["CodPeriodo"].ToString());

                    objEntidad.Año = Convert.ToInt32(r["Año"].ToString());
                    objEntidad.NroPeriodo = Convert.ToInt32(r["NroPeriodo"].ToString());

                    objEntidad.AñoPeriodo1 = r["AñoPeriodo1"].ToString();
                    objEntidad.AñoPeriodo2 = r["AñoPeriodo2"].ToString();

                    objEntidad.FechaInicial = Convert.ToDateTime(r["FechaInicial"].ToString());
                    objEntidad.FechaInicialStr = r["FechaInicial"].ToString();

                    objEntidad.FechaFinal = Convert.ToDateTime(r["FechaFinal"].ToString());
                    objEntidad.FechaFinalStr = r["FechaFinal"].ToString();

                    objEntidad.NroFeriado = Convert.ToInt32(r["NroFeriado"].ToString());

                }
            }
            catch (Exception ex)
            { }

            return objEntidad;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Planilla_PeriodoCE F_Planilla_Periodo_Obtener_Por_Periodo(string AñoPeriodo)
        {
            Planilla_PeriodoCE objEntidad = new Planilla_PeriodoCE();

            try
            {
                objEntidad.AñoPeriodo1 = AñoPeriodo;

                DataTable table = (new Planilla_PeriodoCN()).F_Planilla_Periodo_Obtener_Por_Periodo(objEntidad);

                foreach (DataRow r in table.Rows)
                {
                    objEntidad.CodPeriodo = Convert.ToInt32(r["CodPeriodo"].ToString());

                    objEntidad.Año = Convert.ToInt32(r["Año"].ToString());
                    objEntidad.NroPeriodo = Convert.ToInt32(r["NroPeriodo"].ToString());

                    objEntidad.AñoPeriodo1 = r["AñoPeriodo1"].ToString();
                    objEntidad.AñoPeriodo2 = r["AñoPeriodo2"].ToString();

                    objEntidad.FechaInicial = Convert.ToDateTime(r["FechaInicial"].ToString());
                    objEntidad.FechaInicialStr = r["FechaInicial"].ToString();

                    objEntidad.FechaFinal = Convert.ToDateTime(r["FechaFinal"].ToString());
                    objEntidad.FechaFinalStr = r["FechaFinal"].ToString();

                    objEntidad.NroFeriado = Convert.ToInt32(r["NroFeriado"].ToString());

                }
            }
            catch (Exception ex)
            { }

            return objEntidad;
        }

    }
}
