<%@ Page Title="CheckList" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckList.aspx.cs" Inherits="SistemaInventario.Maestros.CheckList" enableEventValidation="false"   %>
   
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"  type="text/javascript"></script>      
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>    
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript" charset="UTF-8"></script>
    <script type="text/javascript" language="javascript" src="CheckList.js" charset="UTF-8"></script>
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet" type="text/css" />       
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
      <link href="../Asset/toars/toastr.min.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/toars/toastr.min.js" type="text/javascript"></script>
    <script src="../Scripts/inputatajos/kibo.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo">
        CHECK LIST</div>
    <div id="divTabs">
        <ul>
            <li id="liRegistro"><a href="#tabRegistro">Registro</a></li>
            <li id="liConsulta"><a href="#tabConsulta" onclick="getContentTab();">Consulta</a></li>
        </ul>
        <div id="tabRegistro">
            <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 800px">
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    REGISTRO DE CHECK LIST
                </div>

                <div>
                    <table cellpadding="0" cellspacing="0" class="form-inputs">

                        <tr>
                            <td style="font-weight: bold">
                            Placa
                            </td>
                            <td>
                            <table cellpadding="0" cellspacing="0">
                            <tr>
                             <td   style="padding-left: 10px;"  >
                                  <asp:TextBox ID="txtPlaca" runat="server" Width="100px" Font-Names="Arial" ForeColor="Blue"
                                      Font-Bold="True" MaxLength="20" ></asp:TextBox>
                              </td>
                             
                                 
                              <td style="font-weight: bold">
                                 Cliente
                              </td>
                              <td   style="padding-left: 47px;" >
                                  <asp:TextBox ID="txtCliente" runat="server" Width="310px" Font-Names="Arial" ForeColor="Blue"
                                      Font-Bold="True"></asp:TextBox>
                              </td>

                              <td style="font-weight: bold">
                                  Emple. Res
                              </td>
                              <td   style="padding-left: 15px;" >
                                  <div id="div_EmpleadoResponsable">
                                      <asp:DropDownList ID="ddlResponsableEmpleado" runat="server" Font-Names="Arial" ForeColor="Blue"
                                          Font-Bold="True" Width="110" BackColor="#FFFF99">
                                      </asp:DropDownList>
                                  </div>
                              </td>

                            </tr>
                            </table>
                            </td>
                           
                        </tr>

                        <tr>

                        
                            <td style="font-weight: bold;">
                           Res. DNI
                            </td>

                            <td>
                            <table cellpadding="0" cellspacing="0">
                            <tr>
                           <td   style="padding-left: 10px;"  >
                                  <asp:TextBox ID="txtClienteResponsableDNI" runat="server" Width="100px" Font-Names="Arial" ForeColor="Blue"
                                      Font-Bold="True" MaxLength="20" ></asp:TextBox>
                              </td>
                                 
                           <td style="font-weight: bold">
                                 Responsable
                              </td>
                           <td   style="padding-left: 15px;" >
                                  <asp:TextBox ID="txtClienteResponsable" runat="server" Width="310px" Font-Names="Arial" ForeColor="Blue"
                                      Font-Bold="True"></asp:TextBox>
                              </td>

                           <td style="font-weight: bold; padding-left: 2px;">
                                  Color
                              </td>
                           <td   style="padding-left: 38px;" >
                                  <asp:TextBox ID="txtColor" runat="server" Width="107px" Font-Names="Arial" ForeColor="Blue"
                                      Font-Bold="True"></asp:TextBox>
                              </td>
                            </tr>
                            </table>
                            </td>
                           
                        </tr>

                        <tr>

                            <td style="font-weight: bold;">
                           Año
                            </td>

                            <td>
                            <table cellpadding="0" cellspacing="0">
                            <tr>
                               <td   style="padding-left: 10px;" >
                                  <asp:TextBox ID="txtAnio" runat="server" Width="100px" Font-Names="Arial" ForeColor="Blue"
                                      Font-Bold="True"></asp:TextBox>
                              </td>

                               <td style="font-weight: bold; padding-left: 6px;">
                                  Marca
                              </td>
                              <td    style="padding-left: 50px;"  >
                                  <asp:TextBox ID="txtMarca" runat="server" Width="119px" Font-Names="Arial" ForeColor="Blue" ReadOnly="true"
                                      Font-Bold="True"></asp:TextBox>
                              </td>
                                <td style="font-weight: bold; padding-left: 6px;">
                                  Modelo
                              </td>
                              <td   style="padding-left: 15px;" >
                                  <asp:TextBox ID="txtModelo" runat="server" Width="119px" Font-Names="Arial" ForeColor="Blue"
                                      Font-Bold="True"></asp:TextBox>
                               </td>

                                <td style="font-weight: bold;display:none;">
                                  Estado
                              </td>
                              <td   style="padding-left: 33px;display: none;" >
                                  <div id="div_Estado">
                                      <asp:DropDownList ID="ddlEstado" runat="server" Font-Names="Arial" ForeColor="Blue"
                                          Font-Bold="True" Width="110" BackColor="#FFFF99">
                                      </asp:DropDownList>
                                  </div>
                                 </td>

                            </tr>
                            </table>
                            </td>
                           
                        </tr>

                     
                    </table>

                      </div>
   


                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    NIVEL DE GASOLINA
                </div>

                <div>
                <table cellpadding="0" cellspacing="0" class="form-inputs">
                   <tr>

                <td style="padding-left: 32px;">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="padding-left: 5px;font-weight: bold;font-size: 20px;">
                               <asp:RadioButton id="RbnNivelGasolina1" runat="server" Text="25%" GroupName="RbnNivelGasolina"  Font-Size="Large"/>
                            </td>
                              <td style="padding-left: 20px;font-weight: bold;font-size: 20px;"  >
                               <asp:RadioButton id="RbnNivelGasolina2" runat="server" Text="50%" GroupName="RbnNivelGasolina" Font-Size="Large" />
                            </td>
                             <td style="padding-left: 20px;font-weight: bold;font-size: 20px;"  >
                               <asp:RadioButton id="RbnNivelGasolina3" runat="server" Text="75%" GroupName="RbnNivelGasolina"  Font-Size="Large"/>
                            </td>
                              <td style="padding-left: 20px;font-weight: bold;font-size: 20px;"  >
                               <asp:RadioButton id="RbnNivelGasolina4" runat="server" Text="100%" GroupName="RbnNivelGasolina" Font-Size="Large" />
                            </td>
                        </tr>

                    </table>
                </td>
            </tr>
                </table>

            </div>

                
              
                </div>

                    <div id="div_tablaComponentes" style="padding-top: 15px;">
                  <asp:GridView ID="grvTablaComponentes" runat="server" AutoGenerateColumns="False" border="0"
                      CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="800px"  >
                      <Columns>

                       <asp:TemplateField HeaderText="" HeaderStyle-Width="5px">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                            <asp:CheckBox ID="chkComponente" runat="server" Font-Bold="True" CssClass="chkDelete" onclick="F_ValidarCheck_Componente(this.id);"  />
                              <asp:HiddenField ID="hfCodVehiculoComponente" runat="server" Value='<%# Bind("CodVehiculoComponente") %>' />
                                 <asp:HiddenField ID="hfCodEstadoComponente" runat="server" Value='<%# Bind("CodEstadoComponente") %>' />
                                <asp:HiddenField ID="hfCantidadComponente" runat="server" Value='<%# Bind("Cantidad") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        
                            <asp:TemplateField HeaderText="Tipo" HeaderStyle-HorizontalAlign="Center"    HeaderStyle-Width="80px"   >
                              <ItemStyle HorizontalAlign="left" />
                              <ItemTemplate>
                                  <asp:Label runat="server" ID="lblTipo"  Text='<%# Bind("TipoComponente") %>'  ></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>

                          <asp:TemplateField HeaderText="Componente" HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Width="150px" >
                              <ItemStyle HorizontalAlign="left"/>
                              <ItemTemplate>
                                  <asp:Label runat="server" ID="lblComponente"    Text='<%# Bind("Componente") %>'  ></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>

                            <asp:TemplateField HeaderText="Cantidad" HeaderStyle-HorizontalAlign="Center"    HeaderStyle-Width="15px"   >
                              <ItemStyle HorizontalAlign="Center" />
                              <ItemTemplate >
                                  <asp:TextBox ID="txtCantidadComponente" runat="server" Width="50px" Font-Names="Arial" ForeColor="Blue"  CssClass="ccsestilo" 
                                      Font-Bold="True"  Style="text-align: center;"  Text='<%# Bind("Cantidad") %>'   Enabled="False"  ></asp:TextBox>
                              </ItemTemplate>
                          </asp:TemplateField>

                          
                            <asp:TemplateField HeaderText="Estado" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="120px"    >
                              <ItemStyle HorizontalAlign="left" />
                              <ItemTemplate>
                                  <asp:RadioButton id="rbnEstadoComponente1" runat="server" Text="BUENO"   GroupName="rbnEstadoComponente" Enabled="false"/>
                                  <asp:RadioButton id="rbnEstadoComponente2" runat="server" Text="REGULAR" GroupName="rbnEstadoComponente" Enabled="false"/>
                                  <asp:RadioButton id="rbnEstadoComponente3" runat="server" Text="MALO" GroupName="rbnEstadoComponente" Enabled="false"/>
                              </ItemTemplate>
                          </asp:TemplateField>
                          
                            
                      </Columns>
                  </asp:GridView>
              </div>


                <div>
                    <table cellpadding="0" cellspacing="0" class="form-inputs">

                        <tr>
                            <td>
                            <table cellpadding="0" cellspacing="0">
                            <tr>
                              <td style="font-weight: bold">
                            Observacion
                            </td>
                              <td  style="padding-left: 10px">
                                  <asp:TextBox ID="txtObservacion" runat="server" Width="700px" Font-Names="Arial" ForeColor="Blue"
                                      Font-Bold="True" ></asp:TextBox>
                              </td>
                                </tr>
                                  </table>
                                    </td>
                         </tr>
                       </table>

            </div>


         <div class="linea-button">
              <%--  <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120px" />--%>
                   <asp:Button ID="btnNuevo" runat="server" Text="Limpiar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120px" />
                    <asp:Button ID="btnGrabar" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120px" />
                </div>    

           </div> 

                <div id="tabConsulta">
            <div id='divConsulta' class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    Criterio de busqueda
                </div>
                <div class="ui-jqdialog-content">
                    <table cellpadding="0" cellspacing="0" class="form-inputs" width="650">
                        <tr>

                           
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
                                 <asp:TextBox ID="txtNumeroConsulta" runat="server" Width="55" Font-Names="Arial"
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
                             <td style="font-weight: bold">
                                Placa
                             </td>
                             <td  style="padding-left: 5px;"  >
                                <asp:TextBox ID="txtPlacaConsulta" runat="server" Width="150" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                             </td>
                             <td style="font-weight: bold">
                                Cliente
                             </td>
                             <td  style="padding-left: 5px;"  >
                                <asp:TextBox ID="txtClienteConsulta" runat="server" Width="240" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                             </td>

                             <td style="font-weight: bold">
                                Estado
                            </td>
                            <td>
                                 <div id="div_EstadoConsulta">
                                      <asp:DropDownList ID="ddlEstadoConsulta" runat="server" Font-Names="Arial" ForeColor="Blue"
                                          Font-Bold="True" Width="100" BackColor="#FFFF99">
                                      </asp:DropDownList>
                                  </div>
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
                        

                        <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/Eliminar.jpg"
                                                ToolTip="ANULAR COTIZACION" OnClientClick="F_AnularRegistro(this); return false;" />
                                        </ItemTemplate>
                         </asp:TemplateField>

                      <%--  <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgEditarRegistro" ImageUrl="../Asset/images/btnEdit.gif"
                                    ToolTip="EDITAR" OnClientClick="F_EditarRegistro(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        
                         <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgReemplazar" ImageUrl="~/Asset/images/Reemplazo.png"
                                    ToolTip="ACTUALIZAR GUIA" OnClientClick="F_ReemplazarDocumento(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgPdf2" ImageUrl="~/Asset/images/pdf.png" ToolTip="VISUALIZAR PDF"
                                                OnClientClick="F_VistaPreliminar(this); return false;" />
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
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <img id="imgMas" alt="" style="cursor: pointer" src="../Asset/images/plus.gif" onclick="imgMas_Click(this);"
                                                title="Ver Detalle" />
                                            <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                                                <asp:GridView ID="grvDetalle" border="0" CellPadding="0" CellSpacing="1"
                                                    AutoGenerateColumns="False" GridLines="None" class="GridView" runat="server"   >
                                                    <Columns>
                                                        <asp:BoundField DataField="Tipo" HeaderText="Tipo">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Componente" HeaderText="Componente">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="EstadoComponente" HeaderText="Estado Componente">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                       
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                
                     <asp:TemplateField HeaderText="Numero" HeaderStyle-HorizontalAlign="Center"  >
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblNumero" Text='<%# Bind("Numero") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Placa">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="hfPlaca" Text='<%# Bind("Placa") %>' CssClass="detallesart"></asp:Label>
                                <%--<asp:HiddenField ID="hfCliente" runat="server" Value='<%# Bind("Cliente") %>' />--%>
                                  <asp:HiddenField ID="hfCodigo" runat="server" Value='<%# Bind("Codigo") %>' />
                                  <asp:HiddenField ID="hfCliente" runat="server" Value='<%# Bind("Cliente") %>' />
                                  <asp:HiddenField ID="hfEmpleado" runat="server" Value='<%# Bind("Empleado") %>' />
                                  <asp:HiddenField ID="hfClienteDNI" runat="server" Value='<%# Bind("ClienteDNI") %>' />
                                  <asp:HiddenField ID="hfResponsable" runat="server" Value='<%# Bind("Cliente") %>' />
                                  <asp:HiddenField ID="hfColor" runat="server" Value='<%# Bind("Color") %>' />
                                  <asp:HiddenField ID="hfAnio" runat="server" Value='<%# Bind("Anio") %>' />
                                  <asp:HiddenField ID="hfMarca" runat="server" Value='<%# Bind("Marca") %>' />
                                  <asp:HiddenField ID="hfModelo" runat="server" Value='<%# Bind("Modelo") %>' />
                                  <asp:HiddenField ID="hfEstado" runat="server" Value='<%# Bind("Estado") %>' />
                                  <asp:HiddenField ID="hfCodTipoCliente" runat="server" Value='<%# Bind("CodTipoCliente") %>' />
                            </ItemTemplate>

                        </asp:TemplateField>

                        <%-- <asp:TemplateField HeaderText="Cliente" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblCliente" Text='<%# Bind("Cliente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <%-- <asp:TemplateField HeaderText="Placa" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblPlaca" Text='<%# Bind("Placa") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
--%>
                   
                        <asp:TemplateField HeaderText="Cliente" HeaderStyle-HorizontalAlign="Center"  >
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblCliente" Text='<%# Bind("Cliente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                           <asp:TemplateField HeaderText="Emision" HeaderStyle-HorizontalAlign="Center"  >
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblFechaEmision" Text='<%# Bind("FechaEmision") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Empleado" HeaderStyle-HorizontalAlign="Center"   >
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblEmpleado" Text='<%# Bind("Empleado") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="DNI Cliente" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblClienteDNI" Text='<%# Bind("ClienteDNI") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Cliente. Res" HeaderStyle-HorizontalAlign="Center" >
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblClienteRes" Text='<%# Bind("ClienteRes") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Color" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblColor" Text='<%# Bind("Color") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Año" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblAnio" Text='<%# Bind("Anio") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Marca" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblMarca" Text='<%# Bind("Marca") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Modelo" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblModelo" Text='<%# Bind("Modelo") %>'></asp:Label>
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
        <center>
            <asp:Label ID="Label2" runat="server" Text="PROCESANDO..." Font-Bold="true" Font-Size="Large"
                Style="text-align: center"></asp:Label></center>
        <br />
        <center>
            <img alt="Wait..." src="../Asset/images/ajax-loader2.gif" /></center>
    </div>

       <input id="hfPlaca" type="hidden" value="" />
       <input id="hfCodVehiculo" type="hidden" value="" />
       <input id="hfCodCliente" type="hidden" value="" />
       <input id="hfCodVehiculoCheckListCab" type="hidden" value="0" />
       <input id="hfCodigo" type="hidden" value="0" />
       <input id="hfGasolina" type="hidden" value="0" runat="server"  />
       <input id="hfEstado" type="hidden" value="0" runat="server"  />
       <input id="hfCodTipoCliente" type="hidden" value="0" />
       

       
</asp:Content>
