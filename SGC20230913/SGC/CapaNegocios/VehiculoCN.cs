using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;

namespace CapaNegocios
{
    public class VehiculoCN
    {
        VehiculoCD obj = new VehiculoCD();

        public VehiculoCE F_VEHICULO_Insert(VehiculoCE objEntidadBE)
        {
            try
            {
                return obj.F_VEHICULO_Insert(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
       }
        //VehiculoCN
        
        public DataTable F_Vehiculos_Listar(VehiculoCE objEntidadBE)
        {

            try
            {

                return obj.F_Vehiculos_Listar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_Listar_Modelo(VehiculoCE objEntidadBE)
        {

            try
            {

                return obj.F_Listar_Modelo(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public VehiculoCE F_Vehiculo_Eliminar(VehiculoCE objEntidadBE)
        {

            try
            {

                return obj.F_Vehiculo_Eliminar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public VehiculoCE F_Vehiculo_Update(VehiculoCE objEntidadBE)
        {

            try
            {

                return obj.F_Vehiculo_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public DataTable F_VEHICULO_OBSERVACION(VehiculoCE objEntidadBE)
        {
            try
            {
                return obj.F_VEHICULO_OBSERVACION(objEntidadBE);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable F_VEHICULO_AUDITORIA(VehiculoCE objEntidadBE)
        {
            try
            {
                return obj.F_VEHICULO_AUDITORIA(objEntidadBE);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_Vehiculo_Placas_AutoComplete(VehiculoCE objEntidadBE)
        {

            try
            {

                return obj.F_Vehiculo_Placas_AutoComplete(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
       
        
    }
}
