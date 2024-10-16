$(document).ready(function () {
    // Email 即時驗證
    $('#emailInput').on('input', function () {
        let emailValue = $(this).val();
        if (emailValue.trim() === '') {
            $('#emailError').text('電子郵件是必填的');
        } else {
            $('#emailError').text('');
        }
    });

    // 密碼即時驗證
    $('#passwordInput').on('input', function () {
        let passwordValue = $(this).val();
        if (passwordValue.trim() === '') {
            $('#passwordError').text('密碼是必填的');
        } else {
            $('#passwordError').text('');
        }
    });

    // 表單提交前驗證
    $('#loginForm').on('submit', function (e) {
        let emailValue = $('#emailInput').val().trim();
        let passwordValue = $('#passwordInput').val().trim();
        let isValid = true;

        if (emailValue === '') {
            $('#emailError').text('電子郵件是必填的');
            isValid = false;
        }

        if (passwordValue === '') {
            $('#passwordError').text('密碼是必填的');
            isValid = false;
        }

        if (!isValid) {
            e.preventDefault(); // 阻止表單提交
        }
    });
});