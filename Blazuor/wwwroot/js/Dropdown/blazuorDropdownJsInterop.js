let registeredBlazuorDropdowns = {};

export function registerBlazuorDropdownOutsideClick(BlazuorDropdownId, BlazuorDropdownRef) {
    const blazuorDropdownElement = document.getElementById(BlazuorDropdownId);

    if (!blazuorDropdownElement) {
        console.error(`BlazuorDropdown element with id ${BlazuorDropdownId} not found.`);
        return;
    }

    const handleClickOutside = (event) => {
        if (!blazuorDropdownElement.contains(event.target)) {
            BlazuorDropdownRef.invokeMethodAsync("BlazuorDropdownClose");
        }
    };

    // Event listener'ı kaydet
    registeredBlazuorDropdowns[BlazuorDropdownId] = handleClickOutside;

    document.addEventListener("click", handleClickOutside);
}

export function unregisterBlazuorDropdownOutsideClick(BlazuorDropdownId) {
    const handleClickOutside = registeredBlazuorDropdowns[BlazuorDropdownId];

    if (handleClickOutside) {
        document.removeEventListener("click", handleClickOutside);
        delete registeredBlazuorDropdowns[BlazuorDropdownId];
    }
}