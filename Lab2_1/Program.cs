using System;
using System.Text.RegularExpressions;

namespace Lab2_1
{
    public class Program
    {
        public static int State;

        public static void Main(string[] args)
        {
            //var stringInput = Console.ReadLine();
            /*var table = new[,] { 
                {null, "A", "B", "C"},
                {"0", "1", "0", "0"},
                {"1", "1", "2", "0"},
                {"2", "3", "0", "0"},
                {"3", "1", "4", "0"},
                {"4", "5", "0", "0"},
                {"5", "1", "5", "6"}
            };*/

            var s = "ABABAC";
            var reg_ex = new Regex(@"[A-Z]");
            var matches_a = reg_ex.Matches(s);
            State = 0;
            foreach (Match match in matches_a)
            {
                switch (State)
                {
                    case 0:
                        switch (match.Value)
                        {
                            case "A":
                                State = 1;
                                break;
                            case "B":
                                continue;
                            case "C":
                                continue;
                            default:
                                Console.WriteLine("Цепочка не распознана");
                                State = -1;
                                break;
                        }
                        continue;
                    case 1:
                        switch (match.Value)
                        {
                            case "A":
                                continue;
                            case "B":
                                State = 2;
                                break;
                            case "C":
                                State = 0;
                                break;
                            default:
                                Console.WriteLine("Цепочка не распознана");
                                State = -1;
                                break;
                        }
                        continue;
                    case 2:
                        switch (match.Value)
                        {
                            case "A":
                                State = 3;
                                break;
                            case "B":
                                State = 0;
                                break;
                            case "C":
                                State = 0;
                                break;
                            default:
                                Console.WriteLine("Цепочка не распознана");
                                State = -1;
                                break;
                        }
                        continue;
                    case 3:
                        switch (match.Value)
                        {
                            case "A":
                                State = 1;
                                break;
                            case "B":
                                State = 4;
                                break;
                            case "C":
                                State = 0;
                                break;
                            default:
                                Console.WriteLine("Цепочка не распознана");
                                State = -1;
                                break;
                        }
                        continue;
                    case 4:
                        switch (match.Value)
                        {
                            case "A":
                                State = 5;
                                break;
                            case "B":
                                State = 0;
                                break;
                            case "C":
                                State = 0;
                                break;
                            default:
                                Console.WriteLine("Цепочка не распознана");
                                State = -1;
                                break;
                        }
                        continue;
                    case 5:
                        switch (match.Value)
                        {
                            case "A":
                                State = 1;
                                break;
                            case "B":
                                State = 4;
                                break;
                            case "C":
                                State = 6;
                                break;
                            default:
                                Console.WriteLine("Цепочка не распознана");
                                State = -1;
                                break;
                        }
                        continue;
                }
            }
            
            Console.WriteLine(State);
        }
    }
}
