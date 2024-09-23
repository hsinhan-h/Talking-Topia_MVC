document.addEventListener('DOMContentLoaded', function () {
    const taxIdCheckbox = document.getElementById('taxIdCheckBox');
    const taxIdInput = document.getElementById('taxIdInput');
    const form = document.getElementById('shopping-cart-submit-btn');
    const taxIdNumberInput = document.querySelector('input[name="taxIdNumber"]');

});

function updateSubtotalByTime(priceFor25Minutes, priceFor50Minutes, index) {

    const selectedTime = parseInt(document.getElementById("timeSelect-" + index).value);
    const quantity = parseInt(document.getElementById("lh-sc-quantitySelect-" + index).value);

    if (isNaN(selectedTime) || isNaN(quantity) || quantity <= 0) {
        document.getElementById("subtotal-" + index).innerText = "NT$0";
        let discount = subtotal * 0.1;
        document.getElementById("discount-info-" + index).innerText = "省NT$0";
        return;
    }

    let selectedPrice = (selectedTime === 50) ? priceFor50Minutes : priceFor25Minutes;
    let subtotal = quantity * selectedPrice;
    let discount = subtotal * 0.1;

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

form.addEventListener('submit', function (event) {
    if (taxIdCheckbox.checked) {
        taxIdNumberInput.value = taxIdInput.value;
    } else {
        taxIdNumberInput.value = '';
    }

    updateTotalAmount();

    const totalAmount = document.getElementById("total-amount").innerText.replace(/[^\d]/g, ''); // 取得總金額
    const totalAmountInput = document.querySelector('input[name="totalAmount"]');
    totalAmountInput.value = totalAmount;

    const quantities = document.querySelectorAll("[id^='lh-sc-quantitySelect-']");
    let times = document.querySelectorAll("[id^='timeSelect-']");

    quantities.forEach(function (quantity, index) {
        const hiddenQuantityInput = document.createElement("input");
        hiddenQuantityInput.type = "hidden";
        hiddenQuantityInput.name = "Items[" + index + "].Quantity";
        hiddenQuantityInput.value = quantity.value;
        form.appendChild(hiddenQuantityInput);
    });

    times.forEach(function (time, index) {
        const hiddenTimeInput = document.createElement("input");
        hiddenTimeInput.type = "hidden";
        hiddenTimeInput.name = "Items[" + index + "].Time";
        hiddenTimeInput.value = time.value;
        form.appendChild(hiddenTimeInput);
    });

});

function updateCartItem(courseId, selectedTime, quantity, subtotal) {
    let cartItemUpdate = {
        CourseId: courseId,
        CourseQuantity: quantity,
        CourseLength: selectedTime,
        SubtotalNTD: subtotal
    };

    fetch('/ShoppingCart/Updat', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(cartItemUpdate)
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok ' + response.statusText);
            }
            return response.json();
        })
        .then(data => {
            console.log("Cart item updated successfully:", data);
        })
        .catch(error => {
            console.error("Error updating cart item:", error);
        });
}