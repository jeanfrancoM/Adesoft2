using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;


namespace CapaNegocios
{
    public class LGProductosActualizacionPreciosCN
    {
        LGProductosActualizacionPreciosCD obj = new LGProductosActualizacionPreciosCD();

        public DataTable F_LGProductosActualizacionPrecios_Listar(LGProductosActualizacionPreciosCE objEntidadBE)
        {

            try
            {

                return obj.F_LGProductosActualizacionPrecios_Listar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGProductosActualizacionPreciosDet_Listar(int CodActualizacionPrecios)
        {

            try
            {

                return obj.F_LGProductosActualizacionPreciosDet_Listar(CodActualizacionPrecios);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public LGProductosCE F_LGProductos_Actualizacion_Precios_Almacenes(LGProductosActualizacionPreciosCE objEntidadBE)
        {
            try
            {
                LGProductosCE Return = obj.F_LGProductos_Actualizacion_Precios_Almacenes(objEntidadBE);
                return Return;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGProductos_Actualizacion_ObtenerCambios(LGProductosActualizacionPreciosCE objEntidadBE)
        {

            try
            {

                return obj.F_LGProductos_Actualizacion_ObtenerCambios(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGProductos_Actualizacion_ObtenerAlmacenes(LGProductosActualizacionPreciosCE objEntidadBE)
        {

            try
            {

                return obj.F_LGProductos_Actualizacion_ObtenerAlmacenes(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public LGProductosCE F_LGProductos_Actualizar_Async(ref DataTable dta_tableActualizaciones, ref DataTable dta_tableAlmacenesExternos, int CodActualizacionPrecios, int CodUsuario)
        {
            try
            {
                LGProductosCE Return = obj.F_LGProductos_Actualizar_Async(ref dta_tableActualizaciones, ref dta_tableAlmacenesExternos, CodActualizacionPrecios, CodUsuario);
                //if (Return.MsgError == "Se Grabo Correctamente.") obj.Async_F_LGProductos_Update(objEntidadBE);
                return Return;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public LGProductosCE F_LGProductos_Actualizacion_Reintentar(LGProductosActualizacionPreciosCE objEntidadBE)
        {
            try
            {
                LGProductosCE Return = obj.F_LGProductos_Actualizacion_Reintentar(objEntidadBE);
                //if (Return.MsgError == "Se Grabo Correctamente.") obj.Async_F_LGProductos_Update(objEntidadBE);
                return Return;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}
