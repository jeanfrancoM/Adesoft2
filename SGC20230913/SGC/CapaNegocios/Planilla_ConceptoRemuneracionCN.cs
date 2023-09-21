using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;


namespace CapaNegocios
{
    public class Planilla_ConceptoRemuneracionCN
    {

        Planilla_ConceptoRemuneracionCD obj = new Planilla_ConceptoRemuneracionCD();


        public DataTable F_Planilla_ConceptoRemuneracion_Listar(Planilla_ConceptoRemuneracionCE objEntidad)
        {
            try
            {
                return obj.F_Planilla_ConceptoRemuneracion_Listar(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Planilla_ConceptoRemuneracionCE F_Planilla_ConceptoRemuneracion_Insert(Planilla_ConceptoRemuneracionCE objEntidadBE)
        {
            try
            {

                return obj.F_Planilla_ConceptoRemuneracion_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Planilla_ConceptoRemuneracionCE F_Planilla_ConceptoRemuneracion_Update(Planilla_ConceptoRemuneracionCE objEntidadBE)
        {
            try
            {

                return obj.F_Planilla_ConceptoRemuneracion_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Planilla_ConceptoRemuneracionCE F_Planilla_ConceptoRemuneracion_Eliminar(Planilla_ConceptoRemuneracionCE objEntidadBE)
        {
            try
            {

                return obj.F_Planilla_ConceptoRemuneracion_Eliminar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
