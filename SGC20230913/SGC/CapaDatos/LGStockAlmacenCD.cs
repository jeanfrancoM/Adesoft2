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
    public class LGStockAlmacenCD
    {
        public bool F_LGProductos_ActualizarStocks_Azure(LGStockAlmacenCE objEntidadBE)
        {
            bool res = false;
            try
            {
                bool Conectado = false;
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["AZURE"].ConnectionString;
                    try
                    {
                        sql_conexion.Open();
                        Conectado = true;
                    }
                    catch (Exception)
                    { }

                    if (Conectado == true)
                        try
                        {
                            using (SqlCommand sql_comando = new SqlCommand())
                            {

                                sql_comando.Connection = sql_conexion;
                                sql_comando.CommandType = CommandType.StoredProcedure;
                                sql_comando.CommandText = "pa_LGProductos_ActualizarStocks";

                                sql_comando.Parameters.Add("@CodProductoAzure", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                                sql_comando.Parameters.Add("@Almacen", SqlDbType.VarChar, 100).Value = objEntidadBE.DscAlmacen;
                                sql_comando.Parameters.Add("@StockActual", SqlDbType.Int).Value = objEntidadBE.StockActual;

                                sql_comando.ExecuteNonQuery();
                                res = true;
                            }
                        }
                        catch (Exception exx)
                        {
                            res = false;
                        }
                }
            }
            catch (Exception ex)
            {
            }
            return res;
        }

        /// <summary>
        /// Actualizacion de Stocks Asincronos (producto por producto)
        /// </summary>
        /// <param name="objEntidadBE"></param>
        public LGStockAlmacenCE Async_F_LGProductos_ActualizarStocks_Azure(LGStockAlmacenCE objEntidadBE)
        {
            csAsyn_LGProductos_actualizarStocks_Azure pAsync = new csAsyn_LGProductos_actualizarStocks_Azure();
            pAsync.Async_F_LGProductos_ActualizarStocks_Azure(objEntidadBE);
            return null;
        }
        private class csAsyn_LGProductos_actualizarStocks_Azure
        {

            /// <summary>
            /// proceso de Actualizacion de stocks (producto por producto)
            /// </summary>
            /// <param name="objEntidadBE"></param>
            public void Async_F_LGProductos_ActualizarStocks_Azure(LGStockAlmacenCE objEntidadBE)
            {
                System.Threading.Thread thread = new System.Threading.Thread(() => F_LGProductos_ActualizarStocks_Azure(objEntidadBE));
                thread.Start();
            }
            private void F_LGProductos_ActualizarStocks_Azure(LGStockAlmacenCE objEntidadBE)
            {
                objEntidadBE.res = false;
                try
                {
                    bool Conectado = false;
                    using (SqlConnection sql_conexion = new SqlConnection())
                    {
                        sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["AZURE"].ConnectionString;
                        try
                        {
                            sql_conexion.Open();
                            Conectado = true;
                        }
                        catch (Exception)
                        { }

                        if (Conectado == true)
                            try
                            {
                                using (SqlCommand sql_comando = new SqlCommand())
                                {

                                    sql_comando.Connection = sql_conexion;
                                    sql_comando.CommandType = CommandType.StoredProcedure;
                                    sql_comando.CommandText = "pa_LGProductos_ActualizarStocks";

                                    sql_comando.Parameters.Add("@CodProductoAzure", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                                    sql_comando.Parameters.Add("@Almacen", SqlDbType.VarChar, 100).Value = objEntidadBE.DscAlmacen;
                                    sql_comando.Parameters.Add("@StockActual", SqlDbType.Int).Value = objEntidadBE.StockActual;

                                    sql_comando.ExecuteNonQuery();
                                    objEntidadBE.res = true;
                                    F_LGStockAlmacen_ActualizaFlag(objEntidadBE.CodAlmacen, objEntidadBE.CodProducto, 0);
                                }
                            }
                            catch (Exception exx)
                            {
                            }
                    }
                }
                catch (Exception ex)
                {
                }
            }
            private void F_LGStockAlmacen_ActualizaFlag(int CodAlmacen, int CodProducto, int Flag)
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
                            sql_comando.CommandText = "pa_LGStockAlmacen_ActualizaFlag";

                            sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = CodProducto;
                            sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = CodAlmacen;
                            sql_comando.Parameters.Add("@Flag", SqlDbType.Int).Value = Flag;

                            sql_comando.ExecuteNonQuery();

                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }

        }


        /// <summary>
        /// Actualizacion de Stocks Asincronos (producto por producto)
        /// </summary>
        /// <param name="objEntidadBE"></param>
        public LGStockAlmacenCE Async_F_LGProductos_ActualizarStocks_Lotes_Azure()
        {
            csAsyn_LGProductos_actualizarStocks_Lotes_Azure pAsync = new csAsyn_LGProductos_actualizarStocks_Lotes_Azure();
            pAsync.Async_F_LGProductos_ActualizarStocks_Lotes_Azure();
            return null;
        }
        private class csAsyn_LGProductos_actualizarStocks_Lotes_Azure
        {

            /// <summary>
            /// proceso de Actualizacion de stocks (producto por lotes)
            /// </summary>
            /// <param name="objEntidadBE"></param>
            public void Async_F_LGProductos_ActualizarStocks_Lotes_Azure()
            {
                System.Threading.Thread thread = new System.Threading.Thread(() => F_LGProductos_ActualizarStocks_Lotes_Azure());
                thread.Start();
            }
            private void F_LGProductos_ActualizarStocks_Lotes_Azure()
            {
                string Etiqueta = ""; string MsgPers = "";
                try
                {
                    DataTable dtStocks = pa_LGStockAlmacen_PorActualizar_Azure();
                    if (dtStocks.Rows.Count > 0)
                    {
                        bool Conectado = false;
                        using (SqlConnection sql_conexion = new SqlConnection())
                        {
                            sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["AZURE"].ConnectionString;
                            try
                            {
                                sql_conexion.Open();
                                Conectado = true;
                            }
                            catch (Exception exc)
                            {
                                Etiqueta = "1"; MsgPers = "Conectandose: " + ConfigurationManager.ConnectionStrings["AZURE"].ConnectionString;
                                F_LGStockAlmacen_Logs_Sincronizaciones_Azure_insert("LGStockAlmacenCD.F_LGProductos_ActualizarStocks_Lotes_Azure Etiqueta:" + Etiqueta + " " + MsgPers, "", exc.Message.ToString());
                            }

                            if (Conectado == true)
                                try
                                {
                                    using (SqlCommand sql_comando = new SqlCommand())
                                    {

                                        sql_comando.Connection = sql_conexion;
                                        sql_comando.CommandType = CommandType.StoredProcedure;
                                        sql_comando.CommandText = "pa_LGProductos_ActualizarStocks_Lotes";

                                        SqlParameter myDataTable = sql_comando.Parameters.AddWithValue("@Stocks", dtStocks);
                                        sql_comando.ExecuteNonQuery();

                                        F_LGStockAlmacen_ActualizarFlag_Lotes(dtStocks, 0);
                                    }
                                }
                                catch (Exception exx)
                                {
                                    Etiqueta = "4"; MsgPers = "";
                                    F_LGStockAlmacen_Logs_Sincronizaciones_Azure_insert("LGStockAlmacenCD.F_LGProductos_ActualizarStocks_Lotes_Azure Etiqueta:" + Etiqueta + " " + MsgPers, "", exx.Message.ToString());
                                }
                        }
                    }

                }
                catch (Exception ex)
                {
                    Etiqueta = "5"; MsgPers = "";
                    F_LGStockAlmacen_Logs_Sincronizaciones_Azure_insert("LGStockAlmacenCD.F_LGProductos_ActualizarStocks_Lotes_Azure Etiqueta:" + Etiqueta + " " + MsgPers, "", ex.Message.ToString());
                }
            }
            private DataTable pa_LGStockAlmacen_PorActualizar_Azure()
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
                            sql_comando.CommandText = "pa_LGStockAlmacen_PorActualizar_Azure";

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
            private void F_LGStockAlmacen_ActualizarFlag_Lotes(DataTable dtStocks, int Flag)
            {
                string Etiqueta = ""; string MsgPers = "";
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
                            sql_comando.CommandText = "pa_LGStockAlmacen_ActualizarFlag_Lotes";

                            SqlParameter myDataTable = sql_comando.Parameters.AddWithValue("@Stocks", dtStocks);
                            sql_comando.Parameters.Add("@Flag", SqlDbType.Int).Value = Flag;

                            sql_comando.ExecuteNonQuery();

                        }
                    }
                }
                catch (Exception ex)
                {
                    Etiqueta = "6"; MsgPers = "";
                    F_LGStockAlmacen_Logs_Sincronizaciones_Azure_insert("LGStockAlmacenCD.F_LGStockAlmacen_ActualizarFlag_Lotes Etiqueta:" + Etiqueta + " " + MsgPers, "", ex.Message.ToString());
                }
            }
            private void F_LGStockAlmacen_Logs_Sincronizaciones_Azure_insert(string Procedimiento, string NroError, string MsgError)
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
                            sql_comando.CommandText = "pa_LGStockAlmacen_Logs_Sincronizaciones_Azure_insert";

                            sql_comando.Parameters.Add("@Procedimiento", SqlDbType.VarChar, 200).Value = Procedimiento;
                            sql_comando.Parameters.Add("@NroError", SqlDbType.VarChar, 200).Value = NroError;
                            sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000).Value = MsgError;

                            sql_comando.ExecuteNonQuery();

                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }

        }

        public DataTable F_LGProductos_Stocks_Externos_Azure(int CodProducto, string AlmacenActual)
        {

            DataTable dta_consulta = null;

            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["AZURE"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_LGProductos_Stocks_Externos";

                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = CodProducto;
                        sql_comando.Parameters.Add("@Almacen", SqlDbType.VarChar, 50).Value = AlmacenActual;

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


        public DataTable F_LGStockAlmacen_StockActual_Producto(int CodProducto, int AlmacenActual)
        {

            DataTable dta_consulta = null;

            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["AZURE"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_LGStockAlmacen_StockActual_Producto";

                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = CodProducto;
                        sql_comando.Parameters.Add("@Almacen", SqlDbType.Int).Value = AlmacenActual;

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

        public DataTable F_LGStockAlmacen_StockActual_Producto_CA(string CodAlterno, int AlmacenActual)
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
                        sql_comando.CommandText = "pa_LGStockAlmacen_StockActual_Producto_CA";

                        sql_comando.Parameters.Add("@CodAlterno", SqlDbType.VarChar, 15).Value = CodAlterno;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = AlmacenActual;

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




    }

}
