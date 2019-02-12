<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true"   CodeBehind="Login.aspx.cs" Inherits="WebReporting.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Web Reporting Sample Login</title>
    <script type="text/javascript">
        $(document).bind("mobileinit", function () {
            $.mobile.ajaxEnabled = false;
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div style="max-width: 500px; margin: auto; margin-top: 100px">
            <h2>Login</h2>
            Please enter any user name to use the Html5Viewer/WebDesigner with forms authentication.<br />
            <br />
            The web reporting components also support Windows authentication, which may be configured in the web.config file.
            <br />
            <br />

            <label for="TextBoxUserName">Enter any user name:</label>
            <asp:TextBox ID="TextBoxUserName" runat="server" Text="Test"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter a name!" ControlToValidate="TextBoxUserName"></asp:RequiredFieldValidator>
            <asp:Button ID="ButtonLogin" runat="server" class="ui-btn-a" Text="Login" OnClick="ButtonLogin_Click" />
        </div>
    </form>
</asp:Content>
