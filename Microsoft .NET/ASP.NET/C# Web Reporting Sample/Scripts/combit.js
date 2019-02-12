$(function () {
    iFrameHeight();
    $(window).resize(function () {
        iFrameHeight();
    });
    $('.ui-navbar li').css('list-style-image', 'url(data:0)'); 
    if (!$('body').hasClass('postback')) {
        $('body').addClass('postback');
        $("form").submit();
    }

    window.designerButton = $('#DesignerBtn').closest('.ui-btn');
    window.designerButtonHtml = $('#DesignerBtn').closest('.ui-btn').html();
    $('#Report').change(function () {
        window.designerButton.off("click");
        window.designerButton.html(window.designerButtonHtml);
        $(this).parents('form').submit();
    });
})

function iFrameHeight() {
    var iframeHeight = $("body").outerHeight() - $("#form0").outerHeight() - 4;
    $("#myiframe").height(iframeHeight);
    $("#ContentArea").height(iframeHeight);

}

function overlay() {
    el = document.getElementById("overlay");
    el.style.visibility = (el.style.visibility == "visible") ? "hidden" : "visible";
    el.style.position = "fixed";
    el.style.zIndex = 10000;
}
