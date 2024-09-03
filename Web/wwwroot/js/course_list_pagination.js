//換頁
$(function () {
    const prevPageBtn = $('.prev-page');
    const nextPageBtn = $('.next-page');
    const pageText = $('.page-text');

    let currentPage = parseInt(pageText.text());

    prevPageBtn.on('click', function () {
        if (currentPage > 1) {
            currentPage--;
            pageText.text(currentPage);
            window.location.href = `?page=${currentPage}`;
        }
    });

    nextPageBtn.on('click', function () {
        currentPage++;
        pageText.text(currentPage);
        window.location.href = `?page=${currentPage}`;
    })
})