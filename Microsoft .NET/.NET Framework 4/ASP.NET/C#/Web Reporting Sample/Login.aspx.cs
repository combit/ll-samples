using System;
using System.Web.Security;
using System.Web.UI;

namespace WebReporting
{
    public partial class Login : System.Web.UI.Page
    {
        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // D:   Dummy-Login zur Demonstration der Nutzung des Web Designers mit Forms Authentication
                // US:  Dummy-Login for demonstration of using the Web Designer with Forms Autentication.
                FormsAuthentication.SetAuthCookie(TextBoxUserName.Text, false);
                Response.Redirect(FormsAuthentication.GetRedirectUrl(TextBoxUserName.Text, false));
            }
        }
    }
}