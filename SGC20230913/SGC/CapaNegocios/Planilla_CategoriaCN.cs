using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;


namespace CapaNegocios
{
    public class Planilla_CategoriaCN
    {

        Planilla_CategoriaCD obj = new Planilla_CategoriaCD();


        public DataTable F_Planilla_Categoria_Listar(Planilla_CategoriaCE objEntidad)
        {
            try
            {
                return obj.F_Planilla_Categoria_Listar(objEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Planilla_CategoriaCE F_Planilla_Categoria_Insert(Planilla_CategoriaCE objEntidadBE)
        {
            try
            {

                return obj.F_Planilla_Categoria_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Planilla_CategoriaCE F_Planilla_Categoria_Update(Planilla_CategoriaCE objEntidadBE)
        {
            try
            {

                return obj.F_Planilla_Categoria_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Planilla_CategoriaCE F_Planilla_Categoria_Eliminar(Planilla_CategoriaCE objEntidadBE)
        {
            try
            {

                return obj.F_Planilla_Categoria_Eliminar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
