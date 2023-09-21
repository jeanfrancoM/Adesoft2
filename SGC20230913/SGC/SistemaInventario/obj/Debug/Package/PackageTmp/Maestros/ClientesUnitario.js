var AppSession = "../Maestros/ClientesUnitario.aspx";

var CodigoMenu = 1000;
var CodigoInterno = 1;

var P_CodMoneda_LineaCredito_Inicial;

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
        F_FuncionesBotones();
    $('table[id$="MainContent_grvDireccion"] input.txtDistrito').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '../Servicios/Servicios.asmx/F_TCDistrito_Listar',
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: "{ 'Descripcion' : '" + request.term + "'}",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[3],
                            val: item.split(',')[0],
                            CodProvincia: item.split(',')[1],
                            CodDistrito: item.split(',')[2]
                        }
                    }))
                },
                error: function (response) {
                    toastr.warning(response.responseText);
                },
                failure: function (response) {
                    toastr.warning(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfRegionEdicion').val(i.item.val);
            $('#hfProvinciaEdicion').val(i.item.CodProvincia);
            $('#hfDistritoEdicion').val(i.item.CodDistrito);
        },
        minLength: 3
    });

    $('#MainContent_txtDistrito').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_TCDistrito_Listar',
                data: "{'Descripcion':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[3],
                            val: item.split(',')[0],
                            CodProvincia: item.split(',')[1],
                            CodDistrito: item.split(',')[2]
                        }
                    }))
                },
                error: function (response) {
                    toastr.warning(response.responseText);
                },
                failure: function (response) {
                    toastr.warning(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfRegion').val(i.item.val);
            $('#hfProvincia').val(i.item.CodProvincia);
            $('#hfDistrito').val(i.item.CodDistrito);
        },
        minLength: 3
    });

    
    $('#MainContent_txtDescripcionConsulta').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'" + 1 + "','CodTipoCliente':'" + 0 + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0],
                            Direccion: item.split(',')[2],
                            NroRuc: item.split(',')[8],
                        }
                    }))
                },
                error: function (response) {
                    toastr.error(response.responseText);
                },
                failure: function (response) {
                    toastr.error(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfCodCtaCte').val(i.item.val);
            $('#hfNroRuc').val(i.item.NroRuc);
            F_Buscar(0);
        },
        minLength: 3
    });


    $('#MainContent_txtDistritoEdicion').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_TCDistrito_Listar',
                data: "{'Descripcion':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[3],
                            val: item.split(',')[0],
                            CodProvincia: item.split(',')[1],
                            CodDistrito: item.split(',')[2]
                        }
                    }))
                },
                error: function (response) {
                    toastr.warning(response.responseText);
                },
                failure: function (response) {
                    toastr.warning(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfRegionEdicion').val(i.item.val);
            $('#hfProvinciaEdicion').val(i.item.CodProvincia);
            $('#hfDistritoEdicion').val(i.item.CodDistrito);
        },
        minLength: 3
    });

    $('#MainContent_txtDistritoDireccionEdicion').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_TCDistrito_Listar',
                data: "{'Descripcion':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[3],
                            val: item.split(',')[0],
                            CodProvincia: item.split(',')[1],
                            CodDistrito: item.split(',')[2]
                        }
                    }))
                },
                error: function (response) {
                    toastr.warning(response.responseText);
                },
                failure: function (response) {
                    toastr.warning(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfRegion').val(i.item.val);
            $('#hfProvincia').val(i.item.CodProvincia);
            $('#hfDistrito').val(i.item.CodDistrito);
        },
        minLength: 3
    });

    $('#MainContent_txtDistritoMultiple').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_TCDistrito_Listar',
                data: "{'Descripcion':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[3],
                            val: item.split(',')[0],
                            CodProvincia: item.split(',')[1],
                            CodDistrito: item.split(',')[2]
                        }
                    }))
                },
                error: function (response) {
                    toastr.warning(response.responseText);
                },
                failure: function (response) {
                    toastr.warning(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $('#hfRegionEdicion').val(i.item.val);
            $('#hfProvinciaEdicion').val(i.item.CodProvincia);
            $('#hfDistritoEdicion').val(i.item.CodDistrito);
        },
        minLength: 3
    });

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

    $('#divTabs').tabs();

    $('#MainContent_imgBuscar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            var cadena = "Ingresar los sgtes. campos :";
            if ($('#MainContent_txtArticulo').val == "")
                cadena = cadena + "<p></p>" + "Articulo"

            if ($('#MainContent_ddlMoneda option').size() == 0)
            { cadena = cadena + "<p></p>" + "Moneda"; }
            else {
                if ($('#MainContent_ddlMoneda').val() == "-1")
                    cadena = cadena + "<p></p>" + "Moneda";
            }

            if (cadena != "Ingresar los sgtes. campos :") {
                toastr.warning(cadena);
                return false;
            }

            F_Buscar_Productos()
        }
        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }


        return false;

    });

    $('#MainContent_btnAgregarFactura').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            var Cadena = "Ingrese los sgtes. campos: "
            if ($('#hfCodCtaCte').val() == "0")
                Cadena = Cadena + '<p></p>' + "Razon Social";

            if (Cadena != "Ingrese los sgtes. campos: ") {
                toastr.warning(Cadena);
                return false;
            }

            $("#divEdicionRegistro").dialog({
                resizable: false,
                modal: true,
                title: "Consulta de Factura",
                title_html: true,
                height: 450,
                width: 420,
                autoOpen: false
            });

            $('#divEdicionRegistro').dialog('open');

            var Letra = 0;
            var Factura = 0;

            if ($('#MainContent_chkFactura').is(':checked'))
                Factura = 1;

            if ($('#MainContent_chkFactura').is(':checked'))
                Letra = 1;

            var objParams = {
                Filtro_CodCtaCte: $('#hfCodCtaCte').val(),
                Filtro_CodMoneda: $('#MainContent_ddlMoneda').val(),
                Filtro_Letra: Letra,
                Filtro_Factura: Factura
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
                    toastr.warning(result.split('~')[1]);
                }

                return false;

            });


        }
        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }


        return false;

    });

    $('#MainContent_btnAgregar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if (F_ValidarAgregar() == false)
                return false;

            F_AgregarTemporal();
            $('#MainContent_txtArticulo').focus();
            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnEliminarFactura').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;

        try {
            if (F_ValidarEliminar_Factura() == false)
                return false;

            if (confirm("Esta seguro de eliminar los documentos seleccionado"))
                F_EliminarTemporal_Factura();

            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnGrabar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

        try {
            if (F_ValidarGrabarDocumento() == false)
                return false;

            if (confirm("ESTA SEGURO DE GRABAR EL CLIENTE"))
                F_GrabarDocumento();
            //                F_Nuevo();
            //            }
            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnGrabarDireccion').click(function () {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
        try {
            if (!F_ValidarGrabarDireccion())
                return false;

            if (confirm("ESTA SEGURO DE GRABAR LA DIRECCION"))
                F_GrabarDireccion();
    
            return false;
        }
        catch (e) {
            toastr.warning("Error Detectado: " + e);
        }
    });

    $('#MainContent_btnGrabarEdicionDireccion').click(function () {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
        try {
            if (!F_ValidarGrabarDireccionMultiple())
                return false;

            if (confirm("ESTA SEGURO DE GRABAR LA DIRECCION"))
                F_GrabarDireccionMultiple();

            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });
    
        $('#MainContent_btnGrabarEdicionCorreo').click(function () {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
        try {
           

            if (confirm("ESTA SEGURO DE GRABAR EL CORREO"))
                F_GrabarDireccionMultiple();

            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });
    

    $('#MainContent_btnGrabarContacto').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
        try {
            if (!F_ValidarGrabarContacto())
                return false;

            if (confirm("ESTA SEGURO DE GRABAR EL CONTACTO"))
                F_GrabarContacto();
    
            return false;
        }
        catch (e) {
            toastr.warning("Error Detectado: " + e);
        }
    });

    $('#MainContent_btnEditarContacto').click(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
        try {
            if (!F_ValidarEditarContacto())
                return false;

            if (confirm("ESTA SEGURO DE ACTUALIZAR EL Contacto"))
                F_EdicionContacto();

            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });
    
    $('#MainContent_btnNuevo').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;

        try {
            F_Nuevo();

            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnBuscarConsulta').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;

        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {
            F_Buscar(0);
            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnEdicion').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
        try {
            if (F_ValidarEdicionDocumento() == false)
                return false;

            if (confirm("ESTA SEGURO DE ACTUALIZAR LOS DATOS DEL CLIENTE"))
                F_EdicionRegistro();
            //                F_Nuevo();
            //            }
            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

      $('#MainContent_txtGPSLongEdicion').blur(function () {
        try {
            if ($('#MainContent_txtGPSLongEdicion').val() == '')
                return false;


            if (isNaN($('#MainContent_txtGPSLongEdicion').val())) 
            {
                toastr.error('posicion LongEdicionitudinal debe ser numerico');
                $('#MainContent_txtGPSLongEdicion').select();
                return false;
            }


            $('#MainContent_txtGPSLongEdicion').val(Number($('#MainContent_txtGPSLongEdicion').val()).toFixed(8));
        }
        catch (e) {
            toastr.error("Error Detectado: " + e);
        }


        return false;
    });

    $('#MainContent_txtGPSLatEdicion').blur(function () {
        try {
            if ($('#MainContent_txtGPSLatEdicion').val() == '')
                return false;


            if (isNaN($('#MainContent_txtGPSLatEdicion').val())) 
            {
                toastr.error('posicion LatEdicionitudinal debe ser numerico');
                $('#MainContent_txtGPSLatEdicion').select();
                return false;
            }


            $('#MainContent_txtGPSLatEdicion').val(Number($('#MainContent_txtGPSLatEdicion').val()).toFixed(8));
        }
        catch (e) {
            toastr.error("Error Detectado: " + e);
        }


        return false;
    });
    $('#MainContent_txtGPSLongEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtGPSLatEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtGPSLongLat').css('background', '#FFFFE0');
    $('#MainContent_txtGPSLongLatEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtGPSLongCompartir').css('background', '#FFFFE0');
    $('#MainContent_txtGPSLatCompartir').css('background', '#FFFFE0');
    $('#MainContent_txtGPSLinkCompartir').css('background', '#FFFFE0');
    $('#MainContent_txtGPSLong').css('background', '#FFFFE0');

    $('#MainContent_txtGPSLat').css('background', '#FFFFE0');

    F_Controles_Inicializar();

    F_Derecha();

    F_InicializarCajaTexto();
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

$(document).on("change", "select[id $= 'MainContent_ddlTipoCliente']", function () {
    F_ValidarTipoCliente($("#MainContent_ddlTipoCliente").val());
});

$(document).on("change", "select[id $= 'MainContent_ddlTipoCliente_Edicion']", function () {
    F_ValidarTipoClienteEdicion($("#MainContent_ddlTipoCliente_Edicion").val());
});

function F_Controles_Inicializar() {
    F_Inicializar_Parametros();
    var arg;
    var PermisoDescuento = F_PermisoOpcion_SinAviso(CodigoMenu, 1000103, '');
    try {
        var objParams = {
        Filtro_CodCargo: 6,
                Filtro_CodEstado: 1
        };

        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_Controles_Inicializar_NET
            (
                arg,
                function (result) {

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
                    MostrarEspera(false);
                    if (str_resultado_operacion == "1") {
                        F_Update_Division_HTML('div_TipoCliente', result.split('~')[2]);
                        F_Update_Division_HTML('div_tipoclienteedicion', result.split('~')[3]);
                        F_Update_Division_HTML('div_moneda', result.split('~')[4]);
                        F_Update_Division_HTML('div_monedaEdicion', result.split('~')[5]);
                        F_Update_Division_HTML('div_Categoria', result.split('~')[6]);
                        F_Update_Division_HTML('div_CategoriaEdicion', result.split('~')[7]);
                        F_Update_Division_HTML('div_Zona', result.split('~')[9]);
                        F_Update_Division_HTML('div_ZonaEdicion', result.split('~')[10]);
                      F_Update_Division_HTML('div_Vendedor', result.split('~')[11]);
                      F_Update_Division_HTML('div_VendedorEdicion', result.split('~')[12]);

                        $('#MainContent_ddlTipoCliente').val('2');
                        //$('#MainContent_txtRazonSocial').prop('disabled', false); 
                        $('#MainContent_txtNroRuc').prop('disabled', false);
                        $('#MainContent_txtApellidoPaterno').val('');
                        $('#MainContent_txtApellidoMaterno').val('');
                        $('#MainContent_txtNombres').val('');
                        $('#MainContent_txtNroDni').val('');
                        $('#MainContent_txtApellidoPaterno').prop('disabled', true);
                        $('#MainContent_txtApellidoMaterno').prop('disabled', true);
                        $('#MainContent_txtNombres').prop('disabled', true);
                        $('#MainContent_txtNroDni').prop('disabled', true);
                        $('#MainContent_ddlTipoCliente').css('background', '#FFFFE0');
                        $('#MainContent_ddlTipoCliente_Edicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlMoneda').css('background', '#FFFFE0');
                        $('#MainContent_ddlMonedaEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlCategoria').css('background', '#FFFFE0');
                        $('#MainContent_ddlCategoriaEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlZona').css('background', '#FFFFE0');
                        $('#MainContent_ddlZonaEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlZona').val('1');
                        $('#MainContent_ddlZonaEdicion').val('1');
                        $('#MainContent_ddlMoneda').val(P_CodMoneda_LineaCredito_Inicial);
                        $('#MainContent_ddlMonedaEdicion').val(P_CodMoneda_LineaCredito_Inicial);
                        $('#MainContent_ddlCategoria').val(1);
                        $('#MainContent_txtNroRuc').focus();
                        $('#MainContent_ddlCategoria').val(1);
                        $('#MainContent_ddlVendedor').css('background', '#FFFFE0');
                        $('#MainContent_ddlVendedorEdicion').css('background', '#FFFFE0');
                        $('#MainContent_txtD1').css('background', '#FFFFE0');
                        $('#MainContent_txtD2').css('background', '#FFFFE0');
                        $('#MainContent_txtD3').css('background', '#FFFFE0');
                        $('#MainContent_txtD1Editar').css('background', '#FFFFE0');
                        $('#MainContent_txtD2Editar').css('background', '#FFFFE0');
                        $('#MainContent_txtD3Editar').css('background', '#FFFFE0');
                        $('#MainContent_txtD1EnReporte').css('background', '#FFFFE0');
                        $('#MainContent_txtD2EnReporte').css('background', '#FFFFE0');
                        $('#MainContent_txtD3EnReporte').css('background', '#FFFFE0');
                        $('#MainContent_txtLineaCredito').focus('0.00');
                        $('#MainContent_txtD1').val('0.00');
                        $('#MainContent_txtD2').val('0.00');
                        $('#MainContent_txtD3').val('0.00');
                        $('#MainContent_txtD1EnReporte').val('0.00');
                        $('#MainContent_txtD2EnReporte').val('0.00');
                        $('#MainContent_txtD3EnReporte').val('0.00');
                    
                        if (PermisoDescuento==0)
                        {
                            $('#MainContent_txtD1').prop('disabled',true);
                            $('#MainContent_txtD2').prop('disabled',true);
                            $('#MainContent_txtD1EnReporte').prop('disabled',true);
                            $('#MainContent_txtD2EnReporte').prop('disabled',true);
                        }                            
                        else
                        {
                            $('#MainContent_txtD1').prop('disabled',false);
                            $('#MainContent_txtD2').prop('disabled',false);
                            $('#MainContent_txtD1EnReporte').prop('disabled',false);
                            $('#MainContent_txtD2EnReporte').prop('disabled',false);
                        } 
                        
//                        if (Permiso==0)
//                            $('#MainContent_txtLineaCredito').prop('disabled',true);                            
//                         else
//                            $('#MainContent_txtLineaCredito').prop('disabled',false);                            
                         
                              
                    }
                    else {
                        toastr.warning(str_mensaje_operacion);
                    }
                }
            );
    } catch (mierror) {
        MostrarEspera(false);
        toastr.warning("Error detectado: " + mierror);
    }
}

function F_Inicializar_Parametros() {
        P_CodMoneda_LineaCredito_Inicial = "1";
        
var Parametros = F_ParametrosPagina('', CodigoMenu, CodigoInterno);
$.each(Parametros, function (index, item) {

    switch(item.Parametro) {
        case "P_CODMONEDA_LINEACREDITO" :
        P_CodMoneda_LineaCredito_Inicial = item.Valor;
        break;
    };

});


return true;
}

function F_ValidarTipoCliente(CodTipoCliente) {
    var arg;

    try {

    switch (CodTipoCliente) {
        case '1': 
            $('#MainContent_txtNroDni').prop('disabled', false);
            $('#MainContent_txtApellidoPaterno').prop('disabled', false);
            $('#MainContent_txtApellidoMaterno').prop('disabled', false);
            $('#MainContent_txtNombres').prop('disabled', false);
            //$('#MainContent_txtRazonSocial').prop('disabled', true); 
            $('#MainContent_txtNroRuc').prop('disabled', true);
            $('#MainContent_txtRazonSocial').val('');
            $('#MainContent_txtNroRuc').val('');
            $('#MainContent_txtNroDni').focus();        
        break;
        case '2': 
            //$('#MainContent_txtRazonSocial').prop('disabled', false);
            $('#MainContent_txtNroRuc').prop('disabled', false);
            $('#MainContent_txtApellidoPaterno').val('');
            $('#MainContent_txtApellidoMaterno').val('');
            $('#MainContent_txtNombres').val('');
            $('#MainContent_txtNroDni').val('');
            $('#MainContent_txtApellidoPaterno').prop('disabled', true);
            $('#MainContent_txtApellidoMaterno').prop('disabled', true);
            $('#MainContent_txtNombres').prop('disabled', true);
            $('#MainContent_txtNroDni').prop('disabled', true);
            $('#MainContent_txtNroRuc').focus();        
        break;
        case '3': 
            F_BuscarDatosPorRucDni('11111111');
            $('#MainContent_txtNroDni').prop('disabled', true);
            $('#MainContent_txtNroRuc').prop('disabled', true);
            $('#MainContent_txtApellidoPaterno').prop('disabled', false);
            $('#MainContent_txtApellidoMaterno').prop('disabled', false);
            $('#MainContent_txtNombres').prop('disabled', false);
            //$('#MainContent_txtRazonSocial').prop('disabled', true); 
            $('#MainContent_txtNroRuc').prop('disabled', true);
            $('#MainContent_txtRazonSocial').val('');
            $('#MainContent_txtNroRuc').val('55555555555');
            $('#MainContent_txtNroDni').val('');
            $('#MainContent_txtRazonSocial').focus();        
        break;
    }
        return false;


    }
    catch (mierror) {
        toastr.warning("Error detectado: " + mierror);
    }

}

function F_ValidarTipoClienteEdicion(CodTipoCliente) {
    var arg;

    try {

    switch (CodTipoCliente) {
        case '1': 
            $('#MainContent_txtDniEdicion').prop('disabled', false);
            $('#MainContent_txtRucEdicion').prop('disabled', true);
            $('#MainContent_txtRucEdicion').val('');
            $('#MainContent_txtDniEdicion').focus();    
        break;
        case '2': 
            //$('#MainContent_txtRazonSocial').prop('disabled', false);
            $('#MainContent_txtRucEdicion').prop('disabled', false);
            $('#MainContent_txtDniEdicion').prop('disabled', true);
            $('#MainContent_txtDniEdicion').val('');
            $('#MainContent_txtRucEdicion').focus();    
        break;
        case '3': 
            $('#MainContent_txtDniEdicion').prop('disabled', true);
            $('#MainContent_txtRucEdicion').prop('disabled', true);
            $('#MainContent_txtRucEdicion').val('55555555555');
            $('#MainContent_txtDniEdicion').val('');
        break;
    }
        return false;


    }
    catch (mierror) {
        toastr.warning("Error detectado: " + mierror);
    }

}

function F_ValidarGrabarDocumento() {

    try {

        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos: <br> <p></p>';

        if ($(Cuerpo + 'txtRazonSocial').val() == '')
            Cadena = Cadena + '<p></p>' + 'Razon Social';

        if ($(Cuerpo + 'ddlTipoCliente').val() == '2' && $(Cuerpo + 'txtNroRuc').val() == '')
            Cadena = Cadena + '<p></p>' + 'Nro Ruc';

        if ($(Cuerpo + 'ddlTipoCliente').val() == '2' && ValidarRuc($(Cuerpo + 'txtNroRuc').val()) == false)
            Cadena = Cadena + "<p></p>" + "Ruc Invalido";

        if ($(Cuerpo + 'ddlTipoCliente').val() == '1' && $(Cuerpo + 'txtNroDni').val() == '')
            Cadena = Cadena + '<p></p>' + 'Nro Dni';
            
        if ($(Cuerpo + 'ddlVendedor').val() == '0' && $(Cuerpo + 'ddlVendedor').val() == '')
            Cadena = Cadena + '<p></p>' + 'Vendedor';

        if ($(Cuerpo + 'txtNroDni').val() != '' && $(Cuerpo + 'txtNroDni').val().length < 8 & $(Cuerpo + 'ddlTipoCliente').val() == '1')
            Cadena = Cadena + '<p></p>' + 'Nro Dni debe tener 8 digitos';

        if ($(Cuerpo + 'ddlTipoCliente').val() == '3' && $(Cuerpo + 'txtNroRuc').val() != '55555555555')
        {
            $(Cuerpo + 'txtNroRuc').val() = '55555555555';
            Cadena = Cadena + '<p></p>' + 'Nro. Ruc para sin documentos es 55555555555';
        }
           
           

        if (($('#MainContent_txtGPSLong').val() != "" & $('#MainContent_txtGPSLat').val() == "") |
                ($('#MainContent_txtGPSLong').val() == "" & $('#MainContent_txtGPSLat').val() != ""))
            Cadena = Cadena + '<p></p>' + "GPS Long y GPS Lat"; 

             $('#MainContent_txtGPSLong').blur(function () {
        try {
            if ($('#MainContent_txtGPSLong').val() == '')
                return false;


            if (isNaN($('#MainContent_txtGPSLong').val())) 
            {
                toastr.error('posicion longitudinal debe ser numerico');
                $('#MainContent_txtGPSLong').select();
                return false;
            }


            $('#MainContent_txtGPSLong').val(Number($('#MainContent_txtGPSLong').val()).toFixed(8));
        }
        catch (e) {
            toastr.error("Error Detectado: " + e);
        }


        return false;
    });

    $('#MainContent_txtGPSLat').blur(function () {
        try {
            if ($('#MainContent_txtGPSLat').val() == '')
                return false;


            if (isNaN($('#MainContent_txtGPSLat').val())) 
            {
                toastr.error('posicion Latitudinal debe ser numerico');
                $('#MainContent_txtGPSLat').select();
                return false;
            }


            $('#MainContent_txtGPSLat').val(Number($('#MainContent_txtGPSLat').val()).toFixed(8));
        }
        catch (e) {
            toastr.error("Error Detectado: " + e);
        }


        return false;
    });


//        if ($(Cuerpo + 'ddlTipoCliente').val() == '1' && $(Cuerpo + 'txtApellidoPaterno').val() == '')
//            Cadena = Cadena + '<p></p>' + 'Apellido Paterno';

//        if ($(Cuerpo + 'ddlTipoCliente').val() == '1' && $(Cuerpo + 'txtApellidoMaterno').val() == '')
//            Cadena = Cadena + '<p></p>' + 'Apellido Materno';

//        if ($(Cuerpo + 'ddlTipoCliente').val() == '1' && $(Cuerpo + 'txtNombres').val() == '')
//            Cadena = Cadena + '<p></p>' + 'Nombres';

        if ($(Cuerpo + 'txtDistrito').val() == '' || $('#hfDistrito').val() == '0')
            Cadena = Cadena + '<p></p>' + 'Distrito';



        if ($(Cuerpo + 'txtDireccion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Direccion';

//        if ($(Cuerpo + 'txtDireccionEnvio').val() == '')
//            Cadena = Cadena + '<p></p>' + 'Direccion de Envio';

        if (!F_ValidarCorreo($(Cuerpo + 'txtEmail').val()))
            Cadena = Cadena + '<p></p>' + 'Correo';

        if (isNaN($(Cuerpo + 'txtLineaCredito').val()))
            Cadena = Cadena + '<p></p>' + 'Monto Linea de Credito';

        if (Cadena != 'Ingresar los sgtes. Datos: <br> <p></p>') {
            toastr.warning(Cadena);
            return false;
        }
        return true;
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
    }
}

function F_GrabarDocumento() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var Contenedor = '#MainContent_';
        var FlagProveedor = 0;
        var FlagBloqueoCredito = 0;
        var FlagRetencion = 0;
        var TipoDocumento = '1';
        var GPSLong=0;
        var GPSLat=0;

        if ($('#MainContent_chkProveedor').is(':checked'))
            FlagProveedor = 1;

        if ($('#MainContent_txtNroDni').val() == '')
            TipoDocumento = '6';

        if ($(Contenedor + 'txtLineaCredito').val() == '')
            $(Contenedor + 'txtLineaCredito').val('0');

        if ($('#MainContent_chkFlagBloqueoCredito').is(':checked'))
            FlagBloqueoCredito = 1;

        if ($('#MainContent_chkRetencion').is(':checked'))
            FlagRetencion = 1;

            GPSLong=$('#MainContent_txtGPSLongLat').val().split(',')[0];
            GPSLat=$('#MainContent_txtGPSLongLat').val().split(',')[1];

        var objParams = {
            Filtro_CodTipoCliente: $(Contenedor + 'ddlTipoCliente').val(),
            Filtro_NroRuc: $(Contenedor + 'txtNroRuc').val(),
            Filtro_NroDni: $(Contenedor + 'txtNroDni').val(),
            Filtro_RazonSocial: $(Contenedor + 'txtRazonSocial').val(),
            Filtro_ApePaterno: $(Contenedor + 'txtApellidoPaterno').val(),
            Filtro_ApeMaterno: $(Contenedor + 'txtApellidoMaterno').val(),
            Filtro_Nombres: $(Contenedor + 'txtNombres').val(),
            Filtro_CodDepartamento: $('#hfRegion').val(),
            Filtro_CodProvincia: $('#hfProvincia').val(),
            Filtro_CodDistrito: $('#hfDistrito').val(),
            Filtro_Direccion: $(Contenedor + 'txtDireccion').val(),
            Filtro_DireccionEnvio: $(Contenedor + 'txtDireccion').val(),
            Filtro_FlagProveedor: FlagProveedor,
            Filtro_TipoDocumento: TipoDocumento,
            Filtro_Email: $(Contenedor + 'txtEmail').val(),
            Filtro_LineaCredito: $(Contenedor + 'txtLineaCredito').val(),
            Filtro_CodMonedaLineaCredito: $(Contenedor + 'ddlMoneda').val(),
            Filtro_CodCategoria: $(Contenedor + 'ddlCategoria').val(),
            Filtro_NombreComercial: $(Contenedor + 'txtNombreComercial').val(),
            Filtro_Contacto: $(Contenedor + 'txtNombreContactoRegistro').val(),
            Filtro_Area: $(Contenedor + 'txtAreaContactoRegistro').val(),
            Filtro_Telefono: $(Contenedor + 'txtTelefonoContactoRegistro').val(),
            Filtro_Flag_MostrarEnReporte : ($(Contenedor + 'chkContactoReporteRegistro').is(':checked'))? '1' : '0',
            Filtro_CodEstado: $(Contenedor + 'ddlContactoEstadoRegistro').val(),
            Filtro_Correo1: $(Contenedor + 'txtCorreo1ContactoRegistro').val(),
            Filtro_Correo2: $(Contenedor + 'txtCorreo2ContactoRegistro').val(),
            Filtro_Correo3: $(Contenedor + 'txtCorreo3ContactoRegistro').val(),
            Filtro_Celular1: $(Contenedor + 'txtCelular1ContactoRegistro').val(),
            Filtro_Celular2: $(Contenedor + 'txtCelular2ContactoRegistro').val(),
            Filtro_Celular3: $(Contenedor + 'txtCelular3ContactoRegistro').val(),
            Filtro_NombreComercial: $(Contenedor + 'txtNombreComercial').val(),
            Filtro_D1: $(Contenedor + 'txtD1').val(),
            Filtro_D2: $(Contenedor + 'txtD2').val(),
            Filtro_D3: $(Contenedor + 'txtD3').val(),
            Filtro_CodZona: $(Contenedor + 'ddlZona').val(),
            Filtro_CodVendedor: $(Contenedor + 'ddlVendedor').val(),
            Filtro_FlagBloqueoCredito: FlagBloqueoCredito,
            Filtro_FlagRetencion: FlagRetencion,
            Filtro_GPSLong: (GPSLong == "")? 0 : GPSLong,
            Filtro_GPSLat: (GPSLat == "")? 0 : GPSLat
        };


        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_GrabarDocumento_NET(arg, function (result) {
            //                var Entity = Sys.Serialization.JavaScriptSerializer.deserialize(result);

            //                MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'Se grabo correctamente') {               
                    toastr.success('Se Grabo Correctamente.');
                    F_LimpiarCamposGrabados();                    
                }
                else
                    toastr.warning(result.split('~')[1]);

            }
            else {
                toastr.warning(result.split('~')[1]);
            }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }
}

function F_LimpiarCamposGrabados()
{
var Contenedor = '#MainContent_';
                    $(Contenedor + 'txtNroRuc').val('');
                    $(Contenedor + 'txtNroDni').val('');
                    $(Contenedor + 'txtRazonSocial').val('');
                    $(Contenedor + 'txtApellidoPaterno').val('');
                    $(Contenedor + 'txtApellidoMaterno').val('');
                    $(Contenedor + 'txtNombres').val('');
                    $(Contenedor + 'txtRegion').val('');
                    $(Contenedor + 'txtProvincia').val('');
                    $(Contenedor + 'txtLineaCredito').val('0.00');
                    $(Contenedor + 'ddlMoneda').val('1');
                    $(Contenedor + 'txtDistrito').val('');
                    $(Contenedor + 'txtDireccion').val('');
                    $(Contenedor + 'txtDireccionEnvio').val('');
                    $(Contenedor + 'ddlTipoCliente').val('2');
                    $(Contenedor + 'txtEmail').val('');
                    $('#hfRegion').val('0');
                    $('#hfProvincia').val('0');
                    $('#hfDistrito').val('0');
                    $(Contenedor + 'txtNroRuc').prop('disabled', false);                  
                    $(Contenedor + 'txtNroDni').prop('disabled', true);
                    $(Contenedor + 'txtApellidoPaterno').prop('disabled', true);
                    $(Contenedor + 'txtApellidoMaterno').prop('disabled', true);
                    $(Contenedor + 'chkProveedor').prop('checked', false);
                    $(Contenedor + 'txtNombres').prop('disabled', true);
                    $(Contenedor + 'chkFlagBloqueoCredito').prop('checked', false);
                    $(Contenedor + 'txtNombreContactoRegistro').val('');
                    $(Contenedor + 'txtAreaContactoRegistro').val('');
                    $(Contenedor + 'txtTelefonoContactoRegistro').val('');
                    $(Contenedor + 'chkContactoReporteRegistro').prop('checked',false);
                    $(Contenedor + 'ddlContactoEstadoRegistro').val(1),
                    $(Contenedor + 'txtCorreo1ContactoRegistro').val('');
                    $(Contenedor + 'txtCorreo2ContactoRegistro').val('');
                    $(Contenedor + 'txtCorreo3ContactoRegistro').val('');
                    $(Contenedor + 'txtCelular1ContactoRegistro').val('');
                    $(Contenedor + 'txtCelular2ContactoRegistro').val('');
                    $(Contenedor + 'txtCelular3ContactoRegistro').val('');
                    $(Contenedor + 'txtNombreComercial').val('');
                    $(Contenedor + 'txtGPSLongLat').val('');
                    $(Contenedor + 'txtGPSLong').val('');
                    $(Contenedor + 'txtGPSLat').val('');
                    $('#MainContent_txtD1').val('0.00');
                    $('#MainContent_txtD2').val('0.00');
                    $('#MainContent_txtD3').val('0.00');
                    $(Contenedor + 'txtNroRuc').focus();
                    return false;
}

function F_Nuevo() {

    var Contenedor = '#MainContent_';
    $('#MainContent_ddlCategoria').val(1);
    $(Contenedor + 'txtNroRuc').val('');
    $(Contenedor + 'txtNroDni').val('');
    $(Contenedor + 'txtRazonSocial').val('');
    $(Contenedor + 'txtApellidoPaterno').val('');
    $(Contenedor + 'txtApellidoMaterno').val('');
    $(Contenedor + 'txtNombres').val('');
    $(Contenedor + 'txtRegion').val('');
    $(Contenedor + 'txtProvincia').val('');
    $(Contenedor + 'txtDistrito').val('');
    $(Contenedor + 'txtDireccion').val('');
    $(Contenedor + 'txtDireccionEnvio').val('');
    $(Contenedor + 'txtEmail').val('');
    $(Contenedor + 'ddlTipoCliente').val('2');
    $('#MainContent_ddlCategoria').val(1);
    $('#hfRegion').val('0');
    $('#hfProvincia').val('0');
    $('#hfDistrito').val('0');
    $(Contenedor + 'txtNroRuc').prop('disabled', false);
    $(Contenedor + 'txtNombreComercial').val('');
    $(Contenedor + 'txtNroDni').prop('disabled', true);
    $(Contenedor + 'txtApellidoPaterno').prop('disabled', true);
    $(Contenedor + 'txtApellidoMaterno').prop('disabled', true);
    $(Contenedor + 'txtNombres').prop('disabled', true);
    $(Contenedor + 'chkProveedor').prop('checked', false);
    $(Contenedor + 'chkBloqueCredito').prop('checked', false);
    $('#MainContent_ddlMoneda').val(P_CodMoneda_LineaCredito_Inicial);

    $(Contenedor + 'txtNroRuc').focus();
    return false;
}

function F_Buscar(rptExcel) {

    try {

    if ($('#hfNroRuc').val() === "") {
        toastr.warning("debe elegir un cliente");
        return true;
    }


        if (rptExcel === 0) {
            var objParams = {
                Filtro_Descripcion: $('#hfNroRuc').val()
            };

            var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
            MostrarEspera(true);

            F_Buscar_NET(arg, function (result) {
                var str_resultado_operacion = "";
                var str_mensaje_operacion = "";

                str_resultado_operacion = result.split('~')[0];
                str_mensaje_operacion = result.split('~')[1];
                MostrarEspera(false);
                if (str_resultado_operacion == "1") {

                    F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                    F_Update_Division_HTML('div_consultaDetalle', result.split('~')[3]);
                    F_Update_Division_HTML('div_ContactosGrid', result.split('~')[4]);
                    F_LlenarGridDetalle();
                $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsulta",'lblDocumento'));
                $('#lblNumeroConsultaDetalle').text(F_Numerar_Grilla("grvConsultaDetalle",'lblEstado'));
                $('#lblNumeroConsultaContacto').text(F_Numerar_Grilla("grvContactos",'lblDatosPersonales'));

                    if (str_mensaje_operacion != "")
                        toastr.error(result.split('~')[1]);

                }
                else {
                    toastr.error(result.split('~')[1]);
                }

                return false;

            });
        } else {
            var Cuerpo = '#MainContent_';

            var FlagReporte = 0;

            var rptURL = '';
            var Params = 'width=' + (screen.width * 0.48) + ', height=' + (screen.height * 0.40) + ', top=0, left=0, directories=no, menubar=no, toolbar=no, location=no, resizable=yes, scrollbars=yes, titlebar=yes';
            var TipoArchivo = 'application/pdf';
            var CodMenu = '8';

            rptURL = '../Reportes/ConstruirExcel.aspx';
            rptURL = rptURL + '?';
            rptURL = rptURL + 'CodMenu=' + CodMenu + '&';
            rptURL = rptURL + 'TipoArchivo=' + TipoArchivo + '&';
            rptURL = rptURL + 'Filtro_Descripcion=' + $("#MainContent_txtDescripcionConsulta").val() + '&';

            window.open(rptURL, "PopUpRpt", Params);

        }


    }

    catch (e) {

        toastr.error("Error Detectado: " + e);
        return false;
    }

}

function F_LlenarGridDetalle() {

    try {

        var objParams = {
         Filtro_Codigo: $('#hfCodCtaCte').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_LlenarGridDetalle_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);

                if (str_resultado_operacion === "0")
                {
                    F_Update_Division_HTML('div_consultaDetalle', result.split('~')[2]);
                $('#lblNumeroConsultaDetalle').text(F_Numerar_Grilla("grvConsultaDetalle",'lblDistrito'));
                    $('#div_EdicionCorreo').dialog('close');
                }
                else
                {
                    toastr.error(str_mensaje_operacion);
                }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        toastr.error("Error Detectado: " + e);
        return false;
    }
}

function F_AnularRegistro(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;

        var lblCodigo = '#' + imgID.replace('imgAnularDocumento', 'hfCodigo');
        var lblProducto_grilla = '#' + imgID.replace('imgAnularDocumento', 'lblCliente');


        if (confirm("ESTA SEGURO DE ELIMINAR EL CLIENTE " + $(lblProducto_grilla).text()) == false)
            return false;

        var objParams = {
            Filtro_CodCtaCte: $(lblCodigo).val(),
            Filtro_Descripcion: $('#MainContent_txtDescripcionConsulta').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_AnularRegistro_Net(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsulta",'lblDocumento'));
                $('#lblNumeroConsultaDetalle').text(F_Numerar_Grilla("grvConsultaDetalle",'lblEstado'));
                $('#lblNumeroConsultaContacto').text(F_Numerar_Grilla("grvContactos",'lblCodContacto'));
                toastr.warning(result.split('~')[1]);
            }
            else {
                toastr.warning(result.split('~')[1]);
            }

            return false;
        });

    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
        return false;
    }


}

function F_EditarRegistro(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

    try {
        var imgID = Fila.id;
        var lblcodigo_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCodigo');
        var lblCliente_grilla = '#' + imgID.replace('imgEditarRegistro', 'lblCliente');
        var lblDireccion_grilla = '#' + imgID.replace('imgEditarRegistro', 'lblDireccion');
        var lblDistrito_grilla = '#' + imgID.replace('imgEditarRegistro', 'lblDistrito');
        var hfDepartamento_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfDepartamento');
        var hfProvincia_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfProvincia');
        var hfDireccionEnvio_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfDireccionEnvio');
        var hfApePaterno_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfApePaterno');
        var hfApeMaterno_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfApeMaterno');
        var hfNombres_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfNombres');
        var hfNroRuc_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfNroRuc');
        var hfNroDni_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfNroDni');
        var hfCodTipoCliente_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCodTipoCliente');
        var hfCodDepartamento_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCodDepartamento');
        var hfCodProvincia_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCodProvincia');
        var hfCodDistrito_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCodDistrito');
        var hfRazonSocial_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfRazonSocial');
        var hfEmail_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfEmail');
        var hfLineaCredito_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfLineaCredito');
        var hfDeudaCredito_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfDeudaCredito');
        var hfCodMonedaLineaCredito_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCodMonedaLineaCredito');
        var hfCodCategoria = '#' + imgID.replace('imgEditarRegistro', 'hfCodCategoria');
        var hfNombreComercial = '#' + imgID.replace('imgEditarRegistro', 'hfNombreComercial');
        var hfFlagBloqueoCredito = '#' + imgID.replace('imgEditarRegistro', 'hfFlagBloqueoCredito');
        var hfCodZona = '#' + imgID.replace('imgEditarRegistro', 'hfCodZona');
        var hfCodVendedor = '#' + imgID.replace('imgEditarRegistro', 'hfCodVendedor');
        var hfFlagRetencion = '#' + imgID.replace('imgEditarRegistro', 'hfFlagRetencion');
        var D1 = '#' + imgID.replace('imgEditarRegistro', 'hfD1');
        var D2 = '#' + imgID.replace('imgEditarRegistro', 'hfD2');
        var D3 = '#' + imgID.replace('imgEditarRegistro', 'hfD3');
        var Cuerpo = '#MainContent_';

        $(Cuerpo + 'txtRucEdicion').val($(hfNroRuc_grilla).val());
        $(Cuerpo + 'ddlTipoCliente_Edicion').val($(hfCodTipoCliente_grilla).val());
        $(Cuerpo + 'txtDniEdicion').val($(hfNroDni_grilla).val());
        $(Cuerpo + 'txtRazonSocialEdicion').val($(hfRazonSocial_grilla).val());
        $(Cuerpo + 'txtApellidoPaternoEdicion').val($(hfApePaterno_grilla).val());
        $(Cuerpo + 'txtApellidoMaternoEdicion').val($(hfApeMaterno_grilla).val());
        $(Cuerpo + 'txtNombreEdicion').val($(hfNombres_grilla).val());
        $(Cuerpo + 'txtEmailEdicion').val($(hfEmail_grilla).val());
        $(Cuerpo + 'txtNombreComercialEdicion').val($(hfNombreComercial).val());
        $(Cuerpo + 'txtDistritoEdicion').val($(hfDepartamento_grilla).val() + ' ' + $(hfProvincia_grilla).val() + ' ' + $(lblDistrito_grilla).text());
        $(Cuerpo + 'txtDireccionEdicion').val($(lblDireccion_grilla).text());
        $(Cuerpo + 'txtDireccionEnvioEdicion').val($(lblDireccion_grilla).text());
        $(Cuerpo + 'ddlCategoriaEdicion').val($(hfCodCategoria).val());
        $(Cuerpo + 'ddlZonaEdicion').val($(hfCodZona).val());
        $(Cuerpo + 'txtLineaCreditoEdicion').val($(hfLineaCredito_grilla).val());
        $(Cuerpo + 'ddlMonedaEdicion').val($(hfCodMonedaLineaCredito_grilla).val());
        $(Cuerpo + 'ddlVendedorEdicion').val($(hfCodVendedor).val());
        $(Cuerpo + 'txtD1EnReporte').val($(D1).val());
        $(Cuerpo + 'txtD2EnReporte').val($(D2).val());
        $(Cuerpo + 'txtD3EnReporte').val($(D3).val());
        if ($(hfFlagBloqueoCredito).val()==1) $(Cuerpo + 'chkFlagBloqueoCreditoEdicion').prop('checked', true); else $(Cuerpo + 'chkFlagBloqueoCreditoEdicion').prop('checked', false);
        if ($(hfFlagRetencion).val()==1) $(Cuerpo + 'chkRetencionEdicion').prop('checked', true); else $(Cuerpo + 'chkRetencionEdicion').prop('checked', false);
        $('#hfRegionEdicion').val($(hfCodDepartamento_grilla).val());
        $('#hfProvinciaEdicion').val($(hfCodProvincia_grilla).val());
        $('#hfDistritoEdicion').val($(hfCodDistrito_grilla).val());
        $('#hfCodCtaCte').val($(lblcodigo_grilla).val());
        $(Cuerpo + 'ddlTipoCliente_Edicion').prop('disabled', true);
        $(Cuerpo + 'txtDniEdicion').prop('disabled', true);
        $(Cuerpo + 'txtApellidoPaternoEdicion').prop('disabled', true);
        $(Cuerpo + 'txtApellidoMaternoEdicion').prop('disabled', true);
        $(Cuerpo + 'txtNombreEdicion').prop('disabled', true);
        $(Cuerpo + 'txtRucEdicion').prop('disabled', true);
        //$(Cuerpo + 'txtRazonSocialEdicion').prop('disabled', true); 

        if ($(Cuerpo + 'ddlTipoCliente_Edicion').val() == '3') {
            $(Cuerpo + 'ddlTipoCliente_Edicion').prop('disabled', false);
            //$(Cuerpo + 'txtRazonSocialEdicion').prop('disabled', false);
        }
        else {
        }


        $("#divEdicionRegistro").dialog({
            resizable: false,
            modal: true,
            title: "Edicion de Cliente",
            title_html: true,
            height: 300,
            width: 655,
            autoOpen: false
        });

        $('#divEdicionRegistro').dialog('open');


        return false;

    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
        return false;
    }

}

function F_EdicionRegistro() {

    try {
        var Contenedor = '#MainContent_';
        var TipoDocumento = '1';
        var FlagBloqueoCredito = 0;
        var FlagRetencion = 0;

        if ($('#MainContent_txtNroDni').val() == '')
            TipoDocumento = '6';

        if ($('#MainContent_txtLineaCreditoEdicion').val().trim() === '')
            $('#MainContent_txtLineaCreditoEdicion').val('0')

        if ($('#MainContent_chkFlagBloqueoCreditoEdicion').is(':checked'))
            FlagBloqueoCredito = 1;

              if ($('#MainContent_chkRetencionEdicion').is(':checked'))
            FlagRetencion = 1;

        var objParams = {
            Filtro_CodTipoCliente: $(Contenedor + 'ddlTipoCliente_Edicion').val(),
            Filtro_NroRuc: $(Contenedor + 'txtRucEdicion').val(),
            Filtro_NroDni: $(Contenedor + 'txtDniEdicion').val(),
            Filtro_RazonSocial: $(Contenedor + 'txtRazonSocialEdicion').val(),
            Filtro_ApePaterno: $(Contenedor + 'txtApellidoPaternoEdicion').val(),
            Filtro_ApeMaterno: $(Contenedor + 'txtApellidoMaternoEdicion').val(),
            Filtro_Nombres: $(Contenedor + 'txtNombreEdicion').val(),
            Filtro_CodDepartamento: $('#hfRegionEdicion').val(),
            Filtro_CodProvincia: $('#hfProvinciaEdicion').val(),
            Filtro_CodDistrito: $('#hfDistritoEdicion').val(),
            Filtro_Direccion: $(Contenedor + 'txtDireccionEdicion').val(),
            Filtro_DireccionEnvio: $(Contenedor + 'txtDireccionEdicion').val(),
            Filtro_TipoDocumento: TipoDocumento,
            Filtro_CodCtaCte: $('#hfCodCtaCte').val(),
            Filtro_Descripcion: $('#hfNroRuc').val(),
            Filtro_Email: $(Contenedor + 'txtEmailEdicion').val(),
            Filtro_LineaCredito: $(Contenedor + 'txtLineaCreditoEdicion').val(),
            Filtro_CodMonedaLineaCredito: $(Contenedor + 'ddlMonedaEdicion').val(),
            Filtro_CodCategoria: $(Contenedor + 'ddlCategoriaEdicion').val(),
            Filtro_NombreComercial: $(Contenedor + 'txtNombreComercialEdicion').val(),
            Filtro_CodZona: $(Contenedor + 'ddlZonaEdicion').val(),
            Filtro_CodVendedor: $(Contenedor + 'ddlVendedorEdicion').val(),
            Filtro_FlagBloqueoCredito: FlagBloqueoCredito,
            Filtro_D1: $(Contenedor + 'txtD1EnReporte').val(),
            Filtro_D2: $(Contenedor + 'txtD2EnReporte').val(),
            Filtro_D3: $(Contenedor + 'txtD3EnReporte').val(),
            Filtro_FlagRetencion: FlagRetencion
        };


        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EdicionRegistro_NET(arg, function (result) {
            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'Se grabo correctamente') {
                    $(Contenedor + 'txtRucEdicion').val('');
                    $(Contenedor + 'txtDniEdicion').val('');
                    $(Contenedor + 'txtRazonSocialEdicion').val('');
                    $(Contenedor + 'txtApellidoPaternoEdicion').val('');
                    $(Contenedor + 'txtApellidoMaternoEdicion').val('');
                    $(Contenedor + 'txtNombreEdicion').val('');
                    $(Contenedor + 'txtRegionEdicion').val('');
                    $(Contenedor + 'txtProvinciaEdicion').val('');
                    $(Contenedor + 'txtDistritoEdicion').val('');
                    $(Contenedor + 'txtDireccionEdicion').val('');
                    $(Contenedor + 'txtDireccionEnvioEdicion').val('');
                    $(Contenedor + 'ddlTipoCliente_Edicion').val('2');
                    $('#hfRegionEdicion').val('0');
                    $('#hfProvinciaEdicion').val('0');
                    $('#hfDistritoEdicion').val('0');
                    toastr.success('Se Grabo Correctamente.');
                    F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                    $('#divEdicionRegistro').dialog('close');

                }
                else
                    toastr.warning(result.split('~')[1]);

            }
            else {
                toastr.warning(result.split('~')[1]);
            }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }
}

function F_ValidarEdicionDocumento() {
    try {
        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos: <br> <p></p>';

        if ($(Cuerpo + 'txtRazonSocialEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Razon Social';

        if ($(Cuerpo + 'ddlTipoCliente_Edicion').val() == '2' && $(Cuerpo + 'txtRucEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Nro Ruc';

        if ($(Cuerpo + 'ddlTipoCliente_Edicion').val() == '2' && ValidarRuc($(Cuerpo + 'txtRucEdicion').val()) == false)
            Cadena = Cadena + "<p></p>" + "Ruc Invalido";

        if ($(Cuerpo + 'ddlTipoCliente_Edicion').val() == '1' && $(Cuerpo + 'txtDniEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Nro Dni';

        if ($(Cuerpo + 'txtDniEdicion').val() != '' && $(Cuerpo + 'txtDniEdicion').val().length < 8 & $(Cuerpo + 'ddlTipoCliente_Edicion').val() != '3')
            Cadena = Cadena + '<p></p>' + 'Nro Dni debe tener 8 digitos';

            
            if ($(Cuerpo + 'ddlVendedorEdicion').val() == '0' && $(Cuerpo + 'ddlVendedorEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Vendedor';

//        if ($(Cuerpo + 'txtDistritoEdicion').val() == '' || $('#hfDistritoEdicion').val() == '0')
//            Cadena = Cadena + '<p></p>' + 'Distrito';

//        if ($(Cuerpo + 'txtDireccionEdicion').val() == '')
//            Cadena = Cadena + '<p></p>' + 'Direccion';

//        if ($(Cuerpo + 'txtDireccionEnvioEdicion').val() == '')
//            Cadena = Cadena + '<p></p>' + 'Direccion de Envio';

        if (!F_ValidarCorreo($(Cuerpo + 'txtEmail').val()))
            Cadena = Cadena + '<p></p>' + 'Correo';

        if (isNaN($(Cuerpo + 'txtLineaCreditoEdicion').val()))
            Cadena = Cadena + '<p></p>' + 'Monto Linea de Credito';

        if (Cadena != 'Ingresar los sgtes. Datos: <br> <p></p>') {
            toastr.warning(Cadena);
            return false;
        }
        return true;
    }
    catch (e) {
        toastr.warning("Error Detectado: " + e);
    }
}

function ValidarRuc(valor) {
    valor = trim(valor)
    if (esnumero(valor)) {
        if (valor.length == 8) {
            suma = 0
            for (i = 0; i < valor.length - 1; i++) {

                if (i == 0) suma += (digito * 2)
                else suma += (digito * (valor.length - i))
            }
            resto = suma % 11;
            if (resto == 1) resto = 11;
            if (resto + (valor.charAt(valor.length - 1) - '0') == 11) {
                return true
            }
        } else if (valor.length == 11) {
            suma = 0
            x = 6
            for (i = 0; i < valor.length - 1; i++) {
                if (i == 4) x = 8
                digito = valor.charAt(i) - '0';
                x--
                if (i == 0) suma += (digito * x)
                else suma += (digito * x)
            }
            resto = suma % 11;
            resto = 11 - resto

            if (resto >= 10) resto = resto - 10;
            if (resto == valor.charAt(valor.length - 1) - '0') {
                return true
            }
        }
    }
    return false
}

function esnumero(campo) { return (!(isNaN(campo))); }

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

function F_Direccion(Fila) {    
    if (F_PermisoOpcion(CodigoMenu, 1000101, '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
   var imgID = Fila.id;
   var lblcodigo_grilla = '#' + imgID.replace('imgDireccion', 'hfCodigo');       
   F_DireccionesXCliente($(lblcodigo_grilla).val());
   return true;
}

var XCodCliente = 0;
function F_DireccionesXCliente(CodCliente) {
        XCodCliente = CodCliente;
        try {
        var objParams = {
            Filtro_CodCtaCte: CodCliente
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_Direccion_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {

                $('#div_DireccionMultiple').dialog({
                    resizable: false,
                    modal: true,
                    title: "Direcciones",
                    title_html: true,
                    height: 450,
                    width: 650,
                    autoOpen: false
                });
//                F_Update_Division_HTML('div_Direccion', result.split('~')[2]);
                $('#hfCodCtaCte').val(XCodCliente);
                $('#hfRegionEdicion').val('0');
                $('#hfProvinciaEdicion').val('0');
                $('#hfDistritoEdicion').val('0');
                $('#MainContent_txtDireccionMultiple').val('');
                $('#MainContent_txtDistritoMultiple').val('');
                try { $('#div_DireccionMultiple').dialog('open');}
                catch (e) { }

                return false;

            }

            else
                toastr.warning(result.split('~')[1]);

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }

return true;
}

function F_ValidarGrabarDireccion() {

    try {

        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos: <br> <p></p>';

        if ($(Cuerpo + 'txtDistritoMultiple').val() == '')
            Cadena = Cadena + '<p></p>' + 'Distrito';
        else { 
        if($(hfDistritoEdicion).val()=="0")
            Cadena = Cadena + '<p></p>' + 'Distrito';
        }

        if ($(Cuerpo + 'txtDireccionMultiple').val() == '')
            Cadena = Cadena + '<p></p>' + 'Direccion';

//        if ($(Cuerpo + 'txtEmailMultiple').val() == '')
//            Cadena = Cadena + '<p></p>' + 'Email';

//         if (!F_ValidarCorreo($(Cuerpo + 'txtEmailMultiple').val()))
//         Cadena = Cadena + '<p></p>' + 'Email';
  

        if (Cadena != 'Ingresar los sgtes. Datos: <br> <p></p>') {
            toastr.warning(Cadena);
            return false;
        }
        return true;
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
    }
}

function F_GrabarDireccion() {

    try {
        var Contenedor = '#MainContent_';
      
        var objParams = {
            Filtro_CodCtaCte: $('#hfCodCtaCte').val(),
            Filtro_CodDepartamento: $('#hfRegionEdicion').val(),
            Filtro_CodProvincia: $('#hfProvinciaEdicion').val(),
            Filtro_CodDistrito: $('#hfDistritoEdicion').val(),
            Filtro_Direccion: $(Contenedor + 'txtDireccionMultiple').val(),
            Filtro_Email1: $(Contenedor + 'txtEmailMultiple1').val(),
            Filtro_Email2: $(Contenedor + 'txtEmailMultiple2').val(),
            Filtro_Email3: $(Contenedor + 'txtEmailMultiple3').val(),
            Filtro_Email4: $(Contenedor + 'txtEmailMultiple4').val(),
            Filtro_Email5: $(Contenedor + 'txtEmailMultiple5').val(),
            Filtro_Email6: $(Contenedor + 'txtEmailMultiple6').val(),
        };


        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_GrabarDireccion_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'Se Grabo Correctamente') {
                    F_Update_Division_HTML('div_Direccion', result.split('~')[2]);
                    toastr.success('Se Grabo Correctamente.');
                    $('#hfRegionEdicion').val('0');
                    $('#hfProvinciaEdicion').val('0');
                    $('#hfDistritoEdicion').val('0');
                    $(Contenedor + 'txtDireccionMultiple').val('');
                    $(Contenedor + 'txtDistritoMultiple').val('');
                    $(Contenedor + 'txtEmailMultiple1').val('');
                    $(Contenedor + 'txtEmailMultiple2').val('');
                    $(Contenedor + 'txtEmailMultiple3').val('');
                    $(Contenedor + 'txtEmailMultiple4').val('');
                    $(Contenedor + 'txtEmailMultiple5').val('');
                    $(Contenedor + 'txtEmailMultiple6').val('');
                $('#div_DireccionMultiple').dialog('close');
                    F_LlenarGridDetalle();
                }
                else
                    toastr.warning(result.split('~')[1]);

            }
            else {
                toastr.warning(result.split('~')[1]);
            }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }
}

function F_EditarRegistroDireccion(Fila) {

    try {
        var imgID = Fila.id;
        var hfCodDistrito = '#' + imgID.replace('imgEditarRegistro', 'hfCodDistrito');
        var hfCodDepartamento = '#' + imgID.replace('imgEditarRegistro', 'hfCodDepartamento');
        var hfCodProvincia = '#' + imgID.replace('imgEditarRegistro', 'hfCodProvincia');
        var lblCodDireccion = '#' + imgID.replace('imgEditarRegistro', 'lblCodDireccion');
        var lblDireccion = '#' + imgID.replace('imgEditarRegistro', 'lblDireccion');
        var lblDistrito = '#' + imgID.replace('imgEditarRegistro', 'lblDistrito');
        var lblEmail1 = '#' + imgID.replace('imgEditarRegistro', 'hfEmail');
        var lblEmail2 = '#' + imgID.replace('imgEditarRegistro', 'hfEmail2');
        var lblEmail3 = '#' + imgID.replace('imgEditarRegistro', 'hfEmail3');
        var lblEmail4 = '#' + imgID.replace('imgEditarRegistro', 'hfEmail4');
        var lblEmail5 = '#' + imgID.replace('imgEditarRegistro', 'hfEmail5');
        var lblEmail6 = '#' + imgID.replace('imgEditarRegistro', 'hfEmail6');
        var hfGPSLong = '#' + imgID.replace('imgEditarRegistro', 'hfGPSLong');
        var hfGPSLat = '#' + imgID.replace('imgEditarRegistro', 'hfGPSLat');
        var hfCodigo = '#' + imgID.replace('imgEditarRegistro', 'hfCodigo');

    
        var Cuerpo = '#MainContent_';

        $(Cuerpo + 'txtDistritoDireccionEdicion').val($(lblDistrito).text());
        $(Cuerpo + 'txtDireccionEdicionMultiple').val($(lblDireccion).text());
        $(Cuerpo + 'txtEmailEdicionMultiple1').val($(lblEmail1).val());
        $(Cuerpo + 'txtEmailEdicionMultiple2').val($(lblEmail2).val());
        $(Cuerpo + 'txtEmailEdicionMultiple3').val($(lblEmail3).val());
        $(Cuerpo + 'txtEmailEdicionMultiple4').val($(lblEmail4).val());
        $(Cuerpo + 'txtEmailEdicionMultiple5').val($(lblEmail5).val());
        $(Cuerpo + 'txtEmailEdicionMultiple6').val($(lblEmail6).val());
        $(Cuerpo + 'txtGPSLongEdicion').val($(hfGPSLong).val());
        $(Cuerpo + 'txtGPSLatEdicion').val($(hfGPSLat).val());
       $(Cuerpo + 'txtGPSLongLatEdicion').val( $(hfGPSLong).val()+","+$(hfGPSLat).val());

        $('#hfCodDireccion').val($(hfCodigo).val());
        $('#hfDistrito').val($(hfCodDistrito).val());
        $('#hfProvincia').val($(hfCodProvincia).val());
        $('#hfRegion').val($(hfCodDepartamento).val());

        $("#div_EdicionDireccion").dialog({
            resizable: false,
            modal: true,
            title: "Edicion de Direccion",
            title_html: true,
            height: 250,
            width: 600,
            autoOpen: false
        });

     

        $('#div_EdicionDireccion').dialog('open');


        return false;

    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
        return false;
    }

}

function F_EditarRegistroCorreo(Fila) {

    try {
        var imgID = Fila.id;
        var hfCodDistrito = '#' + imgID.replace('imgEditarRegistroCorreo', 'hfCodDistrito');
        var lblDireccion = '#' + imgID.replace('imgEditarRegistroCorreo', 'lblDireccion');
        var lblEmail1 = '#' + imgID.replace('imgEditarRegistroCorreo', 'hfEmail');
        var lblEmail2 = '#' + imgID.replace('imgEditarRegistroCorreo', 'hfEmail2');
        var lblEmail3 = '#' + imgID.replace('imgEditarRegistroCorreo', 'hfEmail3');
        var lblEmail4 = '#' + imgID.replace('imgEditarRegistroCorreo', 'hfEmail4');
        var lblEmail5 = '#' + imgID.replace('imgEditarRegistroCorreo', 'hfEmail5');
        var lblEmail6 = '#' + imgID.replace('imgEditarRegistroCorreo', 'hfEmail6');
        var hfCodigo = '#' + imgID.replace('imgEditarRegistroCorreo', 'hfCodigo');

    
        var Cuerpo = '#MainContent_';

        $(Cuerpo + 'txtEmailEdicionMultiple1').val($(lblEmail1).val());
        $(Cuerpo + 'txtEmailEdicionMultiple2').val($(lblEmail2).val());
        $(Cuerpo + 'txtEmailEdicionMultiple3').val($(lblEmail3).val());
        $(Cuerpo + 'txtEmailEdicionMultiple4').val($(lblEmail4).val());
        $(Cuerpo + 'txtEmailEdicionMultiple5').val($(lblEmail5).val());
        $(Cuerpo + 'txtEmailEdicionMultiple6').val($(lblEmail6).val());

        $('#hfCodDireccion').val($(hfCodigo).val());

        $("#div_EdicionCorreo").dialog({
            resizable: false,
            modal: true,
            title: "Edicion de Correo",
            title_html: true,
            height: 255,
            width: 600,
            autoOpen: false
        });

     

        $('#div_EdicionCorreo').dialog('open');


        return false;

    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
        return false;
    }

}

var hfCodEstado  = '';
var lblEstado = '';
function F_ActivarRegistroDireccion(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;
        var lblCodDireccion = '#' + imgID.replace('imgActivarRegistro', 'hfCodigo');
        hfCodEstado = '#' + imgID.replace('imgActivarRegistro', 'hfCodEstado');
        lblEstado = '#' + imgID.replace('imgActivarRegistro', 'lblEstado');


        var Cuerpo = '#MainContent_';
        var Estado = '2'; if ($(hfCodEstado).val() == '2')
                                Estado = '1';
        var EstadoDsc = 'INACTIVO'; if ($(hfCodEstado).val() == '2')
                                EstadoDsc = 'ACTIVO';

        var objParams = {
                Filtro_CodDireccion: $(lblCodDireccion).val(),
                Filtro_NuevoEstado: Estado
            };


        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ActivarRegistroDireccion_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == '') {
                
                    F_LlenarGridDetalle();

//                    $(lblEstado).text(EstadoDsc);
//                    $(hfCodEstado).val(Estado);
                }
                else
                    toastr.warning(result.split('~')[1]);

            }
            else {
                toastr.warning(result.split('~')[1]);
            }

            return false;

        });
    

        return false;
    }
    catch (e) {
        toastr.warning("Error Detectado: " + e);
        return false; }
}
var hfCodEstadoContacto  = '';
var lblEstadoContacto = '';
function F_ActivarRegistroContacto(Fila) {
    //if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;
        var lblCodContacto = '#' + imgID.replace('imgActivarRegistroContacto', 'lblCodContacto');
        hfCodEstadoContacto = '#' + imgID.replace('imgActivarRegistroContacto', 'hfCodEstado');
        lblEstadoContacto = '#' + imgID.replace('imgActivarRegistroContacto', 'hfEstado');


        var Cuerpo = '#MainContent_';
        var Estado = '2'; if ($(hfCodEstadoContacto).val() == '2')
                                Estado = '1';
        var EstadoDsc = 'INACTIVO'; if ($(hfCodEstadoContacto).val() == '2')
                                EstadoDsc = 'ACTIVO';

        var objParams = {
                Filtro_CodContacto: $(lblCodContacto).val(),
            Filtro_CodCtaCte: $('#hfCodCtaCte').val(), 
                Filtro_NuevoEstado: Estado
            };


        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ActivarRegistroContacto_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == '') {
                
               F_Update_Division_HTML('div_ContactosGrid', result.split('~')[2]);
                $('#lblNumeroConsultaContacto').text(F_Numerar_Grilla("grvContactos",'lblDatosPersonales'));

//                    $(lblEstado).text(EstadoDsc);
//                    $(hfCodEstado).val(Estado);
                }
                else
                    toastr.warning(result.split('~')[1]);

            }
            else {
                toastr.warning(result.split('~')[1]);
            }

            return false;

        });
    

        return false;
    }
    catch (e) {
        toastr.warning("Error Detectado: " + e);
        return false; }
}

function F_ElegirPrincipalDireccion(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion 
    try {
        var imgID = Fila.id;
        var lblCodDireccion = '#' + imgID.replace('imgPrincipal', 'hfCodigo');
        hfCodEstado = '#' + imgID.replace('imgPrincipal', 'hfCodEstado');
        
        var Cuerpo = '#MainContent_';
        if ($(hfCodEstado).val() == '2')
        {
            toastr.warning('LAS DIRECCIONES PRINCPALES DEBEN ESTAR ACTIVAS');
            return false;
        }

        var objParams = {
                Filtro_CodDireccion: $(lblCodDireccion).val()
            };


        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ElegirPrincipalDireccion_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == '') {
                    F_LlenarGridDetalle();
                }
                else
                    toastr.warning(result.split('~')[1]);

            }
            else {
                toastr.warning(result.split('~')[1]);
            }

            return false;

        });
    

        return false;
    }
    catch (e) {
        toastr.warning("Error Detectado: " + e);
        return false; }
}

$('#MainContent_grvDetalleArticulo :checkbox').each(function () {
                        chkSi = this.id;
                        F_ActualizarPrecio(chkSi.replace('chkEliminar','txtPrecio'), Dcto);
                    });

function F_ValidarGrabarDireccionMultiple() {

    try {

        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos: <br> <p></p>';

        if ($(Cuerpo + 'txtDistritoDireccionEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Distrito';
        else {
            if ($('#hfDistrito').val() == "0")
                Cadena = Cadena + '<p></p>' + 'Distrito';
        }

        if ($(Cuerpo + 'txtDireccionEdicionMultiple').val() == '')
            Cadena = Cadena + '<p></p>' + 'Direccion';

//        if ($(Cuerpo + 'txtEmailEdicionMultiple').val() == '')
//            Cadena = Cadena + '<p></p>' + 'Email';


//         if (!F_ValidarCorreo($(Cuerpo + 'txtEmailEdicionMultiple').val()))
//         Cadena = Cadena + '<p></p>' + 'Email';

 if (($('#MainContent_txtGPSLongEdicion').val() != "" & $('#MainContent_txtGPSLatEdicion').val() == "") |
                ($('#MainContent_txtGPSLongEdicion').val() == "" & $('#MainContent_txtGPSLatEdicion').val() != ""))
            Cadena = Cadena + '<p></p>' + "GPS Long y GPS Lat";

        if (Cadena != 'Ingresar los sgtes. Datos: <br> <p></p>') {
            toastr.warning(Cadena);
            return false;
        }
        return true;
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
    }
}

function F_GrabarDireccionMultiple() {

    try {
        var Contenedor = '#MainContent_';
        var GPSLong=0;
        var GPSLat=0;

            
            GPSLong=$('#MainContent_txtGPSLongLatEdicion').val().split(',')[0];
            GPSLat=$('#MainContent_txtGPSLongLatEdicion').val().split(',')[1];



        var objParams = {
            Filtro_CodCtaCte: $('#hfCodCtaCte').val(),
            Filtro_CodDireccion: $('#hfCodDireccion').val(),
            Filtro_CodDepartamento: $('#hfRegion').val(),
            Filtro_CodProvincia: $('#hfProvincia').val(),
            Filtro_CodDistrito: $('#hfDistrito').val(),
            Filtro_Direccion: $(Contenedor + 'txtDireccionEdicionMultiple').val(),
            Filtro_Email1: $(Contenedor + 'txtEmailEdicionMultiple1').val(),
            Filtro_Email2: $(Contenedor + 'txtEmailEdicionMultiple2').val(),
            Filtro_Email3: $(Contenedor + 'txtEmailEdicionMultiple3').val(),
            Filtro_Email4: $(Contenedor + 'txtEmailEdicionMultiple4').val(),
            Filtro_Email5: $(Contenedor + 'txtEmailEdicionMultiple5').val(),
            Filtro_Email6: $(Contenedor + 'txtEmailEdicionMultiple6').val(),
            Filtro_GPSLong: (GPSLong == "")? 0 : GPSLong,
            Filtro_GPSLat: (GPSLat == "")? 0 : GPSLat,
        };


        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_GrabarDireccionMultiple_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'Se Grabo Correctamente') {
                    F_LlenarGridDetalle();
                    toastr.success('Se Grabo Correctamente.');
                    $('#hfRegion').val('0');
                    $('#hfProvincia').val('0');
                    $('#hfDistrito').val('0');
                    $(Contenedor + 'txtGPSLogEdicion').val('');
                    $(Contenedor + 'txtGPSLatEdicion').val('');
                    $('#div_EdicionDireccion').dialog('close');
                    $('#div_EdicionCorreo').dialog('close');
                }
                else
                    toastr.warning(result.split('~')[1]);

            }
            else {
                toastr.warning(result.split('~')[1]);
            }

            return false;

        });
    
    }

    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }
}

function F_EliminarDireccion(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;

        var lblCodDireccion = '#' + imgID.replace('imgAnularDocumento', 'hfCodigo');
        var lblDistrito = '#' + imgID.replace('imgAnularDocumento', 'lblDistrito');
        var lblDireccion = '#' + imgID.replace('imgAnularDocumento', 'lblDireccion');

        if (!confirm("ESTA SEGURO DE ELIMINAR LA DIRECCION " + $(lblDistrito).text() + " " + $(lblDireccion).text()))
            return false;

        var objParams = {
            Filtro_CodCtaCte: $('#hfCodCtaCte').val(),                              
            Filtro_CodDireccion: $(lblCodDireccion).val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EliminarDireccion_Net(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                F_Update_Division_HTML('div_Direccion', result.split('~')[2]);
                    F_LlenarGridDetalle();
                toastr.warning(result.split('~')[1]);
            }
            else {
                toastr.warning(result.split('~')[1]);
            }

            return false;
        });

    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
        return false;
    }


}

function F_InicializarCajaTexto()
{
    $("#MainContent_txtNroRuc").ForceNumericOnly();
    $("#MainContent_txtNroDni").ForceNumericOnly();
    $("#MainContent_txtRucEdicion").ForceNumericOnly();
    $("#MainContent_txtDniEdicion").ForceNumericOnly();

    $('#MainContent_txtNroRuc').css('background', '#FFFFE0');

    $('#MainContent_txtNroDni').css('background', '#FFFFE0');

    $('#MainContent_txtRazonSocial').css('background', '#FFFFE0');

    $('#MainContent_txtApellidoPaterno').css('background', '#FFFFE0');

    $('#MainContent_txtApellidoMaterno').css('background', '#FFFFE0');

    $('#MainContent_txtNombres').css('background', '#FFFFE0');

    $('#MainContent_txtDistrito').css('background', '#FFFFE0');

    $('#MainContent_txtDireccion').css('background', '#FFFFE0');

    $('#MainContent_txtDireccionEnvio').css('background', '#FFFFE0');

    $('#MainContent_txtEmail').css('background', '#FFFFE0');

    $('#MainContent_txtEmail').css('background', '#FFFFE0');

    $('#MainContent_txtEmailEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcionConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtDniEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtRazonSocialEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtApellidoPaternoEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtApellidoMaternoEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtNombreEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtDistritoEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtDireccionEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtDireccionEnvioEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtRucEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtDistritoMultiple').css('background', '#FFFFE0');

    $('#MainContent_txtDireccionMultiple').css('background', '#FFFFE0');

    $('#MainContent_txtDistritoDireccionEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtDireccionEdicionMultiple').css('background', '#FFFFE0');

    $('#MainContent_txtEmailMultiple').css('background', '#FFFFE0');

    $('#MainContent_txtEmailEdicionMultiple').css('background', '#FFFFE0');

    $('#MainContent_txtLineaCredito').css('background', '#FFFFE0');

    $('#MainContent_txtLineaCreditoEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtEmailMultiple1').css('background', '#FFFFE0');
    $('#MainContent_txtEmailMultiple2').css('background', '#FFFFE0');
    $('#MainContent_txtEmailMultiple3').css('background', '#FFFFE0');
    $('#MainContent_txtEmailMultiple4').css('background', '#FFFFE0');
    $('#MainContent_txtEmailMultiple5').css('background', '#FFFFE0');
    $('#MainContent_txtEmailMultiple6').css('background', '#FFFFE0');

    $('#MainContent_txtEmailEdicionMultiple1').css('background', '#FFFFE0');
    $('#MainContent_txtEmailEdicionMultiple2').css('background', '#FFFFE0');
    $('#MainContent_txtEmailEdicionMultiple3').css('background', '#FFFFE0');
    $('#MainContent_txtEmailEdicionMultiple4').css('background', '#FFFFE0');
    $('#MainContent_txtEmailEdicionMultiple5').css('background', '#FFFFE0');
    $('#MainContent_txtEmailEdicionMultiple6').css('background', '#FFFFE0');
    $('#MainContent_txtNombreComercial').css('background', '#FFFFE0');
    $('#MainContent_txtNombreComercialEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtClienteContacto').css('background', '#FFFFE0');

    $('#MainContent_txtContacto').css('background', '#FFFFE0');

    $('#MainContent_txtContactoArea').css('background', '#FFFFE0');

    $('#MainContent_txtCorreoContacto1').css('background', '#FFFFE0');

    $('#MainContent_txtCorreoContacto2').css('background', '#FFFFE0');

    $('#MainContent_txtCorreoContacto3').css('background', '#FFFFE0');

    $('#MainContent_txtCelularContacto1').css('background', '#FFFFE0');

    $('#MainContent_txtCelularContacto2').css('background', '#FFFFE0');

    $('#MainContent_txtCelularContacto3').css('background', '#FFFFE0');

    $('#MainContent_ddlEstadoContacto').css('background', '#FFFFE0');

    $('#MainContent_ddlEstadoContactoEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtTelefonoContacto').css('background', '#FFFFE0');
    
    $('#MainContent_txtContactoEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtContactoAreaEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtTelefonoContactoEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtCorreoContactoEdicion1').css('background', '#FFFFE0');

    $('#MainContent_txtCorreoContactoEdicion2').css('background', '#FFFFE0');

    $('#MainContent_txtCorreoContactoEdicion3').css('background', '#FFFFE0');

    $('#MainContent_txtCelularContactoEdicion1').css('background', '#FFFFE0');
    
    $('#MainContent_txtCelularContactoEdicion2').css('background', '#FFFFE0');

    $('#MainContent_txtCelularContactoEdicion3').css('background', '#FFFFE0');

    $('#MainContent_txtContactoTelefono').css('background', '#FFFFE0');


    $('#MainContent_txtNombreContactoRegistro').css('background', '#FFFFE0');

    $('#MainContent_txtAreaContactoRegistro').css('background', '#FFFFE0');

    $('#MainContent_txtTelefonoContactoRegistro').css('background', '#FFFFE0');

    $('#MainContent_txtCorreo1ContactoRegistro').css('background', '#FFFFE0');

    $('#MainContent_txtCorreo2ContactoRegistro').css('background', '#FFFFE0');

    $('#MainContent_txtCorreo3ContactoRegistro').css('background', '#FFFFE0');

    $('#MainContent_txtCelular1ContactoRegistro').css('background', '#FFFFE0');

    $('#MainContent_txtCelular2ContactoRegistro').css('background', '#FFFFE0');

    $('#MainContent_txtCelular3ContactoRegistro').css('background', '#FFFFE0');

    $('#MainContent_ddlContactoEstadoRegistro').css('background', '#FFFFE0');

    $("#MainContent_txtCelularContacto1").ForceNumericOnly();
    $("#MainContent_txtCelularContacto2").ForceNumericOnly();
    $("#MainContent_txtCelularContacto3").ForceNumericOnly();
    $("#MainContent_txtCelularContactoEdicion1").ForceNumericOnly();
    $("#MainContent_txtCelularContactoEdicion2").ForceNumericOnly();
    $("#MainContent_txtCelularContactoEdicion3").ForceNumericOnly();

    return false;
}

function F_ValidaRucDni() {
if (!F_SesionRedireccionar(AppSession)) return false;
    if ($('#MainContent_txtNroRuc').val().length > 0)
    {
        if (ValidarRuc($('#MainContent_txtNroRuc').val()) == false)
        { 
            toastr.warning('NRO. RUC INVALIDO'); 
            $('#MainContent_txtNroRuc').val('');
            $('#MainContent_txtNroRuc').focus();
            return false;
        }
        else
        {
            //DNI
            if ($('#MainContent_txtNroRuc').val().length == 8)
            {
                toastr.warning('NRO. RUC INVALIDO'); 
                $('#MainContent_txtNroRuc').val('');
                $('#MainContent_txtNroRuc').focus();
                return false;
            }
            else
            {
                if ($('#MainContent_txtNroRuc').val().length == 11)
                {
                    $('#MainContent_txtCliente').prop('disabled', false);
                    $('#MainContent_txtApePaterno').prop('disabled', true);
                    $('#MainContent_txtApePaterno').val('');
                    $('#MainContent_txtApeMaterno').prop('disabled', true);
                    $('#MainContent_txtApeMaterno').val('');
                    $('#MainContent_txtNombres').prop('disabled', true);
                    $('#MainContent_txtNombres').val('');
                    $('#MainContent_txtCliente').focus();
                    F_BuscarPadronSunat();
                }
                else
                {
                    toastr.warning('NRO. RUC INVALIDO'); 
                    $('#MainContent_txtNroRuc').val('');
                    //F_LimpiarCampos();
                }
            }

        }
    }
    else
    {
        if ($('#MainContent_txtNroRuc').val() != $('#hfNroRuc').val())
        {
            //F_LimpiarCampos();
        }
    }
   return false;
}
//aca busca si es un nuevo numero de dni o ruc
var API = ""
var ubigeo="";
function F_BuscarPadronSunat() {
            $('#hfRegion').val("");
                        $('#hfProvincia').val("");
                        $('#hfDistrito').val("");
            F_LimpiarCampos();
          if (API == "") {  
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_TCCuentaCorriente_PadronSunat',
                data: "{'NroRuc':'" + $('#MainContent_txtNroRuc').val() +"','CodTipoCtaCte':'1'}",
                dataType: "json",
                async: true,
                success: function (dbObject) {
                MostrarEspera(true);
                var data = dbObject.d;
                try {
                 // condiciona joel:si en la base de datos no se encuentra ninguna condicion de ruc se manda para la apisunat
                    if (data.length > 0) {
                    if (data[0].split(',')[0] != '0')
                    {
                        try {
                            $.each(data, function (index, item) {
                                if (item.split(',')[13] === '1'){
                                    toastr.warning('EL CLIENTE YA EXISTE');
                                    $('#MainContent_txtNroRuc').val('');
                                    $('#MainContent_txtRazonSocial').val('');
                                    $('#MainContent_txtDistrito').val('');
                                    $('#MainContent_txtDireccion').val('');
                                    $('#MainContent_txtDireccionEnvio').val('');
                                    $('#MainContent_txtNroRuc').focus();
                                } else if (item.split(',')[13] === '2' | item.split(',')[13] === '0') {
                                    $('#MainContent_txtRazonSocial').val(data[0].split(',')[1]); //razon social
                                    $('#MainContent_txtDireccion').val(data[0].split(',')[2]);
                                    $('#MainContent_txtDireccionEnvio').val(data[0].split(',')[2]);
                                    $('#MainContent_txtDistrito').val(data[0].split(',')[4]);
                                    $('#hfRegion').val(data[0].split(',')[5]);
                                    $('#hfProvincia').val(data[0].split(',')[6]);
                                    $('#hfDistrito').val(data[0].split(',')[7]);
                                    
                                    if (item.split(',')[13] === '2') {
                                        $('#MainContent_chkProveedor').prop('checked', false);
                                        $('#MainContent_chkProveedor').prop('disabled', true);
                                        toastr.warning('COMO PROVEEDOR EXISTE Y NO SE PUEDE CREAR NUEVAMENTE');
                                    }
                                } 
                            });
                        }
                        catch (x) { toastr.warning('El Producto no tiene Imagenes'); }
                    }
                    else
                    {
                        $('#MainContent_txtRazonSocial').val(data[0].split(',')[1]); //razon social
                        $('#MainContent_txtDireccion').val(data[0].split(',')[2]);
                        $('#MainContent_txtDireccionEnvio').val(data[0].split(',')[2]);
                        $('#MainContent_txtDistrito').val(data[0].split(',')[4]);
                        $('#hfRegion').val(data[0].split(',')[5]);
                        $('#hfProvincia').val(data[0].split(',')[6]);
                        $('#hfDistrito').val(data[0].split(',')[7]);
                        
                    }
                    }else{
                     API = "Usuario No Encontrado";
                        console.log(API);
                        F_API_RUC_Buscar();
                        F_BuscarPadronSunat();
                       
                    }

                }
                catch (x) { 
                  toastr.warning(x); 
                 }
                MostrarEspera(false);
            },
                error: function (response) {
                    toastr.warning(response.responseText);
                },
                failure: function (response) {
                    toastr.warning(response.responseText);
                }
            });

           }; 
             
  if (API == "Usuario No Encontrado") {
        //api sunat 
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url:  $('#hfurlapisunat').val() + $('#MainContent_txtNroRuc').val() + $('#hftokenapisunat').val(),
            dataType: "json",
            async: true,
            success: function (dbObject) {
                MostrarEspera(true);
                var data = dbObject.d;                                
                try {
                API = "";
                    $('#MainContent_txtRazonSocial').val(dbObject.razonSocial); //razon social
                    $('#MainContent_txtNombreComercial').val(dbObject.razonSocial); //razon social
                    ubigeo=dbObject.ubigeo;
                    if (ubigeo==null){
                     toastr.warning("La sunat no ofrece direccion ni distrito para los ruc 10,debe colocarlo usted mismo.");
                     }
                    var direccion = dbObject.direccion;
                    var distrito = dbObject.departamento + ' ' + dbObject.provincia + ' ' + dbObject.distrito;
                    $('#MainContent_txtDireccion').val(direccion.replace(distrito, ""));
                    $('#MainContent_txtDireccionEnvio').val(direccion.replace(distrito, ""));
                    $('#MainContent_txtDistrito').val(distrito);
                    $('#hfDistrito').val(distrito);
//                    $('#hfUbigeo').val(dbObject.ubigeo);
                    
                    F_BuscarDireccionNuevo();
                }
                catch (x) { }
                MostrarEspera(false);
            },
            error: function (response) {
                if(response.responseText!=''){
                alertify.log(response.responseText);
                }else{
                alertify.log('Verificar conexión');
                $('#td_loading').css('display', 'none');
                }

            },
            failure: function (response) {
                toastr.warning(response.responseText);
            }
        });
    }


    return true;
}

function F_BuscarDireccionPorDefecto() {
if (!F_SesionRedireccionar(AppSession)) return false;
//    $('#hfCodDireccion').val('0');
//    $('#MainContent_txtDireccion').val('');
//    $('#hfDireccion').val('');
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_TCDireccion_ListarXCodDistrito_AutoComplete',
        data: "{'Direccion':'','CodDepartamento':'" + $('#hfCodDepartamento').val() + "','CodProvincia':'" + $('#hfCodProvincia').val() + "','CodDistrito':'" + $('#hfCodDistrito').val() + "','CodCtaCte':'" + $('#hfCodCtaCte').val() + "'}",
        dataType: "json",
        async: false,
        success: function (data) {
                if (data.d.length >= 1)
                {
                    $('#hfCodDireccion').val(data.d[0].split(',')[0]);
                    $('#MainContent_txtDireccion').val(data.d[0].split(',')[1]);
                    $('#hfDireccion').val(data.d[0].split(',')[1]);
                    $('#MainContent_txtCorreo').val(data.d[0].split(',')[5]);
                    if ($('#hfCodCtaCte').val() == 29)
                    {
                        $('#hfCodDistrito').val(data.d[0].split(',')[2]);
                        $('#hfCodProvincia').val(data.d[0].split(',')[3]);
                        $('#hfCodDepartamento').val(data.d[0].split(',')[4]);
                    }
                    return true;
                }
        },
        complete: function () {
            if (($('#hfCodDireccion').val() == '' | $('#hfCodDireccion').val() == '0') && $('#hfCodCtaCte').val() != 0)
            {
                toastr.warning('NO HAY DIRECCION PARA EL DISTRITO ESPECIFICADO')
                $('#MainContent_txtDireccion').val('');
                $('#hfDireccion').val('');
                $('#hfCodDireccion').val('0');
                $('#MainContent_txtCorreo').val('');
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

function imgMas_Click(Control) {
    var Src = $(Control).attr('src');

    if (Src.indexOf('plus') >= 0) {
        $(Control).closest('tr').after('<tr><td></td><td colspan = "999">' + $(Control).next().html() + '</td></tr>');
        $(Control).attr('src', '../Asset/images/minus.gif');
    }
    else {
        $(Control).attr("src", "../Asset/images/plus.gif");
        $(Control).closest("tr").next().remove();
    }

    return false;
}

function F_ValidaCuentaCorriente() {
    
    var Index= $('#MainContent_txtRazonSocial').val().indexOf('-');
    var Cliente = $('#MainContent_txtRazonSocial').val();
    if ( Index ==-1 ) {} else {
        if (isNaN(Cliente.split('-')[0].trim()) | !ValidarRuc(Cliente.split('-')[0].trim()))
        {
            return false;
        }
        $('#MainContent_txtRazonSocial').val(Cliente.split('-')[1].trim())
    }

    return true;
}

var Ruc = '';
function F_BuscarDatosPorRucDni(RucDni) {
        Ruc = RucDni;
        if (RucDni == '55555555555')
            RucDni = '11111111111'

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_BuscarDatosPorRucDni',
                data: "{'NroRuc':'" + RucDni +"'}",
                dataType: "json",
                async: false,
                success: function (dbObject) {
                var data = dbObject.d;
                if (data.length > 0)
                {
                    try {
                            //$('#hfCodCtaCte').val(data[0].split(',')[0]); 
                            $('#MainContent_txtRazonSocial').val(data[0].split(',')[1]);
                            //$('#hfCliente').val($('#MainContent_txtCliente').val()); //razon social
                            $('#MainContent_txtNroRuc').val(data[0].split(',')[8]);
                            //$('#hfNroRuc').val(data[0].split(',')[8]);
                            $('#MainContent_txtDireccion').val(data[0].split(',')[2]);
                            $('#MainContent_txtDestino').val(data[0].split(',')[2]);
                            $('#MainContent_txtDistrito').val(data[0].split(',')[4]);
                            //$('#hfCodDireccion').val('0');
                            $('#hfRegion').val(data[0].split(',')[5]);
                            $('#hfProvincia').val(data[0].split(',')[6]);
                            $('#hfDistrito').val(data[0].split(',')[7]);
                            //$('#hfDistrito').val(data[0].split(',')[4]);
//                            $('#txtSaldoCreditoFavor').text(data[0].split(',')[12]);
//                            $('#hfSaldoCreditoFavor').val(data[0].split(',')[12].replace("S/", "").replace(" ", ""));

                            if (Ruc == '55555555555') {
                                $('#MainContent_txtNroRuc').val(Ruc);
                                Ruc = '';
                                $('#MainContent_txtRazonSocial').val('');
                                }

                                Ruc = '';
                            //F_BuscarDireccionPorDefecto(); 
                            return true;
                    }
                    catch (x) { toastr.warning(x); }
                }
                else
                {
                    F_BuscarPadronSunat();
//                    var NroRuc = $('#MainContent_txtNroRuc').val();
//                    F_LimpiarCampos();
//                    $('#MainContent_txtNroRuc').val(NroRuc);
//                    if ($('#MainContent_txtNroRuc').val().length == 8)
//                    {
//                            $("#hfCodCtaCte").val('0');
//                            if ($('#MainContent_txtNroRuc').val() != '11111111')
//                                $('#MainContent_txtCliente').val('---NUEVO CLIENTE---');
//                            $('#MainContent_txtCliente').select();
//                    }
//                    return false;
                }



            },


                error: function (response) {
                    toastr.warning(response.responseText);
                },
                failure: function (response) {
                    toastr.warning(response.responseText);
                }
            });



return true;
}

//---------------------------------
//CONTACTOS------------------------
//---------------------------------
function F_Contactos(Fila) {
        if (F_PermisoOpcion(CodigoMenu, 1000102, '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        var imgID = Fila.id;
        var lblcodigo_grilla = '#' + imgID.replace('imgContactos', 'hfCodigo');
        var lblcliente_grilla = '#' + imgID.replace('imgContactos', 'lblCliente');
        var Cuerpo = '#MainContent_';

        $(Cuerpo + 'ddlEstadoContacto').val('1');

        $('#hfCodCtaCte').val($(lblcodigo_grilla).val());
        
        try {
        var objParams = {
            Filtro_CodCtaCte: $(lblcodigo_grilla).val()
        };

        if ($(lblcodigo_grilla).val() === '')
            return false;

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);

        F_Contactos_NET(arg, function (result) {
            MostrarEspera(false);

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];

            if (str_resultado_operacion == "1") {

                $('#div_Contactos').dialog({
                    resizable: false,
                    modal: true,
                    title: "Contactos",
                    title_html: true,
                    height: 300,
                    width: 700,
                    autoOpen: false
                });

//                F_Update_Division_HTML('div_ContactosGrid', result.split('~')[2]);
                $(Cuerpo + 'txtContacto').val('');
				$(Cuerpo + 'txtCorreoContacto').val('');
                $(Cuerpo + 'txtClienteContacto').val($(lblcliente_grilla).text());

                $(Cuerpo + 'txtContactoArea').val('');
                $(Cuerpo + 'txtContactoTelefono').val('');
                $(Cuerpo + 'txtCorreoContacto1').val('');
                $(Cuerpo + 'txtCorreoContacto2').val('');
                $(Cuerpo + 'txtCorreoContacto3').val('');
                $(Cuerpo + 'txtCelularContacto1').val('');
                $(Cuerpo + 'txtCelularContacto2').val('');
                $(Cuerpo + 'txtCelularContacto3').val('');
                $(Cuerpo + 'chkFlag_MostrarEnReporte').prop('checked', false);
                

                $('#div_Contactos').dialog('open');



                return false;

            }

            else
                toastr.warning(result.split('~')[1]);

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }

}

function F_ValidarGrabarContacto() {

    try {

        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos: <br> <p></p>';

        if ($(Cuerpo + 'txtContacto').val() == '')
            Cadena = Cadena + '<p></p>' + 'Contacto';
		
        if ($(Cuerpo + 'txtCorreoContacto').val() == '')
            Cadena = Cadena + '<p></p>' + 'Correo';

        if (!F_ValidarCorreo($(Cuerpo + 'txtCorreoContacto1').val()))
            Cadena = Cadena + '<p></p>' + 'Correo 1';

//        if (!F_ValidarCorreo($(Cuerpo + 'txtCorreoContacto2').val()))
//            Cadena = Cadena + '<p></p>' + 'Correo 2';

//        if (!F_ValidarCorreo($(Cuerpo + 'txtCorreoContacto3').val()))
//            Cadena = Cadena + '<p></p>' + 'Correo 3';

        if ($(Cuerpo + 'txtCelularContacto1').val().trim().length > 0)
        if ($(Cuerpo + 'txtCelularContacto1').val().trim().length != 9 | $(Cuerpo + 'txtCelularContacto1').val().trim().substring(0,1) != '9')
            Cadena = Cadena + '<p></p>' + 'Celular 1 debe ser 9 digitos e iniciar con 9';

//        if ($(Cuerpo + 'txtCelularContacto2').val().trim().length > 0)
//        if ($(Cuerpo + 'txtCelularContacto2').val().trim().length != 9 | $(Cuerpo + 'txtCelularContacto2').val().trim().substring(0,1) != '9')
//            Cadena = Cadena + '<p></p>' + 'Celular 2 debe ser 9 digitos e iniciar con 9';

//        if ($(Cuerpo + 'txtCelularContacto3').val().trim().length > 0)
//        if ($(Cuerpo + 'txtCelularContacto3').val().trim().length != 9 | $(Cuerpo + 'txtCelularContacto3').val().trim().substring(0,1) != '9')
//            Cadena = Cadena + '<p></p>' + 'Celular 3 debe ser 9 digitos e iniciar con 9';

        if (Cadena != 'Ingresar los sgtes. Datos: <br> <p></p>') {
            toastr.warning(Cadena);
            return false;
        }
        return true;
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
    }
}

function F_GrabarContacto() {

    try {
        var Contenedor = '#MainContent_';
      
        var objParams = {
            Filtro_CodCtaCte: $('#hfCodCtaCte').val(),
            Filtro_Contacto: $(Contenedor + 'txtContacto').val(),
            Filtro_Area: $(Contenedor + 'txtContactoArea').val(),
            Filtro_Telefono: $(Contenedor + 'txtContactoTelefono').val(),
            Filtro_Flag_MostrarEnReporte : ($(Contenedor + 'chkFlag_MostrarEnReporte').is(':checked'))? '1' : '0',
            Filtro_CodEstado: $(Contenedor + 'ddlEstadoContacto').val(),
            Filtro_Correo1: $(Contenedor + 'txtCorreoContacto1').val(),
            Filtro_Correo2: $(Contenedor + 'txtCorreoContacto2').val(),
            Filtro_Correo3: $(Contenedor + 'txtCorreoContacto3').val(),
            Filtro_Celular1: $(Contenedor + 'txtCelularContacto1').val(),
            Filtro_Celular2: $(Contenedor + 'txtCelularContacto2').val(),
            Filtro_Celular3: $(Contenedor + 'txtCelularContacto3').val(),
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_GrabarContacto_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'SE GRABO CORRECTAMENTE') {
                    F_Update_Division_HTML('div_ContactosGrid', result.split('~')[2]);
                    toastr.success('Se Grabo Correctamente.');
                    $(Contenedor + 'txtContacto').val('');
                    $(Contenedor + 'chkFlag_MostrarEnReporte').val('');
                    $(Contenedor + 'txtContactoArea').val('');
                    $(Contenedor + 'txtContactoTelefono').val('');
                    $(Contenedor + 'txtCorreoContacto1').val('');
                    $(Contenedor + 'txtCorreoContacto2').val('');
                    $(Contenedor + 'txtCorreoContacto3').val('');
                    $(Contenedor + 'txtCelularContacto1').val('');
                    $(Contenedor + 'txtCelularContacto2').val('');
                    $(Contenedor + 'txtCelularContacto3').val('');
                    $(Contenedor + 'txtD1EnReporte').val('0.00');
                    $(Contenedor + 'txtD2EnReporte').val('0.00');
                    $(Contenedor + 'txtD3EnReporte').val('0.00');
                $('#lblNumeroConsultaContacto').text(F_Numerar_Grilla("grvContactos",'lblDatosPersonales'));

                    
                $('#div_Contactos').dialog('close');
                }
                else
                    toastr.warning(result.split('~')[1]);

            }
            else {
                toastr.warning(result.split('~')[1]);
            }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }
}

function F_ValidarEditarContacto() {

    try {

        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos: <br> <p></p>';

      if ($(Cuerpo + 'txtContactoEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Contacto';
		
        if ($(Cuerpo + 'txtCorreoContactoEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Correo';


        if (!F_ValidarCorreo($(Cuerpo + 'txtCorreoContactoEdicion1').val()))
            Cadena = Cadena + '<p></p>' + 'Correo 1';

        if (!F_ValidarCorreo($(Cuerpo + 'txtCorreoContactoEdicion2').val()))
            Cadena = Cadena + '<p></p>' + 'Correo 2';

        if (!F_ValidarCorreo($(Cuerpo + 'txtCorreoContactoEdicion3').val()))
            Cadena = Cadena + '<p></p>' + 'Correo 3';

        if ($(Cuerpo + 'txtCelularContactoEdicion1').val().trim().length > 0)
        if ($(Cuerpo + 'txtCelularContactoEdicion1').val().trim().length != 9 | $(Cuerpo + 'txtCelularContactoEdicion1').val().trim().substring(0,1) != '9')
            Cadena = Cadena + '<p></p>' + 'Celular 1 debe ser 9 digitos e iniciar con 9';

        if ($(Cuerpo + 'txtCelularContactoEdicion2').val().trim().length > 0)
        if ($(Cuerpo + 'txtCelularContactoEdicion2').val().trim().length != 9 | $(Cuerpo + 'txtCelularContactoEdicion2').val().trim().substring(0,1) != '9')
            Cadena = Cadena + '<p></p>' + 'Celular 2 debe ser 9 digitos e iniciar con 9';

        if ($(Cuerpo + 'txtCelularContactoEdicion3').val().trim().length > 0)
        if ($(Cuerpo + 'txtCelularContactoEdicion3').val().trim().length != 9 | $(Cuerpo + 'txtCelularContactoEdicion3').val().trim().substring(0,1) != '9')
            Cadena = Cadena + '<p></p>' + 'Celular 3 debe ser 9 digitos e iniciar con 9';

        if (Cadena != 'Ingresar los sgtes. Datos: <br> <p></p>') {
            toastr.warning(Cadena);
            return false;
        }
        return true;
    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
    }
}

function F_EditarContactos(Fila) {
    //if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;
        var lblCodContacto = '#' + imgID.replace('imgEditarContacto', 'lblCodContacto');
        var lblDatosPersonales = '#' + imgID.replace('imgEditarContacto', 'lblDatosPersonales');
        var lblArea = '#' + imgID.replace('imgEditarContacto', 'lblArea');
        var lblTelefono = '#' + imgID.replace('imgEditarContacto', 'lblTelefono');
        var lblCorreo1 = '#' + imgID.replace('imgEditarContacto', 'lblCorreo1');
        var lblCorreo2 = '#' + imgID.replace('imgEditarContacto', 'lblCorreo2');
        var lblCorreo3 = '#' + imgID.replace('imgEditarContacto', 'lblCorreo3');
        var lblCelular1 = '#' + imgID.replace('imgEditarContacto', 'lblCelular1');
        var lblCelular2 = '#' + imgID.replace('imgEditarContacto', 'lblCelular2');
        var lblCelular3 = '#' + imgID.replace('imgEditarContacto', 'lblCelular3');
        var hfCodCtaCte = '#' + imgID.replace('imgEditarContacto', 'hfCodCtaCte');
        var hfCodEstado = '#' + imgID.replace('imgEditarContacto', 'hfCodEstado');
        var hfD1 = '#' + imgID.replace('imgEditarContacto', 'hfD1');
        var hfD2 = '#' + imgID.replace('imgEditarContacto', 'hfD2');
        var hfD3 = '#' + imgID.replace('imgEditarContacto', 'hfD3');
        var hfchkFlag_MostrarEnReporteEdicion = '#' + imgID.replace('imgEditarContacto', 'hfFlag_MostrarEnReporte');

        var Cuerpo = '#MainContent_';

        $('#hfCodCtaCte').val($(hfCodCtaCte).val());
        $('#hfCodContacto').val($(lblCodContacto).val());
        $(Cuerpo + 'txtContactoEdicion').val($(lblDatosPersonales).text());
        $(Cuerpo + 'txtContactoAreaEdicion').val($(lblArea).text());
        $(Cuerpo + 'txtTelefonoContactoEdicion').val($(lblTelefono).text());
        $(Cuerpo + 'txtCorreoContactoEdicion1').val($(lblCorreo1).text());
        $(Cuerpo + 'txtCorreoContactoEdicion2').val($(lblCorreo2).text());
        $(Cuerpo + 'txtCorreoContactoEdicion3').val($(lblCorreo3).text());
        $(Cuerpo + 'txtCelularContactoEdicion1').val($(lblCelular1).text());
        $(Cuerpo + 'txtCelularContactoEdicion2').val($(lblCelular2).text());
        $(Cuerpo + 'txtCelularContactoEdicion3').val($(lblCelular3).text());
        $(Cuerpo + 'txtD1Editar').val($(hfD1).val());
        $(Cuerpo + 'txtD2Editar').val($(hfD2).val());
        $(Cuerpo + 'txtD3Editar').val($(hfD3).val());
        $(Cuerpo + 'ddlEstadoContactoEdicion').val($(hfCodEstado).val());                
        ($(hfchkFlag_MostrarEnReporteEdicion).val() === '1')? $(Cuerpo + 'chkFlag_MostrarEnReporteEdicion').prop('checked', true) : $(Cuerpo + 'chkFlag_MostrarEnReporteEdicion').prop('checked', false);

        $("#div_ContactosEdicion").dialog({
            resizable: false,
            modal: true,
            title: "Edicion de Contacto",
            title_html: true,
            height: 240,
            width: 650,
            autoOpen: false
        });

     

        $('#div_ContactosEdicion').dialog('open');


        return false;

    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
        return false;
    }

}

function F_EdicionContacto() {

    try {
        var Contenedor = '#MainContent_';
      
        var objParams = {
            Filtro_CodCtaCte: $('#hfCodCtaCte').val(),
            Filtro_CodContacto: $('#hfCodContacto').val(),
            Filtro_DatosPersonales: $('#MainContent_txtContactoEdicion').val(),
            Filtro_Area: $('#MainContent_txtContactoAreaEdicion').val(),
            Filtro_Flag_MostrarEnReporte : ($(Contenedor + 'chkFlag_MostrarEnReporteEdicion').is(':checked'))? '1' : '0',
            Filtro_Telefono: $('#MainContent_txtTelefonoContactoEdicion').val(),
            Filtro_Correo1: $('#MainContent_txtCorreoContactoEdicion1').val(),
            Filtro_Correo2: $('#MainContent_txtCorreoContactoEdicion2').val(),
            Filtro_Correo3: $('#MainContent_txtCorreoContactoEdicion3').val(),
            Filtro_Celular1: $('#MainContent_txtCelularContactoEdicion1').val(),
            Filtro_Celular2: $('#MainContent_txtCelularContactoEdicion2').val(),
            Filtro_Celular3: $('#MainContent_txtCelularContactoEdicion3').val(),
            Filtro_CodEstado: $('#MainContent_ddlEstadoContactoEdicion').val(),
        };


        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ActualizarContactos_NET(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'SE ACTUALIZO CORRECTAMENTE') {
                    F_Update_Division_HTML('div_ContactosGrid', result.split('~')[2]);
                    toastr.success('Se Grabo Correctamente.');
                    $('#hfCodCtaCte').val('0');
                    $(Contenedor + 'txtContacto').val('');
                    $(Contenedor + 'txtContactoArea').val('');
                    $(Contenedor + 'txtContactoTelefono').val('');
                    $(Contenedor + 'txtCorreoContacto').val('');
                    $(Contenedor + 'txtCorreoContactoEdicion1').val('');
                    $(Contenedor + 'txtCorreoContactoEdicion2').val('');
                    $(Contenedor + 'txtCorreoContactoEdicion3').val('');
                    $(Contenedor + 'txtContactoContactoEdicion1').val('');
                    $(Contenedor + 'txtContactoContactoEdicion2').val('');
                    $(Contenedor + 'txtContactoContactoEdicion3').val('');
                    $(Contenedor + 'chkFlag_MostrarEnReporte').prop('checked', false)
                    $('#div_ContactosEdicion').dialog('close');
    
                }
                else
                    toastr.warning(result.split('~')[1]);


            }
            else {
                toastr.warning(result.split('~')[1]);
            }

            return false;

        });
    }

    catch (e) {
        MostrarEspera(false);
        toastr.warning("Error Detectado: " + e);
        return false;
    }
}

function getContentTab(){
//    F_Buscar();
    return false;

}

function F_FuncionesBotones() {
    var k = new Kibo();

    k.down("enter", function () {

        var control = $(':focus');
        var inputs = control.parents("form").eq(0).find("input, select");
        var idx = inputs.index(control);

        if (idx == inputs.length - 1) {
            if (control.attr('id') === 'MainContent_txtDescripcionConsulta')
                F_Buscar();

        } else {
            if (control.attr('id') === 'MainContent_txtDescripcionConsulta')
                F_Buscar();
        }
        return false;
    });
}


//Joel
//api sunat
//esta funcion buscar la direccion con el ubigeo que se consigue con el api,esta funcion se encuentra en servicios
function F_BuscarDireccionNuevo() {
    if (!F_SesionRedireccionar(AppSession)) return false;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_Direccion_Buscar', 
        data: "{'Ubigeo':'" + ubigeo + "'}",
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            $('#hfRegion').val(data[0].split(',')[0]);
            $('#hfProvincia').val(data[0].split(',')[1]);
            $('#hfDistrito').val(data[0].split(',')[2]);
            return true;

        },
        complete: function () {
            if (($('#hfRegion').val() == '' | $('#hfProvincia').val() == '') && $('#hfDistrito').val() == '') {
                toastr.warning('NO HAY DIRECCION PARA EL DISTRITO ESPECIFICADO')
                $('#MainContent_txtDireccion').val('');
                $('#hfDireccion').val('');
                $('#hfCodDireccion').val('0');
                $('#MainContent_txtCorreo').val('');
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
// esta funcion se encarga de busca la url y el token del api para la busque en la parte de padronsunat
function F_API_RUC_Buscar() {
    if (!F_SesionRedireccionar(AppSession)) return false;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_API_RUC_Buscar',
        data: "{}",
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            $('#hfurlapisunat').val(data[0].split(',')[0]);
            $('#hftokenapisunat').val(data[0].split(',')[1]);
            
            return true;

        },
        complete: function () {
         
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
//limpia los campos
function F_LimpiarCampos() {
    if (!F_SesionRedireccionar(AppSession)) return false;

    $('#MainContent_txtRazonSocial').val('');
    $('#MainContent_txtDistrito').val('');
    $('#MainContent_txtDireccion').val('');
    $('#MainContent_txtDistrito').val('');
    $('#MainContent_txtNombreComercial').val('');

    $('#hfRegion').val('0');
    $('#hfProvincia').val('0');
    $('#hfDistrito').val('0');

//    $('#hftokenapisunat').val('');
//    $('#hfurlapisunat').val('');
    

    return true;
}

//FINAL

function F_CompartirDireccionGPS(Fila) {
        var imgID = Fila.id;
        var hfGPSLong = '#' + imgID.replace('imgGPS', 'hfGPSLong');
        var hfGPSLat = '#' + imgID.replace('imgGPS', 'hfGPSLat');
        var hfGPSDireccion = '#' + imgID.replace('imgGPS', 'hfGPSDireccion');


        $('#MainContent_txtGPSLongCompartir').val($(hfGPSLong).val());
        $('#MainContent_txtGPSLatCompartir').val($(hfGPSLat).val());
        $('#MainContent_txtGPSLinkCompartir').val($(hfGPSDireccion).val());
          $('#hfGPSLinkCompartir').val($(hfGPSDireccion).val());


        $("#div_GPSCompartir").dialog({
            resizable: false,
            modal: true,
            title: "Compartir Direccion GPS",
            title_html: true,
            height: 170,
            width: 240,
            autoOpen: false
        });
        
        $('#div_GPSCompartir').dialog('open');
}

function F_CopiarDireccionGPS(Fila) { 
var imgID = Fila.id;
        var hfGPSDireccion = '#' + imgID.replace('imgCopiar', 'hfGPSDireccion');

          $('#hfGPSLinkCompartir').val($(hfGPSDireccion).val());
    $('#hfGPSLinkCompartir').focus();
    $('#hfGPSLinkCompartir').select();
    document.execCommand("copy");
    toastr.success("Copiado!!");
}


function F_AbrirDireccionGPS(Fila) { 
var imgID = Fila.id;
        var hfGPSDireccion = '#' + imgID.replace('imgAbrir', 'hfGPSDireccion');


 
          $('#hfGPSLinkCompartir').val($(hfGPSDireccion).val());
window.open( $('#hfGPSLinkCompartir').val(), '_blank');

}

function F_EliminarContacto(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
         var imgID = Fila.id;
        var lblCodContacto = '#' + imgID.replace('imgAnularContacto', 'lblCodContacto');
        var hfCodCtaCte = '#' + imgID.replace('imgAnularContacto', 'hfCodCtaCte');
        var hfCodEstado = '#' + imgID.replace('imgAnularContacto', 'hfCodEstado');
        var lblDatosPersonales = '#' + imgID.replace('imgAnularContacto', 'lblDatosPersonales');
        var hfchkFlag_MostrarEnReporteEdicion = '#' + imgID.replace('imgAnularContacto', 'hfFlag_MostrarEnReporte');

        var Cuerpo = '#MainContent_';

        $('#hfCodCtaCte').val($(hfCodCtaCte).val());
        $('#hfCodContacto').val($(lblCodContacto).val());
        $(Cuerpo + 'ddlEstadoContactoEdicion').val($(hfCodEstado).val());     

        if (!confirm("ESTA SEGURO DE ELIMINAR EL CONTACTO " + $(lblDatosPersonales).text()))
            return false;

        var objParams = {
            Filtro_CodCtaCte: $('#hfCodCtaCte').val(),                              
            Filtro_CodContacto: $(lblCodContacto).val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EliminarContactos_Net(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
               F_Update_Division_HTML('div_ContactosGrid', result.split('~')[2]);
                    toastr.success('Se Elimino Correctamente.');
                $('#lblNumeroConsultaContacto').text(F_Numerar_Grilla("grvContactos",'lblDatosPersonales'));
            }
            else {
                toastr.warning(result.split('~')[1]);
            }

            return false;
        });

    }

    catch (e) {

        toastr.warning("Error Detectado: " + e);
        return false;
    }


}

var CtlgvCorreo;
var HfgvCorreo;
function imgMasCorreo_Click(Control) {
    CtlgvCorreo = Control;
    var Src = $(Control).attr('src');

    if (Src.indexOf('plus') >= 0) {
        var grid = $(Control).next();
        F_Correo(grid.attr('id'));        
        $(Control).attr('src', '../Asset/images/minus.gif');
    }
    else {
        $(Control).attr("src", "../Asset/images/plus.gif");
        $(Control).closest("tr").next().remove();
    }
    return false;
}

function F_Correo(Fila) {
    try {
        var Col = Fila.split('_')[3];
        var Codigo = $('#' + Fila.replace('pnlOrdersCorreo', 'hfCodigo')).val();
        var grvNombre = 'MainContent_grvConsultaDetalle_grvDetalleCorreo_' + Col;

        if ($(HfgvCorreo).val() === "1") {
                    $(CtlgvCorreo).closest('tr').after('<tr><td></td><td colspan = "999">' + $(CtlgvCorreo).next().html() + '</td></tr>');
                    $(CtlgvCorreo).attr('src', '../Asset/images/minus.gif');
        }
        else {
            {
                var objParams =
                        {
                            Filtro_Col: Col,
                            Filtro_Codigo: Codigo,                           
                            Filtro_grvNombre: grvNombre
                        };

                var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);

                //MostrarEspera(true);
                $(CtlgvCorreo).attr('src', '../Asset/images/loading.gif');
                F_Correo_NET(arg, function (result) {
                $(CtlgvCorreo).attr('src', '../Asset/images/minus.gif');
                    //MostrarEspera(false);

                    var str_resultado_operacion = result.split('~')[0];
                    var str_mensaje_operacion = result.split('~')[1];

                    if (str_resultado_operacion === "0") {
                        var p = $('#' + result.split('~')[3]).parent();
                        $(p).attr('id', result.split('~')[3].replace('MainContent', 'div')); $(p).empty();

                        F_Update_Division_HTML($(p).attr('id'), result.split('~')[2]);

                        $(CtlgvCorreo).closest('tr').after('<tr><td></td><td colspan = "999">' + $(CtlgvCorreo).next().html() + '</td></tr>');
                    }
                    else {
                        toastr.warning(str_mensaje_operacion);
                    }
                    return false;
                });
            }
        }
    }
    catch (e) {
        MostrarEspera(false);
        toastr.warning("ERROR DETECTADO: " + e);
        return false;
    }
    return true;
}