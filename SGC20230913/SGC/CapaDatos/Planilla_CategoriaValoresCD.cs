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
    public class Planilla_CategoriaValoresCD
    {
        public DataTable F_Planilla_CategoriaValores_Listar(Planilla_CategoriaValoresCE objEntidadBE)
        {
            DataTable dta_consulta = null;

            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "Pa_Planilla_Concepto_Categoria_Listar";

                        sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidadBE.CodCodCategoria;

                        dta_consulta = new DataTable();
                        dta_consulta.Load(sql_comando.ExecuteReader());
                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }

        public DataTable F_Planilla_Concepto_Categoria_Listar_SinAsignacion(Planilla_CategoriaValoresCE objEntidadBE)
        {
            DataTable dta_consulta = null;

            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "Pa_Planilla_Concepto_Categoria_Listar_SinAsignacion";

                        sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidadBE.CodCodCategoria;

                        dta_consulta = new DataTable();
                        dta_consulta.Load(sql_comando.ExecuteReader());
                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }

        public DataTable F_Planilla_Salario_Reintegros_Pendientes(Planilla_CategoriaValoresCE objEntidadBE)
        {
            DataTable dta_consulta = null;

            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_Planilla_Salario_Reintegros_Pendientes";

                        sql_comando.Parameters.Add("@CodCategoria", SqlDbType.Int).Value = objEntidadBE.CodCodCategoria;
                        sql_comando.Parameters.Add("@flagTodos", SqlDbType.Int).Value = objEntidadBE.flagTodos;

                        dta_consulta = new DataTable();
                        dta_consulta.Load(sql_comando.ExecuteReader());
                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }

        public Planilla_CategoriaValoresCE F_Planilla_CategoriaValores_Insert(Planilla_CategoriaValoresCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_CategoriaValores_Insert]";

                        sql_comando.Parameters.Add("@CodCodCategoriaValores", SqlDbType.Int).Value = objEntidadBE.CodCodCategoriaValores;
                        sql_comando.Parameters.Add("@CodCodCategoria", SqlDbType.Int).Value = objEntidadBE.CodCodCategoria;
                        sql_comando.Parameters.Add("@CodConceptoRemuneracion", SqlDbType.Int).Value = objEntidadBE.CodConceptoRemuneracion;
                        sql_comando.Parameters.Add("@Valor", SqlDbType.Decimal).Value = objEntidadBE.Valor;
                        sql_comando.Parameters.Add("@Valor2", SqlDbType.Decimal).Value = objEntidadBE.Valor2;
                        sql_comando.Parameters.Add("@FechaInicial", SqlDbType.DateTime).Value = objEntidadBE.FechaInicial;
                        sql_comando.Parameters.Add("@FechaFinal", SqlDbType.DateTime).Value = objEntidadBE.FechaFinal;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 500).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@TopeDiferencia", SqlDbType.Decimal).Value = objEntidadBE.TopeDiferencia;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter CodConcepto = sql_comando.Parameters.Add("@CodCodCategoriaValores", SqlDbType.Int);
                        CodConcepto.Direction = ParameterDirection.Output;


                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodCodCategoriaValores = Convert.ToInt32(CodConcepto.Value.ToString());

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public Planilla_CategoriaValoresCE F_Planilla_CategoriaValores_Update(Planilla_CategoriaValoresCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_CategoriaValores_Update]";

                        sql_comando.Parameters.Add("@CodCodCategoriaValores", SqlDbType.Int).Value = objEntidadBE.CodCodCategoriaValores;
                        sql_comando.Parameters.Add("@Valor", SqlDbType.Decimal).Value = objEntidadBE.Valor;
                        sql_comando.Parameters.Add("@Valor2", SqlDbType.Decimal).Value = objEntidadBE.Valor2;
                        sql_comando.Parameters.Add("@FechaInicial", SqlDbType.DateTime).Value = objEntidadBE.FechaInicial;
                        sql_comando.Parameters.Add("@FechaFinal", SqlDbType.DateTime).Value = objEntidadBE.FechaFinal;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 500).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@TopeDiferencia", SqlDbType.Decimal).Value = objEntidadBE.TopeDiferencia;
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

        public Planilla_CategoriaValoresCE F_Planilla_CategoriaValores_Eliminar(Planilla_CategoriaValoresCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_Planilla_CategoriaValores_Eliminar]";

                        sql_comando.Parameters.Add("@CodCodCategoriaValores", SqlDbType.Int).Value = objEntidadBE.CodCodCategoriaValores;

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


        public Planilla_SalarioCE F_CategoriaValores_Recalcular_Reintegro(Planilla_SalarioCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_Planilla_Salario_Excel_Proceso]";

                        sql_comando.Parameters.Add("@IDExcel", SqlDbType.BigInt).Value = objEntidadBE.IDExcel;
                        sql_comando.Parameters.Add("@EsReintegro", SqlDbType.Int).Value = objEntidadBE.EsReintegro;
                        sql_comando.Parameters.Add("@CodUsuarioReintegro", SqlDbType.Int).Value = objEntidadBE.CodUsuario;
                        

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


        
        public Planilla_CategoriaValoresCE F_Planilla_CategoriaValores_Agregar_Concepto(Planilla_CategoriaValoresCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_CategoriaValores_Agregar_Concepto]";

                        sql_comando.Parameters.Add("@CodCodCategoria", SqlDbType.Int).Value = objEntidadBE.CodCodCategoria;
                        sql_comando.Parameters.Add("@CodConceptoRemuneracion", SqlDbType.Int).Value = objEntidadBE.CodConceptoRemuneracion;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter CodConcepto = sql_comando.Parameters.Add("@CodCodCategoriaValores", SqlDbType.Int);
                        CodConcepto.Direction = ParameterDirection.Output;


                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodCodCategoriaValores = Convert.ToInt32(CodConcepto.Value.ToString());

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
