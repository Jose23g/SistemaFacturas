// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('#postTitle').autocomplete({
        source: 'api/PostController/Buscar'
    });
});

$(document).on('sumit', '#SetDetalle', function (e) {
    e.preventDefault();

    if (!$('#SetEncabezado').valid()) {
        return false;
    }
    var Cod_factura = 0;
    $.ajax({
        type: 'POST',
        url: '/Facturar/SetEncabezado/',
        data: $('#SetEncabezado').serialize(),
        success: function (data) {
            if (data.resultado) {
                IdCompra = data.resultado;
                $.ajax({
                    type: 'POST',
                    url: '/Facturar/SetDetalle/',
                    data: $(this).serialize() + '&Cod_factura' + Cod_factura,
                    success: function (data) {
                        console.log(data);
                    }
                });
            }
            else {
                alert(data.mensaje);
            }
        }
    });
});
