using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using CapaDatos;

public class VehiculoPlanMantenimientoDetCN
{

    VehiculoPlanMantenimientoDetCD obj = new VehiculoPlanMantenimientoDetCD();


    public VehiculoPlanMantenimientoDetCE F_TemporalPlanMantenimientoDet_Update(VehiculoPlanMantenimientoDetCE objEntidadBE)
    {
        try
        {
            return obj.F_TemporalPlanMantenimientoDet_Update(objEntidadBE);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    
  
    public VehiculoPlanMantenimientoDetCE F_TemporalPlanMantenimientoDet_Eliminar(VehiculoPlanMantenimientoDetCE objEntidadBE)
    {
        try
        {
            return obj.F_TemporalPlanMantenimientoDet_Eliminar(objEntidadBE);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    //
    public DataTable F_VehiculoPlanMantenimientoDet_Listar(VehiculoPlanMantenimientoDetCE objEntidadBE)
    {
        try
        {
            return obj.F_VehiculoPlanMantenimientoDet_Listar(objEntidadBE);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DocumentoVentaCabCE F_AplicarPlanMantenimientoDetalle(DocumentoVentaCabCE objEntidadBE)
    {
        try
        {
            return obj.F_AplicarPlanMantenimientoDetalle(objEntidadBE);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DocumentoVentaCabCE F_AplicarPlanMantenimientoDet(DocumentoVentaCabCE objEntidadBE)
    {
        try
        {
            return obj.F_AplicarPlanMantenimientoDet(objEntidadBE);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    

}
