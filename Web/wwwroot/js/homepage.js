document.getElementById('registerForm').addEventListener('submit', function (e) {
    let isValid = true;

    // 驗證名字
    const name = document.getElementById('name').value;
    if (name === '') {
        isValid = false;
        document.getElementById('nameError').style.display = 'block';
    } else {
        document.getElementById('nameError').style.display = 'none';
    }

    // 驗證信箱
    const email = document.getElementById('registerEmail').value;
    if (email === '') {
        isValid = false;
        document.getElementById('emailError').style.display = 'block';
    } else {
        document.getElementById('emailError').style.display = 'none';
    }

    // 如果驗證失敗，防止表單提交
    if (!isValid) {
        e.preventDefault();
    }
});
