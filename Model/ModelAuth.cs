using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerClient.Model
{
    class Auth
    {
        public string command = "AUTH";
        public string login;
        public string password;
        public string checkLogin;
        public string checkPassword;
    }

    static public class AuthStatus
    {
        static public string command;
        static public int status;
    }

}
