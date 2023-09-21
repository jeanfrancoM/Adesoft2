<%@ Page Title="Inventario Stock Actual" Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="Inventario_InventarioRoman.aspx.cs" Inherits="SistemaInventario.Reportes.Inventario_InventarioRoman" %>
  
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"  type="text/javascript"></script>      
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/alertify.min.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="Inventario_InventarioRoman.js" charset="UTF-8"></script>
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"    type="text/css" />    
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.core.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo" style="width: 930px">
        Reporte de Inventario Stock Actual</div>
    <div id="tabRegistro" style="width: 900px">
        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                Inventario Stock Actual
            </div>
            <div id="divConsultaArticulo">
                <div class="ui-jqdialog-content">
                    <table cellpadding="0" cellspacing="0" class="form-inputs">
                        <tr>
                            <td style="font-weight: bold; width:70px">
                                Familia
                            </td>
                            <td colspan="3">
                                <div id="div_Familia" style="width:70px";>
                                    <asp:DropDownList ID="ddlFamilia" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True" Width="117">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; width:70px";>
                                Marca
                            </td>
                            <td colspan="3">
                                <div id="div_Marca" style="width:70px";>
                                    <asp:DropDownList ID="ddlMarca" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True" Width="117">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; width:70px";>
                                Procedencia
                            </td>
                            <td colspan="3">
                                <div id="div1" style="width:70px";>
                                    <asp:DropDownList ID="ddlProcedencia" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True" Width="117">
                                        <asp:ListItem Value="0">TODO</asp:ListItem>
                                        <asp:ListItem Value="1">Nacional</asp:ListItem>
                                        <asp:ListItem Value="2">Importado</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="linea-button">
                <asp:Button ID="btnBuscar" runat="server" Text="BUSCAR" Font-Names="Arial" Font-Bold="True"
                    class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                    Width="120px" />
                <asp:Button ID="btnExcel" runat="server" Text="Excel" Font-Names="Arial" Font-Bold="True"
                    class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                    Width="120px" />
                <asp:Button ID="btnPdf" runat="server" Text="PDF" Font-Names="Arial" Font-Bold="True"
                    Style="display: none;" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                    Width="120px" />
            </div>
        </div>
    </div>
    <div id="div_grvConsultaArticulo" style="padding-top: 5px;">
        <asp:GridView ID="grvConsultaArticulo" runat="server" AutoGenerateColumns="True"
            border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
            Width="900px">
<%--            <Columns>
                <asp:BoundField DataField="Familia" HeaderText="Familia">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="CodigoProducto" HeaderText="Codigo">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Codigo2" HeaderText="Codigo 2">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Pais" HeaderText="Pais">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="DscProducto" HeaderText="Producto">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Marca" HeaderText="Marca">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Stock" HeaderText="Stock" DataFormatString="{0:N0}">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="UM" HeaderText="UM">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Costo" HeaderText="Costo">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="P1" HeaderText="Pre-1">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="P2" HeaderText="Pre-2">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="P3" HeaderText="Pre-3">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Moneda" HeaderText="Mon.">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
            </Columns>--%>
        </asp:GridView>
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
    <input id="hfCodCtaCteConsulta" type="hidden" value="0" />
    <input id="hfCodigoTemporal" type="hidden" value="0" />
    <input id="hfCodDocumentoVenta" type="hidden" value="0" />
</asp:Content>