using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Planilla_CargoCE
    {
        public int CodCargo { get; set; }
        public string DscCargo { get; set; }
        public int CodEstado { get; set; }
        public int CodRegimenLaboral { get; set; }
        public int CodUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int CodUsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
