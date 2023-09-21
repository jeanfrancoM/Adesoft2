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
    public class TCCuentaCorrienteCD
    {
        public TCCuentaCorrienteCE F_TCCuentaCorriente_Insert(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TCCuentaCorriente_Insert";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodTipoCtacte", SqlDbType.Int).Value = objEntidadBE.CodTipoCtaCte;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;

                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;

                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;

                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;

                        sql_comando.Parameters.Add("@NroTelefono", SqlDbType.VarChar, 25).Value = objEntidadBE.NroTelefono;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

                        sql_comando.Parameters.Add("@PaginaWeb", SqlDbType.VarChar, 150).Value = objEntidadBE.PaginaWeb;
                        sql_comando.Parameters.Add("@TipoDocumento", SqlDbType.VarChar, 2).Value = objEntidadBE.TipoDocumento;

                        sql_comando.Parameters.Add("@FlagCliente", SqlDbType.Int).Value = objEntidadBE.FlagCliente;
                        sql_comando.Parameters.Add("@FlagProveedor", SqlDbType.Int).Value = objEntidadBE.FlagProveedor;
                        sql_comando.Parameters.Add("@FlagRetencion", SqlDbType.Int).Value = objEntidadBE.FlagRetencion;
                        sql_comando.Parameters.Add("@Email", SqlDbType.VarChar, 500).Value = objEntidadBE.Email;
                        sql_comando.Parameters.Add("@NombreComercial", SqlDbType.VarChar, 500).Value = objEntidadBE.NombreComercial;
                        sql_comando.Parameters.Add("@LineaCredito", SqlDbType.Decimal).Value = objEntidadBE.LineaCredito;
                        sql_comando.Parameters.Add("@CodMonedaLineaCredito", SqlDbType.Int).Value = objEntidadBE.CodMonedaLineaCredito;
                        sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidadBE.CodCategoria;
                        sql_comando.Parameters.Add("@FlagBloqueoCredito", SqlDbType.Int).Value = objEntidadBE.FlagBloqueoCredito;                        
                        sql_comando.Parameters.Add("@DatosPersonales", SqlDbType.VarChar, 200).Value = objEntidadBE.DatosPersonales;
                        sql_comando.Parameters.Add("@Area", SqlDbType.VarChar, 100).Value = objEntidadBE.Area;
                        sql_comando.Parameters.Add("@Telefono", SqlDbType.VarChar, 100).Value = objEntidadBE.Telefono;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Correo1", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo1;
                        sql_comando.Parameters.Add("@Correo2", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo2;
                        sql_comando.Parameters.Add("@Correo3", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo3;
                        sql_comando.Parameters.Add("@Celular1", SqlDbType.VarChar, 100).Value = objEntidadBE.Celular1;
                        sql_comando.Parameters.Add("@Celular2", SqlDbType.VarChar, 100).Value = objEntidadBE.Celular2;
                        sql_comando.Parameters.Add("@Celular3", SqlDbType.VarChar, 100).Value = objEntidadBE.Celular3;         
                        sql_comando.Parameters.Add("@Flag_MostrarEnReporte", SqlDbType.Int).Value = objEntidadBE.Flag_MostrarEnReporte;
                        sql_comando.Parameters.Add("@CodZona", SqlDbType.Int).Value = objEntidadBE.CodZona;
                        sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidadBE.CodVendedor;
                        sql_comando.Parameters.Add("@D1", SqlDbType.Decimal).Value = objEntidadBE.D1;
                        sql_comando.Parameters.Add("@D2", SqlDbType.Decimal).Value = objEntidadBE.D2;
                        sql_comando.Parameters.Add("@D3", SqlDbType.Decimal).Value = objEntidadBE.D3;
                        sql_comando.Parameters.Add("@GpsLong", SqlDbType.Decimal).Value = objEntidadBE.GpsLong;
                        sql_comando.Parameters.Add("@GpsLat", SqlDbType.Decimal).Value = objEntidadBE.GpsLat;

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

        public TCCuentaCorrienteCE F_TCCuentaCorriente_Insert_Alvarado(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TCCuentaCorriente_Insert";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodTipoCtacte", SqlDbType.Int).Value = objEntidadBE.CodTipoCtaCte;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@NroTelefono", SqlDbType.VarChar, 25).Value = objEntidadBE.NroTelefono;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@PaginaWeb", SqlDbType.VarChar, 150).Value = objEntidadBE.PaginaWeb;
                        sql_comando.Parameters.Add("@TipoDocumento", SqlDbType.VarChar, 2).Value = objEntidadBE.TipoDocumento;
                        sql_comando.Parameters.Add("@FlagCliente", SqlDbType.Int).Value = objEntidadBE.FlagCliente;
                        sql_comando.Parameters.Add("@FlagProveedor", SqlDbType.Int).Value = objEntidadBE.FlagProveedor;
                        sql_comando.Parameters.Add("@FlagRetencion", SqlDbType.Int).Value = objEntidadBE.FlagRetencion;
                        sql_comando.Parameters.Add("@Email", SqlDbType.VarChar, 500).Value = objEntidadBE.Email;
                        sql_comando.Parameters.Add("@NombreComercial", SqlDbType.VarChar, 500).Value = objEntidadBE.NombreComercial;
                        sql_comando.Parameters.Add("@LineaCredito", SqlDbType.Decimal).Value = objEntidadBE.LineaCredito;
                        sql_comando.Parameters.Add("@CodMonedaLineaCredito", SqlDbType.Int).Value = objEntidadBE.CodMonedaLineaCredito;
                        sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidadBE.CodCategoria;
                        sql_comando.Parameters.Add("@FlagBloqueoCredito", SqlDbType.Int).Value = objEntidadBE.FlagBloqueoCredito;
                        sql_comando.Parameters.Add("@DatosPersonales", SqlDbType.VarChar, 200).Value = objEntidadBE.DatosPersonales;
                        sql_comando.Parameters.Add("@Area", SqlDbType.VarChar, 100).Value = objEntidadBE.Area;
                        sql_comando.Parameters.Add("@Telefono", SqlDbType.VarChar, 100).Value = objEntidadBE.Telefono;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Correo1", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo1;
                        sql_comando.Parameters.Add("@Correo2", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo2;
                        sql_comando.Parameters.Add("@Correo3", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo3;
                        sql_comando.Parameters.Add("@Celular1", SqlDbType.VarChar, 100).Value = objEntidadBE.Celular1;
                        sql_comando.Parameters.Add("@Celular2", SqlDbType.VarChar, 100).Value = objEntidadBE.Celular2;
                        sql_comando.Parameters.Add("@Celular3", SqlDbType.VarChar, 100).Value = objEntidadBE.Celular3;
                        sql_comando.Parameters.Add("@Flag_MostrarEnReporte", SqlDbType.Int).Value = objEntidadBE.Flag_MostrarEnReporte;
                        sql_comando.Parameters.Add("@CodZona", SqlDbType.Int).Value = objEntidadBE.CodZona;
                        sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidadBE.CodVendedor;
                        sql_comando.Parameters.Add("@D1", SqlDbType.Decimal).Value = objEntidadBE.D1;
                        sql_comando.Parameters.Add("@D2", SqlDbType.Decimal).Value = objEntidadBE.D2;
                        sql_comando.Parameters.Add("@D3", SqlDbType.Decimal).Value = objEntidadBE.D3;
                        sql_comando.Parameters.Add("@GpsLong", SqlDbType.Decimal).Value = objEntidadBE.GpsLong;
                        sql_comando.Parameters.Add("@GpsLat", SqlDbType.Decimal).Value = objEntidadBE.GpsLat;
          
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

        public TCCuentaCorrienteCE F_TCCuentaCorriente_Insert_Pymes(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TCCuentaCorriente_Insert";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodTipoCtacte", SqlDbType.Int).Value = objEntidadBE.CodTipoCtaCte;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;

                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;

                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;

                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;

                        sql_comando.Parameters.Add("@NroTelefono", SqlDbType.VarChar, 25).Value = objEntidadBE.NroTelefono;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

                        sql_comando.Parameters.Add("@PaginaWeb", SqlDbType.VarChar, 150).Value = objEntidadBE.PaginaWeb;
                        sql_comando.Parameters.Add("@TipoDocumento", SqlDbType.VarChar, 2).Value = objEntidadBE.TipoDocumento;

                        sql_comando.Parameters.Add("@FlagCliente", SqlDbType.Int).Value = objEntidadBE.FlagCliente;
                        sql_comando.Parameters.Add("@FlagProveedor", SqlDbType.Int).Value = objEntidadBE.FlagProveedor;
                        sql_comando.Parameters.Add("@FlagRetencion", SqlDbType.Int).Value = objEntidadBE.FlagRetencion;
                        sql_comando.Parameters.Add("@Email", SqlDbType.VarChar, 500).Value = objEntidadBE.Email;
                        sql_comando.Parameters.Add("@NombreComercial", SqlDbType.VarChar, 500).Value = objEntidadBE.NombreComercial;
                        sql_comando.Parameters.Add("@LineaCredito", SqlDbType.Decimal).Value = objEntidadBE.LineaCredito;
                        sql_comando.Parameters.Add("@CodMonedaLineaCredito", SqlDbType.Int).Value = objEntidadBE.CodMonedaLineaCredito;
                        sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidadBE.CodCategoria;
                        sql_comando.Parameters.Add("@FlagBloqueoCredito", SqlDbType.Int).Value = objEntidadBE.FlagBloqueoCredito;
                        sql_comando.Parameters.Add("@DatosPersonales", SqlDbType.VarChar, 200).Value = objEntidadBE.DatosPersonales;
                        sql_comando.Parameters.Add("@Area", SqlDbType.VarChar, 100).Value = objEntidadBE.Area;
                        sql_comando.Parameters.Add("@Telefono", SqlDbType.VarChar, 100).Value = objEntidadBE.Telefono;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Correo1", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo1;
                        sql_comando.Parameters.Add("@Correo2", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo2;
                        sql_comando.Parameters.Add("@Correo3", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo3;
                        sql_comando.Parameters.Add("@Celular1", SqlDbType.VarChar, 100).Value = objEntidadBE.Celular1;
                        sql_comando.Parameters.Add("@Celular2", SqlDbType.VarChar, 100).Value = objEntidadBE.Celular2;
                        sql_comando.Parameters.Add("@Celular3", SqlDbType.VarChar, 100).Value = objEntidadBE.Celular3;
                        sql_comando.Parameters.Add("@Flag_MostrarEnReporte", SqlDbType.Int).Value = objEntidadBE.Flag_MostrarEnReporte;
                        sql_comando.Parameters.Add("@CodZona", SqlDbType.Int).Value = objEntidadBE.CodZona;
                        sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidadBE.CodVendedor;
                        sql_comando.Parameters.Add("@D1", SqlDbType.Decimal).Value = objEntidadBE.D1;
                        sql_comando.Parameters.Add("@D2", SqlDbType.Decimal).Value = objEntidadBE.D2;
                        sql_comando.Parameters.Add("@D3", SqlDbType.Decimal).Value = objEntidadBE.D3;
                        sql_comando.Parameters.Add("@GpsLong", SqlDbType.Decimal).Value = objEntidadBE.GpsLong;
                        sql_comando.Parameters.Add("@GpsLat", SqlDbType.Decimal).Value = objEntidadBE.GpsLat;

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

        public TCCuentaCorrienteCE F_TCCuentaCorriente_Update(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TCCuentaCorriente_Update";

                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodTipoCtacte", SqlDbType.Int).Value = objEntidadBE.CodTipoCtaCte;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroTelefono", SqlDbType.VarChar, 25).Value = objEntidadBE.NroTelefono;
                        sql_comando.Parameters.Add("@DspPosterior", SqlDbType.VarChar, 1).Value = objEntidadBE.DspPosterior;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@PaginaWeb", SqlDbType.VarChar, 150).Value = objEntidadBE.PaginaWeb;
                        sql_comando.Parameters.Add("@TipoDocumento", SqlDbType.VarChar, 2).Value = objEntidadBE.TipoDocumento;
                        sql_comando.Parameters.Add("@Email", SqlDbType.VarChar, 500).Value = objEntidadBE.Email;
                        sql_comando.Parameters.Add("@LineaCredito", SqlDbType.Decimal).Value = objEntidadBE.LineaCredito;
                        sql_comando.Parameters.Add("@CodMonedaLineaCredito", SqlDbType.Int).Value = objEntidadBE.CodMonedaLineaCredito;
                        sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidadBE.CodCategoria;
                        sql_comando.Parameters.Add("@FlagBloqueoCredito", SqlDbType.Int).Value = objEntidadBE.FlagBloqueoCredito;
                        sql_comando.Parameters.Add("@NombreComercial", SqlDbType.VarChar,250).Value = objEntidadBE.NombreComercial;
                        sql_comando.Parameters.Add("@CodZona", SqlDbType.Int).Value = objEntidadBE.CodZona;
                        sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidadBE.CodVendedor;
                        sql_comando.Parameters.Add("@FlagRetencion", SqlDbType.Int).Value = objEntidadBE.FlagRetencion;
                        sql_comando.Parameters.Add("@D1", SqlDbType.Decimal).Value = objEntidadBE.D1;
                        sql_comando.Parameters.Add("@D2", SqlDbType.Decimal).Value = objEntidadBE.D2;
                        sql_comando.Parameters.Add("@D3", SqlDbType.Decimal).Value = objEntidadBE.D3;
                        sql_comando.Parameters.Add("@FlagExclusivo", SqlDbType.Int).Value = objEntidadBE.FlagExclusivo;

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

        public TCCuentaCorrienteCE F_TCCuentaCorriente_Update_Alvarado(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TCCuentaCorriente_Update";

                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodTipoCtacte", SqlDbType.Int).Value = objEntidadBE.CodTipoCtaCte;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroTelefono", SqlDbType.VarChar, 25).Value = objEntidadBE.NroTelefono;
                        sql_comando.Parameters.Add("@DspPosterior", SqlDbType.VarChar, 1).Value = objEntidadBE.DspPosterior;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@PaginaWeb", SqlDbType.VarChar, 150).Value = objEntidadBE.PaginaWeb;
                        sql_comando.Parameters.Add("@TipoDocumento", SqlDbType.VarChar, 2).Value = objEntidadBE.TipoDocumento;
                        sql_comando.Parameters.Add("@Email", SqlDbType.VarChar, 500).Value = objEntidadBE.Email;
                        sql_comando.Parameters.Add("@LineaCredito", SqlDbType.Decimal).Value = objEntidadBE.LineaCredito;
                        sql_comando.Parameters.Add("@CodMonedaLineaCredito", SqlDbType.Int).Value = objEntidadBE.CodMonedaLineaCredito;
                        sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidadBE.CodCategoria;
                        sql_comando.Parameters.Add("@FlagBloqueoCredito", SqlDbType.Int).Value = objEntidadBE.FlagBloqueoCredito;
                        sql_comando.Parameters.Add("@NombreComercial", SqlDbType.VarChar, 250).Value = objEntidadBE.NombreComercial;
                        sql_comando.Parameters.Add("@CodZona", SqlDbType.Int).Value = objEntidadBE.CodZona;
                        sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidadBE.CodVendedor;
                        sql_comando.Parameters.Add("@FlagRetencion", SqlDbType.Int).Value = objEntidadBE.FlagRetencion;
                        sql_comando.Parameters.Add("@D1", SqlDbType.Decimal).Value = objEntidadBE.D1;
                        sql_comando.Parameters.Add("@D2", SqlDbType.Decimal).Value = objEntidadBE.D2;
                        sql_comando.Parameters.Add("@D3", SqlDbType.Decimal).Value = objEntidadBE.D3;
                       
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

        public DataTable F_TCCuentaCorriente_ListarClientes(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TCCuentaCorriente_ListarClientes";

                        if (!objEntidadBE.NroRuc.Equals(""))
                            sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 15).Value = objEntidadBE.NroRuc;

                        if (!objEntidadBE.RazonSocial.Equals(""))
                            sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 200).Value = objEntidadBE.RazonSocial;

                        if (objEntidadBE.CodTipoCtaCte != 0)
                            sql_comando.Parameters.Add("@CodTipoCtaCte", SqlDbType.Int).Value = objEntidadBE.CodTipoCtaCte;

                        if (objEntidadBE.CodTipoCliente != 0)
                            sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;

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

        public DataTable F_TCCuentaCorriente_Ruc_ListarClientes(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_TCCuentaCorriente_ListarClientes_Ruc]";

                        if (!objEntidadBE.NroRuc.Equals(""))
                            sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 15).Value = objEntidadBE.NroRuc;

                        if (!objEntidadBE.RazonSocial.Equals(""))
                            sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 200).Value = objEntidadBE.RazonSocial;

                        if (objEntidadBE.CodTipoCtaCte != 0)
                            sql_comando.Parameters.Add("@CodTipoCtaCte", SqlDbType.Int).Value = objEntidadBE.CodTipoCtaCte;

                        if (objEntidadBE.CodTipoCliente != 0)
                            sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;

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

        public DataTable F_ValidarClienteCambioPrecio(string NroRuc)
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
                        sql_comando.CommandText = "[PA_ValidarClienteCambioPrecio]";

                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 15).Value = NroRuc;


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

        public DataTable F_TCCuentaCorriente_PadronSunat(TCCuentaCorrienteCE objEntidadBE)
        {

            DataTable dta_consulta = null;

            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDSERVICIOS"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_TCCuentaCorriente_PadronSunat";

                        if (!objEntidadBE.NroRuc.Equals(""))
                            sql_comando.Parameters.Add("@Ruc", SqlDbType.BigInt).Value = objEntidadBE.NroRuc;


                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;

                    }

                }



            }
            catch (Exception ex)
            {



                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDSERVICIOS2"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_TCCuentaCorriente_PadronSunat";

                        if (!objEntidadBE.NroRuc.Equals(""))
                            sql_comando.Parameters.Add("@Ruc", SqlDbType.BigInt).Value = objEntidadBE.NroRuc;


                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;

                    }

                }




            }
            finally { dta_consulta.Dispose(); }
        }

        public DataTable F_TCDistritoBuscarXUbigeo(string CodigoUbigeo)
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
                        sql_comando.CommandText = "pa_TCDistritoBuscarXUbigeo";

                        sql_comando.Parameters.Add("@CodigoUbigeo", SqlDbType.VarChar, 10).Value = CodigoUbigeo;

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

        public DataTable F_BuscarDatosPorRucDni(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TCCuentaCorriente_BuscarClienteXRucDni";

                        sql_comando.Parameters.Add("@Ruc", SqlDbType.VarChar, 20).Value = objEntidadBE.NroRuc;

                        if (objEntidadBE.CodTipoCtaCte > 0)
                            sql_comando.Parameters.Add("@CodTipoCtaCte", SqlDbType.Int).Value = objEntidadBE.CodTipoCtaCte;

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

        public TCCuentaCorrienteCE F_TCCuentaCorriente_Eliminar(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TCCuentaCorriente_Eliminar";

                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;

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

        public DataTable F_TCCuentaCorriente_Listar(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TCCuentaCorriente_Listar";

                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 60).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@CodTipoCtaCte", SqlDbType.Int).Value = objEntidadBE.CodTipoCtaCte;

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

        public TCCuentaCorrienteCE F_LGFamilias_Insert(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGFamilias_Insert";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@DscFamilia", SqlDbType.VarChar).Value = objEntidadBE.DscFamilia;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
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

        public TCCuentaCorrienteCE F_LGFamilias_Update(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGFamilias_Update";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@IDFamilia", SqlDbType.Int).Value = objEntidadBE.IDFamilia;
                        sql_comando.Parameters.Add("@DscFamilia", SqlDbType.VarChar).Value = objEntidadBE.DscFamilia;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
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

        public DataTable F_LGFamilias_Listado(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGFamilias_Listado";

                        if (objEntidadBE.DscFamilia != "")
                            sql_comando.Parameters.Add("@DscFamilia", SqlDbType.VarChar, 50).Value = objEntidadBE.DscFamilia;

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

        public DataTable F_LGFamilias_Listar()
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
                        sql_comando.CommandText = "pa_LGFamilias_Listar";

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

        public TCCuentaCorrienteCE F_LGFamilias_Delete(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGFamilias_Delete";

                        sql_comando.Parameters.Add("@IDFamilia", SqlDbType.Int).Value = objEntidadBE.IDFamilia;

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
        
        public DataTable F_ClientesSaldos_AZURE(string NroRuc)
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
                        sql_comando.CommandText = "pa_ClientesSaldos";

                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 15).Value = NroRuc;

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

        public TCCuentaCorrienteCE F_Linea_Insertar(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LINEA_INSERTAR";
                        
                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = objEntidadBE.Descripcion;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@IPRegistro", SqlDbType.VarChar, 50).Value = objEntidadBE.IPRegistro;

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

        public TCCuentaCorrienteCE F_Linea_Actualizar(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LINEA_ACTUALIZAR";

                        sql_comando.Parameters.Add("@CodLinea", SqlDbType.Int).Value = objEntidadBE.CodLinea;
                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = objEntidadBE.Descripcion;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@IPModificacion", SqlDbType.VarChar,50).Value = objEntidadBE.IPModificacion;

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

        public DataTable F_Linea_Listado(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LINEA_Listado";

                        if (objEntidadBE.DscFamilia != "")
                            sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = objEntidadBE.Descripcion;

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

        public DataTable F_Linea_Listar()
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
                        sql_comando.CommandText = "pa_LINEA_Listar";

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

        public TCCuentaCorrienteCE F_Linea_Eliminar(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_LINEA_ELIMINAR";

                        sql_comando.Parameters.Add("@CodLinea", SqlDbType.Int).Value = objEntidadBE.CodLinea;

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

        public DataTable F_LINEA_AUTOCOMPLETE(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_LINEA_AUTOCOMPLETE";

                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar,50).Value = objEntidadBE.Descripcion;

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

        public TCCuentaCorrienteCE F_Modelo_Insertar(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_MODELOVEHICULO_INSERTAR";

                        sql_comando.Parameters.Add("@CodLinea", SqlDbType.Int).Value = objEntidadBE.CodLinea;
                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = objEntidadBE.Descripcion;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@IPRegistro", SqlDbType.VarChar, 50).Value = objEntidadBE.IPRegistro;

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

        public TCCuentaCorrienteCE F_Modelo_Actualizar(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_MODELOVEHICULO_ACTUALIZAR";

                        sql_comando.Parameters.Add("@CodModeloVehiculo", SqlDbType.Int).Value = objEntidadBE.CodModeloVehiculo;
                        sql_comando.Parameters.Add("@CodLinea", SqlDbType.Int).Value = objEntidadBE.CodLinea;
                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = objEntidadBE.Descripcion;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@IPModificacion", SqlDbType.VarChar, 50).Value = objEntidadBE.IPModificacion;

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

        public DataTable F_Modelo_Listado(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_MODELOVEHICULO_LISTADO";

                        if (objEntidadBE.DscFamilia != "")
                            sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = objEntidadBE.Descripcion;

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

        public DataTable F_Modelo_Listar()
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
                        sql_comando.CommandText = "pa_Modelo_Listar";

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

        public TCCuentaCorrienteCE F_Modelo_Eliminar(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_MODELOVEHICULO_ELIMINAR";

                        sql_comando.Parameters.Add("@CodModeloVehiculo", SqlDbType.Int).Value = objEntidadBE.CodModeloVehiculo;

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

        public DataTable F_MODELOVEHICULO_AUTOCOMPLETE(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_MODELOVEHICULO_AUTOCOMPLETE";

                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = objEntidadBE.Descripcion;

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

        public DataTable F_MARCAPRODUCTO_AUTOCOMPLETE(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_MARCAPRODUCTO_AUTOCOMPLETE";

                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = objEntidadBE.Descripcion;

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

        public DataTable F_TCContactos_Listar(ContactosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Contactos_Listar";

                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;

                        if (objEntidadBE.CodEstado != 0)
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

        public ContactosCE F_Contactos_Insert(ContactosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Contactos_Insert";

                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@DatosPersonales", SqlDbType.VarChar, 200).Value = objEntidadBE.DatosPersonales;
                        sql_comando.Parameters.Add("@Area", SqlDbType.VarChar, 100).Value = objEntidadBE.Area;
                        sql_comando.Parameters.Add("@Telefono", SqlDbType.VarChar, 100).Value = objEntidadBE.Telefono;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Correo1", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo1;
                        sql_comando.Parameters.Add("@Correo2", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo2;
                        sql_comando.Parameters.Add("@Correo3", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo3;
                        sql_comando.Parameters.Add("@Celular1", SqlDbType.VarChar, 100).Value = objEntidadBE.Celular1;
                        sql_comando.Parameters.Add("@Celular2", SqlDbType.VarChar, 100).Value = objEntidadBE.Celular2;
                        sql_comando.Parameters.Add("@Celular3", SqlDbType.VarChar, 100).Value = objEntidadBE.Celular3;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@Flag_MostrarEnReporte", SqlDbType.Int).Value = objEntidadBE.Flag_MostrarEnReporte;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;


                        SqlParameter CodContacto = sql_comando.Parameters.Add("@CodContacto", SqlDbType.Int);
                        CodContacto.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodContacto = Convert.ToInt32(CodContacto.Value);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public ContactosCE F_Contactos_Update(ContactosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Contactos_Update";

                        sql_comando.Parameters.Add("@CodContacto", SqlDbType.Int).Value = objEntidadBE.CodContacto;
                        sql_comando.Parameters.Add("@DatosPersonales", SqlDbType.VarChar, 200).Value = objEntidadBE.DatosPersonales;
                        sql_comando.Parameters.Add("@Area", SqlDbType.VarChar, 100).Value = objEntidadBE.Area;
                        sql_comando.Parameters.Add("@Telefono", SqlDbType.VarChar, 100).Value = objEntidadBE.Telefono;
                        sql_comando.Parameters.Add("@Correo1", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo1;
                        sql_comando.Parameters.Add("@Correo2", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo2;
                        sql_comando.Parameters.Add("@Correo3", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo3;
                        sql_comando.Parameters.Add("@Celular1", SqlDbType.VarChar, 100).Value = objEntidadBE.Celular1;
                        sql_comando.Parameters.Add("@Celular2", SqlDbType.VarChar, 100).Value = objEntidadBE.Celular2;
                        sql_comando.Parameters.Add("@Celular3", SqlDbType.VarChar, 100).Value = objEntidadBE.Celular3;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Flag_MostrarEnReporte", SqlDbType.Int).Value = objEntidadBE.Flag_MostrarEnReporte;

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

        public DataTable F_TCCuentaCorriente_SaldosLineaCredito_Cliente(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TCCuentaCorriente_SaldosLineaCredito_Cliente";

                        sql_comando.Parameters.Add("@CodCtaCtePeticion", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@CodMonedaPeticion", SqlDbType.Int).Value = objEntidadBE.CodMonedaLineaCredito;

                        SqlParameter MontoLineaCredito = sql_comando.Parameters.Add("@MontoLineaCred", SqlDbType.Decimal);
                        MontoLineaCredito.Direction = ParameterDirection.Output;

                        SqlParameter MontoConsumido = sql_comando.Parameters.Add("@MontoConsumido", SqlDbType.Decimal);
                        MontoConsumido.Direction = ParameterDirection.Output;

                        SqlParameter MontoDisponible = sql_comando.Parameters.Add("@MontoDisponibl", SqlDbType.Decimal);
                        MontoDisponible.Direction = ParameterDirection.Output;

                        SqlParameter CodMonedaLineaCredito = sql_comando.Parameters.Add("@CodMonedaLineaCredito", SqlDbType.Decimal);
                        CodMonedaLineaCredito.Direction = ParameterDirection.Output;

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

        //joel 20/02/21
        public TCCuentaCorrienteCE F_TCAlmacen_Insert(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TCAlmacen_Insert";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@DscAlmacen", SqlDbType.VarChar).Value = objEntidadBE.dscAlmacen;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@FlagPrincipal", SqlDbType.Int).Value = objEntidadBE.FlagPrincipal;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@NroTelefono", SqlDbType.VarChar, 25).Value = objEntidadBE.NroTelefono;
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

        //joel 20/02/21
        public DataTable F_TCAlmacen_Listado(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TcAlmacen_Listado";

                        if (objEntidadBE.dscAlmacen != "")
                            sql_comando.Parameters.Add("@DscAlmacen", SqlDbType.VarChar, 50).Value = objEntidadBE.dscAlmacen;

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
        //joel 20/02/21
        public TCCuentaCorrienteCE F_TCAlmacen_Update(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TCAlmacen_Update";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@DscAlmacen", SqlDbType.VarChar).Value = objEntidadBE.dscAlmacen;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.VarChar).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.VarChar).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.VarChar).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@NroTelefono", SqlDbType.VarChar).Value = objEntidadBE.NroTelefono;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@FlagPrincipal", SqlDbType.Int).Value = objEntidadBE.FlagPrincipal;
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

        public TCCuentaCorrienteCE F_TCAlmacen_Delete(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TCAlmacen_Delete";

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

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

        public TCCuentaCorrienteCE F_Usuario_Update(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Usuario_Update";

                        sql_comando.Parameters.Add("@Confirmacion", SqlDbType.VarChar, 60).Value = objEntidadBE.Confirmacion;
                        sql_comando.Parameters.Add("@NombreUsuario", SqlDbType.VarChar,60).Value = objEntidadBE.Usuario;
                        sql_comando.Parameters.Add("@nueva", SqlDbType.VarChar, 60).Value = objEntidadBE.ContraseñaNueva;
                        sql_comando.Parameters.Add("@Antigua", SqlDbType.VarChar, 60).Value = objEntidadBE.Contraseña;

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
        
        public TCCuentaCorrienteCE F_ActualizarDescuento(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "";

                        sql_comando.Parameters.Add("@categoria", SqlDbType.Int).Value = objEntidadBE.categoria;

                        sql_comando.ExecuteNonQuery();
                    

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }
            return objEntidadBE;
        }
        
        public TCCuentaCorrienteCE F_Procedencia_Insertar_Salcedo(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Procedencia_INSERTAR";

                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 250).Value = objEntidadBE.Descripcion;
                        sql_comando.Parameters.Add("@CodigoProcedencia", SqlDbType.VarChar, 250).Value = objEntidadBE.CodigoProcedencia;
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

        public DataTable F_Procedencia_Listado_Salcedo(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_Procedencia_LISTADO";

                        if (objEntidadBE.DscFamilia != "")
                            sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = objEntidadBE.Descripcion;

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

        public TCCuentaCorrienteCE F_Procedencia_Actualizar_Salcedo(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_Procedencia_ACTUALIZAR";

                        sql_comando.Parameters.Add("@CodProcedencia", SqlDbType.Int).Value = objEntidadBE.CodProcedencia;
                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 250).Value = objEntidadBE.Descripcion;
                        sql_comando.Parameters.Add("@CodigoProcedencia", SqlDbType.VarChar, 250).Value = objEntidadBE.CodigoProcedencia;
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

        public TCCuentaCorrienteCE F_Procedencia_Eliminar_Salcedo(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_Procedencia_ELIMINAR";

                        sql_comando.Parameters.Add("@CodProcedencia", SqlDbType.Int).Value = objEntidadBE.CodProcedencia;

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

        public TCCuentaCorrienteCE F_Linea_Insertar_Salcedo(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LINEA_INSERTAR";

                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 250).Value = objEntidadBE.Descripcion;
                        sql_comando.Parameters.Add("@Codigolinea", SqlDbType.VarChar, 250).Value = objEntidadBE.Codigolinea;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@IPRegistro", SqlDbType.VarChar, 50).Value = objEntidadBE.IPRegistro;

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

        public DataTable F_Linea_Listado_Salcedo(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LINEA_Listado";

                        if (objEntidadBE.DscFamilia != "")
                            sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = objEntidadBE.Descripcion;

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

        public TCCuentaCorrienteCE F_Linea_Eliminar_Salcedo(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_LINEA_ELIMINAR";

                        sql_comando.Parameters.Add("@CodLinea", SqlDbType.Int).Value = objEntidadBE.CodLinea;

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

        public TCCuentaCorrienteCE F_Linea_Actualizar_Salcedo(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LINEA_ACTUALIZAR";

                        sql_comando.Parameters.Add("@CodLinea", SqlDbType.Int).Value = objEntidadBE.CodLinea;
                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = objEntidadBE.Descripcion;
                        sql_comando.Parameters.Add("@Codigolinea", SqlDbType.VarChar, 250).Value = objEntidadBE.Codigolinea;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@IPModificacion", SqlDbType.VarChar, 50).Value = objEntidadBE.IPModificacion;

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

        public TCCuentaCorrienteCE F_Marca_Insertar_Salcedo(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_Marca_INSERTAR";

                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 250).Value = objEntidadBE.Descripcion;
                        sql_comando.Parameters.Add("@CodigoMarca", SqlDbType.VarChar, 250).Value = objEntidadBE.CodigoMarca;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@IPRegistro", SqlDbType.VarChar, 50).Value = objEntidadBE.IPRegistro;

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

        public DataTable F_Marca_Listado_Salcedo(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Marca_Listado";

                        if (objEntidadBE.DscFamilia != "")
                            sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = objEntidadBE.Descripcion;

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

        public TCCuentaCorrienteCE F_Marca_Eliminar_Salcedo(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_Marca_ELIMINAR";

                        sql_comando.Parameters.Add("@CodMarca", SqlDbType.Int).Value = objEntidadBE.CodMarca;

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

        public TCCuentaCorrienteCE F_Marca_Actualizar_Salcedo(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_Marca_ACTUALIZAR";

                        sql_comando.Parameters.Add("@CodMarca", SqlDbType.Int).Value = objEntidadBE.CodMarca;
                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = objEntidadBE.Descripcion;
                        sql_comando.Parameters.Add("@CodigoMarca", SqlDbType.VarChar, 250).Value = objEntidadBE.CodigoMarca;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@IPModificacion", SqlDbType.VarChar, 50).Value = objEntidadBE.IPModificacion;

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
        
        public TCCuentaCorrienteCE F_LGFamilias_Insert_Salcedo(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGFamilias_Insert";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@DscFamilia", SqlDbType.VarChar).Value = objEntidadBE.DscFamilia;
                        sql_comando.Parameters.Add("@CodigoFamilia", SqlDbType.VarChar).Value = objEntidadBE.CodigoFamilia;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
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

        public TCCuentaCorrienteCE F_LGFamilias_Update_Salcedo(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGFamilias_Update";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@IDFamilia", SqlDbType.Int).Value = objEntidadBE.IDFamilia;
                        sql_comando.Parameters.Add("@DscFamilia", SqlDbType.VarChar).Value = objEntidadBE.DscFamilia;
                        sql_comando.Parameters.Add("@CodigoFamilia", SqlDbType.VarChar).Value = objEntidadBE.CodigoFamilia;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
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

        public DataTable F_LGFamilias_Listado_Salcedo(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGFamilias_Listado";

                        if (objEntidadBE.DscFamilia != "")
                            sql_comando.Parameters.Add("@DscFamilia", SqlDbType.VarChar, 50).Value = objEntidadBE.DscFamilia;

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

        public DataTable F_LGFamilias_Listar_Salcedo()
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
                        sql_comando.CommandText = "pa_LGFamilias_Listar";

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

        public TCCuentaCorrienteCE F_LGFamilias_Delete_Salcedo(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGFamilias_Delete";

                        sql_comando.Parameters.Add("@IDFamilia", SqlDbType.Int).Value = objEntidadBE.IDFamilia;

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

        public DataTable F_Familia_AUTOCOMPLETE(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_Familia_AUTOCOMPLETE";

                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = objEntidadBE.Descripcion;

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

        public DataTable F_Procedencia_AUTOCOMPLETE(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_Procedencia_AUTOCOMPLETE";

                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = objEntidadBE.Descripcion;

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

        public DataTable F_Procedencia_Listar()
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
                        sql_comando.CommandText = "pa_Procedencia_Listar";

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

        public DataTable F_listar_EmpleadosxCargo(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_listar_EmpleadosxCargo";


                        sql_comando.Parameters.Add("@CodCargo", SqlDbType.Int).Value = objEntidadBE.CodCargo;


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
        
        public DataTable F_TCCuentaCorriente_BuscarMotivo(TCCuentaCorrienteCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TCCuentaCorriente_MostrarMotivo";

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

        public object F_CORREO_DIRECCION(TCCuentaCorrienteCE objEntidad)
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
                        sql_comando.CommandText = "F_CORREO_DIRECCION";

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

        public ContactosCE F_Contactos_Eliminar(ContactosCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Contactos_Eliminar";

                        sql_comando.Parameters.Add("@CodContacto", SqlDbType.Int).Value = objEntidadBE.CodContacto;

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
