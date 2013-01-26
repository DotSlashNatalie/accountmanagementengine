using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccountManagement;
using OTPNet;
using System.Timers;
using System.IO;

namespace AccountManagementConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            //Timer tim;
            
            Dictionary<string, string> options = new Dictionary<string,string>();
            
            if (args[0] == "-f")
            {
                StreamReader filestream = new StreamReader(args[1]);
                string filecont = filestream.ReadToEnd();
                filestream.Close();
                string[] parts = filecont.Split(' ');
                if (parts.Length == 6)
                    options = parseOpts(parts[5]);
                string newpass = ExecuteOptions(parts[0], parts[1], parts[2], parts[3], parts[4], options);
                StreamWriter filewrite = new StreamWriter(args[1]);
                filecont = filecont.Replace(parts[3], newpass);
                filewrite.Write(filecont);
                filewrite.Flush();
                filewrite.Close();
            }
            else
            {

                if (args.Length == 6)
                    options = parseOpts(args[5]);
                ExecuteOptions(args[0], args[1], args[2], args[3], args[4], options);
               
            }
        }

        static string ExecuteOptions(string engine, string key, string user, string oldpass, string newpassbase, Dictionary<string, string> options)
        {
            Engine eng = Engine.NONE;
            string newpass;
            switch (engine)
            {
                case "fb":
                    eng = Engine.FACEBOOK;
                    break;
                case "smf":
                    eng = Engine.SMF;
                    break;
                case "win":
                    eng = Engine.WINDOWS;
                    break;
                case "twitter":
                    eng = Engine.TWITTER;
                    break;
            }


            TOTP t = new TOTP(key);
            using (AccountManagementEngine aeng = new AccountManagementEngine())
            {
                foreach (KeyValuePair<string, string> opt in options)
                {
                    aeng.AddData(opt.Key, opt.Value);
                }
                newpass = newpassbase + t.now().ToString("D6");
                aeng.ChangePassword(eng, user, oldpass, newpass);
            }
            return newpass;
        }

        static Dictionary<string, string> parseOpts(string arg)
        {
            Dictionary<string, string> ret = new Dictionary<string,string>();
            string[] sections = arg.Split('&');
            string[] pieces;
            foreach(string s in sections)
            {
                pieces = s.Split('=');
                ret[pieces[0]] = pieces[1];
            }
            return ret;
        }

    }
}
