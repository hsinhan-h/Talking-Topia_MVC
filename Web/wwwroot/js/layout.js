// 螢幕寬度小於767px時對應變化
function moveUserItem() {
    const screenWidth = window.innerWidth;
    const userItem = document.querySelector('.user-item');
    const navbarNav = document.querySelector('.navbar-nav');

    if (screenWidth <= 767) {
        // 如果螢幕寬度小於等於 767px，將 user-item 移動到 navbar-nav 的最前面
        if (userItem && navbarNav) {
            navbarNav.insertBefore(userItem, navbarNav.firstChild);
        }
    } else {
        // 如果螢幕寬度大於 767px，將 user-item 移動回 ms-auto 的最後面
        const navbarNavAuto = document.querySelector('.navbar-nav.ms-auto');
        if (userItem && navbarNavAuto) {
            navbarNavAuto.appendChild(userItem);
        }
    }
}


//選擇課程選單

document.addEventListener('DOMContentLoaded', function () {
    const firstColumnLinks = document.querySelectorAll('.first-column a');
    const secondColumn = document.querySelector('.second-column');
    const thirdColumn = document.querySelector('.third-column');
    const subMenus = document.querySelectorAll('.second-column .sub-menu');

    firstColumnLinks.forEach(link => {
        link.addEventListener('mouseenter', function () {
            // 隱藏所有的子選單
            subMenus.forEach(subMenu => {
                subMenu.style.display = 'none';
            });

            // 顯示與此 link 對應的子選單
            const targetMenu = document.querySelector(`.second-column .${this.dataset.target}`);
            if (targetMenu) {
                targetMenu.style.display = 'block';
            }

            // 顯示第二欄和第三欄
            secondColumn.style.display = 'block';
            thirdColumn.style.display = 'block';
        });
    });

    // 當滑鼠移出第一欄時隱藏第二、第三欄
    const firstColumn = document.querySelector('.first-column');
    firstColumn.addEventListener('mouseleave', function () {
        secondColumn.style.display = 'none';
        thirdColumn.style.display = 'none';
    });

    // 讓第二、第三欄不會在滑鼠移到其他地方時消失
    secondColumn.addEventListener('mouseenter', function () {
        secondColumn.style.display = 'block';
        thirdColumn.style.display = 'block';
    });

    thirdColumn.addEventListener('mouseenter', function () {
        secondColumn.style.display = 'block';
        thirdColumn.style.display = 'block';
    });

    secondColumn.addEventListener('mouseleave', function () {
        secondColumn.style.display = 'none';
        thirdColumn.style.display = 'none';
    });

    thirdColumn.addEventListener('mouseleave', function () {
        secondColumn.style.display = 'none';
        thirdColumn.style.display = 'none';
    });
});


//登入註冊判斷
document.getElementById('registerForm').addEventListener('submit', function (event) {
    event.preventDefault(); // 防止表單提交

    // 取得欄位
    const name = document.getElementById('name').value.trim();
    const email = document.getElementById('email').value.trim();
    const password = document.getElementById('password').value.trim();
    const confirmPassword = document.getElementById('confirmPassword').value.trim();

    // 取得錯誤訊息元素
    const nameError = document.getElementById('nameError');
    const emailError = document.getElementById('emailError');
    const passwordError = document.getElementById('passwordError');
    const confirmPasswordError = document.getElementById('confirmPasswordError');

    let isValid = true;

    // 檢查名字是否為空
    if (name === '') {
        nameError.style.display = 'block';
        isValid = false;
    } else {
        nameError.style.display = 'none';
    }

    // 檢查信箱是否為空
    if (email === '') {
        emailError.style.display = 'block';
        isValid = false;
    } else {
        emailError.style.display = 'none';
    }

    // 檢查密碼是否為空
    if (password === '') {
        passwordError.style.display = 'block';
        isValid = false;
    } else {
        passwordError.style.display = 'none';
    }

    // 檢查確認密碼是否為空
    if (confirmPassword === '') {
        confirmPasswordError.style.display = 'block';
        isValid = false;
    } else {
        confirmPasswordError.style.display = 'none';
    }

    // 如果所有欄位都有效，執行下一步操作（例如表單提交或其他邏輯）
    if (isValid) {
        // 可以在此處執行註冊的邏輯
        alert('表單已成功提交！');
    }
});





