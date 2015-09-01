using System.Collections.Generic;
using System.Text;

namespace FileIOUtility.Text
{
    public interface ITextFile
    {
        string ToString(string filename);

        string[] ToArray(string filename);

        IList<string> ToList(string filename);

        StringBuilder ToStringBuilder(string filename);

        object ToObject(string filename);

        void OverwriteTo(string filename, string text);

        void OverwriteTo(string filename, string[] lines);

        void OverwriteTo(string filename, IList<string> lines);

        void OverwriteTo(string filename, object o);

        void AppendTo(string filename, string text);

        void AppendTo(string filename, string[] lines);

        void AppendTo(string filename, IList<string> lines);

        void AppendTo(string filename, StringBuilder sb);

        void AppendTo(string filename, object o);
    }
}