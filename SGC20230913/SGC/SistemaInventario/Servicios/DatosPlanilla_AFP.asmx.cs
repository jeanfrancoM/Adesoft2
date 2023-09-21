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
    public class DatosPlanilla_AFP : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Planilla_AFPCE> F_Planilla_AFP_Listar(string Descripcion)
        {

            List<Planilla_AFPCE> lista = new List<Planilla_AFPCE>();
            Planilla_AFPCE objEntidad = new Planilla_AFPCE();

            try
            {
                objEntidad.Descripcion = Descripcion;

                DataTable table = (new Planilla_AFPCN()).F_Planilla_AFP_Listar(objEntidad);

                foreach (DataRow r in table.Rows)
                {
                    Planilla_AFPCE item = new Planilla_AFPCE();
                    item.CodAFP = Convert.ToInt32(r["CodAFP"].ToString());
                    item.Descripcion = r["Descripcion"].ToString();
                    item.Descripcion2 = r["Descripcion2"].ToString();
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
        public Planilla_AFPCE F_AFP_Actualizar(
            string RegistroOperacion, int CodAFP,
            string Descripcion, int CodEstado
            )
        {
            Planilla_AFPCE objEntidad = new Planilla_AFPCE();
            objEntidad.RegistroOperacion = RegistroOperacion;
            objEntidad.CodAFP = CodAFP;
            objEntidad.Descripcion = Descripcion;
            //objEntidad.Descripcion2 = Descripcion2;
            objEntidad.CodEstado = CodEstado;
            objEntidad.CodUsuario = int.Parse(Session["CodUsuario"].ToString());
            try
            {
                if (objEntidad.RegistroOperacion == "Insert")
                {
                    objEntidad = (new Planilla_AFPCN()).F_Planilla_AFP_Insert(objEntidad);
                    if (objEntidad.MsgError != "SE GRABO CORRECTAMENTE")
                        objEntidad.CodEstadoProceso = -1;
                }
                else
                {
                    objEntidad = (new Planilla_AFPCN()).F_Planilla_AFP_Update(objEntidad);
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
        public Planilla_AFPCE F_AFP_Eliminar(int CodAFP)
        {
            Planilla_AFPCE objEntidad = new Planilla_AFPCE();
            objEntidad.CodAFP = CodAFP;
            objEntidad.CodUsuario = int.Parse(Session["CodUsuario"].ToString());
            try
            {
                    objEntidad = (new Planilla_AFPCN()).F_Planilla_AFP_Eliminar(objEntidad);
                    if (objEntidad.MsgError != "SE ELIMINO CORRECTAMENTE")
                        objEntidad.CodEstadoProceso = -1;
            }
            catch (Exception ex)
            {
                objEntidad.MsgError = ex.Message;
            }

            return objEntidad;
        }

        /*[WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<TCConceptosDetCE> F_TCConceptosDet_Listar(int CodPrincipal)
        {

            List<TCConceptosDetCE> lista = new List<TCConceptosDetCE>();
            TCConceptosDetCE objEntidad = new TCConceptosDetCE();

            try
            {
                objEntidad.CodConcepto = CodPrincipal;
                DataTable table = (new TCConceptosDetCN()).F_TCConceptos_Select(objEntidad);


                foreach (DataRow r in table.Rows)
                {
                    TCConceptosDetCE item = new TCConceptosDetCE();
                    item.CodConcepto = Convert.ToInt32(r["CodConcepto"].ToString());
                    item.DscAbvConcepto = r["DscAbvConcepto"].ToString();
                    lista.Add(item);
                }
            }
            catch (Exception ex)
            { }

            return lista;
        }
        */
        /// <summary>
        /// Registro
        /// </summary>
        /// <param name="objEntidad"></param>
        /// <returns></returns>




    }
}
