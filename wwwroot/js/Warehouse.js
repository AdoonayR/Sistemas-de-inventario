document.addEventListener("DOMContentLoaded", function () {
    // Botones del sidebar
    const buscarBtn = document.getElementById("buscarBtn");
    const agregarBtn = document.getElementById("agregarBtn");
    const moverBtn = document.getElementById("moverBtn");
    const solicitudesBtn = document.getElementById("solicitudesBtn");

    // Secciones de contenido
    const buscarSection = document.getElementById("buscarSection");
    const agregarSection = document.getElementById("agregarSection");
    const moverSection = document.getElementById("moverSection");
    const solicitudesSection = document.getElementById("solicitudesSection");

    // Función para ocultar todas las secciones
    function hideAllSections() {
        buscarSection.style.display = "none";
        agregarSection.style.display = "none";
        moverSection.style.display = "none";
        solicitudesSection.style.display = "none";
    }

    // Mostrar sección de búsqueda por defecto
    hideAllSections();
    buscarSection.style.display = "block";

    // Manejadores de eventos para los botones
    if (buscarBtn) {
        buscarBtn.addEventListener("click", function (e) {
            e.preventDefault();
            hideAllSections();
            buscarSection.style.display = "block";
        });
    }

    if (agregarBtn) {
        agregarBtn.addEventListener("click", function (e) {
            e.preventDefault();
            hideAllSections();
            agregarSection.style.display = "block";
        });
    }

    if (moverBtn) {
        moverBtn.addEventListener("click", function (e) {
            e.preventDefault();
            hideAllSections();
            moverSection.style.display = "block";
        });
    }

    if (solicitudesBtn) {
        solicitudesBtn.addEventListener("click", function (e) {
            e.preventDefault();
            hideAllSections();
            solicitudesSection.style.display = "block";
        });
    }
});

document.addEventListener('DOMContentLoaded', function () {
    // Simulación de datos (en producción vendría de tu backend)
    const materiales = {
        'PARTE-001': {
            descripcion: 'Tornillo hexagonal 5mm',
            lotes: [
                { id: 'LOTE-2023-001', cantidad: 150, ubicacion: 'ZONA1-EST1-BIN1' },
                { id: 'LOTE-2023-002', cantidad: 75, ubicacion: 'ZONA1-EST2-BIN1' }
            ]
        },
        'PARTE-002': {
            descripcion: 'Tablero MDF 1/2"',
            lotes: [
                { id: 'LOTE-2023-003', cantidad: 50, ubicacion: 'ZONA2-EST1-BIN2' }
            ]
        }
    };

    // Cuando se selecciona un material
    document.getElementById('parte-mover').addEventListener('change', function () {
        const parte = this.value;
        const loteSelect = document.getElementById('lote-mover');

        // Limpiar opciones anteriores
        loteSelect.innerHTML = '<option value="">Seleccionar lote...</option>';

        if (parte && materiales[parte]) {
            // Llenar lotes disponibles
            materiales[parte].lotes.forEach(lote => {
                const option = document.createElement('option');
                option.value = lote.id;
                option.textContent = `${lote.id} (Q: ${lote.cantidad})`;
                option.dataset.ubicacion = lote.ubicacion;
                option.dataset.cantidad = lote.cantidad;
                loteSelect.appendChild(option);
            });
        }
    });

    // Cuando se selecciona un lote
    document.getElementById('lote-mover').addEventListener('change', function () {
        const selectedOption = this.options[this.selectedIndex];
        if (selectedOption.value) {
            document.getElementById('ubicacion-actual').value = selectedOption.dataset.ubicacion;
            document.getElementById('cantidad-mover').max = selectedOption.dataset.cantidad;
            document.getElementById('cantidad-disponible').textContent =
                `Disponible: ${selectedOption.dataset.cantidad} unidades`;
        } else {
            document.getElementById('ubicacion-actual').value = '';
            document.getElementById('cantidad-disponible').textContent = '';
        }
    });
});