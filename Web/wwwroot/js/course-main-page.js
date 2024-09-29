
function checkLoginStatus(callback) {
    fetch('/api/FindMember/IsLoggedIn')
        .then(response => response.json())
        .then(data => {
            if (!data.isLoggedIn) {
                // 如果未登入，重導向到登入頁面
                window.location.href = '/Account/Account';
            } else {
                // 如果已登入，執行其他邏輯
                callback();
            }
        });
}

const { createApp, ref } = Vue;
const courseId = document.getElementById('app').dataset.courseId;
const memberId = document.getElementById('app').dataset.memberId;

const call = createApp({
    data() {
        return {
            rating: null,
            fetchedRating: null ,
            courseId: courseId,      // 從 DOM 中取得的課程 ID
            isFollowing: false,  // 初始關注狀態，從後端來決定是否已關注
            FollowerId: memberId,       // 假設當前使用者的 ID
            FollowedCourseId: courseId,    // 假設要關注的對象 ID
            courseReviews: []        // 用來儲存課程評論列表
        }
    },
    methods: {
        submitRating() {
            // 構建 FormData 並提交 rating 資料
            let formData = new FormData();
            formData.append('Rating', this.rating);
            

            // 使用 fetch 提交資料到後端控制器
            fetch('/Course/CreateCourseReview', {
                method: 'POST',
                body: formData
            })
                .then(response => response.json())
                .then(data => {
                    console.log('成功:', data);
                    // 在這裡可以處理提交成功後的邏輯
                })
                .catch(error => {
                    console.error('錯誤:', error);
                });
        },
        fetchRatingFromServer() {
            // 從後端獲取 Rating 資料
            fetch(`/api/CourseReview/CourseReviewApi?courseId=${this.courseId}`) 
                .then(response => response.json()) // 解析成 JSON 格式
                .then(data => {
                    this.fetchedRating = data;  // 將獲取到的評分設置到 fetchedRating 中
                })
                .catch(error => {
                    console.error('錯誤:', error);
                });
        },
        fetchCourseReviews() {
            // 從後端 API 獲取課程評論列表
            fetch(`/api/CourseReview/GetCourseReviewList?courseId=${this.courseId}`)
                .then(response => response.json())
                .then(data => {
                    this.courseReviews = data; // 將評論列表數據存入 Vue.js 的 courseReviews
                })
                .catch(error => {
                    console.error('Error fetching course reviews:', error);
                });
        },
        fetchFollowStatusFromServer() {
            // 假設從後端 API 獲取當前是否已關注狀態
            fetch(`/api/Following/GetFollowStatus?courseId=${this.courseId}`)
                .then(response => response.json())
                .then(data => {
                    this.isFollowing = data;
                })
                .catch(error => {
                    console.error('錯誤:', error);
                });
        },

        // 關注功能
        follow() {
            checkLoginStatus(() => {
                fetch(`/api/Following/AddFollowing?courseId=${this.courseId}`, {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify({
                        FollowerId: memberId,
                        FollowedCourseId: courseId,
                    }),
                })
                    .then(response => response.json())
                    .then(data => {
                        if (data.success) {
                            this.isFollowing = true;
                            alert(data.message);
                        } else {
                            alert(data.message);
                        }
                    })
                    .catch(error => console.error('Error:', error));
            });
        },
        // 取消關注功能
        unfollow() {
            fetch(`/api/Following/DeleteFollowingCourse?courseId=${this.courseId}`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    FollowerId: memberId,
                    FollowedCourseId: courseId,
                }),
            })
                .then(response => response.json())
                .then(data => {
                    if (data.success) {
                        this.isFollowing = false;
                        alert(data.message);
                    } else {
                        alert(data.message);
                    }
                })
                .catch(error => console.error('Error:', error));
        }

    },
    mounted() {
        // 在 Vue 應用掛載後自動呼叫 fetchRatingFromServer 來獲取資料
        this.fetchRatingFromServer();
        this.fetchFollowStatusFromServer();
        this.fetchCourseReviews(); 
    }

})

call.use(PrimeVue.Config);

call.component('p-rating', PrimeVue.Rating);

call.mount('#app');


const twentyfive_mins = document.querySelector("#min-25");
const fiftyfive_mins = document.querySelector("#min-50");

fiftyfive_mins.addEventListener("click", () => {
    const tfmins_coursr_group = document.querySelector(".min-25");
    const ftmins_coursr_group = document.querySelector(".min-50");
    ftmins_coursr_group.classList.remove("d-none");
    tfmins_coursr_group.classList.add("d-none",);
    fiftyfive_mins.classList.add("course-info-tab-color");
    twentyfive_mins.classList.remove("course-info-tab-color");
});

twentyfive_mins.addEventListener("click", () => {
    const tfmins_coursr_group = document.querySelector(".min-25");
    const ftmins_coursr_group = document.querySelector(".min-50");
    tfmins_coursr_group.classList.remove("d-none");
    ftmins_coursr_group.classList.add("d-none");
    fiftyfive_mins.classList.remove("course-info-tab-color");
    twentyfive_mins.classList.add("course-info-tab-color");
})

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
