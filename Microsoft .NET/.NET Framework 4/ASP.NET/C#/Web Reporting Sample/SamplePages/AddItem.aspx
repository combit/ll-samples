<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" MasterPageFile="SamplePages.master" Inherits="WebReporting.CreateNewProject" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Web Reporting Sample</title>
    <script type="text/javascript">
        $(document).bind("mobileinit", function () {
            $.mobile.ajaxEnabled = false;
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server" data-ajax="false">
        <div style="max-width: 800px; margin: auto; margin-top: 100px">

            <asp:Panel ID="ProjectCreated" runat="server" Visible="false">
                <div style="color: forestgreen; font-size: 1.2em; text-align: center; padding: 3em">
                    New Project has been created!<br />
                    Please refresh the page to select the new report.
                </div>
            </asp:Panel>


            <asp:Panel ID="NewProject" runat="server">
                <div class="ui-grid-solo">
                    <div class="ui-block-a">
                        <h2>Add Item to Repository</h2>
                        <span>Use this page to upload files and add them to the repository, or to create a new and empty List &amp; Label project of the specified project type in the repository.
                        </span>
                        <br />
                        <br />
                    </div>
                </div>

                <div class="ui-grid-a">
                    <!-- Create new project form -->
                    <div class="ui-block-a" style="padding-right: 1.3em; border-right: 1px solid #d1d1d1">
                        <h4>Create New Project</h4>
                        <span>Note that the Html5Viewer will not work for a new project until it has been designed in the Web Designer!</span><br />
                        <br />
                        <label for="TextBoxProjectName">Name:</label>
                        <asp:TextBox ID="TextBoxProjectName" ClientIDMode="Static" runat="server" ValidationGroup="NewItem"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorProjectName" ValidationGroup="NewItem" ControlToValidate="TextBoxProjectName" runat="server" ErrorMessage="Please enter a project name!"></asp:RequiredFieldValidator>
                        <br />
                        <label for="DropDownListProjectTypes">Project Type:</label>
                        <asp:DropDownList ID="DropDownListProjectTypes" ValidationGroup="NewItem" runat="server"></asp:DropDownList>
                        <asp:Label ID="LabelProjectTypes" runat="server" ValidationGroup="NewItem" Text="Not a valid repository item type!" Visible="false" Font-Size="Small" ForeColor="Red"></asp:Label>
                        <br />
                        <br />
                        <div style="text-align: right">
                            <asp:Button ID="Button1" runat="server" ValidationGroup="NewItem" data-inline="true" data-icon="plus" data-mini="true" Text="Create Project" OnClick="ButtonCreateProject_Click" />
                        </div>
                    </div>

                    <!--Upload file form -->
                    <div class="ui-block-b" style="padding-left: 1.3em">
                        <h4>Upload File</h4>
                        <span>Upload a local file to be imported to the repository.<br />(Project, Picture, PDF, Shapefile, ...)</span><br />
                        <br />
                        <label for="FileUploadItem">Select a file:</label>
                        <asp:FileUpload ID="FileUploadItem" ClientIDMode="Static" ValidationGroup="NewFile" runat="server" />
                        <asp:Label ID="LabelFileUploadItem" runat="server" ValidationGroup="NewItem" Visible="false" Font-Size="Small" ForeColor="Red"></asp:Label>
                        <div id="Section_File2" style="display: none">
                            <label for="FileUploadItem2">Select the corresponding database (.dbf) file:</label>
                            <asp:FileUpload ID="FileUploadItem2" ClientIDMode="Static" ValidationGroup="NewFile" runat="server" />
                        </div>

                    </div>
                    <div id="Section_ShowInToolbar" style="display: none">
                        <asp:CheckBox ID="CheckBoxShowinToolBar" Checked="true" ValidationGroup="NewFile" data-mini="true" Text="Show as report in the toolbar" runat="server" />
                    </div>
                    <br />
                    <div style="text-align: right">
                        <asp:Button ID="ButtonUploadItem" runat="server" ValidationGroup="NewFile" Text="Add File" data-inline="true" data-icon="plus" data-mini="true" OnClick="ButtonUploadItem_Click" />
                    </div>
                    <asp:Label ID="Label1" runat="server" ValidationGroup="NewFile" Text="Not a valid repository item type!" Visible="false" Font-Size="Small" ForeColor="Red"></asp:Label>
                </div>
            </asp:Panel>
        </div>
        <script type="text/javascript">
            $(document).ready(function () {
                // Show or hide elements that depend on the file type of the upload
                $('#FileUploadItem').on('change', function () {
                    var fileExtension = $('#FileUploadItem').val().substr($('#FileUploadItem').val().lastIndexOf('.'));
                    var isShapeFile = (fileExtension === '.shp');
                    var isProjectFile = (fileExtension === '.lst' || fileExtension === '.srt' || fileExtension === '.lsr' || fileExtension === '.crd' || fileExtension === '.lbl');
                    if (isShapeFile) {
                        $('#Section_File2').slideDown();
                    } else {
                        $('#Section_File2').slideUp();
                    }

                    if (isProjectFile) {
                        $('#Section_ShowInToolbar').slideDown();
                    } else {
                        $('#Section_ShowInToolbar').slideUp();
                    }
                });
            });
        </script>
    </form>
</asp:Content>

