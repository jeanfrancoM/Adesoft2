using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class VehiculoComponenteCE
{

    public int CodVehiculoComponente { get; set; }
    public int CodTipoVehiculo { get; set; }
    public int CodTipoComponente { get; set; }
    public string Descripcion { get; set; }
    public int Cantidad { get; set; }
    public int CodEmpresa { get; set; }
    public int CodAlmacen { get; set; }
    public int CodEstado { get; set; }
    public int CodUsuario { get; set; }
    public DateTime FechaRegistro { get; set; }
    public int CodUsuarioModificacion { get; set; }
    public DateTime FechaModificacion { get; set; }
    public string MsgError { get; set; }
    

}
