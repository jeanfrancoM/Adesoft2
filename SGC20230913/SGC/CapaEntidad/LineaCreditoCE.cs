using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class LineaCreditoCE
{
    public int Tipo { get; set; }
    public string Concepto { get; set; }
    public string Moneda { get; set; }
    public decimal Monto { get; set; }
    public string MontoStr { get; set; }
    public int CodMonedaLineaCredito { get; set; }
}
