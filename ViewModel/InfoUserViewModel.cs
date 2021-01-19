using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskManagerClient.BasicClasses;
using TaskManagerClient.Model;

namespace TaskManagerClient.ViewModel
{

    class InfoUserViewModel : BaseViewModel
    {
        Info info = new Info();
        DateOfBirth dateOfBirth = new DateOfBirth();
        private WSocClient wSocClient;

        public InfoUserViewModel()
        {
            wSocClient = WSocClient.getInstance();
        }

        public int Day
        {
            get { return dateOfBirth.day; }
            set
            {
                if (value <= 31)
                    dateOfBirth.day = value;
                else
                    dateOfBirth.day = 1;
                OnPropertyChanged();
            }
        }

        public int Mounth
        {
            get { return dateOfBirth.mounth; }
            set
            {
                if (value <= 12)
                    dateOfBirth.mounth = value;
                else
                    dateOfBirth.mounth = 1;
                OnPropertyChanged();
            }
        }

        public int Year
        {
            get { return dateOfBirth.year; }
            set
            {
                dateOfBirth.year = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return info.name; }
            set
            {
                info.name = value;
                OnPropertyChanged();
            }
        }

        public string SurName
        {
            get { return info.surname; }
            set
            {
                info.surname = value;
                OnPropertyChanged();
            }
        }


        public bool Gender
        {
            get { return info.gender; }
            set
            {
                info.gender = value;
                OnPropertyChanged();
            }
        }

        public ICommand SendToServer
        {
            get
            {
                return new DelegateCommand((args) =>
                {
                    var age = info.GetDateReg().Year - dateOfBirth.GetDate().Year;

                    if (info.GetDateReg().Month - dateOfBirth.GetDate().Month < 0)
                        age -= 1;
                    else if (info.GetDateReg().Month - dateOfBirth.GetDate().Month == 0)
                        if (info.GetDateReg().Day - dateOfBirth.GetDate().Day < 0)
                            age -= 1;

                    info.birthDate = dateOfBirth.GetDate();
                    info.dateReg = info.GetDateReg();
                    info.age = age;
                    info.login = Global.myLogin;


                    JConvert<Info> infoJson = new JConvert<Info>(info);
                    Console.WriteLine(infoJson.Json);
                    wSocClient.Send(infoJson.Json);
                    while (InfoStatus.status == 0)
                    {
                        Thread.Sleep(5);
                    }

                });
            }
        }

    }
}
