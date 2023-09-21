using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using CapaDatos;

public class VehiculoPlanMantenimientoCN
{
    VehiculoPlanMantenimientoCD obj = new VehiculoPlanMantenimientoCD();

    public VehiculoPlanMantenimientoCE F_TemporalVehiculoPlanMantenimientoDet_Insert(VehiculoPlanMantenimientoCE objEntidadBE)
    {
        try
        {
            return obj.F_TemporalVehiculoPlanMantenimientoDet_Insert(objEntidadBE);
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }

    public DataTable F_TemporalVehiculoPlanMantenimientoDet_Listar(VehiculoPlanMantenimientoCE objEntidadBE)
    {
        try
        {
            return obj.F_TemporalVehiculoPlanMantenimientoDet_Listar(objEntidadBE);
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }

    public DataTable F_TemporalVehiculoPlanMantenimientoDetalle_Insert(VehiculoPlanMantenimientoCE objEntidadBE)
    {
        try
        {
            return obj.F_TemporalVehiculoPlanMantenimientoDetalle_Insert(objEntidadBE);
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }



    public DataTable F_VehiculoPlanMantenimiento_AUDITORIA(VehiculoPlanMantenimientoCE objEntidadBE)
    {
        try
        {
            return obj.F_VehiculoPlanMantenimiento_AUDITORIA(objEntidadBE);
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }
    



    public VehiculoPlanMantenimientoCE F_VehiculoPlanMantenimiento_Insert(VehiculoPlanMantenimientoCE objEntidadBE)
        {
            try
            {

                return obj.F_VehiculoPlanMantenimiento_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



      public VehiculoPlanMantenimientoCE F_VehiculoPlanMantenimiento_Update(VehiculoPlanMantenimientoCE objEntidadBE)
        {
            try
            {

                return obj.F_VehiculoPlanMantenimiento_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }




    public DataTable F_VehiculoPlanMantenimiento_Listar(VehiculoPlanMantenimientoCE objEntidadBE)
    {
        try
        {
            return obj.F_VehiculoPlanMantenimiento_Listar(objEntidadBE);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public VehiculoPlanMantenimientoCE F_VehiculoPlanMantenimiento_ObtenerXID(VehiculoPlanMantenimientoCE objEntidadBE)
        {
            try
            {

                return obj.F_VehiculoPlanMantenimiento_ObtenerXID(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    public VehiculoPlanMantenimientoCE F_VehiculoPlanMantenimiento_Eliminar(VehiculoPlanMantenimientoCE objEntidadBE)
    {
        try
        {

            return obj.F_VehiculoPlanMantenimiento_Eliminar(objEntidadBE);

        }
        catch (Exception ex)
        {

            throw ex;
        }

    }

    
}
