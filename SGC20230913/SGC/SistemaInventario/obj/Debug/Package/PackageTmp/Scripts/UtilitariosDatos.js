
var redireccionar = false;
function utF_Conceptos_Combos(Combo, CodPrincipal) {
    var Espera = false;
    var Resultado = false;

    var dtx = new Date();
    var timex = dtx.getHours() + dtx.getMinutes() + dtx.getSeconds();

    $.ajax({
        type: "POST",
        url: '../Servicios/DatosTCConceptosDet.asmx/F_TCConceptosDet_Listar?time=' + timex,
        data: "{'CodPrincipal':'" + CodPrincipal + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (obj, status) {

            $.each(obj.d, function (index, item) {
                $(Combo).append($("<option></option>").val(item.CodConcepto).html(item.DscAbvConcepto));
            });
            $(Combo).css('background', '#FFFFE0');

            redireccionar = false;
            Espera = true;
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            Espera = true;
            Resultado = false;
        }
    });

    do { } while (Espera == false); //Esperar a que se ejecuta el Ajax

    return true;
}








function utF_FormatoImpresionCombo(Combo, CodTipoDoc, SerieDoc) {
    var Espera = false;
    var Resultado = false;

    var dtx = new Date();
    var timex = dtx.getHours() + dtx.getMinutes() + dtx.getSeconds();

    $(Combo).empty();

    $.ajax({
        type: "POST",
        url: '../Servicios/Servicios.asmx/F_FormatoImpresion_Listar?time=' + timex,
        data: "{'CodTipoDoc':'" + CodTipoDoc + "','SerieDoc':'" + SerieDoc + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (obj, status) {

            $.each(obj.d, function (index, item) {
                $(Combo).append($("<option></option>").val(item.CodFormatoImpresion).html(item.Formato + ' - ' + item.Impresora));
            });
            $(Combo).css('background', '#FFFFE0');

            redireccionar = false;
            Espera = true;
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            Espera = true;
            Resultado = false;
        }
    });

    do { } while (Espera == false); //Esperar a que se ejecuta el Ajax

    return true;
}
