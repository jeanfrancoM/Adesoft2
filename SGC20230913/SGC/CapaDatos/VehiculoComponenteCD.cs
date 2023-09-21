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
    public class VehiculoComponenteCD

    {
        public VehiculoComponenteCE F_VehiculoComponentes_Insert(VehiculoComponenteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_VehiculoComponente_Insert";

                        sql_comando.Parameters.Add("@CodTipoVehiculo", SqlDbType.Int).Value = objEntidadBE.CodTipoVehiculo;
                        sql_comando.Parameters.Add("@CodTipoComponente", SqlDbType.Int).Value = objEntidadBE.CodTipoComponente;
                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 200).Value = objEntidadBE.Descripcion;

                        sql_comando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = objEntidadBE.Cantidad;
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


        public DataTable F_VehiculoComponentes_Listar(VehiculoComponenteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_VehiculoComponentes_Listar";

                        if (objEntidadBE.CodTipoComponente != 0)
                            sql_comando.Parameters.Add("@CodTipoComponente", SqlDbType.Int).Value = objEntidadBE.CodTipoComponente;

                        if (objEntidadBE.CodTipoVehiculo != 0)
                            sql_comando.Parameters.Add("@CodTipoVehiculo", SqlDbType.Int).Value = objEntidadBE.CodTipoVehiculo;

                        if (!objEntidadBE.Descripcion.Equals(""))
                            sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 500).Value = objEntidadBE.Descripcion;

                            sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
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

        //
        public VehiculoComponenteCE F_VehiculoComponentes_Eliminar(VehiculoComponenteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_VehiculoComponentes_Eliminar";

                        sql_comando.Parameters.Add("@CodVehiculoComponente", SqlDbType.Int).Value = objEntidadBE.CodVehiculoComponente;

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
        //

        public VehiculoComponenteCE F_VehiculoComponentes_Update(VehiculoComponenteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_VehiculoComponente_Update";

                        sql_comando.Parameters.Add("@CodVehiculoComponente", SqlDbType.Int).Value = objEntidadBE.CodVehiculoComponente;
                        sql_comando.Parameters.Add("@CodTipoVehiculo", SqlDbType.Int).Value = objEntidadBE.CodTipoVehiculo;
                        sql_comando.Parameters.Add("@CodTipoComponente", SqlDbType.Int).Value = objEntidadBE.CodTipoComponente;
                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 200).Value = objEntidadBE.Descripcion;

                        sql_comando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = objEntidadBE.Cantidad;
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

        public DataTable F_VEHICULOCOMPONENTE_AUDITORIA(VehiculoComponenteCE objEntidadBE)
        {
            DataTable dta_auditoria = null;
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
                        sql_comando.CommandText = "PA_VEHICULOCOMPONENTE_AUDITORIA";

                        sql_comando.Parameters.Add("@CodVehiculoComponente", SqlDbType.Int).Value = objEntidadBE.CodVehiculoComponente;

                        dta_auditoria = new DataTable();

                        dta_auditoria.Load(sql_comando.ExecuteReader());

                        return dta_auditoria;
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { dta_auditoria.Dispose(); }
        }



    }
}
