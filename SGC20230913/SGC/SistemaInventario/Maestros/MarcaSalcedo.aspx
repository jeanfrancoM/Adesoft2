<%@ Page Title="Marca" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MarcaSalcedo.aspx.cs" Inherits="SistemaInventario.Maestros.MarcaSalcedo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"type="text/javascript"></script>
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script> 
    
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript" charset="UTF-8"></script>
    <script type="text/javascript" language="javascript"  src="MarcaSalcedo.js" charset="UTF-8"></script>
    <link href="../Asset/css/redmond/jquery-ui-1.10.4.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />  
    <link href="../Asset/toars/toastr.min.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/toars/toastr.min.js" type="text/javascript"></script>
 </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="titulo" >Marca</div> 
                     <div id="divTabs">

                        <ul>
                            <li id="liRegistro"><a href="#tabRegistro">Registro</a></li>
                            <li id="liConsulta"><a href="#tabConsulta">Consulta</a></li>
                        </ul>

                        <div id="tabRegistro">
                               <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 460px">
                                   <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                                    REGISTRO  LINEA
                                   </div>
                           
                                   <div >  
                                    <table  cellpadding="0" cellspacing="0" class="form-inputs">
                                           <tr>
                                                  <td   style="font-weight: bold">
                                    CODIGO
                                     </td>
                              
                                          <td>
                             <asp:TextBox ID="txtCodigo" runat="server"  Width="350px" Font-Names="Arial" ForeColor="Blue"  Font-Bold="True" ></asp:TextBox>
                             </td>
                                   
                                     </tr>                                
                                             <tr>
                                        <td   style="font-weight: bold">
                                    Descripcion
                                     </td>
                                          <td>
                             <asp:TextBox ID="txtDescripcion" runat="server"  Width="350px" Font-Names="Arial" ForeColor="Blue"  Font-Bold="True" ></asp:TextBox>
                             </td>
                                </tr>
                                    </table>
                             
                            </div>     
                            
                               <div class="linea-button">
                               
                                     <asp:Button ID="btnNuevo" runat="server" Text="Nuevo"  
                                class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                                        Font-Names="Arial"  Font-Bold="True"    Width="120px" />
                                     <asp:Button ID="btnGrabar" runat="server" Text="Grabar"  
                                class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                                        Font-Names="Arial"  Font-Bold="True"   Width="120px"   />
                                    
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
                                                                          
                                           <td  style="font-weight: bold">
                                               Descripcion
                                             </td>
                                           
                                           <td>
                                                <asp:TextBox ID="txtDescripcionConsulta" runat="server" Width="772" Font-Names="Arial" ForeColor="Blue"  Font-Bold="True"  ></asp:TextBox>
                                             </td>

                                        </tr>
                                     
                                   

                                        </table>
                                                      
                            </div>

                            <div  class="linea-button">
                              <asp:Button ID="btnBuscarConsulta" runat="server" Text="Buscar"  
                                            class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                                                    Font-Names="Arial"  Font-Bold="True"     Width="120" />
                            </div>
                        </div>
                               <div style="padding-top: 5px;">
               <table cellpadding="0" cellspacing="0" align="center">
                                    <tr>
                                        <td style="font-weight: bold">
                                           Cantidad de Registros:
                                        </td>
                                        <td style="font-weight: bold">
                                            <label id="lblNumeroConsulta">0</label>
                                        </td>                                
                                    </tr>
                                </table>
            </div>
                            <div id="div_consulta" style="padding-top:5px;" >
                                                    <asp:GridView ID="grvConsulta" runat="server" AutoGenerateColumns="False" 
                                                                  border="0" CellPadding="0" CellSpacing="1" CssClass="GridView"
                                                                  GridLines="None" Width="1017px" >
                                                <Columns>                                                 
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton runat="server" id="imgAnularDocumento" ImageUrl="~/Asset/images/EliminarBtn.png" ToolTip="ELIMINAR LINEA" OnClientClick="F_EliminarRegistro(this); return false;" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton runat="server" id="imgEditarRegistro" ImageUrl="../Asset/images/btnEdit.gif" ToolTip="EDITAR LINEA" OnClientClick="F_EditarRegistro(this); return false;" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                         <asp:TemplateField HeaderText="Codigo" HeaderStyle-HorizontalAlign="Center">
                                                           <ItemStyle HorizontalAlign="Right" />
                                                           <ItemTemplate>
                                                             <asp:Label runat="server" ID="lblCodigoMarca"  Text='<%# Bind("CodigoMarcaProducto") %>' CssClass="detallesart"></asp:Label>
                                                             <asp:HiddenField ID="hfCodMarca" runat="server" Value='<%# Bind("CodMarcaProducto") %>' />
                                                           </ItemTemplate>
                                                        </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Descripcion" HeaderStyle-HorizontalAlign ="Center" >
                                                            <ItemStyle HorizontalAlign="left" />
                                                            <ItemTemplate>
                                                                 <asp:Label runat="server" ID="lblDescripcion" Text='<%# Bind("Descripcion") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>                                                     
                                                </Columns>

                                            </asp:GridView>                                    
                                    </div>
                           </div>  
                      </div>

      <div id="divEdicionRegistro" style="display:none;">
                            <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
                                   <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                                    DATOS MARCA
                                   </div>
                                  <div class="ui-jqdialog-content">
                                 <table cellpadding="0" cellspacing="0" class="form-inputs" width="700">
                                        <tr>
                                                <td style="font-weight: bold">
                                              Codigo
                                              </td> 
                                               <td>
                                                <asp:TextBox ID="txtCodigoEdicion" runat="server" Width="50" Font-Names="Arial" ForeColor="Blue"  Font-Bold="True"  ></asp:TextBox>
                                             </td>                         
                                           <td  style="font-weight: bold">
                                               Descripcion
                                             </td>
                                           
                                           <td>
                                                <asp:TextBox ID="txtDescripcionEdicion" runat="server" Width="250" Font-Names="Arial" ForeColor="Blue"  Font-Bold="True"  ></asp:TextBox>
                                             </td>

                                        </tr>
                                        </table>
                                    </div>

                                    <div  class="linea-button">
                                       <asp:Button ID="btnEdicion" runat="server" Text="Grabar"  
                                class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                                        Font-Names="Arial"  Font-Bold="True"   Width="120px"   />
                                    </div>
                                </div>
                                </div>
      <div id="dlgWait" style="background-color:#CCE6FF; text-align:center; display:none;">
        <br /><br />
        <center><asp:Label ID="Label2" runat="server" Text="PROCESANDO..." Font-Bold="true" Font-Size="Large" style="text-align:center"></asp:Label></center>
        <br />
        <center><img alt="Wait..." src="../Asset/images/ajax-loader2.gif"/></center>
    </div>     

     <input id="hfCodMarca" type="hidden"  value="0" />
 
</asp:Content>
