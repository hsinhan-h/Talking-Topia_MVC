﻿const bookingTableBody = document.getElementById("bookingTableBody");
const bookingTableHeader = document.getElementById("bookingTableHeader");
const bookingTableBodyWrapper = document.getElementById("bookingTableBodyWrapper");
const weekRange = document.getElementById("weekRange");
const prevWeekBtn = document.getElementById("prevWeek");
const nextWeekBtn = document.getElementById("nextWeek");


//確認預約Modal
const confirmBookingModal = new bootstrap.Modal(document.getElementById("confirmBookingModal"));
const confirmBookingModalTutorHeadshot = document.getElementById("confirmBookingModalTutorHeadshot");
const confirmBookingModalCourseTitle = document.getElementById("confirmBookingModalCourseTitle");
const confirmBookingModalDate = document.getElementById("confirmBookingModalDate");
const confirmBookingModalTime = document.getElementById("confirmBookingModalTime");
const addToCartBtn = document.getElementById("confirmBookingModalAddToCartBtn");


//初始化資料
let bookingDateStart = new Date();
bookingDateStart.setDate(bookingDateStart.getDate());
let globCourseId = 1;
let tutorSlots = [];
let bookedSlots = [];
let tutorHeadShot = "";
let courseTitle = "";
let selectedBookingDate = null;
let selectedBookingTime = null;


//Booking Table渲染
export async function generateBookingTable(weekStart, courseId) {

    globCourseId = courseId;
    const fetchedData = await fetchBookingTableData(courseId);
    console.log(fetchedData);
    tutorSlots = fetchedData.availableTimeSlots;
    bookedSlots = fetchedData.bookedTimeSlots;
    tutorHeadShot = fetchedData.tutorHeadShotImage;
    courseTitle = fetchedData.courseTitle;


    bookingTableBody.innerHTML = "";
    bookingTableHeader.innerHTML = "";
    const dates = [];
    const standardWeekdays = ["日", "一", "二", "三", "四", "五", "六"];
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
                cell.addEventListener("click", () => {
                    confirmBookingModalCourseTitle.textContent = courseTitle;
                    confirmBookingModalTutorHeadshot.src = tutorHeadShot;

                    selectedBookingDate = date;
                    selectedBookingTime = time;

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
    let newDate = new Date(date);
    let year = newDate.getFullYear();
    let month = String(newDate.getMonth() + 1).padStart(2, '0');
    let day = String(newDate.getDate()).padStart(2, '0');
    return `${year}-${month}-${day}`;
}

function isBooked(date, time, bookedSlots) {
    return bookedSlots.some(bs =>
        formatDate(bs.date) == formatDate(date) && `${String(bs.startHour - 1).padStart(2, "0")}:00` == time);
}

function inTutorTime(weekday, time) {
    for (const tutorSlot of tutorSlots) {
        if (tutorSlot.weekday == weekday && `${String(tutorSlot.startHour - 1).padStart(2, "0")}:00` == time) {
            return true;
        }
    }
    return false;
}

//前一周&後一周換頁鈕
prevWeekBtn.addEventListener("click", () => {
    bookingDateStart.setDate(bookingDateStart.getDate() - 7);
    generateBookingTable(bookingDateStart, globCourseId);
});

nextWeekBtn.addEventListener("click", () => {
    bookingDateStart.setDate(bookingDateStart.getDate() + 7);
    generateBookingTable(bookingDateStart, globCourseId);
});

//提交預約表單 並存入local storage (for購物車使用)
addToCartBtn.addEventListener("click", function () {
    document.getElementById("formCourseId").value = globCourseId;
    document.getElementById("formBookingDate").value = selectedBookingDate.toLocaleDateString('zh-TW');
    document.getElementById("formBookingTime").value = parseInt(selectedBookingTime.split(':')[0]) + 1;
    document.getElementById("addToCartForm").submit();
    localStorage.setItem("CourseId", globCourseId);
    localStorage.setItem("BookingDate", selectedBookingDate.toLocaleDateString('zh-TW'));
    localStorage.setItem("BookingTime", parseInt(selectedBookingTime.split(':')[0]) + 1);
})

//fetch BookingTable API
async function fetchBookingTableData(courseId) {
    const url = `/api/BookingTableApi?courseId=${courseId}`;
    console.log(url);
    try {
        const response = await fetch(url);

        if (!response.ok) {
            console.error(`網路發生錯誤, status: ${response.status} `);
            return null;
        }

        const bookingTableData = await response.json();
        if (!bookingTableData) {
            console.error('沒有fetching到任何BookingTable資料!');
            return null;
        }

        return bookingTableData;

    } catch (error) {
        console.error('Fetching BookingTableData時發生錯誤:', error);
    }
}
