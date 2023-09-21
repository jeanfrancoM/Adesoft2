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
    public class ProformaCabCD
    {
        public ProformaCabCE F_Proformas_Insert(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_Insert";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.Serie;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@FlagIgv", SqlDbType.Int).Value = objEntidadBE.FlagIgv;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@Referencia", SqlDbType.VarChar, 250).Value = objEntidadBE.Referencia;
                        sql_comando.Parameters.Add("@Atencion", SqlDbType.VarChar, 250).Value = objEntidadBE.Atencion;
                        sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@CodProformaAnterior", SqlDbType.Int).Value = objEntidadBE.CodProformaAnterior;
                        sql_comando.Parameters.Add("@Celular", SqlDbType.VarChar, 50).Value = objEntidadBE.Celular;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 250).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;
                        sql_comando.Parameters.Add("@CorreoAtencion", SqlDbType.VarChar, 500).Value = objEntidadBE.CorreoAtencion;
                        sql_comando.Parameters.Add("@LugarEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.LugarEntrega;
                        sql_comando.Parameters.Add("@TiempoEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.TiempoEntrega;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;
                        sql_comando.Parameters.Add("@FechaIngreso", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaIngreso;
                        sql_comando.Parameters.Add("@FechaSalida", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaSalida;
         

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter Numero = sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8);
                        Numero.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.Codigo = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.Numero = Numero.Value.ToString();
                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProformaCabCE F_Proformas_Insert_Karina(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_Insert";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.Serie;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@FlagIgv", SqlDbType.Int).Value = objEntidadBE.FlagIgv;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@Referencia", SqlDbType.VarChar, 250).Value = objEntidadBE.Referencia;
                        sql_comando.Parameters.Add("@Atencion", SqlDbType.VarChar, 250).Value = objEntidadBE.Atencion;
                        sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@CodProformaAnterior", SqlDbType.Int).Value = objEntidadBE.CodProformaAnterior;
                        sql_comando.Parameters.Add("@Celular", SqlDbType.VarChar, 50).Value = objEntidadBE.Celular;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 250).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;
                        sql_comando.Parameters.Add("@CorreoAtencion", SqlDbType.VarChar, 500).Value = objEntidadBE.CorreoAtencion;
                        sql_comando.Parameters.Add("@LugarEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.LugarEntrega;
                        sql_comando.Parameters.Add("@TiempoEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.TiempoEntrega;
                        //sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter Numero = sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8);
                        Numero.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.Codigo = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.Numero = Numero.Value.ToString();
                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProformaCabCE F_Proformas_Insert_Karina_App(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_Insert_App";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.Serie;
                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.Numero;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@FlagIgv", SqlDbType.Int).Value = objEntidadBE.FlagIgv;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@Celular", SqlDbType.VarChar, 50).Value = objEntidadBE.Celular;
                        sql_comando.Parameters.Add("@Detalle", SqlDbType.VarChar, 8000).Value = objEntidadBE.Detalle;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodigoUbigeo", SqlDbType.VarChar, 50).Value = objEntidadBE.Ubigeo;
                        sql_comando.Parameters.Add("@CodigoPedidoApp", SqlDbType.VarChar, 200).Value = objEntidadBE.CodigoPedidoApp;

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

        public ProformaCabCE F_Proformas_Insert_Edicion_Tractos(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_Insert_Edicion";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.Serie;
                        sql_comando.Parameters.Add("@NumeroDocAnterior", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroAnterior;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@flagCodigo", SqlDbType.Int).Value = objEntidadBE.flagCodigo;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@FlagIgv", SqlDbType.Int).Value = objEntidadBE.FlagIgv;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@Referencia", SqlDbType.VarChar, 250).Value = objEntidadBE.Referencia;
                        sql_comando.Parameters.Add("@Atencion", SqlDbType.VarChar, 250).Value = objEntidadBE.Atencion;
                        sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@CodProformaAnterior", SqlDbType.Int).Value = objEntidadBE.CodProformaAnterior;
                        sql_comando.Parameters.Add("@Celular", SqlDbType.VarChar, 50).Value = objEntidadBE.Celular;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 250).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;
                        sql_comando.Parameters.Add("@CorreoAtencion", SqlDbType.VarChar, 500).Value = objEntidadBE.CorreoAtencion;
                        sql_comando.Parameters.Add("@LugarEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.LugarEntrega;
                        sql_comando.Parameters.Add("@TiempoEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.TiempoEntrega;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;
                        sql_comando.Parameters.Add("@Gratuito", SqlDbType.Decimal).Value = objEntidadBE.Gratuito;
                        sql_comando.Parameters.Add("@UsuarioPermiso", SqlDbType.VarChar, 160).Value = objEntidadBE.UsuarioPermiso;
                        sql_comando.Parameters.Add("@ClavePermiso", SqlDbType.VarChar, 60).Value = objEntidadBE.ClavePermiso;
                        sql_comando.Parameters.Add("@ObservacionPermiso", SqlDbType.VarChar, 300).Value = objEntidadBE.ObservacionPermiso;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter Numero = sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8);
                        Numero.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.Codigo = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.Numero = Numero.Value.ToString();
                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }



        public ProformaCabCE F_Proformas_Insert_Tractos(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_Insert";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.Serie;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@flagCodigo", SqlDbType.Int).Value = objEntidadBE.flagCodigo;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@FlagIgv", SqlDbType.Int).Value = objEntidadBE.FlagIgv;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@Referencia", SqlDbType.VarChar, 250).Value = objEntidadBE.Referencia;
                        sql_comando.Parameters.Add("@Atencion", SqlDbType.VarChar, 250).Value = objEntidadBE.Atencion;
                        sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@CodProformaAnterior", SqlDbType.Int).Value = objEntidadBE.CodProformaAnterior;
                        sql_comando.Parameters.Add("@Celular", SqlDbType.VarChar, 50).Value = objEntidadBE.Celular;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 250).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;
                        sql_comando.Parameters.Add("@CorreoAtencion", SqlDbType.VarChar, 500).Value = objEntidadBE.CorreoAtencion;
                        sql_comando.Parameters.Add("@LugarEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.LugarEntrega;
                        sql_comando.Parameters.Add("@TiempoEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.TiempoEntrega;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;
                        sql_comando.Parameters.Add("@Gratuito", SqlDbType.Decimal).Value = objEntidadBE.Gratuito;
                        sql_comando.Parameters.Add("@UsuarioPermiso", SqlDbType.VarChar, 160).Value = objEntidadBE.UsuarioPermiso;
                        sql_comando.Parameters.Add("@ClavePermiso", SqlDbType.VarChar, 60).Value = objEntidadBE.ClavePermiso;
                        sql_comando.Parameters.Add("@ObservacionPermiso", SqlDbType.VarChar, 300).Value = objEntidadBE.ObservacionPermiso;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter Numero = sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8);
                        Numero.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.Codigo = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.Numero = Numero.Value.ToString();
                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProformaCabCE F_ProformasVehicular_Insert_Tractos(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCabVehicular_Insert";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.Serie;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@flagCodigo", SqlDbType.Int).Value = objEntidadBE.flagCodigo;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@FlagIgv", SqlDbType.Int).Value = objEntidadBE.FlagIgv;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@Referencia", SqlDbType.VarChar, 250).Value = objEntidadBE.Referencia;
                        sql_comando.Parameters.Add("@Atencion", SqlDbType.VarChar, 250).Value = objEntidadBE.Atencion;
                        sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@CodProformaAnterior", SqlDbType.Int).Value = objEntidadBE.CodProformaAnterior;
                        sql_comando.Parameters.Add("@Celular", SqlDbType.VarChar, 50).Value = objEntidadBE.Celular;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 250).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;
                        sql_comando.Parameters.Add("@CorreoAtencion", SqlDbType.VarChar, 500).Value = objEntidadBE.CorreoAtencion;
                        sql_comando.Parameters.Add("@LugarEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.LugarEntrega;
                        sql_comando.Parameters.Add("@TiempoEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.TiempoEntrega;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;
                        sql_comando.Parameters.Add("@Gratuito", SqlDbType.Decimal).Value = objEntidadBE.Gratuito;
                        sql_comando.Parameters.Add("@UsuarioPermiso", SqlDbType.VarChar, 160).Value = objEntidadBE.UsuarioPermiso;
                        sql_comando.Parameters.Add("@ClavePermiso", SqlDbType.VarChar, 60).Value = objEntidadBE.ClavePermiso;
                        sql_comando.Parameters.Add("@ObservacionPermiso", SqlDbType.VarChar, 300).Value = objEntidadBE.ObservacionPermiso;

                        sql_comando.Parameters.Add("@CodTipoMantenimiento", SqlDbType.Int).Value = objEntidadBE.CodTipoMantenimiento;
                        sql_comando.Parameters.Add("@Horometraje", SqlDbType.Decimal).Value = objEntidadBE.Horometro;
                        sql_comando.Parameters.Add("@CodVehiculo", SqlDbType.Int).Value = objEntidadBE.CodVehiculo;
                        sql_comando.Parameters.Add("@Kilometros", SqlDbType.Decimal).Value = objEntidadBE.Kilometraje;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter Numero = sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8);
                        Numero.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.Codigo = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.Numero = Numero.Value.ToString();
                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ProformaCabCE F_ProformasVehicular_Insert_Edicion_Tractos(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCabVehicular_Insert_Edicion";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.Serie;
                        sql_comando.Parameters.Add("@NumeroDocAnterior", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroAnterior;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@flagCodigo", SqlDbType.Int).Value = objEntidadBE.flagCodigo;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@FlagIgv", SqlDbType.Int).Value = objEntidadBE.FlagIgv;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@Referencia", SqlDbType.VarChar, 250).Value = objEntidadBE.Referencia;
                        sql_comando.Parameters.Add("@Atencion", SqlDbType.VarChar, 250).Value = objEntidadBE.Atencion;
                        sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@CodProformaAnterior", SqlDbType.Int).Value = objEntidadBE.CodProformaAnterior;
                        sql_comando.Parameters.Add("@Celular", SqlDbType.VarChar, 50).Value = objEntidadBE.Celular;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 250).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;
                        sql_comando.Parameters.Add("@CorreoAtencion", SqlDbType.VarChar, 500).Value = objEntidadBE.CorreoAtencion;
                        sql_comando.Parameters.Add("@LugarEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.LugarEntrega;
                        sql_comando.Parameters.Add("@TiempoEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.TiempoEntrega;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;
                        sql_comando.Parameters.Add("@Gratuito", SqlDbType.Decimal).Value = objEntidadBE.Gratuito;
                        sql_comando.Parameters.Add("@UsuarioPermiso", SqlDbType.VarChar, 160).Value = objEntidadBE.UsuarioPermiso;
                        sql_comando.Parameters.Add("@ClavePermiso", SqlDbType.VarChar, 60).Value = objEntidadBE.ClavePermiso;
                        sql_comando.Parameters.Add("@ObservacionPermiso", SqlDbType.VarChar, 300).Value = objEntidadBE.ObservacionPermiso;

                        sql_comando.Parameters.Add("@CodTipoMantenimiento", SqlDbType.Int).Value = objEntidadBE.CodTipoMantenimiento;
                        sql_comando.Parameters.Add("@Horometraje", SqlDbType.Decimal).Value = objEntidadBE.Horometro;
                        sql_comando.Parameters.Add("@CodVehiculo", SqlDbType.Int).Value = objEntidadBE.CodVehiculo;
                        sql_comando.Parameters.Add("@Kilometros", SqlDbType.Decimal).Value = objEntidadBE.Kilometraje;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter Numero = sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8);
                        Numero.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.Codigo = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.Numero = Numero.Value.ToString();
                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }


        public ProformaCabCE F_Proformas_Insert_Alvarado(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_Insert";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.Serie;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@flagCodigo", SqlDbType.Int).Value = objEntidadBE.flagCodigo;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@FlagIgv", SqlDbType.Int).Value = objEntidadBE.FlagIgv;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@Referencia", SqlDbType.VarChar, 250).Value = objEntidadBE.Referencia;
                        sql_comando.Parameters.Add("@Atencion", SqlDbType.VarChar, 250).Value = objEntidadBE.Atencion;
                        sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@CodProformaAnterior", SqlDbType.Int).Value = objEntidadBE.CodProformaAnterior;
                        sql_comando.Parameters.Add("@Celular", SqlDbType.VarChar, 50).Value = objEntidadBE.Celular;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 250).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;
                        sql_comando.Parameters.Add("@CorreoAtencion", SqlDbType.VarChar, 500).Value = objEntidadBE.CorreoAtencion;
                        sql_comando.Parameters.Add("@LugarEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.LugarEntrega;
                        sql_comando.Parameters.Add("@TiempoEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.TiempoEntrega;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;
                        sql_comando.Parameters.Add("@Gratuito", SqlDbType.Decimal).Value = objEntidadBE.Gratuito;
                        sql_comando.Parameters.Add("@UsuarioPermiso", SqlDbType.VarChar, 160).Value = objEntidadBE.UsuarioPermiso;
                        sql_comando.Parameters.Add("@ClavePermiso", SqlDbType.VarChar, 60).Value = objEntidadBE.ClavePermiso;
                        sql_comando.Parameters.Add("@ObservacionPermiso", SqlDbType.VarChar, 300).Value = objEntidadBE.ObservacionPermiso;
                    
                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter Numero = sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8);
                        Numero.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.Codigo = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.Numero = Numero.Value.ToString();
                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProformaCabCE F_Proformas_Insert_Fundidora(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_Insert";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.Serie;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@flagCodigo", SqlDbType.Int).Value = objEntidadBE.flagCodigo;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@FlagIgv", SqlDbType.Int).Value = objEntidadBE.FlagIgv;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@Referencia", SqlDbType.VarChar, 250).Value = objEntidadBE.Referencia;
                        sql_comando.Parameters.Add("@Atencion", SqlDbType.VarChar, 250).Value = objEntidadBE.Atencion;
                        sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@CodProformaAnterior", SqlDbType.Int).Value = objEntidadBE.CodProformaAnterior;
                        sql_comando.Parameters.Add("@Celular", SqlDbType.VarChar, 50).Value = objEntidadBE.Celular;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 250).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;
                        sql_comando.Parameters.Add("@CorreoAtencion", SqlDbType.VarChar, 500).Value = objEntidadBE.CorreoAtencion;
                        sql_comando.Parameters.Add("@LugarEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.LugarEntrega;
                        sql_comando.Parameters.Add("@TiempoEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.TiempoEntrega;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;
                        sql_comando.Parameters.Add("@Gratuito", SqlDbType.Decimal).Value = objEntidadBE.Gratuito;
                        sql_comando.Parameters.Add("@UsuarioPermiso", SqlDbType.VarChar, 160).Value = objEntidadBE.UsuarioPermiso;
                        sql_comando.Parameters.Add("@ClavePermiso", SqlDbType.VarChar, 60).Value = objEntidadBE.ClavePermiso;
                        sql_comando.Parameters.Add("@ObservacionPermiso", SqlDbType.VarChar, 300).Value = objEntidadBE.ObservacionPermiso;
                        sql_comando.Parameters.Add("@FPago", SqlDbType.VarChar, 2000).Value = objEntidadBE.FPago;
                        sql_comando.Parameters.Add("@FEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.FEntrega;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter Numero = sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8);
                        Numero.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.Codigo = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.Numero = Numero.Value.ToString();
                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProformaCabCE F_Proformas_Insert_Povis(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_Insert";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.Serie;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@FlagIgv", SqlDbType.Int).Value = objEntidadBE.FlagIgv;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@Referencia", SqlDbType.VarChar, 250).Value = objEntidadBE.Referencia;
                        sql_comando.Parameters.Add("@Atencion", SqlDbType.VarChar, 250).Value = objEntidadBE.Atencion;
                        sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@CodProformaAnterior", SqlDbType.Int).Value = objEntidadBE.CodProformaAnterior;
                        sql_comando.Parameters.Add("@Celular", SqlDbType.VarChar, 50).Value = objEntidadBE.Celular;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 250).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;
                        sql_comando.Parameters.Add("@CorreoAtencion", SqlDbType.VarChar, 500).Value = objEntidadBE.CorreoAtencion;
                        sql_comando.Parameters.Add("@LugarEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.LugarEntrega;
                        sql_comando.Parameters.Add("@TiempoEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.TiempoEntrega;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter Numero = sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8);
                        Numero.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.Codigo = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.Numero = Numero.Value.ToString();
                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProformaCabCE F_Proformas_Insert_Roman(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_Insert";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.Serie;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@FlagIgv", SqlDbType.Int).Value = objEntidadBE.FlagIgv;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@Referencia", SqlDbType.VarChar, 250).Value = objEntidadBE.Referencia;
                        sql_comando.Parameters.Add("@Atencion", SqlDbType.VarChar, 250).Value = objEntidadBE.Atencion;
                        sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@CodProformaAnterior", SqlDbType.Int).Value = objEntidadBE.CodProformaAnterior;
                        sql_comando.Parameters.Add("@Celular", SqlDbType.VarChar, 50).Value = objEntidadBE.Celular;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 250).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        //sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;
                        //sql_comando.Parameters.Add("@CorreoAtencion", SqlDbType.VarChar, 500).Value = objEntidadBE.CorreoAtencion;
                        //sql_comando.Parameters.Add("@LugarEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.LugarEntrega;
                        //sql_comando.Parameters.Add("@TiempoEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.TiempoEntrega;
                        //sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter Numero = sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8);
                        Numero.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.Codigo = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.Numero = Numero.Value.ToString();
                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProformaCabCE F_Proformas_Insert_Edicion(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_Insert_Edicion";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.Serie;
                        sql_comando.Parameters.Add("@NumeroDocAnterior", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroAnterior;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@FlagIgv", SqlDbType.Int).Value = objEntidadBE.FlagIgv;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@Referencia", SqlDbType.VarChar, 250).Value = objEntidadBE.Referencia;
                        sql_comando.Parameters.Add("@Atencion", SqlDbType.VarChar, 250).Value = objEntidadBE.Atencion;
                        sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@CodProformaAnterior", SqlDbType.Int).Value = objEntidadBE.CodProformaAnterior;
                        sql_comando.Parameters.Add("@Celular", SqlDbType.VarChar, 50).Value = objEntidadBE.Celular;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 250).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;
                        sql_comando.Parameters.Add("@CorreoAtencion", SqlDbType.VarChar, 500).Value = objEntidadBE.CorreoAtencion;
                        sql_comando.Parameters.Add("@LugarEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.LugarEntrega;
                        sql_comando.Parameters.Add("@TiempoEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.TiempoEntrega;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;
                        sql_comando.Parameters.Add("@FechaIngreso", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaIngreso;
                        sql_comando.Parameters.Add("@FechaSalida", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaSalida;
                 

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter Numero = sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8);
                        Numero.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.Codigo = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.Numero = Numero.Value.ToString();
                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public ProformaCabCE F_Proformas_Insert_Edicion_Karina(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_Insert_Edicion";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.Serie;
                        sql_comando.Parameters.Add("@NumeroDocAnterior", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroAnterior;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@FlagIgv", SqlDbType.Int).Value = objEntidadBE.FlagIgv;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@Referencia", SqlDbType.VarChar, 250).Value = objEntidadBE.Referencia;
                        sql_comando.Parameters.Add("@Atencion", SqlDbType.VarChar, 250).Value = objEntidadBE.Atencion;
                        sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@CodProformaAnterior", SqlDbType.Int).Value = objEntidadBE.CodProformaAnterior;
                        sql_comando.Parameters.Add("@Celular", SqlDbType.VarChar, 50).Value = objEntidadBE.Celular;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 250).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;
                        sql_comando.Parameters.Add("@CorreoAtencion", SqlDbType.VarChar, 500).Value = objEntidadBE.CorreoAtencion;
                        sql_comando.Parameters.Add("@LugarEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.LugarEntrega;
                        sql_comando.Parameters.Add("@TiempoEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.TiempoEntrega;
                        //sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter Numero = sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8);
                        Numero.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.Codigo = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.Numero = Numero.Value.ToString();
                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public ProformaCabCE F_Proformas_Insert_Edicion_Alvarado(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_Insert_Edicion";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.Serie;
                        sql_comando.Parameters.Add("@NumeroDocAnterior", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroAnterior;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@flagCodigo", SqlDbType.Int).Value = objEntidadBE.flagCodigo;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@FlagIgv", SqlDbType.Int).Value = objEntidadBE.FlagIgv;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@Referencia", SqlDbType.VarChar, 250).Value = objEntidadBE.Referencia;
                        sql_comando.Parameters.Add("@Atencion", SqlDbType.VarChar, 250).Value = objEntidadBE.Atencion;
                        sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@CodProformaAnterior", SqlDbType.Int).Value = objEntidadBE.CodProformaAnterior;
                        sql_comando.Parameters.Add("@Celular", SqlDbType.VarChar, 50).Value = objEntidadBE.Celular;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 250).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;
                        sql_comando.Parameters.Add("@CorreoAtencion", SqlDbType.VarChar, 500).Value = objEntidadBE.CorreoAtencion;
                        sql_comando.Parameters.Add("@LugarEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.LugarEntrega;
                        sql_comando.Parameters.Add("@TiempoEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.TiempoEntrega;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;
                        sql_comando.Parameters.Add("@Gratuito", SqlDbType.Decimal).Value = objEntidadBE.Gratuito;
                        sql_comando.Parameters.Add("@UsuarioPermiso", SqlDbType.VarChar, 160).Value = objEntidadBE.UsuarioPermiso;
                        sql_comando.Parameters.Add("@ClavePermiso", SqlDbType.VarChar, 60).Value = objEntidadBE.ClavePermiso;
                        sql_comando.Parameters.Add("@ObservacionPermiso", SqlDbType.VarChar, 300).Value = objEntidadBE.ObservacionPermiso;
                    
                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter Numero = sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8);
                        Numero.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.Codigo = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.Numero = Numero.Value.ToString();
                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public ProformaCabCE F_Proformas_Insert_Edicion_Fundidora(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_Insert_Edicion";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.Serie;
                        sql_comando.Parameters.Add("@NumeroDocAnterior", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroAnterior;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@flagCodigo", SqlDbType.Int).Value = objEntidadBE.flagCodigo;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@FlagIgv", SqlDbType.Int).Value = objEntidadBE.FlagIgv;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@Referencia", SqlDbType.VarChar, 250).Value = objEntidadBE.Referencia;
                        sql_comando.Parameters.Add("@Atencion", SqlDbType.VarChar, 250).Value = objEntidadBE.Atencion;
                        sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@CodProformaAnterior", SqlDbType.Int).Value = objEntidadBE.CodProformaAnterior;
                        sql_comando.Parameters.Add("@Celular", SqlDbType.VarChar, 50).Value = objEntidadBE.Celular;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 250).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;
                        sql_comando.Parameters.Add("@CorreoAtencion", SqlDbType.VarChar, 500).Value = objEntidadBE.CorreoAtencion;
                        sql_comando.Parameters.Add("@LugarEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.LugarEntrega;
                        sql_comando.Parameters.Add("@TiempoEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.TiempoEntrega;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;
                        sql_comando.Parameters.Add("@Gratuito", SqlDbType.Decimal).Value = objEntidadBE.Gratuito;
                        sql_comando.Parameters.Add("@UsuarioPermiso", SqlDbType.VarChar, 160).Value = objEntidadBE.UsuarioPermiso;
                        sql_comando.Parameters.Add("@ClavePermiso", SqlDbType.VarChar, 60).Value = objEntidadBE.ClavePermiso;
                        sql_comando.Parameters.Add("@ObservacionPermiso", SqlDbType.VarChar, 300).Value = objEntidadBE.ObservacionPermiso;
                        sql_comando.Parameters.Add("@FEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.FEntrega;
                        sql_comando.Parameters.Add("@FPago", SqlDbType.VarChar, 2000).Value = objEntidadBE.FPago;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter Numero = sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8);
                        Numero.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.Codigo = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.Numero = Numero.Value.ToString();
                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public ProformaCabCE F_Proformas_Insert_Edicion_Povis(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_Insert_Edicion";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.Serie;
                        sql_comando.Parameters.Add("@NumeroDocAnterior", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroAnterior;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@FlagIgv", SqlDbType.Int).Value = objEntidadBE.FlagIgv;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@Referencia", SqlDbType.VarChar, 250).Value = objEntidadBE.Referencia;
                        sql_comando.Parameters.Add("@Atencion", SqlDbType.VarChar, 250).Value = objEntidadBE.Atencion;
                        sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@CodProformaAnterior", SqlDbType.Int).Value = objEntidadBE.CodProformaAnterior;
                        sql_comando.Parameters.Add("@Celular", SqlDbType.VarChar, 50).Value = objEntidadBE.Celular;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 250).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;
                        sql_comando.Parameters.Add("@CorreoAtencion", SqlDbType.VarChar, 500).Value = objEntidadBE.CorreoAtencion;
                        sql_comando.Parameters.Add("@LugarEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.LugarEntrega;
                        sql_comando.Parameters.Add("@TiempoEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.TiempoEntrega;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter Numero = sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8);
                        Numero.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.Codigo = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.Numero = Numero.Value.ToString();
                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public ProformaCabCE F_Proformas_Insert_Edicion_Roman(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_Insert_Edicion";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.Serie;
                        sql_comando.Parameters.Add("@NumeroDocAnterior", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroAnterior;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@FlagIgv", SqlDbType.Int).Value = objEntidadBE.FlagIgv;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@Referencia", SqlDbType.VarChar, 250).Value = objEntidadBE.Referencia;
                        sql_comando.Parameters.Add("@Atencion", SqlDbType.VarChar, 250).Value = objEntidadBE.Atencion;
                        sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@CodProformaAnterior", SqlDbType.Int).Value = objEntidadBE.CodProformaAnterior;
                        sql_comando.Parameters.Add("@Celular", SqlDbType.VarChar, 50).Value = objEntidadBE.Celular;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 250).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        //sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;
                        //sql_comando.Parameters.Add("@CorreoAtencion", SqlDbType.VarChar, 500).Value = objEntidadBE.CorreoAtencion;
                        //sql_comando.Parameters.Add("@LugarEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.LugarEntrega;
                        //sql_comando.Parameters.Add("@TiempoEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.TiempoEntrega;
                        //sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter Numero = sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8);
                        Numero.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.Codigo = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.Numero = Numero.Value.ToString();
                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public ProformaCabCE F_Proformas_Eliminar(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_Eliminar";

                        sql_comando.Parameters.Add("@CodProforma", SqlDbType.Int).Value = objEntidadBE.CodProforma;

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

        public ProformaCabCE F_Proformas_Anulacion(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_ANULACION";

                        sql_comando.Parameters.Add("@CodProforma", SqlDbType.Int).Value = objEntidadBE.CodProforma;
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

        public DataTable F_ProformaCab_VistaPreliminar(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_VistaPreliminar";

                        sql_comando.Parameters.Add("@CodProforma", SqlDbType.Int).Value = objEntidadBE.CodProforma;

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

        public DataTable F_OrdenPedido_VistaPreliminar(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_OrdenPedidoCab_VistaPreliminar";

                        sql_comando.Parameters.Add("@CodOrdenPedido", SqlDbType.Int).Value = objEntidadBE.CodOrdenPedido;

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

        public DataTable F_ProformaCab_Select(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_Select";

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

                        if (objEntidadBE.CodCtaCte > 0)
                            sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;

                        if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                        {
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        }

                        if (objEntidadBE.Numero != "")
                            sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 10).Value = objEntidadBE.Numero;

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

        public DataTable F_ProformaCab_Select_Detalle(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_Select_Detalle";

                        sql_comando.Parameters.Add("@CodProforma", SqlDbType.Int).Value = objEntidadBE.CodProforma;

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

        public DataTable F_ProformaCab_ListarXCodigo(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_ListarXCodigo";

                        sql_comando.Parameters.Add("@CodProforma", SqlDbType.Int).Value = objEntidadBE.CodProforma;

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

        public DataTable F_ProformaDet_ListarXCodigo(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaDet_ListarXCodigo";

                        sql_comando.Parameters.Add("@CodProforma", SqlDbType.Int).Value = objEntidadBE.CodProforma;

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

        public DataTable F_ProformaCab_ListarXEstado(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_ListarXEstado";

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

        public DataTable F_ProformaCab_ObtenerXNumero(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_ListarXNumero";

                        sql_comando.Parameters.Add("@NumeroCotizacion", SqlDbType.Int).Value = objEntidadBE.Numero;

                        try
                        {
                            if (objEntidadBE.Serie != "")
                                sql_comando.Parameters.Add("@Serie", SqlDbType.VarChar, 4).Value = objEntidadBE.Serie;
                        }
                        catch (Exception)
                        {
                            
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

        public DataTable F_ProformaCab_ObtenerXID(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_ObtenerXId";

                        sql_comando.Parameters.Add("@CodProforma", SqlDbType.Int).Value = objEntidadBE.CodProforma;

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

        public ProformaCabCE F_ProformaDet_InsertTemporal(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaDet_InsertTemporal";

                        sql_comando.Parameters.Add("@CodProforma", SqlDbType.Int).Value = objEntidadBE.CodProforma;

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

        public ProformaCabCE F_ProformaCabActivacion(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCabActivacion";

                        sql_comando.Parameters.Add("@CodProforma", SqlDbType.Int).Value = objEntidadBE.CodProforma;

                        sql_comando.ExecuteNonQuery();

                        return objEntidadBE;

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_ProformaCab_VistaPreliminar_Despacho(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_VistaPreliminar_Despacho";

                        sql_comando.Parameters.Add("@CodProforma", SqlDbType.Int).Value = objEntidadBE.CodProforma;

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
        
        public ProformaCabCE F_OrdenPedidoCab_Insert(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_OrdenPedidoCab_Insert";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.Serie;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@FlagIgv", SqlDbType.Int).Value = objEntidadBE.FlagIgv;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@Referencia", SqlDbType.VarChar, 250).Value = objEntidadBE.Referencia;
                        sql_comando.Parameters.Add("@Atencion", SqlDbType.VarChar, 250).Value = objEntidadBE.Atencion;
                        sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@CodProformaAnterior", SqlDbType.Int).Value = objEntidadBE.CodProformaAnterior;
                        sql_comando.Parameters.Add("@Celular", SqlDbType.VarChar, 50).Value = objEntidadBE.Celular;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 250).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;
                        sql_comando.Parameters.Add("@CorreoAtencion", SqlDbType.VarChar, 500).Value = objEntidadBE.CorreoAtencion;
                        sql_comando.Parameters.Add("@LugarEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.LugarEntrega;
                        sql_comando.Parameters.Add("@TiempoEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.TiempoEntrega;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter Numero = sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8);
                        Numero.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.Codigo = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.Numero = Numero.Value.ToString();
                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProformaCabCE F_OrdenPedidoCab_Insert_Edicion(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_OrdenPedidoCab_Insert_Edicion";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.Serie;
                        sql_comando.Parameters.Add("@NumeroDocAnterior", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroAnterior;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@FlagIgv", SqlDbType.Int).Value = objEntidadBE.FlagIgv;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@Referencia", SqlDbType.VarChar, 250).Value = objEntidadBE.Referencia;
                        sql_comando.Parameters.Add("@Atencion", SqlDbType.VarChar, 250).Value = objEntidadBE.Atencion;
                        sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@CodProformaAnterior", SqlDbType.Int).Value = objEntidadBE.CodProformaAnterior;
                        sql_comando.Parameters.Add("@Celular", SqlDbType.VarChar, 50).Value = objEntidadBE.Celular;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 250).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;
                        sql_comando.Parameters.Add("@CorreoAtencion", SqlDbType.VarChar, 500).Value = objEntidadBE.CorreoAtencion;
                        sql_comando.Parameters.Add("@LugarEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.LugarEntrega;
                        sql_comando.Parameters.Add("@TiempoEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.TiempoEntrega;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter Numero = sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8);
                        Numero.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.Codigo = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.Numero = Numero.Value.ToString();
                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public ProformaCabCE F_OrdenPedidoCab_Anulacion(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_OrdenPedidoCab_ANULACION";

                        sql_comando.Parameters.Add("@CodProforma", SqlDbType.Int).Value = objEntidadBE.CodProforma;
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

        public DataTable F_OrdenPedidoCab_VistaPreliminar(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_OrdenPedidoCab_VistaPreliminar";

                        sql_comando.Parameters.Add("@CodProforma", SqlDbType.Int).Value = objEntidadBE.CodProforma;

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

        public DataTable F_OrdenPedidoCab_Select(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_OrdenPedidoCab_Select";

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

                        if (objEntidadBE.CodCtaCte > 0)
                            sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;

                        if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                        {
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        }

                        if (objEntidadBE.Numero != "")
                            sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 10).Value = objEntidadBE.Numero;

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

        public DataTable F_OrdenPedidoDet_Select_Detalle(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_OrdenPedidoDet_Select_Detalle";

                        sql_comando.Parameters.Add("@CodProforma", SqlDbType.Int).Value = objEntidadBE.CodProforma;

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

        public ProformaCabCE F_Proformas_Insert_Edicion_Clever(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_Insert_Edicion";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.Serie;
                        sql_comando.Parameters.Add("@NumeroDocAnterior", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroAnterior;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@FlagIgv", SqlDbType.Int).Value = objEntidadBE.FlagIgv;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@Referencia", SqlDbType.VarChar, 250).Value = objEntidadBE.Referencia;
                        sql_comando.Parameters.Add("@Atencion", SqlDbType.VarChar, 250).Value = objEntidadBE.Atencion;
                        sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@CodProformaAnterior", SqlDbType.Int).Value = objEntidadBE.CodProformaAnterior;
                        sql_comando.Parameters.Add("@Celular", SqlDbType.VarChar, 50).Value = objEntidadBE.Celular;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 250).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;
                        sql_comando.Parameters.Add("@CorreoAtencion", SqlDbType.VarChar, 500).Value = objEntidadBE.CorreoAtencion;
                        sql_comando.Parameters.Add("@LugarEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.LugarEntrega;
                        sql_comando.Parameters.Add("@TiempoEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.TiempoEntrega;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;
                        sql_comando.Parameters.Add("@FechaIngreso", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaIngreso;
                        sql_comando.Parameters.Add("@FechaSalida", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaSalida;
                        sql_comando.Parameters.Add("@FlagKM", SqlDbType.Int).Value = objEntidadBE.FlagKM;
                        sql_comando.Parameters.Add("@FlagPlaca", SqlDbType.Int).Value = objEntidadBE.FlagPlaca;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter Numero = sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8);
                        Numero.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.Codigo = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.Numero = Numero.Value.ToString();
                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public ProformaCabCE F_Proformas_Insert_Clever(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_Insert";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.Serie;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@FlagIgv", SqlDbType.Int).Value = objEntidadBE.FlagIgv;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@Referencia", SqlDbType.VarChar, 250).Value = objEntidadBE.Referencia;
                        sql_comando.Parameters.Add("@Atencion", SqlDbType.VarChar, 250).Value = objEntidadBE.Atencion;
                        sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@CodProformaAnterior", SqlDbType.Int).Value = objEntidadBE.CodProformaAnterior;
                        sql_comando.Parameters.Add("@Celular", SqlDbType.VarChar, 50).Value = objEntidadBE.Celular;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 250).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;
                        sql_comando.Parameters.Add("@CorreoAtencion", SqlDbType.VarChar, 500).Value = objEntidadBE.CorreoAtencion;
                        sql_comando.Parameters.Add("@LugarEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.LugarEntrega;
                        sql_comando.Parameters.Add("@TiempoEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.TiempoEntrega;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;
                        sql_comando.Parameters.Add("@FechaIngreso", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaIngreso;
                        sql_comando.Parameters.Add("@FechaSalida", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaSalida;
                        sql_comando.Parameters.Add("@FlagKM", SqlDbType.Int).Value = objEntidadBE.FlagKM;
                        sql_comando.Parameters.Add("@FlagPlaca", SqlDbType.Int).Value = objEntidadBE.FlagPlaca;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter Numero = sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8);
                        Numero.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.Codigo = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.Numero = Numero.Value.ToString();
                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object F_COTIZACION_OBSERVACION(ProformaCabCE objEntidad)
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
                        sql_comando.CommandText = "PA_COTIZACION_OBSERVACION";

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

        public object F_AUDITORIA_COTIZACION(ProformaCabCE objEntidad)
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
                        sql_comando.CommandText = "PA_COTIZACION_AUDITORIA";

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

        public object F_PROFORMACAB_PERMISOOBSERVACION(ProformaCabCE objEntidad)
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
                        sql_comando.CommandText = "PA_PROFORMACAB_PERMISOOBSERVACION";

                        sql_comando.Parameters.Add("@CodProforma", SqlDbType.Int).Value = objEntidad.Codigo;

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

        public ProformaCabCE F_Proformas_Insert_TEK(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_Insert";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.Serie;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@flagCodigo", SqlDbType.Int).Value = objEntidadBE.flagCodigo;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@FlagIgv", SqlDbType.Int).Value = objEntidadBE.FlagIgv;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@Referencia", SqlDbType.VarChar, 250).Value = objEntidadBE.Referencia;
                        sql_comando.Parameters.Add("@Atencion", SqlDbType.VarChar, 250).Value = objEntidadBE.Atencion;
                        sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@CodProformaAnterior", SqlDbType.Int).Value = objEntidadBE.CodProformaAnterior;
                        sql_comando.Parameters.Add("@Celular", SqlDbType.VarChar, 50).Value = objEntidadBE.Celular;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 250).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;
                        sql_comando.Parameters.Add("@CorreoAtencion", SqlDbType.VarChar, 500).Value = objEntidadBE.CorreoAtencion;
                        sql_comando.Parameters.Add("@LugarEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.LugarEntrega;
                        sql_comando.Parameters.Add("@TiempoEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.TiempoEntrega;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;
                        sql_comando.Parameters.Add("@Gratuito", SqlDbType.Decimal).Value = objEntidadBE.Gratuito;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter Numero = sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8);
                        Numero.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.Codigo = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.Numero = Numero.Value.ToString();
                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProformaCabCE F_Proformas_Insert_Edicion_TEK(ProformaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_Insert_Edicion";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.Serie;
                        sql_comando.Parameters.Add("@NumeroDocAnterior", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroAnterior;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.Vencimiento;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@flagCodigo", SqlDbType.Int).Value = objEntidadBE.flagCodigo;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@FlagIgv", SqlDbType.Int).Value = objEntidadBE.FlagIgv;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@Referencia", SqlDbType.VarChar, 250).Value = objEntidadBE.Referencia;
                        sql_comando.Parameters.Add("@Atencion", SqlDbType.VarChar, 250).Value = objEntidadBE.Atencion;
                        sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@CodProformaAnterior", SqlDbType.Int).Value = objEntidadBE.CodProformaAnterior;
                        sql_comando.Parameters.Add("@Celular", SqlDbType.VarChar, 50).Value = objEntidadBE.Celular;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 250).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 250).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;
                        sql_comando.Parameters.Add("@CorreoAtencion", SqlDbType.VarChar, 500).Value = objEntidadBE.CorreoAtencion;
                        sql_comando.Parameters.Add("@LugarEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.LugarEntrega;
                        sql_comando.Parameters.Add("@TiempoEntrega", SqlDbType.VarChar, 2000).Value = objEntidadBE.TiempoEntrega;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;
                        sql_comando.Parameters.Add("@Gratuito", SqlDbType.Decimal).Value = objEntidadBE.Gratuito;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter Numero = sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8);
                        Numero.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.Codigo = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.Numero = Numero.Value.ToString();
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
