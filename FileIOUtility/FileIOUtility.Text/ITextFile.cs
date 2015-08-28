using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOUtility.Text
{
    public interface ITextFile
    {
        string ToString(string filename);

        void OverwriteTo(string filename, string text);
    }
}
