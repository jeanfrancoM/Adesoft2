using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Planilla_CategoriaCE
    {
        public int CodCategoria { get; set; }
        public string Descripcion { get; set; }
        public int CodRegimenLaboral { get; set; }
        public int CodEstado { get; set; }
        public int CodUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int CodUsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string Estado { get; set; }
        public string MsgError { get; set; }
        public int CodEstadoProceso { get; set; }
        public string RegistroOperacion { get; set; }
    }
}
