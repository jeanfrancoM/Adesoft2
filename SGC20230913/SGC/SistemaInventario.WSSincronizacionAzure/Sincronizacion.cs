using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocios;
using CapaEntidad;

namespace SistemaInventario.WSSincronizacionAzure
{
    public class Sincronizacion
    {
        List<MensajeError> oMSG_ERROR;
        public void Sincronizar(out List<MensajeError> oMensajesError)
        {
            oMSG_ERROR = new List<MensajeError>();

            ////actualiza primero los clientes y las lineas de credito
            //prActualizarClientes_LineaCredito_Azure();

            //Actualizar los productos locales a Azure
            prActualizarProductos_Azure(); 
            System.Threading.Thread.Sleep(15000); //espero 15 segundos

            ////Actualizo Stocks Azure
            prActualizarStocks_Azure(); 


            oMensajesError = oMSG_ERROR;
        }

        private void prActualizarProductos_Azure()
        {
            LGProductosCE objEntidad = new LGProductosCE();
            objEntidad.CodProducto = 0;
            LGProductosCN objOperacion = new LGProductosCN();
            objOperacion.Async_F_LGProductos_ActualizarProductos_Azure(objEntidad);
        }

        private void prActualizarStocks_Azure()
        {
            LGStockAlmacenCN ActualizacionAzure = new LGStockAlmacenCN();
            ActualizacionAzure.Async_F_LGProductos_ActualizarStocks_Lotes_Azure();
        }



        private void prActualizarClientes_LineaCredito_Azure() {
            //Actualiza LineaCredito Azure
            TCCuentaCorrienteCE EntidadClienteAzure = new TCCuentaCorrienteCE();
            EntidadClienteAzure.CodCtaCte = 0;
            TCCuentaCorrienteLineaCreditoCN ActualizacionSaldosClientesAzure = new TCCuentaCorrienteLineaCreditoCN();
            ActualizacionSaldosClientesAzure.Async_F_TCCuentaCorriente_LineaCredito_Actualizar_Saldos(EntidadClienteAzure);
        }
    }
}
