using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;
using System.Configuration;

namespace SistemaInventario.WSNotificacionDiferenciaAzure
{
    public partial class NotificacionAzure : ServiceBase
    {
        private Timer timer;
        public NotificacionAzure()
        {
            InitializeComponent();
        }


        #region [Eventos]
        protected override void OnStart(string[] args)
        {
            //6000D MILISEGUNDOS O 1 MINUTO//Se puso 1 min para pruebas luego reasignar para 5
            try
            {
                int Tiempo = 300000; try { int tmp = int.Parse(ConfigurationManager.AppSettings["TIME"]); Tiempo = tmp * 60000; }
                catch (Exception ex) { } //5 Minutos por defecto si no parametrizan el tiempo en el app.config
                this.timer = new System.Timers.Timer() { Interval = Tiempo };
                this.timer.AutoReset = true;
                this.timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_Elapsed);
                this.timer.Start();
            }
            catch (Exception ex) { WriteEventLogEntry(ex.Message.ToString()); }
        }
        public void OnDebug()
        {
            OnStart(null);
        }
        protected override void OnStop()
        {
            this.timer.Stop();
            this.timer = null;
        }
        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //Debugger.Launch();
            this.timer.Stop(); //Detengo el temporizador
            Notificaciones Sync = new Notificaciones();
            List<MensajeError> msg;
            //Debugger.Launch();
            Sync.Notificar(); Sync = null;
           // if (msg != null)
           // {
           //     if (msg.Count > 0)
           //     {
           //         string msgError = "";
           //         foreach (var errs in msg)
           //         {
           //             msgError += "------------------------------" + (char)13; msgError += "SistemaInventario.SincronizacionAzure" + (char)13;
           //             msgError += "Error Nro. " + errs.ErrorNumber + (char)13; msgError += "Error Dsc. " + errs.ErrorMensaje + (char)13;
           //         }
           //         WriteEventLogEntry(msgError);
           //     }
           // }
            timer.Start(); //Reinicio el Temporizador
        }

        static void WriteEventLogEntry(string message)
        {
            // Create an instance of EventLog
            EventLog eventLog = new EventLog();

            // Check if the event source exists. If not create it.
            if (!EventLog.SourceExists("Generador FAC ELE"))
            {
                EventLog.CreateEventSource("Generador FAC ELE", "Application");
            }

            // Set the source name for writing log entries.
            eventLog.Source = "Generador FAC ELE";

            // Create an event ID to add to the event log
            int eventID = 8;

            // Write an entry to the event log.
            eventLog.WriteEntry(message, EventLogEntryType.Warning, eventID);

            // Close the Event Log
            eventLog.Close();

        }
        #endregion


        public class MensajeError
        {
            public int ErrorNumber { get; set; }
            public string ErrorMensaje { get; set; }
        }
    }
}
