using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;


namespace CapaNegocios
{
    public class Planilla_SemanaCN
    {

        Planilla_SemanaCD obj = new Planilla_SemanaCD();


        public DataTable F_Planilla_Semana_Listar(Planilla_SemanaCE objEntidad)
        {
            try
            {
                return obj.F_Planilla_Semana_Listar(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataTable F_Planilla_Semana_Obtener(Planilla_SemanaCE objEntidad)
        {
            try
            {
                return obj.F_Planilla_Semana_Obtener(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable F_Planilla_Semana_Obtener_Por_Semana(Planilla_SemanaCE objEntidad)
        {
            try
            {
                return obj.F_Planilla_Semana_Obtener_Por_Semana(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Planilla_SemanaCE F_Planilla_Semana_Insert(Planilla_SemanaCE objEntidadBE)
        {
            try
            {

                return obj.F_Planilla_Semana_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Planilla_SemanaCE F_Planilla_Semana_Update(Planilla_SemanaCE objEntidadBE)
        {
            try
            {

                return obj.F_Planilla_Semana_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
