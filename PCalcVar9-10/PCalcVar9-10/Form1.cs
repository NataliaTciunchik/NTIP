using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCalcVar9_10
{
    public partial class PCalc : Form
    {
        /* 
         * Подключаем класс Control
         * Дословно: создаем экземпляр класса Control
         * Описание класса Control находиться в файле Control.cs
        */
        Control_ ctl = new Control_();

        /* 
         * Функция которая инициализирует компонент(главное окошечко,
         * с кнопочками) что бы появились кнопочки и прочее...
        */
        public PCalc()
        {
            InitializeComponent();
        }

        

        /*
         * Load функция, с рабатывает при каждом запуске
         * ГЛАВНОГО окошечка (при запуске приложения)
         * В этой функции инициализируется начальные значения
         * переменных
         * НАПРИМЕР: выставляется начальная систчема счисления
         * в ползунок и сразу блокируются не доступные для
         * этой системы счисления кнопки
        */
        private void PCalc_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = ctl.PIN;
            this.UpdateButtons();
        }

        /*
         * Функция для обновления состояния
         * всех кнопок, писал зайцев...
        */
        private void UpdateButtons()
        {
            //просмотреть все компоненты формы
            foreach (Control i in this.Controls)
            {
                if (i is Button)//текущий компонент - командная кнопка
                {
                    int j = Convert.ToInt16(i.Tag.ToString());
                    if (j < numericUpDown1.Value)
                    {
                        //сделать кнопку доступной
                        i.Enabled = true;
                    }
                    if ((j >= numericUpDown1.Value) && (j <= 15))
                    {
                        //сделать кнопку недоступной
                        i.Enabled = false;
                    }
                }
            }
        }

        /*
         * Обработчик событие нажатия на клавиши...
         * если нажали клавишу какую-нибудь в калькуляторе
         * срабатывает этот метод
         * он получает поле TAG из нажатой кнопки
         * 
         * СПИСОК КОМАНД
         * тэг это код команды 1-15 это добавить цифру (букву)
         * 16 - поставить запятую
         * 17 - затереть 1 символ
         * 18 - очистить всю строку
         * 19 - поменть знак +/- у числа
         * 20 - операция сложение
         * 21 - операция вычитание
         * 22 - операция умножение
         * 23 - операция деление
         * 24 - переключить с первого операнда на второй и обратно
         * 25 - выполнить вычисление
         * 99 - срабатывает при переключении ползунка системы
         * счисления, очищает все поля
        */
        private void buttonClick(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            int j = Convert.ToInt16(but.Tag.ToString());
            DoCmd(j);
        }

        /*
         * Обработчик ползунка системы счисления
         * Нажатия вверх вниз меняют циферки соответственно
         * и вызывается команда 99
        */
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ctl.PIN = Convert.ToByte(numericUpDown1.Value);
            this.UpdateButtons();
            DoCmd(99);
        }

        /*
         * Обработчик нажатия на клавиатуру
         * писал Зайцев...
         * Ну коротко говоря у клавитуры у каждой клавиши есть
         * код... он преобразуется вот тута, и соответствующая команда
         * из списка выше отправляется в Control_()
        */
        private void PCalcKeyPress(object sender, KeyPressEventArgs e)
        {
            int i = -1;
            if (e.KeyChar >= 'A' && e.KeyChar <= 'F')
                i = (int)e.KeyChar - 'A' + 10;
            if (e.KeyChar >= 'a' && e.KeyChar <= 'f')
                i = (int)e.KeyChar - 'a' + 10;
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                i = (int)e.KeyChar - '0';
            if (e.KeyChar == 46 || e.KeyChar == 44)
                i = 16;
            if ((int)e.KeyChar == 8)
                i = 17;
            if ((int)e.KeyChar == 13)
                i = 25;
            if ((int)e.KeyChar == 43)
                i = 20;
            if ((int)e.KeyChar == 45)
                i = 21;
            if ((int)e.KeyChar == 42)
                i = 22;
            if ((int)e.KeyChar == 47)
                i = 23;
            if ((i < ctl.PIN) || (i >= 16))
                DoCmd(i);
        }

        /*
         * Выполнить команду ПРИВАТНЫЙ метод
         * класса Form1.cs ТОЕСТЬ он доступен
         * только из этого класса
         * просто отправляет команды в Control_()
        */
        private void DoCmd(int j)
        {
            switch (j)
            {
                /*
                 * команды 1-19
                 * заполняют поля firstNumBox (первое окошечко
                 * с числом) и secondNumBox (второе окошечко
                 * с числом) в зависимости от текущего состояния
                 * ввода. Левый операнд или правый.
                 * Это состояние храниться в Control_()
                */
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
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                    if (ctl.St == Control_.State.LeftOperandEnter)
                        firstNumBox.Text = ctl.DoCmd(j);
                    if (ctl.St == Control_.State.RightOperandEnter)
                        secondNumBox.Text = ctl.DoCmd(j);
                    break;
                /*
                 * Если команда добавить знак
                 * + - / * тогда в поле знак
                 * записывается данный знак
                */
                case 20:
                case 21:
                case 22:
                case 23:
                    operatorBox.Text = ctl.DoCmd(j);
                    ctl.DoCmd(24);
                    break;
                case 24:
                    /*
                     * Переключает ввод с одного операнда
                     * на другой
                    */
                    ctl.DoCmd(j);
                    break;
                case 25:
                    /*
                     * выполняет операцию вычесления
                     * и записывает в поле результата
                     * результат вычисления
                    */
                    if (operatorBox.Text.Length != 0)
                        resultBox.Text = ctl.DoCmd(j);
                    break;
                case 99:
                    /*
                     * если сменилась система счисления то
                     * все поля очищаются!
                    */
                    if(firstNumBox.Text.Length != 0)
                    {
                        ctl.St = Control_.State.LeftOperandEnter;
                        firstNumBox.Text = ctl.DoCmd(18);
                    }
                    if (secondNumBox.Text.Length != 0)
                    {
                        ctl.St = Control_.State.RightOperandEnter;
                        secondNumBox.Text = ctl.DoCmd(18);
                    }
                    resultBox.Text = ctl.DoCmd(25);
                    ctl.St = Control_.State.LeftOperandEnter;
                    break;
            }
            /*
             * Подключает подсветку желтым текстом
             * при переключении поля ввода
            */
            ActiveBox();
        }

        /*
         * Приватный метод класса Form1.cs
         * Виден только из класса Form1.cs
         * Если сейчас ативен ввод левого
         * операнда то он подсвечивается желтым
         * цветом, а правый белым
         * если сейчас активен ввод правого
         * операнда то он подсвечивается желтым
         * а левый белым
        */
        private void ActiveBox()
        {
            if (ctl.St == Control_.State.LeftOperandEnter)
            {
                firstNumBox.BackColor = Color.Yellow;
                secondNumBox.BackColor = Color.White;
            }
            if (ctl.St == Control_.State.RightOperandEnter)
            {
                firstNumBox.BackColor = Color.White;
                secondNumBox.BackColor = Color.Yellow;
            }
        }
        /*
         * Обработка кнопки выход...
         * просто закрывает приложение
        */
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
