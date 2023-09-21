using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using CapaNegocios;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Data;
using System.Drawing;

namespace SistemaInventario.Servicios
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

     [System.Web.Script.Services.ScriptService]
    public class APP_Procesos : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool F_APP_ActualizarProducto(int CodProducto, string CodigoApp)
        {
            bool hecho = false;

            LGProductosCE objEntidad = new LGProductosCE();
            objEntidad.CodProducto = CodProducto;
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);
            objEntidad.CodigoApp = CodigoApp;

            objEntidad = (new LGProductosCN()).F_LGProductos_Update_App(objEntidad);

            return hecho;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<imgRetorno> F_APP_LGProductos_ListaImagenes(int CodProducto)
        {
            List<imgRetorno> hecho = new List<imgRetorno>();

            LGProductosCE objEntidad = new LGProductosCE();
            objEntidad.CodProducto = CodProducto;

            DataTable dtTable = (new LGProductosCN()).F_LGProductos_Listar_Imagenes(objEntidad);

            foreach (DataRow r in dtTable.Rows) {
                imgRetorno rt = new imgRetorno();
                rt.imageB64 =Convert.ToBase64String((byte[])r["B_Imagen"]); 
                rt.IdImagen = Convert.ToInt32(r["IdImagen"]);
                rt.name = "";
                hecho.Add(rt);
            }

            return hecho;
        }
        public class imgRetorno {
            public string imageB64 { get; set; }
            public int IdImagen { get; set; }
            public string name { get; set; }
        }









        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool F_APP_Grabar_Factura(string data, string idFirebase, int CodMoneda, int CodTasa, int FlagIgv, int CodFormaPago)
        {
            bool hecho = false;

            PedidoModel dataObj = JsonConvert.DeserializeObject<PedidoModel>(data);

            ProformaCabCE objEntidad = new ProformaCabCE();
            objEntidad.CodEmpresa = Convert.ToInt32(Session["CodEmpresa"]);
            objEntidad.CodAlmacen = Convert.ToInt32(Session["CodAlmacen"]);
            if (objEntidad.CodAlmacen == 0)
               objEntidad.CodAlmacen = Convert.ToInt32(Session["CodSede"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);
            objEntidad.Serie = "9999";
            objEntidad.Numero = dataObj.NroDocumento;
            objEntidad.FechaEmision = DateTime.Now;
            objEntidad.CodMoneda = CodMoneda;
            objEntidad.SubTotal = 0;
            objEntidad.Igv = 0;
            objEntidad.Total = dataObj.Total;
            objEntidad.CodDetalle = 0;
            objEntidad.CodTipoDoc = 0;
            objEntidad.CodTasa = CodTasa;
            objEntidad.FlagIgv = FlagIgv;
            objEntidad.CodFormaPago = CodFormaPago;
            objEntidad.Correo = dataObj.Correo;
            objEntidad.Celular = dataObj.Celular;
            objEntidad.NroRuc = dataObj.NroRuc;
            objEntidad.RazonSocial = dataObj.RazonSocial;
            objEntidad.Direccion = dataObj.DireccionCliente;
            objEntidad.Ubigeo = dataObj.Ubigeo;
            objEntidad.CodigoPedidoApp = idFirebase;

            String XmlDetalle = "";

            foreach (Articulo item in dataObj.Articulos)
            {
                XmlDetalle = XmlDetalle + "<D ";
                XmlDetalle = XmlDetalle + " CodArticulo = '" + 0 + "'";
                XmlDetalle = XmlDetalle + " Cantidad = '" + item.Cantidad + "'";
                XmlDetalle = XmlDetalle + " Precio = '" + item.Precio + "'";
                XmlDetalle = XmlDetalle + " PrecioDscto = '" + item.Precio + "'";
                XmlDetalle = XmlDetalle + " Costo = '" + 0 + "'";
                XmlDetalle = XmlDetalle + " Um = '" + item.Um + "'";
                XmlDetalle = XmlDetalle + " CodDetalle = ''";
                XmlDetalle = XmlDetalle + " OC = ''";
                XmlDetalle = XmlDetalle + " Descripcion = '" + item.Descripcion + "'";
                XmlDetalle = XmlDetalle + " Acuenta = '" + 0 + "'";
                XmlDetalle = XmlDetalle + " CodTipoDoc = '" + 0 + "'";
                XmlDetalle = XmlDetalle + " Fecha = '" + "" + "'";
                XmlDetalle = XmlDetalle + " Codigo = '" + item.IdArticulo + "'";
                XmlDetalle = XmlDetalle + " />";
            }

            XmlDetalle = "<R><XmlLC> " + XmlDetalle + "</XmlLC></R>";
            XmlDetalle = "<?xml version=" + '\u0022' + "1.0" + '\u0022' + " encoding=" + '\u0022' + "iso-8859-1" + '\u0022' + "?>" + XmlDetalle;

            objEntidad.Detalle = XmlDetalle;

            objEntidad = (new ProformaCabCN()).F_Proformas_Insert_Karina_App(objEntidad);

            return hecho;
        }




    }

    public partial class PedidoModel
    {
        public string ObservacionFacturacion { get; set; }
        public Articulo[] Articulos { get; set; }
        public string Fecha { get; set; }
        public object FechaAnulacion { get; set; }
        public string DireccionCliente { get; set; }
        public object TotalFactura { get; set; }
        public string NroRuc { get; set; }
        public long Total { get; set; }
        public string FechaRecepcion { get; set; }
        public string FechaFacturacion { get; set; }
        public string Factura { get; set; }
        public string Id { get; set; }
        public string Estado { get; set; }
        public string DireccionEnvio { get; set; }
        public string NroDocumento { get; set; }
        public long FechaYmd { get; set; }
        public string RazonSocial { get; set; }
        public string Ubigeo { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
    }

    public partial class Articulo
    {
        public string IdArticulo { get; set; }
        public double Precio { get; set; }
        public long Cantidad { get; set; }
        public string Um { get; set; }
        public string Descripcion { get; set; }
        public double Importe { get; set; }
        public string Id { get; set; }
        public string Codigo { get; set; }
        public long NroItem { get; set; }
        public string TipoValorUm { get; set; }
    }

}




