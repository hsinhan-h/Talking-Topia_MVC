var data_categories = [
    {
        "name": "語言學習",
        "id": "001",
        "subcategories": [
            {
                "name": "法文",
                "id": "0011"
            },
            {
                "name": "中文",
                "id": "0012"
            },
            {
                "name": "日文",
                "id": "0013"
            },
            {
                "name": "西班牙",
                "id": "0014"
            },
            {
                "name": "德文",
                "id": "0015"
            },
            {
                "name": "英文",
                "id": "0016"
            }
        ]
    },
    {
        "name": "程式設計",
        "id": "002",
        "subcategories": [
            {
                "name": "HTML/CSS",
                "id": "0021"
            },
            {
                "name": "JavaScript",
                "id": "0022"
            },
            {
                "name": "C#",
                "id": "0023"
            },
            {
                "name": "SQL",
                "id": "0024"
            },
            {
                "name": "Python",
                "id": "0025"
            },
            {
                "name": "Java",
                "id": "0026"
            }
        ]
    },
    {
        "name": "升學科目",
        "id": "003",
        "subcategories": [
            {
                "name": "數學",
                "id": "0031"
            },
            {
                "name": "物理",
                "id": "0032"
            },
            {
                "name": "化學",
                "id": "0033"
            },
            {
                "name": "歷史",
                "id": "0034"
            },
            {
                "name": "地理",
                "id": "0035"
            },
            {
                "name": "生物",
                "id": "0036"
            }
        ]
    }
];
const { createApp } = Vue;
const app = createApp({
    data() {
        return {
            selectedCategory: '',
            selectedSubcategory: '',
            commonData: {},
        };
    },
    computed: {
        categories() {
            return this.commonData['raw_data'];
        },
        subcategories() {
            if (this.selectedCategory) {
                return this.commonData['category_' + this.selectedCategory].subcategories;
            }
            return [];
        },
        selectedCategoryName() {
            if (this.selectedCategory) {
                return this.commonData['category_' + this.selectedCategory].name;
            }
            return '';
        },
        selectedSubcategoryName() {
            if (this.selectedSubcategory) {
                return this.commonData['subcategory_' + this.selectedSubcategory].name;
            }
            return '';
        }
    },
    created() {
        this.ConvertData(data_categories);
    },
    methods: {
        ConvertData: function (data) {
            let result = {};
            result["raw_data"] = data;
            data.forEach(category => {
                result["category_" + category.name] = category; 
                category.subcategories.forEach(subcategory => {
                    result["subcategory_" + subcategory.name] = subcategory; 
                });
            });
            this.commonData = result;
        },
    },
    getCategoryName(categoryId) {
        return this.commonData['category_' + categoryId]?.name || '';
    },
    getSubcategoryName(subcategoryId) {
        return this.commonData['subcategory_' + subcategoryId]?.name || '';
    }
});
app.mount('#vue-wrapper');

