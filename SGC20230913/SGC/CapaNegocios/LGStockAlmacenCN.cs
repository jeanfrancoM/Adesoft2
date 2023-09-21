using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;

namespace CapaNegocios
{
    public class LGStockAlmacenCN
    {
        LGStockAlmacenCD obj = new LGStockAlmacenCD();

        public LGStockAlmacenCE Async_F_LGProductos_ActualizarStocks_Lotes_Azure()
       {

           try
           {

               return obj.Async_F_LGProductos_ActualizarStocks_Lotes_Azure();

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

        public DataTable F_LGProductos_Stocks_Externos_Azure(int CodProducto, string AlmacenActual)
        {
            try
            {

                return obj.F_LGProductos_Stocks_Externos_Azure(CodProducto, AlmacenActual);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGStockAlmacen_StockActual_Producto(int CodProducto, int AlmacenActual)
        {
            try
            {

                return obj.F_LGStockAlmacen_StockActual_Producto(CodProducto, AlmacenActual);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGStockAlmacen_StockActual_Producto_CA(string CodAlterno, int AlmacenActual)
        {
            try
            {

                return obj.F_LGStockAlmacen_StockActual_Producto_CA(CodAlterno, AlmacenActual);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
