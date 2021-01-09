using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskManagerClient.Model;

namespace TaskManagerClient.ViewModel
{
    public struct DateOfBirth
    {
        public int day;
        public int mounth;
        public int year;
        public string GetDate()
        {
            DateTime dateTime = new DateTime(year,mounth,day);
            return dateTime.ToString();
        }
    }
    public class Info
    {
        //public DateOfBirth dateOfBirth;
        public string name;
        public string surname;
        public int age;
        public bool gender;
        public string birthDate;
        public string dateReg;
        public void GetDate()
        {
            this.dateReg= DateTime.Now.ToString();
        }
    }

    class InfoUserViewModel : BaseViewModel
    {
        Info info = new Info();
        DateOfBirth dateOfBirth = new DateOfBirth();

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

        public int Age
        {
            get { return info.age; }
            set
            {
                info.age = value;
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
                    info.birthDate = dateOfBirth.GetDate().ToString();
                    info.GetDate();
                    JConvert infoJson = new JConvert(info);
                    Console.WriteLine(infoJson.Json);

                });
            }
        }

    }
}
