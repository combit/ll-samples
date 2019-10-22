
var _selectedFormat = null;
var _selectedReport = null;
var _selectedDatasourceID = null;

if (typeof jQuery == 'undefined')
{
    // jQuery is not loaded
    alert("Internet access to http://code.jquery.com required!");
}

// D: Fehler Handler
// US: Error handler
function OnError(error, arg)
{
    if (error)
    {
        var stackTrace = error.get_stackTrace();
        var message = error.get_message();
        var statusCode = error.get_statusCode();
        var exceptionType = error.get_exceptionType();

        alert(exceptionType + ": " + message + "\n\nStatuscode: " + statusCode + "\n\nStack:\n" + stackTrace);

        if (arg) {
            arg.close();
        }
    }    
}

// D: Läd alle Berichtsvorlagen zu einer Datenquelle
// US: Load report templates depending on data source
function DataSourceSelected(anker)
{
    if (anker && anker.id)
    {
        var datasourceID = anker.id.toString();
        datasourceID = datasourceID.substring(1);

        _selectedDatasourceID = datasourceID;

        ASP.NET_Web_Services.combit.Services.ReportingService.GetReportTemplates(datasourceID, OnGetReportTemplates, OnError, null);

        //
        $('a').removeClass('active'); 
        $('#'+anker.id).addClass('active');
    }
}

// D: Berichtsvorlagen in Liste einfügen
// US: Add report templates to list
function OnGetReportTemplates(response, eventArgs)
{        
    $('#reportList li').remove();

    $('#reportList').append("<li data-role='list-divider'>Reports</li>");

    if (response && response.Value)
    {
        var count = response.Value.length;
        var file, parts, line;

        if (count > 0)
        {
            _selectedDatasourceID = response.Value[0].Datasource;
        }

        for (var i = 0; i < count; i++)
        {            
            file = response.Value[i].Name;
            parts = file.split('\\');
            file = parts[parts.length - 1];

            line = '<li><a href="javascript:void(0)" onclick="GetAvailableFormats(\'' + file + '\');"><img id="img' + i.toString() + '" alt="no image" src="' + response.Value[i].Image.substr(1) + '"><h3>' + file + '</h3><p>' + response.Value[i].Description + '</p></a></li>';            
            
            $('#reportList').append(line);
        }
    }

    try {
        // D: Liste aktualisieren
        // US: Refresh list
        $('#reportList').trigger('create');
        $("#reportList").listview("refresh");
    }
    catch (e) { }
}


function OnGetDataSources(response, eventArgs)
{
    $('#dataList li').remove();
    $('#dataList').append("<li data-role='list-divider'>Datasources</li>");

    if (response && response.Value)
    {                
        var line;
        var count = response.Value.length;
        for (var i = 0; i < count; i++)
        {
            line = "<li><a id=_" + response.Value[i].Id + " href='javascript:void(0)' onclick='DataSourceSelected(this);'><img id='img" + i.toString() + "' src='" + response.Value[i].Image + "'><h3>" + response.Value[i].Id + "</h3><p>" + response.Value[i].Description + "</p></a></li>";
            $('#dataList').append(line);
        }

        ASP.NET_Web_Services.combit.Services.ReportingService.GetReportTemplates(response.Value[0].Id, OnGetReportTemplates, OnError, null);
    }

    try {
        // D: Liste aktualisieren
        // US: Refresh list
        $('#dataList').trigger('create');
        $("#dataList").listview("refresh");
    }
    catch (e) { }
}

// D: Bild URL setzen
// US: Set image URL
function OnGetReportImage(response, eventArgs)
{
    $(eventArgs).attr("src", response);
}

function helperHtmlEncode(value, encodecrlf)
{
    if (value && typeof value === "string" && value !== '') {
        value = value.replace(/&/g, '&amp;');
        value = value.replace(/</g, '&lt;');
        value = value.replace(/>/g, '&gt;');
        value = value.replace(/\"/g, '&quot;');

        if (encodecrlf === true) {
            value = value.replace(/\r\n/g, "<br>");
        }
    }

    return value;
}

function OnPrint(response, reswin)
{
    if (reswin)
    {
        var element = reswin.document.getElementById("progress");
        if (element) {
            element.style.visibility = "hidden";
        }
        element = reswin.document.getElementById("completed");
        if (element) {
            element.style.visibility = "visible";
        }
    }

    if (response && response.Value)
    {        
        if (response.Status.Succeeded) {
            reswin.location = response.Value;
        }
        else {
            element.innerHTML = helperHtmlEncode(response.Status.Description);
        }        
    }
    else
    {
        if(response && response.Status) {
            element.innerHTML = helperHtmlEncode(response.Status.Description);
        }
    }
}

// D: Exportierten Bericht in neuem Fenster anzeigen
// US: Sgow exported report in new window
function CreateResultWindow(report)
{
    return window.open('ReportResult.aspx?file=' + report, "", "");        
}

// D: Bericht drucken (exportieren) 
// US: Print (export) report
function Print(datasource, report, format)
{
    ASP.NET_Web_Services.combit.Services.ReportingService.Print(datasource, report, format, OnPrint, OnError, CreateResultWindow(report));

    // D: Nach dem Druck wieder zu den Berichten wechseln
    // US: Display reports after print
    ASP.NET_Web_Services.combit.Services.ReportingService.GetReportTemplates(datasource, OnGetReportTemplates, OnError, null);
}

// D: Vorschau öffnen
// US: Open preview window
function Preview(datasource, report)
{
    // D: Wieder zu den Berichten wechseln
    // US: Display reports again
    ASP.NET_Web_Services.combit.Services.ReportingService.GetReportTemplates(datasource, OnGetReportTemplates, OnError, null);

    return window.open('Preview.aspx?instance=' + report + '|' + datasource, "", "");
}

// D: List mit allen möglichen Exportformaten füllen
// US: Fill list with all available export formats
function OnGetFormats(response, args)
{
    $('#reportList li').remove();
    $('#reportList').append("<li data-role='list-divider'>Formats</li>");

    // Preview
    line = '<li><a href="javascript:void(0)" onclick="Preview(\'' + _selectedDatasourceID + '\',\'' + _selectedReport + '\');"><h3>' + 'Preview' + '</h3><p>' + 'Interactive Preview' + '</p></a></li>';
    $('#reportList').append(line);
    if (response && response.Value)
    {
        var line;
        var count = response.Value.length;
        
        for (var i = 0; i < count; i++)
        {
            line = '<li><a href="javascript:void(0)" onclick="Print(\'' + _selectedDatasourceID + '\',\'' + _selectedReport + '\',\'' + response.Value[i].Id + '\');"><h3>' + response.Value[i].Id + '</h3><p>' + response.Value[i].Description + '</p></a></li>';            
            $('#reportList').append(line);
        }
    }

    try {
        $('#reportList').trigger('create');
        $("#reportList").listview("refresh");
    }
    catch (e) { }    
}

function GetAvailableFormats(report)
{
    _selectedReport = report;
    ASP.NET_Web_Services.combit.Services.ReportingService.GetAvailableFormats(OnGetFormats, OnError, null);
}

// D: List mit allen möglichen Datenquellen füllen
// US: Fill list with all available data sources
$(document).ready(function ()
{    
    // call the service for dataservices    
    ASP.NET_Web_Services.combit.Services.ReportingService.GetDataSources(OnGetDataSources, OnError, null);
        
});

