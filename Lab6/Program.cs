using System;

namespace Lab6
{
    public class Point
    {
        public double X;
        public double Y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    public struct PointS
    {
        public double X { get; }
        public double Y { get; }
    
        public PointS(double x, double y) => (X, Y) = (x, y);
    }

    public enum TypePoint
    {
        Point,
        Vector
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            // объявление a без создания объекта и выделения памяти
            Point a;
            // объявление b типа Point и создание объекта с выделением памяти
            Point b = new Point(3, 4);
            Console.WriteLine($"{b.X} {b.Y}");
            // при попытке обратиться к a без присваивания или создания нового объекта код не скомпилируется
            // необходимо присвоить ссылку на другой объект
            a = b;
            // или создать новый
            a = new Point(5, 6);
            Console.WriteLine($"{a.X} {a.Y}");
            // объявление с типа PointS и создание структуры с выделением памяти
            // к значимые типы можно объявлять пустыми конструктрами и обращаться к их полям без инициализации
            PointS c = new PointS();
            Console.WriteLine($"{c.X} {c.Y}");
            // обращение к перечислению типа TypePoint
            // к перечислениям можно обращаться без инициализации и объявления
            Console.WriteLine(TypePoint.Point);
            // также можно объявить переменную типа TypePoint и присвоить конкретное значение
            TypePoint d = TypePoint.Point;
            // создание e типа int
            int e;
            // ошибка при обращении к неинициализированной переменной
            //Console.WriteLine(e);
            // инициализация e
            e = 10;
            Console.WriteLine(e);
            // объявление и инициализация анонимной переменной типа int
            // в данном случае var f;
            // писать нельзя, потому что компилятор определяет тип переменной по значению
            var f = 15;
            Console.WriteLine(f);
            // приведение типа double к int
            f = (int) 14.5;
            Console.WriteLine(f);
            // объявление и инициализация кортежа t2
            (double Sum, int Count) t2 = (4.5, 3);
            Console.WriteLine($"Sum of {t2.Count} elements is {t2.Sum}.");
            
        }
    }
}