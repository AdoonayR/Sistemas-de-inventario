// wwwroot/js/materialesAjax.js
$(document).ready(function () {
    // Seleccionamos el formulario por id:
    $('#agregarForm').submit(function (event) {
        event.preventDefault(); // Evita que el navegador haga el submit tradicional

        // Obtenemos la URL (action) del formulario:
        const url = $(this).attr('action');
        // Serializamos todos los campos (incluye el anti-forgery token)
        const formData = $(this).serialize();

        // Enviamos la petición AJAX
        $.ajax({
            type: 'POST',
            url: url,
            data: formData,
            // Si el servidor responde con código 200 OK
            success: function (response) {
                if (response.success) {
                    // Muestra un alerta, o tu lógica de notificación
                    alert(response.message);

                    // Limpia el formulario
                    $('#agregarForm')[0].reset();

                    // Opcional: Limpia mensajes de error de validación
                    $('.text-danger').text('');
                } else {
                    // Aquí podríamos manejar un caso de "success=false" 
                    // pero con code 200. Depende de tu controlador.
                }
            },
            // Si el servidor responde con 400 u otro error HTTP
            error: function (xhr) {
                if (xhr.status === 400) {
                    // Parseamos el JSON con los errores:
                    const result = xhr.responseJSON;
                    if (result && result.errors) {
                        let errorsText = '';
                        result.errors.forEach(err => {
                            errorsText += `• ${err}\n`;
                        });
                        alert('Errores:\n' + errorsText);
                    } else {
                        alert('Error inesperado al guardar.');
                    }
                } else {
                    alert('Error en el servidor: ' + xhr.status);
                }
            }
        });
    });
});
