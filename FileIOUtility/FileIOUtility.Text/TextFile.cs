using FileIOUtility.Common;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileIOUtility.Text
{
    public class TextFile : FileBase, IFile, ITextFile
    {
        public static readonly new TextFile Instance = new TextFile(); //This instance variable replaces base class instance variable

        private const bool WRITE_MODE_APPEND = true;

        private const bool WRITE_MODE_OVERWRITE = false;

        private TextFile()
        {
            //Clients cannot instantiate this class directly
        }

        public string ToString(string filename)
        {
            return StreamReaderReadToEnd(filename);
        }

        public string[] ToArray(string filename)
        {
            return StreamReaderReadLines(filename).ToArray<string>();
        }

        public IList<string> ToList(string filename)
        {
            return StreamReaderReadLines(filename);
        }

        public StringBuilder ToStringBuilder(string filename)
        {
            return new StringBuilder(StreamReaderReadToEnd(filename));
        }

        public object ToObject(string filename)
        {
            return (object)StreamReaderReadToEnd(filename);
        }

        public void OverwriteTo(string filename, string text)
        {
            StreamWriterWrite(filename, text, writeMode: WRITE_MODE_OVERWRITE);
        }

        public void OverwriteTo(string filename, string[] lines)
        {
            StreamWriterWrite(filename, lines, writeMode: WRITE_MODE_OVERWRITE);
        }

        public void OverwriteTo(string filename, IList<string> lines)
        {
            StreamWriterWrite(filename, lines.ToArray<string>(), writeMode: WRITE_MODE_OVERWRITE);
        }

        public void OverwriteTo(string filename, object o)
        {
            StreamWriterWrite(filename, o.ToString(), writeMode: WRITE_MODE_OVERWRITE);
        }

        public void AppendTo(string filename, string text)
        {
            StreamWriterWrite(filename, text, writeMode: WRITE_MODE_APPEND);
        }

        public void AppendTo(string filename, string[] lines)
        {
            StreamWriterWrite(filename, lines, writeMode: WRITE_MODE_APPEND);
        }

        public void AppendTo(string filename, IList<string> lines)
        {
            StreamWriterWrite(filename, lines.ToArray<string>(), writeMode: WRITE_MODE_APPEND);
        }

        public void AppendTo(string filename, StringBuilder sb)
        {
            StreamWriterWrite(filename, sb.ToString(), writeMode: WRITE_MODE_APPEND);
        }

        public void AppendTo(string filename, object o)
        {
            StreamWriterWrite(filename, o.ToString(), writeMode: WRITE_MODE_APPEND);
        }

        private void StreamWriterWrite(string filename, string text, bool writeMode)
        {
            string[] textAsArray = new string[1];
            textAsArray[0] = text;
            StreamWriterWrite(filename, textAsArray, writeMode);
        }

        private void StreamWriterWrite(string filename, string[] lines, bool writeMode)
        {
            using (StreamWriter writer = new StreamWriter(filename, append: writeMode))
            {
                foreach (string line in lines)
                {
                    writer.Write(line);
                }
            }
        }

        private string StreamReaderReadToEnd(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                return reader.ReadToEnd();
            }
        }

        private IList<string> StreamReaderReadLines(string filename)
        {
            IList<string> ret = new List<string>();

            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    ret.Add(line);
                }
                reader.Close();
            }

            return ret.ToArray<string>();
        }
    }
}