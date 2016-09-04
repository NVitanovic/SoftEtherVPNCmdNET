using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SoftEtherVPNCmdNET
{
    public class Response
    {
        public bool Success { get; set; }
        public string Info { get; set; }
        public Response(bool success, string info)
        {
            Success = success;
            Info = info;
        }
    }
}
