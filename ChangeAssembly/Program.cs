using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 2 && File.Exists(args[0]))
            {
                List<string> oNewList = new List<string>();

                string[] lines = System.IO.File.ReadAllLines(args[0]);
                foreach (string line in lines)
                {
                    if(line.StartsWith("[assembly: AssemblyVersion(\""))
                    {
                        int length = "[assembly: AssemblyVersion(\"".Length;
                        string version = line.Substring(length, line.Length - length - 3);
                        string[] tokens = version.Split('.');
                        oNewList.Add($"[assembly: AssemblyVersion(\"{tokens[0]}.{tokens[1]}.{args[1]}.{tokens[3]}\")]");
                    }
                    else if(line.StartsWith("[assembly: AssemblyFileVersion(\""))
                    {
                        int length = "[assembly: AssemblyFileVersion(\"".Length;
                        string version = line.Substring(length, line.Length - length - 3);
                        string[] tokens = version.Split('.');
                        oNewList.Add($"[assembly: AssemblyFileVersion(\"{tokens[0]}.{tokens[1]}.{args[1]}.{tokens[3]}\")]");
                    }
                    else
                    {
                        oNewList.Add(line);
                    }
                }

                File.WriteAllLines(args[0], oNewList);
            }
        }
    }
}
