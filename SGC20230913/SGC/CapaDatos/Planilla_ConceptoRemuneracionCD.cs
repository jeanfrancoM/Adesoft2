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
    public class Planilla_ConceptoRemuneracionCD
    {
        public DataTable F_Planilla_ConceptoRemuneracion_Listar(Planilla_ConceptoRemuneracionCE objEntidadBE)
        {
            DataTable dta_consulta = null;

            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {
                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "pa_Planilla_ConceptoRemuneracion_Listar";

                        if (objEntidadBE.Descripcion != "")
                            sql_comando.Parameters.Add("@Descripcion", SqlDbType.Int).Value = objEntidadBE.Descripcion;

                        dta_consulta = new DataTable();
                        dta_consulta.Load(sql_comando.ExecuteReader());
                        return dta_consulta;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }

        public Planilla_ConceptoRemuneracionCE F_Planilla_ConceptoRemuneracion_Insert(Planilla_ConceptoRemuneracionCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_ConceptoRemuneracion_Insert]";

                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 300).Value = objEntidadBE.Descripcion;
                        sql_comando.Parameters.Add("@Orden", SqlDbType.Int).Value = objEntidadBE.Orden;
                        sql_comando.Parameters.Add("@CodTipo", SqlDbType.Int).Value = objEntidadBE.CodTipo;
                        sql_comando.Parameters.Add("@CodRegimenLaboral", SqlDbType.Int).Value = objEntidadBE.CodRegimenLaboral;
                        
                        sql_comando.Parameters.Add("@CodConceptoRemuneracion_Referencia", SqlDbType.Int).Value = objEntidadBE.CodConceptoRemuneracion_Referencia;
                        sql_comando.Parameters.Add("@CodClasificacion", SqlDbType.Int).Value = objEntidadBE.CodClasificacion;
                        sql_comando.Parameters.Add("@CodNaturaleza", SqlDbType.Int).Value = objEntidadBE.CodNaturaleza;
                        sql_comando.Parameters.Add("@Orden2", SqlDbType.Int).Value = objEntidadBE.Orden2;

                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;


                        SqlParameter MsgError = sql_comando.Parameters.Add("@MsgError", SqlDbType.VarChar, 1000);
                        MsgError.Direction = ParameterDirection.Output;

                        SqlParameter CodConcepto = sql_comando.Parameters.Add("@CodConceptoRemuneracion", SqlDbType.Int);
                        CodConcepto.Direction = ParameterDirection.Output;


                        sql_comando.ExecuteNonQuery();

                        objEntidadBE.MsgError = MsgError.Value.ToString();
                        objEntidadBE.CodConceptoRemuneracion = Convert.ToInt32(CodConcepto.Value.ToString());

                        return objEntidadBE;

                    }

                }



            }
            catch (Exception ex)
            {

                throw ex;

            }



        }

        public Planilla_ConceptoRemuneracionCE F_Planilla_ConceptoRemuneracion_Update(Planilla_ConceptoRemuneracionCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_ConceptoRemuneracion_Update]";

                        sql_comando.Parameters.Add("@CodConceptoRemuneracion", SqlDbType.Int).Value = objEntidadBE.CodConceptoRemuneracion;
                        sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 300).Value = objEntidadBE.Descripcion;
                        sql_comando.Parameters.Add("@Orden", SqlDbType.Int).Value = objEntidadBE.Orden;
                        sql_comando.Parameters.Add("@CodTipo", SqlDbType.Int).Value = objEntidadBE.CodTipo;
                        sql_comando.Parameters.Add("@CodRegimenLaboral", SqlDbType.Int).Value = objEntidadBE.CodRegimenLaboral;

                        sql_comando.Parameters.Add("@CodConceptoRemuneracion_Referencia", SqlDbType.Int).Value = objEntidadBE.CodConceptoRemuneracion_Referencia;
                        sql_comando.Parameters.Add("@CodClasificacion", SqlDbType.Int).Value = objEntidadBE.CodClasificacion;
                        sql_comando.Parameters.Add("@CodNaturaleza", SqlDbType.Int).Value = objEntidadBE.CodNaturaleza;
                        sql_comando.Parameters.Add("@Orden2", SqlDbType.Int).Value = objEntidadBE.Orden2;

                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
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

        public Planilla_ConceptoRemuneracionCE F_Planilla_ConceptoRemuneracion_Eliminar(Planilla_ConceptoRemuneracionCE objEntidadBE)
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
                        sql_comando.CommandText = "[pa_ConceptoRemuneracion_Eliminar]";

                        sql_comando.Parameters.Add("@CodConceptoRemuneracion", SqlDbType.Int).Value = objEntidadBE.CodConceptoRemuneracion;

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
