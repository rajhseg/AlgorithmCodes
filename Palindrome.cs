using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Word
    {
        public string Text { get; set; }

        public int CharsToAdd { get; set; }
    }

    public class Palindrome
    {
        private static int MinInsertionHelper(string str, int start, int end)
        {
            if (start > end)
                return 0;

            if (start == end)
                return 0;

            if (str[start] == str[end])
            {
                return MinInsertionHelper(str, start + 1, end - 1);
            }
            else
            {
                return Math.Min(MinInsertionHelper(str, start + 1, end), MinInsertionHelper(str, start, end - 1)) + 1;
            }
        }

        public static int MinLettersToFormPalindrome1(string str)
        {
            return MinInsertionHelper(str, 0, str.Length - 1);
        }

        public static int MinLettersToFormPalindrome2(string str)
        {
            // code here
            int charsToAdd = 0;
            int left = 0;
            int right = str.Length - 1;

            List<Word> palindrome = new List<Word>();

            Queue<Word> words = new Queue<Word>();
            words.Enqueue(new Word { Text = str, CharsToAdd = charsToAdd });


            while (words.Count > 0)
            {
                Word a = words.Dequeue();
                List<Word> list = GenerateWords(a.Text, a.CharsToAdd);

                if (list.Count == 0)
                {
                    palindrome.Add(a);
                }
                else
                {
                    list.ForEach(x => words.Enqueue(x));
                }
            }

            return palindrome.Min(x => x.CharsToAdd);
        }


        public static String addChar(String str, char ch, int position)
        {
            StringBuilder sb = new StringBuilder(str);
            sb.Insert(position, ch);
            return sb.ToString();
        }

        private static List<Word> GenerateWords(string str, int charsToAdd)
        {
            List<Word> words = new List<Word>();

            if (Check(str))
            {
                return new List<Word>();
            }

            int left = 0;
            int right = str.Length - 1;

            while (left < right)
            {
                char a = str[left];
                char b = str[right];

                if (a == b)
                {
                    left++;
                    right--;
                }
                else
                {
                    string val1 = addChar(str, a, right + 1);
                    Console.WriteLine(str + "-" + val1);
                    words.Add(new Word { Text = val1, CharsToAdd = charsToAdd + 1 });

                    string val2 = addChar(str, b, left);
                    Console.WriteLine(str + "-" + val2);
                    words.Add(new Word { Text = val2, CharsToAdd = charsToAdd + 1 });

                    break;
                }
            }

            return words;
        }

        public static bool Check(string strData)
        {
            for (int i = 0; i < Math.Ceiling(strData.Length / (decimal)2); i++)
            {
                char first = strData[i];
                char last = strData[strData.Length - 1 - i];

                if (first != last)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
