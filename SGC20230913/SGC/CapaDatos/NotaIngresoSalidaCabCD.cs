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
  public  class NotaIngresoSalidaCabCD
    {
      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Insert(NotaIngresoSalidaCabCE objEntidadBE)
        {
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.CommandTimeout = 90;

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Insert";

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDocSust", SqlDbType.Int).Value = objEntidadBE.CodTipoDocSust;
                        sql_comando.Parameters.Add("@SerieDocSust", SqlDbType.VarChar,4).Value = objEntidadBE.SerieDocSust;
                        sql_comando.Parameters.Add("@NumeroDocSust", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDocSust;

                        sql_comando.Parameters.Add("@FechaIngreso", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaIngreso;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaRegistro;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                                               
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@ImpSubTotal", SqlDbType.Decimal).Value = objEntidadBE.ImpSubTotal;
                        sql_comando.Parameters.Add("@ImpIgv", SqlDbType.Decimal).Value = objEntidadBE.ImpIGV;

                        sql_comando.Parameters.Add("@ImpTotal", SqlDbType.Decimal).Value = objEntidadBE.ImpTotal;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@Periodo", SqlDbType.Int).Value = objEntidadBE.Periodo;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@FlagLetra", SqlDbType.Int).Value = objEntidadBE.FlagLetra;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@CodClasificacion", SqlDbType.Int).Value = objEntidadBE.CodClasificacion;
                        sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidadBE.CodCategoria;
                        sql_comando.Parameters.Add("@CodSerie", SqlDbType.Int).Value = objEntidadBE.CodSerie;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@FlagIncluyeIGV", SqlDbType.Int).Value = objEntidadBE.FlagIncluyeIGV;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;

                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 100).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 300).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@Guia", SqlDbType.VarChar, 500).Value = objEntidadBE.Guia;
                        sql_comando.Parameters.Add("@FacturaAntigua", SqlDbType.Int).Value = objEntidadBE.FacturaAntigua;
                        sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 11).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodTipoCtaCte", SqlDbType.Int).Value = objEntidadBE.CodTipoCtaCte;
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

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Insert_Salcedo(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              using (SqlConnection sql_conexion = new SqlConnection())
              {
                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {
                      sql_comando.CommandTimeout = 90;

                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Insert";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodTipoDocSust", SqlDbType.Int).Value = objEntidadBE.CodTipoDocSust;
                      sql_comando.Parameters.Add("@SerieDocSust", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDocSust;
                      sql_comando.Parameters.Add("@NumeroDocSust", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDocSust;

                      sql_comando.Parameters.Add("@FechaIngreso", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaIngreso;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaRegistro;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;

                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@ImpSubTotal", SqlDbType.Decimal).Value = objEntidadBE.ImpSubTotal;
                      sql_comando.Parameters.Add("@ImpIgv", SqlDbType.Decimal).Value = objEntidadBE.ImpIGV;

                      sql_comando.Parameters.Add("@ImpTotal", SqlDbType.Decimal).Value = objEntidadBE.ImpTotal;
                      sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                      sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                      sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;

                      sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                      sql_comando.Parameters.Add("@Periodo", SqlDbType.Int).Value = objEntidadBE.Periodo;
                      sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                      sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                      sql_comando.Parameters.Add("@FlagLetra", SqlDbType.Int).Value = objEntidadBE.FlagLetra;
                      sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                      sql_comando.Parameters.Add("@CodClasificacion", SqlDbType.Int).Value = objEntidadBE.CodClasificacion;
                      sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidadBE.CodCategoria;
                      sql_comando.Parameters.Add("@CodSerie", SqlDbType.Int).Value = objEntidadBE.CodSerie;
                      sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                      sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                      sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                      sql_comando.Parameters.Add("@FlagIncluyeIGV", SqlDbType.Int).Value = objEntidadBE.FlagIncluyeIGV;
                      sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                      sql_comando.Parameters.Add("@FlagCosteable", SqlDbType.Int).Value = objEntidadBE.FlagCosteable;
                      sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                      sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                      sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                      sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                      sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 100).Value = objEntidadBE.RazonSocial;
                      sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                      sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                      sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 300).Value = objEntidadBE.Direccion;
                      sql_comando.Parameters.Add("@Guia", SqlDbType.VarChar, 500).Value = objEntidadBE.Guia;
                      sql_comando.Parameters.Add("@FacturaAntigua", SqlDbType.Int).Value = objEntidadBE.FacturaAntigua;
                      sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;
                      sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 11).Value = objEntidadBE.NroOperacion;
                      sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                      sql_comando.Parameters.Add("@CodTipoCtaCte", SqlDbType.Int).Value = objEntidadBE.CodTipoCtaCte;
                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                      MsgError.Direction = ParameterDirection.Output;

                      SqlParameter CodMovimiento = sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int);
                      CodMovimiento.Direction = ParameterDirection.Output;

                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.MsgError = MsgError.Value.ToString();
                      objEntidadBE.CodMovimiento = Convert.ToInt32(CodMovimiento.Value);

                      return objEntidadBE;
                  }
              }
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Insert_Tractos(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              using (SqlConnection sql_conexion = new SqlConnection())
              {
                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {
                      sql_comando.CommandTimeout = 90;

                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Insert";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodTipoDocSust", SqlDbType.Int).Value = objEntidadBE.CodTipoDocSust;
                      sql_comando.Parameters.Add("@SerieDocSust", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDocSust;
                      sql_comando.Parameters.Add("@NumeroDocSust", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDocSust;

                      sql_comando.Parameters.Add("@FechaIngreso", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaIngreso;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaRegistro;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;

                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@ImpSubTotal", SqlDbType.Decimal).Value = objEntidadBE.ImpSubTotal;
                      sql_comando.Parameters.Add("@ImpIgv", SqlDbType.Decimal).Value = objEntidadBE.ImpIGV;

                      sql_comando.Parameters.Add("@ImpTotal", SqlDbType.Decimal).Value = objEntidadBE.ImpTotal;
                      sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                      sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                      sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;

                      sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                      sql_comando.Parameters.Add("@Periodo", SqlDbType.Int).Value = objEntidadBE.Periodo;
                      sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                      sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                      sql_comando.Parameters.Add("@FlagLetra", SqlDbType.Int).Value = objEntidadBE.FlagLetra;
                      sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                      sql_comando.Parameters.Add("@CodClasificacion", SqlDbType.Int).Value = objEntidadBE.CodClasificacion;
                      sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidadBE.CodCategoria;
                      sql_comando.Parameters.Add("@CodSerie", SqlDbType.Int).Value = objEntidadBE.CodSerie;
                      sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                      sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                      sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                      sql_comando.Parameters.Add("@FlagIncluyeIGV", SqlDbType.Int).Value = objEntidadBE.FlagIncluyeIGV;
                      sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;

                      sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                      sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                      sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                      sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                      sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 100).Value = objEntidadBE.RazonSocial;
                      sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                      sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                      sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 300).Value = objEntidadBE.Direccion;
                      sql_comando.Parameters.Add("@Guia", SqlDbType.VarChar, 500).Value = objEntidadBE.Guia;
                      sql_comando.Parameters.Add("@FacturaAntigua", SqlDbType.Int).Value = objEntidadBE.FacturaAntigua;
                      sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;
                      sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 11).Value = objEntidadBE.NroOperacion;
                      sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                      sql_comando.Parameters.Add("@CodTipoCtaCte", SqlDbType.Int).Value = objEntidadBE.CodTipoCtaCte;
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

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Insert_Roy(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              using (SqlConnection sql_conexion = new SqlConnection())
              {
                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {
                      sql_comando.CommandTimeout = 90;

                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Insert";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodTipoDocSust", SqlDbType.Int).Value = objEntidadBE.CodTipoDocSust;
                      sql_comando.Parameters.Add("@SerieDocSust", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDocSust;
                      sql_comando.Parameters.Add("@NumeroDocSust", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDocSust;

                      sql_comando.Parameters.Add("@FechaIngreso", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaIngreso;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaRegistro;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;

                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@ImpSubTotal", SqlDbType.Decimal).Value = objEntidadBE.ImpSubTotal;
                      sql_comando.Parameters.Add("@ImpIgv", SqlDbType.Decimal).Value = objEntidadBE.ImpIGV;

                      sql_comando.Parameters.Add("@ImpTotal", SqlDbType.Decimal).Value = objEntidadBE.ImpTotal;
                      sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                      sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                      sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;

                      sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                      sql_comando.Parameters.Add("@Periodo", SqlDbType.Int).Value = objEntidadBE.Periodo;
                      sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                      sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                      sql_comando.Parameters.Add("@FlagLetra", SqlDbType.Int).Value = objEntidadBE.FlagLetra;
                      sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                      sql_comando.Parameters.Add("@CodClasificacion", SqlDbType.Int).Value = objEntidadBE.CodClasificacion;
                      sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidadBE.CodCategoria;
                      sql_comando.Parameters.Add("@CodSerie", SqlDbType.Int).Value = objEntidadBE.CodSerie;
                      sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                      sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                      sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                      sql_comando.Parameters.Add("@FlagIncluyeIGV", SqlDbType.Int).Value = objEntidadBE.FlagIncluyeIGV;
                      sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;

                      sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                      sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                      sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                      sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                      sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 100).Value = objEntidadBE.RazonSocial;
                      sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                      sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                      sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 300).Value = objEntidadBE.Direccion;
                      sql_comando.Parameters.Add("@Guia", SqlDbType.VarChar, 500).Value = objEntidadBE.Guia;
                      sql_comando.Parameters.Add("@FacturaAntigua", SqlDbType.Int).Value = objEntidadBE.FacturaAntigua;
                      sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;
                      sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 11).Value = objEntidadBE.NroOperacion;
                      sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                      sql_comando.Parameters.Add("@CodTipoCtaCte", SqlDbType.Int).Value = objEntidadBE.CodTipoCtaCte;
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

      public DataTable F_NotaIngresoSalidaCab_Select_Compras(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Select_Compras";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;                                        
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@CodClasificacion", SqlDbType.Int).Value = objEntidadBE.CodClasificacion;

                      if (objEntidadBE.CodEmpresa > 0)
                          sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;   

                      if (objEntidadBE.CodTipoOperacion > 0)
                          sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                      if (objEntidadBE.CodCtaCte>0)
                          sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;

                      if (objEntidadBE.Desde.ToString("yyyyMMdd") !="19900101")                     
                      {
                          sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                          sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                      }
                      
                      if (objEntidadBE.NumeroDoc !="")
                          sql_comando.Parameters.Add("@NumeroDoc",SqlDbType.VarChar,10).Value = objEntidadBE.NumeroDoc;

                      if (objEntidadBE.SerieDoc != "")
                          sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                     
                      if (objEntidadBE.CodTipoDocSust != 0)
                           sql_comando.Parameters.Add("@CodTipoDocSust", SqlDbType.Int).Value = objEntidadBE.CodTipoDocSust;

                      if (objEntidadBE.CodEstado != 0)
                          sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;

                      if (objEntidadBE.FlagImportacion > -1)
                          sql_comando.Parameters.Add("@FlagImportacion", SqlDbType.Int).Value = objEntidadBE.FlagImportacion;
                                            
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

      public DataTable F_SUNAT_EstadoDocumentos(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_SUNAT_EstadoDocumentos";

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

      public NotaIngresoSalidaCabCE F_Anulacion_NotaIngreso(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_Anulacion_NotaIngreso";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@ObservacionAnulacion", SqlDbType.VarChar,1000).Value = objEntidadBE.Observacion;
                     
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

      public DataTable F_NotaIngresoSalidaCab_Letras(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Letras";

                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
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

      public DataTable F_NotaIngresoSalidaCab_ConsultaPagos(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_ConsultaPagos";

                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
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

      public NotaIngresoSalidaCabCE F_Pagos_RegistroPagos(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_Pagos_RegistroPagos";

                      sql_comando.Parameters.Add("@CodigoTemporalPagos", SqlDbType.Int).Value = objEntidadBE.CodigoTemporal;
                      sql_comando.Parameters.Add("@CodigoTemporalCobranzas", SqlDbType.Int).Value = objEntidadBE.CodigoTemporalCobranzas;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodMedioPago", SqlDbType.Int).Value = objEntidadBE.CodMedioPago;
                      sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 250).Value = objEntidadBE.NroOperacion;
                      sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                      sql_comando.Parameters.Add("@FechaOperacion", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaOperacion;
                      sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                      sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                      sql_comando.Parameters.Add("@Responsable", SqlDbType.VarChar, 250).Value = objEntidadBE.Responsable;
                      sql_comando.Parameters.Add("@Observaciones", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                      sql_comando.Parameters.Add("@CodBanco", SqlDbType.Int).Value = objEntidadBE.CodBanco;
                      sql_comando.Parameters.Add("@CodCtaBancaria", SqlDbType.Int).Value = objEntidadBE.CodCtaBancaria;
                      sql_comando.Parameters.Add("@CobranzaSoles", SqlDbType.Decimal).Value = objEntidadBE.CobranzaSoles;
                      sql_comando.Parameters.Add("@DeudaSoles", SqlDbType.Decimal).Value = objEntidadBE.DeudaSoles;
                      sql_comando.Parameters.Add("@DeudaOperacionSoles", SqlDbType.Decimal).Value = objEntidadBE.DeudaOperacionSoles;
                      sql_comando.Parameters.Add("@CobranzaDolares", SqlDbType.Decimal).Value = objEntidadBE.CobranzaDolares;
                      sql_comando.Parameters.Add("@DeudaDolares", SqlDbType.Decimal).Value = objEntidadBE.DeudaDolares;
                      sql_comando.Parameters.Add("@DeudaOperacionDolares", SqlDbType.Decimal).Value = objEntidadBE.DeudaOperacionDolares;
                      sql_comando.Parameters.Add("@CodCtacte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

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

      public DataTable F_Pagos_Listar(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_Pagos_Listar";

                      if (objEntidadBE.CodCtaCte > 0)
                          sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;

                      if (objEntidadBE.CodMedioPago > 0)
                          sql_comando.Parameters.Add("@CodMedioPago", SqlDbType.Int).Value = objEntidadBE.CodMedioPago;

                      if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                      {
                          sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                          sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                      }

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

                      if (objEntidadBE.CodCajaFisica > 0)
                          sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;
                      
                      if (objEntidadBE.CodEmpresa > 0)
                          sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;

                      if (objEntidadBE.NumeroDoc != "")
                          sql_comando.Parameters.Add("@Numero", SqlDbType.VarChar, 15).Value = objEntidadBE.NumeroDoc;

                      if (objEntidadBE.chkRegistro > 0)
                          sql_comando.Parameters.Add("@chkRegistro", SqlDbType.Int).Value = objEntidadBE.chkRegistro;

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

      public NotaIngresoSalidaCabCE F_Pagos_Anulacion(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_Pagos_Anulacion";

                      sql_comando.Parameters.Add("@CodPagoCab", SqlDbType.Int).Value = objEntidadBE.CodPagoCab;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;

                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 400);
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

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_InsertGastos(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_InsertGastos";

                      sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodTipoDocSust", SqlDbType.Int).Value = objEntidadBE.CodTipoDocSust;
                      sql_comando.Parameters.Add("@SerieDocSust", SqlDbType.VarChar, 6).Value = objEntidadBE.SerieDocSust;
                      sql_comando.Parameters.Add("@NumeroDocSust", SqlDbType.VarChar, 14).Value = objEntidadBE.NumeroDocSust;
                      sql_comando.Parameters.Add("@FechaIngreso", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaIngreso;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                      sql_comando.Parameters.Add("@Proveedor", SqlDbType.VarChar, 500).Value = objEntidadBE.Proveedor;
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@ImpSubTotal", SqlDbType.Decimal).Value = objEntidadBE.ImpSubTotal;
                      sql_comando.Parameters.Add("@ImpIgv", SqlDbType.Decimal).Value = objEntidadBE.ImpIGV;
                      sql_comando.Parameters.Add("@ImpTotal", SqlDbType.Decimal).Value = objEntidadBE.ImpTotal;
                      sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                      sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                      sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                      sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                      sql_comando.Parameters.Add("@Periodo", SqlDbType.Int).Value = objEntidadBE.Periodo;
                      sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                      sql_comando.Parameters.Add("@FlagLetra", SqlDbType.Int).Value = objEntidadBE.FlagLetra;
                      sql_comando.Parameters.Add("@CodClasificacion", SqlDbType.Int).Value = objEntidadBE.CodClasificacion;
                      sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidadBE.CodCategoria;
                      sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;
                      sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 500).Value = objEntidadBE.Observacion;
                      sql_comando.Parameters.Add("@CodMotivo", SqlDbType.Int).Value = objEntidadBE.CodMotivo;
                      sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                      sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                      sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                      sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                      sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 500).Value = objEntidadBE.Direccion;
                      sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                      sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 15).Value = objEntidadBE.Placa;
                      sql_comando.Parameters.Add("@CodigoTemporal", SqlDbType.Int).Value = objEntidadBE.CodigoTemporal;
                      
                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                      MsgError.Direction = ParameterDirection.Output;

                      SqlParameter CodMovimiento = sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int);
                      CodMovimiento.Direction = ParameterDirection.Output;

                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.MsgError = MsgError.Value.ToString();
                      objEntidadBE.CodMovimiento = Convert.ToInt32(CodMovimiento.Value.ToString());

                      return objEntidadBE;
                  }
              }
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_NotaIngresoSalidaCab_VistaPreliminar(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "sp_NotaIngresoSalida_rpt";

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

      public DataTable F_NotaIngesoSalidaCab_FacturaPercepcion(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngesoSalidaCab_FacturaPercepciones";

                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = objEntidadBE.Monto;
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

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_FacturacionOC(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_FacturacionOC";

                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
                      sql_comando.Parameters.Add("@CodTipoDocSust", SqlDbType.Int).Value = objEntidadBE.CodTipoDocSust;
                      sql_comando.Parameters.Add("@SerieDocSust", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDocSust;
                      sql_comando.Parameters.Add("@NumeroDocSust", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDocSust;

                      sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                      sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                      sql_comando.Parameters.Add("@ImpSubTotal", SqlDbType.Decimal).Value = objEntidadBE.ImpSubTotal;
                      sql_comando.Parameters.Add("@ImpIgv", SqlDbType.Decimal).Value = objEntidadBE.ImpIGV;

                      sql_comando.Parameters.Add("@ImpTotal", SqlDbType.Decimal).Value = objEntidadBE.ImpTotal;
                      sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                      sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                      sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                      sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                      sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                      sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;

                     
                      sql_comando.Parameters.Add("@Periodo", SqlDbType.Int).Value = objEntidadBE.Periodo;
                      sql_comando.Parameters.Add("@FlagLetra", SqlDbType.Int).Value = objEntidadBE.FlagLetra;
                      sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;
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

      public DataTable F_NotaIngresoSalidaCab_OCXFacturar(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_OCXFacturar";

                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
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

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_DevolucionOC(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_DevolucionOC";

                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                      sql_comando.Parameters.Add("@CodTasaIgv", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                      sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
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

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_CompraCorporativa_Insert(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_CompraCorporativa_Insert";

                      sql_comando.Parameters.Add("@Serie", SqlDbType.VarChar,50).Value = objEntidadBE.Serie;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
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

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_OC_Devolucion(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_OC_Devolucion";

                      sql_comando.Parameters.Add("@Serie", SqlDbType.VarChar, 50).Value = objEntidadBE.Serie;
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

      public NotaIngresoSalidaCabCE F_TrasladosCab_GuiaInterna_Devolucion(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_TrasladosCab_GuiaInterna_Devolucion";

                      sql_comando.Parameters.Add("@Serie", SqlDbType.VarChar, 50).Value = objEntidadBE.Serie;
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

      public NotaIngresoSalidaCabCE F_DocumentoVentaCab_OC_NV_Devolucion(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_DocumentoVentaCab_OC_NV_Devolucion";

                      sql_comando.Parameters.Add("@Serie", SqlDbType.VarChar, 50).Value = objEntidadBE.Serie;
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

      public DataTable F_NotaIngresoSalidaCab_ConsultaPago(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_ConsultaPago";

                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
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

      public DataTable F_NotaIngresoSalidaCab_Compras(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Compras";

                      sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                      sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
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
      
      public DataTable F_NotaIngresoSalidaCab_Compras_Detallado(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Compras_DETALLADO";

                      sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                      sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                      if (objEntidadBE.CodCtaCte != 0)
                          sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;

                      if (objEntidadBE.CodEmpresa != 0)
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

      public DataTable F_FacturasXPagar_Reporte(NotaIngresoSalidaCabCE objEntidadBE)
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
                      //sql_comando.CommandText = "pa_FacturasXPagar_Reporte";
                      sql_comando.CommandText = "pa_Pagos_Reporte";
                      
                      if (objEntidadBE.CodEmpresa != 0)
                          sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;

                      if (objEntidadBE.CodCtaCte != 0)
                          sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;

                      if (objEntidadBE.Hasta.ToString("yyyyMMdd") != "19900101")
                      {
                          sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                          sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                      }

                      if (objEntidadBE.CodTipoDoc != 0)
                          sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;

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

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_NotaCredito_Insert(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_NotaCredito_Insert";

                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                      sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                      sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                      sql_comando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                      sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                      sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                      sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                      sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                      sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodFactura_Asociada", SqlDbType.Int).Value = objEntidadBE.CodFactura_Asociada;
                      sql_comando.Parameters.Add("@CodTipoOperacionNC", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacionNC;
                      sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                      sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                      sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                      sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;
                      sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 500).Value = objEntidadBE.Observacion;
                      
                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                      MsgError.Direction = ParameterDirection.Output;

                      SqlParameter Codigo = sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int);
                      Codigo.Direction = ParameterDirection.Output;

                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.MsgError = MsgError.Value.ToString();
                      objEntidadBE.CodMovimiento = Convert.ToInt32(Codigo.Value);

                      return objEntidadBE;

                  }

              }



          }
          catch (Exception ex)
          {

              throw ex;

          }



      }

      public DataTable F_NotaIngresoSalidaCab_ListarXCodigo_NotaCredito(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_ListarXCodigo_NotaCredito";

                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 15).Value = objEntidadBE.NumeroDoc;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
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

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaDet_InsertTemporal(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaDet_InsertTemporal";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
                      sql_comando.Parameters.Add("@CodTipoOperacionNC", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacionNC;

                      SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                      Codigo.Direction = ParameterDirection.Output;


                      sql_comando.ExecuteNonQuery();

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

      public NotaIngresoSalidaCabCE F_DocumentoVentaCab_NV_Devolucion(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_DocumentoVentaCab_NV_Devolucion";

                      sql_comando.Parameters.Add("@Serie", SqlDbType.VarChar, 50).Value = objEntidadBE.Serie;
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

      public DataTable F_NotaIngresoSalidaCab_Select_Compras_OC(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Select_Compras_OC";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      if (objEntidadBE.CodEmpresa>0)
                          sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;

                      if (objEntidadBE.SerieDoc != "TODOS")
                          sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                      if (objEntidadBE.CodCtaCte != 0)
                          sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;

                      if (objEntidadBE.CodEstado != 0)
                          sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;

                      if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")                
                      {
                          sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                          sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                      }

                      if (objEntidadBE.NumeroDoc != "")
                          sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                     
                      if (objEntidadBE.CodTipoDocSust != 0)
                          sql_comando.Parameters.Add("@CodTipoDocSust", SqlDbType.Int).Value = objEntidadBE.CodTipoDocSust;
                      
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

      public NotaIngresoSalidaCabCE F_Eliminacion_NotaIngreso(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_Eliminacion_NotaIngreso";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
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

      public DataTable F_OrdenCompra_Historial(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_OrdenCompra_Historial";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                      sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");

                      if (objEntidadBE.CodEstado == 0)
                          sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = DBNull.Value;
                      else
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

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Update(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Update";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
                      sql_comando.Parameters.Add("@Periodo", SqlDbType.Int).Value = objEntidadBE.Periodo;
                                  
                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.MsgError ="";

                      return objEntidadBE;

                  }

              }



          }
          catch (Exception ex)
          {

              throw ex;

          }



      }

      public DataTable F_NotaIngresoSalidaCab_HistorialCompraSunat(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_HistorialCompraSunat";

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

      public NotaIngresoSalidaCabCE F_ComprobanteCaja_Insert(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_ComprobanteCaja_Insert";

                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                      sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                      sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                      sql_comando.Parameters.Add("@CodMotivo", SqlDbType.Int).Value = objEntidadBE.CodMotivo;
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                      sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                      sql_comando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = objEntidadBE.Monto;
                      sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                      sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 300).Value = objEntidadBE.Proveedor;
                      sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 300).Value = objEntidadBE.Observacion;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodMedioPago", SqlDbType.Int).Value = objEntidadBE.CodMedioPago;
                      sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;
                      sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                      sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                      sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                      sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                      sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                      sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 500).Value = objEntidadBE.Direccion;
                      sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                      sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 500).Value = objEntidadBE.NroOperacion;
                      sql_comando.Parameters.Add("@CodigoTemporal", SqlDbType.Int).Value = objEntidadBE.CodigoTemporal;
                      sql_comando.Parameters.Add("@CodBanco", SqlDbType.Int).Value = objEntidadBE.CodBanco;
                      sql_comando.Parameters.Add("@CodCtaBancaria", SqlDbType.Int).Value = objEntidadBE.CodCtaBancaria;
                      sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 15).Value = objEntidadBE.Placa;
                      if (objEntidadBE.CodEntregado > 0)
                      { 
                          sql_comando.Parameters.Add("@CodEntregado", SqlDbType.Int).Value = objEntidadBE.CodEntregado;
                          sql_comando.Parameters.Add("@CodRecibido", SqlDbType.Int).Value = objEntidadBE.CodRecibido;
                      }                          

                      SqlParameter CodComprobanteCaja = sql_comando.Parameters.Add("@CodComprobanteCaja", SqlDbType.Int);
                      CodComprobanteCaja.Direction = ParameterDirection.Output;

                      SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150);
                      MsgError.Direction = ParameterDirection.Output;

                      sql_comando.ExecuteNonQuery();

                      objEntidadBE.MsgError = MsgError.Value.ToString();
                      objEntidadBE.CodMovimiento = Convert.ToInt32(CodComprobanteCaja.Value.ToString());

                      return objEntidadBE;

                  }

              }



          }
          catch (Exception ex)
          {

              throw ex;

          }



      }

      public DataTable F_ComprobanteCaja_Listar(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_ComprobanteCaja_Listar";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                      if (objEntidadBE.CodCtaCte != 0)
                          sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;

                      if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                      {
                          sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                          sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                      }

                      if (objEntidadBE.NumeroDoc != "")
                          sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;

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

      public DataTable F_ComprobanteCaja_Listar_Egresos(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_ComprobanteCaja_Listar_Egresos";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      if (objEntidadBE.SerieDoc != "")
                      sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                      if (objEntidadBE.CodCtaCte > 0)
                          sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;

                      if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                      {
                          sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                          sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                      }

                      if (objEntidadBE.NumeroDoc != "")
                          sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;

                      if (objEntidadBE.Factura != "")
                          sql_comando.Parameters.Add("@Factura", SqlDbType.VarChar, 13).Value = objEntidadBE.Factura;

                      if (objEntidadBE.CodEmpresa > 0)
                          sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;

                      if (objEntidadBE.CodMotivo > 0)
                          sql_comando.Parameters.Add("@CodMotivo", SqlDbType.Int).Value = objEntidadBE.CodMotivo;

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

      public NotaIngresoSalidaCabCE F_ComprobanteCaja_ActualizarSaldo(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_ComprobanteCaja_ActualizarSaldo";

                      sql_comando.Parameters.Add("@CodComprobanteCaja", SqlDbType.Int).Value = objEntidadBE.CodComprobanteCaja;
                      sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                      sql_comando.Parameters.Add("@SaldoComprobante", SqlDbType.Decimal).Value = objEntidadBE.SaldoComprobante;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

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
      
      public DataTable F_ComprobanteCaja_BuscarFactura(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_ComprobanteCaja_BuscarFactura";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                      sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;

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

      public DataTable F_ComprobanteCaja_BuscarFactura_Compras(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_ComprobanteCaja_BuscarFactura_Compras";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodMotivo", SqlDbType.Int).Value = objEntidadBE.CodMotivo;
                      sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                      sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;

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

      public NotaIngresoSalidaCabCE F_ComprobanteCaja_ActualizarSaldo_Compras(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_ComprobanteCaja_ActualizarSaldo_Compras";

                      sql_comando.Parameters.Add("@CodComprobanteCaja", SqlDbType.Int).Value = objEntidadBE.CodComprobanteCaja;
                      sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                      sql_comando.Parameters.Add("@SaldoComprobante", SqlDbType.Decimal).Value = objEntidadBE.SaldoComprobante;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodMotivo", SqlDbType.Int).Value = objEntidadBE.CodMotivo;

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

      public NotaIngresoSalidaCabCE F_ComprobanteCaja_Anulacion(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_ComprobanteCaja_Anulacion";

                      sql_comando.Parameters.Add("@CodComprobanteCaja", SqlDbType.Int).Value = objEntidadBE.CodComprobanteCaja;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;                      
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@ObservacionAnulacion", SqlDbType.VarChar, 2000).Value = objEntidadBE.ObservacionAnulacion;

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

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Anulacion_NotaCredito(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Anulacion_NotaCredito";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
           
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

      public NotaIngresoSalidaCabCE F_Movimientos_CierreMensual(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_Movimientos_CierreMensual";

                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = objEntidadBE.FechaOperacion;

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

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Validar_Edicion(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Validar_Edicion";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.@CodMovimiento;

                      SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 250);
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

      public DataTable F_NotaIngresoSalidaCab_Reemplazar(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Reemplazar";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
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

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Validar_Factura(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Validar_Factura";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;

                      SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 1000);
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

      public DataTable F_NotaIngresoSalidaCab_Impresion_Factura(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Impresion_Factura";
                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
                      sql_comando.Parameters.Add("@CodTipoFormato", SqlDbType.Int).Value = objEntidadBE.CodTipoFormato;
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
      
      public DataTable F_NotaIngresoSalidaCab_ComprobanteEgreso_Imprimir(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_ComprobanteEgreso_Imprimir";
                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
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
      
      public DataTable F_Pagos_Reporte_Pagados(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_Pagos_Reporte_Pagados";

                      if (objEntidadBE.CodEmpresa != 0)
                          sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;

                      if (objEntidadBE.CodCtaCte != 0)
                          sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;

                      if (objEntidadBE.Hasta.ToString("yyyyMMdd") != "19900101")
                      {
                          sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                          sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                      }

                      if (objEntidadBE.CodMoneda != 0)
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
      
      public NotaIngresoSalidaCabCE F_MOVIMIENTOS_ELIMINARAJUSTES(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "PA_MOVIMIENTOS_ELIMINARAJUSTES";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
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
      
      public DataTable F_NotaIngresoSalida_Documentos(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "NotaIngresoSalida_Documentos";

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

      public DataTable F_NOTAINGRESOSALIDACAB_REPORTE_COMPRAS(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "PA_NOTAINGRESOSALIDACAB_REPORTE_COMPRAS";

                      if (objEntidadBE.CodAlmacen > 0)
                          sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                      sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                      if (objEntidadBE.FlagImportacion > -1)
                          sql_comando.Parameters.Add("@FlagImportacion", SqlDbType.Int).Value = objEntidadBE.FlagImportacion;

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

      public DataTable F_NotaIngresoSalidaCab_Select_IMPORTACION(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Select_IMPORTACION";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@CodClasificacion", SqlDbType.Int).Value = objEntidadBE.CodClasificacion;

                      if (objEntidadBE.CodTipoOperacion != 0)
                          sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                      if (objEntidadBE.CodCtaCte != 0)
                          sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;

                      if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                      {
                          sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                          sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                      }

                      if (objEntidadBE.NumeroDoc != "")
                          sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 10).Value = objEntidadBE.NumeroDoc;

                      if (objEntidadBE.CodTipoDocSust != 0)
                          sql_comando.Parameters.Add("@CodTipoDocSust", SqlDbType.Int).Value = objEntidadBE.CodTipoDocSust;

                      if (objEntidadBE.CodEstado != 0)
                          sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;


                      sql_comando.Parameters.Add("@FlagImportacion", SqlDbType.Int).Value = objEntidadBE.FlagImportacion;

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

      public DataTable F_NOTAINGRESOSALIDACAB_IMPRESION_TICKET(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "PA_NOTAINGRESOSALIDACAB_IMPRESION_TICKET";
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

      public DataTable F_NotaIngresoSalidaCab_ComprobanteEgreso_VistaPreliminar(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_ComprobanteEgreso_VistaPreliminar";
                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@CodTipoFormato", SqlDbType.Int).Value = objEntidadBE.CodTipoFormato;
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

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Insert_Convergentes(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              using (SqlConnection sql_conexion = new SqlConnection())
              {
                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {
                      sql_comando.CommandTimeout = 90;

                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Insert";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodTipoDocSust", SqlDbType.Int).Value = objEntidadBE.CodTipoDocSust;
                      sql_comando.Parameters.Add("@SerieDocSust", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDocSust;
                      sql_comando.Parameters.Add("@NumeroDocSust", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDocSust;

                      sql_comando.Parameters.Add("@FechaIngreso", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaIngreso;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaRegistro;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;

                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@ImpSubTotal", SqlDbType.Decimal).Value = objEntidadBE.ImpSubTotal;
                      sql_comando.Parameters.Add("@ImpIgv", SqlDbType.Decimal).Value = objEntidadBE.ImpIGV;

                      sql_comando.Parameters.Add("@ImpTotal", SqlDbType.Decimal).Value = objEntidadBE.ImpTotal;
                      sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                      sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                      sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;

                      sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                      sql_comando.Parameters.Add("@Periodo", SqlDbType.Int).Value = objEntidadBE.Periodo;
                      sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                      sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                      sql_comando.Parameters.Add("@FlagLetra", SqlDbType.Int).Value = objEntidadBE.FlagLetra;
                      sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                      sql_comando.Parameters.Add("@CodClasificacion", SqlDbType.Int).Value = objEntidadBE.CodClasificacion;
                      sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidadBE.CodCategoria;
                      sql_comando.Parameters.Add("@CodSerie", SqlDbType.Int).Value = objEntidadBE.CodSerie;
                      sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                      sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                      sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                      sql_comando.Parameters.Add("@FlagIncluyeIGV", SqlDbType.Int).Value = objEntidadBE.FlagIncluyeIGV;
                      sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;

                      sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                      sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                      sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                      sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                      sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 100).Value = objEntidadBE.RazonSocial;
                      sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                      sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                      sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 300).Value = objEntidadBE.Direccion;
                      sql_comando.Parameters.Add("@Guia", SqlDbType.VarChar, 500).Value = objEntidadBE.Guia;
                      sql_comando.Parameters.Add("@FacturaAntigua", SqlDbType.Int).Value = objEntidadBE.FacturaAntigua;
                      sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;
                      sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 11).Value = objEntidadBE.NroOperacion;
                      sql_comando.Parameters.Add("@Entrega", SqlDbType.VarChar, 500).Value = objEntidadBE.Entrega;
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

      public DataTable F_NOTAINGRESOSALIDACAB_CP_REPORTE(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "PA_NOTAINGRESOSALIDACAB_CP_REPORTE";

                      if (objEntidadBE.CodAlmacen>0)
                            sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      if (objEntidadBE.CodCtaCte > 0)
                            sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      if (objEntidadBE.FlagServicios > 0)
                            sql_comando.Parameters.Add("@FlagServicios", SqlDbType.Int).Value = objEntidadBE.FlagServicios;

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

      public DataTable F_NOTAINGRESOSALIDACAB_REPORTE_CONTABILIDAD_REGISTROCOMPRA(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "PA_NotaIngresoSalidaCab_REPORTE_CONTABILIDAD_REGISTROCOMPRA";

                      if (objEntidadBE.CodAlmacen > 0)
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
      
      public bool F_SUNAT_MarcaDocumento(NotaIngresoSalidaCabCE objEntidadBE)
      {
          var retorno = false;
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
                      sql_comando.CommandText = "pa_SUNAT_MarcaDocumento";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
                      sql_comando.Parameters.Add("@CodEstadoSunat", SqlDbType.Int).Value = objEntidadBE.CodEstadoSunat;
                      sql_comando.ExecuteNonQuery();

                      retorno = true;
                  }
              }
          }
          catch (Exception ex)
          {
              throw ex;
          }
          return retorno;
      }
      
      public DataTable F_SUNAT_ListarParametros(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_SUNAT_ListarParametros";
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
      
      public bool F_SUNAT_ActualizarToken(NotaIngresoSalidaCabCE objEntidadBE)
      {
          var retorno = false;
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
                      sql_comando.CommandText = "pa_SUNAT_ActualizarToken";

                      sql_comando.Parameters.Add("@CodEmprea", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@TokenNuevo", SqlDbType.VarChar, 5000).Value = objEntidadBE.RazonSocial;

                      sql_comando.ExecuteNonQuery();

                      retorno = true;
                  }
              }
          }
          catch (Exception ex)
          {
              throw ex;
          }
          return retorno;
      }

      public NotaIngresoSalidaCabCE F_Eliminacion_NotaIngreso_Gastos(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_Eliminacion_NotaIngreso_Gastos";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 1000).Value = objEntidadBE.Observacion;

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

      public object F_COMPROBANTEDEINGRESO_OBSERVACION(NotaIngresoSalidaCabCE objEntidad)
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
                      sql_comando.CommandText = "PA_COMPROBANTEDEINGRESO_OBSERVACION";

                      sql_comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = objEntidad.Codigo;
                     
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

      public object F_COMPROBANTEDEEGRESO_OBSERVACION(NotaIngresoSalidaCabCE objEntidad)
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
                      sql_comando.CommandText = "PA_COMPROBANTEDEEGRESO_OBSERVACION";

                      sql_comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = objEntidad.Codigo;

                      if (objEntidad.CodTipoDoc != 0)
                      {
                          sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidad.CodTipoDoc;
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

      public object F_Auditoria(NotaIngresoSalidaCabCE objEntidad)
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
                      sql_comando.CommandText = "PA_AUDITORIA_NOTACREDITO";

                      sql_comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = objEntidad.Codigo;

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

      public object F_AUDITORIA_EGRESO(NotaIngresoSalidaCabCE objEntidad)
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
                      sql_comando.CommandText = "PA_AUDITORIA_EGRESO";

                      sql_comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = objEntidad.Codigo;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidad.CodTipoDoc;

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

      public object F_AUDITORIA_INGRESO(NotaIngresoSalidaCabCE objEntidad)
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
                      sql_comando.CommandText = "PA_AUDITORIA_Ingreso";

                      sql_comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = objEntidad.Codigo;

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

      public NotaIngresoSalidaCabCE F_Anulacion_NotaIngreso_Inventario(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_Anulacion_NotaIngreso_Inventario";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@ObservacionAnulacion", SqlDbType.VarChar, 1000).Value = objEntidadBE.ObservacionAnulacion;

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

      public NotaIngresoSalidaCabCE F_Confirmacion_NotaIngreso_Inventario(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Confirmar";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
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
      
      public NotaIngresoSalidaCabCE F_ComprobanteCaja_Actualizar(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_ComprobanteCaja_Actualizar";

                      sql_comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = objEntidadBE.Codigo;
                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 1000).Value = objEntidadBE.Observacion;
                      
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodMotivo", SqlDbType.Int).Value = objEntidadBE.CodMotivo;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;

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
      
      public object F_AUDITORIA_NOTAINGRESO(NotaIngresoSalidaCabCE objEntidad)
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
                      sql_comando.CommandText = "PA_AUDITORIA_NOTADEINGRESO";

                      sql_comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = objEntidad.Codigo;

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

      public object F_NOTADEINGRESO_OBSERVACION(NotaIngresoSalidaCabCE objEntidad)
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
                      sql_comando.CommandText = "PA_NOTADEINGRESO_OBSERVACION";

                      sql_comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = objEntidad.Codigo;

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

      public DataTable F_NOTAINGRESO_OBSERVACION(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalida_Observacion";

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

      public DataTable F_NOTAINGRESO_AUDITORIA(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalida_Auditoria";

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

      public DataTable F_ORDENCOMPRA_OBSERVACION(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "Pa_OrdenCompra_Observacion";

                      sql_comando.Parameters.Add("@CodOrdenCompraCab", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;

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

      public DataTable F_ORDENCOMPRA_AUDITORIA(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "Pa_OrdenCompra_Auditoria";

                      sql_comando.Parameters.Add("@CodOrdenCompraCab", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;

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
      
      public DataTable F_FACTURACOMPRA_OBSERVACION(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_FacturaCompra_Observacion";

                      sql_comando.Parameters.Add("@CodFactura", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;

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

      public DataTable F_FACTURACOMPRA_AUDITORIA(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_FacturaCompra_Auditoria";

                      sql_comando.Parameters.Add("@CodFactura", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;

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

      public DataTable F_NOTACREDITOCOMPRA_OBSERVACION(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaCreditoCompra_Observacion";

                      sql_comando.Parameters.Add("@CodNotaCredito", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;

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

      public DataTable F_NOTACREDITOCOMPRA_AUDITORIA(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaCreditoCompra_Auditoria";

                      sql_comando.Parameters.Add("@CodNotaCredito", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;

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

      public DataTable F_NOTAINGRESOSALIDACAB_REPORTE_CONTABILIDAD_REGISTROCOMPRA_CONCAR(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "PA_NOTAINGRESOSALIDACAB_REPORTE_CONTABILIDAD_REGISTROCOMPRA_CONCAR";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                      sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                      sql_comando.Parameters.Add("@Numero", SqlDbType.Int).Value = objEntidadBE.Numero;

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

      public DataTable F_NotaIngresoSalidaCab_Select_Compras_FACTURA(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Select_Compras_FACTURA";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                      sql_comando.Parameters.Add("@CodClasificacion", SqlDbType.Int).Value = objEntidadBE.CodClasificacion;

                      if (objEntidadBE.CodEmpresa > 0)
                          sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;

                      if (objEntidadBE.CodTipoOperacion > 0)
                          sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                      if (objEntidadBE.CodCtaCte > 0)
                          sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;

                      if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                      {
                          sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                          sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                      }

                      if (objEntidadBE.NumeroDoc != "")
                          sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 10).Value = objEntidadBE.NumeroDoc;

                      if (objEntidadBE.SerieDoc != "")
                          sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                      if (objEntidadBE.CodTipoDocSust != 0)
                          sql_comando.Parameters.Add("@CodTipoDocSust", SqlDbType.Int).Value = objEntidadBE.CodTipoDocSust;

                      if (objEntidadBE.CodEstado != 0)
                          sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;

                      sql_comando.Parameters.Add("@FlagImportacion", SqlDbType.Int).Value = objEntidadBE.FlagImportacion;

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

      public NotaIngresoSalidaCabCE F_Confirmacion_NotaIngreso_Traslados(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Traslados_Confirmar";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
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

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Insert_ORDENCOMPRA(NotaIngresoSalidaCabCE objEntidadBE)
      {
          try
          {
              using (SqlConnection sql_conexion = new SqlConnection())
              {
                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {
                      sql_comando.CommandTimeout = 90;

                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Insert_ORDENCOMPRA";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                      sql_comando.Parameters.Add("@CodTipoDocSust", SqlDbType.Int).Value = objEntidadBE.CodTipoDocSust;
                      sql_comando.Parameters.Add("@SerieDocSust", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDocSust;
                      sql_comando.Parameters.Add("@NumeroDocSust", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDocSust;

                      sql_comando.Parameters.Add("@FechaIngreso", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaIngreso;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                      sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaRegistro;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;

                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                      sql_comando.Parameters.Add("@ImpSubTotal", SqlDbType.Decimal).Value = objEntidadBE.ImpSubTotal;
                      sql_comando.Parameters.Add("@ImpIgv", SqlDbType.Decimal).Value = objEntidadBE.ImpIGV;

                      sql_comando.Parameters.Add("@ImpTotal", SqlDbType.Decimal).Value = objEntidadBE.ImpTotal;
                      sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                      sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                      sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;

                      sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                      sql_comando.Parameters.Add("@Periodo", SqlDbType.Int).Value = objEntidadBE.Periodo;
                      sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                      sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                      sql_comando.Parameters.Add("@FlagLetra", SqlDbType.Int).Value = objEntidadBE.FlagLetra;
                      sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                      sql_comando.Parameters.Add("@CodClasificacion", SqlDbType.Int).Value = objEntidadBE.CodClasificacion;
                      sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidadBE.CodCategoria;
                      sql_comando.Parameters.Add("@CodSerie", SqlDbType.Int).Value = objEntidadBE.CodSerie;
                      sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                      sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                      sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                      sql_comando.Parameters.Add("@FlagIncluyeIGV", SqlDbType.Int).Value = objEntidadBE.FlagIncluyeIGV;
                      sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                      sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                      sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                      sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                      sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                      sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 100).Value = objEntidadBE.RazonSocial;
                      sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                      sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                      sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 300).Value = objEntidadBE.Direccion;
                      sql_comando.Parameters.Add("@Guia", SqlDbType.VarChar, 500).Value = objEntidadBE.Guia;
                      sql_comando.Parameters.Add("@FacturaAntigua", SqlDbType.Int).Value = objEntidadBE.FacturaAntigua;
                      sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;
                      sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 11).Value = objEntidadBE.NroOperacion;
                      sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                      sql_comando.Parameters.Add("@CodTipoCtaCte", SqlDbType.Int).Value = objEntidadBE.CodTipoCtaCte;
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

      public NotaIngresoSalidaCabCE F_Eliminacion_NotaIngreso_Inventario(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_Eliminacion_NotaIngreso_Inventario";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
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

      public DataTable F_NOTAINGRESOSALIDACAB_REPORTE_EXCEL(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "PA_NOTAINGRESOSALIDACAB_REPORTE_EXCEL";

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

      public NotaIngresoSalidaCabCE F_NOTAINGRESOSALIDACAB_ABRIR(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "PA_NOTAINGRESOSALIDACAB_ABRIR";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
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

      public DataTable F_DOCUMENTOVENTACAB_LISTAR_CP(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "PA_DOCUMENTOVENTACAB_LISTAR_CP";

                      if (objEntidadBE.chkDevolucion > 0)
                          sql_comando.Parameters.Add("@FlagDevolucion", SqlDbType.Int).Value = objEntidadBE.chkDevolucion;

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

      public NotaIngresoSalidaCabCE F_PromedioVentas(NotaIngresoSalidaCabCE objEntidad)
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
                      sql_comando.CommandText = "PA_PromedioVentas";

                      sql_comando.Parameters.Add("@Periodo", SqlDbType.Int).Value = objEntidad.Periodo;
                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidad.CodAlmacen;
                      sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidad.CodProducto;

                      SqlParameter Promedio = sql_comando.Parameters.Add("@Promedio", SqlDbType.VarChar, 100);
                      Promedio.Direction = ParameterDirection.Output;

                      sql_comando.ExecuteNonQuery();

                      objEntidad.Promedio = Convert.ToDecimal(Promedio.Value.ToString());

                      return objEntidad;
                  }
              }
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Validar_Factura_Salcedo(NotaIngresoSalidaCabCE objEntidad)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Validar_Factura";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidad.CodMovimiento;

                      SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 1000);
                      MsgError.Direction = ParameterDirection.Output;

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
      }

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Update_Salcedo(NotaIngresoSalidaCabCE objEntidad)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Update";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidad.CodMovimiento;
                      sql_comando.Parameters.Add("@Periodo", SqlDbType.Int).Value = objEntidad.Periodo;

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



      }
      public DataTable F_NotaIngresoSalidaCab_Select_Compras_OC_Salcedo(NotaIngresoSalidaCabCE objEntidad)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Select_Compras_OC";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidad.CodAlmacen;
                      if (objEntidad.CodEmpresa > 0)
                          sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidad.CodEmpresa;
                      sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidad.CodTipoOperacion;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidad.CodTipoDoc;

                      if (objEntidad.SerieDoc != "TODOS")
                          sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidad.SerieDoc;

                      if (objEntidad.CodCtaCte != 0)
                          sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidad.CodCtaCte;

                      if (objEntidad.CodEstado != 0)
                          sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidad.CodEstado;

                      if (objEntidad.Desde.ToString("yyyyMMdd") != "19900101")
                      {
                          sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidad.Desde.ToString("yyyyMMdd");
                          sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidad.Hasta.ToString("yyyyMMdd");
                      }

                      if (objEntidad.NumeroDoc != "")
                          sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidad.NumeroDoc;

                      if (objEntidad.CodTipoDocSust != 0)
                          sql_comando.Parameters.Add("@CodTipoDocSust", SqlDbType.Int).Value = objEntidad.CodTipoDocSust;
                      
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

      public DataTable F_NotaIngresoSalidaCab_Reemplazar_Salcedo(NotaIngresoSalidaCabCE objEntidad)
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
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Reemplazar";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidad.CodMovimiento;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidad.CodUsuario;

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

      public NotaIngresoSalidaCabCE F_NotaIngresoSalidaCab_Insert_ORDENCOMPRA_Salcedo(NotaIngresoSalidaCabCE objEntidad)
      {
          try
          {
              using (SqlConnection sql_conexion = new SqlConnection())
              {
                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {
                      sql_comando.CommandTimeout = 90;

                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_NotaIngresoSalidaCab_Insert_ORDENCOMPRA";

                      sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidad.CodAlmacen;
                      sql_comando.Parameters.Add("@CodTipoDocSust", SqlDbType.Int).Value = objEntidad.CodTipoDocSust;
                      sql_comando.Parameters.Add("@SerieDocSust", SqlDbType.VarChar, 4).Value = objEntidad.SerieDocSust;
                      sql_comando.Parameters.Add("@NumeroDocSust", SqlDbType.VarChar, 8).Value = objEntidad.NumeroDocSust;

                      sql_comando.Parameters.Add("@FechaIngreso", SqlDbType.SmallDateTime).Value = objEntidad.FechaIngreso;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidad.CodUsuario;
                      sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidad.FechaRegistro;
                      sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidad.CodMoneda;

                      sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidad.CodCtaCte;
                      sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidad.CodEmpresa;
                      sql_comando.Parameters.Add("@ImpSubTotal", SqlDbType.Decimal).Value = objEntidad.ImpSubTotal;
                      sql_comando.Parameters.Add("@ImpIgv", SqlDbType.Decimal).Value = objEntidad.ImpIGV;

                      sql_comando.Parameters.Add("@ImpTotal", SqlDbType.Decimal).Value = objEntidad.ImpTotal;
                      sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidad.CodFormaPago;
                      sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidad.Descuento;
                      sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidad.TipoCambio;

                      sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidad.CodTasa;
                      sql_comando.Parameters.Add("@Periodo", SqlDbType.Int).Value = objEntidad.Periodo;
                      sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidad.Vencimiento;
                      sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidad.CodDetalle;
                      sql_comando.Parameters.Add("@FlagLetra", SqlDbType.Int).Value = objEntidad.FlagLetra;
                      sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidad.TasaIgv;
                      sql_comando.Parameters.Add("@CodClasificacion", SqlDbType.Int).Value = objEntidad.CodClasificacion;
                      sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidad.CodCategoria;
                      sql_comando.Parameters.Add("@CodSerie", SqlDbType.Int).Value = objEntidad.CodSerie;
                      sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidad.SubTotal;
                      sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidad.Igv;
                      sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidad.Total;
                      sql_comando.Parameters.Add("@FlagIncluyeIGV", SqlDbType.Int).Value = objEntidad.FlagIncluyeIGV;
                      sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidad.CodFacturaAnterior;
                      sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidad.CodDireccion;
                      sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidad.CodDepartamento;
                      sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidad.CodProvincia;
                      sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidad.CodDistrito;
                      sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 100).Value = objEntidad.RazonSocial;
                      sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidad.NroDni;
                      sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidad.NroRuc;
                      sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 300).Value = objEntidad.Direccion;
                      sql_comando.Parameters.Add("@Guia", SqlDbType.VarChar, 500).Value = objEntidad.Guia;
                      sql_comando.Parameters.Add("@FacturaAntigua", SqlDbType.Int).Value = objEntidad.FacturaAntigua;
                      sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidad.CodCajaFisica;
                      sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 11).Value = objEntidad.NroOperacion;
                      sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidad.CodTipoCliente;
                      sql_comando.Parameters.Add("@CodTipoCtaCte", SqlDbType.Int).Value = objEntidad.CodTipoCtaCte;
                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                      MsgError.Direction = ParameterDirection.Output;

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



      }

      public NotaIngresoSalidaCabCE F_Eliminacion_NotaIngreso_Salcedo(NotaIngresoSalidaCabCE objEntidad)
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
                      sql_comando.CommandText = "pa_Eliminacion_NotaIngreso";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidad.CodMovimiento;
                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                      MsgError.Direction = ParameterDirection.Output;

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
      }

      public NotaIngresoSalidaCabCE F_Anulacion_NotaIngreso_Salcedo(NotaIngresoSalidaCabCE objEntidad)
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
                      sql_comando.CommandText = "pa_Anulacion_NotaIngreso";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidad.CodMovimiento;
                      sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidad.CodUsuario;
                      sql_comando.Parameters.Add("@ObservacionAnulacion", SqlDbType.VarChar, 1000).Value = objEntidad.Observacion;

                      SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                      MsgError.Direction = ParameterDirection.Output;

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



      }

      //salcedo
      public NotaIngresoSalidaCabCE F_MOVIMIENTOS_ELIMINARAJUSTES_SALCEDO(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "PA_MOVIMIENTOS_ELIMINARAJUSTES";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodMovimiento;
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

      public DataTable F_Utilidad_Bruta(NotaIngresoSalidaCabCE objEntidadBE)
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
                      //sql_comando.CommandText = "pa_FacturasXPagar_Reporte";
                      sql_comando.CommandText = "pa_Utilidad_Bruta";

                      if (objEntidadBE.CodEmpresa != 0)
                          sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;


                      if (objEntidadBE.Hasta.ToString("yyyyMMdd") != "19900101")
                      {
                          sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                          sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                      }

                      if (objEntidadBE.CodAlmacen != 0)
                          sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.VarChar, 10000).Value = objEntidadBE.CodAlmacen;

                      if (objEntidadBE.CodProducto != 0)
                          sql_comando.Parameters.Add("@CodProducto", SqlDbType.VarChar, 10000).Value = objEntidadBE.CodProducto;

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

      public DataTable F_Notaingreso_ListarXEstado(NotaIngresoSalidaCabCE objEntidadBE)
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
                      sql_comando.CommandText = "pa_notaingresosalidacab_ListarXEstado";

                      sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
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

      public DataTable F_NotaingresoCab_ObtenerXNumero(NotaIngresoSalidaCabCE objEntidad)
      {
          DataTable dta_consulta = null;

          try
          {

              using (SqlConnection sql_conexion = new SqlConnection())
              {

                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings[objEntidad.Conexion].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {

                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_NotaingresosalidaCab_ListarXNumero";

                      sql_comando.Parameters.Add("@NumeroNotaingreso", SqlDbType.Int).Value = objEntidad.Numero;
                      sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidad.NroRuc;
                      sql_comando.Parameters.Add("@CodDestino", SqlDbType.Int).Value = objEntidad.destino;
                      sql_comando.Parameters.Add("@Serie", SqlDbType.VarChar, 4).Value = objEntidad.Serie;
                      sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidad.CodTipoDoc;

                      dta_consulta = new DataTable();

                      dta_consulta.Load(sql_comando.ExecuteReader());

                      return dta_consulta;
                  }
              }
          }
          catch (Exception ex)
          {

              objEntidad.MsgError = ex.ToString();
              throw ex;

          }

          finally { dta_consulta.Dispose(); }

      }


      public DataTable F_NotaingresoCab_ListarXCodigo(NotaIngresoSalidaCabCE objEntidad)
      {
          DataTable dta_consulta = null;

          try
          {

              using (SqlConnection sql_conexion = new SqlConnection())
              {

                  sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings[objEntidad.Conexion].ConnectionString;
                  sql_conexion.Open();

                  using (SqlCommand sql_comando = new SqlCommand())
                  {

                      sql_comando.Connection = sql_conexion;
                      sql_comando.CommandType = CommandType.StoredProcedure;
                      sql_comando.CommandText = "pa_NotaingresosalidaDet_ListarXCodigo";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidad.CodMovimiento;

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


      public DataTable F_NotaingresoCab_ObtenerXIDCompra(NotaIngresoSalidaCabCE objEntidad)
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
                      sql_comando.CommandText = "pa_NotaingresosalidaCab_ListarxIDCompra";

                      sql_comando.Parameters.Add("@ID", SqlDbType.Int).Value = objEntidad.ID;
                      

                      dta_consulta = new DataTable();

                      dta_consulta.Load(sql_comando.ExecuteReader());

                      return dta_consulta;
                  }
              }
          }
          catch (Exception ex)
          {

              objEntidad.MsgError = ex.ToString();
              throw ex;

          }

          finally { dta_consulta.Dispose(); }

      }

      public DataTable F_NotaingresoCab_ListarXCodigoCompra(NotaIngresoSalidaCabCE objEntidad)
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
                      sql_comando.CommandText = "pa_NotaingresosalidaDet_ListarXCodigo";

                      sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidad.CodMovimiento;

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
