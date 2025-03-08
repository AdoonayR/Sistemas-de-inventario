
        // Función para buscar un producto (aquí solo simula la búsqueda)
    function searchItem() {
            const searchTerm = document.getElementById('search').value.toLowerCase();
    const rows = document.querySelectorAll('#inventoryTable tbody tr');

            rows.forEach(row => {
                const productName = row.cells[0].textContent.toLowerCase();
    if (productName.includes(searchTerm)) {
        row.style.display = '';
                } else {
        row.style.display = 'none';
                }
            });
        }

    // Función para agregar un producto al inventario (solo simula agregar un producto)
    function addItem() {
            const tableBody = document.querySelector('#inventoryTable tbody');
    const newRow = document.createElement('tr');

    // Puedes personalizar estos datos con lo que quieras
    newRow.innerHTML = `
    <td>Nuevo Producto</td>
    <td>10</td>
    <td>$100</td>
    <td><button onclick="removeItem(this)">Eliminar</button></td>
    `;

    tableBody.appendChild(newRow);
        }

    // Función para eliminar un producto del inventario
    function removeItem(button) {
            const row = button.parentElement.parentElement;
    row.remove();
        }
