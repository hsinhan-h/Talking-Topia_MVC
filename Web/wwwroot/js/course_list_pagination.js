//換頁
$(function () {
    const prevPageBtn = $('.prev-page');
    const nextPageBtn = $('.next-page');
    let pageTextEl = $('.page-text');
    const totalPages = $('.lh-tutors-switch-page-btns').attr('total-pages');

    const params = new URLSearchParams(window.location.search);
    let currentPage = parseInt(params.get('page')) || 1; //若沒有page參數則設為1
    pageTextEl.text(currentPage);

    prevPageBtn.on('click', function () {
        if (currentPage > 1) {
            currentPage--;
            pageTextEl.text(currentPage);
            window.location.href = `?page=${currentPage}`;
        }
    });

    nextPageBtn.on('click', function () {
        if (currentPage < totalPages) {
            currentPage++;
            pageTextEl.text(currentPage);
            window.location.href = `?page=${currentPage}`;
        }
        
    })
})

