using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class LGProductosCE
{
    public int CodProducto { get; set; }
    public string CodAlterno { get; set; }
    public int CodEmpresa { get; set; }
    public int CodAlmacen { get; set; }
    public int IdFamilia { get; set; }
    public int CodLinea { get; set; }
    public string CodSubLinea { get; set; }
    public int CodTipoProducto { get; set; }
    public string ServAlterno { get; set; }
    public int CodClasificacion { get; set; }
    public string Ambos_Preventivo_Correctivo { get; set; }
    public int CodSistema { get; set; }
    public int CodCapacidad { get; set; }
    public string DscProducto { get; set; }
    public string DscProducto2 { get; set; }
    public string DscProductoIngles { get; set; }
    public int CodMarca { get; set; }
    public int CodUnidadCompra { get; set; }
    public int CodUnidadVenta { get; set; }
    public string Medida { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Posicion { get; set; }
    public string Anio { get; set; }
    public string Ubicacion { get; set; }
    public string CodColor { get; set; }
    public string PartidaArancelaria { get; set; }
    public decimal StockMinimo { get; set; }
    public decimal StockMaximo { get; set; }
    public decimal CostoProducto { get; set; }
    public decimal CostoUniProducto { get; set; }
    public int CodIndicador { get; set; }
    public string Observacion { get; set; }
    public string FlagEquivalencia { get; set; }
    public string Estado { get; set; }
    public int CodUsuario { get; set; }
    public DateTime FechaRegistro { get; set; }
    public int CodUsuarioMod { get; set; }
    public DateTime FechaModificacion { get; set; }
    public int CodUsuarioAnul { get; set; }
    public DateTime FechaAnulacion { get; set; }
    public string Capacidad { get; set; }
    public string Anaquel { get; set; }
    public string Fila { get; set; }
    public decimal CostoMercado { get; set; }
    public string CodigoProducto { get; set; }
    public decimal Precio { get; set; }
    public string CodigoAlternativo { get; set; }
    public decimal Precio2 { get; set; }
    public decimal Precio3 { get; set; }
    public decimal Precio4 { get; set; }
    public decimal PrecioApp { get; set; }
    public int CodMoneda { get; set; }
    public string Aro { get; set; }
    public string Suplemento { get; set; }
    public string DescripcionCorta { get; set; }
    public string Medida2 { get; set; }
    public string Aro2 { get; set; }
    public decimal CostoOriginal { get; set; }
    public decimal CostoUniOriginal { get; set; }
    public decimal Medida3 { get; set; }
    public decimal Aro3 { get; set; }
    public decimal Seccion { get; set; }
    public decimal CostoMarginable { get; set; }
    public int Factor { get; set; }
    public string MsgError { get; set; }
    public int Flag { get; set; }
    public string XmlDetalle { get; set; }
    public int Periodo { get; set; }
    public int CodTipoOperacion { get; set; }
    public int CodCtaCte { get; set; }
    public int IdImagenProducto1 { get; set; }
    public byte[] B_ImagenTem { get; set; }
    public int ID_TemporalImagen { get; set; }
    public String T_NombreArchivo { get; set; }
    public String T_Preview { get; set; }
    public string T_Ruta { get; set; }
    public long T_Tamaño { get; set; }
    public decimal Descuento { get; set; }
    public dynamic Imagenes { get; set; }
    public int CodProductoModelo { get; set; }
    public string CodFamilia { get; set; }
    public int FlagCpe { get; set; }
    public string Motor { get; set; }
    public decimal Stock { get; set; }
    public decimal Principal { get; set; }
    public decimal Chorrillos { get; set; }
    public decimal QTOPISO { get; set; }
    public decimal CUADRA3 { get; set; }
    public decimal LURIN1 { get; set; }
    public decimal LURIN2 { get; set; }
    public string UM { get; set; }
    public decimal CostoSoles { get; set; }
    public decimal CostoDolares { get; set; }
    public decimal Precio1 { get; set; }
    public decimal PrecioDolares { get; set; }
    public decimal Precio2Dolares { get; set; }
    public decimal Precio3Dolares { get; set; }
    public decimal Precio4Dolares { get; set; }
    public decimal PrecioAppDolares { get; set; }
    public string CodigoInterno { get; set; }
    public int CodEstado { get; set; }
    public int CodModeloVehiculo { get; set; }
    public int CodProcedencia { get; set; }
    public string IPRegistro { get; set; }
    public string IPModificacion { get; set; }
    public string Comentario { get; set; }
    public string CajaCambio { get; set; }
    public string Pais { get; set; }
    public string Filtro { get; set; }
    public decimal M1 { get; set; }
    public decimal M2 { get; set; }
    public decimal M3 { get; set; }
    public string Transmision { get; set; }
    public string D1 { get; set; }
    public string D2 { get; set; }
    public string D3 { get; set; }
    public string D4 { get; set; }
    public string D5 { get; set; }
    public string D6 { get; set; }
    public string D7 { get; set; }
    public string M1str { get; set; }
    public string M2str { get; set; }
    public string M3str { get; set; }
    public DateTime FechaVigencia { get; set; }
    public int Flag_VenderEnApp { get; set; }
    public string DescripcionApp { get; set; }
    public string Familia { get; set; }
    public string Moneda { get; set; }
    public string Tags { get; set; }
    public List<Imagenes> Imagenes2 { get; set; }
    public string CodigoFabrica { get; set; }
    public int CodTipo { get; set; }
    public int TipoReporte { get; set; }
    public string xmlFamilias { get; set; }
    public string XmlAlmacen { get; set; }
    public string xmlMarcas { get; set; }
    public string xmlLineas { get; set; }
    
    public int FlagProductosConStock { get; set; }

    public int SeVendeEnApp { get; set; }
    public string TituloApp { get; set; }
    public string DescripcionDetalladaApp { get; set; }

    public string CodigoApp { get; set; }


    public int SoloConImagenes { get; set; }
    public int SoloYaEnviados { get; set; }

    public int TipoBusquedaArticulo { get; set; }
    public int Orden { get; set; }
    public int CodMarcaProducto { get; set; }
    public string DescripcionMarcaProducto { get; set; }

    public int CodMarcaProductoBuscar { get; set; }

    public int  CodMarcaProductoEditar{ get; set; }


    public decimal Precio5 { get; set; }

    public decimal Precio5Dolares { get; set; }
    public decimal Margen1 { get; set; }
    public decimal Margen2 { get; set; }

    public decimal Margen3 { get; set; }

    public decimal Margen4 { get; set; }

    public decimal Margen5 { get; set; }

    public int chkMarca { get; set; }

    public decimal CantidadMayorista { get; set; }

    public int CodClaseImagen { get; set; }

    public long ID_Proceso { get; set; }
    

    public int CodCategoria { get; set; }

    public int PermisoMayorista { get; set; }

    public int CodigoMenu { get; set; }

    public int chkMateriaPrima { get; set; }

    public string Chasis { get; set; }

    public string DescComp { get; set; }

    public int FlagCompra { get; set; }

    public int CantidadMayoristaLimite { get; set; }
    public decimal Exclusivo { get; set; }
    public int ProductoNuevo { get; set; }
}

public class Imagenes {
    public string Imagen { get; set; }

}
