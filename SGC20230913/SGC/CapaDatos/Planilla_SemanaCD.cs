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
    public class Planilla_SemanaCD
    {
        public DataTable F_Planilla_Semana_Listar(Planilla_SemanaCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Planilla_Semana_Listar";

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

        public DataTable F_Planilla_Semana_Obtener(Planilla_SemanaCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Planilla_Semana_Obtener";

                        sql_comando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = objEntidadBE.FechaInicial;

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

        public DataTable F_Planilla_Semana_Obtener_Por_Semana(Planilla_SemanaCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Planilla_Semana_Obtener_Por_Semana";

                        sql_comando.Parameters.Add("@AñoSemana", SqlDbType.VarChar, 6).Value = objEntidadBE.AñoSemana1;

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

        public Planilla_SemanaCE F_Planilla_Semana_Insert(Planilla_SemanaCE objEntidadBE)
        {
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.CommandTimeout = 90;

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "[pa_Semana_Insert]";

                        //sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 300).Value = objEntidadBE.Descripcion;
                        //sql_comando.Parameters.Add("@Descripcion2", SqlDbType.VarChar, 300).Value = objEntidadBE.Descripcion2;
                        //sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter CodSemana = sql_comando.Parameters.Add("@CodSemana", SqlDbType.Int);
                        CodSemana.Direction = ParameterDirection.Output;


                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodSemana = Convert.ToInt32(CodSemana);

                        return objEntidadBE;

                    }

                }



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
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.CommandTimeout = 90;

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "[pa_Semana_Update]";

                        sql_comando.Parameters.Add("@CodSemana", SqlDbType.Int).Value = objEntidadBE.CodSemana;
                        //sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 300).Value = objEntidadBE.Descripcion;
                        //sql_comando.Parameters.Add("@Descripcion2", SqlDbType.VarChar, 300).Value = objEntidadBE.Descripcion2;
                        //sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

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
