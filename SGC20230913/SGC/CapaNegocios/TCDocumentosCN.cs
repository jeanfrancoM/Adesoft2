﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;


namespace CapaNegocios
{
  public  class TCDocumentosCN
    {
      TCDocumentosCD obj = new TCDocumentosCD();

      public DataTable F_TCDocumentos_ListarCompras()
      {

          try
          {

              return obj.F_TCDocumentos_ListarCompras();

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public DataTable F_TCDocumentos_ListarVentas()
      {

          try
          {

              return obj.F_TCDocumentos_ListarVentas();

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public DataTable F_TCDocumentos_ComprobanteEgreso()
      {

          try
          {

              return obj.F_TCDocumentos_ComprobanteEgreso();

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public TCDocumentosCE F_TCDocumentos_Anulacion(TCDocumentosCE objEntidad)
      {

          try
          {

              return obj.F_TCDocumentos_Anulacion(objEntidad);

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public DataTable F_TCDocumentos_ListarVentas_FacturaBoleta()
      {
          try
          {
              return obj.F_TCDocumentos_ListarVentas_FacturaBoleta();
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_TCDocumentos_ListarFacturacion()
      {

          try
          {

              return obj.F_TCDocumentos_ListarFacturacion();

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public DataTable F_TCEmpresa_Listar()
      {

          try
          {

              return obj.F_TCEmpresa_Listar();

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public DataTable F_TCDocumentos_Ingresos()
      {
          try
          {
              return obj.F_TCDocumentos_Ingresos();
          }
          catch (Exception ex)
          {
              throw ex;
          }
      }

      public DataTable F_TIPOOPERACION_KARDEX()
      {
          try
          {
              return obj.F_TIPOOPERACION_KARDEX();

          }
          catch (Exception ex)
          {
              throw ex;
          }

      }

      public DataTable F_TCEMPRESA_LISTAR_COMBO()
      {
          try
          {
              return obj.F_TCEMPRESA_LISTAR_COMBO();
          }
          catch (Exception ex)
          {
              throw ex;
          }

      }

      public DataTable F_TCDocumentos_ListarCompras_OC_NP()
      {

          try
          {

              return obj.F_TCDocumentos_ListarCompras_OC_NP();

          }
          catch (Exception ex)
          {

              throw ex;
          }

      }

      public DataTable F_TCDOCUMENTOS_COBRANZAS_PAGOS()
      {
          try
          {
              return obj.F_TCDOCUMENTOS_COBRANZAS_PAGOS();
          }
          catch (Exception ex)
          {
              throw ex;
          }

      }
    }
}
