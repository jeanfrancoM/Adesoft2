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

    public class DatosPlanilla_Semana : System.Web.Services.WebService
    {


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Planilla_SemanaCE F_Planilla_Semana_Obtener(string Fecha)
        {
            Planilla_SemanaCE objEntidad = new Planilla_SemanaCE();

            try
            {
                objEntidad.FechaInicial = Convert.ToDateTime(Fecha);

                DataTable table = (new Planilla_SemanaCN()).F_Planilla_Semana_Obtener(objEntidad);

                foreach (DataRow r in table.Rows)
                {
                    objEntidad.CodSemana = Convert.ToInt32(r["CodSemana"].ToString());
                    
                    objEntidad.Año = Convert.ToInt32(r["Año"].ToString());
                    objEntidad.NroSemana = Convert.ToInt32(r["NroSemana"].ToString());
                    
                    objEntidad.AñoSemana1 = r["AñoSemana1"].ToString();
                    objEntidad.AñoSemana2 = r["AñoSemana2"].ToString();

                    objEntidad.FechaInicial = Convert.ToDateTime(r["FechaInicial"].ToString());
                    objEntidad.FechaInicialStr = r["FechaInicial"].ToString();

                    objEntidad.FechaFinal = Convert.ToDateTime(r["FechaFinal"].ToString());
                    objEntidad.FechaFinalStr = r["FechaFinal"].ToString();
                    
                    objEntidad.NroFeriado = Convert.ToInt32(r["NroFeriado"].ToString());
                    
                    objEntidad.DiaInicial = r["DiaInicial"].ToString();
                    objEntidad.DiaFinal = r["DiaFinal"].ToString();
                }
            }
            catch (Exception ex)
            { }

            return objEntidad;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Planilla_SemanaCE F_Planilla_Semana_Obtener_Por_Semana(string AñoSemana)
        {
            Planilla_SemanaCE objEntidad = new Planilla_SemanaCE();

            try
            {
                objEntidad.AñoSemana1 = AñoSemana;

                DataTable table = (new Planilla_SemanaCN()).F_Planilla_Semana_Obtener_Por_Semana(objEntidad);

                foreach (DataRow r in table.Rows)
                {
                    objEntidad.CodSemana = Convert.ToInt32(r["CodSemana"].ToString());

                    objEntidad.Año = Convert.ToInt32(r["Año"].ToString());
                    objEntidad.NroSemana = Convert.ToInt32(r["NroSemana"].ToString());

                    objEntidad.AñoSemana1 = r["AñoSemana1"].ToString();
                    objEntidad.AñoSemana2 = r["AñoSemana2"].ToString();

                    objEntidad.FechaInicial = Convert.ToDateTime(r["FechaInicial"].ToString());
                    objEntidad.FechaInicialStr = r["FechaInicial"].ToString();

                    objEntidad.FechaFinal = Convert.ToDateTime(r["FechaFinal"].ToString());
                    objEntidad.FechaFinalStr = r["FechaFinal"].ToString();

                    objEntidad.NroFeriado = Convert.ToInt32(r["NroFeriado"].ToString());

                    objEntidad.DiaInicial = r["DiaInicial"].ToString();
                    objEntidad.DiaFinal = r["DiaFinal"].ToString();
                }
            }
            catch (Exception ex)
            { }

            return objEntidad;
        }

    }
}
