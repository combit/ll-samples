<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Web Reporting Sample</title>
    <script src="~/Scripts/jquery-2.2.4.js"></script>
    @*<script type="text/javascript">
            $(document).bind("mobileinit", function () {
                $.mobile.ajaxEnabled = false;   // Use the regular browser navigation instead of jQuery Mobile`s AJAX-based pages (must be set before jQuery Mobile is loaded!)
            });
        </script>*@
    <link href="~/Content/jquery.mobile-1.4.5.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).bind("mobileinit", function () {
            $.mobile.ajaxEnabled = false;
        });
    </script>
    <script src="~/Scripts/jquery.mobile-1.4.5.js"></script>
    <link href="~/Content/combit.css" rel="stylesheet" />
</head>
<body>
    @RenderBody()
</body>
</html>