using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Planilla_TrabajadorCE
    {
        public int CodTrabajador { get; set; }
        public int CodCategoria { get; set; }
        public int CodProyecto { get; set; }
        public int CodAFP { get; set; }
        public int CodTipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string CUSP { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string PaisEmisor { get; set; }
        public string ApellidosNombres { get; set; }
        public int Sexo { get; set; }
        public int EstadoCivil { get; set; }
        public string Nacionalidad { get; set; }
        public string Direccion { get; set; }
        public int CodDistrito { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaCese { get; set; }
        public int NroHijos { get; set; }
        public decimal Pensiones_AFP { get; set; }
        public decimal Prima_AFP { get; set; }
        public decimal Comision_AFP { get; set; }
        public decimal Anticipada_AFP { get; set; }
        public decimal DescuentoJudicial { get; set; }
        public decimal CodUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int CodUsuarioModficacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public decimal SalarioMensual { get; set; }
        public int CodCargo { get; set; }
        public string MsgError { get; set; }
        public int CodEstado { get; set; }
        public string NombreCompleto { get; set; }

        public string RegistroOperacion { get; set; }
        public int CodEstadoProceso { get; set; }


        public int RetencionAnteriorCodRetencion { get; set; }
        public int RetencionAnteriorCodPeriodo { get; set; }
        public int RetencionAnteriorAño { get; set; }
        public decimal RetencionAnteriorMonto { get; set; }
        public decimal RetencionAnteriorTotalRemuneraciones { get; set; }
        public string RetencionAnteriorObservacion { get; set; }
        public int CodSeguridadSocial { get; set; }
        public int CodBanco { get; set; }
        public string NumeroCuenta { get; set; }
        public string CCI { get; set; }
        public string AreaTrabajo { get; set; }
        public string CentroCostos { get; set; }
        public string Consorciado { get; set; }
        public DateTime FechaExactaRetencion { get; set; }

    }
}
