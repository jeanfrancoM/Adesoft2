using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class TCDistritoCE
{
    public int CodAlmacen { get; set; }
    public int CodDireccion { get; set; }
    public int CodDepartamento { get; set; }
    public int CodProvincia { get; set; }
    public int CodDistrito { get; set; }
    public int CodCtaCte { get; set; }
    public int Codigo { get; set; }
    public string DscDistrito { get; set; }
    public string Descripcion { get; set; }
    public string Estado { get; set; }
    public int CodUsuario { get; set; }
    public DateTime FechaRegistro { get; set; }
    public string CodUsuarioMod { get; set; }
    public DateTime FechaModificacion { get; set; }
    public string CodUsuarioAnul { get; set; }
    public DateTime FechaAnulacion { get; set; }
    public string Direccion { get; set; }
    public string Email { get; set; }
    public string Email2 { get; set; }
    public string Email3 { get; set; }
    public string Email4 { get; set; }
    public string Email5 { get; set; }
    public string Email6 { get; set; }
    public string Mensaje { get; set; }

    public string Ubigeo { get; set; }

    public int CodEmpresa { get; set; }

    public decimal GPSLong { get; set; }

    public decimal GPSLat { get; set; }
}
