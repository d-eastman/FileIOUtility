using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileIOUtility.Common
{
    public class FileBase : IFile
    {
        public static readonly FileBase Instance = new FileBase();

        protected FileBase()
        {
            //Clients cannot instantiate this class directly
        }

        public bool Exists(string filename)
        {
            return File.Exists(filename);
        }

        public void Delete(string filename)
        {
            File.Delete(filename);
        }

        public void Rename(string oldFilename, string newFilename)
        {
            if (File.Exists(oldFilename))
            {
                //Only delete the destination if the old file exists
                File.Delete(newFilename);
            }
            File.Move(oldFilename, newFilename);
        }

        public void CopyOver(string oldFilename, string newFilename)
        {
            File.Copy(oldFilename, newFilename, overwrite: true);
        }
    }
}
