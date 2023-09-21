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
    /// Summary description for AutoComplete
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]

    public class Graficos : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public grafico F_ReporteVentasPorPeriodo(string xAbscisas, string yOrdenadas,
            string Desde, string Hasta, int CodMoneda, int TipoReporte, int CodAlmacen, string xmlFamilias, string xmlMarcas)
        {
            //BUSQUEDA DE DATOS
            //----------------------------------------------------------
            DocumentoVentaCabCE objEntidad = new DocumentoVentaCabCE();
            DocumentoVentaCabCN objOperacion = new DocumentoVentaCabCN();

            //filtros
            objEntidad.DesdeInt = Convert.ToInt32(Convert.ToDateTime(Desde).ToString("yyyyMMdd"));
            objEntidad.HastaInt = Convert.ToInt32(Convert.ToDateTime(Hasta).ToString("yyyyMMdd"));
            objEntidad.CodMoneda = CodMoneda;
            objEntidad.TipoReporte = TipoReporte;
            objEntidad.CodAlmacen = CodAlmacen;

            //filtros de combos multiples
            objEntidad.xmlFamilias = "<R><XmlLC> </XmlLC></R>";
            objEntidad.xmlMarcas = "<R><XmlLC> </XmlLC></R>";

            DataTable dtTabla = objOperacion.F_DocumentoVentaCab_VentasDocumentos_Periodo_Grafico(objEntidad);
            HttpContext.Current.Session["dtGrafico"] = dtTabla;

            //ARMADO DE DATOS PARA EL GRAFICO
            //----------------------------------------------------------
            return F_DataGrafico(dtTabla, xAbscisas, yOrdenadas);
        }





























        // ---------------------------------------------------------------------------------------------------------
        // ---------------------------------------------------------------------------------------------------------
        // FUNCION QUE DEVUELVE LA ESTRUCTURA PARA LLENAR EL GRAFICO EN EL JQUERY
        // SE LE PASA UNA TABLA BIDIMENSIONAL Y SE DEBE ESPECIFICAR EL EJE X (ABSCISAS) ADEMAS DEL EJE Y (ORDENADAS)
        // ---------------------------------------------------------------------------------------------------------
        // ---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// FUNCION QUE DEVUELVE LA ESTRUCTURA PARA LLENAR EL GRAFICO EN EL JQUERY
        /// SE LE PASA UNA TABLA BIDIMENSIONAL Y SE DEBE ESPECIFICAR EL EJE X (ABSCISAS) ADEMAS DEL EJE Y (ORDENADAS)
        /// </summary>
        /// <param name="dtTabla">DataTable Bidimencional, con dos columnas y n rows</param>
        /// <param name="xAbscisas">Nombre de la columna que será el eje X</param>
        /// <param name="yOrdenadas">Nombre de las columnas que serán el eje Y [SEPARADO POR COMAS (,)]</param>
        /// <returns></returns>
        public grafico F_DataGrafico(DataTable dtTabla, string xAbscisas, string yOrdenadas)
        {
            string[] yOrdenadasArr = yOrdenadas.Split(',');


            //Armo Listas
            //----------------------------------------------------------------------------------
            List<dataGrafico> lData = new List<dataGrafico>();
            foreach (DataRow r in dtTabla.Rows)
            {
                dataGrafico data = new dataGrafico();
                foreach (DataColumn c in dtTabla.Columns)
                {

                    //Eje X
                    if (c.ColumnName.ToUpper().Trim() == xAbscisas.ToUpper().Trim())
                    {
                        data.X = r[c.ColumnName].ToString();

                        //pregunta si es numerico
                        //en caso de que sea numerico
                        //da formato a Mon-YY si lo amerita
                        if (char.IsNumber(data.X, data.X.Length - 1))
                            data.X = Utilitarios.OtrasFunciones.F_PeriodoFormatoText(data.X);

                        data.Ys = new List<yOrdenadas>();
                    }

                    foreach (string Y in yOrdenadasArr)
                    {
                        string columname = c.ColumnName.ToUpper().Trim();
                        string yordenada = Y.ToUpper().Trim();
                        if (c.ColumnName.ToUpper().Trim() == Y.ToUpper().Trim())
                        {
                            yOrdenadas Yord = new yOrdenadas();
                            Yord.Titulo = Y.Trim();
                            Yord.Valor = r[c.ColumnName].ToString();

                            ////pregunta si es formato decimal para darle formato decimal
                            //if (dtTabla.Columns[c.ColumnName].DataType == typeof(decimal))
                            //    Yord.Valor = Convert.ToDecimal(Yord.Valor).ToString("###,###,###,##0.00");

                            data.Ys.Add(Yord);
                        }
                    }
                }
                lData.Add(data);
            }
            //----------------------------------------------------------------------------------
            List<Keys> yKeys = new List<Keys>();
            foreach (string Y in yOrdenadasArr)
            {
                yKeys.Add(new Keys()
                {
                    Key = Y
                });
            }

            List<Keys> Labels = new List<Keys>();
            foreach (string Y in yOrdenadasArr)
            {
                Labels.Add(new Keys()
                {
                    Key = Y
                });
            }

            grafico grafico = new grafico();
            grafico.data = lData;
            grafico.yKeys = yKeys;
            grafico.Labels = Labels;

            return grafico;
        }
        public class grafico {
            public virtual List<dataGrafico> data { get; set; }
            public virtual List<Keys> yKeys { get; set; }
            public virtual List<Keys> Labels { get; set; }
        }
        public class dataGrafico
        {
            public string X { get; set; }
            public virtual List<yOrdenadas> Ys { get; set; }
        }
        public class yOrdenadas
        {
            public string Titulo { get; set; }
            public string Valor { get; set; }
        }
        public class Keys
        {
            public string Key { get; set; }
        }
        // ---------------------------------------------------------------------------------------------------------
    }
}
