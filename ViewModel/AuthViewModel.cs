using System;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Input;
using TaskManagerClient.BasicClasses;
using TaskManagerClient.Model;

namespace TaskManagerClient.ViewModel
{

    class AuthViewModel : BaseViewModel
    {
        private WSocClient wSocClient;
        private Auth auth = new Auth();

        public AuthViewModel()
        {
            wSocClient = WSocClient.getInstance();
        }

        public string Login
        {
            get { return auth.login; }
            set
            {
                auth.login = value;
                OnPropertyChanged();
            }
        }

        public string CheckLogin
        {
            get { return auth.checkLogin; }
            set
            {
                auth.checkLogin = value;
                OnPropertyChanged();
            }
        }

        public string CheckPassword
        {
            get { return auth.checkPassword; }
            set
            {
                auth.checkPassword = value;
                OnPropertyChanged();
            }
        }

        public ICommand SendToServer
        {
            get
            {
                return new DelegateCommand((args) =>
                {
                    auth.password = ((PasswordBox)args).Password;
                    JConvert<Auth> jConvert = new JConvert<Auth>(auth);
                    AuthStatus.status = 0;
                    wSocClient.Send(jConvert.Json);
                    CheckLogin = "";
                    CheckPassword = "";

                    while (AuthStatus.status == 0)
                    {
                        Thread.Sleep(5);
                    }
                    Console.WriteLine("status={0}", AuthStatus.status);
                    if (AuthStatus.status == -2)
                        CheckLogin = "#FF7257";
                    if (AuthStatus.status == -1)
                        CheckPassword = "#FF7257";
                    AuthStatus.status = 0;
                });
            }
        }
    }
}
