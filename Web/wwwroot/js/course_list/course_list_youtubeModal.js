//youtube彈出視窗
export function autoPlayYouTubeModal() {
    var trigger = $("body").find('[data-bs-toggle="modal"]');
    trigger.click(function () {
        var theModal = $(this).data("bs-target"),
            videoSRC = $(this).attr("data-bs-video"),
            videoSRCauto = videoSRC + "?autoplay=1";
        $(theModal + " iframe").attr("src", videoSRCauto);
        $(theModal).on("hidden.bs.modal", function () {
            $(theModal + " iframe").attr("src", "");
        });
    });
}
autoPlayYouTubeModal();