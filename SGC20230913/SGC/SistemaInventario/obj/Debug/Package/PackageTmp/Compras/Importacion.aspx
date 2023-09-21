<%@ Page Title="Importacion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  CodeBehind="Importacion.aspx.cs" Inherits="SistemaInventario.Compras.Importacion" %>
  
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"   type="text/javascript"></script>
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/alertify.min.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript" charset="UTF-8"></script>
    <script type="text/javascript" language="javascript" src="Importacion.js" charset="UTF-8"></script>
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"    type="text/css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.core.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class='overlay'>
        <div class="titulo">
            Carga Importacion</div>
        <div id="divTabs">
            <ul>
                <li id="liRegistro"><a href="#tabRegistro">Registro</a></li>
                <li id="liConsulta"><a href="#tabConsulta" onclick="getContentTab();">Consulta</a></li>
            </ul>
            <div id="tabRegistro">
                <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
                    <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                        Datos de Importacion
                    </div>
                    <div>
                        <table cellpadding="0" cellspacing="0" class="form-inputs" width="750">
                            <tr>
                                <td style="font-weight: bold">
                                    proveedor
                                </td>
                                <td>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtProveedor" runat="server" Width="400px" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True"></asp:TextBox>
                                                <asp:HiddenField ID="hfCodCtaCte2" runat="server" Value="0" />
                                            </td>
                                            <td style="font-weight: bold">
                                                TC
                                            </td>
                                            <td style="padding-left:38px;">
                                                <asp:TextBox ID="txtTC" runat="server" Width="50" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold">
                                                Moneda
                                            </td>
                                            <td>
                                                <div id="div_moneda">
                                                    <asp:DropDownList ID="ddlMoneda" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True" Enabled="false">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                          
                                          
                                            <td style="font-weight: bold;">
                                                Numero
                                            </td>
                                            <td style="padding-left:16px;">
                                                <asp:TextBox ID="txtNumero" runat="server" Width="140" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True"></asp:TextBox>
                                            </td>
                                           
                                              <td style="display: none;">
                                                <asp:TextBox ID="txtSerie" runat="server" Width="40" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold">
                                    Tipo doc
                                </td>
                                <td>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <div id="div_tipodocumento">
                                                    <asp:DropDownList ID="ddlTipoDocumento" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True" Width="88"  Enabled="false">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td style="font-weight: bold; display: none;">
                                                Clasificacion
                                            </td>
                                            <td style="display: none;">
                                                <div id="div_clasificacion">
                                                    <asp:DropDownList ID="ddlClasificacion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True" Width="100">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td style="display: none;">
                                                <asp:CheckBox ID="chkPercepcion" runat="server" Text="Percepcion" Font-Bold="True" />
                                            </td>
                                            <td style="font-weight: bold; display: none">
                                                INGRESO
                                            </td>
                                            <td style="display: none">
                                                <asp:TextBox ID="txtFechaIngreso" runat="server" Width="55px" CssClass="Jq-ui-dtp"
                                                    Font-Names="Arial" ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold;padding-left:9px;">
                                                Emision
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEmision" runat="server" Width="55px" CssClass="Jq-ui-dtp" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                                <asp:HiddenField ID="hfEmision" runat="server" />
                                            </td>
                                            <td style="font-weight: bold;padding-left:9px;">
                                                condicion pago
                                            </td>
                                            <td>
                                                <div id="div_formapago">
                                                    <asp:DropDownList ID="ddlFormaPago" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True" Width="96">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                           
                                          
                                            <td style="font-weight: bold;">
                                                Nro. DUA
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNroDua" runat="server" Width="177" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold">
                                                Fecha DUA
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFechaDua" runat="server" Width="55px" CssClass="Jq-ui-dtp" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                                       <asp:HiddenField ID="hfFechaDua" runat="server" />
                                            </td>
                                             <td style="font-weight: bold">
                                                Igv
                                            </td>
                                            <td>
                                                <div id="div_igv">
                                                    <asp:DropDownList ID="ddlIgv" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True" Width="60">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                              <td style="display:none;">
                                                <asp:TextBox ID="txtVencimiento" runat="server" Width="56px" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td colspan="2" align="right">
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:CheckBox runat="server" ID="chkConIgvMaestro" Text="Con Igv" onclick="F_ValidarCheckConIgvMaestro(this.id);"
                                                    Checked="True" Font-Bold="True" />
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="chkSinIgvMaestro" Text="Sin Igv" onclick="F_ValidarCheckSinIgvMaestro(this.id);"
                                                    Font-Bold="True" />
                                            </td>
                                            <td style="font-weight: bold; padding-left: 5px;">
                                                descuento
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDsctoTotal" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                    CssClass="Derecha" Font-Bold="True" Text="0.00"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold">
                                                SubTotal
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSubTotal" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" CssClass="Derecha" ReadOnly="True" Text="0.00"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold">
                                                Igv
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIgv" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" CssClass="Derecha" ReadOnly="True" Text="0.00"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold">
                                                total
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotal" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" CssClass="Derecha" ReadOnly="True" Text="0.00"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold">
                                                Monto
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMonto" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" CssClass="Derecha" Text="0.00"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold">
                                    Gastos Ope. %
                                </td>
                                <td>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtGastosOperativos" runat="server" Width="37px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold;">
                                                Excel
                                            </td>
                                            <td>
                                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                            </td>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label>
                                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                            </td>
                                             <td style="font-weight: bold;">
                                                Pre-importacion
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" ID="chkPreImportacion" />
                                            </td>
                                             <td style="font-weight: bold">
                                                Fecha Llegada
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFechaLlegada" runat="server" Width="55px" CssClass="Jq-ui-dtp" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                                       <asp:HiddenField ID="hfFechaLlegada" runat="server"/>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                              <tr>
                                <td style="font-weight: bold; font-size: medium;" colspan='2'>                        
                          LAS COLUMNAS SON A=CODIGOINTERNO,B=DESCRIPCION,C=CANTIDAD,D=COSTO,E=P1,F=P2,G=P3,H=IDFAMILIA,I=LIMITE 
                                </td>                               
                            </tr>
                             <tr>
                                <td style="font-weight: bold; font-size: medium;" colspan='2'>                        
                          LAS COLUMNAS A DEBE SER DE TIPO TEXTO. LA HOJA DEL EXCEL DEBE LLAMARSE : IMPORTACION
                                </td>                               
                            </tr>

                                                        <tr>
                                <td style="font-weight: bold; font-size: medium;" colspan='2'>                        
                          LOS CODIGOS DE LOS PRODUCTOS NO DEBEN DUPLICARSE.  EL EXCEL NO DEBE TENER FUENTES ASIATICAS
                                </td>                               
                            </tr>

                 
                        </table>
                    </div>
                    <div class="linea-button">
                        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" Width="120" OnClick="btnNuevo_Click" />
                        <asp:Button ID="btnImport" runat="server" Text="Cargar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" Width="120" OnClick="btnImport_Click" />
                    </div>
                </div>

                <div  style="padding-top:5px;" >
                   <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
                    <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix"
                        style="width: 1000px">
                        Articulos con algun incoveniente
                    </div>
                    <div id="div_grvDetalleArticulo" style="padding-top: 5px;">
                        <asp:GridView ID="grvDetalleArticulo" runat="server" AutoGenerateColumns="False"
                            border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                            Width="1000px" OnRowDataBound="grvDetalleArticulo_RowDataBound2">
                            <Columns>
                                <asp:TemplateField HeaderText="ERROR">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblError" Text='<%# Bind("DESCRIPCION_ERROR") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Codigo Interno">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCodigoInterno" Text='<%# Bind("CodigoInterno") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Codigo" HeaderText="Codigo" Visible="false">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="DESCRIPCION">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblDescripcion" Text='<%# Bind("DESCRIPCION") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cantidad">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCantidad" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Precio" Visible="false">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPrecio" Text='<%# Bind("UPrice") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Total" HeaderText="Total" Visible="false">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Marca" HeaderText="Marca" Visible="false">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Costo">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCosto" Text='<%# Bind("Costo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="P1">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblP1" Text='<%# Bind("P1") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="P2" HeaderText="P2">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="P3" HeaderText="P3">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                </div>

             
            </div>
            <div id="tabConsulta" style="display: none">
                <div id='divConsulta' class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
                    <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                        Criterio de busqueda
                    </div>
                    <div class="ui-jqdialog-content">
                        <table cellpadding="0" cellspacing="0" class="form-inputs">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkNumero" runat="server" Text="Numero" Font-Bold="True" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNumeroConsulta" runat="server" Width="70" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
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
                                    <td>
                                        <asp:CheckBox ID="chkCliente" runat="server" Text="Proveedor" Font-Bold="True" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtClienteConsulta" runat="server" Width="535" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
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
                        CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="1005px"
                        OnRowDataBound="grvConsulta_RowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                        ToolTip="Eliminar" OnClientClick="F_AnularRegistro(this); return false;" />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="imgIngresarImportacion" ImageUrl="~/Asset/images/checked.png"
                                        ToolTip="Ingresar" OnClientClick="F_IngresarRegistro(this); return false;" />
                                </ItemTemplate>
                            </asp:TemplateField>                              
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="imgExportarExcel" ImageUrl="~/Asset/images/excel.gif"
                                        ToolTip="Exportar Excel" OnClientClick="F_ExportarExcel2(this); return false;" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="O">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgMasObservacion" ImageUrl="~/Asset/images/plus.gif"
                                    OnClientClick="imgMasObservacionImportacion_Click(this); return false;" ToolTip="Observacion" />
                                <asp:Panel ID="pnlOrdersObservacion" runat="server" Style="display: none">
                                    <asp:GridView ID="grvObservacion" runat="server" border="0" CellPadding="0"
                                        CellSpacing="1" AutoGenerateColumns="False" GridLines="None" class="GridView">
                                        <Columns>
                                            <asp:TemplateField>
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                            <asp:ImageButton runat="server" ImageUrl="~/Asset/images/btnEdit.gif"
                                                             ToolTip="Modificar Observacion"  OnClientClick="F_ModificarObservacion(this); return false;"/>
                                            </ItemTemplate>
                                            </asp:TemplateField>                                            
                                            <asp:BoundField DataField="Observacion" HeaderText="Observacion">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="A">
                            <ItemTemplate>
                                <img id="imgMasAuditoria" alt="" style="cursor: pointer" src="../Asset/images/plus.gif"
                                    onclick="imgMasAuditoriaImportacion_Click(this);" title="Auditoria" />
                                <asp:Panel ID="pnlOrdersAuditoria" runat="server" Style="display: none">
                                    <asp:GridView ID="grvAuditoria" runat="server" border="0" CellPadding="0"
                                        CellSpacing="1" AutoGenerateColumns="False" GridLines="None" class="GridView">
                                        <Columns>
                                            <asp:BoundField DataField="Auditoria" HeaderText="Auditoria">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
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
                                                <asp:BoundField DataField="CodigoInterno" HeaderText="Codigo">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Producto" HeaderText="Descripcion">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>   
                                                <asp:BoundField DataField="Costo" HeaderText="Costo">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="CostoGO" HeaderText="Costo GO">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="P1" HeaderText="P1">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="P2" HeaderText="P2">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="P3" HeaderText="P3">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="Limite" HeaderText="Limite">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Numero">
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblnumero" Text='<%# Bind("Numero") %>' CssClass="detallesart"></asp:Label>
                                    <asp:HiddenField ID="hfCodigo" runat="server" Value='<%# Bind("Codigo") %>' />
                                    <asp:HiddenField ID="hfDetalleCargado" runat="server" Value='0' />
                                    <asp:HiddenField ID="hfDetalleCargadoObservacion" runat="server" Value='0' />
                                    <asp:HiddenField ID="hfDetalleCargadoAuditoria" runat="server" Value='0' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Proveedor" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblcliente" Text='<%# Bind("RazonSocial") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                         <asp:TemplateField HeaderText="Emision" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblFechaEmision" Text='<%# Bind("Emision") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Condicion" HeaderText="Condicion">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Vcto" HeaderText="Vcto">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Moneda" HeaderText="Moneda">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Total" HeaderText="Total" HeaderStyle-HorizontalAlign="Center"
                                DataFormatString="{0:N2}">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Saldo" HeaderText="Saldo" HeaderStyle-HorizontalAlign="Center"
                                DataFormatString="{0:N2}">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                             <asp:TemplateField HeaderText="TC" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblTipoCambio" Text='<%# Bind("TipoCambio") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="FechaCancelacion" HeaderText="Cancelac" HeaderStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Estado" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblEstado" Text='<%# Bind("Estado") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Periodo" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblPeriodo" Text='<%# Bind("Periodo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                <%--             <asp:TemplateField HeaderText="EstadoImportacion" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblEstadoImportacion" Text='<%# Bind("EstadoImportacion") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FechaLlegada" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblFechaLlegada" Text='<%# Bind("FechaLlegada") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                         <%--   <asp:TemplateField HeaderText="G.O %" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblGastOperativo" Text='<%# Bind("Gop") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <div id="divSeleccionarEmpresa" style="display: none;">
        <table>
            <tr>
                <td style="font-weight: bold">
                    Usuario Auxiliar
                </td>
                <td>
                    <asp:TextBox ID="txtUsuario" runat="server" Width="98px" Font-Names="Arial" ForeColor="Blue"
                        Font-Bold="True" ToolTip="Ingresar Usuario"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Clave
                </td>
                <td>
                    <asp:TextBox ID="txtContraseña" runat="server" Width="98px" Font-Names="Arial" ForeColor="Blue"
                        Font-Bold="True" TextMode="Password" ToolTip="Ingresar Contraseña"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <asp:Button ID="btnValidar" runat="server" Text="VALIDAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                </td>
            </tr>
        </table>
    </div>
    <div id="divEliminar" style="display: none;">
        <table>
            <tr>
                <td style="font-weight: bold">
                    Usuario Auxiliar
                </td>
                <td>
                    <asp:TextBox ID="txtUsuarioEliminar" runat="server" Width="98px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" ToolTip="Ingresar Usuario"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Clave
                </td>
                <td>
                    <asp:TextBox ID="txtContraseñaEliminar" runat="server" Width="98px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" TextMode="Password" ToolTip="Ingresar Contraseña"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <asp:Button ID="btnEliminar" runat="server" Text="VALIDAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="70" />
                    <asp:Button ID="btnCancelarEliminar" runat="server" Text="CANCELAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="70" />
                </td>
            </tr>
        </table>
    </div>
     <div id="divPreliminar" style="display: none;">
        <table>
            <tr>               
                <td style="font-weight: bold">
                    Numero:
                </td>
                <td>
                    <asp:TextBox ID="txtNumEli" runat="server" Width="300px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>                                                  
            <tr>               
                <td style="font-weight: bold">
                    Proveedor:
                </td>
                <td>
                    <asp:TextBox ID="txtProveedorEli" runat="server" Width="300px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>           
            <tr>               
                <td style="font-weight: bold">
                    Observacion (Opcional):
                </td>
                <td>
                    <asp:TextBox ID="txtObservacionEli" runat="server" Width="300px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" TextMode="MultiLine" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <asp:Button ID="btnPreliminar" runat="server" Text="ACEPTAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="70" />
                    <asp:Button ID="btnCancelarPreli" runat="server" Text="CANCELAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="70" />
                </td>
        </table>
    </div>
     <div id="divIngresar" style="display: none;">
        <table>
            <tr>               
                <td style="font-weight: bold">
                    Numero:
                </td>
                <td>
                    <asp:TextBox ID="txtNumIng" runat="server" Width="300px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>                                                  
            <tr>               
                <td style="font-weight: bold">
                    Proveedor:
                </td>
                <td>
                    <asp:TextBox ID="txtProveedorIng" runat="server" Width="300px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>           
            <tr>               
                <td style="font-weight: bold">
                    Observacion (Opcional):
                </td>
                <td>
                    <asp:TextBox ID="txtObservacion" runat="server" Width="300px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" TextMode="MultiLine" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Fecha Llegada
                </td>
                <td>
                     <%--<asp:TextBox ID="txtFechaLlegadaIng" runat="server" Width="70px" CssClass="Jq-ui-dtp" Font-Names="Arial"
                     ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                     <asp:HiddenField ID="hfFechaLlegadaIng" runat="server"/>--%>
                      <asp:TextBox ID="txtFechaLlegadaIng" runat="server" Width="70" Font-Names="Arial" ForeColor="Blue"
                                            Font-Bold="True" CssClass="Jq-ui-dtp" ReadOnly="True"></asp:TextBox>
               </td>
            </tr>
            
            <tr>
                <td colspan="2" align="right">
                    <asp:Button ID="btnIngresar" runat="server" Text="INGRESAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="70" />
                    <asp:Button ID="btnCancelarIngreso" runat="server" Text="CANCELAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="70" />
                </td>
            </tr>
        </table>
    </div>
    <div id="divObservacion" style="display: none;">
        <table>
            <tr>               
                <td style="font-weight: bold">
                    Numero:
                </td>
                <td>
                    <asp:TextBox ID="txtNumEdi" runat="server" Width="300px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>                                                  
            <tr>               
                <td style="font-weight: bold">
                    Proveedor:
                </td>
                <td>
                    <asp:TextBox ID="txtProvEdi" runat="server" Width="300px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>           
            <tr>               
                <td style="font-weight: bold">
                    Observacion (Opcional):
                </td>
                <td>
                    <asp:TextBox ID="txtObEdi" runat="server" Width="300px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" TextMode="MultiLine" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <asp:Button ID="btnEdi" runat="server" Text="ACEPTAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="70" />
                    <asp:Button ID="btnCancelarEdi" runat="server" Text="CANCELAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="70" />
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
    <input id="hfCodCtaCte" type="hidden" value="0" />
    <input id="hfCodCtaCteConsulta" type="hidden" value="0" />
    <input id="hfCodigoTemporal" type="hidden" value="0" />
    <input id="hfCodDocumentoVenta" type="hidden" value="0" />
    <input id="hfCodDetDocumentoVenta" type="hidden" value="0" />
    <input id="hfCodProducto" type="hidden" value="0" />
    <input id="hfCantidad" type="hidden" value="0" />
    <input id="hfFlagSerie" type="hidden" value="0" />
    <input id="hfNotaPedido" type="hidden" value="0" />
    <input id="hfCodCtaCteNP" type="hidden" value="0" />
    <input id="hfCodUsuarioAuxiliar" type="hidden" value="0" />

</asp:Content>
