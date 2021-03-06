﻿<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="WebDesignerLauncher.aspx.vb" Inherits="WebReporting.WebDesignerLauncher" %>

<%@ Register Assembly="combit.ListLabel26.Web" Namespace="combit.Reporting.Web" TagPrefix="combit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Display Designer Control</title>
</head>
<body>
    <form id="form1" runat="server" style="height:100%">
        <div class="designerContent">
            <!--
            D:  combit:DesignerControl rendert eine Seite, die den Start der Web Designer-Anwendung auf dem Client auslöst oder die Designer-Installation anbietet.
            US: combit:DesignerControl will render a page that launches the Web Designer application on the client or offers to install it.
            -->
            <combit:DesignerControl ID="DesignerControl1" runat="server" Visible="true" />

            <asp:Label ID="ErrorLabel" Visible="false" runat="server" Text=""></asp:Label>
        </div>

    </form>
</body>
</html>
