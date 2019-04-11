using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FracCalc1_4
{
    class Editor
    {
        const char delim = '/';
        const char sign = '-';
        const char ZERO = '0';

        public String Number { get; set; } = "";

        public string AddDigit(char n)
        {
            Number += n;
            return Number;//.Replace(" ", "");
        }

        public string AddDelim()
        {
            if (Number.Length > 0)
            {
                for (int i = 0; i < Number.Length; i++)
                    if (Number[i] == delim)
                        return Number;//.Replace(" ", "");
                Number += delim;
                return Number;//.Replace(" ", "");
            }
            return Number;
        }

        public string ChangeSign()
        {
            if (Number.Length == 0)
                return Number;
            else
            {
                if (Number[0] == '-')
                    Number = Number.Substring(1, Number.Length - 1);
                else
                    Number = Number.Insert(0, "-");
            }
            return Number;
        }

        public string AddZero()
        {
            if (Number.Length != 0)
                if (Number[0] == ZERO)
                    return Number;
            if (Number.Length >= 2)
                if (Number[Number.Length-1] == '/')
                    return Number;
            Number += ZERO;
            return Number;
        }

        public string Bs()
        {
            if (Number.Length > 0)
            {
                Number = Number.Substring(0, Number.Length - 1);
                return Number;//.Replace(" ", "");
            }
            return Number;//.Replace(" ", "");
        }

        public string Clear()
        {
            Number = "";
            return Number;
        }

        public string DoEdit(int Command)
        {
            switch (Command)
            {
                case 0:
                    return AddZero();
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    return AddDigit(Command.ToString()[0]);
                case 14:
                    return Bs();
                case 15:
                    return Clear();
                case 16:
                    return AddDelim();
                case 18:
                    return ChangeSign();
                default:
                    return "Такой команды не существует! Попробуйте еще раз!";
            }
        }
    }
}