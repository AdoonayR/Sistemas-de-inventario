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
document.addEventListener('DOMContentLoaded', function () {
    const searchForm = document.getElementById('search-form');
    const resultadosDiv = document.getElementById('resultados-busqueda');
    const sinResultadosDiv = document.getElementById('sin-resultados');

    if (searchForm) {
        searchForm.addEventListener('submit', function (e) {
            e.preventDefault(); // Evitamos el submit normal

            // Tomamos el part-number
            const partNumber = document.getElementById('part-number').value.trim();

            if (!partNumber) {
                alert("Ingrese un número de parte.");
                return;
            }

            // Llamada AJAX (GET) a /Materiales/Buscar?partNumber=xxx
            fetch(`/Materiales/Buscar?partNumber=${encodeURIComponent(partNumber)}`)
                .then(response => response.json())
                .then(json => {
                    if (!json.success) {
                        // No encontrado
                        resultadosDiv.style.display = 'none';
                        sinResultadosDiv.style.display = 'block';
                    } else {
                        // Llenamos los campos en #resultados-busqueda
                        document.getElementById('num-parte').textContent = json.data.numeroParte;
                        document.getElementById('descripcion').textContent = json.data.descripcion;
                        document.getElementById('categoria').textContent = json.data.categoria;
                        document.getElementById('cantidad').textContent = json.data.cantidad + " " + json.data.unidadMedida;
                        document.getElementById('ubicacion').textContent = json.data.ubicacion;
                        document.getElementById('proveedor').textContent = json.data.proveedor;
                        

                        sinResultadosDiv.style.display = 'none';
                        resultadosDiv.style.display = 'block';
                    }
                })
                .catch(error => {
                    console.error("Error en la búsqueda:", error);
                    alert("Ocurrió un error inesperado en la búsqueda.");
                });
        });
    }
});
