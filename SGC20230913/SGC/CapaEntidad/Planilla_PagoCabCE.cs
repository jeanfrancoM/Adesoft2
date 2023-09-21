using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Planilla_PagoCabCE
    {
        public int CodPagoCab { get; set; }
        public int CodSalarioCab { get; set; }
        public int CodTrabajador { get; set; }
        public int CodUsuario  { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int CodUsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int CodPeriodo{ get; set; }
        public int CodSemana { get; set; }
        public int MontoPago { get; set; }
        public int CodRegimenLaboral { get; set; }
        public int CodProyecto { get; set; }
        public int DesdeInt { get; set; }
        public int HastaInt { get; set; }
        public string MsgError { get; set; }
    }
}
