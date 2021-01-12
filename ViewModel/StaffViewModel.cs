using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerClient.BasicClasses;

namespace TaskManagerClient.ViewModel
{
    class Employee
    {
        public string login;
        public string name;
        public string surname;
    }
    public class Staff{
        public string command;
        ObservableCollection<Employee> staffCol;
    }



    class StaffViewModel : BaseViewModel
    {
        private WSocClient wSocClient;


        public StaffViewModel()
        {
            wSocClient = WSocClient.getInstance();
            //wSocClient.Send();

        }



    }
}
