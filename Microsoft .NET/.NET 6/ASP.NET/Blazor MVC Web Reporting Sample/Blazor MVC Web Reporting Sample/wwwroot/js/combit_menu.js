function webReportViewer() {
        var selectedReportID = $('#ReportRepositoryID').val();
        var html5viewerLink = '/Sample/Viewer?reportRepositoryID=' + encodeURIComponent(selectedReportID);
        $('#ContentContainer').attr('src', html5viewerLink);
}

function webReportDesigner() {
    var selectedReportID = $('#ReportRepositoryID').val();
    var html5viewerLink = '/Sample/WebReportDesigner?reportRepositoryID=' + encodeURIComponent(selectedReportID);
    $('#ContentContainer').attr('src', html5viewerLink);
}

    function startWebDesigner() {
        var selectedReportID = $('#ReportRepositoryID').val();
        var launchWebDesignerLink = '/Sample/WebDesignerLauncher?reportRepositoryID=' + encodeURIComponent(selectedReportID);
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
