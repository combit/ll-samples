using ClientApiExample.Dialogs;
using combit.ReportServer.ClientApi;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ClientApiExample
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var loginDialog = new LoginDialog();
            Application.Run(loginDialog);

            if (loginDialog.DialogResult != DialogResult.OK)
                return;

            Application.Run(new StartDialog(loginDialog.Client));
        }


        public static void ShowValidationErrorsAtControls(Form container, ErrorProvider errProvider, ModelValidationFailedException validationErrors)
        {
            string errorText = "The entered data is not valid (model validation failed). Error Summary:" + Environment.NewLine;
            foreach (var modelError in validationErrors.ErrorDetails)
            {
                errorText += " - " + modelError.FieldName + ": " + modelError.ErrorText + Environment.NewLine;
            }

            MessageBox.Show(container, errorText, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            // Search for a control on the form that has a "Tag" property which equals the name of the invalid model value from the exception.
            // That way we can show the validation error message at the control which contains the invalid input.
            // Of course that requires that all mappable 
            foreach (var modelError in validationErrors.ErrorDetails)
            {
                errProvider.SetError(container.Controls.OfType<Control>().First(c => c.Tag as string == modelError.FieldName), modelError.ErrorText);
            }
        }
    }


}
