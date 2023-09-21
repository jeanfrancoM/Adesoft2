using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class DocumentoVentaDetCE
{    
    public int CodDetDocumentoVenta { get; set; } 
	public int CodDocumentoVenta { get; set; }
    public int Flag { get; set; } 
	public int CodOrdenTrabajo { get; set; }
    public int CodTemporalSerializacionDet { get; set; } 
	public int CodArticulo { get; set; } 
    public decimal  Cantidad { get; set; } 
	public int CodUndMedida { get; set; }
    public decimal Precio { get; set; }
    public decimal Precio2 { get; set; }
    public decimal Precio3 { get; set; }
    public decimal Costo { get; set; }
    public decimal Descuento { get; set; }
    public string XmlDetalle { get; set; }
    public string MsgError { get; set; }
    public int CodTipoOperacion { get; set; }
    public int CodCobranzaCab { get; set; }
    public int CodPagoCab { get; set; }
    public int FlagIgv { get; set; }
    public int CodFacturaDet { get; set; }    
    public decimal TipoCambio { get; set; }
    public decimal Soles { get; set; }
    public decimal Dolares { get; set; }
    public string Descripcion { get; set; }
    public string Marca { get; set; }
    public string Comentario { get; set; }
    public string TiempoProducto { get; set; }
    public int CodTipoDoc { get; set; }
    public int CodAlmacen { get; set; }
    public int CodProducto { get; set; }
    public int CodMoneda { get; set; }
    public int CodComprobanteCaja { get; set; }
    public int SolicitudDescuento { get; set; }
    public string TipoAccion { get; set; }
    public int CodUsuario { get; set; }
    public int CodProforma { get; set; }
    public decimal PrecioOriginal { get; set; }
    public decimal DescuentoPorcMax { get; set; }
    public int CodGratuito { get; set; }
    public int codigo { get; set; }
    public int CodDetPedido { get; set; }
    public int Cantidad173 { get; set; }
    public int Cantidad250 { get; set; }
    public int CantidadABC { get; set; }


    public decimal PxKilo { get; set; }

    public decimal PEstimado { get; set; }

    public string Material { get; set; }

    public object Margen { get; set; }

    public decimal Margen2 { get; set; }
}
