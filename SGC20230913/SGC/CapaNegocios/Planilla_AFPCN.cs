using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;


namespace CapaNegocios
{
    public class Planilla_AFPCN
    {

        Planilla_AFPCD obj = new Planilla_AFPCD();


        public DataTable F_Planilla_AFP_Listar(Planilla_AFPCE objEntidad)
        {
            try
            {
                return obj.F_Planilla_AFP_Listar(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Planilla_AFPCE F_Planilla_AFP_Insert(Planilla_AFPCE objEntidadBE)
        {
            try
            {

                return obj.F_Planilla_AFP_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Planilla_AFPCE F_Planilla_AFP_Update(Planilla_AFPCE objEntidadBE)
        {
            try
            {

                return obj.F_Planilla_AFP_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Planilla_AFPCE F_Planilla_AFP_Eliminar(Planilla_AFPCE objEntidadBE)
        {
            try
            {

                return obj.F_Planilla_AFP_Eliminar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
