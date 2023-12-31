﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class FormatoImpresionCN
    {
        FormatoImpresionCD obj = new FormatoImpresionCD();

        public DataTable F_FormatoImpresion_Listar_X_CodTipoDoc(FormatoImpresionCE objEntidad)
        {
            return obj.F_FormatoImpresion_Listar_X_CodTipoDoc(objEntidad);
        }


        public FormatoImpresionCE F_FormatoImpresion_Listar_X_CodFormatoImpresion(int CodFormatoImpresion)
        {


            DataTable datos = (new FormatoImpresionCD()).F_FormatoImpresion_Listar_X_CodFormatoImpresion(CodFormatoImpresion);
            FormatoImpresionCE p = new FormatoImpresionCE();

            foreach (DataRow r in datos.Rows)
            {
                p.Formato = r["Formato"].ToString();
                p.CodFormatoImpresion = Convert.ToInt32(r["CodFormatoImpresion"].ToString());
                p.CodTipoDoc = Convert.ToInt32(r["CodTipoDoc"].ToString());
                p.SerieDoc = r["SerieDoc"].ToString();
                p.NombreArchivo = r["NombreArchivo"].ToString();
                p.Impresora = r["Impresora"].ToString();
                p.DataTable = r["DataTable"].ToString();
                p.NroCopias = Convert.ToInt32(r["NroCopias"].ToString());
                p.FlagDefecto = Convert.ToInt32(r["FlagDefecto"].ToString());
            }
            return p;

        }

        //public DataTable F_FormatoImpresion_Listar_X_CodTipoDoc(FormatoImpresionCE objEntidad)
        //{
        //    DataTable datos = obj.F_FormatoImpresion_Listar_X_CodTipoDoc(objEntidad);

        //    return datos;
        //}


        public FormatoImpresionCE F_GrabarFormatoImpresion(FormatoImpresionCE objEntidad)
        {
            objEntidad = obj.F_GrabarFormatoImpresion(objEntidad);

            return objEntidad;
        }

        public DataTable F_Buscar(FormatoImpresionCE objEntidadBE)
        {
            try
            {

                return obj.F_Buscar(objEntidadBE);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public FormatoImpresionCE F_EditarFormatoImpresion(FormatoImpresionCE objEntidad)
        {
            objEntidad = obj.F_EditarFormatoImpresion(objEntidad);

            return objEntidad;
        }

        public FormatoImpresionCE F_ObtenerFormatoImpresion(int CodFormatoImpresion)
        {
            FormatoImpresionCE cDatos = new FormatoImpresionCE();
            try
            {
                DataTable dtDatos = obj.F_ObtenerFormatoImpresion(CodFormatoImpresion);
                foreach (DataRow r in dtDatos.Rows)
                {
                    cDatos = new FormatoImpresionCE()
                    {
                        CodFormatoImpresion = Convert.ToInt32(r["CODIGO"].ToString().Trim()),
                        CodDoc = Convert.ToInt32(r["DOCUMENTO"].ToString().Trim()),
                        codTipoFormato = Convert.ToInt32(r["FORMATO"].ToString().Trim()),
                        SerieDoc = r["SERIE"].ToString().Trim(),
                        NombreArchivo = r["NombreArchivo"].ToString().Trim(),
                        Impresora = r["Impresora"].ToString().Trim(),
                        Datatable = r["Datatable"].ToString().Trim(),
                        NroItem = Convert.ToInt32(r["ITEM"].ToString().Trim()),
                        CodEstado = Convert.ToInt32(r["CODESTADO"].ToString().Trim()),
                        FlagDefecto = Convert.ToInt32(r["FlagDefecto"].ToString().Trim()),


                        MsgError = ""
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return cDatos;
        }



        public FormatoImpresionCE F_EliminaFormatoImpresion(FormatoImpresionCE objEntidad)
        {
            try
            {

                return obj.F_EliminaFormatoImpresion(objEntidad);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<FormatoImpresionCE> F_TipoFormato_Listar(int CodEstado, int FlagActivo)
        {
            try
            {
                DataTable dtDatos = obj.F_TipoFormato_Listar(CodEstado);
                List<FormatoImpresionCE> lDatos = new List<FormatoImpresionCE>();

                if (FlagActivo == 0)
                    lDatos.Add(new FormatoImpresionCE()
                    {
                        CodConcepto = 0,
                        Formato = "--SELECCIONE FORMATO--",
                        AbvConcepto = " ",
                        Estado = "A",
                    });

                foreach (DataRow r in dtDatos.Rows)
                {
                    lDatos.Add(new FormatoImpresionCE()
                    {
                        CodConcepto = Convert.ToInt32(r["CodConcepto"].ToString()),
                        Formato = r["Formato"].ToString(),
                        AbvConcepto = r["AbvConcepto"].ToString(),
                        Estado = r["Estado"].ToString(),
                    });
                }

                return lDatos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<FormatoImpresionCE> F_TipoDocumento_Listar(int CodEstado, int FlagActivo)
        {
            try
            {
                DataTable dtDatos = obj.F_TipoDocumento_Listar(CodEstado);
                List<FormatoImpresionCE> lDatos = new List<FormatoImpresionCE>();

                if (FlagActivo == 0)
                    lDatos.Add(new FormatoImpresionCE()
                    {
                        CodDoc = 0,
                        Documento = "-- TODOS --",
                        AbvDdsc = "",
                        Estado = "1",
                    });

                foreach (DataRow r in dtDatos.Rows)
                {
                    lDatos.Add(new FormatoImpresionCE()
                    {
                        CodDoc = Convert.ToInt32(r["CodTipoDoc"].ToString()),
                        Documento = r["Documento"].ToString(),
                        AbvDdsc = r["AbvDdsc"].ToString(),
                        Estado = r["CodEstado"].ToString(),
                    });
                }

                return lDatos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }





        
    }
}
