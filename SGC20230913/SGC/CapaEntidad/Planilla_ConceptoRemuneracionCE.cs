using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Planilla_ConceptoRemuneracionCE
    {
        public string RegistroOperacion { get; set; }
        public int CodConceptoRemuneracion { get; set; }
        public int CodRegimenLaboral { get; set; }
        public string Descripcion { get; set; }
        public int Orden { get; set; }
        public int CodTipo { get; set; }
        public int CodEstado { get; set; }
        public int CodUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int CodUsuarioModficacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int CodConceptoRemuneracion_Referencia { get; set; }
        public int CodClasificacion { get; set; }
        public int CodNaturaleza { get; set; }
        public int Orden2 { get; set; }

        public string Estado { get; set; }
        public string MsgError { get; set; }
        public int CodEstadoProceso { get; set; }
    }
}
