using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDatos
{
    public class EmisorCD
    {
        public EmisorE ObtenerEmisor(string CodigoArea)
        {
            EmisorE emisor = null;
            using (SqlConnection con = new SqlConnection())
            {

                con.ConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                con.Open();
                SqlCommand cmd = new SqlCommand("tms_EmisorCorreoS_ObtenerEmisorea", con);
                cmd.CommandType = CommandType.StoredProcedure;
                var oParam = new IDataParameter[1];
                oParam[0] = new SqlParameter("@T_Codigo_Area", (object)CodigoArea ?? DBNull.Value) { Direction = ParameterDirection.Input };
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(oParam);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    if (dr.Read())
                    {
                        emisor = new EmisorE();
                        emisor.ID_Emisor = dr["ID_Emisor"].getNullOrValue<int, object>();
                        emisor.ID_Area_Empresa = dr["ID_Area_Empresa"].getNullOrValue<int, object>();
                        emisor.T_Correo = dr["T_Correo"].getNullOrValue<string, object>();
                        emisor.T_SmtpHost = dr["T_SmtpHost"].getNullOrValue<string, object>();
                        emisor.N_Puerto = dr["N_Puerto"].getNullOrValue<int, object>();
                        emisor.T_Clave = dr["T_Clave"].getNullOrValue<string, object>();
                        emisor.T_Descripcion_Area = dr["T_Descripcion_Area"].getNullOrValue<string, object>();
                    }
                    dr.Close();
                }
            }

            return emisor;
        }
    }
}
