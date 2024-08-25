$(document).ready(function () {
    const weekdays = [
        "monday",
        "tuesday",
        "wednesday",
        "thursday",
        "friday",
        "saturday",
        "sunday",
    ];
    const timeslotRow = document.getElementById("timeslot-row");

    weekdays.forEach((day) => {
        // 創建一個隱藏的時段選項區塊
        const timeslotDiv = document.createElement("div");
        timeslotDiv.className = "col-12 col-md-6 mt-3 weekday-timeslot";
        timeslotDiv.id = `timeslot-${day}`;
        timeslotDiv.style.display = "none"; // 初始狀態為隱藏

        // 添加標題
        const title = document.createElement("span");
        title.className = "fw-bolder";
        title.textContent = `${day.charAt(0).toUpperCase() + day.slice(1)}時段`;
        timeslotDiv.appendChild(title);

        // 創建時間選項
        const timeslotWrapper = document.createElement("div");
        timeslotWrapper.className = "d-flex flex-wrap mt-2";

        // 創建上午、下午、傍晚、凌晨的checkbox
        const timePeriods = [
            { label: "上午", value: "morning", range: [6, 12] },
            { label: "下午", value: "afternoon", range: [12, 18] },
            { label: "傍晚", value: "evening", range: [18, 24] },
            { label: "深夜", value: "lateNight", range: [0, 6] },
        ];

        timePeriods.forEach((period) => {
            const formCheck = document.createElement("div");
            formCheck.className = "form-check col-3 mb-3";

            const input = document.createElement("input");
            input.className = "form-check-input";
            input.type = "checkbox";
            input.value = period.value;
            input.id = `${day}-${period.value}`;
            input.name = `${day}-period`;

            const label = document.createElement("label");
            label.className = "form-check-label fw-bold"; // 加粗字體
            label.htmlFor = input.id;
            label.textContent = period.label;

            formCheck.appendChild(input);
            formCheck.appendChild(label);
            timeslotWrapper.appendChild(formCheck);

            // 事件監聽器，用於勾選或取消勾選對應的時段
            input.addEventListener("change", function () {
                const checkboxes = timeslotDiv.querySelectorAll(
                    'input[name="' + day + '-time"]'
                );
                checkboxes.forEach((checkbox, index) => {
                    const hour = parseInt(checkbox.value.split(":")[0], 10);
                    if (hour >= period.range[0] && hour < period.range[1]) {
                        checkbox.checked = this.checked;
                    }
                });
            });
        });

        // 原本的時間選項
        for (let hour = 0; hour < 24; hour++) {
            const timeValue = hour.toString().padStart(2, "0") + ":00";
            const checkboxId = `${day}-${hour}`;

            const formCheck = document.createElement("div");
            formCheck.className = "form-check col-3";

            const input = document.createElement("input");
            input.className = "form-check-input";
            input.type = "checkbox";
            input.value = timeValue;
            input.id = checkboxId;
            input.name = `${day}-time`;

            const label = document.createElement("label");
            label.className = "form-check-label";
            label.htmlFor = checkboxId;
            label.textContent = timeValue;

            formCheck.appendChild(input);
            formCheck.appendChild(label);
            timeslotWrapper.appendChild(formCheck);
        }

        timeslotDiv.appendChild(timeslotWrapper);
        timeslotRow.appendChild(timeslotDiv);
    });

    // 事件監聽器，用來控制時段選項的顯示和隱藏
    $('input[name="weekday"]').each(function () {
        $(this).on('change', function () {
            const timeslotDiv = document.getElementById(`timeslot-${this.id}`);
            if (this.checked) {
                timeslotDiv.style.display = "block";
            } else {
                timeslotDiv.style.display = "none";
                // 當取消選擇該星期時，同時取消勾選所有對應的時間段
                $(timeslotDiv)
                    .find('input[type="checkbox"]')
                    .each(function () {
                        this.checked = false;
                    });
            }
        });
    });
});
