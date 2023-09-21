var AppSession = "../Inventario/ProductosCargaMasiva.js";
var CodigoMenu = 2000;
var CodigoInterno = 9;

$(document).ready(function () {
    $("#MainContent_btnImport").click(function () {
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        $('#MainContent_hfEmision').val($('#MainContent_txtEmision').val());

        $('#lblCantidadRegistro').text(F_Numerar_Grilla("grvDetalleArticulo", " CssClass="detallesart" "));
    });
});

function MostrarEspera(pboolMostrar) {
    if (pboolMostrar) {
        $('#dlgWait').dialog({
            autoOpen: false,
            modal: true,
            height: 'auto',
            resizable: false,
            dialogClass: 'alert'
        });

        $('.alert div.ui-dialog-titlebar').hide();
        //        $('.ui-button').remove();
        $('#dlgWait').dialog('open');
    }
    else {
        $('#dlgWait').dialog('close');
    }
}















