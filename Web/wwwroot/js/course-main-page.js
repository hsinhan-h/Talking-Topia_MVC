const { createApp, ref } = Vue;
const courseId = document.getElementById('app').dataset.courseId;
const app = createApp({
    data() {
        return {
            rating: null,
            fetchedRating: null ,
            courseId: courseId      // 從 DOM 中取得的課程 ID

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
            fetch(`/api/CourseReviewRatingValueController/CourseReviewApi?courseId=${this.courseId}`) 
                .then(data => {
                    this.fetchedRating = data;  // 將獲取到的評分設置到 fetchedRating 中
                })
                .catch(error => {
                    console.error('錯誤:', error);
                });
        }
    },
    mounted() {
        // 在 Vue 應用掛載後自動呼叫 fetchRatingFromServer 來獲取資料
        this.fetchRatingFromServer();
    }

})

app.use(PrimeVue.Config);

app.component('p-rating', PrimeVue.Rating);

app.mount('#app');


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
