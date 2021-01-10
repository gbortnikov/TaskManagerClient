using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerClient.Model
{
    static public class RegStatus
    {
        static public string command;
        static public int status;
    }
    class Reg
    {
        public string command = "REG";
        public string login;
        public string password;
        public string email;
        public string checkLogin;
        public string checkPassword;

    }
}
