using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTPoly
{
    class TMember : IComparable
    {
        public int Degree { get; set; } //Степень одночлена.
        //Степень одночлена.
        public int Coeff { get; set; } //Коэффициент одночлена.
        //Коэффициент одночлена.
        public TMember(int d = 0, int c = 0)
        {
            Degree = d;
            Coeff = c;
        }
        public TMember Minus()
        {
            return new TMember(Degree, -Coeff);
        }
        public TMember Add(TMember b)
        {
            return new TMember(Degree, Coeff + b.Coeff);
        }
        //Операция ОдночленВСтроку. Свойство для чтения одночлена в
        //строковом формате.
        public override string ToString()
        {
            string s = "(" + Coeff + "*X^" + Degree + ")";
            return s;
        }
        public int CompareTo(object obj)
        {
            if (Degree < (obj as TMember).Degree) return -1;
            if (Degree > (obj as TMember).Degree) return 1;
            return 0;
        }
        //Операция Дифференцировать.Дифференцирование одночлена.
        public TMember Diff()
        {
            return new TMember(Degree - 1, Degree * Coeff);
        }
        //Операция Равно. Сравнение одночлена с одночленом b.
        public bool Eq(TMember b)
        {
            return CompareTo(b) == 0 ? true : false;
        }
        //Операция Равно. Сравнение одночлена с одночленом b.
        public static bool EqZer0(TMember b)
        {
            return b.Coeff == 0 && b.Degree == 0 ? true : false;
        }
        //Операция Вычислить. Вычисляет значение одночлена.
        public double Value(double v)
        {
            return Coeff * Math.Pow(v, Degree);
        }
        //Операция Копировать. Создаёт копию одночлена.
        public TMember Copy()
        {
            return new TMember(this.Degree, this.Coeff);
        }

        // Операция перемножения двух одночленов
        public static TMember operator *(TMember a, TMember b)
        {
            TMember c = new TMember();
            c.Degree = a.Degree + b.Degree;
            c.Coeff = a.Coeff * b.Coeff;
            return c;
        }

    }
}
