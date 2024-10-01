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
const appresume = createApp({
    data() {
        return {
            selectedCategory: '', // 用來儲存選中的分類 ID
            selectedSubcategory: '', // 用來儲存選中的子分類 ID
            commonData: {}, // 用來存儲轉換過後的數據
            licenses: [ // 正確初始化 licenses，加入 ID 欄位
                {
                    ProfessionalLicenseId: null,
                    ProfessionalLicenseName: '',
                    ProfessionalLicenseUrl: null,
                }
            ],
            works: [ // 初始化一個空的工作經驗表單
                {
                    workName: '',
                    workStartDate: '',
                    workEndDate: '',
                    workExperienceFile: null,
                    workExperienceId: null,
                }
            ],
            formSubmitted: false,
            licensesUpdated: false,  // 用來標記證書是否已更新
            worksUpdated: false,
            selectedFile: null,   // 存儲選擇的文件
            headShotImage: headImage,
            headImageUpdated: false,
            editMode:false,
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
        this.loadHeadShotImage()
    },
    mounted() {
        this.fetchBackendData();
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
                            workExperienceFile: null,
                            workExperienceId: work.workExperienceId || null
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
                valid: false,  // 初始化時證書無效，需用戶填寫後更新為 true
                isTemporary: true // 初始化為暫存狀態
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
            formData.append('ProfessionalLicenseUrl',
                updatedLicense.ProfessionalLicenseUrl instanceof File
                    ? updatedLicense.ProfessionalLicenseUrl
                    : updatedLicense.ProfessionalLicenseUrl.toString()
            );
            console.log(updatedLicense)

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
                        this.licenses[index].isTemporary = false;
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
                        this.works[this.works.length - 1].workExperienceId = data.workExperienceId;
                    }
                    else {
                        alert('Failed to create license: ' + data.message);
                    }
                }).catch(error => {
                    console.error('Error creating license:', error);
                });
        },
        handleWorkFileUpload(event, index) {
            const file = event.target.files[0];
            if (file) {
                // 可以直接將文件物件存儲在 workExperienceUrl 中
                this.works[index].workExperienceFile = file;
            }
        },

        // 移除工作經歷欄位
        removeWorkExperience(index) {
            const workexpToRemove = this.works[index];

            if (workexpToRemove.workExperienceId) {
                const memberId = localStorage.getItem('memberId');
                fetch('/api/UpdateResume/DeleteWorkExp', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify({
                        memberId: memberId,
                        WorkBackground: [   // 傳遞需要刪除的工作經驗
                            {
                                WorkExperienceId: workexpToRemove.workExperienceId
                            }
                        ]
                    })
                })
                    .then(response => response.json())
                    .then(data => {
                        if (data.success) {
                            this.works.splice(index, 1);
                        } else {
                            alert('Failed to delete license: ' + data.message);
                        }
                    })
                    .catch(error => {
                        console.error('Error deleting license:', error);
                    });
            }
            else {
                this.works.splice(index, 1);
            }
        },
        editWorkExp(index) {
            const updatedworkexp = this.works[index];
            const memberId = localStorage.getItem('memberId');
            console.log(`Processing index: ${index}`);
            console.log('This is index 1:', updatedworkexp);


            // 使用 FormData 包裝文件和其他資料
            const formData = new FormData();
            formData.append('memberId', memberId);

            // 處理單個工作經驗的數據
            formData.append(`WorkBackground[0].WorkExperienceId`, updatedworkexp.workExperienceId);
            formData.append(`WorkBackground[0].WorkName`, updatedworkexp.workName || '');
            formData.append(`WorkBackground[0].WorkStartDate`, updatedworkexp.workStartDate || '');
            formData.append(`WorkBackground[0].WorkEndDate`, updatedworkexp.workEndDate || '');
            // 檢查是否為文件，否則直接傳送 URL
            if (updatedworkexp.workExperienceFile instanceof File) {
                formData.append(`WorkBackground[0].WorkExperienceFile`, updatedworkexp.workExperienceFile);
            } else if (updatedworkexp.workExperienceFile) {
                formData.append(`WorkBackground[0].WorkExperienceFile`, updatedworkexp.workExperienceFile.toString());
            } else {
                // 如果 WorkExperienceFile 是 null 或 undefined，傳遞空字串
                formData.append(`WorkBackground[0].WorkExperienceFile`, '');
            }

            // 發送 API 請求
            fetch('/api/UpdateResume/UpdateResumeWorkExp', {
                method: 'POST',
                body: formData,
            })
                .then(response => response.json())
                .then(data => {
                    if (data.success) {
                        // 成功訊息
                        alert('Work experience updated successfully');
                    } else {
                        // 失敗訊息
                        alert('Failed to update work experience: ' + data.message);
                    }
                })
                .catch(error => {
                    console.error('Error updating work experience:', error);
                });
        },
        confirmAllLicensesUpdates() {
            let updatesCompleted = true;

            this.licenses.forEach((license, index) => {
                if (license.ProfessionalLicenseName.trim() === '') {
                    license.valid = false;
                    updatesCompleted = false;  // 如果有無效的條目，則不允許提交
                } else {
                    this.enditLcense(index);  // 觸發更新
                    license.valid = true;
                }
            });

            if (updatesCompleted) {
                this.licensesUpdated = true;
                this.checkFormReady();  // 允許提交表單
                alert("所有證書已更新，您可以提交表單。");
            } else {
                alert("請先填寫所有必填字段。");
            }
        },
        confirmAllWorksUpdates() {
            this.works.forEach((work, index) => {
                this.editWorkExp(index);  // 觸發每個工作的更新邏輯
            });

            this.worksUpdated = true;  // 標記工作經驗已更新
            this.checkFormReady();  // 檢查是否可以提交表單
            alert("所有工作經驗已更新，您可以提交表單。");
        },
        checkFormReady() {
            if (this.licensesUpdated && this.worksUpdated && this.headImageUpdated) {
                this.formSubmitted = true;
            }
        },

        validateForm() {
            let formIsValid = true;
            this.showValidation = true;

            // 遍歷 this.licenses，過濾掉未填寫名稱的證照
            this.licenses.forEach((license, index) => {
                if (!license.ProfessionalLicenseName || license.ProfessionalLicenseName.trim() === '') {
                    license.valid = false;  // 無效的條目設置為 false
                    formIsValid = false;    // 表單無效
                } else {
                    license.valid = true;   // 有效的條目設置為 true
                }
            });

            // 手動移除無效的項目
            this.licenses = this.licenses.filter(license => !license.isTemporary || license.valid);
            // 如果表單有效，手動觸發提交
            if (formIsValid) {
                this.$refs.form.submit();  // 手動觸發表單提交
            }
        },
        onFileChange() {
            const HeadImage = this.selectedFile;
            const memberId = localStorage.getItem('memberId');
            this.headImageUpdated = true;
            this.checkFormReady();
            // 使用 FormData 包装文件和其他资料
            const formData = new FormData();
            formData.append('memberId', memberId);

            // 检查是否为文件，上传文件或传递 URL
            if (HeadImage instanceof File) {
                formData.append('HeadShotImage', HeadImage);
            } else if (HeadImage) {
                formData.append('HeadShotImage', HeadImage.toString());
            } else {
                formData.append('HeadShotImage', '');
            }

            fetch('/api/UpdateResume/UpdateHeadShotImage', {
                method: 'POST', 
                body: formData, 
            })
                .then(response => response.json())
                .then(data => {
                    if (data.success) {
                        alert('Profile picture updated successfully');
                        this.loadHeadShotImage();
                        
                    } else {
                        alert('Failed to update profile picture: ' + data.message);
                    }
                })
                .catch(error => {
                    console.error('Error updating profile picture:', error);
                });
            
            
        },
        HeadImgChange(event) {
            this.selectedFile = event.target.files[0];
        },
        loadHeadShotImage() {
            const memberId = localStorage.getItem('memberId');
            this.editMode = false; 
            fetch(`/api/UpdateResume/GetHeadShotImage?memberId=${memberId}`)
                .then(response => response.json())
                .then(data => {
                    if (data.success && data.headShotImage) {
                        this.headShotImage = data.headShotImage;
                        localStorage.setItem('headShotImage', data.headShotImage); 
                    } else {
                        this.headShotImage = '';
                    }
                })
                .catch(error => {
                    console.error(`Error fetching headshot image: ${error}`);
                });
        },
        toggleEditMode() {
            this.editMode = !this.editMode;  
        },
    },
});
appresume.mount('#vue-wrapper');
