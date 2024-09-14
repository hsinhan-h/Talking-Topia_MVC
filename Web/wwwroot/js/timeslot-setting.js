document.addEventListener("DOMContentLoaded", function () {
    const urlParams = new URLSearchParams(window.location.search);
    const memberId = urlParams.get('memberId'); // 獲取 `memberId` 參數

    if (memberId) {
        document.getElementById('memberIdDisplay').innerText = memberId;
    }// 顯示會員ID

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
        
        
        const dayCheckboxes = document.querySelectorAll('input[name="weekday"]');

        // 為每個 checkbox 添加 change 事件
        dayCheckboxes.forEach((checkbox, index) => {
            checkbox.addEventListener("change", function () {
                // 根據 index 對應到每一天的 timeslotDiv
                const timeslotDiv = document.getElementById(`timeslot-${weekdays[index]}`);

                if (this.checked) {
                    timeslotDiv.style.display = "block"; // 顯示
                } else {
                    timeslotDiv.style.display = "none"; // 隱藏
                }
            });
        });
       
    });

    // 使用 fetch 請求 API
   /* const memberId = 35;*/ //測試用：前端的參數丟到後端
    if (memberId !== null) {
        const apiUrl = `/api/GetTutorReserveApi/GetTutorReserveTimeJson?memberId=${memberId}`;

        fetch(apiUrl)
            .then(response => response.json())
            .then(data => {
                console.log('API response:', data); // 查看返回的資料

                // 檢查是否有回傳的 Json 裡 availableReservation 資料
                if (!data || !data.availableReservation || !Array.isArray(data.availableReservation)) {
                    throw new Error('error');
                }

                if (data) { updateReservationList(data.availableReservation) }

                function getWeeking(dayNumber) {
                    const weekdayMapping = {
                        0: '星期日',
                        1: '星期一',
                        2: '星期二',
                        3: '星期三',
                        4: '星期四',
                        5: '星期五',
                        6: '星期六'
                    };
                    return weekdayMapping[dayNumber];
                }

                function updateReservationList(reservations) {
                    const reservationList = document.getElementById("reservation-list");
                    reservationList.innerHTML = ""; // 清空列表

                    const groupedReservations = {}; // 用來按 weekday 分組

                    // 將 reservation(JSON) 根據 weekday (KEY) 分組
                    reservations.forEach(reservation => {
                        const day = reservation.weekday;//Json中的key
                        if (!groupedReservations[day]) {
                            groupedReservations[day] = []; // 如果還沒有這個 weekday，則新建一個陣列
                        }
                        groupedReservations[day].push(reservation); // 將 reservation 加入對應的 weekday 的object
                    });

                    // 生成每個 weekday 的卡片區塊
                    Object.keys(groupedReservations).forEach(day => {
                        const dayReservations = groupedReservations[day];
                        const cardDiv = document.createElement("div");
                        cardDiv.classList.add("card", "m-2");
                        cardDiv.style.width = "18rem";

                        // 創建卡片 header 顯示星期幾
                        const cardHeader = document.createElement("div");
                        cardHeader.classList.add("card-header");
                        cardHeader.textContent = getWeeking(day); // 顯示星期

                        const timeList = document.createElement("ul");
                        timeList.classList.add("list-group", "list-group-flush");

                        // 創建該星期的時段列表
                        dayReservations.forEach(reservation => {
                            const listItem = document.createElement("li");
                            listItem.classList.add("list-group-item");

                            const startTime = reservation.coursehours.split(":")[0]; // 取得開始小時部分
                            const endTime = (parseInt(startTime) + 1).toString().padStart(2, "0"); // 假設每個時段一小時，這裡是計算結束時間

                            listItem.textContent = `${getWeeking(day)} ${startTime}點至${endTime}點`;
                            timeList.appendChild(listItem);
                        });

                        cardDiv.appendChild(cardHeader);
                        cardDiv.appendChild(timeList);
                        reservationList.appendChild(cardDiv); // 把每個星期的卡片加入到 reservationList
                    });
                }

                //以下是fetch後渲染checkbox用


                // 要確認資料庫的星期幾順序
                const weekdayMap = {
                    0: 'sunday',
                    1: 'monday',
                    2: 'tuesday',
                    3: 'wednesday',
                    4: 'thursday',
                    5: 'friday',
                    6: 'saturday',
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
                    const timesDiv = document.getElementById(`timeslot-${weekday}`);

                    // 勾選對應的星期
                    if (!selectedWeekdays.has(reservation.weekday)) {
                        const weekdayCheckbox = document.getElementById(`weekday-${reservation.weekday}`);
                        if (weekdayCheckbox) {
                            weekdayCheckbox.checked = true;
                            selectedWeekdays.add(reservation.weekday); // 防止重複勾選
                        }
                    }

                    if (timesDiv) {
                        timesDiv.style.display = "block"; // 顯示時段區塊

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
            .catch(error => {
                console.error('Error fetching data:', error);
                alert('無法獲取資料，請稍後再試');// 暫時設計沒抓到資料的處理
            });

        // 事件監聽器，用來控制時段選項的顯示和隱藏
        const weekdayInputs = document.querySelectorAll('input[name="weekday"]');
        weekdayInputs.forEach(function (input) {
            input.addEventListener("change", function () {
                const timesweekDiv = document.getElementById(`timeslot-${this.id}`); // 選到生成的星期區塊
                if (timesweekDiv) {
                    if (this.checked) {
                        timesweekDiv.style.display = "block";
                    } else {
                        timesweekDiv.style.display = "none";
                        // 當取消選擇該星期時，同時取消勾選所有對應的時間段
                        const checkboxes = timesweekDiv.querySelectorAll('input[type="checkbox"]');
                        checkboxes.forEach(function (checkbox) {
                            checkbox.checked = false;
                        });
                    }
                }
            });
        });
    }
});
