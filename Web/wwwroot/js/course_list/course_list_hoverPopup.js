export function initHoverPopup() {
    $(".lh-tutor-cards").on(
        "mouseenter",
        ".lh-tutor-card:not(.lh-tutor-card-floating-popup)",
        function (e) {
            $(".lh-tutor-card-floating-popup").addClass("d-none");

            const popup = $(this).find(".lh-tutor-card-floating-popup");
            if ($(window).width() >= 960) {
                popup.fadeIn(500).removeClass("d-none");

                // init slick if not initialized yet
                const slider = popup.find(".tutor-intro-media-container");
                if (!slider.hasClass("slick-initialized")) {
                    const arrowPrev = popup.find(".arrow_prev");
                    const arrowNext = popup.find(".arrow_next");

                    slider.slick({
                        infinite: true,
                        speed: 400,
                        fade: true,
                        cssEase: "linear",
                        prevArrow: arrowPrev,
                        nextArrow: arrowNext,
                    });
                } else {
                    slider.slick("setPosition"); //位置或視窗大小變更後重新計算
                }
            }
        }
    );
}

$(window).on("resize", function () {
    if ($(window).width() < 960) {
        $(".lh-tutor-card-floating-popup").addClass("d-none");
    }
});




