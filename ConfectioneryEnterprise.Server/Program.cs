using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfectioneryEnterprise.Core.Server;

namespace ConfectioneryEnterprise.Server
{
    class Program
    {
        static int Main(string[] args)
        {
            //AsynchronousSocketServer.StartListening();
            SynchronousSocketServer.StartListening();
            return 0;
        }
    }
}
