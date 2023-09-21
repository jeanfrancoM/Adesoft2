using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class VehiculoCE
{


    public string RazonSocial { get; set; }
    public string Direccion { get; set; }
    public string NroRuc { get; set; }
    public string NroDni { get; set; }
    public int CodTipoCliente { get; set; }
    public int CodProvincia { get; set; }
    public int CodDepartamento { get; set; }
    public int CodDistrito { get; set; }
    public int CodDireccion { get; set; }
    public int CodEmpresa { get; set; }
    public int CodAlmacen { get; set; }
    public int CodMarca { get; set; }
    public string Descripcion { get; set; }

    public int CodVehiculoTipoPlan { get; set; }

    public int CodVehiculo { get; set; }
    public string Placa { get; set; }
    public string Chasis { get; set; }
    public int CodCliente { get; set; }
    public int Anio { get; set; }
    public int CodColor { get; set; }
    public string NroMotor { get; set; }
    public int CodModeloVehiculo { get; set; }
    public int CodTipoVehiculo { get; set; }
    public DateTime FechaVctoSoat { get; set; }
    public DateTime FechaRevisionTecnica { get; set; }
    public int NroFlota { get; set; }
    public string Observacion { get; set; }
    public string MsgError { get; set; }

    public int CodEstado { get; set; }
    //auditoria
    public int CodUsuarioRegistro { get; set; }
    public DateTime FechaRegistro { get; set; }
    public int CodUsuarioModificacion { get; set; }
    public DateTime FechaModificacion { get; set; }
}
