const editors = document.querySelectorAll(".editor_resume");
editors.forEach((element) => {
    new Quill(element, {
        theme: 'snow',
        placeholder: '輸入...',
        modules: {
            toolbar: [
                [{ 'size': ['small', false, 'large', 'huge'] }],
                [{ 'header': [1, 2, 3, false] }], 
                ['bold', 'underline'],
                [{ 'color':[]}, { 'background': [] }], 
                [{ 'list': 'ordered' }, { 'list': 'bullet' }], 
                [{ 'align': [] }], 
                [{ 'indent': '-1' }, { 'indent': '+1' }],
                ['link', 'image', 'video'] 
            ]
        }
    });
});

