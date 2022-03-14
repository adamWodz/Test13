using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLib
{
    public class Calculator
    {
        public static int Add(string s)
        {
            if (s.Length == 0) return 0;
            if (s.Length == 1)
                return Int32.Parse(s);
            else
            {
                List<string> separators = new List<string>();

                if (s[0] == '/' && s[1] == '/')
                {
                    if (s[2] == '[')
                    {
                        // znajdowanie gdzie znajdują się separatory
                        List<(int start, int end)> separatorIndexes = new List<(int, int)>();
                        for (int i = s.IndexOf('['); i > -1; i = s.IndexOf('[', i + 1))
                        {
                            int j = s.IndexOf(']', i + 1);
                            if (j == -1) break;

                            separatorIndexes.Add((i + 1, j - 1));
                            i = j;
                        }

                        // znajdowanie separatorów
                        foreach (var ind in separatorIndexes)
                        {
                            separators.Add(s.Substring(ind.start, ind.end - ind.start + 1));
                        }

                        s = s.Substring(separatorIndexes.Last().end + 1);
                        s = s.Substring(s.IndexOf('\n') + 1);
                    }
                    else
                    {
                        separators.Add(s[2].ToString());

                        if (s[2] == '\n')
                            s = s.Substring(s.IndexOf('\n') + 2);
                        else s = s.Substring(s.IndexOf('\n') + 1);

                    }

                }

                separators.Add(",");
                separators.Add("\n");

                string[] res;

                res = s.Split(separators.ToArray(), StringSplitOptions.None);

                int sum = 0;

                foreach (string str in res)
                {
                    int t = Int32.Parse(str);

                    if (t < 0) throw new Exception("negatives not allowed");

                    if (t <= 1000) sum += t;
                }

                return sum;
            }
        }
    }
}
