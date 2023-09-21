using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace CapaDatos
{
    public class Planilla_PagosCabCD
    {
        public DataTable F_Planilla_Salario_Listar(Planilla_PagoCabCE objEntidadBE)
        {
            DataTable dta_consulta = null;

            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "Pa_Listar_Pagos_Planilla";
                        sql_comando.Parameters.Add("@CodRegimenLaboral", SqlDbType.Int).Value = objEntidadBE.CodRegimenLaboral;
                        sql_comando.Parameters.Add("@CodTrabajador", SqlDbType.Int).Value = objEntidadBE.CodTrabajador;
                        sql_comando.Parameters.Add("@CodSemana", SqlDbType.Int).Value = objEntidadBE.CodSemana;
                        sql_comando.Parameters.Add("@CodPeriodo", SqlDbType.Int).Value = objEntidadBE.CodPeriodo;

                        //if (objEntidadBE.Descripcion != "")
                        //    sql_comando.Parameters.Add("@Descripcion", SqlDbType.Int).Value = objEntidadBE.Descripcion;

                        dta_consulta = new DataTable();
                        dta_consulta.Load(sql_comando.ExecuteReader());
                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }
        public DataTable F_Planilla_Salario_ListarDet(Planilla_PagoCabCE objEntidadBE)
        {
            DataTable dta_consulta = null;

            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "Pa_Listar_Pagos_PlanillaDet";
                        sql_comando.Parameters.Add("@CodRegimenLaboral", SqlDbType.Int).Value = objEntidadBE.CodRegimenLaboral;
                        sql_comando.Parameters.Add("@CodTrabajador", SqlDbType.Int).Value = objEntidadBE.CodTrabajador;
                        sql_comando.Parameters.Add("@CodSemana", SqlDbType.Int).Value = objEntidadBE.CodSemana;
                        sql_comando.Parameters.Add("@CodPeriodo", SqlDbType.Int).Value = objEntidadBE.CodPeriodo;
                        sql_comando.Parameters.Add("@DesdeInt", SqlDbType.Int).Value = objEntidadBE.DesdeInt;
                        sql_comando.Parameters.Add("@HastaInt", SqlDbType.Int).Value = objEntidadBE.HastaInt;

                        //if (objEntidadBE.Descripcion != "")
                        //    sql_comando.Parameters.Add("@Descripcion", SqlDbType.Int).Value = objEntidadBE.Descripcion;

                        dta_consulta = new DataTable();
                        dta_consulta.Load(sql_comando.ExecuteReader());
                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }
        public Planilla_PagoCabCE F_Planilla_Grabar_Pago(Planilla_PagoCabCE objEntidadBE, Planilla_PagoDetCE objEntidadBE2)
        {
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "PA_Grabar_Paga_Planilla";
                        sql_comando.Parameters.Add("@CodPagoCab", SqlDbType.Int).Value = objEntidadBE.CodPagoCab;
                        sql_comando.Parameters.Add("@CodSalarioCab", SqlDbType.Int).Value = objEntidadBE.CodSalarioCab;
                        sql_comando.Parameters.Add("@CodRegimenLaboral", SqlDbType.Int).Value = objEntidadBE.CodRegimenLaboral;
                        sql_comando.Parameters.Add("@CodTrabajador", SqlDbType.Int).Value = objEntidadBE.CodTrabajador;
                        sql_comando.Parameters.Add("@CodSemana", SqlDbType.Int).Value = objEntidadBE.CodSemana;
                        sql_comando.Parameters.Add("@CodPeriodo", SqlDbType.Int).Value = objEntidadBE.CodPeriodo;
                        sql_comando.Parameters.Add("@CodProyecto", SqlDbType.Int).Value = objEntidadBE.CodProyecto;
                        sql_comando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = objEntidadBE2.Total;
                        sql_comando.Parameters.Add("@FechaPago", SqlDbType.SmallDateTime).Value = objEntidadBE2.FechaPago;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE2.CodUsuario;
                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();
                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        
                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Planilla_PagoCabCE F_Planilla_Eliminar_Pago(Planilla_PagoCabCE objEntidadBE, Planilla_PagoDetCE objEntidadBE2)
        {
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "PA_Eliminar_Paga_Planilla";
                        sql_comando.Parameters.Add("@CodPagoCab", SqlDbType.Int).Value = objEntidadBE.CodPagoCab;
                        sql_comando.Parameters.Add("@CodSalarioCab", SqlDbType.Int).Value = objEntidadBE.CodSalarioCab;
                        sql_comando.Parameters.Add("@CodPagoDet", SqlDbType.Int).Value = objEntidadBE2.CodPagoDet;
                        sql_comando.Parameters.Add("@CodRegimenLaboral", SqlDbType.Int).Value = objEntidadBE.CodRegimenLaboral;
                        sql_comando.Parameters.Add("@CodTrabajador", SqlDbType.Int).Value = objEntidadBE.CodTrabajador;
                        sql_comando.Parameters.Add("@CodSemana", SqlDbType.Int).Value = objEntidadBE.CodSemana;
                        sql_comando.Parameters.Add("@CodPeriodo", SqlDbType.Int).Value = objEntidadBE.CodPeriodo;                        
                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();
                        objEntidadBE.MsgError = MsgError.Value.ToString();

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
