document.addEventListener('DOMContentLoaded', function () {
    const paymentCards = document.querySelectorAll('.card-payment');  // 付款方式卡片
    const taxIdCheckbox = document.getElementById('flexCheckDefault'); // 統一發票選項
    const taxIdInput = document.getElementById('inputEmail4'); // 統一編號輸入框
    const submitBtn = document.getElementById('shopping-cart-submit-btn'); // 提交按鈕
    let selectedPayment = null; // 儲存選擇的付款方式

    // 監聽付款方式卡片點擊事件
    paymentCards.forEach(function (card) {
        card.addEventListener('click', function () {
            // 移除所有卡片的選取樣式
            paymentCards.forEach(c => c.classList.remove('selected'));

            // 為當前選中的卡片添加選取樣式
            card.classList.add('selected');

            // 設定選中的付款方式
            selectedPayment = card.getAttribute('data-payment');

            // 更新asp-route的paymentType參數
            submitBtn.setAttribute('asp-route-paymentType', selectedPayment);
        });
    });

    // 監聽提交表單的點擊事件
    submitBtn.addEventListener('click', function () {
        // 檢查是否勾選了 "需開立統一編號發票"
        if (taxIdCheckbox.checked) {
            // 如果勾選了，將統一編號填入 asp-route-taxIdNumber
            submitBtn.setAttribute('asp-route-taxIdNumber', taxIdInput.value);
        } else {
            // 否則清空 taxIdNumber 的路由參數
            submitBtn.setAttribute('asp-route-taxIdNumber', '');
        }
    });
});
