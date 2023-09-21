<%@ Page Title="Retenciones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"   CodeBehind="RegistroRetenciones.aspx.cs" Inherits="SistemaInventario.Ventas.RegistroRetenciones" %>
 
 <asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>   
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js" type="text/javascript"></script>       
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/alertify.min.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript" charset="UTF-8"></script>
    <script type="text/javascript" language="javascript" src="RegistroRetenciones.js"   charset="UTF-8"></script>     
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"  type="text/css" />      
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.core.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo">
        COMPROBANTE DE RETENCIONES</div>
    <div id="divTabs">
        <ul>
            <li id="liRegistro"><a href="#tabRegistro">Registro</a></li>
            <li id="liConsulta"><a href="#tabConsulta" onclick="getContentTab();">Consulta</a></li>
            <li id="liEliminados"><a href="#tabEliminado" onclick="getContentTab2();">Eliminados</a></li>
        </ul>
        <div id="tabRegistro">
            <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    REGISTRO DE RETENCIONES
                </div>
                <div>
                    <table cellpadding="0" cellspacing="0" class="form-inputs" width="750">
                        <tr>
                            <td style="font-weight: bold;">
                                Razon Social
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="padding-left: 2px">
                                            <asp:TextBox ID="txtProveedor" runat="server" Width="367px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold;">
                                            Serie
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSerie" runat="server" Width="51px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold;">
                                            Numero
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNumero" runat="server" Width="60px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold;">
                                            Emision
                                        </td>
                                        <td style="padding-left: 4px">
                                            <asp:TextBox ID="txtEmision" runat="server" Width="55px" CssClass="Jq-ui-dtp" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold;">
                                            Moneda
                                        </td>
                                        <td style="padding-left: 14px">
                                            <div id="div_moneda">
                                                <asp:DropDownList ID="ddlMoneda" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold;">
                   
                            </td>
                            <td style="padding-left: 378px;">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                      
                                        
                         <td style="display:none;">
                                            <div id="div_Empresa">
                                                <asp:DropDownList ID="ddlEmpresa" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="372">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                        <td style="font-weight: bold;">
                                            Tasa
                                        </td>
                                        <td style="font-weight: bold; padding-left: 6px">
                                            <div id="div_tasa">
                                                <asp:DropDownList ID="ddlTasa" runat="server" Font-Names="Arial" Font-Bold="True"
                                                    ForeColor="Blue" Width="55px">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                        <td style="font-weight: bold;">
                                            tc
                                        </td>
                                        <td style="padding-left: 33px;">
                                            <asp:TextBox ID="txtTC" runat="server" Width="60px" Font-Names="Arial" CssClass="Derecha"
                                                Font-Bold="True" ForeColor="Blue"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold;">
                                            fACTURA
                                        </td>
                                        <td style="padding-left: 0px;">
                                            <asp:TextBox ID="txtFactura" runat="server" Width="55px" Font-Names="Arial" Font-Bold="True"
                                                ForeColor="Blue" CssClass="Derecha" ReadOnly="True" Text="0.00"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold;">
                                            Retencion
                                        </td>
                                        <td style="padding-left: 0px;">
                                            <asp:TextBox ID="txtTotalFactura" runat="server" Width="70px" Font-Names="Arial"
                                                ForeColor="Blue" CssClass="Derecha" Font-Bold="True" ReadOnly="True" Text="0.00"></asp:TextBox>
                                        </td>
                                          <td style="display: none">
                                            <asp:TextBox ID="txtResponsable" runat="server" Width="369px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
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
                    <asp:Button ID="btnAgregarFactura" runat="server" Text="Agregar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120px" />
                    <asp:Button ID="btnEliminarFactura" runat="server" Text="Eliminar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120px" />
                    <asp:Button ID="btnGrabar" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120px" />
                </div>
            </div>
                <div  style="padding-top: 5px;">
            
            </div>
            <div style="text-align: center; width: 109%; color: Black; font-weight: bold">
                                                Cantidad de registros
                                                <asp:Label ID="Lbldetalle" runat="server" Text="0"></asp:Label>
                                            </div>
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix"
                style="width: 598px;">
                Facturas
            </div>
            <div id="div_grvFactura" >
                <asp:GridView ID="grvFactura" runat="server" AutoGenerateColumns="False" border="0"
                    CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="600px">
                    <Columns>
                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkEliminar" CssClass="chkDelete" Text="" />
                                <asp:HiddenField ID="hfCodigo" runat="server" Value='<%# Bind("Codigo") %>' />
                                <asp:HiddenField ID="hfSoles" runat="server" Value='<%# Bind("Soles") %>' />
                                <asp:HiddenField ID="hfDolares" runat="server" Value='<%# Bind("Dolares") %>' />
                                <asp:HiddenField ID="hfxSoles" runat="server" Value='<%# Bind("xSoles") %>' />
                                <asp:HiddenField ID="hfxDolares" runat="server" Value='<%# Bind("xDolares") %>' />
                                <asp:HiddenField ID="hfTC" runat="server" Value='<%# Bind("TC") %>' />
                                <asp:HiddenField ID="hfCodTipoDoc" runat="server" Value='<%# Bind("CodTipoDoc") %>' />
                                <asp:HiddenField ID="hfCodMoneda" runat="server" Value='<%# Bind("CodMoneda") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblID" Text='<%# Bind("Detalle") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Numero">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblFactura" Text='<%# Bind("Factura") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Emision" HeaderText="Emision">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="xSoles" HeaderText="Saldo S/." Visible="false">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="xDolares" HeaderText="Saldo $" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Soles" HeaderText="TOTAL FACTURA" DataFormatString="{0:N2}">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Retencion" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="txtMontoObligacion" Width="60px" Font-Bold="true"
                                    Style="text-align: center;" CssClass="ccsestilo" Font-Names="Arial" ForeColor="Blue"
                                    Text='<%# Bind("xSoles") %>' onblur="F_ActualizarMonto(this.id); return false;"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
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
                    <table cellpadding="0" cellspacing="0" class="form-inputs" width="700">
                        <tr>                                           
                              <td style="font-weight: bold">
                                            EMPRESA
                                        </td>
                                          <td>
                                    <div id="div_EmpresaConsulta">
                                        <asp:DropDownList ID="ddlEmpresaConsulta" runat="server" Font-Names="Arial" ForeColor="Blue"
                                            Font-Bold="True" Width="200" Enabled="False">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                            <td style="font-weight: bold;">
                                <asp:CheckBox ID="chkNumero" runat="server" Text="Numero" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtNumeroConsulta" runat="server" Width="45" Font-Names="Arial"
                                    Font-Bold="True" ForeColor="Blue"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold;">
                                <asp:CheckBox ID="chkRango" runat="server" Text="Fecha" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtDesde" runat="server" Width="55" Font-Names="Arial" Font-Bold="True"
                                    ForeColor="Blue" CssClass="Jq-ui-dtp"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtHasta" runat="server" Width="55" Font-Names="Arial" Font-Bold="True"
                                    ForeColor="Blue" CssClass="Jq-ui-dtp"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold;">
                                <asp:CheckBox ID="chkCliente" runat="server" Text="Cliente" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtClienteConsulta" runat="server" Width="340" Font-Names="Arial"
                                    Font-Bold="True" ForeColor="Blue"></asp:TextBox>
                            </td>
                        </tr>
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
            <div style="padding-top: 5px;" id="div_consulta">
                <asp:GridView ID="grvConsulta" runat="server" AutoGenerateColumns="False" border="0"
                    CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" DataKeyNames="Codigo"
                    Width="1018px" OnRowDataBound="grvConsulta_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                    ToolTip="ELIMINAR RETENCION" OnClientClick="F_AnularPopUP(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgImprimir" ImageUrl="~/Asset/images/pdf.png"
                                    ToolTip="VISUALIZAR PDF" OnClientClick="F_Imprimir(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <img id="imgMas" alt="" style="cursor: pointer" src="../Asset/images/plus.gif" onclick="imgMas_Click(this);"
                                    title="Ver Detalle" />
                                <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                                    <asp:GridView runat="server" ID="grvDetalle" border="0" CellPadding="0" CellSpacing="1"
                                        GridLines="None" class="GridView" />
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:BoundField DataField="Empresa" HeaderText="EMP">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="LEFT" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Numero">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblnumero" Text='<%# Bind("Numero") %>' CssClass="detallesart"></asp:Label>
                                <asp:HiddenField ID="hfCodigo" runat="server" Value='<%# Bind("Codigo") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cliente">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblcliente" Text='<%# Bind("Cliente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Emision" HeaderText="Emision">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Moneda" HeaderText="Moneda">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Total" HeaderText="Total">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TC" HeaderText="TC">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div id="tabEliminado">
            <div id='divEliminado' class="ui-jqgrid ui-widget ui-widget-content ui-corner-all"
               >
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    Criterio de busquedaS
                </div>
                <div class="ui-jqdialog-content">
                   <table cellpadding="0" cellspacing="0" class="form-inputs" width="700">
                        <tr>
                           <td style="display:none;font-weight: bold">
                                            EMPRESA
                                        </td>
                                        <td>
                                        <table cellpadding="0" cellspacing="0">
                                        <tr>
                                          <td style="display:none;">
                                    <div id="div_EmpresaEliminado">
                                        <asp:DropDownList ID="DropDownList1" runat="server" Font-Names="Arial" ForeColor="Blue"
                                            Font-Bold="True" Width="200" Enabled="False">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                            <td>
                                <asp:CheckBox ID="ChknroEliminado" runat="server" Text="Numero" Font-Bold="True" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtnroEliminado" runat="server" Width="55" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkRangoEliminado" runat="server" Text="Fecha" Font-Bold="True" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtDesdeEliminado" runat="server" Width="55" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True" CssClass="Jq-ui-dtp"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtHastaEliminado" runat="server" Width="55" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True" CssClass="Jq-ui-dtp"></asp:TextBox>
                            </td>

   <td>
    <asp:CheckBox ID="chkClienteEliminado" runat="server" Text="Cliente" Font-Bold="True" />
                        </td>
                        <td>
                          <asp:TextBox ID="txtclienteEliminado" runat="server" Width="430" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </td>
                                        </tr>
                                        </table>
                                        </td>
                                        
                           
                        </tr>
     
                    </table>
                </div>
                <div class="linea-button">
                    <asp:Button ID="btnBuscarConsultaEliminados" runat="server" Text="Buscar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
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
                                            <label id="lblNumeroConsulta2"></label>
                                        </td>                                
                                    </tr>
                                </table>
            </div>
            <div id="div_Eliminados" style="padding-top: 5PX;">
                <asp:GridView ID="grvEliminado" runat="server" AutoGenerateColumns="False" border="0"
                    CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="913px"
                    OnRowDataBound="grvEliminado_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="A">
                            <ItemTemplate>
                                <img id="imgMasAuditoriaEliminados" alt="" style="cursor: pointer" src="../Asset/images/plus.gif"
                                    onclick="imgMasAuditoriaEliminados_Click(this);" title="Auditoria" />
                                <asp:Panel ID="pnlOrdersAuditoriaEliminados" runat="server" Style="display: none">
                                    <asp:GridView ID="grvDetalleAuditoria" runat="server" border="0" CellPadding="0"
                                        CellSpacing="1" AutoGenerateColumns="False" GridLines="None" class="GridView">
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
                          <asp:TemplateField HeaderText="E">
                            <ItemTemplate>
                                <img id="imgMasObservacionesEliminados" alt="" style="cursor: pointer" src="../Asset/images/plus.gif"
                                    onclick="imgMasObservacionesEliminados_Click(this);" title="OBSERVACION ELIMINACION" />
                                <asp:Panel ID="pnlObservacionesEliminados" runat="server" Style="display: none">
                                    <asp:GridView ID="grvObservacionesEliminados" runat="server" border="0" CellPadding="0"
                                        CellSpacing="1" AutoGenerateColumns="False" GridLines="None" class="GridView">
                                        <Columns>
                                            <asp:BoundField DataField="Observaciones" HeaderText="Observacion ELIMINACION">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="O">
                            <ItemTemplate>
                                <img id="imgMasObservacion" alt="" style="cursor: pointer" src="../Asset/images/plus.gif"
                                    onclick="imgMasObservacionEliminados_Click(this);" title="OBSERVACIONES" />
                                <asp:Panel ID="pnlOrdersObservacionEliminadas" runat="server" Style="display: none">
                                    <asp:GridView ID="grvDetalleObservacionE" runat="server" border="0" CellPadding="0"
                                        CellSpacing="1" AutoGenerateColumns="False" GridLines="None" class="GridView">
                                        <Columns>
                                            <asp:BoundField DataField="Observaciones" HeaderText="Observacion">
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
                                <img id="imgMas" alt="" style="cursor: pointer" src="../Asset/images/plus.gif" onclick="imgMas_ClickEliminar(this);"
                                    title="Ver Detalle" />
                                <asp:Panel ID="pnlOrdersE" runat="server" Style="display: none">
                                    <asp:GridView ID="grvDetalleEliminado" runat="server" border="0" CellPadding="0" CellSpacing="1"
                                        AutoGenerateColumns="False" GridLines="None" class="GridView">
                                        <Columns>
                                            <asp:BoundField DataField="FACTURA" HeaderText="FACTURA">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Fecha" HeaderText="Fecha">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TOTAL" HeaderText="TOTAL">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ImporteRetencion" HeaderText="Importe Retencion">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:TemplateField>
                             <asp:BoundField DataField="Empresa" HeaderText="EMP">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="LEFT" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Numero">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblnumero" Text='<%# Bind("Numero") %>' CssClass="detallesart"></asp:Label>
                                <asp:HiddenField ID="hfCodigo" runat="server" Value='<%# Bind("Codigo") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cliente">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblcliente" Text='<%# Bind("Cliente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Emision" HeaderText="Emision">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Moneda" HeaderText="Moneda">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Total" HeaderText="Total">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TC" HeaderText="TC">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <div id="divConsultaFactura" style="display: none;">
        <div class="ui-jqdialog-content">
            <table width="360">
                <tr>
                    <td>
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" Width="120px" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <div id="div_grvConsultaFactura">
                            <asp:GridView ID="grvConsultaFactura" runat="server" AutoGenerateColumns="False"
                                border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                                Width="460">
                                <Columns>
                                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkOK" CssClass="chkSi" Text="" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Codigo">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("Codigo") %>'></asp:Label>
                                            <asp:HiddenField ID="hfCodMoneda" runat="server" Value='<%# Bind("CodMoneda") %>' />
                                            <asp:HiddenField ID="hfCodEmpresa" runat="server" Value='<%# Bind("CodEmpresa") %>' />
                                            <asp:HiddenField ID="hfCodTipoDoc" runat="server" Value='<%# Bind("CodTipoDoc") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Factura">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblFactura" Text='<%# Bind("Factura") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Emision">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblEmision" Text='<%# Bind("Emision") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblTotal" Text='<%# Bind("Total") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Moneda">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblMoneda" Text='<%# Bind("Moneda") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Retencion">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtMontoObligacion" Text='<%# Bind("MontoObligacion") %>'
                                                Width="55px" Font-Bold="true" Style="text-align: right;" Font-Names="Arial" ForeColor="Blue"
                                                Enabled="True" CssClass="ccsestilo"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
        <div id="div_Anulacion" style="display: none;">
        <div class="ui-jqdialog-content">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="font-weight: bold">
                        ¿ PORQUE LO ESTAS ELIMINANDO ?
                    </td>
                  
                </tr>
                <tr>
                  <td>
                           <asp:TextBox ID="txtObservacionAnulacion" runat="server" Width="450px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" TextMode="MultiLine" Height="80"></asp:TextBox>
                    </td>
                 
                </tr>
                <tr>
                   <td style="font-weight: bold;padding-top:5px;"  align="right">
                        <asp:Button ID="btnAnular" runat="server" Text="ELIMINAR" class="ui-button ui-widget
    ui-state-default ui-corner-all ui-button-text-only" Font-Names="Arial" Font-Bold="True" Width="120" />
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
    <input id="hfMoneda" type="hidden" value="0" />
       <input id="hfCodEmpresa" type="hidden" value="0" />
<input id="hfCodDocumentoVentaAnulacion" type="hidden" value="0" />
       <input id="lblcliente_grilla" type="hidden" value="0" />
        <input id="lblnumero_grilla" type="hidden" value="0" />

</asp:Content>
