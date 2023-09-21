using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class ProformaDetCE
{
	public int CodDetalleProforma {get ;set ; }
	public int CodProforma {get ;set ; }
	public int CodArticulo {get ;set ; }
    public decimal Cantidad { get; set; }
    public decimal CantidadEntregada { get; set; }
	public decimal Precio {get ;set ; }
    public decimal Precio2 { get; set; }
	public decimal ValorVenta {get ;set ; }
    public string Descripcion { get; set; }
    public int CodUnidadMedida { get; set; }
    public decimal Descuento { get; set; }
    public string Comentario { get; set; }
    public int CodTiempoProducto { get; set; }
    public string TiempoProducto { get; set; }
    public int CodProductoPresentacion { get; set; }
    public int CodGratuito { get; set; }
    public decimal Cantidad173 { get; set; }
    public decimal Cantidad250 { get; set; }
    public decimal CantidadABC { get; set; }
    public decimal PEstimado { get; set; }
    public decimal PxKilo { get; set; }
    public decimal Exclusivo { get; set; }
    public string Material { get; set; }
}
