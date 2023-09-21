using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Planilla_CategoriaValoresCE
    {
        public int CodCodCategoriaValores { get; set; }
        public int CodCodCategoria { get; set; }
        public int CodConceptoRemuneracion { get; set; }
        public string Categoria { get; set; }
        public string Concepto { get; set; }
        public decimal Valor { get; set; }
        public string Observacion { get; set; }
        public decimal Valor2 { get; set; }
        public decimal TopeDiferencia { get; set; }
        public string Tipo { get; set; }
        public string Clasificacion { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public string RegistroOperacion { get; set; }
        public string Estado { get; set; }
        public string MsgError { get; set; }
        public int CodEstadoProceso { get; set; }
        public int CodUsuario { get; set; }
        public int flagTodos { get; set; }
    }
}
