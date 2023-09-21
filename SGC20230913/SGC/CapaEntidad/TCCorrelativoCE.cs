using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class TCCorrelativoCE
{
    public int CodSerie { get; set; }
    public int CodEmpresa { get; set; }
    public int CodAlmacen { get; set; }
    public int CodTipoDoc { get; set; }
    public string SerieDoc { get; set; }
    public string NumeroDoc { get; set; }
    public int CodEstado { get; set; }
    public int CodUsuario { get; set; }
    public DateTime FechaRegistro { get; set; }
    public int CodUsuarioMod { get; set; }
    public DateTime FechaModificacion { get; set; }
    public int CodUsuarioAnul { get; set; }
    public DateTime FechaAnulacion { get; set; }
    public string MsgError { get; set; }
    public string Flag_Automatico { get; set; }
    public int FlagNCInterno { get; set; }
    public int CodTipoDoc2 { get; set; }
    public int FlagExterna { get; set; }
    public int CodSede { get; set; }
    public string Estado { get; set; }
}
