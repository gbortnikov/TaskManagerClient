using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TaskManagerClient.Model;
using TaskManagerClient.View;

namespace TaskManagerClient.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        public Action CloseAction { get; set; }


        private AuthPage authPage;
        private RegPage regPage;
        private Page currentPage;
        public Page CurrentPage
        {
            get
            {
                return currentPage;
            }
            set
            {
                currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        private string btnContent = "Регистрация";
        public string BtnContent
        {
            get
            {
                return btnContent;
            }
            set
            {
                btnContent = value;
                OnPropertyChanged("BtnContent");
            }
        }


        public ICommand ChangePage
        {
            get
            {
                return new DelegateCommand((args) =>
                {
                    if (currentPage == authPage)
                    {
                        CurrentPage = regPage;
                        BtnContent = "Авторизация";
                    }
                    else
                    {
                        CurrentPage = authPage;
                        BtnContent = "Регистрация";
                    }
                });
            }
        }






        public ICommand Close
        {
            get
            {
                return new DelegateCommand((args) =>
                {
                    CloseAction();
                });
            }
        }



        public MainViewModel()
        {
            authPage = new AuthPage();
            regPage = new RegPage();
            CurrentPage = authPage;

        }
    }
}
