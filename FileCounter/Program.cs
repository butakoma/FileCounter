using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace FileCounter
{
    class Program
    {

        private static int counter = 0;

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            string curDir = Directory.GetCurrentDirectory();
            SearchFile(curDir);

            sw.Stop();

            File.WriteAllText(Path.Combine(curDir, "result.txt"), "Total： " + counter + "  Time : " + sw.Elapsed);
        }

        private static void SearchFile(string dirPath)
        {
            CountXmlFile(dirPath);

            var curDirInfo = new DirectoryInfo(dirPath);
            var dirs = curDirInfo.EnumerateDirectories("*");

            foreach (DirectoryInfo dir in dirs)
            {
                SearchFile(dir.FullName);
            }

        }

        private static void CountXmlFile(string dirPath)
        {
            var xmlFiles = Directory.EnumerateFiles(dirPath, "*.xml").ToArray();

            foreach (string file in xmlFiles)
            {
                if (Path.GetFileName(file) != "info.xml")
                {
                    counter++;
                }
            }
        }

    }
}
