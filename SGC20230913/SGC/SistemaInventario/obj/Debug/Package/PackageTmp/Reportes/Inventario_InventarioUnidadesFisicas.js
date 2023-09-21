var AppSession = "../Reportes/Inventario_InventarioRoman.aspx";

var CodigoMenu = 10000;
var CodigoInterno = 100004;

var ddlFamilia;
var ddlLinea;
var ddlMarca;
var ddlMoneda;
var ddlAlmacen;
var ddlTipoReporte;
var ddlProcedencia;

var P_RPT_UNIDADES_FILTRO_FAMILIA;
var P_RPT_UNIDADES_FILTRO_MARCAS;
var P_RPT_UNIDADES_FILTRO_PROCEDENCIA;

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

    $('#MainContent_btnBuscar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;

        try {
            F_Buscar();
            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnExcel').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            F_VisualizarExcel();
            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnPdf').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if ($('#MainContent_txtPeriodo').val() == '')
            { alertify.log("Ingrese Periodo"); $('#MainContent_txtPeriodo').focus(); return false; }
            F_VisualizarPdf();
            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('.MesAnioPicker').datepicker({
        changeMonth: true,
        changeYear: true,
        showButtonPanel: true,
        dateFormat: 'yymm',

        onClose: function (dateText, inst) {
            var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
            var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
            $(this).val($.datepicker.formatDate('yymm', new Date(year, month, 1)));
        }
    });

    //$('.MesAnioPicker').datepicker($.datepicker.regional['es']);

    //$('.MesAnioPicker').focus(function () {
    //    $('.ui-datepicker-calendar').hide();
    //    $('#ui-datepicker-div').position({
    //        my: 'center top',
    //        at: 'center bottom',
    //        of: $(this)
    //    });
    //});


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

$().ready(function () {

    $(document).everyTime(900000, function () {
        if (!F_ValidaSesionActiva(AppSession)) return false;
    });

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

$(document).on("change", "select[id $= 'MainContent_ddlFamilia']", function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
    F_Mostrar_Marcas($('#MainContent_ddlFamilia').val());
});

function F_Mostrar_Marcas(CodFam) {
    if (!F_SesionRedireccionar(AppSession)) return false;
    var arg;

    try {

        var objParams = {
            Filtro_CodFamilia: CodFam
        };

        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_Mostrar_Marcas_NET
            (
                arg,
                function (result) {

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
                    MostrarEspera(false);
                    if (str_resultado_operacion == "1") {
                        F_Update_Division_HTML('div_Marca', result.split('~')[2]);
                        $('#MainContent_ddlMarca').css('background', '#FFFFE0');
                    }

                    else
                        alertify.log(str_mensaje_operacion);
                }
            );

    } catch (mierror) {
        MostrarEspera(false);
        alertify.log("Error detectado: " + mierror);

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
            //


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

            ddlProcedencia = new SlimSelect({
              select: '#ddlProcedencia'
            });

            

        $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: 'Inventario_MovimientoProducto.aspx/F_Almacenes_Listar_NET',
        data: "{'pTodos':'0'}",
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




}

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

function F_Buscar() {
    if (!F_SesionRedireccionar(AppSession)) return false;
    var arg;


    //Almacenes
    var arrAlmacens = new Array();
    $.each(ddlAlmacen.selected(), function (index, item) {
        var objDetalle = { Almacen: item, DscAlmacen: '' };
        arrAlmacens.push(objDetalle);
    });


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

    if (arrAlmacens.length == 0) {
        alertify.log('DEBE SELECCIONAR UNO O VARIOS ALMACENES');
        return true;
    }

    try {
        var objParams = {
            //Filtro_CodFamilia: $('#MainContent_ddlFamilia').val(),
            //Filtro_Marca: $('#MainContent_ddlMarca').val(),
            Filtro_Procedencia: ddlProcedencia.selected()[0],
            Filtro_Familias: Sys.Serialization.JavaScriptSerializer.serialize(arrFamilias),
            Filtro_Lineas: Sys.Serialization.JavaScriptSerializer.serialize(arrLinea),
            Filtro_Marcas: Sys.Serialization.JavaScriptSerializer.serialize(arrMarcas),
            Filtro_Almacenes: Sys.Serialization.JavaScriptSerializer.serialize(arrAlmacens)
        };


        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_Buscar_NET
            (
                arg,
                function (result) {

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
                    MostrarEspera(false);
                    if (str_resultado_operacion == "1") {
                        F_Update_Division_HTML('div_grvConsultaArticulo', result.split('~')[2]);
                    }
                    else {

                        alertify.log(str_mensaje_operacion);

                    }


                }
            );

    } catch (mierror) {
        MostrarEspera(false);
        alertify.log("Error detectado: " + mierror);

    }

}

function F_VisualizarExcel() {
    if (!F_SesionRedireccionar(AppSession)) return false;
    var rptURL = '';
    var Params = 'width=' + (screen.width) + ', height=' + (screen.height) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var CodMenu = '1';
    var Titulo = 'Inventario Actual ';

    rptURL = '../Reportes/Web_Pagina_Excel.aspx';
    rptURL = rptURL + '?';
    rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
    rptURL = rptURL + 'Titulo=' + Titulo + '&';

    window.open(rptURL, "PopUpRpt", Params);

    return false;
}

