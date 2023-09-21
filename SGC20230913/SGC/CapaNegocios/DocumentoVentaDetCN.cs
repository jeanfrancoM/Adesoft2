using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;

namespace CapaNegocios
{
    public class DocumentoVentaDetCN
    {
        DocumentoVentaDetCD obj = new DocumentoVentaDetCD();

        public DocumentoVentaDetCE F_TemporalFacturacionDet_Eliminar(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {
                return obj.F_TemporalFacturacionDet_Eliminar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaDetCE F_TemporalFacturacionDetPedido_Eliminar(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {
                return obj.F_TemporalFacturacionDetPedido_Eliminar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_DocumentoVentaDet_Listar(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {
                return obj.F_DocumentoVentaDet_Listar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

         public DataTable F_DocumentoVentaDet_Listar_Alvarado(DocumentoVentaDetCE objEntidadBE)
        {

            try
            {

                return obj.F_DocumentoVentaDet_Listar_Alvarado(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_ProformaDet_ListarDetNI(DocumentoVentaDetCE objEntidadBE)
        {
            
            try
            {
                return obj.F_ProformaDet_ListarDetNI(objEntidadBE);
            }
            catch (Exception ex)
            {

                throw ex;

            }

            

        }

        public DocumentoVentaDetCE F_TemporalCodigoFacturaDet_Eliminar(DocumentoVentaDetCE objEntidadBE)
        {

            try
            {

                return obj.F_TemporalCodigoFacturaDet_Eliminar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_DocumentoVentaCab_RetencionDetalle(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {

                return obj.F_DocumentoVentaCab_RetencionDetalle(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_DocumentoVentaDet_Select_NV(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {

                return obj.F_DocumentoVentaDet_Select_NV(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DocumentoVentaDetCE F_TemporalSerializacionDet_Eliminar(DocumentoVentaDetCE objEntidadBE)
        {

            try
            {

                return obj.F_TemporalSerializacionDet_Eliminar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TemporalFacturacionSerializacionDet_Listar(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {

                return obj.F_TemporalFacturacionSerializacionDet_Listar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DocumentoVentaDetCE F_TemporalFacturacionDet_Update(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {
                return obj.F_TemporalFacturacionDet_Update(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaDetCE F_TemporalFacturacionDetPedido_Update(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {
                return obj.F_TemporalFacturacionDetPedido_Update(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaDetCE F_TemporalFacturacionDet_Update_Yordan(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {
                return obj.F_TemporalFacturacionDet_Update_Yordan(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaDetCE F_TemporalFacturacionDet_UpdateSolicitudDescuento_Yordan(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {
                return obj.F_TemporalFacturacionDet_UpdateSolicitudDescuento_Yordan(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaDetCE F_TemporalFacturacionDet_Update_Roman(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {
                return obj.F_TemporalFacturacionDet_Update_Roman(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaDetCE F_ACTUALIZAR_MONTO_MONEDA(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {
                return obj.F_ACTUALIZAR_MONTO_MONEDA(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaDetCE F_FlagGratuito_Update(DocumentoVentaDetCE objEntidadBE)
        {

            try
            {

                return obj.F_FlagGratuito_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DocumentoVentaDetCE F_TemporalFacturacionDet_Update_Actualizaciones(DocumentoVentaDetCE objEntidadBE)
        {

            try
            {

                return obj.F_TemporalFacturacionDet_Update_Actualizaciones(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DocumentoVentaDetCE F_TemporalFacturacionSerializacionDet_Eliminar(DocumentoVentaDetCE objEntidadBE)
        {

            try
            {

                return obj.F_TemporalFacturacionSerializacionDet_Eliminar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_CobranzasDet_Listar(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {

                return obj.F_CobranzasDet_Listar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_CobranzasDet_Eliminar_Listar(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {

                return obj.F_CobranzasDet_Eliminar_Listar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_PagosDet_Listar(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {

                return obj.F_PagosDet_Listar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DocumentoVentaDetCE F_TemporalFacturacionDet_Editar(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {

                return obj.F_TemporalFacturacionDet_Editar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_DocumentoVentaSerializacionDet_Listar(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {
                return obj.F_DocumentoVentaSerializacionDet_Listar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaDetCE F_TemporalFacturacionDet_Actualizar(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {
                return obj.F_TemporalFacturacionDet_Actualizar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
        public DocumentoVentaDetCE F_TemporalCodigoFacturaDet_Update(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {
                return obj.F_TemporalCodigoFacturaDet_Update(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable F_DOCUMENTOVENTACAB_KARDEX(DocumentoVentaCabCE objEntidadBE)
        {
            try
            {
                return obj.F_DOCUMENTOVENTACAB_KARDEX(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_LGPRODUCTOS_STOCKDETALLE(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {
                return obj.F_LGPRODUCTOS_STOCKDETALLE(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_PROFORMACAB_OBSERVACION(DocumentoVentaCabCE objEntidadBE)
        {
            try
            {
                return obj.F_PROFORMACAB_OBSERVACION(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaDetCE F_TemporalFacturacionDet_Actualizar_TIEMPO(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {
                return obj.F_TemporalFacturacionDet_Actualizar_TIEMPO(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_ComprobanteCajaDet_LISTAR(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {
                return obj.F_ComprobanteCajaDet_LISTAR(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_COBRANZASCAB_OBSERVACION(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {
                return obj.F_COBRANZASCAB_OBSERVACION(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //observacion eliminacion
        public DataTable F_COBRANZASCAB_ELIMINADOS_OBSERVACION(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {
                return obj.F_COBRANZASCAB_ELIMINADOS_OBSERVACION(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //auditoria

        public DataTable F_COBRANZASCAB_AUDITORIA(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {
                return obj.F_COBRANZASCAB_AUDITORIA(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_PAGOSCAB_AUDITORIA(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {
                return obj.F_PAGOSCAB_AUDITORIA(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_PAGOSCAB_OBSERVACION(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {
                return obj.F_PAGOSCAB_OBSERVACION(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_ProformaDet_Listar(DocumentoVentaDetCE objEntidadBE)
        {

            try
            {

                return obj.F_ProformaDet_Listar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_DOCUMENTOVENTACAB_LISTAR_COBRANZAS_DETALLADO(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {

                return obj.F_DOCUMENTOVENTACAB_LISTAR_COBRANZAS_DETALLADO(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_DOCUMENTOVENTACAB_OBSERVACION(DocumentoVentaCabCE objEntidadBE)
        {
            try
            {

                return obj.F_DOCUMENTOVENTACAB_OBSERVACION(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_DOCUMENTOVENTACAB_OBSERVACIONCLEVER(DocumentoVentaCabCE objEntidadBE)
        {
            try
            {

                return obj.F_DOCUMENTOVENTACAB_OBSERVACIONCLEVER(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_PROFORMACAB_OBSERVACIONCLEVER(DocumentoVentaCabCE objEntidadBE)
        {
            try
            {

                return obj.F_PROFORMACAB_OBSERVACIONCLEVER(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DocumentoVentaDetCE F_TemporalFacturacionDetallado_Eliminar(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {
                return obj.F_TemporalFacturacionDetallado_Eliminar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaDetCE F_TemporalFacturacionDet_ACTUALIZAR_DESCUENTO(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {
                return obj.F_TemporalFacturacionDet_ACTUALIZAR_DESCUENTO(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_CobranzasCab_ELIMINADOS_AUDITORIA(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {
                return obj.F_CobranzasCab_ELIMINADOS_AUDITORIA(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_COBRANZASCAB_Eliminadas_OBSERVACIONes(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {
                return obj.F_COBRANZASCAB_Eliminadas_OBSERVACIONes(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaDetCE F_TemporalFacturacionDet_Actualizar_Gratuito(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {
                return obj.F_TemporalFacturacionDet_Actualizar_Gratuito(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_DOCUMENTOVENTACAB_AUDITORIA(DocumentoVentaCabCE objEntidadBE)
        {
            try
            {

                return obj.F_DOCUMENTOVENTACAB_AUDITORIA(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_PagosDet_Eliminar_Listar(DocumentoVentaDetCE objEntidadBE)
        {            
            try
            {
                return obj.F_PagosDet_Eliminar_Listar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public DataTable F_PAGOSCAB_ELIMINADOS_OBSERVACION(DocumentoVentaDetCE objEntidadBE)
        {

            try
            {
                return obj.F_PAGOSCAB_ELIMINADOS_OBSERVACION(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable F_ProformaDet_Listar_ROMAN(DocumentoVentaDetCE objEntidadBE)
        {

            try
            {
                return obj.F_ProformaDet_Listar_ROMAN(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable F_CAJACHICADet_Listar(DocumentoVentaDetCE objEntidad)
        {

            try
            {

                return obj.F_CAJACHICADet_Listar(objEntidad);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LIQUIDACION_OBSERVACION(DocumentoVentaCabCE objEntidadBE)
        {
            try
            {

                return obj.F_LIQUIDACION_OBSERVACION(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_CAJACHICADet_Listar_liquidacion(DocumentoVentaDetCE objEntidad)
        {

            try
            {

                return obj.F_CAJACHICADet_Listar_liquidacion(objEntidad);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DocumentoVentaDetCE F_TemporalFacturacionDet_UpdatexKilo(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {
                return obj.F_TemporalFacturacionDet_UpdatexKilo(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_DocumentoVentaDet_Devolucion_Listar(DocumentoVentaDetCE objEntidadBE)
        {

            try
            {

                return obj.F_DocumentoVentaDet_Devolucion_Listar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DocumentoVentaDetCE F_DevolucionAgregar(DocumentoVentaDetCE objEntidadBE)
        {
            try
            {
                return obj.F_DevolucionAgregar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaDetCE F_TemporalFacturacionDet_Update_Salcedo(DocumentoVentaDetCE objEntidad)
        {
            try
            {
                return obj.F_TemporalFacturacionDet_Update_Salcedo(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentoVentaDetCE F_TemporalFacturacionDet_Actualizar_Salcedo(DocumentoVentaDetCE objEntidad)
        {
            try
            {
                return obj.F_TemporalFacturacionDet_Actualizar_Salcedo(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataTable F_CobranzasDet_ComisionTarjeta(Cobranzas objEntidadBE)
        {

            try
            {

                return obj.F_CobranzasDet_ComisionTarjeta(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
