using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventorP1_P2
{
    class Conver_P_10
    {
        //Преобразовать цифру в число.
        static double char_to_num(char ch)
        {
            switch (ch)
            {
                case 'A':
                    return 10;
                case 'B':
                    return 11;
                case 'C':
                    return 12;
                case 'D':
                    return 13;
                case 'E':
                    return 14;
                case 'F':
                    return 15;
                default:
                    return char.GetNumericValue(ch);
            }
        }

        //Преобразовать строку в число
        private static double convert(string P_num, int P, double weight)
        {
            double number = 0;
            int start = 0;
            if (P_num[0] == '-')
                start = 1;

            for (int i = start; i < P_num.Length; i++)
            {
                number += char_to_num(P_num[i]) * weight;
                weight /= P;
            }

            if (start == 1)
                return (number * (-1));
            else
                return number;
        }

        //Преобразовать из с.сч. с основанием р
        //в с.сч. с основанием 10.
        public static double dval(string P_num, int P)
        {
            string[] new_s = P_num.Split(',');
            double z = 0;
            int start = 0;
            if (new_s[0][0] == '-')
                start = 1;
            for (int i = start; i < new_s[0].Length; i++)
                z += (double)char_to_num(new_s[0][i]) * Math.Pow(P, new_s[0].Length - i - 1);
            if (new_s.Length == 2)
                for (int i = 0; i < new_s[1].Length; i++)
                    z += (double)char_to_num(new_s[1][i]) * Math.Pow(P, -1 - i);
            if (start == 1)
                z = z * -1;
            return z;
        }
    }
}
