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
    public class Planilla_CargoCD
    {
        public DataTable F_Listar_Planilla_Cargo() 
        {
            DataTable dt_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();
                    using (SqlCommand sql_command = new SqlCommand())
                    {
                        sql_command.Connection = sql_conexion;
                        sql_command.CommandType = CommandType.StoredProcedure;
                        sql_command.CommandText = "pa_Listar_Planilla_Cargo";
                        dt_consulta = new DataTable();
                        dt_consulta.Load(sql_command.ExecuteReader());
                        return dt_consulta;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                dt_consulta.Dispose();
            }
        }
    }
}
