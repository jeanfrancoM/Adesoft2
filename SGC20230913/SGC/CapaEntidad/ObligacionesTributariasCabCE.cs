using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class ObligacionesTributariasCabCE
{
    public int CodObligacionTributariaCab { get; set; }
    public int CodEmpresa { get; set; }
    public int CodAlmacen { get; set; }
    public int CodTipoDoc { get; set; }
    public string SerieDoc { get; set; }
    public string NumeroDoc { get; set; }
    public int CodCtaCte { get; set; }
    public int CodTasa { get; set; }
    public DateTime FechaEmision { get; set; }
    public decimal Total { get; set; }
    public int CodMoneda { get; set; }
    public decimal TipoCambio { get; set; }
    public int CodUsuario { get; set; }
    public DateTime FechaRegistro { get; set; }
    public string IP_INSERT { get; set; }
    public int CodUsuarioModificacion { get; set; }
    public DateTime FechaModificacion { get; set; }
    public string IP_UPDATE { get; set; }

    public string MsgError { get; set; }
}
