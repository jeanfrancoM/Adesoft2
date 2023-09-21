<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NotaPedido.aspx.cs" Inherits="SistemaInventario.Compras.NotaPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"type="text/javascript"></script>
 
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
      <script src="../Asset/js/js.js" type="text/javascript"></script> <script src="../Scripts/alertify.min.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript" charset="UTF-8"></script>
    <script type="text/javascript" language="javascript"  src="NotaPedido.js" charset="UTF-8"></script>

    
<%--    <link href="../Asset/css/ModalPopupExtender.css" rel="stylesheet" type="text/css" />--%>
    <link href="../Asset/css/redmond/jquery-ui-1.10.4.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet" type="text/css" />
  
   <%-- <link href="../Asset/css/redmond/ui.jqgrid.css" rel="stylesheet" type="text/css" />--%>
     <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />  <link href="../Asset/css/alertify.core.css" rel="stylesheet" type="text/css" /> <link href="../Asset/css/alertify.default.css" rel="stylesheet" type="text/css" />

 </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="titulo">Nota de Pedido</div> 
                                      
            <div id='divConsulta' class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
                        
                                       <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                                                 Criterio de busqueda
                                        </div>
                                        
                                        <div class="ui-jqdialog-content">
                                        <table cellpadding="0" cellspacing="0" class="form-inputs" width="700">
                                        <tr>
                                    
                                             
                                             <td>
                                         <asp:CheckBox ID="chkNumero" runat="server" Text="Numero" />
                                        </td>
                                             
                                             <td>
                                          <asp:TextBox ID="txtNumeroConsulta" runat="server" Width="75"  Font-Names="Arial" Font-Bold="True" ></asp:TextBox>
                                     </td>

                                             <td>
                                               <asp:CheckBox ID="chkRango" runat="server" Text="Fecha" Checked="True" />
                                              </td>

                                             <td>
                                                <asp:TextBox ID="txtDesde" runat="server" Width="55"  Font-Names="Arial" Font-Bold="True"  
                                                     CssClass="Jq-ui-dtp" ReadOnly="True"></asp:TextBox>
                                             </td>

                                             <td>
                                                <asp:TextBox ID="txtHasta" runat="server" Width="55"  Font-Names="Arial" Font-Bold="True"  
                                                     CssClass="Jq-ui-dtp" ReadOnly="True"></asp:TextBox>
                                             </td>

                                             <td>
                                               <asp:CheckBox ID="chkCliente" runat="server" Text="Cliente" />
                                              </td>

                                             <td>
                                                <asp:TextBox ID="txtClienteConsulta" runat="server" Width="460"  Font-Names="Arial" Font-Bold="True" ></asp:TextBox>
                                             </td>

                                             <td>
                                            <asp:Button ID="btnBuscarConsulta" runat="server" Text="Buscar"  
                                            class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                                                     Font-Names="Arial" Font-Bold="True"    />
                             </td>
                                        </tr>

                                        <tr>
                                    <td colspan="8">
                                    <div style="padding-top: 5px;">
                            <table cellpadding="0" cellspacing="0" align="center">
                                <tr>
                                    <td style="font-weight: bold">
                                        Cantidad de Registros:
                                    </td>
                                    <td style="font-weight: bold">
                                        <label id="lblGrillaConsulta">
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                                    <div id="div_consulta">
                                                    <asp:GridView ID="grvConsulta" runat="server" AutoGenerateColumns="False" 
                                            border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                                            DataKeyNames="Codigo" 
                                            Width="990px" Height="400" OnRowDataBound="grvConsulta_RowDataBound">
                                                <Columns>
                                                  <asp:TemplateField>
                                                                <ItemTemplate>                                                                                                                               
                                                                    <asp:ImageButton runat="server" id="imgPdf" ImageUrl="~/Asset/images/pdf.png" ToolTip="Ver PDF" OnClientClick="MostrarReporte(this); return false;" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                      <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <img id="imgMas" alt = "" style="cursor: pointer" src="../Asset/images/plus.gif" onclick="imgMas_Click(this);" title="Ver Detalle" />
                                                        <asp:Panel ID="pnlOrders" runat="server" Style="display: none">

                                                            <asp:GridView runat="server" ID="grvDetalle"  border="0" CellPadding="0" CellSpacing="1"  GridLines="None" class="GridView" />
                                                 

                                                        </asp:Panel>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Codigo" >
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblcodigo" Text='<%# Bind("Codigo") %>' CssClass="detallesart"></asp:Label>
                                                                </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Pedido" >
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblPedido" Text='<%# Bind("Pedido") %>'></asp:Label>
                                                                </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="RazonSocial" >
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                             <asp:Label runat="server" ID="lblcliente" Text='<%# Bind("RazonSocial") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                      <asp:BoundField DataField="Documento" HeaderText="Documento">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>

                                                    <asp:TemplateField HeaderText="Numero" >
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                             <asp:Label runat="server" ID="lblnumero" Text='<%# Bind("Numero") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     
                                                                                                   
                                                    <asp:BoundField DataField="Emision" HeaderText="Emision" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                           
                                              
                                                    <asp:BoundField DataField="Vcto" HeaderText="Vcto" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="Moneda" HeaderText="Moneda" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                           
                                                    <asp:BoundField DataField="Dscto" HeaderText="Dscto" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="SubTotal" HeaderText="SubTotal" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="Igv" HeaderText="Igv" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                           
                                                    <asp:BoundField DataField="Total" HeaderText="Total">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>

                                                     <asp:BoundField DataField="TipoCambio" HeaderText="TC">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>

                                                   
                                                </Columns>

                                                    </asp:GridView>
                                    
                                    </div>
                                                </td>
                            
                                </tr>

                                        </table>
                                                      
                            </div>
                        </div>
                    
                  <div id="dlgWait" style="background-color:#CCE6FF; text-align:center; display:none;">
        <br /><br />
        <center><asp:Label ID="Label2" runat="server" Text="PROCESANDO..." Font-Bold="true" Font-Size="Large" style="text-align:center"></asp:Label></center>
        <br />
        <center><img alt="Wait..." src="../Asset/images/ajax-loader2.gif"/></center>
    </div>            
                  
     <input id="hfCodCtaCte" type="hidden"  value="0" />
     <input id="hfCodCtaCteConsulta" type="hidden"  value="0" />
     <input id="hfCodigoTemporal" type="hidden"  value="0" />
     <input id="hfCodDocumentoVenta" type="hidden" value="0" />
</asp:Content>
