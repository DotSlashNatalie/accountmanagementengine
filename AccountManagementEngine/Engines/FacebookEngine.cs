using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AccountManagement.Engines
{
    internal class FacebookEngine : IEngine, IDisposable
    {
        private WebEngine web;
        public FacebookEngine(Dictionary<string, string> options)
        {
            //We don't need to store the options
            if (options.Keys.Contains("ignoressl") && options["ignoressl"] == "true")
            {
                AccountManagementEngine.ignoreSSL();
            }
        }
        public bool ChangePassword(string username, string oldpass, string newpass)
        {
            web = new WebEngine("Nokia 7110/1.0");
            this.Login(username, oldpass);
            this.ChangePass(oldpass, newpass);
            return true;
        }

        private void Login(string username, string password)
        {
            Dictionary<string, string> postdatadct = new Dictionary<string, string>();
            postdatadct.Add("{{username}}", username);
            postdatadct.Add("{{password}}", password);
            string[] scriptarr = Regex.Split(Properties.Resources.facebook_login, Environment.NewLine);
            this.web.PostData(scriptarr[0], scriptarr.Skip(1).ToArray(), postdatadct);
        }

        private void ChangePass(string oldpass, string newpass)
        {
            Dictionary<string, string> postdatadct = new Dictionary<string, string>();
            postdatadct.Add("{{oldpassword}}", oldpass);
            postdatadct.Add("{{newpassword}}", newpass);

            string passpage = this.web.DownloadString("https://m.facebook.com/settings/account/?password&refid=70");
            Regex r = new Regex(@"""hidden"" name=""fb_dtsg"" value=""(.*)"" autocomplete=""off"" />");
            Match m = r.Match(passpage);
            List<string> scriptarr = Regex.Split(Properties.Resources.facebook_passgate, Environment.NewLine).ToList();
            scriptarr.Add("fb_dtsg=" + m.Groups[1].ToString());
            this.web.PostData(scriptarr[0], scriptarr.Skip(1).ToArray(), postdatadct);
        }

        public void Dispose()
        {

        }
    }
}
