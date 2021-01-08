using Newtonsoft.Json;
using TaskManagerClient.ViewModel;

namespace TaskManagerClient.Model
{
    class JConvert
    {
        private string json = "";
        public string Json { get { return json; } set { json = value; } }

        public JConvert(Auth auth)
        {
             json = JsonConvert.SerializeObject(auth, Formatting.Indented);
        }
        public JConvert(Reg reg)
        {
            json = JsonConvert.SerializeObject(reg, Formatting.Indented);
        }






    }
}
