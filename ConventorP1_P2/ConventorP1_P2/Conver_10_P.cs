using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventorP1_P2
{
    class Conver_10_P
    {
        //Преобразовать целое в символ. 
        public static char int_to_Char(int d)
        {
            switch (d)
            {
                case 10:
                    return 'A';
                case 11:
                    return 'B';
                case 12:
                    return 'C';
                case 13:
                    return 'D';
                case 14:
                    return 'E';
                case 15:
                    return 'F';
                default:
                    return d.ToString().ToCharArray()[0];
            }
        }

        //Преобразовать десятичное целое в с.сч. с основанием р. 
        public static string int_to_P(int number, int p)
        {
            string result = "";
            bool minus = false;
            if (number < 0)
            {
                minus = true;
                number = Math.Abs(number);
            }

            while (number / p >= 1)
            {
                result += (int_to_Char(number % p));
                number /= p;
            }
            result += int_to_Char(number);
            char[] tmp = result.ToCharArray();
            Array.Reverse(tmp);
            if (minus)
                result = '-' + new string(tmp);
            else
                result = new string(tmp);
            return result;
        }
        //Преобразовать десятичную дробь в с.сч. с основанием р. 
        public static string flt_to_P(string n, int p, int c)
        {
            string result = "";
            double rem;
            rem = double.Parse(n);
            for (int i = 0; i < c; i++)
            {
                int temp = (int)((rem * p) / (int)(Math.Pow(10, n.Length)));
                rem = (int)((rem * p) % (int)(Math.Pow(10, n.Length)));
                result += int_to_Char(temp);
            }
            return result;
        }

        //Преобразовать десятичное  
        //действительное число в с.сч. с осн. р. 
        public static string Do(double n, int p, int c)
        {
            string num = n.ToString();
            string[] doubleNum = num.Split(',');
            int number = int.Parse(doubleNum[0]);

            string result = int_to_P(number, p);

            if (doubleNum.Length == 2)
                result += "," + flt_to_P(doubleNum[1], p, c);

            return result;
        }
    }
}
