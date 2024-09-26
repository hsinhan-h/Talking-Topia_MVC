var data_categories = [
    {
        "name": "語言學習",
        "id": 1, 
        "subcategories": [
            {
                "name": "法文",
                "id": 1
            },
            {
                "name": "中文",
                "id": 2
            },
            {
                "name": "日文",
                "id": 3
            },
            {
                "name": "西班牙",
                "id": 4
            },
            {
                "name": "德文",
                "id": 5
            },
            {
                "name": "英文",
                "id": 6
            }
        ]
    },
    {
        "name": "程式設計",
        "id": 2, 
        "subcategories": [
            {
                "name": "HTML/CSS",
                "id": 7
            },
            {
                "name": "JavaScript",
                "id": 8
            },
            {
                "name": "C#",
                "id": 9
            },
            {
                "name": "SQL",
                "id": 10
            },
            {
                "name": "Python",
                "id": 11
            },
            {
                "name": "Java",
                "id": 12
            }
        ]
    },
    {
        "name": "升學科目",
        "id": 3, 
        "subcategories": [
            {
                "name": "數學",
                "id": 13
            },
            {
                "name": "物理",
                "id": 14
            },
            {
                "name": "化學",
                "id": 15
            },
            {
                "name": "歷史",
                "id": 16
            },
            {
                "name": "地理",
                "id": 17
            },
            {
                "name": "生物",
                "id": 18
            }
        ]
    }
];
const { createApp } = Vue;
const app = createApp({
    data() {
        return {
            selectedCategory: '', // 用來儲存選中的分類 ID
            selectedSubcategory: '', // 用來儲存選中的子分類 ID
            commonData: {}, // 用來存儲轉換過後的數據
            licenses: [ 
                { name: '', file: null }
            ],
            works: [ // 初始化一個空的工作經驗表單
                {
                    workName: '',
                    workStartDate: '',
                    workEndDate: '',
                    workExperienceFile: null
                }
            ],
        };
    },
    computed: {
        categories() {
            return this.commonData['raw_data'] || []; // 返回所有的主分類
        },
        subcategories() {
            if (this.selectedCategory) {
                return this.commonData['category_' + this.selectedCategory]?.subcategories || [];
            }
            return [];
        },
        selectedCategoryName() {
            if (this.selectedCategory) {
                return this.commonData['category_' + this.selectedCategory]?.name || '';
            }
            return '';
        },
        selectedSubcategoryName() {
            if (this.selectedSubcategory) {
                return this.commonData['subcategory_' + this.selectedSubcategory]?.name || '';
            }
            return '';
        }
    },
    created() {
        this.convertData(data_categories);
        this.fetchBackendData();
        //// 如果 TempData 中有 Toast 信息，則顯示
    },
    methods: {
        convertData(data) {
            let result = {};
            result["raw_data"] = data; // 儲存原始數據
            data.forEach(category => {
                result["category_" + category.id] = category;
                category.subcategories.forEach(subcategory => {
                    result["subcategory_" + subcategory.id] = subcategory;
                });
            });
            this.commonData = result;
        },
        fetchBackendData() {
            fetch('/api/ApplyCourseList/ResumeApplyCouseData', {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                }
            })
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Network response was not ok');
                    }
                    return response.json();
                })
                .then(data => {
                    if (!data.success) {
                        throw new Error(data.message || 'Unknown error');
                    }

                    // 獲取 courseList 和 professionalLicense
                    const courseList = data.data.applycoursedata.courseList;
                    this.selectedCategory = courseList.applyCourseCategoryId;
                    this.selectedSubcategory = courseList.applySubCategoryId;

                    const licenseList = data.data.professionalLicense;
                    this.licenses = licenseList.professionalLicenseName.map((name, index) => ({
                            name: name,
                            file: licenseList.professionalLicenseUrl[index] || null
                    }));
                    const workexpList = data.data.workexp.workBackground;
                    if (workexpList && workexpList.length > 0) {
                        this.works = workexpList.map(work => ({
                            workName: work.workName || '',
                            workStartDate: work.workStartDate || '',
                            workEndDate: work.workEndDate || '',
                            workExperienceFile: null
                        }));
                    }
                })
                .catch(error => {
                    console.error('Error fetching course list:', error);
                });
        },
        numberToChinese(num) {
            const chineseNumbers = ['零', '一', '二', '三', '四', '五', '六', '七', '八', '九'];

            if (num === 10) {
                return '十'; // 對於10特殊處理
            }

            let result = '';
            const tens = Math.floor(num / 10);
            const ones = num % 10;

            if (tens === 1) {
                result += '十'; // 當數字在10到19之間
            } else if (tens > 1) {
                result += chineseNumbers[tens] + '十'; // 大於19時處理
            }

            if (ones !== 0) {
                result += chineseNumbers[ones]; // 加上個位數
            }

            return result;
        },

        addLicense() {
            // 增加新的證照欄位
            this.licenses.push({ name: '', file: null });
        }, removeLicense(index) {
            // 移除證照欄位
            this.licenses.splice(index, 1);
        },
        handleFileUpload(event, index) {
            // 當用戶上傳文件時，更新文件數據
            this.licenses[index].file = event.target.files[0];
        },
        addWorkExperience() {
            this.works.push({
                workName: '',
                workStartDate: '',
                workEndDate: '',
                workExperienceFile: null
            });
        },
        handleWorkFileUpload(event, index) {
            this.works[index].workExperienceFile = event.target.files[0];
        },

        // 移除工作經歷欄位
        removeWorkExperience(index) {
            this.works.splice(index, 1);
        }
    },

});
app.mount('#vue-wrapper');
