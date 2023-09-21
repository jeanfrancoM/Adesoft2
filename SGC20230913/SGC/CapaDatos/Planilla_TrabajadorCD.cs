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
    public class Planilla_TrabajadorCD
    {
        public DataTable F_Planilla_Trabajador_Listar(Planilla_TrabajadorCE objEntidadBE)
        {
            DataTable dta_consulta = null;

            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_Planilla_Trabajador_Listar";

                        if (objEntidadBE.ApellidosNombres != "")
                            sql_comando.Parameters.Add("@ApellidosNombres", SqlDbType.VarChar, 200).Value = objEntidadBE.ApellidosNombres;

                        dta_consulta = new DataTable();
                        dta_consulta.Load(sql_comando.ExecuteReader());
                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }

        public DataTable F_Planilla_Trabajador_Obtener(Planilla_TrabajadorCE objEntidadBE)
        {
            DataTable dta_consulta = null;

            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_Planilla_Trabajador_Obtener";

                        //sql_comando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = objEntidadBE.FechaInicial;

                        dta_consulta = new DataTable();
                        dta_consulta.Load(sql_comando.ExecuteReader());
                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }

        public DataTable F_Planilla_Trabajador_Obtener_Por_Trabajador(Planilla_TrabajadorCE objEntidadBE)
        {
            DataTable dta_consulta = null;

            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_Planilla_Trabajador_Obtener_Por_Trabajador";

                        //sql_comando.Parameters.Add("@AñoTrabajador", SqlDbType.VarChar, 6).Value = objEntidadBE.AñoTrabajador1;

                        dta_consulta = new DataTable();
                        dta_consulta.Load(sql_comando.ExecuteReader());
                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }

        public Planilla_TrabajadorCE F_Planilla_Trabajador_Insert(Planilla_TrabajadorCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_Trabajador_Insert]";

                        //sql_comando.Parameters.Add("@CodTrabajador", SqlDbType.Int).Value = objEntidadBE.CodTrabajador;
                        sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidadBE.CodCategoria;
                        sql_comando.Parameters.Add("@CodProyecto", SqlDbType.Int).Value = objEntidadBE.CodProyecto;
                        sql_comando.Parameters.Add("@CodAFP", SqlDbType.Int).Value = objEntidadBE.CodAFP;
                        sql_comando.Parameters.Add("@CodTipoDocumento", SqlDbType.Int).Value = objEntidadBE.CodTipoDocumento;

                        sql_comando.Parameters.Add("@NroDocumento", SqlDbType.VarChar, 20).Value = objEntidadBE.NroDocumento;
                        sql_comando.Parameters.Add("@CUSP", SqlDbType.VarChar, 20).Value = objEntidadBE.CUSP;
                        sql_comando.Parameters.Add("@FechaNacimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaNacimiento;
                        sql_comando.Parameters.Add("@PaisEmisor", SqlDbType.VarChar, 100).Value = objEntidadBE.PaisEmisor;
                        sql_comando.Parameters.Add("@ApellidosNombres", SqlDbType.VarChar, 300).Value = objEntidadBE.ApellidosNombres;
                        sql_comando.Parameters.Add("@Sexo", SqlDbType.Int).Value = objEntidadBE.Sexo;
                        sql_comando.Parameters.Add("@EstadoCivil", SqlDbType.Int).Value = objEntidadBE.EstadoCivil;
                        sql_comando.Parameters.Add("@Nacionalidad", SqlDbType.VarChar, 100).Value = objEntidadBE.Nacionalidad;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 500).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;

                        sql_comando.Parameters.Add("@FechaIngreso", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaIngreso;
                        sql_comando.Parameters.Add("@FechaCese", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaCese;

                        sql_comando.Parameters.Add("@NroHijos", SqlDbType.Int).Value = objEntidadBE.NroHijos;
                        sql_comando.Parameters.Add("@Pensiones_AFP", SqlDbType.Decimal).Value = objEntidadBE.Pensiones_AFP;
                        sql_comando.Parameters.Add("@Prima_AFP", SqlDbType.Decimal).Value = objEntidadBE.Prima_AFP;
                        sql_comando.Parameters.Add("@Comision_AFP", SqlDbType.Decimal).Value = objEntidadBE.Comision_AFP;
                        sql_comando.Parameters.Add("@Anticipada_AFP", SqlDbType.Decimal).Value = objEntidadBE.Anticipada_AFP;
                        sql_comando.Parameters.Add("@DescuentoJudicial", SqlDbType.Decimal).Value = objEntidadBE.DescuentoJudicial;

                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;

                        sql_comando.Parameters.Add("@RetencionAnteriorCodRetencion", SqlDbType.Int).Value = objEntidadBE.RetencionAnteriorCodRetencion;
                        sql_comando.Parameters.Add("@RetencionAnteriorAño", SqlDbType.Int).Value = objEntidadBE.RetencionAnteriorAño;
                        sql_comando.Parameters.Add("@RetencionAnteriorMonto", SqlDbType.Decimal).Value = objEntidadBE.RetencionAnteriorMonto;
                        sql_comando.Parameters.Add("@RetencionAnteriorTotalRemuneraciones", SqlDbType.Decimal).Value = objEntidadBE.RetencionAnteriorTotalRemuneraciones;

                        sql_comando.Parameters.Add("@SalarioMensual", SqlDbType.Decimal).Value = objEntidadBE.SalarioMensual;

                        sql_comando.Parameters.Add("@CodSeguridadSocial", SqlDbType.Int).Value = objEntidadBE.CodSeguridadSocial;

                        sql_comando.Parameters.Add("@Consorciado", SqlDbType.VarChar,30).Value = objEntidadBE.Consorciado;
                        sql_comando.Parameters.Add("@CodBanco", SqlDbType.Int).Value = objEntidadBE.CodBanco;
                        sql_comando.Parameters.Add("@NumCuenta", SqlDbType.VarChar,30).Value = objEntidadBE.NumeroCuenta;
                        sql_comando.Parameters.Add("@CCI", SqlDbType.VarChar, 30).Value = objEntidadBE.CCI;
                        sql_comando.Parameters.Add("@AreaTrabajo", SqlDbType.VarChar, 30).Value = objEntidadBE.AreaTrabajo;
                        sql_comando.Parameters.Add("@CentroCostos", SqlDbType.VarChar, 80).Value = objEntidadBE.CentroCostos;
                        sql_comando.Parameters.Add("@CodCargo", SqlDbType.Int).Value = objEntidadBE.CodCargo;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter CodTrabajador = sql_comando.Parameters.Add("@CodTrabajador", SqlDbType.Int);
                        CodTrabajador.Direction = ParameterDirection.Output;


                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodTrabajador = Convert.ToInt32(CodTrabajador.Value.ToString());

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public Planilla_TrabajadorCE F_Planilla_Trabajador_Update(Planilla_TrabajadorCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_Trabajador_Update]";

                        sql_comando.Parameters.Add("@CodTrabajador", SqlDbType.Int).Value = objEntidadBE.CodTrabajador;
                        sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidadBE.CodCategoria;
                        sql_comando.Parameters.Add("@CodProyecto", SqlDbType.Int).Value = objEntidadBE.CodProyecto;
                        sql_comando.Parameters.Add("@CodAFP", SqlDbType.Int).Value = objEntidadBE.CodAFP;
                        sql_comando.Parameters.Add("@CodTipoDocumento", SqlDbType.Int).Value = objEntidadBE.CodTipoDocumento;

                        sql_comando.Parameters.Add("@NroDocumento", SqlDbType.VarChar, 20).Value = objEntidadBE.NroDocumento;
                        sql_comando.Parameters.Add("@CUSP", SqlDbType.VarChar, 20).Value = objEntidadBE.CUSP;
                        sql_comando.Parameters.Add("@FechaNacimiento", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaNacimiento;
                        sql_comando.Parameters.Add("@PaisEmisor", SqlDbType.VarChar, 100).Value = objEntidadBE.PaisEmisor;
                        sql_comando.Parameters.Add("@ApellidosNombres", SqlDbType.VarChar, 300).Value = objEntidadBE.ApellidosNombres;
                        sql_comando.Parameters.Add("@Sexo", SqlDbType.Int).Value = objEntidadBE.Sexo;
                        sql_comando.Parameters.Add("@EstadoCivil", SqlDbType.Int).Value = objEntidadBE.EstadoCivil;
                        sql_comando.Parameters.Add("@Nacionalidad", SqlDbType.VarChar, 100).Value = objEntidadBE.Nacionalidad;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 500).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;

                        sql_comando.Parameters.Add("@FechaIngreso", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaIngreso;
                        if (objEntidadBE.FechaCese != Convert.ToDateTime("1/1/0001 00:00:00"))
                        {
                            sql_comando.Parameters.Add("@FechaCese", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaCese;                            
                        }                        
                        sql_comando.Parameters.Add("@NroHijos", SqlDbType.Int).Value = objEntidadBE.NroHijos;
                        sql_comando.Parameters.Add("@Pensiones_AFP", SqlDbType.Decimal).Value = objEntidadBE.Pensiones_AFP;
                        sql_comando.Parameters.Add("@Prima_AFP", SqlDbType.Decimal).Value = objEntidadBE.Prima_AFP;
                        sql_comando.Parameters.Add("@Comision_AFP", SqlDbType.Decimal).Value = objEntidadBE.Comision_AFP;
                        sql_comando.Parameters.Add("@Anticipada_AFP", SqlDbType.Decimal).Value = objEntidadBE.Anticipada_AFP;
                        sql_comando.Parameters.Add("@DescuentoJudicial", SqlDbType.Decimal).Value = objEntidadBE.DescuentoJudicial;

                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;

                        sql_comando.Parameters.Add("@RetencionAnteriorCodRetencion", SqlDbType.Int).Value = objEntidadBE.RetencionAnteriorCodRetencion;
                        sql_comando.Parameters.Add("@RetencionAnteriorAño", SqlDbType.Int).Value = objEntidadBE.RetencionAnteriorAño;
                        sql_comando.Parameters.Add("@RetencionAnteriorMonto", SqlDbType.Decimal).Value = objEntidadBE.RetencionAnteriorMonto;
                        sql_comando.Parameters.Add("@RetencionAnteriorTotalRemuneraciones", SqlDbType.Decimal).Value = objEntidadBE.RetencionAnteriorTotalRemuneraciones;

                        sql_comando.Parameters.Add("@SalarioMensual", SqlDbType.Decimal).Value = objEntidadBE.SalarioMensual;

                        sql_comando.Parameters.Add("@CodSeguridadSocial", SqlDbType.Int).Value = objEntidadBE.CodSeguridadSocial;

                        sql_comando.Parameters.Add("@Consorciado", SqlDbType.VarChar, 30).Value = objEntidadBE.Consorciado;
                        sql_comando.Parameters.Add("@CodBanco", SqlDbType.Int).Value = objEntidadBE.CodBanco;
                        sql_comando.Parameters.Add("@NumCuenta", SqlDbType.VarChar, 30).Value = objEntidadBE.NumeroCuenta;
                        sql_comando.Parameters.Add("@CCI", SqlDbType.VarChar, 30).Value = objEntidadBE.CCI;
                        sql_comando.Parameters.Add("@AreaTrabajo", SqlDbType.VarChar, 30).Value = objEntidadBE.AreaTrabajo;
                        sql_comando.Parameters.Add("@CentroCostos", SqlDbType.VarChar, 80).Value = objEntidadBE.CentroCostos;
                        sql_comando.Parameters.Add("@CodCargo", SqlDbType.Int).Value = objEntidadBE.CodCargo;

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

        public Planilla_TrabajadorCE F_Planilla_Trabajador_Eliminar(Planilla_TrabajadorCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_Trabajador_Eliminar]";

                        sql_comando.Parameters.Add("@CodTrabajador", SqlDbType.Int).Value = objEntidadBE.CodTrabajador;

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

        public DataTable F_Planilla_Trabajador_Retenciones_Anteriores_Listar(Planilla_TrabajadorCE objEntidadBE)
        {
            DataTable dta_consulta = null;

            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_Planilla_Empleado_Retenciones_Anteriores_Listar";

                            sql_comando.Parameters.Add("@CodTrabajador", SqlDbType.Int).Value = objEntidadBE.CodTrabajador;

                        dta_consulta = new DataTable();
                        dta_consulta.Load(sql_comando.ExecuteReader());
                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }








        public Planilla_TrabajadorCE F_Planilla_Trabajador_Retenciones_Anteriores_Insert(Planilla_TrabajadorCE objEntidadBE)
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

                        sql_comando.CommandText = "[pa_Planilla_Trabajador_Retenciones_Anteriores_Insert]";

                        sql_comando.Parameters.Add("@CodTrabajador", SqlDbType.Int).Value = objEntidadBE.CodTrabajador;
                        sql_comando.Parameters.Add("@CodPeriodo", SqlDbType.Int).Value = objEntidadBE.RetencionAnteriorCodPeriodo;
                        sql_comando.Parameters.Add("@MontoRetenido", SqlDbType.Decimal).Value = objEntidadBE.RetencionAnteriorMonto;
                        sql_comando.Parameters.Add("@TotalIngresos", SqlDbType.Decimal).Value = objEntidadBE.RetencionAnteriorTotalRemuneraciones;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 1000).Value = objEntidadBE.RetencionAnteriorObservacion;
                        sql_comando.Parameters.Add("@FechaExacta", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaExactaRetencion;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                    
                         SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter CodTrabajador = sql_comando.Parameters.Add("@Id", SqlDbType.Int);
                        CodTrabajador.Direction = ParameterDirection.Output;

                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.RetencionAnteriorCodRetencion = Convert.ToInt32(CodTrabajador.Value.ToString());

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public Planilla_TrabajadorCE F_Planilla_Trabajador_Retenciones_Anteriores_Update(Planilla_TrabajadorCE objEntidadBE)
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

                        sql_comando.CommandText = "[pa_Planilla_Trabajador_Retenciones_Anteriores_Update]";

                        sql_comando.Parameters.Add("@Id", SqlDbType.Int).Value = objEntidadBE.RetencionAnteriorCodRetencion;
                        sql_comando.Parameters.Add("@CodTrabajador", SqlDbType.Int).Value = objEntidadBE.CodTrabajador;
                        sql_comando.Parameters.Add("@CodPeriodo", SqlDbType.Int).Value = objEntidadBE.RetencionAnteriorCodPeriodo;
                        sql_comando.Parameters.Add("@MontoRetenido", SqlDbType.Decimal).Value = objEntidadBE.RetencionAnteriorMonto;
                        sql_comando.Parameters.Add("@TotalIngresos", SqlDbType.Decimal).Value = objEntidadBE.RetencionAnteriorTotalRemuneraciones;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 1000).Value = objEntidadBE.RetencionAnteriorObservacion;
                        sql_comando.Parameters.Add("@FechaExacta", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaExactaRetencion;
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

        public Planilla_TrabajadorCE F_Planilla_Trabajador_Retenciones_Anteriores_Eliminar(Planilla_TrabajadorCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_Planilla_Trabajador_Retenciones_Anteriores_Eliminar]";
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        sql_comando.Parameters.Add("@Id", SqlDbType.Int).Value = objEntidadBE.RetencionAnteriorCodRetencion;

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
