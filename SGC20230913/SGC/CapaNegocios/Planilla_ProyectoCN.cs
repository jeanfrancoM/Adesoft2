using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;


namespace CapaNegocios
{
    public class Planilla_ProyectoCN
    {

        Planilla_ProyectoCD obj = new Planilla_ProyectoCD();

        public DataTable F_Planilla_Proyecto_Listar(Planilla_ProyectoCE objEntidad)
        {
            try
            {
                return obj.F_Planilla_Proyecto_Listar(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        public Planilla_ProyectoCE F_Planilla_Proyecto_Insert(Planilla_ProyectoCE objEntidadBE)
        {
            try
            {

                return obj.F_Planilla_Proyecto_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Planilla_ProyectoCE F_Planilla_Proyecto_Update(Planilla_ProyectoCE objEntidadBE)
        {
            try
            {

                return obj.F_Planilla_Proyecto_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Planilla_ProyectoCE F_Planilla_Proyecto_Eliminar(Planilla_ProyectoCE objEntidadBE)
        {
            try
            {

                return obj.F_Planilla_Proyecto_Eliminar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
