$(document).ready(function () {
    // 名字即時驗證
    $('#firstNameInput').on('input', function () {
        let firstNameValue = $(this).val();
        if (firstNameValue.trim() === '') {
            $('#firstNameError').text('名字是必填的');
        } else {
            $('#firstNameError').text('');
        }
    });

    // 姓氏即時驗證
    $('#lastNameInput').on('input', function () {
        let lastNameValue = $(this).val();
        if (lastNameValue.trim() === '') {
            $('#lastNameError').text('姓氏是必填的');
        } else {
            $('#lastNameError').text('');
        }
    });

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

    // 確認密碼即時驗證
    $('#confirmPasswordInput').on('input', function () {
        let confirmPasswordValue = $(this).val();
        if (confirmPasswordValue.trim() === '') {
            $('#confirmPasswordError').text('確認密碼是必填的');
        } else {
            $('#confirmPasswordError').text('');
        }
    });

    // 表單提交前驗證
    $('#registerForm').on('submit', function (e) {
        let isValid = true;

        if ($('#firstNameInput').val().trim() === '') {
            $('#firstNameError').text('名字是必填的');
            isValid = false;
        }

        if ($('#lastNameInput').val().trim() === '') {
            $('#lastNameError').text('姓氏是必填的');
            isValid = false;
        }

        if ($('#emailInput').val().trim() === '') {
            $('#emailError').text('信箱是必填的');
            isValid = false;
        }

        if ($('#passwordInput').val().trim() === '') {
            $('#passwordError').text('密碼是必填的');
            isValid = false;
        }

        if ($('#confirmPasswordInput').val().trim() === '') {
            $('#confirmPasswordError').text('確認密碼是必填的');
            isValid = false;
        }

        if (!isValid) {
            e.preventDefault(); // 阻止表單提交
        }
    });
});