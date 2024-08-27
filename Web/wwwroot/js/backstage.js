document.addEventListener("DOMContentLoaded", function () {

    document.querySelectorAll('input[name="weekday"]').forEach((weekday) => {
        weekday.addEventListener("change", function () {
            const timeslotDiv = document.getElementById(`timeslot-${this.id}`);
            if (this.checked) {
                timeslotDiv.style.display = "block";
            } else {
                timeslotDiv.style.display = "none";

                timeslotDiv
                    .querySelectorAll('input[type="checkbox"]')
                    .forEach((checkbox) => {
                        checkbox.checked = false;
                    });
            }
        });
    });
    document
        .querySelectorAll('input[name$="-period"]')
        .forEach((periodCheckbox) => {
            periodCheckbox.addEventListener("change", function () {
                const day = this.id.split("-")[0];
                const period = this.value;
                const ranges = {
                    morning: [6, 12],
                    afternoon: [12, 18],
                    evening: [18, 24],
                    lateNight: [0, 6],
                };

                const timeRange = ranges[period];
                const timeslotDiv = document.getElementById(`timeslot-${day}`);
                const checkboxes = timeslotDiv.querySelectorAll('input[name$="-time"]');

                checkboxes.forEach((checkbox) => {
                    const hour = parseInt(checkbox.value.split(":")[0], 10);
                    if (hour >= timeRange[0] && hour < timeRange[1]) {
                        checkbox.checked = this.checked;
                    }
                });
            });
        });
});
