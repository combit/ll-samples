using combit.ListLabel25.DataProviders;
using CustomDataProvider.Properties;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;


namespace combit.ListLabel25.Samples
{
    public class Helper
    {
        /// <summary>
        /// Downloads a file from a network share, local path or web url and returns the (local) path of the downloaded file.
        /// </summary>
        public static string DownloadFile(string cacheDir, Uri uri, string username, string password, string domain)
        {
            if (uri.IsUnc || uri.IsFile)
            {
                string destination = Path.Combine(cacheDir, Guid.NewGuid().ToString() + Path.GetExtension(uri.LocalPath));

                // The destination file must be opened before impersonation to stay accessible for the report server
                using (FileStream dest = new FileStream(destination, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (var impersonationContext = new WrappedImpersonationContext(domain, username, password, uri.IsUnc))  // impersonation is skipped when username is empty
                    {
                        impersonationContext.Enter();
                        using (FileStream source = new FileStream(uri.LocalPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            source.CopyTo(dest);
                            return destination;
                        }
                    }
                }
            }
            else
            {
                TimeoutWebClient client = new TimeoutWebClient();
                if (!String.IsNullOrWhiteSpace(username))
                {
                    client.Credentials = new NetworkCredential(username, password, domain);
                }

                byte[] bytes = client.DownloadData(uri.AbsoluteUri);
                string destination = Path.Combine(cacheDir, Guid.NewGuid().ToString()) + Path.GetExtension(client.FileName);
                File.WriteAllBytes(destination, bytes);
                return File.Exists(destination) ? destination : null;
            }
        }

        /// <summary>
        /// Gets Domain from username or username with domain string
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static string GetDomainFromUsernameString(string username)
        {
            if (String.IsNullOrWhiteSpace(username))
                return String.Empty;

            Match match = Regex.Match(username, @"(.+)\\(.+$)");
            return match.Success ? match.Result("$1") : String.Empty;
        }

        /// <summary>
        /// Gets Username from username or username with domain string
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static string GetUsernameWithoutDomain(string username)
        {
            if (String.IsNullOrWhiteSpace(username))
                return String.Empty;

            Match match = Regex.Match(username, @"(.+)\\(.+$)");
            return match.Success ? match.Result("$2") : username;
        }

        public static bool IsValidUrlUncFileFormat(string urlUncFilePath)
        {
            if (String.IsNullOrWhiteSpace(urlUncFilePath))
                return false;

            Uri uri;
            if (!Uri.TryCreate(urlUncFilePath, UriKind.RelativeOrAbsolute, out uri))
                return false;

            return true;
        }
    }

    /// <summary>
    /// Allows to execute code under a different Windows identity.
    /// </summary>
    public sealed class WrappedImpersonationContext : IDisposable
    {
        private string _domain, _password, _username;
        private IntPtr _token;
        private WindowsImpersonationContext _context;
        private bool disposed = false;
        private LogonType _logonType;

        private bool IsInContext
        {
            get { return _context != null; }
        }

        public WrappedImpersonationContext(string domain, string username, string password, bool isUnc = true)
        {
            _domain = String.IsNullOrEmpty(domain) ? "." : domain;
            _username = username;
            _password = password;

            // remove domain from username:
            var indexOfBackslash = _username.IndexOf('\\');
            if (indexOfBackslash != -1)
            {
                _username = _username.Substring(indexOfBackslash + 1);
            }

            _logonType = isUnc ? LogonType.NewCredentials : LogonType.Interactive;
        }

        /// <summary>
        /// Changes the Windows identity of this thread. Make sure to always call Leave() at the end.
        /// </summary>
        /// <exception cref="Win32Exception">Thrown when user credentials are invalid.</exception>
        [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
        public void Enter()
        {
            if (IsInContext)
                return;

            if (String.IsNullOrWhiteSpace(_username))
                return;

            _token = IntPtr.Zero;
            bool logonSuccessfull = LogonUser(_username, _domain, _password, _logonType, LogonProvider.WinNT50, ref _token);
            if (!logonSuccessfull)
            {
                int error = Marshal.GetLastWin32Error();
                throw new Win32Exception(error, GetWin32ErrorMessage(error));
            }
            WindowsIdentity identity = new WindowsIdentity(_token);
            _context = identity.Impersonate();
        }

        [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
        public void Leave()
        {
            if (!IsInContext)
                return;

            _context.Undo();

            if (_token != IntPtr.Zero)
            {
                CloseHandle(_token);
            }
            _context = null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                Leave();
                disposed = true;
            }
        }

        ~WrappedImpersonationContext()
        {
            Dispose(false);
        }

        private static string GetWin32ErrorMessage(int errorCode)
        {
            switch (errorCode)
            {
                //case 87: //ERROR_INVALID_PARAMETER, occures if url is wrong
                //return

                case 86: //ERROR_INVALID_PASSWORD
                case 1326: //ERROR_LOGON_FAILURE
                case 2202: //ERROR_BAD_USERNAME
                    return Resources.Account_WrongCredentials;

                default:
                    return new Win32Exception(errorCode).Message;
            }
        }


        #region "Native Methods"

        [DllImport("advapi32.dll", EntryPoint = "LogonUserW", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool LogonUser(String lpszUsername, String lpszDomain,
         String lpszPassword, LogonType dwLogonType, LogonProvider dwLogonProvider, ref IntPtr phToken);

        [DllImport("kernel32.dll")]
        private extern static bool CloseHandle(IntPtr handle);

        // descriptions: http://msdn.microsoft.com/en-us/library/windows/desktop/aa378184(v=vs.85).aspx
        private enum LogonType : int
        {
            Interactive = 2,
            Network = 3,
            Batch = 4,
            Service = 5,
            Unlock = 7,
            NetworkClearText = 8,
            NewCredentials = 9
        }

        private enum LogonProvider : int
        {
            Default = 0,  // LOGON32_PROVIDER_DEFAULT
            WinNT35 = 1,
            WinNT40 = 2,  // Use the NTLM logon provider.
            WinNT50 = 3   // Use the negotiate logon provider.
        }

        #endregion

    }

    public class RequiredFieldAttribute : RequiredAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return Resources.Validation_RequiredField;
        }

    }

    public class UrlUncFileFormatAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || String.IsNullOrWhiteSpace(value.ToString()))
                return ValidationResult.Success;

            if (Helper.IsValidUrlUncFileFormat(value.ToString()))
                return ValidationResult.Success;

            return new ValidationResult(Resources.Validation_UrlUncFile);
        }
    }
}
