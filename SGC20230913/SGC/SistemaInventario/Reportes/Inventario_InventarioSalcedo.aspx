<%@ Page Title="Inventario Stock Actual" Language="C#" MasterPageFile="~/Site.Master"    AutoEventWireup="true" CodeBehind="Inventario_InventarioSalcedo.aspx.cs" Inherits="SistemaInventario.Reportes.Inventario_InventarioSalcedo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script> 
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"  type="text/javascript"></script>      
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/alertify.min.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript" charset="UTF-8"></script>
    <script type="text/javascript" language="javascript" src="Inventario_InventarioSalcedo.js" charset="UTF-8"></script>
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"   type="text/css" />     
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.core.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo" style="width: 930px">
        Reporte de Inventario Stock Actual</div>
    <div id="tabRegistro" style="width: 930px">
        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                Inventario Stock Actual
            </div>
            <div id="divConsultaArticulo">
                <div class="ui-jqdialog-content">
                    <table width="900">
                        <tr>
                            <td style="font-weight: bold">
                                Familia
                            </td>
                            <td>
                                <div id="div_familiaconsulta">
                                    <asp:DropDownList ID="ddlFamiliaConsulta" runat="server" Font-Names="Arial" Font-Bold="True"
                                        ForeColor="Blue">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                          <tr>
                            <td style="font-weight: bold">
                                TIPO
                            </td>
                            <td>
                                 <div id="div_Tipo">
                                                            <asp:DropDownList ID="ddlTipo" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="100"  CssClass="ccsestilo" BackColor="#FFFF99">
                                                                  <asp:ListItem Value="0">TODOS</asp:ListItem>
                                                                  <asp:ListItem Value="1">CON STOCK</asp:ListItem>
                                                                  <asp:ListItem Value="2">SIN STOCK</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                            </td>
                        </tr>
                        <tr style="display: none;">
                         <td  >
                                <asp:CheckBox ID="chkMarca" runat="server" Text="Marca" Font-Bold="True" />
                            </td>
                            
                            <td>
                                <asp:TextBox ID="txtMarca" runat="server" Width="150px" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="display: none;">
                        <td style="font-weight: bold">
                        Descripcion
                        </td>
                        <td>
                         <asp:TextBox ID="txtDscProducto" runat="server" Width="310px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                        </td>
                        </tr>
                    </table>
                </div>
                <div class="linea-button">
                    <asp:Button ID="btnBuscar" runat="server" Text="BUSCAR" Font-Names="Arial" Font-Bold="True"
                        class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                      Style="display: none;"  Width="120px" />
                    <asp:Button ID="btnExcel" runat="server" Text="Excel" Font-Names="Arial" Font-Bold="True"
                        class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Width="120px" />
                    <asp:Button ID="btnPdf" runat="server" Text="PDF" Font-Names="Arial" Font-Bold="True"
                        Style="display: none;" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
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
    <input id="hfCodCtaCte" type="hidden" value="0" />
    <input id="hfCodCtaCteConsulta" type="hidden" value="0" />
    <input id="hfCodigoTemporal" type="hidden" value="0" />
    <input id="hfCodDocumentoVenta" type="hidden" value="0" />
    <input id="hfCodMarca" type="hidden" value="0" />
</asp:Content>
