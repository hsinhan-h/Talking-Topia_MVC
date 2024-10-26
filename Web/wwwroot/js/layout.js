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

//document.addEventListener('DOMContentLoaded', function () {
//    const firstColumnLinks = document.querySelectorAll('.first-column a');
//    const secondColumn = document.querySelector('.second-column');
//    //const thirdColumn = document.querySelector('.third-column');
//    const subMenus = document.querySelectorAll('.second-column .sub-menu');

//    firstColumnLinks.forEach(link => {
//        link.addEventListener('mouseenter', function () {
//            // 隱藏所有的子選單
//            subMenus.forEach(subMenu => {
//                subMenu.style.display = 'none';
//            });

//            // 顯示與此 link 對應的子選單
//            const targetMenu = document.querySelector(`.second-column .${this.dataset.target}`);
//            if (targetMenu) {
//                targetMenu.style.display = 'block';
//            }

//            // 顯示第二欄和第三欄
//            secondColumn.style.display = 'block';
//            /*thirdColumn.style.display = 'block';*/
//        });
//    });

//    // 當滑鼠移出第一欄時隱藏第二、第三欄
//    const firstColumn = document.querySelector('.first-column');
//    firstColumn.addEventListener('mouseleave', function () {
//        secondColumn.style.display = 'none';
//    //    thirdColumn.style.display = 'none';
//    });

//     //讓第二、第三欄不會在滑鼠移到其他地方時消失
//    secondColumn.addEventListener('mouseenter', function () {
//        secondColumn.style.display = 'block';
//    //    thirdColumn.style.display = 'block';
//    });

//    //thirdColumn.addEventListener('mouseenter', function () {
//    //    secondColumn.style.display = 'block';
//    //    thirdColumn.style.display = 'block';
//    //});

//    secondColumn.addEventListener('mouseleave', function () {
//        secondColumn.style.display = 'none';
//    //    thirdColumn.style.display = 'none';
//    });

//    //thirdColumn.addEventListener('mouseleave', function () {
//    //    secondColumn.style.display = 'none';
//    //    thirdColumn.style.display = 'none';
//    });




document.addEventListener('DOMContentLoaded', function () {
    const firstColumnLinks = document.querySelectorAll('.first-column a');
    const secondColumn = document.querySelector('.second-column');
    const subMenus = document.querySelectorAll('.second-column .sub-menu');

    // 初始化時隱藏所有子選單和第二欄
    subMenus.forEach(subMenu => {
        subMenu.style.display = 'none';
    });
    secondColumn.style.display = 'none';

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

            // 顯示第二欄
            secondColumn.style.display = 'block';
        });
    });

    // 當滑鼠移出第一欄時隱藏第二欄
    const firstColumn = document.querySelector('.first-column');
    firstColumn.addEventListener('mouseleave', function () {
        secondColumn.style.display = 'none';
    });

    //讓第二欄不會在滑鼠移到其他地方時消失
    secondColumn.addEventListener('mouseenter', function () {
        secondColumn.style.display = 'block';
    });

    secondColumn.addEventListener('mouseleave', function () {
        secondColumn.style.display = 'none';
    });
});

//Search
$(document).ready(function () {
    $('#difysearch').on('submit', function (e) {
        e.preventDefault(); // 防止表單的預設提交

        var query = $('#courseSearchInput').val();

        $.ajax({
            url: '/Search/Index',
            type: 'GET',
            data: { query: query },
            success: function (response) {
                if (response.success) {
                    // 如果成功，使用返回的 redirectUrl 進行跳轉
                    window.location.href = response.redirectUrl;
                } else {
                    // 如果找不到資料，顯示“無資料”
                    $('.second-column').html('<p class="text-muted">' + response.message + '</p>');
                }
            },
            error: function () {
                $('.second-column').html('<p class="text-muted">搜尋時出現錯誤，請稍後再試</p>');
            }
        });
    });
});

//$(document).ready(function () {
//    // 防抖函數，延遲 500 毫秒後才執行搜尋提交
//    function debounce(func, delay) {
//        let timer;
//        return function (...args) {
//            clearTimeout(timer);
//            timer = setTimeout(() => func.apply(this, args), delay);
//        };
//    }

//    // 在搜尋輸入框上使用防抖函數，監聽 input 事件
//    $('#courseSearchInput').on('input', debounce(function () {
//        // 自動提交表單或進行 AJAX 請求
//        $('#difysearch').submit();
//    }, 500));
//});

