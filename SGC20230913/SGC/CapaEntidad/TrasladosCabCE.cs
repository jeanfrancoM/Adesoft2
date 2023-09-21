using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class TrasladosCabCE
{
	public int CodTraslado {get ;set ; }
	public int CodEmpresa {get ;set ; }
	public int CodDoc {get ;set ; }
    public string Serie { get; set; }
    public string SerieDoc {get ;set ; }
	public string NumeroDoc {get ;set ; }
	public DateTime FechaEmision {get ;set ; }
	public DateTime FechaTraslado {get ;set ; }
	public int CodAlmacenPartida {get ;set ; }
	public int CodAlmacenLlegada {get ;set ; }
	public string Observacion {get ;set ; }
	public int Estado {get ;set ; }
	public int CodUsuario {get ;set ; }
	public DateTime FechaRegistro {get ;set ; }
	public int CodUsuarioAnulacion {get ;set ; }
	public DateTime FechaAnulacion {get ;set ; }
	public int GuiaEnlazada {get ;set ; }
    public int CodTipoOperacion { get; set; }
    public int CodCtaCte { get; set; }
    public string Direccion { get; set; }
    public string MsgError { get; set; }
    public int CodMotivoTraslado { get; set; }
    public DateTime Desde { get; set; }
    public DateTime Hasta { get; set; }
    public int CodDocumentoVenta { get; set; }
    public int CodDireccion { get; set; }
    public int CodAlmacen { get; set; }
    public int CodEstado { get; set; }
    public string Partida { get; set; }
    public string Destino { get; set; }
    public int CodDetalle { get; set; }
    public int CodDepartamento { get; set; }
    public int CodTipoDoc { get; set; }
    public decimal TipoCambio { get; set; }
    public int CodMoneda { get; set; }
    public int CodTasa { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Igv { get; set; }
    public decimal Total { get; set; }
    public string Cliente { get; set; }
    public int CodProforma { get; set; }
    public string Descripcion { get; set; }
    public string XmlDetalle { get; set; }
    public decimal TasaIgv { get; set; }
    public int CodCliente { get; set; }
    public string NroReferencia { get; set; }
    public int CodFacturaAnterior { get; set; }
    public string Responsable { get; set; }
    public int CodTrasladoAnterior { get; set; }
    public int CodTipoFormato { get; set; }
    public int CodConductor { get; set; }
    public string DniConductor { get; set; }
    public string NombreConductor { get; set; }
    public int FlagImportacion { get; set; }
    public int CodTransportista { get; set; }
    public int FlagMotorizado { get; set; }
    public string Placa { get; set; }

    public string Marca { get; set; }

    public string Licencia { get; set; }

    public string NroBultos { get; set; }

    public string Peso { get; set; }

    public int CodDireccionTrans { get; set; }

    public string TipoImpresion { get; set; }

    public object ObservacionNS { get; set; }

    public int Numero { get; set; }

    public string Conexion { get; set; }

    public int destino { get; set; }

    public string NroRuc { get; set; }

    public string Observacion2 { get; set; }

    public int CodProducto { get; set; }

    public int Cantidad { get; set; }

    public int CodUnidadVenta { get; set; }

    public string CodigoInterno { get; set; }

    public List<TrasladosCabCE> ltrasladosDet { get; set; }

    public string EmisionStr { get; set; }

    public DateTime Vencimiento { get; set; }

    public string VencimientoStr { get; set; }
}
