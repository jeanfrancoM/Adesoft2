using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Services;
using CapaEntidad;
using CapaNegocios;
using System.Data;

namespace SistemaInventario.Servicios
{
    /// <summary>
    /// Descripción breve de DatosTCConceptosDet
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]

    public class DatosTCConceptosDet : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<TCConceptosDetCE> F_TCConceptosDet_Listar(int CodPrincipal)
        {

            List<TCConceptosDetCE> lista = new List<TCConceptosDetCE>();
            TCConceptosDetCE objEntidad = new TCConceptosDetCE();

            try
            {
                objEntidad.CodConcepto = CodPrincipal;
                DataTable table = (new TCConceptosDetCN()).F_TCConceptos_Select(objEntidad);

                
                foreach (DataRow r in table.Rows)
                {
                    TCConceptosDetCE item = new TCConceptosDetCE();
                    item.CodConcepto = Convert.ToInt32(r["CodConcepto"].ToString());
                    item.DscAbvConcepto = r["DscAbvConcepto"].ToString();
                    lista.Add(item);
                }
            }
            catch (Exception ex)
            { }

            return lista;
        }
    }
}
