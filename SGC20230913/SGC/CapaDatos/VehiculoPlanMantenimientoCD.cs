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
    public class VehiculoPlanMantenimientoCD

    {




        public VehiculoPlanMantenimientoCE F_TemporalVehiculoPlanMantenimientoDet_Insert(VehiculoPlanMantenimientoCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalVehiculoPlanMantenimientoDet_Insert";

                        sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodVehiculoPlanMantenimientoCab = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }


        public DataTable F_TemporalVehiculoPlanMantenimientoDet_Listar(VehiculoPlanMantenimientoCE objEntidadBE)
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
                        sql_comando.CommandText = "Pa_TemporalVehiculoPlanMantenimientoDet_Listar";

                        sql_comando.Parameters.Add("@CodVehiculoPlanMantenimientoCab", SqlDbType.Int).Value = objEntidadBE.CodVehiculoPlanMantenimientoCab;
;
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



        public DataTable F_TemporalVehiculoPlanMantenimientoDetalle_Insert(VehiculoPlanMantenimientoCE objEntidadBE)
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
                        sql_comando.CommandText = "Pa_TemporalVehiculoPlanMantenimientoDetalle_Insert";

                        sql_comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = objEntidadBE.CodVehiculoPlanMantenimientoCab;
                        sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;
                        dta_consulta = new DataTable();

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();

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



        public VehiculoPlanMantenimientoCE F_VehiculoPlanMantenimiento_Insert(VehiculoPlanMantenimientoCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_VehiculoPlanMantenimiento_Insert";


                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 200).Value = objEntidadBE.Descripcion;
                        sql_comando.Parameters.Add("@Kilometraje", SqlDbType.Decimal).Value = objEntidadBE.Kilometraje;
                        sql_comando.Parameters.Add("@Recorrido", SqlDbType.Decimal).Value = objEntidadBE.Recorrido;
                        sql_comando.Parameters.Add("@TiempoTrabajo", SqlDbType.Decimal).Value = objEntidadBE.TiempoTrabajo;

                        sql_comando.Parameters.Add("@CodVehiculoTipoPlan", SqlDbType.Int).Value = objEntidadBE.CodTipoPlan;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                      

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.Codigo = Convert.ToInt32(Codigo.Value);
                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable F_VehiculoPlanMantenimiento_Listar(VehiculoPlanMantenimientoCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_VehiculoPlanMantenimiento_Listar";
                        if (!objEntidadBE.Descripcion.Equals(""))
                            sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 200).Value = objEntidadBE.Descripcion;
                        if (objEntidadBE.CodEstado != 0)
                            sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        if (objEntidadBE.CodTipoPlan != 0)
                            sql_comando.Parameters.Add("@CodVehiculoTipoPlan", SqlDbType.Int).Value = objEntidadBE.CodTipoPlan;

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


        public DataTable F_VehiculoPlanMantenimientoDet_ListarXCodigo(VehiculoPlanMantenimientoCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_VehiculoPlanMantenimientoDet_ListarXCodigo";

                        sql_comando.Parameters.Add("@CodPlanMantenimiento", SqlDbType.Int).Value = objEntidadBE.CodVehiculoPlanMantenimientoCab;

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


        public DataTable F_VehiculoPlanMantenimientoCab_ObtenerXID(VehiculoPlanMantenimientoCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_VehiculoPlanMantenimientoCab_ObtenerXId";

                        sql_comando.Parameters.Add("@CodPlanMantenimientoCab", SqlDbType.Int).Value = objEntidadBE.CodVehiculoPlanMantenimientoCab;

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


        public VehiculoPlanMantenimientoCE F_VehiculoPlanMantenimiento_ObtenerXID(VehiculoPlanMantenimientoCE objEntidadBE)
        {
            try
            {

                DataTable dtDatos = F_VehiculoPlanMantenimientoCab_ObtenerXID(objEntidadBE);
                try
                {
                    foreach (DataRow i in dtDatos.Rows)
                    {
                        objEntidadBE.CodVehiculoPlanMantenimientoCab = int.Parse(i["CodVehiculoPlanMantenimientoCab"].ToString());
                        objEntidadBE.Descripcion = i["Descripcion"].ToString();
                        objEntidadBE.Kilometraje = Convert.ToDecimal(i["Kilometraje"]);
                        objEntidadBE.Recorrido = Convert.ToDecimal(i["Recorrido"]);
                        objEntidadBE.TiempoTrabajo = Convert.ToDecimal(i["TiempoTrabajo"]);
                        objEntidadBE.CodTipoPlan = int.Parse(i["CodVehiculoTipoPlan"].ToString());
                        objEntidadBE.CodEstado = int.Parse(i["CodEstado"].ToString());
                        objEntidadBE.MsgError = "";
                        

                        objEntidadBE.lPlanMantenimientoDet = new List<VehiculoPlanMantenimientoDetCE>();
                        dtDatos = F_VehiculoPlanMantenimientoDet_ListarXCodigo(objEntidadBE);
                        foreach (DataRow r in dtDatos.Rows)
                        {
                            objEntidadBE.lPlanMantenimientoDet.Add(new VehiculoPlanMantenimientoDetCE()
                            {
                                CodVehiculoPlanMantenimientoDet = int.Parse(r["CodVehiculoPlanMantenimientoDet"].ToString()),
                                CodVehiculoPlanMantenimientoCab = int.Parse(r["CodVehiculoPlanMantenimientoCab"].ToString()),
                                CodProducto = int.Parse(r["CodProducto"].ToString()),
                                Cantidad = int.Parse(r["Cantidad"].ToString()),
                                CodEstado = int.Parse(r["CodEstado"].ToString()),
                                DscProducto = r["Descripcion"].ToString(),
                                CodigoProducto = r["CodigoProducto"].ToString(),
                                UM = r["UM"].ToString(),
                                Marca = r["Marca"].ToString(),
                                CodDetalle = int.Parse(r["CodDetalle"].ToString()),
                                CodTipoProducto = int.Parse(r["CodTipoProducto"].ToString())
                               
                            });
                        }
                    }
                }
                catch (Exception ex)
                { }
                finally
                { }

                return objEntidadBE;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }




        public VehiculoPlanMantenimientoCE F_VehiculoPlanMantenimiento_Update(VehiculoPlanMantenimientoCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_VehiculoPlanMantenimiento_Update";


                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 200).Value = objEntidadBE.Descripcion;
                        sql_comando.Parameters.Add("@Kilometraje", SqlDbType.Decimal).Value = objEntidadBE.Kilometraje;
                        sql_comando.Parameters.Add("@Recorrido", SqlDbType.Decimal).Value = objEntidadBE.Recorrido;
                        sql_comando.Parameters.Add("@TiempoTrabajo", SqlDbType.Decimal).Value = objEntidadBE.TiempoTrabajo;
                        sql_comando.Parameters.Add("@CodVehiculoPlanMantenimientoCab", SqlDbType.Decimal).Value = objEntidadBE.CodVehiculoPlanMantenimientoAnterior;

                        sql_comando.Parameters.Add("@CodVehiculoTipoPlan", SqlDbType.Int).Value = objEntidadBE.CodTipoPlan;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;


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



        public VehiculoPlanMantenimientoCE F_VehiculoPlanMantenimiento_Eliminar(VehiculoPlanMantenimientoCE objEntidadBE)
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
                        sql_comando.CommandText = "Pa_VehiculoPlanMantenimiento_Eliminar";

                        sql_comando.Parameters.Add("@CodVehiculoPlanMantenimiento", SqlDbType.Int).Value = objEntidadBE.CodVehiculoPlanMantenimientoCab;

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



        public DataTable F_VehiculoPlanMantenimiento_AUDITORIA(VehiculoPlanMantenimientoCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_VehiculoPlanMantenimiento_AUDITORIA";

                        sql_comando.Parameters.Add("@CodVehiculoPlanMantenimiento", SqlDbType.Int).Value = objEntidadBE.CodVehiculoPlanMantenimientoCab;

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
