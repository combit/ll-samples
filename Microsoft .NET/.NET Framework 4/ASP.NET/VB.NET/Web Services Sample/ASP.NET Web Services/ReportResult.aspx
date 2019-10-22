<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>   
</head>
<body>
    <form id="form1" runat="server">
        <div id="progress" style="height: 100%; vertical-align: middle">
            <div style="text-align : center; vertical-align: middle; height: 100%">
                <img src="images/circle.gif" alt=" "/>
                <p>Please wait while creating report...</p>
            </div>
        </div>
        <div id="completed" style="visibility:hidden; height: 100%; text-align:center; vertical-align:middle">
            <div>
            <img src="images/complete_ok.png" alt=" "/>
            <p>Report was created.</p>
            </div>
        </div>
    </form>
</body>
</html>
