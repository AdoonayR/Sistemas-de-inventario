function searchPart() {
    const partNumber = document.getElementById('searchPart').value;
    // Aquí iría una llamada AJAX o similar para buscar el número de parte en la base de datos
    if (partNumber) {
        document.getElementById('part-number').value = partNumber;
        document.getElementById('part-name').value = 'Nombre del Producto ' + partNumber; // Aquí podría poner la respuesta de la base de datos
    } else {
        alert('Por favor ingresa un número de parte válido.');
    }
}

function addPart() {
    const partNumber = document.getElementById('part-number').value;
    const partName = document.getElementById('part-name').value;
    const quantity = document.getElementById('quantity').value;
    const date = document.getElementById('date').value;     
    const location = document.getElementById('location').value;

    if (!partNumber || !partName || !quantity || !date || !location) {
        alert('Por favor llena todos los campos.');
        return;
    }

    // Aquí iría una llamada AJAX para agregar la información a la base de datos
    console.log(`Agregando: ${partNumber}, ${partName}, Cantidad: ${quantity}, Fecha: ${date}, Locación: ${location}`);
    alert('Parte agregada con éxito!');
}

function deletePart() {
    const partNumber = document.getElementById('part-number').value;

    if (!partNumber) {
        alert('Por favor busca un número de parte primero.');
        return;
    }

    // Aquí iría una llamada AJAX para eliminar el número de parte de la base de datos
    console.log(`Eliminando: ${partNumber}`);
    alert('Parte eliminada con éxito!');
}

