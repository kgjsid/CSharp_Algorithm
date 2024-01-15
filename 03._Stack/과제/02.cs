using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._Stack.과제
{
    class _02
    {
        static void Main(String[] args)
        {
            Console.WriteLine($"{IsOk("[]{}[{{}}]")}");
        }

        static bool IsOk(string text)
        {
            bool ok = false;

            char temp;

            Stack<char> stack = new Stack<char>(text.Length);

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != '(' && text[i] != ')' && text[i] != '}' && text[i] != '{' && text[i] != '[' && text[i] != ']')
                    continue;

                if (text[i] == '(' || text[i] == '{' || text[i] == '[')
                    stack.Push(text[i]);
                else if(stack.Count != 0)
                {
                    if (stack.Peek() == '(' && text[i] == ')')
                    {
                        stack.Pop();
                    }
                    else if (stack.Peek() == '{' && text[i] == '}')
                    {
                        stack.Pop();
                    }
                    else if(stack.Peek() == '[' && text[i] == ']')
                    {
                        stack.Pop();
                    }
                }
            }

            if (stack.Count == 0)
                ok = true;
            else
                ok = false;

            return ok;
        }
    }
}
