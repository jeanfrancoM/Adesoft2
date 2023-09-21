using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;

namespace CapaNegocios
{
   public class TCDistritoCN
    {
       TCDistritoCD obj = new TCDistritoCD();

       public DataTable F_Distrito_Autocomplete(TCDistritoCE objEntidadBE)
        {
            try
            {

                return obj.F_Distrito_Autocomplete(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

       public DataTable F_TCDireccion_Listar(TCDistritoCE objEntidadBE)
       {
           try
           {

               return obj.F_TCDireccion_Listar(objEntidadBE);

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public DataTable F_TCDistrito_Listar(TCDistritoCE objEntidadBE)
       {
           try
           {

               return obj.F_TCDistrito_Listar(objEntidadBE);

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public DataTable F_TCDireccion_ListarXCodDistrito(TCDistritoCE objEntidadBE)
       {
           try
           {

               return obj.F_TCDireccion_ListarXCodDistrito(objEntidadBE);

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public DataTable F_TCDireccion_ListarXCodCtaCte(TCDistritoCE objEntidadBE)
       {
           try
           {

               return obj.F_TCDireccion_ListarXCodCtaCte(objEntidadBE);

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public TCDistritoCE F_TCDireccion_Agregar(TCDistritoCE objEntidadBE)
       {
           try
           {
               return obj.F_TCDireccion_Agregar(objEntidadBE);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public TCDistritoCE F_TCDireccion_Editar(TCDistritoCE objEntidadBE)
       {
           try
           {
               return obj.F_TCDireccion_Editar(objEntidadBE);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public TCDistritoCE F_TCDireccion_Editar_Pymes(TCDistritoCE objEntidadBE)
       {
           try
           {
               return obj.F_TCDireccion_Editar_Pymes(objEntidadBE);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public TCDistritoCE F_TCDireccion_Eliminar(TCDistritoCE objEntidadBE)
       {
           try
           {
               return obj.F_TCDireccion_Eliminar(objEntidadBE);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataTable F_TCDireccion_ListarXCodDistrito_AutoComplete(TCDistritoCE objEntidadBE)
       {
           try
           {

               return obj.F_TCDireccion_ListarXCodDistrito_AutoComplete(objEntidadBE);

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public DataTable F_TCDireccion_ListarXCliente_AutoComplete(TCDistritoCE objEntidadBE)
       {
           try
           {

               return obj.F_TCDireccion_ListarXCliente_AutoComplete(objEntidadBE);

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public DataTable F_TCDistrito_ListarXCodDistrito(TCDistritoCE objEntidadBE)
       {
           try
           {

               return obj.F_TCDistrito_ListarXCodDistrito(objEntidadBE);

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public DataTable F_TCDireccion_ListarXCodCtaCte_AutoComplete(TCDistritoCE objEntidadBE)
       {
           try
           {

               return obj.F_TCDireccion_ListarXCodCtaCte_AutoComplete(objEntidadBE);

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public DataTable F_TCDireccion_ListarCorreosXCodDireccion(int CodDireccion)
       {
           try
           {

               return obj.F_TCDireccion_ListarCorreosXCodDireccion(CodDireccion);

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public bool F_TCDireccion_ActivarDesactivar(int CodDireccion, int CodEstado, out string Mensaje)
       {
           try
           {
               return obj.F_TCDireccion_ActivarDesactivar(CodDireccion, CodEstado, out Mensaje);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public bool F_ElegirPrincipalDireccion(int CodDireccion, out string Mensaje)
       {
           try
           {
               return obj.F_ElegirPrincipalDireccion(CodDireccion, out Mensaje);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }


       public DataTable F_API_RUC_Buscar(int CodEmpresa)
       {
           try
           {

               return obj.F_API_RUC_Buscar(CodEmpresa);

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }






       public DataTable F_Direccion_Buscar(TCDistritoCE objEntidad)
       {
           try
           {

               return obj.F_Direccion_Buscar(objEntidad);

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }


       public bool F_TCContacto_ActivarDesactivar(int CodContacto, int CodEstado, out string Mensaje)
       {
           try
           {
               return obj.F_TCContacto_ActivarDesactivar(CodContacto, CodEstado, out Mensaje);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataTable F_TCDireccion_ListarXCliente_AutoComplete_Conexion(TCDistritoCE objEntidadBE)
       {
           try
           {

               return obj.F_TCDireccion_ListarXCliente_AutoComplete_Conexion(objEntidadBE);

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

    }
}
