//youtube彈出視窗
export function autoPlayYouTubeModal() {
    var trigger = $("body").find('[data-bs-toggle="modal"][data-bs-target="#videoModal"]');
    trigger.click(function () {
        var theModal = $(this).data("bs-target"),
            videoSRC = $(this).attr("data-bs-video"),
            videoSRCauto = videoSRC + "?autoplay=1";
        $(theModal + " iframe").attr("src", videoSRCauto);

        //彈出視窗關閉時停止撥放
        $(theModal).on("hidden.bs.modal", function () {
            $(theModal + " iframe").attr("src", "");
        });
    });
}
autoPlayYouTubeModal();