    function refreshHtml5Viewer() {
        var selectedReportID = $('#ReportRepositoryID').val();
        var html5viewerLink = '/sample/Sample/Html5Viewer?reportRepositoryID=' + encodeURIComponent(selectedReportID);
        $('#ContentContainer').attr('src', html5viewerLink);
    }

    function startWebDesigner() {
        var selectedReportID = $('#ReportRepositoryID').val();
        var launchWebDesignerLink = '/sample/Sample/WebDesignerLauncher?reportRepositoryID=' + encodeURIComponent(selectedReportID);
        $('#ContentContainer').attr('src', launchWebDesignerLink);
    }

function maximizeContentContainerHeight() {
    var bodyH = $(window).height(); 
    $('#ContentContainer').height(bodyH - $('#MainToolbar').outerHeight() - 5);
}

$(document).ready(function () {
    $(window).resize(maximizeContentContainerHeight);
    maximizeContentContainerHeight();
});
