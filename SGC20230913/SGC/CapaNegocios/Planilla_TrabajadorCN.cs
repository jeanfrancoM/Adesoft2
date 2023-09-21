using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;


namespace CapaNegocios
{
    public class Planilla_TrabajadorCN
    {

        Planilla_TrabajadorCD obj = new Planilla_TrabajadorCD();


        public DataTable F_Planilla_Trabajador_Listar(Planilla_TrabajadorCE objEntidad)
        {
            try
            {
                return obj.F_Planilla_Trabajador_Listar(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataTable F_Planilla_Trabajador_Obtener(Planilla_TrabajadorCE objEntidad)
        {
            try
            {
                return obj.F_Planilla_Trabajador_Obtener(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable F_Planilla_Trabajador_Obtener_Por_Trabajador(Planilla_TrabajadorCE objEntidad)
        {
            try
            {
                return obj.F_Planilla_Trabajador_Obtener_Por_Trabajador(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Planilla_TrabajadorCE F_Planilla_Trabajador_Insert(Planilla_TrabajadorCE objEntidadBE)
        {
            try
            {

                return obj.F_Planilla_Trabajador_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Planilla_TrabajadorCE F_Planilla_Trabajador_Update(Planilla_TrabajadorCE objEntidadBE)
        {
            try
            {

                return obj.F_Planilla_Trabajador_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Planilla_TrabajadorCE F_Planilla_Trabajador_Eliminar(Planilla_TrabajadorCE objEntidadBE)
        {
            try
            {

                return obj.F_Planilla_Trabajador_Eliminar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        public DataTable F_Planilla_Trabajador_Retenciones_Anteriores_Listar(Planilla_TrabajadorCE objEntidad)
        {
            try
            {
                return obj.F_Planilla_Trabajador_Retenciones_Anteriores_Listar(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Planilla_TrabajadorCE F_Planilla_Trabajador_Retenciones_Anteriores_Insert(Planilla_TrabajadorCE objEntidadBE)
        {
            try
            {

                return obj.F_Planilla_Trabajador_Retenciones_Anteriores_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public Planilla_TrabajadorCE F_Planilla_Trabajador_Retenciones_Anteriores_Update(Planilla_TrabajadorCE objEntidadBE)
        {
            try
            {

                return obj.F_Planilla_Trabajador_Retenciones_Anteriores_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public Planilla_TrabajadorCE F_Planilla_Trabajador_Retenciones_Anteriores_Eliminar(Planilla_TrabajadorCE objEntidadBE)
        {
            try
            {

                return obj.F_Planilla_Trabajador_Retenciones_Anteriores_Eliminar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
