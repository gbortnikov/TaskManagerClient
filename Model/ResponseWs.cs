using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TaskManagerClient.ViewModel;

namespace TaskManagerClient.Model
{

    class ResponseWs
    {
        public ResponseWs(string res)
        {
            var answer = JsonConvert.DeserializeObject<Dictionary<string, string>>(res);
            Console.WriteLine(answer["command"], answer["status"]);
            if (answer["command"] == "AUTH")
            {
                AuthStatus.status = int.Parse( answer["status"]);
            }
            else if (answer["command"] == "REG")
            {
                RegStatus.status = int.Parse(answer["status"]);
            }

        }
    }



}
