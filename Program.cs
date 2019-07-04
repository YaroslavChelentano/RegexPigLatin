using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PigLatinRegex
{
    class Program
    {
        public static string PigLatinTranslator(string s)
        {
            s = Regex.Replace(s, @"(\b[a|e|i|o|u]\w+)", "$1hay", RegexOptions.IgnoreCase);
            List<string> words = new List<string>();
            foreach (Match v in Regex.Matches(s, @"\w+"))
            {
                string result;
                if (!v.Value.EndsWith("hay"))
                {
                    result = Regex.Replace(v.Value, @"([^a|e|i|o|u]*)([a|e|i|o|u])(\w+)", "$2$3$1ay", RegexOptions.IgnoreCase);
                    words.Add(result);
                }
                else { words.Add(v.Value); }
            }
            s = string.Join(" ", words); // зєднує масив 
            words.Clear();
            foreach (Match v in Regex.Matches(s, @"\w+"))
            {
                string result = Regex.Replace(v.Value, @"\b([^a|e|i|o|u]+)\b", "$1ay", RegexOptions.IgnoreCase);
                words.Add(result);
            }
            s = string.Join(" ", words);
            return s;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello enter text:");
            string text = Console.ReadLine();
            Console.WriteLine("Edited text");
            Console.WriteLine(PigLatinTranslator(text));
        }
    }
}