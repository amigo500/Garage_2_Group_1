((parkViewComponent) => {

    let size
    let parkingSlots;
    let regNr;
    let selectedParkingSlots;
    let hoveredParkingSlots;
    let parkButton;
    
    parkViewComponent.init = (args) => {
        size = args[0];
        parkingSlots = args[1];
        regNr = args[2];

        //optional
        parkButton = (args.length >= 3) ? args[3] : 'undefined';

        parkViewComponent.resetUI();
    }

    parkViewComponent.resetUI = () => {
        $(".box.slot-selected").removeClass("slot-selected");
        $(".box.slot-hover").removeClass("slot-hover");
        selectedParkingSlots = [];
        hoveredParkingSlots = [];
    }

    parkViewComponent.selectParking = () => {
        selectedParkingSlots = [];
        hoveredParkingSlots = [];

        $(".box.green").hover(
            function () {
                hoveredParkingSlots = [];
                const firstSlot = parseInt($(this).attr("value"));
                let fits = true;

                for (let i = 0; i < size; i++) {
                    let neighbourId = firstSlot + i;
                    let selector = `.box#id${neighbourId}`;

                    if ($(selector).hasClass('red') || neighbourId >= parkingSlots.length)
                        fits = false;
                    else
                        hoveredParkingSlots.push(selector);
                }

                if (fits)
                    hoveredParkingSlots.forEach(s => $(s).toggleClass("slot-hover"))
                
            },
            function () {
                hoveredParkingSlots.forEach(s => $(s).removeClass("slot-hover"))
            }
        );
        $(".box.green").click(function () {
            if (hoveredParkingSlots.length < size) return;

            showParkButton();

            selectedParkingSlots.forEach(old => $(old).toggleClass("slot-selected"));
            selectedParkingSlots = hoveredParkingSlots.slice();
            selectedParkingSlots.forEach(s => {
                $(s).toggleClass("slot-selected");
                $(s).toggleClass("slot-hover");
            });
            
        });
    }

    parkViewComponent.parkInSelectedSlots = () => {
        let slots = getSelectedParking();
        var dto = { selected: slots, regnr: regNr };

        return $.ajax({
            url: "/Vehicles/ParkInSelected",
            type: "POST",
            data: JSON.stringify(dto),
            contentType: 'application/json',
            success: function (parkingData) {
                selectedParkingSlots.forEach(s => {
                    $(s).toggleClass("red");
                    $(s).toggleClass("green");
                    $(s).toggleClass("slot-selected");
                    disableParkButton();
                });
            }
        });
    }

    function getSelectedParking() {
        let parkingSlots = selectedParkingSlots.slice();
        for (let i = 0; i < parkingSlots.length; i++)
        {
            parkingSlots[i] = parkingSlots[i].replace(".box#id", "");
        }
        return parkingSlots;
    }

    function showParkButton() {
        if (typeof parkButton !== 'undefined')
            parkButton.classList.remove("hidden");
    }

    function disableParkButton() {
        if (typeof parkButton !== 'undefined')
            parkButton.disabled = 'true';
    }

})((window.parkViewComponent = window.parkViewComponent || {}));