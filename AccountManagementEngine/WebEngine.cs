using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AccountManagement.Engines;

namespace AccountManagement
{
    internal class WebEngine : IDisposable
    {
        private CookieAwareWebClient cli;
        private string useragent = "";

        public void AddHeader(string header, string val)
        {
            this.cli.Headers.Add(header, val);
        }
        public WebEngine()
        {
            this.cli = new CookieAwareWebClient();

        }

        public WebEngine(string ua)
        {
            this.useragent = ua;
            this.cli = new CookieAwareWebClient();

        }

        private void SetHeaders()
        {
            this.cli.Headers.Add("user-agent", this.useragent);
        }
        public string DownloadString(string url)
        {
            this.SetHeaders();
            return this.cli.DownloadString(url);
        }

        public string PostData(string url, string[] postarr, Dictionary<string, string> replace)
        {

            return this.post(url, BuildPostData(postarr, replace));
        }

        public string PostData(string url, string[] postarr)
        {
            return this.post(url, String.Join("&", postarr));
        }

        private string post(string url, string postdata)
        {
            this.SetHeaders();
            this.cli.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            return this.cli.UploadString(url, "POST", postdata);
        }

        private string BuildPostData(string[] postdata, Dictionary<string, string> replace)
        {
            string ret;

            ret = String.Join("&", postdata);

            foreach (KeyValuePair<string, string> entry in replace)
            {
                ret = ret.Replace(entry.Key, entry.Value);
            }

            return ret;
        }

        
        public void Dispose()
        {

        }
    }
}
