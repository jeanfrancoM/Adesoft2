var AppSession = "../Maestros/Almacen.aspx";

var CodigoMenu = 1000;
var CodigoInterno = 16;

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

    $('#divTabs').tabs();

    //joel 19/02/21 17:16
    //autocompleta el distrito 
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
            $('#hfCodDepartemento').val(i.item.val);
            $('#hfCodProvincia').val(i.item.CodProvincia);
            $('#hfCodDistrito').val(i.item.CodDistrito);
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
            $('#hfCodDepartamentoEdicion').val(i.item.val);
            $('#hfCodProvinciaEdicion').val(i.item.CodProvincia);
            $('#hfCodDistritoEdicion').val(i.item.CodDistrito);
        },
        minLength: 3
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
                height: 490,
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
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
        try {
            if (!F_ValidarGrabarDocumento())
                return false;

            if (confirm("ESTA SEGURO DE GRABAR EL ALMACEN"))
                F_GrabarDocumento();
      
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
            F_Buscar();
            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

    $('#MainContent_btnEdicion').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        try {
            if (!F_ValidarEdicionDocumento())
                return false;

            if (confirm("ESTA SEGURO DE ACTUALIZAR LOS DATOS DE LA ALMACEN"))
                F_EdicionRegistro();
      
            return false;
        }
        catch (e) {
            toastr.warning("Error Detectado: " + e);
        }
    });

    F_Controles_Inicializar();

    $('#MainContent_txtDescripcionEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcion').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcionConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtCodAlmacenEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtTelefonoEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtDistritoEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtDireccionEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtDSCALMACEN').css('background', '#FFFFE0');

    $('#MainContent_txtDireccion').css('background', '#FFFFE0');

    $('#MainContent_txtTelefono').css('background', '#FFFFE0');

    $('#MainContent_txtDistrito').css('background', '#FFFFE0');
    
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
        var objParams = {};

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
                        F_Update_Division_HTML('div_Estado', result.split('~')[2]);
                        F_Update_Division_HTML('div_EstadoEdicion', result.split('~')[3]);

                        F_Update_Division_HTML('div_Empresa', result.split('~')[4]);
                        F_Update_Division_HTML('div_EmpresaEdicion', result.split('~')[5]);
                        F_Update_Division_HTML('div_EmpresaConsulta', result.split('~')[6]);


                        $('#MainContent_ddlEstado').val(1);
                        $('#MainContent_ddlEstado').css('background', '#FFFFE0');
                        $('#MainContent_ddlEstadoEdicion').css('background', '#FFFFE0');

                        $('#MainContent_ddlEmpresa').css('background', '#FFFFE0');
                        $('#MainContent_ddlEmpresaEdicion').css('background', '#FFFFE0');
                        $('#MainContent_ddlEmpresaConsulta').css('background', '#FFFFE0');
                        $('#MainContent_txtNroDni').focus();
                        $('.ccsestilo').css('background', '#FFFFE0');
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

function F_ValidarTipoCliente(CodTipoCliente) {
    var arg;
    try {
        if (CodTipoCliente == '1') {
            $('#MainContent_txtNroDni').prop('disabled', false);
            $('#MainContent_txtApellidoPaterno').prop('disabled', false);
            $('#MainContent_txtApellidoMaterno').prop('disabled', false);
            $('#MainContent_txtNombres').prop('disabled', false);
            $('#MainContent_txtRazonSocial').prop('disabled', true);
            $('#MainContent_txtNroRuc').prop('disabled', true);
            $('#MainContent_txtRazonSocial').val('');
            $('#MainContent_txtNroRuc').val('');
            $('#MainContent_txtNroDni').focus();

        }
        else {
            $('#MainContent_txtRazonSocial').prop('disabled', false);
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
        }
        return false;


    }
    catch (mierror) {
        toastr.warning("Error detectado: " + mierror);
    }

}

function F_ValidarGrabarDocumento() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos:';

        if ($(Cuerpo + 'txtDescripcion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Descripcion';

        if ($(Cuerpo + 'txtDireccion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Direccion';

        if ($(Cuerpo + 'txtDistrito').val() == '' || $('#hfDistrito').val() == '0')
            Cadena = Cadena + '<p></p>' + 'Distrito';
                                         
        if ($(Cuerpo + 'ddlEstado').val() == 0 || $(Cuerpo + 'ddlEstado').val() == null)
            Cadena = Cadena + '<p></p>' + 'Estado';

        if (Cadena != 'Ingresar los sgtes. Datos:') {
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
        var FlagPrincipal = 0;

        if ($('#MainContent_chkPrincipal').is(':checked'))
            FlagPrincipal = 1;

        var objParams = {
            Filtro_CodEmpresa:              $(Contenedor + 'ddlEmpresa').val(),
            Filtro_DscAlmacen:              $(Contenedor + 'txtDescripcion').val(),
            Filtro_Direccion:               $(Contenedor + 'txtDireccion').val(),
            Filtro_CodDepartamento:         $('#hfCodDepartemento').val(),
            Filtro_CodProvincia:            $('#hfCodProvincia').val(),
            Filtro_CodDistrito:             $('#hfCodDistrito').val(),
            Filtro_FlagPrincipal:           FlagPrincipal,
            Filtro_CodEstado :              $(Contenedor + 'ddlEstado').val(),
            Filtro_Telefono:                $(Contenedor + 'txtTelefono').val()
        };
        
        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_GrabarDocumento_NET(arg, function (result) {
       
            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                if (str_mensaje_operacion == 'SE GRABO CORRECTAMENTE') {
                    toastr.success('Se Grabo Correctamente');
                    F_Nuevo();
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

function F_Nuevo() {
    var Contenedor = '#MainContent_';
    $(Contenedor + 'txtDescripcion').val('');
    $(Contenedor + 'txtDireccion').val('');
    $(Contenedor + 'txtRegion').val('');
    $(Contenedor + 'txtProvincia').val('');
    $(Contenedor + 'txtDistrito').val('');
    $(Contenedor + 'chkPrincipal').prop('checked', false);
    $(Contenedor + 'ddlEstado').val(1);
    $(Contenedor + 'txtTelefono').val('');
    return false;
}

function F_Buscar() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

    try {
        var objParams = {
            Filtro_DscAlmacen: $("#MainContent_txtDescripcionConsulta").val()

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
                $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsulta", 'lblDscAlmacen'));
                if (str_mensaje_operacion != "")
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

function F_EliminarRegistro(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID         = Fila.id;
        var hfCodAlmacen = '#' + imgID.replace('imgAnularDocumento', 'hfCodAlmacen');
        var lblDescripcion = '#' + imgID.replace('imgAnularDocumento', 'lblDscAlmacen');

        if (!confirm("ESTA SEGURO DE ELIMINAR LA Almacen " + $(lblDescripcion).text()))
            return false;

        var objParams = {
            Filtro_CodAlmacen: $(hfCodAlmacen).val(),
            Filtro_Descripcion: $('#MainContent_txtDescripcionConsulta').val()
        };

        var arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_EliminarRegistro_Net(arg, function (result) {

            var str_resultado_operacion = "";
            var str_mensaje_operacion = "";

            str_resultado_operacion = result.split('~')[0];
            str_mensaje_operacion = result.split('~')[1];
            MostrarEspera(false);
            if (str_resultado_operacion == "1") {
                F_Update_Division_HTML('div_consulta', result.split('~')[2]);
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
        var hfCodEmpresa                    = '#' + imgID.replace('imgEditarRegistro', 'hfCodEmpresa');
        var hfCodAlmacen                    = '#' + imgID.replace('imgEditarRegistro', 'hfCodAlmacen');
        var lblDescripcion                  = '#' + imgID.replace('imgEditarRegistro', 'lblDscAlmacen');
        var hfCodEstado                     = '#' + imgID.replace('imgEditarRegistro', 'hfCodEstado');
        var lblTelefono                     = '#' + imgID.replace('imgEditarRegistro', 'lblTelefono');
        var hfDireccion                     = '#' + imgID.replace('imgEditarRegistro', 'lblDireccion');
        var lblDistrito                     = '#' + imgID.replace('imgEditarRegistro', 'lblDistrito');
        var hfCodDepartamento               = '#' + imgID.replace('imgEditarRegistro', 'hfCodDepartamento');
        var hfCodProvincia                  = '#' + imgID.replace('imgEditarRegistro', 'hfCodProvincia');
        var hfCodDistrito                   = '#' + imgID.replace('imgEditarRegistro', 'hfCodDistrito');
        var hfPrincipal                     = '#' + imgID.replace('imgEditarRegistro', 'hfPrincipal');
        var Cuerpo = '#MainContent_';

        $('#hfCodAlmacen').val($(hfCodAlmacen).val());
        $(Cuerpo + 'ddlEmpresaEdicion').val($(hfCodEmpresa).val());
        $(Cuerpo + 'ddlEstadoEdicion').val($(hfCodEstado).val());
        $(Cuerpo + 'txtDescripcionEdicion').val($(lblDescripcion).text());
        $(Cuerpo + 'txtTelefonoEdicion').val($(lblTelefono).text());
        $(Cuerpo + 'txtDireccionEdicion').val($(hfDireccion).text());
        $(Cuerpo + 'txtDistritoEdicion').val($(lblDistrito).text());
        $('#hfCodDepartamentoEdicion').val($(hfCodDepartamento).val());
        $('#hfCodProvinciaEdicion').val($(hfCodProvincia).val());
        $('#hfCodDistritoEdicion').val($(hfCodDistrito).val());


        if ($(hfPrincipal).val()==1)
            $(Cuerpo + 'chkPrincipalEdicion').prop('checked', true);
        else
            $(Cuerpo + 'chkPrincipalEdicion').prop('checked', false);
          
        $("#divEdicionRegistro").dialog({
            resizable: false,
            modal: true,
            title: "Edicion de Almacen",
            title_html: true,
            height: 250,
            width: 530,
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
        var FlagPrincipal = 0;
        if ($('#MainContent_chkPrincipalEdicion').is(':checked'))
            FlagPrincipal = 1;

        var objParams = {
            Filtro_CodAlmacen:                      $('#hfCodAlmacen').val(),
            Filtro_CodEmpresa:                      $(Contenedor + 'ddlEmpresaEdicion').val(),
            Filtro_DscAlmacen:                      $(Contenedor + 'txtDescripcionEdicion').val(),
            Filtro_Direccion:                       $(Contenedor + 'txtDireccionEdicion').val(),
            Filtro_CodEstado:                       $(Contenedor + 'ddlEstadoEdicion').val(),
            Filtro_Telefono:                        $(Contenedor + 'txtTelefonoEdicion').val(),
            Filtro_CodDepartamento:                 $('#hfCodDepartamentoEdicion').val(),
            Filtro_CodProvincia:                    $('#hfCodProvinciaEdicion').val(),
            Filtro_CodDistrito:                     $('#hfCodDistritoEdicion').val(),
            Filtro_FlagPrincipal:                   FlagPrincipal
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
                if (str_mensaje_operacion == 'SE ACTUALIZO CORRECTAMENTE') {
                    toastr.success('Se ACTUALIZO Correctamente.');
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
        var Cadena = 'Ingresar los sgtes. Datos:';

        if ($(Cuerpo + 'txtDescripcionEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Descripcion';

        if ($(Cuerpo + 'txtDireccionEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Direccion';

        if ($(Cuerpo + 'txtDistritoEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Distrito';

        if ($(Cuerpo + 'ddlEstadoEdicion').val() == 0 || $(Cuerpo + 'ddlEstadoEdicion').val() == null)
            Cadena = Cadena + '<p></p>' + 'Estado';

        if (Cadena != 'Ingresar los sgtes. Datos:') {
            toastr.warning(Cadena);
            return false;
        }
        return true;
    }
    catch (e) {
        toastr.warning("Error Detectado: " + e);
    }
}

var xCodAlmacen = 0;
function F_DireccionesXCliente(CodALmacen) {
    xCodAlmacen = CodAlmacen;
    try {
        var objParams = {
            Filtro_CodALmacen: CodALmacen
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

                
                F_Update_Division_HTML('divEdicionRegistro', result.split('~')[2]);
                try { $('#div_DireccionMultiple').dialog('open'); }
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

function F_ElegirPrincipalDireccion(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion 
    try {
        var imgID = Fila.id;
        var lblCodDireccion = '#' + imgID.replace('imgPrincipal', 'lblCodDireccion');
        hfCodEstado = '#' + imgID.replace('imgPrincipal', 'hfCodEstado');

        var Cuerpo = '#MainContent_';
        if ($(hfCodEstado).val() == '2') {
            toastr.warning('LAS DIRECCIONES PRINCPALES DEBEN ESTAR ACTIVAS');
            return false;
        }

        var objParams = {
            Filtro_CodDireccion: $(lblCodDireccion).text()
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
                    F_DireccionesXCliente($('#hfCodCtaCte').val());
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
        return false;
    }
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

function getContentTab() {
   
    F_Buscar();
    return false;

}
