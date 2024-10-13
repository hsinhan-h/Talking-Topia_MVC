//密碼修改
function submitPasswordChange() {
    let currentPassword = document.getElementById('currentPasswordInput').value;
    let newPassword = document.getElementById('newPasswordInput').value;
    let confirmPassword = document.getElementById('confirmPasswordInput').value;

    if (newPassword !== confirmPassword) {
        showToast("新密碼與確認密碼不相符");
        return;
    }

    // 呼叫後端 API 來修改密碼
    let requestData = {
        currentPassword: currentPassword,
        newPassword: newPassword,
        confirmNewPassword: confirmPassword  // 確保這裡包含確認密碼
    };

    fetch('/Member/ChangePassword', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(requestData)
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            if (data.success) {
                showToast('成功', '密碼修改成功');
                setTimeout(() => window.location.reload(), 2000); // 重新載入頁面
            } else {
                showToast('錯誤', data.message);
            }
        })
        .catch((error) => {
            console.error('Error:', error);
            showToast('錯誤', '密碼修改失敗，請稍後再試');
        });
}



//function saveProfileData() {
//    event.preventDefault();

//    const gender = document.querySelector('input[name="gender"]:checked').value;

//    const profileData = {
//        Account: document.getElementById('floatingInput7').value,
//        LastName: document.getElementById('floatingInput9').value,
//        FirstName: document.getElementById('floatingInput8').value,
//        Nickname: document.getElementById('floatingInput1').value,
//        Gender: gender.toString(),  // 將性別值轉換為字串 "1" 或 "2"
//        Birthday: document.getElementById('floatingInput2').value,
//        Email: document.getElementById('floatingInput10').value,
//        Phone: document.getElementById('floatingInput11').value,
//        CoursePrefer: collectCoursePreferences()
//    };

//    $.ajax({
//        type: "POST",
//        url: '/Member/SaveProfile',
//        data: JSON.stringify(profileData),
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (response) {
//            if (response.success) {
//                alert('儲存成功！');
//                // 更新 Navbar 上的使用者名稱
//                document.getElementById('navbar-username').textContent = 'Hi! ' + profileData.FirstName;

//                // 切換按鈕顯示狀態
//                const editButton = document.getElementById('edit-button');
//                const saveButton = document.getElementById('save-button');
//                const cancelButton = document.getElementById('cancel-button');

//                editButton.classList.remove('d-none');
//                saveButton.classList.add('d-none');
//                cancelButton.classList.add('d-none');

//                // 禁用所有表單元素
//                const inputs = document.querySelectorAll('#app input.form-control');
//                const checkboxes = document.querySelectorAll('#app input[type="checkbox"]');
//                const radioButtons = document.querySelectorAll('#app input[type="radio"]');

//                inputs.forEach(input => {
//                    input.disabled = true;
//                });

//                checkboxes.forEach(checkbox => {
//                    checkbox.disabled = true;
//                });

//                radioButtons.forEach(radio => {
//                    radio.disabled = true;
//                });
//            } else {
//                alert('儲存失敗，請重試。錯誤原因: ' + response.message + '\n' + (response.exception || ''));
//            }
//        },
//        error: function (xhr, status, error) {
//            alert('儲存過程中出現錯誤，請稍後再試。錯誤訊息: ' + xhr.responseText);
//        }
//    });
//}


function saveProfileData() {
    event.preventDefault();

    const gender = document.querySelector('input[name="gender"]:checked').value;

    const profileData = {
        Account: document.getElementById('floatingInput7').value,
        LastName: document.getElementById('floatingInput9').value,
        FirstName: document.getElementById('floatingInput8').value,
        Nickname: document.getElementById('floatingInput1').value,
        Gender: gender.toString(),
        Birthday: document.getElementById('floatingInput2').value,
        Email: document.getElementById('floatingInput10').value,
        Phone: document.getElementById('floatingInput11').value,
        CoursePrefer: collectCoursePreferences()
    };

    $.ajax({
        type: "POST",
        url: '/Member/SaveProfile',
        data: JSON.stringify(profileData),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.success) {
                showToast("會員資料儲存", "儲存成功！");

                // 更新 Navbar 上的使用者名稱
                document.getElementById('navbar-username').textContent = 'Hi! ' + profileData.FirstName;

                // 切換按鈕顯示狀態
                const editButton = document.getElementById('edit-button');
                const saveButton = document.getElementById('save-button');
                const cancelButton = document.getElementById('cancel-button');

                editButton.classList.remove('d-none');
                saveButton.classList.add('d-none');
                cancelButton.classList.add('d-none');

                // 禁用所有表單元素
                const inputs = document.querySelectorAll('#app input.form-control');
                const checkboxes = document.querySelectorAll('#app input[type="checkbox"]');
                const radioButtons = document.querySelectorAll('#app input[type="radio"]');

                inputs.forEach(input => {
                    input.disabled = true;
                });

                checkboxes.forEach(checkbox => {
                    checkbox.disabled = true;
                });

                radioButtons.forEach(radio => {
                    radio.disabled = true;
                });
            } else {
                showToast("錯誤訊息", '儲存失敗，請重試。錯誤原因: ' + response.message + '\n' + (response.exception || ''));
            }
        },
        error: function (xhr, status, error) {
            showToast("錯誤訊息", '儲存過程中出現錯誤，請稍後再試。錯誤訊息: ' + xhr.responseText);
        }
    });
}

function collectCoursePreferences() {
    const selectedCourses = [];
    document.querySelectorAll('input[type="checkbox"]:checked').forEach(input => {
        selectedCourses.push({ SubjectName: input.value });
    });
    return selectedCourses;
}
//編輯
function toggleEditMode() {
    // 取得所有需要編輯的文字輸入欄位
    const inputs = document.querySelectorAll('#app input.form-control');

    // 取得所有的 checkbox 元素
    const checkboxes = document.querySelectorAll('#app input[type="checkbox"]');

    // 取得所有的 radio button 元素
    const radioButtons = document.querySelectorAll('#app input[type="radio"]');

    // 切換每個文字輸入欄位的 disabled 屬性
    inputs.forEach(input => {
        input.disabled = !input.disabled;
    });

    // 切換每個 checkbox 的 disabled 屬性
    checkboxes.forEach(checkbox => {
        checkbox.disabled = !checkbox.disabled;
    });

    // 切換每個 radio button 的 disabled 屬性
    radioButtons.forEach(radio => {
        radio.disabled = !radio.disabled;
    });

    // 取得按鈕
    const editButton = document.getElementById('edit-button');
    const saveButton = document.getElementById('save-button');
    const cancelButton = document.getElementById('cancel-button');

    // 檢查目前的狀態，然後切換顯示狀態
    if (editButton.classList.contains('d-none')) {
        // 如果編輯按鈕目前隱藏，則顯示它，並隱藏儲存和取消按鈕
        editButton.classList.remove('d-none');
        saveButton.classList.add('d-none');
        cancelButton.classList.add('d-none');
    } else {
        // 否則，隱藏編輯按鈕，並顯示儲存和取消按鈕
        editButton.classList.add('d-none');
        saveButton.classList.remove('d-none');
        cancelButton.classList.remove('d-none');
    }
}
//showToast
function showToast(header, message) {
    const toastElement = document.getElementById('toast');
    const toastHeader = toastElement.querySelector('.toast-header strong');
    const toastBody = toastElement.querySelector('.toast-body');

    // 設定 toast 標題和訊息
    toastHeader.textContent = header;
    toastBody.textContent = message;

    // 顯示 toast
    const toast = new bootstrap.Toast(toastElement);
    toast.show();
}

