using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Planilla_ProyectoCE
    {
        public int CodProyecto { get; set; }
        public string Descripcion { get; set; }
        public decimal DescuentoSindical { get; set; }
        public int CodEstadoProceso { get; set; }
        public string Proceso { get; set; }
        public int CodEstado { get; set; }
        public string Estado { get; set; }
        public int CodUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int CodUsuarioModficacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string MsgError { get; set; }
        public string RegistroOperacion { get; set; }
    }
}
