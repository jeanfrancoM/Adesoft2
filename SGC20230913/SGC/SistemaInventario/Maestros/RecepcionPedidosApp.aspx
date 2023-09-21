<%@ Page Title="Recepcion Pedidos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="RecepcionPedidosApp.aspx.cs" Inherits="SistemaInventario.Maestros.RecepcionPedidosApp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"
        type="text/javascript"></script>
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/dropzone.min.js" type="text/javascript"></script>
    <script type="text/javascript">        Dropzone.autoDiscover = false;</script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/alertify.min.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript"
        charset="UTF-8"></script>
    <script type="text/javascript" language="javascript" src="RecepcionPedidosApp.js"
        charset="UTF-8"></script>
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link rel="stylesheet" href="../Asset/css/dropzone.css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/toars/toastr.min.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/toars/toastr.min.js" type="text/javascript"></script>
    <link href="../Asset/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="https://www.gstatic.com/firebasejs/8.2.10/firebase-app.js"></script>
    <script type="text/javascript" src="https://www.gstatic.com/firebasejs/8.2.10/firebase-firestore.js"></script>
    <script type="text/javascript" src="https://www.gstatic.com/firebasejs/8.3.0/firebase-storage.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo" style="width: 480px">
        Pedidos hechos en la APP</div>
    <div class="linea-button">
        <asp:Button ID="btnAprobar" runat="server" Text="Aprobar Seleccionados" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
            Font-Names="Arial" Font-Bold="True" Width="200px" OnClientClick="F_Aprobar_Pedidos(); return false;"/>
        <asp:Button ID="btnAnular" runat="server" Text="Anular Seleccionados" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
            Font-Names="Arial" Font-Bold="True" Width="200px" OnClientClick="F_Rechazar_Pedidos(); return false;"/>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar Pedidos Pendientes" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
            Font-Names="Arial" Font-Bold="True" Width="200px" OnClientClick="F_FiltrarPedidosPendientes(); return false;"/>
    </div>
    <div id="divTabsXXXXXX">
        <div id="div_tablapermisos" style="width: 1100px">
            <table id="tab_Permisos" cellpadding="0" cellspacing="0" class="GridView" width="1100">
                <thead>
                    <tr>
                        <th style="width: 400px">
                            Pagina
                        </th>
                        <th>
                            Permiso
                        </th>
                    </tr>
                </thead>
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
    <input id="hfIDFamilia" type="hidden" value="0" />
</asp:Content>
