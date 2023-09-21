var AppSession = "../Maestros/Perfiles.aspx";

var CodigoMenu = 1000;
var CodigoInterno = 19;

var dbFirestore;
var dbStorage;
$(document).ready(function () {

    if (!F_SesionRedireccionar(AppSession)) return false;

    document.onkeydown = function (evt) {
        return (evt ? evt.which : event.keyCode) != 13;
    }

    // Your web app's Firebase configuration
    // For Firebase JS SDK v7.20.0 and later, measurementId is optional
    var firebaseConfig = {
        apiKey: "AIzaSyDhBjR1UIXJo6Suif1aWB6XfRIMD4RHKqg",
        authDomain: "appmod1-93c45.firebaseapp.com",
        databaseURL: "https://appmod1-93c45.firebaseio.com",
        projectId: "appmod1-93c45",
        storageBucket: "appmod1-93c45.appspot.com",
        messagingSenderId: "782748233038",
        appId: "1:782748233038:web:2bac3409d32977bbd8021f",
        measurementId: "G-C92GK8L9MB"
    };
    // Initialize Firebase
    firebase.initializeApp(firebaseConfig);

    dbFirestore = firebase.firestore();


    F_FiltrarPedidosPendientes();
});


var arrPedidos = new Array();
var arrPedidosID = new Array();
var indexPedido = 0;
function F_FiltrarPedidosPendientes() {
if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Consultar') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
dbFirestore.collection("Pedidos").doc("20547868839").collection("Pedidos").where("Estado", "==", "ENVIADO")
    .onSnapshot((querySnapshot) => {

        arrPedidos = new Array();
        arrPedidosID = new Array();
        indexPedido = 0;
        $('#tab_Permisos').empty();

        

        var html = '<thead><tr> ' +
                            '<th style="width:20px"><input id="MainContent_grvConsultaArticulo_checkAll" type="checkbox" name="ctl00$MainContent$grvConsultaArticulo$ctl01$checkAll" onclick="checkAll(this);"></th>' +
                            '<th style="width:20px"></th> ' + 
                            '<th style="width:100px">Fecha</th> ' + 
                            '<th style="width:120px">NroDocumento</th> ' + 
                            '<th style="width:120px">N. Doc</th> ' + 
                            '<th style="width:200px">RazonSocial</th> ' + 
                            '<th style="width:60px">Total</th> ' + 
                            '<th style="width:60px">Estado</th> ' + 
                    '</tr></thead>';
        $(html).appendTo($("#tab_Permisos"));

        querySnapshot.forEach((doc) => {

            arrPedidosID.push(doc.id);
            arrPedidos.push(doc.data());
            F_PaginasPermisos(doc.data(), doc.id);
            indexPedido = indexPedido + 1;

        });

    });

    return false;

dbFirestore.collection("Pedidos").doc("20547868839").collection("Pedidos").where("Estado", "==", "ENVIADO")
    .get().orderBy("Id", "desc")
    .then((querySnapshot) => {
        querySnapshot.forEach((doc) => {
            arrPedidosID.push(doc.id);
            arrPedidos.push(doc.data());
            F_PaginasPermisos(doc.data(), doc.id);
            indexPedido = indexPedido + 1;
        });
    })
    .catch((error) => {
        toastr.warning("Error getting documents: ", error);
    });
}

function F_PaginasPermisos(Lista, idPedido) {
    try {
        //Limpio y Reconstruyo la table

        //ciclo de permisos
        //$.each(Lista, function (index, item) {

           
            var subtabla = '';
            var nameImgMas = 'imgMas' + indexPedido;
            var estructuraSubtabla =
            ' <img id="' + nameImgMas + '" alt="" style="cursor: pointer" src="../Asset/images/plus.gif" onclick="imgMas_Click(this);" title="Ver Detalle"> ' +
            ' <div id="MainContent_grvConsulta_pnlOrders_0" style="display:none"> ' +
            ' <div> ' +
            ' 	<table cellspacing="1" cellpadding="0" border="0" class="GridView" id="MainContent_grvConsulta_grvDetalle_0"> ' +
            ' 		<tbody><tr> ' +
            ' 			<th style="width:20px;"  align="center" scope="col" >#</th> ' +
            '           <th style="width:100px;" align="center" scope="col">Codigo</th> ' +
            '           <th style="width:300px;" align="center" scope="col">Descripcion</th> ' +
            '           <th style="width:50px;" align="center" scope="col">Cantidad</th> ' +
            '           <th style="width:50px;" align="center" scope="col">Precio</th> ' +
            '           <th style="width:50px;" align="center" scope="col">Importe</th> ' +
            ' 		</tr> @Cuerpo' +
            ' 		 ' +
            ' 	</tbody></table> ' +
            ' </div> ' +
            ' </div> ';
            
            $.each(Lista.Articulos, function (index2, item2) {
            
                subtabla = subtabla +
                ' 		<tr style="height:5px;"> ' +
                ' 			<td align="left">' + item2.NroItem + '</td> ' +
                '           <td>' + item2.Codigo + ' </td>  ' +
                '           <td>' + item2.Descripcion + ' </td>  ' +
                '           <td>' + item2.Cantidad + ' </td>  ' +
                '           <td>' + item2.Precio + ' </td>  ' +
                '           <td>' + item2.Importe.toFixed(2) + ' </td>  ' +
                ' 		</tr> ';
            });
            
            if (subtabla != '')
                subtabla = estructuraSubtabla.replace('@Cuerpo', subtabla);

                
                

            html = '<tr>' +
                    '<td align="center" style="width:20px;"><span class="chkSi"><input id="MainContent_grvConsultaArticulo_chkOK_' + indexPedido + '" type="checkbox"> ' +
                    '<input type="hidden" id="hfIdPedido_' + indexPedido + '" value="' + idPedido + '"> ' +
                    '</span></td> ' +
                    '<td>' + subtabla + '</td>' +
                    '<td>' + Lista.Fecha + '</td>' +
                    '<td> <center>' + '9999-' + Lista.nroDocumento + '</center></td>' +
                    '<td> <center>' + Lista.NroRuc + '</center></td>' +
                    '<td> <center>' + Lista.RazonSocial + '</center></td>' +
                    '<td> <center>' + Lista.Total.toFixed(2) + '</center></td>' +
                    '<td> <center>' + Lista.Estado + '</center></td>' +
                    '</tr>';
            $(html).appendTo($("#tab_Permisos"))

            //if (subtabla != '')
            //    imgMas_Click($('#' + nameImgMas));

        //});
    }
    catch (x) { toastr.warning('ERROR AL CARGAR LOS MENUES'); }
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

function checkAll(objRef)
{
    var checkallid = '#' + objRef.id;

    if ($(checkallid).is(':checked')) {
            $('#tab_Permisos input:checkbox').prop('checked', true);
            $('#tab_Permisos .ccsestilo').prop('disabled', false);
        }
        else {
            $('#tab_Permisos input:checkbox').prop('checked', false);
            $('#tab_Permisos .ccsestilo').prop('disabled', true);

        }
}



var arrRechazados = new Array();
var arrRechazadosID = new Array();
function F_Rechazar_Pedidos() {
if (F_PermisoOpcion(CodigoMenu, CodigoInterno, 'Anular') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
    arrRechazados = new Array();
    arrRechazadosID = new Array();
    //asigno los nombres de como se van a llamar en el storage
    arrPedidos.forEach( function(valor, indice, array) {
            if ($("#MainContent_grvConsultaArticulo_chkOK_" + indice).is(':checked')) {
                   arrRechazados.push(valor);         
                   arrRechazadosID.push($("#hfIdPedido_" + indice).val());         
            }
    });

    if (arrRechazados.length > 0) {
            if (!confirm("¿SEGURO DE RECHAZAR " + arrRechazados.length.toString() + " PEDIDOS DE LA APP? " ))
                return false;
            else
                F_Enviar_Firestore();
        
    } else {
        toastr("NO HAY ARTICULOS QUE PUEDAN SER ENVIADOS A LA APP");
    }

return false;
}

function F_Enviar_Firestore() {
    //MostrarEspera(true);
    fireActual = 0;
    nuevoEstado = "RECHAZADO";
    F_Grabar_Firestore();
return false;
}

var fireActual = 0;
var nuevoEstado;
function F_Grabar_Firestore() {

    

    var arcEstado = {};
    arcEstado["Estado"] = nuevoEstado;

    var actualizacion = dbFirestore.collection("Pedidos").doc("20547868839").collection("Pedidos").doc(arrRechazadosID[fireActual]);

    // Set the "capital" field of the city 'DC'
    return actualizacion.update(arcEstado)
    .then(() => {

        if (fireActual + 1 === arrRechazados.length) {
            //MostrarEspera(false);
            toastr.success("SE ANULARON LOS PEDIDOS");
            return false;
            }

        fireActual = fireActual + 1;

        F_Grabar_Firestore();
    })
    .catch((error) => {
        // The document probably doesn't exist.
        //MostrarEspera(false);
        toastr.warning("Error updating document: ", error);
    });




return false;
}






function F_Aprobar_Pedidos() {
if (F_PermisoOpcion(CodigoMenu, 1000901, '') === "0") return false; //Entra a /Scripts/Utilitarios.js.F_PermisosOpcion para mas informac
    nuevoEstado = "EN PROCESO";

    arrRechazados = new Array();
    arrRechazadosID = new Array();
    //asigno los nombres de como se van a llamar en el storage
    arrPedidos.forEach( function(valor, indice, array) {
            if ($("#MainContent_grvConsultaArticulo_chkOK_" + indice).is(':checked')) {
                   arrRechazados.push(valor);         
                   arrRechazadosID.push($("#hfIdPedido_" + indice).val());         
            }
    });

    if (arrRechazados.length > 0) {
            if (!confirm("¿SEGURO DE APROBAR " + arrRechazados.length.toString() + " PEDIDOS DE LA APP? " ))
                return false;
            else
                F_Enviar_Firestore_Aprobado();
        
    } else {
        toastr("NO HAY ARTICULOS QUE PUEDAN SER ENVIADOS A LA APP");
    }

return false;
}

function F_Enviar_Firestore_Aprobado() {
    //MostrarEspera(true);
    fireActual = 0;

    F_Grabar_Firestore_Aprobar();
return false;
}

function F_Grabar_Firestore_Aprobar() {

    

    var arcEstado = {};
    arcEstado["Estado"] = nuevoEstado;

    var actualizacion = dbFirestore.collection("Pedidos").doc("20547868839").collection("Pedidos").doc(arrRechazadosID[fireActual]);

    // Set the "capital" field of the city 'DC'
    return actualizacion.update(arcEstado)
    .then(() => {

        F_Grabar_PF();

        if (fireActual + 1 === arrRechazados.length) {
            //MostrarEspera(false);
            toastr.success("SE APROBARON LOS PEDIDOS");
            return false;
            }

        fireActual = fireActual + 1;

        F_Grabar_Firestore_Aprobar();
    })
    .catch((error) => {
        // The document probably doesn't exist.
        //MostrarEspera(false);
        toastr.warning("Error updating document: ", error);
    });




return false;
}






function F_Grabar_PF() {
        var data = JSON.stringify(arrRechazados[fireActual]);
        var dataId = arrRechazadosID[fireActual];

        //INSERT EN LA FACTURA FINAL
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: '../Servicios/APP_Procesos.asmx/F_APP_Grabar_Factura',
            data: "{'data':'" + data + "','idFirebase':'" + dataId + "','CodMoneda':'1','CodTasa':'1','FlagIgv':'1','CodFormaPago':'1'}",
            dataType: "json",
            async: false,
            success: function (data) {
                
                valor = data.d;

            },
            error: function (response) {
                toastr.warning(response.statusText);
            },
            failure: function (response) {
                toastr.warning(response.statusText);
            }
        });

return false;
}