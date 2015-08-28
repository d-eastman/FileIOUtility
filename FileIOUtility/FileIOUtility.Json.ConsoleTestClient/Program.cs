using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FileIOUtility.Json.ConsoleTestClient
{
    class Program
    {
        class Cat
        {
            public string Name { get; set; }
            public Color Color { get; set; }
            public bool HasLongWhiskers { get; set; }
            public IList<string> NickNames { get; set; }
            public Cat()
            {
                NickNames = new List<string>();
            }
            public override string ToString()
            {
                return String.Format("Name: {0}, Color: {1}, HasLongWhiskers: {2}, NickNames: {3}",
                    Name, Color.ToString(), HasLongWhiskers, String.Join("; ", NickNames));
            }
        }

        static void Main(string[] args)
        {
            object content = "this is a string";
            JsonFile<object>.Instance.OverwriteTo(@"c:\temp\string.json", content);
            Console.WriteLine("string: " + JsonFile<object>.Instance.ToObject(@"c:\temp\string.json"));

            var cat = new Cat() { Name = "Cat name", Color = Color.Black, HasLongWhiskers = true };
            cat.NickNames.Add("Spanky");
            cat.NickNames.Add("John Boy");
            JsonFile<Cat>.Instance.OverwriteTo(@"c:\temp\cat.json", cat);
            Console.WriteLine("Cat: " + JsonFile<Cat>.Instance.ToObject(@"c:\temp\cat.json"));

            JsonFile<string[]>.Instance.OverwriteTo(@"c:\temp\files.json", System.IO.Directory.GetFiles(@"C:\temp"));
            JsonFile<string[]>.Instance.ToObject(@"c:\temp\files.json")
                .ToList<string>().ForEach(x => Console.WriteLine("string array element: " + x));

            var cats = new List<Cat>();
            cats.Add(new Cat() { Name = "Cat 1", Color = Color.Brown, HasLongWhiskers = true });
            cats.FindLast(x => true).NickNames.Add("Tiger");
            cats.Add(new Cat() { Name = "Cat 2", Color = Color.OrangeRed });
            JsonFile<List<Cat>>.Instance.OverwriteTo(@"c:\temp\cats.json", cats);
            JsonFile<List<Cat>>.Instance.ToObject(@"c:\temp\cats.json")
                .ForEach(x => Console.WriteLine("Cat: " + x)); //Color doesn't rehydrate

            Console.ReadKey();

        }
    }
}
