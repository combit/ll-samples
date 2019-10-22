<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ASP.NET_Web_Services.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Service Sample</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="http://code.jquery.com/mobile/1.1.0/jquery.mobile-1.1.0.min.css" />
    <link rel="stylesheet" href="base.css" />
    <script src="http://code.jquery.com/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="http://code.jquery.com/mobile/1.1.0/jquery.mobile-1.1.0.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager EnablePageMethods="true" runat="server" ScriptMode="Auto">
        <Services>
            <asp:ServiceReference Path="~/ReportingService.asmx" InlineScript="true" />
        </Services>
        <Scripts>
            <asp:ScriptReference Path="~/scripts/main.js" />
        </Scripts>
    </asp:ScriptManager>
    <div data-role="page">
        <div data-role="header" data-position="fixed">
            <h1>
                combit List & Label Web Services Sample
            </h1>
        </div>
        <!-- /header -->
        <div data-role="content">
            <div class="content-primary">
                <!--<p>primary</p>-->
                <ul id="reportList" data-role="listview">
                    <li data-role="list-divider">Reports</li>
                </ul>
            </div>
            <div class="content-secondary">
                <!--<p>secondary</p> -->
                <ul id="dataList" data-role="listview">
                    <li data-role="list-divider">Datasources</li>
                </ul>
            </div>
        </div>
        <!-- /content -->
        <div data-role="footer" data-position="fixed">
            <h4>
                <a href="https://www.combit.net/reporting-tool/" target="_blank">Powered by combit List & Label</a>
            </h4>
        </div>
    </div>
    <!-- /page -->
    </form>
</body>
</html>
