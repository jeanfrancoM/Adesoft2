<%@ Page Title="Carga Masiva Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductosCargaMasiva.aspx.cs" Inherits="SistemaInventario.Inventario.ProductosCargaMasiva" %>
   
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"  type="text/javascript"></script>
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript" charset="UTF-8"></script>
    <script type="text/javascript" language="javascript" src="ProductosCargaMasiva.js" charset="UTF-8"></script>
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"  type="text/css" />      
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/toars/toastr.min.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/toars/toastr.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class='overlay'>
        <div class="titulo">  Carga Masiva Productos</div>
          
                <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
                    <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                        Datos de Importacion
                    </div>
                    <div>
                        <table cellpadding="0" cellspacing="0" class="form-inputs" width="750">
                            <tr>
                                <td style="font-weight: bold">
                                    Excel
                                </td>
                                <td>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                            </td>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label>
                                               
                                            </td>

                                            <td>
                                                <asp:Label ID="Label3" runat="server" Font-Bold="True"></asp:Label>
                                            </td>

                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="linea-button">               
                        <asp:Button ID="btnImport" runat="server" Text="Cargar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" Width="120" OnClick="btnImport_Click" />
                    </div>
                </div>
                <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
                    <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix"
                        style="width: 1000px">
                        Articulos con algun incoveniente
                    </div>
                     <div style="padding-top: 5px;">
                            <table cellpadding="0" cellspacing="0" align="center">
                                <tr>
                                    <td style="font-weight: bold">
                                        Cantidad de Registros:
                                    </td>
                                    <td style="font-weight: bold">
                                        <label id="lblCantidadRegistro">0
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    <div id="div_grvDetalleArticulo" style="padding-top: 5px;">
                        <asp:GridView ID="grvDetalleArticulo" runat="server" AutoGenerateColumns="False"
                            border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                            Width="1000px">
                            <Columns>
                                <asp:TemplateField HeaderText="ERROR">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblError" Text='<%# Bind("DESCRIPCION_ERROR") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Codigo">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("Codigo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
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
    <asp:HiddenField ID="hfCodTemporal" runat="server" />
</asp:Content>
