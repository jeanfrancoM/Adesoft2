<%@ Page Title="Facturador Sunat" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ConsultaDocumentos.aspx.cs" Inherits="SistemaInventario.Facturador.ConsultaDocumentos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"
        type="text/javascript"></script>
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/alertify.min.js" type="text/javascript"></script>
    <%--<script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript"
        charset="UTF-8"></script>--%>
    <script type="text/javascript" language="javascript" src="ConsultaDocumentos.js"
        charset="UTF-8"></script>
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.core.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="divTabs">
        <ul>
            <li id="liConsulta"><a href="#tabConsulta">Consulta</a></li>
        </ul>
        <div id="tabConsulta">
            <div id='divConsulta' class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    Criterio de busqueda
                </div>
                <div class="ui-jqdialog-content">
                    <table cellpadding="0" cellspacing="0" class="form-inputs" width="1200">
                        <tr>
                            <td style="font-weight: bold">
                                Tipo de Cliente
                            </td>
                            <td style="padding-left: 4px;">
                                <div id="div_Empresa">
                                    <asp:DropDownList ID="ddlEmpresa" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True">
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td style="font-weight: bold">
                                Serie
                            </td>
                            <td style="width: 55px">
                                <asp:TextBox ID="txtSerie" runat="server" Width="55px" Font-Names="Arial"
                                    ForeColor="Blue"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold">
                                Desde
                            </td>
                            <td style="width: 55px">
                                <asp:TextBox ID="txtDesde" runat="server" Width="55px" Font-Names="Arial" CssClass="Jq-ui-dtp"
                                    ReadOnly="true" ForeColor="Blue"></asp:TextBox>
                            </td>
                            <td style="padding-left: 5px; font-weight: bold">
                                Hasta
                            </td>
                            <td>
                                <asp:TextBox ID="txtHasta" runat="server" Width="55px" Font-Names="Arial" CssClass="Jq-ui-dtp"
                                    ReadOnly="true" ForeColor="Blue"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold">
                                Tipo Documento
                            </td>
                            <td style="padding-left: 4px;">
                                <div id="div_TipoDocumento">
                                    <asp:DropDownList ID="ddlTipoDocumento" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True">
                                        <asp:ListItem Value="">Todos</asp:ListItem>
                                        <asp:ListItem Value="01">Facturas</asp:ListItem>
                                        <asp:ListItem Value="03">Boletas</asp:ListItem>
                                        <asp:ListItem Value="07">Notas de Credito</asp:ListItem>
                                        <asp:ListItem Value="08">Notas de Debito</asp:ListItem>
                                        <asp:ListItem Value="09">Guias de Remision</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>

                            <td style="font-weight: bold">
                                
                            </td>

                        </tr>
                    </table>
                </div>
                <div class="linea-button">
                    <label id="Label1">Cantidad Registros:</label>
                    <label id="lblCantidadRegistros" style="padding-right:20px"></label>
                    <label id="Label3">ACEPTADOS:</label>
                    <label id="lblCantidadAceptados" style="padding-right:20px"></label>
                    <label id="Label4">NO ACEPTADOS:</label>
                    <label id="lblCantidadNoAceptados" style="padding-right:20px"></label>
                    <label id="Label5">BAJAS:</label>
                    <label id="lblCantidadBajas" style="padding-right:20px"></label>
                    <asp:Button ID="btnBuscarConsulta" runat="server" Text="Buscar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                </div>
            </div>
            <div id="div_consulta" style="padding-top: 5px;">
                <asp:GridView ID="grvConsulta" runat="server" AutoGenerateColumns="False" border="0"
                    CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="1150px"
                    OnRowDataBound="grvConsulta_RowDataBound"
                    
                    >
                    <Columns>
                        <asp:TemplateField HeaderText="ID" HeaderStyle-Width="15px">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblID" Text='<%# Bind("CodArchivoSunatXML") %>'></asp:Label>
                                <asp:HiddenField ID="hfCodDocumentoOrigen" runat="server" Value='<%# Bind("CodDocumentoOrigen") %>' />
                                <asp:HiddenField ID="hfFechaRegistro" runat="server" Value='<%# Bind("FechaRegistro") %>' />
                                <asp:HiddenField ID="hfENVIO_NroTicket" runat="server" Value='<%# Bind("ENVIO_NroTicket") %>' />
                                <asp:HiddenField ID="hfCliente" runat="server" Value='<%# Bind("Cliente") %>' />
                                <asp:HiddenField ID="hfMensajeSunat" runat="server" Value='<%# Bind("MensajeSunat") %>' />
                                <asp:HiddenField ID="hfNumero" runat="server" Value='<%# Bind("Numero") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="EstadoProceso" HeaderText="Estado" HeaderStyle-Width="100px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RucEmpresa" HeaderText="Ruc Emp" HeaderStyle-Width="70px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Doc" HeaderText="T Doc" HeaderStyle-Width="40px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Serie" HeaderText="Serie" HeaderStyle-Width="40px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Numero" HeaderText="Numero" HeaderStyle-Width="50px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FechaDocumento" HeaderText="Emision" HeaderStyle-Width="50px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NroDocumentoCliente" HeaderText="Ruc Cli" HeaderStyle-Width="70px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Total" HeaderText="Total" HeaderStyle-Width="50px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EstadoDocumento" HeaderText="Estado" HeaderStyle-Width="50px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Respuesta" HeaderStyle-Width="100px">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblRespuesta" Text='<%# Bind("RespuestaSunat") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Baja">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblRespuestaBaja" Text='<%# Bind("RespuestaBaja") %>'></asp:Label>
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
    <input id="hfCodCtaCte" type="hidden" value="0" />
    <input id="hfRegion" type="hidden" value="0" />
    <input id="hfProvincia" type="hidden" value="0" />
    <input id="hfDistrito" type="hidden" value="0" />
    <input id="hfRegionEdicion" type="hidden" value="0" />
    <input id="hfProvinciaEdicion" type="hidden" value="0" />
    <input id="hfDistritoEdicion" type="hidden" value="0" />
    <input id="hfMoneda" type="hidden" value="0" />
    <input id="hfCodDireccion" type="hidden" value="0" />
    <input id="hfCodContacto" type="hidden" value="0" />
</asp:Content>
