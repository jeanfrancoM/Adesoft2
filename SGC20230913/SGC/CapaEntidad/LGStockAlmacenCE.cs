using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class LGStockAlmacenCE
{
	public int CodStockAlmacen {get ;set ; }
	public int CodEmpresa {get ;set ; }
	public int CodAlmacen {get ;set ; }
	public int CodProducto {get ;set ; }
	public decimal StockActual {get ;set ; }
	public decimal StockMinimo {get ;set ; }
	public decimal StockMaximo {get ;set ; }
    public int FlagStockAlterado { get; set; }
    public string DscEmpresa { get; set; }
    public string DscAlmacen { get; set; }
    public bool res { get; set; }
}
