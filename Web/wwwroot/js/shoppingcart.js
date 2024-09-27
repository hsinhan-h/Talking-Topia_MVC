document.addEventListener('DOMContentLoaded', function () {
    console.log(window.viewModelData.shoppingCartList);
    let selectLengthElements = document.querySelectorAll('[id^="lh-timeSelect-"]'); //select抓到的是option selected的值!!!
    let selectQuantityElements = document.querySelectorAll('[id^="lh-sc-quantitySelect-"]');
    const submitBtn = document.getElementById('shopping-cart-submit-btn');

    selectLengthElements.forEach(function (selectLength) {
        selectLength.addEventListener('change', function () {
            let dataIndex = this.getAttribute('data-index');
            let vmCourseLength = window.viewModelData.shoppingCartList[dataIndex].courseLength;
            let vmTFUnitPrice = window.viewModelData.shoppingCartList[dataIndex].tfUnitPrice;
            let vmFTUnitPrice = window.viewModelData.shoppingCartList[dataIndex].ftUnitPrice;
            let vmCourseQuantity = window.viewModelData.shoppingCartList[dataIndex].courseQuantity;

            if (this.value == vmTFUnitPrice) {
                window.viewModelData.shoppingCartList[dataIndex].unitPrice = this.value;
                window.viewModelData.shoppingCartList[dataIndex].courseLength = 25;
                updateTotalPrice(dataIndex, vmCourseQuantity, this.value);
            }
            else {
                window.viewModelData.shoppingCartList[dataIndex].unitPrice = this.value;
                window.viewModelData.shoppingCartList[dataIndex].courseLength = 50;
                updateTotalPrice(dataIndex, vmCourseQuantity, this.value);
            }
        });
    });

    selectQuantityElements.forEach(function (selectQuantity) {
        selectQuantity.addEventListener('change', function () {
            let dataIndex = this.getAttribute('data-index');
            let vmUnitPrice = window.viewModelData.shoppingCartList[dataIndex].unitPrice;
            let vmCourseQuantity = window.viewModelData.shoppingCartList[dataIndex].courseQuantity;

            if (this.value == 1) {
                window.viewModelData.shoppingCartList[dataIndex].courseQuantity = this.value;
                window.viewModelData.shoppingCartList[dataIndex].discount = 0;
                updateTotalPrice(dataIndex, this.value, vmUnitPrice);
            }
            else if (this.value == 5) {
                window.viewModelData.shoppingCartList[dataIndex].courseQuantity = this.value;
                window.viewModelData.shoppingCartList[dataIndex].discount = 0.95;
                updateTotalPrice(dataIndex, this.value, vmUnitPrice);
            }
            else if (this.value == 10) {
                window.viewModelData.shoppingCartList[dataIndex].courseQuantity = this.value;
                window.viewModelData.shoppingCartList[dataIndex].discount = 0.9;
                updateTotalPrice(dataIndex, this.value, vmUnitPrice);
            }
            else {
                window.viewModelData.shoppingCartList[dataIndex].courseQuantity = this.value;
                window.viewModelData.shoppingCartList[dataIndex].discount = 0.85;
                updateTotalPrice(dataIndex, this.value, vmUnitPrice);
            }
        });
    });


    // Dto沒辦法順利轉回去action
    submitBtn.addEventListener('click', function (event) {

        const paymentType = document.querySelector('input[name="paymentType"]').value;
        const taxIdNumber = document.getElementById('taxIdInput').value;
        const cart = window.viewModelData.shoppingCartList;

        const orderData = {
            payment: paymentType,
            taxIdNumber: taxIdNumber,
            scVM: cart,
        };

        if (cart.length > 0) {
            fetch('/Order/SubmitToOrder', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(orderData)
            })
                .then(response => response.json())
                .then(result => {
                    console.log('Response from server:', result);
                })
                .catch(error => {
                    console.error('Error:', error);
                });
        } else {
            console.log('購物車為空！');
        }
    });

    function updateTotalPrice(dataIndex, quantity, unitPrice) {
        let subTotal = document.getElementById(`subtotal-${dataIndex}`);
        let discount = document.getElementById(`discount-info-${dataIndex}`);
        let totalPrice = 0;
        if (quantity == 1) {
            totalPrice = quantity * unitPrice;
            window.viewModelData.shoppingCartList[dataIndex].subtotalNTD = totalPrice;
        }
        else if (quantity == 5) {
            totalPrice = quantity * unitPrice * 0.95;
            window.viewModelData.shoppingCartList[dataIndex].subtotalNTD = totalPrice;
        }
        if (quantity == 10) {
            totalPrice = quantity * unitPrice * 0.9;
            window.viewModelData.shoppingCartList[dataIndex].subtotalNTD = totalPrice;
        }
        if (quantity == 20) {
            totalPrice = quantity * unitPrice * 0.85;
            window.viewModelData.shoppingCartList[dataIndex].subtotalNTD = totalPrice;
        }
        subTotal.textContent = totalPrice.toLocaleString('zh-TW', { minimumFractionDigits: 0, maximumFractionDigits: 0 });
        discount.textContent = ((quantity * unitPrice) - totalPrice).toLocaleString('zh-TW', { minimumFractionDigits: 0, maximumFractionDigits: 0 });
        calculateTotalPrice(dataIndex);

    }

    function calculateTotalPrice(dataIndex) {
        const theTotalPrice = document.getElementById('lh-sc-totalPrice');
        let price = 0;
        for (let i = 0; i < window.viewModelData.shoppingCartList.length; i++) {
            price += window.viewModelData.shoppingCartList[i].subtotalNTD;
            theTotalPrice.value = price;
            theTotalPrice.textContent = theTotalPrice.value.toLocaleString('zh-TW', { minimumFractionDigits: 0, maximumFractionDigits: 0 });
        }
        console.log(`現在的總金額是${theTotalPrice.textContent}元`);
    }
});

