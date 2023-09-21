<%@ Page Title="Kardex" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Kardex.aspx.cs" Inherits="SistemaInventario.Inventario.Kardex" %>
   
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"   type="text/javascript"></script>     
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript" charset="UTF-8"></script>       
    <script type="text/javascript" language="javascript" src="Kardex.js" charset="UTF-8"></script>
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"   type="text/css" />     
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
   <link href="../Asset/toars/toastr.min.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/toars/toastr.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo" style="width: 1000px">
        Kardex</div>
    <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 1000px">
        <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix"
            style="width: 1000px">
            Criterio de busqueda
        </div>
        <div id="divConsultaArticulo" style="width: 1000px">
            <table cellpadding="0" cellspacing="0" class="form-inputs" width="1000">
                <tr>
                    <td style="padding-left: 5px; font-weight: bold">
                        Articulo
                    </td>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtArticulo" runat="server" Width="520px" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold">
                                    Desde
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDesde" runat="server" Width="55px" CssClass="Jq-ui-dtp" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold">
                                    Hasta
                                </td>
                                <td>
                                    <asp:TextBox ID="txtHasta" runat="server" Width="55px" CssClass="Jq-ui-dtp" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold">
                                    Stock
                                </td>
                                <td>
                                    <asp:Label ID="lblStock" runat="server" Text="0.00" ForeColor="Blue" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                </td>
                                 <td style="font-weight: bold; color: #0000FF;" >
                                    INGRESOS
                                </td>
                                <td>
                                    <asp:Label ID="lblIngresos" runat="server" Text="0.00" ForeColor="Blue" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                </td>
                              
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        Sucursal
                    </td>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <div id="div_Sucursal">
                                        <asp:DropDownList ID="ddlSucursal" runat="server" Font-Names="Arial" ForeColor="Blue"
                                            Font-Bold="True" Width="117">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td style="font-weight: bold">
                                    Operacion
                                </td>
                                <td>
                                    <div id="div_Operacion">
                                        <asp:DropDownList ID="ddlOperacion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                            Font-Bold="True" Width="117">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td style="font-weight: bold">
                                    Razon Social
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRazonSocial" runat="server" Width="260px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold">
                                    Costo
                                </td>
                                <td>
                                    <asp:Label ID="lblCosto" runat="server" Text="0.00" ForeColor="Blue" Font-Bold="True"></asp:Label>
                                </td>
                                <td style="font-weight: bold">
                                    Moneda
                                </td>
                                <td>
                                    <asp:Label ID="lblMoneda" runat="server" Text="DOLARES" ForeColor="Blue" Font-Bold="True"></asp:Label>
                                </td>
                                   <td style="font-weight: bold; color: #FF0000;">
                                    SALIDAS
                                </td>
                                <td>
                                    <asp:Label ID="lblSalidas" runat="server" Text="0.00" ForeColor="Red" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div class="linea-button">
            <asp:Button ID="btnNuevo" runat="server" Text="nuevo" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                Font-Names="Arial" Font-Bold="True" Width="120" />
            <asp:Button ID="btnBuscar" runat="server" Text="BUSCAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
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
                                            <label id="lblNumeroConsulta">0</label>
                                        </td>                                
                                    </tr>
                                </table>
            </div>
    <div id="div_grvKardex" style="padding-top: 5px;">
        <asp:GridView ID="grvKardex" runat="server" AutoGenerateColumns="False" border="0"
            CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="1000px"
            OnRowDataBound="grvConsulta_RowDataBound">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="../Asset/images/EliminarBtn.png"
                            ToolTip="ELIMINAR AJUSTE" OnClientClick="F_EliminarRegistro(this); return false;" />
                        <asp:ImageButton runat="server" ID="imgEditarDocumento" ImageUrl="../Asset/images/btnEdit.gif"
                            ToolTip="EDITAR SALDO INICIAL" OnClientClick="F_EditarSaldoInicial(this); return false;" />
                             <asp:ImageButton runat="server" ID="imgPdf2" ImageUrl="~/Asset/images/pdf.png" ToolTip="Generar Version PDF"
                             OnClientClick="F_ImprimirDocumento(undefined,this,'imgPdf2','PDF'); return false;" />
                        <asp:HiddenField ID="hfCodigo" runat="server" Value='<%# Bind("Codigo") %>'  />
                        <asp:HiddenField ID="hfCodTipoOperacion" runat="server" Value='<%# Bind("CodTipoOperacion") %>' />
                        <asp:HiddenField ID="hfObservacion" runat="server" Value='<%# Bind("Observacion") %>' />
                        <asp:HiddenField ID="hfcodtipodoc" runat="server" Value='<%# Bind("CodTipoDoc") %>' />
                        <asp:HiddenField ID="hfcoddoc" runat="server" Value='<%# Bind("CodDoc") %>' />
                        <asp:HiddenField ID="hfcodtipodocnota" runat="server" Value='<%# Bind("CodTipoDocNota") %>' />
                        <asp:HiddenField ID="hfDetalleCargado" runat="server" Value='0' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="A">
                    <ItemTemplate>
                        <img id="imgMasAu" alt="" style="cursor: pointer" src="../Asset/images/plus.gif" onclick="imgMasAu_Click(this);"
                            title="Ver Detalle" />
                        <asp:Panel ID="pnlOrdersAu" runat="server" Style="display: none">
                            <asp:GridView ID="grvAuditoria" runat="server" border="0" CellPadding="0" CellSpacing="1"
                                AutoGenerateColumns="False" GridLines="None" class="GridView">
                                <Columns>
                                    <asp:BoundField DataField="Auditoria" HeaderText="Auditoria">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <img id="imgMas" alt="" style="cursor: pointer" src="../Asset/images/plus.gif" onclick="imgMas_Click(this);"
                            title="Ver Detalle" />
                        <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                            <asp:GridView ID="grvDetalle" runat="server" border="0" CellPadding="0" CellSpacing="1"
                                AutoGenerateColumns="False" GridLines="None" class="GridView">
                                <Columns>
                                    <asp:BoundField DataField="Observacion" HeaderText="Observacion">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Almacen" HeaderText="Almacen">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Operacion" HeaderText="Operacion">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="RazonSocial" HeaderText="RazonSocial">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Registro" HeaderText="Registro">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
               <asp:TemplateField HeaderText="Numero">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblnumero" Text='<%# Bind("Numero") %>' CssClass="detallesart"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="FechaAnexo" HeaderText="Fecha Anexo">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Anexo" HeaderText="Anexo">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="TC" HeaderText="TC">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Costo">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Right" />
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblCosto" Text='<%# Bind("Costo") %>' CssClass="detallesart"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Precio">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Right" />
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblPrecio" Text='<%# Bind("Precio") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Moneda" HeaderText="Moneda">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Inicial">
                    <ItemStyle HorizontalAlign="Right" />
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblInicial" Text='<%# Bind("Inicial") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ingreso">
                    <ItemStyle HorizontalAlign="Right" />
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblIngreso" Text='<%# Bind("Ingreso") %>' CssClass="detallesart2"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Salida">
                    <ItemStyle HorizontalAlign="Right" />
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblSalida" Text='<%# Bind("Salida") %>'  CssClass="detallesart3"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Final" HeaderText="Final">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="UM" HeaderText="UM">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
    <div id="divEdicionRegistro" style="display: none;">
        <div class="ui-jqdialog-content ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <table cellpadding="0" cellspacing="0" class="form-inputs">
                <tr>
                    <td style="font-weight: bold">
                        STOCK ACTUAL
                    </td>
                    <td>
                        <asp:TextBox ID="txtStockActual" runat="server" Width="75px" Font-Names="Arial" ForeColor="Blue"
                            Font-Bold="True" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        SALDO INICIAL
                    </td>
                    <td>
                        <asp:TextBox ID="txtIngreso" runat="server" Width="75px" Font-Names="Arial" ForeColor="Blue"
                            Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        Stock Final
                    </td>
                    <td>
                        <asp:TextBox ID="txtStockFinal" runat="server" Width="75px" Font-Names="Arial" ForeColor="Blue"
                            Font-Bold="True" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div class="ui-jqdialog-content ui-jqgrid ui-widget ui-widget-content ui-corner-all"
            style="margin-top: 5px">
            <table cellpadding="0" cellspacing="0" class="form-inputs">
                <tr>
                    <td style="font-weight: bold; width: 105px;">
                        <label id="lblEtiquetaCosto">
                        </label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCosto" runat="server" Width="75px" Font-Names="Arial" ForeColor="Blue"
                            Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table cellpadding="0" cellspacing="0" class="form-inputs">
                <tr>
                    <td colspan='6' align="right">
                        <asp:Button ID="btnEdicion" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Width="120px" />
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
        <input id="hfStockSinSaldoInicial" type="hidden" value="0" />
        <input id="hfCodMovimiento" type="hidden" value="0" />
        <input id="hfCodCtaCte" type="hidden" value="0" />
        <input id="hfCodCtaCteConsulta" type="hidden" value="0" />
        <input id="hfCodigoTemporal" type="hidden" value="0" />
        <input id="hfCodDocumentoVenta" type="hidden" value="0" />
        <input id="hfCodSede" type="hidden" value="0" />
</asp:Content>
