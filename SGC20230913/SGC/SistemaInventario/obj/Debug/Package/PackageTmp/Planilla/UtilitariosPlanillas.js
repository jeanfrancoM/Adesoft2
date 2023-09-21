
 
//PLANILLAS PROYECTOS
//----------------------------------------------------------------------------
function utF_Planilla_Proyecto_Listar(Combo, CodEstadoProceso, CodEstado, Descripcion) {
    var Espera = false;
    var Resultado = false;

    var dtx = new Date();
    var timex = dtx.getHours() + dtx.getMinutes() + dtx.getSeconds();

    $.ajax({
        type: "POST",
        url: '../Servicios/DatosPlanilla_Proyecto.asmx/F_Planilla_Proyecto_Listar?time=' + timex,
        data: "{'CodEstadoProceso':'" + CodEstadoProceso + "', 'CodEstado': '" + CodEstado + "', 'Descripcion':'" + Descripcion + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (obj, status) {

            $.each(obj.d, function (index, item) {
                $(Combo).append($("<option></option>").val(item.CodProyecto).html(item.Descripcion));
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

//FIN PLANILLAS PROYECTOS
//----------------------------------------------------------------------------





//PLANILLAS REGIMEN LABORAL
//----------------------------------------------------------------------------
function utF_Planilla_RegimenLaboral_Listar(Combo, Descripcion) {
    var Espera = false;
    var Resultado = false;

    var dtx = new Date();
    var timex = dtx.getHours() + dtx.getMinutes() + dtx.getSeconds();

    $.ajax({
        type: "POST",
        url: '../Servicios/DatosPlanilla_RegimenLaboral.asmx/F_Planilla_RegimenLaboral_Listar?time=' + timex,
        data: "{'Descripcion':'" + Descripcion + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (obj, status) {

            $.each(obj.d, function (index, item) {
                $(Combo).append($("<option></option>").val(item.CodRegimenLaboral).html(item.Descripcion));
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

//FIN PLANILLAS REGIMEN LABORAL
//----------------------------------------------------------------------------





//PLANILLAS CATEGORIA
//----------------------------------------------------------------------------
function utF_Planilla_Categoria_Listar(Combo, Descripcion) {
    var Espera = false;
    var Resultado = false;

    var dtx = new Date();
    var timex = dtx.getHours() + dtx.getMinutes() + dtx.getSeconds();

    $.ajax({
        type: "POST",
        url: '../Servicios/DatosPlanilla_Categoria.asmx/F_Planilla_Categoria_Listar?time=' + timex,
        data: "{'Descripcion':'" + Descripcion + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (obj, status) {

            $.each(obj.d, function (index, item) {
                $(Combo).append($("<option></option>").val(item.CodCategoria).html(item.Descripcion));
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

//FIN CATEGORIA
//----------------------------------------------------------------------------







//PLANILLAS SEMANA
//----------------------------------------------------------------------------
function utF_Planilla_Semana_Obtener(Fecha) {
    var Espera = false;
    var Resultado = false;
    var Datos;

    var dtx = new Date();
    var timex = dtx.getHours() + dtx.getMinutes() + dtx.getSeconds();

    $.ajax({
        type: "POST",
        url: '../Servicios/DatosPlanilla_Semana.asmx/F_Planilla_Semana_Obtener?time=' + timex,
        data: "{'Fecha':'" + Fecha + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (obj, status) {

            Datos = obj.d;

            redireccionar = false;
            Espera = true;
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            Espera = true;
            Resultado = false;
        }
    });

    do { } while (Espera == false); //Esperar a que se ejecuta el Ajax

    return Datos;
}

function utF_Planilla_Semana_Obtener_Por_Semana(AñoSemana) {
    var Espera = false;
    var Resultado = false;
    var Datos;

    var dtx = new Date();
    var timex = dtx.getHours() + dtx.getMinutes() + dtx.getSeconds();

    $.ajax({
        type: "POST",
        url: '../Servicios/DatosPlanilla_Semana.asmx/F_Planilla_Semana_Obtener_Por_Semana?time=' + timex,
        data: "{'AñoSemana':'" + AñoSemana + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (obj, status) {

            Datos = obj.d;

            redireccionar = false;
            Espera = true;
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            Espera = true;
            Resultado = false;
        }
    });

    do { } while (Espera == false); //Esperar a que se ejecuta el Ajax

    return Datos;
}

//FIN PLANILLAS SEMANA
//---------






//PLANILLAS Periodo
//----------------------------------------------------------------------------
function utF_Planilla_Periodo_Obtener(Fecha) {
    var Espera = false;
    var Resultado = false;
    var Datos;

    var dtx = new Date();
    var timex = dtx.getHours() + dtx.getMinutes() + dtx.getSeconds();

    $.ajax({
        type: "POST",
        url: '../Servicios/DatosPlanilla_Periodo.asmx/F_Planilla_Periodo_Obtener?time=' + timex,
        data: "{'Fecha':'" + Fecha + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (obj, status) {

            Datos = obj.d;

            redireccionar = false;
            Espera = true;
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            Espera = true;
            Resultado = false;
        }
    });

    do { } while (Espera == false); //Esperar a que se ejecuta el Ajax

    return Datos;
}


function utF_Planilla_Periodo_Obtener_Por_Periodo(AñoPeriodo) {
    var Espera = false;
    var Resultado = false;
    var Datos;

    var dtx = new Date();
    var timex = dtx.getHours() + dtx.getMinutes() + dtx.getSeconds();

    $.ajax({
        type: "POST",
        url: '../Servicios/DatosPlanilla_Periodo.asmx/F_Planilla_Periodo_Obtener_Por_Periodo?time=' + timex,
        data: "{'AñoPeriodo':'" + AñoPeriodo + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (obj, status) {

            Datos = obj.d;

            redireccionar = false;
            Espera = true;
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            Espera = true;
            Resultado = false;
        }
    });

    do { } while (Espera == false); //Esperar a que se ejecuta el Ajax

    return Datos;
}





//PLANILLAS REGIMEN LABORAL
//----------------------------------------------------------------------------
function utF_Planilla_AFP_Listar(Combo, Descripcion) {
    var Espera = false;
    var Resultado = false;

    var dtx = new Date();
    var timex = dtx.getHours() + dtx.getMinutes() + dtx.getSeconds();

    $.ajax({
        type: "POST",
        url: '../Servicios/DatosPlanilla_AFP.asmx/F_Planilla_AFP_Listar?time=' + timex,
        data: "{'Descripcion':'" + Descripcion + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (obj, status) {

            $.each(obj.d, function (index, item) {
                $(Combo).append($("<option></option>").val(item.CodAFP).html(item.Descripcion));
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

//FIN PLANILLAS REGIMEN LABORAL
//----------------------------------------------------------------------------
