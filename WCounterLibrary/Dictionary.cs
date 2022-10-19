using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace WCounterLibrary
{
    public static class Dictionary
    {
        private static List<string> DeleteNonWords(string text)
        {
            string pattern = @"[A-Za-zА-ЯЁа-яё]\w+";
            return Regex.Matches(text, pattern).Cast<Match>().Select(k => k.ToString()).ToList();
        }

        private static Dictionary<string, int> _GetDictionary(string text)
        {
            List<string> words = DeleteNonWords(text);
            Dictionary<string, int> distinctWords = new Dictionary<string, int>();

            foreach(var word in words)
            {
                if (distinctWords.ContainsKey(word))
                    distinctWords[word] += 1;
                else
                    distinctWords.Add(word, 1);
            }

            return distinctWords.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        public static Dictionary<string, int> GetDictionaryWMThreading(string text)
        {
            List<string> words = DeleteNonWords(text);
            ConcurrentDictionary<string, int> distinctWords = new ConcurrentDictionary<string, int>();

            Parallel.ForEach(words, word =>
            {
                distinctWords.AddOrUpdate(word, 1, (key, oldValue) => oldValue + 1);
            });

            return distinctWords.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
