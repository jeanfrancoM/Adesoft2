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
    public class LGProductosCD
    {
        public DataTable F_LGProductos_Select_Ventas(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_Select_Ventas";

                        sql_comando.Parameters.Add("@DscArticulo", SqlDbType.VarChar, 150).Value = objEntidadBE.DscProducto;
                        sql_comando.Parameters.Add("@DscArticulo2", SqlDbType.VarChar, 150).Value = objEntidadBE.DscProducto2;
                        sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@FlagProductosConStock", SqlDbType.Int).Value = objEntidadBE.FlagProductosConStock;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                
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

        public DataTable F_LGProductos_Select_Ventas_Fundidora(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_Select_Ventas";

                        sql_comando.Parameters.Add("@DscArticulo", SqlDbType.VarChar, 150).Value = objEntidadBE.DscProducto;
                        sql_comando.Parameters.Add("@DscArticulo2", SqlDbType.VarChar, 150).Value = objEntidadBE.DscProducto2;
                        sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@FlagProductosConStock", SqlDbType.Int).Value = objEntidadBE.FlagProductosConStock;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidadBE.CodCategoria;

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

        public DataTable F_LGProductos_Select_Ventas_Povis(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_Select_Ventas";

                        sql_comando.Parameters.Add("@DscArticulo", SqlDbType.VarChar, 150).Value = objEntidadBE.DscProducto;
                        sql_comando.Parameters.Add("@DscArticulo2", SqlDbType.VarChar, 150).Value = objEntidadBE.DscProducto2;
                        sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@FlagProductosConStock", SqlDbType.Int).Value = objEntidadBE.FlagProductosConStock;
                        

                        if (objEntidadBE.CodCtaCte > 0)
                            sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;


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

        public DataTable F_LGProductos_Select(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_Select";

                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = objEntidadBE.DscProducto;
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

        public bool F_AgregarImagen_Carpeta(LGProductosCE objEntidadCE)
        {
            #region VARIABLES

            bool bol_resultado_operacion = false;

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
                        sql_comando.CommandText = "usp_insert_TemporalImagen_Carpeta";

                        sql_comando.Parameters.Add("@B_ImagenTem", SqlDbType.VarBinary).Value = objEntidadCE.B_ImagenTem;
                        sql_comando.Parameters.Add("@ID_Proceso", SqlDbType.BigInt).Value = objEntidadCE.ID_Proceso;


                        sql_comando.ExecuteNonQuery();


                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;

            }

            return bol_resultado_operacion;

        }


        public DataTable F_Buscar_Producto_Temporal_Carpeta(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "F_Buscar_Producto_Temporal_Carpeta";

                        sql_comando.Parameters.Add("@ID_Proceso", SqlDbType.BigInt).Value = objEntidadBE.ID_Proceso;


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

        public LGProductosCE F_LGProductos_Insert_Tractos(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    if (Tipo == "")
                        sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    else
                        sql_conexion.ConnectionString = (new SqlConnectionStringBuilder() { DataSource = DBHost, InitialCatalog = DBDataBase, UserID = DBUser, Password = DBPass }).ConnectionString;

                    bool Conectado = false;
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
                                sql_comando.CommandText = "pa_LGProductos_Insert";

                                sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                                sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                                sql_comando.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;
                                sql_comando.Parameters.Add("@DscProducto", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProducto;
                                sql_comando.Parameters.Add("@DscProductoIngles", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProductoIngles;
                                sql_comando.Parameters.Add("@PartidaArancelaria", SqlDbType.VarChar, 250).Value = objEntidadBE.PartidaArancelaria;
                                sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                                sql_comando.Parameters.Add("@CodUnidadCompra", SqlDbType.Int).Value = objEntidadBE.CodUnidadCompra;
                                sql_comando.Parameters.Add("@CodUnidadVenta", SqlDbType.Int).Value = objEntidadBE.CodUnidadVenta;
                                sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                                sql_comando.Parameters.Add("@CostoSoles", SqlDbType.Decimal).Value = objEntidadBE.CostoSoles;
                                sql_comando.Parameters.Add("@CostoDolares", SqlDbType.Decimal).Value = objEntidadBE.CostoDolares;
                                sql_comando.Parameters.Add("@Factor", SqlDbType.Int).Value = objEntidadBE.Factor;
                                sql_comando.Parameters.Add("@CodigoInterno", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoInterno;
                                sql_comando.Parameters.Add("@CodigoProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoProducto;
                                sql_comando.Parameters.Add("@CodigoAlternativo", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoAlternativo;
                                sql_comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = objEntidadBE.Precio;
                                sql_comando.Parameters.Add("@Precio2", SqlDbType.Decimal).Value = objEntidadBE.Precio2;
                                sql_comando.Parameters.Add("@Precio3", SqlDbType.Decimal).Value = objEntidadBE.Precio3;
                                sql_comando.Parameters.Add("@PrecioDolares", SqlDbType.Decimal).Value = objEntidadBE.PrecioDolares;
                                sql_comando.Parameters.Add("@Precio2Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio2Dolares;
                                sql_comando.Parameters.Add("@Precio3Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio3Dolares;
                                sql_comando.Parameters.Add("@StockMaximo", SqlDbType.Decimal).Value = objEntidadBE.StockMaximo;
                                sql_comando.Parameters.Add("@StockMinimo", SqlDbType.Decimal).Value = objEntidadBE.StockMinimo;
                                sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                                sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 200).Value = objEntidadBE.Marca;
                                sql_comando.Parameters.Add("@Medida", SqlDbType.VarChar, 200).Value = objEntidadBE.Medida;
                                sql_comando.Parameters.Add("@Modelo", SqlDbType.VarChar, 200).Value = objEntidadBE.Modelo;
                                sql_comando.Parameters.Add("@Posicion", SqlDbType.VarChar, 200).Value = objEntidadBE.Posicion;
                                sql_comando.Parameters.Add("@Anio", SqlDbType.VarChar, 200).Value = objEntidadBE.Anio;
                                sql_comando.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 200).Value = objEntidadBE.Ubicacion;
                                sql_comando.Parameters.Add("@Img1", SqlDbType.Int).Value = objEntidadBE.IdImagenProducto1;
                                sql_comando.Parameters.Add("@M1", SqlDbType.Decimal).Value = objEntidadBE.M1;
                                sql_comando.Parameters.Add("@M2", SqlDbType.Decimal).Value = objEntidadBE.M2;
                                sql_comando.Parameters.Add("@Comentario", SqlDbType.VarChar, 8000).Value = objEntidadBE.Comentario;
                                sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                                sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;

                                SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                                MsgError.Direction = ParameterDirection.Output;
                                SqlParameter CodAlterno = sql_comando.Parameters.Add("@CodAlternoOut", SqlDbType.VarChar, 15);
                                CodAlterno.Direction = ParameterDirection.Output;

                                sql_comando.ExecuteNonQuery();

                                try
                                {
                                    //pasa imagen desde el temporal
                                    if (objEntidadBE.Imagenes.Count > 0)
                                    {
                                        objEntidadBE.CodAlterno = CodAlterno.Value.ToString();
                                        ImagenesCD x = new ImagenesCD();
                                        foreach (dynamic img in objEntidadBE.Imagenes)
                                        {
                                            try
                                            {
                                                x.F_Imagenes_Insert_From_Temporal(int.Parse(img.ToString()), objEntidadBE.CodUsuario, objEntidadBE.CodAlterno, objEntidadBE.IPRegistro);
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }
                                    }
                                }
                                catch (Exception exx)
                                {

                                }


                                objEntidadBE.MsgError = MsgError.Value.ToString();



                            }
                        }
                        catch (Exception exx)
                        {
                            objEntidadBE.MsgError = exx.ToString();
                        }


                }



            }
            catch (Exception ex)
            {

                throw ex;

            }
            return objEntidadBE;


        }


        public bool F_Agregar_Producto_Temporal_Carpeta(LGProductosCE objEntidadCE)
        {
            #region VARIABLES

            bool bol_resultado_operacion = false;

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
                        sql_comando.CommandText = "usp_insert_TemporalProducto_Carpeta";

                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadCE.CodProducto;
                        sql_comando.Parameters.Add("@ID_Proceso", SqlDbType.BigInt).Value = objEntidadCE.ID_Proceso;


                        sql_comando.ExecuteNonQuery();


                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;

            }

            return bol_resultado_operacion;

        }

        public LGProductosCE F_Eliminar_Producto_Temporal_a_Final(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Eliminar_Producto_Temporal_a_Final";

                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                        sql_comando.Parameters.Add("@IdImagen", SqlDbType.Int).Value = objEntidadBE.IdImagenProducto1;
                        sql_comando.Parameters.Add("@CodClaseImagen", SqlDbType.Int).Value = objEntidadBE.CodClaseImagen;
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


        public LGProductosCE F_Grabar_Producto_Temporal_a_Final(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Grabar_Producto_Temporal_a_Final";

                        sql_comando.Parameters.Add("@ID_Proceso", SqlDbType.BigInt).Value = objEntidadBE.ID_Proceso;
                        sql_comando.Parameters.Add("@Titulo", SqlDbType.VarChar, 200).Value = objEntidadBE.CodigoProducto;
                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 2000).Value = objEntidadBE.DscProducto;
                        sql_comando.Parameters.Add("@CodClaseImagen", SqlDbType.Int).Value = objEntidadBE.CodClaseImagen;
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


        public bool F_Eliminar_Producto_Temporal_Carpeta(LGProductosCE objEntidadCE)
        {
            #region VARIABLES

            bool bol_resultado_operacion = false;

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
                        sql_comando.CommandText = "usp_delete_TemporalProducto_Carpeta";

                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadCE.CodProducto;
                        sql_comando.Parameters.Add("@ID_Proceso", SqlDbType.BigInt).Value = objEntidadCE.ID_Proceso;


                        sql_comando.ExecuteNonQuery();


                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;

            }

            return bol_resultado_operacion;

        }

        public LGProductosCE F_LGProductos_Insert_Async(LGProductosCE objEntidadBE, string Tipo, DataTable dta_tableAlmacenesExternos)
        {
            LGProductosCE objEntidad = new LGProductosCE();
            //realiza el recorrido por los almacenes a actualizar
            foreach (DataRow dr in dta_tableAlmacenesExternos.Rows)
            {
                int CodAlmacen = (int)dr["IdAlmacen"];
                string DscEmpresa = dr["DscEmpresa"].ToString();
                string DscAlmacen = dr["DscAlmacen"].ToString();
                string DBHost = dr["DBHost"].ToString();
                string DBDataBase = dr["DBDataBase"].ToString();
                string DBUser = dr["DBUser"].ToString();
                string DBPass = dr["DBPass"].ToString();
                string DBPort = dr["DBPort"].ToString();
                if (Tipo == "Insert")
                    F_LGProductos_Insert(objEntidadBE, "Remoto", DBHost, DBDataBase, DBUser, DBPass, DBPort);
                if (Tipo == "Update")
                    F_LGProductos_Update(objEntidadBE, "Remoto", DBHost, DBDataBase, DBUser, DBPass, DBPort);
            }
            return objEntidad;
        }

        public LGProductosCE F_LGProductos_Insert(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    if (Tipo == "")
                        sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    else
                        sql_conexion.ConnectionString = (new SqlConnectionStringBuilder() { DataSource = DBHost, InitialCatalog = DBDataBase, UserID = DBUser, Password = DBPass }).ConnectionString;

                    bool Conectado = false;
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
                                sql_comando.CommandText = "pa_LGProductos_Insert";

                                sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                                sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                                sql_comando.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;
                                sql_comando.Parameters.Add("@DscProducto", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProducto;
                                sql_comando.Parameters.Add("@DscProductoIngles", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProductoIngles;
                                sql_comando.Parameters.Add("@PartidaArancelaria", SqlDbType.VarChar, 250).Value = objEntidadBE.PartidaArancelaria;
                                sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                                sql_comando.Parameters.Add("@CodUnidadCompra", SqlDbType.Int).Value = objEntidadBE.CodUnidadCompra;
                                sql_comando.Parameters.Add("@CodUnidadVenta", SqlDbType.Int).Value = objEntidadBE.CodUnidadVenta;
                                sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                                sql_comando.Parameters.Add("@CostoSoles", SqlDbType.Decimal).Value = objEntidadBE.CostoSoles;
                                sql_comando.Parameters.Add("@CostoDolares", SqlDbType.Decimal).Value = objEntidadBE.CostoDolares;
                                sql_comando.Parameters.Add("@Factor", SqlDbType.Int).Value = objEntidadBE.Factor;
                                sql_comando.Parameters.Add("@CodigoInterno", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoInterno;
                                sql_comando.Parameters.Add("@CodigoProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoProducto;
                                sql_comando.Parameters.Add("@CodigoAlternativo", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoAlternativo;
                                sql_comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = objEntidadBE.Precio;
                                sql_comando.Parameters.Add("@Precio2", SqlDbType.Decimal).Value = objEntidadBE.Precio2;
                                sql_comando.Parameters.Add("@Precio3", SqlDbType.Decimal).Value = objEntidadBE.Precio3;
                                sql_comando.Parameters.Add("@PrecioDolares", SqlDbType.Decimal).Value = objEntidadBE.PrecioDolares;
                                sql_comando.Parameters.Add("@Precio2Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio2Dolares;
                                sql_comando.Parameters.Add("@Precio3Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio3Dolares;
                                sql_comando.Parameters.Add("@StockMaximo", SqlDbType.Decimal).Value = objEntidadBE.StockMaximo;
                                sql_comando.Parameters.Add("@StockMinimo", SqlDbType.Decimal).Value = objEntidadBE.StockMinimo;
                                sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                                sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 200).Value = objEntidadBE.Marca;
                                sql_comando.Parameters.Add("@Medida", SqlDbType.VarChar, 200).Value = objEntidadBE.Medida;
                                sql_comando.Parameters.Add("@Modelo", SqlDbType.VarChar, 200).Value = objEntidadBE.Modelo;
                                sql_comando.Parameters.Add("@Posicion", SqlDbType.VarChar, 200).Value = objEntidadBE.Posicion;
                                sql_comando.Parameters.Add("@Anio", SqlDbType.VarChar, 200).Value = objEntidadBE.Anio;
                                sql_comando.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 200).Value = objEntidadBE.Ubicacion;
                                sql_comando.Parameters.Add("@Img1", SqlDbType.Int).Value = objEntidadBE.IdImagenProducto1;
                                sql_comando.Parameters.Add("@M1", SqlDbType.Decimal).Value = objEntidadBE.M1;
                                sql_comando.Parameters.Add("@M2", SqlDbType.Decimal).Value = objEntidadBE.M2;
                                sql_comando.Parameters.Add("@Comentario", SqlDbType.VarChar, 8000).Value = objEntidadBE.Comentario;
                                sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                                sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                                sql_comando.Parameters.Add("@CodigoFabrica", SqlDbType.VarChar, 200).Value = objEntidadBE.CodigoFabrica;

                                sql_comando.Parameters.Add("@PrecioApp", SqlDbType.Decimal).Value = objEntidadBE.PrecioApp;
                                sql_comando.Parameters.Add("@PrecioAppDolares", SqlDbType.Decimal).Value = objEntidadBE.PrecioAppDolares;
                                sql_comando.Parameters.Add("@SeVendeEnApp", SqlDbType.Int).Value = objEntidadBE.SeVendeEnApp;
                                sql_comando.Parameters.Add("@TituloApp", SqlDbType.VarChar, 200).Value = objEntidadBE.TituloApp;
                                sql_comando.Parameters.Add("@DescripcionDetalladaApp", SqlDbType.VarChar, 5000).Value = objEntidadBE.DescripcionDetalladaApp;

                                SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                                MsgError.Direction = ParameterDirection.Output;
                                SqlParameter CodAlterno = sql_comando.Parameters.Add("@CodAlternoOut", SqlDbType.VarChar, 15);
                                CodAlterno.Direction = ParameterDirection.Output;

                                sql_comando.ExecuteNonQuery();

                                try
                                {
                                    //pasa imagen desde el temporal
                                    if (objEntidadBE.Imagenes.Count > 0)
                                    {
                                        objEntidadBE.CodAlterno = CodAlterno.Value.ToString();
                                        ImagenesCD x = new ImagenesCD();
                                        foreach (dynamic img in objEntidadBE.Imagenes)
                                        {
                                            try
                                            {
                                                x.F_Imagenes_Insert_From_Temporal(int.Parse(img.ToString()), objEntidadBE.CodUsuario, objEntidadBE.CodAlterno, objEntidadBE.IPRegistro);
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }
                                    }
                                }
                                catch (Exception exx)
                                {

                                }


                                objEntidadBE.MsgError = MsgError.Value.ToString();



                            }
                        }
                        catch (Exception exx)
                        {
                            objEntidadBE.MsgError = exx.ToString();
                        }


                }



            }
            catch (Exception ex)
            {

                throw ex;

            }
            return objEntidadBE;


        }

        public LGProductosCE F_LGProductos_Insert_Povis(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    if (Tipo == "")
                        sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    else
                        sql_conexion.ConnectionString = (new SqlConnectionStringBuilder() { DataSource = DBHost, InitialCatalog = DBDataBase, UserID = DBUser, Password = DBPass }).ConnectionString;

                    bool Conectado = false;
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
                                sql_comando.CommandText = "pa_LGProductos_Insert";

                                sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                                sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                                sql_comando.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;
                                sql_comando.Parameters.Add("@DscProducto", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProducto;
                                sql_comando.Parameters.Add("@DscProductoIngles", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProductoIngles;
                                sql_comando.Parameters.Add("@PartidaArancelaria", SqlDbType.VarChar, 250).Value = objEntidadBE.PartidaArancelaria;
                                sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                                sql_comando.Parameters.Add("@CodUnidadCompra", SqlDbType.Int).Value = objEntidadBE.CodUnidadCompra;
                                sql_comando.Parameters.Add("@CodUnidadVenta", SqlDbType.Int).Value = objEntidadBE.CodUnidadVenta;
                                sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                                sql_comando.Parameters.Add("@CostoSoles", SqlDbType.Decimal).Value = objEntidadBE.CostoSoles;
                                sql_comando.Parameters.Add("@CostoDolares", SqlDbType.Decimal).Value = objEntidadBE.CostoDolares;
                                sql_comando.Parameters.Add("@Factor", SqlDbType.Int).Value = objEntidadBE.Factor;
                                sql_comando.Parameters.Add("@CodigoInterno", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoInterno;
                                sql_comando.Parameters.Add("@CodigoProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoProducto;
                                sql_comando.Parameters.Add("@CodigoAlternativo", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoAlternativo;
                                sql_comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = objEntidadBE.Precio;
                                sql_comando.Parameters.Add("@Precio2", SqlDbType.Decimal).Value = objEntidadBE.Precio2;
                                sql_comando.Parameters.Add("@Precio3", SqlDbType.Decimal).Value = objEntidadBE.Precio3;
                                sql_comando.Parameters.Add("@M1", SqlDbType.Decimal).Value = objEntidadBE.M1;
                                sql_comando.Parameters.Add("@M2", SqlDbType.Decimal).Value = objEntidadBE.M2;
                                sql_comando.Parameters.Add("@M3", SqlDbType.Decimal).Value = objEntidadBE.M3;
                                sql_comando.Parameters.Add("@PrecioDolares", SqlDbType.Decimal).Value = objEntidadBE.PrecioDolares;
                                sql_comando.Parameters.Add("@Precio2Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio2Dolares;
                                sql_comando.Parameters.Add("@Precio3Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio3Dolares;
                                sql_comando.Parameters.Add("@StockMaximo", SqlDbType.Decimal).Value = objEntidadBE.StockMaximo;
                                sql_comando.Parameters.Add("@StockMinimo", SqlDbType.Decimal).Value = objEntidadBE.StockMinimo;
                                sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                                sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 200).Value = objEntidadBE.Marca;
                                sql_comando.Parameters.Add("@Medida", SqlDbType.VarChar, 200).Value = objEntidadBE.Medida;
                                sql_comando.Parameters.Add("@Modelo", SqlDbType.VarChar, 200).Value = objEntidadBE.Modelo;
                                sql_comando.Parameters.Add("@Posicion", SqlDbType.VarChar, 200).Value = objEntidadBE.Posicion;
                                sql_comando.Parameters.Add("@Anio", SqlDbType.VarChar, 200).Value = objEntidadBE.Anio;
                                sql_comando.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 200).Value = objEntidadBE.Ubicacion;
                                sql_comando.Parameters.Add("@Img1", SqlDbType.Int).Value = objEntidadBE.IdImagenProducto1;
                                sql_comando.Parameters.Add("@Comentario", SqlDbType.VarChar, 8000).Value = objEntidadBE.Comentario;
                                sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                                sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                                sql_comando.Parameters.Add("@Orden", SqlDbType.Int).Value = objEntidadBE.Orden;

                                SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                                MsgError.Direction = ParameterDirection.Output;
                                SqlParameter CodAlterno = sql_comando.Parameters.Add("@CodAlternoOut", SqlDbType.VarChar, 15);
                                CodAlterno.Direction = ParameterDirection.Output;

                                sql_comando.ExecuteNonQuery();

                                try
                                {
                                    //pasa imagen desde el temporal
                                    if (objEntidadBE.Imagenes.Count > 0)
                                    {
                                        objEntidadBE.CodAlterno = CodAlterno.Value.ToString();
                                        ImagenesCD x = new ImagenesCD();
                                        foreach (dynamic img in objEntidadBE.Imagenes)
                                        {
                                            try
                                            {
                                                x.F_Imagenes_Insert_From_Temporal(int.Parse(img.ToString()), objEntidadBE.CodUsuario, objEntidadBE.CodAlterno, objEntidadBE.IPRegistro);
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }
                                    }
                                }
                                catch (Exception exx)
                                {

                                }


                                objEntidadBE.MsgError = MsgError.Value.ToString();



                            }
                        }
                        catch (Exception exx)
                        {
                            objEntidadBE.MsgError = exx.ToString();
                        }


                }



            }
            catch (Exception ex)
            {

                throw ex;

            }
            return objEntidadBE;


        }

        public LGProductosCE F_LGProductos_Insert_Alvarado(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    if (Tipo == "")
                        sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    else
                        sql_conexion.ConnectionString = (new SqlConnectionStringBuilder() { DataSource = DBHost, InitialCatalog = DBDataBase, UserID = DBUser, Password = DBPass }).ConnectionString;

                    bool Conectado = false;
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
                                sql_comando.CommandText = "pa_LGProductos_Insert";

                                sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                                sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                                sql_comando.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;
                                sql_comando.Parameters.Add("@DscProducto", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProducto;
                                sql_comando.Parameters.Add("@DscProductoIngles", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProductoIngles;
                                sql_comando.Parameters.Add("@PartidaArancelaria", SqlDbType.VarChar, 250).Value = objEntidadBE.PartidaArancelaria;
                                sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                                sql_comando.Parameters.Add("@CodUnidadCompra", SqlDbType.Int).Value = objEntidadBE.CodUnidadCompra;
                                sql_comando.Parameters.Add("@CodUnidadVenta", SqlDbType.Int).Value = objEntidadBE.CodUnidadVenta;
                                sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                                sql_comando.Parameters.Add("@CostoSoles", SqlDbType.Decimal).Value = objEntidadBE.CostoSoles;
                                sql_comando.Parameters.Add("@CostoDolares", SqlDbType.Decimal).Value = objEntidadBE.CostoDolares;
                                sql_comando.Parameters.Add("@Factor", SqlDbType.Int).Value = objEntidadBE.Factor;
                                sql_comando.Parameters.Add("@CodigoInterno", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoInterno;
                                sql_comando.Parameters.Add("@CodigoProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoProducto;
                                sql_comando.Parameters.Add("@CodigoAlternativo", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoAlternativo;
                                sql_comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = objEntidadBE.Precio;
                                sql_comando.Parameters.Add("@Precio2", SqlDbType.Decimal).Value = objEntidadBE.Precio2;
                                sql_comando.Parameters.Add("@Precio3", SqlDbType.Decimal).Value = objEntidadBE.Precio3;
                                sql_comando.Parameters.Add("@PrecioDolares", SqlDbType.Decimal).Value = objEntidadBE.PrecioDolares;
                                sql_comando.Parameters.Add("@Precio2Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio2Dolares;
                                sql_comando.Parameters.Add("@Precio3Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio3Dolares;
                                sql_comando.Parameters.Add("@StockMaximo", SqlDbType.Decimal).Value = objEntidadBE.StockMaximo;
                                sql_comando.Parameters.Add("@StockMinimo", SqlDbType.Decimal).Value = objEntidadBE.StockMinimo;
                                sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                                sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 200).Value = objEntidadBE.Marca;
                                sql_comando.Parameters.Add("@Medida", SqlDbType.VarChar, 200).Value = objEntidadBE.Medida;
                                sql_comando.Parameters.Add("@Modelo", SqlDbType.VarChar, 200).Value = objEntidadBE.Modelo;
                                sql_comando.Parameters.Add("@Posicion", SqlDbType.VarChar, 200).Value = objEntidadBE.Posicion;
                                sql_comando.Parameters.Add("@Anio", SqlDbType.VarChar, 200).Value = objEntidadBE.Anio;
                                sql_comando.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 200).Value = objEntidadBE.Ubicacion;
                                sql_comando.Parameters.Add("@Img1", SqlDbType.Int).Value = objEntidadBE.IdImagenProducto1;
                                sql_comando.Parameters.Add("@M1", SqlDbType.Decimal).Value = objEntidadBE.M1;
                                sql_comando.Parameters.Add("@M2", SqlDbType.Decimal).Value = objEntidadBE.M2;
                                sql_comando.Parameters.Add("@Comentario", SqlDbType.VarChar, 8000).Value = objEntidadBE.Comentario;
                                sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                                sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                                sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 1000).Value = objEntidadBE.Observacion;
                                sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidadBE.CodCategoria;
                                sql_comando.Parameters.Add("@CantidadMayorista", SqlDbType.Decimal).Value = objEntidadBE.CantidadMayorista;
                                sql_comando.Parameters.Add("@CantidadMayoristaLimite", SqlDbType.Int).Value = objEntidadBE.CantidadMayoristaLimite;
                                sql_comando.Parameters.Add("@PermisoMayorista", SqlDbType.Int).Value = objEntidadBE.PermisoMayorista;
                                sql_comando.Parameters.Add("@CodigoMenu", SqlDbType.Int).Value = objEntidadBE.CodigoMenu;
                                sql_comando.Parameters.Add("@Exclusivo", SqlDbType.Decimal).Value = objEntidadBE.Exclusivo;

                                SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                                MsgError.Direction = ParameterDirection.Output;
                                SqlParameter CodAlterno = sql_comando.Parameters.Add("@CodAlternoOut", SqlDbType.VarChar, 15);
                                CodAlterno.Direction = ParameterDirection.Output;

                                sql_comando.ExecuteNonQuery();

                                try
                                {
                                    //pasa imagen desde el temporal
                                    if (objEntidadBE.Imagenes.Count > 0)
                                    {
                                        objEntidadBE.CodAlterno = CodAlterno.Value.ToString();
                                        ImagenesCD x = new ImagenesCD();
                                        foreach (dynamic img in objEntidadBE.Imagenes)
                                        {
                                            try
                                            {
                                                x.F_Imagenes_Insert_From_Temporal(int.Parse(img.ToString()), objEntidadBE.CodUsuario, objEntidadBE.CodAlterno, objEntidadBE.IPRegistro);
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }
                                    }
                                }
                                catch (Exception exx)
                                {

                                }


                                objEntidadBE.MsgError = MsgError.Value.ToString();



                            }
                        }
                        catch (Exception exx)
                        {
                            objEntidadBE.MsgError = exx.ToString();
                        }


                }



            }
            catch (Exception ex)
            {

                throw ex;

            }
            return objEntidadBE;


        }

        public LGProductosCE F_LGProductos_Insert_Fundidora(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    if (Tipo == "")
                        sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    else
                        sql_conexion.ConnectionString = (new SqlConnectionStringBuilder() { DataSource = DBHost, InitialCatalog = DBDataBase, UserID = DBUser, Password = DBPass }).ConnectionString;

                    bool Conectado = false;
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
                                sql_comando.CommandText = "pa_LGProductos_Insert";

                                sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                                sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                                sql_comando.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;
                                sql_comando.Parameters.Add("@DscProducto", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProducto;
                                sql_comando.Parameters.Add("@DscProductoIngles", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProductoIngles;
                                sql_comando.Parameters.Add("@PartidaArancelaria", SqlDbType.VarChar, 250).Value = objEntidadBE.PartidaArancelaria;
                                sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                                sql_comando.Parameters.Add("@CodUnidadCompra", SqlDbType.Int).Value = objEntidadBE.CodUnidadCompra;
                                sql_comando.Parameters.Add("@CodUnidadVenta", SqlDbType.Int).Value = objEntidadBE.CodUnidadVenta;
                                sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                                sql_comando.Parameters.Add("@CostoSoles", SqlDbType.Decimal).Value = objEntidadBE.CostoSoles;
                                sql_comando.Parameters.Add("@CostoDolares", SqlDbType.Decimal).Value = objEntidadBE.CostoDolares;
                                sql_comando.Parameters.Add("@Factor", SqlDbType.Int).Value = objEntidadBE.Factor;
                                sql_comando.Parameters.Add("@CodigoInterno", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoInterno;
                                sql_comando.Parameters.Add("@CodigoProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoProducto;
                                sql_comando.Parameters.Add("@CodigoAlternativo", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoAlternativo;
                                sql_comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = objEntidadBE.Precio;
                                sql_comando.Parameters.Add("@Precio2", SqlDbType.Decimal).Value = objEntidadBE.Precio2;
                                sql_comando.Parameters.Add("@Precio3", SqlDbType.Decimal).Value = objEntidadBE.Precio3;
                                sql_comando.Parameters.Add("@PrecioDolares", SqlDbType.Decimal).Value = objEntidadBE.PrecioDolares;
                                sql_comando.Parameters.Add("@Precio2Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio2Dolares;
                                sql_comando.Parameters.Add("@Precio3Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio3Dolares;
                                sql_comando.Parameters.Add("@StockMaximo", SqlDbType.Decimal).Value = objEntidadBE.StockMaximo;
                                sql_comando.Parameters.Add("@StockMinimo", SqlDbType.Decimal).Value = objEntidadBE.StockMinimo;
                                sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                                sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 200).Value = objEntidadBE.Marca;
                                sql_comando.Parameters.Add("@Medida", SqlDbType.VarChar, 200).Value = objEntidadBE.Medida;
                                sql_comando.Parameters.Add("@Modelo", SqlDbType.VarChar, 200).Value = objEntidadBE.Modelo;
                                sql_comando.Parameters.Add("@Posicion", SqlDbType.VarChar, 200).Value = objEntidadBE.Posicion;
                                sql_comando.Parameters.Add("@Anio", SqlDbType.VarChar, 200).Value = objEntidadBE.Anio;
                                sql_comando.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 200).Value = objEntidadBE.Ubicacion;
                                sql_comando.Parameters.Add("@Img1", SqlDbType.Int).Value = objEntidadBE.IdImagenProducto1;
                                sql_comando.Parameters.Add("@M1", SqlDbType.Decimal).Value = objEntidadBE.M1;
                                sql_comando.Parameters.Add("@M2", SqlDbType.Decimal).Value = objEntidadBE.M2;
                                sql_comando.Parameters.Add("@Comentario", SqlDbType.VarChar, 8000).Value = objEntidadBE.Comentario;
                                sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                                sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                                sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 1000).Value = objEntidadBE.Observacion;
                                sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidadBE.CodCategoria;
                             
                                SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                                MsgError.Direction = ParameterDirection.Output;
                                SqlParameter CodAlterno = sql_comando.Parameters.Add("@CodAlternoOut", SqlDbType.VarChar, 15);
                                CodAlterno.Direction = ParameterDirection.Output;

                                sql_comando.ExecuteNonQuery();

                                try
                                {
                                    //pasa imagen desde el temporal
                                    if (objEntidadBE.Imagenes.Count > 0)
                                    {
                                        objEntidadBE.CodAlterno = CodAlterno.Value.ToString();
                                        ImagenesCD x = new ImagenesCD();
                                        foreach (dynamic img in objEntidadBE.Imagenes)
                                        {
                                            try
                                            {
                                                x.F_Imagenes_Insert_From_Temporal(int.Parse(img.ToString()), objEntidadBE.CodUsuario, objEntidadBE.CodAlterno, objEntidadBE.IPRegistro);
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }
                                    }
                                }
                                catch (Exception exx)
                                {

                                }


                                objEntidadBE.MsgError = MsgError.Value.ToString();



                            }
                        }
                        catch (Exception exx)
                        {
                            objEntidadBE.MsgError = exx.ToString();
                        }


                }



            }
            catch (Exception ex)
            {

                throw ex;

            }
            return objEntidadBE;


        }

        public LGProductosCE F_LGProductos_Update_Fundidora(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    if (Tipo == "")
                        sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    else
                        sql_conexion.ConnectionString = (new SqlConnectionStringBuilder() { DataSource = DBHost, InitialCatalog = DBDataBase, UserID = DBUser, Password = DBPass }).ConnectionString;

                    bool Conectado = false;
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
                                sql_comando.CommandText = "pa_LGProductos_Update";

                                sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                                sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                                sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                                sql_comando.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;
                                sql_comando.Parameters.Add("@DscProducto", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProducto;
                                sql_comando.Parameters.Add("@DscProductoIngles", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProductoIngles;
                                sql_comando.Parameters.Add("@PartidaArancelaria", SqlDbType.VarChar, 250).Value = objEntidadBE.PartidaArancelaria;
                                sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                                sql_comando.Parameters.Add("@CodUnidadCompra", SqlDbType.Int).Value = objEntidadBE.CodUnidadCompra;
                                sql_comando.Parameters.Add("@CodUnidadVenta", SqlDbType.Int).Value = objEntidadBE.CodUnidadVenta;
                                sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                                sql_comando.Parameters.Add("@CostoSoles", SqlDbType.Decimal).Value = objEntidadBE.CostoSoles;
                                sql_comando.Parameters.Add("@CostoDolares", SqlDbType.Decimal).Value = objEntidadBE.CostoDolares;
                                sql_comando.Parameters.Add("@Factor", SqlDbType.Int).Value = objEntidadBE.Factor;
                                sql_comando.Parameters.Add("@CodigoInterno", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoInterno;
                                sql_comando.Parameters.Add("@CodigoProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoProducto;
                                sql_comando.Parameters.Add("@CodigoAlternativo", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoAlternativo;
                                sql_comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = objEntidadBE.Precio;
                                sql_comando.Parameters.Add("@Precio2", SqlDbType.Decimal).Value = objEntidadBE.Precio2;
                                sql_comando.Parameters.Add("@Precio3", SqlDbType.Decimal).Value = objEntidadBE.Precio3;
                                sql_comando.Parameters.Add("@PrecioDolares", SqlDbType.Decimal).Value = objEntidadBE.PrecioDolares;
                                sql_comando.Parameters.Add("@Precio2Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio2Dolares;
                                sql_comando.Parameters.Add("@Precio3Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio3Dolares;
                                sql_comando.Parameters.Add("@StockMaximo", SqlDbType.Decimal).Value = objEntidadBE.StockMaximo;
                                sql_comando.Parameters.Add("@StockMinimo", SqlDbType.Decimal).Value = objEntidadBE.StockMinimo;
                                sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                                sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 200).Value = objEntidadBE.Marca;
                                sql_comando.Parameters.Add("@Medida", SqlDbType.VarChar, 200).Value = objEntidadBE.Medida;
                                sql_comando.Parameters.Add("@Modelo", SqlDbType.VarChar, 200).Value = objEntidadBE.Modelo;
                                sql_comando.Parameters.Add("@Posicion", SqlDbType.VarChar, 200).Value = objEntidadBE.Posicion;
                                sql_comando.Parameters.Add("@Anio", SqlDbType.VarChar, 200).Value = objEntidadBE.Anio;
                                sql_comando.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 200).Value = objEntidadBE.Ubicacion;
                                sql_comando.Parameters.Add("@Img1", SqlDbType.Int).Value = objEntidadBE.IdImagenProducto1;
                                sql_comando.Parameters.Add("@M1", SqlDbType.Decimal).Value = objEntidadBE.M1;
                                sql_comando.Parameters.Add("@M2", SqlDbType.Decimal).Value = objEntidadBE.M2;
                                sql_comando.Parameters.Add("@Comentario", SqlDbType.VarChar, 8000).Value = objEntidadBE.Comentario;
                                sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                                sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                                sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 1000).Value = objEntidadBE.Observacion;
                                sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidadBE.CodCategoria;

                                SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                                MsgError.Direction = ParameterDirection.Output;
                                SqlParameter CodAlterno = sql_comando.Parameters.Add("@CodAlternoOut", SqlDbType.VarChar, 15);
                                CodAlterno.Direction = ParameterDirection.Output;

                                sql_comando.ExecuteNonQuery();

                                try
                                {
                                    //pasa imagen desde el temporal
                                    if (objEntidadBE.Imagenes.Count > 0)
                                    {
                                        objEntidadBE.CodAlterno = CodAlterno.Value.ToString();
                                        ImagenesCD x = new ImagenesCD();
                                        foreach (dynamic img in objEntidadBE.Imagenes)
                                        {
                                            try
                                            {
                                                x.F_Imagenes_Insert_From_Temporal(int.Parse(img.ToString()), objEntidadBE.CodUsuario, objEntidadBE.CodAlterno, objEntidadBE.IPRegistro);
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }
                                    }
                                }
                                catch (Exception exx)
                                {

                                }


                                objEntidadBE.MsgError = MsgError.Value.ToString();



                            }
                        }
                        catch (Exception exx)
                        {
                            objEntidadBE.MsgError = exx.ToString();
                        }


                }



            }
            catch (Exception ex)
            {

                throw ex;

            }
            return objEntidadBE;


        }

        public LGProductosCE F_LGProductos_Insert_Yordan(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    if (Tipo == "")
                        sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    else
                        sql_conexion.ConnectionString = (new SqlConnectionStringBuilder() { DataSource = DBHost, InitialCatalog = DBDataBase, UserID = DBUser, Password = DBPass }).ConnectionString;

                    bool Conectado = false;
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
                                sql_comando.CommandText = "pa_LGProductos_Insert";

                                sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                                sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                                sql_comando.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;
                                sql_comando.Parameters.Add("@DscProducto", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProducto;
                                sql_comando.Parameters.Add("@DscProductoIngles", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProductoIngles;
                                sql_comando.Parameters.Add("@PartidaArancelaria", SqlDbType.VarChar, 250).Value = objEntidadBE.PartidaArancelaria;
                                sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                                sql_comando.Parameters.Add("@CodUnidadCompra", SqlDbType.Int).Value = objEntidadBE.CodUnidadCompra;
                                sql_comando.Parameters.Add("@CodUnidadVenta", SqlDbType.Int).Value = objEntidadBE.CodUnidadVenta;
                                sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                                sql_comando.Parameters.Add("@CostoSoles", SqlDbType.Decimal).Value = objEntidadBE.CostoSoles;
                                sql_comando.Parameters.Add("@CostoDolares", SqlDbType.Decimal).Value = objEntidadBE.CostoDolares;
                                sql_comando.Parameters.Add("@Factor", SqlDbType.Int).Value = objEntidadBE.Factor;
                                sql_comando.Parameters.Add("@CodigoInterno", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoInterno;
                                sql_comando.Parameters.Add("@CodigoProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoProducto;
                                sql_comando.Parameters.Add("@CodigoAlternativo", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoAlternativo;
                                sql_comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = objEntidadBE.Precio;
                                sql_comando.Parameters.Add("@Precio2", SqlDbType.Decimal).Value = objEntidadBE.Precio2;
                                sql_comando.Parameters.Add("@Precio3", SqlDbType.Decimal).Value = objEntidadBE.Precio3;
                                sql_comando.Parameters.Add("@Precio4", SqlDbType.Decimal).Value = objEntidadBE.Precio4;
                                sql_comando.Parameters.Add("@PrecioDolares", SqlDbType.Decimal).Value = objEntidadBE.PrecioDolares;
                                sql_comando.Parameters.Add("@Precio2Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio2Dolares;
                                sql_comando.Parameters.Add("@Precio3Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio3Dolares;
                                sql_comando.Parameters.Add("@Precio4Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio4Dolares;
                                sql_comando.Parameters.Add("@StockMaximo", SqlDbType.Decimal).Value = objEntidadBE.StockMaximo;
                                sql_comando.Parameters.Add("@StockMinimo", SqlDbType.Decimal).Value = objEntidadBE.StockMinimo;
                                sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                                sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 200).Value = objEntidadBE.Marca;
                                sql_comando.Parameters.Add("@Medida", SqlDbType.VarChar, 200).Value = objEntidadBE.Medida;
                                sql_comando.Parameters.Add("@Modelo", SqlDbType.VarChar, 200).Value = objEntidadBE.Modelo;
                                sql_comando.Parameters.Add("@Posicion", SqlDbType.VarChar, 200).Value = objEntidadBE.Posicion;
                                sql_comando.Parameters.Add("@Anio", SqlDbType.VarChar, 200).Value = objEntidadBE.Anio;
                                sql_comando.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 200).Value = objEntidadBE.Ubicacion;
                                sql_comando.Parameters.Add("@Img1", SqlDbType.Int).Value = objEntidadBE.IdImagenProducto1;
                                sql_comando.Parameters.Add("@M1", SqlDbType.Decimal).Value = objEntidadBE.M1;
                                sql_comando.Parameters.Add("@M2", SqlDbType.Decimal).Value = objEntidadBE.M2;
                                sql_comando.Parameters.Add("@Comentario", SqlDbType.VarChar, 8000).Value = objEntidadBE.Comentario;
                                sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                                sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;

                                SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                                MsgError.Direction = ParameterDirection.Output;
                                SqlParameter CodAlterno = sql_comando.Parameters.Add("@CodAlternoOut", SqlDbType.VarChar, 15);
                                CodAlterno.Direction = ParameterDirection.Output;

                                sql_comando.ExecuteNonQuery();

                                try
                                {
                                    //pasa imagen desde el temporal
                                    if (objEntidadBE.Imagenes.Count > 0)
                                    {
                                        objEntidadBE.CodAlterno = CodAlterno.Value.ToString();
                                        ImagenesCD x = new ImagenesCD();
                                        foreach (dynamic img in objEntidadBE.Imagenes)
                                        {
                                            try
                                            {
                                                x.F_Imagenes_Insert_From_Temporal(int.Parse(img.ToString()), objEntidadBE.CodUsuario, objEntidadBE.CodAlterno, objEntidadBE.IPRegistro);
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }
                                    }
                                }
                                catch (Exception exx)
                                {

                                }


                                objEntidadBE.MsgError = MsgError.Value.ToString();



                            }
                        }
                        catch (Exception exx)
                        {
                            objEntidadBE.MsgError = exx.ToString();
                        }


                }



            }
            catch (Exception ex)
            {

                throw ex;

            }
            return objEntidadBE;


        }
        
        public LGProductosCE F_LGProductos_Insert_Roman(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    if (Tipo == "")
                        sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    else
                        sql_conexion.ConnectionString = (new SqlConnectionStringBuilder() { DataSource = DBHost, InitialCatalog = DBDataBase, UserID = DBUser, Password = DBPass }).ConnectionString;

                    bool Conectado = false;
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
                                sql_comando.CommandText = "pa_LGProductos_Insert";

                                sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                                sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                                sql_comando.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;
                                sql_comando.Parameters.Add("@DscProducto", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProducto;
                                sql_comando.Parameters.Add("@DscProductoIngles", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProductoIngles;
                                sql_comando.Parameters.Add("@PartidaArancelaria", SqlDbType.VarChar, 250).Value = objEntidadBE.PartidaArancelaria;
                                sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                                sql_comando.Parameters.Add("@CodUnidadCompra", SqlDbType.Int).Value = objEntidadBE.CodUnidadCompra;
                                sql_comando.Parameters.Add("@CodUnidadVenta", SqlDbType.Int).Value = objEntidadBE.CodUnidadVenta;
                                sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                                sql_comando.Parameters.Add("@CostoSoles", SqlDbType.Decimal).Value = objEntidadBE.CostoSoles;
                                sql_comando.Parameters.Add("@CostoDolares", SqlDbType.Decimal).Value = objEntidadBE.CostoDolares;
                                sql_comando.Parameters.Add("@Factor", SqlDbType.Int).Value = objEntidadBE.Factor;
                                sql_comando.Parameters.Add("@CodigoInterno", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoInterno;
                                sql_comando.Parameters.Add("@CodigoProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoProducto;
                                sql_comando.Parameters.Add("@CodigoAlternativo", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoAlternativo;
                                sql_comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = objEntidadBE.Precio;
                                sql_comando.Parameters.Add("@Precio2", SqlDbType.Decimal).Value = objEntidadBE.Precio2;
                                sql_comando.Parameters.Add("@Precio3", SqlDbType.Decimal).Value = objEntidadBE.Precio3;
                                sql_comando.Parameters.Add("@Precio4", SqlDbType.Decimal).Value = objEntidadBE.Precio4;
                                sql_comando.Parameters.Add("@Precio5", SqlDbType.Decimal).Value = objEntidadBE.Precio5;
                                sql_comando.Parameters.Add("@PrecioDolares", SqlDbType.Decimal).Value = objEntidadBE.PrecioDolares;
                                sql_comando.Parameters.Add("@Precio2Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio2Dolares;
                                sql_comando.Parameters.Add("@Precio3Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio3Dolares;
                                sql_comando.Parameters.Add("@Precio4Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio4Dolares;
                                sql_comando.Parameters.Add("@Precio5Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio5Dolares;
                                sql_comando.Parameters.Add("@StockMaximo", SqlDbType.Decimal).Value = objEntidadBE.StockMaximo;
                                sql_comando.Parameters.Add("@StockMinimo", SqlDbType.Decimal).Value = objEntidadBE.StockMinimo;
                                sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                                sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 200).Value = objEntidadBE.Marca;
                                sql_comando.Parameters.Add("@Medida", SqlDbType.VarChar, 200).Value = objEntidadBE.Medida;
                                sql_comando.Parameters.Add("@Modelo", SqlDbType.VarChar, 200).Value = objEntidadBE.Modelo;
                                sql_comando.Parameters.Add("@Posicion", SqlDbType.VarChar, 200).Value = objEntidadBE.Posicion;
                                sql_comando.Parameters.Add("@Anio", SqlDbType.VarChar, 200).Value = objEntidadBE.Anio;
                                sql_comando.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 200).Value = objEntidadBE.Ubicacion;
                                sql_comando.Parameters.Add("@Img1", SqlDbType.Int).Value = objEntidadBE.IdImagenProducto1;
                                //Margen
                                sql_comando.Parameters.Add("@Margen1", SqlDbType.Decimal).Value = objEntidadBE.Margen1;
                                sql_comando.Parameters.Add("@Margen2", SqlDbType.Decimal).Value = objEntidadBE.Margen2;
                                sql_comando.Parameters.Add("@Margen3", SqlDbType.Decimal).Value = objEntidadBE.Margen3;
                                sql_comando.Parameters.Add("@Margen4", SqlDbType.Decimal).Value = objEntidadBE.Margen4;
                                sql_comando.Parameters.Add("@Margen5", SqlDbType.Decimal).Value = objEntidadBE.Margen5;
                                //Margen
                                sql_comando.Parameters.Add("@Comentario", SqlDbType.VarChar, 8000).Value = objEntidadBE.Comentario;
                                sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;

                                sql_comando.Parameters.Add("@Pais", SqlDbType.VarChar, 50).Value = objEntidadBE.Pais;
                                sql_comando.Parameters.Add("@FlagCpe", SqlDbType.Int).Value = objEntidadBE.FlagCpe;
                                sql_comando.Parameters.Add("@D1", SqlDbType.VarChar, 10).Value = objEntidadBE.D1;
                                sql_comando.Parameters.Add("@D2", SqlDbType.VarChar, 10).Value = objEntidadBE.D2;
                                sql_comando.Parameters.Add("@D3", SqlDbType.VarChar, 10).Value = objEntidadBE.D3;
                                sql_comando.Parameters.Add("@D4", SqlDbType.VarChar, 10).Value = objEntidadBE.D4;
                                sql_comando.Parameters.Add("@D5", SqlDbType.VarChar, 10).Value = objEntidadBE.D5;
                                sql_comando.Parameters.Add("@D6", SqlDbType.VarChar, 10).Value = objEntidadBE.D6;
                                sql_comando.Parameters.Add("@D7", SqlDbType.VarChar, 10).Value = objEntidadBE.D7;
                                sql_comando.Parameters.Add("@M1", SqlDbType.VarChar, 10).Value = objEntidadBE.M1str;
                                sql_comando.Parameters.Add("@M2", SqlDbType.VarChar, 10).Value = objEntidadBE.M2str;
                                sql_comando.Parameters.Add("@M3", SqlDbType.VarChar, 10).Value = objEntidadBE.M3str;

                                sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;

                                SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                                MsgError.Direction = ParameterDirection.Output;
                                SqlParameter CodAlterno = sql_comando.Parameters.Add("@CodAlternoOut", SqlDbType.VarChar, 15);
                                CodAlterno.Direction = ParameterDirection.Output;

                                sql_comando.ExecuteNonQuery();

                                try
                                {
                                    //pasa imagen desde el temporal
                                    if (objEntidadBE.Imagenes.Count > 0)
                                    {
                                        objEntidadBE.CodAlterno = CodAlterno.Value.ToString();
                                        ImagenesCD x = new ImagenesCD();
                                        foreach (dynamic img in objEntidadBE.Imagenes)
                                        {
                                            try
                                            {
                                                x.F_Imagenes_Insert_From_Temporal(int.Parse(img.ToString()), objEntidadBE.CodUsuario, objEntidadBE.CodAlterno, objEntidadBE.IPRegistro);
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }
                                    }
                                }
                                catch (Exception exx)
                                {

                                }


                                objEntidadBE.MsgError = MsgError.Value.ToString();



                            }
                        }
                        catch (Exception exx)
                        {
                            objEntidadBE.MsgError = exx.ToString();
                        }


                }



            }
            catch (Exception ex)
            {

                throw ex;

            }
            return objEntidadBE;


        }

        public LGProductosCE F_LGProductos_Update(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    if (Tipo == "")
                        sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    else
                        sql_conexion.ConnectionString = (new SqlConnectionStringBuilder() { DataSource = DBHost, InitialCatalog = DBDataBase, UserID = DBUser, Password = DBPass }).ConnectionString;
                    bool Conectado = false;
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
                                sql_comando.CommandText = "pa_LGProductos_Update";

                                sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                                sql_comando.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;
                                sql_comando.Parameters.Add("@DscProducto", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProducto;
                                sql_comando.Parameters.Add("@DscProductoIngles", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProductoIngles;
                                sql_comando.Parameters.Add("@PartidaArancelaria", SqlDbType.VarChar, 250).Value = objEntidadBE.PartidaArancelaria;
                                sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                                sql_comando.Parameters.Add("@CodUnidadCompra", SqlDbType.Int).Value = objEntidadBE.CodUnidadCompra;
                                sql_comando.Parameters.Add("@CodUnidadVenta", SqlDbType.Int).Value = objEntidadBE.CodUnidadVenta;
                                sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                                sql_comando.Parameters.Add("@CostoSoles", SqlDbType.Decimal).Value = objEntidadBE.CostoSoles;
                                sql_comando.Parameters.Add("@CostoDolares", SqlDbType.Decimal).Value = objEntidadBE.CostoDolares;
                                sql_comando.Parameters.Add("@Factor", SqlDbType.Int).Value = objEntidadBE.Factor;
                                sql_comando.Parameters.Add("@CodigoInterno", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoInterno;
                                sql_comando.Parameters.Add("@CodigoProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoProducto;
                                sql_comando.Parameters.Add("@CodigoAlternativo", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoAlternativo;
                                sql_comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = objEntidadBE.Precio;
                                sql_comando.Parameters.Add("@Precio2", SqlDbType.Decimal).Value = objEntidadBE.Precio2;
                                sql_comando.Parameters.Add("@Precio3", SqlDbType.Decimal).Value = objEntidadBE.Precio3;

                                sql_comando.Parameters.Add("@PrecioDolares", SqlDbType.Decimal).Value = objEntidadBE.PrecioDolares;
                                sql_comando.Parameters.Add("@Precio2Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio2Dolares;
                                sql_comando.Parameters.Add("@Precio3Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio3Dolares;
                                sql_comando.Parameters.Add("@StockMaximo", SqlDbType.Decimal).Value = objEntidadBE.StockMaximo;
                                sql_comando.Parameters.Add("@StockMinimo", SqlDbType.Decimal).Value = objEntidadBE.StockMinimo;
                                sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                                sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 200).Value = objEntidadBE.Marca;
                                sql_comando.Parameters.Add("@Medida", SqlDbType.VarChar, 200).Value = objEntidadBE.Medida;
                                sql_comando.Parameters.Add("@Modelo", SqlDbType.VarChar, 200).Value = objEntidadBE.Modelo;
                                sql_comando.Parameters.Add("@Posicion", SqlDbType.VarChar, 200).Value = objEntidadBE.Posicion;
                                sql_comando.Parameters.Add("@Anio", SqlDbType.VarChar, 200).Value = objEntidadBE.Anio;
                                sql_comando.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 200).Value = objEntidadBE.Ubicacion;
                                sql_comando.Parameters.Add("@Img1", SqlDbType.Int).Value = objEntidadBE.IdImagenProducto1;
                                sql_comando.Parameters.Add("@M1", SqlDbType.Decimal).Value = objEntidadBE.M1;
                                sql_comando.Parameters.Add("@M2", SqlDbType.Decimal).Value = objEntidadBE.M2;
                                sql_comando.Parameters.Add("@Comentario", SqlDbType.VarChar, 8000).Value = objEntidadBE.Comentario;
                                sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                                sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                                sql_comando.Parameters.Add("@CodigoFabrica", SqlDbType.VarChar, 200).Value = objEntidadBE.CodigoFabrica;

                                sql_comando.Parameters.Add("@PrecioApp", SqlDbType.Decimal).Value = objEntidadBE.PrecioApp;
                                sql_comando.Parameters.Add("@PrecioAppDolares", SqlDbType.Decimal).Value = objEntidadBE.PrecioAppDolares;
                                sql_comando.Parameters.Add("@SeVendeEnApp", SqlDbType.Int).Value = objEntidadBE.SeVendeEnApp;
                                sql_comando.Parameters.Add("@TituloApp", SqlDbType.VarChar, 200).Value = objEntidadBE.TituloApp;
                                sql_comando.Parameters.Add("@DescripcionDetalladaApp", SqlDbType.VarChar, 5000).Value = objEntidadBE.DescripcionDetalladaApp;

                                SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                                MsgError.Direction = ParameterDirection.Output;
                                SqlParameter CodAlterno = sql_comando.Parameters.Add("@CodAlternoOut", SqlDbType.VarChar, 15);
                                CodAlterno.Direction = ParameterDirection.Output;

                                sql_comando.ExecuteNonQuery();

                                objEntidadBE.MsgError = MsgError.Value.ToString();
                                objEntidadBE.CodAlterno = CodAlterno.Value.ToString();
                                try
                                {
                                    //pasa imagen desde el temporal
                                    if (objEntidadBE.Imagenes.Count > 0)
                                    {
                                        int codusuariomod = objEntidadBE.CodUsuarioMod; if (codusuariomod == 0) codusuariomod = objEntidadBE.CodUsuario;
                                        ImagenesCD x = new ImagenesCD();
                                        foreach (dynamic img in objEntidadBE.Imagenes)
                                        {
                                            try
                                            {
                                                x.F_Imagenes_Insert_From_Temporal(int.Parse(img.ToString()), codusuariomod, objEntidadBE.CodAlterno, objEntidadBE.IPRegistro);
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }

                                    }
                                }
                                catch (Exception ex)
                                {

                                }



                            }

                        }
                        catch (Exception exx)
                        {

                        }

                }

                return objEntidadBE;

            }
            catch (Exception ex)
            {

                throw ex;

            }



        }
        
        public LGProductosCE F_LGProductos_Update_Alvarado(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    if (Tipo == "")
                        sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    else
                        sql_conexion.ConnectionString = (new SqlConnectionStringBuilder() { DataSource = DBHost, InitialCatalog = DBDataBase, UserID = DBUser, Password = DBPass }).ConnectionString;
                    bool Conectado = false;
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
                                sql_comando.CommandText = "pa_LGProductos_Update";

                                sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                                sql_comando.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;
                                sql_comando.Parameters.Add("@DscProducto", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProducto;
                                sql_comando.Parameters.Add("@DscProductoIngles", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProductoIngles;
                                sql_comando.Parameters.Add("@PartidaArancelaria", SqlDbType.VarChar, 250).Value = objEntidadBE.PartidaArancelaria;
                                sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                                sql_comando.Parameters.Add("@CodUnidadCompra", SqlDbType.Int).Value = objEntidadBE.CodUnidadCompra;
                                sql_comando.Parameters.Add("@CodUnidadVenta", SqlDbType.Int).Value = objEntidadBE.CodUnidadVenta;
                                sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                                sql_comando.Parameters.Add("@CostoSoles", SqlDbType.Decimal).Value = objEntidadBE.CostoSoles;
                                sql_comando.Parameters.Add("@CostoDolares", SqlDbType.Decimal).Value = objEntidadBE.CostoDolares;
                                sql_comando.Parameters.Add("@Factor", SqlDbType.Int).Value = objEntidadBE.Factor;
                                sql_comando.Parameters.Add("@CodigoInterno", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoInterno;
                                sql_comando.Parameters.Add("@CodigoProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoProducto;
                                sql_comando.Parameters.Add("@CodigoAlternativo", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoAlternativo;
                                sql_comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = objEntidadBE.Precio;
                                sql_comando.Parameters.Add("@Precio2", SqlDbType.Decimal).Value = objEntidadBE.Precio2;
                                sql_comando.Parameters.Add("@Precio3", SqlDbType.Decimal).Value = objEntidadBE.Precio3;
                                sql_comando.Parameters.Add("@PrecioDolares", SqlDbType.Decimal).Value = objEntidadBE.PrecioDolares;
                                sql_comando.Parameters.Add("@Precio2Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio2Dolares;
                                sql_comando.Parameters.Add("@Precio3Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio3Dolares;
                                sql_comando.Parameters.Add("@StockMaximo", SqlDbType.Decimal).Value = objEntidadBE.StockMaximo;
                                sql_comando.Parameters.Add("@StockMinimo", SqlDbType.Decimal).Value = objEntidadBE.StockMinimo;
                                sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                                sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 200).Value = objEntidadBE.Marca;
                                sql_comando.Parameters.Add("@Medida", SqlDbType.VarChar, 200).Value = objEntidadBE.Medida;
                                sql_comando.Parameters.Add("@Modelo", SqlDbType.VarChar, 200).Value = objEntidadBE.Modelo;
                                sql_comando.Parameters.Add("@Posicion", SqlDbType.VarChar, 200).Value = objEntidadBE.Posicion;
                                sql_comando.Parameters.Add("@Anio", SqlDbType.VarChar, 200).Value = objEntidadBE.Anio;
                                sql_comando.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 200).Value = objEntidadBE.Ubicacion;
                                sql_comando.Parameters.Add("@Img1", SqlDbType.Int).Value = objEntidadBE.IdImagenProducto1;
                                sql_comando.Parameters.Add("@M1", SqlDbType.Decimal).Value = objEntidadBE.M1;
                                sql_comando.Parameters.Add("@M2", SqlDbType.Decimal).Value = objEntidadBE.M2;
                                sql_comando.Parameters.Add("@Comentario", SqlDbType.VarChar, 8000).Value = objEntidadBE.Comentario;
                                sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                                sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                                sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 1000).Value = objEntidadBE.Observacion;
                                sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidadBE.CodCategoria;
                                sql_comando.Parameters.Add("@CantidadMayorista", SqlDbType.Decimal).Value = objEntidadBE.CantidadMayorista;
                                sql_comando.Parameters.Add("@CantidadMayoristaLimite", SqlDbType.Decimal).Value = objEntidadBE.CantidadMayoristaLimite;
                                sql_comando.Parameters.Add("@PermisoMayorista", SqlDbType.Int).Value = objEntidadBE.PermisoMayorista;
                                sql_comando.Parameters.Add("@CodigoMenu", SqlDbType.Int).Value = objEntidadBE.CodigoMenu;
                                sql_comando.Parameters.Add("@Exclusivo", SqlDbType.Decimal).Value = objEntidadBE.Exclusivo;

                                SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                                MsgError.Direction = ParameterDirection.Output;
                                SqlParameter CodAlterno = sql_comando.Parameters.Add("@CodAlternoOut", SqlDbType.VarChar, 15);
                                CodAlterno.Direction = ParameterDirection.Output;

                                sql_comando.ExecuteNonQuery();

                                objEntidadBE.MsgError = MsgError.Value.ToString();
                                objEntidadBE.CodAlterno = CodAlterno.Value.ToString();
                                try
                                {
                                    //pasa imagen desde el temporal
                                    if (objEntidadBE.Imagenes.Count > 0)
                                    {
                                        int codusuariomod = objEntidadBE.CodUsuarioMod; if (codusuariomod == 0) codusuariomod = objEntidadBE.CodUsuario;
                                        ImagenesCD x = new ImagenesCD();
                                        foreach (dynamic img in objEntidadBE.Imagenes)
                                        {
                                            try
                                            {
                                                x.F_Imagenes_Insert_From_Temporal(int.Parse(img.ToString()), codusuariomod, objEntidadBE.CodAlterno, objEntidadBE.IPRegistro);
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }

                                    }
                                }
                                catch (Exception ex)
                                {

                                }



                            }

                        }
                        catch (Exception exx)
                        {

                        }

                }

                return objEntidadBE;

            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public LGProductosCE F_LGProductos_Update_Tractos(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    if (Tipo == "")
                        sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    else
                        sql_conexion.ConnectionString = (new SqlConnectionStringBuilder() { DataSource = DBHost, InitialCatalog = DBDataBase, UserID = DBUser, Password = DBPass }).ConnectionString;
                    bool Conectado = false;
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
                                sql_comando.CommandText = "pa_LGProductos_Update";

                                sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                                sql_comando.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;
                                sql_comando.Parameters.Add("@DscProducto", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProducto;
                                sql_comando.Parameters.Add("@DscProductoIngles", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProductoIngles;
                                sql_comando.Parameters.Add("@PartidaArancelaria", SqlDbType.VarChar, 250).Value = objEntidadBE.PartidaArancelaria;
                                sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                                sql_comando.Parameters.Add("@CodUnidadCompra", SqlDbType.Int).Value = objEntidadBE.CodUnidadCompra;
                                sql_comando.Parameters.Add("@CodUnidadVenta", SqlDbType.Int).Value = objEntidadBE.CodUnidadVenta;
                                sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                                sql_comando.Parameters.Add("@CostoSoles", SqlDbType.Decimal).Value = objEntidadBE.CostoSoles;
                                sql_comando.Parameters.Add("@CostoDolares", SqlDbType.Decimal).Value = objEntidadBE.CostoDolares;
                                sql_comando.Parameters.Add("@Factor", SqlDbType.Int).Value = objEntidadBE.Factor;
                                sql_comando.Parameters.Add("@CodigoInterno", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoInterno;
                                sql_comando.Parameters.Add("@CodigoProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoProducto;
                                sql_comando.Parameters.Add("@CodigoAlternativo", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoAlternativo;
                                sql_comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = objEntidadBE.Precio;
                                sql_comando.Parameters.Add("@Precio2", SqlDbType.Decimal).Value = objEntidadBE.Precio2;
                                sql_comando.Parameters.Add("@Precio3", SqlDbType.Decimal).Value = objEntidadBE.Precio3;
                                sql_comando.Parameters.Add("@PrecioDolares", SqlDbType.Decimal).Value = objEntidadBE.PrecioDolares;
                                sql_comando.Parameters.Add("@Precio2Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio2Dolares;
                                sql_comando.Parameters.Add("@Precio3Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio3Dolares;
                                sql_comando.Parameters.Add("@StockMaximo", SqlDbType.Decimal).Value = objEntidadBE.StockMaximo;
                                sql_comando.Parameters.Add("@StockMinimo", SqlDbType.Decimal).Value = objEntidadBE.StockMinimo;
                                sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                                sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 200).Value = objEntidadBE.Marca;
                                sql_comando.Parameters.Add("@Medida", SqlDbType.VarChar, 200).Value = objEntidadBE.Medida;
                                sql_comando.Parameters.Add("@Modelo", SqlDbType.VarChar, 200).Value = objEntidadBE.Modelo;
                                sql_comando.Parameters.Add("@Posicion", SqlDbType.VarChar, 200).Value = objEntidadBE.Posicion;
                                sql_comando.Parameters.Add("@Anio", SqlDbType.VarChar, 200).Value = objEntidadBE.Anio;
                                sql_comando.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 200).Value = objEntidadBE.Ubicacion;
                                sql_comando.Parameters.Add("@Img1", SqlDbType.Int).Value = objEntidadBE.IdImagenProducto1;
                                sql_comando.Parameters.Add("@M1", SqlDbType.Decimal).Value = objEntidadBE.M1;
                                sql_comando.Parameters.Add("@M2", SqlDbType.Decimal).Value = objEntidadBE.M2;
                                sql_comando.Parameters.Add("@Comentario", SqlDbType.VarChar, 8000).Value = objEntidadBE.Comentario;
                                sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                                sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                               
                               
                               
                                SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                                MsgError.Direction = ParameterDirection.Output;
                                SqlParameter CodAlterno = sql_comando.Parameters.Add("@CodAlternoOut", SqlDbType.VarChar, 15);
                                CodAlterno.Direction = ParameterDirection.Output;

                                sql_comando.ExecuteNonQuery();

                                objEntidadBE.MsgError = MsgError.Value.ToString();
                                objEntidadBE.CodAlterno = CodAlterno.Value.ToString();
                                try
                                {
                                    //pasa imagen desde el temporal
                                    if (objEntidadBE.Imagenes.Count > 0)
                                    {
                                        int codusuariomod = objEntidadBE.CodUsuarioMod; if (codusuariomod == 0) codusuariomod = objEntidadBE.CodUsuario;
                                        ImagenesCD x = new ImagenesCD();
                                        foreach (dynamic img in objEntidadBE.Imagenes)
                                        {
                                            try
                                            {
                                                x.F_Imagenes_Insert_From_Temporal(int.Parse(img.ToString()), codusuariomod, objEntidadBE.CodAlterno, objEntidadBE.IPRegistro);
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }

                                    }
                                }
                                catch (Exception ex)
                                {

                                }



                            }

                        }
                        catch (Exception exx)
                        {

                        }

                }

                return objEntidadBE;

            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public LGProductosCE F_LGProductos_Update_Povis(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    if (Tipo == "")
                        sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    else
                        sql_conexion.ConnectionString = (new SqlConnectionStringBuilder() { DataSource = DBHost, InitialCatalog = DBDataBase, UserID = DBUser, Password = DBPass }).ConnectionString;
                    bool Conectado = false;
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
                                sql_comando.CommandText = "pa_LGProductos_Update";

                                sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                                sql_comando.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;
                                sql_comando.Parameters.Add("@DscProducto", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProducto;
                                sql_comando.Parameters.Add("@DscProductoIngles", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProductoIngles;
                                sql_comando.Parameters.Add("@PartidaArancelaria", SqlDbType.VarChar, 250).Value = objEntidadBE.PartidaArancelaria;
                                sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                                sql_comando.Parameters.Add("@CodUnidadCompra", SqlDbType.Int).Value = objEntidadBE.CodUnidadCompra;
                                sql_comando.Parameters.Add("@CodUnidadVenta", SqlDbType.Int).Value = objEntidadBE.CodUnidadVenta;
                                sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                                sql_comando.Parameters.Add("@CostoSoles", SqlDbType.Decimal).Value = objEntidadBE.CostoSoles;
                                sql_comando.Parameters.Add("@CostoDolares", SqlDbType.Decimal).Value = objEntidadBE.CostoDolares;
                                sql_comando.Parameters.Add("@Factor", SqlDbType.Int).Value = objEntidadBE.Factor;
                                sql_comando.Parameters.Add("@CodigoInterno", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoInterno;
                                sql_comando.Parameters.Add("@CodigoProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoProducto;
                                sql_comando.Parameters.Add("@CodigoAlternativo", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoAlternativo;
                                sql_comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = objEntidadBE.Precio;
                                sql_comando.Parameters.Add("@Precio2", SqlDbType.Decimal).Value = objEntidadBE.Precio2;
                                sql_comando.Parameters.Add("@Precio3", SqlDbType.Decimal).Value = objEntidadBE.Precio3;
                                sql_comando.Parameters.Add("@M1", SqlDbType.Decimal).Value = objEntidadBE.M1;
                                sql_comando.Parameters.Add("@M2", SqlDbType.Decimal).Value = objEntidadBE.M2;
                                sql_comando.Parameters.Add("@M3", SqlDbType.Decimal).Value = objEntidadBE.M3;
                                sql_comando.Parameters.Add("@PrecioDolares", SqlDbType.Decimal).Value = objEntidadBE.PrecioDolares;
                                sql_comando.Parameters.Add("@Precio2Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio2Dolares;
                                sql_comando.Parameters.Add("@Precio3Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio3Dolares;
                                sql_comando.Parameters.Add("@StockMaximo", SqlDbType.Decimal).Value = objEntidadBE.StockMaximo;
                                sql_comando.Parameters.Add("@StockMinimo", SqlDbType.Decimal).Value = objEntidadBE.StockMinimo;
                                sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                                sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 200).Value = objEntidadBE.Marca;
                                sql_comando.Parameters.Add("@Medida", SqlDbType.VarChar, 200).Value = objEntidadBE.Medida;
                                sql_comando.Parameters.Add("@Modelo", SqlDbType.VarChar, 200).Value = objEntidadBE.Modelo;
                                sql_comando.Parameters.Add("@Posicion", SqlDbType.VarChar, 200).Value = objEntidadBE.Posicion;
                                sql_comando.Parameters.Add("@Anio", SqlDbType.VarChar, 200).Value = objEntidadBE.Anio;
                                sql_comando.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 200).Value = objEntidadBE.Ubicacion;
                                sql_comando.Parameters.Add("@Img1", SqlDbType.Int).Value = objEntidadBE.IdImagenProducto1;
                                sql_comando.Parameters.Add("@Comentario", SqlDbType.VarChar, 8000).Value = objEntidadBE.Comentario;
                                sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                                sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                                sql_comando.Parameters.Add("@Orden", SqlDbType.Int).Value = objEntidadBE.Orden;

                                SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                                MsgError.Direction = ParameterDirection.Output;
                                SqlParameter CodAlterno = sql_comando.Parameters.Add("@CodAlternoOut", SqlDbType.VarChar, 15);
                                CodAlterno.Direction = ParameterDirection.Output;

                                sql_comando.ExecuteNonQuery();

                                objEntidadBE.MsgError = MsgError.Value.ToString();
                                objEntidadBE.CodAlterno = CodAlterno.Value.ToString();
                                try
                                {
                                    //pasa imagen desde el temporal
                                    if (objEntidadBE.Imagenes.Count > 0)
                                    {
                                        int codusuariomod = objEntidadBE.CodUsuarioMod; if (codusuariomod == 0) codusuariomod = objEntidadBE.CodUsuario;
                                        ImagenesCD x = new ImagenesCD();
                                        foreach (dynamic img in objEntidadBE.Imagenes)
                                        {
                                            try
                                            {
                                                x.F_Imagenes_Insert_From_Temporal(int.Parse(img.ToString()), codusuariomod, objEntidadBE.CodAlterno, objEntidadBE.IPRegistro);
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }

                                    }
                                }
                                catch (Exception ex)
                                {

                                }



                            }

                        }
                        catch (Exception exx)
                        {

                        }

                }

                return objEntidadBE;

            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public LGProductosCE F_LGProductos_Update_Yordan(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    if (Tipo == "")
                        sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    else
                        sql_conexion.ConnectionString = (new SqlConnectionStringBuilder() { DataSource = DBHost, InitialCatalog = DBDataBase, UserID = DBUser, Password = DBPass }).ConnectionString;
                    bool Conectado = false;
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
                                sql_comando.CommandText = "pa_LGProductos_Update";

                                sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                                sql_comando.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;
                                sql_comando.Parameters.Add("@DscProducto", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProducto;
                                sql_comando.Parameters.Add("@DscProductoIngles", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProductoIngles;
                                sql_comando.Parameters.Add("@PartidaArancelaria", SqlDbType.VarChar, 250).Value = objEntidadBE.PartidaArancelaria;
                                sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                                sql_comando.Parameters.Add("@CodUnidadCompra", SqlDbType.Int).Value = objEntidadBE.CodUnidadCompra;
                                sql_comando.Parameters.Add("@CodUnidadVenta", SqlDbType.Int).Value = objEntidadBE.CodUnidadVenta;
                                sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                                sql_comando.Parameters.Add("@CostoSoles", SqlDbType.Decimal).Value = objEntidadBE.CostoSoles;
                                sql_comando.Parameters.Add("@CostoDolares", SqlDbType.Decimal).Value = objEntidadBE.CostoDolares;
                                sql_comando.Parameters.Add("@Factor", SqlDbType.Int).Value = objEntidadBE.Factor;
                                sql_comando.Parameters.Add("@CodigoInterno", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoInterno;
                                sql_comando.Parameters.Add("@CodigoProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoProducto;
                                sql_comando.Parameters.Add("@CodigoAlternativo", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoAlternativo;
                                sql_comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = objEntidadBE.Precio;
                                sql_comando.Parameters.Add("@Precio2", SqlDbType.Decimal).Value = objEntidadBE.Precio2;
                                sql_comando.Parameters.Add("@Precio3", SqlDbType.Decimal).Value = objEntidadBE.Precio3;
                                sql_comando.Parameters.Add("@Precio4", SqlDbType.Decimal).Value = objEntidadBE.Precio4;
                                sql_comando.Parameters.Add("@PrecioDolares", SqlDbType.Decimal).Value = objEntidadBE.PrecioDolares;
                                sql_comando.Parameters.Add("@Precio2Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio2Dolares;
                                sql_comando.Parameters.Add("@Precio3Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio3Dolares;
                                sql_comando.Parameters.Add("@Precio4Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio4Dolares;
                                sql_comando.Parameters.Add("@StockMaximo", SqlDbType.Decimal).Value = objEntidadBE.StockMaximo;
                                sql_comando.Parameters.Add("@StockMinimo", SqlDbType.Decimal).Value = objEntidadBE.StockMinimo;
                                sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                                sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 200).Value = objEntidadBE.Marca;
                                sql_comando.Parameters.Add("@Medida", SqlDbType.VarChar, 200).Value = objEntidadBE.Medida;
                                sql_comando.Parameters.Add("@Modelo", SqlDbType.VarChar, 200).Value = objEntidadBE.Modelo;
                                sql_comando.Parameters.Add("@Posicion", SqlDbType.VarChar, 200).Value = objEntidadBE.Posicion;
                                sql_comando.Parameters.Add("@Anio", SqlDbType.VarChar, 200).Value = objEntidadBE.Anio;
                                sql_comando.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 200).Value = objEntidadBE.Ubicacion;
                                sql_comando.Parameters.Add("@Img1", SqlDbType.Int).Value = objEntidadBE.IdImagenProducto1;
                                sql_comando.Parameters.Add("@M1", SqlDbType.Decimal).Value = objEntidadBE.M1;
                                sql_comando.Parameters.Add("@M2", SqlDbType.Decimal).Value = objEntidadBE.M2;
                                sql_comando.Parameters.Add("@Comentario", SqlDbType.VarChar, 8000).Value = objEntidadBE.Comentario;
                                sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                                sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;

                                SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                                MsgError.Direction = ParameterDirection.Output;
                                SqlParameter CodAlterno = sql_comando.Parameters.Add("@CodAlternoOut", SqlDbType.VarChar, 15);
                                CodAlterno.Direction = ParameterDirection.Output;

                                sql_comando.ExecuteNonQuery();

                                objEntidadBE.MsgError = MsgError.Value.ToString();
                                objEntidadBE.CodAlterno = CodAlterno.Value.ToString();
                                try
                                {
                                    //pasa imagen desde el temporal
                                    if (objEntidadBE.Imagenes.Count > 0)
                                    {
                                        int codusuariomod = objEntidadBE.CodUsuarioMod; if (codusuariomod == 0) codusuariomod = objEntidadBE.CodUsuario;
                                        ImagenesCD x = new ImagenesCD();
                                        foreach (dynamic img in objEntidadBE.Imagenes)
                                        {
                                            try
                                            {
                                                x.F_Imagenes_Insert_From_Temporal(int.Parse(img.ToString()), codusuariomod, objEntidadBE.CodAlterno, objEntidadBE.IPRegistro);
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }

                                    }
                                }
                                catch (Exception ex)
                                {

                                }



                            }

                        }
                        catch (Exception exx)
                        {

                        }

                }

                return objEntidadBE;

            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public LGProductosCE F_LGProductos_Update_Roman(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    if (Tipo == "")
                        sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    else
                        sql_conexion.ConnectionString = (new SqlConnectionStringBuilder() { DataSource = DBHost, InitialCatalog = DBDataBase, UserID = DBUser, Password = DBPass }).ConnectionString;
                    bool Conectado = false;
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
                                sql_comando.CommandText = "pa_LGProductos_Update";

                                sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                                sql_comando.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;
                                sql_comando.Parameters.Add("@DscProducto", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProducto;
                                sql_comando.Parameters.Add("@DscProductoIngles", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProductoIngles;
                                sql_comando.Parameters.Add("@PartidaArancelaria", SqlDbType.VarChar, 250).Value = objEntidadBE.PartidaArancelaria;
                                sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                                sql_comando.Parameters.Add("@CodUnidadCompra", SqlDbType.Int).Value = objEntidadBE.CodUnidadCompra;
                                sql_comando.Parameters.Add("@CodUnidadVenta", SqlDbType.Int).Value = objEntidadBE.CodUnidadVenta;
                                sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                                sql_comando.Parameters.Add("@CostoSoles", SqlDbType.Decimal).Value = objEntidadBE.CostoSoles;
                                sql_comando.Parameters.Add("@CostoDolares", SqlDbType.Decimal).Value = objEntidadBE.CostoDolares;
                                sql_comando.Parameters.Add("@Factor", SqlDbType.Int).Value = objEntidadBE.Factor;
                                sql_comando.Parameters.Add("@CodigoInterno", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoInterno;
                                sql_comando.Parameters.Add("@CodigoProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoProducto;
                                sql_comando.Parameters.Add("@CodigoAlternativo", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoAlternativo;
                                sql_comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = objEntidadBE.Precio;
                                sql_comando.Parameters.Add("@Precio2", SqlDbType.Decimal).Value = objEntidadBE.Precio2;
                                sql_comando.Parameters.Add("@Precio3", SqlDbType.Decimal).Value = objEntidadBE.Precio3;
                                sql_comando.Parameters.Add("@Precio4", SqlDbType.Decimal).Value = objEntidadBE.Precio4;
                                sql_comando.Parameters.Add("@Precio5", SqlDbType.Decimal).Value = objEntidadBE.Precio5;
                                sql_comando.Parameters.Add("@PrecioDolares", SqlDbType.Decimal).Value = objEntidadBE.PrecioDolares;
                                sql_comando.Parameters.Add("@Precio2Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio2Dolares;
                                sql_comando.Parameters.Add("@Precio3Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio3Dolares;
                                sql_comando.Parameters.Add("@Precio4Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio4Dolares;
                                sql_comando.Parameters.Add("@Precio5Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio5Dolares;
                                sql_comando.Parameters.Add("@StockMaximo", SqlDbType.Decimal).Value = objEntidadBE.StockMaximo;
                                sql_comando.Parameters.Add("@StockMinimo", SqlDbType.Decimal).Value = objEntidadBE.StockMinimo;
                                sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                                sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 200).Value = objEntidadBE.Marca;
                                sql_comando.Parameters.Add("@Medida", SqlDbType.VarChar, 200).Value = objEntidadBE.Medida;
                                sql_comando.Parameters.Add("@Modelo", SqlDbType.VarChar, 200).Value = objEntidadBE.Modelo;
                                sql_comando.Parameters.Add("@Posicion", SqlDbType.VarChar, 200).Value = objEntidadBE.Posicion;
                                sql_comando.Parameters.Add("@Anio", SqlDbType.VarChar, 200).Value = objEntidadBE.Anio;
                                sql_comando.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 200).Value = objEntidadBE.Ubicacion;
                                sql_comando.Parameters.Add("@Img1", SqlDbType.Int).Value = objEntidadBE.IdImagenProducto1;

                                sql_comando.Parameters.Add("@Comentario", SqlDbType.VarChar, 8000).Value = objEntidadBE.Comentario;
                                sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;

                                sql_comando.Parameters.Add("@Pais", SqlDbType.VarChar, 50).Value = objEntidadBE.Pais;
                                sql_comando.Parameters.Add("@FlagCpe", SqlDbType.Int).Value = objEntidadBE.FlagCpe;
                                sql_comando.Parameters.Add("@D1", SqlDbType.VarChar, 10).Value = objEntidadBE.D1;
                                sql_comando.Parameters.Add("@D2", SqlDbType.VarChar, 10).Value = objEntidadBE.D2;
                                sql_comando.Parameters.Add("@D3", SqlDbType.VarChar, 10).Value = objEntidadBE.D3;
                                sql_comando.Parameters.Add("@D4", SqlDbType.VarChar, 10).Value = objEntidadBE.D4;
                                sql_comando.Parameters.Add("@D5", SqlDbType.VarChar, 10).Value = objEntidadBE.D5;
                                sql_comando.Parameters.Add("@D6", SqlDbType.VarChar, 10).Value = objEntidadBE.D6;
                                sql_comando.Parameters.Add("@D7", SqlDbType.VarChar, 10).Value = objEntidadBE.D7;

                                sql_comando.Parameters.Add("@M1", SqlDbType.VarChar, 10).Value = objEntidadBE.M1str;
                                sql_comando.Parameters.Add("@M2", SqlDbType.VarChar, 10).Value = objEntidadBE.M2str;
                                sql_comando.Parameters.Add("@M3", SqlDbType.VarChar, 10).Value = objEntidadBE.M3str;
                                //Margen
                                sql_comando.Parameters.Add("@Margen1", SqlDbType.Decimal).Value = objEntidadBE.Margen1;
                                sql_comando.Parameters.Add("@Margen2", SqlDbType.Decimal).Value = objEntidadBE.Margen2;
                                sql_comando.Parameters.Add("@Margen3", SqlDbType.Decimal).Value = objEntidadBE.Margen3;
                                sql_comando.Parameters.Add("@Margen4", SqlDbType.Decimal).Value = objEntidadBE.Margen4;
                                sql_comando.Parameters.Add("@Margen5", SqlDbType.Decimal).Value = objEntidadBE.Margen5;
                                //Margen


                                sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;

                                SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                                MsgError.Direction = ParameterDirection.Output;
                                SqlParameter CodAlterno = sql_comando.Parameters.Add("@CodAlternoOut", SqlDbType.VarChar, 15);
                                CodAlterno.Direction = ParameterDirection.Output;

                                sql_comando.ExecuteNonQuery();

                                objEntidadBE.MsgError = MsgError.Value.ToString();
                                objEntidadBE.CodAlterno = CodAlterno.Value.ToString();
                                try
                                {
                                    //pasa imagen desde el temporal
                                    if (objEntidadBE.Imagenes.Count > 0)
                                    {
                                        int codusuariomod = objEntidadBE.CodUsuarioMod; if (codusuariomod == 0) codusuariomod = objEntidadBE.CodUsuario;
                                        ImagenesCD x = new ImagenesCD();
                                        foreach (dynamic img in objEntidadBE.Imagenes)
                                        {
                                            try
                                            {
                                                x.F_Imagenes_Insert_From_Temporal(int.Parse(img.ToString()), codusuariomod, objEntidadBE.CodAlterno, objEntidadBE.IPRegistro);
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }

                                    }
                                }
                                catch (Exception ex)
                                {

                                }



                            }

                        }
                        catch (Exception exx)
                        {

                        }

                }

                return objEntidadBE;

            }
            catch (Exception ex)
            {

                throw ex;

            }



        }
        
        public LGProductosCE F_LGProductos_Eliminar(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_Eliminar";

                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 250);
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

        public LGProductosCE F_LGProductos_Activar(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_Activar";

                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 250);
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

        public DataTable F_LGProductos_Listar(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_Listar";

                        if (objEntidadBE.DscProducto.TrimEnd().TrimStart() != "")
                            sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 150).Value = objEntidadBE.DscProducto;

                        if (objEntidadBE.IdFamilia > 0)
                            sql_comando.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

                        if (objEntidadBE.CodEstado > 0)
                            sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;

                        if (objEntidadBE.chkMarca > 0)
                            sql_comando.Parameters.Add("@CodMarca", SqlDbType.Int).Value = objEntidadBE.CodMarca;

                        sql_comando.Parameters.Add("@FlagProductosConStock", SqlDbType.Int).Value = objEntidadBE.FlagProductosConStock;

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

        public DataTable F_LGProductos_ConsultaMovimiento(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_ListarMovimientos";

                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;

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

        public DataTable F_LGProductos_Select_Ajustes(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_Select_Ajustes";

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@DscArticulo", SqlDbType.VarChar, 150).Value = objEntidadBE.DscProducto;

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

        public LGProductosCE F_LGProductos_Ajuste(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_Ajustes";

                        sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 500).Value = objEntidadBE.Observacion;

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

        public DataTable F_LGProductos_Inventario_StockActual(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGStockAlmacen_Inventario_StockActual_Povis";

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

                        if (objEntidadBE.IdFamilia > 0)
                            sql_comando.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;

                        if (objEntidadBE.DscProducto != "")
                            sql_comando.Parameters.Add("@DscProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.DscProducto;

                        if (objEntidadBE.chkMarca > 0)
                            sql_comando.Parameters.Add("@CodMarca", SqlDbType.Int).Value = objEntidadBE.CodMarca;

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

        public DataTable F_LGStockAlmacen_Inventario_StockExterno_Listar(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGStockAlmacen_Inventario_StockExterno_Listar";

                        sql_comando.Parameters.Add("@CodigoProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoProducto;

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

        public DataTable F_LGProductos_InventarioPeriodo(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_InventarioPeriodo";

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@Periodo", SqlDbType.Int).Value = objEntidadBE.Periodo;

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

        public DataTable F_LGProductos_KardexSunat(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Movimientos_InventarioUnidadesFisicas";

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@Periodo", SqlDbType.Int).Value = objEntidadBE.Periodo;

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

        public LGProductosCE F_LGProductosServicios_Update(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductosServicios_Update";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                        sql_comando.Parameters.Add("@DscProducto", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProducto;
                        sql_comando.Parameters.Add("@CodigoProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoProducto;
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

        public DataTable F_LGProductos_UltimoPrecio(LGProductosCE objEntidadBE, int maxrow = 5)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_UltimaVentaArticulo";

                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@nrows", SqlDbType.Int).Value = maxrow;

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

        public DataTable F_LGProductos_Select_Compras(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_Select_Compras";

                        sql_comando.Parameters.Add("@DscArticulo", SqlDbType.VarChar, 150).Value = objEntidadBE.DscProducto;
                        sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;

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

        public DataTable F_LGProductos_StockMinimo_Reporte(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_StockMinimo_Reporte";

                        if (objEntidadBE.IdFamilia != 0)
                            sql_comando.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;

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

        public DataTable F_LGProductos_ListarProductosPrecios(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_ListarProductosPrecios";

                        sql_comando.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;
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

        public LGProductosCE F_LGProductos_ActualizarDatos(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_ActualizarDatos";

                        sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;

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

        public DataTable F_Marcas_Listar(int IdFamilia)
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
                        sql_comando.CommandText = "pa_Marcas_listar";
                        sql_comando.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = IdFamilia;

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

        public bool F_AgregarImagen(LGProductosCE objEntidadCE)
        {
            #region VARIABLES

            bool bol_resultado_operacion = false;

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
                        sql_comando.CommandText = "usp_insert_TemporalImagen";

                        sql_comando.Parameters.Add("@B_ImagenTem", SqlDbType.VarBinary).Value = objEntidadCE.B_ImagenTem;
                        //sql_comando.Parameters.Add("@Flg_QR", SqlDbType.Int).Value = objEntidadCE.Flg_Imagen;


                        sql_comando.ExecuteNonQuery();


                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;

            }

            return bol_resultado_operacion;

        }

        public string F_ConsultarUltimaImagenTemp(out String str_mensaje_operacion)
        {
            #region VARIABLES

            String str_imagen = "";
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
                        sql_comando.CommandText = "usp_primary_TemporalImagen";


                        SqlParameter Imagen = sql_comando.Parameters.Add("@ID_Imagen", SqlDbType.VarChar, 200);
                        Imagen.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();
                        if (Imagen != null && Convert.ToString(Imagen.Value) != "")
                        {
                            str_imagen = Convert.ToString(Imagen.Value);

                        }

                        str_mensaje_operacion = string.Empty;
                    }
                }

                return str_imagen;

            }
            catch (Exception ex)
            {

                str_mensaje_operacion = ex.Message.ToString();

                return null;
            }

        }

        public bool F_EliminarImagen_Temporal(int ID_TemporalImagen, out string str_mensaje_operacion)
        {
            #region VARIABLES

            bool bol_resultado_operacion = false;
            int int_numero_registro = 0;

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
                        sql_comando.CommandText = "usp_delete_TemporalImagen";

                        #region PARAMETROS

                        sql_comando.Parameters.Add("@ID_TemporalImagen", SqlDbType.Int).Value = ID_TemporalImagen;


                        #endregion

                        int_numero_registro = sql_comando.ExecuteNonQuery();

                        bol_resultado_operacion = int_numero_registro > 0 ? true : false;

                        str_mensaje_operacion = !bol_resultado_operacion ? "NO SE PUDO COMPLETAR LA OPERACIÓN" : string.Empty;

                    }

                }

            }
            catch (Exception ex)
            {
                str_mensaje_operacion = ex.Message.ToString();
                bol_resultado_operacion = false;
            }
            return bol_resultado_operacion;
        }

        public bool F_EliminarImagen(int ID_Imagen, out string str_mensaje_operacion)
        {
            #region VARIABLES

            bool bol_resultado_operacion = false;
            int int_numero_registro = 0;

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
                        sql_comando.CommandText = "usp_delete_Imagen";

                        #region PARAMETROS

                        sql_comando.Parameters.Add("@IdImagen", SqlDbType.Int).Value = ID_Imagen;


                        #endregion

                        int_numero_registro = sql_comando.ExecuteNonQuery();

                        bol_resultado_operacion = int_numero_registro > 0 ? true : false;

                        str_mensaje_operacion = !bol_resultado_operacion ? "NO SE PUDO COMPLETAR LA OPERACIÓN" : string.Empty;

                    }

                }

            }
            catch (Exception ex)
            {
                str_mensaje_operacion = ex.Message.ToString();
                bol_resultado_operacion = false;
            }
            return bol_resultado_operacion;
        }

        public DataTable F_AbrirImagen_CP(LGProductosCE objEntidadCE)
        {
            #region VARIABLES
            DataTable dta_consulta = null;
            #endregion

            try
            {
                //Probar la logica de esta funcion
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "usp_search_ImagenProducto_CP";

                        #region PARAMETROS
                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadCE.CodProducto;
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
        }

        public DataTable F_DescargarImagen_CodProducto(LGProductosCE objEntidad)
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
                        sql_comando.CommandText = "[usp_search_ImagenProducto]";

                        #region PARAMETROS

                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidad.CodEmpresa;
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

        public DataTable F_DescargarDocumento_CP(LGProductosCE objEntidad)
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
                        sql_comando.CommandText = "[usp_search_ImagenProducto]";

                        #region PARAMETROS

                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.VarChar).Value = objEntidad.CodigoProducto;
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

        public DataTable F_LGProductos_ListarVentas_Descuento(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_ListarVentas_Descuento";

                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = objEntidadBE.DscProducto;
                        sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        if (objEntidadBE.FlagCpe != 0)
                            sql_comando.Parameters.Add("@FlagCpe", SqlDbType.Int).Value = objEntidadBE.FlagCpe;

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

        /// <summary>
        /// Actualizacion Asincrona de productos INSERT
        /// </summary>
        /// <param name="objEntidadBE"></param>
        public LGProductosCE Async_F_LGProductos_Insert(LGProductosCE objEntidadBE)
        {
            ProcesosAsincronos pAsync = new ProcesosAsincronos();
            pAsync.F_Async_LGProductos_Insert(objEntidadBE);
            return null;
        }

        /// <summary>
        /// Actualizacion Asincrona de productos UPDATE
        /// </summary>
        /// <param name="objEntidadBE"></param>
        public LGProductosCE Async_F_LGProductos_Update(LGProductosCE objEntidadBE)
        {
            ProcesosAsincronos pAsync = new ProcesosAsincronos();
            pAsync.F_Async_LGProductos_Update(objEntidadBE);
            return null;
        }

        /// <summary>
        /// Actualizacion Asincrona de productos ELIMINAR
        /// </summary>
        /// <param name="objEntidadBE"></param>
        public LGProductosCE Async_F_LGProductos_Eliminar(LGProductosCE objEntidadBE)
        {
            ProcesosAsincronos pAsync = new ProcesosAsincronos();
            pAsync.F_Async_LGProductos_Eliminar(objEntidadBE);
            return null;
        }

        /// <summary>
        /// Clase de actualizacion asincrona con otros almacenes
        /// </summary>
        private class ProcesosAsincronos
        {

            /// <summary>
            /// Actualizacion Asincrona de productos INSERT
            /// </summary>
            /// <param name="objEntidadBE"></param>
            public void F_Async_LGProductos_Insert(LGProductosCE objEntidadBE)
            {
                System.Threading.Thread thread = new System.Threading.Thread(() => F_LGProductos_Insert(objEntidadBE));
                thread.Start();
            }

            /// <summary>
            /// Actualizacion Asincrona de productos UPDATE
            /// </summary>
            /// <param name="objEntidadBE"></param>
            public void F_Async_LGProductos_Update(LGProductosCE objEntidadBE)
            {
                System.Threading.Thread thread = new System.Threading.Thread(() => F_LGProductos_Update(objEntidadBE));
                thread.Start();
            }

            /// <summary>
            /// Actualizacion Asincrona de productos ELIMINAR
            /// </summary>
            /// <param name="objEntidadBE"></param>
            public void F_Async_LGProductos_Eliminar(LGProductosCE objEntidadBE)
            {
                System.Threading.Thread thread = new System.Threading.Thread(() => F_LGProductos_Eliminar(objEntidadBE));
                thread.Start();
            }

            private void F_LGProductos_Insert(LGProductosCE objEntidadBE)
            {
                try
                {
                    using (SqlConnection sql_conexion = new SqlConnection())
                    {
                        sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["ALMACEN1"].ConnectionString;
                        sql_conexion.Open();

                        using (SqlCommand sql_comando = new SqlCommand())
                        {

                            sql_comando.Connection = sql_conexion;
                            sql_comando.CommandType = CommandType.StoredProcedure;
                            sql_comando.CommandText = "pa_LGProductos_Insert";

                            sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                            sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                            sql_comando.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;
                            sql_comando.Parameters.Add("@DscProducto", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProducto;
                            sql_comando.Parameters.Add("@DscProductoIngles", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProductoIngles;
                            sql_comando.Parameters.Add("@PartidaArancelaria", SqlDbType.VarChar, 250).Value = objEntidadBE.PartidaArancelaria;
                            sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                            sql_comando.Parameters.Add("@CodUnidadCompra", SqlDbType.Int).Value = objEntidadBE.CodUnidadCompra;
                            sql_comando.Parameters.Add("@CodUnidadVenta", SqlDbType.Int).Value = objEntidadBE.CodUnidadVenta;
                            sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                            sql_comando.Parameters.Add("@Costo", SqlDbType.Decimal).Value = objEntidadBE.CostoProducto;
                            sql_comando.Parameters.Add("@CostoOriginal", SqlDbType.Decimal).Value = objEntidadBE.CostoOriginal;
                            sql_comando.Parameters.Add("@Factor", SqlDbType.Int).Value = objEntidadBE.Factor;
                            sql_comando.Parameters.Add("@CodigoProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoProducto;
                            sql_comando.Parameters.Add("@CodigoAlternativo", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoAlternativo;
                            sql_comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = objEntidadBE.Precio;
                            sql_comando.Parameters.Add("@Precio2", SqlDbType.Decimal).Value = objEntidadBE.Precio2;
                            sql_comando.Parameters.Add("@Precio3", SqlDbType.Decimal).Value = objEntidadBE.Precio3;
                            sql_comando.Parameters.Add("@StockMaximo", SqlDbType.Decimal).Value = objEntidadBE.StockMaximo;
                            sql_comando.Parameters.Add("@StockMinimo", SqlDbType.Decimal).Value = objEntidadBE.StockMinimo;
                            sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                            sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 200).Value = objEntidadBE.Marca;
                            sql_comando.Parameters.Add("@Medida", SqlDbType.VarChar, 200).Value = objEntidadBE.Medida;
                            sql_comando.Parameters.Add("@Modelo", SqlDbType.VarChar, 200).Value = objEntidadBE.Modelo;
                            sql_comando.Parameters.Add("@Posicion", SqlDbType.VarChar, 200).Value = objEntidadBE.Posicion;
                            sql_comando.Parameters.Add("@Anio", SqlDbType.VarChar, 200).Value = objEntidadBE.Anio;
                            sql_comando.Parameters.Add("@Img1", SqlDbType.Int).Value = objEntidadBE.IdImagenProducto1;

                            SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                            MsgError.Direction = ParameterDirection.Output;
                            SqlParameter CodAlterno = sql_comando.Parameters.Add("@CodAlternoOut", SqlDbType.VarChar, 15);
                            CodAlterno.Direction = ParameterDirection.Output;

                            sql_comando.ExecuteNonQuery();

                            //pasa imagen desde el temporal
                            if (objEntidadBE.Imagenes.Count > 0)
                            {
                                objEntidadBE.CodAlterno = CodAlterno.Value.ToString();
                                ImagenesCD x = new ImagenesCD();
                                foreach (dynamic img in objEntidadBE.Imagenes)
                                {
                                    x.F_Imagenes_Insert_From_Temporal(int.Parse(img.ToString()), objEntidadBE.CodUsuario, objEntidadBE.CodAlterno, objEntidadBE.IPRegistro);
                                }
                            }
                            objEntidadBE.MsgError = MsgError.Value.ToString();
                        }
                    }
                }
                catch (Exception ex)
                { }



            }

            private void F_LGProductos_Update(LGProductosCE objEntidadBE)
            {
                try
                {
                    using (SqlConnection sql_conexion = new SqlConnection())
                    {
                        sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["ALMACEN1"].ConnectionString;
                        sql_conexion.Open();

                        using (SqlCommand sql_comando = new SqlCommand())
                        {
                            sql_comando.Connection = sql_conexion;
                            sql_comando.CommandType = CommandType.StoredProcedure;
                            sql_comando.CommandText = "pa_LGProductos_Update";

                            sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                            sql_comando.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;
                            sql_comando.Parameters.Add("@DscProducto", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProducto;
                            sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                            sql_comando.Parameters.Add("@CodUnidadCompra", SqlDbType.Int).Value = objEntidadBE.CodUnidadCompra;
                            sql_comando.Parameters.Add("@CodUnidadVenta", SqlDbType.Int).Value = objEntidadBE.CodUnidadVenta;
                            sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                            sql_comando.Parameters.Add("@Costo", SqlDbType.Decimal).Value = objEntidadBE.CostoProducto;
                            sql_comando.Parameters.Add("@CostoOriginal", SqlDbType.Decimal).Value = objEntidadBE.CostoOriginal;
                            sql_comando.Parameters.Add("@Factor", SqlDbType.Int).Value = objEntidadBE.Factor;
                            sql_comando.Parameters.Add("@CodigoProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoProducto;
                            sql_comando.Parameters.Add("@CodigoAlternativo", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoAlternativo;
                            sql_comando.Parameters.Add("@DscProductoIngles", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProductoIngles;
                            sql_comando.Parameters.Add("@PartidaArancelaria", SqlDbType.VarChar, 250).Value = objEntidadBE.PartidaArancelaria;
                            sql_comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = objEntidadBE.Precio;
                            sql_comando.Parameters.Add("@Precio2", SqlDbType.Decimal).Value = objEntidadBE.Precio2;
                            sql_comando.Parameters.Add("@Precio3", SqlDbType.Decimal).Value = objEntidadBE.Precio3;
                            sql_comando.Parameters.Add("@StockMaximo", SqlDbType.Decimal).Value = objEntidadBE.StockMaximo;
                            sql_comando.Parameters.Add("@StockMinimo", SqlDbType.Decimal).Value = objEntidadBE.StockMinimo;
                            sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                            sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 200).Value = objEntidadBE.Marca;
                            sql_comando.Parameters.Add("@Medida", SqlDbType.VarChar, 200).Value = objEntidadBE.Medida;
                            sql_comando.Parameters.Add("@Modelo", SqlDbType.VarChar, 200).Value = objEntidadBE.Modelo;
                            sql_comando.Parameters.Add("@Posicion", SqlDbType.VarChar, 200).Value = objEntidadBE.Posicion;
                            sql_comando.Parameters.Add("@CostoMarginable", SqlDbType.Decimal).Value = objEntidadBE.CostoMarginable;
                            sql_comando.Parameters.Add("@Flag", SqlDbType.Int).Value = objEntidadBE.Flag;
                            sql_comando.Parameters.Add("@Anio", SqlDbType.VarChar, 200).Value = objEntidadBE.Anio;
                            sql_comando.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 50).Value = objEntidadBE.Ubicacion;
                            sql_comando.Parameters.Add("@Imagen1", SqlDbType.VarChar, 50).Value = objEntidadBE.IdImagenProducto1;

                            SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                            MsgError.Direction = ParameterDirection.Output;
                            SqlParameter CodAlterno = sql_comando.Parameters.Add("@CodAlternoOut", SqlDbType.VarChar, 15);
                            CodAlterno.Direction = ParameterDirection.Output;

                            sql_comando.ExecuteNonQuery();

                            objEntidadBE.MsgError = MsgError.Value.ToString();
                            objEntidadBE.CodAlterno = CodAlterno.Value.ToString();
                            //pasa imagen desde el temporal
                            if (objEntidadBE.Imagenes.Count > 0)
                            {
                                ImagenesCD x = new ImagenesCD();
                                foreach (dynamic img in objEntidadBE.Imagenes)
                                {
                                    x.F_Imagenes_Insert_From_Temporal(int.Parse(img.ToString()), objEntidadBE.CodUsuario, objEntidadBE.CodAlterno, objEntidadBE.IPRegistro); ;
                                }
                                //ImagenesCD x = new ImagenesCD(); x.F_Imagenes_Insert_From_Temporal(objEntidadBE.IdImagenProducto1);
                            }

                        }
                    }
                }
                catch (Exception ex)
                {

                }



            }

            private void F_LGProductos_Eliminar(LGProductosCE objEntidadBE)
            {
                try
                {
                    using (SqlConnection sql_conexion = new SqlConnection())
                    {
                        sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["ALMACEN1"].ConnectionString;
                        sql_conexion.Open();

                        using (SqlCommand sql_comando = new SqlCommand())
                        {

                            sql_comando.Connection = sql_conexion;
                            sql_comando.CommandType = CommandType.StoredProcedure;
                            sql_comando.CommandText = "pa_LGProductos_Eliminar";

                            sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;

                            SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 250);
                            MsgError.Direction = ParameterDirection.Output;

                            sql_comando.ExecuteNonQuery();

                            objEntidadBE.MsgError = MsgError.Value.ToString();
                        }

                    }



                }
                catch (Exception ex)
                { }
            }


        }

        public DataTable F_LGProductos_UltimoPrecio(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_UltimaVentaArticulo";

                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;

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

        public DataTable F_LGProductos_VerPrecio_Moneda(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_VerPrecio_Moneda";

                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaRegistro;

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

        public LGProductosRelacionesCE F_LGProductosRelaciones_Insert(LGProductosRelacionesCE objEntidad)
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
                        sql_comando.CommandText = "[pa_LGProductosRelaciones_Insert]";

                        #region PARAMETROS
                        sql_comando.Parameters.Add("@CodAlternoPrincipal", SqlDbType.VarChar, 15).Value = objEntidad.CodAlternoPrincipal;
                        sql_comando.Parameters.Add("@CodAlternoRelacionado", SqlDbType.VarChar, 15).Value = objEntidad.CodAlternoRelacionado;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidad.CodUsuario;
                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 200);
                        MsgError.Direction = ParameterDirection.Output;
                        #endregion

                        sql_comando.ExecuteNonQuery();

                        objEntidad.MsgError = MsgError.Value.ToString();

                        return objEntidad;

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;

            }

            finally
            {

            }
        }

        public LGProductosRelacionesCE F_LGProductosRelaciones_Eliminar(LGProductosRelacionesCE objEntidad)
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
                        sql_comando.CommandText = "[pa_LGProductosRelaciones_Eliminar]";

                        #region PARAMETROS
                        sql_comando.Parameters.Add("@CodAlternoPrincipal", SqlDbType.VarChar).Value = objEntidad.CodAlternoPrincipal;
                        sql_comando.Parameters.Add("@CodAlternoRelacionado", SqlDbType.VarChar).Value = objEntidad.CodAlternoRelacionado;
                        //SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar);
                        //MsgError.Direction = ParameterDirection.Output;
                        #endregion

                        sql_comando.ExecuteNonQuery();
                        objEntidad.MsgError = "";

                        return objEntidad;

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;

            }

            finally
            {

            }
        }

        public DataTable F_LGProductosRelaciones_Listar(LGProductosRelacionesCE objEntidad)
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
                        sql_comando.CommandText = "[pa_LGProductosRelaciones_Listar]";

                        #region PARAMETROS
                        sql_comando.Parameters.Add("@CodAlternoPrincipal", SqlDbType.VarChar).Value = objEntidad.CodAlternoPrincipal;
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

        /// <summary>
        /// Actualizacion de Productos Asincrono Azure
        /// </summary>
        /// <param name="objEntidadBE"></param>
        public LGProductosCE Async_F_LGProductos_ActualizarProductos_Azure(LGProductosCE objEntidadBE)
        {
            csAsyn_LGProductos_actualizarProductos_Azure pAsync = new csAsyn_LGProductos_actualizarProductos_Azure();
            pAsync.Async_F_LGProductos_ActualizarProductos_Azure(objEntidadBE);
            return null;
        }
        private class csAsyn_LGProductos_actualizarProductos_Azure
        {

            /// <summary>
            /// proceso de Actualizacion productos
            /// </summary>
            /// <param name="objEntidadBE"></param>
            public void Async_F_LGProductos_ActualizarProductos_Azure(LGProductosCE objEntidadBE)
            {
                System.Threading.Thread thread = new System.Threading.Thread(() => F_LGProductos_ActualizarStocks_Azure(objEntidadBE));
                thread.Start();
            }
            private void F_LGProductos_ActualizarStocks_Azure(LGProductosCE objEntidadBE)
            {
                //---------------------------------------------
                //1 - Lista los productos a actualizar en azure
                //---------------------------------------------
                DataTable dt_Productos = pa_LGProductos_Listar_Simple(objEntidadBE.CodProducto);

                string Etiqueta = "0"; string MsgPers = "";
                if (dt_Productos.Rows.Count > 0)
                {
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
                            catch (Exception excon)
                            {
                                Etiqueta = "1"; MsgPers = "Conectandose: " + ConfigurationManager.ConnectionStrings["AZURE"].ConnectionString;
                                F_LGProductos_Logs_Sincronizaciones_Azure_insert("LGProductosCD.F_LGProductos_ActualizarStocks_Azure Etiqueta:" + Etiqueta + " " + MsgPers, "", excon.Message.ToString());
                            }

                            //------------------------------------------------------------------
                            //2 - Actualización directamente en Azure  (Almacen Local --> Azure)
                            //------------------------------------------------------------------
                            DataTable dta_ProductosAzure = null;
                            if (Conectado == true)
                                try
                                {
                                    using (SqlCommand sql_comando = new SqlCommand())
                                    {

                                        sql_comando.Connection = sql_conexion;
                                        sql_comando.CommandType = CommandType.StoredProcedure;
                                        sql_comando.CommandText = "pa_LGProductos_ActualizarProductos";

                                        SqlParameter myDataTable = sql_comando.Parameters.AddWithValue("@sProductos", dt_Productos);
                                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                                        MsgError.Direction = ParameterDirection.Output;

                                        dta_ProductosAzure = new DataTable();
                                        dta_ProductosAzure.Load(sql_comando.ExecuteReader());


                                        if (MsgError.Value.ToString() != "")
                                        {
                                            Etiqueta = "2"; MsgPers = "Ejecutando pa_LGProductos_ActualizarProductos en Azure";
                                            F_LGProductos_Logs_Sincronizaciones_Azure_insert("LGProductosCD.F_LGProductos_ActualizarStocks_Azure Etiqueta:" + Etiqueta + " " + MsgPers, "", MsgError.Value.ToString());
                                        }

                                        //----------------------------------------------------------------
                                        //3 - Actualización en Local desde Azure (AZURE --> Almacen Local)
                                        //----------------------------------------------------------------
                                        if (dta_ProductosAzure.Rows.Count > 0)
                                            F_LGProductos_ActualizarProductos_Azure_a_Local(dta_ProductosAzure);
                                    }
                                }
                                catch (Exception exx)
                                {
                                    Etiqueta = "3"; MsgPers = "";
                                    F_LGProductos_Logs_Sincronizaciones_Azure_insert("LGProductosCD.F_LGProductos_ActualizarStocks_Azure Etiqueta:" + Etiqueta + " " + MsgPers, "", exx.Message.ToString());
                                }
                        }
                    }
                    catch (Exception ex)
                    {
                        Etiqueta = "4"; MsgPers = "";
                        F_LGProductos_Logs_Sincronizaciones_Azure_insert("LGProductosCD.F_LGProductos_ActualizarStocks_Azure Etiqueta:" + Etiqueta + " " + MsgPers, "", ex.Message.ToString());
                    }
                }
            }

            /// <summary>
            /// 1 Lista DT que se hace del producto o los productos que se van a actualizar en el azure
            /// </summary>
            /// <param name="CodProducto"></param>
            /// <returns></returns>
            private DataTable pa_LGProductos_Listar_Simple(int CodProducto)
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
                            sql_comando.CommandText = "pa_LGProductos_Listar_Simple";

                            if (CodProducto > 0)
                                sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = CodProducto;

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
            private void F_LGProductos_ActualizarProductos_Azure_a_Local(DataTable dt_ProductosAzure)
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
                            sql_comando.CommandText = "pa_LGProductos_ActualizarProductos_Azure";
                            sql_comando.CommandTimeout = 50000;

                            SqlParameter myDataTable = sql_comando.Parameters.AddWithValue("@sProductos", dt_ProductosAzure);
                            SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                            MsgError.Direction = ParameterDirection.Output;

                            sql_comando.ExecuteNonQuery();

                            if (MsgError.Value.ToString() != "")
                            {
                                Etiqueta = "5"; MsgPers = "ejecutando F_LGProductos_ActualizarProductos_Azure_a_Local en local";
                                F_LGProductos_Logs_Sincronizaciones_Azure_insert("LGProductosCD.F_LGProductos_ActualizarProductos_Azure_a_Local Etiqueta:" + Etiqueta + " " + MsgPers, "", MsgError.Value.ToString());
                            }



                        }
                    }
                }
                catch (Exception ex)
                {
                    Etiqueta = "6"; MsgPers = "";
                    F_LGProductos_Logs_Sincronizaciones_Azure_insert("LGProductosCD.F_LGProductos_ActualizarProductos_Azure_a_Local Etiqueta:" + Etiqueta + " " + MsgPers, "", ex.Message.ToString());
                }
            }
            private void F_LGProductos_Logs_Sincronizaciones_Azure_insert(string Procedimiento, string NroError, string MsgError)
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
                            sql_comando.CommandText = "pa_LGProductos_Logs_Sincronizaciones_Azure_insert";

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

        public LGProductosCE F_ProductoModelo_Insertar(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_ProductoModelo_INSERTAR";

                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                        sql_comando.Parameters.Add("@CodModeloVehiculo", SqlDbType.Int).Value = objEntidadBE.CodModeloVehiculo;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@Año", SqlDbType.VarChar, 250).Value = objEntidadBE.Anio;
                        sql_comando.Parameters.Add("@Motor", SqlDbType.VarChar, 250).Value = objEntidadBE.Motor;
                        sql_comando.Parameters.Add("@CajaCambio", SqlDbType.VarChar, 1000).Value = objEntidadBE.CajaCambio;
                        sql_comando.Parameters.Add("@Transmision", SqlDbType.VarChar, 1000).Value = objEntidadBE.Transmision;
                        sql_comando.Parameters.Add("@Filtro", SqlDbType.VarChar, 1000).Value = objEntidadBE.Filtro;
                        sql_comando.Parameters.Add("@IPRegistro", SqlDbType.VarChar, 50).Value = objEntidadBE.IPRegistro;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objEntidadBE;
        }

        public LGProductosCE F_ProductoModelo_Actualizar(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_ProductoModelo_ACTUALIZAR";

                        sql_comando.Parameters.Add("@CodProductoModelo", SqlDbType.Int).Value = objEntidadBE.CodProductoModelo;
                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                        sql_comando.Parameters.Add("@CodModeloVehiculo", SqlDbType.Int).Value = objEntidadBE.CodModeloVehiculo;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@Año", SqlDbType.VarChar, 250).Value = objEntidadBE.Anio;
                        sql_comando.Parameters.Add("@Motor", SqlDbType.VarChar, 250).Value = objEntidadBE.Motor;
                        sql_comando.Parameters.Add("@CajaCambio", SqlDbType.VarChar, 1000).Value = objEntidadBE.CajaCambio;
                        sql_comando.Parameters.Add("@Transmision", SqlDbType.VarChar, 1000).Value = objEntidadBE.Transmision;
                        sql_comando.Parameters.Add("@Filtro", SqlDbType.VarChar, 1000).Value = objEntidadBE.Filtro;
                        sql_comando.Parameters.Add("@IPModificacion", SqlDbType.VarChar, 50).Value = objEntidadBE.IPModificacion;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objEntidadBE;
        }

        public LGProductosCE F_ProductoModelo_Eliminar(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_ProductoModelo_ELIMINAR";

                        sql_comando.Parameters.Add("@CodProductoModelo", SqlDbType.Int).Value = objEntidadBE.CodProductoModelo;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objEntidadBE;
        }

        public DataTable F_ProductoModelo_Listado(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_ProductoModelo_LISTADO";

                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;

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

        public DataTable F_LGProductos_ListarServicios(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_ListarServicios";

                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = objEntidadBE.DscProducto;
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

        public LGProductosCE F_LGProductos_Servicios_Insert(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_Servicios_Insert";

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodigoProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoProducto;
                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 8000).Value = objEntidadBE.DscProducto;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 150);
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

        public LGProductosCE F_LGProductos_Servicios_Update(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_Servicios_Update";

                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                        sql_comando.Parameters.Add("@CodigoProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoProducto;
                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 8000).Value = objEntidadBE.DscProducto;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 150);
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

        public LGProductosCE F_LGProductos_Eliminar_Servicios(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_Eliminar_Servicios";

                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 250);
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

        public LGProductosCE F_LGProductos_ActualizarListaPrecio(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_ActualizarListaPrecio";

                        sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodSede", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@FechaVigencia", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaVigencia;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 150);
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

        public LGProductosCE F_LGProductos_NuevaListaPrecio()
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
                        sql_comando.CommandText = "PA_LGProductos_NuevaListaPrecio";

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 150);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        LGProductosCE objEntidadBE = new LGProductosCE();

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

        public DataTable F_LGProductos_ListarProductosPrecios_Reporte(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_ListarProductosPrecios_Reporte";

                        if (!objEntidadBE.FechaVigencia.ToString("yyyyMMdd").Equals("19900101"))
                            sql_comando.Parameters.Add("@FechaVigencia", SqlDbType.Int).Value = objEntidadBE.FechaVigencia.ToString("yyyyMMdd");

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

        public DataTable F_LGProductos_ListarProductosPrecios_Reeim(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_ListarProductosPrecios";

                        if (objEntidadBE.IdFamilia > 0)
                            sql_comando.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;

                        if (objEntidadBE.DscProducto != "")
                            sql_comando.Parameters.Add("@DscProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.DscProducto;

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        if (objEntidadBE.chkMarca > 0)
                            sql_comando.Parameters.Add("@CodMarca", SqlDbType.Int).Value = objEntidadBE.CodMarca;

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

        public DataTable F_LGProductos_ListarProductosPrecios_Reeim_Excel(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_ListarProductosPrecios_Excel";

                        if (objEntidadBE.IdFamilia > 0)
                            sql_comando.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;

                        if (objEntidadBE.DscProducto != "")
                            sql_comando.Parameters.Add("@DscProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.DscProducto;

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        if (objEntidadBE.chkMarca > 0)
                            sql_comando.Parameters.Add("@CodMarca", SqlDbType.Int).Value = objEntidadBE.CodMarca;

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

        public DataTable pa_LGStockAlmacen_Inventario_StockActual_Povis_Excel(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGStockAlmacen_Inventario_StockActual_Povis_Excel";

                        if (objEntidadBE.IdFamilia > 0)
                            sql_comando.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;

                        if (objEntidadBE.DscProducto != "")
                            sql_comando.Parameters.Add("@DscProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.DscProducto;

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        if (objEntidadBE.chkMarca > 0)
                            sql_comando.Parameters.Add("@CodMarca", SqlDbType.Int).Value = objEntidadBE.CodMarca;

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

        public DataTable pa_LGStockAlmacen_Inventario_StockActual_Salcedo_Excel(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_LGSTOCKALMACEN_STOCK_TODOS_ALMACENES";

                        if (objEntidadBE.IdFamilia > 0)
                            sql_comando.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;

                        sql_comando.Parameters.Add("@CodTipo", SqlDbType.Int).Value = objEntidadBE.CodTipo;

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

        public DataTable F_LGProductos_Inventario_StockActual_Roman(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGStockAlmacen_Inventario_StockActual";

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

                        if (objEntidadBE.CodFamilia != "0")
                            sql_comando.Parameters.Add("@CodFamilia", SqlDbType.VarChar, 3).Value = objEntidadBE.CodFamilia;
                        if (objEntidadBE.Marca != "0")
                            sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;
                        if (objEntidadBE.CodProcedencia != 0)
                            sql_comando.Parameters.Add("@Procedencia", SqlDbType.VarChar, 50).Value = objEntidadBE.CodProcedencia;

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

        public DataTable F_Inventario_Unidades_Fisicas(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Inventario_Unidades_Fisicas";

                        sql_comando.Parameters.Add("@TipoReporte", SqlDbType.Int).Value = objEntidadBE.TipoReporte;
                        sql_comando.Parameters.Add("@Procedencia", SqlDbType.Int).Value = objEntidadBE.CodProcedencia;
                        sql_comando.Parameters.Add("@xmlAlmacenes", SqlDbType.VarChar, 10000).Value = objEntidadBE.XmlAlmacen;
                        sql_comando.Parameters.Add("@xmlFamilias", SqlDbType.VarChar, 10000).Value = objEntidadBE.xmlFamilias;
                        sql_comando.Parameters.Add("@xmlLineas", SqlDbType.VarChar, 10000).Value = objEntidadBE.xmlLineas;
                        sql_comando.Parameters.Add("@xmlMarcas", SqlDbType.VarChar, 10000).Value = objEntidadBE.xmlMarcas;

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

        public DataTable F_Inventario_Valorizado(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Inventario_Valorizado";

                        sql_comando.Parameters.Add("@TipoReporte", SqlDbType.Int).Value = objEntidadBE.TipoReporte;
                        sql_comando.Parameters.Add("@Procedencia", SqlDbType.Int).Value = objEntidadBE.CodProcedencia;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@xmlAlmacenes", SqlDbType.VarChar, 10000).Value = objEntidadBE.XmlAlmacen;
                        sql_comando.Parameters.Add("@xmlFamilias", SqlDbType.VarChar, 10000).Value = objEntidadBE.xmlFamilias;
                        sql_comando.Parameters.Add("@xmlLineas", SqlDbType.VarChar, 10000).Value = objEntidadBE.xmlLineas;
                        sql_comando.Parameters.Add("@xmlMarcas", SqlDbType.VarChar, 10000).Value = objEntidadBE.xmlMarcas;

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

        public DataTable F_Marcas_Listar_Roman(string codFamilia)
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
                        sql_comando.CommandText = "pa_Marcas_listar_Roman";
                        sql_comando.Parameters.Add("@codfamilia", SqlDbType.VarChar).Value = codFamilia;

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

        public DataTable F_LGProductos_HistorialCostos(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_LogsCostos";

                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;

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
        
        public DataTable F_LGProductos_HistorialPrecios(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_LogsPrecios";

                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;

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

        public DataTable F_LGProductos_Auditoria_Listar(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_Auditoria_Listar";

                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;

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

        public DataTable F_LGProductos_ListarProductosPrecios_Reporte_KARINA(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_ListarProductosPrecios_Reporte";

                        if (objEntidadBE.IdFamilia > 0)
                            sql_comando.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;

                        if (objEntidadBE.DscProducto != "")
                            sql_comando.Parameters.Add("@DscProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.DscProducto;

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
        
        public DataTable F_LGProductos_Presentaciones_Listar(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductosPresentaciones_Listar";

                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;

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
        
        public LGProductosPresentacionesCE F_LGProductosPresentaciones_Insert(LGProductosPresentacionesCE objEntidad)
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
                        sql_comando.CommandText = "[pa_LGProductosPresentaciones_Insert]";

                        #region PARAMETROS

                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidad.CodProducto;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidad.CodEstado;
                        sql_comando.Parameters.Add("@CodUnidadMedida", SqlDbType.Int).Value = objEntidad.CodUnidadMedida;
                        sql_comando.Parameters.Add("@Factor", SqlDbType.Decimal).Value = objEntidad.Factor;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidad.CodMoneda;
                        sql_comando.Parameters.Add("@Costo", SqlDbType.Decimal).Value = objEntidad.Costo;
                        sql_comando.Parameters.Add("@Precio1", SqlDbType.Decimal).Value = objEntidad.Precio1;
                        sql_comando.Parameters.Add("@Precio2", SqlDbType.Decimal).Value = objEntidad.Precio2;
                        sql_comando.Parameters.Add("@Precio3", SqlDbType.Decimal).Value = objEntidad.Precio3;
                        sql_comando.Parameters.Add("@Precio4", SqlDbType.Decimal).Value = objEntidad.Precio4;
                        sql_comando.Parameters.Add("@Precio5", SqlDbType.Decimal).Value = objEntidad.Precio5;
                        sql_comando.Parameters.Add("@Precio6", SqlDbType.Decimal).Value = objEntidad.Precio6;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidad.CodUsuario;


                        SqlParameter CodProductoPresentacion = sql_comando.Parameters.Add("@CodProductoPresentacion", SqlDbType.Int);
                        CodProductoPresentacion.Direction = ParameterDirection.Output;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 200);
                        MsgError.Direction = ParameterDirection.Output;
                        #endregion

                        sql_comando.ExecuteNonQuery();

                        objEntidad.CodProductoPresentacion = Convert.ToInt32(CodProductoPresentacion.Value.ToString());
                        objEntidad.MsgError = MsgError.Value.ToString();

                        return objEntidad;

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;

            }

            finally
            {

            }
        }

        public LGProductosPresentacionesCE F_LGProductosPresentaciones_Update(LGProductosPresentacionesCE objEntidad)
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
                        sql_comando.CommandText = "[pa_LGProductosPresentaciones_Update]";

                        #region PARAMETROS

                        sql_comando.Parameters.Add("@CodProductoPresentacion", SqlDbType.Int).Value = objEntidad.CodProductoPresentacion;
                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidad.CodProducto;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidad.CodEstado;
                        sql_comando.Parameters.Add("@CodUnidadMedida", SqlDbType.Int).Value = objEntidad.CodUnidadMedida;
                        sql_comando.Parameters.Add("@Factor", SqlDbType.Decimal).Value = objEntidad.Factor;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidad.CodMoneda;
                        sql_comando.Parameters.Add("@Costo", SqlDbType.Decimal).Value = objEntidad.Costo;
                        sql_comando.Parameters.Add("@Precio1", SqlDbType.Decimal).Value = objEntidad.Precio1;
                        sql_comando.Parameters.Add("@Precio2", SqlDbType.Decimal).Value = objEntidad.Precio2;
                        sql_comando.Parameters.Add("@Precio3", SqlDbType.Decimal).Value = objEntidad.Precio3;
                        sql_comando.Parameters.Add("@Precio4", SqlDbType.Decimal).Value = objEntidad.Precio4;
                        sql_comando.Parameters.Add("@Precio5", SqlDbType.Decimal).Value = objEntidad.Precio5;
                        sql_comando.Parameters.Add("@Precio6", SqlDbType.Decimal).Value = objEntidad.Precio6;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidad.CodUsuario;


   
                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 200);
                        MsgError.Direction = ParameterDirection.Output;
                        #endregion

                        sql_comando.ExecuteNonQuery();

                        objEntidad.MsgError = MsgError.Value.ToString();

                        return objEntidad;

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;

            }

            finally
            {

            }
        }

        public LGProductosPresentacionesCE F_LGProductosPresentaciones_Delete(LGProductosPresentacionesCE objEntidad)
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
                        sql_comando.CommandText = "[PA_LGProductosPresentaciones_ELIMINAR]";

                        #region PARAMETROS

                        sql_comando.Parameters.Add("@CodProductoPresentacion", SqlDbType.Int).Value = objEntidad.CodProductoPresentacion;
                     
                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 200);
                        MsgError.Direction = ParameterDirection.Output;
                        #endregion

                        sql_comando.ExecuteNonQuery();

                        objEntidad.MsgError = MsgError.Value.ToString();

                        return objEntidad;

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;

            }

            finally
            {

            }
        }

        public DataTable F_LGProductosPresentaciones_Listar_UM_Ventas(int CodProducto, int CodMoneda, decimal TC)
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
                        sql_comando.CommandText = "pa_LGProductosPresentaciones_Listar_UM_Ventas";

                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = CodProducto;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = CodMoneda;
                        sql_comando.Parameters.Add("@TC", SqlDbType.Decimal).Value = TC;

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
        
        public DataTable F_LGProductos_Listar_App(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_Listar_App";

                        if (objEntidadBE.IdFamilia > 0)
                            sql_comando.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;

                        if (objEntidadBE.DscProducto != "")
                            sql_comando.Parameters.Add("@DscProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.DscProducto;

                        if (objEntidadBE.IdFamilia != -1)
                            sql_comando.Parameters.Add("@SeVendeEnApp", SqlDbType.Int).Value = objEntidadBE.SeVendeEnApp;

                        sql_comando.Parameters.Add("@SoloConImagenes", SqlDbType.Int).Value = objEntidadBE.SoloConImagenes;
                        sql_comando.Parameters.Add("@SoloYaEnviados", SqlDbType.Int).Value = objEntidadBE.SoloYaEnviados;

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
        
        public LGProductosCE F_LGProductos_Update_App(LGProductosCE objEntidadBE)
        {
            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {
                        sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;

                    bool Conectado = false;
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
                                sql_comando.CommandText = "pa_LGProductos_update_app";

                                sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                                sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                                sql_comando.Parameters.Add("@CodigoApp", SqlDbType.VarChar, 100).Value = objEntidadBE.CodigoApp;
                               
                                sql_comando.ExecuteNonQuery();
                            }

                        }
                        catch (Exception exx)
                        {

                        }

                }

                return objEntidadBE;

            }
            catch (Exception ex)
            {

                throw ex;

            }



        }
        
        public DataTable F_LGProductos_Listar_Imagenes(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_Listar_Imagenes";

                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;

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

        public DataTable F_MarcaProducto_listar(int CodEstado)
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
                        sql_comando.CommandText = "[pa_MarcaProducto_Listar]";


                        if (CodEstado != 0)
                            sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = CodEstado;


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

        public DataTable F_ListarMarca_AutoComplete(LGProductosCE objEntidad)
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
                        sql_comando.CommandText = "pa_LGProductos_ListarMarca";


                        sql_comando.Parameters.Add("@DescripcionMarca", SqlDbType.VarChar, 150).Value = objEntidad.DescripcionMarcaProducto;


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
        
        public DataTable F_PRODUCTO_OBSERVACION(LGProductosCE objEntidad)
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
                        sql_comando.CommandText = "pa_Producto_Observacion";

                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidad.CodProducto;

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

        public DataTable P_Permiso_Mayorista(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Permisos";
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

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

        public LGProductosCE F_LGProductos_Insert_Salcedo(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    if (Tipo == "")
                        sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    else
                        sql_conexion.ConnectionString = (new SqlConnectionStringBuilder() { DataSource = DBHost, InitialCatalog = DBDataBase, UserID = DBUser, Password = DBPass }).ConnectionString;

                    bool Conectado = false;
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
                                sql_comando.CommandText = "pa_LGProductos_Insert";

                                sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                                sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                                sql_comando.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;
                                sql_comando.Parameters.Add("@DscProducto", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProducto;
                                sql_comando.Parameters.Add("@DscProductoIngles", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProductoIngles;
                                sql_comando.Parameters.Add("@PartidaArancelaria", SqlDbType.VarChar, 250).Value = objEntidadBE.PartidaArancelaria;
                                sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                                sql_comando.Parameters.Add("@CodUnidadCompra", SqlDbType.Int).Value = objEntidadBE.CodUnidadCompra;
                                sql_comando.Parameters.Add("@CodUnidadVenta", SqlDbType.Int).Value = objEntidadBE.CodUnidadVenta;
                                sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                                sql_comando.Parameters.Add("@CostoSoles", SqlDbType.Decimal).Value = objEntidadBE.CostoSoles;
                                sql_comando.Parameters.Add("@CostoDolares", SqlDbType.Decimal).Value = objEntidadBE.CostoDolares;
                                sql_comando.Parameters.Add("@Factor", SqlDbType.Int).Value = objEntidadBE.Factor;
                                sql_comando.Parameters.Add("@CodigoInterno", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoInterno;
                                sql_comando.Parameters.Add("@CodigoProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoProducto;
                                sql_comando.Parameters.Add("@CodigoAlternativo", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoAlternativo;
                                sql_comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = objEntidadBE.Precio;
                                sql_comando.Parameters.Add("@Precio2", SqlDbType.Decimal).Value = objEntidadBE.Precio2;
                                sql_comando.Parameters.Add("@Precio3", SqlDbType.Decimal).Value = objEntidadBE.Precio3;
                                sql_comando.Parameters.Add("@PrecioDolares", SqlDbType.Decimal).Value = objEntidadBE.PrecioDolares;
                                sql_comando.Parameters.Add("@Precio2Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio2Dolares;
                                sql_comando.Parameters.Add("@Precio3Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio3Dolares;
                                sql_comando.Parameters.Add("@StockMaximo", SqlDbType.Decimal).Value = objEntidadBE.StockMaximo;
                                sql_comando.Parameters.Add("@StockMinimo", SqlDbType.Decimal).Value = objEntidadBE.StockMinimo;
                                sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                                sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 200).Value = objEntidadBE.Marca;
                                sql_comando.Parameters.Add("@Medida", SqlDbType.VarChar, 200).Value = objEntidadBE.Medida;
                                sql_comando.Parameters.Add("@Modelo", SqlDbType.VarChar, 200).Value = objEntidadBE.Modelo;
                                sql_comando.Parameters.Add("@Posicion", SqlDbType.VarChar, 200).Value = objEntidadBE.Posicion;
                                sql_comando.Parameters.Add("@Anio", SqlDbType.VarChar, 200).Value = objEntidadBE.Anio;
                                sql_comando.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 200).Value = objEntidadBE.Ubicacion;
                                sql_comando.Parameters.Add("@Img1", SqlDbType.Int).Value = objEntidadBE.IdImagenProducto1;
                                sql_comando.Parameters.Add("@M1", SqlDbType.Decimal).Value = objEntidadBE.M1;
                                sql_comando.Parameters.Add("@M2", SqlDbType.Decimal).Value = objEntidadBE.M2;
                                sql_comando.Parameters.Add("@Comentario", SqlDbType.VarChar, 8000).Value = objEntidadBE.Comentario;
                                sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                                sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                                sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 1000).Value = objEntidadBE.Observacion;
                                sql_comando.Parameters.Add("@CodLinea", SqlDbType.Int).Value = objEntidadBE.CodLinea;
                                sql_comando.Parameters.Add("@CodProcedencia", SqlDbType.Int).Value = objEntidadBE.CodProcedencia;
                                sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidadBE.CodCategoria;
                                sql_comando.Parameters.Add("@Motor", SqlDbType.VarChar, 1000).Value = objEntidadBE.Motor;
                                sql_comando.Parameters.Add("@Chasis", SqlDbType.VarChar, 1000).Value = objEntidadBE.Chasis;
                                sql_comando.Parameters.Add("@DescComp", SqlDbType.VarChar, 1000).Value = objEntidadBE.DescComp;

                                SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                                MsgError.Direction = ParameterDirection.Output;
                                SqlParameter CodAlterno = sql_comando.Parameters.Add("@CodAlternoOut", SqlDbType.VarChar, 15);
                                CodAlterno.Direction = ParameterDirection.Output;

                                sql_comando.ExecuteNonQuery();

                                try
                                {
                                    //pasa imagen desde el temporal
                                    if (objEntidadBE.Imagenes.Count > 0)
                                    {
                                        objEntidadBE.CodAlterno = CodAlterno.Value.ToString();
                                        ImagenesCD x = new ImagenesCD();
                                        foreach (dynamic img in objEntidadBE.Imagenes)
                                        {
                                            try
                                            {
                                                x.F_Imagenes_Insert_From_Temporal(int.Parse(img.ToString()), objEntidadBE.CodUsuario, objEntidadBE.CodAlterno, objEntidadBE.IPRegistro);
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }
                                    }
                                }
                                catch (Exception exx)
                                {

                                }


                                objEntidadBE.MsgError = MsgError.Value.ToString();



                            }
                        }
                        catch (Exception exx)
                        {
                            objEntidadBE.MsgError = exx.ToString();
                        }


                }



            }
            catch (Exception ex)
            {

                throw ex;

            }
            return objEntidadBE;


        }

        public LGProductosCE F_LGProductos_Update_Salcedo(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    if (Tipo == "")
                        sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    else
                        sql_conexion.ConnectionString = (new SqlConnectionStringBuilder() { DataSource = DBHost, InitialCatalog = DBDataBase, UserID = DBUser, Password = DBPass }).ConnectionString;
                    bool Conectado = false;
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
                                sql_comando.CommandText = "pa_LGProductos_Update";

                                sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                                sql_comando.Parameters.Add("@IdFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;
                                sql_comando.Parameters.Add("@DscProducto", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProducto;
                                sql_comando.Parameters.Add("@DscProductoIngles", SqlDbType.VarChar, 250).Value = objEntidadBE.DscProductoIngles;
                                sql_comando.Parameters.Add("@PartidaArancelaria", SqlDbType.VarChar, 250).Value = objEntidadBE.PartidaArancelaria;
                                sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                                sql_comando.Parameters.Add("@CodUnidadCompra", SqlDbType.Int).Value = objEntidadBE.CodUnidadCompra;
                                sql_comando.Parameters.Add("@CodUnidadVenta", SqlDbType.Int).Value = objEntidadBE.CodUnidadVenta;
                                sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                                sql_comando.Parameters.Add("@CostoSoles", SqlDbType.Decimal).Value = objEntidadBE.CostoSoles;
                                sql_comando.Parameters.Add("@CostoDolares", SqlDbType.Decimal).Value = objEntidadBE.CostoDolares;
                                sql_comando.Parameters.Add("@Factor", SqlDbType.Int).Value = objEntidadBE.Factor;
                                sql_comando.Parameters.Add("@CodigoInterno", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoInterno;
                                sql_comando.Parameters.Add("@CodigoProducto", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoProducto;
                                sql_comando.Parameters.Add("@CodigoAlternativo", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoAlternativo;
                                sql_comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = objEntidadBE.Precio;
                                sql_comando.Parameters.Add("@Precio2", SqlDbType.Decimal).Value = objEntidadBE.Precio2;
                                sql_comando.Parameters.Add("@Precio3", SqlDbType.Decimal).Value = objEntidadBE.Precio3;
                                sql_comando.Parameters.Add("@PrecioDolares", SqlDbType.Decimal).Value = objEntidadBE.PrecioDolares;
                                sql_comando.Parameters.Add("@Precio2Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio2Dolares;
                                sql_comando.Parameters.Add("@Precio3Dolares", SqlDbType.Decimal).Value = objEntidadBE.Precio3Dolares;
                                sql_comando.Parameters.Add("@StockMaximo", SqlDbType.Decimal).Value = objEntidadBE.StockMaximo;
                                sql_comando.Parameters.Add("@StockMinimo", SqlDbType.Decimal).Value = objEntidadBE.StockMinimo;
                                sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                                sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 200).Value = objEntidadBE.Marca;
                                sql_comando.Parameters.Add("@Medida", SqlDbType.VarChar, 200).Value = objEntidadBE.Medida;
                                sql_comando.Parameters.Add("@Modelo", SqlDbType.VarChar, 200).Value = objEntidadBE.Modelo;
                                sql_comando.Parameters.Add("@Posicion", SqlDbType.VarChar, 200).Value = objEntidadBE.Posicion;
                                sql_comando.Parameters.Add("@Anio", SqlDbType.VarChar, 200).Value = objEntidadBE.Anio;
                                sql_comando.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 200).Value = objEntidadBE.Ubicacion;
                                sql_comando.Parameters.Add("@Img1", SqlDbType.Int).Value = objEntidadBE.IdImagenProducto1;
                                sql_comando.Parameters.Add("@M1", SqlDbType.Decimal).Value = objEntidadBE.M1;
                                sql_comando.Parameters.Add("@M2", SqlDbType.Decimal).Value = objEntidadBE.M2;
                                sql_comando.Parameters.Add("@Comentario", SqlDbType.VarChar, 8000).Value = objEntidadBE.Comentario;
                                sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                                sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                                sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 1000).Value = objEntidadBE.Observacion;
                                sql_comando.Parameters.Add("@CodLinea", SqlDbType.Int).Value = objEntidadBE.CodLinea;
                                sql_comando.Parameters.Add("@CodProcedencia", SqlDbType.Int).Value = objEntidadBE.CodProcedencia;
                                sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidadBE.CodCategoria;
                                sql_comando.Parameters.Add("@Motor", SqlDbType.VarChar, 1000).Value = objEntidadBE.Motor;
                                sql_comando.Parameters.Add("@Chasis", SqlDbType.VarChar, 1000).Value = objEntidadBE.Chasis;
                                sql_comando.Parameters.Add("@DescComp", SqlDbType.VarChar, 1000).Value = objEntidadBE.DescComp;

                                SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                                MsgError.Direction = ParameterDirection.Output;
                                SqlParameter CodAlterno = sql_comando.Parameters.Add("@CodAlternoOut", SqlDbType.VarChar, 15);
                                CodAlterno.Direction = ParameterDirection.Output;

                                sql_comando.ExecuteNonQuery();

                                objEntidadBE.MsgError = MsgError.Value.ToString();
                                objEntidadBE.CodAlterno = CodAlterno.Value.ToString();
                                try
                                {
                                    //pasa imagen desde el temporal
                                    if (objEntidadBE.Imagenes.Count > 0)
                                    {
                                        int codusuariomod = objEntidadBE.CodUsuarioMod; if (codusuariomod == 0) codusuariomod = objEntidadBE.CodUsuario;
                                        ImagenesCD x = new ImagenesCD();
                                        foreach (dynamic img in objEntidadBE.Imagenes)
                                        {
                                            try
                                            {
                                                x.F_Imagenes_Insert_From_Temporal(int.Parse(img.ToString()), codusuariomod, objEntidadBE.CodAlterno, objEntidadBE.IPRegistro);
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }

                                    }
                                }
                                catch (Exception ex)
                                {

                                }



                            }

                        }
                        catch (Exception exx)
                        {

                        }

                }

                return objEntidadBE;

            }
            catch (Exception ex)
            {

                throw ex;

            }



        }
        
        public DataTable F_LGProductos_HistorialMargenes(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_HistorialMargen";

                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;

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

        public DataTable F_LGProductos_HistorialCosto(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_HistorialCosto";

                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;

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

        public DataTable F_LGProductos_Select_Ventas_Fundicion(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_Select_Ventas";

                        sql_comando.Parameters.Add("@DscArticulo", SqlDbType.VarChar, 150).Value = objEntidadBE.DscProducto;
                        sql_comando.Parameters.Add("@DscArticulo2", SqlDbType.VarChar, 150).Value = objEntidadBE.DscProducto2;
                        sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@FlagProductosConStock", SqlDbType.Int).Value = objEntidadBE.FlagProductosConStock;


                        if (objEntidadBE.CodCtaCte > 0)
                            sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;


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

        public object F_LGProductos_Select_Ventas_Salcedo(LGProductosCE objEntidad)
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
                        sql_comando.CommandText = "pa_LGProductos_Select_Ventas";

                        sql_comando.Parameters.Add("@DscArticulo", SqlDbType.VarChar, 150).Value = objEntidad.DscProducto;
                        sql_comando.Parameters.Add("@DscArticulo2", SqlDbType.VarChar, 150).Value = objEntidad.DscProducto2;
                        sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidad.CodTipoProducto;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidad.CodAlmacen;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidad.CodMoneda;
                        sql_comando.Parameters.Add("@FlagProductosConStock", SqlDbType.Int).Value = objEntidad.FlagProductosConStock;
                        sql_comando.Parameters.Add("@FlagCompra", SqlDbType.Int).Value = objEntidad.FlagCompra;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidad.CodCtaCte;

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


        public DataTable F_LGProductos_Select_MantenimientoPlan(LGProductosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_Select_MantenimientoPlan";

                        sql_comando.Parameters.Add("@DscArticulo", SqlDbType.VarChar, 150).Value = objEntidadBE.DscProducto;
                        sql_comando.Parameters.Add("@DscArticulo2", SqlDbType.VarChar, 150).Value = objEntidadBE.DscProducto2;
                        sql_comando.Parameters.Add("@CodTipoProducto", SqlDbType.Int).Value = objEntidadBE.CodTipoProducto;
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


    }
}
