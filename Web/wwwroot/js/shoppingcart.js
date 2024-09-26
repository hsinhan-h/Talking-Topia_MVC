document.addEventListener('DOMContentLoaded', function () {
    console.log(window.viewModelData);
    let selectLengthElements = document.querySelectorAll('[id^="lh-timeSelect-"]'); //select抓到的是option selected的值!!!
    let selectQuantityElements = document.querySelectorAll('[id^="lh-sc-quantitySelect-"]');

    selectLengthElements.forEach(function (selectLength) {
        selectLength.addEventListener('change', function () {
            let dataIndex = this.getAttribute('data-index');
            let vmCourseLength = window.viewModelData.shoppingCartList[dataIndex].courseLength;
            let vmTFUnitPrice = window.viewModelData.shoppingCartList[dataIndex].tfUnitPrice;
            let vmFTUnitPrice = window.viewModelData.shoppingCartList[dataIndex].ftUnitPrice;
            let vmCourseQuantity = window.viewModelData.shoppingCartList[dataIndex].courseQuantity;

            console.log(`當前選到的option是: ${this.value}, index是: ${dataIndex}, VM的courseLength:${vmCourseLength},VM的TFUnitPrice:${vmTFUnitPrice} `)

            if (this.value == vmTFUnitPrice) {
                console.log(`選到的值等於vmTFUnitPrice的值: ${vmTFUnitPrice}`);
                window.viewModelData.shoppingCartList[dataIndex].unitPrice = this.value;
                updateTotalPrice(dataIndex, vmCourseQuantity, this.value);
            }
            else {
                console.log(`選到的值等於vmFTUnitPrice的值: ${vmFTUnitPrice}`);
                window.viewModelData.shoppingCartList[dataIndex].unitPrice = this.value;
                updateTotalPrice(dataIndex, vmCourseQuantity, this.value);
            }
        });
    });

    selectQuantityElements.forEach(function (selectQuantity) {
        selectQuantity.addEventListener('change', function () {
            let dataIndex = this.getAttribute('data-index');
            let vmUnitPrice = window.viewModelData.shoppingCartList[dataIndex].unitPrice;
            let vmCourseQuantity = window.viewModelData.shoppingCartList[dataIndex].courseQuantity;

            console.log(`當前選到的option是: ${this.value}, index是: ${dataIndex}, VM的CourseQuantity:${vmCourseQuantity} `)

            if (this.value == 1) {
                console.log(`選到的值等於vmCourseQuantity的值: ${1}`);
                window.viewModelData.shoppingCartList[dataIndex].courseQuantity = this.value;
                updateTotalPrice(dataIndex, this.value, vmUnitPrice);
            }
            else if (this.value == 5) {
                console.log(`選到的值等於vmCourseQuantity的值: ${5}`);
                window.viewModelData.shoppingCartList[dataIndex].courseQuantity = this.value;
                updateTotalPrice(dataIndex, this.value, vmUnitPrice);
            }
            else if (this.value == 10) {
                console.log(`選到的值等於vmCourseQuantity的值: ${10}`);
                window.viewModelData.shoppingCartList[dataIndex].courseQuantity = this.value;
                updateTotalPrice(dataIndex, this.value, vmUnitPrice);
            }
            else {
                console.log(`選到的值等於vmFTUnitPrice的值: ${20}`);
                window.viewModelData.shoppingCartList[dataIndex].courseQuantity = this.value;
                updateTotalPrice(dataIndex, this.value, vmUnitPrice);
            }
        });
    });

    function updateTotalPrice(dataIndex, quantity, unitPrice) {
        let subTotal = document.getElementById(`subtotal-${dataIndex}`);
        let discount = document.getElementById(`discount-info-${dataIndex}`);
        let totalPrice = 0;
        if (quantity == 1) {
            totalPrice = quantity * unitPrice;
            window.viewModelData.shoppingCartList[dataIndex].subTotalNTD = totalPrice;
        }
        else if (quantity == 5) {
            totalPrice = quantity * unitPrice * 0.95;
            window.viewModelData.shoppingCartList[dataIndex].subTotalNTD = totalPrice;
        }
        if (quantity == 10) {
            totalPrice = quantity * unitPrice * 0.9;
            window.viewModelData.shoppingCartList[dataIndex].subTotalNTD = totalPrice;
        }
        if (quantity == 20) {
            totalPrice = quantity * unitPrice * 0.85;
            window.viewModelData.shoppingCartList[dataIndex].subTotalNTD = totalPrice;
        }
        subTotal.textContent = totalPrice.toLocaleString();
        discount.textContent = ((quantity * unitPrice) - totalPrice).toLocaleString();

        console.log(`subTotal.textContent現在是${subTotal.textContent}`)
        console.log(`discount.textContent現在是${discount.textContent}`)
        console.log(window.viewModelData);
    }











});