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
    public class DatosPlanilla_ConceptoRemuneracion : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Planilla_ConceptoRemuneracionCE> F_Planilla_ConceptoRemuneracion_Listar(string Descripcion)
        {

            List<Planilla_ConceptoRemuneracionCE> lista = new List<Planilla_ConceptoRemuneracionCE>();
            Planilla_ConceptoRemuneracionCE objEntidad = new Planilla_ConceptoRemuneracionCE();

            try
            {
                objEntidad.Descripcion = Descripcion;

                DataTable table = (new Planilla_ConceptoRemuneracionCN()).F_Planilla_ConceptoRemuneracion_Listar(objEntidad);

                foreach (DataRow r in table.Rows)
                {
                    Planilla_ConceptoRemuneracionCE item = new Planilla_ConceptoRemuneracionCE();
                    item.CodConceptoRemuneracion = Convert.ToInt32(r["CodConceptoRemuneracion"].ToString());
                    item.Descripcion = r["Descripcion"].ToString();
                    //item.CodRegimenLaboral = Convert.ToInt32(r["CodRegimenLaboral"].ToString());
                    item.CodEstado = Convert.ToInt32(r["CodEstado"].ToString());
                    item.Estado = r["Estado"].ToString();
                    lista.Add(item);
                }
            }
            catch (Exception ex)
            { }

            return lista;
        }



        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Planilla_ConceptoRemuneracionCE F_ConceptoRemuneracion_Actualizar(
            string RegistroOperacion, int CodConceptoRemuneracion, string Descripcion, int Orden, 
            int CodTipo, int CodEstado, int CodConceptoRemuneracion_Referencia, int CodClasificacion, int CodNaturaleza, int Orden2,
            int CodRegimenLaboral
            )
        {
            Planilla_ConceptoRemuneracionCE objEntidad = new Planilla_ConceptoRemuneracionCE();
            objEntidad.RegistroOperacion = RegistroOperacion;
            objEntidad.CodConceptoRemuneracion = CodConceptoRemuneracion;
            objEntidad.Descripcion = Descripcion;
            objEntidad.Orden = Orden;
            objEntidad.CodTipo = CodTipo;
            objEntidad.CodConceptoRemuneracion_Referencia = CodConceptoRemuneracion_Referencia;
            objEntidad.CodClasificacion = CodClasificacion;
            objEntidad.CodNaturaleza = CodNaturaleza;
            objEntidad.Orden2 = Orden2;
            objEntidad.CodRegimenLaboral = CodRegimenLaboral;

            objEntidad.CodEstado = CodEstado;
            objEntidad.CodUsuario = int.Parse(Session["CodUsuario"].ToString());



            try
            {
                if (objEntidad.RegistroOperacion == "Insert")
                {
                    objEntidad = (new Planilla_ConceptoRemuneracionCN()).F_Planilla_ConceptoRemuneracion_Insert(objEntidad);
                    if (objEntidad.MsgError != "SE GRABO CORRECTAMENTE")
                        objEntidad.CodEstadoProceso = -1;
                }
                else
                {
                    objEntidad = (new Planilla_ConceptoRemuneracionCN()).F_Planilla_ConceptoRemuneracion_Update(objEntidad);
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
        public Planilla_ConceptoRemuneracionCE F_ConceptoRemuneracion_Eliminar(int CodConceptoRemuneracion)
        {
            Planilla_ConceptoRemuneracionCE objEntidad = new Planilla_ConceptoRemuneracionCE();
            objEntidad.CodConceptoRemuneracion = CodConceptoRemuneracion;
            objEntidad.CodUsuario = int.Parse(Session["CodUsuario"].ToString());
            try
            {
                objEntidad = (new Planilla_ConceptoRemuneracionCN()).F_Planilla_ConceptoRemuneracion_Eliminar(objEntidad);
                if (objEntidad.MsgError != "SE ELIMINO CORRECTAMENTE")
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
