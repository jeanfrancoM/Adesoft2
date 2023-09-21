using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using CapaNegocios;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Data;


namespace SistemaInventario.Servicios
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]

    public class DeudasConsultaAPI : System.Web.Services.WebService
    {
        //nueva lista de clients para consumir en listas multiples
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<TCAlmacenesExternosCE> F_ListadoAlmacenes_Consulta_Deudas()
        {
            List<TCAlmacenesExternosCE> listado = new List<TCAlmacenesExternosCE>();
            listado = (new TCAlmacenCN()).F_Lista_Almacenes_Deudas_Clientes();

            return listado;
        }
        //Creado por Joel 17-07-21
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<TCAlmacenesExternosCE> F_Lista_Almacenes_Deudas_Clientes_Povis()
        {
            TCAlmacenesExternosCE objEntidad = new TCAlmacenesExternosCE();
            List<TCAlmacenesExternosCE> listado = new List<TCAlmacenesExternosCE>();
            objEntidad.CodEmpresa = Convert.ToInt32(HttpContext.Current.Session["CodEmpresa"]);
            listado = (new TCAlmacenCN()).F_Lista_Almacenes_Deudas_Clientes_Povis(objEntidad);

            return listado;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Deudas F_ConsultarDeudas_PorAlmacen(string NroRuc, string sede, string urlWAPI)
        {
            Deudas objEntidad = new Deudas();
            objEntidad.nroRuc = NroRuc;
            objEntidad.sede = sede;

            string strJSON = JsonConvert.SerializeObject(objEntidad);

            Deudas listado = new Deudas();

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(urlWAPI);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(strJSON);
            }


            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string result;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                listado = JsonConvert.DeserializeObject<Deudas>(result);
            }
            catch (Exception ex)
            {
                listado.nroRuc = NroRuc;
                listado.sede = sede;
                listado.mensaje = "OK";
                listado.mensaje = "Error al conectarse";
            }


            return listado;
        }





    }
}
