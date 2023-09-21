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
    public class Planilla_SalarioCD
    {
        public DataTable F_Planilla_Salario_Listar(Planilla_SalarioCE objEntidadBE)
        {
            DataTable dta_consulta = null;

            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_Planilla_Salario_Listar";

                        //if (objEntidadBE.Descripcion != "")
                        //    sql_comando.Parameters.Add("@Descripcion", SqlDbType.Int).Value = objEntidadBE.Descripcion;

                        dta_consulta = new DataTable();
                        dta_consulta.Load(sql_comando.ExecuteReader());
                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }

        public DataTable F_Planilla_Salario_Obtener(Planilla_SalarioCE objEntidadBE)
        {
            DataTable dta_consulta = null;

            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_Planilla_Salario_Obtener";

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

        public DataTable F_Planilla_Salario_Obtener_Por_Semana(Planilla_SalarioCE objEntidadBE)
        {
            DataTable dta_consulta = null;

            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_Planilla_Salario_Obtener_Por_Semana";

                        sql_comando.Parameters.Add("@AñoSemana", SqlDbType.VarChar, 6).Value = objEntidadBE.AñoSemana;
                        sql_comando.Parameters.Add("@CodProyecto", SqlDbType.Int).Value = objEntidadBE.CodProyecto;

                        dta_consulta = new DataTable();
                        dta_consulta.Load(sql_comando.ExecuteReader());
                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }

        public Planilla_SalarioCE F_Planilla_Salario_Insert(Planilla_SalarioCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_Salario_Insert]";

                        //sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 300).Value = objEntidadBE.Descripcion;
                        //sql_comando.Parameters.Add("@Descripcion2", SqlDbType.VarChar, 300).Value = objEntidadBE.Descripcion2;
                        //sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter CodSalario = sql_comando.Parameters.Add("@CodSalario", SqlDbType.Int);
                        CodSalario.Direction = ParameterDirection.Output;


                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodSalario = Convert.ToInt32(CodSalario);

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public Planilla_SalarioCE F_Planilla_Salario_Update(Planilla_SalarioCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_Salario_Update]";

                        sql_comando.Parameters.Add("@CodSalario", SqlDbType.Int).Value = objEntidadBE.CodSalario;
                        //sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 300).Value = objEntidadBE.Descripcion;
                        //sql_comando.Parameters.Add("@Descripcion2", SqlDbType.VarChar, 300).Value = objEntidadBE.Descripcion2;
                        //sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
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





        public DataTable F_Planilla_Salario_Excel_Validaciones_Previas(long IdExcel, int CodProyecto, int CodRegimenLaboral)
        {
            DataTable dta_consulta = null;

            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_Planilla_Salario_Excel_Validaciones_Previas";

                        sql_comando.Parameters.Add("@IDExcel", SqlDbType.BigInt).Value = IdExcel;
                        sql_comando.Parameters.Add("@CodProyecto", SqlDbType.BigInt).Value = CodProyecto;
                        sql_comando.Parameters.Add("@CodRegimenLaboral", SqlDbType.BigInt).Value = CodRegimenLaboral;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }



        public DataTable F_Planilla_Salario_Excel_Empleados_Validaciones_Previas(long IdExcel, int CodProyecto, int CodRegimenLaboral)
        {
            DataTable dta_consulta = null;

            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_Planilla_Salario_Excel_Empleados_Validaciones_Previas";

                        sql_comando.Parameters.Add("@IDExcel", SqlDbType.BigInt).Value = IdExcel;
                        sql_comando.Parameters.Add("@CodProyecto", SqlDbType.BigInt).Value = CodProyecto;
                        sql_comando.Parameters.Add("@CodRegimenLaboral", SqlDbType.BigInt).Value = CodRegimenLaboral;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }




        public Planilla_SalarioCE F_Planilla_Salario_Excel_Proceso(Planilla_SalarioCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Planilla_Salario_Excel_Proceso";

                        sql_comando.Parameters.Add("@IDExcel", SqlDbType.BigInt).Value = objEntidadBE.IDExcel;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        //SqlParameter CodMovimiento = sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int);
                        //CodMovimiento.Direction = ParameterDirection.Output;

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


        public Planilla_SalarioCE F_Planilla_Salario_Excel_Proceso_Mensual(Planilla_SalarioCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Planilla_Salario_Excel_Proceso_Mensual";

                        sql_comando.Parameters.Add("@IDExcel", SqlDbType.BigInt).Value = objEntidadBE.IDExcel;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        //SqlParameter CodMovimiento = sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int);
                        //CodMovimiento.Direction = ParameterDirection.Output;

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

        public Planilla_SalarioCE F_Eliminar_Carga_Excel_PlanillaRG(Planilla_SalarioCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Eliminar_Carga_Excel_PlanillaRG";

                        sql_comando.Parameters.Add("@CodPeriodo", SqlDbType.Int).Value = objEntidadBE.CodPeriodo;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        //SqlParameter CodMovimiento = sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int);
                        //CodMovimiento.Direction = ParameterDirection.Output;

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

        public Planilla_SalarioCE F_Eliminar_Carga_Excel_PlanillaRCC(Planilla_SalarioCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Eliminar_Carga_Excel_PlanillaRCC";

                        sql_comando.Parameters.Add("@CodSemana", SqlDbType.Int).Value = objEntidadBE.CodSemana;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        //SqlParameter CodMovimiento = sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int);
                        //CodMovimiento.Direction = ParameterDirection.Output;

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

        public Planilla_SalarioCE F_Confirmar_Pago_PlanillaRG(Planilla_SalarioCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Confirmar_Pago_PlanillaRG";

                        sql_comando.Parameters.Add("@CodPeriodo", SqlDbType.Int).Value = objEntidadBE.CodPeriodo;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        //SqlParameter CodMovimiento = sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int);
                        //CodMovimiento.Direction = ParameterDirection.Output;

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

        public Planilla_SalarioCE F_Confirmar_Pago_PlanillaRCC(Planilla_SalarioCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Confirmar_Pago_PlanillaRCC";

                        sql_comando.Parameters.Add("@CodSemana", SqlDbType.Int).Value = objEntidadBE.CodSemana;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        //SqlParameter CodMovimiento = sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int);
                        //CodMovimiento.Direction = ParameterDirection.Output;

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

        public Planilla_SalarioCE F_Planilla_Salario_Excel_Comparacion(Planilla_SalarioCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Planilla_Salario_Excel_Comparacion";

                        sql_comando.Parameters.Add("@IDExcelComparacion", SqlDbType.BigInt).Value = objEntidadBE.IDExcel;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        //SqlParameter CodMovimiento = sql_comando.Parameters.Add("@CodMovimiento", SqlDbType.Int);
                        //CodMovimiento.Direction = ParameterDirection.Output;

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


        public DataTable F_Planilla_Salario_Excel_Comparacion_ConsultaExcel(Planilla_SalarioCE objEntidadBE)
        {
            DataTable dta_consulta = null;

            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_Planilla_Salario_Excel_Comparacion_ConsultaExcel";

                        sql_comando.Parameters.Add("@IDExcelComparacion", SqlDbType.BigInt).Value = objEntidadBE.IDExcel;

                        dta_consulta = new DataTable();
                        dta_consulta.Load(sql_comando.ExecuteReader());
                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }




        public DataTable F_Planilla_Salario_Consulta_Construccion_Civil(Planilla_SalarioCE objEntidad)
        {
            DataTable dta_consulta = null;

            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_Planilla_Salario_Consulta_Construccion_Civil";

                        sql_comando.Parameters.Add("@CodRegimenLaboral", SqlDbType.Int).Value = objEntidad.CodRegimenLaboral;
                        sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidad.CodCategoria;
                        sql_comando.Parameters.Add("@CodProyecto", SqlDbType.Int).Value = objEntidad.CodProyecto;
                        sql_comando.Parameters.Add("@CodSemana", SqlDbType.Int).Value = objEntidad.CodSemana;

                        if (Convert.ToInt32(objEntidad.Desde.ToString("yyyyMMdd")) != 19900101)
                        {
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = Convert.ToInt32(objEntidad.Desde.ToString("yyyyMMdd"));
                            sql_comando.Parameters.Add("@hasta", SqlDbType.Int).Value = Convert.ToInt32(objEntidad.Hasta.ToString("yyyyMMdd"));
                        }


                        sql_comando.Parameters.Add("@CodTrabajador", SqlDbType.Int).Value = objEntidad.CodTrabajador;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }



        public DataTable F_Planilla_Salario_Consulta_General(Planilla_SalarioCE objEntidad)
        {
            DataTable dta_consulta = null;

            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_Planilla_Salario_Consulta_General";

                        sql_comando.Parameters.Add("@CodRegimenLaboral", SqlDbType.Int).Value = objEntidad.CodRegimenLaboral;
                        sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidad.CodCategoria;
                        sql_comando.Parameters.Add("@CodPeriodo", SqlDbType.Int).Value = objEntidad.CodPeriodo;

                        if (Convert.ToInt32(objEntidad.Desde.ToString("yyyyMMdd")) != 19900101)
                        {
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = Convert.ToInt32(objEntidad.Desde.ToString("yyyyMMdd"));
                            sql_comando.Parameters.Add("@hasta", SqlDbType.Int).Value = Convert.ToInt32(objEntidad.Hasta.ToString("yyyyMMdd"));
                        }


                        sql_comando.Parameters.Add("@CodTrabajador", SqlDbType.Int).Value = objEntidad.CodTrabajador;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }

        
        public DataTable F_Planilla_Salario_Consulta_Construccion_Civil_Detalle(Planilla_SalarioCE objEntidad)
        {
            DataTable dta_consulta = null;

            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_Planilla_Salario_Consulta_Construccion_Civil_Detalle";

                        //sql_comando.Parameters.Add("@CodRegimenLaboral", SqlDbType.Int).Value = objEntidad.CodRegimenLaboral;
                        //sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidad.CodCategoria;
                        //sql_comando.Parameters.Add("@CodProyecto", SqlDbType.Int).Value = objEntidad.CodProyecto;
                        //sql_comando.Parameters.Add("@CodSemana", SqlDbType.Int).Value = objEntidad.CodSemana;

                        sql_comando.Parameters.Add("@IDExcel", SqlDbType.BigInt).Value = objEntidad.IDExcel;
                        sql_comando.Parameters.Add("@CodTrabajador", SqlDbType.Int).Value = objEntidad.CodTrabajador;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }


        public DataTable F_Planilla_Salario_Consulta_Construccion_General_Detalle(Planilla_SalarioCE objEntidad)
        {
            DataTable dta_consulta = null;

            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_Planilla_Salario_Consulta_Construccion_General_Detalle";

                        //sql_comando.Parameters.Add("@CodRegimenLaboral", SqlDbType.Int).Value = objEntidad.CodRegimenLaboral;
                        //sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidad.CodCategoria;
                        //sql_comando.Parameters.Add("@CodProyecto", SqlDbType.Int).Value = objEntidad.CodProyecto;
                        //sql_comando.Parameters.Add("@CodSemana", SqlDbType.Int).Value = objEntidad.CodSemana;

                        sql_comando.Parameters.Add("@IDExcel", SqlDbType.BigInt).Value = objEntidad.IDExcel;
                        sql_comando.Parameters.Add("@CodTrabajador", SqlDbType.Int).Value = objEntidad.CodTrabajador;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }


        public DataTable F_Planilla_Salario_Construccion_Civil_Boleta(Planilla_SalarioCE objEntidad)
        {
            DataTable dta_consulta = null;

            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_Planilla_Salario_Construccion_Civil_Boleta";

                        //sql_comando.Parameters.Add("@CodRegimenLaboral", SqlDbType.Int).Value = objEntidad.CodRegimenLaboral;
                        //sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidad.CodCategoria;
                        //sql_comando.Parameters.Add("@CodProyecto", SqlDbType.Int).Value = objEntidad.CodProyecto;
                        //sql_comando.Parameters.Add("@CodSemana", SqlDbType.Int).Value = objEntidad.CodSemana;

                        sql_comando.Parameters.Add("@IDExcel", SqlDbType.BigInt).Value = objEntidad.IDExcel;
                        sql_comando.Parameters.Add("@CodTrabajador", SqlDbType.Int).Value = objEntidad.CodTrabajador;
                        sql_comando.Parameters.Add("@EsReintegro", SqlDbType.Int).Value = objEntidad.EsReintegro;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }

        public DataTable F_Planilla_Salario_Construccion_General_Boleta(Planilla_SalarioCE objEntidad)
        {
            DataTable dta_consulta = null;

            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_Planilla_Salario_Construccion_General_Boleta";

                        //sql_comando.Parameters.Add("@CodRegimenLaboral", SqlDbType.Int).Value = objEntidad.CodRegimenLaboral;
                        //sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidad.CodCategoria;
                        //sql_comando.Parameters.Add("@CodProyecto", SqlDbType.Int).Value = objEntidad.CodProyecto;
                        //sql_comando.Parameters.Add("@CodSemana", SqlDbType.Int).Value = objEntidad.CodSemana;

                        sql_comando.Parameters.Add("@IDExcel", SqlDbType.BigInt).Value = objEntidad.IDExcel;
                        sql_comando.Parameters.Add("@CodTrabajador", SqlDbType.Int).Value = objEntidad.CodTrabajador;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;
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
