document.addEventListener('DOMContentLoaded', function () {
    const paymentCards = document.querySelectorAll('.card-payment');  // 付款方式卡片
    const taxIdCheckbox = document.getElementById('flexCheckDefault'); // 統一發票選項
    const taxIdInput = document.getElementById('inputEmail4'); // 統一編號輸入框
    const submitBtn = document.getElementById('shopping-cart-submit-btn'); // 表單提交按鈕

    // 隱藏的輸入框，用來動態更新數據
    const paymentTypeInput = document.querySelector('input[name="paymentType"]');
    const taxIdNumberInput = document.querySelector('input[name="taxIdNumber"]');

    let selectedPayment = null; // 用來儲存選擇的付款方式

    // 監聽付款方式卡片點擊事件
    paymentCards.forEach(function (card) {
        card.addEventListener('click', function () {
            // 移除其他卡片的選取樣式
            paymentCards.forEach(c => c.classList.remove('selected'));

            // 為當前選中的卡片添加選取樣式
            card.classList.add('selected');

            // 獲取選中的付款方式，並更新隱藏的 paymentType input
            selectedPayment = card.getAttribute('data-payment');
            paymentTypeInput.value = selectedPayment; // 更新隱藏的 input 值
        });
    });

    // 監聽提交表單事件
    submitBtn.addEventListener('submit', function (event) {
        // 在提交表單之前，檢查是否勾選了 "需開立統一編號發票"
        if (taxIdCheckbox.checked) {
            // 如果勾選了，將統一編號填入隱藏的 input
            taxIdNumberInput.value = taxIdInput.value;
        } else {
            // 如果沒有勾選，清空統一編號
            taxIdNumberInput.value = '';
        }

        // 如果沒有選擇付款方式，可以阻止提交
        if (!selectedPayment) {
            alert("請選擇一個付款方式");
            event.preventDefault(); // 阻止表單提交
        }
    });
});
