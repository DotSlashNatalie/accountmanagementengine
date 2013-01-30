using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using AccountManagement.Engines;
using System.Net.Security;

namespace AccountManagement
{
    public enum Engine
    {
        FACEBOOK,
        SMF,
        TWITTER,
        WINDOWS,
        NONE
    }
    public class AccountManagementEngine : IDisposable
    {
        public Dictionary<string, string> options = new Dictionary<string,string>();
        
        // This is an option of do-what-I-say-I-know-what-I'm-doing
        public static void ignoreSSL()
        {
            try
            {
                //Change SSL checks so that all checks pass
                ServicePointManager.ServerCertificateValidationCallback =
                    new RemoteCertificateValidationCallback(
                        delegate
                        { return true; }
                    );
            }
            catch (Exception)
            {
                
            }
        }
        public void AddData(string key, string val)
        {
            this.options[key] = val;
        }
        public bool ChangePassword(Engine engine, string username, string oldpass, string newpass)
        {
            bool retval = true;
            IEngine eng = null;
            switch (engine)
            {
                case Engine.FACEBOOK:
                    eng = new FacebookEngine(options);
                    break;
                case Engine.TWITTER:
                    eng = new TwitterEngine(options);
                    break;
                case Engine.SMF:
                    // Options:
                    // Required:
                    // URL
                    eng = new SMFEngine(options);
                    break;
                case Engine.WINDOWS:
                    // Options:
                    // Required:
                    // location { local | domain }
                    // if location == domain
                    // domain -> domain of AD
                    // ads -> path of AD ie dc=microsoft,dc=com
                    eng = new WindowsEngine(options);
                    break;
            }
            if (eng != null)
                eng.ChangePassword(username, oldpass, newpass);
            return retval;
        }

        public void Dispose()
        {
            
        }
    }

}
