using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;

namespace CapaNegocios
{
    public class TCCuentaCorrienteCN
    {
        TCCuentaCorrienteCD obj = new TCCuentaCorrienteCD();

        public TCCuentaCorrienteCE F_TCCuentaCorriente_Insert(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_TCCuentaCorriente_Insert(objEntidadBE);
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
                return obj.F_TCCuentaCorriente_Insert_Alvarado(objEntidadBE);
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
                return obj.F_TCCuentaCorriente_Insert_Pymes(objEntidadBE);
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

                return obj.F_TCCuentaCorriente_Update(objEntidadBE);

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

                return obj.F_TCCuentaCorriente_Update_Alvarado(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TCCuentaCorriente_ListarClientes(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_TCCuentaCorriente_ListarClientes(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TCCuentaCorriente_Ruc_ListarClientes(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_TCCuentaCorriente_Ruc_ListarClientes(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        
        public DataTable F_ValidarClienteCambioPrecio(string NroRuc)
        {

            try
            {

                return obj.F_ValidarClienteCambioPrecio(NroRuc);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TCCuentaCorriente_PadronSunat(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_TCCuentaCorriente_PadronSunat(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TCDistritoBuscarXUbigeo(string CodigoUbigeo)
        {

            try
            {

                return obj.F_TCDistritoBuscarXUbigeo(CodigoUbigeo);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_BuscarDatosPorRucDni(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_BuscarDatosPorRucDni(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TCCuentaCorrienteCE F_TCCuentaCorriente_Eliminar(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_TCCuentaCorriente_Eliminar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TCCuentaCorriente_Listar(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_TCCuentaCorriente_Listar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TCCuentaCorrienteCE F_LGFamilias_Insert(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_LGFamilias_Insert(objEntidadBE);

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

                return obj.F_LGFamilias_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGFamilias_Listado(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_LGFamilias_Listado(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGFamilias_Listar()
        {

            try
            {

                return obj.F_LGFamilias_Listar();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TCCuentaCorrienteCE F_LGFamilias_Delete(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_LGFamilias_Delete(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        
        public TCCuentaCorrienteCE F_ClientesSaldos_AZURE(string NroRuc)
        {

            try
            {

                DataTable dtSaldos = obj.F_ClientesSaldos_AZURE(NroRuc);
                TCCuentaCorrienteCE tcSaldos = new TCCuentaCorrienteCE(); ;
                foreach (DataRow r in dtSaldos.Rows)
                {
                    tcSaldos = (new TCCuentaCorrienteCE()
                    {
                        Saldo = Convert.ToDecimal(r["Saldo"].ToString())
                    });
                }

                return tcSaldos;
            }
            catch (Exception ex)
            {

                return null;
            }

        }

        public TCCuentaCorrienteCE F_Linea_Insertar(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Linea_Insertar(objEntidadBE);
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
                return obj.F_Linea_Actualizar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Linea_Listado(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Linea_Listado(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Linea_Listar()
        {
            try
            {
                return obj.F_Linea_Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Linea_Eliminar(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Linea_Eliminar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_LINEA_AUTOCOMPLETE(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_LINEA_AUTOCOMPLETE(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public TCCuentaCorrienteCE F_Modelo_Insertar(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Modelo_Insertar(objEntidadBE);
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
                return obj.F_Modelo_Actualizar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Modelo_Listado(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Modelo_Listado(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Modelo_Listar()
        {
            try
            {
                return obj.F_Modelo_Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Modelo_Eliminar(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Modelo_Eliminar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataTable F_MODELOVEHICULO_AUTOCOMPLETE(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_MODELOVEHICULO_AUTOCOMPLETE(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_MARCAPRODUCTO_AUTOCOMPLETE(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_MARCAPRODUCTO_AUTOCOMPLETE(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_TCContactos_Listar(ContactosCE objEntidadBE)
        {

            try
            {

                return obj.F_TCContactos_Listar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ContactosCE F_Contactos_Insert(ContactosCE objEntidadBE)
        {

            try
            {

                return obj.F_Contactos_Insert(objEntidadBE);

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

                return obj.F_Contactos_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TCCuentaCorriente_SaldosLineaCredito_Cliente(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_TCCuentaCorriente_SaldosLineaCredito_Cliente(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //joel 20/02/21
        public TCCuentaCorrienteCE F_TCAlmacen_Insert(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_TCAlmacen_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //joel 20/02/21
        public DataTable F_TCAlmacen_Listado(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_TCAlmacen_Listado(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //joel 20/02/21
        public TCCuentaCorrienteCE F_TCAlmacen_Update(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_TCAlmacen_Update(objEntidadBE);

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

                return obj.F_TCAlmacen_Delete(objEntidadBE);

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

                return obj.F_Usuario_Update(objEntidadBE);

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

                return obj.F_ActualizarDescuento(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Procedencia_Insertar_Salcedo(TCCuentaCorrienteCE objEntidad)
        {
            try
            {
                return obj.F_Procedencia_Insertar_Salcedo(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Procedencia_Listado_Salcedo(TCCuentaCorrienteCE objEntidad)
        {
            try
            {
                return obj.F_Procedencia_Listado_Salcedo(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Procedencia_Actualizar_Salcedo(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Procedencia_Actualizar_Salcedo(objEntidadBE);
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
                return obj.F_Procedencia_Eliminar_Salcedo(objEntidadBE);
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
                return obj.F_Linea_Insertar_Salcedo(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Linea_Listado_Salcedo(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Linea_Listado_Salcedo(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Linea_Eliminar_Salcedo(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Linea_Eliminar_Salcedo(objEntidadBE);
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
                return obj.F_Linea_Actualizar_Salcedo(objEntidadBE);
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
                return obj.F_Marca_Insertar_Salcedo(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Marca_Listado_Salcedo(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Marca_Listado_Salcedo(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TCCuentaCorrienteCE F_Marca_Eliminar_Salcedo(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Marca_Eliminar_Salcedo(objEntidadBE);
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
                return obj.F_Marca_Actualizar_Salcedo(objEntidadBE);
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

                return obj.F_LGFamilias_Insert_Salcedo(objEntidadBE);

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

                return obj.F_LGFamilias_Update_Salcedo(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGFamilias_Listado_Salcedo(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_LGFamilias_Listado_Salcedo(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGFamilias_Listar_Salcedo()
        {

            try
            {

                return obj.F_LGFamilias_Listar_Salcedo();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TCCuentaCorrienteCE F_LGFamilias_Delete_Salcedo(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_LGFamilias_Delete_Salcedo(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_Familia_AUTOCOMPLETE(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Familia_AUTOCOMPLETE(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Procedencia_AUTOCOMPLETE(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_Procedencia_AUTOCOMPLETE(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Procedencia_Listar()
        {
            try
            {
                return obj.F_Procedencia_Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_listar_EmpleadosxCargo(TCCuentaCorrienteCE objEntidadBE)
        {

            try
            {

                return obj.F_listar_EmpleadosxCargo(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TCCuentaCorriente_BuscarMotivo(TCCuentaCorrienteCE objEntidadBE)
        {
            try
            {
                return obj.F_TCCuentaCorriente_BuscarMotivo(objEntidadBE);
            }
            catch (Exception ex)
            {

                throw ex;

            }

        }

        public object F_CORREO_DIRECCION(TCCuentaCorrienteCE objEntidad)
        {
            try
            {

                return obj.F_CORREO_DIRECCION(objEntidad);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ContactosCE F_Contactos_Eliminar(ContactosCE objEntidadBE)
        {

            try
            {

                return obj.F_Contactos_Eliminar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
