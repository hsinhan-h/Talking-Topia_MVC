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
            licenses: [ // 正確初始化 licenses，加入 ID 欄位
                {
                    ProfessionalLicenseId: null,
                    ProfessionalLicenseName: '',
                    ProfessionalLicenseUrl: null
                }
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
                        ProfessionalLicenseName: name,
                        ProfessionalLicenseUrl: licenseList.professionalLicenseUrl[index] || null,
                        ProfessionalLicenseId: licenseList.professionalLicenseId[index]
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
            const newLicense = {
                ProfessionalLicenseName: '',
                ProfessionalLicenseUrl: null,
                ProfessionalLicenseId: null,
                valid: true// 初始化為 null，稍後設置
            };

            // 暫時添加到 licenses 列表中
            this.licenses.push(newLicense);

            // 假設後端有一個 API 可以用來生成新證照並返回新的 ProfessionalLicenseId
            fetch('/api/UpdateResume/CreateLicense', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    memberId: localStorage.getItem('memberId') // 假設 memberId 存在於 localStorage 中
                })
            })
                .then(response => response.json())
                .then(data => {
                    if (data.success) {
                        // 更新 licenses 列表中最新的證照物件，設置其 ProfessionalLicenseId
                        this.licenses[this.licenses.length - 1].ProfessionalLicenseId = data.professionalLicenseId;
                    } else {
                        alert('Failed to create license: ' + data.message);
                    }
                })
                .catch(error => {
                    console.error('Error creating license:', error);
                });
        },
        enditLcense(index) {
            const updatedLicense = this.licenses[index];
            const memberId = localStorage.getItem('memberId');

            // 使用 FormData 包裝文件和其他資料
            const formData = new FormData();
            formData.append('memberId', memberId);
            formData.append('ProfessionalLicenseId', updatedLicense.ProfessionalLicenseId); // 添加證照 ID
            formData.append('ProfessionalLicenseName', updatedLicense.ProfessionalLicenseName);

            // 檢查是否為文件，否則直接傳送 URL
            if (updatedLicense.ProfessionalLicenseUrl instanceof File) {
                formData.append('ProfessionalLicenseUrl', updatedLicense.ProfessionalLicenseUrl);
            } else {
                formData.append('ProfessionalLicenseUrl', updatedLicense.ProfessionalLicenseUrl);
            }

            fetch('/api/UpdateResume/UpdateResumeLicenses', {
                method: 'POST',
                body: formData, // 使用 FormData 發送
                // 注意：不需要顯式設置 Content-Type，瀏覽器會自動設置為 multipart/form-data
            })
                .then(response => response.json())
                .then(data => {
                    if (data.success) {
                        // 成功訊息
                        alert('License updated successfully');
                    } else {
                        // 失敗訊息
                        alert('Failed to update license:', data.message);
                    }
                })
                .catch(error => {
                    console.error('Error updating license:', error);
                });
        },
        removeLicense(index) {
            const licenseToRemove = this.licenses[index];

            // 檢查是否有 ProfessionalLicenseId，只有存在於資料庫中的項目才進行刪除操作
            if (licenseToRemove.ProfessionalLicenseId) {
                // 發送刪除請求到後端
                const memberId = localStorage.getItem('memberId'); // 假設 memberId 是存在本地存儲中
                fetch('/api/UpdateResume/DeleteLicense', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify({
                        memberId: memberId,
                        ProfessionalLicenseId: [licenseToRemove.ProfessionalLicenseId] // 包裝成數組發送
                    })
                })
                    .then(response => response.json())
                    .then(data => {
                        if (data.success) {
                            // 刪除成功，從 licenses 陣列中移除該項目
                            this.licenses.splice(index, 1);
                        } else {
                            alert('Failed to delete license: ' + data.message);
                        }
                    })
                    .catch(error => {
                        console.error('Error deleting license:', error);
                    });
            }
            else {
                // 如果沒有 ProfessionalLicenseId，只是刪除本地未儲存的證照
                this.licenses.splice(index, 1);
            }
        },
        handleFileUpload(event, index) {
            // 當用戶上傳文件時，更新文件數據
            const file = event.target.files[0];
            if (file) {
                // 可以直接將文件物件存儲在 ProfessionalLicenseUrl 中
                this.licenses[index].ProfessionalLicenseUrl = file;
            }
        },
        addWorkExperience() {
            //新增工作經驗欄位
            const newWorkExperience = {
                workName: '',
                workStartDate: '',
                workEndDate: '',
                workExperienceFile: null
                //valid: true// 初始化為 null，稍後設置
            };
                // 暫時添加到 licenses 列表中
            this.works.push(newWorkExperience);
                // 假設後端有一個 API 可以用來生成新證照並返回新的 WorkExperienceId
            fetch('/api/UpdateResume/CreateWorkExperience', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify({
                        memberId: localStorage.getItem('memberId') // 假設 memberId 存在於 localStorage 中
                    })
            })
                .then(response => response.json())
                .then(data => {
                        if (data.success) {
                            // 更新 licenses 列表中最新的證照物件，設置其 ProfessionalLicenseId
                            this.works[this.works.length - 1].WorkExperienceId = data.workExperienceId;
                        }
                        else {
                            alert('Failed to create license: ' + data.message);
                        }
                }).catch(error => {
                  console.error('Error creating license:', error);
                });
        },
        handleWorkFileUpload(event, index) {
            this.works[index].workExperienceFile = event.target.files[0];
        },

        // 移除工作經歷欄位
        removeWorkExperience(index) {
            this.works.splice(index, 1);
        },
        validateForm() {
            let formIsValid = true;
            this.showValidation = true;

            // 驗證每個證照的名稱是否填寫
            this.licenses.forEach(license => {
                if (!license.ProfessionalLicenseName) {
                    license.valid = false;
                    formIsValid = false;
                } else {
                    license.valid = true;
                }
            });

            // 如果表單有效，手動觸發提交
            if (formIsValid) {
                this.$refs.form.submit();  // 手動觸發表單提交
            }
        }
    },


});
app.mount('#vue-wrapper');
