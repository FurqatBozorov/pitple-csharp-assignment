using System;
using System.IO;

namespace projectthree
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Furqat\Downloads\archive\data.csv";
            string path2 = @"C:\Users\Furqat\Downloads\archive\fifa-tab.tsv";
            string result = File.ReadAllText(path);
            
            string convertedString =result.Replace("," , "  ") ;

            File.WriteAllText(path2, convertedString);
            
            Console.WriteLine(convertedString);
        }
    }
}
