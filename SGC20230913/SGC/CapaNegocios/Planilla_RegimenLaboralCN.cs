using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;


namespace CapaNegocios
{
    public class Planilla_RegimenLaboralCN
    {

        Planilla_RegimenLaboralCD obj = new Planilla_RegimenLaboralCD();


        public DataTable F_Planilla_RegimenLaboral_Listar(Planilla_RegimenLaboralCE objEntidad)
        {
            try
            {
                return obj.F_Planilla_RegimenLaboral_Listar(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Planilla_RegimenLaboralCE F_Planilla_RegimenLaboral_Insert(Planilla_RegimenLaboralCE objEntidadBE)
        {
            try
            {

                return obj.F_Planilla_RegimenLaboral_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Planilla_RegimenLaboralCE F_Planilla_RegimenLaboral_Update(Planilla_RegimenLaboralCE objEntidadBE)
        {
            try
            {

                return obj.F_Planilla_RegimenLaboral_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
