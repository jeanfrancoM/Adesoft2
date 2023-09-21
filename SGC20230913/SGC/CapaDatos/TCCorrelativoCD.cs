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
   public class TCCorrelativoCD
    {
       public DataTable F_TCCorrelativo_Serie_Select(TCCorrelativoCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_TCCorrelativo_Serie_Select";

                       sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                       sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                       sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                       if (objEntidadBE.CodEstado != 0)
                           sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;

                       if (objEntidadBE.Flag_Automatico != null & objEntidadBE.Flag_Automatico != "")
                           sql_comando.Parameters.Add("@Flag_Automatico", SqlDbType.Int).Value = objEntidadBE.Flag_Automatico;

                       if (objEntidadBE.FlagNCInterno > -1)
                            sql_comando.Parameters.Add("@FlagNCInterno", SqlDbType.Int).Value = objEntidadBE.FlagNCInterno;

                       if (objEntidadBE.CodTipoDoc2 > 0)
                           sql_comando.Parameters.Add("@CodTipoDoc2", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc2;

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

       public DataTable F_TCCorrelativo_Numero_Select(TCCorrelativoCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_TCCorrelativo_Numero_Select";

                       sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                       sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                       sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar,4).Value = objEntidadBE.SerieDoc;
                       sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;

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

       public TCCorrelativoCE F_TCCorrelativo_Edicion(TCCorrelativoCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_TCCorrelativo_Edicion";

                       sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                       sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                       sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                       sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                       sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                       sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;

                       SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 200);
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
