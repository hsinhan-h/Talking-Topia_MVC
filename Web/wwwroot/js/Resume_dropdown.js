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
            toastMessage: window.toastMessage || '', // 使用全局變數傳遞的 TempData 信息
            toastHeader: window.toastHeader || ''  // 使用全局變數傳遞的 TempData 標題
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
        if (this.toastHeader && this.toastMessage) {
            this.showToast(this.toastHeader, this.toastMessage);
        }
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
                    const courseList = data.data.courseList; 
                    this.selectedCategory = courseList.applyCourseCategoryId; 
                    this.selectedSubcategory = courseList.applySubCategoryId; 
                })
                .catch(error => {
                    console.error('Error fetching course list:', error);
                });
        },
    },

});
app.mount('#vue-wrapper');
