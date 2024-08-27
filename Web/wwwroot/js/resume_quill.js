const editors = document.querySelectorAll(".editor_resume");
editors.forEach((element) => {
    element.style.height = "300px"; // 設定編輯器容器的高度
    new Quill(element, {
        theme: 'snow',
        placeholder: '輸入...',
        modules: {
            toolbar: [
                [{ 'header': [1, 2, 3, false] }],
                ['bold', 'underline'],
                [{ 'color': [] }, { 'background': [] }],
                [{ 'list': 'ordered' }, { 'list': 'bullet' }],
                [{ 'align': [] }],
                [{ 'indent': '-1' }, { 'indent': '+1' }],
                ['link', 'image', 'video']
            ]
        }
    });
});
