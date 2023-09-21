using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocios;
using EasyCallback;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using SistemaInventario.Clases;

namespace SistemaInventario.Planilla
{
    public partial class SalarioEmpleado : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            CallbackManager.Register(F_ValidarUsuario_NET);
            CallbackManager.Register(F_ExportarDetalle_NET);
            CallbackManager.Register(F_EspecificarValores_NET);
        }

        private string _menu = "3000"; private string _opcion = "6";
        protected void Page_Load(object sender, EventArgs e)
        {
            String Menu = Request.QueryString["Mn"]; String Opcion = Request.QueryString["Op"];
            Utilitarios.Menu.EstablecerPermisos(int.Parse(Session["CodUsuario"].ToString()));
            Utilitarios.Menu.ModificarAccesos((System.Web.UI.WebControls.Menu)Master.FindControl("NavigationMenu"), Convert.ToInt32((Session["CodUsuario"])));
        }

        protected void grvDetalleArticulo_RowDataBound2(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label Error = (Label)(e.Row.FindControl("lblError"));
                if (Error.Text.Trim() != "")
                {
                    //  Label lblDescripcion = (Label)(e.Row.FindControl("lblDescripcion"));
                    //  Label lblCodigoInterno = (Label)(e.Row.FindControl("lblCodigoInterno"));
                    //  Label lblCantidad = (Label)(e.Row.FindControl("lblCantidad"));
                    //  Label lblCosto = (Label)(e.Row.FindControl("lblCosto"));
                    //  Label lblPrecio = (Label)(e.Row.FindControl("lblP1"));
                    //
                    //  if (Error.Text == "NUEVO SIN DESCRIPCION")
                    //  {
                    //      if (lblDescripcion.Text.Trim() == "")
                    //          lblDescripcion.Text = "--REQUIERE DESCRIPCION--";
                    //      lblDescripcion.BackColor = Color.Orange;
                    //  }
                    //  else if (Error.Text == "DUPLICADO EN EL EXCEL")
                    //  {
                    //      lblCodigoInterno.Text = lblCodigoInterno.Text + " (REPETIDO)";
                    //      lblCodigoInterno.BackColor = Color.Orange;
                    //  }
                    //  else if (Error.Text == "CANTIDAD CERO O NULO")
                    //  {
                    //      if (lblCantidad.Text.Trim() == "")
                    //          lblCantidad.Text = "NULO";
                    //      lblCantidad.BackColor = Color.Orange;
                    //  }
                    //  else if (Error.Text == "COSTO CERO O NULO")
                    //  {
                    //      if (lblCosto.Text.Trim() == "")
                    //          lblCosto.Text = "NULO";
                    //      lblCosto.BackColor = Color.Orange;
                    //  }
                    //  else if (Error.Text == "PRECIO 1 CERO O NULO")
                    //  {
                    //      if (lblPrecio.Text.Trim() == "")
                    //          lblPrecio.Text = "NULO";
                    //      lblPrecio.BackColor = Color.Orange;
                    //  }
                    //
                }
            }
        }

        public void P_Inicializar_GrillaVacia_DetalleArticulo()
        {
            DataTable dta_consultadetalle = null;
            DataRow dtr_filadetalle = null;

            dta_consultadetalle = new DataTable();

            //dta_consultadetalle.Columns.Add("DESCRIPCION_ERROR", typeof(string));
            //dta_consultadetalle.Columns.Add("CodigoInterno", typeof(string));
            //dta_consultadetalle.Columns.Add("CODIGO", typeof(string));
            //dta_consultadetalle.Columns.Add("DESCRIPCION", typeof(string));
            //dta_consultadetalle.Columns.Add("Cantidad", typeof(string));
            //dta_consultadetalle.Columns.Add("UPrice", typeof(string));
            //dta_consultadetalle.Columns.Add("Total", typeof(string));
            //dta_consultadetalle.Columns.Add("Marca", typeof(string));
            //dta_consultadetalle.Columns.Add("Costo", typeof(string));
            //dta_consultadetalle.Columns.Add("P1", typeof(string));
            //dta_consultadetalle.Columns.Add("P2", typeof(string));
            //dta_consultadetalle.Columns.Add("P3", typeof(string));

            //dtr_filadetalle = dta_consultadetalle.NewRow();

            //dta_consultadetalle.Rows.Add(dtr_filadetalle);

            grvDetalleArticulo.DataSource = dta_consultadetalle;
            grvDetalleArticulo.DataBind();
        }

        /// <summary>
        /// Nuevo Procedimiento para consultar detalles
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public String F_ExportarDetalle_NET(String arg)
        {
            int int_resultado_operacion = 0;
            String str_resultado = "";
            String str_mensaje_operacion = "";
            String grvNombre = "";
            String str_grv_Detalle_html = "";
            int Col = 0;
            int Codigo = 0;
            int CodTipoDoc = 0;

            Hashtable obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);

            try
            {
                Codigo = Convert.ToInt32(obj_parametros["Filtro_Codigo"]);
                ExportarExcelDetalle(Codigo);

            }
            catch (Exception exxx)
            {
                str_resultado = "ERROR AL BUSCAR DETALLE: " + exxx;
                int_resultado_operacion = 1;
            }


            str_resultado = "";
            return str_resultado;
        }

        public String F_ValidarUsuario_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;
            int CodUsuarioAuxiliar = 0;
            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_ValidarUsuario(obj_parametros, ref MsgError, ref CodUsuarioAuxiliar);
                int_resultado_operacion = 1;
                str_mensaje_operacion = MsgError;
            }
            catch (Exception ex)
            {
                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion
                + "~" +
                CodUsuarioAuxiliar.ToString();

            return str_resultado;
        }

        public String F_EspecificarValores_NET(String arg)
        {
            String str_resultado = "";
            String str_mensaje_operacion = "";
            int int_resultado_operacion = 0;
            String MsgError = "";
            Hashtable obj_parametros = null;
            int CodUsuarioAuxiliar = 0;
            try
            {
                obj_parametros = SistemaInventario.Clases.JsonSerializer.FromJson<Hashtable>(arg);
                P_EspecificarValores(obj_parametros, ref MsgError);
                int_resultado_operacion = 1;
                str_mensaje_operacion = MsgError;
            }
            catch (Exception ex)
            {
                str_mensaje_operacion = "Ha ocurrido el siguiente error: " + ex.Message;
                int_resultado_operacion = 0;
            }

            str_resultado =
                Convert.ToString(int_resultado_operacion)
                + "~" +
                str_mensaje_operacion;

            return str_resultado;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            HiddenField1.Value = "0";
            FileUpload1 = new FileUpload();
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            string Mensaje = ""; int CodMovimiento = 0;
            Label1.Text = "";
            HiddenField1.Value = DateTime.Now.ToString("yyyyMMddHHmmss");
            long IdExcel = long.Parse(HiddenField1.Value.ToString());
            MSG = "";
            dtValidacionesPrevias = null;
            if (!f_Validacion_Preliminares())
            {
                btnImport.Enabled = true;
                btnNuevo.Enabled = true;
                FileUpload1.Enabled = true;
                Label1.Text = MSG;
                return;
            }

            btnImport.Enabled = false;
            btnNuevo.Enabled = false;
            FileUpload1.Enabled = false;

            string MensajeErrorCarga;
            ImportarExcel(out MensajeErrorCarga);

            dtValidacionesPrevias = (new Planilla_SalarioCN()).F_Planilla_Salario_Excel_Empleados_Validaciones_Previas(Convert.ToInt64(HiddenField1.Value), CodProyecto, CodRegimenLaboral);
            if (dtValidacionesPrevias.Rows.Count > 0)
            {
                grvDetalleArticulo.DataSource = dtValidacionesPrevias;
                grvDetalleArticulo.DataBind();
                MensajeErrorCarga = "HAY OBSERVACIONES EN EL EXCEL, POR FAVOR REVISAR PRIMERO ANTES DE PROCESAR";
                return;
            }

            if (MensajeErrorCarga == "")
            {
                ProcedimientoTrasladar(ref Mensaje, ref CodMovimiento);
                Label1.Text = Mensaje;

                if (Mensaje.ToUpper() == "SE GRABO CORRECTAMENTE")
                {

                    HiddenField1.Value = "0";
                    FileUpload1 = new FileUpload();
                }
            }

            btnImport.Enabled = false;
            btnNuevo.Enabled = false;
            FileUpload1.Enabled = false;


            //btnNuevo_Click(sender, EventArgs.Empty);
            return;
        }

        public static int CodProyecto = 0;
        public static int CodRegimenLaboral = 0;
        public static int CodPeriodo = 0;
        private void ImportarExcel(out string MensajeError)
        {
            MensajeError = "";
            string ExcelContentType = "application/vnd.ms-excel";
            string Excel2010ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            if (FileUpload1.HasFile)
            {
                if (FileUpload1.PostedFile.ContentType == ExcelContentType || FileUpload1.PostedFile.ContentType == Excel2010ContentType)
                {
                    string path;
                    string excelConnectionString;
                    string Cadena;
                    try
                    {
                        path = string.Concat(Server.MapPath("~/Temporales/"), FileUpload1.FileName);
                        FileUpload1.SaveAs(path);

                        excelConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);
                        Cadena = string.Format("Select [COD], [DFALTA], [DVAC], [DLABFER], [DMED], [DLUTO], [DLAB], [H25], [H35], " +
                                               " [H100], [BASNOC], [PATERN], [MOVILID], [OTRINAF], [OTRAFE], [OTRDESAFE], [OTRAFEPRO], [SUBSIDIO], [RESPECIE], [ADELANTO], [JUDICIAL], [SCRT], [SEGVLEY], "+
                                                 "[OBSERVACIONES], [VACACIONES], " + 
                                                HiddenField1.Value + " AS IDExcel, " +
                                                "'" + FileUpload1.FileName + "' AS NombreExcel, " +
                                                Session["CodUsuario"].ToString() + " AS CodUsuario, " +
                                                CodProyecto.ToString() + " as CodProyecto, " +
                                                CodRegimenLaboral.ToString() + " as CodRegimenLaboral, " +
                                                CodPeriodo.ToString() + " as CodPeriodo " +
                                                "FROM [{0}] ", "TAREO$");

                        using (OleDbConnection connection = new OleDbConnection(excelConnectionString))
                        {
                            OleDbCommand command = new OleDbCommand(Cadena, connection);

                            connection.Open();

                            using (DbDataReader dr = command.ExecuteReader())
                            {
                                string sqlConnectionString = ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
                                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConnectionString))
                                {
                                    bulkCopy.DestinationTableName = "Planilla_Salario_Excel";

                                    bulkCopy.ColumnMappings.Add("[COD]", "[COD]");
                                    bulkCopy.ColumnMappings.Add("[DFALTA]", "[DFALTA]");
                                    bulkCopy.ColumnMappings.Add("[DVAC]", "[DVAC]");
                                    bulkCopy.ColumnMappings.Add("[DLABFER]", "[DLABFER]");
                                    bulkCopy.ColumnMappings.Add("[DMED]", "[DMED]");
                                    bulkCopy.ColumnMappings.Add("[DLUTO]", "[DLUTO]");
                                    bulkCopy.ColumnMappings.Add("[DLAB]", "[DLAB]");
                                    bulkCopy.ColumnMappings.Add("[H25]", "[H25]");
                                    bulkCopy.ColumnMappings.Add("[H35]", "[H35]");
                                    bulkCopy.ColumnMappings.Add("[H100]", "[H100]");
                                    bulkCopy.ColumnMappings.Add("[BASNOC]", "[BASNOC]");
                                    bulkCopy.ColumnMappings.Add("[PATERN]", "[PATERN]");
                                    bulkCopy.ColumnMappings.Add("[MOVILID]", "[MOVILID]");
                                    bulkCopy.ColumnMappings.Add("[OTRINAF]", "[OTRINAF]");
                                    bulkCopy.ColumnMappings.Add("[OTRAFE]", "[OTRAFE]");
                                    bulkCopy.ColumnMappings.Add("[OTRDESAFE]", "[OTRDESAFE]");
                                    bulkCopy.ColumnMappings.Add("[OTRAFEPRO]", "[OTRAFEPRO]");
                                    bulkCopy.ColumnMappings.Add("[SUBSIDIO]", "[SUBSIDIO]");
                                    bulkCopy.ColumnMappings.Add("[RESPECIE]", "[RESPECIE]");
                                    bulkCopy.ColumnMappings.Add("[ADELANTO]", "[ADELANTO]");
                                    bulkCopy.ColumnMappings.Add("[JUDICIAL]", "[JUDICIAL]");
                                    bulkCopy.ColumnMappings.Add("[SCRT]", "[SCRT]");
                                    bulkCopy.ColumnMappings.Add("[SEGVLEY]", "[SEGVLEY]");
                                    bulkCopy.ColumnMappings.Add("[OBSERVACIONES]", "[OBSERVACIONES]");
                                    bulkCopy.ColumnMappings.Add("[VACACIONES]", "[VACACIONES]");
                                    bulkCopy.ColumnMappings.Add("[IDExcel]", "IDExcel");
                                    bulkCopy.ColumnMappings.Add("[NombreExcel]", "NombreExcel");
                                    bulkCopy.ColumnMappings.Add("[CodUsuario]", "CodUsuario");
                                    bulkCopy.ColumnMappings.Add("[CodProyecto]", "CodProyecto");
                                    bulkCopy.ColumnMappings.Add("[CodRegimenLaboral]", "CodRegimenLaboral");
                                    bulkCopy.ColumnMappings.Add("[CodPeriodo]", "CodPeriodo");
                                    bulkCopy.WriteToServer(dr);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            MensajeError = "Error en la lectura del excel. <p></p> " +
                                            "Descripción: " + ex.Message.ToString() + " <p></p>  <p></p> " +
                                            " debe tener cuenta que el documento debe tener las siguientes especificaciones:  <p></p> " +
                                            " <b>Hoja: TAREO</b>" +
                                            " Columnas: <p></p>" +
                                            " <b> A=[COD], B=[DFALTA], C=[DVAC], D=[DLABFER], E=[DMED], F=[DLUTO], G=[DLAB], H=[H25], I=[H35],  </b>" +
                                            " <b> J=[H100], K=[JUDICIAL], L=[BASNOC], M=[PATERN], N=[MOVILID], O=[OTRINAF], P=[OTRAFE], Q=[OTRDESAF], R=[OTRAFEPRO], S=[SUBSIDIO], T=[RESPECIE] </b>"+
                                            " <b> U=[ADELANTO], V=[SCRT], W=[SEGVLEY], X=[OBSERVACIONES], Y=[VACACIONES]</b>";

                            Label1.Text = MensajeError;
                        }
                        catch (Exception exx)
                        { }
                    }
                }
            }
            else
            {
                MensajeError = "No ha seleccionado ningun archivo";
                Label1.Text = MensajeError;
            }
        }

        protected string MSG;
        protected DataTable dtValidacionesPrevias;
        private bool f_Validacion_Preliminares()
        {
            bool resp = true;

            int countVal = 0;
            MSG = "ERRORES:   ";


            //----------------------------------------
            //VALIDACION DE PeriodoS-------------------
            //----------------------------------------
            if (txtAñoPeriodo.Text.Trim() == "")
            {
                MSG += "|   AÑO Periodo VACIA";
                countVal++;
            }

            if (txtAñoPeriodo.Text.Trim() != "")
            {
                if (txtAñoPeriodo.Text.Trim().Length != 6)
                {
                    MSG += "|   AÑO Periodo INCORRECTO";
                    countVal++;
                }
                else
                {
                    try
                    {
                        var x = Convert.ToInt32(txtAñoPeriodo.Text);
                        Planilla_PeriodoCE objEntidad = new Planilla_PeriodoCE();
                        objEntidad.AñoPeriodo1 = x.ToString();
                        DataTable dtSem = (new Planilla_PeriodoCN()).F_Planilla_Periodo_Obtener_Por_Periodo(objEntidad);
                        if (dtSem.Rows.Count == 0)
                        {
                            MSG += "|   Periodo NO EXISTE";
                        }
                        else
                        {
                            Planilla_SalarioCE objEntidadSalario = new Planilla_SalarioCE();
                            objEntidadSalario.AñoSemana = x.ToString();
                            objEntidadSalario.CodProyecto = 1;

                            //DataTable dtSal = (new Planilla_SalarioCN()).F_Planilla_Salario_Obtener_Por_Periodo(objEntidadSalario);
                            //if (dtSal.Rows.Count > 0) {
                            //    MSG += "|   LA PLANILLA DEL PROYECTO Y DE LA Periodo SELECCIONADA YA EXISTE";
                            //}

                        }
                    }
                    catch (Exception exxx)
                    {
                        MSG += "|   AÑO Periodo INCORRECTO";
                    }



                }

            }
            //----------------------------------------
            //FIN VALIDACION DE PeriodoS-------------------
            //----------------------------------------

            return resp;
        }

        private void ProcedimientoTrasladar(ref string Mensaje, ref int CodMovimiento)
        {
            Planilla_SalarioCE objEntidad = new Planilla_SalarioCE();
            objEntidad.IDExcel = Convert.ToInt64(HiddenField1.Value);

            Planilla_SalarioCE objOperacion = (new Planilla_SalarioCN()).F_Planilla_Salario_Excel_Proceso_Mensual(objEntidad);

            Mensaje = objEntidad.MsgError;
            CodMovimiento = 0;
        }

        protected void ExportarExcelNuevo(long IdExcel, int CodMovimiento)
        {
            DocumentoVentaCabCN objOperacion = null;
            objOperacion = new DocumentoVentaCabCN();
            DataTable ds = objOperacion.F_ListaPreciosExcel_Exportacion(IdExcel, CodMovimiento, Convert.ToDecimal("0.0"));

            if (ds.Rows.Count > 0)
            {
                FileInfo newFile = new FileInfo(Server.MapPath("Xls_Importaciones.xlsx"));

                ExcelPackage pck = new ExcelPackage(newFile);
                var ws = pck.Workbook.Worksheets["IMPORTACION"];

                for (int i = 2; i < 5000; i++)
                    ws.DeleteRow(2);

                ws.Cells["A2"].LoadFromDataTable(ds, true);
                ws.DeleteRow(2);

                for (int i = 2; i < ds.Rows.Count + 2; i++)
                {
                    try
                    {
                        var Valor = ws.Cells["J" + i.ToString()].Value.ToString();
                        if (Valor != "")
                        {
                            if (Valor == "1")
                            {
                                ws.Cells["A" + i.ToString() + ":I" + i.ToString()].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                ws.Cells["A" + i.ToString() + ":I" + i.ToString()].Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                            }
                        }
                    }
                    catch (Exception exxxx)
                    { }
                }

                ws.DeleteColumn(10); //elimino la columna M que no va...

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=Xls_Importaciones.xlsx");

                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    pck.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }

        protected void ExportarExcelDetalle(int CodMovimiento)
        {
            NotaIngresoSalidaDetCN objOperacion = new NotaIngresoSalidaDetCN();
            NotaIngresoSalidaDetCE objEntidad = new NotaIngresoSalidaDetCE();
            objEntidad.CodMovimiento = CodMovimiento;
            DataTable ds = objOperacion.F_NotaIngresoSalidaDet_Select_Importaciones(objEntidad);

            if (ds.Rows.Count > 0)
            {
                FileInfo newFile = new FileInfo(Server.MapPath("Importaciones.xlsx"));

                ExcelPackage pck = new ExcelPackage(newFile);
                var ws = pck.Workbook.Worksheets["IMPORTACION"];

                for (int i = 2; i < 50000; i++)
                    ws.DeleteRow(2);

                ws.Cells["A2"].LoadFromDataTable(ds, true);
                ws.DeleteRow(2);

                //for (int i = 2; i < ds.Rows.Count + 2; i++)
                //{
                //    try
                //    {
                //        var Valor = ws.Cells["H" + i.ToString()].Value.ToString();
                //        if (Valor != "")
                //        {
                //            if (Valor == "1")
                //            {
                //                ws.Cells["A" + i.ToString() + ":G" + i.ToString()].Style.Fill.PatternType = ExcelFillStyle.Solid;
                //                ws.Cells["A" + i.ToString() + ":G" + i.ToString()].Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                //            }
                //        }
                //    }
                //    catch (Exception exxxx)
                //    { }
                //}

                ws.DeleteColumn(8); //elimino la columna M que no va...

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=Importaciones.xlsx");

                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    pck.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }

        public void P_ValidarUsuario(Hashtable objTablaFiltro, ref String MsgError, ref Int32 CodUsuarioAuxiliar)
        {
            UsuarioCE objEntidad = null;
            UsuarioCN objOperacion = null;

            objEntidad = new UsuarioCE();

            objEntidad.NombreUsuario = Convert.ToString(objTablaFiltro["Filtro_Usuario"]);
            objEntidad.Clave = Convert.ToString(objTablaFiltro["Filtro_NvClave"]);
            objEntidad.Pagina = Convert.ToString(objTablaFiltro["Filtro_Pagina"]);
            objEntidad.CodUsuario = Convert.ToInt32(Session["CodUsuario"]);

            objOperacion = new UsuarioCN();
            objOperacion.F_Usuario_Login_Modulo(objEntidad);
            MsgError = objEntidad.Mensaje;
            CodUsuarioAuxiliar = objEntidad.CodUsuarioAuxiliar;
        }


        public void P_EspecificarValores(Hashtable objTablaFiltro, ref String MsgError)
        {
            try
            {
                CodProyecto = Convert.ToInt32(objTablaFiltro["Filtro_CodProyecto"]);
                CodRegimenLaboral = Convert.ToInt32(objTablaFiltro["Filtro_CodRegimenLaboral"]);
                CodPeriodo = Convert.ToInt32(objTablaFiltro["Filtro_CodPeriodo"]);
                MsgError = "";

            }
            catch (Exception ex)
            {
                MsgError = ex.Message;
            }

        }

    }
}
