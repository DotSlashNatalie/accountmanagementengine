using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AccountManagement.Engines
{
    class TwitterEngine : IEngine, IDisposable
    {
        private WebEngine web;
        public TwitterEngine()
        {

        }
        public void Dispose()
        {
            
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
            string page = this.web.DownloadString("https://mobile.twitter.com/session/new");
            Regex r = new Regex("input name=\"authenticity_token\" type=\"hidden\" value=\"(.*)\" /></div>");
            Match m = r.Match(page);
            Dictionary<string, string> postdatadct = new Dictionary<string, string>();
            postdatadct.Add("{{username}}", username);
            postdatadct.Add("{{password}}", password);
            postdatadct.Add("{{token}}", m.Groups[1].ToString());
            string[] scriptarr = Regex.Split(Properties.Resources.twitter_login, Environment.NewLine);
            string ret = this.web.PostData(scriptarr[0], scriptarr.Skip(1).ToArray(), postdatadct);
            //Console.WriteLine(ret);
        }

        private void ChangePass(string oldpass, string newpass)
        {
            String page = this.web.DownloadString("https://mobile.twitter.com/settings/password");
            Regex r = new Regex("input name=\"authenticity_token\" type=\"hidden\" value=\"(.*)\" /></div>");
            Match m = r.Match(page);
            Dictionary<string, string> postdatadct = new Dictionary<string, string>();
            postdatadct.Add("{{oldpassword}}", oldpass);
            postdatadct.Add("{{newpassword}}", newpass);
            postdatadct.Add("{{token}}", m.Groups[1].ToString());
            List<string> scriptarr = Regex.Split(Properties.Resources.twitter_passgate, Environment.NewLine).ToList();
            string ret = this.web.PostData(scriptarr[0], scriptarr.Skip(1).ToArray(), postdatadct);
        }
    }
}
