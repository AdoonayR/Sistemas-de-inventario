document.addEventListener("DOMContentLoaded", function () {
    const form = document.getElementById("formulario");
    const showButton = document.querySelector(".show-button");
    const cancelButton = document.querySelector(".btn-secondary"); 

    if (form && showButton) {
        // Asegurarse de que el formulario está oculto inicialmente
        form.style.display = "none";

        showButton.addEventListener("click", function () {
            const isHidden = form.style.display === "none";

            // Mostrar u ocultar el formulario
            form.style.display = isHidden ? "block" : "none";

            // Si se muestra, desplazarse hacia él
            if (isHidden) {
                setTimeout(() => {
                    window.scrollBy({
                        top: 200,
                        behavior: "smooth"
                    });
                }, 100);
            }
        });
    }

    //  Funcionalidad del botón Cancelar
    if (cancelButton && form) {
        cancelButton.addEventListener("click", function () {
            form.style.display = "none";
        });
    }

    // Simulación de búsqueda de material
    const searchForm = document.getElementById("search-form");

    if (searchForm) {
        searchForm.addEventListener("submit", function (e) {
            e.preventDefault();

            const partNumber = document.getElementById("part-number").value;

            document.getElementById("resultado-part-number").textContent = partNumber;
            document.getElementById("resultado-descripcion").textContent = "Descripción simulada para " + partNumber;
            document.getElementById("resultado-cantidad").textContent = "150 unidades";

            document.getElementById("resultados-busqueda").style.display = "block";
        });
    }
});

