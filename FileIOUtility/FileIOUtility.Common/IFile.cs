using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOUtility.Common
{
    public interface IFile
    {
        bool Exists(string filename);

        void Delete(string filename);

        void Rename(string oldFilename, string newFilename);

        void CopyOver(string oldFilename, string newFilename);
    }
}
