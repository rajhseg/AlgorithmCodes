using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Paranthesis
    {
        public static bool IsBalancedCorrectlyCheck(string val)
        {
            Stack<Brackets> stack = new Stack<Brackets>();

            for (int i = 0; i < val.Length; i++)
            {
                string b = val[i].ToString();
                Brackets a = (Brackets)b[0];

                if (a == Brackets.OpenParam || a == Brackets.OpenBracket || a == Brackets.OpenAngleBracket)
                {
                    stack.Push(a);
                }
                else
                {
                    try
                    {
                        var pk = stack.Peek();

                        if ((pk == Brackets.OpenParam && a == Brackets.CloseParam) ||
                        (pk == Brackets.OpenBracket && a == Brackets.CloseBracket) ||
                        (pk == Brackets.OpenAngleBracket && a == Brackets.CloseAngleBracket))
                        {
                            stack.Pop();
                        }
                        else
                        {
                            stack.Push(a);
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }

        enum Brackets
        {
            OpenParam = '{',
            CloseParam = '}',
            OpenBracket = '(',
            CloseBracket = ')',
            OpenAngleBracket = '[',
            CloseAngleBracket = ']'
        }
    }
}
