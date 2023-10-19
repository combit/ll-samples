function webReportViewer() {
    var selectedReportID = $('#ReportRepositoryID').val();
    var viewerLink = '/Sample/Viewer?reportRepositoryID=' + encodeURIComponent(selectedReportID);
    $('#ContentContainer').attr('src', viewerLink);
}

function webReportDesigner() {
    var selectedReportID = $('#ReportRepositoryID').val();
    var designerLink = '/Sample/WebReportDesigner?reportRepositoryID=' + encodeURIComponent(selectedReportID);
    $('#ContentContainer').attr('src', designerLink);
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
