//document.addEventListener("DOMContentLoaded", function () {
//    if (typeof Vue !== 'undefined') {
//        new Vue({
//            el: '#app',
//            data: {
//                activeTab: '語言學習',  // 預設為 "語言學習" tab
//            },
//            methods: {
//                setActiveTab(tab) {
//                    this.activeTab = tab;  // 切換當前選中的 tab
//                }
//            }
//        });
//    } else {
//        console.error('Vue is not loaded');
//    }
//});



// 選擇所有具有 class "tutorrecommendcard" 的元素
const tutorCards = document.querySelectorAll(".TRMC");

// 為每個卡片添加點擊事件監聽器
tutorCards.forEach(function (card) {
    card.addEventListener("click", function () {
        // 獲取卡片上的 data-courseid 屬性
        const courseId = card.getAttribute("data-courseid");

        // 跳轉到目標頁面，並將 courseId 作為查詢參數
        window.location.href = `/Course/CourseMainPage?courseId=${courseId}`;

        console.log(`跳轉到課程ID: ${courseId}`);
    });
});


