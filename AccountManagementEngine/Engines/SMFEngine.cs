using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AccountManagement.Engines
{
    class SMFEngine : IDisposable, IEngine
    {
        private WebEngine web;
        private Dictionary<string, string> options;
        public SMFEngine(Dictionary<string, string> options)
        {
            this.web = new WebEngine();
            this.options = options;
        }
        public bool ChangePassword(string username, string oldpass, string newpass)
        {
            this.Login(username, oldpass);
            this.ChangePass(oldpass, newpass);
            return true;
        }

        private void Login(string username, string password)
        {
            Dictionary<string, string> postdatadct = new Dictionary<string, string>();
            postdatadct.Add("{{username}}", username);
            postdatadct.Add("{{password}}", password);
            postdatadct.Add("{{url}}", this.options["url"]);
            string[] scriptarr = Regex.Split(Properties.Resources.smf_login, Environment.NewLine);
            this.web.PostData(scriptarr[0], scriptarr.Skip(1).ToArray(), postdatadct);
        }

        private void ChangePass(string oldpass, string newpass)
        {
            Dictionary<string, string> postdatadct = new Dictionary<string, string>();
            postdatadct.Add("{{oldpassword}}", oldpass);
            postdatadct.Add("{{newpassword}}", newpass);
            postdatadct.Add("{{url}}", this.options["url"]);
            string[] scriptarr = Regex.Split(Properties.Resources.smf_passgate, Environment.NewLine);
            this.web.PostData(scriptarr[0], scriptarr.Skip(1).ToArray(), postdatadct);
        }

        public void Dispose()
        {
            
        }
    }
}
