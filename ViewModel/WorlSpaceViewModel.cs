using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TaskManagerClient.View;

namespace TaskManagerClient.ViewModel
{
    class WorlSpaceViewModel : BaseViewModel
    {
        private Page currentPage;
        private InfoUserPage infoUserPage;
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

        public ICommand ChangePage
        {
            get
            {
                return new DelegateCommand((args) =>
                {

                    //CurrentPage = regPage;

                });
            }
        }


        public WorlSpaceViewModel(){
            infoUserPage = new InfoUserPage();
            CurrentPage = infoUserPage;
            }


    }
}
