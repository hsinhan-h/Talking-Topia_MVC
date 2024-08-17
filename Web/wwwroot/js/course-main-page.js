const { createApp, ref } = Vue;
const app = createApp({
    data() {
        return {
            rating: null
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
