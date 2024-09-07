
async function handleCourseLinkClick(event, courseId, redirectUrl) {
    event.preventDefault(); //防止跳轉
    await fetchBookingTableData(courseId);
    // 抓到資料後再後導向CourseMainPage
    //window.location.href = redirectUrl;
}


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
