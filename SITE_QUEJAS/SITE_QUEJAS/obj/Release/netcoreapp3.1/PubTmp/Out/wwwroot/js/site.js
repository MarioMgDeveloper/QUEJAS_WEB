function FillMunicipios(ddlDepartamento, ddlMunicipios, IdSelected,reset) {
    var IdDepartamento = $(ddlDepartamento).val() == '' || $(ddlDepartamento).val() == null ? "0" : $(ddlDepartamento).val();
    if (reset == '1') {
        IdDepartamento = '0';
    }
    $.ajax({
        type: "post",
        url: "/Helpers/FillMunicipios?IdDepartamento=" + IdDepartamento + "&IdSelected=" + IdSelected,
        contentType: "html",
        success: function (response) {
            $(ddlMunicipios).empty();
            $(ddlMunicipios).append(response);
        }
    })
}

function FillDepartamentos(ddlRegion, ddlDepartamento, IdSelected) {
    var IdRegion = $(ddlRegion).val() == '' || $(ddlRegion).val() == null ? "0" : $(ddlRegion).val();
    $.ajax({
        type: "post",
        url: "/Helpers/FillDepartamentos?IdRegion=" + IdRegion + "&IdSelected=" + IdSelected,
        contentType: "html",
        success: function (response) {
            $(ddlDepartamento).empty();
            $(ddlDepartamento).append(response);
        }
    })
}

function BuscarQuejas(ddlRegion, ddlDepartamento, ddlMunicipio, ddlEstado, TxtDel, TxtAl, TxtNOmbre, div) {
    var IdRegion = $(ddlRegion).val() == '' || $(ddlRegion).val() == null ? "0" : $(ddlRegion).val();
    var IdDepartamento = $(ddlDepartamento).val() == '' || $(ddlDepartamento).val() == null ? "0" : $(ddlDepartamento).val();
    var IdMunicipio = $(ddlMunicipio).val() == '' || $(ddlMunicipio).val() == null ? "0" : $(ddlMunicipio).val();
    var IdEstado = $(ddlEstado).val() == '' || $(ddlEstado).val() == null ? "0" : $(ddlEstado).val();
    var Del = $(TxtDel).val() == '' || $(TxtDel).val() == null ? "0" : $(TxtDel).val();
    var Al = $(TxtAl).val() == '' || $(TxtAl).val() == null ? "0" : $(TxtAl).val();
    var Nombre = $(TxtNOmbre).val() == '' || $(TxtNOmbre).val() == null ? "null" : $(TxtNOmbre).val();


    $.ajax({
        type: "post",
        url: "/Reportes/BuscarQuejas?region=" + IdRegion + "&departamento=" + IdDepartamento + "&municipio=" + IdMunicipio +
            "&estado=" + IdEstado + "&del=" + Del + "&al=" + Al + "&nombre=" + Nombre,
        contentType: "html",
        success: function (response) {
            $(div).empty();
            $(div).append(response);
        }
    })
}





