var AppSession = "../Maestros/Vehiculos.aspx";

var CodigoMenu = 9000;
var CodigoInterno = 1;

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

            if (confirm("ESTA SEGURO DE GRABAR EL VEHICULO"))
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

            if (confirm("ESTA SEGURO DE ACTUALIZAR LOS DATOS DEL VEHICULO"))
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
                        F_Update_Division_HTML('div_Color', result.split('~')[2]);
                        F_Update_Division_HTML('div_Marca', result.split('~')[3]);
                       // F_Update_Division_HTML('div_Modelo', result.split('~')[4]);
                        F_Update_Division_HTML('div_Tipo', result.split('~')[5]);
                        F_Update_Division_HTML('div_Estado', result.split('~')[6]);

                          F_Update_Division_HTML('div_ColorEdicion', result.split('~')[7]);
                        F_Update_Division_HTML('div_MarcaEdicion', result.split('~')[8]);
                       // F_Update_Division_HTML('div_ModeloEdicion', result.split('~')[9]);
                        F_Update_Division_HTML('div_TipoEdicion', result.split('~')[10]);
                        F_Update_Division_HTML('div_EstadoEdicion', result.split('~')[11]);
                        F_Update_Division_HTML('div_EstadoConsulta', result.split('~')[12]);
                        //1314
                        F_Update_Division_HTML('div_TipoPlan', result.split('~')[13]);
                        F_Update_Division_HTML('div_TipoPlanEdicion', result.split('~')[14]);



                         $('#MainContent_ddlTipoPlan').css('background', '#FFFFE0');
                         $('#MainContent_ddlTipoPlanEdicion').css('background', '#FFFFE0');
                         $('#MainContent_ddlTipoPlanEdicion').val(-1);
                         $('#MainContent_ddlTipoPlan').val(-1);

                         $('#MainContent_ddlColor').css('background', '#FFFFE0');
                         $('#MainContent_ddlMarca').css('background', '#FFFFE0');
                         $('#MainContent_ddlModelo').css('background', '#FFFFE0');
                         $('#MainContent_ddlTipo').css('background', '#FFFFE0');
                         $('#MainContent_ddlEstado').css('background', '#FFFFE0');


                         $('#MainContent_ddlColor').val(-1);
                         $('#MainContent_ddlMarca').val(-1);
                         $('#MainContent_ddlModelo').val(-1);
                         $('#MainContent_ddlTipo').val(-1);

                          
                         $('#MainContent_ddlColorEdicion').css('background', '#FFFFE0');
                         $('#MainContent_ddlMarcaEdicion').css('background', '#FFFFE0');
                         $('#MainContent_ddlModeloEdicion').css('background', '#FFFFE0');
                         $('#MainContent_ddlTipoEdicion').css('background', '#FFFFE0');
                         $('#MainContent_ddlEstadoEdicion').css('background', '#FFFFE0');
                         $('#MainContent_ddlEstadoConsulta').css('background', '#FFFFE0');

                          $('#MainContent_txtVencimientoSoat').val('');
                          $('#MainContent_txtRevision').val('');

                          $('#MainContent_txtVencimientoSoat').prop('readonly', false);
                          $('#MainContent_txtRevision').prop('readonly', false);

                          $('#MainContent_txtVencimientoSoatEdicion').prop('readonly', false);
                          $('#MainContent_txtRevisionEdicion').prop('readonly', false);


                          //$('#MainContent_ddlEstado').val(0);
                          $('#MainContent_txtNroRuc').focus();
                          
                     
                              
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
                case "MainContent_txtCliente":
                        $('#MainContent_txtPlaca').select();
                    break;
                   case "MainContent_txtDireccion":
                        $('#MainContent_txtPlaca').select();
                    break;
                    case "MainContent_txtPlaca":
                        $('#MainContent_txtChasis').select();
                    break;
                    case "MainContent_txtChasis":
                        $('#MainContent_txtAnio').select();
                    break;
                    case "MainContent_txtAnio":
                        $('#MainContent_ddlColor').select();
                    break;
                    case "MainContent_ddlColor":
                           $('#MainContent_txtNroMotor').select();
                    break;
                    case "MainContent_txtNroMotor":
                           $('#MainContent_ddlMarca').select();
                    break;
                    case "MainContent_ddlMarca":
                        $('#MainContent_ddlModelo').select();
                    break;
                    case "MainContent_ddlModelo":
                        $('#MainContent_ddlTipo').select();
                    break;
                    case "MainContent_ddlTipo":
                        $('#MainContent_txtVencimientoSoat').select();
                    break;
                    case "MainContent_txtVencimientoSoat":
                        $('#MainContent_txtRevision').select();
                    break;
                    case "MainContent_txtRevision":
                        $('#MainContent_txtFlota').select();
                    break;
                     case "MainContent_txtFlota":
                        $('#MainContent_ddlEstado').select();
                    break;

                      case "MainContent_ddlEstado":
                        $('#MainContent_txtObservacion').select();
                    break;

                    case "MainContent_txtObservacion":
                        $('#MainContent_btnGrabar').select();
                    break;

                       case "MainContent_btnGrabar":
                        $('#MainContent_btnGrabar').click();
                    break;

                    case "MainContent_txtNroRucEdicion":
                        $('#MainContent_txtPlacaEdicion').focus();
                    break;

                     case "MainContent_txtClienteEdicion":
                        $('#MainContent_txtPlacaEdicion').focus();
                    break;
                    case "MainContent_txtPlacaEdicion":
                        $('#MainContent_txtChasisEdicion').focus();
                    break;
                    case "MainContent_txtChasisEdicion":
                        $('#MainContent_txtAnioEdicion').focus();
                    break;
                    case "MainContent_txtAnioEdicion":
                        $('#MainContent_ddlColorEdicion').focus();
                    break;
                    case "MainContent_ddlColorEdicion":
                           $('#MainContent_txtNroMotorEdicion').focus();
                    break;
                    case "MainContent_txtNroMotorEdicion":
                           $('#MainContent_ddlMarcaEdicion').focus();
                    break;
                    case "MainContent_ddlMarcaEdicion":
                        $('#MainContent_ddlModeloEdicion').focus();
                    break;
                    case "MainContent_ddlModeloEdicion":
                        $('#MainContent_ddlTipoEdicion').focus();
                    break;
                    case "MainContent_ddlTipoEdicion":
                        $('#MainContent_txtVencimientoSoatEdicion').focus();
                    break;
                    case "MainContent_txtVencimientoSoatEdicion":
                        $('#MainContent_txtRevisionEdicion').focus();
                    break;
                    case "MainContent_txtRevisionEdicion":
                        $('#MainContent_txtFlotaEdicion').focus();
                    break;
                     case "MainContent_txtFlotaEdicion":
                        $('#MainContent_ddlEstadoEdicion').focus();
                    break;

                      case "MainContent_ddlEstadoEdicion":
                        $('#MainContent_txtObservacionEdicion').focus();
                    break;

                    case "MainContent_txtObservacionEdicion":
                        $('#MainContent_btnEdicion').select();
                    break;

                       case "MainContent_btnEdicion":
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

                        var color = $('#MainContent_ddlColor').val();
                         var marca = $('#MainContent_ddlMarca').val();
                         var modelo  = $('#MainContent_ddlModelo').val();
                         var tipo  = $('#MainContent_ddlTipo').val();


                        F_Update_Division_HTML('div_Color', result.split('~')[2]);
                        F_Update_Division_HTML('div_Marca', result.split('~')[3]);
                       // F_Update_Division_HTML('div_Modelo', result.split('~')[4]);
                        F_Update_Division_HTML('div_Tipo', result.split('~')[5]);
                        F_Update_Division_HTML('div_Estado', result.split('~')[6]);

                          F_Update_Division_HTML('div_ColorEdicion', result.split('~')[7]);
                        F_Update_Division_HTML('div_MarcaEdicion', result.split('~')[8]);
                       // F_Update_Division_HTML('div_ModeloEdicion', result.split('~')[9]);
                        F_Update_Division_HTML('div_TipoEdicion', result.split('~')[10]);
                        F_Update_Division_HTML('div_EstadoEdicion', result.split('~')[11]);
                         F_Update_Division_HTML('div_TipoPlan', result.split('~')[13]);
                        F_Update_Division_HTML('div_TipoPlanEdicion', result.split('~')[14]);


                          if(color) $('#MainContent_ddlColor').val(color);   else  $('#MainContent_ddlColor').val(-1);
                         if(marca) $('#MainContent_ddlMarca').val(marca);   else $('#MainContent_ddlMarca').val(-1);
                          F_ListarModelo();
                         if(modelo)  $('#MainContent_ddlModelo').val(modelo);   else $('#MainContent_ddlModelo').val(-1);

                         if(tipo) $('#MainContent_ddlTipo').val(tipo);    else $('#MainContent_ddlTipo').val(-1);
                         $('#MainContent_ddlTipoPlan').css('background', '#FFFFE0');
                         $('#MainContent_ddlTipoPlanEdicion').css('background', '#FFFFE0');

                         $('#MainContent_ddlColor').css('background', '#FFFFE0');
                         $('#MainContent_ddlMarca').css('background', '#FFFFE0');
                         $('#MainContent_ddlModelo').css('background', '#FFFFE0');
                         $('#MainContent_ddlTipo').css('background', '#FFFFE0');
                         $('#MainContent_ddlEstado').css('background', '#FFFFE0');

                         $('#MainContent_ddlColorEdicion').css('background', '#FFFFE0');
                         $('#MainContent_ddlMarcaEdicion').css('background', '#FFFFE0');
                         $('#MainContent_ddlModeloEdicion').css('background', '#FFFFE0');
                         $('#MainContent_ddlTipoEdicion').css('background', '#FFFFE0');
                         $('#MainContent_ddlEstadoEdicion').css('background', '#FFFFE0');

                          $('#MainContent_txtVencimientoSoat').val('');
                          $('#MainContent_txtRevision').val('');

                           $('#MainContent_txtVencimientoSoat').prop('readonly', false);
                            $('#MainContent_txtRevision').prop('readonly', false);

                          $('#MainContent_txtVencimientoSoatEdicion').prop('readonly', false);
                           $('#MainContent_txtRevisionEdicion').prop('readonly', false);

                        

                              
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

          if (($(Cuerpo + 'txtCliente').val()==''  | $('#MainContent_txtNroRuc').val()=="" )  &&  ($('#hfCodCtaCte').val()==0))
                    Cadena=Cadena + '<p></p>' + 'Cliente';
         
             if ($('#hfCodCtaCte').val()==0 && $('#hfCodDistrito').val()==0 && $('#MainContent_txtDistrito').val()== "")
                    Cadena=Cadena + '<p></p>' + 'Distrito';

             if ($('#hfCodCtaCte').val()==0 && $(Cuerpo + 'txtDireccion').val()=='')
                    Cadena=Cadena + '<p></p>' + 'Direccion';
        
             if ($(Cuerpo + 'txtPlaca').val() == '')
            Cadena = Cadena + '<p></p>' + 'Placa';

              if ($(Cuerpo + 'txtChasis').val() == '')
            Cadena = Cadena + '<p></p>' + 'Chasis';

               if ($(Cuerpo + 'txtAnio').val() == '')
            Cadena = Cadena + '<p></p>' + 'Año';

            if ( $("#MainContent_ddlColor option:selected").text() == ""){
            Cadena = Cadena + "<p></p>" + "Color";
            }
               if ($(Cuerpo + 'txtNroMotor').val() == '')
            Cadena = Cadena + '<p></p>' + 'Numero Motor';

              if ( $("#MainContent_ddlMarca option:selected").text() == ""){
            Cadena = Cadena + "<p></p>" + "Marca";
            }
              if ( $("#MainContent_ddlModelo option:selected").text() == ""){
            Cadena = Cadena + "<p></p>" + "Modelo";
            }
              if ( $("#MainContent_ddlTipo option:selected").text() == ""){
            Cadena = Cadena + "<p></p>" + "Tipo Vehiculo";
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
        var Cliente = $('#MainContent_txtCliente').val();

        var CodTipoCliente = 0;
        var NroDni = '';
        var NroRuc = '';
         NroDni = $('#MainContent_txtNroRuc').val();
         NroRuc = $('#MainContent_txtNroRuc').val();
           if (NroDni.length == 11)
        {
            NroDni = '';
            CodTipoCliente=2;
        }            

        if (NroRuc.length == 8)
        {
            NroRuc = '';
            CodTipoCliente=1;
        }
            

        var objParams = {
            Filtro_Placa: $(Contenedor + 'txtPlaca').val(),
            Filtro_Chasis: $(Contenedor + 'txtChasis').val(),
            Filtro_CodCliente: $('#hfCodCtaCte').val(),
            Filtro_Anio:  $(Contenedor + 'txtAnio').val(),
            Filtro_NroMotor:  $(Contenedor + 'txtNroMotor').val(),
            Filtro_VencimientoSoat:  $(Contenedor + 'txtVencimientoSoat').val(),
            Filtro_Revision:  $(Contenedor + 'txtRevision').val(),
            Filtro_NroFlota:  $(Contenedor + 'txtFlota').val(),
             Filtro_NroDni: NroDni, 
            Filtro_NroRuc: NroRuc, 
            Filtro_Observacion:  $(Contenedor + 'txtObservacion').val(),
            Filtro_CodColor:  $(Contenedor + 'ddlColor').val(),
            Filtro_CodModelo:  $(Contenedor + 'ddlModelo').val(),
            Filtro_CodMarca:  $(Contenedor + 'ddlMarca').val(),
            Filtro_CodTipo:  $(Contenedor + 'ddlTipo').val(),
            Filtro_CodEstado:  $(Contenedor + 'ddlEstado').val(),
            Filtro_RazonSocial: Cliente,
            Filtro_CodTipoCliente:  CodTipoCliente,
            Filtro_CodTipoPlan:  $(Contenedor + 'ddlTipoPlan').val(),

            Filtro_CodDepartamento: $('#hfCodDepartamento').val(),
            Filtro_CodProvincia: $('#hfCodProvincia').val(),
            Filtro_CodDistrito: $('#hfCodDistrito').val(),
            Filtro_Direccion: $(Contenedor + 'txtDireccion').val(),
             Filtro_CodDireccion: $('#hfCodDireccion').val()
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
   $(Contenedor + 'txtNroRuc').val('');
   $(Contenedor + 'txtNroDni').val('');
                   
                    return false;
}

function F_Nuevo() {

    var Contenedor = '#MainContent_';

    $(Contenedor + 'txtNroRuc').val('');
    $(Contenedor + 'txtNroDni').val('');
    $('#MainContent_txtNroRuc').val('');

    $('#MainContent_txtDistrito').val('');

    $('#MainContent_txtDireccion').val('');

    $('#MainContent_txtPlaca').val('');

    $('#MainContent_txtChasis').val('');

    $('#MainContent_txtAnio').val('');

    $('#MainContent_txtAnio').val('');

    $('#MainContent_ddlColor').val(-1);

    $('#MainContent_ddlMarca').val(-1);
    $('#MainContent_ddlModelo').val(-1);
    $('#MainContent_ddlTipo').val(-1);
    $('#MainContent_ddlEstado').val(1);

    $('#MainContent_txtCliente').val('');
    $('#MainContent_txtFlota').val('');
    
    $('#MainContent_ddlTipoPlan').val(-1);
    $('#MainContent_ddlTipoPlanEdicion').val(-1);

    $('#MainContent_txtVencimientoSoat').val('');
    $('#MainContent_txtRevision').val('');
    $('#MainContent_txtNroMotor').val('');
    $('#MainContent_txtObservacion').val('');
    F_LimpiarHiddenCliente();

    return false;
}

function F_LimpiarHiddenCliente(){
    $('#hfCodCtaCte').val(0);
    $('#hfNroRuc').val('');
    $('#hfCodCtaCte').val(0);
    $('#hfCliente').val('');
    $('#hfDireccion').val('');
    $('#hfCodDireccion').val(0);
    $('#hfCodDireccion').val(0);
    $('#hfCodDepartamento').val(0);
    $('#hfCodProvincia').val(0);
    $('#hfCodDistrito').val(0);
    $('#hfDistrito').val('');
    ConsultandoPadron = false;
    ConsultandoCliente = false;


}


function F_LimpiarHiddenClienteEdicion() {
    $('#hfCodCtaCteEdicion').val(0);
    $('#hfNroRucEdicion').val('');
    $('#hfCodCtaCteTransportistaEdicion').val(0);
    $('#hfClienteEdicion').val('');
    $('#hfDireccionEdicion').val('');
    $('#hfCodDireccionEdicion').val(0);
    $('#hfCodDireccionDefectoEdicion').val(0);
    $('#hfCodDepartamentoEdicion').val(0);
    $('#hfCodProvinciaEdicion').val(0);
    $('#hfCodDistritoEdicion').val(0);
    $('#hfDistritoEdicion').val('');
     ConsultandoPadronEdicion = false;
     ConsultandoClienteEdicion  = false;
}


function F_Buscar() {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var objParams = {
            Filtro_Descripcion: $("#MainContent_txtDescripcionConsulta").val(),
            Filtro_Placa: $("#MainContent_txtPlacaConsulta").val(),
            Filtro_CodEstado: $("#MainContent_ddlEstadoConsulta").val()
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
                $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsulta",'lblPlaca'));
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
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Eliminar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;

        var lblCodigo = '#' + imgID.replace('imgAnularDocumento', 'hfCodVehiculo');
        var lblProducto_grilla = '#' + imgID.replace('imgAnularDocumento', 'lblCliente');

        if ($(lblCodigo).val() == "" | $(lblCodigo).val() == '0') return false;
         

        if (confirm("ESTA SEGURO DE ELIMINAR EL VEHICULO " + $(lblProducto_grilla).text()) == false)
            return false;

        var objParams = {
            Filtro_CodVehiculo: $(lblCodigo).val(),
            
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
                $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsulta",'lblPlaca'));
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
    var imgID = Fila.id;
    var hfCodVehiculo_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCodVehiculo');
    if ($(hfCodVehiculo_grilla).val() == "" | $(hfCodVehiculo_grilla).val() == "0") return false;

    try {
    CodModeloEdicionGlobal = "-1";
        var imgID = Fila.id;
        var lblcodigo_grilla = '#' + imgID.replace('imgEditarRegistro', 'lblcodigo');
        var hfCliente_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCliente');
        var hfCodVehiculo_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCodVehiculo');
        var hfCodModelo_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCodModeloVehiculo');
        var hfCodTipoVehiculo_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCodTipoVehiculo');
        var hfCodColor_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCodColor');
        var hfCodMarca_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCodMarca');
        var hfCodEstado_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCodEstado');
        var hfCodCliente_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCodCliente');
        var hfPlaca_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfPlaca');  
        var hfChasis_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfChasis');  
        var hfNroMotor_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfNroMotor');  
        var hfAnio_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfAnio');  
        var hfFechaRevisionTecnica_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfFechaRevisionTecnica');  
        var hfFechaVctoSoat_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfFechaVctoSoat');  
        var hfRucCliente_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfRucCliente'); 
        var hfNroFlota_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfNroFlota'); 
        var hfObservacion_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfObservacion'); 

         var hfCodTipoPlan_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCodTipoPlan');

        var hfRazonSocial_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfRazonSocial');
        var hfDistrito_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfDistrito');
        var hfDireccion_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfDireccion');
        var hfCodDistrito_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCodDistrito');
        var hfCodDepartamento_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCodDepartamento');
        var hfCodProvincia_grilla = '#' + imgID.replace('imgEditarRegistro', 'hfCodProvincia');

        var Cuerpo = '#MainContent_';

        $(Cuerpo + 'txtNroRucEdicion').val($(hfRucCliente_grilla).val());
        $(Cuerpo + 'txtClienteEdicion').val($(hfCliente_grilla).val());
        $(Cuerpo + 'txtDistritoEdicion').val($(hfDistrito_grilla).val());
        $(Cuerpo + 'txtDireccionEdicion').val($(hfDireccion_grilla).val());
        $(Cuerpo + 'ddlDireccionEdicion').val(1);
        $('#hfCodVehiculo').val($(hfCodVehiculo_grilla).val());
        $('#hfCodDistritoEdicion').val($(hfCodDistrito_grilla).val());
        $('#hfCodDepartamentoEdicion').val($(hfCodDepartamento_grilla).val());
        $('#hfCodProvinciaEdicion').val($(hfCodProvincia_grilla).val());

        $('#hfCodCtaCteEdicion').val($(hfCodCliente_grilla).val());
        $(Cuerpo + 'txtPlacaEdicion').val($(hfPlaca_grilla).val());
        $(Cuerpo + 'txtChasisEdicion').val($(hfChasis_grilla).val());
        $(Cuerpo + 'txtAnioEdicion').val($(hfAnio_grilla).val());
        $(Cuerpo + 'txtClienteEdicion').val($(hfRazonSocial_grilla).val());

        $(Cuerpo + 'ddlColorEdicion').val($(hfCodColor_grilla).val());
        $(Cuerpo + 'ddlMarcaEdicion').val($(hfCodMarca_grilla).val());
        $(Cuerpo + 'ddlTipoEdicion').val($(hfCodTipoVehiculo_grilla).val());

        $(Cuerpo + 'ddlTipoPlanEdicion').val($(hfCodTipoPlan_grilla).val());

        if ($(hfCodTipoPlan_grilla).val() == 0 | $(hfCodTipoPlan_grilla).val() == "") {
          $(Cuerpo + 'ddlTipoPlanEdicion').val(0);
        }

        if ($(hfNroFlota_grilla).val() == '')
        $(Cuerpo + 'txtFlotaEdicion').val(0);
        else
         $(Cuerpo + 'txtFlotaEdicion').val($(hfNroFlota_grilla).val());

        $(Cuerpo + 'txtObservacionEdicion').val($(hfObservacion_grilla).val());

         if ($(hfFechaVctoSoat_grilla).val() == "")
          $(Cuerpo + 'txtVencimientoSoatEdicion').val('');
          else 
          $(Cuerpo + 'txtVencimientoSoatEdicion').val($(hfFechaVctoSoat_grilla).val());

          if ($(hfFechaRevisionTecnica_grilla).val() == "")
          $(Cuerpo + 'txtRevisionEdicion').val('');
          else 
           $(Cuerpo + 'txtRevisionEdicion').val($(hfFechaRevisionTecnica_grilla).val());
           $(Cuerpo + 'txtNroMotorEdicion').val($(hfNroMotor_grilla).val());
           $(Cuerpo + 'ddlEstadoEdicion').val($(hfCodEstado_grilla).val());

           var CodModelo =  $(hfCodModelo_grilla).val();
           F_ListarModeloEdicion();
           $('#MainContent_ddlModeloEdicion').val(CodModelo);
           CodModeloEdicionGlobal = CodModelo;

        //NroFlota
        $("#divEdicionRegistro").dialog({
            resizable: false,
            modal: true,
            title: "Edicion de VEHICULO",
            title_html: true,
            height: 250,
            width: 950,
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
        var Cliente = $('#MainContent_txtClienteEdicion').val();

        var CodTipoCliente = 0;
        var NroDni = '';
        var NroRuc = '';
         NroDni = $('#MainContent_txtNroRucEdicion').val();
         NroRuc = $('#MainContent_txtNroRucEdicion').val();
           if (NroDni.length == 11)
        {
            NroDni = '';
            CodTipoCliente=2;
        }            

        if (NroRuc.length == 8)
        {
            NroRuc = '';
            CodTipoCliente=1;
        }
            
            var CodEstado = $(Contenedor + 'ddlEstadoEdicion').val();
            $("#MainContent_ddlEstadoConsulta").val(CodEstado);
        var objParams = {
            Filtro_Placa: $(Contenedor + 'txtPlacaEdicion').val(),

            Filtro_CodEstado: CodEstado,
            Filtro_CodVehiculo: $('#hfCodVehiculo').val(),
            Filtro_Chasis: $(Contenedor + 'txtChasisEdicion').val(),
            Filtro_CodCliente: $('#hfCodCtaCteEdicion').val(),
            Filtro_Anio:  $(Contenedor + 'txtAnioEdicion').val(),
            Filtro_NroMotor:  $(Contenedor + 'txtNroMotorEdicion').val(),
            Filtro_VencimientoSoat:  $(Contenedor + 'txtVencimientoSoatEdicion').val(),
            Filtro_Revision:  $(Contenedor + 'txtRevisionEdicion').val(),
            Filtro_NroFlota:  $(Contenedor + 'txtFlotaEdicion').val(),
             Filtro_NroDni: NroDni, 
            Filtro_NroRuc: NroRuc, 
            Filtro_Observacion:  $(Contenedor + 'txtObservacionEdicion').val(),
            Filtro_CodColor:  $(Contenedor + 'ddlColorEdicion').val(),
            Filtro_CodModelo:  $(Contenedor + 'ddlModeloEdicion').val(),
            Filtro_CodMarca:  $(Contenedor + 'ddlMarcaEdicion').val(),
            Filtro_CodTipo:  $(Contenedor + 'ddlTipoEdicion').val(),
            Filtro_CodEstado:  $(Contenedor + 'ddlEstadoEdicion').val(),
            Filtro_RazonSocial: Cliente,
             Filtro_CodTipoCliente:  CodTipoCliente,

              Filtro_CodTipoPlan:  $(Contenedor + 'ddlTipoPlanEdicion').val(),

            Filtro_CodDepartamento: $('#hfCodDepartamentoEdicion').val(),
            Filtro_CodProvincia: $('#hfCodProvinciaEdicion').val(),
            Filtro_CodDistrito: $('#hfCodDistritoEdicion').val(),
            Filtro_Direccion: $(Contenedor + 'txtDireccionEdicion').val(),
             Filtro_CodDireccion: $('#hfCodDireccionEdicion').val()
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
                    $(Contenedor + 'txtRucEdicionEdicion').val('');
                    $(Contenedor + 'txtDniEdicionEdicion').val('');
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
                    $('#lblNumeroConsulta').text(F_Numerar_Grilla("grvConsulta",'lblPlaca'));
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
         
             if ($('#hfCodCtaCteEdicion').val()==0 && $('#hfCodDistritoEdicion').val()==0 && $('#MainContent_txtDistritoEdicion').val()== "")
                    Cadena=Cadena + '<p></p>' + 'Distrito';

             if ($('#hfCodCtaCteEdicion').val()==0 && $(Cuerpo + 'txtDireccionEdicion').val()=='')
                    Cadena=Cadena + '<p></p>' + 'Direccion';
        
             if ($(Cuerpo + 'txtPlacaEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Placa';

              if ($(Cuerpo + 'txtChasisEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Chasis';

               if ($(Cuerpo + 'txtAnioEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Año';

          
            if ( $("#MainContent_ddlColorEdicion option:selected").text() == ""){
            Cadena = Cadena + "<p></p>" + "Color";
            }
               if ($(Cuerpo + 'txtNroMotorEdicion').val() == '')
            Cadena = Cadena + '<p></p>' + 'Numero Motor';

              if ( $("#MainContent_ddlMarcaEdicion option:selected").text() == ""){
            Cadena = Cadena + "<p></p>" + "Marca";
            }
              if ( $("#MainContent_ddlModeloEdicion option:selected").text() == ""){
            Cadena = Cadena + "<p></p>" + "Modelo";
            }
              if ( $("#MainContent_ddlTipoEdicion option:selected").text() == ""){
            Cadena = Cadena + "<p></p>" + "Tipo Vehiculo";
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

function ValidarRuc(valor) {
    valor = trim(valor)
    if (esnumero(valor)) {
        if (valor.length < 11) {
            if (valor.length == 8)
                return true;
//            suma = 0
//            for (i = 0; i < valor.length - 1; i++) {

//                if (i == 0) suma += (digito * 2)
//                else suma += (digito * (valor.length - i))
//            }
//            resto = suma % 11;
//            if (resto == 1) resto = 11;
//            if (resto + (valor.charAt(valor.length - 1) - '0') == 11) {
//                return true
//            }
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
   var lblcodigo_grilla = '#' + imgID.replace('imgDireccion', 'lblcodigo');       
   F_DireccionesXCliente($(lblcodigo_grilla).text());
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
                    height: 500,
                    width: 890,
                    autoOpen: false
                });
                F_Update_Division_HTML('div_Direccion', result.split('~')[2]);
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

    
        var Cuerpo = '#MainContent_';

        $(Cuerpo + 'txtDistritoDireccionEdicion').val($(lblDistrito).text());
        $(Cuerpo + 'txtDireccionEdicionMultiple').val($(lblDireccion).text());
        $(Cuerpo + 'txtEmailEdicionMultiple1').val($(lblEmail1).val());
        $(Cuerpo + 'txtEmailEdicionMultiple2').val($(lblEmail2).val());
        $(Cuerpo + 'txtEmailEdicionMultiple3').val($(lblEmail3).val());
        $(Cuerpo + 'txtEmailEdicionMultiple4').val($(lblEmail4).val());
        $(Cuerpo + 'txtEmailEdicionMultiple5').val($(lblEmail5).val());
        $(Cuerpo + 'txtEmailEdicionMultiple6').val($(lblEmail6).val());

        $('#hfCodDireccion').val($(lblCodDireccion).text());
        $('#hfDistrito').val($(hfCodDistrito).val());
        $('#hfProvincia').val($(hfCodProvincia).val());
        $('#hfRegion').val($(hfCodDepartamento).val());

        $("#div_EdicionDireccion").dialog({
            resizable: false,
            modal: true,
            title: "Edicion de Direccion",
            title_html: true,
            height: 350,
            width: 800,
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

var hfCodEstado  = '';
var lblEstado = '';
function F_ActivarRegistroDireccion(Fila) {
    if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Editar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informacion
    try {
        var imgID = Fila.id;
        var lblCodDireccion = '#' + imgID.replace('imgActivarRegistro', 'lblCodDireccion');
        hfCodEstado = '#' + imgID.replace('imgActivarRegistro', 'hfCodEstado');
        lblEstado = '#' + imgID.replace('imgActivarRegistro', 'lblEstado');


        var Cuerpo = '#MainContent_';
        var Estado = '2'; if ($(hfCodEstado).val() == '2')
                                Estado = '1';
        var EstadoDsc = 'INACTIVO'; if ($(hfCodEstado).val() == '2')
                                EstadoDsc = 'ACTIVO';

        var objParams = {
                Filtro_CodDireccion: $(lblCodDireccion).text(),
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

                    F_DireccionesXCliente($('#hfCodCtaCte').val());

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
        var lblCodDireccion = '#' + imgID.replace('imgPrincipal', 'lblCodDireccion');
        hfCodEstado = '#' + imgID.replace('imgPrincipal', 'hfCodEstado');
        
        var Cuerpo = '#MainContent_';
        if ($(hfCodEstado).val() == '2')
        {
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
                    F_Update_Division_HTML('div_Direccion', result.split('~')[2]);
                    toastr.success('Se Grabo Correctamente.');
                    $('#hfRegion').val('0');
                    $('#hfProvincia').val('0');
                    $('#hfDistrito').val('0');
                    $('#div_EdicionDireccion').dialog('close');
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

        var lblCodDireccion = '#' + imgID.replace('imgAnularDocumento', 'lblCodDireccion');
        var lblDistrito = '#' + imgID.replace('imgAnularDocumento', 'lblDistrito');
        var lblDireccion = '#' + imgID.replace('imgAnularDocumento', 'lblDireccion');

        if (!confirm("ESTA SEGURO DE ELIMINAR LA DIRECCION " + $(lblDistrito).text() + " " + $(lblDireccion).text()))
            return false;

        var objParams = {
            Filtro_CodCtaCte: $('#hfCodCtaCte').val(),                              
            Filtro_CodDireccion: $(lblCodDireccion).text()
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
   
    $("#MainContent_txtFlota").ForceNumericOnly();

      $("#MainContent_txtFlotaEdicion").ForceNumericOnly();

    $('#MainContent_txtNroRuc').css('background', '#FFFFE0');

    $('#MainContent_txtDistrito').css('background', '#FFFFE0');

    $('#MainContent_txtDireccion').css('background', '#FFFFE0');

    $('#MainContent_txtPlaca').css('background', '#FFFFE0');

    $('#MainContent_txtChasis').css('background', '#FFFFE0');

    $('#MainContent_txtAnio').css('background', '#FFFFE0');

    $('#MainContent_txtAnio').css('background', '#FFFFE0');

    $('#MainContent_ddlColor').css('background', '#FFFFE0');

    $('#MainContent_ddlMarca').css('background', '#FFFFE0');
    $('#MainContent_ddlModelo').css('background', '#FFFFE0');
    $('#MainContent_ddlTipo').css('background', '#FFFFE0');
    $('#MainContent_ddlEstado').css('background', '#FFFFE0');

    $('#MainContent_txtCliente').css('background', '#FFFFE0');

    $('#MainContent_txtVencimientoSoat').css('background', '#FFFFE0');
    $('#MainContent_txtRevision').css('background', '#FFFFE0');
    $('#MainContent_txtFlota').css('background', '#FFFFE0');
    $('#MainContent_txtNroMotor').css('background', '#FFFFE0');
    $('#MainContent_txtObservacion').css('background', '#FFFFE0');


    $('#MainContent_txtDescripcionConsulta').css('background', '#FFFFE0');

    $('#MainContent_txtPlacaConsulta').css('background', '#FFFFE0');
   

    $('#MainContent_txtNroRucEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtDistritoEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtDireccionEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtPlacaEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtChasisEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtAnioEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtAnioEdicion').css('background', '#FFFFE0');

    $('#MainContent_ddlColorEdicion').css('background', '#FFFFE0');

    $('#MainContent_ddlMarcaEdicion').css('background', '#FFFFE0');
    $('#MainContent_ddlModeloEdicion').css('background', '#FFFFE0');
    $('#MainContent_ddlTipoEdicion').css('background', '#FFFFE0');
    $('#MainContent_ddlEstadoEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtClienteEdicion').css('background', '#FFFFE0');

    $('#MainContent_txtVencimientoSoatEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtRevisionEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtFlotaEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtNroMotorEdicion').css('background', '#FFFFE0');
    $('#MainContent_txtObservacionEdicion').css('background', '#FFFFE0');





    //   $('#MainContent_ddlContactoEstadoRegistro').css('background', '#FFFFE0');


    return false;
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

var ConsultandoCliente = false;
function F_BuscarDatosPorRucDni(RucDni) {

    if (ConsultandoCliente == true)
        return true;

    ConsultandoCliente = true;

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_BuscarClientesPorRucDni',
                data: "{'NroRuc':'" + RucDni +"'}",
                dataType: "json",
                async: false,
                success: function (dbObject) {
                ConsultandoCliente = false;
                var data = dbObject.d;
                if (data.length > 0)
                {
                    try {
                            $('#hfCodCtaCte').val(data[0].split(',')[0]); 
                            $('#MainContent_txtCliente').val(data[0].split(',')[1]);
                            $('#hfCliente').val($('#MainContent_txtCliente').val()); //razon social
                            $('#MainContent_txtNroRuc').val(data[0].split(',')[8]);
                            $('#hfNroRuc').val(data[0].split(',')[8]);
                            $('#MainContent_txtDireccion').val(data[0].split(',')[2]);
                            $('#MainContent_txtDestino').val(data[0].split(',')[2]);
                            $('#MainContent_txtDistrito').val(data[0].split(',')[4]);
                            $('#hfCodDireccion').val('0');
                            $('#hfCodDepartamento').val(data[0].split(',')[5]);
                            $('#hfCodProvincia').val(data[0].split(',')[6]);
                            $('#hfCodDistrito').val(data[0].split(',')[7]);
                            $('#hfDistrito').val(data[0].split(',')[4]);
                            
                            try { 
                            $('#txtSaldoCreditoFavor').text(data[0].split(',')[9]);
                            $('#hfSaldoCreditoFavor').val(data[0].split(',')[9].replace("S/", "").replace(" ", ""));} 
                            catch (e) { 
                            $('#txtSaldoCreditoFavor').text("0.00");
                            $('#hfSaldoCreditoFavor').val("0.00"); }
                            
                            
                            if ($('#MainContent_txtNroRuc').val() === '11111111')
                            {
                                $('#MainContent_txtCliente').prop('readonly', false);
                            }
                            F_BuscarDireccionPorDefecto(); 
                            return true;
                    }
                    catch (x) { toastr.warning(x); }
                }
                else
                {
                    var NroRuc = $('#MainContent_txtNroRuc').val();
//                    F_LimpiarCampos();
                    $('#MainContent_txtNroRuc').val(NroRuc);
                    if ($('#MainContent_txtNroRuc').val().length == 8)
                    {
                            $("#hfCodCtaCte").val('0');
                            if ($('#MainContent_txtNroRuc').val() != '11111111')
                            {
                                $('#MainContent_txtCliente').prop('readonly', false);
                                $('#MainContent_txtCliente').val('---NUEVO CLIENTE---');
                                }
                            $('#MainContent_txtCliente').select();
                    }
                    return true;
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





//cliente

//ENZO
function F_BuscarDireccionesCliente() {
if (!F_SesionRedireccionar(AppSession)) return false;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_TCDireccion_ListarXCodDistritoCliente_AutoComplete',
        data: "{'Direccion':'','CodDepartamento':'" + $('#hfCodDepartamento').val() + "','CodProvincia':'" + $('#hfCodProvincia').val() + "','CodDistrito':'" + $('#hfCodDistrito').val() + "','CodCtaCte':'" + $('#hfCodCtaCte').val() + "'}",
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            try {
                $('#MainContent_ddlDireccion').empty();
                $.each(data.rows, function (index, item) {
                    $('#MainContent_ddlDireccion').append($("<option></option>").val(item.CodDireccion).html(item.Direccion));
                });
                if (data.rows.length > 0) {
                    if ($('#hfCodDireccionDefecto').val() != '0') {
                        $('#MainContent_ddlDireccion').val($('#hfCodDireccionDefecto').val());
                    }
                    $('#MainContent_txtDireccion').val($("#MainContent_ddlDireccion option:selected").text());
                    if ($('#MainContent_txtDireccion').val() == "")
                    {
                        $('#MainContent_ddlDireccion').val($("#MainContent_ddlDireccion option:first").val());
                        $('#hfCodDireccion').val($("#MainContent_ddlDireccion option:first").val());          
                        $('#MainContent_txtDireccion').val($("#MainContent_ddlDireccion option:selected").text());
                    }
                    $('#hfCodDireccion').val($("#MainContent_ddlDireccion").val());
                }
            }
            catch (x) { toastr.warning('El Producto no tiene Imagenes'); }
            MostrarEspera(false);
        },
        complete: function () {
            if (($('#hfCodDireccion').val() == '' | $('#hfCodDireccion').val() == '0') && $('#hfCodCtaCte').val() != 0)
            {
                toastr.warning('NO HAY DIRECCION PARA EL DISTRITO ESPECIFICADO')
                $('#MainContent_txtDireccion').val('');
                $('#hfDireccion').val('');
                $('#hfCodDireccion').val('0');
            }
            // $('#MainContent_ddlDireccion').focus();
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
function F_ValidaRucDni() {
if (!F_SesionRedireccionar(AppSession)) return false;

    if ($('#MainContent_txtNroRuc').val().length > 0)
    {
        if ($('#MainContent_txtNroRuc').val().trim() === $('#hfNroRuc').val().trim() & 
            $('#MainContent_txtCliente').val().trim() === $('#hfCliente').val().trim() & 
            $('#MainContent_txtNroRuc').val().trim() != ""){
            $('#MainContent_txtPlaca').focus();
        return false;

        }
    F_LimpiarHiddenCliente();
       var Cliente2 = $('#MainContent_txtNroRuc').val();
       var rucVarios = Cliente2.split('-')[0].trim();

        if ( rucVarios == '11111111'){
    $('#MainContent_txtNroRuc').val('');
    $('#MainContent_txtCliente').val('');
    $('#MainContent_txtDistrito').val('');
    $('#MainContent_txtDireccion').val('');
     F_LimpiarHiddenCliente();
     
    toastr.warning('NRO. RUC/DNI INVALIDO'); 
    return false;
    }

    var Index= $('#MainContent_txtNroRuc').val().indexOf('-');
    var Cliente = $('#MainContent_txtNroRuc').val();

    if ($('#MainContent_txtNroRuc').val() != "1" & Index ==-1 ) {
       if (isNaN($('#MainContent_txtNroRuc').val()) | !ValidarRuc($('#MainContent_txtNroRuc').val()))
        {
            $('#MainContent_txtNroRuc').val('');
            $('#MainContent_txtNroRuc').focus();
            toastr.warning('ERROR EN RUC');
            return false;
        }
    } else {
    $('#MainContent_txtNroRuc').val(Cliente.split('-')[0].trim());
    }

        if ($('#hfCodCtaCte').val() != '0') 
            return true;

        $('#MainContent_txtCliente').val('');
        $('#hfCliente').val('');

        //DNI
        if ($('#MainContent_txtNroRuc').val().length == 8)
        {
            if ($('#MainContent_ddlTipoDoc').val() === '1') {
                $('#MainContent_txtNroRuc').val('');
                $('#MainContent_txtNroRuc').focus();
                return true;
            }

            var NroRuc = $('#MainContent_txtNroRuc').val();
            F_BuscarDatosPorRucDni($('#MainContent_txtNroRuc').val());
            return true;
        }
        else
        {
            //RUC
            if ($('#MainContent_txtNroRuc').val().length == 11 & $('#MainContent_txtNroRuc').val() != '55555555555')
            {
                
                F_BuscarPadronSunat();
                $('#MainContent_txtPlaca').focus();
                return true;
            }
            else
            {
                //CLIENTE VARIOS
                if ($('#MainContent_txtNroRuc').val() == '1' & $('#MainContent_ddlTipoDoc').val() != '1')
                {
                    $('#MainContent_txtNroRuc').val('11111111');
                    $('#hfNroRuc').val($('#MainContent_txtNroRuc').val());
                    F_BuscarDatosPorRucDni('11111111');
                    return true;
                }
                else
                {
//                    if ( Index ==-1 ) {} else {

                    if ($('#MainContent_txtNroRuc').val() === '55555555555' & $('#MainContent_ddlTipoDoc').val() == '16')
                    return true;

                    toastr.warning('NRO. RUC/DNI INVALIDO'); 
                    $('#MainContent_txtNroRuc').val('');
                    F_LimpiarCampos();
//                    }
                    return true;
                }
            }
        }
    }
    else
    {
        if ($('#MainContent_txtNroRuc').val() != $('#hfNroRuc').val())
        {
            F_LimpiarCampos();
            return true;
        }
    }
   return false;
}



var API = ""
var ubigeo="";
var ConsultandoPadron = false;
function F_BuscarPadronSunat() {

    if (ConsultandoPadron == true)
        return true;

    ConsultandoPadron = true;

        $('#td_loading').css('display', 'block');
        var NroRuc = $('#MainContent_txtNroRuc').val();
        F_LimpiarCampos();
        $('#MainContent_txtNroRuc').val(NroRuc);
         if (API == "") {
         $('#hfCodDepartamento').val("");
         $('#hfCodProvincia').val("");
         $('#hfCodDistrito').val("");
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_TCCuentaCorriente_PadronSunat',
                data: "{'NroRuc':'" + $('#MainContent_txtNroRuc').val() +"','CodTipoCtaCte':'1'}",
                dataType: "json",
                async: true,
                success: function (dbObject) {
                ConsultandoPadron = false;
                var data = dbObject.d;
                try {
                // condiciona joel:si en la base de datos no se encuentra ninguna condicion de ruc se manda para la apisunat
                    if (data.length > 0) {
                    $('#td_loading').css('display', 'none');
                    $('#hfCodCtaCte').val(data[0].split(',')[0]); 
                    $('#hfCliente').val(data[0].split(',')[1]); //razon social
                    $('#MainContent_txtNroRuc').val(data[0].split(',')[8]);
                    $('#hfNroRuc').val(data[0].split(',')[8]);
                    $('#MainContent_txtCliente').val(data[0].split(',')[1]);
                    $('#hfCliente').val(data[0].split(',')[1]);
                    $('#MainContent_txtDireccion').val(data[0].split(',')[2]);
                    $('#MainContent_txtDestino').val(data[0].split(',')[2]+ ' ' + data[0].split(',')[4]);
                    $('#MainContent_txtDistrito').val(data[0].split(',')[4]);
                    $('#hfCodDireccion').val('0');
                    $('#hfCodDepartamento').val(data[0].split(',')[5]);
                    $('#hfCodProvincia').val(data[0].split(',')[6]);
                    $('#hfCodDistrito').val(data[0].split(',')[7]);
                    $('#hfDistrito').val(data[0].split(',')[4]);
                    $('#txtSaldoCreditoFavor').text(data[0].split(',')[12]);
                    $('#hfSaldoCreditoFavor').val(data[0].split(',')[12].replace("S/", "").replace(" ", ""));
                    $('#hfCodDireccionDefecto').val(data[0].split(',')[14]);

                    if ($('#MainContent_txtCliente').val().trim().length > 0 & $('#hfCodDepartamento').val() === "0")
                    { toastr.warning('ESPECIFIQUE LA DIRECCION Y DISTRITO, PORQUE SUNAT NO ESTA PROVEYENDO ESTA INFORMACION'); }

                    F_BuscarDireccionesCliente();
                    //F_BuscarDireccionPorDefecto();
                    }else{
                     API = "Usuario No Encontrado";
                        console.log(API);
                        F_API_RUC_Buscar();
                        F_BuscarPadronSunat();
                       
                    }
                }
                catch (x) { 
                    //alertify.log(x);
                    toastr.warning('Por alguna razon el cliente no fue encontrado');
                    $('#td_loading').css('display', 'none');
                }
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
                $('#td_loading').css('display', 'none');
                    $('#MainContent_txtCliente').val(dbObject.razonSocial); //razon social
                    $('#MainContent_txtNombreComercial').val(dbObject.razonSocial); //razon social
                    ubigeo=dbObject.ubigeo;
                    if (ubigeo==null){
                     toastr.warning("La sunat no ofrece direccion ni distrito para los ruc 10,debe colocarlo usted mismo.");
                     }
                    var direccion = dbObject.direccion;
                    var distrito = dbObject.departamento + ' ' + dbObject.provincia + ' ' + dbObject.distrito;
                    $('#MainContent_txtDireccion').val(direccion.replace(distrito, ""));
                     $('#MainContent_txtDestino').val(direccion);
                    $('#MainContent_txtDireccionEnvio').val(direccion.replace(distrito, ""));
                    $('#MainContent_txtDistrito').val(distrito);
                    $('#hfDistrito').val(distrito);
//                    $('#hfUbigeo').val(dbObject.ubigeo);
                     $('#hfCliente').val(dbObject.razonSocial); //razon social
                     $('#hfNroRuc').val(dbObject.ruc);
                    F_BuscarDireccionNuevo();
                }
                catch (x) { }
                MostrarEspera(false);
            },
            error: function (response) {
                
                if(response.responseText!=''){
                toastr.warning(response.responseText);
                }else{
                toastr.warning('Verificar conexión');
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

function F_BuscarDatosPorRucDni(RucDni) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_BuscarClientesPorRucDni',
                data: "{'NroRuc':'" + RucDni +"'}",
                dataType: "json",
                async: false,
                success: function (dbObject) {
                var data = dbObject.d;
                if (data.length > 0)
                {
                    try {
                            $('#hfCodCtaCte').val(data[0].split(',')[0]); 
                            $('#MainContent_txtCliente').val(data[0].split(',')[1]);
                            $('#hfCliente').val($('#MainContent_txtCliente').val()); //razon social
                            $('#MainContent_txtNroRuc').val(data[0].split(',')[8]);
                            $('#hfNroRuc').val(data[0].split(',')[8]);
                            $('#MainContent_txtDireccion').val(data[0].split(',')[2]);
                            $('#MainContent_txtDestino').val(data[0].split(',')[2]+' ' + data[0].split(',')[4]);
                            $('#MainContent_txtDistrito').val(data[0].split(',')[4]);
                            $('#hfCodDireccion').val('0');
                            $('#hfCodDepartamento').val(data[0].split(',')[5]);
                            $('#hfCodProvincia').val(data[0].split(',')[6]);
                            $('#hfCodDistrito').val(data[0].split(',')[7]);
                            $('#hfDistrito').val(data[0].split(',')[4]);
                            try { 
                            $('#txtSaldoCreditoFavor').text(data[0].split(',')[9]);
                            $('#hfSaldoCreditoFavor').val(data[0].split(',')[9].replace("S/", "").replace(" ", ""));} 
                            catch (e) { 
                            $('#txtSaldoCreditoFavor').text("0.00");
                            $('#hfSaldoCreditoFavor').val("0.00"); }
                            
                            
                            if ($('#MainContent_txtNroRuc').val() === '11111111')
                            {
                                $('#MainContent_txtCliente').prop('readonly', false);
                            }
                            F_BuscarDireccionesCliente(); 
                            return true;
                    }
                    catch (x) { toastr.warning(x); }
                }
                else
                {
                    var NroRuc = $('#MainContent_txtNroRuc').val();
                    F_LimpiarCampos();
                    $('#MainContent_txtNroRuc').val(NroRuc);
                    if ($('#MainContent_txtNroRuc').val().length == 8)
                    {
                            $("#hfCodCtaCte").val('0');
                            if ($('#MainContent_txtNroRuc').val() != '11111111')
                            {
                                $('#MainContent_txtCliente').prop('readonly', false);
                                $('#MainContent_txtCliente').val('---NUEVO CLIENTE---');
                                }
                            $('#MainContent_txtCliente').select();
                    }
                    return true;
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
        var Codigo = $('#' + Fila.replace('pnlOrdersAuditoria', 'hfCodVehiculo')).val();
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
            $('#hfCodDepartamento').val(data[0].split(',')[0]);
            $('#hfCodProvincia').val(data[0].split(',')[1]);
            $('#hfCodDistrito').val(data[0].split(',')[2]);
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

//edicion cliente



    
function F_BuscarDireccionesClienteEdicion() {
if (!F_SesionRedireccionar(AppSession)) return false;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_TCDireccion_ListarXCodDistritoCliente_AutoComplete',
        data: "{'Direccion':'','CodDepartamento':'" + $('#hfCodDepartamentoEdicion').val() + "','CodProvincia':'" + $('#hfCodProvinciaEdicion').val() + "','CodDistrito':'" + $('#hfCodDistritoEdicion').val() + "','CodCtaCte':'" + $('#hfCodCtaCteEdicion').val() + "'}",
        dataType: "json",
        async: false,
        success: function (dbObject) {
            var data = dbObject.d;
            try {
                $('#MainContent_ddlDireccionEdicion').empty();
                $.each(data.rows, function (index, item) {
                    $('#MainContent_ddlDireccionEdicion').append($("<option></option>").val(item.CodDireccion).html(item.Direccion));
                });
                if (data.rows.length > 0) {
                    if ($('#hfCodDireccionDefectoEdicion').val() != '0') {
                        $('#MainContent_ddlDireccionEdicion').val($('#hfCodDireccionDefectoEdicion').val());
                    }
                    $('#MainContent_txtDireccionEdicion').val($("#MainContent_ddlDireccionEdicion option:selected").text());
                    if ($('#MainContent_txtDireccionEdicion').val() == "")
                    {
                        $('#MainContent_ddlDireccionEdicion').val($("#MainContent_ddlDireccionEdicion option:first").val());
                        $('#hfCodDireccionEdicion').val($("#MainContent_ddlDireccionEdicion option:first").val());          
                        $('#MainContent_txtDireccionEdicion').val($("#MainContent_ddlDireccionEdicion option:selected").text());
                    }
                    $('#hfCodDireccionEdicion').val($("#MainContent_ddlDireccionEdicion").val());
                 
                }
            }
            catch (x) { toastr.warning('El Producto no tiene Imagenes'); }
            MostrarEspera(false);
        },
        complete: function () {
            if (($('#hfCodDireccionEdicion').val() == '' | $('#hfCodDireccionEdicion').val() == '0') && $('#hfCodCtaCteEdicion').val() != 0)
            {
                toastr.warning('NO HAY DIRECCION PARA EL DISTRITO ESPECIFICADO')
                $('#MainContent_txtDireccionEdicion').val('');
                $('#hfDireccionEdicion').val('');
                $('#hfCodDireccionEdicion').val('0');
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


function F_ListarModelo() {
if (!F_SesionRedireccionar(AppSession)) return false;
    var arg;

    try {

        var objParams = {

            Filtro_CodMarca:  $('#MainContent_ddlMarca').val()
        };

        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ListarModelo_NET
            (
                arg,
                function (result) {

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
                    MostrarEspera(false);
                    if (str_resultado_operacion == "1") 
                    {
                     F_Update_Division_HTML('div_Modelo', result.split('~')[2]);
                            $('#MainContent_ddlModelo').css('background', '#FFFFE0');       
                            $('#MainContent_ddlModelo').val(-1);
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

var CodModeloEdicionGlobal = "-1";
function F_ListarModeloEdicion() {
if (!F_SesionRedireccionar(AppSession)) return false;
    var arg;

    try {

        var objParams = {

            Filtro_CodMarca:  $('#MainContent_ddlMarcaEdicion').val()
        };

        arg = Sys.Serialization.JavaScriptSerializer.serialize(objParams);
        MostrarEspera(true);
        F_ListarModelo_NET
            (
                arg,
                function (result) {

                    var str_resultado_operacion = "";
                    var str_mensaje_operacion = "";

                    str_resultado_operacion = result.split('~')[0];
                    str_mensaje_operacion = result.split('~')[1];
                    MostrarEspera(false);
                    if (str_resultado_operacion == "1") 
                    {
                     F_Update_Division_HTML('div_ModeloEdicion', result.split('~')[3]);
                             $('#MainContent_ddlModeloEdicion').val(CodModeloEdicionGlobal);
                            $('#MainContent_ddlModeloEdicion').css('background', '#FFFFE0');
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


function F_ValidaRucDniEdicion() {
if (!F_SesionRedireccionar(AppSession)) return false;

    if ($('#MainContent_txtNroRucEdicion').val().length > 0)
    {
        if ($('#MainContent_txtNroRucEdicion').val().trim() === $('#hfNroRucEdicion').val().trim() & 
            $('#MainContent_txtClienteEdicion').val().trim() === $('#hfClienteEdicion').val().trim() & 
            $('#MainContent_txtNroRucEdicion').val().trim() != "")
        return false;
    F_LimpiarHiddenClienteEdicion();

   var Cliente2 = $('#MainContent_txtNroRucEdicion').val();
       var rucVarios = Cliente2.split('-')[0].trim();

        if ( rucVarios == '11111111'){
    $('#MainContent_txtNroRucEdicion').val('');
    $('#MainContent_txtClienteEdicion').val('');
    $('#MainContent_txtDistritoEdicion').val('');
    $('#MainContent_txtDireccionEdicion').val('');
     F_LimpiarHiddenClienteEdicion();
     
    toastr.warning('NRO. RUC/DNI INVALIDO'); 
    return false;
    }

    var Index= $('#MainContent_txtNroRucEdicion').val().indexOf('-');
    var Cliente = $('#MainContent_txtNroRucEdicion').val();

    if ($('#MainContent_txtNroRucEdicion').val() != "1" & Index ==-1 ) {
       if (isNaN($('#MainContent_txtNroRucEdicion').val()) | !ValidarRuc($('#MainContent_txtNroRucEdicion').val()))
        {
            $('#MainContent_txtNroRucEdicion').val('');
             $('#MainContent_txtNroRucEdicion').focus();
            toastr.warning('ERROR EN RUC');
            return false;
        }
    } else {
    $('#MainContent_txtNroRucEdicion').val(Cliente.split('-')[0].trim());
    }

        if ($('#hfCodCtaCteEdicion').val() != '0') 
            return true;

        $('#MainContent_txtClienteEdicion').val('');
        $('#hfClienteEdicion').val('');

        //DNI
        if ($('#MainContent_txtNroRucEdicion').val().length == 8)
        {
            var NroRuc = $('#MainContent_txtNroRucEdicion').val();
            F_BuscarDatosPorRucDniEdicion($('#MainContent_txtNroRucEdicion').val());
            return true;
        }
        else
        {
            //RUC
            if ($('#MainContent_txtNroRucEdicion').val().length == 11 & $('#MainContent_txtNroRucEdicion').val() != '55555555555')
            {
                $('#MainContent_txtNroRucEdicion').focus();
                F_BuscarPadronSunatEdicion();
                return true;
            }
            else
            {
                //CLIENTE VARIOS
                if ($('#MainContent_txtNroRucEdicion').val() == '1')
                {
                  toastr.warning('NRO. RUC/DNI INVALIDO'); 
                    return true;
                }
                else
                {
//                    if ( Index ==-1 ) {} else {

                    if ($('#MainContent_txtNroRucEdicion').val() === '55555555555')
                    toastr.warning('NRO. RUC/DNI INVALIDO'); 
                    return true;
                }
            }
        }
    }
    else
    {
        if ($('#MainContent_txtNroRucEdicion').val() != $('#hfNroRucEdicion').val())
        {
            F_LimpiarCampos();
            return true;
        }
    }
   return false;
}



var APIEdicion = ""
var ubigeoEdicion="";
var ConsultandoPadronEdicion = false;
function F_BuscarPadronSunatEdicion() {

    if (ConsultandoPadronEdicion == true)
        return true;

    ConsultandoPadronEdicion = true;

        $('#td_loadingEdicion').css('display', 'block');
        var NroRuc = $('#MainContent_txtNroRucEdicion').val();
        F_LimpiarCamposEdicion();
        $('#MainContent_txtNroRucEdicion').val(NroRuc);
         if (APIEdicion == "") {
         $('#hfCodDepartamentoEdicion').val("");
         $('#hfCodProvinciaEdicion').val("");
         $('#hfCodDistritoEdicion').val("");
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_TCCuentaCorriente_PadronSunat',
                data: "{'NroRuc':'" + $('#MainContent_txtNroRucEdicion').val() +"','CodTipoCtaCte':'1'}",
                dataType: "json",
                async: true,
                success: function (dbObject) {
                ConsultandoPadronEdicion = false;
                var data = dbObject.d;
                try {
                // condiciona joel:si en la base de datos no se encuentra ninguna condicion de ruc se manda para la apisunat
                    if (data.length > 0) {
                    $('#td_loadingEdicion').css('display', 'none');
                    $('#hfCodCtaCteEdicion').val(data[0].split(',')[0]); 
                    $('#hfClienteEdicion').val(data[0].split(',')[1]); //razon social
                    $('#MainContent_txtNroRucEdicion').val(data[0].split(',')[8]);
                    $('#hfNroRucEdicion').val(data[0].split(',')[8]);
                    $('#MainContent_txtClienteEdicion').val(data[0].split(',')[1]);
                    $('#hfClienteEdicion').val(data[0].split(',')[1]);
                    $('#MainContent_txtDireccionEdicion').val(data[0].split(',')[2]);
                    $('#MainContent_txtDestinoEdicion').val(data[0].split(',')[2]+ ' ' + data[0].split(',')[4]);
                    $('#MainContent_txtDistritoEdicion').val(data[0].split(',')[4]);
                    $('#hfCodDireccionEdicion').val('0');
                    $('#hfCodDepartamentoEdicion').val(data[0].split(',')[5]);
                    $('#hfCodProvinciaEdicion').val(data[0].split(',')[6]);
                    $('#hfCodDistritoEdicion').val(data[0].split(',')[7]);
                    $('#hfDistritoEdicion').val(data[0].split(',')[4]);
                    $('#txtSaldoCreditoFavorEdicion').text(data[0].split(',')[12]);
                    $('#hfCodDireccionDefectoEdicion').val(data[0].split(',')[14]);

                    if ($('#MainContent_txtClienteEdicion').val().trim().length > 0 & $('#hfCodDepartamentoEdicion').val() === "0")
                    { toastr.warning('ESPECIFIQUE LA DIRECCION Y DISTRITO, PORQUE SUNAT NO ESTA PROVEYENDO ESTA INFORMACION'); }

                    F_BuscarDireccionesClienteEdicion();
                    //F_BuscarDireccionPorDefecto();
                    }else{
                     APIEdicion = "Usuario No Encontrado";
                        console.log(API);
                        F_API_RUC_Buscar();
                        F_BuscarPadronSunatEdicion();
                       
                    }
                }
                catch (x) { 
                    //alertify.log(x);
                    toastr.warning('Por alguna razon el cliente no fue encontrado');
                    $('#td_loadingEdicion').css('display', 'none');
                }
            },
                error: function (response) {
                    toastr.warning(response.responseText);
                },
                failure: function (response) {
                    toastr.warning(response.responseText);
                }
            });
 }; 
  if (APIEdicion == "Usuario No Encontrado") {
        //api sunat 
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url:  $('#hfurlapisunat').val() + $('#MainContent_txtNroRucEdicion').val() + $('#hftokenapisunat').val(),
            dataType: "json",
            async: true,
            success: function (dbObject) {
                MostrarEspera(true);
                var data = dbObject.d;                                
                try {
                API = "";
                $('#td_loadingEdicion').css('display', 'none');
                    $('#MainContent_txtClienteEdicion').val(dbObject.razonSocial); //razon social
                    $('#MainContent_txtNombreEdicion').val(dbObject.razonSocial); //razon social
                    ubigeo=dbObject.ubigeo;
                    if (ubigeo==null){
                     toastr.warning("La sunat no ofrece direccion ni distrito para los ruc 10,debe colocarlo usted mismo.");
                     }
                    var direccion = dbObject.direccion;
                    var distrito = dbObject.departamento + ' ' + dbObject.provincia + ' ' + dbObject.distrito;
                    $('#MainContent_txtDireccionEdicion').val(direccion.replace(distrito, ""));
                     $('#MainContent_txtDestinoEdicion').val(direccion);
                    $('#MainContent_txtDireccionEnvioEdicion').val(direccion.replace(distrito, ""));
                    $('#MainContent_txtDistritoEdicion').val(distrito);
                    $('#hfDistritoEdicion').val(distrito);
//                    $('#hfUbigeo').val(dbObject.ubigeo);
                     $('#hfClienteEdicion').val(dbObject.razonSocial); //razon social
                     $('#hfNroRucEdicion').val(dbObject.ruc);
                    F_BuscarDireccionNuevoEdicion();
                }
                catch (x) { }
                MostrarEspera(false);
            },
            error: function (response) {
                
                if(response.responseText!=''){
                toastr.warning(response.responseText);
                }else{
                toastr.warning('Verificar conexión');
                $('#td_loadingEdicion').css('display', 'none');
                }
            },
            failure: function (response) {
               toastr.warning(response.responseText);
            }
        });
    }


return true;
}



function  F_BuscarDireccionNuevoEdicion() {
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
            $('#hfCodDepartamentoEdicion').val(data[0].split(',')[0]);
            $('#hfCodProvinciaEdicion').val(data[0].split(',')[1]);
            $('#hfCodDistritoEdicion').val(data[0].split(',')[2]);
            return true;

        },
        complete: function () {
            if (($('#hfRegionEdicion').val() == '' | $('#hfProvinciaEdicion').val() == '') && $('#hfDistritoEdicion').val() == '') {
                toastr.warning('NO HAY DIRECCION PARA EL DISTRITO ESPECIFICADO')
                $('#MainContent_txtDireccionEdicion').val('');
                $('#hfDireccionEdicion').val('');
                $('#hfCodDireccionEdicion').val('0');
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



var ConsultandoClienteEdicion = false;
function F_BuscarDatosPorRucDniEdicion(RucDni) {

    if (ConsultandoClienteEdicion == true)
        return true;

    ConsultandoClienteEdicion = true;

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../Servicios/Servicios.asmx/F_BuscarClientesPorRucDni',
                data: "{'NroRuc':'" + RucDni +"'}",
                dataType: "json",
                async: false,
                success: function (dbObject) {
                ConsultandoCliente = false;
                var data = dbObject.d;
                if (data.length > 0)
                {
                    try {
                            $('#hfCodCtaCteEdicion').val(data[0].split(',')[0]); 
                            $('#MainContent_txtClienteEdicion').val(data[0].split(',')[1]);
                            $('#hfClienteEdicion').val($('#MainContent_txtClienteEdicion').val()); //razon social
                            $('#MainContent_txtNroRucEdicion').val(data[0].split(',')[8]);
                            $('#hfNroRucEdicion').val(data[0].split(',')[8]);
                            $('#MainContent_txtDireccionEdicion').val(data[0].split(',')[2]);
                            $('#MainContent_txtDestinoEdicion').val(data[0].split(',')[2]);
                            $('#MainContent_txtDistritoEdicion').val(data[0].split(',')[4]);
                            $('#hfCodDireccionEdicion').val('0');
                            $('#hfCodDepartamentoEdicion').val(data[0].split(',')[5]);
                            $('#hfCodProvinciaEdicion').val(data[0].split(',')[6]);
                            $('#hfCodDistritoEdicion').val(data[0].split(',')[7]);
                            $('#hfDistritoEdicion').val(data[0].split(',')[4]);
                            
                           
                            if ($('#MainContent_txtNroRucEdicion').val() === '11111111')
                            {
                                $('#MainContent_txtClienteEdicion').prop('readonly', false);
                            }
                            F_BuscarDireccionPorDefectoEdicion(); 
                            return true;
                    }
                    catch (x) { toastr.warning(x); }
                }
                else
                {
                    var NroRuc = $('#MainContent_txtNroRucEdicion').val();
//                    F_LimpiarCampos();
                    $('#MainContent_txtNroRucEdicion').val(NroRuc);
                    if ($('#MainContent_txtNroRucEdicion').val().length == 8)
                    {
                            $("#hfCodCtaCteEdicionEdicion").val('0');
                            if ($('#MainContent_txtNroRucEdicion').val() != '11111111')
                            {
                                $('#MainContent_txtClienteEdicion').prop('readonly', false);
                                $('#MainContent_txtClienteEdicion').val('---NUEVO CLIENTE---');
                                }
                            $('#MainContent_txtClienteEdicion').select();
                    }
                    return true;
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



function F_BuscarDireccionPorDefectoEdicion() {
if (!F_SesionRedireccionar(AppSession)) return false;
//    $('#hfCodDireccion').val('0');
//    $('#MainContent_txtDireccion').val('');
//    $('#hfDireccion').val('');
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Servicios/Servicios.asmx/F_TCDireccion_ListarXCodDistrito_AutoComplete',
        data: "{'Direccion':'','CodDepartamento':'" + $('#hfCodDepartamentoEdicion').val() + "','CodProvincia':'" + $('#hfCodProvinciaEdicion').val() + "','CodDistrito':'" + $('#hfCodDistritoEdicion').val() + "','CodCtaCte':'" + $('#hfCodCtaCteEdicion').val() + "'}",
        dataType: "json",
        async: false,
        success: function (data) {
                if (data.d.length >= 1)
                {
                    $('#hfCodDireccionEdicion').val(data.d[0].split(',')[0]);
                    $('#MainContent_txtDireccionEdicion').val(data.d[0].split(',')[1]);
                    $('#hfDireccionEdicion').val(data.d[0].split(',')[1]);
                    $('#MainContent_txtCorreoEdicion').val(data.d[0].split(',')[5]);
                    if ($('#hfCodCtaCteEdicion').val() == 29)
                    {
                        $('#hfCodDistritoEdicion').val(data.d[0].split(',')[2]);
                        $('#hfCodProvinciaEdicion').val(data.d[0].split(',')[3]);
                        $('#hfCodDepartamentoEdicion').val(data.d[0].split(',')[4]);
                    }
                    return true;
                }
        },
        complete: function () {
            if (($('#hfCodDireccionEdicion').val() == '' | $('#hfCodDireccionEdicion').val() == '0') && $('#hfCodCtaCteEdicion').val() != 0)
            {
                toastr.warning('NO HAY DIRECCION PARA EL DISTRITO ESPECIFICADO')
                $('#MainContent_txtDireccionEdicion').val('');
                $('#hfDireccionEdicion').val('');
                $('#hfCodDireccionEdicion').val('0');
                $('#MainContent_txtCorreoEdicion').val('');
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