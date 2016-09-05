using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        /*public IEnumerable<T> GetRecordsFromCSV<T>(string data)
        {

            if(data.IndexOf("\n\n") != -1)
            {
                string text = data.Substring(data.IndexOf("\n\n"));
                var csv = new CsvReader(new StringReader(text));
                //All Classes that have mappings need to be called ClassNameClassMap. "ClassMap" part is obligatory!!!
                //TODO: does not return type that is needed only null, idea is to go trough all classes until we find the one with the matching name.
                Type t = typeof(T).Assembly.GetType(typeof(T).Name + "ClassMap");
                csv.Configuration.RegisterClassMap(t);
                var records = csv.GetRecords<T>();
                return records;
            }
            return null;
        }*/
    }
}
