using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTPoly
{
    class TPoly
    {
        List<TMember> Poly;

        //Конструктор без параметров.
        public TPoly()
        {
            Poly = new List<TMember>();
        }


        // Добавить уравнение в полином
        public void Add(TMember a)
        {
            this.Poly.Add(a);
            this.Invar();
        }

        //Преобразует полином в формат строки.
        public new string ToString()
        {
            string s = "";
            for (int i = 0; i < this.Poly.Count; i++)
            {
                s += this.Poly[i].ToString();
                if (i != this.Poly.Count-1)
                    s += " + ";
            }
            if (s == "")
                s += "0*X^0";
            return s;
        }

        //Степень полинома.
        public int Degree()
        {
            return this.Poly[Poly.Count - 1].Degree;
        }

        //Коэффициент при заданной степени.
        public int Coeff(int n)
        {
            for(int i = 0; i < this.Poly.Count; i++)
                if(this.Poly[i].Degree == n)
                    return this.Poly[i].Coeff;
            return 0;
        }

        public void Invar()
        {
            //приводим подобные
            Likeness();
            //удаляем члены с нулевыми коэффициентами
            RemoveZero();
            //упорядочиваем список
            Poly.Sort();
        }

        //Операция Сложить.
        public static TPoly operator +(TPoly a, TPoly b)
        {
            TPoly c = new TPoly();
            for (int i = 0; i < a.Poly.Count; i++)
                c.Poly.Add(a.Poly[i].Copy());
            for (int i = 0; i < b.Poly.Count; i++)
                c.Poly.Add(b.Poly[i].Copy());
            c.Invar();
            return c;
        }

        // Операция унарный Минус.
        public static TPoly operator -(TPoly a)
        {
            TPoly c = new TPoly();
            for (int i = 0; i < a.Poly.Count; i++)
                c.Poly.Add(a.Poly[i].Minus().Copy());
            return c;
        }

        //Операция Вычесть.
        public static TPoly operator -(TPoly a, TPoly b)
        {
            TPoly c = new TPoly();
            for (int i = 0; i < a.Poly.Count; i++)
                c.Poly.Add(a.Poly[i].Copy());
            b = -b;
            for (int i = 0; i < b.Poly.Count; i++)
                c.Poly.Add(b.Poly[i].Copy());
            c.Invar();
            return c;
        }
        
        //Умножение //полинома на одночлен.
        public TPoly MulNum(TMember Num)
        {
            TPoly c = new TPoly();
            for(int i = 0; i < this.Poly.Count; i++)
                c.Poly.Add(this.Poly[i] * Num);
            c.Invar();
            return c;
        }

        // Операция Умножить.
        public static TPoly operator *(TPoly a, TPoly b)
        {
            TPoly c = new TPoly();
            for (int i = 0; i < a.Poly.Count; i++)
                c += b.MulNum(a.Poly[i]);
            c.Invar();
            return c;
        }

        //Приведение подобных.
        private void Likeness()
        {
            for (int i = 0; i < Poly.Count - 1; i++)
                for (int j = i + 1; j < Poly.Count; j++)
                    if (!TMember.EqZer0(Poly[i]) && !TMember.EqZer0(Poly[j]))
                        if (Poly[i].Degree == Poly[j].Degree)
                        {
                            Poly[i].Coeff += Poly[j].Coeff;
                            Poly[j] = new TMember();
                        }
        }

        //Удаляет члены с нулевыми //коэффициентами.
        private void RemoveZero()
        {
            int i = 0;
            while (i < Poly.Count)
            {
                if (Poly[i].Coeff == 0)
                    Poly.Remove(Poly[i]);
                else
                    i++;
            }
        }
        
        // Операция Дифференцировать.
        public TPoly Diff()
        {
            for (int i = 0; i < this.Poly.Count; i++)
                this.Poly[i] = this.Poly[i].Diff();
            return this;
        }

        // Операция Вычислить.
        public double Eval(double v)
        {
            double result = 0;
            for(int i = 0; i < this.Poly.Count; i++)
                result += this.Poly[i].Value(v);
            return result;
        }

        // Операция Равно.
        public static bool operator ==(TPoly a, TPoly b)
        {
            if (a.Poly.Count == b.Poly.Count)
            {
                a.Poly.Sort();
                b.Poly.Sort();
                for (int i = 0; i < a.Poly.Count; i++)
                    if (a.Poly[i] != b.Poly[i])
                        return false;
            }
            else
                return false;
            return true;
        }

        // Операция Неравно.
        public static bool operator !=(TPoly a, TPoly b)
        {
            if (a.Poly.Count == b.Poly.Count)
            {
                a.Poly.Sort();
                b.Poly.Sort();
                for (int i = 0; i < a.Poly.Count; i++)
                    if (a.Poly[i] != b.Poly[i])
                        return true;
            }
            else
                return true;
            return false;
        }
    }
}