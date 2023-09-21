<%@ Page Title="REG. VENTA" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="RegistroFacturaMultipleOmar.aspx.cs" Inherits="SistemaInventario.Ventas.RegistroFacturaMultipleOmar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>
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
    <script type="text/javascript" language="javascript" src="RegistroFacturaMultipleOmar.js"
        charset="UTF-8"></script>
    <link href="../Asset/css/redmond/jquery-ui-1.10.4.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.core.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.default.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/sss.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr valign="top">
            <td style="width: 1100px" valign="top">
                <div class="titulo" style="width: 1045px">
                    <asp:Label ID="lbTipoDocumento" runat="server" Text="Factura" Font-Bold="False" Font-Size="Large"
                        Visible="false"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text="REGISTRO DE DOCUMENTO DE VENTA" Font-Bold="False"
                        Font-Size="Large"></asp:Label>
                </div>
                <div id="divTabs" style="width: 1045px">
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
                                            Tipo
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <div id="div_TipoDoc">
                                                            <asp:DropDownList ID="ddlTipoDoc" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="85px">
                                                                <asp:ListItem Value="1">FACTURA</asp:ListItem>
                                                                <asp:ListItem Value="2">BOLETA</asp:ListItem>
                                                                <asp:ListItem Value="15">COTIZACION</asp:ListItem>
                                                                <asp:ListItem Value="16">NOTA DE PEDIDO</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td style="font-weight: bold">
                                                        Cliente
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNroRuc" runat="server" Width="70px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" MaxLength="11" onblur="F_ValidaRucDni(); return false;"></asp:TextBox>
                                                    </td>
                                                    <td id="td_loading" style="font-weight: bold; padding-left: 5px; display: none">
                                                        <img src="../Asset/images/loading.gif" />
                                                    </td>
                                                    <td id="div_Cliente">
                                                        <asp:TextBox ID="txtCliente" runat="server" Width="310px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold">
                                                        Distrito
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDistrito" runat="server" Width="340px" Font-Names="Arial" ForeColor="Blue"
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
                                                        <asp:TextBox Style="width: 508px; position: absolute; color: blue; font-family: Arial;
                                                            font-weight: bold; background: rgb(255, 255, 224);" ID="txtDireccion" runat="server"
                                                            autocomplete="off"></asp:TextBox>
                                                        <asp:DropDownList ID="ddlDireccion" Style="width: 528px" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="font-weight: bold">
                                                        Moneda
                                                    </td>
                                                    <td style="padding-left: 4px">
                                                        <div id="div_moneda">
                                                            <asp:DropDownList ID="ddlMoneda" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="85" BackColor="#FFFF99">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td id="tdftNormal">
                                                        <table>
                                                            <tr>
                                                                <td style="font-weight: bold">
                                                                    Serie
                                                                </td>
                                                                <td id="tdddlSerie">
                                                                    <div id="div_serie">
                                                                        <asp:DropDownList ID="ddlSerie" Width="55" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                            Font-Bold="True">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </td>
                                                                <td id="tdtxtNumero">
                                                                    <asp:TextBox ID="txtNumero" runat="server" Width="48" Font-Names="Arial" ForeColor="Blue"
                                                                        Font-Bold="True"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td style="font-weight: bold;">
                                                        Igv (%)
                                                    </td>
                                                    <td>
                                                        <div id="div_igv">
                                                            <asp:DropDownList ID="ddlIgv" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="53">
                                                            </asp:DropDownList>
                                                        </div>
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
                                                            ForeColor="Blue" Font-Bold="True" ReadOnly="False"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold;">
                                                        condICION PAGO
                                                    </td>
                                                    <td>
                                                        <div id="div_formapago">
                                                            <asp:DropDownList ID="ddlFormaPago" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="85">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td style="font-weight: bold;">
                                                        vcto
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtVencimiento" runat="server" Width="56px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold;">
                                                        T.C.
                                                    </td>
                                                    <td style="font-weight: bold;">
                                                        <asp:Label ID="lblTC" runat="server" Text="Label" Font-Bold="True"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chkConIgvMaestro" Text="Con Igv" onclick="F_ValidarCheckConIgvMaestro(this.id);"
                                                            Checked="True" Font-Bold="True" />
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chkSinIgvMaestro" Text="Sin Igv" onclick="F_ValidarCheckSinIgvMaestro(this.id);"
                                                            Font-Bold="True" />
                                                    </td>
                                                    <td style="font-weight: bold; padding-left: 4PX;">
                                                        SubTotal
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSubTotal" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                            CssClass="Derecha" Font-Bold="True" ReadOnly="True" Text="0.00"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold; padding-left: 10px">
                                                        Igv
                                                    </td>
                                                    <td style="padding-left: 14PX;">
                                                        <asp:TextBox ID="txtIgv" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                            CssClass="Derecha" Font-Bold="True" ReadOnly="True" Text="0.00"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold">
                                                        total
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTotal" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                            CssClass="Derecha" Font-Bold="True" ReadOnly="True" Text="0.00"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold">
                                            Correo
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtCorreo" runat="server" Width="238px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" ReadOnly="False"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold; display: none">
                                                        Cotizacion
                                                    </td>
                                                    <td style="display: none">
                                                    </td>
                                                    <td style="font-weight: bold">
                                                        Orden Compra
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNroOC" runat="server" Width="190px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold;">
                                                        Placa
                                                    </td>
                                                    <td id="div_Placa1" style="padding-left: 13px;">
                                                        <asp:TextBox ID="txtPlaca" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold; padding-left: 10px">
                                                        KM
                                                    </td>
                                                    <td id="Td1" style="padding-left: 16px;">
                                                        <asp:TextBox ID="txtKM" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chkImpresion" runat="server" Text="Impresion" Font-Bold="True" />
                                                    </td>
                                                    <td style="display: none">
                                                        <asp:TextBox ID="txtAtencion" runat="server" Width="225px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold; display: none">
                                                        Referencia
                                                    </td>
                                                    <td style="display: none">
                                                        <asp:TextBox ID="txtReferencia" runat="server" Width="197px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td id="div_lblPlaca1" style="font-weight: bold; display: none;">
                                                        Vehiculos
                                                    </td>
                                                    <td id="div_Placa2">
                                                        <asp:TextBox ID="txtPlaca2" runat="server" Width="50px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td id="div_Placa3">
                                                        <asp:TextBox ID="txtPlaca3" runat="server" Width="50px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td id="div_Placa4">
                                                        <asp:TextBox ID="txtPlaca4" runat="server" Width="50px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold">
                                            VENDEDOR
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <div id="div_Vendedor">
                                                            <asp:DropDownList ID="ddlVendedor" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="242">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td style="font-weight: bold; padding-left: 2px">
                                                        Nro Operacion
                                                    </td>
                                                    <td style="padding-left: 0px;">
                                                        <asp:TextBox ID="txtNroOperacion" runat="server" Width="100px" Font-Names="Arial"
                                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold">
                                                        Cotizacion
                                                    </td>
                                                    <td style="padding-left: 10px">
                                                        <asp:TextBox ID="txtCodCotizacion" CssClass="Derecha" runat="server" Width="100px"
                                                            Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="display: none">
                                                        <asp:TextBox ID="txtCotizacion" runat="server" Width="45" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chkNotaVentaANTIGUA" runat="server" Text="ANTIGUO ENVIA SUNAT"
                                                            Font-Bold="True" />
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chkFacturaAntigua" runat="server" Text="ANTIGUO NO ENVIA SUNAT"
                                                            Font-Bold="True" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="accordion">
                                <h3>
                                    DATOS DE LA GUIA</h3>
                                <div>
                                    <div class="ui-jqdialog-content">
                                        <table cellpadding="0" cellspacing="0" class="form-inputs">
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkGuia" runat="server" Text="Guia Serie" Font-Bold="True" />
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <div id="div_serieguia">
                                                                    <asp:DropDownList ID="ddlSerieGuia" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                        Font-Bold="True">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtNumeroGuia" runat="server" Width="50" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True"></asp:TextBox>
                                                            </td>
                                                            <td style="font-weight: bold; padding-left: 97px;">
                                                                Fecha
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtFechaTraslado" runat="server" Width="56px" CssClass="Jq-ui-dtp"
                                                                    Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                            </td>
                                                            <td style="font-weight: bold;">
                                                                Destino
                                                            </td>
                                                            <td style="padding-left: 14px;">
                                                                <asp:TextBox ID="txtDestino" runat="server" Width="510px" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="font-weight: bold">
                                                    Transportista
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtTransportista" runat="server" Width="300" Font-Names="Arial"
                                                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                            </td>
                                                            <td style="font-weight: bold">
                                                                Direccion
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtDireccionTransportista" runat="server" Width="510" Font-Names="Arial"
                                                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                            </td>
                                                            <td style="display: none;">
                                                                <asp:CheckBox ID="chkImpresionTicket" runat="server" Text="Ticket" Checked="True"
                                                                    Font-Bold="True" />
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
                                                            <td id="tdftOC">
                                                                <table>
                                                                    <tr>
                                                                        <td style="font-weight: bold;">
                                                                            Serie
                                                                        </td>
                                                                        <td id="tdtxtSerieOC">
                                                                            <asp:TextBox ID="txtSerieOC" runat="server" Width="25px" ForeColor="Blue" Font-Names="Arial"
                                                                                Font-Bold="True"></asp:TextBox>
                                                                        </td>
                                                                        <td style="font-weight: bold;">
                                                                            Num.
                                                                        </td>
                                                                        <td id="tdtxtNumeroOC">
                                                                            <asp:TextBox ID="txtNumeroOC" runat="server" Width="42px" ForeColor="Blue" Font-Names="Arial"
                                                                                Font-Bold="True"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr style="display: none">
                                                <td style="font-weight: bold">
                                                    Placa
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtPlacaTraslado" runat="server" Width="60" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True"></asp:TextBox>
                                                            </td>
                                                            <td style="font-weight: bold">
                                                                Marca
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtMarcaGuia" runat="server" Width="190" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True"></asp:TextBox>
                                                            </td>
                                                            <td style="font-weight: bold">
                                                                Licencia
                                                            </td>
                                                            <td style="padding-left: 11px;">
                                                                <asp:TextBox ID="txtLicenciaGuia" runat="server" Width="120" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True"></asp:TextBox>
                                                            </td>
                                                            <td style="font-weight: bold">
                                                                Numero Bultos
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtNuBultos" runat="server" Width="30" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                                                            </td>
                                                            <td style="font-weight: bold">
                                                                Peso (kg)
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPeso" runat="server" Width="30" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div class="linea-button">
                                <asp:Button ID="btnListarCotizaciones" runat="server" Text="Listar Cotiz." class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120" />
                                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120" Style="display: none;" />
                                <asp:Button ID="btnNuevo" runat="server" Text="Limpiar (F1)" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120" />
                                <asp:Button ID="btnAgregarProducto" runat="server" Text="Agregar (F2)" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120" />
                                <asp:Button ID="btnNotaVenta" runat="server" Text="Nota Venta (F3)" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120" />
                                <asp:Button ID="btnCotizacion" runat="server" Text="Cotizaciones (F4)" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120" />
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar (F5)" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120" />
                                <asp:Button ID="btnGrabar" runat="server" Text="Grabar (F6)" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
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
                                        <label id="lblCantidadRegistro">
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="div_grvDetalleArticulo" style="padding-top: 5px;">
                            <asp:GridView ID="grvDetalleArticulo" runat="server" AutoGenerateColumns="False"
                                border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                                Width="1018px">
                                <Columns>
                                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkEliminar" CssClass="chkDelete" Text="" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID">
                                        <ItemStyle Font-Bold="true" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" ID="lblcoddetalle" Font-Underline="true" ForeColor="Blue"
                                                Style="cursor: hand" Text='<%# Bind("CodDetalle") %>' onclick="F_VerUltimoPrecio2(this.id); return false;"
                                                ToolTip="Ver Series">
                                            </asp:HyperLink>
                                            <asp:HiddenField ID="hfcodarticulo" runat="server" Value='<%# Bind("CodArticulo") %>' />
                                            <asp:HiddenField ID="hfCodDetalleOC" runat="server" Value='<%# Bind("CodDetalleOC") %>' />
                                            <asp:HiddenField ID="hfCantidad" runat="server" Value='<%# Bind("Cantidad") %>' />
                                            <asp:HiddenField ID="hfPrecio" runat="server" Value='<%# Bind("Precio") %>' />
                                            <asp:HiddenField ID="hfDescripcion" runat="server" Value='<%# Bind("Producto") %>' />
                                            <asp:HiddenField ID="hfCodTipoDoc" runat="server" Value='<%# Bind("CodTipoDoc") %>' />
                                            <asp:HiddenField ID="hfP1" runat="server" Value='<%# Bind("P1") %>' />
                                            <asp:HiddenField ID="hfP2" runat="server" Value='<%# Bind("P2") %>' />
                                            <asp:HiddenField ID="hfP3" runat="server" Value='<%# Bind("P3") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="CodigoProducto" HeaderText="Código">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Descripcion" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtDescripcion" Font-Bold="true" CssClass="ccsestilo"
                                                Width="480px" Font-Names="Arial" ForeColor="Blue" Text='<%# Bind("Producto") %>'
                                                onblur="F_ActualizarDescripcion(this.id); return false;"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtCantidad" Width="75px" Font-Bold="true" Style="text-align: center;"
                                                CssClass="ccsestilo" Font-Names="Arial" ForeColor="Blue" Text='<%# Bind("Cantidad") %>'
                                                onblur="F_ActualizarCantidad(this.id); return false;"></asp:TextBox>
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
                                                onblur="F_ActualizarPrecio(this.id); return false;"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Importe">
                                        <ItemStyle HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblimporte" Text='<%# Bind("Importe") %>' CssClass="detallesart"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ACUENTA NV">
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
                                                Tipo
                                            </td>
                                            <td>
                                                <div id="div_TipoDoc2">
                                                    <asp:DropDownList ID="ddlTipoDoc2" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True" Width="85px">
                                                        <asp:ListItem Value="1">FACTURA</asp:ListItem>
                                                        <asp:ListItem Value="2">BOLETA</asp:ListItem>
                                                        <asp:ListItem Value="15">COTIZACION</asp:ListItem>
                                                        <asp:ListItem Value="16">NOTA DE PEDIDO</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
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
                                                <asp:TextBox ID="txtClienteConsulta" runat="server" Width="190" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold">
                                                VENDEDOR
                                            </td>
                                            <td>
                                                <div id="div_EmpleadoConsulta">
                                                    <asp:DropDownList ID="ddlEmpleadoConsulta" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True" Width="115">
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
                                        <label id="lblGrillaConsulta">
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="div_consulta" style="padding-top: 5px;">
                            <asp:GridView ID="grvConsulta" runat="server" AutoGenerateColumns="False" border="0"
                                CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="1005px"
                                OnRowDataBound="grvConsulta_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkEliminar" CssClass="chkDelete" Text="" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgEliminarDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                                ToolTip="Eliminar Factura" OnClientClick="F_EliminarRegistro(this); return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/Eliminar.jpg"
                                                ToolTip="Anular Factura" OnClientClick="F_AnularRegistro(this); return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgEditarDocumento" ImageUrl="~/Asset/images/btnEdit.gif"
                                                ToolTip="Editar Factura" OnClientClick="F_EditarRegistro(this); return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgReemplazar" ImageUrl="~/Asset/images/Reemplazo.png"
                                                ToolTip="Actualizar Documento" OnClientClick="F_ReemplazarDocumento(this); return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PDF">
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgPdf2" ImageUrl="~/Asset/images/pdf.png" ToolTip="Generar Version PDF"
                                                OnClientClick="F_ImprimirDocumento(undefined,this,'imgPdf2','PDF'); return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GR">
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgImprimir" ImageUrl="~/Asset/images/imprimir.gif"
                                                ToolTip="Imprimir Guia" OnClientClick="F_ImprimirGuia(this); return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="IMP">
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgPdf" ImageUrl="~/Asset/images/imprimir.gif"
                                                ToolTip="Imprimir Factura" OnClientClick="F_ImprimirDocumento(undefined,this,'imgPdf','IMP'); return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CE">
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgMail" ImageUrl="~/Asset/images/Mail2.png"
                                                ToolTip="Reenvio de Correo" OnClientClick="F_ReenvioMail(this); return false;" />
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
                                                        <asp:BoundField DataField="ID" HeaderText="ID">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
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
                                                        <asp:BoundField DataField="OV" HeaderText="Anexo">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Anexo2" HeaderText="Anexo 2">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Numero" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblnumero" Text='<%# Bind("Numero") %>' CssClass="detallesart"></asp:Label>
                                            <asp:HiddenField ID="lblCodigo" runat="server" Value='<%# Bind("Codigo") %>' />
                                            <asp:HiddenField ID="hfCodTipoDoc" runat="server" Value='<%# Bind("CodTipoDoc") %>' />
                                            <asp:HiddenField ID="hfCodTraslado" runat="server" Value='<%# Bind("CodGuia") %>' />
                                            <asp:HiddenField ID="hfDetalleCargado" runat="server" Value='0' />
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
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Condicion" HeaderText="Condicion" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Moneda" HeaderText="Moneda" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Saldo" HeaderText="Saldo" HeaderStyle-HorizontalAlign="Center"
                                        DataFormatString="{0:N2}">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Guia" HeaderText="Guia">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Estado">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblEstado" Text='<%# Bind("Estado") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="FechaCancelacion" HeaderText="Cancelac" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Est. Sunat">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" ID="lblEstadoSunat" Font-Underline="true" ForeColor="Black"
                                                Style="cursor: hand" Text='<%# Bind("EstadoSunat") %>' onclick="F_VerArchivoCDR(this.id); return false;"
                                                ToolTip="Ver Archivo CDR">
                                            </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Correo Sunat">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblCorreoSunat" Text='<%# Bind("EstadoCorreoSunat") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </td>
            <td valign="top" style="width: 120px">
                <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 250px;
                    height: 100%;">
                    <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                        Saldo de Credito a Favor
                    </div>
                    <div id="div2" class="ui-jqdialog-content">
                        <div>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="font-weight: bold">
                                        Saldo a Favor
                                    </td>
                                    <td style="padding-left: 5px">
                                        <label id="txtSaldoCreditoFavor" style="font-weight: bold; font-size: 20px;">
                                            S/0.00</label>
                                        <%--                                        <asp:TextBox ID="txtSaldoCreditoFavor2" runat="server" Width="150px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True" Enabled="false" CssClass="Derecha"></asp:TextBox>--%>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 250px;
                    height: 100%;">
                    <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                        Cotizaciones
                    </div>
                    <div id="divListaCotizaciones" class="ui-jqdialog-content">
                        <ul id="lu_Cotizaciones" class="ul-float" style="padding-left: 5px; width: 220px">
                        </ul>
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
                            <td style="font-weight: bold">
                                Descripcion
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="padding-left: 5px; font-weight: bold">
                                            <asp:CheckBox ID="chkDescripcion" runat="server" Text="descripcion" Font-Bold="True"
                                                Style="display: none;" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtArticulo" runat="server" Width="717px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnBuscarArticulo" runat="server" Text="Buscar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                                Font-Names="Arial" Font-Bold="True" Width="120" />
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
                            <div>
                                <table class="GridView" style="padding-top: 5px; padding-bottom: 0px; margin-bottom: 5px">
                                    <tr>
                                        <th scope="col" style="width: 26px">
                                            &nbsp;
                                        </th>
                                        <th scope="col" style="width: 15px">
                                            &nbsp;
                                        </th>
                                        <th scope="col" style="width: 150px">
                                            Código
                                        </th>
                                        <th align="center" scope="col">
                                            Descripcion
                                        </th>
                                        <th scope="col" style="width: 55px">
                                            Stock
                                        </th>
                                        <th scope="col" style="width: 33px">
                                            UM
                                        </th>
                                        <th align="center" scope="col" style="width: 62px">
                                            Costo
                                        </th>
                                        <th align="center" scope="col" style="width: 62px">
                                            Precio
                                        </th>
                                        <th align="center" scope="col" style="width: 40px">
                                            Mon
                                        </th>
                                        <th scope="col" style="width: 8px">
                                            &nbsp;
                                        </th>
                                    </tr>
                                </table>
                            </div>
                            <div style="overflow-y: scroll; height: 330px;">
                                <div id="div_grvConsultaArticulo" style="padding-top: 5px">
                                    <asp:GridView ID="grvConsultaArticulo" runat="server" AutoGenerateColumns="False"
                                        border="0" CellPadding="0" CellSpacing="1" CssClass="GridView GridView-MaxHeight"
                                        GridLines="None" Width="970px" OnRowDataBound="grvConsultaArticulo_RowDataBound"
                                        ShowHeader="false"
                                        >
                                        <Columns>
                                            <asp:TemplateField>
                                            <ItemStyle Font-Bold="true" Width="26px" />
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="imgAgregar" ImageUrl="~/Asset/images/ok.gif"
                                                        ToolTip="Agregar" OnClientClick="F_AgregarArticulo(this.id,1); return false;" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemStyle Font-Bold="true" Width="18px" />
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
                                                <ItemStyle Font-Bold="true" Width="150px" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="hlkCodNeumaticoGv" Text='<%# Bind("CodigoProducto") %>'></asp:Label>
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
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Descripcion" HeaderStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:HyperLink runat="server" ID="lblProducto" Font-Underline="true" ForeColor="Blue"
                                                        Style="cursor: hand" Text='<%# Bind("Producto") %>' onclick="F_AgregarArticuloFromDsc(this.id); return false;">
                                                    </asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Stock">
                                                <ItemStyle HorizontalAlign="Center" Width="50px"  />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblstock" Text='<%# Bind("Stock") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="UM">
                                                <ItemStyle HorizontalAlign="Center"  Width="38px" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblUM" Text='<%# Bind("UM") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="CostoConIgv" HeaderText="Costo">
                                                <ItemStyle Width="64px" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Precio1" HeaderText="Precio">
                                                <ItemStyle Width="64px" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Moneda" HeaderText="Mon">
                                                <ItemStyle Width="44px" />
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
                                        <%--ARCHIVO CDR--%>
                                        <div id="div_CDR" style="display: none">
                                            <div>
                                                <table cellpadding="0" cellspacing="0" class="form-inputs">
                                                    <tr>
                                                        <td style="font-weight: bold">
                                                            Factura
                                                        </td>
                                                        <td style="padding-left: 10px">
                                                            <asp:TextBox ID="txtFacturaCDR" runat="server" Width="200px" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-weight: bold">
                                                            Archivo
                                                        </td>
                                                        <td style="padding-left: 10px">
                                                            <asp:TextBox ID="txtArchivoCDR" runat="server" Width="200px" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td style="padding-left: 10px">
                                                            <div id="tr_btnDescargaCDR">
                                                                <asp:Button ID="btnDescargarCDR" runat="server" Text="Descargar XML CDR Y PDF" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                                                    Font-Names="Arial" Font-Bold="True" Width="200" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
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
                            <td style="font-weight: bold">
                                Codigo
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtCodigoProductoAgregar" runat="server" Width="425px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True" ReadOnly="true" Font-Size="16"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            Stock
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtStockAgregar" runat="server" Width="100px" Font-Names="Arial"
                                                CssClass="Derecha" ForeColor="Blue" Font-Bold="True" ReadOnly="true" Font-Size="16"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            UM
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtUMAgregar" runat="server" Width="100px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" ReadOnly="true" Font-Size="16"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
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
                                                Font-Names="Arial" Font-Bold="True" Width="120" />
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
    <div id="div_FacturarCotizacion" style="display: none;">
        <div class="ui-jqdialog-content">
            <table>
                <tr>
                    <td>
                        Numero Cotizacion
                    </td>
                    <td style="padding-left: 5px;">
                        <%--                        <asp:TextBox ID="txtCodCotizacion" runat="server" Width="150px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True" Font-Size="Small"></asp:TextBox>--%>
                    </td>
                    <td style="padding-left: 5px;">
                        <asp:Button ID="btnFacturarCotizacion" runat="server" Text="Facturar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="div_FacturacionNotaVenta" style="display: none;">
        <div class="ui-jqdialog-content">
            <table>
                <tr>
                    <td>
                        Codigo (ID)
                    </td>
                    <td style="padding-left: 5px;">
                        <asp:TextBox ID="txtCodNotaVenta" runat="server" Width="80px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True" Font-Size="Small"></asp:TextBox>
                    </td>
                    <td style="padding-left: 10px;">
                        <asp:Button ID="btnFacturarNV" runat="server" Text="Facturar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" />
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
    <div id="divFacturacionNV" style="display: none;">
        <table cellpadding="0" cellspacing="0" width="850">
            <tr>
                <td style="padding-top: 10px;">
                    <asp:CheckBox ID="chkDesdeNV" runat="server" Text="DESDE" Font-Bold="True" Checked="True" />
                </td>
                <td style="padding-left: 2px; padding-top: 10px;">
                    <asp:TextBox ID="txtDesdeNV" runat="server" Width="55" Font-Names="Arial" ForeColor="Blue"
                        Font-Bold="True" CssClass="Jq-ui-dtp" ReadOnly="True"></asp:TextBox>
                </td>
                <td style="padding-top: 10px; padding-left: 2px; font-weight: bold">
                    HASTA
                </td>
                <td style="padding-top: 10px; padding-left: 2px;">
                    <asp:TextBox ID="txtHastaNV" runat="server" Width="55" Font-Names="Arial" ForeColor="Blue"
                        Font-Bold="True" CssClass="Jq-ui-dtp" ReadOnly="True"></asp:TextBox>
                </td>
                <td style="font-weight: bold; padding-top: 10px;">
                    Serie
                </td>
                <td style="padding-top: 10px;">
                    <div id="div_SerieNV">
                        <asp:DropDownList ID="ddlSerieNV" runat="server" Font-Names="Arial" ForeColor="Blue"
                            Font-Bold="True">
                        </asp:DropDownList>
                    </div>
                </td>
                <td style="padding-top: 10px;">
                    <asp:CheckBox ID="chkNotaVenta" runat="server" Text="Numero" Font-Bold="True" />
                </td>
                <td style="padding-top: 10px;">
                    <asp:TextBox ID="txtNumeroNotaVenta" runat="server" Width="45" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                </td>
                <td style="padding-top: 10px; padding-left: 285px;">
                    <asp:Button ID="btnBuscarNV" runat="server" Text="Buscar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                    <asp:Button ID="btnDevolverNV" runat="server" Text="Devolver" Style="display: none;"
                        class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                    <asp:Button ID="btnAgregarItemNV" runat="server" Text="Agregar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px;" colspan='9'>
                    <div id="div_DetalleNV">
                        <asp:GridView ID="grvDetalleNV" runat="server" AutoGenerateColumns="False" border="0"
                            CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="960px">
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
                                        <asp:HiddenField ID="hfCodArticulo" runat="server" Value='<%# Bind("CodProducto") %>' />
                                        <asp:HiddenField ID="hfCodUndMedida" runat="server" Value='<%# Bind("CodUndMedida") %>' />
                                        <asp:HiddenField ID="hfCodMovimiento" runat="server" Value='<%# Bind("CodMovimiento") %>' />
                                        <asp:HiddenField ID="hfSerieDoc" runat="server" Value='<%# Bind("SerieDoc") %>' />
                                        <asp:HiddenField ID="hfNumeroDoc" runat="server" Value='<%# Bind("NumeroDoc") %>' />
                                        <asp:HiddenField ID="hfCostoUnitario" runat="server" Value='<%# Bind("CostoUnitario") %>' />
                                        <asp:HiddenField ID="hfFechaAnexo" runat="server" Value='<%# Bind("FechaAnexo") %>' />
                                        <asp:HiddenField ID="hfNroRuc" runat="server" Value='<%# Bind("NroRuc") %>' />
                                        <asp:HiddenField ID="hfPrecioSinIgv" runat="server" Value='<%# Bind("PrecioSinIgv") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Numero">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblNumero" Text='<%# Bind("Numero") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Cliente" HeaderText="Cliente">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
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
                                <asp:TemplateField HeaderText="Venta">
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
                                <asp:BoundField DataField="IMPORTE" HeaderText="IMPORTE">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Acuenta">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblAcuenta" Text='<%# Bind("Acuenta") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" ID="txtCantidadEntregada" Width="55px" CssClass="ccsestilo"
                                            Style="text-align: center;" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"
                                            onblur="F_ValidarStockGrillaOC(this.id);" Enabled="False"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="divFacturacionCT" style="display: none;">
        <table cellpadding="0" cellspacing="0" width="850">
            <tr>
                <td style="padding-top: 10px;">
                    <asp:CheckBox ID="chkDesdeCT" runat="server" Text="DESDE" Font-Bold="True" Checked="True" />
                </td>
                <td style="padding-left: 2px; padding-top: 10px;">
                    <asp:TextBox ID="txtDesdeCT" runat="server" Width="55" Font-Names="Arial" ForeColor="Blue"
                        Font-Bold="True" CssClass="Jq-ui-dtp" ReadOnly="True"></asp:TextBox>
                </td>
                <td style="padding-top: 10px; padding-left: 2px; font-weight: bold">
                    HASTA
                </td>
                <td style="padding-top: 10px; padding-left: 2px;">
                    <asp:TextBox ID="txtHastaCT" runat="server" Width="55" Font-Names="Arial" ForeColor="Blue"
                        Font-Bold="True" CssClass="Jq-ui-dtp" ReadOnly="True"></asp:TextBox>
                </td>
                <td style="font-weight: bold; padding-top: 10px;">
                    Serie
                </td>
                <td style="padding-top: 10px;">
                    <div id="div_SerieCT">
                        <asp:DropDownList ID="ddlSerieCT" runat="server" Font-Names="Arial" ForeColor="Blue"
                            Font-Bold="True">
                        </asp:DropDownList>
                    </div>
                </td>
                <td style="padding-top: 10px;">
                    <asp:CheckBox ID="chkCotizacion" runat="server" Text="Numero" Font-Bold="True" />
                </td>
                <td style="padding-top: 10px;">
                </td>
                <td style="padding-top: 10px; padding-left: 285px;">
                    <asp:Button ID="btnBuscarCT" runat="server" Text="Buscar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                    <asp:Button ID="btnDevolverCT" runat="server" Text="Devolver" Style="display: none;"
                        class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                    <asp:Button ID="btnAgregarItemCT" runat="server" Text="Agregar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px;" colspan='9'>
                    <div id="div_DetalleCT">
                        <asp:GridView ID="grvDetalleCT" runat="server" AutoGenerateColumns="False" border="0"
                            CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="960px">
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
                                        <asp:HiddenField ID="hfFechaAnexo" runat="server" Value='<%# Bind("FechaAnexo") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Numero">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblNumero" Text='<%# Bind("Numero") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Cliente" HeaderText="Cliente">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
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
                                <asp:TemplateField HeaderText="Venta">
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
                                <asp:BoundField DataField="IMPORTE" HeaderText="IMPORTE">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Acuenta" Visible="false">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblAcuenta" Text='<%# Bind("Acuenta") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" ID="txtCantidadEntregada" Width="55px" CssClass="ccsestilo"
                                            Style="text-align: center;" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"
                                            onblur="F_ValidarStockGrillaOC(this.id);" Enabled="False"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
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
    <div id="div_Editar" style="display: none;">
        <table>
            <tr>
                <td style="font-weight: bold">
                    <asp:Label ID="lblTipoFacturaEdicion" runat="server" Text="" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtNroFacturaEditar" runat="server" Width="80px" ReadOnly="True"
                                    Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold">
                                Cliente
                            </td>
                            <td>
                                <asp:TextBox ID="txtClienteEditar" runat="server" Width="270px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td id="div_lblPlaca1Editar" style="font-weight: bold;">
                                Placa
                            </td>
                            <td id="div_Placa1Editar" style="padding-left: 50px;">
                                <asp:TextBox ID="txtPlaca1Editar" runat="server" Width="80px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold">
                                KM
                            </td>
                            <td>
                                <asp:TextBox ID="txtKMEdicion" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True"></asp:TextBox>
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
                    <table>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtEmisionEdicion" runat="server" Width="80px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold">
                                Forma Pago
                            </td>
                            <td>
                                <div id="div_FormaPagoEdicion">
                                    <asp:DropDownList ID="ddlFormaPagoEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True" Width="85">
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td style="font-weight: bold">
                                Vencimiento
                            </td>
                            <td>
                                <asp:TextBox ID="txtVencimientoEdicion" runat="server" Width="80px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True" CssClass="Jq-ui-dtp" Enabled="false"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold">
                                Nro Operacion
                            </td>
                            <td>
                                <asp:TextBox ID="txtNroOperacionEdicion" runat="server" Width="80px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
            Edicion de Datos de la guia
        </div>
        <div class="ui-jqdialog-content">
            <table cellpadding="0" cellspacing="0" width="750" class="form-inputs">
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chkGuiaEdicion" runat="server" Text="Guia Serie" Font-Bold="True" />
                                </td>
                                <td>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <div id="div_serieguiaEdicion">
                                                    <asp:DropDownList ID="ddlSerieGuiaEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNumeroGuiaEdicion" runat="server" Width="50" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold; padding-left: 97px;">
                                                Fecha
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFechaTrasladoEdicion" runat="server" Width="56px" CssClass="Jq-ui-dtp"
                                                    Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold;">
                                                Destino
                                            </td>
                                            <td style="padding-left: 14px;">
                                                <asp:TextBox ID="txtDestinoEdicion" runat="server" Width="455px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold">
                                    Transportista
                                </td>
                                <td>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtTransportistaEdicion" runat="server" Width="300" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold">
                                                Direccion
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDireccionTransportistaEdicion" runat="server" Width="455px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr align="right">
                    <td style="padding-top: 10px; padding-left: 100px;">
                        <asp:Button ID="btnEditarFactura" runat="server" Text="Guardar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" Width="120" />
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
    <input id="hfCodTipoCliente" type="hidden" value="2" />
    <input id="hfCodDireccion" type="hidden" value="2" />
    <input id="hfCodTipoDoc2" type="hidden" value="2" />
    <input id="hfApePaterno" type="hidden" value="CLIENTE" />
    <input id="hfNroRuc" type="hidden" value="" />
    <input id="hfDistrito" type="hidden" value="" />
    <input id="hfDireccion" type="hidden" value="" />
    <input id="hfCliente" type="hidden" value="" />
    <input id="hfCodTransportista" type="hidden" value="0" />
    <input id="hfCodDireccionTransportista" type="hidden" value="0" />
    <input id="hfCodFacturaAnterior" type="hidden" value="0" />
    <input id="hfNumeroAnterior" type="hidden" value="0" />
    <input id="hfSaldoCreditoFavor" type="hidden" value="0" />
    <input id="hfCodFacturaEdicion" type="hidden" value="0" />
    <input id="hfCodProductoAgregar" type="hidden" value="0" />
    <input id="hfMenorPrecioAgregar" type="hidden" value="0" />
    <input id="hfCostoAgregar" type="hidden" value="0" />
    <input id="hfCodUmAgregar" type="hidden" value="0" />
    <input id="hfDireccionFacturaEditar" type="hidden" value="0" />
    <input id="hfDireccionTransportista" type="hidden" value="" />
    <input id="hfCodDireccionDefecto" type="hidden" value="0" />
</asp:Content>
