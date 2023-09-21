using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class CheckListCE
{

    public int CodVehiculoCheckListCab { get; set; }
    public int CodVehiculo { get; set; }
    public int CodTipoVehiculo { get; set; }
    public int CodCtaCte { get; set; }
    public int CodEmpresa { get; set; }
    public int CodAlmacen { get; set; }
    public int CodEstado { get; set; }
    public string SerieDoc { get; set; }
    public string MsgError { get; set; }
    public string Descripcion { get; set; }
    public string Placa { get; set; }
    public string NumeroDoc { get; set; }
    public DateTime FechaEmision { get; set; }
    public int CodEmpleadoResponsable { get; set; }
    public string ResponsableClienteDni { get; set; }
    public string XmlDetalle { get; set; }
    public string ResponsableCliente { get; set; }
    public string Observacion { get; set; }
    public int NivelGasolina { get; set; }
    public DateTime Desde { get; set; }
    public DateTime Hasta { get; set; }
    public int CodUsuario { get; set; }
     public DateTime FechaRegistro { get; set; }
    public int CodUsuarioAnulacion { get; set; }
    public DateTime FechaAnulacion { get; set; }
    public int CodUsuarioModificacion { get; set; }
    public DateTime FechaModificacion { get; set; }

}
