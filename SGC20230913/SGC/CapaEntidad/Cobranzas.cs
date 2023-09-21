using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class Cobranzas
{
	public int CodCobranza {get ;set ; }
	public int CodDocumentoVenta {get ;set ; }
	public int CodMedioPago {get ;set ; }
	public string NroOperacion {get ;set ; }
	public int CodMoneda {get ;set ; }
	public decimal Amortizacion {get ;set ; }
	public decimal TipoCambio {get ;set ; }
	public DateTime FechaOperacion {get ;set ; }
	public int CodEstado {get ;set ; }
	public int CodNotaCredito {get ;set ; }
	public string Responsable {get ;set ; }
	public string Observaciones {get ;set ; }
    public DateTime FechaRegistro { get; set; }
    public int CodUsuario { get; set; }
    public int CodBanco { get; set; }
    public int CodCtaBancaria { get; set; }
    public string Observacion { get; set; }
    public decimal Comision { get; set; }
    public string MsgError { get; set; }
    public decimal ComisionTarjeta { get; set; }
    public DateTime FechaEmision { get; set; }
    public int CodCajaFisica { get; set; }


    public string Recibo { get; set; }

    public string XmlDetalle { get; set; }
}