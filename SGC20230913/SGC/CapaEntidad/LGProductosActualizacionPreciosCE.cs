using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class LGProductosActualizacionPreciosCE : LGProductosCE
{
    public int CodActualizacionPrecios { get; set; }
    public int CodDetalle { get; set; }
    public decimal Igv { get; set; }
    public DateTime Desde { get; set; }
    public DateTime Hasta { get; set; }
}

public class LGProductosActualizacionPreciosDetCE : LGProductosActualizacionPreciosCE
{
    public string DescripcionNueva { get; set; }
    public string MarcaNueva { get; set; }
    public decimal PrecioNuevo { get; set; }
    public decimal Precio2Nuevo { get; set; }
    public decimal Precio3Nuevo { get; set; }
}