document.addEventListener("DOMContentLoaded", function () {
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

        // 創建上午、下午、傍晚、凌晨的 checkbox
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

            // 勾選或取消勾選對應的時段
            input.addEventListener("change", function () {
                const checkboxes = timeslotDiv.querySelectorAll(
                    'input[name="' + day + '-time"]'
                );
                checkboxes.forEach((checkbox) => {
                    const hour = parseInt(checkbox.value.split(":")[0], 10);
                    if (hour >= period.range[0] && hour < period.range[1]) {
                        checkbox.checked = this.checked;
                    }
                });
            });
        });

        // 創建具體時間選項
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

    // 使用 fetch 請求 API
    const memberId = 1;  // 根據實際情況動態設置
    const apiUrl = `/api/GetTutorReserveApi/GetTutorReserveTimeJson?memberId=${memberId}`;

    fetch(apiUrl)
        .then(response => response.json())
        .then(data => {
            console.log('API response:', data); // 查看返回的資料

            // 檢查是否有 availableReservation 資料
            if (!data || !data.availableReservation || !Array.isArray(data.availableReservation)) {
                throw new Error('AvailableReservation data is not available or is not an array');
            }

            const weekdayMap = {
                1: 'monday',
                2: 'tuesday',
                3: 'wednesday',
                4: 'thursday',
                5: 'friday',
                6: 'saturday',
                7: 'sunday'
            };

            const timePeriodMap = {
                morning: [6, 12],    // 上午 6:00 - 12:00
                afternoon: [12, 18], // 下午 12:00 - 18:00
                evening: [18, 24],   // 傍晚 18:00 - 24:00
                lateNight: [0, 6]    // 深夜 0:00 - 6:00
            };

            const selectedWeekdays = new Set();  // 存放所有選中的星期，避免重複處理

            // 處理 availableReservation 資料
            data.availableReservation.forEach(reservation => {
                const weekday = weekdayMap[reservation.weekday]; // 根據數字轉換為星期幾的名稱
                const timeslotDiv = document.getElementById(`timeslot-${weekday}`);

                // 勾選對應的星期
                if (!selectedWeekdays.has(reservation.weekday)) {
                    const weekdayCheckbox = document.getElementById(`weekday-${reservation.weekday}`);
                    if (weekdayCheckbox) {
                        weekdayCheckbox.checked = true;
                        selectedWeekdays.add(reservation.weekday); // 防止重複勾選
                    }
                }

                if (timeslotDiv) {
                    timeslotDiv.style.display = "block"; // 顯示時段區塊

                    // 勾選具體的 coursehours (如: 07:00, 08:00 等)
                    const timeCheckbox = document.getElementById(`${weekday}-${parseInt(reservation.coursehours.split(":")[0])}`);
                    if (timeCheckbox) {
                        timeCheckbox.checked = true;
                    }

                    // 處理時段的勾選 (上午、下午、傍晚、深夜)
                    const hour = parseInt(reservation.coursehours.split(":")[0]);
                    Object.keys(timePeriodMap).forEach(period => {
                        const [start, end] = timePeriodMap[period];
                        if (hour >= start && hour < end) {
                            const periodCheckbox = document.getElementById(`${weekday}-${period}`);
                            if (periodCheckbox) {
                                periodCheckbox.checked = true;
                            }
                        }
                    });
                }
            });
        })
        .catch(error => console.error('Error fetching data:', error));

    // 事件監聽器，用來控制時段選項的顯示和隱藏
    const weekdayInputs = document.querySelectorAll('input[name="weekday"]');
    weekdayInputs.forEach(function (input) {
        input.addEventListener("change", function () {
            const timeslotDiv = document.getElementById(`timeslot-${this.id}`);
            if (this.checked) {
                timeslotDiv.style.display = "block";
            } else {
                timeslotDiv.style.display = "none";
                // 當取消選擇該星期時，同時取消勾選所有對應的時間段
                const checkboxes = timeslotDiv.querySelectorAll(
                    'input[type="checkbox"]'
                );
                checkboxes.forEach(function (checkbox) {
                    checkbox.checked = false;
                });
            }
        });
    });
});
