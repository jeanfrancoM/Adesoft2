using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CapaDatos;
using System.Net.Mail;
using CapaEntidad;

namespace SistemaInventario.WSNotificacionDiferenciaAzure
{
    public class Notificaciones
    {

        //public void Notificar(out List<SistemaInventario.WSNotificacionDiferenciaAzure.NotificacionAzure.MensajeError> msg)
        public void Notificar()
        {
            //msg = new List<SistemaInventario.WSNotificacionDiferenciaAzure.NotificacionAzure.MensajeError>();

            DataTable dtProductos = (new AzureCD()).F_Diferencias_Productos();
            DataTable dtPrecios = (new AzureCD()).F_Diferencias_Precios();



            //ARMADO DE TABLA DE PRODUCTOS 
            string TABLA_PRODUCTOS = "";
            string cabecera = "";
            string cuerpo = "";
            if (dtProductos.Rows.Count > 0)
            {


                //armo cabecera
                //-------------
                string TDS = ""; ;
                foreach (DataColumn col in dtProductos.Columns)
                {

                    TDS = TDS + SistemaInventario.WSNotificacionDiferenciaAzure.Properties.Resources.CABECERA_TABLA_TD.Replace("@TEXTO", col.ColumnName);

                }
                cabecera = SistemaInventario.WSNotificacionDiferenciaAzure.Properties.Resources.CABECERA_TABLA_TR.Replace("@CONTENIDO_CABECERA", TDS);


                //armo detalle
                //-------------
                TDS = "";
                foreach (DataRow row in dtProductos.Rows)
                {
                    string tds = "";
                    foreach (DataColumn col in dtProductos.Columns)
                    {
                        tds = tds + SistemaInventario.WSNotificacionDiferenciaAzure.Properties.Resources.CUERPO_TABLA_TD.Replace("@DATO", row[col.ColumnName].ToString());
                    }
                    TDS = TDS + SistemaInventario.WSNotificacionDiferenciaAzure.Properties.Resources.CUERPO_TABLA_TR.Replace("@CONTENIDO_TR", tds);
                }
                cuerpo = cabecera + TDS;

            }

            TABLA_PRODUCTOS = SistemaInventario.WSNotificacionDiferenciaAzure.Properties.Resources.TABLA.Replace("@CONTENIDO_TABLA", cuerpo);


            //ARMADO DE TABLA DE PRECIOS
            string TABLA_PRECIOS = "";
            cabecera = "";
            cuerpo = "";
            if (dtPrecios.Rows.Count > 0)
            {
                //armo cabecera
                //-------------
                string TDS = ""; ;
                foreach (DataColumn col in dtPrecios.Columns)
                {

                    TDS = TDS + SistemaInventario.WSNotificacionDiferenciaAzure.Properties.Resources.CABECERA_TABLA_TD.Replace("@TEXTO", col.ColumnName);

                }
                cabecera = SistemaInventario.WSNotificacionDiferenciaAzure.Properties.Resources.CABECERA_TABLA_TR.Replace("@CONTENIDO_CABECERA", TDS);

                //armo detalle
                //-------------
                TDS = "";
                foreach (DataRow row in dtPrecios.Rows)
                {
                    string tds = "";
                    foreach (DataColumn col in dtPrecios.Columns)
                    {
                        tds = tds + SistemaInventario.WSNotificacionDiferenciaAzure.Properties.Resources.CUERPO_TABLA_TD.Replace("@DATO", row[col.ColumnName].ToString());
                    }
                    TDS = TDS + SistemaInventario.WSNotificacionDiferenciaAzure.Properties.Resources.CUERPO_TABLA_TR.Replace("@CONTENIDO_TR", tds);
                }
                cuerpo = cabecera + TDS;
            }
            TABLA_PRECIOS = SistemaInventario.WSNotificacionDiferenciaAzure.Properties.Resources.TABLA.Replace("@CONTENIDO_TABLA", cuerpo);


            string divisores = "</p></p></p></p></p></p></p>";
            string diviproductos = "PRODUCTOS DIFERENCIAS DE PRODUCTOS LOCAL VS AZURE";
            if (dtProductos.Rows.Count == 0)
                diviproductos = "";
            string diviprecios = "PRODUCTOS DIFERENCIAS DE PRECIOS LOCAL VS AZURE";
            if (dtPrecios.Rows.Count == 0)
                diviprecios = "";

            string cuerpoTOTAL = SistemaInventario.WSNotificacionDiferenciaAzure.Properties.Resources.PAGINA.Replace("@TABLA", diviproductos + TABLA_PRODUCTOS + divisores + diviprecios + TABLA_PRECIOS);


            //-----------------------------------------------------------------------------------------
            //si hay algo que notificar
            if (dtProductos.Rows.Count > 0 | dtPrecios.Rows.Count > 0)
            {
                DataTable dtListaCorreos = (new AzureCD()).F_ListaCorreos("NOTIFICACIONES AZURE");
                DataTable dtDatosAlmacen = (new AzureCD()).F_DatosAlmacen();


                MailMessage mmsg = new MailMessage();

                //lleno los mails a enviar
                foreach (DataRow correo in dtListaCorreos.Rows) {
                    mmsg.To.Add(correo["correo"].ToString());
                }

                //ASUNTO
                mmsg.Subject = dtDatosAlmacen.Rows[0]["PrefijoNotificacion"].ToString() + " " +
                        dtDatosAlmacen.Rows[0]["NombreCorto"].ToString() + " " +
                        dtDatosAlmacen.Rows[0]["Almacen"].ToString();

                //CUERPO
                mmsg.Body = cuerpoTOTAL;



                mmsg.BodyEncoding = Encoding.UTF8;
                mmsg.IsBodyHtml = true; //ENVIAR MENSAJE HTML : TRUE


                EmisorE emisor = new EmisorE();
                emisor = new EmisorCD().ObtenerEmisor("9999");
                mmsg.From = new MailAddress(emisor.T_Correo);

                /*---CLIENTE CORREO---*/

                SmtpClient cliente = new SmtpClient();
                cliente.UseDefaultCredentials = false;

                // set up the Gmail server
                //cliente.Host = "smtpout.secureserver.net";
                //cliente.Host = Host.ToString();
                cliente.Host = emisor.T_SmtpHost;
                cliente.EnableSsl = true;
                //cliente.Port = 80;
                //cliente.Port =Convert.ToInt32(Port.ToString());
                cliente.Port = emisor.N_Puerto;
                //cliente.Credentials = new System.Net.NetworkCredential("info@bitscom.pe", "1234@ABCD");
                //cliente.Credentials = new System.Net.NetworkCredential(correoEmisor.ToString(), contraseñaEmisor.ToString());
                cliente.Credentials = new System.Net.NetworkCredential(emisor.T_Correo.Trim(), emisor.T_Clave.Trim());

                cliente.DeliveryMethod = SmtpDeliveryMethod.Network;
                /*---ENVIAR CORREO---*/

                try
                {
                    //ENVIAR CORREO y actualizar estado
                    cliente.Send(mmsg);
                }
                catch (SmtpException ex)
                {

                }





            }





        }


    }
}
