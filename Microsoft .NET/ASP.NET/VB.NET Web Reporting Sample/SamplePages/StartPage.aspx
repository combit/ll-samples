<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="StartPage.aspx.vb" MasterPageFile="SamplePages.master" Inherits="WebReporting.StartPage" %>

<%@ Import Namespace="WebReporting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Web Reporting Sample</title>
    <script type="text/javascript">
        $(document).bind("mobileinit", function () {
            $.mobile.ajaxEnabled = false;
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
        <div>

            <div style="margin: 5px 10px">
                <span style="font-weight: 200; color: #808080; font-size: 1.1em;">Choose a report</span>
                <img runat="server" src="~/Content/images/ArrowUpGray.png" />
            </div>

            <asp:Literal ID="LiteralReadMe" runat="server"></asp:Literal>

            <br />
            <div style="max-width: 1300px; margin: auto">
                <button id="btnShowRepositoryItems" onclick="$('#RepositoryItemList').slideDown(); $('#btnShowRepositoryItems').hide(); return false;" data-mini="true" data-inline="true" data-icon="search">Show Repository Items</button>

                <div id="RepositoryItemList" style="display: none">
                    <h4>Repository Items</h4>

                    <asp:Repeater ID="RepeaterRepository" runat="server" OnItemDataBound="RepeaterRepository_ItemDataBound">
                        <ItemTemplate>
                            <div data-role="collapsible" data-mini="true">
                                <h4><asp:Label ID="LabelItemName" runat="server" Text="Label"></asp:Label></h4>

                                <table class="RepositoryItemTable">
                                    <tr>
                                        <td>ID:</td>
                                        <td><%# DirectCast(Container.DataItem, CustomizedRepostoryItem).InternalID %></td>
                                        <td>Author:</td>
                                        <td><%# DirectCast(Container.DataItem, CustomizedRepostoryItem).Author %></td>
                                    </tr>
                                    <tr>
                                        <td>Type:</td>
                                        <td><%# DirectCast(Container.DataItem, CustomizedRepostoryItem).Type %></td>
                                        <td>Last Modification:</td>
                                        <td><%# DirectCast(Container.DataItem, CustomizedRepostoryItem).LastModificationUTC.ToLocalTime() %></td>
                                    </tr>
                                </table>
                                <div style="text-align: right">
                                    <asp:HyperLink ID="LinkHtml5Viewer" runat="server" Visible="false" data-ajax="false" data-role="button" data-mini="true" data-inline="true">Html5Viewer</asp:HyperLink>
                                    <asp:HyperLink ID="LinkDesigner" runat="server" Visible="false" data-ajax="false" data-role="button" data-mini="true" data-inline="true">Design</asp:HyperLink>
                                    <asp:HyperLink ID="LinkDownload" runat="server" data-ajax="false" data-role="button" data-mini="true" data-inline="true">Download</asp:HyperLink>
                                    <asp:HyperLink ID="LinkDelete" runat="server" data-ajax="false" data-role="button" data-mini="true" data-inline="true">Delete</asp:HyperLink>
                                </div>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>

                    </asp:Repeater>

                </div>
            </div>


            <div id="CreateProjectPopup" data-role="popup" data-position-to="window">
                <div data-role="header">
                    <h4>Create Project</h4>
                </div>
                <asp:HyperLink ID="HyperLink1" NavigateUrl="~/SamplePages/AddItem.aspx" runat="server">HyperLink</asp:HyperLink>
            </div>

        </div>
    </form>
</asp:Content>
