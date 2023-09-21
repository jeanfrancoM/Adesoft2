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
    public class Planilla_ProyectoCD
    {
        public DataTable F_Planilla_Proyecto_Listar(Planilla_ProyectoCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Planilla_Proyecto_Listar";

                        if (objEntidadBE.CodEstado != 0)
                            sql_comando.Parameters.Add("@CodEstadoProceso", SqlDbType.Int).Value = objEntidadBE.CodEstadoProceso;

                        if (objEntidadBE.CodEstado != 0)
                            sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;

                        if (objEntidadBE.Descripcion != "")
                            sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = objEntidadBE.Descripcion;

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


        public Planilla_ProyectoCE F_Planilla_Proyecto_Insert(Planilla_ProyectoCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_Proyecto_Insert]";

                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 300).Value = objEntidadBE.Descripcion;
                        sql_comando.Parameters.Add("@DescuentoSindical", SqlDbType.Decimal).Value = objEntidadBE.DescuentoSindical;
                        sql_comando.Parameters.Add("@CodEstadoProceso", SqlDbType.Int).Value = objEntidadBE.CodEstadoProceso;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter CodProyecto = sql_comando.Parameters.Add("@CodProyecto", SqlDbType.Int);
                        CodProyecto.Direction = ParameterDirection.Output;


                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodProyecto = Convert.ToInt32(CodProyecto.Value.ToString());

                        return objEntidadBE;

                    }

                }



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
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.CommandTimeout = 90;

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "[pa_Proyecto_Update]";

                        sql_comando.Parameters.Add("@CodProyecto", SqlDbType.Int).Value = objEntidadBE.CodProyecto;
                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 300).Value = objEntidadBE.Descripcion;
                        sql_comando.Parameters.Add("@DescuentoSindical", SqlDbType.Decimal).Value = objEntidadBE.DescuentoSindical;
                        sql_comando.Parameters.Add("@CodEstadoProceso", SqlDbType.Int).Value = objEntidadBE.CodEstadoProceso;
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

        public Planilla_ProyectoCE F_Planilla_Proyecto_Eliminar(Planilla_ProyectoCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_Proyecto_Eliminar]";

                        sql_comando.Parameters.Add("@CodProyecto", SqlDbType.Int).Value = objEntidadBE.CodProyecto;

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
