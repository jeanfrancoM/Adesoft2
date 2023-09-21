<%@ Page Title="Planilla Pagos"  MasterPageFile="~/Site.Master" EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="Planilla_Pagos.aspx.cs" Inherits="SistemaInventario.Planilla.Planilla_Pagos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"  type="text/javascript"></script>      
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript" charset="UTF-8"></script>       
    <script type="text/javascript" language="javascript" src="Planilla_Pagos.js" charset="UTF-8"></script>
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"   type="text/css" />     
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/toars/toastr.min.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/toars/toastr.min.js" type="text/javascript"></script>
    <script src="../Asset/js/moment.js" type="text/javascript"></script>
    <script src="UtilitariosPlanillas.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class='overlay'>
        <div class="titulo" style="width:1085px">
            Pagos de Planilla</div>
        <div id="divTabs" style="width:1080px">
        <ul>
            <li id="liRegistro"><a href="#tabRegistro">Registro</a></li>
            <li id="liConsulta"><a href="#tabConsulta">Consulta</a></li>
        </ul>
        <div id="tabRegistro" style="width: 1045px;">
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
                                            <td style="font-weight: bold; width:100px">
                                                Regimen Laboral
                                            </td>
                                            <td>
                                                <div id="div_regimenlaboral">
                                                    <asp:DropDownList ID="ddlRegimenLaboral" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True" Width="290">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>                                            
                                            <td>
                                                <asp:CheckBox ID="chkTrabajador" runat="server" Text="Trabajador" Font-Bold="True" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTrabajador" runat="server" Width="390" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True"></asp:TextBox>
                                            </td>
                                            
                                            <td style="font-weight: bold" id="lblSemana">
                                               Semana
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
                                           <%--<td>
                                                <asp:CheckBox ID="chkRango" runat="server" Text="Fecha" Font-Bold="True" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDesde" runat="server" Width="55" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" CssClass="Jq-ui-dtp" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtHasta" runat="server" Width="55" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" CssClass="Jq-ui-dtp" ReadOnly="True"></asp:TextBox>
                                            </td>--%>
                                             <td style="font-weight: bold; width:100px;">
                                                Proyecto
                                            </td>
                                            <td>
                                                <div id="div_proyecto">
                                                    <asp:DropDownList ID="ddlProyecto" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True" Width="290">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            
                                        </tr>

                                    </table>
                                </td>
                            </tr>                            
                        <tr>    
                            <td>
                             <table cellpadding="0" cellspacing="0" class="form-inputs" style="width: 1000px">
                                        <tr>
                                            <td  style="font-weight: bold; width:100px;">
                                                 Fecha Pago
                                            </td>
                                             <td>                                               
                                                    <asp:TextBox ID="txtFechaPago" runat="server" Width="55" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" CssClass="Jq-ui-dtp" ReadOnly="True"></asp:TextBox>                                               
                                            </td>
                                        </tr>

                                    </table>
                                </td>
                        </tr>
                     
                        </tbody>
                    </table>
                </div>
                <div class="linea-button">
                    <asp:TextBox ID="txtPorcentaje" runat="server" Width="75px" Font-Bold="true" Style="text-align: center;"
                                    CssClass="ccsestilo" Font-Names="Arial" ForeColor="Blue"></asp:TextBox>
                     <asp:Label runat="server" ID="lblPorcentaje" Text='%'></asp:Label>
                    <asp:Button ID="btnCalcular" runat="server" Text="Calcular" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                                Font-Names="Arial" Font-Bold="True" Width="120" />
                    <asp:Button ID="btnGrabar" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                                Font-Names="Arial" Font-Bold="True" Width="120" />
                    <asp:Button ID="btnBuscarConsulta" runat="server" Text="Buscar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                </div>
              
            </div>
              <div id="div_consulta" style="padding-top: 5px">
                <asp:GridView ID="grvConsulta" runat="server" AutoGenerateColumns="False" border="0"
                CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="1000px"
                OnRowDataBound="grvConsulta_RowDataBound">
                <Columns>
                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="ChkAll" runat="server" onclick='F_CheckAll(this);'/>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkPdf" CssClass="chkItem" Text="" onclick="F_ValidarCheck(this.id);" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>                    
                   
                   <%-- <asp:TemplateField>
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
                    </asp:TemplateField>--%>
                    <asp:BoundField DataField="DNI" HeaderText="DNI">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Nombre Completo">
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblNombreCompleto" CssClass="detallesart" Text='<%# Bind("NombreCompleto") %>'></asp:Label>
                            <asp:HiddenField ID="hfCodPagoCab" runat="server" Value='<%# Bind("CodPagoCab") %>' />
                            <asp:HiddenField ID="hfCodSalarioCab" runat="server" Value='<%# Bind("CodSalarioCab") %>' />
                            <asp:HiddenField ID="hfCodRegimenLaboral" runat="server" Value='<%# Bind("CodRegimenLaboral") %>' />
                            <asp:HiddenField ID="hfCodTrabajador" runat="server" Value='<%# Bind("CodTrabajador") %>' />
                            <asp:HiddenField ID="hfCodSemana" runat="server" Value='<%# Bind("CodSemana") %>' />
                            <asp:HiddenField ID="hfCodPeriodo" runat="server" Value='<%# Bind("CodPeriodo") %>' />
                            <asp:HiddenField ID="hfCodEstado" runat="server" Value='<%# Bind("CodEstado") %>' />
                            <asp:HiddenField ID="hfCodProyecto" runat="server" Value='<%# Bind("CodProyecto") %>' />
                            <asp:HiddenField ID="hfDetalleCargado" runat="server" Value='0' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Descripcion" HeaderText="Regimen Laboral">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DscBanco" HeaderText="Banco">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NumeroCuenta" HeaderText="NumeroCuenta">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CCI" HeaderText="CCI">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="MontoPago" HeaderText="Total">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                   <asp:TemplateField HeaderText="Saldo">
                        <ItemTemplate>
                           <asp:Label runat="server" ID="lblSaldo" Text='<%# Bind("PorPagar") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Monto">
                        <ItemTemplate>
                           <asp:TextBox runat="server" ID="txtMonto" Width="75px" Font-Bold="true" Style="text-align: center;"
                                    CssClass="ccsestilo" Font-Names="Arial" ForeColor="Blue" Enabled="false"
                                    ></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Cancelado" HeaderText="A Cuenta">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                           <asp:Label runat="server" ID="lblEstado" Text='<%# Bind("Estado") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        </div>
          <div id="tabConsulta" style="width: 1045px;">
            <div id='divConsulta2' class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
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
                                            <td style="font-weight: bold; width:100px">
                                                Regimen Laboral
                                            </td>
                                            <td>
                                                <div id="div_regimenlaboral2">
                                                    <asp:DropDownList ID="ddlRegimenLaboral2" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True" Width="290">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>                                            
                                            <td>
                                                <asp:CheckBox ID="chkTrabajador2" runat="server" Text="Trabajador" Font-Bold="True" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTrabajador2" runat="server" Width="390" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True"></asp:TextBox>
                                            </td>
                                            
                                            <td style="font-weight: bold" id="lblSemana2">
                                               Semana
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtAñoSemana2" runat="server" Width="50px" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True"></asp:TextBox>
                                            </td>
                                            <td style="display: none">
                                                <asp:Label runat="server" ID="lblCodSemana2"></asp:Label>
                                                <label id="lblDisplaySemana2" style="font-size=14; font-weight=">
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
                                             <td style="font-weight: bold; width:100px;">
                                                Proyecto
                                            </td>
                                            <td>
                                                <div id="div4">
                                                    <asp:DropDownList ID="ddlProyecto2" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True" Width="290">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            
                                        </tr>

                                    </table>
                                </td>
                            </tr>                            
                        <tr>    
                            <td>
                             <table cellpadding="0" cellspacing="0" class="form-inputs" style="width: 1000px">
                                        <tr>
                                            <td style="width:100px">
                                                <asp:CheckBox ID="chkRango" runat="server" Text="Fecha" Font-Bold="True" />
                                            </td>
                                            <td style="width:80px">
                                                <asp:TextBox ID="txtDesde" runat="server" Width="55" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" CssClass="Jq-ui-dtp" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtHasta" runat="server" Width="55" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" CssClass="Jq-ui-dtp" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>

                                    </table>
                                </td>
                        </tr>
                     
                        </tbody>
                    </table>
                </div>
                <div class="linea-button">
                    <asp:Button ID="btnBuscarConsulta2" runat="server" Text="Buscar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                                Font-Names="Arial" Font-Bold="True" Width="120" />
                </div>
              
            </div>
            <div id="div_consulta2" style="padding-top: 5px">
                <asp:GridView ID="grvConsulta2" runat="server" AutoGenerateColumns="False" border="0"
                CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="1000px"
                OnRowDataBound="grvConsulta2_RowDataBound">
                <Columns>
                <%-- <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="ChkAll" runat="server" onclick='F_CheckAll(this);'/>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkPdf" CssClass="chkItem" Text="" onclick="F_ValidarCheck(this.id);" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>                    --%>
                   
                    <asp:TemplateField>
                        <ItemTemplate>
                             <asp:ImageButton runat="server" ID="imgEliminarPago" ImageUrl="~/Asset/images/EliminarBtn.png"
                                    ToolTip="ELIMINAR PAGO" OnClientClick="F_AnularRegistro(this); return false;" />
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:BoundField DataField="DNI" HeaderText="DNI">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Nombre Completo">
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblNombreCompleto2" CssClass="detallesart" Text='<%# Bind("NombreCompleto") %>'></asp:Label>                                                       
                            <asp:HiddenField ID="hfCodSalarioCab2" runat="server" Value='<%# Bind("CodSalarioCab") %>' />
                            <asp:HiddenField ID="hfCodPagoCab2" runat="server" Value='<%# Bind("CodPagoCab") %>' />
                            <asp:HiddenField ID="hfCodPagoDet" runat="server" Value='<%# Bind("CodPagoDet") %>' />
                            <asp:HiddenField ID="hfCodRegimenLaboral2" runat="server" Value='<%# Bind("CodRegimenLaboral") %>' />
                            <asp:HiddenField ID="hfCodTrabajador2" runat="server" Value='<%# Bind("CodTrabajador") %>' />
                            <asp:HiddenField ID="hfCodSemana2" runat="server" Value='<%# Bind("CodSemana") %>' />    
                            <asp:HiddenField ID="hfCodPeriodo2" runat="server" Value='<%# Bind("CodPeriodo") %>' />                                                                                 
                            <asp:HiddenField ID="hfDetalleCargado" runat="server" Value='0' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Descripcion" HeaderText="Regimen Laboral">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DscBanco" HeaderText="Banco">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NumeroCuenta" HeaderText="NumeroCuenta">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CCI" HeaderText="CCI">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="A CUENTA">
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblAcuenta" Text='<%# Bind("Acuenta") %>'></asp:Label>                                                                                   
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:BoundField DataField="Saldo" HeaderText="Saldo">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>               
                    <asp:BoundField DataField="Total" HeaderText="Total">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                         
                     <asp:TemplateField HeaderText="Fecha Pago">
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblFechaPago" Text='<%# Bind("FechaPago") %>'></asp:Label>                                                                                   
                        </ItemTemplate>
                    </asp:TemplateField>
                       <asp:BoundField DataField="Periodo" HeaderText="Periodo/Semana">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
        </div>
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
    <input id="hfCodCtaCteConsulta2" type="hidden" value="0" />
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