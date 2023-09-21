using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;


namespace CapaNegocios
{
  public class NotaIngresoSalidaDetCN
    {
      NotaIngresoSalidaDetCD obj = new NotaIngresoSalidaDetCD();

        public DataTable F_NotaIngresoSalidaDet_Select(NotaIngresoSalidaDetCE objEntidadBE)
        {

            try
            {

                return obj.F_NotaIngresoSalidaDet_Select(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_NotaIngresoSalidaDet_Select_GuiaExterna(NotaIngresoSalidaDetCE objEntidadBE)
        {

            try
            {

                return obj.F_NotaIngresoSalidaDet_Select_GuiaExterna(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TrasladosDet_Select_GuiaExterna(NotaIngresoSalidaDetCE objEntidadBE)
        {

            try
            {

                return obj.F_TrasladosDet_Select_GuiaExterna(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_NotaIngresoSalidaDet_Select_Importaciones(NotaIngresoSalidaDetCE objEntidadBE)
        {

            try
            {

                return obj.F_NotaIngresoSalidaDet_Select_Importaciones(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_NotaIngresoSalidaDet_NotaPedido(NotaIngresoSalidaDetCE objEntidadBE)
        {

            try
            {

                return obj.F_NotaIngresoSalidaDet_NotaPedido(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_NotaIngresoSalidaDet_Select_OC(NotaIngresoSalidaDetCE objEntidadBE)
        {

            try
            {

                return obj.F_NotaIngresoSalidaDet_Select_OC(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_NotaIngresoSalidaDetSerializacionDet_Listar(NotaIngresoSalidaDetCE objEntidadBE)
        {

            try
            {

                return obj.F_NotaIngresoSalidaDetSerializacionDet_Listar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_NotaIngresoSalidaDet_Select_Importaciones_REEIM(NotaIngresoSalidaDetCE objEntidadBE)
        {

            try
            {

                return obj.F_NotaIngresoSalidaDet_Select_Importaciones_REEIM(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
