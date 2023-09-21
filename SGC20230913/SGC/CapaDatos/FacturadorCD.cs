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
    public class FacturadorCD
    {
        public DataTable PA_INTERFACE_LISTAR_EMPRESAS()
        {
            DataTable dta_consulta = null;

            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["APIFACTURADORSUNAT"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "PA_INTERFACE_LISTAR_EMPRESAS";

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dta_consulta.Dispose(); }
        }

        public DataTable PA_INTERFACE_LISTA_DOCUMENTOS(FacturadorCE facturador)
        {
            DataTable dta_consulta = null;

            try
            {
                using (SqlConnection sql_conexion = new SqlConnection())
                {
                    sql_conexion.ConnectionString = ConfigurationManager.ConnectionStrings["APIFACTURADORSUNAT"].ConnectionString;
                    sql_conexion.Open();

                    using (SqlCommand sql_comando = new SqlCommand())
                    {

                        sql_comando.Connection = sql_conexion;
                        sql_comando.CommandType = CommandType.StoredProcedure;
                        sql_comando.CommandText = "PA_INTERFACE_LISTA_DOCUMENTOS";

                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = facturador.CodEmpresa;
                        sql_comando.Parameters.Add("@Serie", SqlDbType.VarChar, 4).Value = facturador.Serie;
                        sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = facturador.Desde;
                        sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = facturador.Hasta;
                        sql_comando.Parameters.Add("@CodTipoDocumento", SqlDbType.VarChar, 10).Value = facturador.CodTipoDocumento;
                        sql_comando.Parameters.Add("@CodEstadoProcesoSunat", SqlDbType.Int).Value = facturador.CodEstadoProcesoSunat;

                        dta_consulta = new DataTable();

                        dta_consulta.Load(sql_comando.ExecuteReader());

                        return dta_consulta;

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
