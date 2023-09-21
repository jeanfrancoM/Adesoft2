<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Graficos.aspx.cs" Inherits="SistemaInventario.Graficos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"
        type="text/javascript"></script>
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript"
        charset="UTF-8"></script>
    <script src="../Scripts/inputatajos/kibo.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="Graficos.js" charset="UTF-8"></script>
    <link href="../Asset/css/redmond/jquery-ui-1.10.4.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.core.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.default.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/sss.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/toars/toastr.min.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/toars/toastr.min.js" type="text/javascript"></script>

    <link  href="../Asset/graficos_morris.js-0.5.1/morris.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/graficos_morris.js-0.5.1/raphael-min.js" type="text/javascript"></script>
    <script src="../Asset/graficos_morris.js-0.5.1/morris.js" type="text/javascript"></script>
    <script src="../Asset/graficos_morris.js-0.5.1/otros/rgbcolor.js" type="text/javascript"></script>
    <script src="../Asset/graficos_morris.js-0.5.1/otros/canvg.js" type="text/javascript"></script>
    <script src="../Asset/graficos_morris.js-0.5.1/otros/canvg.min.js" type="text/javascript"></script>
    <script src="../Asset/graficos_morris.js-0.5.1/otros/jspdf.min.js" type="text/javascript"></script>
    <script src="../Asset/graficos_morris.js-0.5.1/otros/html2canvas.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%--    <button id="btnGraficos" onclick="F_Controles_Inicializar(); return false;">
        Graficos</button>--%>
    <button id="btnPDF" onclick="F_PDF(); return false;">
        pdf</button>
<%--    <button id="btnGuardar">
        save</button>--%>
    <div id="bar-Total">
    </div>
    <div id="bar-multi-Xdocumentos-Yperiodos">
    </div>
    <div id="bar-multi-Yperiodos-Xdocumentos">
    </div>
    <div id="line-example">
    </div>
    <div id="donut-example">
    </div>
    <div id="graph" style="height: 250px;">
    </div>
    <div id="myfirstchart" style="height: 250px;">
    </div>
    <canvas style="display: none" id="canvas" width="800px" height="600px">
    </canvas>
    <asp:TextBox ID="txtClienteConsulta" runat="server" Width="280" Font-Names="Arial"
        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
    <%--<div id="mysecondchart" style="height: 250px;"></div>--%>
</asp:Content>
