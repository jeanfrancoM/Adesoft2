using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class VehiculoPlanMantenimientoDetCE
{

    public int CodVehiculoPlanMantenimientoDet { get; set; }
    public int CodVehiculoPlanMantenimientoCab { get; set; }
    public int CodProducto { get; set; }
    public int  CodTipoProducto{ get; set; }
    public int Cantidad { get; set; }
    public int CodEstado { get; set; }
    public int CodDetalle { get; set; }
    public string XmlDetalle { get; set; }

    public int CodTipoPlan { get; set; }
    public Decimal Kilometros { get; set; }
    
    public string MsgError { get; set; }
    public string DscProducto { get; set; }
    public string CodigoProducto { get; set; }
    public string UM { get; set; }
    public string Marca { get; set; }
    

}
