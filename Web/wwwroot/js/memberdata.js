//密碼修改
function goToStep2() {
    const emailInput = document.getElementById('emailInput').value;  // 使用者輸入的電子信箱
    const existingEmail = document.getElementById('floatingInput10').value;  // 從資料庫中取出的電子信箱

    if (emailInput) {
        if (emailInput === existingEmail) {
            // 電子信箱匹配，隱藏第一步的模態框，顯示第二步的模態框
            const step1Modal = bootstrap.Modal.getInstance(document.getElementById('step1Modal'));
            if (step1Modal) {
                step1Modal.hide();  // 隱藏第一步模態框
            }

            const step2Modal = new bootstrap.Modal(document.getElementById('step2Modal'));
            step2Modal.show();  // 顯示第二步模態框
        } else {
            alert('輸入的電子信箱與會員記錄的不一致');
        }
    } else {
        alert('請輸入有效的電子信箱');
    }
}

function goToStep3() {
    const verificationCode = document.getElementById('verificationCodeInput').value;
    if (verificationCode) {
        // 處理驗證碼邏輯，顯示下一個模態框
        new bootstrap.Modal(document.getElementById('step3Modal')).show();
        new bootstrap.Modal(document.getElementById('step2Modal')).hide();
    } else {
        alert('請輸入驗證碼');
    }
}

function submitPasswordChange() {
    const newPassword = document.getElementById('newPasswordInput').value;
    const confirmPassword = document.getElementById('confirmPasswordInput').value;

    if (newPassword && confirmPassword && newPassword === confirmPassword) {
        // 處理新密碼邏輯
        alert('密碼修改成功');
        // 關閉模態框
        new bootstrap.Modal(document.getElementById('step3Modal')).hide();
    } else {
        alert('請確認兩次輸入的密碼相同');
    }
}

////編輯及儲存
//document.addEventListener("DOMContentLoaded", function () {
//    const editButton = document.querySelector('.btn[value="編輯"]');
//    const saveButton = document.querySelector('.btn[value="儲存"]');
//    const formFields = document.querySelectorAll('.form-control');
//    const checkboxes = document.querySelectorAll('.form-check-input');

//    // 當按下編輯按鈕時
//    editButton.addEventListener('click', function () {
//        formFields.forEach(field => field.disabled = false); // 解除 disabled
//        checkboxes.forEach(box => box.disabled = false); // 解除 checkbox 的 disabled
//        editButton.classList.add('d-none'); // 隱藏編輯按鈕
//        saveButton.parentElement.classList.remove('d-none'); // 顯示儲存按鈕
//    });

//    // 當按下儲存按鈕時
//    saveButton.addEventListener('click', function () {
//        // 這裡可以觸發保存資料的邏輯，例如提交表單到後端
//        document.querySelector('form').submit(); // 提交表單

//        formFields.forEach(field => field.disabled = true); // 再次鎖定字段
//        checkboxes.forEach(box => box.disabled = true); // 鎖定 checkbox
//        saveButton.parentElement.classList.add('d-none'); // 隱藏儲存按鈕
//        editButton.classList.remove('d-none'); // 顯示編輯按鈕
//    });
//});

function saveProfileData() {
    event.preventDefault();

    const gender = document.querySelector('input[name="gender"]:checked').value;

    const profileData = {
        Account: document.getElementById('floatingInput7').value,
        LastName: document.getElementById('floatingInput8').value,
        FirstName: document.getElementById('floatingInput9').value,
        Nickname: document.getElementById('floatingInput1').value,
        Gender: gender.toString(),  // 將性別值轉換為字串 "1" 或 "2"
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
                alert('儲存成功！');

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
                alert('儲存失敗，請重試。錯誤原因: ' + response.message + '\n' + (response.exception || ''));
            }
        },
        error: function (xhr, status, error) {
            alert('儲存過程中出現錯誤，請稍後再試。錯誤訊息: ' + xhr.responseText);
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

    // 切換按鈕的顯示狀態
    if (editButton.classList.contains('d-none')) {
        editButton.classList.remove('d-none');
        saveButton.classList.add('d-none');
        cancelButton.classList.add('d-none');
    } else {
        editButton.classList.add('d-none');
        saveButton.classList.remove('d-none');
        cancelButton.classList.remove('d-none');
    }
}

