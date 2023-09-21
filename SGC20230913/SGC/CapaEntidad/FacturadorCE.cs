using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class FacturadorCE
{

    public int CodEmpresa { get; set; }
    public string Serie { get; set; }
    public int Desde { get; set; }
    public int Hasta { get; set; }
    public string CodTipoDocumento { get; set; }
    public int CodEstadoProcesoSunat { get; set; }
}
