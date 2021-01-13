using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskManagerClient.BasicClasses;

namespace TaskManagerClient.ViewModel
{
    public struct Task
    {
        public string login;
        public string name;
        public string discription;
        public string projectId;
        public List<string> projectList;
        public DateTime startTime;
        public DateTime endTime;
    }

    class TaskViewModel : BaseViewModel
    {
        private WSocClient wSocClient = WSocClient.getInstance();
        private Task task = new Task();

        public TaskViewModel()
        {
            task.projectList = new List<string>()
            {
                "project1","project2","project333333"
            };
        }
        public List<string> ProjectList
        {
            get { return task.projectList; }
        }
        public string ProjectId
        {
            get { return task.projectId; }
            set
            {
                task.projectId = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return task.name; }
            set
            {
                task.name = value;
                OnPropertyChanged();
            }
        }
        public string Discription
        {
            get { return task.discription; }
            set
            {
                task.discription = value;
                OnPropertyChanged();
            }
        }
        public DateTime StartTime
        {
            get { return task.startTime; }
            set
            {
                task.startTime = value;
                OnPropertyChanged();
            }
        }

        public DateTime EndTime
        {
            get { return task.endTime; }
            set
            {
                task.endTime = value;
                OnPropertyChanged();
            }
        }

        private void Clear()
        {
            EndTime = DateTime.Now;
            StartTime = DateTime.Now;
            Name = null;
            Discription = null;
        }

        public ICommand SendToServer
        {
            get
            {
                return new DelegateCommand((args) =>
                {
                    Console.WriteLine(task.projectId);
                    Clear();
                    task.login = Global.myLogin;
                    JConvert taskJson = new JConvert(task);
                    Console.WriteLine(taskJson.Json);
                    wSocClient.Send(taskJson.Json);
                    //while (InfoStatus.status == 0)
                    //{
                    //    Thread.Sleep(5);
                    //}

                });
            }
        }

    }
}
