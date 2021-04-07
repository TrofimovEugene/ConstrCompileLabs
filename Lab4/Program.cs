using System;
using System.Collections.Generic;

namespace Lab4
{
    public class Program
    {
        private const string Str = "a+a*(a-a)+a#";
        private static int _index = 0;
        public static void Main(string[] args)
        {
            var stack = new Stack<char>();
            stack.Push('#');
            stack.Push('E');
            var X = stack.Peek();
            var ip = Str[_index];
            while (X != '#')
            {
                var a = ip;
                if (X == a)
                {
                    stack.Pop();
                    _index++;
                    ip = Str[_index];
                    Console.WriteLine($"удаляем {a}");
                }
                else if (X.IsTerminal())
                {
                    Console.WriteLine("Error terminal");
                    break;
                }
                else if (CheckRuleInTable(X, a) == 0)
                {
                    Console.WriteLine($"Error rule. {X} {a}");
                    break;
                }
                else
                    DoingRule(stack, CheckRuleInTable(X, a));

                X = stack.Peek();
            }
        }

        private static int CheckRuleInTable(char X, char a)
        {
            return X switch
            {
                'E' => a switch
                {
                    '(' => 1,
                    'a' => 1,
                    _ => 0
                },
                'S' => a switch
                {
                    ')' => 4,
                    '+' => 2,
                    '-' => 3,
                    '#' => 4,
                    _ => 0
                },
                'T' => a switch
                {
                    '(' => 5,
                    'a' => 5,
                    _ => 0
                },
                'R' => a switch
                {
                    ')' => 8,
                    '+' => 8,
                    '-' => 8,
                    '*' => 6,
                    '/' => 7,
                    '#' => 8,
                    _ => 0
                },
                'F' => a switch
                {
                    '(' => 9,
                    'a' => 10,
                    _ => 0
                },
                _ => 0
            };
        }

        private static void DoingRule(Stack<char> stack, int number)
        {
            switch (number)
            {
                case 1:
                    R1(stack);
                    break;
                case 2:
                    R2(stack);
                    break;
                case 3:
                    R3(stack);
                    break;
                case 4:
                    R4(stack);
                    break;
                case 5:
                    R5(stack);
                    break;
                case 6:
                    R6(stack);
                    break;
                case 7:
                    R7(stack);
                    break;
                case 8:
                    R8(stack);
                    break;
                case 9:
                    R9(stack);
                    break;
                case 10:
                    R10(stack);
                    break;
            }
        }

        private static void R1(Stack<char> stack)
        {
            Console.WriteLine($"{stack.Pop()} -> TS");
            stack.Push('S');
            stack.Push('T');
        }
        
        private static void R2(Stack<char> stack)
        {
            Console.WriteLine($"{stack.Pop()} -> +TS");
            stack.Push('S');
            stack.Push('T');
            stack.Push('+');
        }
        
        private static void R3(Stack<char> stack)
        {
            Console.WriteLine($"{stack.Pop()} -> -TS");
            stack.Push('S');
            stack.Push('T');
            stack.Push('-');
        }
        
        private static void R4(Stack<char> stack)
        {
            Console.WriteLine($"{stack.Pop()} -> #");
        }
        
        private static void R5(Stack<char> stack)
        {
            Console.WriteLine($"{stack.Pop()} -> FR");
            stack.Push('R');
            stack.Push('F');
        }
        
        private static void R6(Stack<char> stack)
        {
            Console.WriteLine($"{stack.Pop()} -> *FR");
            stack.Push('R');
            stack.Push('F');
            stack.Push('*');
        }
        
        private static void R7(Stack<char> stack)
        {
            Console.WriteLine($"{stack.Pop()} -> /FR");
            stack.Push('R');
            stack.Push('F');
            stack.Push('/');
        }
        
        private static void R8(Stack<char> stack)
        {
            Console.WriteLine($"{stack.Pop()} -> #");
        }
        
        private static void R9(Stack<char> stack)
        {
            Console.WriteLine($"{stack.Pop()} -> (E)");
            stack.Push(')');
            stack.Push('E');
            stack.Push('(');
        }
        
        private static void R10(Stack<char> stack)
        {
            Console.WriteLine($"{stack.Pop()} -> a");
            stack.Push('a');
        }
    }
}