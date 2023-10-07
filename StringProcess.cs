using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class StringProcess
    {
        public static string smallestWindow(string s, string p)
        {
            List<int> indexes = GetIndexes(s, p);
            List<string> _combination = new List<string>();

            var filteredIndex = indexes.Where(x => x + p.Length <= s.Length).ToList();
            int h = 0;

            while (h<filteredIndex.Count())
            {
                var item = filteredIndex[h];
                int k = -1;
                int len = p.Length;
                int inc = 0;
                List<char> word = new List<char>(p);
                bool repeat = false;

                for (int i = item; i < s.Length; i++)
                {
                    if (p.Contains(s[i]))
                    {
                        if (word.Contains(s[i]))
                        {
                            word.Remove(s[i]);
                            inc++;
                        }
                        else
                        {
                            repeat = true;
                        }

                        if(inc == len)
                        {
                            k = i;
                            break;
                        }
                    }
                }

                if (k > -1)
                {
                    var _matchWord = s.Substring(item, k - item+1);
                    _combination.Add(_matchWord);

                    if (!repeat)
                    {
                        filteredIndex = filteredIndex.Where(x => x > k).ToList();
                        h = -1;
                    }
                }
                
                h++;
            }

            int minLen = _combination.Min(x => x.Length);

            return _combination == null ? "-1" : _combination.FirstOrDefault(x=>x.Length == minLen);
        }

        public static List<int> GetIndexes(string s, string p)
        {
            List<int> index = new List<int>();

            for (int i = 0; i < p.Length; i++)
            {
                for (int j = 0; j < s.Length; j++)
                {
                    if (p[i] == s[j])
                    {
                        index.Add(j);
                    }
                }
            }

            return index;
        }

        public static string Reverse(string strdata)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = strdata.Length -1; i >-1; i--)
            {
                builder.Append(strdata[i]);
            }

            return builder.ToString();
        }

        public static List<StringMatch> GetStringMatch(string value1, string value2)
        {
            string result = string.Empty;
            List<StringMatch> matches = new List<StringMatch>();


            for (int i = 0; i < value1.Length; i++)
            {
                for (int j = 0; j < value2.Length; j++)
                {
                    if(value1[i] == value2[j])
                    {
                        result+=value1[i];
                        i++;                                               
                    }
                    else
                    {
                        if (result != string.Empty)
                        {
                            if (result.Length > 1)
                            {
                                matches.Add(new StringMatch { SubString = result, String1Index = i-result.Length, String2Index = j-result.Length });
                            }

                            result = string.Empty;
                        }
                    }
                }
            }

            return matches;
        }
    }

    internal class StringMatch
    {
        public string SubString { get; set; }

        public int String1Index { get; set; }

        public int String2Index { get; set; }
    }
}
