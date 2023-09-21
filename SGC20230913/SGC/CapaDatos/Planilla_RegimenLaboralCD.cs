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
    public class Planilla_RegimenLaboralCD
    {
        public DataTable F_Planilla_RegimenLaboral_Listar(Planilla_RegimenLaboralCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Planilla_RegimenLaboral_Listar";

                        if (objEntidadBE.Descripcion != "")
                            sql_comando.Parameters.Add("@Descripcion", SqlDbType.Int).Value = objEntidadBE.Descripcion;

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

        public Planilla_RegimenLaboralCE F_Planilla_RegimenLaboral_Insert(Planilla_RegimenLaboralCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_RegimenLaboral_Insert]";

                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 300).Value = objEntidadBE.Descripcion;
                        sql_comando.Parameters.Add("@Descripcion2", SqlDbType.VarChar, 300).Value = objEntidadBE.Descripcion2;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter CodRegimenLaboral = sql_comando.Parameters.Add("@CodRegimenLaboral", SqlDbType.Int);
                        CodRegimenLaboral.Direction = ParameterDirection.Output;


                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodRegimenLaboral = Convert.ToInt32(CodRegimenLaboral.Value.ToString());

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public Planilla_RegimenLaboralCE F_Planilla_RegimenLaboral_Update(Planilla_RegimenLaboralCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_RegimenLaboral_Update]";

                        sql_comando.Parameters.Add("@CodRegimenLaboral", SqlDbType.Int).Value = objEntidadBE.CodRegimenLaboral;
                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 300).Value = objEntidadBE.Descripcion;
                        sql_comando.Parameters.Add("@Descripcion2", SqlDbType.VarChar, 300).Value = objEntidadBE.Descripcion2;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
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
