var AppSession = "../Reportes/Inventario_MovimientoProducto.aspx";

var CodigoMenu = 10000;
var CodigoInterno = 100004;

var ddlFamilia;
var ddlLinea;
var ddlMarca; 
var ddlMoneda;
var ddlAlmacen;
var ddlTipoReporte;


var P_RPT_UNIDADES_FILTRO_FAMILIA;
var P_RPT_UNIDADES_FILTRO_MARCAS;
var P_RPT_UNIDADES_FILTRO_PROCEDENCIA;

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

    $('.Jq-ui-dtp').datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: 'dd/mm/yy'
    });

    $('.Jq-ui-dtp').datepicker($.datepicker.regional['es']);

    $('.Jq-ui-dtp').datepicker('setDate', new Date());

//    $('#MainContent_txtDesde').datepicker({ onSelect: function () {
//        var date = $(this).datepicker('getDate');
//        if (date) {
//            date.setDate(1);
//            $(this).datepicker('setDate', date);
//        }
//    }
//    });

//    $('#MainContent_txtDesde').datepicker({ beforeShowDay: function (date) {
//        return [date.getDate() == 1, ''];
//    }
//    });

//    $('#MainContent_txtHasta').datepicker({ onSelect: function () {
//        var date = $(this).datepicker('getDate');
//        if (date) {
//            date.setDate(1);
//            $(this).datepicker('setDate', date);
//        }
//    }
//    });

//    $('#MainContent_txtHasta').datepicker({ beforeShowDay: function (date) {
//        return [date.getDate() == 1, ''];
//    }
//    });

    $('#MainContent_btnReportePorFamilia').click(function () {
        try {
            F_Reporte(1);

            return false;
        }

        catch (e) {

            alert("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnReporteGeneral').click(function () {
        try {
            F_Reporte(2);

            return false;
        }

        catch (e) {

            alert("Error Detectado: " + e);
        }

    });
    $('.MesAnioPicker').datepicker({
        changeMonth: true,
        changeYear: true,
        showButtonPanel: true,
        dateFormat: 'dd/mm/yy'
    });

    $('.MesAnioPicker').datepicker($.datepicker.regional['es']);

    $('.MesAnioPicker').datepicker('setDate', new Date());

    
    F_Inicializar_Parametros();


    if (P_RPT_UNIDADES_FILTRO_FAMILIA != '1')
        $('#trFamilia').css('display', 'none');

    if (P_RPT_UNIDADES_FILTRO_MARCAS != '1')
        $('#trMarca').css('display', 'none');

    if (P_RPT_UNIDADES_FILTRO_PROCEDENCIA != '1')
        $('#trProcedencia').css('display', 'none');


    F_Controles_Inicializar();

    $('#MainContent_txtDesde').css('background', '#FFFFE0');

    $('#MainContent_txtHasta').css('background', '#FFFFE0');

    $('#MainContent_ddlMoneda').css('background', '#FFFFE0');



});


$(document).unbind('keydown').bind('keydown', function (event) {
    var doPrevent = false;
    if (event.keyCode === 8) {
        var d = event.srcElement || event.target;
        if ((d.tagName.toUpperCase() === 'INPUT' && (d.type.toUpperCase() === 'TEXT' || d.type.toUpperCase() === 'PASSWORD' || d.type.toUpperCase() === 'FILE' || d.type.toUpperCase() === 'EMAIL'))
             || d.tagName.toUpperCase() === 'TEXTAREA') {
            doPrevent = d.readOnly || d.disabled;
        }
        else {
            doPrevent = true;
        }
    }

    if (doPrevent) {
        event.preventDefault();
    }
});

function VerifySessionState(result) { }

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

function F_Inicializar_Parametros() {
    P_CodMoneda = "1";
    P_RPT_UNIDADES_FILTRO_FAMILIA  = '1';
    P_RPT_UNIDADES_FILTRO_MARCAS  = '1';
    P_RPT_UNIDADES_FILTRO_PROCEDENCIA  = '1';

    var Parametros = F_ParametrosPagina('', CodigoMenu, CodigoInterno);
    $.each(Parametros, function (index, item) {

        switch (item.Parametro) {
            case "P_CODMONEDA":
                P_CodMoneda = item.Valor;
                break;
            case "P_RPT_UNIDADES_FILTRO_FAMILIA":
                P_RPT_UNIDADES_FILTRO_FAMILIA = item.Valor;
                break;
            case "P_RPT_UNIDADES_FILTRO_MARCAS":
                P_RPT_UNIDADES_FILTRO_MARCAS = item.Valor;
                break;
            case "P_RPT_UNIDADES_FILTRO_PROCEDENCIA":
                P_RPT_UNIDADES_FILTRO_PROCEDENCIA = item.Valor;
                break;
        };

    });

    return true;
}


function F_Controles_Inicializar() {
        $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: 'Inventario_MovimientoProducto.aspx/F_Familias_Listar_NET',
        data: "{'pTodos':'0'}",
        dataType: "json",
        async: false,
        success: function (json) {

                let data = []
                var d = json.d;
                for (let i = 0; i < d.length; i++) {
                data.push({
                text: d[i].DscFamilia,
                value: d[i].IdFamilia
                    
                    })
                };

                ddlFamilia = new SlimSelect({
                  select: '#ddlFamilia',
                  placeholder: 'TODAS LAS FAMILIAS POR DEFECTO',
                  searchingText: 'Buscando...', // Optional - Will show during ajax request
                  searchText: 'NO SE ENCONTRARON FAMILIAS',
                  searchPlaceholder: 'BUSQUEDA DE FAMILIAS',
                  searchFocus: true, // Whether or not to focus on the search input field
                  closeOnSelect: false,
                  data: data
                });

                },
                error: function (response) {
                    alertify.log(response.responseText);
                    callback(false);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                    callback(false);
                }
            });



            ddlLinea = new SlimSelect({
                select: '#ddlLinea',
                placeholder: 'TODAS LAS LINEAS POR DEFECTO',
                searchingText: 'Buscando...', // Optional - Will show during ajax request
                searchText: 'NO SE ENCONTRARON LINEAS',
                searchPlaceholder: 'BUSQUEDA DE LINEAS',
                searchFocus: true, // Whether or not to focus on the search input field
                closeOnSelect: false,
                  ajax: function (search, callback) {
                    // Check search value. If you dont like it callback(false) or callback('Message String')
                    if (search.length < 2) {
                      callback('Necesita 3 caracteres')
                      return
                    }

                        $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: 'Inventario_MovimientoProducto.aspx/F_Lineas_Listar_NET',
                        data: "{'Descripcion':'" + search + "'}",
                        dataType: "json",
                        async: false,
                        success: function (json) {

                                let data = [];
                                var d = json.d;
                                for (let i = 0; i < d.length; i++) {
                                data.push({
                                text: d[i].DscFamilia,
                                value: d[i].IdFamilia
                    
                            })
                        };

                        callback(data);

                                },
                                error: function (response) {
                                    alertify.log(response.responseText);
                                    callback(false);
                                },
                                failure: function (response) {
                                    alertify.log(response.responseText);
                                    callback(false);
                                }
                            });

                  }
            });

            ddlMarca = new SlimSelect({
                select: '#ddlMarca',
                placeholder: 'TODAS LAS MARCAS POR DEFECTO',
                searchingText: 'Buscando...', // Optional - Will show during ajax request
                searchText: 'NO SE ENCONTRARON MARCAS',
                searchPlaceholder: 'BUSQUEDA DE MARCAS SEGUN FAMILIAS SELECCIONADAS',
                searchFocus: true, // Whether or not to focus on the search input field
                closeOnSelect: false,
                  ajax: function (search, callback) {
                    // Check search value. If you dont like it callback(false) or callback('Message String')
                    if (search.length < 2) {
                      callback('Necesita 3 caracteres')
                      return
                    }


                    var seleccionados = ddlFamilia.selected();
                    var arrDetalle = new Array();
                        $.each(seleccionados, function (index, item) {
                            var objDetalle = {
                            IdFamilia: item
                            };
                    
                            arrDetalle.push(objDetalle);
                        });

                        $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: 'Inventario_MovimientoProducto.aspx/F_Marcas_Por_Familias_Listar_NET',
                        data: "{'xml':'" + Sys.Serialization.JavaScriptSerializer.serialize(arrDetalle) + "'}",
                        dataType: "json",
                        async: false,
                        success: function (json) {

                                let data = [];
                                var d = json.d;
                                for (let i = 0; i < d.length; i++) {
                                data.push({
                                text: d[i].Marca,
                                value: d[i].Marca
                    
                            })
                        };

                        callback(data);

                                },
                                error: function (response) {
                                    alertify.log(response.responseText);
                                    callback(false);
                                },
                                failure: function (response) {
                                    alertify.log(response.responseText);
                                    callback(false);
                                }
                            });

                  }
            });

            ddlMoneda = new SlimSelect({
              select: '#ddlMoneda'
            });

            ddlTipoReporte = new SlimSelect({
              select: '#ddlTipoReporte'
            });


        $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: 'Inventario_MovimientoProducto.aspx/F_Almacenes_Listar_NET',
        data: "{'pTodos':'1'}",
        dataType: "json",
        async: false,
        success: function (json) {

                let data = []
                var d = json.d;
                for (let i = 0; i < d.length; i++) {
                data.push({
                text: d[i].DscAlmacen,
                value: d[i].CodAlmacen
                    
                    })
                };

                ddlAlmacen = new SlimSelect({
                  select: '#ddlAlmacen',
                  //placeholder: 'TODAS LAS FAMILIAS POR DEFECTO',
                  searchingText: 'Buscando...', // Optional - Will show during ajax request
                  searchText: 'NO SE ENCONTRARON ALMACENES',
                  searchPlaceholder: 'BUSQUEDA DE ALMACENES',
                  searchFocus: true, // Whether or not to focus on the search input field
                  closeOnSelect: true,
                  data: data
                });

                },
                error: function (response) {
                    alertify.log(response.responseText);
                    callback(false);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                    callback(false);
                }
            });




}



function F_Reporte(TipoReporte) {

    var Cuerpo = '#MainContent_';
    var Cadena = 'Ingresar los sgtes. Datos:';
    var falt = 0;

    if ($(Cuerpo + 'txtDesde').val() == '') {
        falt++;
        Cadena = Cadena + '<p></p>' + 'Desde';
    }

    if ($(Cuerpo + 'txtHasta').val() == '') {
        falt++;
        Cadena = Cadena + '<p></p>' + 'Hasta';
    }

    if (falt != 0) {
        alert(Cadena);
        return false;
    }

    var arrFamilias = new Array();
    $.each(ddlFamilia.selected(), function (index, item) {
        var objDetalle = {
        IdFamilia: item
        };
                    
        arrFamilias.push(objDetalle);
    });

    var arrLinea = new Array();
    $.each(ddlLinea.selected(), function (index, item) {
        var objDetalle = {
        IdLinea: item
        };
                    
        arrLinea.push(objDetalle);
    });

    var arrMarcas = new Array();
    $.each(ddlMarca.selected(), function (index, item) {
        var objDetalle = {
        Marca: item
        };
                    
        arrMarcas.push(objDetalle);
    });

    var rptURL = '';
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var TipoArchivo = 'application/pdf';
    var CodTipoArchivo = '5';
    var CodMenu = '11';

    if (TipoReporte == 2)
        var CodMenu = '12';    

    rptURL = '../Reportes/Web_Pagina_ConstruirExcel.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'CodTipoArchivo=' + CodTipoArchivo + '&';
    rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
    rptURL = rptURL + 'Desde=' + $('#MainContent_txtDesde').val() + '&';
    rptURL = rptURL + 'Hasta=' + $('#MainContent_txtHasta').val() + '&';
    rptURL = rptURL + 'Lineas=' + Sys.Serialization.JavaScriptSerializer.serialize(arrLinea) + '&';
    rptURL = rptURL + 'Familias=' + Sys.Serialization.JavaScriptSerializer.serialize(arrFamilias) + '&';
    rptURL = rptURL + 'Marcas=' + Sys.Serialization.JavaScriptSerializer.serialize(arrMarcas) + '&';
    rptURL = rptURL + 'CodMoneda=' + ddlMoneda.selected()[0] + '&';
    rptURL = rptURL + 'CodAlmacen=' + ddlAlmacen.selected()[0] + '&';
    rptURL = rptURL + 'TipoReporte=' + ddlTipoReporte.selected()[0] + '&';
    rptURL = rptURL + 'CodEmpresa=' + 3 + '&';
    rptURL = rptURL + 'Descripcion=' + '' + '&';
    
    alertify.log('Este reporte puede tardar varios minutos, por favor espere');
    window.open(rptURL, "PopUpRpt", Params);

    return false;
}
