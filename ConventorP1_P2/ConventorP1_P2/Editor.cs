using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventorP1_P2
{
    class Editor
    {
        //Поле для хранения редактируемого числа.
        string number = "";

        //Разделитель целой и дробной частей.
        const char delim = ',';

        //Ноль.
        const string zero = "0";

        //Свойствое для чтения редактируемого числа.
        public string Number
        {
            get { return number; }
        }

        //Добавить цифру.
        public string AddDigit(char n)
        {
            number += n;
            return number.Replace(" ", "");
        }

        //Точность представления результата.
        public int Acc()
        {
            return 1;
        }

        //Добавить ноль.
        public string AddZero()
        {
            number += zero;
            return number;
        }

        //Добавить разделитель.
        public string AddDelim()
        {
            number += delim;
            return number;
        }

        //Удалить символ справа.
        public string Bs()
        {
            if(number.Length > 0)
                number = number.Substring(0, number.Length - 1);
            return number.Replace(" ", "");
        }

        //Очистить редактируемое число.
        public string Clear()
        {
            number = zero;
            return number;
        }

        //Выполнить команду редактирования.
        public string DoEdit(int j)
        {
            switch (j)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    return AddDigit((char)(j.ToString()[0]));// КАСТЫЛЬ ИЗ ЗА КОДИРОВКИ
                case 10:
                    return AddDigit('A');
                case 11:
                    return AddDigit('B');
                case 12:
                    return AddDigit('C');
                case 13:
                    return AddDigit('D');
                case 14:
                    return AddDigit('E');
                case 15:
                    return AddDigit('F');
                case 16:
                    return AddDelim();
                case 17:
                    return Bs();
                case 18:
                    return Clear();
                default:
                    return "Такой команды не существует! Попробуйте еще раз!";
            }
        }
    }
}
