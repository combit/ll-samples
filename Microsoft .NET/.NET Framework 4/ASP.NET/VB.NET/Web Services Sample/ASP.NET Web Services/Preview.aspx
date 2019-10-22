<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Preview.aspx.vb" Inherits="ASP.NET_Web_Services.Preview" %>

<%@ Register assembly="combit.ListLabel25.Web" namespace="combit.ListLabel25.Web" tagprefix="combit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
