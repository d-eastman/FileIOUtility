using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileIOUtility.Text;
using System.Web.Script.Serialization;

namespace FileIOUtility.Json
{
    public class JsonFile<T> : IJsonFile <T>
    {
        public static readonly new JsonFile<T> Instance = new JsonFile<T>();

        private JsonFile()
        {
            //Clients cannot instantiate this class directly
        }

        public void OverwriteTo(string filename, T jsonObject)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            TextFile.Instance.OverwriteTo(filename, serializer.Serialize(jsonObject));
        }

        public T ToObject(string filename)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(TextFile.Instance.ToString(filename));
        }
    }
}
