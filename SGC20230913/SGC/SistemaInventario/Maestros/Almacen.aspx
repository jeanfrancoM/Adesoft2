<%@ Page Title="Almacen" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Almacen.aspx.cs" Inherits="SistemaInventario.Maestros.Almacen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"
        type="text/javascript"></script>
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
  
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript"
        charset="UTF-8"></script>
    <script type="text/javascript" language="javascript" src="Almacen.js" charset="UTF-8"></script>
    <link href="../Asset/css/redmond/jquery-ui-1.10.4.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
  <link href="../Asset/toars/toastr.min.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/toars/toastr.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo">
        Almacen</div>
    <div id="divTabs">
        <ul>
            <li id="liRegistro"><a href="#tabRegistro">Registro</a></li>
            <li id="liConsulta"><a href="#tabConsulta" onclick="getContentTab();">Consulta</a></li>
        </ul>
        <div id="tabRegistro">
            <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 460px">
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    REGISTRO DE Almacen
                </div>
                <div>
                    <table cellpadding="0" cellspacing="0" class="form-inputs">
                        <tr>
                            <td style="font-weight: bold">
                                EMPRESA
                            </td>
                            <td>
                                <div id="div_Empresa">
                                    <asp:DropDownList ID="ddlEmpresa" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True" Width="354">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
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
                                Direccion
                            </td>
                            <td style="font-weight: bold">
                                <asp:TextBox ID="txtDireccion" runat="server" Width="350px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                          <tr>
                            <td style="font-weight: bold">
                                Distrito
                            </td>
                              <td colspan='5'>
                                  <table cellpadding="0" cellspacing="0">
                                      <tr>
                                          <td >
                                              <asp:TextBox ID="txtDistrito" runat="server" Width="347px" Font-Names="Arial" ForeColor="Blue"
                                                  Font-Bold="True"></asp:TextBox>
                                          </td>
                                      </tr>
                                  </table>
                              </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Principal
                            </td>
                            <td>
                                <div >
                                    <asp:CheckBox ID="chkPrincipal" runat="server" Text="" Font-Bold="True" />
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
                       <tr>
                            <td style="font-weight: bold">
                                Telefono
                            </td>
                            <td style="font-weight: bold">
                                <asp:TextBox ID="txtTelefono" runat="server" Width="350px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
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
                            <td style="display: none; font-weight: bold">
                                EMPRESA
                            </td>
                            <td>
                                <div id="div_EmpresaConsulta">
                                    <asp:DropDownList ID="ddlEmpresaConsulta" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True" Width="200">
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td style="font-weight: bold">
                                Descripcion
                            </td>
                            <td>
                                <asp:TextBox ID="txtDescripcionConsulta" runat="server" Width="500" Font-Names="Arial"
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
                    CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="1017px">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                    ToolTip="ELIMINAR ALMACEN" OnClientClick="F_EliminarRegistro(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgEditarRegistro" ImageUrl="../Asset/images/btnEdit.gif"
                                    ToolTip="EDITAR ALMACEN" OnClientClick="F_EditarRegistro(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="descripcion" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                             <asp:Label runat="server" ID="lblDscAlmacen" Text='<%# Bind("DscAlmacen") %>' CssClass="detallesart"></asp:Label>
                                <asp:HiddenField runat="server" ID="hfCodAlmacen" value='<%# Bind("CodAlmacen") %>'/>
                                <asp:HiddenField ID="hfEmpresa" runat="server" Value='<%# Bind("Empresa") %>' />
                                <asp:HiddenField ID="hfCodEmpresa" runat="server" Value='<%# Bind("CodEmpresa") %>' />
                                <asp:HiddenField ID="hfCodEstado" runat="server" Value='<%# Bind("CodEstado") %>' />
                                <asp:HiddenField ID="hfCodDepartamento" runat="server" Value='<%# Bind("CodDepartamento") %>' />
                                <asp:HiddenField ID="hfCodDistrito" runat="server" Value='<%# Bind("CodDistrito") %>' />
                                <asp:HiddenField ID="hfCodProvincia" runat="server" Value='<%# Bind("CodProvincia") %>' />
                                <asp:HiddenField ID="hfPrincipal" runat="server" Value='<%# Bind("FlagPrincipal") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Direccion" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDireccion" Text='<%# Bind("Direccion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Distrito" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDistrito" Text='<%# Bind("Distrito") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Telefono">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblTelefono" Text='<%# Bind("Telefono") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Estado" HeaderText="Estado">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Principal" >
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgPrincipal" ImageUrl="../Asset/images/Circle_Green.png"
                                            ToolTip="Activar/Desactivar" OnClientClick="return false;" />
                                    </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <div id="divEdicionRegistro" style="display: none;" >
        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                DATOS ALMACEN
            </div>
            <div class="ui-jqdialog-content">
                <table cellpadding="0" cellspacing="0" class="form-inputs" width="800">
                    <tr>
                        <td style="font-weight: bold">
                            EMPRESA
                        </td>
                        <td colspan='3'>
                            <div id="div_EmpresaEdicion">
                                <asp:DropDownList ID="ddlEmpresaEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True" Width="405" Enabled="false">
                                </asp:DropDownList>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold">
                            Descripcion
                        </td>
                        <td>
                            <asp:TextBox ID="txtDescripcionEdicion" runat="server" Width="402" Font-Names="Arial"
                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 5px; font-weight: bold">
                            Direccion
                        </td>
                        <td  colspan='3'>
                            <asp:TextBox ID="txtDireccionEdicion" runat="server" Width="402" Font-Names="Arial" ForeColor="Blue"
                                Font-Bold="True" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 10px; font-weight: bold">
                            Distrito
                        </td>
                        <td  colspan='3'>
                            <asp:TextBox ID="txtDistritoEdicion" runat="server" Width="402" Font-Names="Arial" ForeColor="Blue"
                                Font-Bold="True" ></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold">
                            PRINCIPAL
                        </td>
                        <td colspan='3'>
                            <div id="div1">
                                <asp:CheckBox ID="chkPrincipalEdicion" runat="server" Text="" Font-Bold="True"  />
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
                                    Font-Bold="True" Width="405">
                                </asp:DropDownList>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold">
                            Telefono
                        </td>
                        <td colspan='3'>
                            <asp:TextBox ID="txtTelefonoEdicion" runat="server" Width="402" Font-Names="Arial"
                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
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
        <br />
        <br />
        <center>
            <img alt="Wait..." src="../Asset/images/ajax-loader2.gif" /></center>
    </div>
    <input id="hfCodDepartemento" type="hidden" value="0" />
    <input id="hfCodProvincia" type="hidden" value="0" />
    <input id="hfCodDistrito" type="hidden" value="0" />
    <input id="hfCodDepartamentoEdicion" type="hidden" value="0" />
    <input id="hfCodProvinciaEdicion" type="hidden" value="0" />
    <input id="hfCodDistritoEdicion" type="hidden" value="0" />
    <input id="hfCodAlmacen" type="hidden" value="0" />
</asp:Content>
