function BuscarComercios(ddlDepartamento, ddlMunicipio, txtBusqueda, DivContainer) {
    var IdMunicipio = $(ddlMunicipio).val() == '' || $(ddlMunicipio).val() == null ? "0" : $(ddlMunicipio).val();
    var IdDepartamento = $(ddlDepartamento).val() == '' ? "0" : $(ddlDepartamento).val();
    var Nombre = document.getElementById(txtBusqueda).value == '' ? '0' : document.getElementById(txtBusqueda).value;

    $.ajax({
        type: "post",
        url: "/Comercios/BusquedaComercios?IdDepto=" + IdDepartamento + "&IdMuni=" + IdMunicipio + "&NombreBusqueda="+Nombre,
        contentType: "html",
        success: function (response) {
            debugger
            $(DivContainer).empty();
            $(DivContainer).append(response);
        }
    })
}

function LimpiarSeleccionComercio() {
    $("#IdComercio").val("0");
    $("#DescComercioSeleccionado").val("");
    document.getElementById('LblComercioSelecionado').innerHTML = "";
}


function DetalleQueja(txtid,divcontainer) {
    var IdQueja = $(txtid).val() == '' || $(txtid).val() == null ? "0" : $(txtid).val();
    $.ajax({
        type: "post",
        url: "/Quejas/DetalleQueja?IdQueja=" + IdQueja ,
        contentType: "html",
        success: function (response) {
            debugger
            $(divcontainer).empty();
            $(divcontainer).append(response);
        }
    })
}


function VerDetalleQueja(descripcion) {
    console.log('ingreso');
    document.getElementById('TextoModal').innerHTML = "";
    document.getElementById('TextoModal').innerHTML = descripcion;
    console.log('paso los inner');
    $("#ModalDetalle").modal("show");
}