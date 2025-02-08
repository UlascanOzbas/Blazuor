window.blazuorOffcanvas = {
    show: (id) => {
        let offcanvas = new bootstrap.Offcanvas(document.getElementById(id));
        offcanvas.show();
    },
    hide: (id) => {
        let offcanvas = bootstrap.Offcanvas.getInstance(document.getElementById(id));
        if (offcanvas) {
            offcanvas.hide();
        }
    }
};
