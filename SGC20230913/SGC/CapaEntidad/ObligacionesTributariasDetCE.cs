using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class ObligacionesTributariasDet
{
    public int CodObligacionTributariaDet { get; set; }
    public int CodObligacionTributariaCab { get; set; }
    public int CodDocumentoVenta { get; set; }
    public int CodNotaIngresoSalida { get; set; }
    public int CodTipoDoc { get; set; }
    public decimal ImportePagoMonedaOriginal { get; set; }
    public decimal ImporteRetencion { get; set; }
    public decimal ImportePagoMonedaNacional { get; set; }
}
