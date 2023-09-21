<%@ Page Title="REPORTE PLANILLA" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  CodeBehind="RRHH_PlanillaSemana_RCC.aspx.cs" Inherits="SistemaInventario.Reportes.RRHH_PlanillaSemana_RCC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js" type="text/javascript"></script>       
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/alertify.min.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript" charset="UTF-8"></script>
   <script type="text/javascript" language="javascript" src="RRHH_PlanillaSemana_RCC.js" charset="UTF-8"></script>   
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"  type="text/css" />      
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.core.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.default.css" rel="stylesheet" type="text/css" />
     <script src="../Planilla/UtilitariosPlanillas.js" type="text/javascript"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo" style="width: 600px">
        REPORTE PLANILLA 
    </div>
    <div id="tabRegistro" style="width: 600px">
        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                CRITERIO DE BUSQUEDA
            </div>
            <div id="divConsultaArticulo">
                <div class="ui-jqdialog-content">
                    <table cellpadding="0" cellspacing="0" class="form-inputs">
                        <tr>
                            <td style="font-weight: bold">
                                Regimen Laboral
                            </td>
                            <td>
                                <div id="div_regimenlaboral">
                                    <asp:DropDownList ID="ddlRegimenLaboral" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                            <tr class="trCivil">
                            <td style="font-weight: bold">
                                Proyecto
                            </td>
                            <td>
                                <div id="div_proyecto">
                                    <asp:DropDownList ID="ddlProyecto" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True">
                                    </asp:DropDownList>
                               </div>
                            </td>
                        </tr>

                        <tr class="trCivil">
                            <td style="font-weight: bold">
                                Nro Semana Inicio
                            </td>
                            <td>
                      <table cellpadding="0" cellspacing="0">
                            <tr>
                              <td>
                                <asp:TextBox ID="txtAñoSemanaInicio" runat="server" Width="50px" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True"></asp:TextBox>
                            </td>
                         
                                             <td>
                                                <asp:Label ID="lblDisplaySemanaInicio" runat="server" Text="" Font-Bold="true" Font-Size="Small"></asp:Label>
                                            </td>
                                            <td style="display: none">
                                                <asp:Label runat="server" ID="lblCodSemanaInicio"></asp:Label>
                                            </td>
                            </tr>
                      </table>
                            </td>
                
                                 </tr>               
                      <tr class="trCivil">
                            <td style="font-weight: bold">
                                Nro Semana Fin
                            </td>
                            <td>
                      <table cellpadding="0" cellspacing="0">
                            <tr>
                              <td>
                                <asp:TextBox ID="txtAñoSemanaFinal" runat="server" Width="50px" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True"></asp:TextBox>
                            </td>                         
                                             <td>
                                                <asp:Label ID="lblDisplaySemanaFinal" runat="server" Text="" Font-Bold="true" Font-Size="Small"></asp:Label>
                                            </td>
                                            <td style="display: none">
                                                <asp:Label runat="server" ID="lblCodSemanaFinal"></asp:Label>
                                            </td>
                            </tr>
                      </table>
                            </td>                
                                 </tr> 
                      <tr>
                                <td style="font-weight: bold">
                                    Periodo
                                </td>
                                <td>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtAñoPeriodo" runat="server" Width="50px" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Size="Small" Font-Bold="True"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDisplayPeriodo" runat="server" Text="" Font-Bold="true" Font-Size="Small"></asp:Label>
                                            </td>
                                            <td style="display: none">
                                                <asp:Label runat="server" ID="lblCodPeriodo"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>     
                    </table>
                </div>
                <div class="linea-button">
                    <asp:Button ID="btnExcel" runat="server" Text="Excel" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Width="120px"/>              
                </div>
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
    <input id="hfCodTipoCliente" type="hidden" value="2" />
    <input id="hfCodCtaCte" type="hidden" value="0" />
</asp:Content>