using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;
using System.Data;

namespace CapaNegocios
{
    public class TCEmpresaCN
    {
        TCEmpresaCD obj = new TCEmpresaCD();


        public TCEmpresaCE F_TCEmpresa_Insert(TCEmpresaCE objEntidadBE)
        {
            try
            {

                return obj.F_TCEmpresa_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public TCEmpresaCE F_TCEmpresa_Update(TCEmpresaCE objEntidadBE)
        {
            try
            {

                return obj.F_TCEmpresa_Update(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public bool F_AgregarImagen(TCEmpresaCE objEntidadCE)
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

        public DataTable F_DescargarImagen_CodEmpresa(TCEmpresaCE objEntidad)
        {
            return obj.F_DescargarImagen_CodEmpresa(objEntidad);
        }

        public DataTable F_AbrirImagen_CP(TCEmpresaCE objEntidadCE)
        {
            return obj.F_AbrirImagen_CP(objEntidadCE);
        }

        
        public DataTable Listar()
        {
            DataTable dta_consulta = null;
            dta_consulta = obj.Listar();
            return dta_consulta;
        }

        public DataTable F_TCEmpresa_Listar(TCEmpresaCE objEntidadBE)
        {

            try
            {

                return obj.F_TCEmpresa_Listar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public DataTable F_ParametrosSistemas_Listar(string Parametro, int CodigoMenu, int CodigoInterno)
        {
            DataTable dta_consulta = null;
            dta_consulta = obj.F_ParametrosSistemas_Listar(Parametro, CodigoMenu, CodigoInterno);
            return dta_consulta;
        }

        public DataTable F_ParametrosPagina(int CodigoModulo, int CodigoInterno)
        {
            DataTable dta_consulta = null;
            dta_consulta = obj.F_ParametrosPagina(CodigoModulo, CodigoInterno);
            return dta_consulta;
        }



        public string RutaFacturadorPorCodEmpresa(int CodEmpresa) {
            string Ruta = "";

            try {
                Ruta = obj.F_RutaFacturadorPorCodEmpresa(CodEmpresa).Rows[0][0].ToString();
            }
            catch (Exception ex) { }

            return Ruta;
        }


        public DataTable F_DatosDocumento_Descarga(int CodDocumentoVenta)
        {

            try
            {

                return obj.F_DatosDocumento_Descarga(CodDocumentoVenta);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }




        public TCEmpresaCE F_Firma_Insert(TCEmpresaCE objEntidadBE)
        {
            try
            {

                return obj.F_Firma_Insert(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }




        public DataTable F_tipodoc_Select(TCEmpresaCE objEntidad)
        {

            try
            {

                return obj.F_tipodoc_Select(objEntidad);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
