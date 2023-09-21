using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;
using System.Data.SqlClient;


namespace CapaNegocios
{
    public class LGProductosCN
    {
        LGProductosCD obj = new LGProductosCD();

        public DataTable F_Buscar_Producto_Temporal_Carpeta(LGProductosCE objEntidad)
        {
            return obj.F_Buscar_Producto_Temporal_Carpeta(objEntidad);
        }
        public bool F_AgregarImagen_Carpeta(LGProductosCE objEntidadCE)
        {
            return obj.F_AgregarImagen_Carpeta(objEntidadCE);
        }


        public LGProductosCE F_Eliminar_Producto_Temporal_a_Final(LGProductosCE objEntidadBE)
        {
            try
            {

                return obj.F_Eliminar_Producto_Temporal_a_Final(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGProductos_Select_Ventas(LGProductosCE objEntidadBE)
        {
            try
            {
                return obj.F_LGProductos_Select_Ventas(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_LGProductos_Select_Ventas_Fundidora(LGProductosCE objEntidadBE)
        {
            try
            {
                return obj.F_LGProductos_Select_Ventas_Fundidora(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_LGProductos_Select_Ventas_Povis(LGProductosCE objEntidadBE)
        {

            try
            {

                return obj.F_LGProductos_Select_Ventas_Povis(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGProductos_Select(LGProductosCE objEntidadBE)
        {

            try
            {

                return obj.F_LGProductos_Select(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public bool F_Eliminar_Producto_Temporal_Carpeta(LGProductosCE objEntidadCE)
        {
            return obj.F_Eliminar_Producto_Temporal_Carpeta(objEntidadCE);
        }


        public bool F_Agregar_Producto_Temporal_Carpeta(LGProductosCE objEntidadCE)
        {
            return obj.F_Agregar_Producto_Temporal_Carpeta(objEntidadCE);
        }

        public LGProductosCE F_LGProductos_Insert_Tractos(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {
                LGProductosCE Return = obj.F_LGProductos_Insert_Tractos(objEntidadBE, Tipo, DBHost, DBDataBase, DBUser, DBPass, DBPort);
                if (Return.MsgError == "Se Grabo Correctamente.") obj.Async_F_LGProductos_ActualizarProductos_Azure(objEntidadBE);
                return Return;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public LGProductosCE F_Grabar_Producto_Temporal_a_Final(LGProductosCE objEntidadBE)
        {
            try
            {

                return obj.F_Grabar_Producto_Temporal_a_Final(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public LGProductosCE F_LGProductos_Insert_Async(LGProductosCE objEntidadBE, string Tipo, DataTable dta_tableAlmacenesExternos)
        {
            try
            {
                LGProductosCE Return = obj.F_LGProductos_Insert_Async(objEntidadBE, Tipo, dta_tableAlmacenesExternos);
                return Return;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public LGProductosCE F_LGProductos_Insert(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {
                LGProductosCE Return = obj.F_LGProductos_Insert(objEntidadBE, Tipo, DBHost, DBDataBase, DBUser, DBPass, DBPort);
                if (Return.MsgError == "Se Grabo Correctamente.") obj.Async_F_LGProductos_ActualizarProductos_Azure(objEntidadBE);
                return Return;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //public LGProductosCE F_LGProductosApp_Insert(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        //{
        //    try
        //    {
        //        LGProductosCE Return = obj.F_LGProductosApp_Insert(objEntidadBE, Tipo, DBHost, DBDataBase, DBUser, DBPass, DBPort);
        //        if (Return.MsgError == "Se Grabo Correctamente.") obj.Async_F_LGProductos_ActualizarProductos_Azure(objEntidadBE);
        //        return Return;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //}


        public LGProductosCE F_LGProductos_Insert_Alvarado(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {
                LGProductosCE Return = obj.F_LGProductos_Insert_Alvarado(objEntidadBE, Tipo, DBHost, DBDataBase, DBUser, DBPass, DBPort);
                if (Return.MsgError == "Se Grabo Correctamente.") obj.Async_F_LGProductos_ActualizarProductos_Azure(objEntidadBE);
                return Return;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public LGProductosCE F_LGProductos_Insert_Fundidora(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {
                LGProductosCE Return = obj.F_LGProductos_Insert_Fundidora(objEntidadBE, Tipo, DBHost, DBDataBase, DBUser, DBPass, DBPort);
                if (Return.MsgError == "Se Grabo Correctamente.") obj.Async_F_LGProductos_ActualizarProductos_Azure(objEntidadBE);
                return Return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LGProductosCE F_LGProductos_Update_Fundidora(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {
                LGProductosCE Return = obj.F_LGProductos_Update_Fundidora(objEntidadBE, Tipo, DBHost, DBDataBase, DBUser, DBPass, DBPort);             
                return Return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LGProductosCE F_LGProductos_Insert_Povis(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {
                LGProductosCE Return = obj.F_LGProductos_Insert_Povis(objEntidadBE, Tipo, DBHost, DBDataBase, DBUser, DBPass, DBPort);
                return Return;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public LGProductosCE F_LGProductos_Insert_Yordan(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {
                LGProductosCE Return = obj.F_LGProductos_Insert_Yordan(objEntidadBE, Tipo, DBHost, DBDataBase, DBUser, DBPass, DBPort);
                if (Return.MsgError == "Se Grabo Correctamente.") obj.Async_F_LGProductos_ActualizarProductos_Azure(objEntidadBE);
                return Return;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public LGProductosCE F_LGProductos_Insert_Roman(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {
                LGProductosCE Return = obj.F_LGProductos_Insert_Roman(objEntidadBE, Tipo, DBHost, DBDataBase, DBUser, DBPass, DBPort);
                if (Return.MsgError == "Se Grabo Correctamente.") obj.Async_F_LGProductos_ActualizarProductos_Azure(objEntidadBE);
                return Return;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public LGProductosCE F_LGProductos_Update(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {
                LGProductosCE Return = obj.F_LGProductos_Update(objEntidadBE, Tipo, DBHost, DBDataBase, DBUser, DBPass, DBPort);
                if (Return.MsgError == "Se Actualizo Correctamente.") obj.Async_F_LGProductos_ActualizarProductos_Azure(objEntidadBE);
                return Return;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //public LGProductosCE F_LGProductosApp_Update(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        //{
        //    try
        //    {
        //        LGProductosCE Return = obj.F_LGProductosApp_Update(objEntidadBE, Tipo, DBHost, DBDataBase, DBUser, DBPass, DBPort);
        //        if (Return.MsgError == "Se Actualizo Correctamente.") obj.Async_F_LGProductos_ActualizarProductos_Azure(objEntidadBE);
        //        return Return;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //}

        public LGProductosCE F_LGProductos_Update_Alvarado(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {
                LGProductosCE Return = obj.F_LGProductos_Update_Alvarado(objEntidadBE, Tipo, DBHost, DBDataBase, DBUser, DBPass, DBPort);
                if (Return.MsgError == "Se Actualizo Correctamente.") obj.Async_F_LGProductos_ActualizarProductos_Azure(objEntidadBE);
                return Return;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public LGProductosCE F_LGProductos_Update_Tractos(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {
                LGProductosCE Return = obj.F_LGProductos_Update_Tractos(objEntidadBE, Tipo, DBHost, DBDataBase, DBUser, DBPass, DBPort);
                if (Return.MsgError == "Se Actualizo Correctamente.") obj.Async_F_LGProductos_ActualizarProductos_Azure(objEntidadBE);
                return Return;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public LGProductosCE F_LGProductos_Update_Povis(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {
                LGProductosCE Return = obj.F_LGProductos_Update_Povis(objEntidadBE, Tipo, DBHost, DBDataBase, DBUser, DBPass, DBPort);
                return Return;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public LGProductosCE F_LGProductos_Update_Yordan(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {
                LGProductosCE Return = obj.F_LGProductos_Update_Yordan(objEntidadBE, Tipo, DBHost, DBDataBase, DBUser, DBPass, DBPort);
                if (Return.MsgError == "Se Actualizo Correctamente.") obj.Async_F_LGProductos_ActualizarProductos_Azure(objEntidadBE);
                return Return;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public LGProductosCE F_LGProductos_Update_Roman(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {
                LGProductosCE Return = obj.F_LGProductos_Update_Roman(objEntidadBE, Tipo, DBHost, DBDataBase, DBUser, DBPass, DBPort);
                if (Return.MsgError == "Se Actualizo Correctamente.") obj.Async_F_LGProductos_ActualizarProductos_Azure(objEntidadBE);
                return Return;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        
        public LGProductosCE F_LGProductos_Eliminar(LGProductosCE objEntidadBE)
        {
            try
            {
                LGProductosCE Return = obj.F_LGProductos_Eliminar(objEntidadBE);
                if (Return.MsgError == "El producto se elimino correctamente.") obj.Async_F_LGProductos_ActualizarProductos_Azure(objEntidadBE);
                return Return;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public LGProductosCE F_LGProductos_Activar(LGProductosCE objEntidadBE)
        {
            try
            {
                LGProductosCE Return = obj.F_LGProductos_Activar(objEntidadBE);
                if (Return.MsgError == "El producto se activo correctamente.") obj.Async_F_LGProductos_ActualizarProductos_Azure(objEntidadBE);
                return Return;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGProductos_Listar(LGProductosCE objEntidadBE)
        {
            try
            {
                return obj.F_LGProductos_Listar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_LGProductos_ConsultaMovimiento(LGProductosCE objEntidadBE)
        {

            try
            {

                return obj.F_LGProductos_ConsultaMovimiento(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGProductos_Select_Ajustes(LGProductosCE objEntidadBE)
        {

            try
            {

                return obj.F_LGProductos_Select_Ajustes(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public LGProductosCE F_LGProductos_Ajuste(LGProductosCE objEntidadBE)
        {
            try
            {
                LGProductosCE Return = obj.F_LGProductos_Ajuste(objEntidadBE);
                if (Return.MsgError == "Se Grabo Correctamente") {
                    LGStockAlmacenCN x = new LGStockAlmacenCN();
                    x.Async_F_LGProductos_ActualizarStocks_Lotes_Azure();
                }
                return Return;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGProductos_Inventario_StockActual(LGProductosCE objEntidadBE)
        {
            try
            {
                return obj.F_LGProductos_Inventario_StockActual(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_LGStockAlmacen_Inventario_StockExterno_Listar(LGProductosCE objEntidadBE)
        {
            try
            {

                return obj.F_LGStockAlmacen_Inventario_StockExterno_Listar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        
        public DataTable F_LGProductos_InventarioPeriodo(LGProductosCE objEntidadBE)
        {
            try
            {

                return obj.F_LGProductos_InventarioPeriodo(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGProductos_KardexSunat(LGProductosCE objEntidadBE)
        {
            try
            {

                return obj.F_LGProductos_KardexSunat(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public LGProductosCE F_LGProductosServicios_Update(LGProductosCE objEntidadBE)
        {

            try
            {

                return obj.F_LGProductosServicios_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGProductos_UltimoPrecio(LGProductosCE objEntidadBE, int maxrows)
        {
            try
            {

                return obj.F_LGProductos_UltimoPrecio(objEntidadBE, maxrows);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGProductos_Select_Compras(LGProductosCE objEntidadBE)
        {

            try
            {

                return obj.F_LGProductos_Select_Compras(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGProductos_StockMinimo_Reporte(LGProductosCE objEntidadBE)
        {

            try
            {

                return obj.F_LGProductos_StockMinimo_Reporte(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGProductos_ListarProductosPrecios(LGProductosCE objEntidadBE)
        {
            try
            {
                return obj.F_LGProductos_ListarProductosPrecios(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LGProductosCE F_LGProductos_ActualizarDatos(LGProductosCE objEntidadBE)
        {
            try
            {

                return obj.F_LGProductos_ActualizarDatos(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_Marcas_Listar(int IdFamilia)
        {
            try
            {

                return obj.F_Marcas_Listar(IdFamilia);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool F_AgregarImagen(LGProductosCE objEntidadCE)
        {
            return obj.F_AgregarImagen(objEntidadCE);
        }

        public string F_ConsultarUltimaImagenTemp(out string str_mensaje_operacion)
        {
            return obj.F_ConsultarUltimaImagenTemp(out str_mensaje_operacion);
        }

        public bool F_EliminarImagen_Temporal(int ID_TemporalImagen, out string str_mensaje_operacion)
        {
            return obj.F_EliminarImagen_Temporal(ID_TemporalImagen, out str_mensaje_operacion);
        }

        public bool F_EliminarImagen(int ID_TemporalImagen, out string str_mensaje_operacion)
        {
            return obj.F_EliminarImagen(ID_TemporalImagen, out str_mensaje_operacion);
        }

        public DataTable F_DescargarImagen_CodProducto(LGProductosCE objEntidad)
        {
            return obj.F_DescargarImagen_CodProducto(objEntidad);
        }

        public DataTable F_DescargarDocumento_CP(LGProductosCE objEntidad)
        {
            return obj.F_DescargarDocumento_CP(objEntidad);
        }

        public DataTable F_AbrirImagen_CP(LGProductosCE objEntidadCE)
        {
            return obj.F_AbrirImagen_CP(objEntidadCE);
        }

        public DataTable F_LGProductos_ListarVentas_Descuento(LGProductosCE objEntidadBE)
        {

            try
            {

                return obj.F_LGProductos_ListarVentas_Descuento(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGProductos_UltimoPrecio(LGProductosCE objEntidadBE)
        {
            try
            {

                return obj.F_LGProductos_UltimoPrecio(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGProductos_VerPrecio_Moneda(LGProductosCE objEntidadBE)
        {

            try
            {

                return obj.F_LGProductos_VerPrecio_Moneda(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public LGProductosRelacionesCE F_LGProductosRelaciones_Insert(LGProductosRelacionesCE objEntidad)
        {
            return obj.F_LGProductosRelaciones_Insert(objEntidad);
        }

        public LGProductosRelacionesCE F_LGProductosRelaciones_Eliminar(LGProductosRelacionesCE objEntidad)
        {
            return obj.F_LGProductosRelaciones_Eliminar(objEntidad);
        }

        public DataTable F_LGProductosRelaciones_Listar(LGProductosRelacionesCE objEntidad)
        {
            return obj.F_LGProductosRelaciones_Listar(objEntidad);
        }

        //public DataTable pa_lgProductos_listar_App_update(LGProductosCE objEntidad)
        //{
        //    return obj.pa_lgProductos_listar_App_update(objEntidad);
        //}

        public LGProductosCE Async_F_LGProductos_ActualizarProductos_Azure(LGProductosCE objEntidadBE)
        {
            try
            {
                LGProductosCE Return = obj.Async_F_LGProductos_ActualizarProductos_Azure(objEntidadBE);
                return Return;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public LGProductosCE F_ProductoModelo_Insertar(LGProductosCE objEntidadBE)
        {
            try
            {
                return obj.F_ProductoModelo_Insertar(objEntidadBE);          
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LGProductosCE F_ProductoModelo_Actualizar(LGProductosCE objEntidadBE)
        {
            try
            {
               return obj.F_ProductoModelo_Actualizar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LGProductosCE F_ProductoModelo_Eliminar(LGProductosCE objEntidadBE)
        {
            try
            {
                return obj.F_ProductoModelo_Eliminar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_ProductoModelo_Listado(LGProductosCE objEntidadBE)
        {
            try
            {
                return obj.F_ProductoModelo_Listado(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_LGProductos_ListarServicios(LGProductosCE objEntidadBE)
        {

            try
            {

                return obj.F_LGProductos_ListarServicios(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public LGProductosCE F_LGProductos_Servicios_Insert(LGProductosCE objEntidadBE)
        {
            try
            {

                return obj.F_LGProductos_Servicios_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public LGProductosCE F_LGProductos_Servicios_Update(LGProductosCE objEntidadBE)
        {
            try
            {

                return obj.F_LGProductos_Servicios_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public LGProductosCE F_LGProductos_Eliminar_Servicios(LGProductosCE objEntidadBE)
        {
            try
            {
                return obj.F_LGProductos_Eliminar_Servicios(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LGProductosCE F_LGProductos_ActualizarListaPrecio(LGProductosCE objEntidadBE)
        {
            try
            {
                return obj.F_LGProductos_ActualizarListaPrecio(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LGProductosCE F_LGProductos_NuevaListaPrecio()
        {
            try
            {
                return obj.F_LGProductos_NuevaListaPrecio();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_LGProductos_ListarProductosPrecios_Reporte(LGProductosCE objEntidadBE)
        {
            try
            {
                return obj.F_LGProductos_ListarProductosPrecios_Reporte(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable F_LGProductos_ListarProductosPrecios_Reeim(LGProductosCE objEntidadBE)
        {

            try
            {

                return obj.F_LGProductos_ListarProductosPrecios_Reeim(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGProductos_ListarProductosPrecios_Reeim_Excel(LGProductosCE objEntidadBE)
        {

            try
            {

                return obj.F_LGProductos_ListarProductosPrecios_Reeim_Excel(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable pa_LGStockAlmacen_Inventario_StockActual_Povis_Excel(LGProductosCE objEntidadBE)
        {

            try
            {

                return obj.pa_LGStockAlmacen_Inventario_StockActual_Povis_Excel(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable pa_LGStockAlmacen_Inventario_StockActual_Salcedo_Excel(LGProductosCE objEntidadBE)
        {

            try
            {

                return obj.pa_LGStockAlmacen_Inventario_StockActual_Salcedo_Excel(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGProductos_Inventario_StockActual_Roman(LGProductosCE objEntidadBE)
        {
            try
            {
                return obj.F_LGProductos_Inventario_StockActual_Roman(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Inventario_Unidades_Fisicas(LGProductosCE objEntidadBE)
        {
            try
            {
                return obj.F_Inventario_Unidades_Fisicas(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Inventario_Valorizado(LGProductosCE objEntidadBE)
        {
            try
            {
                return obj.F_Inventario_Valorizado(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_Marcas_Listar_Roman(string codFamilia)
        {
            try
            {

                return obj.F_Marcas_Listar_Roman(codFamilia);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        public DataTable F_LGProductos_HistorialCostos(LGProductosCE objEntidadBE)
        {

            try
            {

                return obj.F_LGProductos_HistorialCostos(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGProductos_HistorialPrecios(LGProductosCE objEntidadBE)
        {

            try
            {

                return obj.F_LGProductos_HistorialPrecios(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGProductos_Auditoria_Listar(LGProductosCE objEntidadBE)
        {

            try
            {

                return obj.F_LGProductos_Auditoria_Listar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGProductos_ListarProductosPrecios_Reporte_KARINA(LGProductosCE objEntidadBE)
        {
            try
            {
                return obj.F_LGProductos_ListarProductosPrecios_Reporte_KARINA(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable F_LGProductos_Presentaciones_Listar(LGProductosCE objEntidadBE)
        {
            try
            {
                return obj.F_LGProductos_Presentaciones_Listar(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public LGProductosPresentacionesCE F_LGProductosPresentaciones_Insert(LGProductosPresentacionesCE objEntidad)
        {
            return obj.F_LGProductosPresentaciones_Insert(objEntidad);
        }

        public LGProductosPresentacionesCE F_LGProductosPresentaciones_Update(LGProductosPresentacionesCE objEntidad)
        {
            return obj.F_LGProductosPresentaciones_Update(objEntidad);
        }

        public LGProductosPresentacionesCE F_LGProductosPresentaciones_Delete(LGProductosPresentacionesCE objEntidad)
        {
            return obj.F_LGProductosPresentaciones_Delete(objEntidad);
        }

        public List<LGProductosPresentacionesCE> F_LGProductosPresentaciones_Listar_UM_Ventas(int CodProducto, int CodMoneda, decimal TC)
        {
            try
            {
                DataTable dt = obj.F_LGProductosPresentaciones_Listar_UM_Ventas(CodProducto, CodMoneda, TC);

                List<LGProductosPresentacionesCE> lista = new List<LGProductosPresentacionesCE>();
                foreach (DataRow r in dt.Rows) {

                    LGProductosPresentacionesCE item = new LGProductosPresentacionesCE();
                    item.CodProducto = CodProducto;
                    item.CodMoneda = CodMoneda;
                    item.CodProductoPresentacion = Convert.ToInt32(r["CodProductoPresentacion"].ToString());
                    item.CodUnidadMedida = Convert.ToInt32(r["CodUnidadMedida"].ToString());
                    item.UnidadMedida = Convert.ToString(r["UnidadMedida"].ToString());
                    item.Factor = Convert.ToDecimal(r["Factor"].ToString());
                    try { item.Precio1 = Convert.ToDecimal(r["Precio1"].ToString()); } catch (Exception) { }
                    try { item.Precio2 = Convert.ToDecimal(r["Precio2"].ToString()); } catch (Exception) { }
                    try { item.Precio3 = Convert.ToDecimal(r["Precio3"].ToString()); } catch (Exception) { }
                    try { item.Precio4 = Convert.ToDecimal(r["Precio4"].ToString()); } catch (Exception) { }
                    try { item.Precio5 = Convert.ToDecimal(r["Precio5"].ToString()); } catch (Exception) { }
                    try { item.Precio6 = Convert.ToDecimal(r["Precio6"].ToString()); } catch (Exception) { }
                    try { item.Precio4 = Convert.ToDecimal(r["Precio4"].ToString()); } catch (Exception) { }
                    try { item.Precio5 = Convert.ToDecimal(r["Precio5"].ToString()); } catch (Exception) { }
                    try { item.Precio6 = Convert.ToDecimal(r["Precio6"].ToString()); } catch (Exception) { }

                    lista.Add(item);
                }


                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_LGProductos_Listar_App(LGProductosCE objEntidadBE)
        {

            try
            {

                return obj.F_LGProductos_Listar_App(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public LGProductosCE F_LGProductos_Update_App(LGProductosCE objEntidadBE)
        {
            try
            {
                LGProductosCE Return = obj.F_LGProductos_Update_App(objEntidadBE);
                return Return;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public DataTable F_LGProductos_Listar_Imagenes(LGProductosCE objEntidadBE)
        {

            try
            {

                return obj.F_LGProductos_Listar_Imagenes(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<LGProductosCE> F_MarcaProducto_listar(int CodEstado, int FlagActivo)
        {
            try
            {
                DataTable dtDatos = obj.F_MarcaProducto_listar(CodEstado);
                List<LGProductosCE> lDatos = new List<LGProductosCE>();

                if (FlagActivo == 0)
                    lDatos.Add(new LGProductosCE()
                    {
                        CodMarcaProducto = 0,
                        DescripcionMarcaProducto = "--SELECCIONE MARCA--",

                    });
                foreach (DataRow r in dtDatos.Rows)
                {
                    lDatos.Add(new LGProductosCE()
                    {
                        CodMarcaProducto = Convert.ToInt32(r["CodMarcaProducto"].ToString()),
                        DescripcionMarcaProducto = r["DescripcionMarcaProducto"].ToString(),
                    });
                }

                return lDatos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable F_ListarMarca_AutoComplete(LGProductosCE objEntidad)
        {
            try
            {

                return obj.F_ListarMarca_AutoComplete(objEntidad);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public DataTable F_PRODUCTO_OBSERVACION(LGProductosCE objEntidad)
        {
            try
            {
                return obj.F_PRODUCTO_OBSERVACION(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable P_Permiso_Mayorista(LGProductosCE objEntidadBE)
        {

            try
            {

                return obj.P_Permiso_Mayorista(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public LGProductosCE F_LGProductos_Insert_Salcedo(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {
                LGProductosCE Return = obj.F_LGProductos_Insert_Salcedo(objEntidadBE, Tipo, DBHost, DBDataBase, DBUser, DBPass, DBPort);
                if (Return.MsgError == "Se Grabo Correctamente.") obj.Async_F_LGProductos_ActualizarProductos_Azure(objEntidadBE);
                return Return;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public LGProductosCE F_LGProductos_Update_Salcedo(LGProductosCE objEntidadBE, string Tipo, string DBHost, string DBDataBase, string DBUser, string DBPass, string DBPort)
        {
            try
            {
                LGProductosCE Return = obj.F_LGProductos_Update_Salcedo(objEntidadBE, Tipo, DBHost, DBDataBase, DBUser, DBPass, DBPort);
                if (Return.MsgError == "Se Actualizo Correctamente.") obj.Async_F_LGProductos_ActualizarProductos_Azure(objEntidadBE);
                return Return;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        public DataTable F_LGProductos_HistorialMargenes(LGProductosCE objEntidadBE)
        {

            try
            {

                return obj.F_LGProductos_HistorialMargenes(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DataTable F_LGProductos_HistorialCosto(LGProductosCE objEntidadBE)
        {

            try
            {

                return obj.F_LGProductos_HistorialCosto(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public DataTable F_LGProductos_Select_Ventas_Fundicion(LGProductosCE objEntidadBE)
        {

            try
            {

                return obj.F_LGProductos_Select_Ventas_Fundicion(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public object F_LGProductos_Select_Ventas_Salcedo(LGProductosCE objEntidad)
        {
            try
            {
                return obj.F_LGProductos_Select_Ventas_Salcedo(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable F_LGProductos_Select_MantenimientoPlan(LGProductosCE objEntidadBE)
        {
            try
            {
                return obj.F_LGProductos_Select_MantenimientoPlan(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
