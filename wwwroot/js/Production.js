function searchPart() {
    const partNumber = document.getElementById('searchPart').value;
    // buscar el número de parte en la base de datos
    if (partNumber) {
        document.getElementById('part-number').value = partNumber;
        document.getElementById('part-name').value = 'Nombre del Producto ' + partNumber; // respuesta de la base de datos
        document.getElementById('quantity').value = 50;  // Ejemplo de cantidad
        document.getElementById('location').value = 'A1 - Estante 1'; // Ejemplo de locación
    } else {
        alert('Por favor ingresa un número de parte válido.');
    }
}

function requestMaterial() {
    const partNumber = document.getElementById('part-number').value;

    if (!partNumber) {
        alert('Por favor busca un número de parte primero.');
        return;
    }

    
    console.log(`Solicitando material para: ${partNumber}`);
    alert('Solicitud de material realizada con éxito!');
}

