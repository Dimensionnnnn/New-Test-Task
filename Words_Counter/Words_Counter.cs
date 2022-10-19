using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Text;
using System.Diagnostics;

namespace Words_Counter
{
    class Words_Counter
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            string pathToReadText = "..\\test.txt";
            string text = File.ReadAllText(pathToReadText);

            text = text.ToLower();

            Type typeClass = typeof(WCounterLibrary.Dictionary);
            if (typeClass == null)
                return;

            //MethodInfo dictMethod = typeClass.GetMethod("_GetDictionary",
            //    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            //if (dictMethod == null)
            //    return;

            //Dictionary<string, int> distinctWords = (Dictionary<string, int>)dictMethod.Invoke(null, new object[] { text });
            //if (distinctWords == null)
            //    return;

            MethodInfo dictMethod = typeClass.GetMethod("GetDictionaryWMThreading",
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            if (dictMethod == null)
                return;

            Dictionary<string, int> distinctWords = (Dictionary<string, int>)dictMethod.Invoke(null, new object[] { text });
            if (distinctWords == null)
                return;

            string pathToWriteText = "..\\output.txt";
            File.WriteAllText(pathToWriteText, "");

            StringBuilder str2Write = new StringBuilder();

            foreach (var word in distinctWords)
                str2Write.Append(word.Key + '\t' + Convert.ToString(word.Value) + '\n');

            File.AppendAllText(pathToWriteText, str2Write.ToString());

            stopWatch.Stop();
            Console.WriteLine($"Time Spent: {stopWatch.ElapsedMilliseconds}");
        }
    }
}
