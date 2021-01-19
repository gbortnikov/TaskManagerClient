using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskManagerClient.BasicClasses;

namespace TaskManagerClient.ViewModel
{
    public class NewProject
    {
        public string command = "NEWPROJECT";
        public string name;
        public string description;
    }

    static public class NewProjectStatus
    {
        static public string command;
        static public int status;
    }

    static public class ProjectListStatus
    {
        static public string command;
        static public int status;
        static public List<string> dataList;
    }
    static public class UserListStatus
    {
        static public string command;
        static public int status;
        static public List<string> dataList;
    }



    class NewProjectViewModel : BaseViewModel
    {
        struct SNewUserProject
        {
            public string command;
            public string selectedUser;
            public string selectedProject;
        }
        SNewUserProject sNewUserProject = new SNewUserProject() { command= "NEWUSERINPROJECT" };
        private NewProject project = new NewProject();
        private WSocClient wSocClient;
        static private List<string> projectList;
        static private List<string> userList;
        private string visability = "Hidden";

        public NewProjectViewModel()
        {
            wSocClient = WSocClient.getInstance();
            GetListProjectAsync(wSocClient);
            GetListUsertAsync(wSocClient);
        }

        public string SelectedUser
        {
            get { return sNewUserProject.selectedUser; }
            set
            {
                sNewUserProject.selectedUser = value;
                OnPropertyChanged();
            }
        }
        public string SelectedProject
        {
            get { return sNewUserProject.selectedProject; }
            set
            {
                sNewUserProject.selectedProject = value;
                OnPropertyChanged();
            }
        }
        public string Description
        {
            get { return project.description; }
            set
            {
                project.description = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get { return project.name; }
            set
            {
                project.name = value;
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
        public List<string> UsertList
        {
            get { return userList; }
            set
            {
                userList = value;
                OnPropertyChanged();
            }
        }


        static void WaitResponseProject()
        {
            while (ProjectListStatus.status == 0)
            {
                Thread.Sleep(5);
            }
            projectList = ProjectListStatus.dataList;

        }
        static async void GetListProjectAsync(WSocClient ws)
        {
            string getList = "{   \"command\": \"GETLISTPROJECT\" }";
            ws.Send(getList);
            await Task.Run(() => WaitResponseProject());
        }

        static void WaitResponseUser()
        {
            while (UserListStatus.status == 0)
            {
                Thread.Sleep(5);
            }
            userList = UserListStatus.dataList;
        }

        static async void GetListUsertAsync(WSocClient ws)
        {
            string getList = "{\"command\": \"GETLISTUSER\" }";
            ws.Send(getList);
            await Task.Run(() => WaitResponseUser());
        }

        public void Clear()
        {
            Description = null;
            Name = null;
        }

        public string Visibility
        {
            get { return visability; }
            set
            {
                visability = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddNewMember
        {
            get
            {
                return new DelegateCommand((args) =>
                {
                    GetListProjectAsync(wSocClient);
                    GetListUsertAsync(wSocClient);
                    ProjectList = projectList;
                    UsertList = userList;
                    if (Visibility == "Visible")
                        Visibility = "Hidden";
                    else
                        Visibility = "Visible";
                });
            }
        }


        public ICommand SendToServer
        {
            get
            {
                return new DelegateCommand((args) =>
                {
                    JConvert<NewProject> newProjectJson = new JConvert<NewProject>(project);
                    Console.WriteLine(newProjectJson.Json);
                    wSocClient.Send(newProjectJson.Json);
                    while (NewProjectStatus.status == 0)
                    {
                        Thread.Sleep(5);
                    }
                    Clear();
                });
            }
        }

        public ICommand SendToServerNewUserProject
        {
            get
            {
                return new DelegateCommand((args) =>
                {
                    JConvert<SNewUserProject> newUserPrjectJson = new JConvert<SNewUserProject>(sNewUserProject);
                    Console.WriteLine(newUserPrjectJson.Json);
                    wSocClient.Send(newUserPrjectJson.Json);
                    SelectedUser = null;
                });
            }
        }

    }
}
