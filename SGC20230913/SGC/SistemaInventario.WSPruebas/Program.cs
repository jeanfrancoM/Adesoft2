using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaInventario.WSSincronizacionAzure;

namespace SistemaInventario.WSPruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            List<MensajeError> msg;
            Sincronizacion x = new Sincronizacion();
            x.Sincronizar(out msg);
        }
    }
}
