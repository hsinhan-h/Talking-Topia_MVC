const { createApp } = Vue;
const apptutorindex = createApp({
    data: function () {
        return {
            selectedLanguage: '英文',
            hoursRate: '76,156',
            hoursRate_md: '76,156',

            items: [
                {
                    language: '英文',
                    title: '【線上英文老師】- 英文新進!',
                    salaryRange: '自訂時薪範圍：NT$96 - NT$3,200 / 時',
                    description: '有英文考試、英文教學、曾是英文教師、私人家教經驗佳。'
                },
                {
                    language: '英文',
                    title: '【線上兒童美語 (4-11)老師】- New!',
                    salaryRange: '自訂時薪範圍：NT$96 - NT$2,765 / 時',
                    description: '有兒童美語 (4-11)考試、兒童美語 (4-11)教學、曾是兒童美語 (4-11)教師、私人家教、業界講師經驗佳。'
                },
                {
                    language: '英文',
                    title: '【線上英文會話老師】- New!',
                    salaryRange: '自訂時薪範圍：NT$96 - NT$3,200 / 時',
                    description: '有英文會話考試、英文會話教學、曾是英文會話教師、私人家教、業界講師經驗佳。'
                },
                {
                    language: '英文',
                    title: '【線上英文口說老師】- New!',
                    salaryRange: '自訂時薪範圍：NT$96 - NT$1,532 / 時',
                    description: '有旅遊英文考試、旅遊英文教學、曾是旅遊英文教師、私人家教、業界講師經驗佳。'
                },
                {
                    language: '英文',
                    title: '【線上幼兒英文 (3-5)老師】- New!',
                    salaryRange: '自訂時薪範圍：NT$96 - NT$2,074 / 時',
                    description: '有幼兒英文 (3-5)考試、幼兒英文 (3-5)教學、曾是幼兒英文 (3-5)教師、私人家教、業界講師經驗佳。'
                },
                //日文
                {
                    language: '日文',
                    title: '【線上日文老師】- 日文新進!',
                    salaryRange: '自訂時薪範圍：NT$96 - NT$2,560 / 時',
                    description: '有日文考試、日文教學、曾是日文教師、私人家教經驗佳。'
                },
                {
                    language: '日文',
                    title: '【線上日文會話老師】- New!',
                    salaryRange: '自訂時薪範圍：NT$96 - NT$1,536 / 時',
                    description: '有日文會話考試、日文會話教學、曾是日文會話教師、私人家教、業界講師經驗佳。'
                },
                {
                    language: '日文',
                    title: '【線上入門日文老師】- New!',
                    salaryRange: '自訂時薪範圍：NT$120 - NT$1,805 / 時',
                    description: '有入門日文考試、入門日文教學、曾是入門日文教師、私人家教、業界講師經驗佳。'
                },
                {
                    language: '日文',
                    title: '【線上日文考試老師】- New!',
                    salaryRange: '自訂時薪範圍：NT$160 - NT$1,152 / 時',
                    description: '有日文考試考試、日文考試教學、曾是日文考試教師、私人家教、業界講師經驗佳。'
                },
                {
                    language: '日文',
                    title: '【線上日文口說老師】- New!',
                    salaryRange: '自訂時薪範圍：NT$96 - NT$2,560 / 時',
                    description: '有日文口說考試、日文口說教學、曾是日文口說教師、私人家教、業界講師經驗佳。'
                },
                //中文
                {
                    language: '中文',
                    title: '【線上中文老師】- New!',
                    salaryRange: '自訂時薪範圍：NT$96 - NT$3,200 / 時',
                    description: '有中文考試、中文教學、曾是中文教師、私人家教經驗佳。'
                },
                {
                    language: '中文',
                    title: '【線上中文口說老師】- New!',
                    salaryRange: '自訂時薪範圍：NT$136 - NT$3,200 / 時',
                    description: '有中文口說考試、中文口說教學、曾是中文口說教師、私人家教、業界講師經驗佳。'
                },
                {
                    language: '中文',
                    title: '【線上入門日文老師】- New!',
                    salaryRange: '自訂時薪範圍：NT$96 - NT$1,728 / 時',
                    description: '有中文會話考試、中文會話教學、曾是中文會話教師、私人家教、業界講師經驗佳。'
                },
                {
                    language: '中文',
                    title: '【線上幼兒中文 (3-5)老師】- New!',
                    salaryRange: '自訂時薪範圍：NT$96 - NT$2,560 / 時',
                    description: '有幼兒中文 (3-5)考試、幼兒中文 (3-5)教學、曾是幼兒中文 (3-5)教師、私人家教、業界講師經驗佳。'
                },
                {
                    language: '中文',
                    title: '【線上成人中文老師】- New!',
                    salaryRange: '自訂時薪範圍：NT$96 - NT$1,350 / 時',
                    description: '有成人中文考試、成人中文教學、曾是成人中文教師、私人家教、業界講師經驗佳。'
                },
                //法文
                {
                    language: '法文',
                    title: '【線上法文老師】- New!',
                    salaryRange: '自訂時薪範圍：NT$96 - NT$1,934 / 時',
                    description: '有法文考試、法文教學、曾是法文教師、私人家教經驗佳。'
                },
                {
                    language: '法文',
                    title: '【線上法文會話老師】- New!',
                    salaryRange: '自訂時薪範圍：NT$96 - NT$1,934 / 時',
                    description: '有法文會話考試、法文會話教學、曾是法文會話教師、私人家教、業界講師經驗佳。'
                },
                {
                    language: '法文',
                    title: '【線上基礎法文老師】- New!',
                    salaryRange: '自訂時薪範圍：NT$136 - NT$1,411 / 時',
                    description: '有基礎法文考試、基礎法文教學、曾是基礎法文教師、私人家教、業界講師經驗佳。'
                },
                {
                    language: '法文',
                    title: '【線上法文考試老師】- New!',
                    salaryRange: '自訂時薪範圍：NT$160 - NT$1,440 / 時',
                    description: '有法文考試考試、法文考試教學、曾是法文考試教師、私人家教、業界講師經驗佳。'
                },
                {
                    language: '法文',
                    title: '【線上法文口說老師】- New!',
                    salaryRange: '自訂時薪範圍：NT$144 - NT$1,504 / 時',
                    description: '有法文口說考試、法文口說教學、曾是法文口說教師、私人家教、業界講師經驗佳。'
                },
                //西班牙
                {
                    language: '西班牙',
                    title: '【線上西班牙老師】- New!',
                    salaryRange: '自訂時薪範圍：NT$96 - NT$1,934 / 時',
                    description: '有西班牙考試、西班牙教學、曾是西班牙教師、私人家教經驗佳。'
                },
                {
                    language: '西班牙',
                    title: '【線上西班牙會話老師】- New!',
                    salaryRange: '自訂時薪範圍：NT$96 - NT$1,934 / 時',
                    description: '有西班牙會話考試、西班牙會話教學、曾是西班牙會話教師、私人家教、業界講師經驗佳。'
                },
                {
                    language: '西班牙',
                    title: '【線上基礎西班牙老師】- New!',
                    salaryRange: '自訂時薪範圍：NT$136 - NT$1,411 / 時',
                    description: '有基礎西班牙考試、基礎西班牙教學、曾是基礎西班牙教師、私人家教、業界講師經驗佳。'
                },
                {
                    language: '西班牙',
                    title: '【線上西班牙考試老師】- New!',
                    salaryRange: '自訂時薪範圍：NT$160 - NT$1,440 / 時',
                    description: '有西班牙考試考試、西班牙考試教學、曾是西班牙考試教師、私人家教、業界講師經驗佳。'
                },
                {
                    language: '西班牙',
                    title: '【線上西班牙口說老師】- New!',
                    salaryRange: '自訂時薪範圍：NT$144 - NT$1,504 / 時',
                    description: '有西班牙口說考試、西班牙口說教學、曾是西班牙口說教師、私人家教、業界講師經驗佳。'
                },
                //德文
                {
                    language: '德文',
                    title: '【線上德文老師】- New!',
                    salaryRange: '自訂時薪範圍：NT$96 - NT$1,934 / 時',
                    description: '有德文考試、德文教學、曾是德文教師、私人家教經驗佳。'
                },
                {
                    language: '德文',
                    title: '【線上德文會話老師】- New!',
                    salaryRange: '自訂時薪範圍：NT$96 - NT$1,934 / 時',
                    description: '有德文會話考試、德文會話教學、曾是德文會話教師、私人家教、業界講師經驗佳。'
                },
                {
                    language: '德文',
                    title: '【線上基礎德文老師】- New!',
                    salaryRange: '自訂時薪範圍：NT$136 - NT$1,411 / 時',
                    description: '有基礎德文考試、基礎德文教學、曾是基礎德文教師、私人家教、業界講師經驗佳。'
                },
                {
                    language: '德文',
                    title: '【線上德文考試老師】- New!',
                    salaryRange: '自訂時薪範圍：NT$160 - NT$1,440 / 時',
                    description: '有德文考試考試、德文考試教學、曾是德文考試教師、私人家教、業界講師經驗佳。'
                },
                {
                    language: '德文',
                    title: '【線上德文口說老師】- New!',
                    salaryRange: '自訂時薪範圍：NT$144 - NT$1,504 / 時',
                    description: '有德文口說考試、德文口說教學、曾是德文口說教師、私人家教、業界講師經驗佳。'
                },
            ]
        }
    },
    computed: {
        filteredItems() {
            return this.items.filter(x => x.language === this.selectedLanguage);
        }
    },
    methods: {
        changeLanguage(language) {
            this.selectedLanguage = language;
        },

        handleRateChange(e) {
            const selectchange = e.target.value;
            if (selectchange === "40") {
                this.hoursRate = "76,156"
            }
            else if (selectchange === "20") {
                this.hoursRate = "38,078"
            }
            else if (selectchange === "10") {
                this.hoursRate = "19,039"
            }
        },
        handleRateChange_md(e) {
            const selectchange = e.target.value;
            if (selectchange === "40") {
                this.hoursRate_md = "76,156"
            }
            else if (selectchange === "20") {
                this.hoursRate_md = "38,078"
            }
            else if (selectchange === "10") {
                this.hoursRate_md = "19,039"
            }
        },
        scrollToTop() {
            window.scrollTo({
                top: 0,
                behavior: 'smooth', 
            });
        },
    }
})
apptutorindex.mount("#vue_card");//綁定哪個屬性