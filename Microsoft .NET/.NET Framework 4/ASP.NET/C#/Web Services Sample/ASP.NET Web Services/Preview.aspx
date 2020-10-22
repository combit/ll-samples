<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Preview.aspx.cs" Inherits="ASP.NET_Web_Services.Preview" %>

<%@ Register assembly="combit.ListLabel26.Web" namespace="combit.Reporting.Web" tagprefix="combit" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Preview</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        <combit:Html5ViewerControl ID="Html5ViewerControl1" runat="server" >
        </combit:Html5ViewerControl>    
    </div>
    </form>
</body>
</html>
