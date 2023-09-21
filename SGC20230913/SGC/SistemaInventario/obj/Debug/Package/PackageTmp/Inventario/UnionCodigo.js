var AppSession = "../Inventario/UnionCodigo.aspx";

var CodigoMenu = 2000;
var CodigoInterno = 6;

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

    //    document.onkeydown = function (evt) {
    //        return (evt ? evt.which : event.keyCode) != 13;
    //    }

    $('#MainContent_btnGrabar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
        try {
            if (!F_ValidarGrabarDocumento())
                return false;

            if (confirm("ESTA SEGURO DE GRABAR"))
                F_GrabarDocumento();

            return false;
        }
        catch (e) {
            alertify.log("Error Detectado: " + e);
                    }

    });

    $('#MainContent_txtArticulo').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_LGProductos_Select',
                data: "{'Descripcion':'" + request.term + "','CodAlmacen':'" + $('#hfCodSede').val() + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0],
                            Stock: item.split(',')[2],
                            Costo: item.split(',')[3],
                            Moneda: item.split(',')[4],
                            CodProducto: item.split(',')[5],
                            NroSerie: item.split(',')[6]
                        }
                    }))
                },
                error: function (response) {
                    alertify.log(response.responseText);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfCodProductoCorrecto').val(i.item.CodProducto);         
        },
        minLength: 3
    });

    $('#MainContent_txtCodProductoIncorrecto').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_LGProductos_Select',
                data: "{'Descripcion':'" + request.term + "','CodAlmacen':'" + $('#hfCodSede').val() + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0],
                            Stock: item.split(',')[2],
                            Costo: item.split(',')[3],
                            Moneda: item.split(',')[4],
                            CodProducto: item.split(',')[5],
                            NroSerie: item.split(',')[6]
                        }
                    }))
                },
                error: function (response) {
                    alertify.log(response.responseText);
                },
                failure: function (response) {
                    alertify.log(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfCodProductoIncorrecto').val(i.item.CodProducto);
      },
        minLength: 3
    });

    $('#MainContent_btnAgregarFactura').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
        try {
            var Cadena = "Ingrese los sgtes. campos: "
            if ($('#hfCodCtaCte').val() == "0")
                Cadena = Cadena + '\n' + "Razon Social";

            if (Cadena != "Ingrese los sgtes. campos: ") {
                alertify.log(Cadena);
                return false;
            }

            $("#divConsultaFactura").dialog({
                resizable: false,
                modal: true,
                title: "Consulta de Factura",
                title_html: true,
                height: 450,
                width: 390,
                autoOpen: false
            });

            $('#divConsultaFactura').dialog('open');


            var objParams = {
                Filtro_CodCtaCte: $('#hfCodCtaCte').val(),
                Filtro_CodMoneda: $('#MainContent_ddlMoneda').val()
            };
            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);


            F_Buscar_Factura_NET(arg, function (result) {
                //                var Entity = Sys.Serialization.JavaScriptSerializer.deserialize(result);

                //                MostrarEspera(false);

                var str_resultado_operacion = "";
                var str_mensaje_operacion = "";

                str_resultado_operacion = result.split('~')[0];
                str_mensaje_operacion = result.split('~')[1];

                if (str_resultado_operacion == "1") {

                    F_Update_Division_HTML('div_grvConsultaFactura', result.split('~')[2]);

                }
                else {
                    alertify.log(result.split('~')[1]);
                }

                return false;

            });


        }
        catch (e) {

            alertify.log("Error Detectado: " + e);
        }


        return false;

    });

    $('#MainContent_btnNuevo').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            F_Nuevo();
            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnEliminar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if (F_ValidarEliminar() == false)
                return false;

            if (confirm("Esta seguro de eliminar los productos seleccionado"))
                F_EliminarTemporal();

            return false;
        }

        catch (e) {

            alertify.log("Error Detectado: " + e);
        }

    });

    F_Controles_Inicializar();

    $('#MainContent_txtArticulo').css('background', '#FFFFE0');

    $('#MainContent_txtCodProductoIncorrecto').css('background', '#FFFFE0');

});

$(document).keypress(function (event) {
    var keycode = (event.keyCode ? event.keyCode : event.which);
    if (keycode == '13') {
        console.log('You pressed a "enter" key in somewhere');
    }
});

$().ready(function () {
    $(document).everyTime(600000, function () {
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

function F_Controles_Inicializar() {

    var arg;

    try {
        var objParams =
            {

                Filtro_CodSerie: 52
            };


        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

        F_Controles_Inicializar_NET
            (
                arg,
                function (result) {

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];

                    if (str_resultado_operacion == "1") {
                        F_Update_Division_HTML('div_TipoOperaciones', result.split('~')[2]);
                        $('#hfCodSede').val(result.split('~')[3]);
                        $('#MainContent_ddlTipoOperaciones').val('2');
                        $('#MainContent_ddlTipoOperaciones').css('background', '#FFFFE0');
                    }

                    else {

                        alertify.log(str_mensaje_operacion);

                    }


                }
            );

    } catch (mierror) {

        alertify.log("Error detectado: " + mierror);

    }

}

function F_ValidarGrabarDocumento() {

    try {
        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

        if ($(Cuerpo + 'txtArticulo').val() == '' || $('#hfCodProductoCorrecto').val() == 0)
            Cadena = Cadena + '<p></p>' + 'Producto Correcto';

        if ($(Cuerpo + 'txtCodProductoIncorrecto').val() == '' || $('#hfCodProductoIncorrecto').val() == 0)
            Cadena = Cadena + '<p></p>' + 'Producto Incorrecto';


        if (Cadena != 'Ingresar los sgtes. Datos:') {
            alertify.log(Cadena);
            return false;
        }
        return true;
    }

    catch (e) {

        alertify.log("Error Detectado: " + e);
    }
}

function F_GrabarDocumento() {

    try {
        var Contenedor = '#MainContent_';

        var objParams = {
            Filtro_CodProductoCorrecto: $('#hfCodProductoCorrecto').val(),
            Filtro_CodProductoIncorrecto: $('#hfCodProductoIncorrecto').val()
        };


        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_GrabarDocumento_NET(arg, function (result) {

            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'SE GRABO CORRECTAMENTE') {
                    alertify.log('SE GRABO CORRECTAMENTE');
                    F_Nuevo();
                }

            }
            else {
                alertify.log(result.split('~')[1]);
            }

            return false;

        });
    }

    catch (e) {

        alertify.log("Error Detectado: " + e);
        return false;
    }
}

function F_Nuevo() {
    var Contenedor = '#MainContent_';

    $('#hfCodProductoCorrecto').val('0');
    $('#hfCodProductoIncorrecto').val('0');

    $(Contenedor + 'txtArticulo').val('');
    $(Contenedor + 'txtCodProductoIncorrecto').val('');
   
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
