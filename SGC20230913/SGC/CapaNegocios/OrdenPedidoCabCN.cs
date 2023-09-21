using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;
namespace CapaNegocios
{

    public class OrdenPedidoCabCN
    {
        OrdenPedidoCabCD obj = new OrdenPedidoCabCD();

        public OrdenPedidoCabCE F_OrdenPedidos_Insert(OrdenPedidoCabCE objEntidadBE)
        {
            try
            {

                return obj.F_OrdenPedidos_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public OrdenPedidoCabCE F_OrdenPedidos_Insert_Karina(OrdenPedidoCabCE objEntidadBE)
        {
            try
            {

                return obj.F_OrdenPedidos_Insert_Karina(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public OrdenPedidoCabCE F_OrdenPedidos_Insert_Alvarado(OrdenPedidoCabCE objEntidadBE)
        {
            try
            {

                return obj.F_OrdenPedidos_Insert_Alvarado(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public OrdenPedidoCabCE F_OrdenPedidos_Insert_Povis(OrdenPedidoCabCE objEntidadBE)
        {
            try
            {

                return obj.F_OrdenPedidos_Insert_Povis(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public OrdenPedidoCabCE F_OrdenPedidos_Insert_Roman(OrdenPedidoCabCE objEntidadBE)
        {
            try
            {

                return obj.F_OrdenPedidos_Insert_Roman(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public OrdenPedidoCabCE F_OrdenPedidos_Insert_Edicion(OrdenPedidoCabCE objEntidadBE)
        {
            try
            {

                return obj.F_OrdenPedidos_Insert_Edicion(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public OrdenPedidoCabCE F_OrdenPedidos_Insert_Edicion_Karina(OrdenPedidoCabCE objEntidadBE)
        {
            try
            {

                return obj.F_OrdenPedidos_Insert_Edicion_Karina(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public OrdenPedidoCabCE F_OrdenPedidos_Insert_Edicion_Alvarado(OrdenPedidoCabCE objEntidadBE)
        {
            try
            {

                return obj.F_OrdenPedidos_Insert_Edicion_Alvarado(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public OrdenPedidoCabCE F_OrdenPedidos_Insert_Edicion_Povis(OrdenPedidoCabCE objEntidadBE)
        {
            try
            {

                return obj.F_OrdenPedidos_Insert_Edicion_Povis(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public OrdenPedidoCabCE F_OrdenPedidos_Insert_Edicion_Roman(OrdenPedidoCabCE objEntidadBE)
        {
            try
            {

                return obj.F_OrdenPedidos_Insert_Edicion_Roman(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public OrdenPedidoCabCE F_OrdenPedidos_Eliminar(OrdenPedidoCabCE objEntidadBE)
        {
            try
            {

                return obj.F_OrdenPedidos_Eliminar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public OrdenPedidoCabCE F_OrdenPedidos_Anulacion(OrdenPedidoCabCE objEntidadBE)
        {
            try
            {

                return obj.F_OrdenPedidos_Anulacion(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_OrdenPedidoCab_VistaPreliminar(OrdenPedidoCabCE objEntidadBE)
        {

            try
            {

                return obj.F_OrdenPedidoCab_VistaPreliminar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_OrdenPedidoCab_Select(OrdenPedidoCabCE objEntidadBE)
        {

            try
            {

                return obj.F_OrdenPedidoCab_Select(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_OrdenPedidoCab_Select_Detalle(OrdenPedidoCabCE objEntidadBE)
        {

            try
            {

                return obj.F_OrdenPedidoCab_Select_Detalle(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<OrdenPedidoCabCE> F_OrdenPedidoCab_ListarXEstado(OrdenPedidoCabCE objEntidadBE)
        {

            List<OrdenPedidoCabCE> lOrdenPedidoCab = new List<OrdenPedidoCabCE>();

            try
            {
                DataTable dtDatos = obj.F_OrdenPedidoCab_ListarXEstado(objEntidadBE);
                foreach (DataRow i in dtDatos.Rows)
                {
                    OrdenPedidoCabCE newpr = new OrdenPedidoCabCE()
                    {
                        CodOrdenPedido = int.Parse(i["CodOrdenPedido"].ToString()),
                        Serie = i["SerieDoc"].ToString(),
                        Numero = i["NumeroDoc"].ToString(),
                        NroRuc = i["NroRuc"].ToString(),
                        Cliente = i["Cliente"].ToString(),
                        Vendedor = i["Vendedor"].ToString(),

                        FechaEmision = DateTime.Parse(i["Emision"].ToString()),
                        EmisionStr = i["Emision"].ToString(),
                        Vencimiento = DateTime.Parse(i["Vencimiento"].ToString()),
                        VencimientoStr = i["Vencimiento"].ToString(),
                        CodCtaCte = int.Parse(i["CodCtaCte"].ToString()),
                        CodFormaPago = int.Parse(i["CodFormaPago"].ToString()),
                        CodMoneda = int.Parse(i["CodMoneda"].ToString()),
                        TipoCambio = decimal.Parse(i["TC"].ToString()),
                        SubTotal = decimal.Parse(i["SubTotal"].ToString()),
                        Igv = decimal.Parse(i["Igv"].ToString()),
                        Total = decimal.Parse(i["Total"].ToString()),
                        COTIZACIONES_HOY = int.Parse(i["COTIZACIONES_HOY"].ToString()),
                        FlagVisibleFacturacion = int.Parse(i["FlagVisibleFacturacion"].ToString()),
                        CodDepartamento = int.Parse(i["CodDepartamento"].ToString()),
                        CodProvincia = int.Parse(i["CodProvincia"].ToString()),
                        CodDistrito = int.Parse(i["CodDistrito"].ToString()),
                        Distrito = i["Distrito"].ToString(),
                        Direccion = i["Direccion"].ToString(),
                        FlagIgv = int.Parse(i["FlagCSIgv"].ToString()),
                        NroOperacion = i["NroOperacion"].ToString(),
                        CodEmpleado = int.Parse(i["CodEmpleado"].ToString()),
                        Placa = i["Placa"].ToString(),
                        KM = i["KM"].ToString(),
                    };
                    lOrdenPedidoCab.Add(newpr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lOrdenPedidoCab;
        }

        public OrdenPedidoCabCE F_OrdenPedidoCab_ObtenerXNumero(OrdenPedidoCabCE objEntidadBE)
        {

            try
            {
                DataTable dtDatos = obj.F_OrdenPedidoCab_ObtenerXNumero(objEntidadBE);
                try
                {
                    foreach (DataRow i in dtDatos.Rows)
                    {
                        objEntidadBE.CodOrdenPedido = int.Parse(i["CodOrdenPedido"].ToString());
                        objEntidadBE.Serie = i["SerieDoc"].ToString();
                        objEntidadBE.Numero = i["NumeroDoc"].ToString();
                        objEntidadBE.NroRuc = i["NroRuc"].ToString();
                        objEntidadBE.Cliente = i["Cliente"].ToString();
                        objEntidadBE.Vendedor = i["Vendedor"].ToString();
                        objEntidadBE.FechaEmision = DateTime.Parse(i["Emision"].ToString());
                        objEntidadBE.EmisionStr = i["Emision"].ToString();
                        objEntidadBE.Vencimiento = DateTime.Parse(i["Vencimiento"].ToString());
                        objEntidadBE.VencimientoStr = objEntidadBE.Vencimiento.ToString();
                        objEntidadBE.CodCtaCte = int.Parse(i["CodCtaCte"].ToString());
                        objEntidadBE.CodFormaPago = int.Parse(i["CodFormaPago"].ToString());
                        objEntidadBE.CodMoneda = int.Parse(i["CodMoneda"].ToString());
                        objEntidadBE.TipoCambio = decimal.Parse(i["TC"].ToString());
                        objEntidadBE.SubTotal = decimal.Parse(i["SubTotal"].ToString());
                        objEntidadBE.Igv = decimal.Parse(i["Igv"].ToString());
                        objEntidadBE.Total = decimal.Parse(i["Total"].ToString());
                        objEntidadBE.COTIZACIONES_HOY = int.Parse(i["COTIZACIONES_HOY"].ToString());
                        objEntidadBE.FlagVisibleFacturacion = int.Parse(i["FlagVisibleFacturacion"].ToString());
                        objEntidadBE.NroRuc = i["NroRuc"].ToString();
                        objEntidadBE.Cliente = i["Cliente"].ToString();
                        objEntidadBE.CodDireccion = int.Parse(i["CodDireccion"].ToString());
                        objEntidadBE.CodDepartamento = int.Parse(i["CodDepartamento"].ToString());
                        objEntidadBE.CodProvincia = int.Parse(i["CodProvincia"].ToString());
                        objEntidadBE.CodDistrito = int.Parse(i["CodDistrito"].ToString());
                        objEntidadBE.Distrito = i["Distrito"].ToString();
                        objEntidadBE.Direccion = i["Direccion"].ToString();
                        objEntidadBE.FlagIgv = int.Parse(i["FlagCSIgv"].ToString());
                        objEntidadBE.NroOperacion = i["NroOperacion"].ToString();
                        objEntidadBE.CodEmpleado = int.Parse(i["CodEmpleado"].ToString());
                        objEntidadBE.Placa = i["Placa"].ToString();
                        objEntidadBE.KM = i["KM"].ToString();
                        objEntidadBE.FlagComisionable = int.Parse(i["FlagComisionable"].ToString());
                        objEntidadBE.CodCategoria = int.Parse(i["CodCategoria"].ToString());
                        objEntidadBE.NombreComercial = i["NombreComercial"].ToString();
                        objEntidadBE.CodTipoDoc = int.Parse(i["CodTipoDoc"].ToString());
                        objEntidadBE.lOrdenPedidoDet = new List<OrdenPedidoDetCE>();
                        dtDatos = (new OrdenPedidoCabCN()).F_OrdenPedidoDet_ListarXCodigo(objEntidadBE);
                        foreach (DataRow r in dtDatos.Rows)
                        {
                            objEntidadBE.lOrdenPedidoDet.Add(new OrdenPedidoDetCE()
                            {
                                CodDetalleOrdenPedido = int.Parse(r["CodDetalleOrdenPedido"].ToString()),
                                CodOrdenPedido = int.Parse(r["CodOrdenPedido"].ToString()),
                                CodArticulo = int.Parse(r["CodArticulo"].ToString()),
                                Cantidad = decimal.Parse(r["Cantidad"].ToString()),
                                CantidadEntregada = decimal.Parse(r["CantidadEntregada"].ToString()),
                                Precio = decimal.Parse(r["Precio"].ToString()),
                                PrecioOriginal = decimal.Parse(r["PrecioOriginal"].ToString()),
                                ValorVenta = decimal.Parse(r["ValorVenta"].ToString()),
                                Descripcion = r["Descripcion"].ToString(),
                                CodUnidadMedida = int.Parse(r["CodUnidadVenta"].ToString()),
                                Descuento = decimal.Parse(r["Descuento"].ToString()),
                                Comentario = r["Comentario"].ToString(),
                                CodTiempoProducto = int.Parse(r["CodTiempoProducto"].ToString()),
                                TiempoProducto = r["TiempoProducto"].ToString(),
                                CodProductoPresentacion = int.Parse(r["CodProductoPresentacion"].ToString()),
                                DescuentoPorcMax = decimal.Parse(r["DescuentoPorcMax"].ToString()),
                                Material = r["Material"].ToString(),
                                PEstimado = decimal.Parse(r["PEstimado"].ToString()),
                                PxKilo = decimal.Parse(r["PxKilo"].ToString())
                            });
                        }
                    }
                }
                catch (Exception ex)
                { }
                finally
                { }

                return objEntidadBE;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public OrdenPedidoCabCE F_OrdenPedidoCab_ObtenerXID(OrdenPedidoCabCE objEntidadBE)
        {
            try
            {
                DataTable dtDatos = obj.F_OrdenPedidoCab_ObtenerXID(objEntidadBE);
                try
                {
                    foreach (DataRow i in dtDatos.Rows)
                    {
                        objEntidadBE.CodOrdenPedido = int.Parse(i["CodOrdenPedido"].ToString());
                        objEntidadBE.Serie = i["SerieDoc"].ToString();
                        objEntidadBE.Numero = i["NumeroDoc"].ToString();
                        objEntidadBE.NroRuc = i["NroRuc"].ToString();
                        objEntidadBE.Cliente = i["Cliente"].ToString();
                        objEntidadBE.Vendedor = i["Vendedor"].ToString();
                        objEntidadBE.FechaEmision = DateTime.Parse(i["Emision"].ToString());
                        objEntidadBE.EmisionStr = objEntidadBE.FechaEmision.ToString("dd/MM/yyyy");
                        objEntidadBE.Vencimiento = DateTime.Parse(i["Vencimiento"].ToString());
                        objEntidadBE.VencimientoStr = objEntidadBE.Vencimiento.ToString("dd/MM/yyyy");
                        objEntidadBE.CodCtaCte = int.Parse(i["CodCtaCte"].ToString());
                        objEntidadBE.CodFormaPago = int.Parse(i["CodFormaPago"].ToString());
                        objEntidadBE.CodMoneda = int.Parse(i["CodMoneda"].ToString());
                        objEntidadBE.TipoCambio = decimal.Parse(i["TC"].ToString());
                        objEntidadBE.SubTotal = decimal.Parse(i["SubTotal"].ToString());
                        objEntidadBE.Igv = decimal.Parse(i["Igv"].ToString());
                        objEntidadBE.Total = decimal.Parse(i["Total"].ToString());
                        objEntidadBE.COTIZACIONES_HOY = int.Parse(i["COTIZACIONES_HOY"].ToString());
                        objEntidadBE.FlagVisibleFacturacion = int.Parse(i["FlagVisibleFacturacion"].ToString());
                        objEntidadBE.NroRuc = i["NroRuc"].ToString();
                        objEntidadBE.Cliente = i["Cliente"].ToString();
                        objEntidadBE.CodDireccion = int.Parse(i["CodDireccion"].ToString());
                        objEntidadBE.CodDepartamento = int.Parse(i["CodDepartamento"].ToString());
                        objEntidadBE.CodProvincia = int.Parse(i["CodProvincia"].ToString());
                        objEntidadBE.CodDistrito = int.Parse(i["CodDistrito"].ToString());
                        objEntidadBE.Distrito = i["Distrito"].ToString();
                        objEntidadBE.Direccion = i["Direccion"].ToString();
                        objEntidadBE.FlagIgv = int.Parse(i["FlagCSIgv"].ToString());
                        objEntidadBE.NroOperacion = i["NroOperacion"].ToString();
                        objEntidadBE.CodEmpleado = int.Parse(i["CodEmpleado"].ToString());
                        objEntidadBE.Placa = i["Placa"].ToString();
                        objEntidadBE.KM = i["KM"].ToString();
                        objEntidadBE.FlagConCodigo = Convert.ToInt32(i["FlagConCodigo"]);
                        objEntidadBE.Observacion = i["Observacion"].ToString();
                        objEntidadBE.Atencion = i["Atencion"].ToString();
                        objEntidadBE.Referencia = i["Referencia"].ToString();
                        objEntidadBE.TiempoEntrega = i["TiempoEntrega"].ToString();
                        objEntidadBE.LugarEntrega = i["LugarEntrega"].ToString();
                        objEntidadBE.CorreoAtencion = i["CorreoAtencion"].ToString();
                        objEntidadBE.FlagComisionable = int.Parse(i["FlagComisionable"].ToString());                        
                        objEntidadBE.CodTipoDoc = Convert.ToInt32(i["CodTipoDoc"].ToString());
                        objEntidadBE.NombreComercial = i["NombreComercial"].ToString();
                        objEntidadBE.CodCategoria = int.Parse(i["CodCategoria"].ToString());
                        objEntidadBE.lOrdenPedidoDet = new List<OrdenPedidoDetCE>();
                        dtDatos = (new OrdenPedidoCabCN()).F_OrdenPedidoDet_ListarXCodigo(objEntidadBE);
                        foreach (DataRow r in dtDatos.Rows)
                        {
                            objEntidadBE.lOrdenPedidoDet.Add(new OrdenPedidoDetCE()
                            {
                                CodDetalleOrdenPedido = int.Parse(r["CodDetalleOrdenPedido"].ToString()),
                                CodOrdenPedido = int.Parse(r["CodOrdenPedido"].ToString()),
                                CodArticulo = int.Parse(r["CodArticulo"].ToString()),
                                Cantidad = decimal.Parse(r["Cantidad"].ToString()),
                                Precio = decimal.Parse(r["Precio"].ToString()),
                                ValorVenta = decimal.Parse(r["ValorVenta"].ToString()),
                                Descripcion = r["Descripcion"].ToString(),
                                CodUnidadMedida = int.Parse(r["CodUnidadVenta"].ToString()),
                                Descuento = decimal.Parse(r["Descuento"].ToString()),
                                Comentario = r["Comentario"].ToString(),
                                CodTiempoProducto = int.Parse(r["CodTiempoProducto"].ToString()),
                                CodProductoPresentacion = int.Parse(r["CodProductoPresentacion"].ToString()),
                                TiempoProducto = r["TiempoProducto"].ToString()         
                            });
                        }
                    }
                }
                catch (Exception ex)
                { }
                finally
                { }

                return objEntidadBE;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        
        public DataTable F_OrdenPedidoCab_ListarXCodigo(OrdenPedidoCabCE objEntidadBE)
        {

            try
            {

                return obj.F_OrdenPedidoCab_ListarXCodigo(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_OrdenPedidoDet_ListarXCodigo(OrdenPedidoCabCE objEntidadBE)
        {

            try
            {

                return obj.F_OrdenPedidoDet_ListarXCodigo(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        
        public OrdenPedidoCabCE F_OrdenPedidoDet_InsertTemporal(OrdenPedidoCabCE objEntidadBE)
        {
            try
            {

                return obj.F_OrdenPedidoDet_InsertTemporal(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public OrdenPedidoCabCE F_OrdenPedidoCabActivacion(OrdenPedidoCabCE objEntidadBE)
        {
            try
            {

                return obj.F_OrdenPedidoCabActivacion(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_OrdenPedidoCab_VistaPreliminar_Despacho(OrdenPedidoCabCE objEntidadBE)
        {

            try
            {

                return obj.F_OrdenPedidoCab_VistaPreliminar_Despacho(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        
        public OrdenPedidoCabCE F_OrdenPedidoCab_Insert(OrdenPedidoCabCE objEntidadBE)
        {
            try
            {

                return obj.F_OrdenPedidoCab_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public OrdenPedidoCabCE F_OrdenPedidoCab_Insert_Edicion(OrdenPedidoCabCE objEntidadBE)
        {
            try
            {

                return obj.F_OrdenPedidoCab_Insert_Edicion(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public OrdenPedidoCabCE F_OrdenPedidoCab_Anulacion(OrdenPedidoCabCE objEntidadBE)
        {
            try
            {

                return obj.F_OrdenPedidoCab_Anulacion(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_OrdenPedidoCab_VistaPreliminar2(OrdenPedidoCabCE objEntidadBE)
        {
            try
            {
                return obj.F_OrdenPedidoCab_VistaPreliminar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_OrdenPedidoCab_Select2(OrdenPedidoCabCE objEntidadBE)
        {
            try
            {
                return obj.F_OrdenPedidoCab_Select(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_OrdenPedidoDet_Select_Detalle(OrdenPedidoCabCE objEntidadBE)
        {
            try
            {
                return obj.F_OrdenPedidoDet_Select_Detalle(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OrdenPedidoCabCE F_OrdenPedido_Aprobacion(int CodOrdenPedido, string Observacion, int CodUsuario)
        {
            try
            {
                return obj.F_OrdenPedido_Aprobacion(CodOrdenPedido, Observacion, CodUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OrdenPedidoCabCE F_OrdenPedidos_Insert_Edicion_Fundicion(OrdenPedidoCabCE objEntidadBE)
        {
            try
            {

                return obj.F_OrdenPedidos_Insert_Edicion_Fundicion(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public OrdenPedidoCabCE F_OrdenPedidos_InsertFundicion(OrdenPedidoCabCE objEntidadBE)
        {
            try
            {

                return obj.F_OrdenPedidos_InsertFundicion(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }









        public object F_Auditoria(OrdenPedidoCabCE objEntidad)
        {
            try
            {

                return obj.F_Auditoria(objEntidad);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public object F_OBSERVACION(OrdenPedidoCabCE objEntidad)
        {
            try
            {

                return obj.F_OBSERVACION(objEntidad);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
