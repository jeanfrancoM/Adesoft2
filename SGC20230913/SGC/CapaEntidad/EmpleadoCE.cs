using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class EmpleadoCE
{
    public int CodAlmacen { get; set; }
    public int CodEmpleado {get ;set;}
    public string Dni { get; set; }
    public string NombreCompleto { get; set; }
    public int CodEstado { get; set; }
    public int CodTipoDoc { get; set; }
    public int CodCargo {get ;set;}
    public DateTime FechaRegistro { get; set; }
    public string IPRegistro { get; set; }
    public int CodUsuario {get ;set;}

}
