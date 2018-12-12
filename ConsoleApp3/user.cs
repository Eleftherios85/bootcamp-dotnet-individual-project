using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class user
    {

        public string username;
        public string password;
    
        public user(string u,string p)
        {
            this.username = u;
            this.password = p;
        }
        
    }
    class message
    {
        public string MessageID;
        public string DateOfSubmission;
        public string Sender;
        public string Receiver;
        public string Message_Data;

        public message(string d,string s,string r, string m)
        {
            this.DateOfSubmission = d;
            this.Sender = s;
            this.Receiver = r;
            this.Message_Data = m;
        }
    }
}
