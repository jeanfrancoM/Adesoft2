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
    public class LGProductosActualizacionPreciosCD
    {

        public DataTable F_LGProductosActualizacionPrecios_Listar(LGProductosActualizacionPreciosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductosActualizacionPrecios_Listar";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

                        if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                        {
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        }

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

        public DataTable F_LGProductosActualizacionPreciosDet_Listar(int CodActualizacionPrecios)
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
                        sql_comando.CommandText = "pa_LGProductosActualizacionPreciosDet_listar";

                        sql_comando.Parameters.Add("@CodActualizacionPrecios", SqlDbType.Int).Value = CodActualizacionPrecios;

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

        public LGProductosCE F_LGProductos_Actualizacion_Precios(LGProductosActualizacionPreciosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_Update";

                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 500).Value = objEntidadBE.Observacion;
	
                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter CodActualizacionPrecios = sql_comando.Parameters.Add("@CodActualizacionPrecios", SqlDbType.Int);
                        CodActualizacionPrecios.Direction = ParameterDirection.Output;

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

        public DataTable F_LGProductos_Actualizacion_ObtenerCambios(LGProductosActualizacionPreciosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_Actualizacion_ObtenerCambios";

                        sql_comando.Parameters.Add("@CodActualizacion", SqlDbType.Int).Value = objEntidadBE.CodActualizacionPrecios;

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

        public DataTable F_LGProductos_Actualizacion_ObtenerAlmacenes(LGProductosActualizacionPreciosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_Actualizacion_Almacenes";

                        sql_comando.Parameters.Add("@CodActualizacion", SqlDbType.Int).Value = objEntidadBE.CodActualizacionPrecios;

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

        public LGProductosCE F_LGProductos_Actualizacion_Precios_Almacenes(LGProductosActualizacionPreciosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_Actualizacion_Precios";

                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 500).Value = objEntidadBE.Observacion;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter CodActualizacionPrecios = sql_comando.Parameters.Add("@CodActualizacionPrecios", SqlDbType.Int);
                        CodActualizacionPrecios.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodActualizacionPrecios = Convert.ToInt32(CodActualizacionPrecios.Value);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public LGProductosCE F_LGProductos_Actualizar_Async(ref DataTable dta_tableActualizaciones, ref DataTable dta_tableAlmacenesExternos, int CodActualizacionPrecios, int CodUsuario)
        {
            LGProductosCE objEntidad = new LGProductosCE();
            string MensajeFinal = "";
            int CantidadErrores = 0;
            //realiza el recorrido por los almacenes a actualizar
            foreach (DataRow dr in dta_tableAlmacenesExternos.Rows) {
                int CodDetActualizar = (int)dr["CodDetActualizar"];
                int CodAlmacen = (int)dr["IdAlmacen"];
                string DscEmpresa = dr["DscEmpresa"].ToString();
                string DscAlmacen = dr["DscAlmacen"].ToString();
                string DBHost = dr["DBHost"].ToString();
                string DBDataBase = dr["DBDataBase"].ToString();
                string DBUser = dr["DBUser"].ToString();
                string DBPass = dr["DBPass"].ToString();
                string DBPort = dr["DBPort"].ToString();
                int Actualizado = (int)dr["Actualizado"];
                string MsgError = "";
                //actualiza sucursal
                F_LGProductos_Actualizar_Remoto(DBHost, DBDataBase, DBUser, DBPass, DBPort, dta_tableActualizaciones, out Actualizado, out MsgError);
                //actualiza detalle indicando si se actualizo o no
                F_LGProductosActualizacionPreciosDetActualizar_Update(CodDetActualizar, Actualizado, CodUsuario, MsgError);
                if (Actualizado == 0)
                {
                    MensajeFinal += " " + DscAlmacen;
                    CantidadErrores++;
                }
            }
            //actualiza cabecera
            F_LGProductosActualizacionPreciosActualizar_Update(CodActualizacionPrecios, CodUsuario, MensajeFinal);
            return objEntidad;
        }

        private void F_LGProductos_Actualizar_Remoto(string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort,
                                                        DataTable dtActualizaciones, out int Actualizado, out string MensajeError)
        {
            Actualizado = 0;
            MensajeError = "";
            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = (new SqlConnectionStringBuilder() { DataSource = DBHost, InitialCatalog = DBDataBase, UserID = DBUser, Password = DBPass }).ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_LGProductos_Actualizar";

                        SqlParameter myDataTable = sql_comando.Parameters.AddWithValue("@Actualizaciones", dtActualizaciones);

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        MensajeError = MsgError.Value.ToString();
                        Actualizado = 1;
                    }

                }



            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }
        }

        private void F_LGProductosActualizacionPreciosDetActualizar_Update(int CodDetActualizar, int Actualizado, int CodUsuario, string MsgError) {
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
                        sql_comando.CommandText = "pa_LGProductosActualizacionPreciosDetActualizar_Update";

                        sql_comando.Parameters.Add("@CodDetActualizar", SqlDbType.Int).Value = CodDetActualizar;
                        sql_comando.Parameters.Add("@Actualizado", SqlDbType.Int).Value = Actualizado;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = CodUsuario;
                        sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000).Value = MsgError;

                        sql_comando.ExecuteNonQuery();
                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }
        
        }

        private void F_LGProductosActualizacionPreciosActualizar_Update(int CodActualizacionPrecios, int CodUsuario, string MsgError)
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
                        sql_comando.CommandText = "pa_LGProductosActualizacionPreciosActualizar_Update";

                        sql_comando.Parameters.Add("@CodActualizacionPrecios", SqlDbType.Int).Value = CodActualizacionPrecios;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = CodUsuario;
                        sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000).Value = MsgError;

                        sql_comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }






        public LGProductosCE F_LGProductos_Actualizacion_Reintentar(LGProductosActualizacionPreciosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_Actualizacion_Reintentar";

                        sql_comando.Parameters.Add("@CodActualizacionPrecios", SqlDbType.Int).Value = objEntidadBE.CodActualizacionPrecios;
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
