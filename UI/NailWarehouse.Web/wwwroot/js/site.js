document.addEventListener("DOMContentLoaded", function () {
    const selectMaterial = document.getElementById("selectMaterial");
    const inputCustomMaterial = document.getElementById("inputCustomMaterial");

    if (selectMaterial && inputCustomMaterial)
    {
        const originalName = selectMaterial.getAttribute("name");

        selectMaterial.addEventListener("change", function () {
            if (this.value === "Other")
            {
                inputCustomMaterial.classList.remove("d-none");
                inputCustomMaterial.setAttribute("required", "required");

                inputCustomMaterial.setAttribute("name", originalName);
                selectMaterial.removeAttribute("name");
            }
            else
            {
                inputCustomMaterial.classList.add("d-none");
                inputCustomMaterial.removeAttribute("required");
                inputCustomMaterial.value = "";

                selectMaterial.setAttribute("name", originalName);
                inputCustomMaterial.removeAttribute("name");
            }
        });
    }
});

document.addEventListener("DOMContentLoaded", function ()
{
    const selectSize = document.getElementById("selectSize");
    const inputCustomSize = document.getElementById("inputCustomSize");

    if (selectSize && inputCustomSize)
    {
        const originalName = selectSize.getAttribute("name");

        selectSize.addEventListener("change", function () {
            if (this.value === "Other")
            {
                inputCustomSize.classList.remove("d-none");
                inputCustomSize.setAttribute("required", "required");

                inputCustomSize.setAttribute("name", originalName);
                selectSize.removeAttribute("name");
            }
            else {
                inputCustomSize.classList.add("d-none");
                inputCustomSize.removeAttribute("required");
                inputCustomSize.value = "";

                selectSize.setAttribute("name", originalName);
                inputCustomSize.removeAttribute("name");
            }
        });
    }
});

        document.addEventListener("DOMContentLoaded", function () {
        let formToSubmit = null;

        const deleteButtons = document.querySelectorAll('.btn-delete');
        const confirmBtn = document.getElementById('confirmDeleteBtn');
        const productNameSpan = document.getElementById('productNameToDelete');

        const deleteModal = new bootstrap.Modal(document.getElementById('deleteModal'));

        deleteButtons.forEach(button => {
        button.addEventListener('click', function () {
        formToSubmit = this.closest('form');

        const productName = this.getAttribute('data-name');

        productNameSpan.textContent = `${productName}`;
        deleteModal.show();
    });
    });
        confirmBtn.addEventListener('click', function () {
        if (formToSubmit) {
        formToSubmit.submit();
    }
        });
        });
