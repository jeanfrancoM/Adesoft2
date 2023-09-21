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
    public class TCAlmacenCD
    {
        public DataTable F_TCAlmacen_Listar(TCAlmacenCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TCAlmacen_Listar";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        if (objEntidadBE.CodAlmacen != 0)
                            sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

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

        public DataTable F_TCAlmacen_Actual(TCAlmacenCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TCAlmacen_Actual";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

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

        public DataTable F_TCAlmacen_Listar(int codEmp)
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
                        sql_comando.CommandText = "pa_TCAlmacen_Listar";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = codEmp;

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

        public DataTable F_DscDestinos_Listar(TCAlmacenCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DscDestinos_Listar";

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

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

        public DataTable F_TCAlmacen_ObtenerDatos(int CodAlmacen)
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
                        sql_comando.CommandText = "pa_TCAlmacen_ObtenerDatos";

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = CodAlmacen;

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

        public DataTable F_TCAlmacen_Listar_Conexiones(TCAlmacenCE objEntidad)
        {
            #region VARIABLES
            DataTable dta_consulta = null;

            #endregion

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
                        sql_comando.CommandText = "[pa_TCAlmacen_Listar_Conexiones]";

                        #region PARAMETROS
                        if (objEntidad.Clave != "")
                            sql_comando.Parameters.Add("@Clave", SqlDbType.VarChar, 200).Value = objEntidad.Clave;
                        #endregion

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

            finally
            {
                dta_consulta.Dispose();
            }
        }

        public DataTable F_Consulta_Stock_Almacen_Externo(TCAlmacenCE objEnt)
        {
            #region VARIABLES
            DataTable dta_consulta = null;

            #endregion

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
                        sql_comando.CommandText = "[pa_Consulta_Stock_Almacen_Externo]";

                        #region PARAMETROS
                        sql_comando.Parameters.Add("@CodigoProducto", SqlDbType.VarChar, 50).Value = objEnt.CodigoProducto;
                        sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 50).Value = objEnt.Marca;
                        #endregion

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;

                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            finally
            {
                dta_consulta.Dispose();
            }
        }

        public decimal F_Consulta_Stock_Almacen_Remoto(TCAlmacenCE objEnt)
        {
            #region VARIABLES
            decimal Stock = 0;
            DataTable dta_consulta = null;

            #endregion

            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    //sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.ConnectionString = (new SqlConnectionStringBuilder() { DataSource = objEnt.DBHost, InitialCatalog = objEnt.DBDataBase, UserID = objEnt.DBUser, Password = objEnt.DBPass }).ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandTimeout = 10;
                        //sql_comando.CommandText = "pa_Consulta_Stock";

                        string Query = " 	select " +
                                       "       sa.CodEmpresa, sa.CodAlmacen, sa.StockActual, " +
                                       "       pro.DscProducto, pro.CodigoProducto " +
                                       "   from LGStockAlmacen sa " +
                                       "       inner join LGProductos pro on pro.CodProducto = sa.CodProducto " +
                                       "   where Annio = YEAR(getdate()) " +
                                       "   and pro.CodEmpresa = " + objEnt.CodEmpresa.ToString() + " and pro.CodAlmacen = " + objEnt.CodAlmacen.ToString() +
                                       "   and CodigoProducto = '" + objEnt.CodigoProducto + "' " +
                                       "   order by pro.CodigoProducto ";
                        sql_comando.CommandText = Query;


                        //#region PARAMETROS
                        //if (objEnt.Clave != "")
                        //    sql_comando.Parameters.Add("@Clave", SqlDbType.VarChar, 200).Value = objEnt.Clave;
                        //#endregion

                        dta_consulta = new DataTable();

                        //dta_consulta.Load(sql_comando.ExecuteReader());

                        SqlDataAdapter adapter = new SqlDataAdapter(Query, sql_conexion);
                        adapter.Fill(dta_consulta);

                        Stock = decimal.Parse(dta_consulta.Rows[0]["StockActual"].ToString());


                        return Stock;

                    }
                }
            }
            catch (Exception ex)
            {
                return Stock;
            }

            finally
            {
                dta_consulta.Dispose();
            }
        }

        public DataTable F_TCAlmacenesExternos_Listar_Parametros_Conexion()
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
                        sql_comando.CommandText = "pa_TCAlmacenesExternos_Listar_Parametros_Conexion";
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

        public DataTable F_TCAlmacenesExternos_Listar(int SoloExternos)
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
                        sql_comando.CommandText = "pa_TCAlmacenesExternos_Listar";
                        sql_comando.Parameters.Add("@SoloExternos", SqlDbType.Int).Value = SoloExternos;
                       // sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = CodAlmacen;
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

        public DataTable F_Consulta_Stock_Azure(int CodProductoAzure, string CodigoInterno)
        {
            DataTable dta_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    try
                    {
                        sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["AZURE"].ConnectionString;
                        sql_conexion.Open();
                        //sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                        //sql_conexion.Open();
                        using (SqlCommand sql_comando = new SqlCommand())
                        {
                            sql_comando.Connection = sql_conexion;
                            sql_comando.CommandType = CommandType.StoredProcedure;
                            sql_comando.CommandText = "pa_LGProductos_Stocks";
                            sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = CodProductoAzure;
                            sql_comando.Parameters.Add("@CodigoInterno", SqlDbType.VarChar, 100).Value = CodigoInterno;
                            dta_consulta = new DataTable();

                            dta_consulta.Load(sql_comando.ExecuteReader());
                        }
                    }
                    catch (Exception)
                    {
                        dta_consulta = null;
                    }
                }
            }
            catch (Exception ex)
            {
                dta_consulta = null;
            }
            return dta_consulta;
        }

        public DataTable F_Consulta_Stock_Azure_Salcedo(int CodProductoAzure, string CodigoInterno)
        {
            DataTable dta_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    try
                    {
                        //sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["AZURE"].ConnectionString;
                        //sql_conexion.Open();
                        sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                        sql_conexion.Open();
                        using (SqlCommand sql_comando = new SqlCommand())
                        {
                            sql_comando.Connection = sql_conexion;
                            sql_comando.CommandType = CommandType.StoredProcedure;
                            sql_comando.CommandText = "pa_LGProductos_Stocks";
                            sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = CodProductoAzure;
                            sql_comando.Parameters.Add("@CodigoInterno", SqlDbType.VarChar, 100).Value = CodigoInterno;
                            dta_consulta = new DataTable();

                            dta_consulta.Load(sql_comando.ExecuteReader());
                        }
                    }
                    catch (Exception)
                    {
                        dta_consulta = null;
                    }
                }
            }
            catch (Exception ex)
            {
                dta_consulta = null;
            }
            return dta_consulta;
        }

        public DataTable F_LGStockAlmacen_StockArticulo(int CodProductoAzure, int CodProducto, int CodAlmacen)
        {
            DataTable dta_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    try
                    {
                        sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                        sql_conexion.Open();

                        using (SqlCommand sql_comando = new SqlCommand())
                        {
                            sql_comando.Connection = sql_conexion;
                            sql_comando.CommandType = CommandType.StoredProcedure;
                            sql_comando.CommandText = "pa_LGStockAlmacen_StockArticulo";
                            if (CodProductoAzure > 0)
                                sql_comando.Parameters.Add("@CodProductoAzure", SqlDbType.Int).Value = CodProductoAzure;
                            else
                                sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = CodProducto;
                            sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = CodAlmacen;
                            dta_consulta = new DataTable();

                            dta_consulta.Load(sql_comando.ExecuteReader());
                        }
                    }
                    catch (Exception)
                    {
                        dta_consulta = null;
                    }
                }
            }
            catch (Exception ex)
            {
                dta_consulta = null;
            }
            return dta_consulta;
        }

        public DataTable F_TCAlmacen_Listar_Excluyente(TCAlmacenCE objEntidad)
        {
            #region VARIABLES
            DataTable dta_consulta = null;

            #endregion

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
                        sql_comando.CommandText = "pa_TCAlmacen_Listar_Excluyente";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidad.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidad.CodAlmacen;

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

            finally
            {
                dta_consulta.Dispose();
            }
        }

        public DataTable F_TCALMACEN_LISTAR_TODOS(TCAlmacenCE objEntidad)
        {
            #region VARIABLES
            DataTable dta_consulta = null;

            #endregion

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
                        sql_comando.CommandText = "PA_TCALMACEN_LISTAR_TODOS";

                        if (objEntidad.CodEstado>0)
                            sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidad.CodEstado;
                       
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

            finally
            {
                dta_consulta.Dispose();
            }
        }

        public DataTable F_ListarAlmacenesExternos()
        {
            #region VARIABLES
            DataTable dta_consulta = null;

            #endregion

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
                        sql_comando.CommandText = "pa_ListarAlmacenesExternos";                        

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

            finally
            {
                dta_consulta.Dispose();
            }
        }

        public DataTable F_Lista_Almacenes_Deudas_Clientes()
        {
            #region VARIABLES
            DataTable dta_consulta = null;

            #endregion

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
                        sql_comando.CommandText = "pa_Lista_Almacenes_Deudas_Clientes";

                        #region PARAMETROS
                        //sql_comando.Parameters.Add("@CodigoProducto", SqlDbType.VarChar, 50).Value = objEnt.CodigoProducto;
                        //sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 50).Value = objEnt.Marca;
                        #endregion

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;

                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            finally
            {
                dta_consulta.Dispose();
            }
        }


        public DataTable F_TCAlmacenFisico_Listar(TCAlmacenCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TCAlmacenFisico_Listar";

                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = objEntidadBE.Descripcion;

                        
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
        //creado por joel
        public DataTable F_Lista_Almacenes_Deudas_Clientes_Povis( TCAlmacenesExternosCE objEntidad)
        {
            #region VARIABLES
            DataTable dta_consulta = null;

            #endregion

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
                        sql_comando.CommandText = "pa_Lista_Almacenes_Deudas_Clientes_Povis";

                        if (objEntidad.CodEmpresa != 0)
                            sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidad.CodEmpresa;
                        #region PARAMETROS
                        
                        //sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 50).Value = objEnt.Marca;
                        #endregion

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;

                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            finally
            {
                dta_consulta.Dispose();
            }
        }

        public DataTable F_Empresa_Destino(TCAlmacenCE objEntidadAlmacen)
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
                        sql_comando.CommandText = "pa_TCAlmacenFisico_Destino";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.VarChar).Value = objEntidadAlmacen.CodEmpresa;


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
