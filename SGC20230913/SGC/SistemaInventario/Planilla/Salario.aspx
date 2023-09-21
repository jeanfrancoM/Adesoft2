<%@ Page Title="Salario" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Salario.aspx.cs" EnableEventValidation="false" Inherits="SistemaInventario.Planilla.Salario" %>
        
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"  type="text/javascript"></script>      
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript" charset="UTF-8"></script>       
    <script type="text/javascript" language="javascript" src="Salario.js" charset="UTF-8"></script>
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"   type="text/css" />     
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/toars/toastr.min.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/toars/toastr.min.js" type="text/javascript"></script>
    <script src="../Asset/js/moment.js" type="text/javascript"></script>
    <script src="UtilitariosPlanillas.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class='overlay'>
        <div class="titulo">
            Planilla</div>
        <div id="divTabs">
            <div id="tabRegistro">
                <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
                    <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                        Datos de la Planilla
                    </div>
                    <div>
                        <table cellpadding="0" cellspacing="0" class="form-inputs" width="750">
                            <tr>
                                <td style="font-weight: bold; width=200px">
                                    FECHA ACTUAL
                                </td>
                                <td style="width=500px">
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtFechaHoraDisplayCobranza" runat="server" Width="120" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True" Style="text-align: center;" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold; padding-left: 19px;">
                                                SEMANA ACTUAL
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtAñoSemanaActual" runat="server" Width="50px" Font-Names="Arial"
                                                    ForeColor="Blue" Enabled="False" Font-Bold="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold">
                                    Proyecto
                                </td>
                                <td>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <div id="div_proyecto">
                                                    <asp:DropDownList ID="ddlProyecto" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True" Width="290">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold">
                                    Regimen Laboral
                                </td>
                                <td>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <div id="div_regimenlaboral">
                                                    <asp:DropDownList ID="ddlRegimenLaboral" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True" Width="290" Enabled=false>
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold">
                                    Semana de la Nomina
                                </td>
                                <td>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtAñoSemana" runat="server" Width="100px" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Size="18" Font-Bold="True"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDisplaySemana" runat="server" Text="" Font-Bold="true" Font-Size="Small"></asp:Label>
                                            </td>
                                            <td style="display: none">
                                                <asp:Label runat="server" ID="lblCodSemana"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
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
                                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                                                <asp:HiddenField ID="HiddenField1" runat="server"/>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
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
            </div>
        </div>
        <div style="padding-top: 5px;">
            <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix"
                    style="width: 1000px">
                    Inconvenientes
                </div>
                <div id="div_grvDetalleArticulo" style="padding-top: 5px;">
                    <asp:GridView ID="grvDetalleArticulo" runat="server" AutoGenerateColumns="False"
                        border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                        Width="1000px" OnRowDataBound="grvDetalleArticulo_RowDataBound2">
                        <Columns>
                            <asp:TemplateField HeaderText="Linea">
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblLinea" Text='<%# Bind("Linea") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DNI">
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblDNI" Text='<%# Bind("DNI") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ERROR">
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblError" Text='<%# Bind("DESCRIPCION_ERROR") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
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
