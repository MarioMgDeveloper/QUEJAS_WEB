function SetEmpresaSelect(IdEmpresa, Nombre, direccion, nit, IdEstado) {
    $("#TxtIdEmp").val(IdEmpresa);
    $("#TxtNombre").val(Nombre);
    $("#TxtDireccion").val(direccion);
    $("#TxtNit").val(nit);
    $("#ddlEstado").val(IdEstado);
}

function CargarEmpresas(DivContainer) {
    console.log('llego');
    $.ajax({
        type: "post",
        url: "/Comercios/AdminEmpresas",
        contentType: "html",
        success: function (response) {
            debugger
            $(DivContainer).empty();
            $(DivContainer).append(response);
        }
    })
}

function CargarEstablecimiento(DivContainer,IdEst) {
    console.log('llego');
    $.ajax({
        type: "get",
        url: "/Comercios/AdminEstablecimiento?IdEst=" + IdEst,
        contentType: "html",
        success: function (response) {
            debugger
            $(DivContainer).empty();
            $(DivContainer).append(response);
        }
    })
}

function ListarEstablecimientos(DivContainer, IdEmpresa) {
    console.log('llego');
    $.ajax({
        type: "post",
        url: "/Comercios/ListarEstablecimientos",
        contentType: "html",
        success: function (response) {
            debugger
            $(DivContainer).empty();
            $(DivContainer).append(response);
        }
    })
}

function CargarEstablecimientoDetalle(idestab,nombre,direccion,departamento,municipio,patente,estado) {
    $("#TxtNombreEstablecimiento").val(nombre);
    $("#TxtDireccionEstab").val(direccion);
    $("#ddlDeptoEstablecimiento").val(departamento);
    $("#ddlMunicipioEstablecimiento").val(municipio);
    $("#TxtPatente").val(patente);
    $("#ddlEstadoEstablecimiento").val(estado);
    $("#TxtIdEstab").val(idestab);
    FillMunicipios('#ddlDeptoEstablecimiento', '#ddlMunicipioEstablecimiento', municipio)
}