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
            selectedSubject: null,
            selectedNation: null,
            selectedWeekdays: [],
            selectedTimeslots: [],
            selectedBudget: null,
            availableSlots: [], //二維陣列, 元素為各課程的教師時段Array
            bookedSlots: [], //二維陣列, 元素為各課程的被預約時段Array          
            courseCategories: [], //動態科目篩選選單資料
            nations: []  //動態國籍篩選選單資料
        };
    },
    mounted() {
        const params = new URLSearchParams(window.location.search);
        this.page = parseInt(params.get('page')) || 1; //從query string取得page
        this.selectedSubject = params.get('subject') || null;
        this.selectedNation = params.get('nation') || null;
        this.selectedBudget = params.get('budget') || null;       
        this.fetchCourses();
        this.fetchCategories();
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
                let url = `/api/CourseListApi?page=${this.page}`;
                if (this.selectedSubject) {
                    url += `&subject=${this.selectedSubject}`;
                }
                if (this.selectedNation) {
                    url += `&nation=${this.selectedNation}`;
                }
                if (this.selectedWeekdays.length > 0) {
                    url += `&weekdays=${this.selectedWeekdays.join(',')}`;
                }
                if (this.selectedTimeslots.length > 0) {
                    url += `&timeslots=${this.selectedTimeslots.join(',')}`;
                }
                if (this.selectedBudget) {
                    url += `&budget=${this.selectedBudget}`;
                }

                const response = await fetch(url);
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

        //篩選選單動態資料
        async fetchCategories() {
            try {
                const response = await fetch('/api/CourseCategoryApi');
                if (response.ok) {
                    const courseCategoriesData = await response.json();
                    this.courseCategories = courseCategoriesData;
                }
            } catch (e) {
                this.error = e;
            } finally {

                this.loading = false;
            }
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
                let url = `/api/CourseListApi/GetTotalCourseQty`;
                if (this.selectedSubject) {
                    url += `?subject=${this.selectedSubject}`;
                }
                if (this.selectedNation) {
                    url += `?nation=${this.selectedNation}`;
                }
                if (this.selectedWeekdays.length > 0) {
                    url += `?weekdays=${this.selectedWeekdays.join(',')}`;
                }
                if (this.selectedTimeslots.length > 0) {
                    url += `?timeslots=${this.selectedTimeslots.join(',')}`;
                }
                if (this.selectedBudget) {
                    url += `?budget=${this.selectedBudget}`;
                }
                const response = await fetch(url);

                if (response.ok) {
                    const totalCourseQty = await response.json();
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
                //this.updateQueryString();
                //history.pushState(null, '', `?page=${this.page}`);
            }
        },
        updateQueryString() {
            const queryParams = new URLSearchParams(window.location.search);
            queryParams.set('page', this.page);
            if (this.selectedSubject) {
                queryParams.set('subject', this.selectedSubject);
            } else {
                queryParams.delete('subject');
            }

            if (this.selectedNation) {
                queryParams.set('nation', this.selectedNation);
            } else {
                queryParams.delete('nation');
            }

            if (this.selectedWeekdays && this.selectedWeekdays.length > 0) {
                queryParams.set('weekdays', this.selectedWeekdays.join(','));
            } else {
                queryParams.delete('weekdays');
            }

            if (this.selectedTimeslots && this.selectedTimeslots.length > 0) {
                queryParams.set('timeslots', this.selectedTimeslots.join(','));
            } else {
                queryParams.delete('timeslots');
            }

            if (this.selectedBudget) {
                queryParams.set('budget', this.selectedBudget);
            } else {
                queryParams.delete('budget');
            }

            history.pushState(null, '', '?' + queryParams.toString());
        },

        //篩選
        //1. 課程種類
        filterBySubject(subject) {
            this.selectedSubject = subject;
            this.applyFilter();
        },
        //2. 國籍
        filterByNation(nation) {
            this.selectedNation = nation;
            this.applyFilter();
        },
        //3. 時段
        filterByWeekdayAndTimeSlot() {
            //v-model已綁定, 不用再push到selectedWeekdays
            this.applyFilter();
        },

        //4. 預算區間
        filterByBudget(budget) {
            this.selectedBudget = budget;
            this.applyFilter();
        },

        applyFilter() {
            this.page = 1;
            this.fetchCourses();
            this.fetchTotalCourseQty();
            this.updateQueryString();
        },

        //取消篩選
        clearSubjectFilter() {
            this.selectedSubject = null;
            this.applyFilter();
        },
        clearNationFilter() {
            this.selectedNation = null;
            this.applyFilter();
        },
        clearWeekdayAndTimeslotFilter() {            
            this.selectedWeekdays = [];
            this.selectedTimeslots = [];
            this.applyFilter();
        },
        clearBudgetFilter() {
            this.selectedBudget = null;
            this.applyFilter();
        },

        getWeekdayName(weekdayNumber) {
            const weekdayMapping = {
                1: '星期一',
                2: '星期二',
                3: '星期三',
                4: '星期四',
                5: '星期五',
                6: '星期六',
                0: '星期日'
            };
            return weekdayMapping[weekdayNumber];
        }
    }
});

courseCardsApp.mount('#course-cards-app');
