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

    public class DatosPlanilla_Categoria : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Planilla_CategoriaCE> F_Planilla_Categoria_Listar(string Descripcion)
        {

            List<Planilla_CategoriaCE> lista = new List<Planilla_CategoriaCE>();
            Planilla_CategoriaCE objEntidad = new Planilla_CategoriaCE();

            try
            {
                objEntidad.Descripcion = Descripcion;

                DataTable table = (new Planilla_CategoriaCN()).F_Planilla_Categoria_Listar(objEntidad);

                foreach (DataRow r in table.Rows)
                {
                    Planilla_CategoriaCE item = new Planilla_CategoriaCE();
                    item.CodCategoria = Convert.ToInt32(r["CodCategoria"].ToString());
                    item.Descripcion = r["Descripcion"].ToString();
                    item.CodRegimenLaboral = Convert.ToInt32(r["CodRegimenLaboral"].ToString());
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
        public Planilla_CategoriaCE F_Categoria_Actualizar(
            string RegistroOperacion, int CodCategoria, int CodRegimenLaboral,
            string Descripcion, int CodEstado
            )
        {
            Planilla_CategoriaCE objEntidad = new Planilla_CategoriaCE();
            objEntidad.RegistroOperacion = RegistroOperacion;
            objEntidad.CodCategoria = CodCategoria;
            objEntidad.Descripcion = Descripcion;
            objEntidad.CodRegimenLaboral = CodRegimenLaboral;
            objEntidad.CodEstado = CodEstado;
            objEntidad.CodUsuario = int.Parse(Session["CodUsuario"].ToString());
            try
            {
                if (objEntidad.RegistroOperacion == "Insert")
                {
                    objEntidad = (new Planilla_CategoriaCN()).F_Planilla_Categoria_Insert(objEntidad);
                    if (objEntidad.MsgError != "SE GRABO CORRECTAMENTE")
                        objEntidad.CodEstadoProceso = -1;
                }
                else
                {
                    objEntidad = (new Planilla_CategoriaCN()).F_Planilla_Categoria_Update(objEntidad);
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
        public Planilla_CategoriaCE F_Categoria_Eliminar(int CodCategoria)
        {
            Planilla_CategoriaCE objEntidad = new Planilla_CategoriaCE();
            objEntidad.CodCategoria = CodCategoria;
            objEntidad.CodUsuario = int.Parse(Session["CodUsuario"].ToString());
            try
            {
                objEntidad = (new Planilla_CategoriaCN()).F_Planilla_Categoria_Eliminar(objEntidad);
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
