using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DocumentoVentaCabCD
    {
        public DocumentoVentaCabCE F_TemporalFacturacionDet_Insert(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionDet_Insert";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.DateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;

                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodProforma", SqlDbType.Int).Value = objEntidadBE.CodProforma;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;

                        sql_comando.Parameters.Add("@CodGuia", SqlDbType.Int).Value = objEntidadBE.CodGuia;
                        sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;
                        sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar,1000).Value = objEntidadBE.Observacion;
                        if (objEntidadBE.CodTipoOperacion != 0)
                            sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Decimal).Value = objEntidadBE.CodTipoOperacion;


                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }
        
        public DocumentoVentaCabCE F_TemporalFacturacionDetPedido_Insert(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionDetPedido_Insert";

                        sql_comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;                                                
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
        
        public DocumentoVentaCabCE F_TemporalFacturacionDet_Insert_Povis(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionDet_Insert";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.DateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;

                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodProforma", SqlDbType.Int).Value = objEntidadBE.CodProforma;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;

                        sql_comando.Parameters.Add("@CodGuia", SqlDbType.Int).Value = objEntidadBE.CodGuia;
                        sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;
                        sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public DocumentoVentaCabCE F_TemporalFacturacionDet_Insert_Yordan(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionDet_Insert";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.DateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;

                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodProforma", SqlDbType.Int).Value = objEntidadBE.CodProforma;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;

                        sql_comando.Parameters.Add("@CodGuia", SqlDbType.Int).Value = objEntidadBE.CodGuia;
                        sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;
                        sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;

                        sql_comando.Parameters.Add("@SolicitarDescuento", SqlDbType.Int).Value = objEntidadBE.SolicitarDescuento;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public DocumentoVentaCabCE F_TemporalFacturacionDetalle_Insert(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionDetalle_Insert";

                        sql_comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;
                        if (objEntidadBE.CodTipoOperacion != 0)
                            sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Decimal).Value = objEntidadBE.CodTipoOperacion;
                        if (objEntidadBE.CodAlmacen != 0)
                            sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Decimal).Value = objEntidadBE.CodAlmacen;

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

        public DocumentoVentaCabCE F_TemporalFacturacionDetalle_Insert_Povis(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionDetalle_Insert";

                        sql_comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
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

        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert_Factura_NONV_Tracto(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Insert_Factura_NONV";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 250).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                        sql_comando.Parameters.Add("@FlagCSIgv", SqlDbType.Int).Value = objEntidadBE.FlagCSIgv;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;



                        sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 50).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NroBultos", SqlDbType.VarChar, 50).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 50).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 50).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@ObservacionesCliente", SqlDbType.VarChar, 2000).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@Placa1", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@NroOC", SqlDbType.VarChar, 100).Value = objEntidadBE.NroOC;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;

                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@RucTransportista", SqlDbType.VarChar, 50).Value = objEntidadBE.NroRucTransportista;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 500).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTrans", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@CodDepartamentoTrasportista", SqlDbType.Int).Value = objEntidadBE.CodDepartamentoTransportista;
                        sql_comando.Parameters.Add("@RazonSocialTrasportista", SqlDbType.VarChar, 500).Value = objEntidadBE.Transportista;
                        sql_comando.Parameters.Add("@CodProvinciaTrasportista", SqlDbType.Int).Value = objEntidadBE.CodProvinciaTransportista;
                        sql_comando.Parameters.Add("@CodDistritoTrasportista", SqlDbType.Int).Value = objEntidadBE.CodDistritoTransportista;



                        // DATOS DE LA GUIA ELECTRONICA
                        sql_comando.Parameters.Add("@CodConductor", SqlDbType.Int).Value = objEntidadBE.CodConductor;
                        sql_comando.Parameters.Add("@DniConductor", SqlDbType.VarChar, 8).Value = objEntidadBE.DniConductor;
                        sql_comando.Parameters.Add("@NombreConductor", SqlDbType.VarChar, 350).Value = objEntidadBE.NombreConductor;

                        sql_comando.Parameters.Add("@UsuarioPermiso", SqlDbType.VarChar, 160).Value = objEntidadBE.UsuarioPermiso;
                        sql_comando.Parameters.Add("@ClavePermiso", SqlDbType.VarChar, 60).Value = objEntidadBE.ClavePermiso;
                        sql_comando.Parameters.Add("@ObservacionPermiso", SqlDbType.VarChar, 300).Value = objEntidadBE.ObservacionPermiso;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter CodGuia = sql_comando.Parameters.Add("@CodGuia", SqlDbType.Int);
                        CodGuia.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.CodGuia = Convert.ToInt32(CodGuia.Value);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }


        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert_NV_OC_Tracto(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandTimeout = 120;
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Insert_NV_OC";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDocumento", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.DateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;

                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;

                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 150).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@NotaPedido", SqlDbType.Int).Value = objEntidadBE.NotaPedido;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;

                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;

                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@ObservacionesCliente", SqlDbType.VarChar, 2000).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;

                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 200).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTrans", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 50).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NroBultos", SqlDbType.VarChar, 50).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 50).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 50).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@Placa1", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;

                        sql_comando.Parameters.Add("@UsuarioPermiso", SqlDbType.VarChar, 160).Value = objEntidadBE.UsuarioPermiso;
                        sql_comando.Parameters.Add("@ClavePermiso", SqlDbType.VarChar, 60).Value = objEntidadBE.ClavePermiso;
                        sql_comando.Parameters.Add("@ObservacionPermiso", SqlDbType.VarChar, 300).Value = objEntidadBE.ObservacionPermiso;
                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter codigoGuia = sql_comando.Parameters.Add("@codigoGuia", SqlDbType.Int);
                        codigoGuia.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DocumentoVentaCabCE F_ActualizaTrasladoExterno(DocumentoVentaCabCE objEntidadBE)
        {
            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings[objEntidadBE.Conexion].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "F_ActualizaTrasladoExterno";

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDocSust", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDocSust", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                        sql_comando.Parameters.Add("@NumeroDocSust", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@Usuario", SqlDbType.VarChar, 100).Value = objEntidadBE.Usuario;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = "";

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaCabCE F_EdicionFactura_Tracto(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Update";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.DateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 10).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 10).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 10).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 10).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 10).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@CodTraslado", SqlDbType.Int).Value = objEntidadBE.CodTraslado;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 10).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 10).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.DateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 250).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@OrdenCompra", SqlDbType.VarChar, 15).Value = objEntidadBE.NroOC;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;
                        sql_comando.Parameters.Add("@Motorizado", SqlDbType.Int).Value = objEntidadBE.Motorizado;
                        sql_comando.Parameters.Add("@Recepcion", SqlDbType.SmallDateTime).Value = objEntidadBE.Recepcion;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@GuiaAgencia", SqlDbType.VarChar, 30).Value = objEntidadBE.GuiaAgencia;
                        sql_comando.Parameters.Add("@ObservacionesCliente", SqlDbType.VarChar, 250).Value = objEntidadBE.ObservacionesCliente;
                        sql_comando.Parameters.Add("@SerieOC", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieOC;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@NombreAgencia", SqlDbType.VarChar, 200).Value = objEntidadBE.NombreAgencia;
                        sql_comando.Parameters.Add("@ClaveAgencia", SqlDbType.VarChar, 20).Value = objEntidadBE.ClaveAgencia;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 100).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 100).Value = objEntidadBE.DireccionTraslado;

                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTransportista", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@CodDepartamentoTransportista", SqlDbType.Int).Value = objEntidadBE.CodDepartamentoTransportista;
                        sql_comando.Parameters.Add("@CodProvinciaTransportista", SqlDbType.Int).Value = objEntidadBE.CodProvinciaTransportista;
                        sql_comando.Parameters.Add("@CodDistritoTransportista", SqlDbType.Int).Value = objEntidadBE.CodDistritoTransportista;
                        sql_comando.Parameters.Add("@DireccionTransportista", SqlDbType.VarChar, 100).Value = objEntidadBE.DireccionTransportista;

                        sql_comando.Parameters.Add("@RazonSocialTransportista  ", SqlDbType.VarChar, 200).Value = objEntidadBE.Transportista;
                        sql_comando.Parameters.Add("@RucTransportista  ", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRucTransportista;

                        sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 100).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 100).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NuBultos", SqlDbType.VarChar, 100).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 100).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@CodConductor", SqlDbType.Int).Value = objEntidadBE.CodConductor;
                        sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;


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



        public DocumentoVentaCabCE F_TemporalFacturacionDetalle_Insert_Yordan(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionDetalle_Insert";

                        sql_comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;
                        sql_comando.Parameters.Add("@SolicitarDescuento", SqlDbType.Int).Value = objEntidadBE.SolicitarDescuento;

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

        public DataTable F_TemporalFacturacionDet_Listar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionDet_Listar";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@Tasa", SqlDbType.Decimal).Value = objEntidadBE.Tasa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        if (objEntidadBE.CodCliente > 0)
                            sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCliente;

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

        public DataTable F_TemporalFacturacionDetPedido_Listar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionDetPedido_Listar";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@CodProforma", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                        sql_comando.Parameters.Add("@FlagReemplazo", SqlDbType.Int).Value = objEntidadBE.Flag; 

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

        public DataTable F_DOCUMENTOVENTACAB_PERMISOOBSERVACION(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_DOCUMENTOVENTACAB_PERMISOOBSERVACION";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                    
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

        public DataTable F_TemporalFacturacionDet_SolicitudDescuentos_Listar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_TemporalFacturacionDet_SolicitudDescuentos_Listar]";

                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Tasa", SqlDbType.Decimal).Value = objEntidadBE.Tasa;

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

        public DataTable F_TemporalFacturacionDet_Listar_Actualizaciones(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionDet_Listar_Actualizaciones";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@Tasa", SqlDbType.Decimal).Value = objEntidadBE.Tasa;

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

        public DataTable F_TemporalFacturacionCab_Listar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionCab_Listar";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
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

        public DocumentoVentaCabCE F_TemporalFacturacionCab_Eliminar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionCab_Eliminar";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.NVarChar, 400);
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

        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Insert";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDocumento", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.DateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;

                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodProforma", SqlDbType.Int).Value = objEntidadBE.CodProforma;

                        sql_comando.Parameters.Add("@CodGuia", SqlDbType.Int).Value = objEntidadBE.CodGuia;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;

                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 150).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;

                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@NotaPedido", SqlDbType.Int).Value = objEntidadBE.NotaPedido;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;

                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;

                        sql_comando.Parameters.Add("@CodNotaVenta", SqlDbType.Int).Value = objEntidadBE.CodClasificacion;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;

                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;

                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_DocumentoVentaCab_Listar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Listar";

                        if (objEntidadBE.CodTipoDoc != 0)
                            sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                        {
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        }
                        if (objEntidadBE.SerieDoc != "TODOS")
                            sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                        if (objEntidadBE.NumeroDoc != "")
                            sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;

                        if (objEntidadBE.CodCliente != 0)
                            sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        if (objEntidadBE.CodEstado != 0)
                            sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;

                        if (objEntidadBE.CodVendedor != 0)
                            sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidadBE.CodVendedor;

                        if (objEntidadBE.CodEmpresa != 0)
                            sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;

                        if (objEntidadBE.Placa != "")
                            sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 8).Value = objEntidadBE.Placa;

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

        public DocumentoVentaCabCE F_DocumentoVentaCab_Anulacion(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Anulacion";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@ObservacionAnulacion", SqlDbType.VarChar, 2000).Value = objEntidadBE.ObservacionAnulacion;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.NVarChar, 400);
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

        public DocumentoVentaCabCE F_TemporalCodigoFacturaCab_Insert(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalCodigoFacturaCab_Insert";

                        sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public DocumentoVentaCabCE F_TemporalCodigoFacturaDet_Insert(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalCodigoFacturaDet_Insert";

                        sql_comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
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

        public DocumentoVentaCabCE F_TemporalCodigoFacturaDet_Update(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalCodigoFacturaDet_Update";

                        sql_comando.Parameters.Add("@CodFacturaDet", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@TC", SqlDbType.Int).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@Soles", SqlDbType.Decimal).Value = objEntidadBE.CobranzaSoles;
                        sql_comando.Parameters.Add("@Dolares", SqlDbType.Decimal).Value = objEntidadBE.CobranzaDolares;
                        if (objEntidadBE.CobroOperacionSoles > 0)
                            sql_comando.Parameters.Add("@xSoles", SqlDbType.Decimal).Value = objEntidadBE.CobroOperacionSoles;
                        if (objEntidadBE.CobroOperacionDolares > 0)
                            sql_comando.Parameters.Add("@xDolares", SqlDbType.Decimal).Value = objEntidadBE.CobroOperacionDolares;


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

        public DocumentoVentaCabCE F_TemporalCodigoCobranzasCab_Insert(FiltroCobranzas objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalCodigoCobranzasCab_Insert";

                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        sql_comando.Parameters.Add("@FlagFiltroFecha", SqlDbType.Int).Value = objEntidadBE.FlagFiltroFecha;
                        if (objEntidadBE.FlagFiltroFecha == 1)
                        {
                            sql_comando.Parameters.Add("@FechaDesde", SqlDbType.Int).Value = objEntidadBE.FechaDesde.ToString("yyyyMMdd");
                            sql_comando.Parameters.Add("@FechaHasta", SqlDbType.Int).Value = objEntidadBE.FechaHasta.ToString("yyyyMMdd");
                        }

                        sql_comando.Parameters.Add("@FlagFiltroMonto", SqlDbType.Int).Value = objEntidadBE.FlagFiltroMonto;
                        if (objEntidadBE.FlagFiltroMonto == 1)
                        {
                            sql_comando.Parameters.Add("@MontoDesde", SqlDbType.Decimal).Value = objEntidadBE.MontoDesde;
                            sql_comando.Parameters.Add("@MontoHasta", SqlDbType.Decimal).Value = objEntidadBE.MontoHasta;
                        }

                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@FlagOC", SqlDbType.Int).Value = objEntidadBE.FlagOC;

                        if (objEntidadBE.CodEmpresa > 0)
                            sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@CodigoTemporal", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter Codigo2 = sql_comando.Parameters.Add("@CodigoTemporalPago", SqlDbType.Int);
                        Codigo2.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodigoTemporal = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.CodigoTemporalPago = Convert.ToInt32(Codigo2.Value);

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_TemporalCodigoCobranzaPagoDet_Listar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalCodigoCobranzaPagoDet_Listar";

                        sql_comando.Parameters.Add("@CodigoTemporal", SqlDbType.Int).Value = objEntidadBE.CodigoTemporal;
                        sql_comando.Parameters.Add("@Tipo", SqlDbType.VarChar, 1).Value = objEntidadBE.Tipo;

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

        public DataTable F_TemporalCodigoFacturaDet_Listar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalCodigoFacturaDet_Listar";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;

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

        public DataTable F_TemporalCodigoFacturaDet_Listar_Excel(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalCodigoFacturaDet_Listar_Excel";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;

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

        public DataTable F_DocumentoVentaCab_ConsultaCobranzas(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_ConsultaCobranzas";

                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCliente;
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

        public DocumentoVentaCabCE F_Cobranzas_RegistroCobranzas(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Cobranzas_RegistroCobranzas";

                        sql_comando.Parameters.Add("@Tipo", SqlDbType.VarChar, 1).Value = objEntidadBE.Tipo;
                        sql_comando.Parameters.Add("@CodigoTemporalCobranza", SqlDbType.Int).Value = objEntidadBE.CodigoTemporal;
                        sql_comando.Parameters.Add("@CodigoTemporalPago", SqlDbType.Int).Value = objEntidadBE.CodigoTemporalPago;
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
                        sql_comando.Parameters.Add("@CobroOperacionSoles", SqlDbType.Decimal).Value = objEntidadBE.CobroOperacionSoles;
                        sql_comando.Parameters.Add("@CobranzaDolares", SqlDbType.Decimal).Value = objEntidadBE.CobranzaDolares;
                        sql_comando.Parameters.Add("@DeudaDolares", SqlDbType.Decimal).Value = objEntidadBE.DeudaDolares;
                        sql_comando.Parameters.Add("@CobroOperacionDolares", SqlDbType.Decimal).Value = objEntidadBE.CobroOperacionDolares;
                        sql_comando.Parameters.Add("@CodCtacte", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;
                        sql_comando.Parameters.Add("@TipoDevolucion", SqlDbType.Int).Value = objEntidadBE.TipoDevolucion;
                        sql_comando.Parameters.Add("@CodMonedaVuelto", SqlDbType.Int).Value = objEntidadBE.CodMonedaVuelto;
                        sql_comando.Parameters.Add("@Vuelto", SqlDbType.Decimal).Value = objEntidadBE.Vuelto;
                        sql_comando.Parameters.Add("@Vuelto2", SqlDbType.Decimal).Value = objEntidadBE.Vuelto2;
                        sql_comando.Parameters.Add("@Tasa", SqlDbType.Decimal).Value = objEntidadBE.Tasa;
                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@NroRecibo", SqlDbType.VarChar,15).Value = objEntidadBE.NroRecibo;
                        sql_comando.Parameters.Add("@Cobrador", SqlDbType.Int).Value = objEntidadBE.Cobrador;
                        sql_comando.Parameters.Add("@ComisionTarjeta", SqlDbType.Decimal).Value = objEntidadBE.ComisionTarjeta;

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

        public DocumentoVentaCabCE F_Cobranzas_RegistroCobranzas_Excel(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_Cobranzas_RegistroCobranzas_Excel]";

                        sql_comando.Parameters.Add("@CodigoTemporalCobranza", SqlDbType.Int).Value = objEntidadBE.CodigoTemporal;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@Observaciones", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter CodCobranzaExcelCab = sql_comando.Parameters.Add("@CodCobranzaExcelCab", SqlDbType.Int);
                        CodCobranzaExcelCab.Direction = ParameterDirection.Output;

                        //@CodCobranzaExcelCab

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodCobranza = Convert.ToInt32(CodCobranzaExcelCab.Value);
                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Cobranzas_RegistroCobranzas_Listar_Excel(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_Cobranzas_RegistroCobranzas_Listar_Excel]";

                        sql_comando.Parameters.Add("@CodCobranzaExcelCab", SqlDbType.Int).Value = objEntidadBE.CodCobranza;

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

        public Cobranzas F_Pagos_Edicion_MedioPago(Cobranzas objEntidadBE)
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
                        sql_comando.CommandText = "pa_Pagos_Edicion_MedioPago";

                        sql_comando.Parameters.Add("@CodCobranzaCab", SqlDbType.Int).Value = objEntidadBE.CodCobranza;
                        sql_comando.Parameters.Add("@CodBanco", SqlDbType.Int).Value = objEntidadBE.CodBanco;
                        sql_comando.Parameters.Add("@CodCtaBancaria", SqlDbType.Int).Value = objEntidadBE.CodCtaBancaria;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 250).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@Comision", SqlDbType.Decimal).Value = objEntidadBE.Comision;

                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;
                        sql_comando.Parameters.Add("@CodMedioPago", SqlDbType.Int).Value = objEntidadBE.CodMedioPago;
                        sql_comando.Parameters.Add("@CodUsuarioModificacion", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@Recibo", SqlDbType.VarChar, 250).Value = objEntidadBE.Recibo;

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

        public Cobranzas F_Cobranzas_Edicion_MedioPago(Cobranzas objEntidadBE)
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
                        sql_comando.CommandText = "pa_Cobranzas_Edicion_MedioPago";

                        sql_comando.Parameters.Add("@CodCobranzaCab", SqlDbType.Int).Value = objEntidadBE.CodCobranza;
                        sql_comando.Parameters.Add("@CodBanco", SqlDbType.Int).Value = objEntidadBE.CodBanco;
                        sql_comando.Parameters.Add("@CodCtaBancaria", SqlDbType.Int).Value = objEntidadBE.CodCtaBancaria;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 250).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@Comision", SqlDbType.Decimal).Value = objEntidadBE.Comision;

                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;
                        sql_comando.Parameters.Add("@CodMedioPago", SqlDbType.Int).Value = objEntidadBE.CodMedioPago;
                        sql_comando.Parameters.Add("@Recibo", SqlDbType.VarChar, 250).Value = objEntidadBE.Recibo;
                        sql_comando.Parameters.Add("@ComisionTarjeta", SqlDbType.Decimal).Value = objEntidadBE.ComisionTarjeta;
                        sql_comando.Parameters.Add("@CodUsuarioModificacion", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
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

        public DataTable F_Cobranzas_Listar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Cobranzas_Listar";

                        if (objEntidadBE.NumeroDoc != "")
                            sql_comando.Parameters.Add("@Numero", SqlDbType.VarChar, 15).Value = objEntidadBE.NumeroDoc;

                        if (objEntidadBE.CodCliente != 0)
                            sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        if (objEntidadBE.CodMedioPago > 0)
                            sql_comando.Parameters.Add("@CodMedioPago", SqlDbType.Int).Value = objEntidadBE.CodMedioPago;

                        if (objEntidadBE.CodCajaFisica > 0)
                            sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;

                        if (objEntidadBE.CodEmpresa > 0)
                            sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;

                        if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                        {
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        }

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

                        if (objEntidadBE.CodTipoDoc > 0)
                        sql_comando.Parameters.Add("@codTipodoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;

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

        public DataTable F_Cobranzas_RegistroCobranzasCab_Listar_Excel(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_Cobranzas_RegistroCobranzasCab_Listar_Excel]";

                        if (objEntidadBE.CodCliente != 0)
                            sql_comando.Parameters.Add("@CodCobranzaExcelCab", SqlDbType.Int).Value = objEntidadBE.CodCobranza;

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

        public DocumentoVentaCabCE F_Cobranzas_Anulacion(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Cobranzas_Anulacion";

                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodCobranza", SqlDbType.Int).Value = objEntidadBE.CodCobranza;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@Observaciones", SqlDbType.VarChar, 250).Value = objEntidadBE.ObservacionAnulacion;

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

        public DataTable F_OperacionNC_Listar()
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
                        sql_comando.CommandText = "pa_Operaciones_NC";
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

        public DocumentoVentaCabCE F_Cobranzas_RegistroCobranzas_Letras(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Cobranzas_RegistroCobranzas_Letras";

                        sql_comando.Parameters.Add("@CodigoTemporal", SqlDbType.Int).Value = objEntidadBE.CodigoTemporal;
                        sql_comando.Parameters.Add("@CodigoTemporalPago", SqlDbType.Int).Value = objEntidadBE.CodigoTemporalPago;
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
                        sql_comando.Parameters.Add("@CobroOperacionSoles", SqlDbType.Decimal).Value = objEntidadBE.CobroOperacionSoles;
                        sql_comando.Parameters.Add("@CobranzaDolares", SqlDbType.Decimal).Value = objEntidadBE.CobranzaDolares;
                        sql_comando.Parameters.Add("@DeudaDolares", SqlDbType.Decimal).Value = objEntidadBE.DeudaDolares;
                        sql_comando.Parameters.Add("@CobroOperacionDolares", SqlDbType.Decimal).Value = objEntidadBE.CobroOperacionDolares;
                        sql_comando.Parameters.Add("@CodCtacte", SqlDbType.Int).Value = objEntidadBE.CodCliente;
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

        public DataTable F_DocumentoVentaCab_Impresion(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Impresion";
                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;                        
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

        public DataTable F_DocumentoVentaCab_Impresion_Tickets(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_ImpresionFlagTicket_Insert";
                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@IP", SqlDbType.VarChar).Value = objEntidadBE.IP;
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

        public DataTable F_DocumentoVentaCab_FacturaRetenciones(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_FacturaRetenciones";

                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@Monto", SqlDbType.Decimal).Value = objEntidadBE.Total;
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

        public DocumentoVentaCabCE F_DocumentoVentaCab_Retenciones_Insert(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ObligacionesTributarias_Insert";

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDocumento", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@FechaCancelacion", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaCancelacion;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@CodTemporal", SqlDbType.Int).Value = objEntidadBE.CodigoTemporal;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@Responsable", SqlDbType.VarChar, 200).Value = objEntidadBE.Responsable;
                        sql_comando.Parameters.Add("@Tasa", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;

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

        public DocumentoVentaCabCE F_DocumentoVentaCab_AnulacionRetencion(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_AnulacionRetencion";

                        sql_comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 1000).Value = objEntidadBE.Observacion;
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

        public DataTable F_DocumentoVentaCab_Retenciones_Listar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ObligacionesTributariasCab_Listar";

                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                        {
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        }
                        if (objEntidadBE.SerieDoc != "TODOS")
                            sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                        if (objEntidadBE.NumeroDoc != "")
                            sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;

                        if (objEntidadBE.CodCliente > 0)
                            sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        if (objEntidadBE.CodEstado > 0)
                            sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;

                        if (objEntidadBE.CodVendedor > 0)
                            sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidadBE.CodVendedor;

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

        public DataTable F_DocumentoVentaCab_Retencion_Impresion(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ObligacionesTributariasCab_Impresion";
                        sql_comando.Parameters.Add("@CodObligacionTributariaCab", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
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

        public DocumentoVentaCabCE F_DocumentoVentaCab_FacturacionNV(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_FacturacionNV";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@FechaVencimiento", SqlDbType.DateTime).Value = objEntidadBE.FechaVencimiento;


                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodSerie", SqlDbType.Int).Value = objEntidadBE.CodSerie;



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

        public DocumentoVentaCabCE F_DocumentoVentaCab_DevolucionNV(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_DevolucionNV";

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

        public DataTable F_DocumentoVentaCab_OCXFacturar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_OCXFacturar";

                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;

                        if (objEntidadBE.CodTipoDoc > 0)
                            sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;

                        if (objEntidadBE.SerieDoc != "")
                            sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                        if (objEntidadBE.NumeroDoc != "")
                            sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;

                        if (objEntidadBE.CodAlmacen > 0)
                            sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

                        if (objEntidadBE.CodVendedor != 0)
                            sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidadBE.CodVendedor;

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

        public DocumentoVentaCabCE F_DocumentoVentaCab_DevolucionOC(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_DevolucionOC";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@CodTasaIgv", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCliente;
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

        public DocumentoVentaCabCE F_TemporalSerializacionCab_Insert(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalSerializacionCab_Insert";

                        sql_comando.Parameters.Add("@CodSerializacionCab", SqlDbType.Int).Value = objEntidadBE.CodSerializacionCab;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@Serie", SqlDbType.VarChar, 50).Value = objEntidadBE.Serie;
                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public DataTable F_TemporalSerializacionCab_Listar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalSerializacionCab_Listar";

                        sql_comando.Parameters.Add("@CodSerializacionCab", SqlDbType.Int).Value = objEntidadBE.CodSerializacionCab;

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

        public DocumentoVentaCabCE F_Serializacion_Insert(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Serializacion_Insert";

                        sql_comando.Parameters.Add("@CodSerializacionCab", SqlDbType.Int).Value = objEntidadBE.CodSerializacionCab;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 250);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = Convert.ToString(MsgError.Value);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public DocumentoVentaCabCE F_TemporalFacturacionSerializacionDet_Insert(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionSerializacionDet_Insert";


                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@Serie", SqlDbType.VarChar, 50).Value = objEntidadBE.Serie;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TC", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;

                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public DocumentoVentaCabCE F_TemporalFacturacionSerializacionDetalle_Insert(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionSerializacionDetalle_Insert";

                        sql_comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@Serie", SqlDbType.VarChar, 50).Value = objEntidadBE.Serie;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TC", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;

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

        public DocumentoVentaCabCE F_DocumentoVentaCab_VentaPalieres_Insert(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_VentaPalieres_Insert";


                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
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

        public DocumentoVentaCabCE F_TemporalFacturacionSerializacionDet_Insert_Compras(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionSerializacionDet_Insert_Compras";


                        sql_comando.Parameters.Add("@CodDetDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDetDocumentoVenta;
                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                        sql_comando.Parameters.Add("@Serie", SqlDbType.VarChar, 50).Value = objEntidadBE.Serie;

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

        public DataTable F_DocumentoVentaCab_ListarXCodigo(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_ListarXCodigo";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;

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

        public DocumentoVentaCabCE F_DocumentoVentaDet_InsertTemporal(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaDet_InsertTemporal";

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
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

        public DataTable F_DocumentoVentaCab_VentasDiarias(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_VentasDiarias";

                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");

                        if (objEntidadBE.CodEstado != 0)
                            sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;

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

        public DataTable F_LGProductos_VentasUnidades(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_VentasUnidades";

                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        if (objEntidadBE.IdFamilia != 0)
                            sql_comando.Parameters.Add("@CodFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;

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

        public DataTable F_DocumentoVentaCab_Ventas(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Ventas";

                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        if (!objEntidadBE.SerieDoc.Equals("0"))
                            sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
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

        public DocumentoVentaCabCE F_VendedoresExternos_Insert(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_VendedoresExternos_Insert";

                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@Vendedor", SqlDbType.VarChar, 300).Value = objEntidadBE.Vendedor;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = Convert.ToString(MsgError.Value);


                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public DataTable F_Comisiones_Listar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Comisiones_Listar";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;

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

        public DataTable F_Vendedores_Listar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Vendedores_Listar";

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

        public DocumentoVentaCabCE F_Comisiones_Insert(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Comisiones_Insert";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidadBE.CodVendedor;
                        sql_comando.Parameters.Add("@Comision", SqlDbType.Decimal).Value = objEntidadBE.Comision;
                        sql_comando.Parameters.Add("@TotalFactura", SqlDbType.VarChar, 300).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = Convert.ToString(MsgError.Value);


                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public DataTable F_Comisiones_Reporte(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Comisiones_Reporte";

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");

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

        public DataTable F_DocumentoVentaCab_ConsultaCobranzas_NotaVenta(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_ConsultaCobranzas_NotaVenta";

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

        public DataTable F_Cobranzas_cxc_Reporte(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Cobranzas_cxc_Reporte";

                        if (objEntidadBE.CodCliente != 0)
                            sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        if (objEntidadBE.CodEstado != 0)
                            sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;

                        if (objEntidadBE.Hasta.ToString("yyyyMMdd") != "19000101")
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");

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

        public DataTable F_Cobranzas_Reporte(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Cobranzas_Reporte";

                        sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;

                        if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                        {
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        }

                        if (objEntidadBE.CodTipoDoc != 0)
                            sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;

                        if (objEntidadBE.CodVendedor != 0)
                            sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidadBE.CodVendedor;

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

        public DataTable F_Cobranzas_Reporte_Credito(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Cobranzas_Reporte_Credito";

                        sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;

                        if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                        {
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        }

                        if (objEntidadBE.CodTipoDoc != 0)
                            sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;

                        if (objEntidadBE.CodVendedor != 0)
                            sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidadBE.CodVendedor;

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

        public DataTable F_Cobranzas_Facturas_Vencidas_Reporte(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Cobranzas_Facturas_Vencidas_Reporte";

                        sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;

                        if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                        {
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        }

                        if (objEntidadBE.CodTipoDoc != 0)
                            sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;

                        if (objEntidadBE.CodVendedor != 0)
                            sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidadBE.CodVendedor;

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

        public DataTable F_DOCUMENTOVENTACAB_FACTURAS_VENCIDAS_RESUMIDO(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_DOCUMENTOVENTACAB_FACTURAS_VENCIDAS_RESUMIDO";

                        sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;

                        if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                        {
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        }

                        if (objEntidadBE.CodTipoDoc != 0)
                            sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;

                        if (objEntidadBE.CodVendedor != 0)
                            sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidadBE.CodVendedor;

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

        public DataTable F_Cobranzas_Reporte_Cobrados(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Cobranzas_Reporte_Cobrados";

                        if (objEntidadBE.CodCliente != 0)
                            sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");

                        if (objEntidadBE.Hasta.ToString("yyyyMMdd") != "19900101")
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");

                        if (objEntidadBE.CodTipoDoc != 0)
                            sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;

                        if (objEntidadBE.CodVendedor != 0)
                            sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidadBE.CodVendedor;

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

        public DataTable F_DOCUMENTOVENTACAB_REPORTECOBRANZARESUMIDO(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_DOCUMENTOVENTACAB_REPORTECOBRANZARESUMIDO";


                        if (objEntidadBE.CodCliente != 0)
                            sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");

                        if (objEntidadBE.Hasta.ToString("yyyyMMdd") != "19900101")
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");

                        if (objEntidadBE.CodTipoDoc != 0)
                            sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;

                        if (objEntidadBE.CodVendedor != 0)
                            sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidadBE.CodVendedor;

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

        public DataTable F_Cobranzas_Reporte_COBRADOS_HASTA(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Cobranzas_Reporte_COBRADOS_HASTA";

                        sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;

                        if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                        {
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        }

                        if (objEntidadBE.CodTipoDoc != 0)
                            sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;

                        if (objEntidadBE.CodVendedor != 0)
                            sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidadBE.CodVendedor;

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

        public DataTable F_ComprobanteCaja_COMISIONES(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_ComprobanteCaja_COMISIONES";
                       
                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");                  
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
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

        public DocumentoVentaCabCE F_DocumentoVentaCab_NotaCredito_Insert(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_NotaCredito_Insert";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodFactura_Asociada", SqlDbType.Int).Value = objEntidadBE.CodFactura_Asociada;
                        sql_comando.Parameters.Add("@CodTipoOperacionNC", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacionNC;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;
                        if (objEntidadBE.FlagCSIgv > 0)
                            sql_comando.Parameters.Add("@FlagCSIgv", SqlDbType.Int).Value = objEntidadBE.FlagCSIgv;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;
                        sql_comando.Parameters.Add("@ObservacionCliente", SqlDbType.VarChar, 500).Value = objEntidadBE.ObservacionesCliente;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaCabCE F_DocumentoVentaCab_NotaCredito_Insert_Alvarado(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_NotaCredito_Insert";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodFactura_Asociada", SqlDbType.Int).Value = objEntidadBE.CodFactura_Asociada;
                        sql_comando.Parameters.Add("@CodTipoOperacionNC", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacionNC;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;
                        sql_comando.Parameters.Add("@ObservacionCliente", SqlDbType.VarChar, 1000).Value = objEntidadBE.ObservacionesCliente;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_DocumentoVentaCab_ListarXCodigo_NotaCredito(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_ListarXCodigo_NotaCredito";

                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 15).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
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

        public DataTable F_DocumentoVentaCab_NVXFacturar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_NVXFacturar";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                        {
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        }

                        if (objEntidadBE.NumeroDoc != "")
                            sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;

                        if (objEntidadBE.SerieDoc != "TODOS")
                            sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

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

        public DataTable F_DocumentoVentaCab_FACTURAR_ANTICIPOS(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_FACTURAR_ANTICIPOS";

                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                        {
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        }

                        if (objEntidadBE.NumeroDoc != "")
                            sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;

                        if (objEntidadBE.SerieDoc != "TODOS")
                            sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

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

        public DocumentoVentaCabCE F_DocumentoVentaCab_Eliminacion(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Eliminacion";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.NVarChar, 400);
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

        public DataTable F_OrdenCompra_Venta_Historial(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_OrdenCompra_Venta_Historial";

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

        public DataTable F_DocumentoVentaCab_HistorialVentaSunat(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_HistorialVentaSunat";

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

        public DocumentoVentaCabCE F_LGProductos_UnirCodigos(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_LGProductos_UnirCodigos";

                        sql_comando.Parameters.Add("@CodProductoCorrecto", SqlDbType.Int).Value = objEntidadBE.CodProductoCorrecto;
                        sql_comando.Parameters.Add("@CodProductoIncorrecto", SqlDbType.Int).Value = objEntidadBE.CodProductoIncorrecto;

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
        
        public DocumentoVentaCabCE F_CajaChica_Insertar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_CajaChica_Insertar";

                        sql_comando.Parameters.Add("@FechaCaja", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 400);
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

        public DataTable F_CajaChica_Reporte(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_CajaChica_Reporte";

                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
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

        public DataTable F_CajaChicaDetalle_Reporte(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_CajaChicaDetalle_Reporte";

                        sql_comando.Parameters.Add("@FechaCaja", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@FechaHasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
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

        public DataTable F_CajaChicaDetalle_Listar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_CajaChicaDetalle_Listar";

                        sql_comando.Parameters.Add("@CodCajaChica", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;

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

        public DocumentoVentaCabCE F_CajaChica_Regenerar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_CajaChica_Regenerar";

                        sql_comando.Parameters.Add("@FechaCaja", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;
                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@FechaSaldo", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaSaldo;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 400);
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

        public DocumentoVentaCabCE F_CajaChica_Liquidacion(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_CajaChica_Liquidacion";

                        sql_comando.Parameters.Add("@CodCajaChica", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 400);
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

        public DataTable F_CajaChica_Detalle(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_CajaChica_Detalle";

                        sql_comando.Parameters.Add("@FechaCaja", SqlDbType.Int).Value = objEntidadBE.FechaEmision.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@FechaSaldo", SqlDbType.Int).Value = objEntidadBE.FechaSaldo.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;
                        if (objEntidadBE.CodMedioPago>0)
                            sql_comando.Parameters.Add("@CodMedioPago", SqlDbType.Int).Value = objEntidadBE.CodMedioPago;
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

        public DataTable F_Reporte_VoucherCobranzas(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_Reporte_VoucherCobranzas]";

                        sql_comando.Parameters.Add("@Fecha", SqlDbType.Int).Value = objEntidadBE.FechaEmision.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
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

        public DocumentoVentaCabCE F_ComprobanteCaja_Eliminar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ComprobanteCaja_Eliminar";

                        sql_comando.Parameters.Add("@CodComprobanteCaja", SqlDbType.Int).Value = objEntidadBE.CodComprobanteCaja;

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

        public DocumentoVentaCabCE F_ComprobanteCaja_Anulacion(DocumentoVentaCabCE objEntidadBE)
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

        public DocumentoVentaCabCE F_DocumentoVentaCab_Anulacion_NotaCredito(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Anulacion_NotaCredito";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@ObservacionAnulacion", SqlDbType.VarChar, 2000).Value = objEntidadBE.ObservacionAnulacion;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.NVarChar, 400);
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

        public DocumentoVentaCabCE F_DocumentoVentaCab_Eliminacion_NotaCredito(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Eliminacion_NotaCredito";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.NVarChar, 400);
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

        public DataTable F_DocumentoVentaCab_HistorialVentas(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_HistorialVentas";

                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        if (!objEntidadBE.SerieDoc.Equals("0"))
                            sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
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

        public DataTable F_VentasPorUnidad(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_VentasPorUnidad_Listar";

                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        if (objEntidadBE.CodAlmacen != 0)
                            sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;

                        if (objEntidadBE.IdFamilia != 0)
                            sql_comando.Parameters.Add("@CodFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;

                        if (objEntidadBE.Marca != "TODOS")
                            sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 100).Value = objEntidadBE.Marca;

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

        public DocumentoVentaCabCE F_TrasladosCab_GuiaInterna_Producto_Insert(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TrasladosCab_GuiaInterna_Producto_Insert";

                        sql_comando.Parameters.Add("@CodAlmacenPartida", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodAlmacenDestino", SqlDbType.Int).Value = objEntidadBE.CodAlmacenDestino;
                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = objEntidadBE.Cantidad;
                        sql_comando.Parameters.Add("@CodAlterno", SqlDbType.VarChar, 15).Value = objEntidadBE.CodAlterno;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 250);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = Convert.ToString(MsgError.Value);

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaCabCE Async_F_TrasladosCab_GuiaInterna_Producto_Insert(DocumentoVentaCabCE objEntidadBE)
        {
            ProcesosAsincronos pAsync = new ProcesosAsincronos();
            pAsync.F_Async_TrasladosCab_GuiaInterna_Producto_Insert(objEntidadBE);
            return null;
        }

        private class ProcesosAsincronos
        {

            public void F_Async_TrasladosCab_GuiaInterna_Producto_Insert(DocumentoVentaCabCE objEntidadBE)
            {
                System.Threading.Thread thread = new System.Threading.Thread(() => F_TrasladosCab_GuiaInterna_Producto_Insert(objEntidadBE));
                thread.Start();
            }
            private DocumentoVentaCabCE F_TrasladosCab_GuiaInterna_Producto_Insert(DocumentoVentaCabCE objEntidadBE)
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
                            sql_comando.CommandText = "pa_TrasladosCab_GuiaInterna_Producto_Insert";

                            sql_comando.Parameters.Add("@CodAlmacenPartida", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                            sql_comando.Parameters.Add("@CodAlmacenDestino", SqlDbType.Int).Value = objEntidadBE.CodAlmacenDestino;
                            sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                            sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                            sql_comando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = objEntidadBE.Cantidad;
                            sql_comando.Parameters.Add("@CodAlterno", SqlDbType.VarChar, 15).Value = objEntidadBE.CodAlterno;

                            SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 250);
                            MsgError.Direction = ParameterDirection.Output;

                            sql_comando.ExecuteNonQuery();

                            objEntidadBE.MsgError = Convert.ToString(MsgError.Value);

                        }
                    }
                }
                catch (Exception ex)
                {

                }
                return objEntidadBE;
            }

        }

        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert_Factura_NV(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Insert_Factura_NV";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;
                        sql_comando.Parameters.Add("@AcuentaNV", SqlDbType.Decimal).Value = objEntidadBE.AcuentaNV;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 250).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                        sql_comando.Parameters.Add("@FlagCSIgv", SqlDbType.Int).Value = objEntidadBE.FlagCSIgv;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@ObservacionesCliente", SqlDbType.VarChar, 2000).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 200).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTrans", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 50).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NroBultos", SqlDbType.VarChar, 50).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 50).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 50).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@NroOC", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOC;
                        sql_comando.Parameters.Add("@Placa1", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;

                        // DATOS DE LA GUIA ELECTRONICA
                        sql_comando.Parameters.Add("@CodConductor", SqlDbType.Int).Value = objEntidadBE.CodConductor;
                        sql_comando.Parameters.Add("@DniConductor", SqlDbType.VarChar, 8).Value = objEntidadBE.DniConductor;
                        sql_comando.Parameters.Add("@NombreConductor", SqlDbType.VarChar, 350).Value = objEntidadBE.NombreConductor;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter CodGuia = sql_comando.Parameters.Add("@CodGuia", SqlDbType.Int);
                        CodGuia.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.CodGuia = Convert.ToInt32(CodGuia.Value);

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert_Factura_NV_Karina(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Insert_Factura_NV";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;
                        sql_comando.Parameters.Add("@AcuentaNV", SqlDbType.Decimal).Value = objEntidadBE.AcuentaNV;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 250).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                        sql_comando.Parameters.Add("@FlagCSIgv", SqlDbType.Int).Value = objEntidadBE.FlagCSIgv;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;

                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 200).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTrans", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 50).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NroBultos", SqlDbType.VarChar, 50).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 50).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 50).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo;
                        //sql_comando.Parameters.Add("@NroOC", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOC;
                        sql_comando.Parameters.Add("@Placa1", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;

                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 1000).Value = objEntidadBE.ObservacionesCliente;
                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert_Factura_NV_Alvarado(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Insert_Factura_NV";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;
                        sql_comando.Parameters.Add("@AcuentaNV", SqlDbType.Decimal).Value = objEntidadBE.AcuentaNV;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 250).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                        sql_comando.Parameters.Add("@FlagCSIgv", SqlDbType.Int).Value = objEntidadBE.FlagCSIgv;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;

                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 200).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTrans", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 50).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NroBultos", SqlDbType.VarChar, 50).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 50).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 50).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@NroOC", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOC;
                        sql_comando.Parameters.Add("@Placa1", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;

                        // DATOS GUIA ELECTRONICA
                        sql_comando.Parameters.Add("@CodConductor", SqlDbType.Int).Value = objEntidadBE.CodConductor;
                        sql_comando.Parameters.Add("@DniConductor", SqlDbType.VarChar, 8).Value = objEntidadBE.DniConductor;
                        sql_comando.Parameters.Add("@NombreConductor", SqlDbType.VarChar, 350).Value = objEntidadBE.NombreConductor;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;
                        sql_comando.Parameters.Add("@ComisionTarjeta", SqlDbType.Decimal).Value = objEntidadBE.ComisionTarjeta;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter CodigoGuia = sql_comando.Parameters.Add("@CodTraslado", SqlDbType.Int);
                        CodigoGuia.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.CodGuia = Convert.ToInt32(CodigoGuia.Value);

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert_Factura_NV_Salcedo(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Insert_Factura_NV";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;
                        sql_comando.Parameters.Add("@AcuentaNV", SqlDbType.Decimal).Value = objEntidadBE.AcuentaNV;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 250).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                        sql_comando.Parameters.Add("@FlagCSIgv", SqlDbType.Int).Value = objEntidadBE.FlagCSIgv;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;

                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 200).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTrans", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 50).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NroBultos", SqlDbType.VarChar, 50).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 50).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 50).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@Celular", SqlDbType.VarChar, 50).Value = objEntidadBE.Celular;
                        sql_comando.Parameters.Add("@NroOC", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOC;
                        sql_comando.Parameters.Add("@Placa1", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;

                        // DATOS GUIA ELECTRONICA
                        sql_comando.Parameters.Add("@CodConductor", SqlDbType.Int).Value = objEntidadBE.CodConductor;
                        sql_comando.Parameters.Add("@DniConductor", SqlDbType.VarChar, 8).Value = objEntidadBE.DniConductor;
                        sql_comando.Parameters.Add("@NombreConductor", SqlDbType.VarChar, 350).Value = objEntidadBE.NombreConductor;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter CodigoGuia = sql_comando.Parameters.Add("@CodGuia", SqlDbType.Int);
                        CodigoGuia.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.CodGuia = Convert.ToInt32(CodigoGuia.Value);

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert_Factura_NV_Povis(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Insert_Factura_NV";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;
                        sql_comando.Parameters.Add("@AcuentaNV", SqlDbType.Decimal).Value = objEntidadBE.AcuentaNV;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 250).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                        sql_comando.Parameters.Add("@FlagCSIgv", SqlDbType.Int).Value = objEntidadBE.FlagCSIgv;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;

                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 200).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTrans", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 50).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NroBultos", SqlDbType.VarChar, 50).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 50).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 50).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@NroOC", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOC;
                        sql_comando.Parameters.Add("@Placa1", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;

                        sql_comando.Parameters.Add("@CodConductor", SqlDbType.Int).Value = objEntidadBE.CodConductor;
                        sql_comando.Parameters.Add("@DniConductor", SqlDbType.VarChar, 8).Value = objEntidadBE.DniConductor;
                        sql_comando.Parameters.Add("@NombreConductor", SqlDbType.VarChar, 350).Value = objEntidadBE.NombreConductor;
                        sql_comando.Parameters.Add("@ObservacionesCliente", SqlDbType.VarChar, 350).Value = objEntidadBE.ObservacionesCliente;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert_Factura_NV_Roman(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Insert_Factura_NV";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;
                        sql_comando.Parameters.Add("@AcuentaNV", SqlDbType.Decimal).Value = objEntidadBE.AcuentaNV;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 250).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                        sql_comando.Parameters.Add("@FlagCSIgv", SqlDbType.Int).Value = objEntidadBE.FlagCSIgv;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;

                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 200).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTrans", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 50).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NroBultos", SqlDbType.VarChar, 50).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 50).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 50).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@NroOC", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOC;
                        sql_comando.Parameters.Add("@Placa1", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 1000).Value = objEntidadBE.Observacion;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert_Factura_NONV(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Insert_Factura_NONV";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 250).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                        sql_comando.Parameters.Add("@FlagCSIgv", SqlDbType.Int).Value = objEntidadBE.FlagCSIgv;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;

                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 200).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTrans", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 50).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NroBultos", SqlDbType.VarChar, 50).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 50).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 50).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@ObservacionesCliente", SqlDbType.VarChar, 2000).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@Placa1", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@NroOC", SqlDbType.VarChar, 100).Value = objEntidadBE.NroOC;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;

                        // DATOS DE LA GUIA ELECTRONICA
                        sql_comando.Parameters.Add("@CodConductor", SqlDbType.Int).Value = objEntidadBE.CodConductor;
                        sql_comando.Parameters.Add("@DniConductor", SqlDbType.VarChar, 8).Value = objEntidadBE.DniConductor;
                        sql_comando.Parameters.Add("@NombreConductor", SqlDbType.VarChar, 350).Value = objEntidadBE.NombreConductor;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter CodGuia = sql_comando.Parameters.Add("@CodGuia", SqlDbType.Int);
                        CodGuia.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.CodGuia = Convert.ToInt32(CodGuia.Value);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert_Factura_NONV_Karina(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Insert_Factura_NONV";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 250).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                        sql_comando.Parameters.Add("@FlagCSIgv", SqlDbType.Int).Value = objEntidadBE.FlagCSIgv;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;

                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 200).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTrans", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 50).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NroBultos", SqlDbType.VarChar, 50).Value = objEntidadBE.NuBultos; 
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 1000).Value = objEntidadBE.ObservacionesCliente;
                       
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 50).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 50).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo;

                        sql_comando.Parameters.Add("@Placa1", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        //sql_comando.Parameters.Add("@NroOC", SqlDbType.VarChar, 100).Value = objEntidadBE.NroOC;
                        //sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert_Factura_NONV_Alvarado(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Insert_Factura_NONV";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 250).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                        sql_comando.Parameters.Add("@FlagCSIgv", SqlDbType.Int).Value = objEntidadBE.FlagCSIgv;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;

                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@RucTransportista", SqlDbType.VarChar, 50).Value = objEntidadBE.NroRucTransportista;
                        sql_comando.Parameters.Add("@CodDepartamentoTrasportista", SqlDbType.Int).Value = objEntidadBE.CodDepartamentoTransportista;
                        sql_comando.Parameters.Add("@RazonSocialTrasportista", SqlDbType.VarChar, 500).Value = objEntidadBE.Transportista;
                        sql_comando.Parameters.Add("@CodProvinciaTrasportista", SqlDbType.Int).Value = objEntidadBE.CodProvinciaTransportista;
                        sql_comando.Parameters.Add("@CodDistritoTrasportista", SqlDbType.Int).Value = objEntidadBE.CodDistritoTransportista;
                        sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 200).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTrans", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 50).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NroBultos", SqlDbType.VarChar, 50).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 50).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 50).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo;

                        sql_comando.Parameters.Add("@Placa1", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@NroOC", SqlDbType.VarChar, 100).Value = objEntidadBE.NroOC;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;
                        
                        // DATOS DE LA GUIA ELECTRONICA
                        sql_comando.Parameters.Add("@CodConductor", SqlDbType.Int).Value = objEntidadBE.CodConductor;
                        sql_comando.Parameters.Add("@DniConductor", SqlDbType.VarChar, 8).Value = objEntidadBE.DniConductor;
                        sql_comando.Parameters.Add("@NombreConductor", SqlDbType.VarChar, 350).Value = objEntidadBE.NombreConductor;

                        sql_comando.Parameters.Add("@UsuarioPermiso", SqlDbType.VarChar, 160).Value = objEntidadBE.UsuarioPermiso;
                        sql_comando.Parameters.Add("@ClavePermiso", SqlDbType.VarChar, 60).Value = objEntidadBE.ClavePermiso;
                        sql_comando.Parameters.Add("@ObservacionPermiso", SqlDbType.VarChar, 300).Value = objEntidadBE.ObservacionPermiso;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;
                        sql_comando.Parameters.Add("@ComisionTarjeta", SqlDbType.Decimal).Value = objEntidadBE.ComisionTarjeta;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter CodGuia = sql_comando.Parameters.Add("@CodTraslado", SqlDbType.Int);
                        CodGuia.Direction = ParameterDirection.Output;
                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.CodGuia = Convert.ToInt32(CodGuia.Value);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert_Factura_NONV_Povis(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Insert_Factura_NONV";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 250).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                        sql_comando.Parameters.Add("@FlagCSIgv", SqlDbType.Int).Value = objEntidadBE.FlagCSIgv;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@CodTipoFormato", SqlDbType.Int).Value = objEntidadBE.CodTipoFormato;

                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 200).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTrans", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 50).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NroBultos", SqlDbType.VarChar, 50).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 50).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 50).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo;

                        sql_comando.Parameters.Add("@Placa1", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@NroOC", SqlDbType.VarChar, 100).Value = objEntidadBE.NroOC;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;

                        sql_comando.Parameters.Add("@NroRucTransportista", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRucTransportista;
                        sql_comando.Parameters.Add("@RazonSocialTransportista", SqlDbType.VarChar, 300).Value = objEntidadBE.Transportista;
                        sql_comando.Parameters.Add("@DireccionTransportista", SqlDbType.VarChar, 300).Value = objEntidadBE.DireccionTransportista;

                        sql_comando.Parameters.Add("@DepartamentoTransportista", SqlDbType.VarChar, 300).Value = objEntidadBE.DepartamentoTransportista;
                        sql_comando.Parameters.Add("@ProvinciaTransportista", SqlDbType.VarChar, 300).Value = objEntidadBE.ProvinciaTransportista;
                        sql_comando.Parameters.Add("@DistritoTransportista", SqlDbType.VarChar, 300).Value = objEntidadBE.DistritoTransportista;

                        sql_comando.Parameters.Add("@CodDepartamentoTransportista", SqlDbType.Int).Value = objEntidadBE.CodDepartamentoTransportista;
                        sql_comando.Parameters.Add("@CodProvinciaTransportista", SqlDbType.Int).Value = objEntidadBE.CodProvinciaTransportista;
                        sql_comando.Parameters.Add("@CodDistritoTransportista", SqlDbType.Int).Value = objEntidadBE.CodDistritoTransportista;

                        sql_comando.Parameters.Add("@CodConductor", SqlDbType.Int).Value = objEntidadBE.CodConductor;
                        sql_comando.Parameters.Add("@DniConductor", SqlDbType.VarChar, 8).Value = objEntidadBE.DniConductor;
                        sql_comando.Parameters.Add("@NombreConductor", SqlDbType.VarChar, 350).Value = objEntidadBE.NombreConductor;
                        sql_comando.Parameters.Add("@ObservacionesCliente", SqlDbType.VarChar, 350).Value = objEntidadBE.ObservacionesCliente;
                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert_Factura_NONV_Roman(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Insert_Factura_NONV";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 250).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                        sql_comando.Parameters.Add("@FlagCSIgv", SqlDbType.Int).Value = objEntidadBE.FlagCSIgv;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;

                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 200).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTrans", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 50).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NroBultos", SqlDbType.VarChar, 50).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 50).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 50).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo;

                        sql_comando.Parameters.Add("@Placa1", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 1000).Value = objEntidadBE.Observacion;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert_Factura_NONV_SALCEDO(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Insert_Factura_NONV";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 250).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                        sql_comando.Parameters.Add("@FlagCSIgv", SqlDbType.Int).Value = objEntidadBE.FlagCSIgv;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 200).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTrans", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 50).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NroBultos", SqlDbType.VarChar, 50).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 50).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 50).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@Celular", SqlDbType.VarChar, 50).Value = objEntidadBE.Celular;
                        sql_comando.Parameters.Add("@Placa1", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@NroOC", SqlDbType.VarChar, 100).Value = objEntidadBE.NroOC;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;                    
                        sql_comando.Parameters.Add("@CodConductor", SqlDbType.Int).Value = objEntidadBE.CodConductor;
                        sql_comando.Parameters.Add("@DniConductor", SqlDbType.VarChar, 8).Value = objEntidadBE.DniConductor;
                        sql_comando.Parameters.Add("@NombreConductor", SqlDbType.VarChar, 350).Value = objEntidadBE.NombreConductor;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;


                        SqlParameter CodGuia = sql_comando.Parameters.Add("@CodGuia", SqlDbType.Int);
                        CodGuia.Direction = ParameterDirection.Output;
                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.CodGuia = Convert.ToInt32(CodGuia.Value);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert_Factura_NONV_NVANTIGUA(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Insert_Factura_NONV_NVANTIGUA";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 250).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                        sql_comando.Parameters.Add("@FlagCSIgv", SqlDbType.Int).Value = objEntidadBE.FlagCSIgv;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;

                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 200).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTrans", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 50).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NroBultos", SqlDbType.VarChar, 50).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 50).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 50).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo;

                        sql_comando.Parameters.Add("@Placa1", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@FlagFacturaANTIGUA", SqlDbType.Int).Value = objEntidadBE.FlagFacturaANTIGUA;
                        sql_comando.Parameters.Add("@FlagNotaVentaANTIGUA", SqlDbType.Int).Value = objEntidadBE.FlagNotaVentaANTIGUA;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@NroOC", SqlDbType.VarChar, 100).Value = objEntidadBE.NroOC;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert_Factura_NONV_NVANTIGUA_Alvarado(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Insert_Factura_NONV_NVANTIGUA";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 250).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                        sql_comando.Parameters.Add("@FlagCSIgv", SqlDbType.Int).Value = objEntidadBE.FlagCSIgv;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;

                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 200).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTrans", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 50).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NroBultos", SqlDbType.VarChar, 50).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 50).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 50).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo;

                        sql_comando.Parameters.Add("@Placa1", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@FlagFacturaANTIGUA", SqlDbType.Int).Value = objEntidadBE.FlagFacturaANTIGUA;
                        sql_comando.Parameters.Add("@FlagNotaVentaANTIGUA", SqlDbType.Int).Value = objEntidadBE.FlagNotaVentaANTIGUA;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@NroOC", SqlDbType.VarChar, 100).Value = objEntidadBE.NroOC;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert_Factura_NONV_NVANTIGUA_Povis(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Insert_Factura_NONV_NVANTIGUA";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 250).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                        sql_comando.Parameters.Add("@FlagCSIgv", SqlDbType.Int).Value = objEntidadBE.FlagCSIgv;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@CodTipoFormato", SqlDbType.Int).Value = objEntidadBE.CodTipoFormato;

                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 200).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTrans", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 50).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NroBultos", SqlDbType.VarChar, 50).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 50).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 50).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo;

                        sql_comando.Parameters.Add("@Placa1", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@FlagFacturaANTIGUA", SqlDbType.Int).Value = objEntidadBE.FlagFacturaANTIGUA;
                        sql_comando.Parameters.Add("@FlagNotaVentaANTIGUA", SqlDbType.Int).Value = objEntidadBE.FlagNotaVentaANTIGUA;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@NroOC", SqlDbType.VarChar, 100).Value = objEntidadBE.NroOC;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert_NV_OC(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandTimeout = 120;
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Insert_NV_OC";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDocumento", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.DateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;

                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;

                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 150).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@NotaPedido", SqlDbType.Int).Value = objEntidadBE.NotaPedido;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;

                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;

                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@ObservacionesCliente", SqlDbType.VarChar, 2000).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;

                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 200).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTrans", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 50).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NroBultos", SqlDbType.VarChar, 50).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 50).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 50).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@Placa1", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert_NV_OC_Karina(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandTimeout = 120;
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Insert_NV_OC";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDocumento", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.DateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;

                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;

                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 150).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@NotaPedido", SqlDbType.Int).Value = objEntidadBE.NotaPedido;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;

                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;

                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;

                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;

                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 200).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTrans", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 50).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NroBultos", SqlDbType.VarChar, 50).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 50).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 50).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@Placa1", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 1000).Value = objEntidadBE.ObservacionesCliente;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert_NV_OC_Alvarado(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandTimeout = 120;
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Insert_NV_OC";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDocumento", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.DateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;

                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;

                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 150).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@NotaPedido", SqlDbType.Int).Value = objEntidadBE.NotaPedido;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;

                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;

                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;

                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;

                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 200).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTrans", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 50).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NroBultos", SqlDbType.VarChar, 50).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 50).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 50).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@Placa1", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;

                         //GUIA ELECTRONICA
                        sql_comando.Parameters.Add("@CodConductor", SqlDbType.Int).Value = objEntidadBE.CodConductor;
                        sql_comando.Parameters.Add("@DniConductor", SqlDbType.VarChar, 8).Value = objEntidadBE.DniConductor;
                        sql_comando.Parameters.Add("@NombreConductor", SqlDbType.VarChar, 350).Value = objEntidadBE.NombreConductor;

                        sql_comando.Parameters.Add("@UsuarioPermiso", SqlDbType.VarChar, 160).Value = objEntidadBE.UsuarioPermiso;
                        sql_comando.Parameters.Add("@ClavePermiso", SqlDbType.VarChar, 60).Value = objEntidadBE.ClavePermiso;
                        sql_comando.Parameters.Add("@ObservacionPermiso", SqlDbType.VarChar, 300).Value = objEntidadBE.ObservacionPermiso;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;
                        sql_comando.Parameters.Add("@ComisionTarjeta", SqlDbType.Decimal).Value = objEntidadBE.ComisionTarjeta;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter codigoGuia = sql_comando.Parameters.Add("@codigoGuia", SqlDbType.Int);
                        codigoGuia.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.CodGuia = Convert.ToInt32(codigoGuia.Value);

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert_NV_OC_Povis(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandTimeout = 120;
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Insert_NV_OC";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDocumento", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.DateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;

                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;

                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 150).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@NotaPedido", SqlDbType.Int).Value = objEntidadBE.NotaPedido;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodTipoFormato", SqlDbType.Int).Value = objEntidadBE.CodTipoFormato;

                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;

                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;

                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;

                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 200).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTrans", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 50).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NroBultos", SqlDbType.VarChar, 50).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 50).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 50).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@Placa1", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;

                        sql_comando.Parameters.Add("@CodConductor", SqlDbType.Int).Value = objEntidadBE.CodConductor;
                        sql_comando.Parameters.Add("@DniConductor", SqlDbType.VarChar, 8).Value = objEntidadBE.DniConductor;
                        sql_comando.Parameters.Add("@NombreConductor", SqlDbType.VarChar, 350).Value = objEntidadBE.NombreConductor;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 1000).Value = objEntidadBE.Observacion;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert_NV_OC_Roman(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandTimeout = 120;
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Insert_NV_OC";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDocumento", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.DateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;

                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;

                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 150).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@NotaPedido", SqlDbType.Int).Value = objEntidadBE.NotaPedido;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;

                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;

                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;

                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;

                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 200).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTrans", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 50).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NroBultos", SqlDbType.VarChar, 50).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 50).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 50).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@Placa1", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;
                        sql_comando.Parameters.Add("@SerieOC", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieOC;
                        sql_comando.Parameters.Add("@NumeroOC", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroOC;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 2000).Value = objEntidadBE.Observacion;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert_NV_OC_SALCEDO(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandTimeout = 120;
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Insert_NV_OC";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDocumento", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.DateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;

                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;

                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 150).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@NotaPedido", SqlDbType.Int).Value = objEntidadBE.NotaPedido;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;

                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;

                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@Celular", SqlDbType.VarChar, 50).Value = objEntidadBE.Celular;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;

                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 200).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTrans", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 50).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NroBultos", SqlDbType.VarChar, 50).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 50).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 50).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@Placa1", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;

                        //GUIA ELECTRONICA
                        sql_comando.Parameters.Add("@CodConductor", SqlDbType.Int).Value = objEntidadBE.CodConductor;
                        sql_comando.Parameters.Add("@DniConductor", SqlDbType.VarChar, 8).Value = objEntidadBE.DniConductor;
                        sql_comando.Parameters.Add("@NombreConductor", SqlDbType.VarChar, 350).Value = objEntidadBE.NombreConductor;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter codigoGuia = sql_comando.Parameters.Add("@codigoGuia", SqlDbType.Int);
                        codigoGuia.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.CodGuia = Convert.ToInt32(codigoGuia.Value);

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataTable F_NotaIngresoSalidaCab_Observacion(DocumentoVentaCabCE objEntidadBE)
        {
            DataTable dta_observacion = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "PA_NotaIngresoSalidaCab_OBSERVACION";

                        sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;

                        dta_observacion = new DataTable();

                        dta_observacion.Load(sql_comando.ExecuteReader());

                        return dta_observacion;
                    }

                }
            }
            catch (Exception)
            {
                
                throw;
            }
            finally { dta_observacion.Dispose(); }
        }
        public DataTable F_NotaIngresoSalidaCab_Auditoria(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_NotaIngresoSalidaCab_AUDITORIA";

                        sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;

                        dta_auditoria = new DataTable();

                        dta_auditoria.Load(sql_comando.ExecuteReader());

                        return dta_auditoria;
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { dta_auditoria.Dispose(); }
        }

        public DataTable F_DOCUMENTOVENTACAB_REPORTE_VENTA_INGRESOS(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_DOCUMENTOVENTACAB_REPORTE_VENTA_INGRESOS";

                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        if (!objEntidadBE.SerieDoc.Equals("0"))
                            sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
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
        public DocumentoVentaCabCE F_NotaIngresoSalidaCab_EditarObservacion(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_NotaIngresoSalidaCab_EditarObservacion";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 500).Value = objEntidadBE.Observacion;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.NVarChar, 1000);
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
        public DataTable F_DOCUMENTOVENTACAB_REPORTE_VENTA_TIPODOCUMENTO(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_DOCUMENTOVENTACAB_REPORTE_VENTA_TIPODOCUMENTO";

                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        if (objEntidadBE.CodAlmacen > 0)
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        if (!objEntidadBE.SerieDoc.Equals("0"))
                            sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                        if (objEntidadBE.CodTipoDoc > 0)
                            sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        if (objEntidadBE.CodVendedor > 0)
                            sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidadBE.CodVendedor;
                        if (objEntidadBE.CodCliente > 0)
                            sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;

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

        public DataTable F_DocumentoVentaCab_Impresion_Factura_Electronica(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Impresion_Factura_Electronica";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
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

        public DataTable F_DocumentoVentaCab_VistaPreliminar_Factura(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_VistaPreliminar_Factura";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
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

        public DataTable F_Tst_DocumentoVentaSS_UnReg_FE_GetOne_ComunicacionBaja(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Tst_DocumentoVentaSS_UnReg_FE_GetOne_ComunicacionBaja";

                        sql_comando.Parameters.Add("@ID_DocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;

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

        public DocumentoVentaCabCE F_DocumentoVentaCab_ReenvioMail(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_ReenvioMail";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.NVarChar, 400);
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

        public DataTable F_DocumentoVentaCab_RegistroVentas_Excel(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_RegistroVentas_Excel";

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.DesdeInt;
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.HastaInt;

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

        public DataTable F_DocumentoVentaCab_ImpresionConfiguracion(int CodEmpresa, int CodSede,
                                                            string SerieDoc, int CodTipoDoc,
                                                            string TipoImpPorDefecto)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_ImpresionConfiguracion";
                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = CodSede;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar).Value = SerieDoc;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = CodTipoDoc;
                        if (TipoImpPorDefecto.Trim() != "")
                            sql_comando.Parameters.Add("@TipoImpPorDefecto", SqlDbType.VarChar).Value = TipoImpPorDefecto;
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

        public bool F_NotaPedido_FlagImpresionServicio(int CodDocumentoVenta, string IP)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_FlagImpresionServicio";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = CodDocumentoVenta;
                        sql_comando.Parameters.Add("@Flag_Impresion", SqlDbType.VarChar).Value = IP;
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

        //Insert de la Nota de Pedido en Bruto
        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert_NP_OC(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_DocumentoVentaCab_Insert_NP_OC]";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;

                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;

                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;

                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodTraslado", SqlDbType.Int).Value = objEntidadBE.CodTraslado;
                        sql_comando.Parameters.Add("@CodProforma", SqlDbType.Int).Value = objEntidadBE.CodProforma;
                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;

                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@NotaPedido", SqlDbType.Int).Value = objEntidadBE.NotaPedido;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@FlagRetencion", SqlDbType.Int).Value = objEntidadBE.FlagRetencion;
                        sql_comando.Parameters.Add("@FlagLetra", SqlDbType.Int).Value = objEntidadBE.FlagLetra;

                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;

                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;

                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 250).Value = objEntidadBE.Destino;

                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 20).Value = objEntidadBE.PlacaTraslado;

                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.VarChar, 20).Value = objEntidadBE.CodDireccion;

                        sql_comando.Parameters.Add("@DireccionTrans", SqlDbType.VarChar, 100).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTransportista", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;

                        if (objEntidadBE.Transportista.Trim() != "")
                            sql_comando.Parameters.Add("@Transportista", SqlDbType.VarChar, 100).Value = objEntidadBE.Transportista;
                        if (objEntidadBE.Marca.Trim() != "")
                            sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 100).Value = objEntidadBE.Marca;
                        if (objEntidadBE.Licencia.Trim() != "")
                            sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 100).Value = objEntidadBE.Licencia;
                        if (objEntidadBE.NuBultos.Trim() != "")
                            sql_comando.Parameters.Add("@NuBultos", SqlDbType.VarChar, 100).Value = objEntidadBE.NuBultos;
                        if (objEntidadBE.Peso.Trim() != "")
                            sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 100).Value = objEntidadBE.Peso;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public DataTable F_DocumentoVentaCab_CTXFacturar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_CTXFacturar";

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                        {
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        }

                        if (objEntidadBE.NumeroDoc != "")
                            sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;

                        if (objEntidadBE.SerieDoc != "TODOS")
                            sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

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

        public DataTable F_DocumentoVentaCab_Placas_Listar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Placas_Listar";

                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar).Value = objEntidadBE.Placa;

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

        public DataTable F_ProformaCab_Reemplazar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_Reemplazar";

                        sql_comando.Parameters.Add("@CodProforma", SqlDbType.Int).Value = objEntidadBE.CodProforma;
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

        public DataTable F_OrdenPedidoCab_Reemplazar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_Reemplazar";

                        sql_comando.Parameters.Add("@CodProforma", SqlDbType.Int).Value = objEntidadBE.CodProforma;
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

        public DocumentoVentaCabCE F_DocumentoVentaCab_Validar_Factura(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Validar_Factura";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;

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

        public DataTable F_DocumentoVentaCab_Reemplazar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Reemplazar";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
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

        public DataTable F_DocumentoVentaCab_Datos(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Datos";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;

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

        public DocumentoVentaCabCE F_EdicionFactura(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Update";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.DateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 10).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 10).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 10).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 10).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 10).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@CodTraslado", SqlDbType.Int).Value = objEntidadBE.CodTraslado;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 10).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 10).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.DateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 250).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@OrdenCompra", SqlDbType.VarChar, 15).Value = objEntidadBE.NroOC;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;
                        sql_comando.Parameters.Add("@Motorizado", SqlDbType.Int).Value = objEntidadBE.Motorizado;
                        sql_comando.Parameters.Add("@Recepcion", SqlDbType.SmallDateTime).Value = objEntidadBE.Recepcion;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@GuiaAgencia", SqlDbType.VarChar, 30).Value = objEntidadBE.GuiaAgencia;
                        sql_comando.Parameters.Add("@ObservacionesCliente", SqlDbType.VarChar, 250).Value = objEntidadBE.ObservacionesCliente;
                        sql_comando.Parameters.Add("@SerieOC", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieOC;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidadBE.CodVendedor;
                        sql_comando.Parameters.Add("@NombreAgencia", SqlDbType.VarChar, 200).Value = objEntidadBE.NombreAgencia;
                        sql_comando.Parameters.Add("@ClaveAgencia", SqlDbType.VarChar, 20).Value = objEntidadBE.ClaveAgencia;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 100).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 100).Value = objEntidadBE.DireccionTraslado;
                        sql_comando.Parameters.Add("@CodDireccionTransportista", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@DireccionTransportista", SqlDbType.VarChar, 100).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 100).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 100).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NuBultos", SqlDbType.VarChar, 100).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 100).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@CodConductor", SqlDbType.Int).Value = objEntidadBE.CodConductor;
                        sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;

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

        public DataTable F_ReporteVentasPorUnidades(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ReporteVentasPorUnidades";

                        sql_comando.Parameters.Add("@Desdef", SqlDbType.DateTime).Value = objEntidadBE.Desde;
                        sql_comando.Parameters.Add("@Hastaf", SqlDbType.DateTime).Value = objEntidadBE.Hasta;
                        sql_comando.Parameters.Add("@CodFamilia", SqlDbType.VarChar, 3).Value = objEntidadBE.IdFamilia;
                        sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;

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

        public DataTable F_ReporteVentasPorPeriodo(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ReporteVentasPorPeriodo";

                        sql_comando.Parameters.Add("@Desdef", SqlDbType.DateTime).Value = objEntidadBE.Desde;
                        sql_comando.Parameters.Add("@Hastaf", SqlDbType.DateTime).Value = objEntidadBE.Hasta;
                        sql_comando.Parameters.Add("@CodFamilia", SqlDbType.VarChar, 3).Value = objEntidadBE.IdFamilia;
                        sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;
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

        public DataTable F_DocumentoVentaCab_VentasArticulos_Periodo(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_VentasArticulos_Periodo";

                        sql_comando.Parameters.Add("@Desde", SqlDbType.VarChar, 8).Value = objEntidadBE.DesdeInt;
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.VarChar, 8).Value = objEntidadBE.HastaInt;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@TipoReporte", SqlDbType.Int).Value = objEntidadBE.TipoReporte;
                        sql_comando.Parameters.Add("@xmlFamilias", SqlDbType.VarChar, 10000).Value = objEntidadBE.xmlFamilias;
                        sql_comando.Parameters.Add("@xmlLineas", SqlDbType.VarChar, 10000).Value = objEntidadBE.xmlLineas;
                        sql_comando.Parameters.Add("@xmlMarcas", SqlDbType.VarChar, 10000).Value = objEntidadBE.xmlMarcas;
                        if (objEntidadBE.Descripcion.Trim() != "")
                            sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = objEntidadBE.Descripcion;

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

        public DataTable F_DocumentoVentaCab_VentasDocumentos_Periodo(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_VentasDocumentos_Periodo";

                        sql_comando.Parameters.Add("@Desde", SqlDbType.VarChar, 8).Value = objEntidadBE.DesdeInt;
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.VarChar, 8).Value = objEntidadBE.HastaInt;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@TipoReporte", SqlDbType.Int).Value = objEntidadBE.TipoReporte;
                        sql_comando.Parameters.Add("@xmlFamilias", SqlDbType.VarChar, 10000).Value = objEntidadBE.xmlFamilias;
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

        public DataTable F_DocumentoVentaCab_VentasDocumentos_Periodo_Grafico(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_VentasDocumentos_Periodo_Grafico";

                        sql_comando.Parameters.Add("@Desde", SqlDbType.VarChar, 8).Value = objEntidadBE.DesdeInt;
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.VarChar, 8).Value = objEntidadBE.HastaInt;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@TipoReporte", SqlDbType.Int).Value = objEntidadBE.TipoReporte;
                        sql_comando.Parameters.Add("@xmlFamilias", SqlDbType.VarChar, 10000).Value = objEntidadBE.xmlFamilias;
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

        public DocumentoVentaCabCE F_PROCEDIMIENTO_TRASLADAR(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PROCEDIMIENTO3";

                        sql_comando.Parameters.Add("@IDPruebasExcelCab", SqlDbType.BigInt).Value = objEntidadBE.IDPruebasExcelCab;

                        //SqlParameter MsgError = sql_comando.Parameters.Add("@Mensaje", SqlDbType.VarChar, 150);
                        //MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        //objEntidadBE.MsgError = MsgError.Value.ToString();

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaCabCE F_PROCEDIMIENTO(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PROCEDIMIENTO";

                        sql_comando.Parameters.Add("@IDPruebasExcelCab", SqlDbType.BigInt).Value = objEntidadBE.IDPruebasExcelCab;

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

        public DocumentoVentaCabCE F_PROCEDIMIENTO2(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PROCEDIMIENTO2";

                        sql_comando.Parameters.Add("@IDPruebasExcelCab", SqlDbType.BigInt).Value = objEntidadBE.IDPruebasExcelCab;

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
        public DocumentoVentaCabCE F_ListaPreciosExcel_ACTUALIZARPRODUCTOS_REEIM(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_ImportacionExcel_ACTUALIZARPRODUCTOS";

                        sql_comando.Parameters.Add("@IDPruebasExcelCab", SqlDbType.BigInt).Value = objEntidadBE.IDPruebasExcelCab;
                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@FechaDua", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaDua;
                        sql_comando.Parameters.Add("@FechaLlegada", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaLlegada;
                        sql_comando.Parameters.Add("@TC", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@NroDua", SqlDbType.VarChar).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@SerieDocPro", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                        sql_comando.Parameters.Add("@NumeroDocPro", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@CodClasificacion", SqlDbType.Int).Value = objEntidadBE.CodClasificacion;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@GastosOperativos", SqlDbType.Decimal).Value = objEntidadBE.GastosOperativos;
                        sql_comando.Parameters.Add("@FlagPreImport", SqlDbType.Decimal).Value = objEntidadBE.FlagPreImport;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter CodMovimiento = sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int);
                        CodMovimiento.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        try
                        {
                            objEntidadBE.CodDocumentoVenta = Convert.ToInt32(CodMovimiento.Value.ToString());
                        }
                        catch (Exception) { objEntidadBE.CodDocumentoVenta = 0; }


                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DocumentoVentaCabCE F_NotaIngresoSalidaCab_IngresarImportacion(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_NotaIngresoSalidaCab_IngresarImportacion";
                        
                        sql_comando.Parameters.Add("@FechaLlegada", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaLlegada;                       
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value=objEntidadBE.CodDocumentoVenta;
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
        public DocumentoVentaCabCE F_ListaPreciosExcel_ACTUALIZARPRODUCTOS(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_ImportacionExcel_ACTUALIZARPRODUCTOS";

                        sql_comando.Parameters.Add("@IDPruebasExcelCab", SqlDbType.BigInt).Value = objEntidadBE.IDPruebasExcelCab;
                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@FechaDua", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaDua;
                        sql_comando.Parameters.Add("@FechaLlegada", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaLlegada;
                        sql_comando.Parameters.Add("@TC", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@NroDua", SqlDbType.VarChar).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@SerieDocPro", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                        sql_comando.Parameters.Add("@NumeroDocPro", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@CodClasificacion", SqlDbType.Int).Value = objEntidadBE.CodClasificacion;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@GastosOperativos", SqlDbType.Decimal).Value = objEntidadBE.GastosOperativos;
                        sql_comando.Parameters.Add("@FlagPreImport", SqlDbType.Decimal).Value = objEntidadBE.FlagPreImport;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter CodMovimiento = sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int);
                        CodMovimiento.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        try
                        {
                            objEntidadBE.CodDocumentoVenta = Convert.ToInt32(CodMovimiento.Value.ToString());
                        }
                        catch (Exception) { objEntidadBE.CodDocumentoVenta = 0; }


                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaCabCE F_RegistroAjustes_Excel_GRABAR(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_RegistroAjustes_Excel_GRABAR";

                        sql_comando.Parameters.Add("@IDPruebasExcelCab", SqlDbType.BigInt).Value = objEntidadBE.IDPruebasExcelCab;
                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter CodMovimiento = sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int);
                        CodMovimiento.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        try
                        {
                            objEntidadBE.CodDocumentoVenta = Convert.ToInt32(CodMovimiento.Value.ToString());
                        }
                        catch (Exception ex) { objEntidadBE.CodDocumentoVenta = 0; }


                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable F_ListaPreciosExcel_VALIDACIONES_PRODUCTOS_REEIM(long IdExcel)
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
                        sql_comando.CommandText = "PA_ImportacionExcel_VALIDACIONES_PRODUCTOS";

                        sql_comando.Parameters.Add("@IDPruebasExcelCab", SqlDbType.BigInt).Value = IdExcel;

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
        public DataTable F_ListaPreciosExcel_VALIDACIONES_PRODUCTOS(long IdExcel)
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
                        sql_comando.CommandText = "PA_ImportacionExcel_VALIDACIONES_PRODUCTOS";

                        sql_comando.Parameters.Add("@IDPruebasExcelCab", SqlDbType.BigInt).Value = IdExcel;

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

        public DataTable F_RegistroAjustes_VALIDACIONES_EXCEL(long IdExcel)
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
                        sql_comando.CommandText = "PA_RegistroAjustes_VALIDACIONES_EXCEL";

                        sql_comando.Parameters.Add("@IDPruebasExcelCab", SqlDbType.BigInt).Value = IdExcel;

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
        public DataTable F_ListaPreciosExcel_Exportacion_REEIM(long IdExcel, int CodMovimiento, decimal GastosOperativos)
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
                        sql_comando.CommandText = "PA_ImportacionExcel_Listar";

                        sql_comando.Parameters.Add("@IDPruebasExcelCab", SqlDbType.BigInt).Value = IdExcel;
                        sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.BigInt).Value = CodMovimiento;
                        sql_comando.Parameters.Add("@GastosOperativos", SqlDbType.Decimal).Value = GastosOperativos;

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
        public DataTable F_ListaPreciosExcel_Exportacion(long IdExcel, int CodMovimiento, decimal GastosOperativos)
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
                        sql_comando.CommandText = "PA_ImportacionExcel_Listar";

                        sql_comando.Parameters.Add("@IDPruebasExcelCab", SqlDbType.BigInt).Value = IdExcel;
                        sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.BigInt).Value = CodMovimiento;
                        sql_comando.Parameters.Add("@GastosOperativos", SqlDbType.Decimal).Value = GastosOperativos;

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

        public DataTable F_ImportacionExcel_Validaciones(string SerieDoc, string NumeroDoc, int CodCtaCte)
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
                        sql_comando.CommandText = "PA_ImportacionExcel_Validaciones";

                        sql_comando.Parameters.Add("@SerieDocSust", SqlDbType.VarChar, 4).Value = SerieDoc;
                        sql_comando.Parameters.Add("@NumeroDocSust", SqlDbType.VarChar, 8).Value = NumeroDoc;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = CodCtaCte;


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

        public DataTable F_RegistroAjustes_VerificaExcel(string NombreArchivo)
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
                        sql_comando.CommandText = "PA_RegistroAjustes_VerificaExcel";

                        sql_comando.Parameters.Add("@NombreArchivo", SqlDbType.VarChar, 200).Value = NombreArchivo;


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

        public DataTable F_DocumentoVentaCab_Letras(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Letras";

                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@FlagRenovar", SqlDbType.Int).Value = objEntidadBE.FlagRenovar;
                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@FlagNotaVenta", SqlDbType.Int).Value = objEntidadBE.NotaVenta;

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

        public DataTable F_Tst_ArchivoCDR_FactElectronica(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Tst_ArchivoCDR_FactElectronica";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
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

        public DataTable F_DOCUMENTOVENTACAB_REPORTE_VENTA_TIPODOCUMENTO_DETALLADO(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_DOCUMENTOVENTACAB_REPORTE_VENTA_TIPODOCUMENTO_DETALLADO";

                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        if (objEntidadBE.CodAlmacen > 0)
                            sql_comando.Parameters.Add("@CodSede", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        if (!objEntidadBE.SerieDoc.Equals("0"))
                            sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                        if (objEntidadBE.CodTipoDoc > 0)
                            sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        if (objEntidadBE.CodCliente > 0)
                            sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        if (objEntidadBE.CodEmpresa > 0)
                            sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        if (objEntidadBE.CodEmpleado > 0)
                            sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;

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

        public DataTable F_TCCORELATIVO_EsElectronica(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_TCCORELATIVO_EsElectronica";

                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

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

        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert_NV(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandTimeout = 120;
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Insert_NV";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.DateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;

                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;

                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 150).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@NotaPedido", SqlDbType.Int).Value = objEntidadBE.NotaPedido;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;

                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;

                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;

                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@FlagCSIgv", SqlDbType.Int).Value = objEntidadBE.FlagCSIgv;
                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 200).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTrans", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 50).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NroBultos", SqlDbType.VarChar, 50).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 50).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 50).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@Placa1", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;


                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataTable F_UsuariosPermisos_ADMINISTRADOR(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_UsuariosPermisos_ADMINISTRADOR";

                        sql_comando.Parameters.Add("@CodigoPagina", SqlDbType.Int).Value = objEntidadBE.CodigoPagina;
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

        public DataTable F_DOCUMENTOVENTACAB_RANKINGVENTAS_REPORTE(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_DOCUMENTOVENTACAB_RANKINGVENTAS_REPORTE";

                        if (objEntidadBE.CodAlmacen > 0)
                            sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@Ranking", SqlDbType.Int).Value = objEntidadBE.Ranking;

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

        public DataTable F_CajaChica_Regenerar_VistaPreliminar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_CajaChica_Regenerar_VistaPreliminar";

                        if (objEntidadBE.CodUsuario > 0)
                            sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;
                        sql_comando.Parameters.Add("@FechaCaja", SqlDbType.Int).Value = objEntidadBE.FechaEmision.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@FechaSaldo", SqlDbType.Int).Value = objEntidadBE.FechaSaldo.ToString("yyyyMMdd");
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

        public DocumentoVentaCabCE F_CAJACHICA_ELIMINAR(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_CAJACHICA_ELIMINAR";

                        sql_comando.Parameters.Add("@CodCajaChica", SqlDbType.Int).Value = objEntidadBE.CodCajaChica;

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

        public DocumentoVentaCabCE F_CAJACHICA_ABRIR(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_CAJACHICA_ABRIR";

                        sql_comando.Parameters.Add("@CodCajaChica", SqlDbType.Int).Value = objEntidadBE.CodCajaChica;

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

        public DataTable F_DocumentoVentaCab_Comprobantes(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Comprobantes";

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodMotivo", SqlDbType.Int).Value = objEntidadBE.CodMotivo;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCliente;
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

        public DataTable F_DOCUMENTOVENTACAB_REPORTE_CONTABILIDAD_REGISTROVENTA(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_DOCUMENTOVENTACAB_REPORTE_CONTABILIDAD_REGISTROVENTA";

                        if (objEntidadBE.CodAlmacen > 0)
                            sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");

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

        public DataTable F_DOCUMENTOVENTACAB_REPORTE_VENTAS(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_DOCUMENTOVENTACAB_REPORTE_VENTAS";

                        if (objEntidadBE.CodAlmacen > 0)
                            sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");

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

        public DataTable F_PROFORMACAB_SUMATORIA(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_PROFORMACAB_SUMATORIA";

                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        if (objEntidadBE.CodAlmacen > 0)
                            sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        if (objEntidadBE.IdFamilia > 0)
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

        public DataTable F_ObligacionesTributariasCab_REPORTE(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_ObligacionesTributariasCab_REPORTE";

                        if (objEntidadBE.CodCliente != 0)
                            sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;

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

        public DataTable F_COBRANZASCAB_CUENTABANCARIA(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_COBRANZASCAB_CUENTABANCARIA_TARJETA_DEPOSITO";

                        if (objEntidadBE.CodAlmacen != 0)
                            sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");

                        if (objEntidadBE.CodMedioPago != 0)
                            sql_comando.Parameters.Add("@CodMedioPago", SqlDbType.Int).Value = objEntidadBE.CodMedioPago;

                        if (objEntidadBE.CodCtaBancaria != 0)
                            sql_comando.Parameters.Add("@CodCtaBancaria", SqlDbType.Int).Value = objEntidadBE.CodCtaBancaria;

                        if (objEntidadBE.CodCajaFisica != 0)
                            sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;

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

        public DataTable F_CAJACHICA_LISTAR(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_CAJACHICA_LISTAR";

                        if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                        {
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        }

                        if (objEntidadBE.CodCajaFisica > 0)
                            sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;
                        if (objEntidadBE.CodAlmacen > 0)
                            sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        if (objEntidadBE.CodUsuario > 0)
                            sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
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

        public DataTable F_DOCUMENTOVENTACAB_REPORTE_VENTA_X_VENDEDOR(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_DOCUMENTOVENTACAB_REPORTE_VENTA_X_VENDEDOR";

                        if (objEntidadBE.CodAlmacen > 0)
                            sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        if (objEntidadBE.CodEmpleado > 0)
                            sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;

                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.DesdeInt;
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.HastaInt;
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

        public DataTable F_DocumentoVentaCab_OCXFacturar_Compras(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_OCXFacturar_Compras";

                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;

                        if (objEntidadBE.CodTipoDoc > 0)
                            sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;

                        if (objEntidadBE.SerieDoc != "")
                            sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                        if (objEntidadBE.NumeroDoc != "")
                            sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;

                        if (objEntidadBE.CodAlmacen > 0)
                            sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

                        if (objEntidadBE.CodVendedor != 0)
                            sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidadBE.CodVendedor;

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

        public DataTable F_USUARIO_X_OPERACION_DIARIA(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_USUARIO_X_OPERACION_DIARIA";

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;
                        sql_comando.Parameters.Add("@Fecha", SqlDbType.Int).Value = objEntidadBE.FechaEmision.ToString("yyyyMMdd");

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

        public DataTable F_CAJACHICA_RESUMIDO(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_CAJACHICA_RESUMIDO";

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;
                        sql_comando.Parameters.Add("@FechaCaja", SqlDbType.Int).Value = objEntidadBE.FechaEmision.ToString("yyyyMMdd");

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

        public DataTable PA_CAJACHICA_RESUMIDO_DETALLE(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_CAJACHICA_RESUMIDO_DETALLE";

                        sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.VarChar, 3).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;
                        sql_comando.Parameters.Add("@FechaCaja", SqlDbType.Int).Value = objEntidadBE.FechaEmision.ToString("yyyyMMdd");

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

        public DataTable F_DocumentoVentaCab_VENTAS_COMPRAS(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_VENTAS_COMPRAS";

                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;

                        if (objEntidadBE.CodTipoDoc > 0)
                            sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;

                        if (objEntidadBE.SerieDoc != "")
                            sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                        if (objEntidadBE.NumeroDoc != "")
                            sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;

                        if (objEntidadBE.CodAlmacen > 0)
                            sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

                        if (objEntidadBE.CodVendedor != 0)
                            sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidadBE.CodVendedor;

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

        public DataTable F_ProductoCargaMasiva_VALIDACIONES_EXCEL(long IdExcel)
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
                        sql_comando.CommandText = "PA_ProductoCargaMasiva_VALIDACIONES_EXCEL";

                        sql_comando.Parameters.Add("@IDPruebasExcelCab", SqlDbType.BigInt).Value = IdExcel;

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

        public DocumentoVentaCabCE F_ProductoCargaMasiva_Excel_GRABAR(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_ProductoCargaMasiva_Excel_GRABAR";

                        sql_comando.Parameters.Add("@IDPruebasExcelCab", SqlDbType.BigInt).Value = objEntidadBE.IDPruebasExcelCab;
                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
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

        public DataTable F_PROFORMACAB_LISTAR(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_PROFORMACAB_LISTAR";

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                        {
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        }
                        if (objEntidadBE.SerieDoc != "TODOS")
                            sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                        if (objEntidadBE.NumeroDoc != "")
                            sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;

                        if (objEntidadBE.CodCliente != 0)
                            sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        if (objEntidadBE.CodEstado != 0)
                            sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;

                        if (objEntidadBE.CodVendedor != 0)
                            sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidadBE.CodVendedor;

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

        public DataTable F_DOCUMENTOVENTACAB_LISTAR_COBRANZAS_DETALLADO(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_DOCUMENTOVENTACAB_LISTAR_COBRANZAS_DETALLADO";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;

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

        public DataTable F_DOCUMENTOVENTACAB_LISTAR_COBRANZAS(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_DOCUMENTOVENTACAB_LISTAR_COBRANZAS";

                        if (objEntidadBE.NumeroDoc != "")
                            sql_comando.Parameters.Add("@Numero", SqlDbType.VarChar, 15).Value = objEntidadBE.NumeroDoc;

                        if (objEntidadBE.CodCliente != 0)
                            sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        if (objEntidadBE.Ruta != 0)
                            sql_comando.Parameters.Add("@Ruta", SqlDbType.Int).Value = objEntidadBE.Ruta;

                        if (objEntidadBE.CodTipoDoc > 0)
                            sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;

                        if (objEntidadBE.CodVendedor > 0)
                            sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidadBE.CodVendedor;

                        sql_comando.Parameters.Add("@FlagAcuenta", SqlDbType.Int).Value = objEntidadBE.FlagAcuenta;

                        if (objEntidadBE.CodEmpresa > 0)
                            sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;

                        if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                        {
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        }

                        if (objEntidadBE.CodAlmacen > 0)
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

        public DataTable F_DOCUMENTOVENTACAB_ELIMINADOS_LISTAR_COBRANZAS(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Cobranzas_Eliminados_Listar";

                        if (objEntidadBE.NumeroDoc != "")
                            sql_comando.Parameters.Add("@Numero", SqlDbType.VarChar, 15).Value = objEntidadBE.NumeroDoc;

                        if (objEntidadBE.CodCliente != 0)
                            sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        if (objEntidadBE.CodMedioPago > 0)
                            sql_comando.Parameters.Add("@CodMedioPago", SqlDbType.Int).Value = objEntidadBE.CodMedioPago;

                        if (objEntidadBE.CodCajaFisica > 0)
                            sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;

                        if (objEntidadBE.CodEmpresa > 0)
                            sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;

                        if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                        {
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        }

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

                        if (objEntidadBE.CodTipoDoc > 0)
                            sql_comando.Parameters.Add("@codTipodoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;

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
        //eliminados pagos
        public DataTable F_DOCUMENTOVENTACAB_ELIMINADOS_LISTAR_PAGO(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Pagos_Eliminados_Listar";

                        if (objEntidadBE.NumeroDoc != "")
                            sql_comando.Parameters.Add("@Numero", SqlDbType.VarChar, 15).Value = objEntidadBE.NumeroDoc;

                        if (objEntidadBE.CodCliente != 0)
                            sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        if (objEntidadBE.CodMedioPago > 0)
                            sql_comando.Parameters.Add("@CodMedioPago", SqlDbType.Int).Value = objEntidadBE.CodMedioPago;

                        if (objEntidadBE.CodCajaFisica > 0)
                            sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;

                        if (objEntidadBE.CodEmpresa > 0)
                            sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;

                        if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                        {
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        }

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

                        if (objEntidadBE.CodTipoDoc > 0)
                            sql_comando.Parameters.Add("@codTipodoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;

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

        public DocumentoVentaCabCE F_TemporalFacturacionDetallado_Insert(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionDetallado_Insert";

                        sql_comando.Parameters.Add("@CodDetDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDetDocumentoVenta;
                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@CodProductoSuperior", SqlDbType.Int).Value = objEntidadBE.CodProductoSuperior;
                        sql_comando.Parameters.Add("@CodArticulo", SqlDbType.Int).Value = objEntidadBE.CodArticulo;
                        sql_comando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = objEntidadBE.Cantidad;
                        sql_comando.Parameters.Add("@CodUndMedida", SqlDbType.Int).Value = objEntidadBE.CodUndMedida;
                        sql_comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = objEntidadBE.Precio;
                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 500).Value = objEntidadBE.Descripcion;

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

        public DataTable F_TemporalFacturacionDetallado_Listar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionDetallado_Listar";

                        sql_comando.Parameters.Add("@CodDetDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDetDocumentoVenta;

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

        public DataTable F_DOCUMENTOVENTACAB_REPORTE_CONTABILIDAD_REGISTROVENTA_CONCAR(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_DOCUMENTOVENTACAB_REPORTE_CONTABILIDAD_REGISTROVENTA_CONCAR";

                        if (objEntidadBE.CodAlmacen > 0)
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

        public DataTable F_COBRANZAS_POR_PERIODO(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_COBRANZASCAB_POR_PERIODO";

                        if (objEntidadBE.CodCliente > 0)
                            sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@FlagTodo", SqlDbType.Int).Value = objEntidadBE.FlagTodo;

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

        public DataTable F_DOCUMENTOVENTACAB_LISTAR_COBRANZAS_DETALLADO_HISTORIAL(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_DOCUMENTOVENTACAB_LISTAR_COBRANZAS_DETALLADO_HISTORIAL";

                        if (objEntidadBE.NumeroDoc != "")
                            sql_comando.Parameters.Add("@Numero", SqlDbType.VarChar, 15).Value = objEntidadBE.NumeroDoc;

                        if (objEntidadBE.CodCliente != 0)
                            sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        if (objEntidadBE.CodTipoDoc > 0)
                            sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;

                        sql_comando.Parameters.Add("@FlagAcuenta", SqlDbType.Int).Value = objEntidadBE.FlagAcuenta;

                        if (objEntidadBE.CodEmpresa > 0)
                            sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;

                        if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                        {
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        }

                        if (objEntidadBE.CodAlmacen > 0)
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

        public DocumentoVentaCabCE F_MOVIMIENTOS_AJUSTE_CERO(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_MOVIMIENTOS_AJUSTE_CERO";

                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 100).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
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

        public DataTable F_Planilla_Salario_Cab_REPORTE_CONSTRUCCIONCIVIL(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_Planilla_Salario_Cab_REPORTE_CONSTRUCCIONCIVIL";

                        sql_comando.Parameters.Add("@CodSemana", SqlDbType.Int).Value = objEntidadBE.CodSemana;
                        sql_comando.Parameters.Add("@CodProyecto", SqlDbType.Int).Value = objEntidadBE.CodProyecto;
                        sql_comando.Parameters.Add("@CodRegimenLaboral", SqlDbType.Int).Value = objEntidadBE.CodRegimenLaboral;

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

        public DataTable F_DOCUMENTOVENTACAB_SERVICIOSPORFACTURAR(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_DOCUMENTOVENTACAB_SERVICIOSPORFACTURAR";

                        if (objEntidadBE.CodAlmacen>0)
                            sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        if (objEntidadBE.CodEmpleado > 0)
                             sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
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

        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert_NV_OC_Clever(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandTimeout = 120;
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Insert_NV_OC";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDocumento", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.DateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;

                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;

                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 150).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@NotaPedido", SqlDbType.Int).Value = objEntidadBE.NotaPedido;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;

                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;

                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@ObservacionesCliente", SqlDbType.VarChar, 2000).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;

                        sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 200).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTrans", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 50).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NroBultos", SqlDbType.VarChar, 50).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 50).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 50).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@Placa1", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;
                        sql_comando.Parameters.Add("@CodTipoFormato", SqlDbType.Int).Value = objEntidadBE.CodTipoFormato;
                        sql_comando.Parameters.Add("@UsuarioPermiso", SqlDbType.VarChar, 160).Value = objEntidadBE.UsuarioPermiso;
                        sql_comando.Parameters.Add("@ClavePermiso", SqlDbType.VarChar, 60).Value = objEntidadBE.ClavePermiso;
                        sql_comando.Parameters.Add("@ObservacionPermiso", SqlDbType.VarChar, 300).Value = objEntidadBE.ObservacionPermiso;
                        sql_comando.Parameters.Add("@FlagOC", SqlDbType.Int).Value = objEntidadBE.FlagOC;
                        sql_comando.Parameters.Add("@FlagKM", SqlDbType.Int).Value = objEntidadBE.FlagKM;
                        sql_comando.Parameters.Add("@FlagPlaca", SqlDbType.Int).Value = objEntidadBE.FlagPlaca;

                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@CodDepartamentoTransportista", SqlDbType.Int).Value = objEntidadBE.CodDepartamentoTransportista;
                        sql_comando.Parameters.Add("@CodProvinciaTransportista", SqlDbType.Int).Value = objEntidadBE.CodProvinciaTransportista;
                        sql_comando.Parameters.Add("@CodDistritoTransportista", SqlDbType.Int).Value = objEntidadBE.CodDistritoTransportista;
                        sql_comando.Parameters.Add("@RazonSocialTransportista  ", SqlDbType.VarChar, 200).Value = objEntidadBE.Transportista;
                        sql_comando.Parameters.Add("@RucTransportista  ", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRucTransportista;


                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter CodGuia = sql_comando.Parameters.Add("@CodIgoGuia", SqlDbType.Int);
                        CodGuia.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_DOCUMENTOVENTACAB_VENTADIARIA(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_DOCUMENTOVENTACAB_VENTADIARIA";

                        if (objEntidadBE.CodAlmacen > 0)
                            sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        
                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                       
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

        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert_Factura_NONV_Clever(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Insert_Factura_NONV";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 250).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                        sql_comando.Parameters.Add("@FlagCSIgv", SqlDbType.Int).Value = objEntidadBE.FlagCSIgv;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;

                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@RucTransportista", SqlDbType.VarChar, 50).Value = objEntidadBE.NroRucTransportista;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 500).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTrans", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@CodDepartamentoTrasportista", SqlDbType.Int).Value = objEntidadBE.CodDepartamentoTransportista;
                        sql_comando.Parameters.Add("@RazonSocialTrasportista", SqlDbType.VarChar, 500).Value = objEntidadBE.Transportista;
                        sql_comando.Parameters.Add("@CodProvinciaTrasportista", SqlDbType.Int).Value = objEntidadBE.CodProvinciaTransportista;
                        sql_comando.Parameters.Add("@CodDistritoTrasportista", SqlDbType.Int).Value = objEntidadBE.CodDistritoTransportista;

                        sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 50).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NroBultos", SqlDbType.VarChar, 50).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 50).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 50).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@ObservacionesCliente", SqlDbType.VarChar, 2000).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@Placa1", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@NroOC", SqlDbType.VarChar, 100).Value = objEntidadBE.NroOC;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;

                        sql_comando.Parameters.Add("@FlagOC", SqlDbType.Int).Value = objEntidadBE.FlagOC;
                        sql_comando.Parameters.Add("@FlagKM", SqlDbType.Int).Value = objEntidadBE.FlagKM;
                        sql_comando.Parameters.Add("@FlagPlaca", SqlDbType.Int).Value = objEntidadBE.FlagPlaca;
                        sql_comando.Parameters.Add("@CodTipoFormato", SqlDbType.Int).Value = objEntidadBE.CodTipoFormato;


                        // DATOS DE LA GUIA ELECTRONICA
                        sql_comando.Parameters.Add("@CodConductor", SqlDbType.Int).Value = objEntidadBE.CodConductor;
                        sql_comando.Parameters.Add("@DniConductor", SqlDbType.VarChar, 8).Value = objEntidadBE.DniConductor;
                        sql_comando.Parameters.Add("@NombreConductor", SqlDbType.VarChar, 350).Value = objEntidadBE.NombreConductor;

                        sql_comando.Parameters.Add("@UsuarioPermiso", SqlDbType.VarChar, 160).Value = objEntidadBE.UsuarioPermiso;
                        sql_comando.Parameters.Add("@ClavePermiso", SqlDbType.VarChar, 60).Value = objEntidadBE.ClavePermiso;
                        sql_comando.Parameters.Add("@ObservacionPermiso", SqlDbType.VarChar, 300).Value = objEntidadBE.ObservacionPermiso;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;


                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter CodGuia = sql_comando.Parameters.Add("@CodGuia", SqlDbType.Int);
                        CodGuia.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();


                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert_Factura_NV_Clever(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Insert_Factura_NV";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;
                        sql_comando.Parameters.Add("@AcuentaNV", SqlDbType.Decimal).Value = objEntidadBE.AcuentaNV;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 250).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                        sql_comando.Parameters.Add("@FlagCSIgv", SqlDbType.Int).Value = objEntidadBE.FlagCSIgv;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@ObservacionesCliente", SqlDbType.VarChar, 2000).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 200).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTrans", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 50).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NroBultos", SqlDbType.VarChar, 50).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 50).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 50).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@NroOC", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOC;
                        sql_comando.Parameters.Add("@Placa1", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagOC", SqlDbType.Int).Value = objEntidadBE.FlagOC;
                        sql_comando.Parameters.Add("@FlagKM", SqlDbType.Int).Value = objEntidadBE.FlagKM;
                        sql_comando.Parameters.Add("@FlagPlaca", SqlDbType.Int).Value = objEntidadBE.FlagPlaca;
                        sql_comando.Parameters.Add("@CodTipoFormato", SqlDbType.Int).Value = objEntidadBE.CodTipoFormato;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaCabCE F_EdicionFactura_Clever(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Update";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.DateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 10).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 10).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 10).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 10).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 10).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@CodTraslado", SqlDbType.Int).Value = objEntidadBE.CodTraslado;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 10).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 10).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.DateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 250).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@Motorizado", SqlDbType.Int).Value = objEntidadBE.Motorizado;

                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 100).Value = objEntidadBE.DireccionTransportista;

                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTransportista", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@CodDepartamentoTransportista", SqlDbType.Int).Value = objEntidadBE.CodDepartamentoTransportista;
                        sql_comando.Parameters.Add("@CodProvinciaTransportista", SqlDbType.Int).Value = objEntidadBE.CodProvinciaTransportista;
                        sql_comando.Parameters.Add("@CodDistritoTransportista", SqlDbType.Int).Value = objEntidadBE.CodDistritoTransportista;
                        sql_comando.Parameters.Add("@DireccionTransportista", SqlDbType.VarChar, 100).Value = objEntidadBE.DireccionTransportista;

                        sql_comando.Parameters.Add("@RazonSocialTransportista  ", SqlDbType.VarChar, 200).Value = objEntidadBE.Transportista;
                        sql_comando.Parameters.Add("@RucTransportista  ", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRucTransportista;

                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;

                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 100).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 100).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 100).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NuBultos", SqlDbType.VarChar, 100).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 100).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@OrdenCompra", SqlDbType.VarChar, 15).Value = objEntidadBE.NroOC;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;
                        sql_comando.Parameters.Add("@Recepcion", SqlDbType.SmallDateTime).Value = objEntidadBE.Recepcion;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@SerieOC", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieOC;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@FlagOC", SqlDbType.Int).Value = objEntidadBE.FlagOC;
                        sql_comando.Parameters.Add("@FlagKM", SqlDbType.Int).Value = objEntidadBE.FlagKM;
                        sql_comando.Parameters.Add("@FlagPlaca", SqlDbType.Int).Value = objEntidadBE.FlagPlaca;

                        sql_comando.Parameters.Add("@CodConductor", SqlDbType.Int).Value = objEntidadBE.CodConductor;
                        sql_comando.Parameters.Add("@NombreAgencia", SqlDbType.VarChar, 200).Value = objEntidadBE.NombreAgencia;
                        sql_comando.Parameters.Add("@GuiaAgencia", SqlDbType.VarChar, 30).Value = objEntidadBE.GuiaAgencia;
                        sql_comando.Parameters.Add("@ClaveAgencia", SqlDbType.VarChar, 20).Value = objEntidadBE.ClaveAgencia;

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

        public DataTable F_DOCUMENTOVENTACAB_PLACAS_REPORTE(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_DOCUMENTOVENTACAB_PLACAS_REPORTE";

                        if (objEntidadBE.CodAlmacen > 0)
                            sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

                        if (objEntidadBE.CodCliente > 0)
                            sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        if (objEntidadBE.Placa !="")
                            sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar,20).Value = objEntidadBE.Placa;

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

        //orden Pedido

        public DataTable F_RegistroOrdenPedido_Listar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_RegistroOrdenPedido_Listar";

                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                        {
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        }
                        if (objEntidadBE.SerieDoc != "TODOS")
                            sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                        if (objEntidadBE.NumeroDoc != "")
                            sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;

                        if (objEntidadBE.CodCliente != 0)
                            sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        if (objEntidadBE.CodEstado != 0)
                            sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;

                        if (objEntidadBE.CodVendedor != 0)
                            sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidadBE.CodVendedor;

                        if (objEntidadBE.CodEmpresa != 0)
                            sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;

                        if (objEntidadBE.Placa != "")
                            sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 8).Value = objEntidadBE.Placa;

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

        public DataTable F_COTIZACION_Listar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_COTIZACION_Listar";

                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                        {
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        }
                        if (objEntidadBE.SerieDoc != "TODOS")
                            sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                        if (objEntidadBE.NumeroDoc != "")
                            sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;

                        if (objEntidadBE.CodCliente != 0)
                            sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        if (objEntidadBE.CodEstado != 0)
                            sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;

                        if (objEntidadBE.CodVendedor != 0)
                            sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidadBE.CodVendedor;

                        if (objEntidadBE.CodEmpresa != 0)
                            sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;

                        if (objEntidadBE.Placa != "")
                            sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 8).Value = objEntidadBE.Placa;

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

        public DataTable F_NotaCredito_Listar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_NotaCredito_Listar";

                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                        {
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        }
                        if (objEntidadBE.SerieDoc != "TODOS")
                            sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                        if (objEntidadBE.NumeroDoc != "")
                            sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;

                        if (objEntidadBE.Anexo != "")
                            sql_comando.Parameters.Add("@Anexo", SqlDbType.VarChar, 8).Value = objEntidadBE.Anexo;

                        if (objEntidadBE.CodCliente != 0)
                            sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        if (objEntidadBE.CodEstado != 0)
                            sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;

                        if (objEntidadBE.CodVendedor != 0)
                            sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidadBE.CodVendedor;

                        if (objEntidadBE.CodEmpresa != 0)
                            sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;

                        if (objEntidadBE.Placa != "")
                            sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 8).Value = objEntidadBE.Placa;

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
        
        public DataTable F_REPORTE_RXH(DocumentoVentaCabCE objDocumentoVentaCabCE)
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
                        sql_comando.CommandText = "pa_Reporte_RXH";

                        if (objDocumentoVentaCabCE.CodAlmacen != 0)
                            sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objDocumentoVentaCabCE.CodAlmacen;

                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objDocumentoVentaCabCE.Desde.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objDocumentoVentaCabCE.Hasta.ToString("yyyyMMdd");

                       

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

        public DataTable P_Registro_RPH(DocumentoVentaCabCE objEntidad)
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
                        sql_comando.CommandText = "pa_Reporte_Excel_RXH";

                        if (objEntidad.CodAlmacen != 0)
                            sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidad.CodAlmacen;

                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidad.Desde.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidad.Hasta.ToString("yyyyMMdd");



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

        public DataTable F_ProformaCab_Listar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_ProformaCab_Listar";

                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                        {
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        }
                        if (objEntidadBE.SerieDoc != "TODOS")
                            sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                        if (objEntidadBE.NumeroDoc != "")
                            sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;

                        if (objEntidadBE.CodCliente != 0)
                            sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        if (objEntidadBE.CodEstado != 0)
                            sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;

                        if (objEntidadBE.CodVendedor != 0)
                            sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidadBE.CodVendedor;

                        if (objEntidadBE.CodEmpresa != 0)
                            sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;

                        if (objEntidadBE.Placa != "")
                            sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 8).Value = objEntidadBE.Placa;

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

        public DataTable F_Planilla_Salario_Cab_REPORTE_RCC(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Planilla_ReporteRCC";

                        sql_comando.Parameters.Add("@CodSemanaInicio", SqlDbType.Int).Value = objEntidadBE.CodSemanaInicio;
                        sql_comando.Parameters.Add("@CodSemanaFin", SqlDbType.Int).Value = objEntidadBE.CodSemanaFinal;
                        sql_comando.Parameters.Add("@CodPeriodo", SqlDbType.Int).Value = objEntidadBE.CodPeriodo;

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

        public DataTable F_Planilla_Salario_Cab_REPORTE_RG(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Planilla_ReporteRG";

                        sql_comando.Parameters.Add("@CodPeriodo", SqlDbType.Int).Value = objEntidadBE.CodPeriodo;

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

        public object F_AUDITORIA_DOCUMENTOVENTA(DocumentoVentaCabCE objEntidad)
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
                        sql_comando.CommandText = "PA_AUDITORIA_DOCUMENTOVENTA";

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

        public DataTable F_DocumentoVentaCab_Retenciones_Listar_Eliminados(DocumentoVentaCabCE objEntidad)
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
                        sql_comando.CommandText = "pa_ObligacionesTributariasCab_eliminados_Listar";

                        if (objEntidad.CodTipoDoc > 0)
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidad.CodTipoDoc;

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidad.CodAlmacen;
                        if (objEntidad.Desde.ToString("yyyyMMdd") != "19900101")
                        {
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidad.Desde.ToString("yyyyMMdd");
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidad.Hasta.ToString("yyyyMMdd");
                        }
                        if (objEntidad.SerieDoc != "TODOS")
                            sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidad.SerieDoc;

                        if (objEntidad.NumeroDoc != "")
                            sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidad.NumeroDoc;

                        if (objEntidad.CodCliente > 0)
                            sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidad.CodCliente;

                        if (objEntidad.CodEstado > 0)
                            sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidad.CodEstado;

                        if (objEntidad.CodVendedor > 0)
                            sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidad.CodVendedor;

                        if (objEntidad.CodEmpresa > 0)
                            sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidad.CodEmpresa;

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

        public object F_RetencionesDet_Eliminar_Listar(DocumentoVentaCabCE objEntidad)
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
                        sql_comando.CommandText = "pa_RetencionesDet_Eliminados_Listar";

                        sql_comando.Parameters.Add("@codigo", SqlDbType.Int).Value = objEntidad.Codigo;

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

        public object F_RetencionesCab_ELIMINADOS_AUDITORIA(DocumentoVentaCabCE objEntidad)
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
                        sql_comando.CommandText = "PA_RetencionesCab_ELIMINADOS_AUDITORIA";

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

        public object F_RetencionesCab_ELIMINADOS_OBSERVACION(DocumentoVentaCabCE objEntidad)
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
                        sql_comando.CommandText = "PA_RetencionesCab_ELIMINADOS_OBSERVACION";

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

        public object F_RetencionesCab_Eliminadas_OBSERVACIONES(DocumentoVentaCabCE objEntidad)
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
                        sql_comando.CommandText = "PA_RetencionesCab_Eliminadas_OBSERVACIONES";

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

        public DataTable F_ProformaCab_ListarNI(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_CotizacionCab_NotaIngreso";

                        sql_comando.Parameters.Add("@CodProforma", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;

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
        
        public DocumentoVentaCabCE F_CotizacionCab_AnularIngreso(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandTimeout = 120;
                        sql_comando.CommandText = "pa_CotizacionCab_AnularNotaIngreso";

                        sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar,300).Value = objEntidadBE.Observacion;
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

        public DataTable F_DOCUMENTOVENTACAB_VENTAS_MENSUALES_VENDEDOR(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_DOCUMENTOVENTACAB_VENTAS_MENSUALES_VENDEDOR";

                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.DesdeInt;
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.HastaInt;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
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

        public DataTable F_DOCUMENTOVENTACAB_VENTAS_MENSUALES_VENDEDOR_POVIS(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_DOCUMENTOVENTACAB_VENTAS_MENSUALES_VENDEDOR";
                        //cambiar
                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");

                        sql_comando.Parameters.Add("@Ruta", SqlDbType.Int).Value = objEntidadBE.Ruta;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodVendedor;
                        if (objEntidadBE.chkMarca > 0)
                            sql_comando.Parameters.Add("@CodMarca", SqlDbType.Int).Value = objEntidadBE.codMarca;
                        if (objEntidadBE.chkCliente > 0)
                            sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;

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

        public DataTable F_COBRANZAS_REPORTE_VENTA_COMISION(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_COBRANZAS_REPORTE_VENTA_COMISION ";

                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");

                        if (objEntidadBE.DesdeCancelacion.ToString("yyyyMMdd") != "19900101")
                        {
                            sql_comando.Parameters.Add("@DesdeCancelacion", SqlDbType.Int).Value = objEntidadBE.DesdeCancelacion.ToString("yyyyMMdd");
                            sql_comando.Parameters.Add("@HastaCancelacion", SqlDbType.Int).Value = objEntidadBE.HastaCancelacion.ToString("yyyyMMdd");
                        }

                        if (objEntidadBE.Ruta != 0)
                        sql_comando.Parameters.Add("@Ruta", SqlDbType.Int).Value = objEntidadBE.Ruta;

                        if (objEntidadBE.CodVendedor != 0)
                        sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidadBE.CodVendedor;
                        

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

        public DataTable F_DOCUMENTOVENTACAB_LISTAR_COBRANZAS_DETALLADO_HISTORIAL_POVIS(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_DOCUMENTOVENTACAB_LISTAR_COBRANZAS_DETALLADO_HISTORIAL_POVIS";

                        if (objEntidadBE.NumeroDoc != "")
                            sql_comando.Parameters.Add("@Numero", SqlDbType.VarChar, 15).Value = objEntidadBE.NumeroDoc;

                        if (objEntidadBE.CodCliente != 0)
                            sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        if (objEntidadBE.CodTipoDoc > 0)
                            sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;

                        sql_comando.Parameters.Add("@FlagAcuenta", SqlDbType.Int).Value = objEntidadBE.FlagAcuenta;

                        if (objEntidadBE.CodEmpresa > 0)
                            sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;

                        if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                        {
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        }

                        if (objEntidadBE.CodAlmacen > 0)
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

        public DataTable F_CAJACHICA_LISTAR_LIQUIDACION(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_CAJACHICA_LISTAR_LIQUIDACION";

                        sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;


                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.Codigodetalle = Convert.ToInt32(Codigo.Value);

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


        public DataTable F_Liquidacion_LISTAR(DocumentoVentaCabCE objEntidad)
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
                        sql_comando.CommandText = "PA_Liquidacion_LISTAR";

                        if (objEntidad.Desde.ToString("yyyyMMdd") != "19900101")
                        {
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidad.Desde.ToString("yyyyMMdd");
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidad.Hasta.ToString("yyyyMMdd");
                        }

                        if (objEntidad.CodCajaFisica > 0)
                            sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidad.CodCajaFisica;
                        //if (objEntidad.CodAlmacen > 0)
                        //    sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidad.CodAlmacen;
                        //if (objEntidad.CodUsuario > 0)
                        //    sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidad.CodUsuario;
                        if (objEntidad.CodEmpresa > 0)
                            sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidad.CodEmpresa;

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

        public object F_AUDITORIA_lIQUIDACION(DocumentoVentaCabCE objEntidad)
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
                        sql_comando.CommandText = "PA_AUDITORIA_lIQUIDACION";

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

        public DocumentoVentaCabCE F_LIQUIDACION_ELIMINAR(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_LIQUIDACION_ELIMINAR";

                        sql_comando.Parameters.Add("@Codliquidacion", SqlDbType.Int).Value = objEntidadBE.Codliquidacion;

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
              
        public DataTable F_CajaChica_Detalle_Efectivo(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_CajaChica_Detalle_Efectivo";

                        sql_comando.Parameters.Add("@FechaCaja", SqlDbType.Int).Value = objEntidadBE.FechaEmision.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;
                        if (objEntidadBE.CodMedioPago > 0)
                            sql_comando.Parameters.Add("@CodMedioPago", SqlDbType.Int).Value = objEntidadBE.CodMedioPago;
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

        public DataTable F_DocumentoVentaCab_VENTA_EMPLEADO_DETALLADO(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_DocumentoVentaCab_VENTA_EMPLEADO_DETALLADO";
                                      
                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
             
                        if (objEntidadBE.CodAlmacen > 0)
                            sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;

                        if (objEntidadBE.CodEmpleado > 0)
                            sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;

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

        public DocumentoVentaCabCE F_EdicionFactura_TEK(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Update";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.DateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 10).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 10).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 10).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 10).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 10).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@CodTraslado", SqlDbType.Int).Value = objEntidadBE.CodTraslado;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 10).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 10).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.DateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 250).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 100).Value = objEntidadBE.DireccionTraslado;
                        sql_comando.Parameters.Add("@CodDireccionTransportista", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@DireccionTransportista", SqlDbType.VarChar, 100).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 100).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 100).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 100).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NuBultos", SqlDbType.VarChar, 100).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 100).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@OrdenCompra", SqlDbType.VarChar, 15).Value = objEntidadBE.NroOC;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;
                        sql_comando.Parameters.Add("@Motorizado", SqlDbType.Int).Value = objEntidadBE.Motorizado;
                        sql_comando.Parameters.Add("@Recepcion", SqlDbType.SmallDateTime).Value = objEntidadBE.Recepcion;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@ObservacionesCliente", SqlDbType.VarChar, 250).Value = objEntidadBE.ObservacionesCliente;
                        sql_comando.Parameters.Add("@SerieOC", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieOC;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidadBE.CodVendedor;

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

        public DataTable F_MOVIMIENTOS_PRODUCTOS_VENTAS(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_MOVIMIENTOS_PRODUCTOS_VENTAS";

                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.DesdeInt;
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.HastaInt;
                        if (objEntidadBE.IdFamilia > 0)
                            sql_comando.Parameters.Add("@IDFamilia", SqlDbType.Int).Value = objEntidadBE.IdFamilia;
                        if (objEntidadBE.CodCliente>0)
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                      

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

        public DataTable F_OperacionND_Listar()
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
                        sql_comando.CommandText = "pa_Operaciones_ND";
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

        public DocumentoVentaCabCE F_NotaIngreso_Manual(DocumentoVentaCabCE objEntidad)
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
                        sql_comando.CommandText = "pa_NotaIngreso_Manual";

                        sql_comando.Parameters.Add("@Desde", SqlDbType.DateTime).Value = objEntidad.Desde;
                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidad.CodEmpresa;

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


        public DataTable F_CajaChica_Detalle_Grupal_Excel(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_CajaChica_Detalle_grupal_excel";

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@coddoc", SqlDbType.Int).Value = objEntidadBE.coddoc;
                        sql_comando.Parameters.Add("@Codigos", SqlDbType.Text).Value = objEntidadBE.Codigos;
                        if (objEntidadBE.CodMedioPago > 0)
                            sql_comando.Parameters.Add("@CodMedioPago", SqlDbType.Int).Value = objEntidadBE.CodMedioPago;
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
        public DataTable F_LGLiquidacion_Detallado(DocumentoVentaCabCE objEntidad)
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
                        sql_comando.CommandText = "pa_LGLiquidacion_Detallado";

                        sql_comando.Parameters.Add("@CodCajaChica", SqlDbType.Int).Value = objEntidad.CodCajaChica;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidad.CodUsuario;
                        if (objEntidad.CodDetalle > 0)
                            sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidad.CodDetalle;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);

                        Codigo.Direction = ParameterDirection.Output;
                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());
                        objEntidad.Codigo = Convert.ToInt32(Codigo.Value);

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


        public DataTable PA_CAJACHICA_LISTAR_LIQUIDACION_Detallado(DocumentoVentaCabCE objEntidad)
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
                        sql_comando.CommandText = "PA_CAJACHICA_LISTAR_LIQUIDACION_Detallado";

                        sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidad.XmlDetalle;
                        sql_comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = objEntidad.Codigo;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidad.MsgError = MsgError.Value.ToString();

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

        public DocumentoVentaCabCE F_AplicarDetallado(DocumentoVentaCabCE objEntidad)
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
                        sql_comando.CommandText = "Pa_AplicarDetallado";

                        sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidad.XmlDetalle;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidad.Codigo = Convert.ToInt32(Codigo.Value);
                        return objEntidad;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaCabCE F_TemporalFacturacionDet_Insert_Salcedo(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionDet_Insert";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.DateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;

                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodProforma", SqlDbType.Int).Value = objEntidadBE.CodProforma;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;

                        sql_comando.Parameters.Add("@CodGuia", SqlDbType.Int).Value = objEntidadBE.CodGuia;
                        sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;
                        sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 1000).Value = objEntidadBE.Observacion;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public DocumentoVentaCabCE F_TemporalFacturacionDetalle_Insert_Salcedo(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionDetalle_Insert";

                        sql_comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
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

        public DocumentoVentaCabCE F_TemporalFacturacionDet_Insert_Fundicion(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionDet_Insert";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.DateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;

                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodProforma", SqlDbType.Int).Value = objEntidadBE.CodProforma;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;

                        sql_comando.Parameters.Add("@CodGuia", SqlDbType.Int).Value = objEntidadBE.CodGuia;
                        sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;
                        sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public DocumentoVentaCabCE F_TemporalFacturacionDetalle_Insert_Fundicion(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionDetalle_Insert";

                        sql_comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
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

        public DataTable F_CajaChica_Detalle_liquidacion(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_CajaChica_Detalle_liquidacion";


                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@Codliquidacion", SqlDbType.Int).Value = objEntidadBE.Codliquidacion;
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

        public DataTable P_Contabilidad_Registrocobranzas(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_COBRANZASCAB_REPORTE_CONTABILIDAD_CONCAR";

                        if (objEntidadBE.CodAlmacen > 0)
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
        
        public DocumentoVentaCabCE F_EdicionFactura_Roy(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Update";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.DateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 10).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 10).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 10).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 10).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 10).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@CodTraslado", SqlDbType.Int).Value = objEntidadBE.CodTraslado;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 10).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 10).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.DateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 250).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@OrdenCompra", SqlDbType.VarChar, 15).Value = objEntidadBE.NroOC;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;
                        sql_comando.Parameters.Add("@Motorizado", SqlDbType.Int).Value = objEntidadBE.Motorizado;
                        sql_comando.Parameters.Add("@Recepcion", SqlDbType.SmallDateTime).Value = objEntidadBE.Recepcion;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 250).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@GuiaAgencia", SqlDbType.VarChar, 30).Value = objEntidadBE.GuiaAgencia;
                        sql_comando.Parameters.Add("@ObservacionesCliente", SqlDbType.VarChar, 250).Value = objEntidadBE.ObservacionesCliente;
                        sql_comando.Parameters.Add("@SerieOC", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieOC;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodVendedor", SqlDbType.Int).Value = objEntidadBE.CodVendedor;
                        sql_comando.Parameters.Add("@NombreAgencia", SqlDbType.VarChar, 200).Value = objEntidadBE.NombreAgencia;
                        sql_comando.Parameters.Add("@ClaveAgencia", SqlDbType.VarChar, 20).Value = objEntidadBE.ClaveAgencia;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 100).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 100).Value = objEntidadBE.DireccionTraslado;

                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTransportista", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@CodDepartamentoTransportista", SqlDbType.Int).Value = objEntidadBE.CodDepartamentoTransportista;
                        sql_comando.Parameters.Add("@CodProvinciaTransportista", SqlDbType.Int).Value = objEntidadBE.CodProvinciaTransportista;
                        sql_comando.Parameters.Add("@CodDistritoTransportista", SqlDbType.Int).Value = objEntidadBE.CodDistritoTransportista;
                        sql_comando.Parameters.Add("@DireccionTransportista", SqlDbType.VarChar, 100).Value = objEntidadBE.DireccionTransportista;

                        sql_comando.Parameters.Add("@RazonSocialTransportista  ", SqlDbType.VarChar, 200).Value = objEntidadBE.Transportista;
                        sql_comando.Parameters.Add("@RucTransportista  ", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRucTransportista;



                        sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 100).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 100).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NuBultos", SqlDbType.VarChar, 100).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 100).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@CodConductor", SqlDbType.Int).Value = objEntidadBE.CodConductor;
                        sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;

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

        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert_Factura_NV_Roy(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Insert_Factura_NV";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;
                        sql_comando.Parameters.Add("@AcuentaNV", SqlDbType.Decimal).Value = objEntidadBE.AcuentaNV;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 250).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                        sql_comando.Parameters.Add("@FlagCSIgv", SqlDbType.Int).Value = objEntidadBE.FlagCSIgv;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;


                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@RucTransportista", SqlDbType.VarChar, 50).Value = objEntidadBE.NroRucTransportista;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 200).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTrans", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@CodDepartamentoTrasportista", SqlDbType.Int).Value = objEntidadBE.CodDepartamentoTransportista;
                        sql_comando.Parameters.Add("@RazonSocialTrasportista", SqlDbType.VarChar, 500).Value = objEntidadBE.Transportista;
                        sql_comando.Parameters.Add("@CodProvinciaTrasportista", SqlDbType.Int).Value = objEntidadBE.CodProvinciaTransportista;
                        sql_comando.Parameters.Add("@CodDistritoTrasportista", SqlDbType.Int).Value = objEntidadBE.CodDistritoTransportista;

                        sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;

                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 50).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NroBultos", SqlDbType.VarChar, 50).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 50).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 50).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo;
                        sql_comando.Parameters.Add("@NroOC", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOC;
                        sql_comando.Parameters.Add("@Placa1", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 50).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;

                        // DATOS GUIA ELECTRONICA
                        sql_comando.Parameters.Add("@CodConductor", SqlDbType.Int).Value = objEntidadBE.CodConductor;
                        sql_comando.Parameters.Add("@DniConductor", SqlDbType.VarChar, 8).Value = objEntidadBE.DniConductor;
                        sql_comando.Parameters.Add("@NombreConductor", SqlDbType.VarChar, 350).Value = objEntidadBE.NombreConductor;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        SqlParameter CodigoGuia = sql_comando.Parameters.Add("@CodGuia", SqlDbType.Int);
                        CodigoGuia.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.CodGuia = Convert.ToInt32(CodigoGuia.Value);

                        return objEntidadBE;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaCabCE F_DocumentoVentaCab_Insert_Factura_NONV_Roy(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DocumentoVentaCab_Insert_Factura_NONV";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;
                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@FlagGuia", SqlDbType.Int).Value = objEntidadBE.FlagGuia;
                        sql_comando.Parameters.Add("@SerieGuia", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieGuia;
                        sql_comando.Parameters.Add("@NumeroGuia", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroGuia;
                        sql_comando.Parameters.Add("@FechaTraslado", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaTraslado;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodClaseCliente", SqlDbType.Int).Value = objEntidadBE.CodClaseCliente;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@ApePaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApePaterno;
                        sql_comando.Parameters.Add("@ApeMaterno", SqlDbType.VarChar, 80).Value = objEntidadBE.ApeMaterno;
                        sql_comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 80).Value = objEntidadBE.Nombres;
                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 8).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@Acuenta", SqlDbType.Decimal).Value = objEntidadBE.Acuenta;
                        sql_comando.Parameters.Add("@TasaIgv", SqlDbType.Decimal).Value = objEntidadBE.TasaIgv;
                        sql_comando.Parameters.Add("@Destino", SqlDbType.VarChar, 250).Value = objEntidadBE.Destino;
                        sql_comando.Parameters.Add("@Cliente", SqlDbType.VarChar, 250).Value = objEntidadBE.Cliente;
                        sql_comando.Parameters.Add("@CodTasa", SqlDbType.Int).Value = objEntidadBE.CodTasa;
                        sql_comando.Parameters.Add("@CodDetalle", SqlDbType.Int).Value = objEntidadBE.CodDetalle;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@CodFacturaAnterior", SqlDbType.Int).Value = objEntidadBE.CodFacturaAnterior;
                        sql_comando.Parameters.Add("@FlagCSIgv", SqlDbType.Int).Value = objEntidadBE.FlagCSIgv;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;


                        sql_comando.Parameters.Add("@CodTransportista", SqlDbType.Int).Value = objEntidadBE.CodTransportista;
                        sql_comando.Parameters.Add("@RucTransportista", SqlDbType.VarChar, 50).Value = objEntidadBE.NroRucTransportista;
                        sql_comando.Parameters.Add("@DireccionTraslado", SqlDbType.VarChar, 500).Value = objEntidadBE.DireccionTransportista;
                        sql_comando.Parameters.Add("@CodDireccionTrans", SqlDbType.Int).Value = objEntidadBE.CodDireccionTransportista;
                        sql_comando.Parameters.Add("@CodDepartamentoTrasportista", SqlDbType.Int).Value = objEntidadBE.CodDepartamentoTransportista;
                        sql_comando.Parameters.Add("@RazonSocialTrasportista", SqlDbType.VarChar, 500).Value = objEntidadBE.Transportista;
                        sql_comando.Parameters.Add("@CodProvinciaTrasportista", SqlDbType.Int).Value = objEntidadBE.CodProvinciaTransportista;
                        sql_comando.Parameters.Add("@CodDistritoTrasportista", SqlDbType.Int).Value = objEntidadBE.CodDistritoTransportista;




                        sql_comando.Parameters.Add("@MarcaVehiculo", SqlDbType.VarChar, 50).Value = objEntidadBE.Marca;

                        sql_comando.Parameters.Add("@Licencia", SqlDbType.VarChar, 50).Value = objEntidadBE.Licencia;
                        sql_comando.Parameters.Add("@NroBultos", SqlDbType.VarChar, 50).Value = objEntidadBE.NuBultos;
                        sql_comando.Parameters.Add("@Peso", SqlDbType.VarChar, 50).Value = objEntidadBE.Peso;
                        sql_comando.Parameters.Add("@PlacaTraslado", SqlDbType.VarChar, 50).Value = objEntidadBE.PlacaTraslado;
                        sql_comando.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = objEntidadBE.Correo;

                        sql_comando.Parameters.Add("@Placa1", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Placa2", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa2;
                        sql_comando.Parameters.Add("@Placa3", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa3;
                        sql_comando.Parameters.Add("@Placa4", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa4;
                        sql_comando.Parameters.Add("@KM", SqlDbType.VarChar, 20).Value = objEntidadBE.KM;
                        sql_comando.Parameters.Add("@NroOperacion", SqlDbType.VarChar, 50).Value = objEntidadBE.NroOperacion;
                        sql_comando.Parameters.Add("@CodEmpleado", SqlDbType.Int).Value = objEntidadBE.CodEmpleado;
                        sql_comando.Parameters.Add("@NroOC", SqlDbType.VarChar, 100).Value = objEntidadBE.NroOC;
                        sql_comando.Parameters.Add("@FlagComisionable", SqlDbType.Int).Value = objEntidadBE.FlagComisionable;

                        // DATOS DE LA GUIA ELECTRONICA
                        sql_comando.Parameters.Add("@CodConductor", SqlDbType.Int).Value = objEntidadBE.CodConductor;
                        sql_comando.Parameters.Add("@DniConductor", SqlDbType.VarChar, 8).Value = objEntidadBE.DniConductor;
                        sql_comando.Parameters.Add("@NombreConductor", SqlDbType.VarChar, 350).Value = objEntidadBE.NombreConductor;

                        sql_comando.Parameters.Add("@UsuarioPermiso", SqlDbType.VarChar, 160).Value = objEntidadBE.UsuarioPermiso;
                        sql_comando.Parameters.Add("@ClavePermiso", SqlDbType.VarChar, 60).Value = objEntidadBE.ClavePermiso;
                        sql_comando.Parameters.Add("@ObservacionPermiso", SqlDbType.VarChar, 300).Value = objEntidadBE.ObservacionPermiso;
                        sql_comando.Parameters.Add("@FlagConCodigo", SqlDbType.Int).Value = objEntidadBE.FlagConCodigo;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;


                        SqlParameter CodGuia = sql_comando.Parameters.Add("@CodGuia", SqlDbType.Int);
                        CodGuia.Direction = ParameterDirection.Output;
                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);
                        objEntidadBE.CodGuia = Convert.ToInt32(CodGuia.Value);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public DataTable F_NotaINgresoSalidaSinEnlazar(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_NotaINgresoSalidaSinEnlazar";

                        sql_comando.Parameters.Add("@Desde", SqlDbType.VarChar, 8).Value = objEntidadBE.DesdeInt;
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.VarChar, 8).Value = objEntidadBE.HastaInt;
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

        public DataTable F_Contabilidad_ClientesNuevos(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_TCCUENTACORRIENTE_NUEVO";

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

        public DocumentoVentaCabCE F_TemporalFacturacionDet_Insert_Alvarado_Servidor(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionDet_Insert_Alvarado_Servidor";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodTipoDoc", SqlDbType.Int).Value = objEntidadBE.CodTipoDoc;
                        sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                        sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;
                        sql_comando.Parameters.Add("@FechaEmision", SqlDbType.DateTime).Value = objEntidadBE.FechaEmision;
                        sql_comando.Parameters.Add("@Vencimiento", SqlDbType.DateTime).Value = objEntidadBE.FechaVencimiento;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;

                        sql_comando.Parameters.Add("@CodFormaPago", SqlDbType.Int).Value = objEntidadBE.CodFormaPago;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = objEntidadBE.SubTotal;

                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodProforma", SqlDbType.Int).Value = objEntidadBE.CodProforma;
                        sql_comando.Parameters.Add("@Igv", SqlDbType.Decimal).Value = objEntidadBE.Igv;
                        sql_comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = objEntidadBE.Total;

                        sql_comando.Parameters.Add("@CodGuia", SqlDbType.Int).Value = objEntidadBE.CodGuia;
                        sql_comando.Parameters.Add("@XmlDetalle", SqlDbType.Text).Value = objEntidadBE.XmlDetalle;
                        sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;

                        sql_comando.Parameters.Add("@SolicitarDescuento", SqlDbType.Int).Value = objEntidadBE.SolicitarDescuento;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter Codigo = sql_comando.Parameters.Add("@Codigo", SqlDbType.Int);
                        Codigo.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodDocumentoVenta = Convert.ToInt32(Codigo.Value);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public DataTable F_CAJACHICA_RESUMIDO_TICKET(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_CAJACHICA_RESUMIDO_TICKET";

                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCajaFisica", SqlDbType.Int).Value = objEntidadBE.CodCajaFisica;
                        sql_comando.Parameters.Add("@FechaCaja", SqlDbType.Int).Value = objEntidadBE.FechaEmision.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@FechaSaldo", SqlDbType.Int).Value = objEntidadBE.FechaSaldo.ToString("yyyyMMdd");

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

        public DataTable F_LiquidacionCajaCab_REPORTE(DocumentoVentaCabCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_LiquidacionCajaCab_REPORTE";

                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");

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
