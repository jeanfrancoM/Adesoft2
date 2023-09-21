<%@ Page Title="Componentes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VehiculoComponentes.aspx.cs" Inherits="SistemaInventario.Maestros.VehiculoComponentes" enableEventValidation="false"   %>
   
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"  type="text/javascript"></script>      
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>    
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript" charset="UTF-8"></script>
    <script type="text/javascript" language="javascript" src="VehiculoComponentes.js" charset="UTF-8"></script>
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet" type="text/css" />       
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
      <link href="../Asset/toars/toastr.min.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/toars/toastr.min.js" type="text/javascript"></script>
    <script src="../Scripts/inputatajos/kibo.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo">
        COMPONENTES DE VEHICULO</div>
    <div id="divTabs">
        <ul>
            <li id="liRegistro"><a href="#tabRegistro">Registro</a></li>
            <li id="liConsulta"><a href="#tabConsulta" onclick="getContentTab();">Consulta</a></li>
        </ul>
        <div id="tabRegistro">
            <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 600px">
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    REGISTRO DE COMPONENTES
                </div>

                <div>
                    <table cellpadding="0" cellspacing="0" class="form-inputs">

                          <tr>
                          <td style="font-weight: bold">
                          Tipo Componente
                            </td>
                            
                            <td>
                            <table cellpadding="0" cellspacing="0">
                            <tr>
                             
                               <td>
                                            <div id="div_TipoComponente">
                                                <asp:DropDownList ID="ddlTipoComponente" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="150" BackColor="#FFFF99">
                                                </asp:DropDownList>
                                            </div>
                                </td>

                                <td style="font-weight: bold; padding-left: 6px;">
                                 Tipo Vehiculo
                            </td>

                               <td  style="padding-left: 5px;">
                                            <div id="div_TipoVehiculo">
                                                <asp:DropDownList ID="ddlTipoVehiculo" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="145" BackColor="#FFFF99">
                                                </asp:DropDownList>
                                            </div>
                                </td>

                            </tr>
                            </table>
                            </td>
                        </tr>
                          <tr>
                             <td style="font-weight: bold; padding-left: 6px;">
                                 Descripcion
                            </td>

                            <td>
                            <table cellpadding="0" cellspacing="0">
                            <tr>
                             
                              <td>
                                            <asp:TextBox ID="txtDescripcion" mode="multiline" runat="server" Width="384px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                               

                            </tr>
                            </table>
                            </td>
                           
                        </tr>
                          <tr>

                             <td style="font-weight: bold; padding-left: 6px;">
                                 Cantidad
                            </td>

                            
                            <td>
                            <table cellpadding="0" cellspacing="0">
                            <tr>
                             
                             
                              <td>
                                            <asp:TextBox ID="txtCantidad" mode="multiline" runat="server" Width="145px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>





                                <td style="font-weight: bold;padding-left: 8px;">
                                       Estado
                              </td    >
                                <td  style="padding-left: 40px;">
                                            <div id="div_Estado">
                                                <asp:DropDownList ID="ddlEstado" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="146" BackColor="#FFFF99">
                                                </asp:DropDownList>
                                            </div>
                                </td>

                            </tr>
                            </table>
                            </td>
                           
                        </tr>

                    </table>
                </div>

                <div class="linea-button">
                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120px" />
                   <asp:Button ID="btnNuevo" runat="server" Text="Limpiar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
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
                


                <table cellpadding="0" cellspacing="0" class="form-inputs">

                          <tr>
                            <td style="font-weight: bold">
                          Tipo Componente
                            </td>
                            
                            <td>
                            <table cellpadding="0" cellspacing="0">
                            <tr>
                             
                               <td>
                                            <div id="div_TipoComponenteConsulta">
                                                <asp:DropDownList ID="ddlTipoComponenteConsulta" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="150" BackColor="#FFFF99">
                                                </asp:DropDownList>
                                            </div>
                                </td>

                                <td style="font-weight: bold; padding-left: 6px;">
                                   Tipo Vehiculo
                               </td>

                               <td  style="padding-left: 5px;">
                                          <div id="div_TipoVehiculoConsulta">
                                                <asp:DropDownList ID="ddlTipoVehiculoConsulta" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="150" BackColor="#FFFF99">
                                                </asp:DropDownList>
                                            </div>
                                </td>


                                <td style="font-weight: bold; padding-left: 6px;">
                                 Descripcion
                               </td>
                               
                                <td>
                                  <asp:TextBox ID="txtDescripcionConsulta" mode="multiline" runat="server" Width="250px" Font-Names="Arial" ForeColor="Blue"
                                      Font-Bold="True"></asp:TextBox>
                                  </td>

                                     <td style="font-weight: bold; padding-left: 6px;">
                                   Estado
                               </td>

                               <td  style="padding-left: 5px;">
                                          <div id="div_EstadoConsulta">
                                                <asp:DropDownList ID="ddlEstadoConsulta" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="150" BackColor="#FFFF99">
                                                </asp:DropDownList>
                                            </div>
                                </td>


                            </tr>





                            </table>
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
                                            <label id="lblNumeroConsulta" text="0">0</label>
                                        </td>                                
                                    </tr>
                                </table>
            </div>
            <div id="div_consulta" style="padding-top: 5px;">
                <asp:GridView ID="grvConsulta" runat="server" AutoGenerateColumns="False" border="0"
                    CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="1017px"  OnRowDataBound="grvConsulta_RowDataBound"    >
                    <Columns>

                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                    ToolTip="ELIMINAR" OnClientClick="F_AnularRegistro(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgEditarRegistro" ImageUrl="../Asset/images/btnEdit.gif"
                                    ToolTip="EDITAR" OnClientClick="F_EditarRegistro(this); return false;" />
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

                          <%-- 
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
                        </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="Cliente" HeaderStyle-Width="300px">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDescripcion" Text='<%# Bind("Descripcion") %>' CssClass="detallesart"></asp:Label>
                                <asp:HiddenField ID="hfCodTipoComponente" runat="server" Value='<%# Bind("CodTipoComponente") %>' />
                                <asp:HiddenField ID="hfDescripcion" runat="server" Value='<%# Bind("Descripcion") %>' />
                                <asp:HiddenField ID="hfCantidad" runat="server" Value='<%# Bind("Cantidad") %>' />
                                <asp:HiddenField ID="hfEstado" runat="server" Value='<%# Bind("Estado") %>' />
                                <asp:HiddenField ID="hfTipoVehiculo" runat="server" Value='<%# Bind("TipoVehiculo") %>' />
                                <asp:HiddenField ID="hfTipoConcepto" runat="server" Value='<%# Bind("TipoConcepto") %>' />
                                <asp:HiddenField ID="hfCodTipoVehiculo" runat="server" Value='<%# Bind("CodTipoVehiculo") %>' />
                                <asp:HiddenField ID="hfCodVehiculoComponente" runat="server" Value='<%# Bind("CodVehiculoComponente") %>' />
                                 <asp:HiddenField ID="hfCodEstado" runat="server" Value='<%# Bind("CodEstado") %>' />
                            </ItemTemplate>
                            
                        </asp:TemplateField>

                        <%--
                         <asp:TemplateField HeaderText="Descripcion" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDescripcion" Text='<%# Bind("Descripcion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="Cantidad" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblCantidad" Text='<%# Bind("Cantidad") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="TipoVehiculo" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblTipoVehiculo" Text='<%# Bind("TipoVehiculo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="TipoConcepto" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblTipoConcepto" Text='<%# Bind("TipoConcepto") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        
                       <asp:TemplateField HeaderText="Estado" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblEstado" Text='<%# Bind("Estado") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>


                    </Columns>
                </asp:GridView>
            </div>
        </div>




    </div>


    <div id="divEdicionRegistro" style="display: none;">
        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                DATOS VEHICULO COMPONENTES
            </div>
            <div class="ui-jqdialog-content">
                <table cellpadding="0" cellspacing="0" class="form-inputs">

                          <tr>
                          <td style="font-weight: bold">
                          Tipo Componente
                            </td>
                            
                            <td>
                            <table cellpadding="0" cellspacing="0">
                            <tr>
                             
                               <td>
                                            <div id="div_TipoComponenteEdicion">
                                                <asp:DropDownList ID="ddlTipoComponenteEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="150" BackColor="#FFFF99">
                                                </asp:DropDownList>
                                            </div>
                                </td>

                                <td style="font-weight: bold; padding-left: 6px;">
                                 Tipo Vehiculo
                            </td>

                               <td  style="padding-left: 5px;">
                                            <div id="div_TipoVehiculoEdicion">
                                                <asp:DropDownList ID="ddlTipoVehiculoEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="145" BackColor="#FFFF99">
                                                </asp:DropDownList>
                                            </div>
                                </td>

                            </tr>
                            </table>
                            </td>
                        </tr>
                          <tr>
                             <td style="font-weight: bold; padding-left: 6px;">
                                 Descripcion
                            </td>

                            <td>
                            <table cellpadding="0" cellspacing="0">
                            <tr>
                             
                              <td>
                                            <asp:TextBox ID="txtDescripcionEdicion" mode="multiline" runat="server" Width="384px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                               

                            </tr>
                            </table>
                            </td>
                           
                        </tr>
                          <tr>

                             <td style="font-weight: bold; padding-left: 6px;">
                                 Cantidad
                            </td>

                            
                            <td>
                            <table cellpadding="0" cellspacing="0">
                            <tr>
                             
                             
                              <td>
                                            <asp:TextBox ID="txtCantidadEdicion" mode="multiline" runat="server" Width="145px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>





                                <td style="font-weight: bold;padding-left: 8px;">
                                       Estado
                              </td    >
                                <td  style="padding-left: 40px;">
                                            <div id="div_EstadoEdicion">
                                                <asp:DropDownList ID="ddlEstadoEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="146" BackColor="#FFFF99">
                                                </asp:DropDownList>
                                            </div>
                                </td>

                            </tr>
                            </table>
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

      <input id="hfCodVehiculoComponente" type="hidden" value="0" />



</asp:Content>
