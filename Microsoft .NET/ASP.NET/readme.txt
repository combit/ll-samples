DE:
Die combit.ListLabel??.Web.dll verwendet intern die Frameworks ASP.NET MVC und WebAPI. Damit die benötigten Referenzen gefunden werden, müssen Sie die entsprechenden NuGet-Packages auch zu Ihrem eigenen Projekt hinzufügen. Suchen Sie die Pakete "Microsoft.AspNet.Mvc" (Version 4.0.40804 oder neuer) und "Microsoft.AspNet.WebApi" (Version 4.0.30506 oder neuer) im NuGet Package Manager und installieren Sie diese. Alternativ führen Sie im "Package Manager Console"-Fenster von Visual Studio die folgenden Befehle aus:

	Install-Package Microsoft.AspNet.Mvc
	Install-Package Microsoft.AspNet.WebApi

Bitte beachten Sie, dass weiterhin nur die .NET Framework-Versionen 4.0 und neuer unterstützt werden.


Update von bestehenden ASP.NET Anwendungen auf die neue List & Label Version
----------------------------------------------------------------------------
Wenn nach einem Update Ihrer bestehenden ASP.NET Anwendung auf die neue List & Label Version folgende Meldung erscheint, dann liegt dies daran, dass der HTML5Viewer eine neuere Version der Newtonsoft.Json (mind. 8.0.3) benötigt.

	No HTTP resource was found that matches the request ... No type was found that matches the controller named HTML5Viewer

Um ein Update der Version durchzuführen, gehen Sie in die "NuGet Package Manager Console" (Tools > NuGet Package Manager > Package Manager Console) und geben Folgendes ein
	Update-Package Newtonsoft.Json -version 8.0.3

===================================================================================================

US:
Internally, combit.ListLabel??.Web.dll uses the ASP.NET MVC and WebAPI frameworks. In order for the required references to be found, you will need to add the relevant NuGet packages to your own project as well. In the NuGet Package Manager, search for the packages "Microsoft.AspNet.Mvc" (Version 4.0.40804 or later) and "Microsoft.AspNet.WebApi" (Version 4.0.30506 or later) and install them. Alternatively, run the following commands from Visual Studio’s "Package Manager Console" screen:

	Install-Package Microsoft.AspNet.Mvc
	Install-Package Microsoft.AspNet.WebApi

Please note that only .NET Framework versions 4.0 and above are supported.


Update ASP.NET Applications to the new List & Label Version
-----------------------------------------------------------
If the following error message appears after updating your ASP.NET application to the new List & Label version, you have to update the Newtonsoft.Json dll. List & Label needs at least the version 8.0.3.

	No HTTP resource was found that matches the request ... No type was found that matches the controller named HTML5Viewer

To update the version use the "NuGet Package Manager Console" (Tools > NuGet Package Manager > Package Manager Console) and execute the following command
Update-Package Newtonsoft.Json -version 8.0.3