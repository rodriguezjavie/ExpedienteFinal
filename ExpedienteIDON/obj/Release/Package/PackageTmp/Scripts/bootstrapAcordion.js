 $(document).ready(function () {

            $(".toggle-accordion").on("click", function () {
                var accordionId = $(this).attr("accordion-id"),
                    numPanelOpen = $(accordionId + ' .collapse.show').length;

                $(this).toggleClass("active");

                if (numPanelOpen == 0) {
                    openAllPanels(accordionId);
                } else {
                    closeAllPanels(accordionId);
                }
            })

            openAllPanels = function (aId) {
                $(aId + ' .collapse:not(".in")').collapse('show');
                const link = document.getElementById("PanelsLink");
                link.text = 'Cerrar Paneles';
            }
            closeAllPanels = function (aId) {
                $(aId + ' .collapse.show').collapse('hide');
                const link = document.getElementById("PanelsLink");
                link.text = 'Abrir Paneles';
            }
        });