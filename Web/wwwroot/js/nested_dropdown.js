const nestedDropdownBtns = document.querySelectorAll(
    ".nested-dropdown > .dropdown-menu button"
);

nestedDropdownBtns.forEach((btn) =>
    btn.addEventListener("click", (e) => {
        e.target
            .closest(".nested-dropdown")
            .closest(".dropdown-menu")
            .classList.remove("show");
    })
);
