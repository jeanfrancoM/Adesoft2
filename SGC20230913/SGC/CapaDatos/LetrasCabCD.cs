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
   public class LetrasCabCD
    {
       public LetrasCabCE F_LetraCab_Insert(LetrasCabCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_LetraCab_Insert";

                       sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                       sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                       sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                       sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                       sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                       sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;

                       sql_comando.Parameters.Add("@AvalPermanente", SqlDbType.VarChar, 100).Value = objEntidadBE.AvalPermanente;
                       sql_comando.Parameters.Add("@Domicilio", SqlDbType.VarChar, 100).Value = objEntidadBE.Domicilio;
                       sql_comando.Parameters.Add("@Localidad", SqlDbType.VarChar, 100).Value = objEntidadBE.Localidad;
                       sql_comando.Parameters.Add("@Telefono", SqlDbType.VarChar, 100).Value = objEntidadBE.Telefono;
                       sql_comando.Parameters.Add("@DOIRUC", SqlDbType.VarChar, 100).Value = objEntidadBE.DOIRUC;

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
       
       public LetrasCabCE F_TemporalLetraCab_Insert(LetrasCabCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_TemporalLetraCab_Insert";

                       sql_comando.Parameters.Add("@NroLetra", SqlDbType.VarChar, 12).Value = objEntidadBE.Numero;
                       sql_comando.Parameters.Add("@Emision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                       sql_comando.Parameters.Add("@CantidadLetra", SqlDbType.Int).Value = objEntidadBE.CantidadLetra;
                       sql_comando.Parameters.Add("@TotalFactura", SqlDbType.Decimal).Value = objEntidadBE.TotalFactura;
                       sql_comando.Parameters.Add("@Moneda", SqlDbType.VarChar, 15).Value = objEntidadBE.Moneda;
                       sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                       sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                       sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                       sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;
                       sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                       sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                       sql_comando.Parameters.Add("@Dias", SqlDbType.Int).Value = objEntidadBE.Dias;

                       //sql_comando.Parameters.Add("@NroLetra", SqlDbType.VarChar,12).Value = objEntidadBE.Numero;
                       //sql_comando.Parameters.Add("@Emision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                       //sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaVencimiento;

                       //sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                       //sql_comando.Parameters.Add("@Moneda", SqlDbType.VarChar,15).Value = objEntidadBE.Moneda;
                       //sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;

                       //sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                       //sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodSede;
                       //sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;

                       //sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                       //sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
          
                       
                       SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                       MsgError.Direction = ParameterDirection.Output;

                       SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                       Codigo.Direction = ParameterDirection.Output;

                       sql_comando.ExecuteNonQuery();

                       objEntidadBE.MsgError = MsgError.Value.ToString();
                       objEntidadBE.CodLetra = Convert.ToInt32(Codigo.Value);

                       return objEntidadBE;

                   }

               }



           }
           catch (Exception ex)
           {

               throw ex;

           }



       }

       public DataTable F_TemporalLetraCab_Listar(LetrasCabCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_TemporalLetraCab_Listar";

                       sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;
                       
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

       public LetrasCabCE F_TemporalLetra_Eliminar(LetrasCabCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_TemporalLetraCab_Eliminar";

                       sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;


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

       public DataTable F_LetraCab_Select(LetrasCabCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_LetrasCab_Select";

                       sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                       sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                       if (objEntidadBE.CodEstado > 0)
                       sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;

                       if (objEntidadBE.CodCtaCte > 0)
                           sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;

                       if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                       {
                           sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                           sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                       }

                       if (objEntidadBE.Numero != "")
                           sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 10).Value = objEntidadBE.Numero;

                       if (objEntidadBE.CodEmpresa > 0)
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

       public LetrasCabCE F_Anulacion_Letras(LetrasCabCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_Anulacion_Letras";

                       sql_comando.Parameters.Add("@CodLetra", SqlDbType.Int).Value = objEntidadBE.CodLetra;
                       sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                       sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 1000).Value = objEntidadBE.Observacion;
                       sql_comando.Parameters.Add("@Observaciones", SqlDbType.VarChar, 1000).Value = objEntidadBE.Observaciones;
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
               objEntidadBE.MsgError = ex.Message.ToString();
               throw ex;

           }



       }

       public DataTable F_LetrasCab_ConsultaPagos(LetrasCabCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_LetrasCab_ConsultaPagos";

                       sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
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

       public LetrasCabCE F_LETRASCAB_CODIGOUNICO(LetrasCabCE objEntidadBE)
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
                       sql_comando.CommandText = "PA_LETRASCAB_CODIGOUNICO";

                       sql_comando.Parameters.Add("@CodLetra", SqlDbType.Int).Value = objEntidadBE.CodLetra;
                       sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                       sql_comando.Parameters.Add("@CodigoUnico", SqlDbType.VarChar, 50).Value = objEntidadBE.CodigoUnico;
                       if (objEntidadBE.CodBanco == 0)
                           sql_comando.Parameters.Add("@CodBanco", SqlDbType.Int).Value = DBNull.Value;
                       else
                           sql_comando.Parameters.Add("@CodBanco", SqlDbType.Int).Value = objEntidadBE.CodBanco;
                       if (objEntidadBE.IngresoBanco.ToString("yyyyMMdd") == "19900101")
                           sql_comando.Parameters.Add("@IngresoBanco", SqlDbType.SmallDateTime).Value = DBNull.Value;
                       else
                           sql_comando.Parameters.Add("@IngresoBanco", SqlDbType.SmallDateTime).Value = objEntidadBE.IngresoBanco;
                       sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                       sql_comando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaVencimiento;
                       sql_comando.Parameters.Add("@Numero", SqlDbType.VarChar, 20).Value = objEntidadBE.Numero;

                       SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150);
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

       public LetrasCabCE F_TemporalLetraCab_UPDATE(LetrasCabCE objEntidadBE)
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
                       sql_comando.CommandText = "PA_TemporalLetraCab_UPDATE";

                       sql_comando.Parameters.Add("@CodLetraCab", SqlDbType.Int).Value = objEntidadBE.CodLetraCab;
                       sql_comando.Parameters.Add("@Numero", SqlDbType.VarChar, 12).Value = objEntidadBE.Numero;
                       sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                       sql_comando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaVencimiento;
                       sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;

                       SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150);
                       MsgError.Direction = ParameterDirection.Output;

                       SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                       Codigo.Direction = ParameterDirection.Output;

                       sql_comando.ExecuteNonQuery();

                       objEntidadBE.MsgError = MsgError.Value.ToString();
                       objEntidadBE.CodLetra = Convert.ToInt32(Codigo.Value) ;

                       return objEntidadBE;
                   }
               }
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public LetrasCabCE F_Eliminacion_Letras(LetrasCabCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_Eliminacion_Letras";

                       sql_comando.Parameters.Add("@CodLetra", SqlDbType.Int).Value = objEntidadBE.CodLetra;
                       sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                       sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                       sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 1000).Value = objEntidadBE.Observacion;
                       sql_comando.Parameters.Add("@Observaciones", SqlDbType.VarChar, 1000).Value = objEntidadBE.Observaciones;

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
               objEntidadBE.MsgError = ex.Message.ToString();
               throw ex;
           }
       }

       public DataTable F_LetrasCab_Listar_Documentos1(LetrasCabCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_LetrasCab_Listar_Documentos1";

                       sql_comando.Parameters.Add("@CodLetra", SqlDbType.Int).Value = objEntidadBE.CodLetra;

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

       public DataTable F_LetrasCab_Listar_Documentos2(LetrasCabCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_LetrasCab_Listar_Documentos2";

                       sql_comando.Parameters.Add("@CodLetra", SqlDbType.Int).Value = objEntidadBE.CodLetra;

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


       public DataTable F_LetraCab_Imprimir(LetrasCabCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_LetrasCab_Imprimir";

                       sql_comando.Parameters.Add("@CodLetra", SqlDbType.Int).Value = objEntidadBE.CodLetra;

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

       public DataTable F_LetraCab_Select_Eliminados(LetrasCabCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_LetrasCab_Select_Eliminadas";

                       sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                       sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                       if (objEntidadBE.CodCtaCte > 0)
                           sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;

                       if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                       {
                           sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                           sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                       }

                       if (objEntidadBE.Numero != "")
                           sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 10).Value = objEntidadBE.Numero;

                       if (objEntidadBE.CodEmpresa > 0)
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

       //eliminar letra

       public DataTable F_LetrasDet_Eliminar_Listar(LetrasCabCE objEntidadBE)
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
                       sql_comando.CommandText = "pa_LetrasDet_Eliminados_Listar";

                       sql_comando.Parameters.Add("@CodLetraCab", SqlDbType.Int).Value = objEntidadBE.CodLetra;

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


       //observacion elmiinacion

       public DataTable F_LETRASCAB_ELIMINADOS_OBSERVACION(LetrasCabCE objEntidadBE)
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
                       sql_comando.CommandText = "PA_LetraCAB_Eliminadas_OBSERVACION";

                       sql_comando.Parameters.Add("@CodLetraCab", SqlDbType.Int).Value = objEntidadBE.CodLetra;

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

       public object F_LetrasCAB_Eliminadas_OBSERVACIONes(LetrasCabCE objEntidad)
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
                       sql_comando.CommandText = "PA_LetraCAB_Eliminadas_OBSERVACIONEs";

                       sql_comando.Parameters.Add("@CodLetraCab", SqlDbType.Int).Value = objEntidad.CodLetra;

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

       public DataTable F_LetraCab_ELIMINADOS_AUDITORIA(LetrasCabCE objEntidadBE)
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
                       sql_comando.CommandText = "PA_LetraCab_ELIMINADOS_AUDITORIA";

                       sql_comando.Parameters.Add("@CodLetraCab", SqlDbType.Int).Value = objEntidadBE.CodLetra;

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

       public DataTable F_LetraCab_AUDITORIA(LetrasCabCE objEntidadBE)
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
                       sql_comando.CommandText = "PA_LetraCab_AUDITORIA";

                       sql_comando.Parameters.Add("@CodLetraCab", SqlDbType.Int).Value = objEntidadBE.CodLetra;

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
