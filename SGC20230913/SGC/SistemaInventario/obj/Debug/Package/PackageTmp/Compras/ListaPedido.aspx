<%@ Page Title="Lista de Pedido" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ListaPedido.aspx.cs" Inherits="SistemaInventario.Compras.ListaPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"
        type="text/javascript"></script>
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/alertify.min.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript"
        charset="UTF-8"></script>
    <script src="../Scripts/inputatajos/kibo.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="ListaPedido.js" charset="UTF-8"></script>
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.core.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.default.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/css/tooltipbutton/jquery.toolbar.js" type="text/javascript"></script>
    <link href="../Asset/css/tooltipbutton/jquery.toolbar.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/sss.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo" style="width: 530px;">
        LISTA DE PEDIDO</div>
    <div id="divTabs">
        <ul>
            <li id="liRegistro"><a href="#tabRegistro">Registro</a></li>
            <li id="liConsulta"><a href="#tabConsulta" onclick="getContentTab();">Consulta</a></li>
        </ul>
        <div id="tabRegistro" style="width: 530px;">
            <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    Nota Pedido
                </div>
                <div class="ui-jqdialog-content">
                    <table cellpadding="0" cellspacing="0" class="form-inputs" width="750">
                        <tr>
                            <td style="font-weight: bold">
                                Fecha
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0" class="form-inputs" width="750">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtEmision" runat="server" Width="55px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="linea-button">
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120px" />
                    <asp:Button ID="btnAgregarProducto" runat="server" Text="Agregar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120px" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120px" />
                    <asp:Button ID="btnExcel" runat="server" Text="Excel" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                </div>
            </div>
             <div style="text-align: center; width: 100%; color: Black; font-weight: bold">
                Cantidad de registros
                <asp:Label ID="lblNumRegistros" runat="server" Text="0"></asp:Label>
            </div>
            <div id="div_grvDetalleArticulo" style="padding-top: 5px;">
                <asp:GridView ID="grvDetalleArticulo" runat="server" AutoGenerateColumns="False"
                    border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                    Width="530px">
                    <Columns>
                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkEliminar" CssClass="chkDelete" Text="" />
                                <asp:HiddenField ID="hfCodDetalle" runat="server" Value='<%# Bind("CodDetalle") %>'  />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CodigoProducto" HeaderText="Codigo" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div id="tabConsulta">
            <div id='divConsulta' class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    Criterio de busqueda
                </div>
                <div class="ui-jqdialog-content">
                    <table cellpadding="0" cellspacing="0" class="form-inputs">
                        <tbody>
                            <tr>
                                <%--                                <td>
                                    <asp:CheckBox ID="chkNumero" runat="server" Text="Numero" Font-Bold="True" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNumeroConsulta" runat="server" Width="70" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>--%>
                                <td>
                                    <asp:CheckBox ID="chkRango" runat="server" Text="Fecha" Font-Bold="True" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDesde" runat="server" Width="55" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True" CssClass="Jq-ui-dtp" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtHasta" runat="server" Width="55" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True" CssClass="Jq-ui-dtp" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td style="width: 800px">
                                    <%--<asp:CheckBox ID="chkCliente" runat="server" Text="Cliente" Font-Bold="True" />--%>
                                </td>
                                <%--                                <td>
                                    <asp:TextBox ID="txtClienteConsulta" runat="server" Width="485" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>--%>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="linea-button">
                    <asp:Button ID="btnBuscarConsulta" runat="server" Text="Buscar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
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
            <div id="div_consulta" style="padding-top: 5px;">
                <asp:GridView ID="grvConsulta" runat="server" AutoGenerateColumns="False" border="0"
                    CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="1013px"
                    OnRowDataBound="grvConsulta_RowDataBound">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="20px">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                    ToolTip="ELIMINAR LISTA DE PEDIDO" OnClientClick="F_AnularRegistro(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="20px">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgReemplazar" ImageUrl="~/Asset/images/Reemplazo.png"
                                    ToolTip="MODIFICAR LISTA DE PEDIDO" OnClientClick="F_ReemplazarFactura(this.id); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="20px">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgExcel" ImageUrl="~/Asset/images/excel.gif"
                                    ToolTip="EXPORTAR LISTA DE PEDIDO" OnClientClick="F_VisualizarExcel_Grilla(this.id); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="20px">
                            <ItemTemplate>
                                <img id="imgMas" alt="" style="cursor: pointer" src="../Asset/images/plus.gif" onclick="imgMas_Click(this);"
                                    title="Ver Detalle" />
                                <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                                    <asp:GridView runat="server" ID="grvDetalle" border="0" CellPadding="0" CellSpacing="1"
                                        GridLines="None" class="GridView" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:BoundField DataField="CodDetalle" HeaderText="ID" ItemStyle-Width="15px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CodigoProducto" HeaderText="Codigo" ItemStyle-Width="100px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID" ItemStyle-Width="20px">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("CodDocumentoVenta") %>' CssClass="detallesart"></asp:Label>
                                <asp:HiddenField ID="hfFechaEmision" runat="server" Value='<%# Bind("FechaEmision") %>' />
                                <asp:HiddenField ID="hfUsuario" runat="server" Value='<%# Bind("Usuario") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FechaEmision" HeaderText="Emision">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Usuario" HeaderText="Creador">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <div id="divConsultaArticulo" style="display: none;">
        <div id='div1' class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                Criterio de busqueda
            </div>
            <div class="ui-jqdialog-content">
                <table cellpadding="0" cellspacing="0" class="form-inputs">
                    <tbody>
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkServicios" runat="server" Text="Servicios" Font-Bold="True"
                                    Style="display: none;" />
                            </td>
                            <td>
                                <asp:CheckBox ID="chkNotaPedido" runat="server" Text="nota pedido" Font-Bold="True"
                                    Style="display: none;" />
                            </td>
                            <td style="padding-left: 5px; font-weight: bold">
                                Articulo
                            </td>
                            <td>
                                <asp:TextBox ID="txtArticulo" runat="server" Width="717px" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="linea-button">
                <asp:Button ID="btnBuscarArticulo" runat="server" Text="Buscar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                    Font-Names="Arial" Font-Bold="True" Width="120" />
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                    Font-Names="Arial" Font-Bold="True" Width="120" />
            </div>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <div id="div_grvConsultaArticulo" style="padding-top: 5px;">
                            <asp:GridView ID="grvConsultaArticulo" runat="server" AutoGenerateColumns="False"
                                border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                                Width="970px">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemStyle Font-Bold="true" />
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgAgregar" ImageUrl="~/Asset/images/ok.gif"
                                                ToolTip="Agregar" OnClientClick="F_AgregarArticulo(this.id,1); return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkOK" CssClass="chkSi" Text="" onclick="F_ValidarCheck(this.id);" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblcodproducto" Text='<%# Bind("CodProducto") %>'></asp:Label>
                                            <asp:HiddenField ID="hfCodigoInterno" runat="server" Value='<%# Bind("CodigoProducto") %>' />
                                            <asp:HiddenField ID="hfCodProductoAzure" runat="server" Value='<%# Bind("CodProducto") %>' />
                                            <asp:HiddenField ID="hfcodunidadventa" runat="server" Value='<%# Bind("CodUnidadVenta") %>' />
                                            <asp:HiddenField ID="hfcosto" runat="server" Value='<%# Bind("Costo") %>' />
                                            <asp:HiddenField ID="hfDescuento" runat="server" Value='<%# Bind("Descuento") %>' />
                                            <asp:HiddenField ID="hfIdFamilia" runat="server" Value='<%# Bind("IdFamilia") %>' />
                                            <asp:HiddenField ID="hfCostoProductoSoles" runat="server" Value='<%# Bind("CostoProductoSoles") %>' />
                                            <asp:HiddenField ID="hfCostoProductoDolares" runat="server" Value='<%# Bind("CostoProductoDolares") %>' />
                                            <asp:HiddenField ID="hfMargen" runat="server" Value='<%# Bind("Margen") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Codigo">
                                        <ItemStyle Font-Bold="true" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" ID="hlkCodigo" Font-Underline="true" ForeColor="Blue"
                                                Style="cursor: hand" Text='<%# Bind("CodigoProducto") %>' onclick="F_VerUltimoPrecio(this.id); return false;"
                                                ToolTip="Ver Series">
                                            </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Producto" HeaderText="Producto">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Stock">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblChala1" Text='<%# Bind("Chala1") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="UM" HeaderText="UM">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Dolares">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblPrecioDolares" Text='<%# Bind("PrecioDolares") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Soles">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblPrecioSoles" Text='<%# Bind("PrecioSoles") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="TipoCambio" HeaderText="TC" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Descuento" HeaderText="Dscto-Max" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Cant." ItemStyle-HorizontalAlign="Center" Visible="false">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtCantidad" Width="55px" Font-Bold="true" Style="text-align: center;"
                                                Font-Names="Arial" onblur="F_ValidarStockGrilla(this.id);" Enabled="False"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                    <td valign="top">
                        <div id="divStocksEmpresas" style="width: 230px; padding-top: 5px">
                            <table>
                                <thead>
                                    <tr>
                                        <th style="width: 190px">
                                            Almacen
                                        </th>
                                        <th style="width: 25px">
                                            Stock
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>
                                            KARINA Principal
                                        </td>
                                        <td align="right">
                                            10
                                        </td>
                                    </tr>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <td>
                                            TOTAL
                                        </td>
                                        <td align="right">
                                            10
                                        </td>
                                    </tr>
                                </tfoot>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
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
    <input id="hfNotaPedido" type="hidden" value="0" />
    <input id="hfCodUsuario" type="hidden" value="0" />
    <input id="hfCodDepartamento" type="hidden" value="0" />
    <input id="hfCodProvincia" type="hidden" value="0" />
    <input id="hfCodDistrito" type="hidden" value="0" />
    <input id="hfCodProforma" type="hidden" value="0" />
    <input id="hfCodTraslado" type="hidden" value="0" />
    <input id="hfPartida" type="hidden" value="" />
</asp:Content>
