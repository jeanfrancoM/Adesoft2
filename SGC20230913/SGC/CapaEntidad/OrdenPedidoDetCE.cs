using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class OrdenPedidoDetCE
{
	public int CodDetalleOrdenPedido {get ;set ; }
	public int CodOrdenPedido {get ;set ; }
	public int CodArticulo {get ;set ; }
    public decimal Cantidad { get; set; }
    public decimal CantidadEntregada { get; set; }
	public decimal Precio {get ;set ; }
    public decimal PrecioOriginal { get; set; }
	public decimal ValorVenta {get ;set ; }
    public string Descripcion { get; set; }
    public int CodUnidadMedida { get; set; }
    public decimal Descuento { get; set; }
    public string Comentario { get; set; }
    public int CodTiempoProducto { get; set; }
    public string TiempoProducto { get; set; }
    public int CodProductoPresentacion { get; set; }
    public decimal DescuentoPorcMax { get; set; }
    public string Material { get; set; }
    public decimal PEstimado { get; set; }
    public decimal PxKilo { get; set; }
}
