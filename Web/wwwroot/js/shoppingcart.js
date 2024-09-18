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

function updateSubtotalByTime(priceFor25Minutes, priceFor50Minutes, index) {

    const selectedTime = parseInt(document.getElementById("timeSelect-" + index).value);
    const quantity = parseInt(document.getElementById("lh-sc-quantitySelect-" + index).value);

    if (isNaN(selectedTime) || isNaN(quantity) || quantity <= 0) {
        document.getElementById("subtotal-" + index).innerText = "NT$0";
        document.getElementById("discount-info-" + index).innerText = "省NT$0";
        return;
    }

    let selectedPrice = (selectedTime === 50) ? priceFor50Minutes : priceFor25Minutes;
    let subtotal = quantity * selectedPrice;

    //var originalPrice = quantity * priceFor25Minutes;
    //var discount = originalPrice - subtotal;
    
    document.getElementById("subtotal-" + index).innerText = "NT$" + subtotal.toLocaleString();
    document.getElementById("discount-info-" + index).innerText = "省NT$" + discount.toLocaleString();

    updateCartItem(courseId, selectedTime, quantity, subtotal);

    updateShoppingDetails(index, selectedTime, quantity, subtotal);
    updateTotalAmount();
}


function updateShoppingDetails(index, time, quantity, subtotal) {
    document.getElementById("details-time-" + index).innerText = time + " 分鐘";
    document.getElementById("details-quantity-" + index).innerText = quantity + " 堂";
    document.getElementById("details-subtotal-" + index).innerText = "NT$" + subtotal.toLocaleString();
}

function updateTotalAmount() {
    const subtotals = document.querySelectorAll("[id^='subtotal-']");
    let total = 0;

    subtotals.forEach(function (element) {
        let subtotal = parseInt(element.innerText.replace(/[^\d]/g, ''));
        total += isNaN(subtotal) ? 0 : subtotal;
    });

    document.getElementById("total-amount").innerText = "NT$" + total.toLocaleString();
}

submitBtn.addEventListener('submit', function (event) {
    if (taxIdCheckbox.checked) {
        taxIdNumberInput.value = taxIdInput.value;
    } else {
        taxIdNumberInput.value = '';
    }

    const quantities = document.querySelectorAll("[id^='lh-sc-quantitySelect-']");
    let times = document.querySelectorAll("[id^='timeSelect-']");

    quantities.forEach(function (quantity, index) {
        const hiddenQuantityInput = document.createElement("input");
        hiddenQuantityInput.type = "hidden";
        hiddenQuantityInput.name = "Items[" + index + "].Quantity";
        hiddenQuantityInput.value = quantity.value;
        submitBtn.appendChild(hiddenQuantityInput);
    });

    times.forEach(function (time, index) {
        // 更新隱藏欄位的時間
        const hiddenTimeInput = document.createElement("input");
        hiddenTimeInput.type = "hidden";
        hiddenTimeInput.name = "Items[" + index + "].Time";
        hiddenTimeInput.value = time.value;
        submitBtn.appendChild(hiddenTimeInput);
    });

    if (!selectedPayment) {
        alert("請選擇一個付款方式");
        event.preventDefault();
    }
});

function updateCartItem(courseId, selectedTime, quantity, subtotal) {
    let cartItemUpdate = {
        CourseId: courseId,
        CourseQuantity: quantity,
        CourseLength: selectedTime,
        SubtotalNTD: subtotal
    };

    $.ajax({
        url: '/ShoppingCart/UpdateCartItem',
        type: 'POST',
        data: JSON.stringify(cartItemUpdate),
        contentType: 'application/json',
        success: function (response) {
            console.log("Cart item updated successfully:", response);
        },
        error: function (xhr, status, error) {
            console.error("Error updating cart item:", error);
        }
    });
}





