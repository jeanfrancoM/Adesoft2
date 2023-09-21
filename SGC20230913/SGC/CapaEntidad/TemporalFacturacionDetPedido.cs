using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class TemporalFacturacionDetPedido
    {
        public int CodDetPedido { get; set; }
        public int CodDetDocumentoVenta { get; set; }
        public int CodDocumentoVenta { get; set; }
        public int CodArticulo { get; set; }
        public string Descripcion { get; set; }
        public int Cant173 { get; set; }
        public int Cant250 { get; set; }
        public int CantABC { get; set; }
        public string MsgError { get; set; }
    }
}
