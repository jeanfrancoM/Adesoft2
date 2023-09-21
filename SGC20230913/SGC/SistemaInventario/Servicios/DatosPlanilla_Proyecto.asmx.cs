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

    public class DatosPlanilla_Proyecto : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Planilla_ProyectoCE> F_Planilla_Proyecto_Listar(int CodEstadoProceso, int CodEstado, string Descripcion)
        {

            List<Planilla_ProyectoCE> lista = new List<Planilla_ProyectoCE>();
            Planilla_ProyectoCE objEntidad = new Planilla_ProyectoCE();

            try
            {
                objEntidad.CodEstado = CodEstado;
                objEntidad.CodEstadoProceso = CodEstadoProceso;
                objEntidad.Descripcion = Descripcion;

                DataTable table = (new Planilla_ProyectoCN()).F_Planilla_Proyecto_Listar(objEntidad);

                foreach (DataRow r in table.Rows)
                {
                    Planilla_ProyectoCE item = new Planilla_ProyectoCE();
                    item.CodProyecto = Convert.ToInt32(r["CodProyecto"].ToString());
                    item.Descripcion = r["Descripcion"].ToString();
                    item.DescuentoSindical = Convert.ToDecimal(r["DescuentoSindical"].ToString());
                    item.CodEstadoProceso = Convert.ToInt32(r["CodEstadoProceso"].ToString());
                    item.Proceso = r["Proceso"].ToString();
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
        public Planilla_ProyectoCE F_Proyecto_Actualizar(
            string RegistroOperacion, int CodProyecto, decimal DescuentoSindical,
            string Descripcion, int CodEstado, int CodEstadoProceso
            )
        {
            Planilla_ProyectoCE objEntidad = new Planilla_ProyectoCE();
            objEntidad.RegistroOperacion = RegistroOperacion;
            objEntidad.CodProyecto = CodProyecto;
            objEntidad.Descripcion = Descripcion;
            objEntidad.DescuentoSindical = DescuentoSindical;
            objEntidad.CodEstado = CodEstado;
            objEntidad.CodEstadoProceso = CodEstadoProceso;
            objEntidad.CodUsuario = int.Parse(Session["CodUsuario"].ToString());
            try
            {
                if (objEntidad.RegistroOperacion == "Insert")
                {
                    objEntidad = (new Planilla_ProyectoCN()).F_Planilla_Proyecto_Insert(objEntidad);
                    if (objEntidad.MsgError != "SE GRABO CORRECTAMENTE")
                        objEntidad.CodEstadoProceso = -1;
                }
                else
                {
                    objEntidad = (new Planilla_ProyectoCN()).F_Planilla_Proyecto_Update(objEntidad);
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
        public Planilla_ProyectoCE F_Proyecto_Eliminar(int CodProyecto)
        {
            Planilla_ProyectoCE objEntidad = new Planilla_ProyectoCE();
            objEntidad.CodProyecto = CodProyecto;
            objEntidad.CodUsuario = int.Parse(Session["CodUsuario"].ToString());
            try
            {
                objEntidad = (new Planilla_ProyectoCN()).F_Planilla_Proyecto_Eliminar(objEntidad);
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
