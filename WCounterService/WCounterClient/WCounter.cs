using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCounterClient.WordsCounterClient;

namespace WCounterClient
{
    class WCounter
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            string pathToReadText = "..\\test.txt";
            string text = File.ReadAllText(pathToReadText);

            text = text.ToLower();

            ServiceClient client = new ServiceClient();

            Dictionary<string, int> distinctWords = client.GetDictionary(text);

            string pathToWriteText = "..\\output.txt";
            File.WriteAllText(pathToWriteText, "");

            StringBuilder str2Write = new StringBuilder();

            foreach (var word in distinctWords)
                str2Write.Append(word.Key + '\t' + Convert.ToString(word.Value) + '\n');

            File.AppendAllText(pathToWriteText, str2Write.ToString());

            stopwatch.Stop();
            Console.WriteLine($"Time spent: {stopwatch.ElapsedMilliseconds}");

            Console.ReadLine();
        }
    }
}
