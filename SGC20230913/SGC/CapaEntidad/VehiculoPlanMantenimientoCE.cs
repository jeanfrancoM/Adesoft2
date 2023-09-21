using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class VehiculoPlanMantenimientoCE
{


    public int CodVehiculoPlanMantenimientoCab { get; set; }
    public string Descripcion { get; set; }
    public Decimal Kilometraje { get; set; }
    public Decimal TiempoTrabajo { get; set; }
    public Decimal Recorrido { get; set; }
    public int CodEmpresa { get; set; }
    public int CodDetalle { get; set; }
    public int Codigo { get; set; }
    public int CodTipoPlan { get; set; }
    
    
    public int CodVehiculoPlanMantenimientoAnterior { get; set; }

    public List<VehiculoPlanMantenimientoDetCE> lPlanMantenimientoDet { get; set; }

    public string XmlDetalle { get; set; }
    public int CodEstado { get; set; }
    public int CodUsuario { get; set; }
    public DateTime FechaRegistro { get; set; }
    public int CodUsuarioModificacion { get; set; }
    public DateTime FechaModificacion { get; set; }
    public string MsgError { get; set; }
    

}
