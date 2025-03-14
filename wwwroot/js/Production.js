
// Función que se ejecuta cuando se envía el formulario
document.getElementById('formproducto').addEventListener('submit', function (e) {
    e.preventDefault(); // Prevenir el comportamiento por defecto (enviar el formulario)

    // Obtener los valores del formulario
    const pn = document.getElementById('PN').value;
    const quantity = document.getElementById('quantity').value;

    // Llamar a la función para agregar el producto a la tabla
    addProductToTable(pn, quantity);

    // Limpiar los campos del formulario después de agregar
    document.getElementById('PN').value = '';
    document.getElementById('quantity').value = '';
});

// Función para agregar el producto a la tabla
function addProductToTable(pn, quantity) {
    // Crear una nueva fila en la tabla
    const table = document.getElementById('productTable').getElementsByTagName('tbody')[0];
    const newRow = table.insertRow();

    // Insertar celdas en la nueva fila
    const cell1 = newRow.insertCell(0);
    const cell2 = newRow.insertCell(1);

    // Asignar los valores del producto a las celdas
    cell1.textContent = pn;
    cell2.textContent = quantity;
}
