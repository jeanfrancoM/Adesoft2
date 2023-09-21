using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;


namespace CapaNegocios
{
    public class Planilla_PeriodoCN
    {

        Planilla_PeriodoCD obj = new Planilla_PeriodoCD();


        public DataTable F_Planilla_Periodo_Listar(Planilla_PeriodoCE objEntidad)
        {
            try
            {
                return obj.F_Planilla_Periodo_Listar(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataTable F_Planilla_Periodo_Obtener(Planilla_PeriodoCE objEntidad)
        {
            try
            {
                return obj.F_Planilla_Periodo_Obtener(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable F_Planilla_Periodo_Obtener_Por_Periodo(Planilla_PeriodoCE objEntidad)
        {
            try
            {
                return obj.F_Planilla_Periodo_Obtener_Por_Periodo(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Planilla_PeriodoCE F_Planilla_Periodo_Insert(Planilla_PeriodoCE objEntidadBE)
        {
            try
            {

                return obj.F_Planilla_Periodo_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Planilla_PeriodoCE F_Planilla_Periodo_Update(Planilla_PeriodoCE objEntidadBE)
        {
            try
            {

                return obj.F_Planilla_Periodo_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
