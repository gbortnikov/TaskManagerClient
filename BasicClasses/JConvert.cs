using Newtonsoft.Json;
using TaskManagerClient.Model;
using TaskManagerClient.ViewModel;

namespace TaskManagerClient.BasicClasses
{
    class JConvert<T>
    {
        private string json = "";
        public string Json { get { return json; } set { json = value; } }
        public JConvert(T arg)
        {
            json = JsonConvert.SerializeObject(arg, Formatting.Indented);
        }





    }
}
