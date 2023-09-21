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
    public class DatosLGProductosPresentaciones : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public LGProductosPresentacionesCE F_LGProductosPresentaciones_Actualizar(
            int CodProductoPresentacion, int CodProducto, int CodEstado, int CodUnidadMedida,
            decimal Factor, int CodMoneda, decimal Costo
            , decimal Precio1, decimal Precio2, decimal Precio3
            , decimal Precio4, decimal Precio5, decimal Precio6
            , string RegistroOperacion
            )
        {
            LGProductosPresentacionesCE objEntidad = new LGProductosPresentacionesCE();
            objEntidad.CodProductoPresentacion = CodProductoPresentacion;
            objEntidad.CodProducto = CodProducto;
            objEntidad.CodEstado = CodEstado;
            objEntidad.CodUnidadMedida = CodUnidadMedida;
            objEntidad.Factor = Factor;
            objEntidad.CodMoneda = CodMoneda;
            objEntidad.Costo = Costo;
            objEntidad.Precio1 = Precio1;
            objEntidad.Precio2 = Precio2;
            objEntidad.Precio3 = Precio3;
            objEntidad.Precio4 = Precio4;
            objEntidad.Precio5 = Precio5;
            objEntidad.Precio6 = Precio6;
            objEntidad.RegistroOperacion = RegistroOperacion;

            //objEntidad.Descripcion2 = Descripcion2;
            objEntidad.CodEstado = CodEstado;
            objEntidad.CodUsuario = int.Parse(Session["CodUsuario"].ToString());
            try
            {
                //if (objEntidad.RegistroOperacion == "Insert")
                //{
                //    objEntidad = (new LGProductosCN()).F_LGProductosPresentaciones_Insert(objEntidad);
                //    if (objEntidad.MsgError != "SE GRABO CORRECTAMENTE")
                //        objEntidad.CodEstadoProceso = -1;
                //}
                //else
                //{
                //    objEntidad = (new LGProductosCN()).F_LGProductosPresentaciones_Update(objEntidad);
                //    if (objEntidad.MsgError != "SE ACTUALIZO CORRECTAMENTE")
                //        objEntidad.CodEstadoProceso = -1;
                //}

                switch (objEntidad.RegistroOperacion)
                {
                    case "Insert":
                            objEntidad = (new LGProductosCN()).F_LGProductosPresentaciones_Insert(objEntidad);
                            if (objEntidad.MsgError != "SE GRABO CORRECTAMENTE")
                                objEntidad.CodEstadoProceso = -1;
                        break;
                    case "Update":
                            objEntidad = (new LGProductosCN()).F_LGProductosPresentaciones_Update(objEntidad);
                            if (objEntidad.MsgError != "SE ACTUALIZO CORRECTAMENTE")
                                objEntidad.CodEstadoProceso = -1;
                        break;
                    case "Delete":
                        objEntidad = (new LGProductosCN()).F_LGProductosPresentaciones_Delete(objEntidad);
                        if (objEntidad.MsgError != "SE ELIMINO CORRECTAMENTE")
                            objEntidad.CodEstadoProceso = -1;
                        break;
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
        public List<LGProductosPresentacionesCE> F_LGProductosPresentaciones_Listar_UM_Ventas(int CodProducto, int CodMoneda, decimal TC)
        {
            List<LGProductosPresentacionesCE> lista = (new LGProductosCN()).F_LGProductosPresentaciones_Listar_UM_Ventas(CodProducto, CodMoneda, TC);

            return lista;
        }

    }
}
