import { generateBookingTable } from '/js/booking_table/booking_table_modal.js';
import { initHoverPopup, initTooltips, autoPlayYouTubeModal } from '/js/course_list/course_list_slick.js';

const courseCardsApp = Vue.createApp({
    data() {
        return {
            courses: [],
            page: 1,
            pageSize: 6,
            totalPages: 0,
            error: null,
            loading: true,
            selectedNationality: null,
            availableSlots: [], //二維陣列, 元素為各課程的教師時段Array
            bookedSlots: [], //二維陣列, 元素為各課程的被預約時段Array
            nations: []
        };
    },
    mounted() {
        const params = new URLSearchParams(window.location.search);
        this.page = parseInt(params.get('page')) || 1; //從query string取得page
        this.fetchCourses();
        this.fetchNations();
        this.fetchTotalCourseQty();
        
    },
    updated() {
        //DOM 已更新完後, 重新呼叫slick function & tooltips & modals
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
                    this.availableSlots = [];
                    this.bookedSlots = [];
                    if (this.courses.length > 0) {
                        this.courses.forEach(c => {
                            this.availableSlots.push(c.availableTimeSlots);
                            this.bookedSlots.push(c.bookedTimeSlots);
                        });                      
                    }
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
        addBookingStatusClass(startHour, endHour, weekday, index) {
            const isAvailable = this.availableSlots[index].some(slot => slot.weekday === weekday && slot.startHour >= startHour && slot.startHour < endHour);
            const isOccupied = this.bookedSlots[index].some(slot => {
                const today = new Date();
                const currentDayOfWeek = today.getDay();

                const startOfWeek = new Date(today);
                startOfWeek.setDate(today.getDate() - currentDayOfWeek);

                const endOfWeek = new Date(startOfWeek);
                endOfWeek.setDate(startOfWeek.getDate() + 6);

                const bookedDate = new Date(slot.date);

                return bookedDate >= startOfWeek && bookedDate <= endOfWeek &&
                    bookedDate.getDay() === weekday && slot.startHour >= startHour && slot.startHour < endHour;
            });
            if (isOccupied) {
                return 'occupied';
            }
            else if (isAvailable) {
                return 'available';
            }
            return '';
        },
        async fetchNations() {
            try {
                const response = await fetch('/api/NationApi');
                if (response.ok) {
                    const nationNameData = await response.json();
                    this.nations = nationNameData;          
                }
            } catch (e) {
                this.error = e;
            } finally {
                
                this.loading = false;
            }
        },
        async fetchTotalCourseQty() {
            try {
                const response = await fetch('/api/CourseListApi/GetTotalCourseQty');
                if (response.ok) {
                    const totalCourseQty = await response.json();
                    console.log(totalCourseQty);
                    this.totalPages = Math.ceil(totalCourseQty / this.pageSize);
                }
            } catch (e) {
                this.error = e;
            } finally {

                this.loading = false;
            }
        },
        //換頁 不刷新頁面
        goToPage(page) {
            if (page > 0 && page <= this.totalPages) {
                this.page = page;
                this.fetchCourses();
                history.pushState(null, '', `?page=${this.page}`);
            }
        }

    }
});

courseCardsApp.mount('#course-cards-app');
