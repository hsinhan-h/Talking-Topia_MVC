const { createApp, ref } = Vue;
const app = createApp({
    data() {
        return {
            rating: null
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
        }
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
