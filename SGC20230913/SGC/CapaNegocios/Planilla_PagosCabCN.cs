using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;
namespace CapaNegocios
{
    public class Planilla_PagosCabCN
    {
        Planilla_PagosCabCD obj = new Planilla_PagosCabCD();
        public DataTable F_Planilla_Salario_Listar(Planilla_PagoCabCE objEntidadBE)
        {
           
            try
            {
                return obj.F_Planilla_Salario_Listar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
        public Planilla_PagoCabCE F_Planilla_Grabar_Pago(Planilla_PagoCabCE objEntidadBE, Planilla_PagoDetCE objEntidadBE2)
        {
            try
            {
                return obj.F_Planilla_Grabar_Pago(objEntidadBE, objEntidadBE2);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public Planilla_PagoCabCE F_Planilla_Eliminar_Pago(Planilla_PagoCabCE objEntidadBE, Planilla_PagoDetCE objEntidadBE2)
        {
            try
            {
                return obj.F_Planilla_Eliminar_Pago(objEntidadBE,objEntidadBE2);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable F_Planilla_Salario_ListarDet(Planilla_PagoCabCE objEntidadBE)
        {           
            try
            {
                return obj.F_Planilla_Salario_ListarDet(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
