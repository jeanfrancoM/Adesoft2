using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;

namespace CapaNegocios
{
    public class CheckListCN
    {
        CheckListCD obj = new CheckListCD();

         public DataTable F_VehiculoComponentesDetalle_Listar(CheckListCE objEntidadBE)
        {

            try
            {

                return obj.F_VehiculoComponentesDetalle_Listar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


         public CheckListCE F_CheckList_Insert(CheckListCE objEntidadBE)
        {
            try
            {
                return obj.F_CheckList_Insert(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
       }



         public DataTable F_CheckList_Listar(CheckListCE objEntidadBE)
         {

             try
             {

                 return obj.F_CheckList_Listar(objEntidadBE);

             }
             catch (Exception ex)
             {

                 throw ex;
             }

         }

         public DataTable F_CheckList_Reemplazar(CheckListCE objEntidadBE)
         {

             try
             {

                 return obj.F_CheckList_Reemplazar(objEntidadBE);

             }
             catch (Exception ex)
             {

                 throw ex;
             }

         }

         public CheckListCE F_VehiculoCheckListAnular_Eliminar(CheckListCE objEntidadBE)
         {
             try
             {
                 return obj.F_VehiculoCheckListAnular_Eliminar(objEntidadBE);
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }


         public DataTable F_CHECKLIST_VistaPreliminar(CheckListCE objEntidadBE)
         {

             try
             {

                 return obj.F_CHECKLIST_VistaPreliminar(objEntidadBE);

             }
             catch (Exception ex)
             {

                 throw ex;
             }

         }


         public DataTable F_VEHICULOCHECKLIST_OBSERVACION(CheckListCE objEntidadBE)
         {
             try
             {
                 return obj.F_VEHICULOCHECKLIST_OBSERVACION(objEntidadBE);
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }

         public DataTable F_VEHICULOCHECKLIST_AUDITORIA(CheckListCE objEntidadBE)
         {
             try
             {
                 return obj.F_VEHICULOCHECKLIST_AUDITORIA(objEntidadBE);
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }

         public DataTable F_VehiculoCheckListCabDetalleEdicion_Listar(CheckListCE objEntidadBE)
         {

             try
             {

                 return obj.F_VehiculoCheckListCabDetalleEdicion_Listar(objEntidadBE);

             }
             catch (Exception ex)
             {

                 throw ex;
             }

         }



         public DataTable F_CheckListDet_Listar(CheckListCE objEntidadBE)
         {

             try
             {

                 return obj.F_CheckListDet_Listar(objEntidadBE);

             }
             catch (Exception ex)
             {

                 throw ex;
             }

         }


         public CheckListCE F_VehiculoCheckListCab_Validar_CheckListC(CheckListCE objEntidadBE)
        {
            try
            {
                return obj.F_VehiculoCheckListCab_Validar_CheckListC(objEntidadBE);
            }
            catch (Exception ex)
            {
                throw ex;
            }
       }




        

       
        
    }
}
