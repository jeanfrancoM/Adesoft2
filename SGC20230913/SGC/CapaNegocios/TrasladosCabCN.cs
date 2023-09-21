using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;

namespace CapaNegocios
{
  public class TrasladosCabCN
    {
        TrasladosCabCD obj = new TrasladosCabCD();

        public DataTable F_TrasladosCab_Impresion(TrasladosCabCE objEntidadBE)
        {
            try
            {
                return obj.F_TrasladosCab_Impresion(objEntidadBE);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TrasladosCab_Impresion_Electronica(TrasladosCabCE objEntidadBE)
        {
            try
            {
                return obj.F_TrasladosCab_Impresion_Electronica(objEntidadBE);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TrasladosCab_Impresion_Factura(TrasladosCabCE objEntidadBE)
        {
            try
            {
                return obj.F_TrasladosCab_Impresion_Factura(objEntidadBE);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TrasladosCabCE F_TrasladosCab_GuiaInterna_Insert(TrasladosCabCE objEntidadBE)
        {

            try
            {

                return obj.F_TrasladosCab_GuiaInterna_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TrasladosCab_Listar_GuiaInterna(TrasladosCabCE objEntidadBE)
        {

            try
            {

                return obj.F_TrasladosCab_Listar_GuiaInterna(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TrasladosCabCE F_TrasladosCab_Insert(TrasladosCabCE objEntidadBE)
        {
            try
            {

                return obj.F_TrasladosCab_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TrasladosCab_Listar(TrasladosCabCE objEntidadBE)
        {
            try
            {

                return obj.F_TrasladosCab_Listar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TrasladosCabCE F_TrasladosCab_Anulacion(TrasladosCabCE objEntidadBE)
        {
            try
            {
                return obj.F_TrasladosCab_Anulacion(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TrasladosCabCE F_TrasladosCab_Eliminacion(TrasladosCabCE objEntidadBE)
        {
            try
            {
                return obj.F_TrasladosCab_Eliminacion(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TrasladosCabCE F_TrasladosCab_Eliminacion_Inventario(TrasladosCabCE objEntidadBE)
        {
            try
            {
                return obj.F_TrasladosCab_Eliminacion_Inventario(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TrasladosCabCE F_TrasladosCab_Devolucion(TrasladosCabCE objEntidadBE)
        {
            try
            {
                return obj.F_TrasladosCab_Devolucion(objEntidadBE);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable F_TrasladosCab_FacturarGuia(TrasladosCabCE objEntidadBE)
        {
            try
            {

                return obj.F_TrasladosCab_FacturarGuia(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
      
        public TrasladosCabCE F_Transferencias_Insert(TrasladosCabCE objEntidadBE)
        {
            try
            {

                return obj.F_Transferencias_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TrasladosCabCE F_Transferencias_Insert_Alvarado(TrasladosCabCE objEntidadBE)
        {
            try
            {

                return obj.F_Transferencias_Insert_Alvarado(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_TrasladosCab_Reemplazar(TrasladosCabCE objEntidadBE)
        {

            try
            {

                return obj.F_TrasladosCab_Reemplazar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
      
        public DataTable F_GUIAREMISION_OBSERVACION(TrasladosCabCE objEntidadBE)
        {

            try
            {
                return obj.F_GUIAREMISION_OBSERVACION(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable F_GUIAREMISION_AUDITORIA(TrasladosCabCE objEntidadBE)
        {
            try
            {
                return obj.F_GUIAREMISION_AUDITORIA(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public TrasladosCabCE F_Transferencias_Insert_Salcedo(TrasladosCabCE objEntidadBE)
        {
            try
            {

                return obj.F_Transferencias_Insert_Salcedo(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TrasladosCabCE F_TrasladosCab_Insert_Salcedo(TrasladosCabCE objEntidadBE)
        {
            try
            {

                return obj.F_TrasladosCab_Insert_Salcedo(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TrasladosCabCE F_TrasladosCab_Abrir(TrasladosCabCE objEntidadBE)
        {

            try
            {

                return obj.F_TrasladosCab_Abrir(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public TrasladosCabCE F_TrasladosCab_ObtenerXNumero(TrasladosCabCE objEntidad)
        {

            try
            {
                DataTable dtDatos = obj.F_TrasladosCab_ObtenerXNumero(objEntidad);
                if (dtDatos.Rows.Count > 0)
                {
                    try
                    {
                        foreach (DataRow i in dtDatos.Rows)
                        {
                            objEntidad.CodTraslado = int.Parse(i["CodTraslado"].ToString());
                            objEntidad.SerieDoc = i["SerieDoc"].ToString();
                            objEntidad.NumeroDoc = i["NumeroDoc"].ToString();
                            objEntidad.FechaEmision = DateTime.Parse(i["Emision"].ToString());
                            objEntidad.EmisionStr = objEntidad.FechaEmision.ToString();
                            objEntidad.Vencimiento = DateTime.Parse(i["Vencimiento"].ToString());
                            objEntidad.VencimientoStr = objEntidad.Vencimiento.ToString();
                            objEntidad.Observacion2 = i["Observacion2"].ToString();


                            objEntidad.ltrasladosDet = new List<TrasladosCabCE>();
                            dtDatos = (new TrasladosCabCN()).F_TrasladosCab_ListarXCodigo(objEntidad);
                            if (dtDatos.Rows.Count > 0)
                            {
                                foreach (DataRow r in dtDatos.Rows)
                                {
                                    objEntidad.ltrasladosDet.Add(new TrasladosCabCE()
                                    {

                                        CodTraslado = int.Parse(r["CodTraslado"].ToString()),
                                        CodProducto = int.Parse(r["CodArticulo"].ToString()),
                                        Cantidad = int.Parse(r["Cantidad"].ToString()),
                                        Descripcion = r["Descripcion"].ToString(),
                                        CodUnidadVenta = int.Parse(r["CodUnidadVenta"].ToString()),
                                        CodigoInterno = r["CodigoInterno"].ToString(),
                                    });
                                }
                            }
                            else
                            {
                                objEntidad.Observacion2 = "NO SE ENCONTRO NINGUNA DETALLE DE LA NOTA DE INGRESO";
                            };

                        }
                    }

                    catch (Exception ex)
                    {
                        objEntidad.Observacion2 = "NO SE ENCONTRO NINGUNA 1";
                    }

                    finally
                    {
                    }
                }
                else
                {
                    objEntidad.Observacion2 = "NO SE ENCONTRO NINGUNA CABECERA DE LA NOTA DE INGRESO";
                };
                return objEntidad;

            }
            catch (Exception ex)
            {
                objEntidad.MsgError = ex.ToString();
                objEntidad.Observacion2 = ex.ToString();
                throw ex;
            }

        }


        public DataTable F_TrasladosCab_ListarXCodigo(TrasladosCabCE objEntidad)
        {

            try
            {

                return obj.F_TrasladosCab_ListarXCodigo(objEntidad);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
