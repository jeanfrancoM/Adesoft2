<%@ Page Title="Ventas Por Vendedor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ventas_VentaXVendedorDetallado.aspx.cs" Inherits="SistemaInventario.Reportes.Ventas_VentaXVendedorDetallado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script> 
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"type="text/javascript"></script>
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script> 
    <script src="../Scripts/alertify.min.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript" charset="UTF-8"></script>
    <script type="text/javascript" language="javascript"  src="Ventas_VentaXVendedorDetallado.js" charset="UTF-8"></script>
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />  
    <link href="../Asset/css/alertify.core.css" rel="stylesheet" type="text/css" /> 
    <link href="../Asset/css/alertify.default.css" rel="stylesheet" type="text/css" />
 </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="titulo"    style="width: 390px">REPORTE DE VENTAS POR VENDEDOR</div> 
               <div id="tabRegistro" style="width: 390px">
                          <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" >
                                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix" >
                                    CRITERIO DE BUSQUEDA</div>
                         
                                <div id="divConsultaArticulo">
                           
                                         <div class="ui-jqdialog-content">
                                        <table  cellpadding="0" cellspacing="0" class="form-inputs">
                                         <tr>
                            <td style="font-weight: bold">
                                Sucursal
                            </td>
                            <td style="padding-left: 5px">
                                <div id="div_Sucursal">
                                    <asp:DropDownList ID="ddlSucursal" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True" Width="100px">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                                         <tr>
                                          <td style="font-weight: bold">
                                                        VENDEDOR
                                                    </td>
                                                    <td style="padding-left: 5px">
                                                        <div id="div_Vendedor">
                                                            <asp:DropDownList ID="ddlVendedor" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="100" BackColor="#FFFF99">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                        </tr>
                                
                                          <tr style="display:none;" >
                                             <td style="font-weight: bold">
                                                        Condicion Pago
                                                    </td>
                                                    <td style="padding-left: 5px">
                                                    
                                                     <div id="div_FormaPago">
                                                            <asp:DropDownList ID="ddlFormaPago" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="100"  CssClass="ccsestilo" BackColor="#FFFF99">
                                                                  <asp:ListItem Value="0">TODOS</asp:ListItem>
                                                                  <asp:ListItem Value="1">CONTADO</asp:ListItem>
                                                                   <asp:ListItem Value="2">CREDITO</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                        </tr>
                                               
                                         <tr>    
                                                <td style="font-weight: bold">
                                                            DESDE
                                              </td>
                                                 <td>
                                                            <table  cellpadding="0" cellspacing="0">
                                                            <tr>
                                                              <td>
                                                            
                                                                     <asp:TextBox ID="txtDesde" runat="server" Width="56px" CssClass="Jq-ui-dtp" Font-Names="Arial"
                                                            ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                                            </td>
                                                            <td style="font-weight: bold">
                                                            HASTA
                                                            </td>
                                                        <td style="padding-left:5px;">
                                                            
                                                                     <asp:TextBox ID="txtHasta" runat="server" Width="56px" CssClass="Jq-ui-dtp" Font-Names="Arial"
                                                            ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                                            </td>
                                                            </tr>
                                                            </table>
                                                            </td>

                                                           
                                                       </tr>

                                                               <tr style="display:none;">
                                             <td style="font-weight: bold">
                                                        Moneda
                                                    </td>
                                                    <td style="padding-left: 5px">
                                                    
    <div id="div_Moneda">
                                                            <asp:DropDownList ID="ddlMoneda" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="100" BackColor="#FFFF99">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                        </tr>

                               
                                        </table>
                                    </div>

                                    <div  class="linea-button">
                                      <asp:Button ID="btnReporte" runat="server" Text="Reporte" Font-Names="Arial"
                                                                class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" Width="120px" 
                                                                 />
                                    </div>
                                </div>

                    
                           </div>   
    
                        </div>


                                   <div id="div_Consulta" style ="padding-top:5px;">
                            <asp:GridView ID="grvConsulta" runat="server" AutoGenerateColumns="True"
                                border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                                Width="1018px">                       
                            </asp:GridView>
                        </div>
                          
          <div id="dlgWait" style="background-color:#CCE6FF; text-align:center; display:none;">
        <br /><br />
        <center><asp:Label ID="Label2" runat="server" Text="PROCESANDO..." Font-Bold="true" Font-Size="Large" style="text-align:center"></asp:Label></center>
        <br />
        <center><img alt="Wait..." src="../Asset/images/ajax-loader2.gif"/></center>
    </div>               
</asp:Content>