<%@ Page Title="Valores de Conceptos" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="MaestroCategoriaValores.aspx.cs" Inherits="SistemaInventario.Planilla.MaestroCategoriaValores"
    EnableEventValidation="false" %>

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
    <script src="../Scripts/UtilitariosDatos.js" type="text/javascript"></script>
    <script src="UtilitariosPlanillas.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="MaestroCategoriaValores.js"
        charset="UTF-8"></script>
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/toars/toastr.min.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/toars/toastr.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo">
        Categoria</div>
    <div id="tabConsulta">
        <div id='divConsulta' style="width: 1120px" class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                Criterio de busqueda
            </div>
            <div class="ui-jqdialog-content">
                <table cellpadding="0" cellspacing="0" class="form-inputs" width="700">
                    <tr>
                        <td style="font-weight: bold">
                            Categoria
                        </td>
                        <td>
                            <div id="div1">
                                <asp:DropDownList ID="ddlCategoria" runat="server" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True" Width="354">
                                </asp:DropDownList>
                            </div>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td style="font-weight: bold">
                            Descripcion
                        </td>
                        <td>
                            <asp:TextBox ID="txtDescripcionConsulta" runat="server" Width="772" Font-Names="Arial"
                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="linea-button">
                <table>
                    <tr>
                        <td style="width: 200px">
                        </td>
                        <td style="font-weight: bold">
                            Fecha Inicial
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtFechaInicial" Width="55px" Font-Bold="true" Style="text-align: center;"
                                CssClass="ccsestilo Jq-ui-dtp" Font-Names="Arial" ForeColor="Blue" Enabled="true"></asp:TextBox>
                        </td>
                        <td style="font-weight: bold">
                            Fecha Final
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtFechaFinal" Width="55px" Font-Bold="true" Style="text-align: center;"
                                CssClass="ccsestilo Jq-ui-dtp" Font-Names="Arial" ForeColor="Blue" Enabled="true"></asp:TextBox>
                        </td>
                        <td style="width: 50px">
                        </td>
                        <td style="width: 160px">
                            <asp:Button ID="btnGenerarReintegros" runat="server" Text="Generar Reintegros" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                Font-Names="Arial" Font-Bold="True" Width="150" />
                        </td>
                        <td>
                            <asp:Button ID="btnBuscarNoAsignados" runat="server" Text="Agregar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                Font-Names="Arial" Font-Bold="True" Width="120" />
                            <asp:Button ID="btnGrabar" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                Font-Names="Arial" Font-Bold="True" Width="120" />
                            <asp:Button ID="btnBuscarConsulta" runat="server" Text="Buscar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                Font-Names="Arial" Font-Bold="True" Width="120" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="div_consulta" style="padding-top: 5px;">
            <asp:GridView ID="grvConsulta" runat="server" AutoGenerateColumns="False" border="0"
                CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="1117px">
                <Columns>
                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkOK" CssClass="chkSi" Text="" onclick="F_ValidarCheck(this.id);" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Descripcion" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="left" Width="300px" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblConcepto" Text='<%# Bind("Concepto") %>'></asp:Label>
                            <asp:HiddenField ID="hfID" runat="server" Value='<%# Bind("CodCodCategoriaValores") %>' />
                            <asp:HiddenField ID="hfCodCodCategoria" runat="server" Value='<%# Bind("CodCodCategoria") %>' />
                            <asp:HiddenField ID="hfCodConceptoRemuneracion" runat="server" Value='<%# Bind("CodConceptoRemuneracion") %>' />
                            <asp:HiddenField ID="hfValor" runat="server" Value='<%# Bind("Valor") %>' />
                            <asp:HiddenField ID="hfValor2" runat="server" Value='<%# Bind("Valor2") %>' />
                            <asp:HiddenField ID="hfObservacion" runat="server" Value='<%# Bind("Observacion") %>' />
                            <asp:HiddenField ID="hfTopeDiferencia" runat="server" Value='<%# Bind("TopeDiferencia") %>' />
                            <asp:HiddenField ID="hfFechaInicial" runat="server" Value='<%# Bind("FechaInicial") %>' />
                            <asp:HiddenField ID="hfFechaFinal" runat="server" Value='<%# Bind("FechaFinal") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" HeaderStyle-HorizontalAlign="Center">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Clasificacion" HeaderText="Clasificacion" HeaderStyle-HorizontalAlign="Center">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Valor" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtValor" Width="55px" Font-Bold="true" Style="text-align: center;"
                                CssClass="ccsestilo" Font-Names="Arial" ForeColor="Blue" Text='<%# Bind("Valor") %>'
                                Enabled="false"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor2" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtValor2" Width="55px" Font-Bold="true" Style="text-align: center;"
                                CssClass="ccsestilo" Font-Names="Arial" ForeColor="Blue" Text='<%# Bind("Valor2") %>'
                                Enabled="false"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Desde" ItemStyle-HorizontalAlign="Center" Visible="false">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtFechaInicial" Width="55px" Font-Bold="true" Style="text-align: center;"
                                CssClass="ccsestilo Jq-ui-dtp" Font-Names="Arial" ForeColor="Blue" Text='<%# Bind("FechaInicial") %>'
                                Enabled="false"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Hasta" ItemStyle-HorizontalAlign="Center" Visible="false">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtFechaFinal" Width="55px" Font-Bold="true" Style="text-align: center;"
                                CssClass="ccsestilo Jq-ui-dtp" Font-Names="Arial" ForeColor="Blue" Text='<%# Bind("FechaFinal") %>'
                                Enabled="false"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Observacion" ItemStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="left" Width="300px" />
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtObservacion" Width="300px" Font-Bold="true" Style="text-align: left;"
                                CssClass="ccsestilo" Font-Names="Arial" ForeColor="Blue" Text='<%# Bind("Observacion") %>'
                                Enabled="false"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Diferencia Comparaciones" ItemStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="left" Width="100px" />
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtTopeDiferencia" Width="90px" Font-Bold="true"
                                Style="text-align: center;" CssClass="ccsestilo" Font-Names="Arial" ForeColor="Blue"
                                Text='<%# Bind("TopeDiferencia") %>' Enabled="false"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div id="div_AgregarConcepto" style="display: none;">
        <div>
            <div id="div_TableConceptosNoAsignados" class="ui-jqdialog-content">
                <asp:GridView ID="grvConceptosNoAsignados" runat="server" AutoGenerateColumns="False"
                    border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                    Width="500px">
                    <Columns>
                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkOK" CssClass="chkSi" Text="" onclick="F_ValidarCheck(this.id);" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Descripcion" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblConcepto" Text='<%# Bind("Concepto") %>'></asp:Label>
                                <asp:HiddenField ID="hfID" runat="server" Value='<%# Bind("CodConceptoRemuneracion") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Tipo" HeaderText="Tipo" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Clasificacion" HeaderText="Clasificacion" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="linea-button">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                    Font-Names="Arial" Font-Bold="True" Width="120px" />
            </div>
        </div>
    </div>
    <div id="div_Reintegros" style="display: none;">
        <table cellpadding="0" cellspacing="0" width="850">
            <tr>
                <td align="right" style="padding-top: 10px;">
                    <asp:Button ID="btnDevolverGuia" runat="server" Text="Devolver" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" ForeColor="Blue" Font-Bold="True" Visible="false" />
                    <asp:Button ID="btnRecalcularReintegros" runat="server" Text="Recalcular Reintegros"
                        class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" ForeColor="Blue" Font-Bold="True" />
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px;">
                    <div id="div_GrillaReintegros">
                        <asp:GridView ID="grvReintegros" runat="server" AutoGenerateColumns="False" border="0"
                            CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="860px">
                            <Columns>
                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chkEliminar" CssClass="chkDelete" Text="" onclick="F_ValidarCheck_OC(this.id);" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="categoria">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblcategoria" Text='<%# Bind("Categoria") %>'></asp:Label>
                                        <asp:HiddenField ID="hfIDExcel" runat="server" Value='<%# Bind("IDExcel") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Año">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblAño" Text='<%# Bind("Año") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sem">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblSemana" Text='<%# Bind("NroSemana") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="F. Ini">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblFechaInicial" Text='<%# Bind("FechaInicial") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="F. Fin">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblFechaFinal" Text='<%# Bind("FechaFinal") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Pagos">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblTotalPagos" Text='<%# Bind("TotalPago") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Reintegros">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblTotalReintegros" Text='<%# Bind("TotalPagoReintegro") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="FechaReintegro" HeaderText="Fecha Reintegro" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UsuarioReintegro" HeaderText="Usuario Reintegro" HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Nro. Boletas">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblNroBoletas" Text='<%# Bind("Boletas") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
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
    <input id="hfCodigo" type="hidden" value="0" />
</asp:Content>
