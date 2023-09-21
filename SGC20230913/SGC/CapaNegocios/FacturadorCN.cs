using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;


namespace CapaNegocios
{
  public  class FacturadorCN
    {
      FacturadorCD obj = new FacturadorCD();

      public DataTable PA_INTERFACE_LISTAR_EMPRESAS()
      {

          try
          {

              return obj.PA_INTERFACE_LISTAR_EMPRESAS();

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public DataTable PA_INTERFACE_LISTA_DOCUMENTOS(FacturadorCE objEntidadBE)
      {
          try
          {
              return obj.PA_INTERFACE_LISTA_DOCUMENTOS(objEntidadBE);
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

    }
}
