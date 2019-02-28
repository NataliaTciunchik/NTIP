using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventorP1_P2
{
    class Control_
    {
        public History his = new History();
        //Основание системы сч. исходного числа.
        int pin = 10;

        //Основание системы сч. результата.
        int pout = 16;

        //Число разрядов в дробной части результата.
        int accuracy = 10;

        //public History his = new History();
        public enum State { Редактирование, Преобразовано }

        //Свойство для чтения и записи состояние Конвертера.
        public State St
        {
            get ;
            set ;
        }

        //Конструктор.
        public Control_()
        {
            St = State.Редактирование;
            Pin = pin;
            Pout = pout;
        }

        //объект редактор
        public Editor ed = new Editor();

        //Свойство для чтения и записи основание системы сч. р1.
        public int Pin
        {
            get { return pin; }
            set { pin = value; }
        }

        //Свойство для чтения и записи основание системы сч. р2.
        public int Pout
        {
            get { return pout; }
            set { pout = value; }
        }

        //Выполнить команду конвертера.
        public string DoCmnd(int j)
        {
            if (j == 19)
            {
                double r = Conver_P_10.dval(ed.Number, (Int16)Pin);
                string res = Conver_10_P.Do(r, (Int32)Pout, acc());
                St = State.Преобразовано;
                his.AddRecord(Pin, Pout, ed.Number, res);
                return res;
            }
            else
            {
                St = State.Редактирование;
                return ed.DoEdit(j);
            }

        }

        //Точность представления результата.
        private int acc()
        {
            return (int)Math.Round(ed.Acc() * Math.Log(Pin) / Math.Log(Pout) + 0.5);
        }
    }
}