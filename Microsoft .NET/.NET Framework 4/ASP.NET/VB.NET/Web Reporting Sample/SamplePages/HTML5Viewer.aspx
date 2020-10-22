<%@ Page Language="vb" CodeBehind="HTML5Viewer.aspx.vb" Inherits="WebReporting.HTML5Viewer" %>

<%@ Register TagPrefix="combit" Namespace="combit.Reporting.Web" Assembly="combit.ListLabel26.Web" %>
<html>
<head>
    <title>
        <asp:Literal ID="LTViewerTitle" runat="server"></asp:Literal></title>
    <!-- Resources used by the HTML5Viewer: Download them (see combitMaster.master) and uncomment the following block for using the "CDNType" "Inherited" in the code behind -->
    <!--
    <link rel="stylesheet" type="text/css" href="Styles/jquery.mobile-1.4.5.min.css">
    <script type="text/javascript" src="Scripts/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.mobile-1.4.5.min.js"></script>
    -->
</head>
<body>
    <form method="post" runat="server">
        <div>
            <combit:Html5ViewerControl ID="Html5ViewerControl1" runat="server"></combit:Html5ViewerControl>
            <asp:Label Text=""  Visible="false" ID="LabelError" runat="server" />
        </div>
    </form>
</body>
</html>
