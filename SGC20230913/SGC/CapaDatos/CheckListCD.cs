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
    public class CheckListCD
    {

        public DataTable F_VehiculoComponentesDetalle_Listar(CheckListCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_VehiculoComponentesDetalle_Listar";

                        if (!objEntidadBE.CodTipoVehiculo.Equals(""))

                            sql_comando.Parameters.Add("@CodTipoVehiculo", SqlDbType.Int).Value = objEntidadBE.CodTipoVehiculo;

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

        //F_CheckList_Insert

        public CheckListCE F_CheckList_Insert(CheckListCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_VehiculoCheckListCab_Insert";
                        sql_comando.Parameters.Add("@CodVehiculoCheckListCab", SqlDbType.Int).Value = objEntidadBE.CodVehiculoCheckListCab;
                        sql_comando.Parameters.Add("@CodAlmacen", SqlDbType.Int).Value = objEntidadBE.CodAlmacen;
                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
                        sql_comando.Parameters.Add("@CodVehiculo", SqlDbType.Int).Value = objEntidadBE.CodVehiculo;
                        sql_comando.Parameters.Add("@CodCtaCte", SqlDbType.Int).Value = objEntidadBE.CodCtaCte;
                        sql_comando.Parameters.Add("@CodEmpleadoResponsable", SqlDbType.Int).Value = objEntidadBE.CodEmpleadoResponsable;
                        sql_comando.Parameters.Add("@ResponsableClienteDni", SqlDbType.VarChar, 20).Value = objEntidadBE.ResponsableClienteDni;
                        sql_comando.Parameters.Add("@ResponsableCliente", SqlDbType.VarChar, 100).Value = objEntidadBE.ResponsableCliente;
                        sql_comando.Parameters.Add("@NivelGasolina", SqlDbType.Int).Value = objEntidadBE.NivelGasolina;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 500).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodUsuario", SqlDbType.Int).Value = objEntidadBE.CodUsuario;

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



        public DataTable F_CheckList_Listar(CheckListCE objEntidadBE)
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
                        sql_comando.CommandText = "Pa_CheckList_Listar";

                        if (!objEntidadBE.Descripcion.Equals(""))
                            sql_comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = objEntidadBE.Descripcion;
                        if (objEntidadBE.CodEstado != 0) 
                            sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        if (!objEntidadBE.Placa.Equals(""))
                            sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa;
                        if (objEntidadBE.Desde.ToString("yyyyMMdd") != "19900101")
                        {
                            sql_comando.Parameters.Add("@Desde", SqlDbType.Int).Value = objEntidadBE.Desde.ToString("yyyyMMdd");
                            sql_comando.Parameters.Add("@Hasta", SqlDbType.Int).Value = objEntidadBE.Hasta.ToString("yyyyMMdd");
                        }
                        if (objEntidadBE.SerieDoc != "TODOS")
                            sql_comando.Parameters.Add("@SerieDoc", SqlDbType.VarChar, 4).Value = objEntidadBE.SerieDoc;

                        if (objEntidadBE.NumeroDoc != "")
                            sql_comando.Parameters.Add("@NumeroDoc", SqlDbType.VarChar, 8).Value = objEntidadBE.NumeroDoc;

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

        //


        public DataTable F_CheckList_Reemplazar(CheckListCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_VehiculoCheckListCab_Reemplazar";

                        sql_comando.Parameters.Add("@CodVehiculoCheckListCab", SqlDbType.Int).Value = objEntidadBE.CodVehiculoCheckListCab;
                        if (objEntidadBE.CodUsuario != 0)
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



        public DataTable F_CheckListDet_Listar(CheckListCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_CheckListDet_Listar";

                        sql_comando.Parameters.Add("@CodVehiculoCheckListCab", SqlDbType.Int).Value = objEntidadBE.CodVehiculoCheckListCab;
                        if (objEntidadBE.CodUsuario != 0)
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



        public DataTable F_VehiculoCheckListCabDetalleEdicion_Listar(CheckListCE objEntidadBE)
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
                        sql_comando.CommandText = "Pa_VehiculoCheckListCabDetalleEdicion_Listar";

                        sql_comando.Parameters.Add("@CodVehiculoCheckListCab", SqlDbType.Int).Value = objEntidadBE.CodVehiculoCheckListCab;

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


        public CheckListCE F_VehiculoCheckListCab_Validar_CheckListC(CheckListCE objEntidadBE)
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
                        sql_comando.CommandText = "Pa_VehiculoCheckListCab_Validar_CheckList";

                        sql_comando.Parameters.Add("@CodVehiculoCheckListCab", SqlDbType.Int).Value = objEntidadBE.CodVehiculoCheckListCab;

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


        public CheckListCE F_VehiculoCheckListAnular_Eliminar(CheckListCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_VehiculoCheckListAnular_Eliminar";

                        sql_comando.Parameters.Add("@CodVehiculoCheckListCab", SqlDbType.Int).Value = objEntidadBE.CodVehiculoCheckListCab;
                        sql_comando.Parameters.Add("@CodUsuarioAnulacion", SqlDbType.Int).Value = objEntidadBE.CodUsuarioAnulacion;

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

        public DataTable F_VEHICULOCHECKLIST_OBSERVACION(CheckListCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_VEHICULOCHECKLIST_OBSERVACION";

                        sql_comando.Parameters.Add("@CodVehiculoCheckListCab", SqlDbType.Int).Value = objEntidadBE.CodVehiculoCheckListCab;

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

        public DataTable F_VEHICULOCHECKLIST_AUDITORIA(CheckListCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_VEHICULOCHECKLIST_AUDITORIA";

                        sql_comando.Parameters.Add("@CodVehiculoCheckListCab", SqlDbType.Int).Value = objEntidadBE.CodVehiculoCheckListCab;

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


        public DataTable F_CHECKLIST_VistaPreliminar(CheckListCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_VistaPriliminarCheckList";

                        sql_comando.Parameters.Add("@CodVehiculoCheckListCab", SqlDbType.Int).Value = objEntidadBE.CodVehiculoCheckListCab;
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

        


        public DataTable F_Listar_Modelo(VehiculoCE objEntidadBE)
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

                        if (!objEntidadBE.CodMarca.Equals(""))
                            sql_comando.Parameters.Add("@CodMarca", SqlDbType.Int).Value = objEntidadBE.CodMarca;

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

       

        public VehiculoCE F_Vehiculo_Eliminar(VehiculoCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_Vehiculo_Eliminar";

                        sql_comando.Parameters.Add("@CodVehiculo", SqlDbType.Int).Value = objEntidadBE.CodVehiculo;

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
        //

        public VehiculoCE F_Vehiculo_Update(VehiculoCE objEntidadBE)
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
                        sql_comando.CommandText = "pa_VEHICULO_Update";

                        sql_comando.Parameters.Add("@Placa", SqlDbType.VarChar, 20).Value = objEntidadBE.Placa;
                        sql_comando.Parameters.Add("@Chasis", SqlDbType.VarChar, 100).Value = objEntidadBE.Chasis;
                        sql_comando.Parameters.Add("@CodCliente", SqlDbType.Int).Value = objEntidadBE.CodCliente;
                        sql_comando.Parameters.Add("@CodVehiculo", SqlDbType.Int).Value = objEntidadBE.CodVehiculo;
                        sql_comando.Parameters.Add("@CodMarca", SqlDbType.Int).Value = objEntidadBE.CodMarca;
                        sql_comando.Parameters.Add("@Anio", SqlDbType.Int).Value = objEntidadBE.Anio;
                        sql_comando.Parameters.Add("@CodColor", SqlDbType.Int).Value = objEntidadBE.CodColor;
                        sql_comando.Parameters.Add("@NroMotor", SqlDbType.VarChar, 100).Value = objEntidadBE.NroMotor;

                        sql_comando.Parameters.Add("@CodModeloVehiculo", SqlDbType.Int).Value = objEntidadBE.CodModeloVehiculo;
                        sql_comando.Parameters.Add("@CodTipoVehiculo", SqlDbType.Int).Value = objEntidadBE.CodTipoVehiculo;

                        sql_comando.Parameters.Add("@FechaVctoSoat", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaVctoSoat;
                        sql_comando.Parameters.Add("@FechaRevisionTecnica", SqlDbType.SmallDateTime).Value = objEntidadBE.FechaRevisionTecnica;
                        sql_comando.Parameters.Add("@NroFlota", SqlDbType.Int).Value = objEntidadBE.NroFlota;
                        sql_comando.Parameters.Add("@Observacion", SqlDbType.VarChar, 500).Value = objEntidadBE.Observacion;
                        sql_comando.Parameters.Add("@CodEstado", SqlDbType.Int).Value = objEntidadBE.CodEstado;
                        sql_comando.Parameters.Add("@CodUsuarioModificacion", SqlDbType.Int).Value = objEntidadBE.CodUsuarioModificacion;

                        sql_comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 250).Value = objEntidadBE.RazonSocial;
                        sql_comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 250).Value = objEntidadBE.Direccion;
                        sql_comando.Parameters.Add("@NroRuc", SqlDbType.VarChar, 11).Value = objEntidadBE.NroRuc;
                        sql_comando.Parameters.Add("@NroDni", SqlDbType.VarChar, 9).Value = objEntidadBE.NroDni;
                        sql_comando.Parameters.Add("@CodTipoCliente", SqlDbType.Int).Value = objEntidadBE.CodTipoCliente;
                        sql_comando.Parameters.Add("@CodProvincia", SqlDbType.Int).Value = objEntidadBE.CodProvincia;
                        sql_comando.Parameters.Add("@CodDepartamento", SqlDbType.Int).Value = objEntidadBE.CodDepartamento;
                        sql_comando.Parameters.Add("@CodDistrito", SqlDbType.Int).Value = objEntidadBE.CodDistrito;
                        sql_comando.Parameters.Add("@CodDireccion", SqlDbType.Int).Value = objEntidadBE.CodDireccion;
                        sql_comando.Parameters.Add("@CodEmpresa", SqlDbType.Int).Value = objEntidadBE.CodEmpresa;
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

        public DataTable F_VEHICULO_OBSERVACION(VehiculoCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_VEHICULO_OBSERVACION";

                        sql_comando.Parameters.Add("@CodVehiculo", SqlDbType.Int).Value = objEntidadBE.CodVehiculo;

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

        public DataTable F_VEHICULO_AUDITORIA(VehiculoCE objEntidadBE)
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
                        sql_comando.CommandText = "PA_VEHICULO_AUDITORIA";

                        sql_comando.Parameters.Add("@CodVehiculo", SqlDbType.Int).Value = objEntidadBE.CodVehiculo;

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



        public DataTable F_Vehiculo_Placas_AutoComplete(VehiculoCE objEntidadBE)
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
                        sql_comando.CommandText = "Pa_Vehiculo_Placas_AutoComplete";

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







      

    }
}
