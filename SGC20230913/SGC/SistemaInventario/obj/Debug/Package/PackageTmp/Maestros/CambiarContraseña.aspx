<%@ Page Title="CambiarContraseña" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CambiarContraseña.aspx.cs" Inherits="SistemaInventario.Maestros.CambiarConstraseña" %>
   
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>  
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"   type="text/javascript"></script>     
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/alertify.min.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript"  charset="UTF-8"></script>      
    <script type="text/javascript" language="javascript" src="CambiarContraseña.js" charset="UTF-8"></script>
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"   type="text/css" />     
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.core.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.default.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 146px;
        }
        .style2
        {
            width: 146px;
            height: 17px;
        }
        .style3
        {
            height: 17px;
        }
        .form-inputs
        {
            width: 622px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo" style="width: 460px">
        Cambiar Contraseña</div>
    <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 460px">
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    Cambiar Contraseña
                </div>
                <div>
                    <table cellpadding="0" cellspacing="0" class="form-inputs">
                        <tr>
                            <td style="font-weight: bold" class="style1">
                                Usuario
                            </td>
                            <td colspan='5' style="padding-left: 4px;">
                                <asp:TextBox ID="txtUsuario" runat="server" Width="104px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"  ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold" class="style2">
                                Contraseña Antigua &nbsp;&nbsp;
                            </td>
                            <td colspan='5' style="padding-left: 4px;" class="style3">
                                <asp:TextBox ID="txtantigua" runat="server" Width="100px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                          <tr>
                            <td style="font-weight: bold" class="style1" >
                                Contraseña Nueva
                            </td>
                            <td colspan='5' style="padding-left: 4px;">
                                <asp:TextBox ID="txtnueva" runat="server" Width="100px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                          <tr>
                            <td style="font-weight: bold" class="style1" >
                                Confirmar Contraseña
                            </td>
                             <td colspan='5' style="padding-left: 4px;">
                                <asp:TextBox ID="txtconfirmar" runat="server" Width="100px" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True" TextMode="Password" ></asp:TextBox>
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
   
    <div id="dlgWait" style="background-color: #CCE6FF; text-align: center; display: none;">
        <br />
        <br />
        <center>
            <asp:Label ID="Label2" runat="server" Text="PROCESANDO..." Font-Bold="true" Font-Size="Large"
                Style="text-align: center"></asp:Label></center>
        <br />
        <br />
        <br />
        <center>
            <img alt="Wait..." src="../Asset/images/ajax-loader2.gif" /></center>
    </div>
    <input id="hfIDAlmacen" type="hidden" value="0" />
    <input id="hfRegion" type="hidden" value="0" />
    <input id="hfRegionEdicion" type="hidden" value="0" />
    <input id="hfProvinciaEdicion" type="hidden" value="0" />
    <input id="hfDistritoEdicion" type="hidden" value="0" />
</asp:Content>
