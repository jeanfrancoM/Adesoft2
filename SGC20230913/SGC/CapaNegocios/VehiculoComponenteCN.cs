using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;

namespace CapaNegocios
{
    public class VehiculoComponenteCN
    {
        VehiculoComponenteCD obj = new VehiculoComponenteCD();

        public VehiculoComponenteCE F_VehiculoComponentes_Insert(VehiculoComponenteCE objEntidadBE)
        {
            try
            {
                return obj.F_VehiculoComponentes_Insert(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
       }

        public DataTable F_VehiculoComponentes_Listar(VehiculoComponenteCE objEntidadBE)
        {
            try
            {
                return obj.F_VehiculoComponentes_Listar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
       }

        public VehiculoComponenteCE F_VehiculoComponentes_Update(VehiculoComponenteCE objEntidadBE)
        {

            try
            {

                return obj.F_VehiculoComponentes_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public VehiculoComponenteCE F_VehiculoComponentes_Eliminar(VehiculoComponenteCE objEntidadBE)
        {

            try
            {

                return obj.F_VehiculoComponentes_Eliminar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public DataTable F_VEHICULOCOMPONENTE_AUDITORIA(VehiculoComponenteCE objEntidadBE)
        {
            try
            {
                return obj.F_VEHICULOCOMPONENTE_AUDITORIA(objEntidadBE);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
  
        
    }
}
