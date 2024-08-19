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




//tab區塊在螢幕大小767px時, 需要有左右箭頭
document.addEventListener('DOMContentLoaded', function () {
    const tabWrapper = document.querySelector('.lh-layout-tabs');
    const leftArrow = document.querySelector('.lh-tab-arrow-left');
    const rightArrow = document.querySelector('.lh-tab-arrow-right');
    const tabWidth = tabWrapper.querySelector('.lh-layout-tab').offsetWidth + 25; // 25px 是每個tab之間的間距

    leftArrow.addEventListener('click', function () {
        tabWrapper.scrollBy({
            left: -tabWidth, // 左移一個標籤的寬度
            behavior: 'smooth'
        });
    });

    rightArrow.addEventListener('click', function () {
        tabWrapper.scrollBy({
            left: tabWidth, // 右移一個標籤的寬度
            behavior: 'smooth'
        });
    });
});




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


