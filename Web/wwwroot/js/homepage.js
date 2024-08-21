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
