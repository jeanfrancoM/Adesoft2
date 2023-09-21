<%@ Page Title="Graficos Ventas Por Periodo en Montos" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="ven_grafico_VentasPorPeriodo.aspx.cs" Inherits="SistemaInventario.Reportes.ven_grafico_VentasPorPeriodo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"
        type="text/javascript"></script>
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/alertify.min.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript"
        charset="UTF-8"></script>
    <script type="text/javascript" language="javascript" src="ven_grafico_VentasPorPeriodo.js"
        charset="UTF-8"></script>
    <link href="../Asset/css/redmond/jquery-ui-1.10.4.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/toars/toastr.min.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/toars/toastr.min.js" type="text/javascript"></script>
    <link href="../Asset/multiselect-slim-autoc/slimselect.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../Asset/multiselect-slim-autoc/slimcustom.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/multiselect-slim-autoc/slimselect.min.js" type="text/javascript"></script>

    <link  href="../Asset/graficos_morris.js-0.5.1/morris.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/graficos_morris.js-0.5.1/raphael-min.js" type="text/javascript"></script>
    <script src="../Asset/graficos_morris.js-0.5.1/morris.js" type="text/javascript"></script>
    <script src="../Asset/graficos_morris.js-0.5.1/otros/rgbcolor.js" type="text/javascript"></script>
    <script src="../Asset/graficos_morris.js-0.5.1/otros/canvg.js" type="text/javascript"></script>
    <script src="../Asset/graficos_morris.js-0.5.1/otros/canvg.min.js" type="text/javascript"></script>
    <script src="../Asset/graficos_morris.js-0.5.1/otros/jspdf.min.js" type="text/javascript"></script>
    <script src="../Asset/graficos_morris.js-0.5.1/otros/html2canvas.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo" style="width: 550px">
        Graficos Ventas Por Periodo en Montos</div>
    <div id="tabRegistro" style="width: 550px">
        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                CRITERIO DE BUSQUEDA
            </div>
            <div id="divConsultaArticulo">
                <div class="ui-jqdialog-content">
                    <table cellpadding="0" cellspacing="0" class="form-inputs">
                        <tr>
                            <td style="font-weight: bold">
                                Desde
                            </td>
                            <td style="padding-left: 5px">
                                <asp:TextBox ID="txtDesde" runat="server" Width="55px" Font-Names="Arial" CssClass="MesAnioPicker"
                                    ReadOnly="true" ForeColor="Blue"></asp:TextBox>
                            </td>
                            <td style="padding-left: 5px; font-weight: bold">
                                Hasta
                            </td>
                            <td>
                                <asp:TextBox ID="txtHasta" runat="server" Width="55px" Font-Names="Arial" CssClass="MesAnioPicker"
                                    ReadOnly="true" ForeColor="Blue"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="display:none">
                            <td style="font-weight: bold">
                                Familia
                            </td>
                            <td style="padding-left: 5px" colspan="3">
                                <select id="ddlFamilia" style="width: 420px" multiple>
                                </select>
                            </td>
                        </tr>
                        <tr style="display:none">
                            <td style="font-weight: bold">
                                Marca
                            </td>
                            <td style="padding-left: 5px" colspan="3">
                                <select id="ddlMarca" style="width: 420px" multiple>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Moneda
                            </td>
                            <td style="padding-left: 5px" colspan="3">
                                <select id="ddlMoneda" style="width: 420px">
                                    <option value="0">Todos</option>
                                    <option value="1">Soles</option>
                                    <option value="2">Dolares</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Almacen
                            </td>
                            <td style="padding-left: 5px" colspan="3">
                                <select id="ddlAlmacen" style="width: 420px">
                                </select>
                            </td>
                        </tr>
                        <tr style="display:none">
                            <td style="font-weight: bold">
                                TIPO REPORTE
                            </td>
                            <td style="padding-left: 5px" colspan="3">
                                <select id="ddlTipoReporte" style="width: 420px">
                                    <option value="1">SOLO PRODUCTOS CON VENTAS</option>
                                    <option value="2">INCLUIR TODOS LOS PRODUCTOS C/S VENTAS</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                TIPO GRAFICO
                            </td>
                            <td style="padding-left: 5px" colspan="3">
                                <select id="ddlTipoGrafico" style="width: 420px">
                                    <option value="1">LINEA</option>
                                    <option value="2">BARRAS</option>
                                </select>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="linea-button">
                    <asp:Button ID="btnGenerarPdf" runat="server" Text="PDF" Font-Names="Arial" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Width="120px" />
                    <asp:Button ID="btnReporte" runat="server" Text="Reporte" Font-Names="Arial" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Width="120px" />
                </div>
            </div>
        </div>
    </div>
    <div id="div_Graficos">
        <div id="bar-Total">
        </div>
        <canvas style="border: 1px solid #CCC;" id="canvas" width="800px" height="600px">
        </canvas>
    </div>
    <div id="dlgWait" style="background-color: #CCE6FF; text-align: center; display: none;">
        <br />
        <br />
        <center>
            <asp:Label ID="Label2" runat="server" Text="PROCESANDO..." Font-Bold="true" Font-Size="Large"
                Style="text-align: center"></asp:Label></center>
        <br />
        <center>
            <img alt="Wait..." src="../Asset/images/ajax-loader2.gif" /></center>
    </div>
</asp:Content>
