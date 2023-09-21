var AppSession = "../Maestros/Vehiculos.aspx";

var CodigoMenu = 9000;
var CodigoInterno = 2;

var P_CodMoneda_LineaCredito_Inicial;

$(document).ready(function () {
    if (!F_SesionRedireccionar(AppSession)) return false;
        F_FuncionesBotones();

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

    $('#MainContent_txtVencimientoSoat').datepicker({ onSelect: function () {
        var date = $(this).datepicker('getDate');
        if (date) {
            date.setDate(1);
            $(this).datepicker('setDate', date);
        }
    }
    });

    $('#MainContent_txtVencimientoSoat').datepicker({ beforeShowDay: function (date) {
        return [date.getDate() == 1, ''];
    }
    });

    $('#MainContent_txtRevision').datepicker({ onSelect: function () {
        var date = $(this).datepicker('getDate');
        if (date) {
            date.setDate(1);
            $(this).datepicker('setDate', date);
        }
    }
    });

    $('#MainContent_txtRevision').datepicker({ beforeShowDay: function (date) {
        return [date.getDate() == 1, ''];
    }
    });

    $(document).on("change", "select[id $= 'MainContent_ddlMarca']",function () {
     F_ListarModelo();
} );

    $(document).on("change", "select[id $= 'MainContent_ddlMarcaEdicion']",function () {
     F_ListarModeloEdicion();
} );

        $('#MainContent_txtNroRucEdicion').autocomplete(   
    {
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'1','CodTipoCliente':'0'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0],
                            Direccion: item.split(',')[2],
                            DireccionEnvio: item.split(',')[3],
                            Distrito: item.split(',')[4],
                            CodDepartamento: item.split(',')[5],
                            CodProvincia: item.split(',')[6],
                            CodDistrito: item.split(',')[7],
                            NroRuc: item.split(',')[8],
                            ApePaterno: item.split(',')[9],
                            ApeMaterno: item.split(',')[10],
                            Nombres: item.split(',')[11],
                            Cliente: item.split(',')[1],
                            SaldoCreditoFavor: item.split(',')[12],
                            CodDireccion: item.split(',')[14]
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

         $('#MainContent_txtNroRucEdicion').val(i.item.NroRuc);
            $('#hfNroRucEdicion').val(i.item.NroRuc);
            $('#hfCodCtaCteEdicion').val(i.item.val);
            $('#hfClienteEdicion').val(i.item.label);
            $('#MainContent_txtClienteEdicion').val(i.item.label);
            $('#MainContent_txtNroRucEdicion').val(i.item.NroRuc);
            $('#MainContent_txtDireccionEdicion').val(i.item.Direccion);
            $('#hfDireccionEdicion').val(i.item.Direccion);
            $('#MainContent_txtDistritoEdicion').val(i.item.Distrito.trim());
            $('#hfCodDireccionEdicion').val('0');
            $('#hfCodDireccionDefectoEdicion').val(i.item.CodDireccion);
            $('#hfCodDepartamentoEdicion').val(i.item.CodDepartamento);
            $('#hfCodProvinciaEdicion').val(i.item.CodProvincia);
            $('#hfCodDistritoEdicion').val(i.item.CodDistrito);
            $('#hfDistritoEdicion').val(i.item.Distrito.trim());

            F_BuscarDireccionesClienteEdicion();
           // $('#MainContent_txtDireccion').focus();
        },
        complete: function () {
            $('#MainContent_txtNroRucEdicion').val($('#hfNroRucEdicion').val());
        },
        minLength: 3
    });




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

  

     $('#MainContent_txtNroRuc').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_ListarClientes_AutoComplete',
                data: "{'NroRuc':'" + "" + "','RazonSocial':'" + request.term + "','CodTipoCtaCte':'1','CodTipoCliente':'" + '0' + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.split(',')[1],
                            val: item.split(',')[0],
                            Direccion: item.split(',')[2],
                            DireccionEnvio: item.split(',')[3],
                            Distrito: item.split(',')[4],
                            CodDepartamento: item.split(',')[5],
                            CodProvincia: item.split(',')[6],
                            CodDistrito: item.split(',')[7],
                            NroRuc: item.split(',')[8],
                            ApePaterno: item.split(',')[9],
                            ApeMaterno: item.split(',')[10],
                            Nombres: item.split(',')[11],
                            Cliente: item.split(',')[1],
                            SaldoCreditoFavor: item.split(',')[12],
                            CodDireccion: item.split(',')[14]
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
            $('#MainContent_txtNroRuc').val(i.item.NroRuc);
            $('#hfNroRuc').val(i.item.NroRuc);
            $('#hfCodCtaCte').val(i.item.val);
            $('#hfCliente').val(i.item.label);
            $('#MainContent_txtCliente').val(i.item.label);
            $('#MainContent_txtNroRuc').val(i.item.NroRuc);
            $('#MainContent_txtDireccion').val(i.item.Direccion);
            $('#hfDireccion').val(i.item.Direccion);
            $('#MainContent_txtDistrito').val(i.item.Distrito.trim());
            $('#hfCodDireccion').val('0');
            $('#hfCodDireccionDefecto').val(i.item.CodDireccion);
            $('#hfCodDepartamento').val(i.item.CodDepartamento);
            $('#hfCodProvincia').val(i.item.CodProvincia);
            $('#hfCodDistrito').val(i.item.CodDistrito);
            $('#hfDistrito').val(i.item.Distrito.trim());
            $('#hfFlagRuc').val("1");
            $('#txtSaldoCreditoFavor').text(i.item.SaldoCreditoFavor);
            $('#hfSaldoCreditoFavor').val(i.item.SaldoCreditoFavor.replace("S/", "").replace(" ", ""));

            F_BuscarDireccionesCliente();
           // $('#MainContent_txtDireccion').focus();

        },
        complete: function () {
            $('#MainContent_txtNroRuc').val($('#hfNroRuc').val());
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


    $('#MainContent_btnGrabar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion

        try {
            if (F_ValidarGrabarDocumento() == false)
                return false;

            if (confirm("ESTA SEGURO DE GRABAR EL COMPONENTE"))
                F_GrabarDocumento();
              //   F_Nuevo();
            //            }
            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

      $('#MainContent_btnActualizar').click(function () {
        if (!F_SesionRedireccionar(AppSession)) return false;
       // if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Insertar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacio
        
        try {
      
            F_ActualizarCombos();
            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

    //

    
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
        if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
        try {
            if (F_ValidarEdicionDocumento() == false)
                return false;

            if (confirm("ESTA SEGURO DE ACTUALIZAR LOS DATOS DEL COMPONENTE"))
                F_EdicionRegistro();
            //                F_Nuevo();
            //            }
            return false;
        }

        catch (e) {

            toastr.warning("Error Detectado: " + e);
        }

    });

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


                        F_Update_Division_HTML('div_TipoComponente', result.split('~')[2]);
                        F_Update_Division_HTML('div_TipoComponenteEdicion', result.split('~')[3]);
                        F_Update_Division_HTML('div_TipoComponenteConsulta', result.split('~')[4]);
                        F_Update_Division_HTML('div_TipoVehiculo', result.split('~')[5]);
                        F_Update_Division_HTML('div_TipoVehiculoEdicion', result.split('~')[6]);
                        F_Update_Division_HTML('div_TipoVehiculoConsulta', result.split('~')[7]);
                        F_Update_Division_HTML('div_Estado', result.split('~')[8]);
                        F_Update_Division_HTML('div_EstadoEdicion', result.split('~')[9]);
                        F_Update_Division_HTML('div_EstadoConsulta', result.split('~')[10]);


                        //$('#MainContent_ddlEstadoConsulta').prepend("<option value='0' >TODOS</option>");
                        $('#MainContent_ddlTipoVehiculoConsulta').prepend("<option value='0' >TODOS</option>");
                        $('#MainContent_ddlTipoComponenteConsulta').prepend("<option value='0' >TODOS</option>");

                        //$('#MainContent_ddlEstadoConsulta').val("0");
                        $('#MainContent_ddlTipoVehiculoConsulta').val("0");
                        $('#MainContent_ddlTipoComponenteConsulta').val("0");

                        
                          $('#MainContent_ddlTipoVehiculo').val(-1);
                          $('#MainContent_ddlTipoVehiculoEdicion').val(-1);

                          $('#MainContent_ddlTipoComponente').val(-1);
                          $('#MainContent_ddlTipoComponenteEdicion').val(-1);


                         $('#MainContent_ddlEstado').css('background', '#FFFFE0');
                         $('#MainContent_ddlEstadoEdicion').css('background', '#FFFFE0');
                         $('#MainContent_ddlEstadoConsulta').css('background', '#FFFFE0');

                          $('#MainContent_ddlTipoVehiculo').css('background', '#FFFFE0');
                          $('#MainContent_ddlTipoVehiculoEdicion').css('background', '#FFFFE0');
                          $('#MainContent_ddlTipoVehiculoConsulta').css('background', '#FFFFE0');

                          $('#MainContent_ddlTipoComponente').css('background', '#FFFFE0');
                          $('#MainContent_ddlTipoComponenteEdicion').css('background', '#FFFFE0');
                          $('#MainContent_ddlTipoComponenteConsulta').css('background', '#FFFFE0');


                        // $('#MainContent_ddlEstado').val(-1);
                         //$('#MainContent_ddlEstadoEdicion').val(-1);


                          //$('#MainContent_ddlEstado').val(0);
                          $('#MainContent_ddlTipoComponente').focus();
                          
                     
                              
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
return true;
}


function F_FuncionesBotones() {
    var k = new Kibo(); 

    k.down("enter", function () {

            var control = $(':focus');
            var inputs = control.parents("form").eq(0).find("input, select");
            var idx = inputs.index(control);

            if (idx == inputs.length - 1) {
                //campos especiales
                F_CamposAlternativas(control.attr('id'));
            } 
            else {

              inputs[idx + 1].focus(); //  handles submit buttons
                try {inputs[idx + 1].select();
                F_CamposAlternativas(control.attr('id'));
                } catch (e) { }    
                          

            }
       return false;
    });
    }


    
function F_CamposAlternativas(Campos) {
                switch (Campos)
                {
                case "MainContent_ddlTipoComponente":
                        $('#MainContent_ddlTipoVehiculo').select();
                    break;
                   case "MainContent_ddlTipoVehiculo":
                        $('#MainContent_txtDescripcion').select();
                    break;
                    case "MainContent_txtDescripcion":
                        $('#MainContent_txtCantidad').select();
                    break;
                    case "MainContent_txtCantidad":
                        $('#MainContent_ddlEstado').select();
                    break;
                    case "MainContent_ddlEstado":
                        $('#MainContent_btnGrabar').click();
                    break;
                    case "MainContent_btnGrabar":
                        $('#MainContent_btnGrabar').click();
                    break;


                     case "MainContent_ddlTipoComponenteEdicion":
                        $('#MainContent_ddlTipoVehiculoEdicion').select();
                    break;
                   case "MainContent_ddlTipoVehiculoEdicion":
                        $('#MainContent_txtDescripcionEdicion').select();
                    break;
                    case "MainContent_txtDescripcionEdicion":
                        $('#MainContent_txtCantidadEdicion').select();
                    break;
                    case "MainContent_txtCantidadEdicion":
                        $('#MainContent_ddlEstadoEdicion').select();
                    break;
                    case "MainContent_ddlEstadoEdicion":
                        $('#MainContent_btnEdicion').click();
                    break;
                    
                    default:
                    //otros casos

                        //Agregar Con Enter desde la Grilla
                    break;
                }

return true;
}

function F_ActualizarCombos() {
    F_Inicializar_Parametros();
    var arg;
    //var PermisoDescuento = F_PermisoOpcion_SinAviso(CodigoMenu, 1000103, '');

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
                
                    
                       // var color = $('#MainContent_ddlEstado').val();
                         var tipoVehiculo = $('#MainContent_ddlTipoVehiculo').val();
                         var tipoComponente  = $('#MainContent_ddlTipoComponente').val();

                        F_Update_Division_HTML('div_TipoComponente', result.split('~')[2]);
                        F_Update_Division_HTML('div_TipoComponenteEdicion', result.split('~')[3]);
                        F_Update_Division_HTML('div_TipoComponenteConsulta', result.split('~')[4]);
                        F_Update_Division_HTML('div_TipoVehiculo', result.split('~')[5]);
                        F_Update_Division_HTML('div_TipoVehiculoEdicion', result.split('~')[6]);
                        F_Update_Division_HTML('div_TipoVehiculoConsulta', result.split('~')[7]);
                        F_Update_Division_HTML('div_Estado', result.split('~')[8]);
                        F_Update_Division_HTML('div_EstadoEdicion', result.split('~')[9]);
                        F_Update_Division_HTML('div_EstadoConsulta', result.split('~')[10]);


                         $('#MainContent_ddlTipoVehiculoConsulta').prepend("<option value='0' >TODOS</option>");
                        $('#MainContent_ddlTipoComponenteConsulta').prepend("<option value='0' >TODOS</option>");

                        //$('#MainContent_ddlEstadoConsulta').val("0");
                        $('#MainContent_ddlTipoVehiculoConsulta').val("0");
                        $('#MainContent_ddlTipoComponenteConsulta').val("0");

                          if(tipoVehiculo) $('#MainContent_ddlTipoVehiculo').val(tipoVehiculo);   else  $('#MainContent_ddlTipoVehiculo').val(-1);
                          if(tipoComponente) $('#MainContent_ddlTipoComponente').val(tipoComponente);   else $('#MainContent_ddlTipoComponente').val(-1);


                         $('#MainContent_ddlEstado').css('background', '#FFFFE0');
                         $('#MainContent_ddlEstadoEdicion').css('background', '#FFFFE0');
                         $('#MainContent_ddlEstadoConsulta').css('background', '#FFFFE0');

                          $('#MainContent_ddlTipoVehiculo').css('background', '#FFFFE0');
                          $('#MainContent_ddlTipoVehiculoEdicion').css('background', '#FFFFE0');
                          $('#MainContent_ddlTipoVehiculoConsulta').css('background', '#FFFFE0');

                          $('#MainContent_ddlTipoComponente').css('background', '#FFFFE0');
                          $('#MainContent_ddlTipoComponenteEdicion').css('background', '#FFFFE0');
                          $('#MainContent_ddlTipoComponenteConsulta').css('background', '#FFFFE0');

                              
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

function F_ValidarGrabarDocumento() {

    try {

        var Cuerpo = '#MainContent_';
        var Cadena = 'Ingresar los sgtes. Datos: <br> <p></p>';
        //MainContent_
          
              if ( $("#MainContent_ddlTipoComponente option:selected").text() == ""){
            Cadena = Cadena + "<p></p>" + "Tipo Componente";
            }

             if ( $("#MainContent_ddlTipoVehiculo option:selected").text() == ""){
            Cadena = Cadena + "<p></p>" + "Tipo Vehiculo";
            }

              if ( $("#MainContent_ddlEstado option:selected").text() == ""){
            Cadena = Cadena + "<p></p>" + "Estado";
            }

              if ( $("#MainContent_txtDescripcion").val() == ""){
            Cadena = Cadena + "<p></p>" + "Descripcion";
            }

             if ( $("#MainContent_txtCantidad").val() == ""){
            Cadena = Cadena + "<p></p>" + "Cantidad";
            }
              
            

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

        var objParams = {
            Filtro_CodTipoVehiculo: $(Contenedor + 'ddlTipoVehiculo').val(),
            Filtro_CodTipoComponente: $(Contenedor + 'ddlTipoComponente').val(),
            Filtro_Descripcion: $(Contenedor + 'txtDescripcion').val(),
            Filtro_Cantidad: $(Contenedor + 'txtCantidad').val(),
            Filtro_CodEstado: $(Contenedor + 'ddlEstado').val()
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
                if (str_mensaje_operacion == 'Se grabo correctamente') {               
                    toastr.success('Se Grabo Correctamente.');
                    F_LimpiarCamposGrabados();    
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

function F_LimpiarCamposGrabados()
{
var Contenedor = '#MainContent_';
  return false;
}

function F_Nuevo() {

    var Contenedor = '#MainContent_';

    $(Contenedor + 'ddlTipoComponente').val(-1);
    $(Contenedor + 'ddlTipoVehiculo').val(-1);
     $(Contenedor + 'txtDescripcion').val('');
    $(Contenedor + 'txtCantidad').val('');
    $(Contenedor + 'ddlEstado').val(1);
  
    return false;
}



function F_Buscar() {
  //  if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {

        var objParams = {
            Filtro_Descripcion: $("#MainContent_txtDescripcionConsulta").val(),
            Filtro_CodTipoComponente: $("#MainContent_ddlTipoComponenteConsulta").val(),
            Filtro_CodTipoVehiculo: $("#MainContent_ddlTipoVehiculoConsulta").val(),
            Filtro_CodEstado : $("#MainContent_ddlEstadoConsulta").val()
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
                $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsulta",'lblDescripcion'));
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

function F_AnularRegistro(Fila) {
   // if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;

        var lblCodigo = '#' + imgID.replace('imgAnularDocumento', 'hfCodVehiculoComponente');
        var lblProducto_grilla = '#' + imgID.replace('imgAnularDocumento', 'hfDescripcion');

        if ($(lblCodigo).val() == "" | $(lblCodigo).val() == '0') return false;
         

        if (confirm("ESTA SEGURO DE ELIMINAR EL COMPONENTE " + $(lblProducto_grilla).text()) == false)
            return false;

        var objParams = {
            Filtro_CodVehiculoComponente: $(lblCodigo).val()
            
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
                $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsulta",'lblDescripcion'));
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
    //if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    var imgID = Fila.id;
    var hfCodVehiculoComponente = '#' + imgID.replace('imgEditarRegistro', 'hfCodVehiculoComponente');
    if ($(hfCodVehiculoComponente).val() == "" | $(hfCodVehiculoComponente).val() == "0") return false;

  try {

    var imgID = Fila.id;
        var hfCodVehiculoComponente = '#' + imgID.replace('imgEditarRegistro', 'hfCodVehiculoComponente');
        var hfDescripcion = '#' + imgID.replace('imgEditarRegistro', 'hfDescripcion');
        var hfCantidad = '#' + imgID.replace('imgEditarRegistro', 'hfCantidad');
        var hfCodTipoVehiculo = '#' + imgID.replace('imgEditarRegistro', 'hfCodTipoVehiculo');
        var hfCodTipoComponente = '#' + imgID.replace('imgEditarRegistro', 'hfCodTipoComponente');
        var hfCodEstado = '#' + imgID.replace('imgEditarRegistro', 'hfCodEstado');
        var Cuerpo = '#MainContent_';

        $(Cuerpo + 'txtDescripcionEdicion').val($(hfDescripcion).val());
        $(Cuerpo + 'txtCantidadEdicion').val($(hfCantidad).val());

        $(Cuerpo + 'ddlTipoComponenteEdicion').val($(hfCodTipoComponente).val());
        $(Cuerpo + 'ddlTipoVehiculoEdicion').val($(hfCodTipoVehiculo).val());
        $(Cuerpo + 'ddlTipoVehiculoEdicion').val($(hfCodTipoVehiculo).val());
        $(Cuerpo + 'ddlEstadoEdicion').val($(hfCodEstado).val());
         $('#hfCodVehiculoComponente').val($(hfCodVehiculoComponente).val());
        

        //NroFlota
        $("#divEdicionRegistro").dialog({
            resizable: false,
            modal: true,
            title: "Edicion de VEHICULO COMPONENTES",
            title_html: true,
            height: 190,
            width: 550,
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


        var objParams = {
            Filtro_CodVehiculoComponente: $(Contenedor + 'ddlTipoVehiculoEdicion').val(),
            Filtro_CodTipoVehiculo: $(Contenedor + 'ddlTipoVehiculoEdicion').val(),
            Filtro_CodTipoComponente: $(Contenedor + 'ddlTipoComponenteEdicion').val(),
            Filtro_Descripcion: $(Contenedor + 'txtDescripcionEdicion').val(),
            Filtro_Cantidad: $(Contenedor + 'txtCantidadEdicion').val(),
            Filtro_CodEstado: $(Contenedor + 'ddlEstadoEdicion').val(),
            Filtro_CodVehiculoComponente:   $('#hfCodVehiculoComponente').val()
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
                    $(Contenedor + 'ddlTipoVehiculo').val('');
                    $(Contenedor + 'ddlTipoComponente').val('');
                    $(Contenedor + 'txtDescripcion').val('');
                    $(Contenedor + 'txtCantidad').val('');
                    toastr.success('Se Grabo Correctamente.');
                    F_Update_Division_HTML('div_consulta', result.split('~')[2]);
                    $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsulta",'lblDescripcion'));
                    $('#hfCodVehiculoComponente').val('0');
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

        if (($(Cuerpo + 'txtClienteEdicion').val()==''  | $('#MainContent_txtNroRucEdicion').val()=="" )  &&  ($('#hfCodCtaCteEdicion').val()==0))
                    Cadena=Cadena + '<p></p>' + 'Cliente';
         
         
              if ( $("#MainContent_ddlTipoComponenteEdicion option:selected").text() == ""){
            Cadena = Cadena + "<p></p>" + "Tipo Componente";
            }

              if ( $("#MainContent_ddlTipoVehiculoEdicion option:selected").text() == ""){
            Cadena = Cadena + "<p></p>" + "Tipo Vehiculo";
            }

              if ( $("#MainContent_ddlEstadoEdicion option:selected").text() == ""){
            Cadena = Cadena + "<p></p>" + "Estado";
            }

              if ( $("#MainContent_txtDescripcionEdicion").val() == ""){
            Cadena = Cadena + "<p></p>" + "Descripcion";
            }

             if ( $("#MainContent_txtCantidadEdicion").val() == ""){
            Cadena = Cadena + "<p></p>" + "Cantidad";
            }
              
        if (Cadena != 'Ingresar los sgtes. Datos: <br> <p></p>') {
            toastr.warning(Cadena);
            return false;
        }
    }
    catch (e) {
        toastr.warning("Error Detectado: " + e);
    }
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


function F_InicializarCajaTexto()
{
   
    $("#MainContent_txtFlota").ForceNumericOnly();

    $('#MainContent_ddlTipoComponente').css('background', '#FFFFE0');

    $('#MainContent_ddlTipoVehiculo').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcion').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcionEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtDescripcionConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtCantidad').css('background', '#FFFFE0');

     $('#MainContent_txtCantidadEdicion').css('background', '#FFFFE0');

    $('#MainContent_dllEstado').css('background', '#FFFFE0');

    $('#MainContent_dllEstadoEdicion').css('background', '#FFFFE0');

    $('#MainContent_dllEstadoConsulta').css('background', '#FFFFE0');

    $('#MainContent_ddlTipoComponenteEdicion').css('background', '#FFFFE0');

    $('#MainContent_ddlTipoVehiculoEdicion').css('background', '#FFFFE0');



    //   $('#MainContent_ddlContactoEstadoRegistro').css('background', '#FFFFE0');


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

function getContentTab(){
//    F_Buscar();
    return false;

}

//function F_FuncionesBotones() {
//    var k = new Kibo();

//    k.down("enter", function () {

//        var control = $(':focus');
//        var inputs = control.parents("form").eq(0).find("input, select");
//        var idx = inputs.index(control);

//        if (idx == inputs.length - 1) {
//            if (control.attr('id') === 'MainContent_txtDescripcionConsulta')
//                F_Buscar();

//        } else {
//            if (control.attr('id') === 'MainContent_txtDescripcionConsulta')
//                F_Buscar();
//        }
//        return false;
//    });
//}


// DETALLE AUDITORIA
var CtlgvAuditoria;
var HfgvAuditoria;
function imgMasAuditoria_Click(Control) {
    CtlgvAuditoria = Control;
    var Src = $(Control).attr('src');

    if (Src.indexOf('plus') >= 0) {
        var grid = $(Control).next();
        F_Auditoria(grid.attr('id'));        
        $(Control).attr('src', '../Asset/images/minus.gif');
    }
    else {
        $(Control).attr("src", "../Asset/images/plus.gif");
        $(Control).closest("tr").next().remove();
    }
    return false;
}


function F_Auditoria(Fila) {
    try {
        var Col = Fila.split('_')[3];
        var Codigo = $('#' + Fila.replace('pnlOrdersAuditoria', 'hfCodVehiculoComponente')).val();
        var grvNombre = 'MainContent_grvConsulta_grvDetalleAuditoria_' + Col;
        HfgvAuditoria = '#' + Fila.replace('pnlOrdersAuditoria', 'hfDetalleCargadoAuditoria');

          if (Codigo == "" | Codigo == '0') return false;

        if ($(HfgvAuditoria).val() === "1") {
                    $(CtlgvAuditoria).closest('tr').after('<tr><td></td><td colspan = "999">' + $(CtlgvAuditoria).next().html() + '</td></tr>');
                    $(CtlgvAuditoria).attr('src', '../Asset/images/minus.gif');
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
                $(CtlgvAuditoria).attr('src', '../Asset/images/loading.gif');
                F_Auditoria_NET(arg, function (result) {
                $(CtlgvAuditoria).attr('src', '../Asset/images/minus.gif');
                    //MostrarEspera(false);

                    var str_resultado_operacion = result.split('~')[0];
                    var str_mensaje_operacion = result.split('~')[1];

                    if (str_resultado_operacion === "0") {
                        var p = $('#' + result.split('~')[3]).parent();
                        $(p).attr('id', result.split('~')[3].replace('MainContent', 'div')); $(p).empty();

                        F_Update_Division_HTML($(p).attr('id'), result.split('~')[2]);

                        $(CtlgvAuditoria).closest('tr').after('<tr><td></td><td colspan = "999">' + $(CtlgvAuditoria).next().html() + '</td></tr>');
                        $(HfgvAuditoria).val('1');
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


// DETALLE OBSERVACION
var CtlgvObservacion;
var HfgvObservacion;
function imgMasObservacion_Click(Control) {
    CtlgvObservacion = Control;
    var Src = $(Control).attr('src');

    if (Src.indexOf('plus') >= 0) {
        var grid = $(Control).next();
        F_Observacion(grid.attr('id'));        
        $(Control).attr('src', '../Asset/images/minus.gif');
    }
    else {
        $(Control).attr("src", "../Asset/images/plus.gif");
        $(Control).closest("tr").next().remove();
    }
    return false;
}


function F_Observacion(Fila) {
    try {
        var Col = Fila.split('_')[3];
        var Codigo = $('#' + Fila.replace('pnlOrdersObservacion', 'hfCodVehiculo')).val();
        var grvNombre = 'MainContent_grvConsulta_grvDetalleObservacion_' + Col;
        HfgvObservacion = '#' + Fila.replace('pnlOrdersObservacion', 'grvDetalleObservacion');

        if (Codigo == "" | Codigo == '0') return false;

        if ($(HfgvObservacion).val() === "1") {
            $(CtlgvObservacion).closest('tr').after('<tr><td></td><td colspan = "999">' + $(CtlgvObservacion).next().html() + '</td></tr>');
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

                MostrarEspera(true);
                F_Observacion_NET(arg, function (result) {

                    MostrarEspera(false);

                    var str_resultado_operacion = result.split('~')[0];
                    var str_mensaje_operacion = result.split('~')[1];

                    if (str_resultado_operacion === "0") {
                        var p = $('#' + result.split('~')[3]).parent();
                        $(p).attr('id', result.split('~')[3].replace('MainContent', 'div')); $(p).empty();

                        F_Update_Division_HTML($(p).attr('id'), result.split('~')[2]);
                       
                        $(CtlgvObservacion).closest('tr').after('<tr><td></td><td colspan = "999">' + $(CtlgvObservacion).next().html() + '</td></tr>');
                        $(HfgvObservacion).val('1');
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

function F_LimpiarCampos() {
if (!F_SesionRedireccionar(AppSession)) return false;
    //Tipo de CtaCte a filtrar
    $('#hfCodTipoCliente').val('0')
    $('#MainContent_txtCliente').prop('readonly', true);
    $('#MainContent_chkConIgvMaestro').prop('checked',true );
    $('#MainContent_chkSinIgvMaestro').prop('checked',false );
    //Valores por Defecto
    $('#hfCodCtaCte').val('0');
    $('#hfCodDireccion').val('0');
    $('#MainContent_txtNroRuc').val('');
    $('#hfNroRuc').val('');
    $('#MainContent_txtCliente').val('');
    $('#hfCliente').val('');
    $('#MainContent_txtDireccion').val('');
    $('#MainContent_txtDestino').val('');
    $('#MainContent_txtDistrito').val('');
    $('#hfCodDepartamento').val('0');
    $('#hfCodProvincia').val('0');
    $('#hfCodDistrito').val('0');
    $('#hfDistrito').val('');
    $('#hfDireccion').val('');
}

function F_LimpiarCamposEdicion() {
if (!F_SesionRedireccionar(AppSession)) return false;
    //Tipo de CtaCte a filtrar
    $('#hfCodTipoClienteEdicion').val('0')
    $('#MainContent_txtClienteEdicion').prop('readonly', true);
    $('#MainContent_chkConIgvMaestroEdicion').prop('checked',true );
    $('#MainContent_chkSinIgvMaestroEdicion').prop('checked',false );
    //Valores por Defecto
    $('#hfCodCtaCteEdicion').val('0');
    $('#hfCodDireccionEdicion').val('0');
    $('#MainContent_txtNroRucEdicion').val('');
    $('#hfNroRucEdicion').val('');
    $('#MainContent_txtClienteEdicion').val('');
    $('#hfClienteEdicion').val('');
    $('#MainContent_txtDireccionEdicion').val('');
    $('#MainContent_txtDestinoEdicion').val('');
    $('#MainContent_txtDistritoEdicion').val('');
    $('#hfCodDepartamentoEdicion').val('0');
    $('#hfCodProvinciaEdicion').val('0');
    $('#hfCodDistritoEdicion').val('0');
    $('#hfDistritoEdicion').val('');
    $('#hfDireccionEdicion').val('');
}
//FINAL