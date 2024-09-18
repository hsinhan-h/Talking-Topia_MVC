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

    const profileData = {
        Account: document.getElementById('floatingInput7').value,
        LastName: document.getElementById('floatingInput8').value,
        FirstName: document.getElementById('floatingInput9').value,
        Nickname: document.getElementById('floatingInput1').value,
        Gender: document.getElementById('floatingInput3').value,
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
                // 禁用所有輸入欄位和選框
                toggleEditMode();
            } else {
                alert('儲存失敗，請重試。錯誤原因: ' + response.message + '\n' + (response.exception || ''));
            }
        },
        error: function (xhr, status, error) {
            alert('儲存過程中出現錯誤，請稍後再試。錯誤訊息: ' + xhr.responseText);
        }
    });
    // 隱藏「儲存」和「取消」按鈕，顯示「編輯」按鈕
    document.querySelector('input[data-action="save"]').parentElement.classList.add('d-none');
    document.querySelector('input[data-action="cancel"]').parentElement.classList.add('d-none');
    document.querySelector('input[data-action="edit"]').parentElement.classList.remove('d-none');
}

function collectCoursePreferences() {
    const selectedCourses = [];
    document.querySelectorAll('input[type="checkbox"]:checked').forEach(input => {
        selectedCourses.push({ SubjectName: input.value });
    });
    return selectedCourses;
}


function toggleEditMode() {
    const inputs = document.querySelectorAll('#app input.form-control');
    const checkboxes = document.querySelectorAll('#app input[type="checkbox"]');

    inputs.forEach(input => {
        input.disabled = !input.disabled;
    });
    checkboxes.forEach(checkbox => {
        checkbox.disabled = !checkbox.disabled;
    });

    const editButton = document.querySelector('input[data-action="edit"]');
    const saveButton = document.querySelector('input[data-action="save"]');
    const cancelButton = document.querySelector('input[data-action="cancel"]');

    if (editButton.classList.contains('d-none')) {
        saveButton.parentElement.classList.add('d-none');
        cancelButton.parentElement.classList.add('d-none');
        editButton.parentElement.classList.remove('d-none');
    } else {
        editButton.parentElement.classList.add('d-none');
        saveButton.parentElement.classList.remove('d-none');
        cancelButton.parentElement.classList.remove('d-none');
    }
}




