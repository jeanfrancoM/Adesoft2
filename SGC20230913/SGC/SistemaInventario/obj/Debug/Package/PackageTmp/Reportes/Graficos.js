$(document).ready(function () {
    VerificarSession = false;

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }
    
    F_Controles_Inicializar();

    $('#MainContent_btnBuscar').click(function () {
        try {
            var Cadena = 'Ingresar los sgtes. Datos: ';

            if ($('#MainContent_txtUsuario').val() == '')
                Cadena = Cadena + '\n' + 'Usuario'

            if ($('#MainContent_txtContraseña').val() == '')
                Cadena = Cadena + '\n' + 'Contraseña'

            if (Cadena != 'Ingresar los sgtes. Datos: ') {
                toastr.warning(Cadena);
                return false;
            }

            F_Buscar();

            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

    $("#MainContent_txtUsuario").focus();

    $('#MainContent_txtUsuario').css('background', '#FFFFE0');

    $('#MainContent_txtContraseña').css('background', '#FFFFE0');



    $('#btnGuardar').click(function() {       
        f_guardar();

        return false;
    });

});

var Desde = 20190101;
var Hasta = 20191231;

function F_Controles_Inicializar() {


        $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: 'Graficos.aspx/F_VentasUnidades',
        data: "{'Desde':'" + Desde + "','Hasta':'" + Hasta + "'}",
        dataType: "json",
        async: false,
        success: function (json) {



        

try {
                //grafico X:DOCUMENTOS Y:PERIODOS
            let data = []
            //Para XDocumentos YPeriodos
            var yKeysDP = [];
            var labelsDP = [];
            var yKeysPD = [];
            var labelsPD = [];
            var pas = false;
            var d = json.d;
            for (let j = 0; j < d.length; j++) {

                var DocumentosVentas = new Object();
                DocumentosVentas["Doc"] =         d[j].Doc;
                DocumentosVentas["Documento"] =   d[j].Documento + ', TOTAL: ' + d[j].Total;
                DocumentosVentas["Total"] =       d[j].Total;

                yKeysPD.push(d[j].Documento);
                labelsPD.push(d[j].Documento);


                                //creo los periodos
                                var cper = 0;
                                for (let ii = 0; ii < d[j].VentasPeriodos.length; ii++) { 
                                    DocumentosVentas[d[j].VentasPeriodos[ii].PeriodoStr] = d[j].VentasPeriodos[ii].TotalPeriodo;
                                            if (pas === false) {
                                                yKeysDP.push(d[j].VentasPeriodos[ii].PeriodoStr);
                                                labelsDP.push(d[j].VentasPeriodos[ii].PeriodoStr);
                                                }

                                                cper++;
                                                                                               

                                }
                                        pas = true;


            data.push(DocumentosVentas)
            DocumentosVentas = {};
            };

            Morris.Bar({
                element: 'bar-Total',
                data: data,
                xkey: 'Documento',
                ykeys: ['Total'],
                labels: ['Total'],
                stacked: true,
            });

            Morris.Bar({
                element: 'bar-multi-Xdocumentos-Yperiodos',
                data: data,
                xkey: 'Documento',
                ykeys: yKeysDP,
                labels: labelsDP,
                stacked: true,
            });

} catch (e) { 
    toastr.warning(e);
}


                },
                error: function (response) {
                    toastr.warning(response.responseText);
                    callback(false);
                },
                failure: function (response) {
                    toastr.warning(response.responseText);
                    callback(false);
                }
            });




        $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: 'Graficos.aspx/F_VentasUnidades2',
        data: "{'Desde':'" + Desde + "','Hasta':'" + Hasta + "'}",
        dataType: "json",
        async: false,
        success: function (json) {



        

try {
                //grafico X:DOCUMENTOS Y:PERIODOS
            let data = []
            //Para XDocumentos YPeriodos
            var yKeysDP = [];
            var labelsDP = [];
            var yKeysPD = [];
            var labelsPD = [];
            var pas = false;
            var d = json.d;
            for (let j = 0; j < d.length; j++) {

                var DocumentosVentas = new Object();
                DocumentosVentas["PeriodoStr"] =         d[j].PeriodoStr;
                DocumentosVentas["Periodo"] =         d[j].Periodo;
                DocumentosVentas["Total"] =       d[j].TotalPeriodo;

                yKeysPD.push(d[j].PeriodoStr);
                labelsPD.push(d[j].PeriodoStr);


                                //creo los periodos
                                var cper = 0;
                                for (let ii = 0; ii < d[j].VentasDocumentos.length; ii++) { 
                                            DocumentosVentas[d[j].VentasDocumentos[ii].Documento] = d[j].VentasDocumentos[ii].TotalDocumento;
                                            if (pas === false) {
                                                yKeysDP.push(d[j].VentasDocumentos[ii].Documento);
                                                labelsDP.push(d[j].VentasDocumentos[ii].Documento);
                                                }

                                                cper++;
                                                                                               

                                }
                                        pas = true;


            data.push(DocumentosVentas)
            DocumentosVentas = {};
            };

            Morris.Bar({
                element: 'bar-multi-Yperiodos-Xdocumentos',
                data: data,
                xkey: 'PeriodoStr',
                ykeys: yKeysDP,
                labels: labelsDP,
                stacked: true,
            });


    //----------------
    // Use Morris.Line
    //----------------
    Morris.Line({
      element: 'line-example',
                data: data,
                xkey: 'PeriodoStr',
                ykeys: yKeysDP,
                labels: labelsDP,
    });


} catch (e) { 
    toastr.warning(e);
}


                },
                error: function (response) {
                    toastr.warning(response.responseText);
                    callback(false);
                },
                failure: function (response) {
                    toastr.warning(response.responseText);
                    callback(false);
                }
            });











            
    //----------------
    // Use Morris.Bar
    //----------------
    Morris.Bar({
        element: 'myfirstchart',
        data: [
                { x: '2011 Q1', y: 3, z: 2, a: 3, j: 14 },
                { x: '2011 Q2', y: 2, z: null, a: 1, j: 9 },
                { x: '2011 Q3', y: 0, z: 2, a: 4, j: null },
                { x: '2011 Q4', y: 2, z: 4, a: 3, j: 10 }
              ],
        xkey: 'x',
        ykeys: ['y', 'z', 'a', 'j'],
        labels: ['Producto Y', 'Producto Z', 'Producto A', 'Producto J']
    }).on('click', function (i, row) {
        console.log(i, row);
    });
    //----------------        

    //return true;

    //----------------
    // Use Morris.Donut
    //----------------
    Morris.Donut({
        element: 'donut-example',
        data: [
                {label: "Download Sales", value: 12},
                {label: "In-Store Sales", value: 30},
                {label: "Mail-Order Sales", value: 20}
              ]
    });
    //----------------




    return false;
}

function f_guardar() {

    var svg = $("#bar-multi-Yperiodos-Xdocumentos").html();        
    canvg(document.getElementById('canvas'), svg.split("<div")[0]);    
    
    var imgData = canvas.toDataURL('image/png'); 
        
        $("#MainContent_imgFINAL").attr("src", imgData);

return true;
}


function F_PDF() {

    //transformo el grafico a img guardado en el canvas oculto
    var svg = $("#bar-multi-Yperiodos-Xdocumentos").html();        
    canvg(document.getElementById('canvas'), svg.split("<div")[0]);     
    //obtengo la imagen
    var imgData = canvas.toDataURL('image/png'); 

    var arg;
    try {
        var objParams =
            {
                Filtro_Img: imgData,
                Filtro_Desde: Desde,
                Filtro_Hasta: Hasta
            };

        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        F_CrearPDF_NET
            (
                arg,
                function (result) {

                    var direccion = "";

            direccion = result.split('~')[0];



   var rptURL = '';
    var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
    var TipoArchivo = 'application/pdf';
    var CodTipoArchivo = '5';
    var CodMenu = 2004;
    var SerieDoc = '0';

    rptURL = '../Reportes/Web_Crystal.aspx';
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

