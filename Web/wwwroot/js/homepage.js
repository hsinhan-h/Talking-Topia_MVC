document.getElementById('registerForm').addEventListener('submit', function (e) {
    let isValid = true;

    // ���ҦW�r
    const name = document.getElementById('name').value;
    if (name === '') {
        isValid = false;
        document.getElementById('nameError').style.display = 'block';
    } else {
        document.getElementById('nameError').style.display = 'none';
    }

    // ���ҫH�c
    const email = document.getElementById('registerEmail').value;
    if (email === '') {
        isValid = false;
        document.getElementById('emailError').style.display = 'block';
    } else {
        document.getElementById('emailError').style.display = 'none';
    }

    // �p�G���ҥ��ѡA�����洣��
    if (!isValid) {
        e.preventDefault();
    }
});
