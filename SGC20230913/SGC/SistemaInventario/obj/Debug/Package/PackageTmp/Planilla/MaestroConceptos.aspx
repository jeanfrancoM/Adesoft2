<%@ Page Title="Conceptos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="MaestroConceptos.aspx.cs" Inherits="SistemaInventario.Planilla.MaestroConceptos"
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
    <script type="text/javascript" language="javascript" src="MaestroConceptos.js" charset="UTF-8"></script>
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/toars/toastr.min.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/toars/toastr.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo">
        Concepto</div>
    <div id="divTabs">
        <ul>
            <li id="liRegistro"><a href="#tabRegistro">Registro</a></li>
            <li id="liConsulta"><a href="#tabConsulta">Consulta</a></li>
        </ul>
        <div id="tabRegistro">
            <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 460px">
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    REGISTRO DE Concepto
                </div>
                <div>
                    <table cellpadding="0" cellspacing="0" class="form-inputs">
                        <tr>
                            <td style="font-weight: bold">
                                Descripcion
                            </td>
                            <td>
                                <asp:TextBox ID="txtDescripcion" runat="server" Width="350px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Ordenamiento
                            </td>
                            <td>
                                <asp:TextBox ID="txtOrden" runat="server" Width="350px" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Tipo
                            </td>
                            <td>
                                <div id="div1">
                                    <asp:DropDownList ID="ddlTipo" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True" Width="354">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Clasificacion
                            </td>
                            <td>
                                <div id="div3">
                                    <asp:DropDownList ID="ddlClasificacion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True" Width="354">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Regimen Laboral
                            </td>
                            <td>
                                <div id="div5">
                                    <asp:DropDownList ID="ddlRegimenLaboral" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True" Width="354">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Estado
                            </td>
                            <td>
                                <div id="div_Estado">
                                    <asp:DropDownList ID="ddlEstado" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True" Width="354">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="linea-button">
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120px" />
                    <asp:Button ID="btnGrabar" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120px" />
                </div>
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
                    <asp:Button ID="btnBuscarConsulta" runat="server" Text="Buscar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                </div>
            </div>
            <div id="div_consulta" style="padding-top: 5px;">
                <asp:GridView ID="grvConsulta" runat="server" AutoGenerateColumns="False" border="0"
                    CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="1017px">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                    ToolTip="ELIMINAR Concepto" OnClientClick="F_EliminarRegistro(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgEditarRegistro" ImageUrl="../Asset/images/btnEdit.gif"
                                    ToolTip="EDITAR Concepto" OnClientClick="F_EditarRegistro(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="RegimenLaboral" HeaderText="Regimen Laboral">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Descripcion" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDescripcion" Text='<%# Bind("Descripcion") %>'></asp:Label>
                                <asp:HiddenField ID="hfID" runat="server" Value='<%# Bind("CodConceptoRemuneracion") %>' />
                                <asp:HiddenField ID="hfCodEstado" runat="server" Value='<%# Bind("CodEstado") %>' />
                                <asp:HiddenField ID="hfCodRegimenLaboral" runat="server" Value='<%# Bind("CodRegimenLaboral") %>' />
                                <asp:HiddenField ID="hfCodTipo" runat="server" Value='<%# Bind("CodTipo") %>' />
                                <asp:HiddenField ID="hfOrden" runat="server" Value='<%# Bind("Orden") %>' />
                                <asp:HiddenField ID="hfCodConceptoRemuneracion_Referencia" runat="server" Value='<%# Bind("CodConceptoRemuneracion_Referencia") %>' />
                                <asp:HiddenField ID="hfCodClasificacion" runat="server" Value='<%# Bind("CodClasificacion") %>' />
                                <asp:HiddenField ID="hfClasificacion" runat="server" Value='<%# Bind("Clasificacion") %>' />
                                <asp:HiddenField ID="hfCodNaturaleza" runat="server" Value='<%# Bind("CodNaturaleza") %>' />
                                <asp:HiddenField ID="hfOrden2" runat="server" Value='<%# Bind("Orden2") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tipo" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblTipo" Text='<%# Bind("Tipo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Estado" HeaderText="Estado">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <div id="divEdicionRegistro" style="display: none;">
        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                DATOS LINEA
            </div>
            <div class="ui-jqdialog-content">
                <table cellpadding="0" cellspacing="0" class="form-inputs" width="700">
                    <tr>
                        <td style="font-weight: bold">
                            Descripcion
                        </td>
                        <td>
                            <asp:TextBox ID="txtDescripcionEdicion" runat="server" Width="250" Font-Names="Arial"
                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold">
                            Ordenamiento
                        </td>
                        <td>
                            <asp:TextBox ID="txtOrdenEdicion" runat="server" Width="350px" Font-Names="Arial"
                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold">
                            Tipo
                        </td>
                        <td colspan='3'>
                            <div id="div2">
                                <asp:DropDownList ID="ddlTipoEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True" Width="403">
                                </asp:DropDownList>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold">
                            Clasificacion
                        </td>
                        <td colspan='3'>
                            <div id="div4">
                                <asp:DropDownList ID="ddlClasificacionEdicion" runat="server" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True" Width="403">
                                </asp:DropDownList>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold">
                            Regimen Laboral
                        </td>
                        <td>
                            <div id="div6">
                                <asp:DropDownList ID="ddlRegimenLaboralEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True" Width="354">
                                </asp:DropDownList>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold">
                            ESTADO
                        </td>
                        <td colspan='3'>
                            <div id="div_EstadoEdicion">
                                <asp:DropDownList ID="ddlEstadoEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True" Width="403">
                                </asp:DropDownList>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="linea-button">
                <asp:Button ID="btnEdicion" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                    Font-Names="Arial" Font-Bold="True" Width="120px" />
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
    <input id="hfCodigo" type="hidden" value="0" />
</asp:Content>
