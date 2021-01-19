using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TaskManagerClient.ViewModel
{
    public class MyTask
    {
        public string Name { get; set; }
        public string Discription { get; set; }
        public string ProjectName { get; set; }
        public int Condition { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Remains { get; set; }
    }

    class MyTasksViewModel : BaseViewModel
    {
        static public MyTask t1 = new MyTask() { Condition = 2, Discription = "Asdsadasdsa", Name = "11111" };

        private List<MyTask> task_s = new List<MyTask>() { t1, t1 };
        public List<MyTask> Task_s
        {
            get { return task_s; }
            set
            {
                task_s = value;
                OnPropertyChanged();
            }
        }
        public ICommand Update
        {
            get
            {
                return new DelegateCommand((args) =>
                {
                    task_s.Add(t1);
                    Task_s = task_s;
                });
            }
        }



    }
}
