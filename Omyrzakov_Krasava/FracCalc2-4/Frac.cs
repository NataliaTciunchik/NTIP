using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FracCalc1_4
{
    class Frac
    {
        int num;
        int den;

        public Frac(int num, int den)
        {
            int gcd = GCD(num, den);
            this.num = num / gcd;
            this.den = den / gcd;
        }

        public Frac(string frac)
        {
            string tmp = "";
            int num = 0;
            int den = 0;
            bool isDelim = false;
            for (int i = 0; i < frac.Length; i++)
            {
                if (frac[i] != '/')
                    tmp += frac[i];
                else
                {
                    isDelim = true;
                    num = int.Parse(tmp);
                    tmp = "";
                }
            }
            if (!isDelim)
            {
                num = int.Parse(tmp);
                den = 1;
            }
            else
            {
                den = int.Parse(tmp);
                if (den == 0)
                    den = 1;
            }
            int gcd = GCD(num, den); // для сокращения дроби ищется НОД
            this.num = num / gcd;
            this.den = den / gcd;
        }

        public override string ToString()
        {
            if (num == 0)
                return "0";
            else
            {
                if (den != 0 && den != 1)
                    return num + "/" + den; // возврат строки типа "1/2"
                else
                    return num.ToString();
            }
        }

        public static Frac operator +(Frac a, Frac b)
        {
            int tnum = a.num * b.den + b.num * a.den;
            int tden = a.den * b.den;
            return new Frac(tnum, tden);
        }
        
        public static Frac operator -(Frac a, Frac b)
        {
            int tnum = a.num * b.den - a.den * b.num;
            int tden = a.den * b.den;
            return new Frac(tnum, tden);
        }
        
        public static Frac operator *(Frac a, Frac b)
        {
            int tnum = a.num * b.num;
            int tden = a.den * b.den;
            return new Frac(tnum, tden);
        }

        public static Frac operator /(Frac a, Frac b)
        {
            if (b.num != 0)
            {
                int tnum = a.num * b.den;
                int tden = b.num * a.den;
                return new Frac(tnum, tden);
            }
            else
                return new Frac(0, 1);
        }

        private int GCD(int a, int b)
        {
            if (a == 0)
                return 1;
            else
            {
                int temp;
                while (b != 0)
                {
                    temp = b;
                    b = a % b;
                    a = temp;
                }
                return Math.Abs(a);
            }
        }
    }
}
