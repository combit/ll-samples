<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="true" CodeBehind="Default.aspx.cs" Inherits="ASPDOMSample.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>List &amp; Label ASP.NET DOM Sample</title>
    <style type="text/css">
        * { font-family: Tahoma; }
        form { border: 1px solid gray; background-image: -moz-linear-gradient(left,#F2F4F4, #BAC6D1); filter: progid:DXImageTransform.Microsoft.Gradient(GradientType=1,StartColorStr='#f2f2f2',EndColorStr='#bac6d1'); }
        h1 { font-size: 16pt; text-align: center; }
        p { font-size: 10pt; padding: 0; margin: 0; }
        .fs { width: 50%; padding: 10px 20px 10px 20px; margin-left: 40px; border-radius: 10px; }
        legend { color: Blue; }
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <div>
        <h1>
            List & Label ASP.NET DOM Sample</h1>
        <p style="margin-left: 28%; margin-bottom: 10px;">
            D: Dieses Beispiel zeigt die dynamische Erstellung von List & Label Projekten</p>
        <p style="margin-left: 28%; margin-bottom: 10px;">
            US: This sample shows the dynamic creation of List & Label projects</p>
    </div>
    <div style="margin-left: 25%;">
        <fieldset class="fs" runat="server">
            <legend>Project Layout</legend>
            <p>
                Table:</p>
            <!-- table dropdown -->
            <asp:DropDownList ID="DropDownList1" Style="width: 100%;" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1" AutoPostBack="True">
            </asp:DropDownList>
            <!-- field table -->
            <table runat="server" style="width: 100%; margin-top: 10px;">
                <tr>
                    <td style="width: 45%; font-weight: bold; font-size: 10pt;">
                        Available Fields
                    </td>
                    <td style="width: 10%;">
                    </td>
                    <td style="width: 45%; font-weight: bold; font-size: 10pt;">
                        Selected Fields
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:ListBox ID="lstAvailableFlds" SelectionMode="Multiple" runat="server" Style="width: 100%;" Rows="8"></asp:ListBox>
                    </td>
                    <td style="text-align: center;">
                        <asp:Button ID="btnSelect" runat="server" Style="margin-bottom: 10px;" Text=">" OnClick="HandleBtn_Click" />
                        <asp:Button ID="btnDeselect" runat="server" Text="<" OnClick="HandleBtn_Click" />
                    </td>
                    <td>
                        <asp:ListBox ID="lstSelectedFlds" SelectionMode="Multiple" runat="server" Style="width: 100%;" Rows="8"></asp:ListBox>
                    </td>
                </tr>
            </table>
            <!-- title -->
            <p style="margin-top: 10px;">
                Title:</p>
            <asp:TextBox ID="txtTitle" Text="Dynamically created project" runat="server" Style="width: 100%;"></asp:TextBox>
            <!-- Logo -->
            <p style="margin-top: 10px;">
                Logo:</p>
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </fieldset>
        <fieldset class="fs" runat="server">
            <legend>Export Options</legend>
            <!-- Filename -->
            <p>
                Filename:</p>
            <asp:TextBox ID="txtFilename" Text="export" runat="server" Style="width: 100%;"></asp:TextBox>
            <!-- Format -->
            <p style="margin-top: 10px;">
                Format:</p>
            <asp:DropDownList ID="DropDownListFormat" Style="width: 100%;" runat="server">
                <asp:ListItem Selected="True">XHTML</asp:ListItem>
                <asp:ListItem>XLSX</asp:ListItem>
                <asp:ListItem>PDF</asp:ListItem>
                <asp:ListItem>Multi TIFF</asp:ListItem>
                <asp:ListItem>Preview</asp:ListItem>
            </asp:DropDownList>
        </fieldset>
        <!-- Create and open buttons -->
        <asp:Button ID="btnCreateReport" Style="margin-left: 48%; margin-top: 5px; width: 100px;" runat="server" Text="Create & open" OnClick="BtnCreateReport_Click" />        
    </div>
    </form>
</body>
</html>
