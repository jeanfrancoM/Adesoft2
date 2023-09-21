using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;


namespace CapaNegocios
{
    public class Planilla_CategoriaValoresCN
    {

        Planilla_CategoriaValoresCD obj = new Planilla_CategoriaValoresCD();


        public DataTable F_Planilla_CategoriaValores_Listar(Planilla_CategoriaValoresCE objEntidad)
        {
            try
            {
                return obj.F_Planilla_CategoriaValores_Listar(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable F_Planilla_Concepto_Categoria_Listar_SinAsignacion(Planilla_CategoriaValoresCE objEntidad)
        {
            try
            {
                return obj.F_Planilla_Concepto_Categoria_Listar_SinAsignacion(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable F_Planilla_Salario_Reintegros_Pendientes(Planilla_CategoriaValoresCE objEntidad)
        {
            try
            {
                return obj.F_Planilla_Salario_Reintegros_Pendientes(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Planilla_CategoriaValoresCE F_Planilla_CategoriaValores_Insert(Planilla_CategoriaValoresCE objEntidadBE)
        {
            try
            {

                return obj.F_Planilla_CategoriaValores_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Planilla_CategoriaValoresCE F_Planilla_CategoriaValores_Update(Planilla_CategoriaValoresCE objEntidadBE)
        {
            try
            {

                return obj.F_Planilla_CategoriaValores_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Planilla_CategoriaValoresCE F_Planilla_CategoriaValores_Eliminar(Planilla_CategoriaValoresCE objEntidadBE)
        {
            try
            {

                return obj.F_Planilla_CategoriaValores_Eliminar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Planilla_SalarioCE F_CategoriaValores_Recalcular_Reintegro(Planilla_SalarioCE objEntidadBE)
        {
            try
            {

                return obj.F_CategoriaValores_Recalcular_Reintegro(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public Planilla_CategoriaValoresCE F_Planilla_CategoriaValores_Agregar_Concepto(Planilla_CategoriaValoresCE objEntidadBE)
        {
            try
            {

                return obj.F_Planilla_CategoriaValores_Agregar_Concepto(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
