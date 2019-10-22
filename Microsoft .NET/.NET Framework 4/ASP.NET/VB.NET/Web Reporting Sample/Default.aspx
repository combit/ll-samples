<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="WebReporting.Default" MasterPageFile="~/Root.master" Culture="auto"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>List &amp; Label Web Reporting Sample</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="Form1" clientidmode="Static" method="post" runat="server">
        <div data-role="header" id="MainToolbar">
            <div data-role="controlgroup" data-type="horizontal">
                <asp:LinkButton data-role="button" ID="LinkButtonStart" runat="server" data-icon="home" data-iconpos="right" OnClick="StartPage" meta:resourcekey="LinkButton2ResourceStart"></asp:LinkButton>
                <asp:DropDownList ID="DropDownListProjectFile" ClientIDMode="Static" runat="server" meta:resourcekey="DropDownListProjectFileResource1" OnSelectedIndexChanged="DropDownListProjectFile_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                <asp:LinkButton data-role="button" ID="LinkButtonRefresh" runat="server" data-icon="eye" data-iconpos="right" OnClick="DropDownListProjectFile_SelectedIndexChanged">HTML5 Viewer</asp:LinkButton>
                <asp:LinkButton data-role="button" ID="LinkButtonDesign" runat="server" data-icon="edit" data-iconpos="right" OnClick="DesignReport" meta:resourcekey="LinkButton2Resource1"></asp:LinkButton>
                <asp:LinkButton data-role="button" ID="LinkButtonCreate" runat="server" data-icon="plus" data-iconpos="right" OnClick="CreateNewProject" meta:resourcekey="LinkButton2Resource2"></asp:LinkButton>
            </div>
        </div>
    </form>
    
    <iframe id="ContentContainer" clientidmode="Static" frameborder="0" style="width:100%" runat="server"></iframe>

    <script type="text/javascript">
        function maximizeContentContainerHeight() {
            $('#ContentContainer').height($('body').height() - $('#MainToolbar').outerHeight() - 5);
        }

        $(document).ready(function () {
            $(window).resize(maximizeContentContainerHeight);
            maximizeContentContainerHeight();

            $("#ContentContainer").load(function (ev) {
                var url = $("#ContentContainer")[0].contentWindow.location.href;
                if (url.indexOf("WebDesignerLauncher") === -1) {
                    if (url && url.indexOf("reportRepositoryID") > 0) {
                        var match = RegExp('[?&]reportRepositoryID=([^&]*)').exec(url);
                        var reportID = decodeURIComponent(match[1]);
                        var ddlVal = $("#DropDownListProjectFile").val();
                        if (reportID !== ddlVal) {
                            $("#DropDownListProjectFile").val(reportID).change();
                        }
                    }
                }
            });
        });
    </script>

</asp:Content>
