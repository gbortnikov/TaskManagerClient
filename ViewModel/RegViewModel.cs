using System;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Input;
using TaskManagerClient.BasicClasses;
using TaskManagerClient.Model;
using TaskManagerClient.View;

namespace TaskManagerClient.ViewModel
{
    class RegViewModel : BaseViewModel
    {
        private Reg reg = new Reg();
        private WSocClient wSocClient;


        public RegViewModel()
        {
            wSocClient = WSocClient.getInstance();
        }

        public string Login
        {
            get { return reg.login; }
            set
            {
                reg.login = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get { return reg.password; }
            set
            {
                reg.password = value;
                OnPropertyChanged();
            }
        }

        public string CheckLogin
        {
            get { return reg.checkLogin; }
            set
            {
                reg.checkLogin = value;
                OnPropertyChanged();
            }
        }

        public string CheckPassword
        {
            get { return reg.checkPassword; }
            set
            {
                reg.checkPassword = value;
                OnPropertyChanged();
            }
        }



        public string Email
        {
            get { return reg.email; }
            set
            {
                reg.email = value;
                OnPropertyChanged();
            }
        }

        public ICommand SendToServer
        {
            get
            {
                return new DelegateCommand((args) =>
                {
                    reg.password = ((PasswordBox)args).Password;

                    if (reg.password.Length > 3)
                    {
                        RegStatus.status = 0;
                        CheckLogin = "";
                        CheckPassword = "";

                        JConvert regJson = new JConvert(reg);
                        Global.myLogin = reg.login;
                        wSocClient.Send(regJson.Json);
                        while (RegStatus.status == 0)
                        {
                            Thread.Sleep(5);
                        }

                        Console.WriteLine("status={0}", RegStatus.status);
                        if (RegStatus.status == 1)
                        {
                            InfoUserWindow infoWin = new InfoUserWindow();
                            infoWin.Show();
                        }
                        else if (RegStatus.status == -1)
                            CheckLogin = "#FF7257";
                        else
                            CheckPassword = "#FF7257";
                    }
                });
            }
        }

    }
}
