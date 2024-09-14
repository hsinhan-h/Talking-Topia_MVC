import { generateBookingTable } from '/js/booking_table/booking_table_modal.js';
import { initHoverPopup, initTooltips, autoPlayYouTubeModal } from '/js/course_list/course_list_slick.js';

const courseCardsApp = Vue.createApp({
    data() {
        return {
            courses: [],
            page: 1,
            pageSize: 6,
            error: null,
            loading: true,
            selectedNationality: null
        };
    },
    mounted() {
        const params = new URLSearchParams(window.location.search);
        this.page = parseInt(params.get('page')) || 1; //從query string取得page
        this.fetchCourses();
    },
    updated() {
        //DOM 已更新完後, 重新呼叫slick function & tooltips
        this.$nextTick(() => {
            initHoverPopup();  
            initTooltips();
            autoPlayYouTubeModal();
        });
    },
    methods: {
        async fetchCourses() {
            this.loading = true;
            try {
                const response = await fetch(`/api/CourseListApi?page=${this.page}`);
                if (response.ok) {
                    const courseData = await response.json();
                    console.log(courseData);
                    this.courses = courseData.courseInfoList;
                } else {
                    throw new Error(`Error: ${response.status} ${response.statusText}`);
                }
            } catch (e) {
                this.error = e;
            } finally {
                this.loading = false;
            }
        },
        goToCourseMainPage(courseId) {
            window.location.href = `/Course/CourseMainPage?courseId=${courseId}`;
        },
        formatPrice(price) {
            return price.toLocaleString('en-US');
        },
        openBookingTable(courseId) {
            this.$nextTick(() => {
                generateBookingTable(new Date(), courseId);

                const bookingTableModal = new bootstrap.Modal(document.getElementById('bookingTableModal'));
                bookingTableModal.show();
            });
        },
        addBookingStatusClass(startHour, endHour, weekday) {

        }

    }
});

courseCardsApp.mount('#course-cards-app');
