using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string dir = args[0];
            Console.WriteLine(dir);
            List<string> files = new List<string>(System.IO.Directory.GetFiles(dir));
            List<long> numbers = new List<long>();

            foreach(string s in files)
            {
                long val;
                string[] path = s.Split('\\');
                string name = path[path.Length - 1];
                if(long.TryParse(name.Split('.')[0], out val))
                {
                    numbers.Add(val);
                }
            }

            numbers.Sort();

            StringBuilder sb = new StringBuilder();
            long previous = numbers[0];
            for(int i = 1; i < numbers.Count; i++)
            {
                sb.Append("file '").Append(previous).Append(".jpg'").Append(Environment.NewLine);
                sb.Append("duration ").Append((numbers[i] - previous)/1000f).Append(Environment.NewLine);
                previous = numbers[i];
            }
            System.IO.File.WriteAllText(System.IO.Path.Combine(dir, "input.txt"), sb.ToString());

            Console.WriteLine("Complete");
            Console.ReadLine();
        }
    }
}
