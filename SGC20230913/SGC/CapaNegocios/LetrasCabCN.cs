using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;

namespace CapaNegocios
{
   public class LetrasCabCN
    {
       LetrasCabCD obj = new LetrasCabCD();

       public LetrasCabCE F_LetraCab_Insert(LetrasCabCE objEntidadBE)
       {

           try
           {

               return obj.F_LetraCab_Insert(objEntidadBE);

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public LetrasCabCE F_TemporalLetraCab_Insert(LetrasCabCE objEntidadBE)
        {

            try
            {

                return obj.F_TemporalLetraCab_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

       public DataTable F_TemporalLetraCab_Listar(LetrasCabCE objEntidadBE)
       {

           try
           {

               return obj.F_TemporalLetraCab_Listar(objEntidadBE);

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public LetrasCabCE F_TemporalLetra_Eliminar(LetrasCabCE objEntidadBE)
       {

           try
           {

               return obj.F_TemporalLetra_Eliminar(objEntidadBE);

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public DataTable F_LetraCab_Select(LetrasCabCE objEntidadBE)
       {
        try
           {

               return obj.F_LetraCab_Select(objEntidadBE);

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public LetrasCabCE F_Anulacion_Letras(LetrasCabCE objEntidadBE)
       {
           try
           {

               return obj.F_Anulacion_Letras(objEntidadBE);

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public DataTable F_LetrasCab_ConsultaPagos(LetrasCabCE objEntidadBE)
       {
           try
           {

               return obj.F_LetrasCab_ConsultaPagos(objEntidadBE);

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public LetrasCabCE F_LETRASCAB_CODIGOUNICO(LetrasCabCE objEntidadBE)
       {
           try
           {
               return obj.F_LETRASCAB_CODIGOUNICO(objEntidadBE);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public LetrasCabCE F_TemporalLetraCab_UPDATE(LetrasCabCE objEntidadBE)
       {

           try
           {

               return obj.F_TemporalLetraCab_UPDATE(objEntidadBE);

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }


       public LetrasCabCE F_Eliminacion_Letras(LetrasCabCE objEntidadBE)
       {
           try
           {
               return obj.F_Eliminacion_Letras(objEntidadBE);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataTable F_LetrasCab_Listar_Documentos1(LetrasCabCE objEntidadBE)
       {

           try
           {

               return obj.F_LetrasCab_Listar_Documentos1(objEntidadBE);

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public DataTable F_LetrasCab_Listar_Documentos2(LetrasCabCE objEntidadBE)
       {

           try
           {

               return obj.F_LetrasCab_Listar_Documentos2(objEntidadBE);

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public DataTable F_LetraCab_Imprimir(LetrasCabCE objEntidadBE)
       {

           try
           {

               return obj.F_LetraCab_Imprimir(objEntidadBE);

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }



       public DataTable F_LetraCab_Select_Eliminados(LetrasCabCE objEntidadBE)
       {
           try
           {

               return obj.F_LetraCab_Select_Eliminados(objEntidadBE);

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }

       public DataTable F_LetrasDet_Eliminar_Listar(LetrasCabCE objEntidad)
       {
           try
           {

               return obj.F_LetrasDet_Eliminar_Listar(objEntidad);

           }
           catch (Exception ex)
           {

               throw ex;
           }

       }


       //observacion eliminacion
       public DataTable F_LETRASCAB_ELIMINADOS_OBSERVACION(LetrasCabCE objEntidadBE)
       {
           try
           {
               return obj.F_LETRASCAB_ELIMINADOS_OBSERVACION(objEntidadBE);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public object F_LetrasCAB_Eliminadas_OBSERVACIONes(LetrasCabCE objEntidad)
       {
           try
           {
               return obj.F_LetrasCAB_Eliminadas_OBSERVACIONes(objEntidad);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataTable F_LetraCab_ELIMINADOS_AUDITORIA(LetrasCabCE objEntidadBE)
       {
           try
           {
               return obj.F_LetraCab_ELIMINADOS_AUDITORIA(objEntidadBE);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataTable F_LetraCab_AUDITORIA(LetrasCabCE objEntidadBE)
       {
           try
           {
               return obj.F_LetraCab_AUDITORIA(objEntidadBE);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
    }
}
