using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;
namespace CapaNegocios
{
  public  class MovimientosCN
    {
      MovimientosCD obj = new MovimientosCD();

      public DataTable F_Movimientos_Kardex(MovimientosCE objEntidadBE)
        {
            try
            {
                return obj.F_Movimientos_Kardex(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


      public MovimientosCE F_Movimientos_Kardex_SaldoInicial_Modificar(MovimientosCE objEntidadBE)
      {
          try
          {
              return obj.F_Movimientos_Kardex_SaldoInicial_Modificar(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }

      }
      public MovimientosCE F_Movimientos_Kardex_InicialAjuste_Modificar(MovimientosCE objEntidadBE)
      {
          try
          {
              return obj.F_Movimientos_Kardex_InicialAjuste_Modificar(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }

      }
      public DataTable F_Movimientos_Kardex_Auditoria(MovimientosCE objEntidadBE)
      {
          try
          {
              return obj.F_Movimientos_Kardex_Auditoria(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }

      }

      //salcedo

      public DataTable F_Movimientos_Kardex_Salcedo(MovimientosCE objEntidadBE)
      {
          try
          {
              return obj.F_Movimientos_Kardex(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }

      }

      public MovimientosCE F_Movimientos_Kardex_SaldoInicial_Modificar_Salcedo(MovimientosCE objEntidadBE)
      {
          try
          {
              return obj.F_Movimientos_Kardex_SaldoInicial_Modificar_Salcedo(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }

      }


      public DataTable F_Movimientos_Kardex_Auditoria_Salcedo(MovimientosCE objEntidadBE)
      {
          try
          {
              return obj.F_Movimientos_Kardex_Auditoria(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }

      }

      public MovimientosCE F_Movimientos_Kardex_InicialAjuste_Modificar_Salcedo(MovimientosCE objEntidadBE)
      {
          try
          {
              return obj.F_Movimientos_Kardex_InicialAjuste_Modificar_Salcedo(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }

      }





    }
}
