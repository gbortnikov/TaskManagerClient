using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using TaskManagerClient.BasicClasses;
using TaskManagerClient.View;

namespace TaskManagerClient.ViewModel
{
    public class Task_
    {
        public string command = "NEWTASK";
        public string login;
        public string name;
        public string discription;
        public int projectId;
        //public List<string> projectList;
        public DateTime startDate;
        public DateTime endDate;
    }

    class TaskViewModel : BaseViewModel
    {
        private WSocClient wSocClient = WSocClient.getInstance();
        private Task_ task = new Task_();
        private NewProjectPage projectPage = new NewProjectPage();


        public Page ProjectPage
        {
            get
            {
                return projectPage;
            }
        }



        public int ProjectId
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
        public DateTime StartDate
        {
            get { return task.startDate; }
            set
            {
                task.startDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime EndDate
        {
            get { return task.endDate; }
            set
            {
                task.endDate = value;
                OnPropertyChanged();
            }
        }

        private void Clear()
        {
            EndDate = DateTime.Now;
            StartDate = DateTime.Now;
            Name = null;
            Discription = null;
            ProjectId = -1;
        }

        public ICommand SendToServer
        {
            get
            {
                return new DelegateCommand((args) =>
                {
                    Console.WriteLine(task.projectId);
                    task.login = Global.myLogin;
                    JConvert<Task_> taskJson = new JConvert<Task_>(task);
                    Console.WriteLine(taskJson.Json);
                    wSocClient.Send(taskJson.Json);
                    //while (InfoStatus.status == 0)
                    //{
                    //    Thread.Sleep(5);
                    //}
                    Clear();

                });
            }
        }

    }
}
