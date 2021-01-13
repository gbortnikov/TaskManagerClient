using Newtonsoft.Json;
using TaskManagerClient.Model;
using TaskManagerClient.ViewModel;

namespace TaskManagerClient.BasicClasses
{
    class JConvert<T>
    {
        private string json = "";
        public string Json { get { return json; } set { json = value; } }

        //public JConvert(Auth auth)
        //{
        //     json = JsonConvert.SerializeObject(auth, Formatting.Indented);
        //}
        //public JConvert(Reg reg)
        //{
        //    json = JsonConvert.SerializeObject(reg, Formatting.Indented);
        //}

        //public JConvert(Info info)
        //{
        //    json = JsonConvert.SerializeObject(info, Formatting.Indented);
        //}

        public JConvert(T arg)
        {
            json = JsonConvert.SerializeObject(arg, Formatting.Indented);
        }





    }
}
