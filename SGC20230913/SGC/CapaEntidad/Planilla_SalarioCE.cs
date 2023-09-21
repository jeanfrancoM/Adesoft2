using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Planilla_SalarioCE
    {
        public int CodSalario { get; set; }
        public int CodTrabajador { get; set; }
        public int CodProyecto { get; set; }
        public int CodSemana { get; set; }
        public string AñoSemana { get; set; }
        public int CodConceptoRemuneracion { get; set; }
        public decimal Valor { get; set; }
        public int CodUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int CodUsuarioModficacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public long IDExcel { get; set; }
        public string MsgError { get; set; }

        public int CodPeriodo { get; set; }


        public int CodRegimenLaboral { get; set; }
        public int CodCategoria { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }

        public int EsReintegro { get; set; }

        public int CodEstadoProceso { get; set; }
    }
}
