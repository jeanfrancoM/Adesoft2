using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class OrdenPedidoCabCE
{
    public int CodOrdenPedido { get; set; }
    public int CodAlmacen { get; set; }
    public int CodEmpresa { get; set; }
    public string Serie { get; set; }
    public string Numero { get; set; }
    public string NumeroAnterior { get; set; }
    public DateTime Desde { get; set; }
    public int CodCtaCte { get; set; }
    public int CodDetalle { get; set; }
    public DateTime FechaEmision { get; set; }
    public int CodMoneda { get; set; }
    public DateTime Hasta { get; set; }
    public DateTime Vencimiento { get; set; }
    public string Observacion { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Igv { get; set; }
    public decimal Total { get; set; }
    public int CodEstado { get; set; }
    public int CodTraslado { get; set; }
    public int CodUsuario { get; set; }
    public DateTime FechaRegistro { get; set; }
    public int Codigo { get; set; }
    public decimal TipoCambio { get; set; }
    public int CodTasa { get; set; }
    public DateTime FechaAprobacion { get; set; }
    public int CodMotivo { get; set; }
    public string Referencia { get; set; }
    public string Atencion { get; set; }
    public int CodTipoDoc { get; set; }
    public string Placa { get; set; }
    public string KM { get; set; }
    public string Placa2 { get; set; }
    public string Placa3 { get; set; }
    public string Placa4 { get; set; }
    public string MsgError { get; set; }
    public int CodFormaPago { get; set; }
    public string NroRuc { get; set; }
    public string Cliente { get; set; }
    public string Vendedor { get; set; }
    public string EmisionStr { get; set; }
    public string VencimientoStr { get; set; }
    public int COTIZACIONES_HOY { get; set; }
    public int FlagVisibleFacturacion { get; set; }
    public string Correo { get; set; }
    public string CorreoAtencion { get; set; }
    public string Celular { get; set; }
    public string NroOperacion { get; set; }
    public string NroDni { get; set; }
    public int CodDepartamento { get; set; }
    public int CodDistrito { get; set; }
    public int CodProvincia { get; set; }
    public int CodTipoCliente { get; set; }
    public string RazonSocial { get; set; }    
    public string ApePaterno { get; set; }    
    public string ApeMaterno { get; set; }    
    public string Nombres { get; set; }
    public string Direccion { get; set; }
    public string Distrito { get; set; }    
    public int CodDireccion { get; set; }
    public int FlagIgv { get; set; }
    public int FlagConCodigo { get; set; }
    public int CodEmpleado { get; set; }
    public int CodOrdenPedidoAnterior { get; set; }
    public List<OrdenPedidoDetCE> lOrdenPedidoDet { get; set; }
    public string LugarEntrega { get; set; }
    public string TiempoEntrega { get; set; }
    public int CodVendedor { get; set; }
    public int FlagComisionable { get; set; }
    public DateTime FechaIngreso { get; set; }
    public DateTime FechaSalida { get; set; }
    public string FechaIngresoStr { get; set; }
    public string FechaSalidaStr { get; set; }
    public string NombreComercial { get; set; }
    public int CodCategoria { get; set; }
    public int CodigoPedidoApp { get; set; }

    public string observacionanulacion { get; set; }

    public string FPago { get; set; }

    public string FEntrega { get; set; }
}
