using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices.AccountManagement;

namespace AccountManagement.Engines
{
    class WindowsEngine : IDisposable, IEngine
    {
        private Dictionary<string, string> options;
        public WindowsEngine(Dictionary<string, string> options)
        {
            this.options = options;
        }

        // Adapted from http://www.snippetdirectory.com/csharp/changing-password-of-a-local-or-domain-user/
        public bool ChangePassword(string username, string oldpass, string newpass)
        {
            PrincipalContext insPrincipalContext = null;
            if (this.options.Keys.Contains("location") && this.options["location"] == "local")
            {
                insPrincipalContext = new PrincipalContext(ContextType.Machine);//Connecting to local computer.
            }
            else if (this.options.Keys.Contains("location") && this.options["location"] == "domain")
            {
                insPrincipalContext = new PrincipalContext(ContextType.Domain, this.options["domain"], this.options["ads"]);//Connecting to Active Directory
            }
            UserPrincipal insUserPrincipal = new UserPrincipal(insPrincipalContext);
            insUserPrincipal.Name = username;
            PrincipalSearcher insPrincipalSearcher = new PrincipalSearcher();
            insUserPrincipal = insPrincipalSearcher.FindOne() as UserPrincipal;
            insUserPrincipal.SetPassword(newpass);
            insUserPrincipal.Save();
            insUserPrincipal.Dispose();
            return true;
        }

        public void Dispose()
        {
            
        }
    }
}
