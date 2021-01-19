using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TaskManagerClient.Model;
using TaskManagerClient.ViewModel;

namespace TaskManagerClient.BasicClasses
{
    class Answer
    {
        public string command;
        public int status;
        public List<string> dataList;
    }

    class ResponseWs
    {
        public ResponseWs(string res)
        {
            Answer answer = JsonConvert.DeserializeObject<Answer>(res);
            Console.WriteLine(answer.command, answer.status);
            if (answer.command == "AUTH")
            {
                AuthStatus.status = answer.status;
            }
            else if (answer.command == "REG")
            {
                RegStatus.status = answer.status;
            }
            else if (answer.command == "INFO")
            {
                InfoStatus.status = answer.status;
            }
            else if (answer.command == "NEWPROJECT")
            {
                NewProjectStatus.status = answer.status;
            }
            else if (answer.command == "GETLISTPROJECT")
            {
                ProjectListStatus.status = answer.status;
                ProjectListStatus.dataList = answer.dataList;
            }
            else if (answer.command == "GETLISTUSER")
            {
                UserListStatus.status = answer.status;
                UserListStatus.dataList = answer.dataList;
            }
            else if (answer.command == "GETMYLISTPROJECT")
            {
                MyProjectListStatus.status = answer.status;
                MyProjectListStatus.dataList = answer.dataList;
            }
        }
    }



}
