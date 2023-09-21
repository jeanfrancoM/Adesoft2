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
  public class MovimientosCD
    {
      public DataTable F_Movimientos_Kardex(MovimientosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_Movimientos_Kardex";

                      sql_comando.Parameters.Add("@CodAlterno", SqlDbType.VarChar,15).Value = objEntidadBE.CodAlterno;
                      sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                      sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                      if (objEntidadBE.CodAlmacen > 0)
                          sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      if (objEntidadBE.CodCtaCte > 0)
                          sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      if (objEntidadBE.CodTipoOperacion > 0)
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

      public MovimientosCE F_Movimientos_Kardex_SaldoInicial_Modificar(MovimientosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_Movimientos_Kardex_SaldoInicial_Modificar";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
                      sql_comando.Parameters.Add("@CantidadIng", SqlDbType.Decimal).Value = objEntidadBE.CantidadIng;
                      sql_comando.Parameters.Add("@Costo", SqlDbType.Decimal).Value = objEntidadBE.CostoCompra;
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
      public MovimientosCE F_Movimientos_Kardex_InicialAjuste_Modificar(MovimientosCE objEntidadBE)
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
                      sql_comando.CommandText = "PA_MOVIMIENTOS_KARDEX_INICIALAJUSTE_MODIFICAR";

                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
                      sql_comando.Parameters.Add("@CantIng", SqlDbType.Decimal).Value = objEntidadBE.CantidadIng;
                      sql_comando.Parameters.Add("@CantSalida", SqlDbType.Decimal).Value = objEntidadBE.CantidadSal;
                      sql_comando.Parameters.Add("@FechaIngreso", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaIngreso;
                      sql_comando.Parameters.Add("@TipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                      sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar,500).Value = objEntidadBE.Observacion;

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
      public DataTable F_Movimientos_Kardex_Auditoria(MovimientosCE objEntidadBE)
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
                      sql_comando.CommandText = "PA_Movimientos_Kardex_AUDITORIA";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;

                      dta_auditoria = new DataTable();

                      dta_auditoria.Load(sql_comando.ExecuteReader());

                      return dta_auditoria;

                  }
              }

          }
          catch (Exception ex)
          {
              throw ex;
          }
          finally { dta_auditoria.Dispose(); }
      }


      //salcedo
      public DataTable F_Movimientos_Kardex_Salcedo(MovimientosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_Movimientos_Kardex";

                      sql_comando.Parameters.Add("@CodAlterno", SqlDbType.VarChar, 15).Value = objEntidadBE.CodAlterno;
                      sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                      sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                      if (objEntidadBE.CodAlmacen > 0)
                          sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      if (objEntidadBE.CodCtaCte > 0)
                          sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      if (objEntidadBE.CodTipoOperacion > 0)
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

      public MovimientosCE F_Movimientos_Kardex_SaldoInicial_Modificar_Salcedo(MovimientosCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_Movimientos_Kardex_SaldoInicial_Modificar";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
                      sql_comando.Parameters.Add("@CantidadIng", SqlDbType.Decimal).Value = objEntidadBE.CantidadIng;
                      sql_comando.Parameters.Add("@Costo", SqlDbType.Decimal).Value = objEntidadBE.CostoCompra;
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

      public DataTable F_Movimientos_Kardex_Auditoria_Salcedo(MovimientosCE objEntidadBE)
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
                      sql_comando.CommandText = "PA_Movimientos_Kardex_AUDITORIA";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;

                      dta_auditoria = new DataTable();

                      dta_auditoria.Load(sql_comando.ExecuteReader());

                      return dta_auditoria;

                  }
              }

          }
          catch (Exception ex)
          {
              throw ex;
          }
          finally { dta_auditoria.Dispose(); }
      }

      public MovimientosCE F_Movimientos_Kardex_InicialAjuste_Modificar_Salcedo(MovimientosCE objEntidadBE)
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
                      sql_comando.CommandText = "PA_MOVIMIENTOS_KARDEX_INICIALAJUSTE_MODIFICAR";

                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
                      sql_comando.Parameters.Add("@CantIng", SqlDbType.Decimal).Value = objEntidadBE.CantidadIng;
                      sql_comando.Parameters.Add("@CantSalida", SqlDbType.Decimal).Value = objEntidadBE.CantidadSal;
                      sql_comando.Parameters.Add("@FechaIngreso", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaIngreso;
                      sql_comando.Parameters.Add("@TipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
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
    }
}
