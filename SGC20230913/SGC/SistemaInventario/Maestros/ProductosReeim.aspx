<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ProductosReeim.aspx.cs" Inherits="SistemaInventario.Maestros.ProductosReeim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"
        type="text/javascript"></script>
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/dropzone.min.js" type="text/javascript"></script>
    <script type="text/javascript">        Dropzone.autoDiscover = false;</script>
    <link rel="stylesheet" href="../Asset/css/checkbox.css" />
    <link rel="stylesheet" href="../Asset/css/imagescss.css" />
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript"></script>
    <script src="../Scripts/inputatajos/kibo.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="ProductosReeim.js" charset="UTF-8"></script>
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link rel="stylesheet" href="../Asset/css/dropzone.css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/toars/toastr.min.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/toars/toastr.min.js" type="text/javascript"></script>
    <link href="../Asset/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/sss.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo" style="width: 1200px;">
        Productos</div>
    <div id="divTabs" style="width: 1200px; height: 500px">
        <ul>
            <li id="liRegistro"><a href="#tabRegistro">Registro</a></li>
            <li id="liConsulta"><a href="#tabConsulta">Consulta</a></li>
        </ul>
        <div id="tabRegistro">
            <table cellpadding="0" cellspacing="0" class="form-inputs">
                <tr>
                    <td>
                        <%--DATOS DEL PRODUCTO--%>
                        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 640px;
                            height: 450px">
                            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                                REGISTRO DE PRODUCTOS
                            </div>
                            <div>
                                <table cellpadding="0" cellspacing="0" class="form-inputs">
                                    <tr>
                                        <td style="font-weight: bold">
                                            Codigo
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtCodigo" runat="server" Width="470px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold">
                                                        t.c.
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTC" runat="server" Width="34px" Font-Names="Arial" ForeColor="Blue"
                                                            CssClass="Derecha" Font-Bold="True" ReadOnly="True" Text="3.286"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold;">
                                            Cod Reemp.
                                        </td>
                                        <td style="padding-left: 4px;">
                                            <asp:TextBox ID="txtCodigo2" runat="server" Width="534px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold;">
                                            Cod Fabrica
                                        </td>
                                        <td style="padding-left: 4px;">
                                            <asp:TextBox ID="txtCodigoFabrica" runat="server" Width="534px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold">
                                            Descripcion
                                        </td>
                                        <td style="padding-left: 4px;">
                                            <asp:TextBox ID="txtDescripcion" runat="server" Width="534px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold">
                                            Linea
                                        </td>
                                        <td style="padding-left: 4px;">
                                            <asp:TextBox ID="txtLinea" runat="server" Width="534px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold;">
                                            Marca
                                        </td>
                                        <td colspan='5' style="padding-left: 4px;">
                                            <asp:TextBox ID="txtMarca" runat="server" Width="534px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="display: none;">
                                        <td style="font-weight: bold;">
                                            Modelo
                                        </td>
                                        <td colspan='5' style="padding-left: 4px;">
                                            <asp:TextBox ID="txtModelo" runat="server" Width="534px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr style="display: none;">
                                        <td style="font-weight: bold">
                                            Medida
                                        </td>
                                        <td colspan='5'>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtMedida" runat="server" Width="211px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold">
                                                        Posicion
                                                    </td>
                                                    <td style="padding-left: 24px;">
                                                        <asp:TextBox ID="txtPosicion" runat="server" Width="240px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr style="display: none;">
                                        <td style="font-weight: bold">
                                            Partida ARan
                                        </td>
                                        <td style="padding-left: 4px;">
                                            <asp:TextBox ID="txtPartidaArancelaria" runat="server" Width="534px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold">
                                            Año
                                        </td>
                                        <td colspan='5'>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="padding-left: 2px;">
                                                        <asp:TextBox ID="txtAño" runat="server" Width="211px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="padding-left: 3px; font-weight: bold">
                                                        UM COMPRA
                                                    </td>
                                                    <td style="padding-left: 9px;">
                                                        <div id="div_umcompra">
                                                            <asp:DropDownList ID="ddlUMCompra" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="79">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td style="padding-left: 2px; font-weight: bold">
                                                        UM Venta
                                                    </td>
                                                    <td style="padding-left: 27px;">
                                                        <div id="div_umventa">
                                                            <asp:DropDownList ID="ddlUMVenta" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="80">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold">
                                            Costo C/Igv
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtCostoConIgv" runat="server" Width="75px" Font-Names="Arial" ForeColor="Blue"
                                                            CssClass="Derecha" Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold">
                                                        Moneda
                                                    </td>
                                                    <td style="padding-left: 6px;">
                                                        <div id="div_moneda">
                                                            <asp:DropDownList ID="ddlMoneda" runat="server" Font-Names="Arial" Width="79" ForeColor="Blue"
                                                                Font-Bold="True" Enabled="False">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td style="padding-left: 3px; font-weight: bold">
                                                        Margen 1
                                                    </td>
                                                    <td style="padding-left: 19px;">
                                                        <asp:TextBox ID="txtMargen" runat="server" Width="75px" Font-Names="Arial" ForeColor="Blue"
                                                            CssClass="Derecha" Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="padding-left: 2px; font-weight: bold">
                                                        Margen 2
                                                    </td>
                                                    <td style="padding-left: 26px;">
                                                        <asp:TextBox ID="txtMargen2" runat="server" Width="75px" Font-Names="Arial" ForeColor="Blue"
                                                            CssClass="Derecha" Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold">
                                            Cost. C/Igv S/
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtCostoSolesIgv" runat="server" Width="75px" Font-Names="Arial"
                                                            CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="padding-left: 140px; font-weight: bold">
                                                        Precio MIN
                                                    </td>
                                                    <td style="padding-left: 11px;">
                                                        <asp:TextBox ID="txtPrecio" runat="server" Width="75px" Font-Names="Arial" ForeColor="Blue"
                                                            CssClass="Derecha" Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="padding-left: 2px; font-weight: bold">
                                                        Precio SUG
                                                    </td>
                                                    <td style="padding-left: 16px;">
                                                        <asp:TextBox ID="txtPrecio2" runat="server" Width="75px" Font-Names="Arial" ForeColor="Blue"
                                                            CssClass="Derecha" Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 2px; font-weight: bold; display: none;">
                                            Stock Max.
                                            <asp:TextBox ID="txtStockMinimo" runat="server" Width="75px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" Text="0"></asp:TextBox>
                                        </td>
                                        <td style="padding-left: 16px; font-weight: bold; display: none;">
                                            <asp:TextBox ID="txtStockMaximo" runat="server" Width="74px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" Text="0"></asp:TextBox>
                                        </td>
                                        <td style="padding-left: 16px; display: none;">
                                            <asp:TextBox ID="txtDescuento" runat="server" Width="75px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" Text="0"></asp:TextBox>
                                        </td>
                                        <td style="padding-left: 0px; display: none;">
                                            <div id="div_Familia">
                                                <asp:DropDownList ID="ddlFamilia" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="213">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="linea-button">
                                <asp:Button ID="btnGrabar" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120px" />
                            </div>
                        </div>
                    </td>
                    <td>
                        <%--IMAGEN--%>
                        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 500px;
                            height: 450px">
                            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                                IMAGEN DEL PRODUCTO</div>
                            <div>
                                <table cellpadding="0" cellspacing="0" class="form-inputs">
                                    <tr>
                                        <td style="height: 290px">
                                            <%--                                                              <span style="padding-left:140px; padding-top:145px">Imagen del Artículo</span>--%>
                                            <span>
                                                <input id="hid_tipo_operacion_mantenimiento" type="hidden" />
                                                <input id="hid_id_mantenimiento" type="hidden" />
                                                <input id="hid_id_logo" type="hidden" />
                                            </span>
                                            <div id="drop" style="padding-top: 5px;">
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div id="tabConsulta">
            <div id='divConsulta' class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    Criterio de busqueda
                </div>
                <div class="ui-jqdialog-content">
                    <table cellpadding="0" cellspacing="0" class="form-inputs" width="700">
                        <tr>
                            <td style="font-weight: bold">
                                Busqueda
                            </td>
                            <td>
                                <asp:TextBox ID="txtDescripcionConsulta" runat="server" Width="280" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDescripcionConsulta2" runat="server" Width="280" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="display: none;">
                                <asp:TextBox ID="txtDescripcionConsulta3" runat="server" Width="280" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="padding-left: 5px; font-weight: bold;">
                                Estado
                            </td>
                            <td style="padding-left: 22px; font-weight: bold;">
                                <div id="div_FiltroEstados">
                                    <asp:DropDownList ID="ddlFiltroCodEstado" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True" Width="78">
                                        <asp:ListItem Value="0">Todos</asp:ListItem>
                                        <asp:ListItem Value="1" Selected>Activos</asp:ListItem>
                                        <asp:ListItem Value="2">Inactivos</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td style="font-weight: bold; display: none;">
                                familia
                            </td>
                            <td style="display: none;">
                                <div id="div_familiaconsulta">
                                    <asp:DropDownList ID="ddlFamiliaConsulta" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="linea-button">
                    <asp:Button ID="btnLimpiarConsulta" runat="server" Text="LIMPIAR" CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                    <asp:Button ID="btnBuscarConsulta" runat="server" Text="Buscar" CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
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
                            <label id="lblNumeroConsulta">0
                            </label>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="div_consulta" style="padding-top: 5px;">
                <asp:GridView ID="grvConsulta" runat="server" AutoGenerateColumns="False" border="0"
                    CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="1172px">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="55px">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                    ToolTip="ELIMINAR PRODUCTO" OnClientClick="F_AnularRegistro(this); return false;" />
                                <asp:ImageButton runat="server" ID="imgEditarRegistro" ImageUrl="../Asset/images/btnEdit.gif"
                                    ToolTip="EDITAR PRODUCTO" OnClientClick="F_EditarRegistro(this); return false;" />
                                <asp:ImageButton runat="server" ID="imgVisualizarRegistro" ImageUrl="../Asset/images/Viewx16.png"
                                    ToolTip="VISUALIZAR IMAGEN" OnClientClick="F_VisualizarRegistro(this); return false;" />
                                <%--    <asp:ImageButton runat="server" ID="imgHistorialCosto" ImageUrl="../Asset/images/historial4.png"
                                    ToolTip="HISTORIAL DE COSTOS" OnClientClick="F_HistorialCostos(this); return false;"
                                    Width="18px" Height="18px" />
                                <asp:ImageButton runat="server" ID="imgDetalleProducto" ImageUrl="../Asset/images/texto.png"
                                    ToolTip="DETALLE PRODUCTO" OnClientClick="F_DetalleProducto(this); return false;" />--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--            <asp:TemplateField>
                            <ItemTemplate>
                                <img id="imgMas" alt="" style="cursor: pointer" src="../Asset/images/plus.gif" onclick="imgMas_Click(this);"
                                    title="Ver Detalle" />
                                <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                                    <asp:GridView ID="grvDetalle" runat="server" border="0" CellPadding="0" CellSpacing="1"
                                        AutoGenerateColumns="False" GridLines="None" class="GridView">
                                        <Columns>
                                            <asp:BoundField DataField="Linea" HeaderText="Linea">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Modelo" HeaderText="Modelo">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Año" HeaderText="Año">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Motor" HeaderText="Motor">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CajaCambio" HeaderText="Caja Cambio">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Transmision" HeaderText="Transmision">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Filtro" HeaderText="Filtro">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Codigo">
                            <ItemStyle HorizontalAlign="LEFT" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblCodigoProducto" Text='<%# Bind("CodigoProducto") %>'
                                    CssClass="detallesart"></asp:Label>
                                <asp:HiddenField ID="lblCodigo" runat="server" Value='<%# Bind("Codigo") %>' />
                                <asp:HiddenField ID="hfModelo" runat="server" Value='<%# Bind("Modelo") %>' />
                                <asp:HiddenField ID="hfMedida" runat="server" Value='<%# Bind("Medida") %>' />
                                <asp:HiddenField ID="hfMarca" runat="server" Value='<%# Bind("Marca") %>' />
                                <asp:HiddenField ID="hfPosicion" runat="server" Value='<%# Bind("Posicion") %>' />
                                <asp:HiddenField ID="hfCodMoneda" runat="server" Value='<%# Bind("CodMoneda") %>' />
                                <asp:HiddenField ID="hfCodUnidadCompra" runat="server" Value='<%# Bind("CodUnidadCompra") %>' />
                                <asp:HiddenField ID="hfCodUnidadVenta" runat="server" Value='<%# Bind("CodUnidadVenta") %>' />
                                <asp:HiddenField ID="hfCodFamilia" runat="server" Value='<%# Bind("CodFamilia") %>' />
                                <asp:HiddenField ID="hfFactor" runat="server" Value='<%# Bind("Factor") %>' />
                                <asp:HiddenField ID="hfCostoMercado" runat="server" Value='<%# Bind("CostoMercado") %>' />
                                <asp:HiddenField ID="hfCostoSoles" runat="server" Value='<%# Bind("CostoSoles") %>' />
                                <asp:HiddenField ID="hfAnio" runat="server" Value='<%# Bind("Anio") %>' />
                                <asp:HiddenField ID="hfStockMaximo" runat="server" Value='<%# Bind("StockMaximo") %>' />
                                <asp:HiddenField ID="hfStockMinimo" runat="server" Value='<%# Bind("StockMinimo") %>' />
                                <asp:HiddenField ID="hfCodigoAlternativo" runat="server" Value='<%# Bind("CodigoAlternativo") %>' />
                                <asp:HiddenField ID="hfPartidaArancelaria" runat="server" Value='<%# Bind("PartidaArancelaria") %>' />
                                <asp:HiddenField ID="hfDescripcionCorta" runat="server" Value='<%# Bind("DescripcionCorta") %>' />
                                <asp:HiddenField ID="hIdImagenProducto1" runat="server" Value='<%# Bind("IdImagenProducto1") %>' />
                                <asp:HiddenField ID="hfPrecio1Original" runat="server" Value='<%# Bind("Precio1Original") %>' />
                                <asp:HiddenField ID="hfPrecio2Original" runat="server" Value='<%# Bind("Precio2Original") %>' />
                                <asp:HiddenField ID="hfCosto" runat="server" Value='<%# Bind("Costo") %>' />
                                <asp:HiddenField ID="hfDetalleCargado" runat="server" Value='0' />
                                <asp:HiddenField ID="hfCodEstado" runat="server" Value='<%# Bind("CodEstado") %>' />
                                <asp:HiddenField ID="hfMargen1" runat="server" Value='<%# Bind("M1") %>' />
                                <asp:HiddenField ID="hfMargen2" runat="server" Value='<%# Bind("M2") %>' />
                                <asp:HiddenField ID="hfCodigoFabrica" runat="server" Value='<%# Bind("CodigoFabrica") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CodigoAlternativo" HeaderText="Codigo Reem">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Producto">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblProducto" Text='<%# Bind("Producto") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Linea">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDescripcionIngles" Text='<%# Bind("DescripcionIngles") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Marca">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblMarca" Text='<%# Bind("Marca") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Stock" HeaderText="Stock">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UM" HeaderText="UM">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <%--                        <asp:TemplateField HeaderText="Costo">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblCosto" Text='<%# Bind("CostoSimbolo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <%--                        <asp:TemplateField HeaderText="M1">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblM1" Text='<%# Bind("M1") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="M2">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblM2" Text='<%# Bind("M2") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:BoundField DataField="Precio" HeaderText="Pre. Min">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Precio2" HeaderText="Pre. Sug">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Dscto" Visible="false">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDescuento" Text='<%# Bind("Descuento") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Moneda" HeaderText="Mon">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <%--                        <asp:BoundField DataField="Familia" HeaderText="Familia">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>--%>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <div id="divEdicionRegistro" style="display: none;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 640px;">
                        <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix"
                            style="width: 640px">
                            DATOS PRODUCTO
                        </div>
                        <div class="ui-jqdialog-content">
                            <table cellpadding="0" cellspacing="0" class="form-inputs">
                                <tr>
                                    <td style="font-weight: bold">
                                        Codigo
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtCodigoProductoEdicion" runat="server" Width="470px" Font-Names="Arial"
                                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                </td>
                                                <td style="font-weight: bold">
                                                    t.c.
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTCEdicion" runat="server" Width="34px" Font-Names="Arial" ForeColor="Blue"
                                                        CssClass="Derecha" Font-Bold="True" ReadOnly="True" Text="2.796"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-weight: bold">
                                        Cod Reemp.
                                    </td>
                                    <td style="padding-left: 4px;">
                                        <asp:TextBox ID="txtCodigo2Edicion" runat="server" Width="533px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-weight: bold">
                                        Cod Fabrica.
                                    </td>
                                    <td style="padding-left: 4px;">
                                        <asp:TextBox ID="txtCodigoFabricaEdicion" runat="server" Width="533px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-weight: bold">
                                        Descripcion
                                    </td>
                                    <td style="padding-left: 4px;">
                                        <asp:TextBox ID="txtDescripcionEdicion" runat="server" Width="533px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-weight: bold">
                                        Linea
                                    </td>
                                    <td style="padding-left: 4px;">
                                        <asp:TextBox ID="txtLineaEdicion" runat="server" Width="532px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-weight: bold;">
                                        Marca
                                    </td>
                                    <td style="padding-left: 4px;">
                                        <asp:TextBox ID="txtMarcaEdicion" runat="server" Width="532px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-weight: bold">
                                        Año
                                    </td>
                                    <td colspan='5'>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtAñoEdicion" runat="server" Width="211px" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True"></asp:TextBox>
                                                </td>
                                                <td style="padding-left: 3px; font-weight: bold">
                                                    UM COMPRA
                                                </td>
                                                <td style="padding-left: 2px;">
                                                    <div id="div_CompraEdicion">
                                                        <asp:DropDownList ID="ddlCompraEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" Width="78">
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td style="padding-left: 2px; font-weight: bold">
                                                    UM Venta
                                                </td>
                                                <td style="padding-left: 35px;">
                                                    <div id="div_VentaEdicion">
                                                        <asp:DropDownList ID="ddlVentaEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" Width="79">
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-weight: bold">
                                        Cost. C/Igv
                                    </td>
                                    <td colspan='5'>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtCostoEdicion" runat="server" Width="75px" Font-Names="Arial"
                                                        CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                </td>
                                                <td style="padding-left: 2px; font-weight: bold">
                                                    Moneda
                                                </td>
                                                <td style="padding-left: 8px;">
                                                    <div id="div_MonedaEdicion">
                                                        <asp:DropDownList ID="ddlMonedaEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" Width="78">
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td style="padding-left: 3px; font-weight: bold">
                                                    Margen
                                                </td>
                                                <td style="padding-left: 19px;">
                                                    <asp:TextBox ID="txtMargenEdicion" runat="server" Width="74px" Font-Names="Arial"
                                                        CssClass="Derecha" ForeColor="Blue" Font-Bold="True" Text="0.00"></asp:TextBox>
                                                </td>
                                                <td style="padding-left: 2px; font-weight: bold">
                                                    Margen 2
                                                </td>
                                                <td style="padding-left: 34px;">
                                                    <asp:TextBox ID="txtMargen2Edicion" runat="server" Width="75px" Font-Names="Arial"
                                                        ForeColor="Blue" CssClass="Derecha" Font-Bold="True"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-weight: bold">
                                        Cost. C/Igv S/
                                    </td>
                                    <td colspan='5'>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtCostoSolesEdicion" runat="server" Width="75px" Font-Names="Arial"
                                                        CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                </td>
                                                <td style="padding-left: 140px; font-weight: bold">
                                                    Precio MIN
                                                </td>
                                                <td style="padding-left: 4px;">
                                                    <asp:TextBox ID="txtPrecioEdicion" runat="server" Width="74px" Font-Names="Arial"
                                                        CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                </td>
                                                <td style="font-weight: bold; padding-left: 2px;">
                                                    Precio SUG
                                                </td>
                                                <td style="padding-left: 24px;">
                                                    <asp:TextBox ID="txtPrecio2Edicion" runat="server" Width="75px" Font-Names="Arial"
                                                        CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-weight: bold">
                                        Estado
                                    </td>
                                    <td style="padding-left: 4px;">
                                        <div id="div_EstadoEdicion">
                                            <asp:DropDownList ID="ddlEstadoEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" Width="78">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                </tr>
                                <tr style="display: none;">
                                    <td style="font-weight: bold">
                                        Partida Aran
                                    </td>
                                    <td style="padding-left: 4px;">
                                        <asp:TextBox ID="txtPartidaArancelariaEdicion" runat="server" Width="534px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="display: none;">
                                    <td style="padding-left: 2px; font-weight: bold">
                                        Stock Min.
                                    </td>
                                    <td style="padding-left: 18px;">
                                        <asp:TextBox ID="txtStockMinimoEdicion" runat="server" Width="75px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                    <td style="padding-left: 2px; font-weight: bold">
                                        Stock Max.
                                    </td>
                                    <td style="padding-left: 13px;">
                                        <asp:TextBox ID="txtStockMaximoEdicion" runat="server" Width="74px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                    <td style="padding-left: 2px; font-weight: bold">
                                    </td>
                                    <td style="padding-left: 14px;">
                                        <asp:TextBox ID="txtDescuentoEdicion" runat="server" Width="74px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True" Style="display: none;" Text="0.00"></asp:TextBox>
                                    </td>
                                    <td style="display: none;">
                                        <div id="div_FamiliaEdicion">
                                            <asp:DropDownList ID="ddlFamiliaEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" Width="213">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                </tr>
                                <tr style="display: none;">
                                    <td style="font-weight: bold">
                                        Modelo
                                    </td>
                                    <td style="padding-left: 4px;">
                                        <asp:TextBox ID="txtModeloEdicion" runat="server" Width="534px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="display: none;">
                                    <td style="font-weight: bold">
                                        Medida
                                    </td>
                                    <td colspan='5'>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtMedidaEdicion" runat="server" Width="211px" Font-Names="Arial"
                                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                </td>
                                                <td style="font-weight: bold">
                                                    Posicion
                                                </td>
                                                <td style="padding-left: 17px;">
                                                    <asp:TextBox ID="txtPosicionEdicion" runat="server" Width="247px" Font-Names="Arial"
                                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="linea-button">
                            <asp:Button ID="btnEdicion" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                Font-Names="Arial" Font-Bold="True" Width="120px" />
                        </div>
                    </div>
                </td>
                <td style="padding-left: 5px;" valign="top">
                    <%--IMAGEN--%>
                    <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 550px;
                        height: 450px">
                        <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix"
                            style="width: 550px">
                            IMAGEN DEL PRODUCTO</div>
                        <div>
                            <table cellpadding="0" cellspacing="0" class="form-inputs">
                                <tr>
                                    <td style="height: 290px" align="center">
                                        <%--<span style="padding-left:140px; padding-top:145px">Imagen del Artículo</span>--%>
                                        <span>
                                            <input id="hid_id_nombre_edit" type="hidden" />
                                            <input id="hid_id_logo_Edit" type="hidden" />
                                            <input id="hid_id_logo_Edit2" type="hidden" />
                                        </span>
                                        <div id="div_drop_Edit" style="padding-top: 5px;">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <%--VISUALIZACION DE IMAGENES--%>
    <div id="divVisualizarImagen" class="wrapper" style="display: none;">
        <table>
            <tr style="max-height: 100px;">
                <td>
                    <%--CAMPOS --%>
                    <div>
                        <table>
                            <tr>
                                <td style="font-weight: bold; width: 50px; text-align: right">
                                    Código
                                </td>
                                <td colspan='5'>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtCodigoVisualizacion" runat="server" Width="100px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold; width: 60px; text-align: right">
                                                Código 2
                                            </td>
                                            <td style="padding-left: 5px;">
                                                <asp:TextBox ID="txtCodigo2Visualizacion" runat="server" Width="100px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold; width: 80px; text-align: right">
                                                Descripcion
                                            </td>
                                            <td style="padding-left: 5px;">
                                                <asp:TextBox ID="txtDescripcionVisualizacion" runat="server" Width="280px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold; width: 60px; text-align: right">
                                                Medida
                                            </td>
                                            <td style="padding-left: 5px;">
                                                <asp:TextBox ID="txtMedidaVisualizacion" runat="server" Width="230px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; width: 50px; text-align: right">
                                    Linea
                                </td>
                                <td colspan='5'>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="padding-left: 0px;">
                                                <asp:TextBox ID="txtLineaVisualizacion" runat="server" Width="100px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold; width: 60px; text-align: right">
                                                Marca
                                            </td>
                                            <td style="padding-left: 5px;">
                                                <asp:TextBox ID="txtMarcaVisualizacion" runat="server" Width="100px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold; width: 80px; text-align: right">
                                                Modelo
                                            </td>
                                            <td style="padding-left: 5px;">
                                                <asp:TextBox ID="txtModeloVisualizacion" runat="server" Width="280px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold; width: 60px; text-align: right">
                                                Posicion
                                            </td>
                                            <td style="padding-left: 5px;">
                                                <asp:TextBox ID="txtPosicionVisualizacion" runat="server" Width="121px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold; width: 50px; text-align: right">
                                                Año
                                            </td>
                                            <td style="padding-left: 5px;">
                                                <asp:TextBox ID="txtAnovisualizacion" runat="server" Width="50px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <ul id="luImagenes" class="ul-float">
                    </ul>
                </td>
            </tr>
        </table>
    </div>
    <div id="div_DetalleProducto" style="display: none;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td style="padding-top: 10px; font-weight: bold">
                    PRODUCTO
                </td>
                <td style="padding-top: 10px;">
                    <asp:TextBox ID="txtProductoDetalle" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    MODELO
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtModeloDetalle" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    AÑO
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtAñoDetalle" runat="server" Width="500px" Font-Names="Arial" ForeColor="Blue"
                        Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Motor
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtMotorDetalle" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Caja Cambio
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtCajaCambio" runat="server" Width="500px" Font-Names="Arial" ForeColor="Blue"
                        Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Transmision
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtTransmision" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Filtro
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtFiltro" runat="server" Width="500px" Font-Names="Arial" ForeColor="Blue"
                        Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="2">
                    <asp:Button ID="btnGrabarDetalle" runat="server" Text="GRABAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px;" colspan="2">
                    <div id="div_ProductoDetalle">
                        <asp:GridView ID="grvProductoDetalle" runat="server" AutoGenerateColumns="False"
                            border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                            Width="860px">
                            <Columns>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                            ToolTip="ELIMINAR DETALLE PRODUCTO" OnClientClick="F_EliminarDetalleProducto(this); return false;" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgEditarRegistro" ImageUrl="../Asset/images/btnEdit.gif"
                                            ToolTip="EDITAR DETALLE PRODUCTO" OnClientClick="F_EditarDetalleProducto(this); return false;" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Linea" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblLinea" Text='<%# Bind("Linea") %>'></asp:Label>
                                        <asp:HiddenField ID="hfCodProductoModelo" runat="server" Value='<%# Bind("CodProductoModelo") %>' />
                                        <asp:HiddenField ID="hfCodModelo" runat="server" Value='<%# Bind("CodModeloVehiculo") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Modelo" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblModelo" Text='<%# Bind("Modelo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Año" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblAño" Text='<%# Bind("Año") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Motor" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblMotor" Text='<%# Bind("Motor") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Caja Cambio" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCajaCambio" Text='<%# Bind("CajaCambio") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Transmision" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblTransmision" Text='<%# Bind("Transmision") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Filtro" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblFiltro" Text='<%# Bind("Filtro") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="div_DetalleProductoEditar" style="display: none;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td style="padding-top: 10px; font-weight: bold">
                    PRODUCTO
                </td>
                <td style="padding-top: 10px;">
                    <asp:TextBox ID="txtProductoDetalleEdicion" runat="server" Width="370px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    MODELO
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtModeloDetalleEdicion" runat="server" Width="370px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    AÑO
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtAñoDetalleEdicion" runat="server" Width="370px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Motor
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtMotorDetalleEdicion" runat="server" Width="370px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Caja Cambio
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtCajaCambioEdicion" runat="server" Width="370px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Transmision
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtTransmisionEdicion" runat="server" Width="370px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Filtro
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtFiltroEdicion" runat="server" Width="370px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 10px;" align="right" colspan="2">
                    <asp:Button ID="btnGrabarDetalleEdicion" runat="server" Text="GRABAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                </td>
            </tr>
        </table>
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
    <div id="div_HistorialCostos" style="display: none;">
        <div>
            <table>
                <tr>
                    <td style="font-weight: bold">
                        Producto
                    </td>
                    <td style="padding-left: 4px;">
                        <asp:TextBox ID="txtProductoHistorial" runat="server" Width="577px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True" Enabled="false"></asp:TextBox>
                    </td>
                    <td style="font-weight: bold">
                        Marca
                    </td>
                    <td style="padding-left: 4px;">
                        <asp:TextBox ID="txtMarcaHistorial" runat="server" Width="200px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True" Enabled="false"></asp:TextBox>
                    </td>
                    <td style="font-weight: bold">
                        Costo Actual
                    </td>
                    <td style="padding-left: 4px;">
                        <asp:TextBox ID="txtCostoActual" runat="server" Width="100px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="div_tab2" style="width: 1120px;">
            <ul>
                <li id="liCostos"><a href="#tabCostos">Costos</a></li>
                <li id="liPrecios"><a href="#tabPrecios">Precios</a></li>
            </ul>
            <div id="tabCostos">
                <div id="div_grvHistorialCostos" style="padding-top: 5px;">
                    <asp:GridView ID="grvHistorialCostos" runat="server" AutoGenerateColumns="False"
                        border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                        Width="1100px">
                        <Columns>
                            <asp:BoundField DataField="FechaRegistro" HeaderText="Registro" HeaderStyle-Width="80px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Usuario" HeaderText="Usuario" HeaderStyle-Width="160px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Modulo" HeaderText="Modulo-Transaccion" HeaderStyle-Width="170px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FechaDocumento" HeaderText="Emision" HeaderStyle-Width="50px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Proveedor" HeaderText="Proveedor" HeaderStyle-Width="250px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CostoMercado_ANTERIOR" HeaderText="Costo Anterior" HeaderStyle-Width="40px"
                                Visible="false">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CostoMercado_NUEVO" HeaderText="Costo" HeaderStyle-Width="60px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div id="tabPrecios">
                <div id="div_grvHistorialPrecios" style="padding-top: 5px;">
                    <asp:GridView ID="grvHistorialPrecios" runat="server" AutoGenerateColumns="False"
                        border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                        Width="1100px">
                        <Columns>
                            <asp:BoundField DataField="FechaRegistro" HeaderText="Registro" HeaderStyle-Width="80px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Usuario" HeaderText="Usuario" HeaderStyle-Width="60px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Modulo" HeaderText="Modulo-Transaccion" HeaderStyle-Width="70px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CodigoProductoAnterior" HeaderText="Codigo Anterior" HeaderStyle-Width="40px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CodigoProductoNuevo" HeaderText="Codigo Nuevo" HeaderStyle-Width="60px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DscProductoAnterior" HeaderText="Descripcion Anterior"
                                HeaderStyle-Width="40px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DscProductoNuevo" HeaderText="Descripcion Nuevo" HeaderStyle-Width="60px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PrecioAnterior" HeaderText="Precio Anterior" HeaderStyle-Width="40px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PrecioNuevo" HeaderText="Precio Nuevo" HeaderStyle-Width="40px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Precio2Anterior" HeaderText="Precio2 Anterior" HeaderStyle-Width="40px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Precio2Nuevo" HeaderText="Precio2 Nuevo" HeaderStyle-Width="40px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Precio3Anterior" HeaderText="Precio3 Anterior" HeaderStyle-Width="40px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Precio3Nuevo" HeaderText="Precio3 Nuevo" HeaderStyle-Width="40px">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <input id="hfCodCtaCte" type="hidden" value="0" />
    <input id="hfCodCtaCteConsulta" type="hidden" value="0" />
    <input id="hfCodigoTemporal" type="hidden" value="0" />
    <input id="hfCodProducto" type="hidden" value="0" />
    <input id="hfMoneda" type="hidden" value="0" />
    <input id="hfCodModeloDetalle" type="hidden" value="0" />
    <input id="hfCodModeloDetalleEdicion" type="hidden" value="0" />
    <input id="hfCodProductoModelo" type="hidden" value="0" />
    <input id="hfCodLinea" type="hidden" value="0" />
    <input id="hfCodLineaEdicion" type="hidden" value="0" />
    <input id="hfCodMarca" type="hidden" value="0" />
    <input id="hfCodMarcaEdicion" type="hidden" value="0" />
</asp:Content>
