<%@ Page Title="Maestro de Trabajador" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="MaestroTrabajador.aspx.cs" Inherits="SistemaInventario.Planilla.MaestroTrabajador"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"
        type="text/javascript"></script>
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript"
        charset="UTF-8"></script>
    <script src="../Scripts/UtilitariosDatos.js" type="text/javascript"></script>
    <script src="UtilitariosPlanillas.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="MaestroTrabajador.js" charset="UTF-8"></script>
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/toars/toastr.min.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/toars/toastr.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo">
        TRABAJADOR</div>
    <div id="divTabs">
        <ul>
            <li id="liRegistro"><a href="#tabRegistro">Registro</a></li>
            <li id="liConsulta"><a href="#tabConsulta">Consulta</a></li>
        </ul>
        <div id="tabRegistro">
            <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 900px">
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    REGISTRO DE TRABAJADOR
                </div>
                <div>
                    <table cellpadding="0" cellspacing="0" class="form-inputs">
                        <tr>
                            <td style="font-weight: bold; width: 130px">
                                Nro. Documento
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <div>
                                                <asp:DropDownList ID="ddlTipoDocumento" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="50">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNroDocumento" runat="server" Width="70px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold; width: 145px; padding-left: 20px;">
                                            Apellidos y Nombres
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtApellidosNombres" runat="server" Width="415px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Categoria
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <div id="div3">
                                                <asp:DropDownList ID="ddlCategoria" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="300">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                        <td style="font-weight: bold; width: 80px;">
                                            Proyecto
                                        </td>
                                        <td>
                                            <div id="div4">
                                                <asp:DropDownList ID="ddlProyecto" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="331">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                AFP
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <div id="div5">
                                                <asp:DropDownList ID="ddlAFP" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="300">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                        <td style="font-weight: bold; width: 80px;">
                                            CUSP
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCusp" runat="server" Width="192px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold; width: 62px">
                                            Pais
                                        </td>
                                        <td>
                                            <div id="div1">
                                                <asp:DropDownList ID="ddlPaisEmisor" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="64">
                                                    <asp:ListItem Value="PERU">PERU</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Sexo
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <div id="div6">
                                                <asp:DropDownList ID="ddlSexo" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="50">
                                                    <asp:ListItem Value="1">M</asp:ListItem>
                                                    <asp:ListItem Value="2">F</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                        <td style="font-weight: bold; width: 80px; padding-left: 10px">
                                            Estado Civil
                                        </td>
                                        <td>
                                            <div id="div8">
                                                <asp:DropDownList ID="ddlEstadoCivil" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="154px">
                                                    <asp:ListItem Value="1">Soltero(a)</asp:ListItem>
                                                    <asp:ListItem Value="2">Casado(a)</asp:ListItem>
                                                    <asp:ListItem Value="3">Divorciado(a)</asp:ListItem>
                                                    <asp:ListItem Value="4">Viudo(a)</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                        <td style="font-weight: bold; width: 80px;">
                                            Nacionalidad
                                        </td>
                                        <td>
                                            <div id="div9">
                                                <asp:DropDownList ID="ddlNacionalidad" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="80">
                                                    <asp:ListItem Value="1">PERUANA</asp:ListItem>
                                                    <asp:ListItem Value="2">VENEZOLANA</asp:ListItem>
                                                    <asp:ListItem Value="3">COLOMBIANA</asp:ListItem>
                                                    <asp:ListItem Value="4">ARGENTINA</asp:ListItem>
                                                    <asp:ListItem Value="5">BOLIVIANA</asp:ListItem>
                                                    <asp:ListItem Value="6">CHILENA</asp:ListItem>
                                                    <asp:ListItem Value="7">ECUATORIANA</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                        <td style="font-weight: bold; width: 74px;">
                                            Nro. Hijos
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNroHijos" runat="server" Width="30px" Font-Names="Arial" ForeColor="Blue"
                                                CssClass="Derecha" Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold; width: 63px;">
                                            F. Ingreso
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFechaIngreso" runat="server" Width="60px" Font-Names="Arial"
                                                CssClass="Jq-ui-dtp" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
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
                                            <asp:TextBox ID="txtDireccion" runat="server" Width="465px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold; width: 73px;">
                                            Distrito
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDistrito" runat="server" Width="165px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold;">
                                F. Nacimiento
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtFechaNacimiento" runat="server" Width="80px" Font-Names="Arial"
                                                CssClass="Jq-ui-dtp" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold; width: 100px;">
                                            Pensiones AFP
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPensiones_AFP" runat="server" Width="104px" Font-Names="Arial"
                                                CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold; width: 80px;">
                                            Prima AFP
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPrima_AFP" runat="server" Width="78px" Font-Names="Arial" ForeColor="Blue"
                                                CssClass="Derecha" Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold; width: 74px;">
                                            Com. AFP
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtComisionAFP" runat="server" Width="165px" Font-Names="Arial"
                                                CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; width: 150px;">
                                Anticipada AFP
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtAnticipada_AFP" runat="server" Width="80px" Font-Names="Arial"
                                                CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold; width: 100px; display: none">
                                            Desc. Judicial
                                        </td>
                                        <td style="display: none">
                                            <asp:TextBox ID="txtDescuentoJudicial" runat="server" Width="104px" Font-Names="Arial"
                                                CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold; width:100px;">
                                            Seg Social
                                        </td>
                                        <td>
                                            <div id="div16">
                                                <asp:DropDownList ID="ddlSeguridadSocial" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="107px">
                                                    <asp:ListItem Value="1">ESSALUD</asp:ListItem>
                                                    <asp:ListItem Value="2">EPS</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                        <td style="font-weight: bold; width: 80px">
                                            Estado
                                        </td>

                                        <td>
                                            <div id="div_Estado">
                                                <asp:DropDownList ID="ddlEstado" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="82">
                                                </asp:DropDownList>
                                            </div>
                                        </td>                                        
                                        <td>
                                            <table id="tdSalarioMensualLabel">
                                                <tr>
                                                    
                                                        <td style="font-weight: bold; width: 100px">
                                                            Salario Mensual
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSalarioMensual" runat="server" Width="130px" Font-Names="Arial"
                                                                CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                        </td>
                                                    
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>                                                                                                                                                                               
                            
                            <td style="font-weight: bold;">
                                Banco
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                         <td>
                                            <asp:DropDownList ID="ddlBancos" runat="server" Width="130px" Font-Names="Arial"
                                                CssClass="Jq-ui-dtp" ForeColor="Blue" Font-Bold="True"></asp:DropDownList>
                                        </td>                                                                                    
                                       
                                        <td style="font-weight: bold; width: 110px;">
                                            Nro. Cuenta
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNumCta" runat="server" Width="215px" Font-Names="Arial"
                                                CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                         <td style="font-weight: bold; width: 75px;">
                                            CCI
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCCI" runat="server" Width="165px" Font-Names="Arial"
                                                CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>                                                                    
                                        
                                    </tr>
                                </table>
                            </td>
                        </tr>                        
                         <tr>                            
                            <td style="font-weight: bold; width: 150px;">
                                Area de Trabajo
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtEstrab" runat="server" Width="126px" Font-Names="Arial" ForeColor="Blue"
                                                CssClass="Derecha" Font-Bold="True"></asp:TextBox>
                                        </td>                                          
                                        <td style="font-weight: bold; width: 110px;">
                                              Centro de Costos                                             
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCcost" runat="server" Width="215px" Font-Names="Arial"
                                                CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>                                                                                  
                                         <td style="font-weight: bold; width: 74px;">
                                            Consorciado
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCons" runat="server" Width="165px" Font-Names="Arial"
                                                CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>   
                                    </tr>
                                </table>
                            </td>
                            
                        </tr>
                        <tr style="display:none">
                            <td style="font-weight: bold; width: 150px;">
                                Retenido Anterior
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtRetencionAnteriorMonto" runat="server" Width="78px" Font-Names="Arial"
                                                CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold; width: 200px;">
                                            Total Remuneracion Anterior
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRetencionAnteriorTotalRemuneraciones" runat="server" Width="78px"
                                                Font-Names="Arial" CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold;" class="tdEmpleado">
                                            Cargo
                             </td>
                             <td>   
                             <table cellpadding="0" cellspacing="0">
                             <tr>
                                      <td style="width:130px" class="tdEmpleado">
                                   <asp:DropDownList ID="ddlCargo" runat="server" Width="165px" Font-Names="Arial"
                                 CssClass="Jq-ui-dtp" ForeColor="Blue" Font-Bold="True"></asp:DropDownList>
                                 </td>     
                                </tr>
                                 </table>
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
                            <td style="font-weight: bold">
                                Apellidos y Nombres
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
            <div id="div_consulta" style="padding-top: 5px;">
                <asp:GridView ID="grvConsulta" runat="server" AutoGenerateColumns="False" border="0"
                    CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="1017px">
                    <Columns>
                        <asp:TemplateField>
                            <ItemStyle Width="20px" />
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                    ToolTip="ELIMINAR TRABAJADOR" OnClientClick="F_EliminarRegistro(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemStyle Width="20px" />
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgEditarRegistro" ImageUrl="../Asset/images/btnEdit.gif"
                                    ToolTip="EDITAR TRABAJADOR" OnClientClick="F_EditarRegistro(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemStyle Width="20px" />
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgRetencionesAnteiores" ImageUrl="../Asset/images/retencion2x20.png"
                                    Width="20px" Height="20px" ToolTip="RETENCIONES ANTERIORES" OnClientClick="F_RetencionesAnteriores(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="NroDocumento" HeaderText="Nro. Doc.">
                            <ItemStyle Width="60px" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Apellidos y Nombres" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblApellidosNombres" Text='<%# Bind("ApellidosNombres") %>'></asp:Label>
                                <asp:HiddenField ID="hfID" runat="server" Value='<%# Bind("CodTrabajador") %>' />
                                <asp:HiddenField ID="hfCodCategoria" runat="server" Value='<%# Bind("CodCategoria") %>' />
                                <asp:HiddenField ID="hfCodProyecto" runat="server" Value='<%# Bind("CodProyecto") %>' />
                                <asp:HiddenField ID="hfCodAFP" runat="server" Value='<%# Bind("CodAFP") %>' />
                                <asp:HiddenField ID="hfCodTipoDocumento" runat="server" Value='<%# Bind("CodTipoDocumento") %>' />
                                <asp:HiddenField ID="hfNroDocumento" runat="server" Value='<%# Bind("NroDocumento") %>' />
                                <asp:HiddenField ID="hfCUSP" runat="server" Value='<%# Bind("CUSP") %>' />
                                <asp:HiddenField ID="hfFechaNacimiento" runat="server" Value='<%# Bind("FechaNacimiento") %>' />
                                <asp:HiddenField ID="hfPaisEmisor" runat="server" Value='<%# Bind("PaisEmisor") %>' />
                                <asp:HiddenField ID="hfApellidosNombres" runat="server" Value='<%# Bind("ApellidosNombres") %>' />
                                <asp:HiddenField ID="hfNombreCompleto" runat="server" Value='<%# Bind("NombreCompleto") %>' />
                                <asp:HiddenField ID="hfSexo" runat="server" Value='<%# Bind("Sexo") %>' />
                                <asp:HiddenField ID="hfEstadoCivil" runat="server" Value='<%# Bind("EstadoCivil") %>' />
                                <asp:HiddenField ID="hfNacionalidad" runat="server" Value='<%# Bind("Nacionalidad") %>' />
                                <asp:HiddenField ID="hfDireccion" runat="server" Value='<%# Bind("Direccion") %>' />
                                <asp:HiddenField ID="hfCodDistrito" runat="server" Value='<%# Bind("CodDistrito") %>' />
                                <asp:HiddenField ID="hfDistrito" runat="server" Value='<%# Bind("Distrito") %>' />
                                <asp:HiddenField ID="hfFechaIngreso" runat="server" Value='<%# Bind("FechaIngreso") %>' />
                                <asp:HiddenField ID="hfFechaCese" runat="server" Value='<%# Bind("FechaCese") %>' />
                                <asp:HiddenField ID="hfNroHijos" runat="server" Value='<%# Bind("NroHijos") %>' />
                                <asp:HiddenField ID="hfPensiones_AFP" runat="server" Value='<%# Bind("Pensiones_AFP") %>' />
                                <asp:HiddenField ID="hfPrima_AFP" runat="server" Value='<%# Bind("Prima_AFP") %>' />
                                <asp:HiddenField ID="hfComision_AFP" runat="server" Value='<%# Bind("Comision_AFP") %>' />
                                <asp:HiddenField ID="hfAnticipada_AFP" runat="server" Value='<%# Bind("Anticipada_AFP") %>' />
                                <asp:HiddenField ID="hfDescuentoJudicial" runat="server" Value='<%# Bind("DescuentoJudicial") %>' />
                                <asp:HiddenField ID="hfRetencionAnteriorAño" runat="server" Value='<%# Bind("RetencionAnteriorAño") %>' />
                                <asp:HiddenField ID="hfRetencionAnteriorCodRetencion" runat="server" Value='<%# Bind("RetencionAnteriorCodRetencion") %>' />
                                <asp:HiddenField ID="hfRetencionAnteriorMonto" runat="server" Value='<%# Bind("RetencionAnteriorMonto") %>' />
                                <asp:HiddenField ID="hfRetencionAnteriorTotalRemuneraciones" runat="server" Value='<%# Bind("RetencionAnteriorTotalRemuneraciones") %>' />
                                <asp:HiddenField ID="hfSalarioMensual" runat="server" Value='<%# Bind("SalarioMensual") %>' />
                                <asp:HiddenField ID="hfCodEstado" runat="server" Value='<%# Bind("CodEstado") %>' />
                                <asp:HiddenField ID="hfCodSeguridadSocial" runat="server" Value='<%# Bind("CodSeguridadSocial") %>' />
                                <asp:HiddenField ID="hfCodBanco" runat="server" Value='<%# Bind("CodBanco") %>' />
                                <asp:HiddenField ID="hfNumeroCuenta" runat="server" Value='<%# Bind("NumeroCuenta") %>' />
                                <asp:HiddenField ID="hfCCI" runat="server" Value='<%# Bind("CCI") %>' />
                                <asp:HiddenField ID="hfAreaTrabajo" runat="server" Value='<%# Bind("AreaTrabajo") %>' />
                                <asp:HiddenField ID="hfCentroCostos" runat="server" Value='<%# Bind("CentroCostos") %>' />
                                <asp:HiddenField ID="hfConsorciado" runat="server" Value='<%# Bind("Consorciado") %>' />
                                <asp:HiddenField ID="hfCodCargo" runat="server" Value='<%# Bind("CodCargo") %>' />

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
                DATOS DE TRABAJADOR
            </div>
            <div>
                <table cellpadding="0" cellspacing="0" class="form-inputs">
                    <tr>
                        <td style="font-weight: bold; width: 130px">
                            Nro. Documento
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <div>
                                            <asp:DropDownList ID="ddlTipoDocumentoEdicion" runat="server" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True" Width="50">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNroDocumentoEdicion" runat="server" Width="70px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td style="font-weight: bold; width: 145px; padding-left: 20px;">
                                        Apellidos y Nombres
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtApellidosNombresEdicion" runat="server" Width="415px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold">
                            Categoria
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <div id="div2">
                                            <asp:DropDownList ID="ddlCategoriaEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" Width="300">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                    <td style="font-weight: bold; width: 80px;">
                                        Proyecto
                                    </td>
                                    <td>
                                        <div id="div7">
                                            <asp:DropDownList ID="ddlProyectoEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" Width="331">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold">
                            AFP
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <div id="div10">
                                            <asp:DropDownList ID="ddlAFPEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" Width="300">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                    <td style="font-weight: bold; width: 80px;">
                                        CUSP
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCuspEdicion" runat="server" Width="192px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                    <td style="font-weight: bold; width: 62px">
                                        Pais
                                    </td>
                                    <td>
                                        <div id="div11">
                                            <asp:DropDownList ID="ddlPaisEmisorEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" Width="64">
                                                <asp:ListItem Value="PERU">PERU</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold">
                            Sexo
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <div id="div12">
                                            <asp:DropDownList ID="ddlSexoEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" Width="50">
                                                <asp:ListItem Value="1">M</asp:ListItem>
                                                <asp:ListItem Value="2">F</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                    <td style="font-weight: bold; width: 80px; padding-left: 10px">
                                        Estado Civil
                                    </td>
                                    <td>
                                        <div id="div13">
                                            <asp:DropDownList ID="ddlEstadoCivilEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" Width="154px">
                                                <asp:ListItem Value="1">Soltero(a)</asp:ListItem>
                                                <asp:ListItem Value="2">Casado(a)</asp:ListItem>
                                                <asp:ListItem Value="3">Divorciado(a)</asp:ListItem>
                                                <asp:ListItem Value="4">Viudo(a)</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                    <td style="font-weight: bold; width: 80px;">
                                        Nacionalidad
                                    </td>
                                    <td>
                                        <div id="div14">
                                            <asp:DropDownList ID="ddlNacionalidadEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" Width="80">
                                                <asp:ListItem Value="1">PERUANA</asp:ListItem>
                                                <asp:ListItem Value="2">VENEZOLANA</asp:ListItem>
                                                <asp:ListItem Value="3">COLOMBIANA</asp:ListItem>
                                                <asp:ListItem Value="4">ARGENTINA</asp:ListItem>
                                                <asp:ListItem Value="5">BOLIVIANA</asp:ListItem>
                                                <asp:ListItem Value="6">CHILENA</asp:ListItem>
                                                <asp:ListItem Value="7">ECUATORIANA</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                    <td style="font-weight: bold; width: 74px;">
                                        Nro. Hijos
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNroHijosEdicion" runat="server" Width="30px" Font-Names="Arial"
                                            CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                    <td style="font-weight: bold; width: 63px;">
                                        F. Ingreso
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFechaIngresoEdicion" runat="server" Width="60px" Font-Names="Arial"
                                            CssClass="Jq-ui-dtp" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
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
                                        <asp:TextBox ID="txtDireccionEdicion" runat="server" Width="465px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                    <td style="font-weight: bold; width: 73px;">
                                        Distrito
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDistritoEdicion" runat="server" Width="165px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold;">
                            F. Nacimiento
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtFechaNacimientoEdicion" runat="server" Width="80px" Font-Names="Arial"
                                            CssClass="Jq-ui-dtp" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                    <td style="font-weight: bold; width: 100px;">
                                        Pensiones AFP
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPensiones_AFPEdicion" runat="server" Width="104px" Font-Names="Arial"
                                            CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                    <td style="font-weight: bold; width: 80px;">
                                        Prima AFP
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPrima_AFPEdicion" runat="server" Width="78px" Font-Names="Arial"
                                            CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                    <td style="font-weight: bold; width: 74px;">
                                        Com. AFP
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtComisionAFPEdicion" runat="server" Width="165px" Font-Names="Arial"
                                            CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold; width: 150px;">
                            Anticipada AFP
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtAnticipada_AFPEdicion" runat="server" Width="80px" Font-Names="Arial"
                                            CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                    <td style="font-weight: bold; width: 100px; display: none">
                                        Desc. Judicial
                                    </td>
                                    <td style="display: none">
                                        <asp:TextBox ID="txtDescuentoJudicialEdicion" runat="server" Width="104px" Font-Names="Arial"
                                            CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                        <td style="font-weight: bold; width:100px;">
                                            Seg Social
                                        </td>
                                        <td>
                                            <div id="div17">
                                                <asp:DropDownList ID="ddlSeguridadSocialEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" Width="107px">
                                                    <asp:ListItem Value="1">ESSALUD</asp:ListItem>
                                                    <asp:ListItem Value="2">EPS</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    <td style="font-weight: bold; width: 80px">
                                        Estado
                                    </td>
                                    <td>
                                        <div id="div15">
                                            <asp:DropDownList ID="ddlEstadoEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" Width="100">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                    <td>
                                            <asp:CheckBox ID="chkCeseEdicion" runat="server"/>                                            
                                        </td>
                                        <td style="font-weight:bold; width:50px" id="lblCeseEdicion">
                                            F. Cese
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFCeseEdicion" runat="server" Width="80px" Font-Names="Arial"
                                                CssClass="Jq-ui-dtp" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                    <td>
                                        <table id="tdSalarioMensualLabelEdicion">
                                            <tr>
                                                <td>
                                                    <td style="font-weight: bold; width: 100px">
                                                        Salario Mensual
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSalarioMensualEdicion" runat="server" Width="104px" Font-Names="Arial"
                                                            CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                </td>
                                            </tr>                                            
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                           <td style="font-weight: bold;">
                                         Banco
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                                                 
                                   
                                        <td>
                                            <asp:DropDownList ID="ddlBancosEdicion" runat="server" Width="130px" Font-Names="Arial"
                                                CssClass="Jq-ui-dtp" ForeColor="Blue" Font-Bold="True"></asp:DropDownList>
                                        </td>
                                        <td style="font-weight: bold; width: 110px;">
                                            Nro. Cuenta
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNumCtaEdicion" runat="server" Width="215px" Font-Names="Arial"
                                                CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                         <td style="font-weight: bold; width: 75px;">
                                            CCI
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCCIEdicion" runat="server" Width="165px" Font-Names="Arial"
                                                CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>  
                                        
                                    </tr>
                                </table>
                            </td>
                        </tr>                        
                         <tr>                            
                            <td style="font-weight: bold; width: 150px;">
                                Area de Trabajo
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtEstrabEdicion" runat="server" Width="126px" Font-Names="Arial" ForeColor="Blue"
                                                CssClass="Derecha" Font-Bold="True"></asp:TextBox>
                                        </td>                                          
                                        <td style="font-weight: bold; width: 110px;">
                                              Centro de Costos                                             
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCcostEdicion" runat="server" Width="215px" Font-Names="Arial"
                                                CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>                                                                                  
                                         <td style="font-weight: bold; width: 74px;">
                                            Consorciado
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtConsEdicion" runat="server" Width="165px" Font-Names="Arial"
                                                CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>   
                                    </tr>
                                </table>
                            </td>
                            
                        </tr>
                    <tr style="display:none">
                        <td style="font-weight: bold; width: 150px;">
                            Retenido Anterior
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtRetencionAnteriorMontoEdicion" runat="server" Width="78px" Font-Names="Arial"
                                            CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                    <td style="font-weight: bold; width: 200px;">
                                        Total Remuneracion Anterior
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRetencionAnteriorTotalRemuneracionesEdicion" runat="server" Width="78px"
                                            Font-Names="Arial" CssClass="Derecha" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold;" class="tdEmpleadoEdicion">
                           Cargo
                        </td>  
                        <td>
                        <table cellpadding="0" cellspacing="0">
                        <tr>
                       <td class="tdEmpleadoEdicion">
                            <asp:DropDownList ID="ddlCargoEdicion" runat="server" Width="165px" Font-Names="Arial"
                                            CssClass="Jq-ui-dtp" ForeColor="Blue" Font-Bold="True"></asp:DropDownList>
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
    <div id="divRetenciones" style="display: none;">
        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                Retenciones Anteriores
            </div>
            <div>
                <table>
                    <tr>
                        <td style="font-weight: bold;">
                            Trabajador
                        </td>
                        <td>
                            <asp:TextBox ID="txtRanteriorApellidosNombres" runat="server" Width="720px" Font-Names="Arial"
                                ForeColor="Blue" Font-Bold="True" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <table cellpadding="0" cellspacing="0" class="form-inputs">
                    <tr>
                        <td style="font-weight: bold;">
                            Periodo
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtRanteriorPeriodo" runat="server" Width="70px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                    <td style="font-weight: bold;">
                                        Monto Retenido
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRanteriorMontoRetenido" runat="server" Width="70px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                    <td style="font-weight: bold;">
                                        Total Ingresos
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRanteriorTotalIngresos" runat="server" Width="70px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                     <td style="font-weight:bold;" id="Td1">
                                            F. Exacta
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFEx" runat="server" Width="70px" Font-Names="Arial"
                                                CssClass="Jq-ui-dtp" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                    <td>
                                        <asp:ImageButton ID="btnRatenriorAgregar" runat="server" Width="20px" Height="20px"
                                            ImageUrl="../Asset/images/ok.gif" OnClientClick="F_RetencionesAnteriores_Insertar(); return true;" />
                                    </td>
                                    
                                    
                                </tr>
                               <tr>
                                    <td colspan="7">
                                        <asp:Label ID="lblDisplayPeriodo" runat="server" Text="" Font-Bold="true" Font-Size="Small"></asp:Label>
                                    </td>
                                    <td style="display: none">
                                        <asp:Label runat="server" ID="lblCodPeriodo"></asp:Label>
                                    </td>
                                </tr>

                            </table>                        
                        </td>
                    </tr>
                     <tr>
                                    <td style="font-weight: bold; width: 23px;">
                                        Observacion
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRanteriorObservacion" runat="server" Width="233px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                    </tr>
                      <tr>
                </table>
            </div>
        </div>
        <div id="div_grvRetenciones" style="padding-top: 5px;">
            <asp:GridView ID="grvRetenciones" runat="server" AutoGenerateColumns="False" border="0"
                CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="800px">
                <Columns>
                    <asp:TemplateField>
                        <ItemStyle Width="20px" />
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                ToolTip="ELIMINAR RETENCION" OnClientClick="F_RetencionesAnteriores_Eliminar(this); return false;" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemStyle Width="20px" />
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="imgEditarRegistro" ImageUrl="../Asset/images/btnEdit.gif"
                                ToolTip="EDITAR RETENCION" OnClientClick="F_RetencionesAnteriores_Editar(this); return false;" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Periodo" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="center" Width="50px" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblPeriodo" Text='<%# Bind("Periodo") %>'></asp:Label>
                            <asp:HiddenField ID="hfID" runat="server" Value='<%# Bind("ID") %>' />
                            <asp:HiddenField ID="hfCodTrabajador" runat="server" Value='<%# Bind("CodTrabajador") %>' />
                            <asp:HiddenField ID="hfCodPeriodo" runat="server" Value='<%# Bind("CodPeriodo") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Monto Retenido" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="right" Width="100px"/>
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblMontoRetenido" Text='<%# Bind("MontoRetenido") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Ingresos" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="right" Width="100px" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblTotalIngresos" Text='<%# Bind("TotalIngresos") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Fecha Exacta" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="right" Width="100px" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblFEx" Text='<%# Bind("FechaExacta") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Observacion" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="left" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblObservacion" Text='<%# Bind("Observacion") %>'></asp:Label>
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
    <input id="hfCodigo" type="hidden" value="0" />
    <input id="hfDistrito" type="hidden" value="0" />
    <input id="hfIdRetencionAnterior" type="hidden" value="0" />
</asp:Content>
