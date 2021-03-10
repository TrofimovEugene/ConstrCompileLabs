using System;
using System.Collections.Generic;

namespace Lab2_2
{
    public static class Program
    {
        private static string State { get; set; }

        public static void Main(string[] args)
        {
            const string s = "0000011111";
            var stack = new Stack<char>();
            State = "N";
            try
            {
                for (var i = 0; i < s.Length; i++)
                {
                    switch (s[i])
                    {
                        case '0':
                            if (i > 0)
                            {    if (s[i - 1] == s[i])
                                {
                                    stack.Push(s[i]);
                                    State = "0";
                                }
                                else
                                {
                                    throw new InvalidOperationException();
                                }
                            }
                            else
                            {
                                stack.Push(s[i]);
                                State = "0";
                            }
                            break;
                        case '1':
                            if (i < s.Length - 1)
                            {
                                if (s[i] == s[i + 1])
                                {
                                    stack.Pop();
                                    State = "1";
                                }
                                else
                                {
                                    throw new InvalidOperationException();
                                }
                            }
                            else
                            {
                                stack.Pop();
                                State = "1";
                            }

                            break;
                    }
                }

                State = "E";
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Цепочка не распознана.");
                return;
            }
            
            if (stack.TryPop(out  _))
                Console.WriteLine("Цепочка не распознана.");
            else
                if (State == "E")
                    Console.WriteLine("Цепочка распознана.");
        }
    }
}