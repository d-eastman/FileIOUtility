using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOUtility.Json
{
    public interface IJsonFile<T> 
    {
        void OverwriteTo(string filename, T jsonObject);

        T ToObject(string filename);
    }
}
