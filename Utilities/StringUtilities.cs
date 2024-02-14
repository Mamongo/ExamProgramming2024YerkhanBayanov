using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class StringUtilities
    {
        public static int LongWordsCount(string input)
        {
            string[] words = input.Split(' ');
            int count = 0;

            foreach (string word in words)
            {
                if (word.Length > 2)
                {
                    count++;
                }
            }

            return count;
        }

        public static string ToSpinalCase(string input)
        {
            string[] words = input.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].ToLower();
            }

            return string.Join("-", words);
        }
    }

    public static class StringExtensions
    {
        public static string ToPascalCase(this string input)
        {
            string[] words = input.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
            }

            return string.Join("", words);
        }
    }
}

