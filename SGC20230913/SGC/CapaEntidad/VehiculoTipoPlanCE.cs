using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class VehiculoTipoPlanCE
{
    public int CodVehiculoTipoPlan { get; set; }
    public string Descripcion { get; set; }
    public int CodEstado { get; set; }
    public int CodUsuario { get; set; }
    public Decimal Recorrido { get; set; }
    
    public DateTime FechaRegistro { get; set; }
    public int CodUsuarioModificacion { get; set; }
    public DateTime FechaModificacion { get; set; }
    public string MsgError { get; set; }
    

}

