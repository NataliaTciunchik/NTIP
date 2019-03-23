using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCalcVar9_10
{
    class Editor
    {
        /*
         * Это поле класса Editor в него записывается
         * число которое вводит пользователь
         * класс Conrtol_ вызывает два класса Editor
         * как раз для того что бы были два разных
         * поля Number, для ввода левого операнда
         * и правого операнда
         * 
         * Данное поле имеет метод get и set
         * get позволяет считывать текущее значение
         * поля Number, тоесть можно сделать так
         * ... = Editor.Number - это выведет текущее
         * значение в поле Number
         * 
         * set ползволяет изменять текущее значение
         * поля Number, тоесть можно сделать так
         * Editor.Number = "XYU" и в поле Number
         * запишется интересное слово.
         * Можно еще так
         * Editor.Number += "JOPA" и в поле Number 
         * добавить к тексту который уже написан
         * добавиться еще одно интересное слово
        */
        public string Number { get; set; } = "";

        /*
         * просто переменная которая хранит в себе
         * символ запятую
        */
        const char delim = ',';

        /*
         * просто переменная которая хранит в себе
         * символ 0
        */
        const char ZERO = '0';

        /*
         * метод класса, который добавляет к строке
         * необходимый символ (ОДИН СИМВОЛ!!!)
         * например A или 1...
        */
        public string AddDigit(char n)
        {
            Number += n;
            return Number.Replace(" ", "");
        }

        /*
         * Добавить разделитель в строку, разделитель
         * это символ запятой, храниться в переменной
         * delim
        */
        public string AddDelim()
        {
            /*
             * Осуществляется проверка можно ли поставить
             * делить в текущий момент?
             * Если количество символов в поле Number
             * больше 0 тогда проверяем дальше
            */
            if (Number.Length > 0)
            {
                /*
                 * Эт цикл по всем элементам строки
                 * тоесть проверется каждый символ строки
                */
                for (int i = 0; i < Number.Length; i++)
                {
                    /*
                     * если какой либо символ строки
                     * равен разделителю (запятой) тогда
                     * запятую ставить НЕЛЬЗЯ и мы возвращаем
                     * туже строку что и пришла, убрав из нее
                     * пробелы
                    */
                    if (Number[i] == delim)
                        return Number.Replace(" ", "");
                }
                /*
                 * если запятая в строке не была найдена
                 * тогда мы добавляем ее и возвращем строку
                 * в которую мы добавили заяпятую
                */
                Number += delim;
                return Number.Replace(" ", "");
            }
            /*
             * Если количество символов в поле Number
             * меньше или равно 0
             * тогда ниче не меняем и возвращаем строку
             * такой же, какой она была
            */
            return Number;
        }

        /*
         * Удалить последний символ!
        */
        public string BS()
        {
            /*
             * Если количество символов в поле
             * Number больше 0 тогда удалить
             * последний символ можно, удаляем
             * его и возвращаем новую строку
             * если количество символов в поле 
             * Number меньше или равно 0 тогда
             * удалить последний символ низя
             * просто возвразаем строку которая и была
            */
            if (Number.Length > 0)
                Number = Number.Substring(0, Number.Length - 1);
            return Number.Replace(" ", "");
        }

        /*
         * Метод класса Editor, полностью очищает
         * строку и возвращает ее...
        */
        public string Clear()
        {
            Number = "";
            return Number;
        }

        /*
         * Метод класса Editor, меняет знак
         * числа заданного в Number
         * на противоположный
        */
        public string changeSing()
        {
            /* если количетсво символов
             * в поле Number равно 0
             * тогда просто вернуть строку
            */
            if (Number.Length == 0)
                return Number;
            else
            {
                /*
                 * если количество символов
                 * в поле Number больше 0
                 * и первый символ в Number
                 * равен "-" тогда вырезаем
                 * строку со второго элемента
                 * по последний и возвращаем ее
                */
                if (Number[0] == '-')
                {
                    Number = Number.Substring(1, Number.Length - 1);
                    return Number;
                }
                /*
                 * Если количество символов
                 * в поле Number больше 0
                 * и первый символ в Number
                 * НЕ равен "-" тогда добавлем
                 * в начало Number знак "-"
                */
                else
                {
                    Number = '-' + Number;
                    return Number;
                }
            }
        }

        /*
         * Метод класса Editor добавляет
         * 0 в строку если мона
        */
        public string AddZero()
        {
            /*
             * Если количество символов в поле
             * Number больше нуля тогда проверяем
             * дальше
            */
            if (Number.Length > 0)
            {
                /*
                 * Цикл по всем элементам поля Number
                 * тоесть проверяется каждая буковка
                 * и символ в строке Number
                 * если найден разделитель то можно
                 * спокойно ставить 0 и возвращать
                 * строку
                */
                for (int i = 0; i < Number.Length; i++)
                {
                    if (Number[i] == delim)
                    {
                        Number += ZERO;
                        return Number;
                    }
                }
                /*
                 * если разделитель не найден тогда
                 * смотрим стоит ли на первом месте 0
                 * если НЕ стоит то ставим 0 и возвращаем
                 * строку
                */
                if (!CheckFirstZero())
                {
                    Number += ZERO;
                    return Number;
                }
                /*
                 * если стоит 0 на первом месте то
                 * ставить ноль нельзя
                */
                else
                    return Number;

            }
            /*
             * Если количество символов в строке 0
             * тогда можно спокойно добавить 0
             * и вернуть строку
            */
            else
            {
                Number += ZERO;
                return Number;
            }
        }

        /*
         * Метод класса Editor совершает определенное
         * действие в зависимости от прешедшей команды
        */
        public string DoEdit(int j)
        {
            switch(j)
            {
                /*
                 * Если пришел ноль добавляет
                 * ноль
                */
                case 0:
                    return AddZero();
                /*
                 * Если пришла 1-15
                 * тогда проверяется стоит ли разделитель
                 * если стоит тогда можно писать любые
                 * символы
                 * если разделитель не стоит, тогда
                 * проверяем, стоит ли перым ноль?
                 * если стоит то ставить число нельзя
                 * если не стоит то ставить число можно
                */
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    if(CheckDelim())
                        return AddDigit((j).ToString()[0]);
                    else
                        if(!CheckFirstZero())
                            return AddDigit((j).ToString()[0]);
                    return Number;
                case 10:
                    if (CheckDelim())
                        return AddDigit('A');
                    else
                        if (!CheckFirstZero())
                        return AddDigit('A');
                    return Number;
                case 11:
                    if (CheckDelim())
                        return AddDigit('B');
                    else
                        if (!CheckFirstZero())
                        return AddDigit('B');
                    return Number;
                case 12:
                    if (CheckDelim())
                        return AddDigit('C');
                    else
                        if (!CheckFirstZero())
                        return AddDigit('C');
                    return Number;                    
                case 13:
                    if (CheckDelim())
                        return AddDigit('D');
                    else
                        if (!CheckFirstZero())
                        return AddDigit('D');
                    return Number;
                case 14:
                    if (CheckDelim())
                        return AddDigit('E');
                    else
                        if (!CheckFirstZero())
                        return AddDigit('E');
                    return Number;
                case 15:
                    if (CheckDelim())
                        return AddDigit('F');
                    else
                        if (!CheckFirstZero())
                        return AddDigit('F');
                    return Number;
                case 16:
                    /*
                     * Выполняется команда
                     * поставить делитель
                    */
                    return AddDelim();
                case 17:
                    /*
                     * Выполняется команда
                     * удалить 1 символ
                    */
                    return BS();
                case 18:
                    /*
                     * Выполняется команда
                     * стереть все нахуй
                     * из Number
                    */
                    return Clear();
                case 19:
                    /*
                     * Выполняется команда
                     * поменять знак числа
                    */
                    return changeSing();
                default:
                    /*
                     * Ну сюда никогда не дойдет...
                     * но есливдругвсетакидакогданибудь
                     * тогда вернеться строка которая
                     * сообщит, что такой команды нет
                    */
                    return "ERR: Ошибка, такой команды не существует!";
            }
        }

        /*
         * ПРИВАТНЫЙ метод класса Editor
         * приватный означает то, что он
         * не виден из других классов, тоесть
         * он может вызываться только внутри
         * данного класса (Editor)
         * 
         * проверяет стоит ли на первом месте 0
         * если стоит возвращает true
         * если не стоит возвращает false
        */
        private bool CheckFirstZero()
        {
            /*
             * Если количество символов в поле
             * Number больше 0 тогда проверяем
             * дальше...
            */
            if(Number.Length > 0)
            {
                /*
                 * Если первый символ "-"
                 * а второй символ "0"
                 * тогда ноль на первом месте
                 * вернем true
                */
                if (Number[0] == '-')
                    if(Number[1] == '0')
                        return true;
                /*
                 * если на первом месте
                 * в Number 0, тогда
                 * вернем true
                */
                if (Number[0] == '0')
                    return true;
                /*
                 * Во всех остальных
                 * случаях ноль не на
                 * первом месте возвращаем
                 * false
                */
                return false;
            }
            else
                return false;
        }

        /*
         * Проверка строки на наличие разделителя
         * если в строке есть разделитель вернется true
         * если в строке нет разделителя вернется false
        */
        private bool CheckDelim()
        {
            /*
             * если длина больше 0 значит надо проверить
             * строку если нет сразу вернется false
            */
            if(Number.Length > 0)
                /*
                 * цикл по всем элементам поля Number
                 * если встретиться разделитель то вернется
                 * true
                */
                for(int i = 0; i < Number.Length; i++)
                    if (Number[i] == delim)
                        return true;
            return false;
        }
    }
}
