<%@ Page Title="APP Sinc. Productos" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="ListaPreciosKarinaApp.aspx.cs" Inherits="SistemaInventario.Maestros.ListaPreciosKarinaApp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"
        type="text/javascript"></script>
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/alertify.min.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="ListaPreciosKarinaApp.js"
        charset="UTF-8"></script>
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/toars/toastr.min.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/toars/toastr.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="https://www.gstatic.com/firebasejs/8.2.10/firebase-app.js"></script>
    <script type="text/javascript" src="https://www.gstatic.com/firebasejs/8.2.10/firebase-firestore.js"></script>
    <script type="text/javascript" src="https://www.gstatic.com/firebasejs/8.3.0/firebase-storage.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo" style="width: 1030px">
        Sincronizacion de productos con la APP</div>
    <div id="tabRegistro" style="width: 1030px">
        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                Lista Precios
            </div>
            <div id="divConsultaArticulo">
                <div class="ui-jqdialog-content">
                    <table cellpadding="0" cellspacing="0" width="900" class="form-inputs">
                        <tr>
                            <td style="font-weight: bold">
                                Familia
                            </td>
                            <td style="padding-left: 0px;">
                                <div id="div_Familia">
                                    <asp:DropDownList ID="ddlFamilia" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True">
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td style="font-weight: bold">
                                Articulo
                            </td>
                            <td>
                                <asp:TextBox ID="txtArticulo" runat="server" Width="250px" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold">
                                Sinc.
                            </td>
                            <td style="padding-left: 0px;">
                                <div id="div1">
                                    <asp:DropDownList ID="ddlTipoSincronizacion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True">
                                        <asp:ListItem Value="-1">TODOS</asp:ListItem>
                                        <asp:ListItem Value="1" Selected="True">SOLO LOS QUE SE VENDEN EN APP</asp:ListItem>
                                        <asp:ListItem Value="0">LOS QUE NO SE VENDEN EN APP</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkSoloConImagenes" runat="server" Text="SOLO CON IMAGENES" Font-Bold="True" />
                            </td>
                            <td>
                                <asp:CheckBox ID="chkSoloYaEnviados" runat="server" Text="YA ENVIADOS" Font-Bold="True" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="linea-button">
                <asp:Button ID="btnNuevo" runat="server" Text="Nueva Lista Precio" Font-Names="Arial"
                    Style="display: none;" Font-Bold="True" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                    Width="180" />
                <asp:Button ID="btnReporte" runat="server" Text="Reporte" Font-Names="Arial" Font-Bold="True"
                    class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                    Width="120" Visible="false" />
                <asp:CheckBox runat="server" ID="chkEnviarImagenes" Text="Enviar Imagenes" Checked="True"
                    Font-Bold="True" />
                <asp:Button ID="btnEnvarArticulos" runat="server" Text="Enviar Articulos" Font-Names="Arial"
                    Font-Bold="True" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                    Width="150" OnClientClick="F_Enviar_Productos(); return false;" />
                <%--                <asp:Button ID="btnEnviarImagenes" runat="server" Text="Enviar Imagenes" Font-Names="Arial"
                    Font-Bold="True" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                    Width="150" />--%>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Font-Names="Arial" Font-Bold="True"
                    class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                    Width="120" />
                <asp:Button ID="btnAgregar" runat="server" Text="Grabar" Font-Names="Arial" Font-Bold="True"
                    Width="120" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                    Visible="false" />
            </div>
        </div>
        <div style="padding-top: 5px;">
               <table cellpadding="0" cellspacing="0" align="center">
                                    <tr>
                                        <td style="font-weight: bold">
                                           Cantidad de Registros:
                                        </td>
                                        <td style="font-weight: bold">
                                            <label id="lblNumeroConsulta"></label>
                                        </td>                                
                                    </tr>
                                </table>
            </div>
        <div id="div_grvConsultaArticulo" style="padding-top: 5px;">
            <asp:GridView ID="grvConsultaArticulo" runat="server" AutoGenerateColumns="False"
                border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                Width="1030px">
                <Columns>
                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Left" Width="20px" />
                        <HeaderTemplate>
                            <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkOK" CssClass="chkSi" Text="" onclick="F_ValidarCheck(this.id);" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Codigo">
                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("Codigo") %>' CssClass="detallesart"></asp:Label>
                            <asp:HiddenField ID="hfEmpresaRuc" runat="server" Value='<%# Bind("EmpresaRuc") %>' />
                            <asp:HiddenField ID="hfCodProducto" runat="server" Value='<%# Bind("CodProducto") %>' />
                            <asp:HiddenField ID="hfCodAlterno" runat="server" Value='<%# Bind("CodAlterno") %>' />
                            <asp:HiddenField ID="hfCodigoApp" runat="server" Value='<%# Bind("CodigoApp") %>' />
                            <asp:HiddenField ID="hfCodEstado" runat="server" Value='<%# Bind("CodEstado") %>' />
                            <asp:HiddenField ID="hfDescripcionDetalladaApp" runat="server" Value='<%# Bind("DescripcionDetalladaApp") %>' />
                            <asp:HiddenField ID="hfStock" runat="server" Value='<%# Bind("Stock") %>' />
                            <asp:HiddenField ID="hfTipoValorUM" runat="server" Value='<%# Bind("TipoValorUM") %>' />
                            <asp:HiddenField ID="hfUM" runat="server" Value='<%# Bind("UM") %>' />
                            <asp:HiddenField ID="hfTags" runat="server" Value='<%# Bind("Tags") %>' />
                            <asp:HiddenField ID="hfTagsMarcaModelo" runat="server" Value='<%# Bind("TagsMarcaModelo") %>' />
                            <asp:HiddenField ID="hfTagsMarcas" runat="server" Value='<%# Bind("TagsMarcas") %>' />
                            <asp:HiddenField ID="hfTagsModelos" runat="server" Value='<%# Bind("TagsModelos") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CodigoAlternativo" HeaderText="Codigo 2" Visible="false">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Familia">
                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblFamilia" Text='<%# Bind("Familia") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Descripcion">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblDescripcion" Text='<%# Bind("Descripcion") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Precio App S./">
                        <ItemStyle HorizontalAlign="Right" Width="50px" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblPrecioApp" Text='<%# Bind("PrecioApp") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cant. Imgs">
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblCantidadImagenes" Text='<%# Bind("CantidadImagenes") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Publicado">
                        <ItemStyle HorizontalAlign="Left" Width="50px" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblPublicadoApp" Text='<%# Bind("PublicadoApp") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
                        <ItemStyle HorizontalAlign="Left" Width="20px" />
                        <ItemTemplate>
                            <asp:Image runat="server" ID="imgProceso" ImageUrl="~/Asset/images/nada.png" Width="18px"
                                Height="18px" ToolTip="Proceso de producto" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
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
    <input id="hfCodUsuario" type="hidden" value="0" />
    <input id="hfCodSede" type="hidden" value="0" />
    <input id="hfCodProducto" type="hidden" value="0" />
    <input id="hfCodDocumentoVenta" type="hidden" value="0" />
</asp:Content>
