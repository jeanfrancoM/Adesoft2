﻿<%@ Page Title="Reporte Historial Pagos" Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="CXP_HistorialPagos.aspx.cs" Inherits="SistemaInventario.Reportes.CXP_HistorialPagos" %>
  
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"   type="text/javascript"></script>     
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/alertify.min.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript" charset="UTF-8"></script>
    <script type="text/javascript" language="javascript" src="CXP_HistorialPagos.js" charset="UTF-8"></script>
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"  type="text/css" />      
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.core.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo" style="width: 500px">
        Historial de Pagos</div>
    <div id='divConsulta' class="ui-jqgrid ui-widget ui-widget-content ui-corner-all"
        style="width: 500px">
        <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
            Criterio de busqueda
        </div>
        <div class="ui-jqdialog-content" style="width: 700px;">
            <table cellpadding="0" cellspacing="0" class="form-inputs" width="700">
                <tr style="display:none" >
                    <td style="font-weight: bold">
                        Empresa
                    </td>
                    <td colspan='4' style="padding-left: 4px;">
                        <div id="div_Empresa">
                            <asp:DropDownList ID="ddlEmpresa" runat="server" Font-Names="Arial" ForeColor="Blue"
                                Font-Bold="True" Width="362" BackColor="#FFFF99">
                            </asp:DropDownList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        PROVEEDOR
                    </td>
                    <td style="padding-left: 4px;">
                        <asp:TextBox ID="txtCliente" runat="server" Width="358px" Font-Names="Arial" ForeColor="Blue"
                            Font-Bold="True"></asp:TextBox>
                    </td>
                    <td style="display: none;">
                        <asp:CheckBox ID="chkVencidas" runat="server" Text="Solo Vencidas" Font-Bold="True" />
                    </td>
                    <td style="display: none;">
                        <asp:CheckBox ID="chkDeudas" runat="server" Text="todas DEUDAS" Checked="True" Font-Bold="True" />
                    </td>
                    <td style="display: none;">
                        <asp:CheckBox ID="chkTodas" runat="server" Text="todas" Font-Bold="True" />
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        Moneda
                    </td>
                    <td style="padding-left: 4px">
                        <div id="div_moneda">
                            <asp:DropDownList ID="ddlMoneda" runat="server" Font-Names="Arial" ForeColor="Blue"
                                Font-Bold="True" Width="85" BackColor="#FFFF99">
                            </asp:DropDownList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        <asp:CheckBox ID="chkRango" runat="server" Text="Fecha" Font-Bold="True" />
                    </td>
                    <td colspan='4'>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtDesde" runat="server" Width="55" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True" CssClass="Jq-ui-dtp" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold">
                                    Hasta
                                </td>
                                <td>
                                    <asp:TextBox ID="txtHasta" runat="server" Width="55" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True" CssClass="Jq-ui-dtp" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div class="linea-button">
            <asp:Button ID="btnBuscar" runat="server" Text="Reporte" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                Font-Names="Arial" Font-Bold="True" Width="120" />
        </div>
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
    <input id="hfCodCtaCte" type="hidden" value="0" />
</asp:Content>
