using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class TCAlmacenCE
{

    public int CodEmpresa { get; set; }
    public int CodAlmacen { get; set; }
    public string DscAlmacen { get; set; }
    public string Direccion { get; set; }
    public int CodPais { get; set; }
    public int CodDepartamento { get; set; }
    public int CodProvincia { get; set; }
    public int CodDistrito { get; set; }
    public string FlagPrincipal { get; set; }
    public int CodEstado { get; set; }
    public int CodUsuario { get; set; }
    public DateTime FechaRegistro { get; set; }
    public int CodUsuarioMod { get; set; }
    public DateTime FechaModificacion { get; set; }
    public int CodUsuarioAnul { get; set; }
    public DateTime FechaAnulacion { get; set; }
    public string Cuenta { get; set; }



    public string Clave { get; set; }
    public string Empresa { get; set; }
    public string Almacen { get; set; }
    public string DBHost { get; set; }
    public string DBDataBase { get; set; }
    public string DBUser { get; set; }
    public string DBPass { get; set; }
    public string DBPort { get; set; }
    public string RazonSocial { get; set; }
    public decimal Stock { get; set; }
    public int FlagInicial { get; set; }
    public int CodProducto { get; set; }
    public string CodigoProducto { get; set; }
    public string Marca { get; set; }
    public int FlagProductoInicial { get; set; }

    public int ConsultadoSN { get; set; }
    public string ConexionNombre { get; set; }
    public int CodAlmacenRemoto { get; set; }



    public string Descripcion { get; set; }
}
