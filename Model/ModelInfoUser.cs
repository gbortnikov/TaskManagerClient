using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerClient.Model
{
    static public class InfoStatus
    {
        static public string command;
        static public int status;
    }
    public class DateOfBirth
    {
        public int day = 1;
        public int mounth = 1;
        public int year = 1995;
        public DateTime GetDate()
        {
            DateTime dateTime = new DateTime(year, mounth, day);
            return dateTime;
        } 
    }
    public class Info
    {
        public string login;
        public string command = "INFO";
        public string name;
        public string surname;
        public int age;
        public bool gender =true;
        public DateTime birthDate;
        public DateTime dateReg;
        public DateTime GetDateReg()
        {
            return DateTime.Now;
        }
    }
}
