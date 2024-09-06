
async function handleCourseClick(event, courseId, redirectUrl) {
    event.preventDefault(); //防止跳轉
    await fetcheBookingTableData(courseId);
    console.log("fetch api done");
    // 抓到資料後再後導向CourseMainPage
    //window.location.href = redirectUrl;
}

//async function fetcheBookingTableData(courseId) {
//    const url = `/api/bookingtable?courseId=${courseId}`;

//    // 發送 GET 請求到 API
//    fetch(url)
//        .then(response => {
//            if (response.ok) {
//                console.log(response);
//                return response.json(); // 轉換為 JSON 格式
//            } else {
//                throw new Error('Data not found');
//            }
//        })
//        .then(data => {
//            console.log(data);
//        })
//}

async function fetcheBookingTableData(courseId) {
    const url = `/api/BookingTableApi?courseId=${courseId}`;

    try {
        // 發送 GET 請求到 API
        const response = await fetch(url);

        // 檢查回應是否正確
        if (!response.ok) {
            throw new Error('Data not found');
        }

        // 轉換為 JSON 格式
        const data = await response.json();

        // 打印結果
        console.log(data);

        return data;

    } catch (error) {
        // 捕捉錯誤並打印
        console.error('Error fetching booking table data:', error);
    }
}
