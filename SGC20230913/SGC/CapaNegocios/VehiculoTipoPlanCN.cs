using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;

namespace CapaNegocios
{
    public class VehiculoTipoPlanCN
    {
        VehiculoTipoPlanCD obj = new VehiculoTipoPlanCD();

        public VehiculoTipoPlanCE F_VehiculoTipoPlan_Insert(VehiculoTipoPlanCE objEntidad)
        {
            try
            {

                return obj.F_VehiculoTipoPlan_Insert(objEntidad);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable F_VehiculoTipoPlan_Listado(VehiculoTipoPlanCE objEntidad)
        {
            try
            {

                return obj.F_VehiculoTipoPlan_Listado(objEntidad);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable F_VehiculoTipoPlan_Listar(VehiculoTipoPlanCE objEntidad)
        {
            try
            {

                return obj.F_VehiculoTipoPlan_Listar(objEntidad);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        
        public VehiculoTipoPlanCE F_VehiculoTipoPlan_Update(VehiculoTipoPlanCE objEntidad)
        {
            try
            {

                return obj.F_VehiculoTipoPlan_Update(objEntidad);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public VehiculoTipoPlanCE F_VehiculoTipoPlan_Delete(VehiculoTipoPlanCE objEntidad)
        {
            try
            {

                return obj.F_VehiculoTipoPlan_Delete(objEntidad);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        

      
    }
}
