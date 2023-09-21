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
   public class NotaIngresoSalidaDetCD
    {
       public DataTable F_NotaIngresoSalidaDet_Select(NotaIngresoSalidaDetCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_NotaIngresoSalidaDet_Select";

                        sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;

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

       public DataTable F_NotaIngresoSalidaDet_Select_GuiaExterna(NotaIngresoSalidaDetCE objEntidadBE)
       {

           DataTable dta_consulta = null;

           try
           {

               using (SqlConnection sql_conexion = new SqlConnection())
               {

                   sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings[objEntidadBE.ConexionNombre].ConnectionString;
                   sql_conexion.Open();

                   using (SqlCommand sql_comando = new SqlCommand())
                   {

                       sql_comando.Connection = sql_conexion;
                       sql_comando.CommandType = CommandType.StoredProcedure;
                       sql_comando.CommandText = "[pa_NotaIngresoSalidaDet_Select_EXTERNO]";

                       sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                       sql_comando.Parameters.Add("@CodTipoDocSust", SqlDbType.Int).Value = objEntidadBE.CodTipoDocSust;
                       sql_comando.Parameters.Add("@SerieDocSust", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDocSust;
                       sql_comando.Parameters.Add("@NumeroDocSust", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDocSust;

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

       public DataTable F_TrasladosDet_Select_GuiaExterna(NotaIngresoSalidaDetCE objEntidadBE)
       {

           DataTable dta_consulta = null;

           try
           {

               using (SqlConnection sql_conexion = new SqlConnection())
               {

                   sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings[objEntidadBE.ConexionNombre].ConnectionString;
                   sql_conexion.Open();

                   using (SqlCommand sql_comando = new SqlCommand())
                   {

                       sql_comando.Connection = sql_conexion;
                       sql_comando.CommandType = CommandType.StoredProcedure;
                       sql_comando.CommandText = "[pa_TrasladosDet_Select_EXTERNO]";

                       sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                       sql_comando.Parameters.Add("@CodAlmacenLlegada", SqlDbType.Int).Value = objEntidadBE.CodAlmacenLlegada;
                       sql_comando.Parameters.Add("@CodTipoDocSust", SqlDbType.Int).Value = objEntidadBE.CodTipoDocSust;
                       sql_comando.Parameters.Add("@SerieDocSust", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDocSust;
                       sql_comando.Parameters.Add("@NumeroDocSust", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDocSust;

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


       public DataTable F_NotaIngresoSalidaDet_Select_Importaciones(NotaIngresoSalidaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_NotaIngresoSalidaDet_Select_importaciones";

                       sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;

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

       public DataTable F_NotaIngresoSalidaDet_NotaPedido(NotaIngresoSalidaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_NotaIngresoSalidaDet_NotaPedido";

                       sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;

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

       public DataTable F_NotaIngresoSalidaDet_Select_OC(NotaIngresoSalidaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_NotaIngresoSalidaDet_Select_OC";

                       sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;

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

       public DataTable F_NotaIngresoSalidaDetSerializacionDet_Listar(NotaIngresoSalidaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_NotaIngresoSalidaDetSerializacionDet_Listar";

                       sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;

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

       public DataTable F_NotaIngresoSalidaDet_Select_Importaciones_REEIM(NotaIngresoSalidaDetCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_NotaIngresoSalidaDet_Select_importaciones";

                       sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;

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
