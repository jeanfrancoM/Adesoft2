using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;

namespace CapaNegocios
{
    public class TipoOperacionesCN
    {
        TipoOperacionesCD obj = new TipoOperacionesCD();

        public DataTable F_Motivo_Traslado_Listar()
        {

            try
            {

                return obj.F_Motivo_Traslado_Listar();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
