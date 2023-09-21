var AppSession = "../Reportes/ven_grafico_VentasPorPeriodo.aspx";
var ddlFamilia;
var ddlMarca; 
var ddlMoneda;
var ddlAlmacen;
var ddlTipoReporte;
var ddlTipoGrafico;


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

    $('#MainContent_btnLimpiar').click(function () {
        try {
            F_Limpiar_Controles();
            return false;
        }

        catch (e) {

            alert("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnGenerarPdf').click(function () {
        try {
            F_PDF();
            return false;
        }

        catch (e) {

            alert("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnReporte').click(function () {
        try {
            F_Reporte();

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

function F_Controles_Inicializar() {
        $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: 'ven_grafico_VentasPorPeriodo.aspx/F_Familias_Listar_NET',
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
                        url: 'ven_grafico_VentasPorPeriodo.aspx/F_Marcas_Por_Familias_Listar_NET',
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

            ddlTipoGrafico = new SlimSelect({
              select: '#ddlTipoGrafico'
            });


        $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: 'ven_grafico_VentasPorPeriodo.aspx/F_Almacenes_Listar_NET',
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


    F_Limpiar_Controles();


}

function F_Limpiar_Controles() {
    $("#MainContent_txtDesde").prop("disabled", false);
    $("#MainContent_txtHasta").prop("disabled", false);

return false;
}

function F_Reporte() {

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

    var arrMarcas = new Array();
    $.each(ddlMarca.selected(), function (index, item) {
        var objDetalle = {
        Marca: item
        };
                    
        arrMarcas.push(objDetalle);
    });


//----------------------
//1. CREACION DE GRAFICO
//----------------------
    var xAbscisas = 'Periodo';
    var yOrdenadas = 'Soles';
    if (Number(ddlMoneda.selected()[0]) === 2)
        yOrdenadas = 'Dolares';
    if (Number(ddlMoneda.selected()[0]) === 0)
        yOrdenadas = 'Soles, Dolares';



    //Constructor de parametros para la busqueda de los datos del grafico
    var ParametrosGrafico = {};
    ParametrosGrafico["xAbscisas"] = xAbscisas; //Eje 'X' abscisas del grafico (debe ser una sola columna)
    ParametrosGrafico["yOrdenadas"] = yOrdenadas //Ejes 'Y' ordenadas del gráficos (puedes nombrar varias columnas separadas por Comas (,)
    //Parametros variables de acuerdo al reporte de grafico
    ParametrosGrafico["Desde"] = $('#MainContent_txtDesde').val();
    ParametrosGrafico["Hasta"] = $('#MainContent_txtHasta').val();
    ParametrosGrafico["CodMoneda"] = Number(ddlMoneda.selected()[0]);
    ParametrosGrafico["TipoReporte"] = Number(ddlTipoReporte.selected()[0]);
    ParametrosGrafico["CodAlmacen"] = Number((ddlAlmacen.selected()[0] === 'T')? '0' : ddlAlmacen.selected()[0]);
    ParametrosGrafico["xmlFamilias"] = ""; //Sys.Serialization.JavaScriptSerializer.serialize(arrFamilias);
    ParametrosGrafico["xmlMarcas"] = ""; //Sys.Serialization.JavaScriptSerializer.serialize(arrMarcas);

    $.ajax({
    type: "POST",
    contentType: "application/json; charset=utf-8",
    url: '../Servicios/Graficos.asmx/F_ReporteVentasPorPeriodo',
    data: JSON.stringify(ParametrosGrafico),
    dataType: "json",
    async: false,
    success: function (json) {

try {
$("#bar-Total").empty();

   var data   = F_GraficosJsonACartesiano_DATA(json.d.data);
   var yKeys  = F_GraficosJsonACartesiano_YKEYS(json.d.data);
   var Labels = F_GraficosJsonACartesiano_YKEYS(json.d.data); 


   switch (Number(ddlTipoGrafico.selected()[0])) {
    case 1:

Morris.Line({
            element: 'bar-Total',
            data: data,
            xkey: 'x',
            ykeys: yKeys,
            labels: Labels,
            parseTime: false,
});

        break;
    case 2:
        Morris.Bar({
            element: 'bar-Total',
            data: data,
            xkey: 'x',
            ykeys: yKeys,
            labels: Labels,
            stacked: true,
        });

        break;
   }



//-------------------------------
//2. CREACION DE IMAGEN EN CANVAS
//-------------------------------
    //transformo el grafico a img guardado en el canvas oculto
    var svg = $("#bar-Total").html();        
    canvg(document.getElementById('canvas'), svg.split("<div")[0]);     

} catch (e) { 
toastr.warning(e);
}


            },
            error: function (response) {
                toastr.warning(response.responseText);
            },
            failure: function (response) {
                toastr.warning(response.responseText);
            }
        });










   

    return false;
}


function F_PDF() {

//------------------
//3. CREACION DE PDF
//------------------
    //obtengo la imagen
    var imgData = canvas.toDataURL('image/png'); 

    //archivo fisico (en el directorio)
    //base64 = imagen convertida en alfanumerico

    var arg;
    try {
        var objParams =
            {
                Filtro_Img: imgData,
                Filtro_Desde: $('#MainContent_txtDesde').val(),
                Filtro_Hasta: $('#MainContent_txtHasta').val(),
                Filtro_CodMoneda : Number(ddlMoneda.selected()[0]),
                Filtro_TipoReporte: Number(ddlTipoReporte.selected()[0]),
                Filtro_CodAlmacen : Number((ddlAlmacen.selected()[0] === 'T')? '0' : ddlAlmacen.selected()[0])

            };

        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        F_CrearPDF_NET
            (
                arg,
                function (result) {

                    var direccion = "";

            direccion = result.split('~')[0];

//-----------------------
//4. VISUALIZACION DE PDF
//-----------------------

               var rptURL = '';
                var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
                var TipoArchivo = 'application/pdf';
                var CodTipoArchivo = '5';
                var CodMenu = 2004;
                var SerieDoc = '0';

                rptURL = '../Reportes/Web_Pagina_Crystal.aspx';
                rptURL = rptURL + '?';
                rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
                rptURL = rptURL + 'txt=' + direccion + '&';

                window.open(rptURL, "PopUpRpt", Params);


                }
            );

    } catch (mierror) {
    }

return false;
}