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

    public class DatosPlanilla_CategoriaValores : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Planilla_CategoriaValoresCE> F_Planilla_CategoriaValores_Listar(int CodCodCategoria)
        {

            List<Planilla_CategoriaValoresCE> lista = new List<Planilla_CategoriaValoresCE>();
            Planilla_CategoriaValoresCE objEntidad = new Planilla_CategoriaValoresCE();

            try
            {
                objEntidad.CodCodCategoria = CodCodCategoria;

                DataTable table = (new Planilla_CategoriaValoresCN()).F_Planilla_CategoriaValores_Listar(objEntidad);

                foreach (DataRow r in table.Rows)
                {
                    Planilla_CategoriaValoresCE item = new Planilla_CategoriaValoresCE();
                    item.CodCodCategoriaValores = Convert.ToInt32(r["CodCategoriaValores"].ToString());
                    item.CodCodCategoria = Convert.ToInt32(r["CodCodCategoria"].ToString());
                    item.CodConceptoRemuneracion = Convert.ToInt32(r["CodConceptoRemuneracion"].ToString());
                    item.Categoria = r["Categoria"].ToString();
                    item.Concepto = r["Concepto"].ToString();
                    item.Valor = Convert.ToDecimal(r["Valor"].ToString());
                    item.Observacion = r["Observacion"].ToString();
                    item.Valor2 = Convert.ToDecimal(r["Valor2"].ToString());
                    item.TopeDiferencia = Convert.ToDecimal(r["TopeDiferencia"].ToString());
                    item.Tipo = r["Tipo"].ToString();
                    item.Clasificacion = r["Clasificacion"].ToString();
                    lista.Add(item);
                }
            }
            catch (Exception ex)
            { }

            return lista;
        }



        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Planilla_CategoriaValoresCE F_CategoriaValores_Actualizar(
            string RegistroOperacion, 
            int CodCodCategoriaValores, int CodCodCategoria, int CodConceptoRemuneracion,
            decimal Valor, string Observacion, decimal Valor2, decimal TopeDiferencia,
            string FechaInicial, string FechaFinal
            )
        {

            Planilla_CategoriaValoresCE objEntidad = new Planilla_CategoriaValoresCE();

            objEntidad.CodCodCategoriaValores = CodCodCategoriaValores;
            objEntidad.CodCodCategoria = CodCodCategoria;
            objEntidad.CodConceptoRemuneracion = CodConceptoRemuneracion;
            objEntidad.Valor = Valor;
            objEntidad.Observacion = Observacion;
            objEntidad.Valor2 = Valor2;
            objEntidad.TopeDiferencia = TopeDiferencia;
            objEntidad.FechaInicial = Convert.ToDateTime(FechaInicial);
            objEntidad.FechaFinal = Convert.ToDateTime(FechaFinal);
            objEntidad.CodUsuario = int.Parse(Session["CodUsuario"].ToString());

            try
            {
                if (objEntidad.RegistroOperacion == "Insert")
                {
                    objEntidad = (new Planilla_CategoriaValoresCN()).F_Planilla_CategoriaValores_Insert(objEntidad);
                    if (objEntidad.MsgError != "SE GRABO CORRECTAMENTE")
                        objEntidad.CodEstadoProceso = -1;
                }
                else
                {
                    objEntidad = (new Planilla_CategoriaValoresCN()).F_Planilla_CategoriaValores_Update(objEntidad);
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
        public Planilla_CategoriaValoresCE F_CategoriaValores_Agregar(int CodConceptoRemuneracion, int CodCodCategoria)
        {

            Planilla_CategoriaValoresCE objEntidad = new Planilla_CategoriaValoresCE();

            objEntidad.CodCodCategoria = CodCodCategoria;
            objEntidad.CodConceptoRemuneracion = CodConceptoRemuneracion;
            objEntidad.CodUsuario = int.Parse(Session["CodUsuario"].ToString());

            try
            {
                objEntidad = (new Planilla_CategoriaValoresCN()).F_Planilla_CategoriaValores_Agregar_Concepto(objEntidad);
                    if (objEntidad.MsgError != "SE GRABO CORRECTAMENTE")
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
        public Planilla_CategoriaValoresCE F_CategoriaValores_Eliminar(int CodCategoriaValores)
        {
            Planilla_CategoriaValoresCE objEntidad = new Planilla_CategoriaValoresCE();
            objEntidad.CodCodCategoriaValores = CodCategoriaValores;
            objEntidad.CodUsuario = int.Parse(Session["CodUsuario"].ToString());
            try
            {
                objEntidad = (new Planilla_CategoriaValoresCN()).F_Planilla_CategoriaValores_Eliminar(objEntidad);
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
        public Planilla_SalarioCE F_CategoriaValores_Recalcular_Reintegro(Int64 IDExcel)
        {
            Planilla_SalarioCE objEntidad = new Planilla_SalarioCE();
            objEntidad.IDExcel = IDExcel;
            objEntidad.EsReintegro = 1;
            objEntidad.CodUsuario = int.Parse(Session["CodUsuario"].ToString());
            try
            {
                objEntidad = (new Planilla_CategoriaValoresCN()).F_CategoriaValores_Recalcular_Reintegro(objEntidad);
                if (objEntidad.MsgError != "SE GRABO CORRECTAMENTE")
                    objEntidad.CodEstadoProceso = -1;
            }
            catch (Exception ex)
            {
                objEntidad.MsgError = ex.Message;
            }

            return objEntidad;
        }
    }
}
