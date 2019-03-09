using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationSetInt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------Работа с INT----------------------------");
            //
            TSet<int> a = new TSet<int>();
            a.AddTo(1);
            a.AddTo(5);
            a.AddTo(10);
            Console.WriteLine("Проверка int a: " + a.ToString());
            Console.WriteLine("Количество элементов в списке: " + a.Count());

            //
            TSet<int> b = new TSet<int>();
            b.AddTo(3);
            b.AddTo(5);
            b.AddTo(8);
            b.AddTo(11);
            Console.WriteLine("Проверка int b: " + b.ToString());
            Console.WriteLine("Количество элементов в списке: " + b.Count());

            //
            TSet<int> c = a + b;
            Console.WriteLine("Объеденим два множества a+b: " + c.ToString());
            c = a * b;
            Console.WriteLine("Новое множество путем пересечения двух множеств a*b: " + c.ToString());
            c = a - b;
            Console.WriteLine("Новое множество путем вычитания a-b: " + c.ToString());
            Console.WriteLine("Сравнение a и b на РАВЕНСТВО: " + (a == b));
            Console.WriteLine("Сравнение a и b на НЕ РАВЕНСТВО: " + (a != b));
            a.Clear();
            Console.WriteLine("Очистка множества a: " + a.ToString() + " текущее количество элементов: " + a.Count());
            Console.WriteLine("Проверка a на пустоту: " + a.IsEmpty());
            Console.WriteLine("Проверка b на пустоту: " + b.IsEmpty());

            Console.WriteLine("-----------------------------------------------------------------");

            Console.WriteLine("-------------------------Работа с CHAR---------------------------");
            //
            TSet<char> d = new TSet<char>();
            d.AddTo('a');
            d.AddTo('b');
            d.AddTo('c');
            Console.WriteLine("Проверка char d: " + d.ToString());
            Console.WriteLine("Количество элементов в списке: " + d.Count());

            //
            TSet<char> e = new TSet<char>();
            e.AddTo('b');
            e.AddTo('f');
            e.AddTo('z');
            e.AddTo('a');
            Console.WriteLine("Проверка char e: " + e.ToString());
            Console.WriteLine("Количество элементов в списке: " + e.Count());

            //
            TSet<char> f = d + e;
            Console.WriteLine("Объеденим два множества d+e: " + f.ToString());
            f = d * e;
            Console.WriteLine("Новое множество путем пересечения двух множеств d*e: " + f.ToString());
            f = d - e;
            Console.WriteLine("Новое множество путем вычитания d-e: " + f.ToString());
            Console.WriteLine("Сравнение d и e на РАВЕНСТВО: " + (d == e));
            Console.WriteLine("Сравнение d и e на НЕ РАВЕНСТВО: " + (d != e));
            d.Clear();
            Console.WriteLine("Очистка множества d: " + d.ToString() + " текущее количество элементов: " + d.Count());
            Console.WriteLine("Проверка d на пустоту: " + d.IsEmpty());
            Console.WriteLine("Проверка e на пустоту: " + e.IsEmpty());
            Console.WriteLine("-----------------------------------------------------------------");

            Console.WriteLine("-------------------------Работа с BOOL---------------------------");
            TSet<bool> g = new TSet<bool>();
            g.AddTo(false);
            g.AddTo(false);
            g.AddTo(true);
            Console.WriteLine("Проверка bool g: " + g.ToString());
            Console.WriteLine("Количество элементов в списке: " + g.Count());

            //
            TSet<bool> h = new TSet<bool>();
            h.AddTo(true);
            h.AddTo(false);
            h.AddTo(true);
            h.AddTo(true);
            Console.WriteLine("Проверка bool h: " + h.ToString());
            Console.WriteLine("Количество элементов в списке: " + h.Count());

            //
            TSet<bool> i = g + h;
            Console.WriteLine("Объеденим два множества g+h: " + i.ToString());
            i = g * h;
            Console.WriteLine("Новое множество путем пересечения двух множеств g*h: " + i.ToString());
            i = g - h;
            Console.WriteLine("Новое множество путем вычитания g-h: " + i.ToString());
            Console.WriteLine("Сравнение g и h на РАВЕНСТВО: " + (g == h));
            Console.WriteLine("Сравнение g и h на НЕ РАВЕНСТВО: " + (g != h));
            g.Clear();
            Console.WriteLine("Очистка множества g: " + g.ToString() + " текущее количество элементов: " + g.Count());
            Console.WriteLine("Проверка g на пустоту: " + g.IsEmpty());
            Console.WriteLine("Проверка h на пустоту: " + h.IsEmpty());
            Console.WriteLine("-----------------------------------------------------------------");

            Console.WriteLine("-------------------------Работа с DOUBLE-------------------------");
            //
            TSet<double> k = new TSet<double>();
            k.AddTo(1.22);
            k.AddTo(5.45);
            k.AddTo(10.005);
            Console.WriteLine("Проверка double k: " + k.ToString());
            Console.WriteLine("Количество элементов в списке: " + k.Count());

            //
            TSet<double> l = new TSet<double>();
            l.AddTo(3.29);
            l.AddTo(5.45);
            l.AddTo(8.920);
            l.AddTo(11.123);
            Console.WriteLine("Проверка double l: " + l.ToString());
            Console.WriteLine("Количество элементов в списке: " + l.Count());

            //
            TSet<double> m = k + l;
            Console.WriteLine("Объеденим два множества k+l: " + m.ToString());
            m = k * l;
            Console.WriteLine("Новое множество путем пересечения двух множеств k*l: " + m.ToString());
            m = k - l;
            Console.WriteLine("Новое множество путем вычитания k-l: " + m.ToString());
            Console.WriteLine("Сравнение k и l на РАВЕНСТВО: " + (k == l));
            Console.WriteLine("Сравнение k и l на НЕ РАВЕНСТВО: " + (k != l));
            k.Clear();
            Console.WriteLine("Очистка множества k: " + k.ToString() + " текущее количество элементов: " + k.Count());
            Console.WriteLine("Проверка k на пустоту: " + k.IsEmpty());
            Console.WriteLine("Проверка l на пустоту: " + l.IsEmpty());
            Console.WriteLine("-----------------------------------------------------------------");
        }
    }
}
