document.addEventListener('DOMContentLoaded', function () {
    const editors = document.querySelectorAll(".editor_resume");
    editors.forEach((element) => {
        element.style.height = "300px"; // 設定編輯器容器的高度
        new Quill(element, {
            theme: 'snow',
            placeholder: '輸入...',
            modules: {
                toolbar: [
                    ['bold', 'italic', 'underline'],
                    ['link', 'image', 'video'],
                    [{ 'list': 'ordered' }, { 'list': 'bullet' }]
                ]
            }
        });
    });
});
