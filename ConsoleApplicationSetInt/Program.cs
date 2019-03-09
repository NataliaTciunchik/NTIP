using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationSetInt
{
    public struct test
    {
        public int m1;

        public test(int m)
        {
            m1 = m;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TSet<int> a = new TSet<int>();
            a.AddTo(1);
            a.AddTo(5);
            a.AddTo(10);
            Console.WriteLine(a.ToSting());

            TSet<char> b = new TSet<char>();
            b.AddTo('a');
            b.AddTo('b');
            b.AddTo('c');
            Console.WriteLine(b.ToSting());

            TSet<test> c = new TSet<test>();
            c.AddTo(new test(5));

            TSet<double> d = new TSet<double>();
            d.AddTo(12.4);
            d.AddTo(1.2);
            d.AddTo(15.6);
            Console.WriteLine(d.ToSting());
        }
    }
}
