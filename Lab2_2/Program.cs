using System;
using System.Collections.Generic;

namespace Lab2_2
{
    public class Program
    {
        public static string State;
        public static void Main(string[] args)
        {
            var s = "0000011111";
            var stack = new Stack<char>();
            State = "N";
            try
            {
                foreach (var ch in s)
                {
                    switch (ch)
                    {
                        case '0':
                            stack.Push(ch);
                            State = "0";
                            break;
                        case '1':
                            stack.Pop();
                            State = "1";
                            break;
                    }
                }
            }
            catch (InvalidOperationException e)
            {
                // ignore
            }
            
            if (stack.TryPop(out  _))
                Console.WriteLine("Цепочка не распознана. Нулей больше чем единиц");
        }
    }
}