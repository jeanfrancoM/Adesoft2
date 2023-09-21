using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Planilla_PagoDetCE
    {
        public int CodPagoDet{ get; set; }
        public int CodPagoCab{ get; set; }
        public decimal Total { get; set; }
        public DateTime FechaPago { get; set; }
        public int CodUsuario{ get; set; }
        public DateTime FechaRegistro { get; set; }
        public int CodUsuarioModificacion{ get; set; }
        public DateTime FechaModificacion { get; set; }       
    }              
}                  
                   