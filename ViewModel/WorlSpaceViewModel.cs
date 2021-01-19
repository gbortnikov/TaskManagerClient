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
        private TaskPage taskPage;
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

        public ICommand ChangePageInfo
        {
            get
            {
                return new DelegateCommand((args) =>
                {

                    CurrentPage = infoUserPage;

                });
            }
        }
        public ICommand ChangePageTask
        {
            get
            {
                return new DelegateCommand((args) =>
                {

                    CurrentPage = taskPage;

                });
            }
        }


        public WorlSpaceViewModel()
        {
            infoUserPage = new InfoUserPage();
            taskPage = new TaskPage();
            CurrentPage = infoUserPage;
        }
    }
}
