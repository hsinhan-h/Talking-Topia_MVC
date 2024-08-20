const editors = document.querySelectorAll(".editor_resume");
editors.forEach((element) => {
    new Quill(element, {
        theme: 'snow'
    });
});

