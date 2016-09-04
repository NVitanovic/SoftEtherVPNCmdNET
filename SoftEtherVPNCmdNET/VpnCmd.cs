using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace SoftEtherVPNCmdNET
{
    public abstract class VpnCmd
    {
        protected string hostport;
        protected string password;
        protected Process app;
        protected ProcessStartInfo processStartInfo;
        protected bool timeoutOverride { get; set; }
        private int timeout;
        private bool client;
        public VpnCmd(string hostport, string pass, bool client, int timeout)
        {
            this.hostport = hostport;
            this.password = pass;
            this.client = client;
            this.timeout = timeout;
            this.timeoutOverride = false;

            processStartInfo = new ProcessStartInfo();

            processStartInfo.FileName = "vpncmd";
            processStartInfo.UseShellExecute = false;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processStartInfo.CreateNoWindow = true;
        }
        public Response GeneralCommand(string command, string arguments)
        {
            app = new Process();
            app.StartInfo = processStartInfo;
            app.StartInfo.Arguments = hostport + (client == true?" /CLIENT ":" /SERVER ") + (password == "" ? " " : " /PASSWORD " + password + " ") + " /CSV /CMD " + command + " " + arguments;
            app.Start();

            //override the timeout if needed so the process wont be killed
            if (!timeoutOverride) 
            {
                //kills the process if it hangs more than specified timeout period
                Timer t = new Timer(f => { app.Kill(); }, null, this.timeout, Timeout.Infinite);
            }
            
            string output = app.StandardOutput.ReadToEnd();
            var words = output.Split(' ', '\n', '\r', '\t');
            var matchquery = from string word in words where word.ToLowerInvariant() == "Error".ToLowerInvariant() select word;

            if (matchquery.Count() >= 1)
                return new Response(false, output);
            if (!timeoutOverride) //override the timeout if needed
            {
                app.WaitForExit(this.timeout);
                timeoutOverride = false;
            }
            else
            {
                app.WaitForExit();
            }
            return new Response(true, output);
        }
    }
}
