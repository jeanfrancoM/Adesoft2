<%@ Page Title="COTIZACION" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"   CodeBehind="RegistroCotizacionesFundidora.aspx.cs" Inherits="SistemaInventario.Ventas.RegistroCotizacionesFundidora" EnableEventValidation="false"%>
 
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"   type="text/javascript"></script>     
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/alertify.min.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript"  charset="UTF-8"></script>      
    <script src="../Scripts/inputatajos/kibo.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="RegistroCotizacionesFundidora.js"   charset="UTF-8"></script>     
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"   type="text/css" />     
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.core.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.default.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/css/tooltipbutton/jquery.toolbar.js" type="text/javascript"></script>
    <link href="../Asset/css/tooltipbutton/jquery.toolbar.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/sss.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/toars/toastr.min.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/toars/toastr.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr valign="top">
            <td style="width: 1100px" valign="top">
                <div class="titulo" style="width: 1245px">
                    <asp:Label ID="lbTipoDocumento" runat="server" Text="Factura" Font-Bold="False" Font-Size="Large"
                        Visible="false"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text="REGISTRO DE COTIZACIONES" Font-Bold="False"
                        Font-Size="Large"></asp:Label>
                </div>
                <div id="divTabs" style="width: 1245px">
                    <ul>
                        <li id="liRegistro"><a href="#tabRegistro">Registro</a></li>
                        <li id="liConsulta"><a href="#tabConsulta" onclick="getContentTab();">Consulta</a></li>
                    </ul>
                    <div id="tabRegistro">
                        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
                            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                                Datos de Factura
                            </div>
                            <div>
                                <table cellpadding="0" cellspacing="0" class="form-inputs" width="750">
                                    <tr>
                                        <td style="font-weight: bold">
                                            Cliente
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtNroRuc" runat="server" Width="70px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" MaxLength="11" onblur="F_ValidaRucDni(); return false;"></asp:TextBox>
                                                    </td>
                                                    <td id="td_loading" style="font-weight: bold; padding-left: 5px; display: none">
                                                        <img src="../Asset/images/loading.gif" />
                                                    </td>
                                                    <td id="div_Cliente">
                                                        <asp:TextBox ID="txtCliente" runat="server" Width="450px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold;padding-Right: 30px">
                                                        Distrito
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDistrito" runat="server" Width="515px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold">
                                            Direccion
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox Style="width: 515px; position: absolute; color: blue; font-family: Arial;
                                                            font-weight: bold; background: rgb(255, 255, 224);" ID="txtDireccion" runat="server"
                                                            autocomplete="off"></asp:TextBox>
                                                        <asp:DropDownList ID="ddlDireccion" Style="width: 535px" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="font-weight: bold">
                                                        Moneda
                                                    </td>
                                                    <td style="padding-left: 30px">
                                                        <div id="div_moneda">
                                                            <asp:DropDownList ID="ddlMoneda" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="85" BackColor="#FFFF99">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                   
                                                     <td style="font-weight: bold; padding-left: 4px">
                                                        SubTotal
                                                    </td>
                                                    <td style="padding-left: 20px">
                                                        <asp:TextBox ID="txtSubTotal" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                            CssClass="Derecha" Font-Bold="True" ReadOnly="True" Text="0.00"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold">
                                                        Igv
                                                    </td>
                                                    <td style="padding-left: 20px">
                                                        <asp:TextBox ID="txtIgv" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                            CssClass="Derecha" Font-Bold="True" ReadOnly="True" Text="0.00"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold; padding-left: 10px">
                                                        total
                                                    </td>
                                                    <td style="padding-left: 20px">
                                                        <asp:TextBox ID="txtTotal" runat="server" Width="70px" Font-Names="Arial" ForeColor="Blue"
                                                            CssClass="Derecha" Font-Bold="True" ReadOnly="True" Text=""></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold">
                                            Emision
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtEmision" runat="server" Width="56px" CssClass="Jq-ui-dtp" Font-Names="Arial"
                                                            ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                   
                                                  
                                                    <td id="tdftNormal">
                                                        <table>
                                                            <tr>
                                                                <td style="font-weight: bold;padding-left: 28px">
                                                                    Serie
                                                                </td>
                                                                <td id="tdddlSerie" style="padding-left: 12px">
                                                                    <div id="div_serie">
                                                                        <asp:DropDownList ID="ddlSerie" Width="55" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                            Font-Bold="True">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </td>
                                                                <td style="display: none">
                                                                    <asp:TextBox ID="txtNumero" runat="server" Width="48" Font-Names="Arial" ForeColor="Blue"
                                                                        Font-Bold="True"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td style="font-weight: bold;padding-left: 20px">
                                                        Igv (%)
                                                    </td>
                                                    <td>
                                                        <div id="div_igv">
                                                            <asp:DropDownList ID="ddlIgv" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="53">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                      <td style="font-weight: bold;padding-left: 20px">
                                                        T.C.
                                                    </td>
                                                    <td style="font-weight: bold;">
                                                        <asp:Label ID="lblTC" runat="server" Text="Label" Font-Bold="True"></asp:Label>
                                                    </td>
                                                    <td style="font-weight: bold; padding-left: 10px">
                                                        <asp:CheckBox runat="server" ID="chkConIgvMaestro" Text="Con Igv" onclick="F_ValidarCheckConIgvMaestro(this.id);"
                                                             Font-Bold="True" />
                                                    </td>
                                                    <td style="font-weight: bold; padding-left: 10px">
                                                        <asp:CheckBox runat="server" ID="chkSinIgvMaestro" Text="Sin Igv" onclick="F_ValidarCheckSinIgvMaestro(this.id);"
                                                           Checked="True" Font-Bold="True" />
                                                    </td>
                                                    <td style="font-weight: bold;display:none;">
                                                        <asp:CheckBox runat="server" ID="chkComisionable" Text="Comision" Font-Bold="True" />
                                                    </td>
                                                     <td style="font-weight: bold; padding-left: 10px">
                                                       Atencion
                                                    </td>
                                                     <td style="padding-left: 25px">
                                                             <asp:TextBox ID="txtAtencion" runat="server" Width="515px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" ReadOnly="False"></asp:TextBox>
                                                    </td>
                                                   
                                                     <td style="font-weight: bold;display:none;">
                                                        CONDICION PAGO
                                                    </td>
                                                    <td style="display: none">
                                                        <div id="div_formapago">
                                                            <asp:DropDownList ID="ddlFormaPago" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="85">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td style="font-weight: bold; padding-left: 20px;display:none;">
                                                        <asp:CheckBox runat="server" ID="ChkCodigo" Text="Con Codigo" 
                                                            Checked="True" Font-Bold="True" />
                                                    </td>
                                                     <td style="font-weight: bold;display:none;">
                                                        D1
                                                    </td>
                                                    <td style="font-weight: bold;display:none;">
                                                        <asp:Label ID="lblD1" runat="server" Text="" Font-Bold="True"></asp:Label>
                                                    </td>
                                                     <td style="font-weight: bold;display:none;">
                                                       D2
                                                    </td>
                                                    <td style="font-weight: bold;display:none;">
                                                        <asp:Label ID="lblD2" runat="server" Text="" Font-Bold="True"></asp:Label>
                                                    </td>
                                                     <td style="font-weight: bold;display:none;">
                                                        D3
                                                    </td>
                                                    <td style="font-weight: bold;display:none;">
                                                        <asp:Label ID="lblD3" runat="server" Text="" Font-Bold="True"></asp:Label>
                                                    </td>
                                                    <%--  <td style="font-weight: bold;">
                                                        GRA
                                                    </td>--%>
                                                    <td style="padding-left: 11px;display:none;">
                                                        <asp:TextBox ID="txtGratuito" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                         CssClass="Derecha"   Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold;display:none;">
                                                        nro Operacion
                                                    </td>
                                                    <td style="display:none;">
                                                        <asp:TextBox ID="txtNroOperacion" runat="server" Width="160px" Font-Names="Arial"
                                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                 
                                                    
                                                  
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                        <tr>
                                     <td style="font-weight: bold; padding-left: 2px">
                                             Entrega 
                                        </td>
                                        <td>
                                         <table cellpadding="0" cellspacing="0">
                                           <tr>
                                           
                                           </tr>
                                                    <td>
                                                        <asp:TextBox ID="txtFEntrega" runat="server" Width="532px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" ReadOnly="False"></asp:TextBox>
                                                    </td>
                                                       <td style="font-weight: bold">
                                            F. Pago
                                        </td>
                                                       <td style="padding-left: 33px">
                                                        <asp:TextBox ID="txtFPago" runat="server" Width="515px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" ReadOnly="False"></asp:TextBox>
                                                    </td>
                                         </table>
                                        </td>
                                      
                                      </tr>
                                    <tr style="display: none">
                                        <td style="font-weight: bold;display:none;">
                                            VENDEDOR
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <div id="div_Vendedor">
                                                            <asp:DropDownList ID="ddlVendedor" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="200">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td style="font-weight: bold; padding-left: 1px;display:none;">
                                                        CORREO
                                                    </td>
                                                    <td style="display: none">
                                                        <asp:TextBox ID="txtCorreo" runat="server" Width="261px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" ReadOnly="False"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold;display:none;">
                                                        Celular
                                                    </td>
                                                    <td style="display: none">
                                                        <asp:TextBox ID="txtCelular" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold;display:none;">
                                                        PLACA
                                                    </td>
                                                    <td style="display: none">
                                                        <asp:TextBox ID="txtPlaca" runat="server" Width="60px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold;display:none;">
                                                        KM
                                                    </td>
                                                    <td style="display: none">
                                                        <asp:TextBox ID="txtKM" runat="server" Width="60px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="display: none">
                                                        <asp:CheckBox ID="chkImpresionTicket" runat="server" Text="Imprim" Checked="True"
                                                            Font-Bold="True" />
                                                    </td>
                                                    <td style="font-weight: bold; display: none">
                                                        vcto
                                                    </td>
                                                    <td style="padding-left: 30px; display: none">
                                                        <asp:TextBox ID="txtVencimiento" runat="server" Width="56px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                    <td style="display: none">
                                                        Dscto %
                                                    </td>
                                                    <td style="display: none">
                                                        <asp:TextBox ID="txtDescuento" runat="server" Width="40px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" ReadOnly="False" Text="0.00"></asp:TextBox>
                                                    </td>
                                                    <td style="display: none">
                                                        <asp:Button ID="btnAplicarDescuento" runat="server" Text=">" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                                            Font-Names="Arial" Font-Bold="True" Width="30" />
                                                    </td>
                                                    <td style="font-weight: bold; display: none">
                                                        ACUENTA
                                                    </td>
                                                    <td style="display: none">
                                                        <asp:TextBox ID="txtAcuenta" runat="server" Width="90px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" CssClass="Derecha" ReadOnly="True" Text="0.00"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold; display: none">
                                                        ACUENTA NV
                                                    </td>
                                                    <td style="display: none">
                                                        <asp:TextBox ID="txtAcuentaNV" runat="server" Width="90px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" CssClass="Derecha" ReadOnly="True" Text="0.00"></asp:TextBox>
                                                    </td>
                                                   
                                                </tr>

                                            </table>
                                        </td>
                                    </tr>
                                     <tr style="display: none">
                                        <td style="font-weight: bold; display: none">
                                            Observacion
                                        </td>
                                        <td>
                                        <table>
                                        
                                                    <td>
                                                        <asp:TextBox ID="txtObservacion" runat="server" Width="900px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" ReadOnly="False"></asp:TextBox>
                                                    </td>
                                        </table>
                                        </td>
                                      </tr>
                                  
                                </table>
                            </div>
                            <div class="linea-button">
                       <%--         <asp:Button ID="btnPedido" runat="server" Text="Listar Pedido" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120" OnClientClick="F_VerDetallePedido(); return false;"/>--%>
                                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120" Style="display: none;" />
                                <asp:Button ID="btnNuevo" runat="server" Text="Limpiar (F1)" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120" />
                                <asp:Button ID="btnAgregarProducto" runat="server" Text="Agregar (F2)" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120" />
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar (F6)" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120" />
                                <asp:Button ID="btnGrabar" runat="server" Text="Grabar (F7)" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120" />
                            </div>
                            <div>
                                <table cellpadding="0" cellspacing="0" width="850" class="form-inputs">
                                    <tr>
                                    </tr>
                                </table>
                            </div>
                        </div>
                              <div style="padding-top: 5px;">
               <table cellpadding="0" cellspacing="0" align="center">
                                    <tr>
                                        <td style="font-weight: bold">
                                           Cantidad de Registros:
                                        </td>
                                        <td style="font-weight: bold">
                                            <label id="lblCantidadRegistro"></label>
                                        </td>                                
                                    </tr>
                                </table>
            </div>
                        <div id="div_grvDetalleArticulo">
                            <asp:GridView ID="grvDetalleArticulo" runat="server" AutoGenerateColumns="False"
                                border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                                Width="1220px">
                                <Columns>
                                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                                                <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" />
                                                            </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkEliminar" CssClass="chkDelete" Text="" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Codigo" HeaderStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblCodigo"
                                                        Text='<%# Bind("CodigoProducto") %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Descripcion" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtDescripcion" Font-Bold="true" CssClass="ccsestilo"
                                                Width="480px" Font-Names="Arial" ForeColor="Blue" Text='<%# Bind("Producto") %>'
                                                onblur="F_ActualizarDescripcion(this.id); return false;"></asp:TextBox>
                                            <asp:HiddenField ID="hfcodarticulo" runat="server" Value='<%# Bind("CodArticulo") %>' />
                                            <asp:HiddenField ID="hfCodDetalleOC" runat="server" Value='<%# Bind("CodDetalleOC") %>' />
                                            <asp:HiddenField ID="hfCantidad" runat="server" Value='<%# Bind("Cantidad") %>' />
                                            <asp:HiddenField ID="hfPrecio" runat="server" Value='<%# Bind("Precio") %>' />
                                            <asp:HiddenField ID="hfDescripcion" runat="server" Value='<%# Bind("Producto") %>' />
                                            <asp:HiddenField ID="hfCodTipoDoc" runat="server" Value='<%# Bind("CodTipoDoc") %>' />
                                            <asp:HiddenField ID="hfP1" runat="server" Value='<%# Bind("P1") %>' />
                                            <asp:HiddenField ID="hfP2" runat="server" Value='<%# Bind("P2") %>' />
                                            <asp:HiddenField ID="hfP3" runat="server" Value='<%# Bind("P3") %>' />
                                            <asp:HiddenField ID="hfCodDetalle" runat="server" Value='<%# Bind("CodDetalle") %>' />
                                            <asp:HiddenField ID="hfCodGratuito" runat="server" Value='<%# Bind("CodGratuito") %>' />
                                            <asp:HiddenField ID="hfExclusivo" runat="server" Value='<%# Bind("Exclusivo") %>' />
                                            <asp:HiddenField ID="hfMaterial" runat="server" Value='<%# Bind("Material") %>' />
                                            <asp:HiddenField ID="hfpestimado" runat="server" Value='<%# Bind("Pestimado") %>' />
                                            <asp:HiddenField ID="hfpxkilo" runat="server" Value='<%# Bind("PxKilo") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtCantidad" Width="75px" Font-Bold="true" Style="text-align: center;"
                                                CssClass="ccsestilo" Font-Names="Arial" ForeColor="Blue" Text='<%# Bind("Cantidad") %>'
                                                onblur="F_ActualizarCantidad(this.id); return false;"></asp:TextBox>                                                                                              
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Material" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtMaterial" Width="75px" Font-Bold="true" Style="text-align: center;"
                                                CssClass="ccsestilo" Font-Names="Arial" ForeColor="Blue" Text='<%# Bind("Material") %>'
                                                onblur="F_ActualizarMaterial(this.id); return false;"  ></asp:TextBox>                                                                                              
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="P Estimado" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtPestimado" Width="75px" Font-Bold="true" Style="text-align: center;"
                                                CssClass="ccsestilo" Font-Names="Arial" ForeColor="Blue" Text='<%# Bind("Pestimado") %>'
                                                 onblur="F_ActualizarPestimado(this.id); return false;" ></asp:TextBox>                                                                                              
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PxKilo" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtPxKilo" Width="75px" Font-Bold="true" Style="text-align: center;"
                                                CssClass="ccsestilo" Font-Names="Arial" ForeColor="Blue" Text='<%# Bind("PxKilo") %>'
                                                  onblur="F_ActualizarPxKilo(this.id); return false;" ></asp:TextBox>                                                                                              
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="UM" HeaderText="UM">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Precio" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtPrecio" Width="75px" Font-Bold="true" Style="text-align: center;"
                                                CssClass="ccsestilo" Font-Names="Arial" ForeColor="Blue" Text='<%# Bind("Precio") %>'
                                                onblur="F_ActualizarPrecio(this.id); return false;" onkeypress="return onKeyDecimal(this,event);"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Importe">
                                        <ItemStyle HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblimporte" Text='<%# Bind("Importe") %>' CssClass="detallesart"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ACUENTA NV" Visible="false">
                                        <ItemStyle HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblAcuenta" Text='<%# Bind("Acuenta") %>'></asp:Label>
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
                                <table cellpadding="0" cellspacing="0" class="form-inputs">
                                    <tbody>
                                        <tr>
                                            <td style="font-weight: bold">
                                                Serie
                                            </td>
                                            <td>
                                                <div id="div_serieconsulta">
                                                    <asp:DropDownList ID="ddlSerieConsulta" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkNumero" runat="server" Text="Numero" Font-Bold="True" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNumeroConsulta" runat="server" Width="40" Font-Names="Arial"
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
                                                <asp:CheckBox ID="chkCliente" runat="server" Text="Cliente" Font-Bold="True" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtClienteConsulta" runat="server" Width="280" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold;display:none;">
                                                VENDEDOR
                                            </td>
                                            <td style="display: none">
                                                <div id="div_EmpleadoConsulta">
                                                    <asp:DropDownList ID="ddlEmpleadoConsulta" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True" Width="120">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td style="font-weight: bold">
                                                ESTADO
                                            </td>
                                            <td>
                                                <div id="div_Estado">
                                                    <asp:DropDownList ID="ddlEstado" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True" Width="60">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div class="linea-button" style="height: 25px">
                                <table style="float: right; width: auto">
                                    <tr>                                     
                                        <td>
                                            <asp:Button ID="btnImpresionPedidos" runat="server" Text="Imprimir" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                                Font-Names="Arial" Font-Bold="True" Width="120" Visible="false" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnBuscarConsulta" runat="server" Text="Buscar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                                Font-Names="Arial" Font-Bold="True" Width="120" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                           <div style="padding-top: 5px;">
               <table cellpadding="0" cellspacing="0" align="center">
                                    <tr>
                                        <td style="font-weight: bold">
                                           Cantidad de Registros:
                                        </td>
                                        <td style="font-weight: bold">
                                            <label id="lblGrillaConsulta"></label>
                                        </td>                                
                                    </tr>
                                </table>
            </div>
                        <div id="div_consulta">
                            <asp:GridView ID="grvConsulta" runat="server" AutoGenerateColumns="False" border="0"
                                CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="1220px"
                                OnRowDataBound="grvConsulta_RowDataBound">
                                <Columns>
                                    <%--                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div id="toolbar-options" >
                                                <a href="#"><i class="fa fa-plane"></i></a>
                                                <a href="#"><i class="fa fa-car"></i></a>
                                                <a href="#"><i class="fa fa-bicycle"></i></a>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                             
                                    <%--     <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgEliminarDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                                ToolTip="ELIMINAR COTIZACION" OnClientClick="F_EliminarRegistro(this); return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <%--<asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgAnularNI" ImageUrl="~/Asset/images/EliminarBtn.png"
                                                ToolTip="ANULAR NOTA INGRESO" OnClientClick="F_AnularNIPopUP(this); return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/Eliminar.jpg"
                                                ToolTip="ANULAR COTIZACION" OnClientClick="F_AnularPopUP(this); return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgReemplazar" ImageUrl="~/Asset/images/Reemplazo.png"
                                                ToolTip="EDITAR COTIZACION" OnClientClick="F_ReemplazarDocumento2(this); return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgPdf2" ImageUrl="~/Asset/images/pdf.png" ToolTip="VISUALIZAR PDF"
                                                OnClientClick="F_VistaPreliminar(this); return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <%-- <asp:TemplateField HeaderText="P">
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgPdf3" ImageUrl="~/Asset/images/pdf.png" ToolTip="VISUALIZAR PDF PEDIDO"
                                                OnClientClick="F_VerPDF(this); return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                 <%--   <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgDSP" ImageUrl="~/Asset/images/texto.png" ToolTip="IMPRIMIR DESPACHO"
                                                OnClientClick="F_ImprimirDocumento(undefined,this,'imgDSP','DSP');  return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                <%--    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgPdf" ImageUrl="~/Asset/images/imprimir.gif"
                                                ToolTip="IMPRIMIR COTIZACION" OnClientClick="F_ImprimirDocumento(undefined,this,'imgPdf','IMP'); return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="O">
                            <ItemTemplate>
                                <img id="imgMasObservacion" alt="" style="cursor: pointer" src="../Asset/images/plus.gif"
                                    onclick="imgMasObservacion_Click(this);" title="OBSERVACION" />
                                <asp:Panel ID="pnlOrdersObservacion" runat="server" Style="display: none">
                                    <asp:GridView ID="grvDetalleObservacion" runat="server" border="0" CellPadding="0"
                                        CellSpacing="1" AutoGenerateColumns="False" GridLines="None" class="GridView">
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
                        <asp:TemplateField HeaderText="A">
                            <ItemTemplate>
                                <img id="imgMasAuditoria" alt="" style="cursor: pointer" src="../Asset/images/plus.gif"
                                    onclick="imgMasAuditoria_Click(this);" title="Auditoria" />
                                <asp:Panel ID="pnlOrdersAuditoria" runat="server" Style="display: none">
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
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <img id="imgMas" alt="" style="cursor: pointer" src="../Asset/images/plus.gif" onclick="imgMas_Click(this);"
                                                title="Ver Detalle" />
                                            <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                                                <asp:GridView ID="grvDetalle" runat="server" border="0" CellPadding="0" CellSpacing="1"
                                                    AutoGenerateColumns="False" GridLines="None" class="GridView">
                                                    <Columns>
                                                        <asp:BoundField DataField="Codigo" HeaderText="Codigo">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Material" HeaderText="Material">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Pestimado" HeaderText="P.Estimado">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="PxKilo" HeaderText="P.x Kilo">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="UM" HeaderText="UM">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Precio" HeaderText="Precio">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Importe" HeaderText="Importe">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <%-- <asp:TemplateField HeaderText="P">
                                        <ItemTemplate>
                                            <img id="imgMasNI" alt="" style="cursor: pointer" src="../Asset/images/plus.gif" onclick="imgMasNI_Click(this);"
                                                title="DETALLE PEDIDO" />
                                            <asp:Panel ID="pnlOrdersNI" runat="server" Style="display: none">
                                                <asp:GridView ID="grvDetalleNI" runat="server" border="0" CellPadding="0" CellSpacing="1"
                                                    AutoGenerateColumns="False" GridLines="None" class="GridView">
                                                    <Columns>
                                                        <asp:BoundField DataField="Codigo" HeaderText="Codigo">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="APartida" HeaderText="ALMACEN">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="NroNotaIngreso" HeaderText="Nota de Ingreso">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Estado" HeaderText="Estado">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Numero" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblnumero" Text='<%# Bind("Numero") %>' CssClass="detallesart"></asp:Label>
                                            <asp:HiddenField ID="lblCodigo" runat="server" Value='<%# Bind("Codigo") %>' />
                                            <asp:HiddenField ID="hfCodTipoDoc" runat="server" Value='<%# Bind("CodTipoDoc") %>' />                                            
                                            <asp:HiddenField ID="hfCodUsuario" runat="server" Value='<%# Bind("CodUsuario") %>' />
                                            <asp:HiddenField ID="hfCodTraslado" runat="server" Value='<%# Bind("CodGuia") %>' />
                                            <asp:HiddenField ID="hfVendedor" runat="server" Value='<%# Bind("Vendedor") %>' />
                                            <asp:HiddenField ID="hfFlagVisibleFacturacion" runat="server" Value='<%# Bind("FlagVisibleFacturacion") %>' />
                                            <asp:HiddenField ID="hfFlagVisibleFacturacionDsc" runat="server" Value='<%# Bind("FlagVisibleFacturacionDsc") %>' />
                                            <asp:HiddenField ID="hfNroOperacion" runat="server" Value='<%# Bind("NroOperacion") %>' />
                                            <asp:HiddenField ID="hfCodNotaIngresos" runat="server" Value='<%# Bind("CodNotaIngresos") %>' />
                                            <asp:HiddenField ID="hfDetalleCargado" runat="server" Value='0' />
                                            <asp:HiddenField ID="hfDetalleCargadoNI" runat="server" Value='0' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cliente" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblcliente" Text='<%# Bind("Cliente") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Emision" HeaderText="Emision" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Condicion" HeaderText="Condicion" HeaderStyle-HorizontalAlign="Center"
                                        Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Moneda">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblMoneda" Text='<%# Bind("Moneda") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total">
                                        <ItemStyle HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblTotal" Text='<%# Bind("Total") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--    <asp:BoundField DataField="Saldo" HeaderText="Saldo" HeaderStyle-HorizontalAlign="Center"
                                        Visible="false" DataFormatString="{0:N2}">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>--%>
                                    <asp:BoundField DataField="Guia" HeaderText="Guia" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                   <%-- <asp:TemplateField HeaderText="Vendedor">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblVendedor" Text='<%# Bind("Vendedor") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Estado">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblEstado" Text='<%# Bind("Estado") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Factura" HeaderText="OT" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </td>
                <td valign="top" style="width: 120px;display:none;">
                <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 250px;
                    height: 100%;">
                    <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                        Deuda del Cliente
                    </div>
                    <div id="div2" class="ui-jqdialog-content">
                        <div>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 60px; font-weight: bold; padding-left: 5px">
                                        Deuda
                                    </td>
                                    <td style="width: 190px; text-align: right; padding-right: 12px">
                                        <label id="txtSaldoCreditoFavor" style="font-weight: bold; font-size: 20px; text-align: right">
                                            S/0.00</label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="div_table_almacenes">
                            <div>
                                <table id="table_almacenes_deudas" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="font-weight: bold; padding-left: 5px">
                                            Deuda
                                        </td>
                                        <td style="padding-left: 10px; text-align: right">
                                            <label id="Label1" style="font-weight: bold; text-align: right">
                                                S/0.00</label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="text-align:center; padding-top:5px" >
                                <asp:Button ID="btnVerDetalleDeuda" runat="server" Text="Ver detalle de las Deudas"
                                    class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="220" OnClientClick="F_MostrarDetalle_DeudaCliente(); return false;"/>
                            </div>
                        </div>
                    </div>
                </div>
           
            </td>
        </tr>
    </table>
    <div id="divFacturacionOC" style="display: none;">
        <table cellpadding="0" cellspacing="0" width="850">
            <tr>
                <td align="right" style="padding-top: 10px;">
                    <asp:Button ID="btnDevolverItemOC" runat="server" Text="Devolver" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Width="120" />
                    <asp:Button ID="btnAgregarItemOC" runat="server" Text="Agregar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Width="120" />
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px;">
                    <div id="div_DetalleOC">
                        <asp:GridView ID="grvDetalleOC" runat="server" AutoGenerateColumns="False" border="0"
                            CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="860px">
                            <Columns>
                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chkEliminar" CssClass="chkDelete" Text="" onclick="F_ValidarCheck_OC(this.id);" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCodDetalle" Text='<%# Bind("CodDetalle") %>'></asp:Label>
                                        <asp:HiddenField ID="hfCodArticulo" runat="server" Value='<%# Bind("CodArticulo") %>' />
                                        <asp:HiddenField ID="hfCodUndMedida" runat="server" Value='<%# Bind("CodUndMedida") %>' />
                                        <asp:HiddenField ID="hfCodMovimiento" runat="server" Value='<%# Bind("CodMovimiento") %>' />
                                        <asp:HiddenField ID="hfSerieDoc" runat="server" Value='<%# Bind("SerieDoc") %>' />
                                        <asp:HiddenField ID="hfNumeroDoc" runat="server" Value='<%# Bind("NumeroDoc") %>' />
                                        <asp:HiddenField ID="hfCostoUnitario" runat="server" Value='<%# Bind("CostoUnitario") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Numero">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblNumero" Text='<%# Bind("Numero") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Codigo">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("Codigo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Descripcion">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblProducto" Text='<%# Bind("Producto") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Compra">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCantidad" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="UM" HeaderText="UM">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Precio">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPrecio" Text='<%# Bind("Precio") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" ID="txtCantidadEntregada" Width="55px" Font-Bold="true"
                                            Style="text-align: center;" Font-Names="Arial" onblur="F_ValidarStockGrillaOC(this.id);"
                                            Enabled="False"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="div_FacturacionGuia" style="display: none;">
        <table cellpadding="0" cellspacing="0" width="850">
            <tr>
                <td align="right" style="padding-top: 10px;">
                    <asp:Button ID="btnDevolverGuia" runat="server" Text="Devolver" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" ForeColor="Blue" Font-Bold="True" />
                    <asp:Button ID="btnAgregarGuia" runat="server" Text="Agregar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" ForeColor="Blue" Font-Bold="True" />
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px;">
                    <div id="div_GrillaFacturacionGuia">
                        <asp:GridView ID="grvFacturacionGuia" runat="server" AutoGenerateColumns="False"
                            border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                            Width="860px" Height="400">
                            <Columns>
                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chkEliminar" CssClass="chkDelete" Text="" onclick="F_ValidarCheck_OC(this.id);" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCodDetalle" Text='<%# Bind("CodDetalle") %>'></asp:Label>
                                        <asp:HiddenField ID="hfCodArticulo" runat="server" Value='<%# Bind("CodArticulo") %>' />
                                        <asp:HiddenField ID="hfCodUndMedida" runat="server" Value='<%# Bind("CodUndMedida") %>' />
                                        <asp:HiddenField ID="hfCodMovimiento" runat="server" Value='<%# Bind("CodMovimiento") %>' />
                                        <asp:HiddenField ID="hfSerieDoc" runat="server" Value='<%# Bind("SerieDoc") %>' />
                                        <asp:HiddenField ID="hfNumeroDoc" runat="server" Value='<%# Bind("NumeroDoc") %>' />
                                        <asp:HiddenField ID="hfCostoUnitario" runat="server" Value='<%# Bind("CostoUnitario") %>' />
                                        <asp:HiddenField ID="hfCodDepartamento" runat="server" Value='<%# Bind("CodDepartamento") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Guia">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblNumero" Text='<%# Bind("Numero") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="FechaEmision" HeaderText="Fecha">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Almacen" HeaderText="Almacen">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Codigo">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("Codigo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Producto" HeaderText="Descripcion">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Compra">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCantidad" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="UM" HeaderText="UM">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Precio">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPrecio" Text='<%# Bind("Precio") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" ID="txtCantidadEntregada" Width="55px" Font-Bold="true"
                                            Style="text-align: center;" Font-Names="Arial" onblur="F_ValidarStockGrillaOC(this.id);"
                                            Enabled="False"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="divConsultaArticulo" style="display: none;">
        <div id='divCabecera' class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                Criterio de busqueda
            </div>
            <div class="ui-jqdialog-content">
                <table cellpadding="0" cellspacing="0" class="form-inputs">
                    <tbody>
                        <tr>
                             <td style="font-weight: bold;">
                                <asp:CheckBox ID="chkMateriaPrima" runat="server" Text="MATERIA PRIMA" Font-Bold="True" />
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="padding-left: 5px; font-weight: bold">
                                            <asp:CheckBox ID="chkDescripcion" runat="server" Text="descripcion" Font-Bold="True"
                                                Style="display: none;" />
                                        </td>
                                        <td style="font-weight: bold">
                                Descripcion
                            </td>
                                        <td>
                                            <asp:TextBox ID="txtArticulo" runat="server" Width="717px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnBuscarArticulo" runat="server" Text="Buscar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                                Font-Names="Arial" Font-Bold="True" Width="120" />
                                        </td>
                                             <td style="font-weight: bold;font-size: medium;display:none;">
                                                        D1 :
                                                    </td>
                                                    <td style="font-weight: bold;display:none;">
                                                        <asp:Label ID="lblD1Articulo" style="font-size: medium; color: #000000" runat="server" Text="" Font-Bold="True"></asp:Label>
                                                    </td>
                                                     <td style="font-weight: bold;font-size: medium;display:none;">
                                                       D2 :
                                                    </td>
                                                    <td style="font-weight: bold;display:none;">
                                                        <asp:Label ID="lblD2Articulo"  style="font-size: medium; color: #000000" runat="server" Text="" Font-Bold="True"></asp:Label>
                                                    </td>
                                                     <td style="font-weight: bold;font-size: medium;display:none;">
                                                        D3 :
                                                    </td>
                                                    <td style="font-weight: bold;display:none;">
                                                        <asp:Label ID="lblD3Articulo" style="font-size: medium; color: #000000" runat="server" Text="" Font-Bold="True"></asp:Label>
                                                    </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="linea-button">
            </div>
            <div>
                <table>
                    <tr>
                        <td valign="top">
                        
                            <div style="overflow-y: scroll; height: 330px;">
                                               <div id="div_grvConsultaArticulo" style="padding-top: 5px">
                                    <asp:GridView ID="grvConsultaArticulo" runat="server" AutoGenerateColumns="False"
                                        border="0" CellPadding="0" CellSpacing="1" CssClass="GridView GridView-MaxHeight"
                                        GridLines="None" Width="970px" OnRowDataBound="grvConsultaArticulo_RowDataBound" > 
                                     <Columns>
                                            <asp:TemplateField>
                                            <ItemStyle Font-Bold="true"/>
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="imgAgregar" ImageUrl="~/Asset/images/ok.gif"
                                                        ToolTip="Agregar" OnClientClick="F_AgregarArticulo(this.id,1); return false;" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemStyle Font-Bold="true"/>
                                                <ItemTemplate>
                                                    <img id="imgMas" alt="" style="cursor: pointer" src="../Asset/images/plus.gif" onclick="F_Kardex(this);"
                                                        title="Ver Kardex" />
                                                    <asp:Panel ID="pnlOrdersKardex" runat="server" Style="display: none">
                                                        <asp:GridView ID="grvDetalleKardex" runat="server" border="0" CellPadding="0" CellSpacing="1"
                                                            AutoGenerateColumns="False" GridLines="None" class="GridView">
                                                            <Columns>
                                                                <asp:BoundField DataField="Fecha" HeaderText="Fecha">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Ruc" HeaderText="Ruc">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="RazonSocial" HeaderText="RazonSocial">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="LEFT" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Numero" HeaderText="Numero">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Precio" HeaderText="Precio">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Moneda" HeaderText="Moneda">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Código">
                                                <ItemStyle Font-Bold="true"/>
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="hlkCodNeumaticoGv" Text='<%# Bind("CodigoProducto") %>' Font-Size="Medium"></asp:Label>
                                                    <asp:HiddenField ID="lblcodproducto" runat="server" Value='<%# Bind("CodProducto") %>' />
                                                    <asp:HiddenField ID="hfcodunidadventa" runat="server" Value='<%# Bind("CodUnidadVenta") %>' />
                                                    <asp:HiddenField ID="hfcosto" runat="server" Value='<%# Bind("Costo") %>' />
                                                    <asp:HiddenField ID="lblPrecio1" runat="server" Value='<%# Bind("Precio1") %>' />
                                                    <asp:HiddenField ID="lblPrecio2" runat="server" Value='<%# Bind("Precio2") %>' />
                                                    <asp:HiddenField ID="lblPrecio3" runat="server" Value='<%# Bind("Precio3") %>' />
                                                    <asp:HiddenField ID="hfMedida" runat="server" Value='<%# Bind("Medida") %>' />
                                                    <asp:HiddenField ID="hfMarca" runat="server" Value='<%# Bind("Marca") %>' />
                                                    <asp:HiddenField ID="hfModelo" runat="server" Value='<%# Bind("Modelo") %>' />
                                                    <asp:HiddenField ID="hfPosicion" runat="server" Value='<%# Bind("Posicion") %>' />
                                                    <asp:HiddenField ID="hfDescripcion" runat="server" Value='<%# Bind("Descripcion") %>' />
                                                    <asp:HiddenField ID="hfAnio" runat="server" Value='<%# Bind("Anio") %>' />
                                                    <asp:HiddenField ID="hfCodigoAlternativo" runat="server" Value='<%# Bind("Codigo2") %>' />
                                                    <asp:HiddenField ID="hfFlagProductoInicial" runat="server" Value='<%# Bind("FlagProductoInicial") %>' />
                                                    <asp:HiddenField ID="hfMoneda" runat="server" Value='<%# Bind("Moneda") %>' />
                                                    <asp:HiddenField ID="hfStock" runat="server" Value='<%# Bind("Stock") %>' />
                                                    <asp:HiddenField ID="hfCodigoInterno" runat="server" Value='<%# Bind("CodigoInterno") %>' />
                                                    <asp:HiddenField ID="hfCodProductoAzure" runat="server" Value='<%# Bind("CodProductoAzure") %>' />
                                                    <asp:HiddenField ID="hfexclusivo" runat="server" Value='<%# Bind("Exclusivo") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Descripcion" HeaderStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:HyperLink runat="server" ID="lblProducto" Font-Underline="true" ForeColor="Blue" Font-Size="Medium"
                                                        Style="cursor: hand" Text='<%# Bind("Producto") %>' onclick="F_AgregarArticuloFromDsc(this.id); return false;">
                                                    </asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Stock">
                                                <ItemStyle HorizontalAlign="Center"/>
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblstock" Text='<%# Bind("Stock") %>' Font-Size="Medium"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="UM">
                                                <ItemStyle HorizontalAlign="Center"/>
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblUM" Text='<%# Bind("UM") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="CostoConIgv" HeaderText="Costo">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Precio1" HeaderText="Precio">
                                                <ItemStyle  />
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Moneda" HeaderText="Mon">
                                                <ItemStyle  />
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Precio" ItemStyle-HorizontalAlign="Center" Visible="false">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" ID="txtPrecioLibre" Width="55px" Font-Bold="true" Style="text-align: center;"
                                                        CssClass="ccsestilo" Font-Names="Arial" ForeColor="Blue" Text='<%# Bind("Precio1") %>'
                                                        onblur="F_ValidarPrecioGrilla(this.id); return false;" Enabled="false"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Precio" Visible="false">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlPrecio" runat="server" CssClass="ccsestilo" Font-Bold="true">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cant." ItemStyle-HorizontalAlign="Center" Visible="false">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" ID="txtCantidad" Width="55px" Font-Bold="true" Style="text-align: center;"
                                                        CssClass="ccsestilo" Font-Names="Arial" ForeColor="Blue" onblur="F_ValidarStockGrilla(this.id); return false;"
                                                        Enabled="False"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </td>
                        <td valign="top" >
                            <div id="divStocksEmpresas" style="width: 230px; padding-top: 5px;display:none;">
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
                            <div id="div_ultimoprecio">
                                <div class="ui-jqdialog-content">
                                    <div class="ui-jqdialog-content">
                                        <%--COMBO--%>
                                        <div id="divcombo">
                                            <%--<asp:Label runat="server" ID="lblID" Text='<%# Bind("ID") %>'></asp:Label>--%>
                                            <asp:Label runat="server" ID="lbCodProducto" Text=""></asp:Label>
                                            <asp:Label runat="server" ID="lbCodNeumatico" Text=""></asp:Label>
                                            <asp:TextBox ID="txtClienteDropTop" runat="server" Width="227px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                            <asp:DropDownList ID="ddlDropTop" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True">
                                                <asp:ListItem Text="Top 5" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="Top 10" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="Top 15" Value="15"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Button ID="btnBuscarTop" runat="server" Text="Buscar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                                Font-Names="Arial" Font-Bold="True" Width="120" />
                                        </div>
                                        <%--GRID CON LOS ULTIMOS PRECIOS--%>
                                        <div id="div_grvConsultaUltimosPrecios" style="padding-top: 5px;">
                                            <asp:GridView ID="grvConsultaUltimosPrecios" runat="server" AutoGenerateColumns="False"
                                                border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                                                Width="227px">
                                                <Columns>
                                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Factura" HeaderText="FT">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Cantidad" HeaderText="Cant">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Precio" HeaderText="Prec">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Moneda" HeaderText="Mon">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="linea-button">
            </div>
            <div class="ui-jqdialog-content">
                <table cellpadding="0" cellspacing="0" class="form-inputs">
                    <tbody>
                        <tr>
                            
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                    <td style="font-weight: bold">
                                Codigo
                            </td>
                                        <td>
                                            <asp:TextBox ID="txtCodigoProductoAgregar" runat="server" Width="340px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True" ReadOnly="true" Font-Size="16"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            Stock
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtStockAgregar" runat="server" Width="80px" Font-Names="Arial"
                                                CssClass="Derecha" ForeColor="Blue" Font-Bold="True" ReadOnly="true" Font-Size="16"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            UM
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtUMAgregar" runat="server" Width="68px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" ReadOnly="true" Font-Size="16"></asp:TextBox>
                                        </td>                                        
                                        <td style="font-weight: bold">
                                            Material
                                        </td>
                                        <td >
                                            <asp:TextBox ID="txtMaterial" runat="server" Width="145px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" Font-Size="16" ></asp:TextBox>
                                        </td> 
                                        <td style="font-weight: bold; margin-right:17px">
                                           P. Estimado
                                        </td>
                                        <td >
                                            <asp:TextBox ID="txtPEstimado" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" Font-Size="16" CssClass="Derecha" onblur="F_PrecioUnitario(this.id); return false;"></asp:TextBox>
                                        </td> 
                                        <td style="font-weight: bold">
                                           P. x Kilo
                                        </td>
                                        <td >
                                            <asp:TextBox ID="txtPxKilo" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" Font-Size="16" CssClass="Derecha" onblur="F_PrecioUnitario(this.id); return false;"></asp:TextBox>
                                        </td>
                                         <td style="font-weight: bold; color: Red; font-size: medium;display:none;">
                                            EXCLUSIVO
                                        </td>
                                        <td style="display: none">
                                            <asp:TextBox ID="txtExclusivo" runat="server" Width="100px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" Font-Size="16" CssClass="Derecha" Enabled="False"></asp:TextBox>
                                        </td> 
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold;display:none;">
                                <asp:CheckBox ID="chkServicios" runat="server" Text="Servicios" Font-Bold="True" />
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtArticuloAgregar" runat="server" Width="700px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True" Font-Size="16"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            Cantidad
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCantidad" runat="server" Width="40px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" CssClass="Derecha" Font-Size="16"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            Precio
                                        </td>
                                        <td>
                                            <asp:TextBox Style="width: 80px; position: absolute; color: blue; font-family: Arial;
                                                font-weight: bold; background: rgb(255, 255, 224);" ID="txtPrecioDisplay" runat="server"
                                                Font-Size="16"></asp:TextBox>
                                            <asp:DropDownList ID="ddlPrecio" Style="width: 100px" runat="server" Font-Size="16">
                                                <asp:ListItem Value="test1">test1</asp:ListItem>
                                                <asp:ListItem Value="test2">test2</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="font-weight: bold">
                                            <asp:Label ID="lblMonedaAgregar" runat="server" Text="" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                                Font-Names="Arial" Font-Bold="True" Width="136px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

        <div id="div_grvArticulosPedidoCab" style="display: none">

       <div style="display:block; margin-bottom:15px; margin-top:15px;" id="CamposPedido">
        <asp:Label  runat="server" Font-Bold="true" Text="Articulo"></asp:Label>
        <asp:TextBox ID="txtArticuloPedido" runat="server" Width="515px" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True"></asp:TextBox>
        <input type="hidden" id="hfCodArticuloPedido"/>        
        <asp:Label  runat="server" Font-Bold="true" Text="C. Actual"></asp:Label>
        <asp:TextBox ID="txtCantidadArticulo" runat="server" Width="50px" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True" CssClass="Derecha" ReadOnly="true"></asp:TextBox>
        <asp:Label  runat="server" Font-Bold="true" Text="C. 173"></asp:Label>
        <asp:TextBox ID="txtCantidad173Ped" runat="server" Width="50px" Font-Names="Arial" ForeColor="Blue"
        Font-Bold="True" CssClass="Derecha" onkeypress="return justNumbers(event);"></asp:TextBox>
        <asp:Label   runat="server" Font-Bold="true" Text="C. 250"></asp:Label>
        <asp:TextBox ID="txtCantidad250Ped" runat="server" Width="50px" Font-Names="Arial" ForeColor="Blue"
        Font-Bold="True" CssClass="Derecha" onkeypress="return justNumbers(event);"></asp:TextBox>
        <asp:Label   runat="server" Font-Bold="true" Text="C. ABC"></asp:Label>
        <asp:TextBox ID="txtCantidadABCPed" runat="server" Width="50px" Font-Names="Arial" ForeColor="Blue"
        Font-Bold="True" CssClass="Derecha" onkeypress="return justNumbers(event);"></asp:TextBox>
        <asp:Button ID="btnAgregarPedido" runat="server" Text="Agregar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
            Font-Names="Arial" Font-Bold="True" Width="115" />
       </div>
       
        <asp:Button ID="btnEliminarPedido" runat="server" Text="Eliminar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
            Font-Names="Arial" Font-Bold="True" Width="120" />

        <div style="text-align: center; width: 100%; color: Black; font-weight: bold">
            Cantidad de registros
            <asp:Label ID="lblNumRegistros" runat="server" Text="0"></asp:Label>
        </div>
        <div id="div_grvArticulosPedido" style="padding-top: 5px;">
            <asp:GridView ID="grvDetallePedido" runat="server" AutoGenerateColumns="False"
                border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                Width="1080px">
                <Columns>
                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                        <HeaderTemplate>
                            <asp:CheckBox runat="server" ID="chkAllDetalle" Text="" onclick="F_CheckAllPedido(this);" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkEliminar" CssClass="chkDelete" Text="" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>                    
                    <%--         <asp:TemplateField HeaderText="PE">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblAcuenta" Text="0.00"></asp:Label>
                              
                            </ItemTemplate>
                        </asp:TemplateField>--%>                    
                    <asp:TemplateField HeaderText="Codigo">
                        <HeaderStyle CssClass="novisible" />
                        <ItemStyle HorizontalAlign="Right" CssClass="novisible" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblCodigoProducto" Text='<%# Bind("CodigoProducto") %>'
                                CssClass="detallesart"></asp:Label>
                            <asp:HiddenField ID="hfCodPedido" runat="server" Value='<%# Bind("CodDetPedido") %>' />
                            <asp:HiddenField ID="hfCodArticulo" runat="server" Value='<%# Bind("CodArticulo") %>' />
                            <asp:HiddenField ID="hfCodDetDocumentoVenta" runat="server" Value='<%# Bind("CodDetDocumentoVenta") %>' />
                            <asp:HiddenField ID="hfCodDocumentoVenta" runat="server" Value='<%# Bind("CodDocumentoVenta") %>' />                                                                                                                
                            <asp:HiddenField ID="hfCantidad173" runat="server" Value='<%# Bind("Cantidad173") %>' /> 
                            <asp:HiddenField ID="hfCantidad250" runat="server" Value='<%# Bind("Cantidad250") %>' /> 
                            <asp:HiddenField ID="hfCantidadABC" runat="server" Value='<%# Bind("CantidadABC") %>' /> 
                        </ItemTemplate>
                    </asp:TemplateField>                                                         
                    <asp:TemplateField HeaderText="Descripcion" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtDescripcionPedido" Font-Bold="true" CssClass="ccsestilo"
                                Width="480px" Font-Names="Arial" ForeColor="Blue" Text='<%# Bind("Producto") %>' ReadOnly="true">
                                </asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="UM" HeaderText="UM">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="C. 173" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtCantidadPed173" Width="75px" Font-Bold="true" Style="text-align: center;"
                                CssClass="ccsestilo tcant" Font-Names="Arial" ForeColor="Blue" Text='<%# Bind("Cantidad173") %>'
                                onchange="F_ActualizarCantidadPedido(this.id); return false;" onkeypress="return justNumbers(event);"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="C. 250" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtCantidadPed250" Width="75px" Font-Bold="true" Style="text-align: center;"
                                CssClass="ccsestilo tcant" Font-Names="Arial" ForeColor="Blue" Text='<%# Bind("Cantidad250") %>'
                                onchange="F_ActualizarCantidadPedido(this.id); return false;" onkeypress="return justNumbers(event);"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="C. ABC" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtCantidadPedABC" Width="75px" Font-Bold="true" Style="text-align: center;"
                                CssClass="ccsestilo tcant" Font-Names="Arial" ForeColor="Blue" Text='<%# Bind("CantidadABC") %>'
                                onchange="F_ActualizarCantidadPedido(this.id); return false;" onkeypress="return justNumbers(event);"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>                    
                    <asp:TemplateField HeaderText="C. Total" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtCantidadPedTotal" Width="75px" Font-Bold="true" Style="text-align: center;"
                                CssClass="ccsestilo tcant" Font-Names="Arial" ForeColor="Blue" Text='<%# Bind("Cantidad") %>'
                                ReadOnly="true"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <div id="divNotaIngreso" style="display: none">

       
        <div id="div_grvNotaIngreso" style="padding-top: 5px;">
            <asp:GridView ID="grvNotaIngreso" runat="server" AutoGenerateColumns="False"
                border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                Width="800px">
                <Columns>                    
                    <%--         <asp:TemplateField HeaderText="PE">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblAcuenta" Text="0.00"></asp:Label>
                              
                            </ItemTemplate>
                        </asp:TemplateField>--%>                    
                    <asp:TemplateField HeaderText="Numero">
                        <HeaderStyle CssClass="novisible" />
                        <ItemStyle HorizontalAlign="Left" CssClass="novisible" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblNroNotaIngreso" Text='<%# Bind("NroNotaIngreso") %>'
                                CssClass="detallesart"></asp:Label>
                            <asp:HiddenField ID="hfCodNotaIngreso" runat="server" Value='<%# Bind("CodMovimiento") %>' />                            
                            <asp:HiddenField ID="hfCodUsuario" runat="server" Value='<%# Bind("CodUsuario") %>' /> 
                        </ItemTemplate>
                    </asp:TemplateField>                                                         
                    <asp:TemplateField HeaderText="ALMACEN" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblAlmacen" Text='<%# Bind("APartida") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="FechaEmision" HeaderText="EMISION">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Estado" HeaderText="ESTADO">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Observacion" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtObsNI" Width="448px" Font-Bold="true" Style="text-align: center; margin-right:2px"
                                CssClass="notIng" Font-Names="Arial" ForeColor="Blue"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="450px"></ItemStyle>
                    </asp:TemplateField>                                        
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="imgAnularIngreso" ImageUrl="~/Asset/images/EliminarBtn.png" ToolTip="ELIMINAR INGRESO"
                            OnClientClick="F_AnularNotaIngreso(this);"/>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="25px"/>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>


    <div id="div_PrecioMinimo" style="display: none;">
        <div class="ui-jqdialog-content">
            <table cellpadding="0" cellspacing="0" class="form-inputs">
                <tr>
                    <td>
                        Precio Minimo
                    </td>
                    <td>
                        <asp:TextBox ID="txtPrecioMinimo" runat="server" Width="80px" ReadOnly="True" Font-Names="Arial"
                            Font-Bold="True" Font-Size="Small"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMoneda" runat="server" Width="80px" ReadOnly="True" Font-Names="Arial"
                            Font-Bold="True" Font-Size="Small"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="div_VerPrecio" style="display: none;">
        <div id="div_PrecioMoneda" style="padding-top: 5px;">
            <asp:GridView ID="grvPrecioMoneda" runat="server" AutoGenerateColumns="False" border="0"
                CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="300px">
                <Columns>
                    <asp:BoundField DataField="CodProducto" HeaderText="ID">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Precio3" HeaderText="Precio 3">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Precio2" HeaderText="Precio 2">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Precio1" HeaderText="Precio 1">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Moneda" HeaderText="Moneda">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div id="div_ImpresorasNotaPedido" style="display: none;">
        <div class="ui-jqdialog-content">
            <table>
                <tr>
                    <td style="font-weight: bold">
                        Impresora
                    </td>
                    <td style="padding-left: 3px;">
                        <div id="div_ComboImpresoraNotaPedido">
                            <asp:DropDownList ID="ddlImpresoraNotaPedido" runat="server" Font-Names="Arial" ForeColor="Blue"
                                Font-Bold="True" Width="250">
                            </asp:DropDownList>
                        </div>
                    </td>
                    <td style="font-weight: bold">
                        <asp:Button ID="btnImprimirPedidos" runat="server" Text="Imprimir" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" Width="120" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="divClavePrecio" style="display: none">
        <table>
            <tr>
                <td style="font-weight: bold">
                    Usuario Auxiliar
                </td>
                <td>
                    <asp:TextBox ID="txtUsuarioPrecio" runat="server" Width="98px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" ToolTip="Ingresar Usuario"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Clave
                </td>
                <td>
                    <asp:TextBox ID="txtContraseñaPrecio" runat="server" Width="98px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" TextMode="Password" ToolTip="Ingresar Contraseña"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div class="linea-button">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" Width="100" />
                    </td>
                    <td>
                        <asp:Button ID="btnVerificar" runat="server" Text="Aceptar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" Width="100" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
        <div id="div_DetalleDeudasPopUp" style="display: none">
        <div id="div_DetalleDeudas">
            <asp:GridView ID="grvDetalleDeudas" runat="server" AutoGenerateColumns="False" border="0"
                CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="1018px">
                <Columns>
                    <asp:BoundField DataField="Almacen" HeaderText="Almacen">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NroDocumento" HeaderText="Nro. Documento">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Ruc" HeaderText="Ruc">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Emision" HeaderText="Emision">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Vencimiento" HeaderText="Vencimiento">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Retraso" HeaderText="Retraso">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="MontoDeudaSoles" HeaderText="Deuda Soles">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Vendedor" HeaderText="Vendedor">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>

    </div>
       <div id="div_Mantenimiento" style="display: none;">
        <div class="ui-jqdialog-content">
            <table cellpadding="0" cellspacing="0" class="form-inputs">
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnGrabarEdicion" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" Width="120" />
                        <asp:Button ID="btnCancelarEdicion" runat="server" Text="Cancelar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" Width="120" style="display:none;" />
                    </td>
                </tr>
                <tr>
                 <td style="font-weight: bold;">
                 Codigo
                 </td>
                 <td>
                  <table cellpadding="0" cellspacing="0">
                 <tr>
                  <td>
                        <asp:TextBox ID="txtCodigoEdicion" runat="server" Width="100px" Font-Names="Arial" ForeColor="Blue"
                            Font-Bold="True" ReadOnly="True" ></asp:TextBox>
                    </td>
                    <td>
                     <asp:TextBox ID="txtProductoEdicion" runat="server" Width="300px" Font-Names="Arial"
                         ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                    </td>
                 </tr>
                 </table>
                 </td>
                
                   
                </tr>
                <tr>
                    <td style="font-weight: bold;font-weight: bold">
                        TIPO
                    </td>
                    <td style="padding-left: 4px;">
                           <div id="div_Gratuito">
                                <asp:DropDownList ID="ddlGratuito" runat="server" Font-Names="Arial" ForeColor="Blue"  Font-Bold="True">                                  
                                </asp:DropDownList>
                          </div>
                    </td>
                </tr>           
            </table>
        </div>
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
                                    Precio1
                                </td>
                                <td colspan='5'>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="padding-left: 0px;">
                                                <asp:TextBox ID="txtPaisVisualizacion" runat="server" Width="100px" Font-Names="Arial"
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
    <div id="div_NumeroDocumento" style="background-color: #CCE6FF; text-align: center;
        display: none;">
        <br />
        <br />
        <center>
            <asp:Label ID="Label6" runat="server" Text="Numero de Cotizacion" Font-Bold="true"
                Font-Size="Large" Style="text-align: center"></asp:Label>
        </center>
        <br />
        <center>
            <asp:Label ID="lblNumeroDocumento" runat="server" Text="" Font-Bold="true" Font-Size="XX-Large"
                Style="text-align: center"></asp:Label>
        </center>
        <br />
    </div>
      <div id="div_Anulacion" style="display: none;">
        <div class="ui-jqdialog-content">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="font-weight: bold">
                        ¿ PORQUE LO ESTAS ANULANDO ?
                    </td>
                  
                </tr>
                <tr>
                  <td>
                           <asp:TextBox ID="txtObservacionAnulacion" runat="server" Width="450px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" TextMode="MultiLine" Rows="10"  Height="80"></asp:TextBox>
                    </td>
                 
                </tr>
                <tr>
                   <td style="font-weight: bold;padding-top:5px;"  align="right">
                        <asp:Button ID="btnAnular" runat="server" Text="Anular" class="ui-button ui-widget
    ui-state-default ui-corner-all ui-button-text-only" Font-Names="Arial" Font-Bold="True" Width="120" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="dlgWait" style="background-color: #CCE6FF; text-align: center; display: none;">
        <br />
        <br />
        <div id="div_wait" style="display: block">
            <center>
                <asp:Label ID="Label7" runat="server" Text="PROCESANDO..." Font-Bold="true" Font-Size="Large"
                    Style="text-align: center"></asp:Label></center>
            <br />
            <center>
                <img alt="Wait..." src="../Asset/images/ajax-loader2.gif" /></center>
        </div>
    </div>
    <input id="hfCodCtaCte" type="hidden" value="0" />
    <input id="hfCodCtaCteConsulta" type="hidden" value="0" />
    <input id="hfCodigoTemporal" type="hidden" value="0" />
    <input id="hfCodDocumentoVenta" type="hidden" value="0" />
    <input id="hfNotaPedido" type="hidden" value="0" />
    <input id="hfCodCtaCteNP" type="hidden" value="0" />
    <input id="hfCodUsuario" type="hidden" value="0" />
    <input id="hfCodDepartamento" type="hidden" value="0" />
    <input id="hfCodProvincia" type="hidden" value="0" />
    <input id="hfCodDistrito" type="hidden" value="0" />
    <input id="hfCodProforma" type="hidden" value="0" />
    <input id="hfCodTraslado" type="hidden" value="0" />
    <input id="hfPartida" type="hidden" value="" />
    <input id="hfCodNotaVenta" type="hidden" value="0" />
    <input id="hfCodSede" type="hidden" value="0" />
    <input id="hfCodTipoCliente" type="hidden" value="0" />
    <input id="hfCodDireccion" type="hidden" value="0" />
    <input id="hfCodTipoDoc2" type="hidden" value="0" />
    <input id="hfNroRuc" type="hidden" value="" />
    <input id="hfDistrito" type="hidden" value="" />
    <input id="hfDireccion" type="hidden" value="" />
    <input id="hfCliente" type="hidden" value="" />
    <input id="hfCodTransportista" type="hidden" value="0" />
    <input id="hfCodDireccionTransportista" type="hidden" value="0" />
    <input id="hfCodFacturaAnterior" type="hidden" value="0" />
    <input id="hfNumeroAnterior" type="hidden" value="0" />
    <input id="hfSaldoCreditoFavor" type="hidden" value="0" />
    <input id="hfCodProductoAgregar" type="hidden" value="0" />
    <input id="hfMenorPrecioAgregar" type="hidden" value="0" />
    <input id="hfCostoAgregar" type="hidden" value="0" />
    <input id="hfCodUmAgregar" type="hidden" value="0" />
    <input id="hfCodDireccionDefecto" type="hidden" value="0" />
    <input id="hfFlagRuc" type="hidden" value="0" />
    <input id="hfurlapisunat" type="hidden" value="0" />
    <input id="hftokenapisunat" type="hidden" value="0" />
    <input id="hfCodigo" type="hidden" value="0" />
     <input id="hfEstado" type="hidden" value="0" />
     <input id="hfNumeroAnulacion" type="hidden" value="0" />
     <input id="hfnumero_grilla" type="hidden" value="0" />
     <input id="hfcliente_grilla" type="hidden" value="0" />
     <input id="hfcodtipodoc_grilla" type="hidden" value="0" />
     <input id="hfIdAlmacen" type="hidden" value="0"/>
     <input id="hfpestimado" type="hidden" value="0"/>
     <input id="hfpxkilo" type="hidden" value="0"/>
     
     <input id="hfPrecioExclusivo" type="hidden" value="0"/>
</asp:Content>
