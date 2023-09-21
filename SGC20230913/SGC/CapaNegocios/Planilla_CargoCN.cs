using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;
namespace CapaNegocios
{
    public class Planilla_CargoCN
    {
        Planilla_CargoCD obj = new Planilla_CargoCD();

        public DataTable F_Listar_Planilla_Cargo()
        {
            try
            {
                return obj.F_Listar_Planilla_Cargo();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
