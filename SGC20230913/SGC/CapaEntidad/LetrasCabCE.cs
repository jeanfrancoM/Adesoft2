using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class LetrasCabCE
{
    public int CodLetra { get; set; }
    public int CodAlmacen { get; set; }
    public int CodTipoOperacion { get; set; }
    public string Numero { get; set; }
    public DateTime FechaEmision { get; set; }
    public int CodCtaCte { get; set; }
    public int CodEstado { get; set; }
    public int CodFormaPago { get; set; }
    public DateTime FechaVencimiento { get; set; }
    public DateTime FechaCancelacion { get; set; }
    public int CodMoneda { get; set; }
    public decimal TipoCambio { get; set; }
    public decimal Total { get; set; }
    public int CodUsuario { get; set; }
    public string XmlDetalle { get; set; }
    public string MsgError { get; set; }
    public string Moneda { get; set; }
    public DateTime Desde { get; set; }
    public DateTime Hasta { get; set; }
    public int CodFactura { get; set; }
    public decimal TotalFactura { get; set; }
    public int Dias { get; set; }
    public string CodigoUnico { get; set; }
    public int CodBanco { get; set; }
    public DateTime IngresoBanco { get; set; }
    public int CodLetraCab { get; set; }
    public int CodEmpresa { get; set; }
    public int CantidadLetra { get; set; }
    public string AvalPermanente { get; set; }
    public string Domicilio { get; set; }
    public string Localidad { get; set; }
    public string Telefono { get; set; }
    public string DOIRUC { get; set; }
    public string Observacion { get; set; }

    public string Observaciones { get; set; }

    public DateTime FechaLiquidacion { get; set; }
}
