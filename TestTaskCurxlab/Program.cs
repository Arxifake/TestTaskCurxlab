using System;
using System.IO;
using System.Text.RegularExpressions;

namespace TestTaskCurxlab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rightPass = 0;
            string filePath = "../../test.txt";
            string pattern = @"\d+";
            Regex regex = new Regex(pattern);

            var lines = File.ReadLines(filePath);

            foreach (var line in lines) 
            {
                var splitLine = line.Split(' ');

                MatchCollection matches = regex.Matches(splitLine[1]);

                char key = Convert.ToChar(splitLine[0]);
                int lowValue = Convert.ToInt32(matches[0].Value);
                int highValue = Convert.ToInt32(matches[1].Value);
                int count = 0;

                foreach(char c in splitLine[2]) 
                {
                    if (c == key)
                        count++;
                }
                if(lowValue<=count&&count<=highValue)
                    rightPass++;
            }
            Console.WriteLine($"Count of valid passwords: {rightPass}");
            Console.ReadKey();
        }
    }
}
