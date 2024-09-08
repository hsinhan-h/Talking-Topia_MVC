const bookingTableBody = document.getElementById("bookingTableBody");
const bookingTableHeader = document.getElementById("bookingTableHeader");
const weekRange = document.getElementById("weekRange");
const prevWeekBtn = document.getElementById("prevWeek");
const nextWeekBtn = document.getElementById("nextWeek");
const confirmBookingModal = new bootstrap.Modal(
    document.getElementById("confirmBookingModal")
);

const confirmBookingModalTutorHeadshot = document.getElementById(
    "confirmBookingModalTutorHeadshot");

const confirmBookingModalCourseTitle = document.getElementById(
    "confirmBookingModalCourseTitle");

const confirmBookingModalDate = document.getElementById(
    "confirmBookingModalDate"
);
const confirmBookingModalTime = document.getElementById(
    "confirmBookingModalTime"
);
const bookingTableBodyWrapper = document.getElementById(
    "bookingTableBodyWrapper"
);

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
let globCourseId = 1;
let tutorSlots = [];


//傳入confirmBookingModel的資訊
//let courseTitle;
//let tutorHeadShot;
//const bookBtn = document.querySelectorAll('.lh-tutor-card__book-btn');
//bookBtn.forEach((btn) => btn.addEventListener("click", (e) => {
//    courseTitle = e.target.getAttribute('data-course-title');
//    tutorHeadShot = e.target.getAttribute('data-tutor-headshot').slice(1);
//}))

async function generateBookingTable(weekStart, courseId) {
    globCourseId = courseId;
    const fetchedData = await fetchBookingTableData(courseId);
    tutorSlots = fetchedData.availableTimeSlots;
    console.log(tutorSlots);

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
            if (!inTutorTime(weekday, time)) {
                cell.classList.add("d-none");
            }

            

            //如果時段還沒被預約, 加入confirmBookingModal事件
            if (!isBooked(date, time, bookedSlots)) {
                cell.addEventListener("click", (e) => {
                    //confirmBookingModalCourseTitle.textContent = courseTitle;
                    //confirmBookingModalTutorHeadshot.src = tutorHeadShot;
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

//產生00:00 ~ 23:00 的時間段陣列
function generateTimeSlots() {
    const times = [];
    for (let hour = 0; hour < 24; hour++) {
        times.push(`${String(hour).padStart(2, "0")}:00`);
    }
    return times;
}

//把date轉換成yyyy-mm-dd
function formatDate(date) {
    let dateInUTC8 = new Date(date);
    dateInUTC8.setDate(dateInUTC8.getDate());
    return dateInUTC8.toISOString().split("T")[0];
}

function isBooked(date, time, bookedSlots) {
    return bookedSlots.includes(`${formatDate(date)} ${time}`);
}

function inTutorTime(weekday, time) {
    for (const tutorSlot of tutorSlots) {
        if (tutorSlot.weekday == weekday && `${String(tutorSlot.startHour - 1).padStart(2, "0")}:00` == time) {
            return true;
        }
    }
    return false;
}

prevWeekBtn.addEventListener("click", () => {
    bookingDateStart.setDate(bookingDateStart.getDate() - 7);
    generateBookingTable(bookingDateStart, globCourseId);
});

nextWeekBtn.addEventListener("click", () => {
    bookingDateStart.setDate(bookingDateStart.getDate() + 7);
    generateBookingTable(bookingDateStart, globCourseId);
});



//fetch BookingTable API
async function fetchBookingTableData(courseId) {
    const url = `/api/BookingTableApi?courseId=${courseId}`;

    try {
        const response = await fetch(url);

        if (!response.ok) {
            console.error(`Fetching BookingTableData時發生錯誤, status: ${response.status} `);
            return null;
        }

        const bookingTableData = await response.json();
        if (!bookingTableData) {
            console.error('沒有fetching到任何BookingTable資料!');
            return null;
        }

        console.log(bookingTableData);
        return bookingTableData;

    } catch (error) {
        console.error('Fetching BookingTableData時發生錯誤:', error);
    }
}