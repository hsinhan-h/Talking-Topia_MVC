const bookingTableBody = document.getElementById("bookingTableBody");
const bookingTableHeader = document.getElementById("bookingTableHeader");
const weekRange = document.getElementById("weekRange");
const prevWeekBtn = document.getElementById("prevWeek");
const nextWeekBtn = document.getElementById("nextWeek");
const confirmBookingModal = new bootstrap.Modal(
    document.getElementById("confirmBookingModal")
);
const confirmBookingModalDate = document.getElementById(
    "confirmBookingModalDate"
);
const confirmBookingModalTime = document.getElementById(
    "confirmBookingModalTime"
);
const bookingTableBodyWrapper = document.getElementById(
    "bookingTableBodyWrapper"
);
const expandTableBtn = document.getElementById("expandBookingTable");

//教師有教課的時間由此匯入
const tutorAvailableSlots = [
    ["tuesday", "00:00"],
    ["tuesday", "01:00"],
    ["tuesday", "02:00"],
    ["tuesday", "03:00"],
    ["tuesday", "04:00"],
    ["tuesday", "05:00"],
    ["tuesday", "06:00"],
    ["tuesday", "07:00"],
    ["tuesday", "08:00"],
    ["tuesday", "09:00"],
    ["tuesday", "10:00"],
    ["tuesday", "11:00"],
    ["tuesday", "12:00"],
    ["tuesday", "13:00"],
    ["tuesday", "14:00"],
    ["tuesday", "15:00"],
    ["tuesday", "16:00"],
    ["tuesday", "17:00"],
    ["tuesday", "18:00"],
    ["tuesday", "19:00"],
    ["tuesday", "20:00"],
    ["tuesday", "21:00"],
    ["tuesday", "22:00"],
    ["tuesday", "23:00"],
    ["wednesday", "10:00"],
    ["thursday", "13:00"],
    ["thursday", "14:00"],
    ["thursday", "15:00"],
    ["thursday", "16:00"],
    ["thursday", "17:00"],
    ["friday", "13:00"],
    ["friday", "14:00"],
    ["friday", "15:00"],
    ["friday", "16:00"],
    ["friday", "17:00"],
    ["saturday", "13:00"],
    ["saturday", "14:00"],
    ["saturday", "15:00"],
    ["saturday", "16:00"],
];

//已被預約的時間由此匯入
const bookedSlots = [
    "2024-08-15 12:00",
    "2024-08-15 13:00",
    "2024-08-15 14:00",
    "2024-08-17 15:00",
    "2024-08-17 16:00",
    "2024-08-20 13:00",
    "2024-08-18 18:00",
];

let bookingDateStart = new Date();
bookingDateStart.setDate(bookingDateStart.getDate());

function generateBookingTable(weekStart) {
    bookingTableBody.innerHTML = "";
    bookingTableHeader.innerHTML = "";
    const dates = [];
    const standardWeekdays = ["日", "一", "二", "三", "四", "五", "六"];
    const engWeekdays = [
        "sunday",
        "monday",
        "tuesday",
        "wednesday",
        "thursday",
        "friday",
        "saturday",
    ];
    const today = new Date().getDay();
    let weekDaysBeginFromToday = standardWeekdays
        .slice(today)
        .concat(standardWeekdays.slice(0, today));

    for (let i = 0; i < 7; i++) {
        const date = new Date(weekStart);
        date.setDate(weekStart.getDate() + i);
        dates.push(date);

        const divTableHead = document.createElement("div");
        divTableHead.innerHTML = `${weekDaysBeginFromToday[i]
            }<br>${date.getDate()}`;
        bookingTableHeader.appendChild(divTableHead);
    }
    weekRange.textContent = `${formatDate(dates[0])} 
  至 ${formatDate(dates[6])}`;

    //產出表格內時間
    const times = generateTimeSlots();

    for (const date of dates) {
        const column = document.createElement("div");
        const weekday = date.getDay();
        column.classList.add(engWeekdays[weekday]);
        for (const time of times) {
            const cell = document.createElement("div");
            cell.textContent = time;
            cell.dataset.time = `${formatDate(date)} ${time}`;
            cell.className = isBooked(date, time, bookedSlots)
                ? "booked"
                : "available";

            //如果日期不在教師的教課時間內, 隱藏日期
            if (!inTutorTime(engWeekdays[weekday], time)) {
                cell.classList.add("d-none");
            }

            //如果時段還沒被預約, 跳出confirmBookingModal
            if (!isBooked(date, time, bookedSlots)) {
                cell.addEventListener("click", () => {
                    confirmBookingModalDate.textContent = `${formatDate(date)} (${standardWeekdays[date.getDay()]
                        })`;
                    confirmBookingModalTime.textContent = time;
                    confirmBookingModal.show();
                });
                cell.setAttribute("title", "預約此時段");
                cell.setAttribute("data-bs-custom-class", "custom-table-tooltip");
            }
            column.appendChild(cell);
        }
        bookingTableBody.appendChild(column);
    }

    // Initialize tooltips
    const tooltipTriggerList = Array.from(document.querySelectorAll("[title]"));
    tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl, {
            delay: { show: 100, hide: 0 },
        });
    });
}

//產生06:00 ~ 23:00 ~ 05:00的時間段陣列
function generateTimeSlots() {
    const times = [];
    for (let hour = 6; hour < 24; hour++) {
        times.push(`${String(hour).padStart(2, "0")}:00`);
    }
    for (let hour = 0; hour < 6; hour++) {
        times.push(`${String(hour).padStart(2, "0")}:00`);
    }
    return times;
}

//把date轉換成yyyy-mm-dd
function formatDate(date) {
    let dateInUTC8 = new Date(date);
    dateInUTC8.setDate(dateInUTC8.getDate() + 1);
    return dateInUTC8.toISOString().split("T")[0];
}

function isBooked(date, time, bookedSlots) {
    return bookedSlots.includes(`${formatDate(date)} ${time}`);
}

function inTutorTime(weekday, time) {
    for (const tutorAvailableSlot of tutorAvailableSlots) {
        if (tutorAvailableSlot[0] == weekday && tutorAvailableSlot[1] == time) {
            return true;
        }
    }
    return false;
}

prevWeekBtn.addEventListener("click", () => {
    bookingDateStart.setDate(bookingDateStart.getDate() - 7);
    generateBookingTable(bookingDateStart);
});

nextWeekBtn.addEventListener("click", () => {
    bookingDateStart.setDate(bookingDateStart.getDate() + 7);
    generateBookingTable(bookingDateStart);
});

// expandTableBtn.addEventListener("click", () => {
//   bookingTableBodyWrapper.style.maxHeight = "none";
//   expandTableBtn.style.display = "none";
// });

generateBookingTable(bookingDateStart);
