using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTPoly
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем одночлен m
            TMember m = new TMember(1, 2);
            Console.WriteLine("m = " + m.ToString());

            // Создаем одночлен d
            TMember d = new TMember(1, 2);
            Console.WriteLine("d = " + d.ToString());

            // Сравнение степеней одночленов
            Console.WriteLine("Сравнение степеней m и d = " + m.CompareTo(d));

            // Создаем одночлен p
            TMember p = new TMember(2, 2);
            Console.WriteLine("p = " + p.ToString());

            // Дифференцируем одночлен p
            Console.WriteLine("Дифференцируем p = " + p.Diff().ToString());

            // Сравниваем два одночлена
            TMember a = new TMember(2, 2);
            Console.WriteLine("Сравнение " + m.ToString() + " с " + a.ToString() + m.Eq(a));
            Console.WriteLine("Сравнение " + p.ToString() + " с " + a.ToString() + p.Eq(a));

            // Создание нулевого одночлена
            TMember b = new TMember();
            // Проверка на ноль одночлена
            Console.WriteLine("Проверка на 0 " + b.ToString() + TMember.EqZer0(b));
            Console.WriteLine("Проверка на 0 " + a.ToString() + TMember.EqZer0(a));

            // Вычисление значения одночлена
            Console.WriteLine("Вычисление значеня " + a.ToString() + "при 2ух = " + a.Value(2));

            // Создание одночлена путем копирования
            TMember c = b.Copy();
            Console.WriteLine("Создание переменной путем копирования: " + c.ToString());

            // эээээ ну типа сложение двух одночленов, но на деле там просто коэффициенты 
            //суммируются делал зайцев
            TMember e = m.Add(d);
            Console.WriteLine("Сложение двух одночленов " + e.ToString());

            // делаем одночлен с противоположным знаком... на -1 домножаем короч
            TMember f = m.Minus();
            Console.WriteLine("Делаем одночлен с противоположным знаком: "  + f.ToString());

            // Первое уравнение
            TPoly firstEquation = new TPoly();
            firstEquation.Add(new TMember(2, 2));
            firstEquation.Add(new TMember(2, 1));
            firstEquation.Add(new TMember(4, -7));
            firstEquation.Add(new TMember(0, 0));
            //Console.WriteLine(firstEquation.ToString());
            //firstEquation.Invar();
            Console.WriteLine( "a = " + firstEquation.ToString());

            // Второе уравнение
            TPoly secondEquation = new TPoly();
            secondEquation.Add(new TMember(4, 1));
            secondEquation.Add(new TMember(2, 3));
            secondEquation.Add(new TMember(7, 2));
            //secondEquation.Invar();
            Console.WriteLine( "b = " + secondEquation.ToString());
            
            // Сложение двух уравнений
            Console.WriteLine("a+b = " + (firstEquation + secondEquation).ToString());
            
            // Перемножение двух уравнений
            Console.WriteLine();
            Console.WriteLine("a*b = " +(firstEquation * secondEquation).ToString());

            // Разность двух уравнений
            Console.WriteLine();
            Console.WriteLine("a-b = " + (firstEquation - secondEquation).ToString());

            // Умножение числа на полином
            Console.WriteLine();
            Console.WriteLine("a*3 = " + (firstEquation.MulNum(new TMember(0, 3))).ToString());

            // Дифференцируем
            Console.WriteLine();
            Console.WriteLine("preddiff = " + firstEquation.ToString());
            Console.WriteLine("diff = " + firstEquation.Diff().ToString());

            // Вычислим при определенном Х
            Console.WriteLine();
            Console.WriteLine("result(3) = " + firstEquation.Eval(3));

            // Сравнение двух полиномов
            Console.WriteLine();
            Console.WriteLine("Сравним на РАВЕНСТВО " + firstEquation.ToString() + " и " + secondEquation.ToString());
            Console.WriteLine(firstEquation == secondEquation);
            
            // Сравнение двух полиномов
            Console.WriteLine();
            Console.WriteLine("Сравним на НЕРАВЕНСТВО " + firstEquation.ToString() + " и " + secondEquation.ToString());
            Console.WriteLine(firstEquation != secondEquation);

            // Сравнение двух полиномов
            secondEquation = firstEquation;
            Console.WriteLine();
            Console.WriteLine("Сравним на РАВЕНСТВО " + firstEquation.ToString() + " и " + secondEquation.ToString());
            Console.WriteLine(firstEquation == secondEquation);

            // Сравнение двух полиномов
            Console.WriteLine();
            Console.WriteLine("Сравним на НЕРАВЕНСТВО " + firstEquation.ToString() + " и " + secondEquation.ToString());
            Console.WriteLine(firstEquation != secondEquation);
        }
    }
}
