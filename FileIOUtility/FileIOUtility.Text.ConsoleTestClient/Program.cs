using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileIOUtility.Text;

namespace FileIOUtility.Text.ConsoleTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            
            TextFile.Instance.OverwriteTo(@"c:\temp\1234test.txt", "blah blah blah");
            Console.WriteLine(TextFile.Instance.ToString(@"c:\temp\1234test.txt"));            
            Console.WriteLine(TextFile.Instance.Exists(@"c:\temp\1234test.txt"));

            TextFile.Instance.Delete(@"c:\temp\1234test.txt");
            Console.WriteLine(TextFile.Instance.Exists(@"c:\temp\1234test.txt"));

            Console.ReadKey();
        }
    }
}
