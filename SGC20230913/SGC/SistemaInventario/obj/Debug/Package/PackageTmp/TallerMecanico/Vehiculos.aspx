<%@ Page Title="Vehiculos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vehiculos.aspx.cs" Inherits="SistemaInventario.Maestros.Vehiculos" enableEventValidation="false"   %>
   
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"  type="text/javascript"></script>      
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>    
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript" charset="UTF-8"></script>
    <script type="text/javascript" language="javascript" src="Vehiculos.js" charset="UTF-8"></script>
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet" type="text/css" />       
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
      <link href="../Asset/toars/toastr.min.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/toars/toastr.min.js" type="text/javascript"></script>
    <script src="../Scripts/inputatajos/kibo.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo">
        Vehiculos</div>
    <div id="divTabs">
        <ul>
            <li id="liRegistro"><a href="#tabRegistro">Registro</a></li>
            <li id="liConsulta"><a href="#tabConsulta" onclick="getContentTab();">Consulta</a></li>
        </ul>
        <div id="tabRegistro">
            <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 940px">
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    REGISTRO DE Vehiculos
                </div>

                <div>
                    <table cellpadding="0" cellspacing="0" class="form-inputs">

                        <tr>
                            <td style="font-weight: bold">
                            Cliente
                            </td>
                            <td>
                            <table cellpadding="0" cellspacing="0">
                            <tr>
                              <td>
                                  <asp:TextBox ID="txtNroRuc" runat="server" Width="70px" Font-Names="Arial" ForeColor="Blue"
                                      Font-Bold="True" MaxLength="11" onblur="F_ValidaRucDni(); return false;"></asp:TextBox>
                              </td>
                              <td id="td_loading" style="font-weight: bold; padding-left: 5px; display: none">
                                  <img src="../Asset/images/loading.gif" />
                              </td>
                              <td id="div_Cliente">
                                  <asp:TextBox ID="txtCliente" runat="server" Width="310px" Font-Names="Arial" ForeColor="Blue"
                                      Font-Bold="True"></asp:TextBox>
                              </td>
                              <td style="font-weight: bold">
                                  Distrito
                              </td>
                              <td   style="padding-left: 5px;" >
                                  <asp:TextBox ID="txtDistrito" runat="server" Width="371px" Font-Names="Arial" ForeColor="Blue"
                                      Font-Bold="True"></asp:TextBox>
                              </td>

                            </tr>
                            </table>
                            </td>
                           
                        </tr>

                          <tr>

                          <td style="font-weight: bold">
                            Direccion
                            </td>

                            <td>
                            <table cellpadding="0" cellspacing="0">
                            <tr>
                              <td>
                                   <asp:TextBox Style="width: 388px; position: absolute; color: blue; font-family: Arial;
                                       font-weight: bold; background: rgb(255, 255, 224);" ID="txtDireccion" runat="server"
                                       autocomplete="off"></asp:TextBox>
                                   <asp:DropDownList ID="ddlDireccion" Style="width: 388px" runat="server">
                                   </asp:DropDownList>
                               </td>


                              <td style="font-weight: bold; padding-left: 6px;">
                                  Placa
                              </td>
                              <td   style="padding-left: 17px;" >
                                  <asp:TextBox ID="txtPlaca" runat="server" Width="60px" Font-Names="Arial" ForeColor="Blue"
                                      Font-Bold="True"></asp:TextBox>
                              </td>

                               <td style="font-weight: bold; padding-left: 6px;">
                                  Chasis
                              </td>
                              <td   style="padding-left: 15px;" >
                                  <asp:TextBox ID="txtChasis" runat="server" Width="160px" Font-Names="Arial" ForeColor="Blue"
                                      Font-Bold="True"></asp:TextBox>
                              </td>
                                <td style="font-weight: bold; padding-left: 6px;">
                                  Año
                              </td>
                              <td   style="padding-left: 15px;" >
                                  <asp:TextBox ID="txtAnio" runat="server" Width="34px" Font-Names="Arial" ForeColor="Blue"
                                      Font-Bold="True"></asp:TextBox>
                              </td>


                            </tr>
                            </table>
                            </td>
                           
                        </tr>

                          <tr>

                          <td style="font-weight: bold">
                            Color
                            </td>

                            <td>
                            <table cellpadding="0" cellspacing="0">
                            <tr>
                             <td >
                                            <div id="div_Color">
                                                <asp:DropDownList ID="ddlColor" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="155" BackColor="#FFFF99">
                                                </asp:DropDownList>
                                            </div>
                                        </td>



                    <td style="font-weight: bold;padding-left: 4px;">
                                  Motor     
                              </td    >
                               <td colspan='5' style="padding-left: 20px;">
                                <asp:TextBox ID="txtNroMotor" runat="server" Width="168px" Font-Names="Arial"
                                    Font-Bold="True" ForeColor="Blue"></asp:TextBox>
                            </td>
                                 
                              <td style="font-weight: bold; padding-left: 6px;">
                                 Marca
                            </td>

                               <td  style="padding-left: 10px;">
                                            <div id="div_Marca">
                                                <asp:DropDownList ID="ddlMarca" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="157" BackColor="#FFFF99">
                                                </asp:DropDownList>
                                            </div>
                                </td>



                               <td style="font-weight: bold;padding-left: 4px;">
                                Modelo
                                </td>
                                 <td style="padding-left: 11px;" >
                                            <div id="div_Modelo">
                                                <asp:DropDownList ID="ddlModelo" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="156" BackColor="#FFFF99">
                                                </asp:DropDownList>
                                            </div>
                                        </td>


                            </tr>
                            </table>
                            </td>
                           
                        </tr>


                             <tr>

                          <td style="font-weight: bold">
                         Tipo
                            </td>

                            <td>
                            <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="padding-left: 2px;" >
                                            <div id="div_Tipo">
                                                <asp:DropDownList ID="ddlTipo" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="155" BackColor="#FFFF99">
                                                </asp:DropDownList>
                                            </div>
                                        </td>

                                 <td style="font-weight: bold;padding-left: 2px;">
                                 Vcto Soat
                            </td>
                                        <td style="font-weight: bold;" >
                                  <asp:TextBox ID="txtVencimientoSoat" runat="server" Width="52px" Font-Names="Arial" CssClass="Jq-ui-dtp"
                                      ReadOnly="true" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                              </td>



                              <td style="font-weight: bold;padding-left: 5px;">
                                    Revision
                              </td    >
                              <td style="font-weight: bold;padding-left: 4px;" >
                                  <asp:TextBox ID="txtRevision" runat="server" Width="52px" Font-Names="Arial" CssClass="Jq-ui-dtp"
                                      ReadOnly="true" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                              </td>

                              <td style="font-weight: bold;padding-left: 4px;">
                                       Flota
                              </td    >
                               <td   style="padding-left: 15px;" >
                                  <asp:TextBox ID="txtFlota" runat="server" Width="155px" Font-Names="Arial" ForeColor="Blue"
                                      Font-Bold="True"></asp:TextBox>
                              </td>


                             <td style="font-weight: bold">
                                              ESTADO 
                                        </td>
                                          <td style="padding-left: 15px;" >
                                            <div id="div_Estado">
                                                <asp:DropDownList ID="ddlEstado" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="155" BackColor="#FFFF99">
                                                </asp:DropDownList>
                                            </div>
                                        </td>

                            </tr>
                            </table>
                            </td>
                           
                        </tr>


                          <tr>
                            <td style="font-weight: bold">
                                 OBSERVACION
                            </td>
                            <td colspan='5'>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtObservacion" mode="multiline" runat="server" Width="603px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>

                                         <td style="font-weight: bold">
                                                 Tipo Plan
                                     </td>

                                     <td style="padding-left: 2px" >
                                        <div id="div_TipoPlan" >
                                         <asp:DropDownList ID="ddlTipoPlan" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True" Width="155" BackColor="#FFFF99">
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
                    <table cellpadding="0" cellspacing="0" class="form-inputs" width="650">
                        <tr>
                            <td style="font-weight: bold">
                                Cliente (Razon Social/RUC)
                            </td>
                            <td>
                                <asp:TextBox ID="txtDescripcionConsulta" runat="server" Width="400" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                             <td style="font-weight: bold">
                                Placa
                            </td>
                            <td>
                                <asp:TextBox ID="txtPlacaConsulta" runat="server" Width="80" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>

                             <td style="font-weight: bold">
                                Estado
                            </td>
                            <td>
                                 <div id="div_EstadoConsulta">
                                      <asp:DropDownList ID="ddlEstadoConsulta" runat="server" Font-Names="Arial" ForeColor="Blue"
                                          Font-Bold="True" Width="155" BackColor="#FFFF99">
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

                        <asp:TemplateField HeaderText="Cliente" HeaderStyle-Width="300px">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="hfCliente" Text='<%# Bind("Cliente") %>' CssClass="detallesart"></asp:Label>
                                <%--<asp:HiddenField ID="hfCliente" runat="server" Value='<%# Bind("Cliente") %>' />--%>
                                 <asp:HiddenField ID="hfCodVehiculo" runat="server" Value='<%# Bind("CodVehiculo") %>' />
                                <asp:HiddenField ID="hfCodModeloVehiculo" runat="server" Value='<%# Bind("CodModeloVehiculo") %>' />
                                 
                                  <asp:HiddenField ID="hfCodTipoVehiculo" runat="server" Value='<%# Bind("CodTipoVehiculo") %>' />
                                 <asp:HiddenField ID="hfCodColor" runat="server" Value='<%# Bind("CodColor") %>' />
                                 <asp:HiddenField ID="hfCodMarca" runat="server" Value='<%# Bind("CodMarca") %>' />
                                 <asp:HiddenField ID="hfCodEstado" runat="server" Value='<%# Bind("CodEstado") %>' />
                                  <asp:HiddenField ID="hfCodCliente" runat="server" Value='<%# Bind("CodCliente") %>' />
                                <asp:HiddenField ID="hfPlaca" runat="server" Value='<%# Bind("Placa") %>' />
                                <asp:HiddenField ID="hfChasis" runat="server" Value='<%# Bind("Chasis") %>' />
                                 <asp:HiddenField ID="hfNroMotor" runat="server" Value='<%# Bind("NroMotor") %>' />
                                  <asp:HiddenField ID="hfColor" runat="server" Value='<%# Bind("Color") %>' />
                                <asp:HiddenField ID="hfTipoVehiculo" runat="server" Value='<%# Bind("TipoVehiculo") %>' />
                                <asp:HiddenField ID="hfEstado" runat="server" Value='<%# Bind("Estado") %>' />
                                <asp:HiddenField ID="hfMarca" runat="server" Value='<%# Bind("Marca") %>' />
                                 <asp:HiddenField ID="hfModelo" runat="server" Value='<%# Bind("Modelo") %>' />
                                   <asp:HiddenField ID="hfAnio" runat="server" Value='<%# Bind("Anio") %>' />
                                   <asp:HiddenField ID="hfFechaRevisionTecnica" runat="server" Value='<%# Bind("FechaRevisionTecnica") %>' />
                                    <asp:HiddenField ID="hfFechaVctoSoat" runat="server" Value='<%# Bind("FechaVctoSoat") %>' />
                                     <asp:HiddenField ID="hfRucCliente" runat="server" Value='<%# Bind("RucCliente") %>' />
                                      <asp:HiddenField ID="hfNroFlota" runat="server" Value='<%# Bind("NroFlota") %>' />
                                   <asp:HiddenField ID="hfObservacion" runat="server" Value='<%# Bind("Observacion") %>' />

                                    <asp:HiddenField ID="hfCodTipoPlan" runat="server" Value='<%# Bind("CodTipoPlan") %>' />
                                     <asp:HiddenField ID="hfDistrito" runat="server" Value='<%# Bind("Distrito") %>' />
                                     <asp:HiddenField ID="hfDireccion" runat="server" Value='<%# Bind("Direccion") %>' />
                                     <asp:HiddenField ID="hfRazonSocial" runat="server" Value='<%# Bind("RazonSocial") %>' />
                                     <asp:HiddenField ID="hfCodDistrito" runat="server" Value='<%# Bind("CodDistrito") %>' />
                                      <asp:HiddenField ID="hfCodDepartamento" runat="server" Value='<%# Bind("CodDepartamento") %>' />
                                       <asp:HiddenField ID="hfCodProvincia" runat="server" Value='<%# Bind("CodProvincia") %>' />
                            </ItemTemplate>

                        </asp:TemplateField>

                        <%-- <asp:TemplateField HeaderText="Cliente" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblCliente" Text='<%# Bind("Cliente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                         <asp:TemplateField HeaderText="Placa" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" >
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblPlaca" Text='<%# Bind("Placa") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Chasis" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblChasis" Text='<%# Bind("Chasis") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Motor" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblNroMotor" Text='<%# Bind("NroMotor") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Color" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblColor" Text='<%# Bind("Color") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Tipo" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblTipoVehiculo" Text='<%# Bind("TipoVehiculo") %>'></asp:Label>
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

                         <asp:TemplateField HeaderText="Año" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblAnio" Text='<%# Bind("Anio") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%--  <asp:TemplateField HeaderText="Flota" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblNroFlota" Text='<%# Bind("NroFlota") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <%-- <asp:TemplateField HeaderText="Rev. Tec" HeaderStyle-HorizontalAlign="Center" Visible="false">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblFechaRevisionTecnica" Text='<%# Bind("FechaRevisionTecnica") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                       <%-- <asp:TemplateField HeaderText="Vcto Soat" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblFechaVctoSoat" Text='<%# Bind("FechaVctoSoat") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
--%>
                         <asp:TemplateField HeaderText="Estado" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblEstado" Text='<%# Bind("Estado") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                          <asp:TemplateField HeaderText="Tipo Plan" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblTipoPlan" Text='<%# Bind("TipoPlan") %>'></asp:Label>
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
                DATOS VEHICULO
            </div>
            <div class="ui-jqdialog-content">
               <table cellpadding="0" cellspacing="0" class="form-inputs">
                        <tr>
                            <td style="font-weight: bold">
                            Cliente
                            </td>
                            <td>
                            <table cellpadding="0" cellspacing="0">
                            <tr>
                              <td>
                                  <asp:TextBox ID="txtNroRucEdicion" runat="server" Width="70px" Font-Names="Arial" ForeColor="Blue"
                                      Font-Bold="True" MaxLength="11" onblur="F_ValidaRucDniEdicion(); return false;"></asp:TextBox>
                              </td>
                              <td id="td_loadingEdicion" style="font-weight: bold; padding-left: 5px; display: none">
                                  <img src="../Asset/images/loading.gif" />
                              </td>
                              <td id="div_ClienteEdicion">
                                  <asp:TextBox ID="txtClienteEdicion" runat="server" Width="310px" Font-Names="Arial" ForeColor="Blue"
                                      Font-Bold="True"></asp:TextBox>
                              </td>
                              <td style="font-weight: bold">
                                  Distrito
                              </td>
                              <td   style="padding-left: 5px;" >
                                  <asp:TextBox ID="txtDistritoEdicion" runat="server" Width="370px" Font-Names="Arial" ForeColor="Blue"
                                      Font-Bold="True"></asp:TextBox>
                              </td>

                            </tr>
                            </table>
                            </td>
                           
                        </tr>

                          <tr>

                          <td style="font-weight: bold">
                            Direccion
                            </td>

                            <td>
                            <table cellpadding="0" cellspacing="0">
                            <tr>
                              <td>
                                   <asp:TextBox Style="width: 388px; position: absolute; color: blue; font-family: Arial;
                                       font-weight: bold; background: rgb(255, 255, 224);" ID="txtDireccionEdicion" runat="server"
                                       autocomplete="off"></asp:TextBox>
                                   <asp:DropDownList ID="ddlDireccionEdicion" Style="width: 388px" runat="server">
                                   </asp:DropDownList>
                               </td>


                              <td style="font-weight: bold; padding-left: 6px;">
                                  Placa
                              </td>
                              <td   style="padding-left: 17px;" >
                                  <asp:TextBox ID="txtPlacaEdicion" runat="server" Width="60px" Font-Names="Arial" ForeColor="Blue"
                                      Font-Bold="True"></asp:TextBox>
                              </td>

                               <td style="font-weight: bold; padding-left: 6px;">
                                  Chasis
                              </td>
                              <td   style="padding-left: 15px;" >
                                  <asp:TextBox ID="txtChasisEdicion" runat="server" Width="160px" Font-Names="Arial" ForeColor="Blue"
                                      Font-Bold="True"></asp:TextBox>
                              </td>
                                <td style="font-weight: bold; padding-left: 6px;">
                                  Año
                              </td>
                              <td   style="padding-left: 15px;" >
                                  <asp:TextBox ID="txtAnioEdicion" runat="server" Width="34px" Font-Names="Arial" ForeColor="Blue"
                                      Font-Bold="True"></asp:TextBox>
                              </td>


                            </tr>
                            </table>
                            </td>
                           
                        </tr>

                          <tr>

                          <td style="font-weight: bold">
                            Color
                            </td>

                            <td>
                            <table cellpadding="0" cellspacing="0">
                            <tr>
                             <td >
                                            <div id="div_ColorEdicion">
                                                <asp:DropDownList ID="ddlColorEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="155" BackColor="#FFFF99">
                                                </asp:DropDownList>
                                            </div>
                                        </td>



                    <td style="font-weight: bold;padding-left: 4px;">
                                  Motor     
                              </td    >
                               <td colspan='5' style="padding-left: 20px;">
                                <asp:TextBox ID="txtNroMotorEdicion" runat="server" Width="168px" Font-Names="Arial"
                                    Font-Bold="True" ForeColor="Blue"></asp:TextBox>
                            </td>
                                 
                              <td style="font-weight: bold; padding-left: 6px;">
                                 Marca
                            </td>

                               <td  style="padding-left: 10px;">
                                            <div id="div_MarcaEdicion">
                                                <asp:DropDownList ID="ddlMarcaEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="157" BackColor="#FFFF99">
                                                </asp:DropDownList>
                                            </div>
                                </td>



                               <td style="font-weight: bold;padding-left: 4px;">
                                Modelo
                                </td>
                                 <td style="padding-left: 11px;" >
                                            <div id="div_ModeloEdicion">
                                                <asp:DropDownList ID="ddlModeloEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="155" BackColor="#FFFF99">
                                                </asp:DropDownList>
                                            </div>
                                        </td>


                            </tr>
                            </table>
                            </td>
                           
                        </tr>


                             <tr>

                          <td style="font-weight: bold">
                         Tipo
                            </td>

                            <td>
                            <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="padding-left: 2px;" >
                                            <div id="div_TipoEdicion">
                                                <asp:DropDownList ID="ddlTipoEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="155" BackColor="#FFFF99">
                                                </asp:DropDownList>
                                            </div>
                                        </td>

                                 <td style="font-weight: bold;padding-left: 2px;">
                                 Vcto Soat
                            </td>
                                        <td style="font-weight: bold;" >
                                  <asp:TextBox ID="txtVencimientoSoatEdicion" runat="server" Width="52px" Font-Names="Arial" CssClass="Jq-ui-dtp"
                                      ReadOnly="true" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                              </td>



                              <td style="font-weight: bold;padding-left: 5px;">
                                    Revision
                              </td    >
                              <td style="font-weight: bold;padding-left: 4px;" >
                                  <asp:TextBox ID="txtRevisionEdicion" runat="server" Width="52px" Font-Names="Arial" CssClass="Jq-ui-dtp"
                                      ReadOnly="true" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                              </td>

                              <td style="font-weight: bold;padding-left: 4px;">
                                       Flota
                              </td    >
                               <td   style="padding-left: 15px;" >
                                  <asp:TextBox ID="txtFlotaEdicion" runat="server" Width="155px" Font-Names="Arial" ForeColor="Blue"
                                      Font-Bold="True"></asp:TextBox>
                              </td>


                             <td style="font-weight: bold">
                                              ESTADO 
                                        </td>
                                          <td style="padding-left: 15px;" >
                                            <div id="div_EstadoEdicion">
                                                <asp:DropDownList ID="ddlEstadoEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="155" BackColor="#FFFF99">
                                                </asp:DropDownList>
                                            </div>
                                        </td>

                            </tr>
                            </table>
                            </td>
                           
                        </tr>


                          <tr>
                            <td style="font-weight: bold">
                                 OBSERVACION
                            </td>
                            <td colspan='5'>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtObservacionEdicion" mode="multiline" runat="server" Width="603px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                     </td>
                                     <td style="font-weight: bold">
                                                 Tipo Plan
                                     </td>

                                     <td>
                                        <div id ="div_TipoPlanEdicion" >
                                         <asp:DropDownList ID="ddlTipoPlanEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True" Width="155" BackColor="#FFFF99">
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
    <input id="hfCodCtaCte" type="hidden" value="0" />
    <input id="hfRegion" type="hidden" value="0" />
    <input id="hfProvincia" type="hidden" value="0" />
    <input id="hfDistrito" type="hidden" value="0" />
    <input id="hfRegionEdicion" type="hidden" value="0" />
    <input id="hfProvinciaEdicion" type="hidden" value="0" />
    <input id="hfMoneda" type="hidden" value="0" />
    <input id="hfCodDireccion" type="hidden" value="0" />
    <input id="hfCodContacto" type="hidden" value="0" />
    <input id="hfUbigeo" type="hidden" value="0" />
    <input id="hfurlapisunat" type="hidden" value="0" />
    <input id="hftokenapisunat" type="hidden" value="0" />



    <input id="hfCodCtaCteEdicion" type="hidden" value="0" />
    <input id="hfCodCtaCteConsulta" type="hidden" value="0" />
    <input id="hfCodigoTemporal" type="hidden" value="0" />
    <input id="hfCodCtaCteNP" type="hidden" value="0" />
    <input id="hfCodUsuario" type="hidden" value="0" />
    <input id="hfCodDepartamento" type="hidden" value="0" />
    <input id="hfCodProvincia" type="hidden" value="0" />
    <input id="hfCodDistrito" type="hidden" value="0" />
    <input id="hfCodProforma" type="hidden" value="0" />
    <input id="hfPartida" type="hidden" value="" />
    <input id="hfCodSede" type="hidden" value="0" />
     <input id="hfCodVehiculo" type="hidden" value="0" />
    <input id="hfCodTipoCliente" type="hidden" value="2" />
    <input id="hfNroRuc" type="hidden" value="" />
    <input id="hfDireccion" type="hidden" value="" />
    <input id="hfCliente" type="hidden" value="" />

     <input id="hfCodDepartamentoEdicion" type="hidden" value="0" />
     <input id="hfCodProvinciaEdicion" type="hidden" value="0" />
     <input id="hfCodDistritoEdicion" type="hidden" value="0" />
     <input id="hfDireccionEdicion" type="hidden" value="" />
       <input id="hfDistritoEdicion" type="hidden" value="" />
    <input id="hfNroRucEdicion" type="hidden" value="" />
    <input id="hfClienteEdicion" type="hidden" value="" />



</asp:Content>
