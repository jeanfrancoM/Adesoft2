using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaInventario.WSNotificacionDiferenciaAzure;

namespace PruebasUnitarias
{
    class Program
    {
        static void Main(string[] args)
        {

            Notificaciones not = new Notificaciones();
            //List<SistemaInventario.WSNotificacionDiferenciaAzure.NotificacionAzure.MensajeError> msg;
            //Debugger.Launch();
            not.Notificar(); 
            not = null;

        }
    }
}
