$(document).ready(function () {
    const tutorRecommendCarousel = $(this).find(
        ".tutor-recommend-carousel-wrapper"
    );
    const arrowPrev = tutorRecommendCarousel.find(".arrow_prev");
    const arrowNext = tutorRecommendCarousel.find(".arrow_next");
    $(".tutor-recommend-carousel").slick({
        // dots: true,
        infinite: true,
        // autoplay: true,
        autoplaySpeed: 2000,
        speed: 300,
        slidesToShow: 5,
        slidesToScroll: 2,
        responsive: [
            {
                breakpoint: 1400,
                settings: {
                    slidesToShow: 4,
                    slidesToScroll: 2,
                    infinite: true,
                },
            },
            {
                breakpoint: 960,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 1,
                },
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                },
            },
            // You can unslick at a given breakpoint now by adding:
            // settings: "unslick"
            // instead of a settings object
        ],
        prevArrow: arrowPrev,
        nextArrow: arrowNext,
    });
});

