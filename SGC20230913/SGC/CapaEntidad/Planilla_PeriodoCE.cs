using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Planilla_PeriodoCE
    {
        public int CodPeriodo { get; set; }
        public int Año { get; set; }
        public int NroPeriodo { get; set; }
        public string AñoPeriodo1 { get; set; }
        public string AñoPeriodo2 { get; set; }
        public DateTime FechaInicial { get; set; }
        public string FechaInicialStr { get; set; }
        public DateTime FechaFinal { get; set; }
        public string FechaFinalStr { get; set; }
        public int NroFeriado { get; set; }
        public string DiaInicial { get; set; }
        public string DiaFinal { get; set; }
        public int CodUsuario { get; set; }
        public string MsgError { get; set; }
    }
}
