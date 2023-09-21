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
    public class DocumentoVentaDetCD
    {
        public DocumentoVentaDetCE F_TemporalFacturacionDet_Eliminar(DocumentoVentaDetCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionDet_Eliminar";

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

        public DocumentoVentaDetCE F_TemporalFacturacionDetPedido_Eliminar(DocumentoVentaDetCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionDetPedido_Eliminar";

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

        public DataTable F_DocumentoVentaDet_Listar(DocumentoVentaDetCE objEntidadBE)
        {
            DataTable dta_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_DocumentoVentaDet_Listar";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
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

        public DataTable F_DocumentoVentaDet_Listar_Alvarado(DocumentoVentaDetCE objEntidadBE)
        {
            DataTable dta_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_DocumentoVentaDet_Listar";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
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
        
        public DataTable F_ProformaDet_ListarDetNI(DocumentoVentaDetCE objEntidadBE)
        {
            DataTable dta_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_CotizacionDet_NotaIngreso";

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

        public DocumentoVentaDetCE F_TemporalCodigoFacturaDet_Eliminar(DocumentoVentaDetCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalCodigoFacturaDet_Eliminar";

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

        public DataTable F_DocumentoVentaCab_RetencionDetalle(DocumentoVentaDetCE objEntidadBE)
        {

            DataTable dta_consulta = null;

            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_DocumentoVentaCab_RetencionDetalle";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@CodTipoOperacion", SqlDbType.Int).Value = objEntidadBE.CodTipoOperacion;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }

            finally { dta_consulta.Dispose(); }

        }

        public DataTable F_DocumentoVentaDet_Select_NV(DocumentoVentaDetCE objEntidadBE)
        {

            DataTable dta_consulta = null;

            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_DocumentoVentaDet_Select_NV";

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

        public DocumentoVentaDetCE F_TemporalSerializacionDet_Eliminar(DocumentoVentaDetCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalSerializacionDet_Eliminar";

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

        public DataTable F_TemporalFacturacionSerializacionDet_Listar(DocumentoVentaDetCE objEntidadBE)
        {

            DataTable dta_consulta = null;

            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_TemporalFacturacionSerializacionDet_Listar";

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

        public DocumentoVentaDetCE F_TemporalFacturacionDet_Update(DocumentoVentaDetCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_TemporalFacturacionDet_Update_Actualizaciones]";

                        sql_comando.Parameters.Add("@CodDetDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDetDocumentoVenta;
                        sql_comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = objEntidadBE.Precio;
                        sql_comando.Parameters.Add("@Precio2", SqlDbType.Decimal).Value = objEntidadBE.Precio2;
                        sql_comando.Parameters.Add("@PrecioOriginal", SqlDbType.Decimal).Value = objEntidadBE.PrecioOriginal;
                        sql_comando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = objEntidadBE.Cantidad;
                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 500).Value = objEntidadBE.Descripcion;
                        sql_comando.Parameters.Add("@Flag", SqlDbType.Int).Value = objEntidadBE.Flag;
                        sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                        sql_comando.Parameters.Add("@SolicitudDescuento", SqlDbType.Int).Value = objEntidadBE.SolicitudDescuento;
                        sql_comando.Parameters.Add("@Margen", SqlDbType.Int).Value = objEntidadBE.Margen;
                        sql_comando.Parameters.Add("@Margen2", SqlDbType.Decimal).Value = objEntidadBE.Margen2;
                        sql_comando.Parameters.Add("@Material", SqlDbType.VarChar, 250).Value = objEntidadBE.Material;
                    
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
                //objEntidadBE.MsgError = ex.Message.ToString();

            }
        }

        public DocumentoVentaDetCE F_TemporalFacturacionDetPedido_Update(DocumentoVentaDetCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_TemporalFacturacionDetPedido_Update]";

                        sql_comando.Parameters.Add("@CodDetPedido", SqlDbType.Int).Value = objEntidadBE.CodDetPedido;
                        sql_comando.Parameters.Add("@CantidadABC", SqlDbType.Decimal).Value = objEntidadBE.CantidadABC;
                        sql_comando.Parameters.Add("@Cantidad173", SqlDbType.Decimal).Value = objEntidadBE.Cantidad173;
                        sql_comando.Parameters.Add("@Cantidad250", SqlDbType.Decimal).Value = objEntidadBE.Cantidad250;

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
                //objEntidadBE.MsgError = ex.Message.ToString();

            }
        }

        public DocumentoVentaDetCE F_TemporalFacturacionDet_Update_Yordan(DocumentoVentaDetCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_TemporalFacturacionDet_Update_Actualizaciones]";

                        sql_comando.Parameters.Add("@CodDetDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDetDocumentoVenta;
                        sql_comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = objEntidadBE.Precio;
                        sql_comando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = objEntidadBE.Cantidad;
                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 500).Value = objEntidadBE.Descripcion;
                        sql_comando.Parameters.Add("@Flag", SqlDbType.Int).Value = objEntidadBE.Flag;
                        sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                        sql_comando.Parameters.Add("@SolicitudDescuento", SqlDbType.Int).Value = objEntidadBE.SolicitudDescuento;

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
                //objEntidadBE.MsgError = ex.Message.ToString();

            }
        }

        public DocumentoVentaDetCE F_TemporalFacturacionDet_UpdateSolicitudDescuento_Yordan(DocumentoVentaDetCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_TemporalFacturacionDet_Update_SolicitudDescuento_Actualizaciones]";

                        sql_comando.Parameters.Add("@CodDetDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDetDocumentoVenta;
                        sql_comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = objEntidadBE.Precio;
                        sql_comando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = objEntidadBE.Cantidad;
                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 500).Value = objEntidadBE.Descripcion;
                        sql_comando.Parameters.Add("@Flag", SqlDbType.Int).Value = objEntidadBE.Flag;
                        sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                        sql_comando.Parameters.Add("@SolicitudDescuento", SqlDbType.Int).Value = objEntidadBE.SolicitudDescuento;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@TipoAccion", SqlDbType.VarChar, 1).Value = objEntidadBE.TipoAccion;

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
                //objEntidadBE.MsgError = ex.Message.ToString();

            }
        }

        public DocumentoVentaDetCE F_TemporalFacturacionDet_Update_Roman(DocumentoVentaDetCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_TemporalFacturacionDet_Update_Actualizaciones]";

                        sql_comando.Parameters.Add("@CodDetDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDetDocumentoVenta;
                        sql_comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = objEntidadBE.Precio;
                        sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;
                        sql_comando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = objEntidadBE.Cantidad;
                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 500).Value = objEntidadBE.Descripcion;
                        sql_comando.Parameters.Add("@Flag", SqlDbType.Int).Value = objEntidadBE.Flag;

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
                //objEntidadBE.MsgError = ex.Message.ToString();

            }



        }

        public DocumentoVentaDetCE F_FlagGratuito_Update(DocumentoVentaDetCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_TemporalFacturacionDet_Update_FlagGratuito]";

                        sql_comando.Parameters.Add("@CodDetDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDetDocumentoVenta;
                        sql_comando.Parameters.Add("@Flag", SqlDbType.Int).Value = objEntidadBE.Flag;

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
                //objEntidadBE.MsgError = ex.Message.ToString();

            }



        }

        public DocumentoVentaDetCE F_TemporalFacturacionDet_Update_Actualizaciones(DocumentoVentaDetCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_TemporalFacturacionDet_Update_Actualizaciones]";

                        sql_comando.Parameters.Add("@CodDetDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDetDocumentoVenta;
                        sql_comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = objEntidadBE.Precio;
                        sql_comando.Parameters.Add("@Precio2", SqlDbType.Decimal).Value = objEntidadBE.Precio2;
                        sql_comando.Parameters.Add("@Precio3", SqlDbType.Decimal).Value = objEntidadBE.Precio3;
                        sql_comando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = objEntidadBE.Cantidad;
                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 500).Value = objEntidadBE.Descripcion;
                        sql_comando.Parameters.Add("@Marca", SqlDbType.VarChar, 100).Value = objEntidadBE.Marca;
                        sql_comando.Parameters.Add("@Flag", SqlDbType.Int).Value = objEntidadBE.Flag;

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
                //objEntidadBE.MsgError = ex.Message.ToString();

            }



        }

        public DocumentoVentaDetCE F_TemporalFacturacionSerializacionDet_Eliminar(DocumentoVentaDetCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionSerializacionDet_Eliminar";

                        sql_comando.Parameters.Add("@CodTemporalSerializacionDet", SqlDbType.Int).Value = objEntidadBE.CodTemporalSerializacionDet;
                        sql_comando.Parameters.Add("@CodDetDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDetDocumentoVenta;
                        sql_comando.Parameters.Add("@Flag", SqlDbType.Int).Value = objEntidadBE.Flag;

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

        public DataTable F_CobranzasDet_Listar(DocumentoVentaDetCE objEntidadBE)
        {
            DataTable dta_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_CobranzasDet_Listar";

                        sql_comando.Parameters.Add("@CodCobranzaCab", SqlDbType.Int).Value = objEntidadBE.CodCobranzaCab;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }

        //eliminar 

        public DataTable F_CobranzasDet_Eliminar_Listar(DocumentoVentaDetCE objEntidadBE)
        {
            DataTable dta_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_CobranzasDet_Eliminados_Listar";

                        sql_comando.Parameters.Add("@CodCobranzaCab", SqlDbType.Int).Value = objEntidadBE.CodCobranzaCab;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }

        public DocumentoVentaDetCE F_TemporalFacturacionDet_Editar(DocumentoVentaDetCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionDet_Editar";

                        sql_comando.Parameters.Add("@CodDetDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDetDocumentoVenta;
                        sql_comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = objEntidadBE.Precio;
                        sql_comando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = objEntidadBE.Cantidad;

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

        public DataTable F_PagosDet_Listar(DocumentoVentaDetCE objEntidadBE)
        {

            DataTable dta_consulta = null;

            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_PagosDet_Listar";

                        sql_comando.Parameters.Add("@CodPagoCab", SqlDbType.Int).Value = objEntidadBE.CodPagoCab;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }

            finally { dta_consulta.Dispose(); }

        }

        public DataTable F_DocumentoVentaSerializacionDet_Listar(DocumentoVentaDetCE objEntidadBE)
        {

            DataTable dta_consulta = null;

            try
            {

                using (SqlConnection sql_conexion = new SqlConnection())
                {

                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_DocumentoVentaSerializacionDet_Listar";

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

        public DocumentoVentaDetCE F_TemporalFacturacionDet_Actualizar(DocumentoVentaDetCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionDet_Actualizar";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@FlagIgv", SqlDbType.Decimal).Value = objEntidadBE.FlagIgv;

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

        public DocumentoVentaDetCE F_TemporalCodigoFacturaDet_Update(DocumentoVentaDetCE objEntidadBE)
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

                        sql_comando.Parameters.Add("@CodFacturaDet", SqlDbType.Int).Value = objEntidadBE.CodFacturaDet;
                        sql_comando.Parameters.Add("@TC", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;
                        sql_comando.Parameters.Add("@Soles", SqlDbType.Decimal).Value = objEntidadBE.Soles;
                        sql_comando.Parameters.Add("@Dolares", SqlDbType.Decimal).Value = objEntidadBE.Dolares;

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

        public DataTable F_DOCUMENTOVENTACAB_KARDEX(DocumentoVentaCabCE objEntidadBE)
        {
            DataTable dta_consulta = null;

            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "PA_DOCUMENTOVENTACAB_KARDEX";

                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCliente;

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

        public DataTable F_LGPRODUCTOS_STOCKDETALLE(DocumentoVentaDetCE objEntidadBE)
        {
            DataTable dta_consulta = null;

            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "PA_LGPRODUCTOS_STOCKDETALLE";

                        sql_comando.Parameters.Add("@CodProducto", SqlDbType.Int).Value = objEntidadBE.CodProducto;
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

        public DataTable F_PROFORMACAB_OBSERVACION(DocumentoVentaCabCE objEntidadBE)
        {
            DataTable dta_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "PA_PROFORMACAB_OBSERVACION";

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

        public DocumentoVentaDetCE F_ACTUALIZAR_MONTO_MONEDA(DocumentoVentaDetCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_TEMPORALFACTURACIONDET_ACTUALIZAR_MONTO_MONEDA";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@CodMoneda", SqlDbType.Int).Value = objEntidadBE.CodMoneda;
                        sql_comando.Parameters.Add("@TipoCambio", SqlDbType.Decimal).Value = objEntidadBE.TipoCambio;

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
                //objEntidadBE.MsgError = ex.Message.ToString();

            }



        }

        public DocumentoVentaDetCE F_TemporalFacturacionDet_Actualizar_TIEMPO(DocumentoVentaDetCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionDet_Actualizar_TIEMPO";

                        sql_comando.Parameters.Add("@CodDetDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDetDocumentoVenta;
                        sql_comando.Parameters.Add("@Comentario", SqlDbType.VarChar, 8000).Value = objEntidadBE.Comentario;
                        sql_comando.Parameters.Add("@TiempoProducto", SqlDbType.VarChar, 500).Value = objEntidadBE.TiempoProducto;

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
                //objEntidadBE.MsgError = ex.Message.ToString();

            }



        }

        public DataTable F_ComprobanteCajaDet_LISTAR(DocumentoVentaDetCE objEntidadBE)
        {
            DataTable dta_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "PA_ComprobanteCajaDet_LISTAR";

                        sql_comando.Parameters.Add("@CodComprobanteCaja", SqlDbType.Int).Value = objEntidadBE.CodComprobanteCaja;
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

        public DataTable F_COBRANZASCAB_OBSERVACION(DocumentoVentaDetCE objEntidadBE)
        {
            DataTable dta_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "PA_COBRANZASCAB_OBSERVACION";

                        sql_comando.Parameters.Add("@CodCobranzaCab", SqlDbType.Int).Value = objEntidadBE.CodCobranzaCab;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;
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

        public DataTable F_COBRANZASCAB_ELIMINADOS_OBSERVACION(DocumentoVentaDetCE objEntidadBE)
        {
            DataTable dta_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "PA_COBRANZASCAB_Eliminadas_OBSERVACION";

                        sql_comando.Parameters.Add("@CodCobranzaCab", SqlDbType.Int).Value = objEntidadBE.CodCobranzaCab;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }
        //auditoria
        public DataTable F_COBRANZASCAB_AUDITORIA(DocumentoVentaDetCE objEntidadBE)
        {
            DataTable dta_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "PA_CobranzasCab_AUDITORIA";

                        sql_comando.Parameters.Add("@CodCobranzaCab", SqlDbType.Int).Value = objEntidadBE.CodCobranzaCab;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }

        public DataTable F_PAGOSCAB_AUDITORIA(DocumentoVentaDetCE objEntidadBE)
        {
            DataTable dta_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "PA_PAGOSCab_AUDITORIA";

                        sql_comando.Parameters.Add("@CodPagoCab", SqlDbType.Int).Value = objEntidadBE.CodPagoCab;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }

        public DataTable F_PAGOSCAB_OBSERVACION(DocumentoVentaDetCE objEntidadBE)
        {
            DataTable dta_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "PA_PAGOSCAB_OBSERVACION";

                        sql_comando.Parameters.Add("@CodPagoCab", SqlDbType.Int).Value = objEntidadBE.CodPagoCab;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }

        public DataTable F_ProformaDet_Listar(DocumentoVentaDetCE objEntidadBE)
        {
            DataTable dta_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_ProformaDet_Listar";

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

        public DataTable F_DOCUMENTOVENTACAB_LISTAR_COBRANZAS_DETALLADO(DocumentoVentaDetCE objEntidadBE)
        {
            DataTable dta_consulta = null;
            try
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

        public DataTable F_DOCUMENTOVENTACAB_OBSERVACION(DocumentoVentaCabCE objEntidadBE)
        {
            DataTable dta_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "PA_DOCUMENTOVENTACAB_OBSERVACION";

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

        public DataTable F_DOCUMENTOVENTACAB_OBSERVACIONCLEVER(DocumentoVentaCabCE objEntidadBE)
        {
            DataTable dta_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "PA_DOCUMENTOVENTACAB_OBSERVACIONCLEVER";

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

        public DataTable F_PROFORMACAB_OBSERVACIONCLEVER(DocumentoVentaCabCE objEntidadBE)
        {
            DataTable dta_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "PA_PROFORMACAB_OBSERVACIONCLEVER";

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

        public DocumentoVentaDetCE F_TemporalFacturacionDetallado_Eliminar(DocumentoVentaDetCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionDetallado_Eliminar";

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

        public DocumentoVentaDetCE F_TemporalFacturacionDet_ACTUALIZAR_DESCUENTO(DocumentoVentaDetCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_TemporalFacturacionDet_ACTUALIZAR_DESCUENTO";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidadBE.Descuento;

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
                //objEntidadBE.MsgError = ex.Message.ToString();
            }
        }

        public DataTable F_CobranzasCab_ELIMINADOS_AUDITORIA(DocumentoVentaDetCE objEntidadBE)
        {
            DataTable dta_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "PA_CobranzasCab_ELIMINADOS_AUDITORIA";

                        sql_comando.Parameters.Add("@CodCobranzaCab", SqlDbType.Int).Value = objEntidadBE.CodCobranzaCab;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }

        public DataTable F_COBRANZASCAB_Eliminadas_OBSERVACIONes(DocumentoVentaDetCE objEntidadBE)
        {
            DataTable dta_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "PA_COBRANZASCAB_Eliminadas_OBSERVACIONes";

                        sql_comando.Parameters.Add("@CodCobranzaCab", SqlDbType.Int).Value = objEntidadBE.CodCobranzaCab;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }

        public DocumentoVentaDetCE F_TemporalFacturacionDet_Actualizar_Gratuito(DocumentoVentaDetCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_TemporalFacturacionDet_GRATUITO";

                        sql_comando.Parameters.Add("@CodDetDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDetDocumentoVenta;
                        sql_comando.Parameters.Add("@CodGratuito", SqlDbType.Int).Value = objEntidadBE.CodGratuito;
                        
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
                //objEntidadBE.MsgError = ex.Message.ToString();

            }



        }

        public DataTable F_DOCUMENTOVENTACAB_AUDITORIA(DocumentoVentaCabCE objEntidadBE)
        {
            DataTable dta_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "PA_DOCUMENTOVENTACAB_AUDITORIA";

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
        public DataTable F_PagosDet_Eliminar_Listar(DocumentoVentaDetCE objEntidadBE)
        {
            DataTable dta_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_PagosDet_Eliminados_Listar";

                        sql_comando.Parameters.Add("@CodPagoCab", SqlDbType.Int).Value = objEntidadBE.CodPagoCab;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }

        public DataTable F_PAGOSCAB_ELIMINADOS_OBSERVACION(DocumentoVentaDetCE objEntidadBE)
        {
            DataTable dta_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_Pagos_Eliminados_Observacion";

                        sql_comando.Parameters.Add("@CodPagoCab", SqlDbType.Int).Value = objEntidadBE.CodPagoCab;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }

        public DataTable F_ProformaDet_Listar_ROMAN(DocumentoVentaDetCE objEntidadBE)
        {
            DataTable dta_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "PA_ProformaDet_Listar";

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

        public DataTable F_CAJACHICADet_Listar(DocumentoVentaDetCE objEntidadBE)
        {
            DataTable dta_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_CAJACHICADet_Listar";

                        sql_comando.Parameters.Add("@CodLiquidacionCajaCab", SqlDbType.Int).Value = objEntidadBE.codigo;
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

        public DataTable F_LIQUIDACION_OBSERVACION(DocumentoVentaCabCE objEntidadBE)
        {
            DataTable dta_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "PA_LIQUIDACION_OBSERVACION";

                        sql_comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = objEntidadBE.Codigo;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }

        public DataTable F_CAJACHICADet_Listar_liquidacion(DocumentoVentaDetCE objEntidadBE)
        {
            DataTable dta_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_CAJACHICADet_Listar_liquidacion";

                        sql_comando.Parameters.Add("@CodLiquidacionCajaCab", SqlDbType.Int).Value = objEntidadBE.codigo;
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


        public DocumentoVentaDetCE F_TemporalFacturacionDet_UpdatexKilo(DocumentoVentaDetCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionDet_Update_Actualizaciones_Xkilo";

                        sql_comando.Parameters.Add("@CodDetDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.CodDetDocumentoVenta;
                        sql_comando.Parameters.Add("@PxKilo", SqlDbType.Decimal).Value = objEntidadBE.PxKilo;
                        sql_comando.Parameters.Add("@PEstimado", SqlDbType.Decimal).Value = objEntidadBE.PEstimado;


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
                //objEntidadBE.MsgError = ex.Message.ToString();

            }
        }

        public DataTable F_DocumentoVentaDet_Devolucion_Listar(DocumentoVentaDetCE objEntidadBE)
        {
            DataTable dta_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_DocumentoVentaDet_Devolucion_Listar";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidadBE.codigo;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }

            finally { dta_consulta.Dispose(); }

        }

        public DocumentoVentaDetCE F_DevolucionAgregar(DocumentoVentaDetCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_DevolucionAgregar";

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

        public DocumentoVentaDetCE F_TemporalFacturacionDet_Update_Salcedo(DocumentoVentaDetCE objEntidad)
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
                        sql_comando.CommandText = "[pa_TemporalFacturacionDet_Update_Actualizaciones]";

                        sql_comando.Parameters.Add("@CodDetDocumentoVenta", SqlDbType.Int).Value = objEntidad.CodDetDocumentoVenta;
                        sql_comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = objEntidad.Precio;
                        sql_comando.Parameters.Add("@Precio2", SqlDbType.Decimal).Value = objEntidad.Precio2;
                        sql_comando.Parameters.Add("@PrecioOriginal", SqlDbType.Decimal).Value = objEntidad.PrecioOriginal;
                        sql_comando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = objEntidad.Cantidad;
                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 500).Value = objEntidad.Descripcion;
                        sql_comando.Parameters.Add("@Flag", SqlDbType.Int).Value = objEntidad.Flag;
                        sql_comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = objEntidad.Descuento;
                        sql_comando.Parameters.Add("@SolicitudDescuento", SqlDbType.Int).Value = objEntidad.SolicitudDescuento;
                        sql_comando.Parameters.Add("@Margen", SqlDbType.Int).Value = objEntidad.Margen;
                        sql_comando.Parameters.Add("@Margen2", SqlDbType.Decimal).Value = objEntidad.Margen2;
                        sql_comando.Parameters.Add("@Material", SqlDbType.VarChar, 250).Value = objEntidad.Material;

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
                //objEntidadBE.MsgError = ex.Message.ToString();

            }
        }

        public DocumentoVentaDetCE F_TemporalFacturacionDet_Actualizar_Salcedo(DocumentoVentaDetCE objEntidad)
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
                        sql_comando.CommandText = "pa_TemporalFacturacionDet_Actualizar";

                        sql_comando.Parameters.Add("@CodDocumentoVenta", SqlDbType.Int).Value = objEntidad.CodDocumentoVenta;
                        sql_comando.Parameters.Add("@FlagIgv", SqlDbType.Decimal).Value = objEntidad.FlagIgv;

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


        public DataTable F_CobranzasDet_ComisionTarjeta(Cobranzas objEntidadBE)
        {
            DataTable dta_consulta = null;
            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "PA_CobranzasDet_ComisionTarjeta";

                        sql_comando.Parameters.Add("@CodCobranza", SqlDbType.Int).Value = objEntidadBE.CodCobranza;
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
    }
}
