using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FileIOUtility.Common;

namespace FileIOUtility.Text
{
    public class TextFile : FileBase, IFile, ITextFile
    {
        public static readonly TextFile Instance = new TextFile();

        private TextFile()
        {
            //Clients cannot instantiate this class directly
        }

        public string ToString(string filename)
        {
           using(StreamReader reader = new StreamReader(filename))
           {
               return reader.ReadToEnd();
           }
        }

        public void OverwriteTo(string filename, string text)
        {
            using (StreamWriter writer = new StreamWriter(filename, append: false))
            {
                writer.Write(text);
            }
        }











        //public bool Exists(string filename)
        //{
        //    return File.Exists(filename);
        //}

        //public void Delete(string filename)
        //{
        //    File.Delete(filename);
        //}

        //public void CreateIfNotExists(string filename)
        //{
        //    throw new NotImplementedException();
        //}

        //public string[] ToArray(string filename)
        //{
        //    throw new NotImplementedException();
        //}

        //public IList<string> ToList(string filename)
        //{
        //    throw new NotImplementedException();
        //}

        //public object ToObject(string filename)
        //{
        //    throw new NotImplementedException();
        //}

        //public string ToString(string filename)
        //{
        //    throw new NotImplementedException();
        //}


        

        //public void AppendTo(string filename, string text)
        //{
        //    throw new NotImplementedException();
        //}

        //public void AppendTo(string filename, string[] lines)
        //{
        //    throw new NotImplementedException();
        //}

        //public void AppendTo(string filename, IList<string> lines)
        //{
        //    throw new NotImplementedException();
        //}

        //public void AppendTo(string filename, object o)
        //{
        //    throw new NotImplementedException();
        //}

        //public void OverwriteTo(string filename, string text)
        //{
        //    throw new NotImplementedException();
        //}

        //public void OverwriteTo(string filename, string[] lines)
        //{
        //    throw new NotImplementedException();
        //}

        //public void OverwriteTo(string filename, IList<string> lines)
        //{
        //    throw new NotImplementedException();
        //}

        //public void OverwriteTo(string filename, object o)
        //{
        //    throw new NotImplementedException();
        //}


        //public void Rename(string oldFilename, string newFilename)
        //{
        //    throw new NotImplementedException();
        //}

        //public void CopyOver(string oldFilename, string newFilename)
        //{
        //    throw new NotImplementedException();
        //}

        //bool IFile.Exists(string filename)
        //{
        //    throw new NotImplementedException();
        //}

        //void IFile.Delete(string filename)
        //{
        //    throw new NotImplementedException();
        //}

        //object IFile.ToObject(string filename)
        //{
        //    throw new NotImplementedException();
        //}

        //void IFile.Rename(string oldFilename, string newFilename)
        //{
        //    throw new NotImplementedException();
        //}

        //void IFile.CopyOver(string oldFilename, string newFilename)
        //{
        //    throw new NotImplementedException();
        //}

        
    }
}
