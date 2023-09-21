<%@ Page Title="Consulta Salarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SalarioConsultas.aspx.cs" EnableEventValidation="false" Inherits="SistemaInventario.Planilla.SalarioConsultas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"
        type="text/javascript"></script>
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript"
        charset="UTF-8"></script>
    <script type="text/javascript" language="javascript" src="SalarioConsultas.js" charset="UTF-8"></script>
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/toars/toastr.min.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/toars/toastr.min.js" type="text/javascript"></script>
    <script src="../Asset/js/moment.js" type="text/javascript"></script>
    <script src="UtilitariosPlanillas.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class='overlay'>
        <div class="titulo">
            Consulta de Planilla</div>
        <div id="tabConsulta" style="width: 1100px">
            <div id='divConsulta' class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    Criterio de busqueda
                </div>
                <div class="ui-jqdialog-content" style="width: 1000px">
                    <table cellpadding="0" cellspacing="0" class="form-inputs" style="width: 1000px">
                        <tbody>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" class="form-inputs" style="width: 1000px">
                                        <tr>
                                            <td style="font-weight: bold">
                                                Proyecto
                                            </td>
                                            <td>
                                                <div id="div_proyecto">
                                                    <asp:DropDownList ID="ddlProyecto" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True" Width="290">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td style="font-weight: bold">
                                                Regimen Laboral
                                            </td>
                                            <td>
                                                <div id="div_regimenlaboral">
                                                    <asp:DropDownList ID="ddlRegimenLaboral" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True" Width="290" Enabled=false>
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td style="font-weight: bold">
                                                Semana de la Nomina
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtAñoSemana" runat="server" Width="50px" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True"></asp:TextBox>
                                            </td>
                                            <td style="display: none">
                                                <asp:Label runat="server" ID="lblCodSemana"></asp:Label>
                                                <label id="lblDisplaySemana" style="font-size=14; font-weight=">
                                                </label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" class="form-inputs" style="width: 1000px">
                                        <tr>
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
                                                <asp:CheckBox ID="chkTrabajador" runat="server" Text="Trabajador" Font-Bold="True" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTrabajador" runat="server" Width="535" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True"></asp:TextBox>
                                            </td>
                                        </tr>

                                    </table>
                                </td>
                            </tr>
                            <tr>                               
                                <td>
                                     <table cellpadding="0" cellspacing="0" >
                                        <tr>    
                                            <td style="font-weight: bold; width:66px">
                                                &nbsp &nbsp Estado
                                            </td>                                                 
                                            <td>                                                
                                                <asp:DropDownList ID="ddlEstado" runat="server" Width="145px" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" ReadOnly="True"></asp:DropDownList>
                                            </td>                                              
                                            <td>
                                                <asp:ImageButton ImageUrl="../Asset/images/EliminarBtn.png" ID="imgEliminarCarga" runat="server" ToolTip="ELIMINAR CARGA DE EXCEL"/>
                                            </td>                                            
                                                                                      
                                        </tr>
                                    </table>
                                </td>
                                
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="linea-button">
                 <asp:Button ID="btnVerPDF" runat="server" Text="Ver PDF" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                                Font-Names="Arial" Font-Bold="True" Width="120" />
                    <asp:Button ID="btnVerPDFReintegro" runat="server" Text="Ver PDF Reintegro" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                                Font-Names="Arial" Font-Bold="True" Width="120" />
                    <asp:Button ID="btnBuscarConsulta" runat="server" Text="Buscar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                </div>
            </div>
        </div>
        <div id="div_consulta" style="padding-top: 5px;">
            <asp:GridView ID="grvConsulta" runat="server" AutoGenerateColumns="False" border="0"
                CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="1000px"
                OnRowDataBound="grvConsulta_RowDataBound">
                <Columns>
                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="ChkAll" runat="server" onclick='F_CheckAll(this);'/>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkPdf" CssClass="chkItem" Text="" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>                    
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="imgPdf2" ImageUrl="~/Asset/images/pdf.png" ToolTip="Generar Version PDF"
                                OnClientClick="F_ImprimirDocumento(this.id, 0); return false;" />
                            <asp:ImageButton runat="server" ID="imgPdf3" ImageUrl="~/Asset/images/pdf.png" ToolTip="Reintegro Version PDF"
                                OnClientClick="F_ImprimirDocumento(this.id, 1); return false;" />
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
                                        <asp:BoundField DataField="Tipo" HeaderText="Tipo">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Concepto" HeaderText="Concepto">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Valor" HeaderText="Valor">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha">
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblFecha" CssClass="detallesart" Text='<%# Bind("Fecha") %>'></asp:Label>
                            <asp:HiddenField ID="hfIDExcel" runat="server" Value='<%# Bind("IDExcel") %>' />
                            <asp:HiddenField ID="hfCodRegimenLaboral" runat="server" Value='<%# Bind("CodRegimenLaboral") %>' />
                            <asp:HiddenField ID="hfCodCategoria" runat="server" Value='<%# Bind("CodCategoria") %>' />
                            <asp:HiddenField ID="hfCodProyecto" runat="server" Value='<%# Bind("CodProyecto") %>' />
                            <asp:HiddenField ID="hfCodSemana" runat="server" Value='<%# Bind("CodSemana") %>' />
                            <asp:HiddenField ID="hfCodTrabajador" runat="server" Value='<%# Bind("CodTrabajador") %>' />
                            <asp:HiddenField ID="hfCodEstado" runat="server" Value='<%# Bind("CodEstado") %>' />
                            <asp:HiddenField ID="hfDetalleCargado" runat="server" Value='0' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="AñoSemana" HeaderText="Semana">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="RegimenLaboral" HeaderText="Regimen Laboral">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Categoria" HeaderText="Categoria">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Proyecto" HeaderText="Proyecto">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Estado">
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblEstado" Text='<%# Bind("Estado") %>'></asp:Label>                            
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
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
