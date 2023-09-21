<%@ Page Title="Lista Precios" Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="ListaPreciosTEK.aspx.cs" Inherits="SistemaInventario.Maestros.ListaPreciosTEK" %>
  
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"  type="text/javascript"></script>      
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    
    <script src="../Scripts/utilitarios.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="ListaPreciosTEK.js"   charset="UTF-8"></script>   
   <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"    type="text/css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/toars/toastr.min.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/toars/toastr.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo" style="width: 1030px">
        Lista Precios</div>
    <div id="tabRegistro" style="width: 1030px">
        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                Lista Precios
            </div>
            <div id="divConsultaArticulo">
                <div class="ui-jqdialog-content">
                    <table cellpadding="0" cellspacing="0" width="900" class="form-inputs">
                        <tr>
                           <td style="font-weight: bold">
                                Familia
                            </td>
                            <td style="padding-left: 0px;">
                                <div id="div_Familia">
                                    <asp:DropDownList ID="ddlFamilia" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True">
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td style="font-weight: bold">
                                Articulo
                            </td>
                            <td>
                                <asp:TextBox ID="txtArticulo" runat="server" Width="500px" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True"></asp:TextBox>
                            </td>
                         
                            <td style="font-weight: bold ;display:none;">
                                VIGENCIA
                            </td>
                            <td  style="display:none;">
                                <asp:TextBox ID="txtEmision" runat="server" Width="56px" CssClass="Jq-ui-dtp" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td style="padding-left: 10px; font-weight: bold;display:none;">
                                PRECIO INCLUIDO IGV
                            </td>
                            <td  style="display:none;">
                                <asp:CheckBox ID="chkPrecioLista" runat="server" Text="VER LISTA PRECIO ACTUAL" Font-Bold="True" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="linea-button">
                <asp:Button ID="btnNuevo" runat="server" Text="Nueva Lista Precio" Font-Names="Arial" style="display:none;"
                    Font-Bold="True" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                    Width="180" />
                <asp:Button ID="btnReporte" runat="server" Text="Reporte" Font-Names="Arial" Font-Bold="True"
                    class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                    Width="120"  />
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Font-Names="Arial" Font-Bold="True"
                    class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                    Width="120" />
                <asp:Button ID="btnAgregar" runat="server" Text="Grabar" Font-Names="Arial" Font-Bold="True"
                    Width="120" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" />
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
        <div id="div_grvConsultaArticulo" style="padding-top: 5px;">
            <asp:GridView ID="grvConsultaArticulo" runat="server" AutoGenerateColumns="False"
                border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                Width="1030px">
                <Columns>
                 

                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                    
                                                        
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkOK" CssClass="chkSi" Text="" onclick="F_ValidarCheck(this.id);"/>
                            </ItemTemplate>
                        </asp:TemplateField>

                                   <asp:TemplateField HeaderText="Codigo">
                                                <ItemStyle HorizontalAlign="Center" Width="70px"  />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("Codigo") %>' CssClass="detallesart"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Marca" HeaderText="Marca">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>

                
               
          <asp:TemplateField HeaderText="COSTO" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtCostoOriginal" Width="80px" Style="text-align: center;"
                                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" CssClass="ccsestilo" onblur="F_Precio(this.id);"
                               Enabled="False" Text='<%# Bind("CostoOriginal") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Moneda">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:DropDownList runat="server" ID="ddlMonedaLista" Font-Names="Arial" ForeColor="Blue"
                                Font-Bold="True" CssClass="ccsestilo" onchange="F_Moneda(this.id);">
                                <asp:ListItem Value="1">S/.</asp:ListItem>
                                <asp:ListItem Value="2">US$</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
            
                    <asp:TemplateField HeaderText="MAYORISTA SOLES" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtPrecioLista1" Width="80px" Style="text-align: center;"
                                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" CssClass="ccsestilo" onblur="F_Precio(this.id);"
                                Text='<%# Bind("Precio1") %>' Enabled="False"></asp:TextBox>
                                      <asp:HiddenField ID="hfCodAlterno" runat="server" Value='<%# Bind("CodAlterno") %>' />
                            <asp:HiddenField ID="hfCosto" runat="server" Value='<%# Bind("Costo") %>' />
                            <asp:HiddenField ID="hfPrecio" runat="server" Value='<%# Bind("Precio") %>' />
                            <asp:HiddenField ID="hfPrecio1" runat="server" Value='<%# Bind("Precio1") %>' />
                            <asp:HiddenField ID="hfPrecio2" runat="server" Value='<%# Bind("Precio2") %>' />
                            <asp:HiddenField ID="hfPrecio3" runat="server" Value='<%# Bind("Precio3") %>' />
                            <asp:HiddenField ID="hfPrecio4" runat="server" Value='<%# Bind("Precio4") %>' />
                            <asp:HiddenField ID="hfMargen" runat="server" Value='<%# Bind("Margen") %>' />
                            <asp:HiddenField ID="hfDescuento" runat="server" Value='<%# Bind("Descuento") %>' />
                            <asp:HiddenField ID="hfCostoOriginal" runat="server" Value='<%# Bind("CostoOriginal") %>' />
                            <asp:HiddenField ID="hfCodMoneda" runat="server" Value='<%# Bind("CodMoneda") %>' />
                            <asp:HiddenField ID="hfCodProducto" runat="server" Value='<%# Bind("CodProducto") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="STOCK">
                                                <ItemStyle HorizontalAlign="Center" Width="50px"  />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblstock" Text='<%# Bind("Total") %>' Font-Size="Medium"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                    <asp:TemplateField HeaderText="ESTADO">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:DropDownList runat="server" ID="ddlEstado" Font-Names="Arial" ForeColor="Blue"
                                Font-Bold="True" CssClass="ccsestilo">
                                <asp:ListItem Value="1">ACTIVO</asp:ListItem>
                                <asp:ListItem Value="2">INACTIVO</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
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
    <input id="hfCodUsuario" type="hidden" value="0" />
    <input id="hfCodSede" type="hidden" value="0" />
    <input id="hfCodProducto" type="hidden" value="0" />
    <input id="hfCodDocumentoVenta" type="hidden" value="0" />
</asp:Content>
