using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TaskManagerClient.BasicClasses;
using TaskManagerClient.View;

namespace TaskManagerClient.ViewModel
{
    static public class MyProjectListStatus
    {
        static public string command;
        static public int status;
        static public List<string> dataList;
    }
    public class Task_
    {
        public string command = "NEWTASK";
        public string login;
        public string name;
        public string discription;
        public string projectName;
        public int condition=0;
        public DateTime startDate;
        public DateTime endDate;
    }

    class TaskViewModel : BaseViewModel
    {
        private WSocClient wSocClient = WSocClient.getInstance();
        private Task_ task = new Task_();
        private NewProjectPage projectPage = new NewProjectPage();
        static private List<string> projectList;

        static void WaitResponseProject()
        {
            while (MyProjectListStatus.status == 0)
            {
                Thread.Sleep(5);
            }
            projectList = MyProjectListStatus.dataList;

        }
        static async void GetListProjectAsync(WSocClient ws)
        {
            string getList = "{   \"command\": \"GETMYLISTPROJECT\",\"login\":\""+ Global.myLogin+ "\"}";
            ws.Send(getList);
            await Task.Run(() => WaitResponseProject());
        }

        public TaskViewModel()
        {
            GetListProjectAsync(wSocClient);
        }


        public Page ProjectPage
        {
            get
            {
                return projectPage;
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
        public List<string> ProjectList
        {
            get { return projectList; }
            set
            {
                projectList = value;
                OnPropertyChanged();
            }
        }

        public string ProjectName
        {
            get { return task.projectName; }
            set
            {
                task.projectName = value;
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
            ProjectName = null;
        }

        public ICommand SendToServer
        {
            get
            {
                return new DelegateCommand((args) =>
                {
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
        public ICommand Update
        {
            get
            {
                return new DelegateCommand((args) =>
                {
                    GetListProjectAsync(wSocClient);
                    ProjectList = projectList;
                });
            }
        }

    }
}
