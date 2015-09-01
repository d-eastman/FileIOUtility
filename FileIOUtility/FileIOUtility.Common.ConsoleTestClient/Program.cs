using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOUtility.Common.ConsoleTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FileBase.Instance.Exists(@"c:\temp\cat.json"));

            FileBase.Instance.CopyOverwrite(@"c:\temp\cat.json", @"c:\temp\cat.copy.json");
            Console.WriteLine(FileBase.Instance.Exists(@"c:\temp\cat.copy.json"));

            FileBase.Instance.Rename(@"c:\temp\cat.copy.json", @"c:\temp\cat.copy2.json");
            Console.WriteLine(FileBase.Instance.Exists(@"c:\temp\cat.copy.json"));
            Console.WriteLine(FileBase.Instance.Exists(@"c:\temp\cat.copy2.json"));

            FileBase.Instance.Delete(@"c:\temp\cat.copy.json");
            FileBase.Instance.Delete(@"c:\temp\cat.copy2.json");
            Console.WriteLine(FileBase.Instance.Exists(@"c:\temp\cat.copy.json"));
            Console.WriteLine(FileBase.Instance.Exists(@"c:\temp\cat.copy2.json"));

            Console.ReadKey();


        }
    }
}
