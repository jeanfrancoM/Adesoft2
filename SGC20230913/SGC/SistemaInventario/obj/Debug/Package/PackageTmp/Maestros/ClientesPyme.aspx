<%@ Page Title="Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientesPyme.aspx.cs" Inherits="SistemaInventario.Maestros.ClientesPyme" %>
   
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"  type="text/javascript"></script>      
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>    
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript" charset="UTF-8"></script>
    <script type="text/javascript" language="javascript" src="ClientesPyme.js" charset="UTF-8"></script>
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet" type="text/css" />       
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
      <link href="../Asset/toars/toastr.min.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/toars/toastr.min.js" type="text/javascript"></script>
    <script src="../Scripts/inputatajos/kibo.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo">
        Clientes</div>
    <div id="divTabs">
        <ul>
            <li id="liRegistro"><a href="#tabRegistro">Registro</a></li>
            <li id="liConsulta"><a href="#tabConsulta" onclick="getContentTab();">Consulta</a></li>
        </ul>
        <div id="tabRegistro">
            <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 640px">
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    REGISTRO DE Clientes
                </div>
                <div>
                    <table cellpadding="0" cellspacing="0" class="form-inputs">
                        <tr>
                            <td style="font-weight: bold">
                                Tipo de Cliente
                            </td>
                            <td>
                            <table cellpadding="0" cellspacing="0">
                            <tr>
                             <td>
                                <div id="div_TipoCliente">
                                    <asp:DropDownList ID="ddlTipoCliente" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True">
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td style="padding-left: 50px; font-weight: bold">
                                Nro Ruc
                            </td>
                            <td style="padding-left: 18px;">
                                <asp:TextBox ID="txtNroRuc" runat="server" Width="85px" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True" MaxLength="11" onblur="F_ValidaRucDni();"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold">
                                Nro Dni
                            </td>
                            <td style="padding-left: 18px;">
                                <asp:TextBox ID="txtNroDni" runat="server" Width="100px" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True" MaxLength="8"></asp:TextBox>
                            </td>
                            </tr>
                            </table>
                            </td>
                           
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                CLIENTE
                            </td>
                            <td colspan='5' style="padding-left: 4px;">
                                <asp:TextBox ID="txtRazonSocial" runat="server" Width="500px" Font-Names="Arial"
                                    Font-Bold="True" ForeColor="Blue" onblur="F_ValidaCuentaCorriente();"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Nom. Comercial
                            </td>
                            <td colspan='5' style="padding-left: 4px;">
                                <asp:TextBox ID="txtNombreComercial" runat="server" Width="500px" Font-Names="Arial"
                                    Font-Bold="True" ForeColor="Blue"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="display:none">
                            <td style="font-weight: bold">
                                Apellido Paterno
                            </td>
                            <td colspan='5'>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtApellidoPaterno" runat="server" Width="219px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            Materno
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtApellidoMaterno" runat="server" Width="219px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr style="display:none">
                            <td style="font-weight: bold">
                                Nombres
                            </td>
                            <td colspan='5'>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtNombres" runat="server" Width="500px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Distrito
                            </td>
                            <td colspan='5'>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtDistrito" runat="server" Width="500px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                 <td style="display:none">
                                            Vendedor
                                        </td>
                                        <td style="display:none">
                                            <div id="div_Vendedor">
                                                <asp:DropDownList ID="ddlVendedor" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="115" BackColor="#FFFF99">
                                                </asp:DropDownList>
                                            </div>
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
                             <td style="padding-left: 2px;" colspan='5'>
                                <asp:TextBox ID="txtDireccion" runat="server" Width="500px" Font-Names="Arial" Font-Bold="True"
                                    ForeColor="Blue"></asp:TextBox>
                            </td>
                                 <td style="display:none">
                                            Zona
                                        </td>
                                        <td style="display:none">
                                            <div id="div_Zona">
                                                <asp:DropDownList ID="ddlZona" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="145" BackColor="#FFFF99">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                            </tr>
                            </table>
                            </td>
                           
                        </tr>
                          <tr>
                            <td style="font-weight: bold">
                                GPS
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                       
                                        <td style="display:none">
                                            <asp:TextBox ID="txtGPSLong" runat="server" Width="100px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" MaxLength="14" Font-Size="Small"></asp:TextBox>
                                        </td>
                                       
                                        <td style="display:none">
                                            <asp:TextBox ID="txtGPSLat" runat="server" Width="100px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" MaxLength="14" Font-Size="Small"></asp:TextBox>
                                        </td>
                                         <td style="padding-left: 2px; font-weight: bold">
                                            <asp:TextBox ID="txtGPSLongLat" runat="server" Width="500px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"  Font-Size="Small"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr style="display:none">
                            <td style="font-weight: bold">
                                Direccion Envio
                            </td>
                            <td style="padding-left: 4px;" colspan='5'>
                                <asp:TextBox ID="txtDireccionEnvio" runat="server" Width="500px" Font-Names="Arial"
                                    Font-Bold="True" ForeColor="Blue"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="display:none">
                            <td style="font-weight: bold">
                                Email
                            </td>
                            <td colspan='5'>
                            <table cellpadding="0" cellspacing="0">
                            <tr>

                            <td style="padding-left: 2px;">
                                <asp:TextBox ID="txtEmail" runat="server" Width="350px" Font-Names="Arial" Font-Bold="True"
                                    ForeColor="Blue"></asp:TextBox>
                            </td>
                             
                            </tr>
                            </table>
                            </td>
                            
                        </tr>
                        <tr style="display:none">
                            <td style="font-weight: bold">
                                Linea Credito
                            </td>
                            <td colspan='5'>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="padding-left: 2px;" colspan='5'>
                                            <asp:TextBox ID="txtLineaCredito" runat="server" Width="80px" Font-Names="Arial"
                                                Font-Bold="True" ForeColor="Blue" CssClass="Derecha"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold;padding-left:2px;">
                                            Moneda
                                        </td>
                                        <td style="padding-left:3px;">
                                            <div id="div_moneda">
                                                <asp:DropDownList ID="ddlMoneda" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="72" BackColor="#FFFF99">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                        <td>
                                <asp:CheckBox ID="chkFlagBloqueoCredito" runat="server" Text="BLOQUEO CREDITO"
                                    Font-Bold="True" />
                            </td>
                                        <td style="font-weight: bold">
                                            Categoria
                                        </td>
                                        <td>
                                            <div id="div_Categoria">
                                                <asp:DropDownList ID="ddlCategoria" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="105" BackColor="#FFFF99">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                    
                                </table>
                            </td>
                        </tr>
                        <tr style="display:none">
                          <td style="font-weight: bold; padding-left: 5px">
                                DG
                            </td>
                        <td>
                        <table>
                      <tr style="display:none">
                      <td style="padding-left: 0px">
                                <asp:TextBox ID="txtD1" runat="server" Width="65px" Font-Names="Arial"
                                   CssClass="Derecha"   ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold; padding-left: 16px">
                                DM
                            </td>
                            <td style="padding-left: 10px">
                                <asp:TextBox ID="txtD2" runat="server" Width="65px" Font-Names="Arial"
                                   CssClass="Derecha"   ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                              <td>
                                <asp:CheckBox ID="chkRetencion" runat="server" Text="Retencion"
                                    Font-Bold="True" />
                            </td>
                            <td style="font-weight: bold; padding-left: 16px;display:none;">
                               D3
                            </td>
                            <td style="padding-left: 10px;display:none;">
                                <asp:TextBox ID="txtD3" runat="server" Width="60px" Font-Names="Arial"
                                   CssClass="Derecha"   ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>

                      </tr>
                      
            <tr>  
                   
                        </table>
                        </td>
                        </tr>
                    </table>
                </div>
                   <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    DATOS DE CONTACTO
                </div>

                <div>
                <table cellpadding="0" cellspacing="0" class="form-inputs">
                   <tr>

                <td style="font-weight: bold">
                    Nombre
                </td>
                <td style="padding-left: 32px;">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="padding-left: 14px;" colspan='5'>
                                <asp:TextBox ID="txtNombreContactoRegistro" runat="server" Width="500px" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
           
            <tr>
              
                   <td style="font-weight: bold; padding-left: 2px">
                                Celular 
                            </td>
                <td style="padding-left: 32px;">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                        
                            
                            <td style="padding-left: 14px">
                                <asp:TextBox ID="txtCelular1ContactoRegistro" runat="server" Width="210px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                              <td style="padding-left: 25px;font-weight: bold">
                    Correo 
                                    </td>
                            <td>
                                <asp:TextBox ID="txtCorreo1ContactoRegistro" runat="server" Width="210px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="display:none">
                                Correo 2
                            </td>
                            <td style="display:none">
                                <asp:TextBox ID="txtCorreo2ContactoRegistro" runat="server" Width="210px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>

        <tr>
                <td style="display:none">
                    Area
                </td>
                <td style="padding-left: 32px;">
                    <table cellpadding="0" cellspacing="0">
                        <tr style="display:none">
                            <td>
                                <asp:TextBox ID="txtAreaContactoRegistro" runat="server" Width="210px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold; padding-left: 5px">
                                Telefono
                            </td>
                            <td style="padding-left: 12px">
                                <asp:TextBox ID="txtTelefonoContactoRegistro" runat="server" Width="210px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
                <td style="display:none">
                    Correo 3
                </td>
                <td style="display:none">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="display:none">
                                <asp:TextBox ID="txtCorreo3ContactoRegistro" runat="server" Width="210px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                         
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="display:none">
                    Celular 2
                </td>
                <td style="display:none">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="txtCelular2ContactoRegistro" runat="server" Width="210px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold; padding-left: 5px">
                                Celular 3
                            </td>
                            <td style="padding-left: 10px">
                                <asp:TextBox ID="txtCelular3ContactoRegistro" runat="server" Width="210px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="display:none">
                <td style="font-weight: bold">
                    Estado
                </td>
                <td style="padding-left: 32px;">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <div id="div_ContactoEstadoRegistro">
                                    <asp:DropDownList ID="ddlContactoEstadoRegistro" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True">
                                        <asp:ListItem Value="1">Activo</asp:ListItem>
                                        <asp:ListItem Value="2">Inativo</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkContactoReporteRegistro" runat="server" Text="Mostrar en Reporte"
                                    Font-Bold="True" />
                            </td>
                            
                        </tr>
                    </table>
                </td>
            </tr>
                </table>
                </div>
                <div class="linea-button">
                    <%--<asp:CheckBox ID="chkProveedor" runat="server" Text="Proveedor" Font-Bold="True" />
                    <asp:HyperLink ID="HyperLink1" Target="_blank" runat="server" ForeColor="Blue" Text="CONSULTA RUC SUNAT"
                        NavigateUrl="http://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias">CONSULTA RUC SUNAT</asp:HyperLink>--%>
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
                                Descripcion (Razon Social/RUC)
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
                    CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="1005px">
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
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgDireccion" ImageUrl="../Asset/images/add_small.png"
                                    ToolTip="DIRECCION" OnClientClick="F_Direccion(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgContactos" ImageUrl="../Asset/images/User.png"
                                    ToolTip="CONTACTO" OnClientClick="F_Contactos(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                   <%--     <asp:TemplateField HeaderText="ID" HeaderStyle-Width="15px">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblcodigo" Text='<%# Bind("Codigo") %>' ></asp:Label>
                               
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Documento" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="50px">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDocumento" Text='<%# Bind("Documento") %>' CssClass="detallesart"></asp:Label>
                                 <asp:HiddenField ID="hfCodigo" runat="server" Value='<%# Bind("Codigo") %>' />
                                 <asp:HiddenField ID="hfDepartamento" runat="server" Value='<%# Bind("DscDepartamento") %>' />
                                <asp:HiddenField ID="hfProvincia" runat="server" Value='<%# Bind("DscProvincia") %>' />
                                <asp:HiddenField ID="hfDireccionEnvio" runat="server" Value='<%# Bind("DireccionEnvio") %>' />
                                <asp:HiddenField ID="hfApePaterno" runat="server" Value='<%# Bind("ApePaterno") %>' />
                                <asp:HiddenField ID="hfApeMaterno" runat="server" Value='<%# Bind("ApeMaterno") %>' />
                                <asp:HiddenField ID="hfNombres" runat="server" Value='<%# Bind("Nombres") %>' />
                                <asp:HiddenField ID="hfNroRuc" runat="server" Value='<%# Bind("NroRuc") %>' />
                                <asp:HiddenField ID="hfNroDni" runat="server" Value='<%# Bind("NroDni") %>' />
                                <asp:HiddenField ID="hfCodTipoCliente" runat="server" Value='<%# Bind("CodTipoCliente") %>' />
                                <asp:HiddenField ID="hfCodDepartamento" runat="server" Value='<%# Bind("CodDepartamento") %>' />
                                <asp:HiddenField ID="hfCodProvincia" runat="server" Value='<%# Bind("CodProvincia") %>' />
                                <asp:HiddenField ID="hfCodDistrito" runat="server" Value='<%# Bind("CodDistrito") %>' />
                                <asp:HiddenField ID="hfRazonSocial" runat="server" Value='<%# Bind("RazonSocial") %>' />
                                <asp:HiddenField ID="hfEmail" runat="server" Value='<%# Bind("Email") %>' />
                                <asp:HiddenField ID="hfLineaCredito" runat="server" Value='<%# Bind("LineaCredito") %>' />
                                <asp:HiddenField ID="hfDeudaCredito" runat="server" Value='<%# Bind("DeudaCredito") %>' />
                                <asp:HiddenField ID="hfCodMonedaLineaCredito" runat="server" Value='<%# Bind("CodMonedaLineaCredito") %>' />
                                <asp:HiddenField ID="hfCodCategoria" runat="server" Value='<%# Bind("CodCategoria") %>' />
                                <asp:HiddenField ID="hfNombreComercial" runat="server" Value='<%# Bind("NombreComercial") %>' />
                                <asp:HiddenField ID="hfFlagBloqueoCredito" runat="server" Value='<%# Bind("FlagBloqueoCredito") %>' />
                                <asp:HiddenField ID="hfCodZona" runat="server" Value='<%# Bind("CodZona") %>' />
                                <asp:HiddenField ID="hfCodVendedor" runat="server" Value='<%# Bind("CodVendedor") %>' />
                                <asp:HiddenField ID="hfFlagRetencion" runat="server" Value='<%# Bind("FlagRetencion") %>' />
                                <asp:HiddenField ID="hfD1" runat="server" Value='<%# Bind("D1") %>' />
                                <asp:HiddenField ID="hfD2" runat="server" Value='<%# Bind("D2") %>' />
                                <asp:HiddenField ID="hfD3" runat="server" Value='<%# Bind("D3") %>' />
                                <asp:HiddenField ID="hfRetencion" runat="server" Value='<%# Bind("Retencion") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cliente" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblCliente" Text='<%# Bind("Cliente") %>'></asp:Label>
                            </ItemTemplate>
                      </asp:TemplateField>
                          <%--     <asp:BoundField DataField="Categoria" HeaderText="Categoria" HeaderStyle-Width="50px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>--%>
                                 <asp:TemplateField HeaderText="Nombre Comercial" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblNombreComercial" Text='<%# Bind("NombreComercial") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Retencion" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblRetencion" Text='<%# Bind("Retencion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <%--<asp:TemplateField HeaderText="Celular" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblCelular1" Text='<%# Bind("Celular1") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                    </Columns>
                </asp:GridView>
            </div>
             <div style="padding-top: 5px;">
               <table cellpadding="0" cellspacing="0" align="center">
                                    <tr>
                                        <td style="font-weight: bold">
                                           Cantidad de Registros:
                                        </td>
                                        <td style="font-weight: bold">
                                            <label id="lblNumeroConsultaDetalle" text="0">0</label>
                                        </td>                                
                                    </tr>
                                </table>
            </div>
             <div id="div_consultaDetalle" style="padding-top: 5px; width: 1080px">
                <asp:GridView ID="grvConsultaDetalle" runat="server" AutoGenerateColumns="False"
                    border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                    Width="1005px" OnRowDataBound="grvConsultaDetalle_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="PRI" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgPrincipal" ImageUrl="../Asset/images/Circle_Yellow.png"
                                    ToolTip="Activar/Desactivar" OnClientClick="F_ElegirPrincipalDireccion(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="A/I" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40px">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgActivarRegistro" ImageUrl="../Asset/images/poweron.png"
                                    Height="15px" Width="28px" ToolTip="ACTIVO: PRESIONES PARA INACTIVAR" OnClientClick="F_ActivarRegistroDireccion(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="COP" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgCopiar" ImageUrl="../Asset/images/historial.png"
                                    Width="16px" Height="16px" ToolTip="Copiar Direccion GPS" OnClientClick="F_CopiarDireccionGPS(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="GPS" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgAbrir" ImageUrl="../Asset/images/gpsgoogleiconx36.png"
                                    Width="16px" Height="16px" ToolTip="Abrir Direccion GPS" OnClientClick="F_AbrirDireccionGPS(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                    ToolTip="Eliminar Direccion" OnClientClick="F_EliminarDireccion(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgEditarRegistro" ImageUrl="../Asset/images/btnEdit.gif"
                                    ToolTip="Editar Direccion" OnClientClick="F_EditarRegistroDireccion(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgEditarRegistroCorreo" ImageUrl="../Asset/images/Mail1.png"
                                    ToolTip="Editar Correo" OnClientClick="F_EditarRegistroCorreo(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                       <%-- <asp:TemplateField HeaderText="Est" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblEstado" Text='<%# Bind("Estado") %>' CssClass="detallesart"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                           <asp:TemplateField HeaderText="C">
                            <ItemTemplate>
                                <img id="imgMasCorreo" alt="" style="cursor: pointer" src="../Asset/images/plus.gif"
                                    onclick="imgMasCorreo_Click(this);" title="Correo" />
                                <asp:Panel ID="pnlOrdersCorreo" runat="server" Style="display: none">
                                    <asp:GridView ID="grvDetalleCorreo" runat="server" border="0" CellPadding="0"
                                        CellSpacing="1" AutoGenerateColumns="False" GridLines="None" class="GridView">
                                        <Columns>
                                            <asp:BoundField DataField="Correo" HeaderText="Correo">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Distrito" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDistrito" Text='<%# Bind("Distrito") %>'  CssClass="detallesart"></asp:Label>
                                <asp:HiddenField ID="hfCodigo" runat="server" Value='<%# Bind("CodDireccion") %>' />
                                <asp:HiddenField ID="hfPrincipal" runat="server" Value='<%# Bind("Principal") %>' />
                                <asp:HiddenField ID="hfCodDistrito" runat="server" Value='<%# Bind("CodDistrito") %>' />
                                <asp:HiddenField ID="hfCodDepartamento" runat="server" Value='<%# Bind("CodDepartamento") %>' />
                                <asp:HiddenField ID="hfCodProvincia" runat="server" Value='<%# Bind("CodProvincia") %>' />
                                <asp:HiddenField ID="hfCodEstado" runat="server" Value='<%# Bind("CodEstado") %>' />
                                <asp:HiddenField ID="hfEmail" runat="server" Value='<%# Bind("Email") %>' />
                                <asp:HiddenField ID="hfEmail2" runat="server" Value='<%# Bind("Email2") %>' />
                                <asp:HiddenField ID="hfEmail3" runat="server" Value='<%# Bind("Email3") %>' />
                                <asp:HiddenField ID="hfEmail4" runat="server" Value='<%# Bind("Email4") %>' />
                                <asp:HiddenField ID="hfEmail5" runat="server" Value='<%# Bind("Email5") %>' />
                                <asp:HiddenField ID="hfEmail6" runat="server" Value='<%# Bind("Email6") %>' />
                                <asp:HiddenField ID="hfTelefono" runat="server" Value='<%# Bind("Telefono") %>' />
                                <asp:HiddenField ID="hfReferencia" runat="server" Value='<%# Bind("Referencia") %>' />
                                <asp:HiddenField ID="hfContacto" runat="server" Value='<%# Bind("Contacto") %>' />
                                <asp:HiddenField ID="hfDestino" runat="server" Value='<%# Bind("Destino") %>' />
                                <asp:HiddenField ID="hfCodRutaDespacho" runat="server" Value='<%# Bind("CodRutaDespacho") %>' />
                                <asp:HiddenField ID="hfCodRutaDespachoHermana" runat="server" Value='<%# Bind("CodRutaDespachoHermana") %>' />
                                <asp:HiddenField ID="hfGPSLong" runat="server" Value='<%# Bind("GPSLong") %>' />
                                <asp:HiddenField ID="hfGPSLat" runat="server" Value='<%# Bind("GPSLat") %>' />
                                <asp:HiddenField ID="hfGPSDireccion" runat="server" Value='<%# Bind("GPSDireccion") %>' />
                                <asp:HiddenField ID="hfCodTransportista" runat="server" Value='<%# Bind("CodTransportista") %>' />
                                <asp:HiddenField ID="hfTransportista" runat="server" Value='<%# Bind("Transportista") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Direccion" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDireccion" Text='<%# Bind("Direccion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="Destino" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDestino" Text='<%# Bind("Destino") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Referencia" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblReferencia" Text='<%# Bind("Referencia") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Contacto" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblContacto" Text='<%# Bind("Contacto") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Telefono" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblTelefono" Text='<%# Bind("Telefono") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        
                    </Columns>
                </asp:GridView>
            </div>
             <div style="padding-top: 5px;">
               <table cellpadding="0" cellspacing="0" align="center">
                                    <tr>
                                        <td style="font-weight: bold">
                                           Cantidad de Registros:
                                        </td>
                                        <td style="font-weight: bold">
                                            <label id="lblNumeroConsultaContacto" text="0">0</label>
                                        </td>                                
                                    </tr>
                                </table>
            </div>
            <div id="div_ContactosGrid">
                        <asp:GridView ID="grvContactos" runat="server" AutoGenerateColumns="False" border="0"
                            CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="1005px" 
                            OnRowDataBound="grvConsultaContacto_RowDataBound">
                            <Columns>
                               <asp:TemplateField HeaderText="A/I" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40px">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgActivarRegistroContacto" ImageUrl="../Asset/images/poweron.png"
                                    Height="15px" Width="28px" ToolTip="ACTIVO: PRESIONES PARA INACTIVAR" OnClientClick="F_ActivarRegistroContacto(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                                <asp:TemplateField HeaderText="ELI" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40px" >
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgAnularContacto" ImageUrl="~/Asset/images/EliminarBtn.png"
                                            ToolTip="Eliminar Contacto" OnClientClick="F_EliminarContacto(this); return false;" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="EDI" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40px">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgEditarContacto" ImageUrl="../Asset/images/btnEdit.gif"
                                            ToolTip="Editar Contacto" OnClientClick="F_EditarContactos(this); return false;" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                              <%--  <asp:TemplateField HeaderText="ID">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Datos Personales" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblDatosPersonales" Text='<%# Bind("DatosPersonales") %>'  CssClass="detallesart"></asp:Label>
                                        <asp:HiddenField ID="lblCodContacto" runat="server" Value='<%# Bind("CodContacto") %>' />
                                        <asp:HiddenField ID="hfCodCtaCte" runat="server" Value='<%# Bind("CodCtaCte") %>' />
                                        <asp:HiddenField ID="hfCodEstado" runat="server" Value='<%# Bind("CodEstado") %>' />
                                        <asp:HiddenField ID="hfFlag_MostrarEnReporte" runat="server" Value='<%# Bind("Flag_MostrarEnReporte") %>' />
                                        <asp:HiddenField ID="hfEstado" runat="server" Value='<%# Bind("Estado") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <%-- <asp:TemplateField HeaderText="Area" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblArea" Text='<%# Bind("Area") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                              <%--  <asp:TemplateField HeaderText="Telef" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblTelefono" Text='<%# Bind("Telefono") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                               <%-- <asp:TemplateField HeaderText="Correo" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCorreo1" Text='<%# Bind("Correo1") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                               <%-- <asp:TemplateField HeaderText="Correo2" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCorreo2" Text='<%# Bind("Correo2") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Correo3" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCorreo3" Text='<%# Bind("Correo3") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Celular" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCelular1" Text='<%# Bind("Celular1") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              <%--  <asp:TemplateField HeaderText="Celular 2" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCelular2" Text='<%# Bind("Celular2") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Celular 3" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCelular3" Text='<%# Bind("Celular3") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <%--<asp:TemplateField HeaderText="Estado" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblEstado" Text='<%# Bind("Estado") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </div>
        </div>
    </div>
    <div id="divEdicionRegistro" style="display: none;">
        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                DATOS CLIENTE
            </div>
            <div class="ui-jqdialog-content">
                <table cellpadding="0" cellspacing="0" class="form-inputs">
                 <tr>
                        <td style="font-weight: bold">
                          Tipo de Cliente
                        </td>
                        <td>
                        <table cellpadding="0" cellspacing="0">
                        <tr>
                        <td colspan='5' style="padding-left: 4px;">
                           <div id="div_tipoclienteedicion">
                                <asp:DropDownList ID="ddlTipoCliente_Edicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True">
                                </asp:DropDownList>
                            </div>
                        </td>
                        <td style="padding-left: 45px; font-weight: bold">
                            Nro Ruc
                        </td>
                        <td style="padding-left: 15px;">
                            <asp:TextBox ID="txtRucEdicion" runat="server" Width="82px" Font-Names="Arial" ForeColor="Blue"
                                Font-Bold="True" MaxLength="11"></asp:TextBox>
                        </td>
                                     <td style="padding-left: 45px; font-weight: bold">
                            Nro Dni
                        </td>
                        <td style="padding-left: 10px;">
                            <asp:TextBox ID="txtDniEdicion" runat="server" Width="75px" Font-Names="Arial" ForeColor="Blue"
                                Font-Bold="True" MaxLength="8"></asp:TextBox>
                        </td>
                                        </tr>
                        </table>
                        </td>
                        
                    </tr>
                    <tr>
                        <td style="font-weight: bold">
                            CLIENTE
                        </td>
                        <td>
                        <table cellpadding="0" cellspacing="0">
                        <tr>
                        <td colspan='5' style="padding-left: 4px;">
                            <asp:TextBox ID="txtRazonSocialEdicion" runat="server" Width="500px" Font-Names="Arial"
                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </td>
                        <td style="display:none">
                                            Ven.
                                        </td>
                                        <td style="display:none">
                                            <div id="div_VendedorEdicion">
                                                <asp:DropDownList ID="ddlVendedorEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="109" BackColor="#FFFF99">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                        </tr>
                        </table>
                        </td>
                        
                    </tr>
                     <tr>
                        <td style="font-weight: bold">
                            NOM. COMERCIAL
                        </td>
                        <td colspan='5' >
                        <table cellpadding="0" cellspacing="0">
                        <tr>
                         <td style="padding-left: 2px;">
                            <asp:TextBox ID="txtNombreComercialEdicion" runat="server" Width="500px" Font-Names="Arial"
                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </td>

                          <td style="display:none">
                                            Zona
                                        </td>
                                        <td style="display:none">
                                            <div id="div_ZonaEdicion">
                                                <asp:DropDownList ID="ddlZonaEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="105" BackColor="#FFFF99">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                        </tr>
                        </table>
                        </td>
                       
                    </tr>
                    <tr style="display:none">
                        <td style="font-weight: bold">
                            Apellido Paterno
                        </td>
                        <td colspan='5'>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtApellidoPaternoEdicion" runat="server" Width="219px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                    <td style="font-weight: bold">
                                        Materno
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtApellidoMaternoEdicion" runat="server" Width="219px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="display:none">
                        <td style="font-weight: bold">
                            Nombres
                        </td>
                        <td colspan='5'>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtNombreEdicion" runat="server" Width="500px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; display: none">
                            Distrito
                        </td>
                        <td colspan='5' style="display: none">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtDistritoEdicion" runat="server" Width="500px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; display: none">
                            Direccion
                        </td>
                        <td style="padding-left: 4px; display: none" colspan='5'>
                            <asp:TextBox ID="txtDireccionEdicion" runat="server" Width="500px" Font-Names="Arial"
                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display:none">
                        <td style="font-weight: bold; display: none">
                            Direccion Envio
                        </td>
                        <td style="padding-left: 4px; display: none" colspan='5'>
                            <asp:TextBox ID="txtDireccionEnvioEdicion" runat="server" Width="500px" Font-Names="Arial"
                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; display: none">
                            Email
                        </td>
                        <td style="padding-left: 4px; display: none" colspan='5'>
                            <asp:TextBox ID="txtEmailEdicion" runat="server" Width="500px" Font-Names="Arial"
                                Font-Bold="True" ForeColor="Blue"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="display:none">
                            Linea Credito
                        </td>
                        <td colspan='5' style="display:none">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="padding-left: 2px;" colspan='5'>
                                        <asp:TextBox ID="txtLineaCreditoEdicion" runat="server" Width="80px" Font-Names="Arial"
                                            Font-Bold="True" ForeColor="Blue" CssClass="Derecha"></asp:TextBox>
                                    </td>
                                    <td style="font-weight: bold;padding-left:2px;">
                                        Moneda
                                    </td>
                                    <td style="padding-left:3px;">
                                        <div id="div_monedaEdicion">
                                            <asp:DropDownList ID="ddlMonedaEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" Width="75" BackColor="#FFFF99">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                       <td>
                                <asp:CheckBox ID="chkFlagBloqueoCreditoEdicion" runat="server" Text="BLOQUEO CREDITO"
                                    Font-Bold="True" />
                            </td>
                                                  <td style="font-weight: bold">
                                            Categoria
                                        </td>
                                        <td>
                                            <div id="div_CategoriaEdicion">
                                                <asp:DropDownList ID="ddlCategoriaEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="102" BackColor="#FFFF99">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                    <td style="display:none">
                                DG
                            </td>

                            <td >
                             <table cellpadding="0" cellspacing="0">
                             <tr>
                            <td style="display:none">
                           
                                <asp:TextBox ID="txtD1EnReporte" runat="server" Width="82px" Font-Names="Arial"
                                  CssClass="Derecha"    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="display:none">
                                DM
                            </td>
                            <td style="display:none">
                                <asp:TextBox ID="txtD2EnReporte" runat="server" Width="73px" Font-Names="Arial"
                                   CssClass="Derecha"   ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                                <td>
                                <asp:CheckBox ID="chkRetencionEdicion" runat="server" Text="Retencion"
                                    Font-Bold="True" />
                            </td>
                            <td style="font-weight: bold; padding-left: 5px;display:none;">
                               D3
                            </td>
                            <td style="padding-left: 30px;display:none;">
                                <asp:TextBox ID="txtD3EnReporte" runat="server" Width="82px" Font-Names="Arial"
                                   CssClass="Derecha"   ForeColor="Blue" Font-Bold="True"></asp:TextBox>
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
      <div id="div_GPSCompartir" style="display: none;">
        <div class="ui-jqdialog-content">
            <table>
                <tr>
                    <td style="width: 50px">
                        <table>
                            <tr>
                                <td style="font-weight: bold">
                                    Long
                                </td>
                                <td style="padding-left: 5px;">
                                    <asp:TextBox ID="txtGPSLongCompartir" runat="server" Width="100px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True" MaxLength="14" Font-Size="Small" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; padding-top: 5px;">
                                    Lat
                                </td>
                                <td style="padding-left: 5px;">
                                    <asp:TextBox ID="txtGPSLatCompartir" runat="server" Width="100px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True" MaxLength="14" Font-Size="Small" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <image src="../Asset/images/googlemapsicon.png" style="width: 50px; height: 50px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table>
                            <tr style="width: 50px">
                                <td style="font-weight: bold;">
                                    Link
                                </td>
                                <td style="padding-left: 11px;">
                                    <asp:TextBox ID="txtGPSLinkCompartir" runat="server" Width="160px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True" Style="text-transform: none"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <asp:Button ID="btnCopiarLink" runat="server" Text="Copiar Link" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" Width="100" OnClientClick="F_CopiarDireccionGPS(this); return false;" />
                        <asp:Button ID="btnAbrirLink" runat="server" Text="Abrir Link" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" Width="100" OnClientClick="F_AbrirDireccionGPS(this); return false;" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="div_DireccionMultiple" style="display: none;">
     <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all"> 
          <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix"> 
            DATOS DIRECCION
          </div>
          <div class="ui-jqdialog-content"> 
    <table cellpadding="0" cellspacing="0" class="form-inputs">
            <tr>
                <td style="padding-top: 10px; font-weight: bold">
                    Distrito
                </td>
                <td style="padding-top: 10px;">
                    <asp:TextBox ID="txtDistritoMultiple" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Direccion
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtDireccionMultiple" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Email
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtEmailMultiple1" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr  style="display: none;">
                <td style="padding-top: 5px; font-weight: bold">
                    Email 2
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtEmailMultiple2" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: none;">
                <td style="padding-top: 5px; font-weight: bold">
                    Email 3
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtEmailMultiple3" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: none;">
                <td style="padding-top: 5px; font-weight: bold">
                    Email 4
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtEmailMultiple4" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: none;">
                <td style="padding-top: 5px; font-weight: bold">
                    Email 5
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtEmailMultiple5" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: none;">
                <td style="padding-top: 5px; font-weight: bold">
                    Email 6
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtEmailMultiple6" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
          
            <tr  style="display: none;">
                <td style="padding-top: 5px;" colspan="2">
                    <div id="div_Direccion">
                        <asp:GridView ID="grvDireccion" runat="server" AutoGenerateColumns="False" border="0"
                            CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="860px"
                            OnRowDataBound="grvConsulta_RowDataBound">
                            <Columns>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                            ToolTip="Eliminar Direccion" OnClientClick="F_EliminarDireccion(this); return false;" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgEditarRegistro" ImageUrl="../Asset/images/btnEdit.gif"
                                            ToolTip="Editar Direccion" OnClientClick="F_EditarRegistroDireccion(this); return false;" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgActivarRegistro" ImageUrl="../Asset/images/poweron.png" Height="15px" Width="28px"
                                            ToolTip="ACTIVO: PRESIONES PARA INACTIVAR" OnClientClick="F_ActivarRegistroDireccion(this); return false;" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgPrincipal" ImageUrl="../Asset/images/Circle_Yellow.png"
                                            ToolTip="Activar/Desactivar" OnClientClick="F_ElegirPrincipalDireccion(this); return false;" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label       ID="lblCodDireccion"   runat="server"  Text='<%# Bind("CodDireccion") %>'></asp:Label>
                                        <asp:HiddenField ID="hfPrincipal"       runat="server" Value='<%# Bind("Principal") %>' />
                                        <asp:HiddenField ID="hfCodDistrito"     runat="server" Value='<%# Bind("CodDistrito") %>' />
                                        <asp:HiddenField ID="hfCodDepartamento" runat="server" Value='<%# Bind("CodDepartamento") %>' />
                                        <asp:HiddenField ID="hfCodProvincia"    runat="server" Value='<%# Bind("CodProvincia") %>' />
                                        <asp:HiddenField ID="hfCodEstado"       runat="server" Value='<%# Bind("CodEstado") %>' />
                                        <asp:HiddenField ID="hfEmail"           runat="server" Value='<%# Bind("Email") %>' />
                                        <asp:HiddenField ID="hfEmail2"          runat="server" Value='<%# Bind("Email2") %>' />
                                        <asp:HiddenField ID="hfEmail3"          runat="server" Value='<%# Bind("Email3") %>' />
                                        <asp:HiddenField ID="hfEmail4"          runat="server" Value='<%# Bind("Email4") %>' />
                                        <asp:HiddenField ID="hfEmail5"          runat="server" Value='<%# Bind("Email5") %>' />
                                        <asp:HiddenField ID="hfEmail6"          runat="server" Value='<%# Bind("Email6") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                        <ItemTemplate>
                                            <img id="imgMas" alt="" style="cursor: pointer" src="../Asset/images/plus.gif" onclick="imgMas_Click(this);"
                                                title="Ver Detalle" />
                                            <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                                                <asp:GridView ID="grvDetalle" runat="server" border="0" CellPadding="0" CellSpacing="1"
                                                    AutoGenerateColumns="True" GridLines="None" class="GridView">
                                                    <Columns>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                <asp:TemplateField HeaderText="Estado" HeaderStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblEstado" Text='<%# Bind("Estado") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Distrito" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblDistrito" Text='<%# Bind("Distrito") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Direccion" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblDireccion" Text='<%# Bind("Direccion") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
          </div>
          <div class="linea-button">
            <asp:Button ID="btnGrabarDireccion" runat="server" Text="GRABAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
          </div>
     </div>
    
    </div>
    <div id="div_EdicionDireccion" style="display: none;"> 
    <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all"> 
         <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix"> 
            DATOS DIRECCION
          </div>
         <div class="ui-jqdialog-content">
            <table cellpadding="0" cellspacing="0" class="form-inputs">
               
                <tr>
                    <td style="font-weight: bold; padding-top: 5px;">
                        Distrito
                    </td>
                    <td style="padding-left: 5px; padding-top: 5px;">
                        <asp:TextBox ID="txtDistritoDireccionEdicion" runat="server" Width="360px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold; padding-top: 5px;">
                        Direccion
                    </td>
                    <td style="padding-left: 5px; padding-top: 5px;">
                        <asp:TextBox ID="txtDireccionEdicionMultiple" runat="server" Width="360px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        GPS
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="display: none;">
                                    Long
                                </td>
                                <td style="display: none;">
                                    <asp:TextBox ID="txtGPSLongEdicion" runat="server" Width="100px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True" MaxLength="14" Font-Size="Small"></asp:TextBox>
                                </td>
                                <td style="display: none;">
                                    Lat
                                </td>
                                <td style="display: none;">
                                    <asp:TextBox ID="txtGPSLatEdicion" runat="server" Width="100px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True" MaxLength="14" Font-Size="Small"></asp:TextBox>
                                </td>
                                 <td style="padding-left: 5px; padding-top: 5px; font-weight: bold">
                                            <asp:TextBox ID="txtGPSLongLatEdicion" runat="server" Width="360px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"  Font-Size="Small"></asp:TextBox>
                                        </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
         <div class="linea-button">
              <asp:Button ID="btnGrabarEdicionDireccion" runat="server" Text="GRABAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" Width="120" />
          </div>
    </div>
    </div>
    <div id="div_EdicionCorreo" style="display: none;"> 
    <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all"> 
          <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix"> 
            DATOS CORREO
          </div>
         <div class="ui-jqdialog-content">
            <table cellpadding="0" cellspacing="0" class="form-inputs">
                <tr>
                    <td style="font-weight: bold; padding-top: 5px;">
                        Email
                    </td>
                    <td style="padding-left: 5px; padding-top: 5px;">
                        <asp:TextBox ID="txtEmailEdicionMultiple1" runat="server" Width="360px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr style="font-weight: bold; padding-top: 5px;display:none">
                    <td style="font-weight: bold; padding-top: 5px;">
                        Email 2
                    </td>
                    <td style="padding-left: 5px; padding-top: 5px;">
                        <asp:TextBox ID="txtEmailEdicionMultiple2" runat="server" Width="360px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr style="font-weight: bold; padding-top: 5px;display:none">
                    <td style="font-weight: bold; padding-top: 5px;">
                        Email 3
                    </td>
                    <td style="padding-left: 5px; padding-top: 5px;">
                        <asp:TextBox ID="txtEmailEdicionMultiple3" runat="server" Width="360px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr style="font-weight: bold; padding-top: 5px;display:none">
                    <td style="font-weight: bold; padding-top: 5px;">
                        Email 4
                    </td>
                    <td style="padding-left: 5px; padding-top: 5px;">
                        <asp:TextBox ID="txtEmailEdicionMultiple4" runat="server" Width="360px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr style="font-weight: bold; padding-top: 5px;display:none">
                    <td style="font-weight: bold; padding-top: 5px;">
                        Email 5
                    </td>
                    <td style="padding-left: 5px; padding-top: 5px;">
                        <asp:TextBox ID="txtEmailEdicionMultiple5" runat="server" Width="360px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr style="font-weight: bold; padding-top: 5px;display:none">
                    <td style="font-weight: bold; padding-top: 5px;">
                        Email 6
                    </td>
                    <td style="padding-left: 5px; padding-top: 5px;">
                        <asp:TextBox ID="txtEmailEdicionMultiple6" runat="server" Width="360px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
          <div class="linea-button">
              <asp:Button ID="btnGrabarEdicionCorreo" runat="server" Text="GRABAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" Width="120" />
          </div>
       
    </div>
    </div>
    <div id="div_Contactos" style="display: none;">
     <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                DATOS CONTACTOS
            </div>
            <div class="ui-jqdialog-content">
             <table cellpadding="0" cellspacing="0" class="form-inputs" >
            <tr>
                <td style="font-weight: bold">
                    Cliente
                </td>
                <td>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="txtClienteContacto" runat="server" Width="505px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>

                <td style="font-weight: bold">
                    Nombre
                </td>
                <td>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="txtContacto" runat="server" Width="505px" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="display:none;">
                <td style="font-weight: bold">
                    Area
                </td>
                <td>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="txtContactoArea" runat="server" Width="210px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold; padding-left: 10px;display:none;">
                                Telefono
                            </td>
                            <td style="padding-left: 13px">
                                <asp:TextBox ID="txtContactoTelefono" runat="server" Width="210px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Correo
                </td>
                <td>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="txtCorreoContacto1" runat="server" Width="210px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold; padding-left: 10px">
                                Celular
                            </td>
                <td>
                 <td style="padding-left: 10px">
                                <asp:TextBox ID="txtCelularContacto1" runat="server" Width="210px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold; padding-left: 12px;display:none;">
                                Correo 2
                            </td>
                            <td style="padding-left: 12px;display:none;">
                                <asp:TextBox ID="txtCorreoContacto2" runat="server" Width="210px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="display:none">
                  <td style="font-weight: bold; padding-left: 10px">
                                Celular 1
                            </td>
                <td>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td style:"display:none">
                                <asp:TextBox ID="txtCorreoContacto3" runat="server" Width="210px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                          
                           
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="display:none;">
                <td style="font-weight: bold">
                    Celular 2
                </td>
                <td>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="txtCelularContacto2" runat="server" Width="210px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="font-weight: bold; padding-left: 10px">
                                Celular 3
                            </td>
                            <td style="padding-left: 10px">
                                <asp:TextBox ID="txtCelularContacto3" runat="server" Width="210px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Estado
                </td>
                <td style="font-weight: bold">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <div id="div_EstadoContacto">
                                    <asp:DropDownList ID="ddlEstadoContacto" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True">
                                        <asp:ListItem Value="1">Activo</asp:ListItem>
                                        <asp:ListItem Value="2">Inativo</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td style="display:none">
                                <asp:CheckBox ID="chkFlag_MostrarEnReporte" runat="server" Text="Mostrar en Reporte"
                                    Font-Bold="True" />
                            </td>
                             
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px;" colspan="2">
                   <%-- <div id="div1">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" border="0"
                            CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="860px">
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                            ToolTip="Eliminar Direccion" OnClientClick="F_EliminarDireccion(this); return false;" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgEditarContacto" ImageUrl="../Asset/images/btnEdit.gif"
                                            ToolTip="Editar Direccion" OnClientClick="F_EditarContactos(this); return false;" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCodContacto" Text='<%# Bind("CodContacto") %>'></asp:Label>
                                        <asp:HiddenField ID="hfCodCtaCte" runat="server" Value='<%# Bind("CodCtaCte") %>' />
                                        <asp:HiddenField ID="hfCodEstado" runat="server" Value='<%# Bind("CodEstado") %>' />
                                        <asp:HiddenField ID="hfFlag_MostrarEnReporte" runat="server" Value='<%# Bind("Flag_MostrarEnReporte") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Datos Personales" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblDatosPersonales" Text='<%# Bind("DatosPersonales") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Area" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblArea" Text='<%# Bind("Area") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Telef" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblTelefono" Text='<%# Bind("Telefono") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Correo1" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCorreo1" Text='<%# Bind("Correo1") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Correo2" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCorreo2" Text='<%# Bind("Correo2") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Correo3" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCorreo3" Text='<%# Bind("Correo3") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Celular 1" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCelular1" Text='<%# Bind("Celular1") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Celular 2" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCelular2" Text='<%# Bind("Celular2") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Celular 3" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCelular3" Text='<%# Bind("Celular3") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estado" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblEstado" Text='<%# Bind("Estado") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>--%>
                </td>
            </tr>
        </table>
         </div>
            <div class="linea-button">
                <asp:Button ID="btnGrabarContacto" runat="server" Text="GRABAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
            </div>
        </div>
     </div>
    <div id="div_ContactosEdicion" style="display: none;">
    <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all"> 
          <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix"> 
            DATOS CONTACTO
          </div>
        <div class="ui-jqdialog-content">
            <table cellpadding="0" cellspacing="0" class="form-inputs">
                <tr style="padding-top: 10px">
                    <td style="font-weight: bold">
                        Nombre
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="3">
                                    <asp:TextBox ID="txtContactoEdicion" runat="server" Width="505px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="padding-top: 10px;display:none">
                    <td style="font-weight: bold">
                        Area
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtContactoAreaEdicion" runat="server" Width="210px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold; padding-left: 10px">
                                    Telefono
                                </td>
                                <td style="padding-left: 12px">
                                    <asp:TextBox ID="txtTelefonoContactoEdicion" runat="server" Width="210px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        Correo 
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtCorreoContactoEdicion1" runat="server" Width="230px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                               <td style="font-weight: bold">
                       Celular
                    </td>
                                 <td style="padding-left: 10px">
                                    <asp:TextBox ID="txtCelularContactoEdicion1" runat="server" Width="210px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="font-weight: bold; padding-left: 10px;display:none">
                    <td style="font-weight: bold">
                       Celular
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="font-weight: bold;display:none">
                                    <asp:TextBox ID="txtCorreoContactoEdicion3" runat="server" Width="210px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold; padding-left: 10px;display:none">
                                    
                                </td>
                                 <td style="font-weight: bold; padding-left: 10px;display:none">
                                    Correo 2
                                </td>
                                <td style="padding-left: 12px;display:none">
                                    <asp:TextBox ID="txtCorreoContactoEdicion2" runat="server" Width="210px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="font-weight: bold;display:none">
                    <td style="font-weight: bold;display:none">
                        celular 2
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="font-weight: bold; padding-left: 10px;display:none">
                                    <asp:TextBox ID="txtCelularContactoEdicion2" runat="server" Width="210px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold; padding-left: 10px;display:none">
                                    Celular 3
                                </td>
                                <td style="padding-left: 10px">
                                    <asp:TextBox ID="txtCelularContactoEdicion3" runat="server" Width="210px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        Estado
                    </td>
                    <td style="font-weight: bold">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <div id="div_EstadoContactoEdicion">
                                        <asp:DropDownList ID="ddlEstadoContactoEdicion" runat="server" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True">
                                            <asp:ListItem Value="1">Activo</asp:ListItem>
                                            <asp:ListItem Value="2">Inativo</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </td>
                               <%-- <td>
                                    <asp:CheckBox ID="chkFlag_MostrarEnReporteEdicion" runat="server" Text="Mostrar en Reporte"
                                        Font-Bold="True" />
                                </td>
                               --%>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
         <div class="linea-button">
          <asp:Button ID="btnEditarContacto" runat="server" Text="GRABAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" Width="120" />
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
    <input id="hfDistritoEdicion" type="hidden" value="0" />
    <input id="hfMoneda" type="hidden" value="0" />
    <input id="hfCodDireccion" type="hidden" value="0" />
    <input id="hfCodContacto" type="hidden" value="0" />
    <input id="hfUbigeo" type="hidden" value="0" />
    <input id="hfurlapisunat" type="hidden" value="0" />
    <input id="hftokenapisunat" type="hidden" value="0" />
    <input id="hfNroRuc" type="hidden" value="" />
    <input id="hfGPSLinkCompartir" type="hidden" value="" />
</asp:Content>
