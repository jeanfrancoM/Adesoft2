using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;


namespace CapaNegocios
{
    public class Planilla_SalarioCN
    {

        Planilla_SalarioCD obj = new Planilla_SalarioCD();


        public DataTable F_Planilla_Salario_Listar(Planilla_SalarioCE objEntidad)
        {
            try
            {
                return obj.F_Planilla_Salario_Listar(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataTable F_Planilla_Salario_Obtener(Planilla_SalarioCE objEntidad)
        {
            try
            {
                return obj.F_Planilla_Salario_Obtener(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable F_Planilla_Salario_Obtener_Por_Semana(Planilla_SalarioCE objEntidad)
        {
            try
            {
                return obj.F_Planilla_Salario_Obtener_Por_Semana(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable F_Planilla_Salario_Excel_Comparacion_ConsultaExcel(Planilla_SalarioCE objEntidad)
        {
            try
            {
                return obj.F_Planilla_Salario_Excel_Comparacion_ConsultaExcel(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public Planilla_SalarioCE F_Planilla_Salario_Insert(Planilla_SalarioCE objEntidadBE)
        {
            try
            {

                return obj.F_Planilla_Salario_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Planilla_SalarioCE F_Planilla_Salario_Update(Planilla_SalarioCE objEntidadBE)
        {
            try
            {

                return obj.F_Planilla_Salario_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public DataTable F_Planilla_Salario_Excel_Validaciones_Previas(long IdExcel, int CodProyecto, int CodRegimenLaboral)
        {
            try
            {
                return obj.F_Planilla_Salario_Excel_Validaciones_Previas(IdExcel, CodProyecto, CodRegimenLaboral);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataTable F_Planilla_Salario_Excel_Empleados_Validaciones_Previas(long IdExcel, int CodProyecto, int CodRegimenLaboral)
        {
            try
            {
                return obj.F_Planilla_Salario_Excel_Empleados_Validaciones_Previas(IdExcel, CodProyecto, CodRegimenLaboral);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public Planilla_SalarioCE F_Planilla_Salario_Excel_Proceso(Planilla_SalarioCE objEntidadBE)
        {
            try
            {
                return obj.F_Planilla_Salario_Excel_Proceso(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Planilla_SalarioCE F_Planilla_Salario_Excel_Proceso_Mensual(Planilla_SalarioCE objEntidadBE)
        {
            try
            {
                return obj.F_Planilla_Salario_Excel_Proceso_Mensual(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Planilla_SalarioCE F_Planilla_Salario_Excel_Comparacion(Planilla_SalarioCE objEntidadBE)
        {
            try
            {
                return obj.F_Planilla_Salario_Excel_Comparacion(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Planilla_Salario_Consulta_Construccion_Civil(Planilla_SalarioCE objEntidad)
        {
            try
            {
                return obj.F_Planilla_Salario_Consulta_Construccion_Civil(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable F_Planilla_Salario_Consulta_General(Planilla_SalarioCE objEntidad)
        {
            try
            {
                return obj.F_Planilla_Salario_Consulta_General(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Planilla_SalarioCE F_Eliminar_Carga_Excel_PlanillaRG(Planilla_SalarioCE objEntidadBE)
        {
            try
            {
                return obj.F_Eliminar_Carga_Excel_PlanillaRG(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Planilla_SalarioCE F_Confirmar_Pago_PlanillaRG(Planilla_SalarioCE objEntidadBE)
        {
            try
            {
                return obj.F_Confirmar_Pago_PlanillaRG(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Planilla_SalarioCE F_Eliminar_Carga_Excel_PlanillaRCC(Planilla_SalarioCE objEntidadBE)
        {
            try
            {
                return obj.F_Eliminar_Carga_Excel_PlanillaRCC(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Planilla_SalarioCE F_Confirmar_Pago_PlanillaRCC(Planilla_SalarioCE objEntidadBE)
        {
            try
            {
                return obj.F_Confirmar_Pago_PlanillaRCC(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable F_Planilla_Salario_Consulta_Construccion_Civil_Detalle(Planilla_SalarioCE objEntidad)
        {
            try
            {
                return obj.F_Planilla_Salario_Consulta_Construccion_Civil_Detalle(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable F_Planilla_Salario_Consulta_Construccion_General_Detalle(Planilla_SalarioCE objEntidad)
        {
            try
            {
                return obj.F_Planilla_Salario_Consulta_Construccion_General_Detalle(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable F_Planilla_Salario_Construccion_Civil_Boleta(Planilla_SalarioCE objEntidad)
        {
            try
            {
                return obj.F_Planilla_Salario_Construccion_Civil_Boleta(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataTable F_Planilla_Salario_Construccion_General_Boleta(Planilla_SalarioCE objEntidad)
        {
            try
            {
                return obj.F_Planilla_Salario_Construccion_General_Boleta(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
