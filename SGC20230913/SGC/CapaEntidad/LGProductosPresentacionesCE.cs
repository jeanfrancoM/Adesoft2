using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class LGProductosPresentacionesCE
{
    public int CodProductoPresentacion { get; set; }
    public int CodProducto { get; set; }
    public int CodEstado { get; set; }
    public string Estado { get; set; }
    public int CodUnidadMedida { get; set; }
    public string UnidadMedida { get; set; }
    public decimal Factor { get; set; }
    public int CodMoneda { get; set; }
    public string Moneda { get; set; }
    public decimal Costo { get; set; }
    public decimal Precio1 { get; set; }
    public decimal Precio2 { get; set; }
    public decimal Precio3 { get; set; }
    public decimal Precio4 { get; set; }
    public decimal Precio5 { get; set; }
    public decimal Precio6 { get; set; }
    public int CodUsuario { get; set; }
    public string MsgError { get; set; }

    public string RegistroOperacion { get; set; }
    public int CodEstadoProceso { get; set; }
}
