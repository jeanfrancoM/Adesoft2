﻿<%@ Page Title="Reporte Compra Plaza" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Compras_CompraPlaza.aspx.cs" Inherits="SistemaInventario.Reportes.Compras_CompraPlaza" %>
   
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"  type="text/javascript"></script>      
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/alertify.min.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript" charset="UTF-8"></script>
    <script type="text/javascript" language="javascript" src="Compras_CompraPlaza.js" charset="UTF-8"></script>
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet" type="text/css" />       
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.core.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo" style="width: 410px">
        Reporte Compras Plaza</div>
    <div id="tabRegistro" style="width: 410px">
        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                CRITERIO DE BUSQUEDA</div>
            <div id="divConsultaArticulo">
                <div class="ui-jqdialog-content">
                    <table cellpadding="0" cellspacing="0" class="form-inputs">
                        <tr>
                            <td style="font-weight: bold">
                                Sucursal
                            </td>
                            <td>
                                <div id="div_Sucursal">
                                    <asp:DropDownList ID="ddlSucursal" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True" Width="100px">
                                    </asp:DropDownList>
                                </div>
                            </td>
                            
                        </tr>
                        <tr>
                        <td style="font-weight: bold">
                           tipo producto
                            </td>
                            <td>
                               <asp:DropDownList runat="server" ID="ddlTipoProducto" Font-Names="Arial" ForeColor="Blue"
                                Font-Bold="True" CssClass="ccsestilo">
                                <asp:ListItem Value="-1">TODOS</asp:ListItem>
                                <asp:ListItem Value="0">PRODUCTOS</asp:ListItem>
                                <asp:ListItem Value="1">SERVICIOS</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                        </tr>
              
                          <tr>
                            <td style="font-weight: bold">
                                cliente
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtCliente" runat="server" Width="300px" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Desde
                            </td>
                            <td style="width:55px">
                                <asp:TextBox ID="txtDesde" runat="server" Width="55px" Font-Names="Arial" CssClass="Jq-ui-dtp"
                                    ReadOnly="true" ForeColor="Blue"></asp:TextBox>
                            </td>
                            <td style="padding-left: 5px; font-weight: bold">
                                Hasta
                            </td>
                            <td>
                                <asp:TextBox ID="txtHasta" runat="server" Width="55px" Font-Names="Arial" CssClass="Jq-ui-dtp"
                                    ReadOnly="true" ForeColor="Blue"></asp:TextBox>
                            </td>
                        </tr>
                      
                    </table>
                </div>
                <div class="linea-button">
                    <asp:Button ID="btnReporte" runat="server" Text="Reporte" Font-Names="Arial" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Width="120px" />
                </div>
            </div>
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
        <input id="hfCodTipoCliente" type="hidden" value="2" />
    <input id="hfCodCtaCte" type="hidden" value="0" />
</asp:Content>

