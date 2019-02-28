using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConventorP1_P2
{
    public partial class TPanel_p_p : Form
    {
        Control_ ctl = new Control_();

        public TPanel_p_p()
        {
            InitializeComponent();
        }

        private void TPanelp_p_Load(object sender, EventArgs e)
        {
            label1.Text = ctl.ed.Number;
            this.KeyPreview = true;
            //Основание с.сч. исходного числа р1.
            trackBar1.Value = ctl.Pin;
            //Основание с.сч. результата р2.
            trackBar2.Value = ctl.Pout;
            label3.Text = "Основание с. сч. исходного числа " + trackBar1.Value;
            label4.Text = "Основание с. сч. результата " + trackBar2.Value;
            label2.Text = "0";
            numericUpDown1.Value = trackBar1.Value;
            numericUpDown2.Value = trackBar2.Value;
            //Обновить состояние командных кнопок.
            this.UpdateButtons();
        }

        private void TPanelp_p_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                //Клавиша Delete.
                DoCmnd(18);
            if (e.KeyCode == Keys.Execute)
                //Клавиша Execute Separator.
                DoCmnd(19);
            /*
            if (e.KeyCode == Keys.Decimal)
                DoCmnd(16);
                */
        }

        private void TPanelp_p_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                int i = -1;
                if (e.KeyChar >= 'A' && e.KeyChar <= 'F')
                    i = (int)e.KeyChar - 'A' + 10;
                if (e.KeyChar >= 'a' && e.KeyChar <= 'f')
                    i = (int)e.KeyChar - 'a' + 10;
                if (e.KeyChar >= '0' && e.KeyChar <= '9')
                    i = (int)e.KeyChar - '0';
                if (e.KeyChar == '.')
                    i = 16;
                if ((int)e.KeyChar == 8)
                    i = 17;
                if ((int)e.KeyChar == 13)
                    i = 19;
                if ((i < ctl.Pin) || (i >= 16))
                    DoCmnd(i);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            numericUpDown1.Value = trackBar1.Value;
            //Обновить состояние командных кнопок.
            this.UpdateP1();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //Обновить состояние.
            trackBar1.Value = Convert.ToByte(numericUpDown1.Value);
            //Обновить состояние командных кнопок.
            this.UpdateP1();
        }

        //Выполняет необходимые обновления при смене ос. с.сч. р1.
        private void UpdateP1()
        {
            label3.Text = "Основание с. сч. исходного числа " + trackBar1.Value;
            //Сохранить р1 в объекте управление.
            ctl.Pin = trackBar1.Value;
            //Обновить состояние командных кнопок.
            this.UpdateButtons();
            label1.Text = ctl.DoCmnd(18);
            label2.Text = "0";
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            //Обновить состояние.
            numericUpDown2.Value = trackBar2.Value;
            this.UpdateP2();
        }


        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            trackBar2.Value = Convert.ToByte(numericUpDown2.Value);
            this.UpdateP2();
        }

        //Выполняет необходимые обновления при смене ос. с.сч. р2.
        private void UpdateP2()
        {
            //Копировать основание результата.
            ctl.Pout = trackBar2.Value;
            //Пересчитать результат.
            label2.Text = ctl.DoCmnd(19);
            label4.Text = "Основание с. сч. результата " + trackBar2.Value;
        }

        private void button_Click(object sender, EventArgs e)
        {
            //ссылка на компонент, на котором кликнули мышью
            Button but = (Button)sender;
            //номер выбранной команды
            int j = Convert.ToInt16(but.Tag.ToString());
            DoCmnd(j);
        }

        private void DoCmnd(int j)
        {
            if (j == 19)
                label2.Text = ctl.DoCmnd(j);
            else
            {
                if (ctl.St == Control_.State.Преобразовано)
                {
                    //очистить содержимое редактора
                    label1.Text = ctl.DoCmnd(18);
                }
                //выполнить команду редактирования
                label1.Text = ctl.DoCmnd(j);
                label2.Text = "0";
            }
        }

        private void UpdateButtons()
        {
            //просмотреть все компоненты формы
            foreach (Control i in this.Controls)
            {
                if (i is Button)//текущий компонент - командная кнопка
                {
                    int j = Convert.ToInt16(i.Tag.ToString());
                    if (j < trackBar1.Value)
                    {
                        //сделать кнопку доступной
                        i.Enabled = true;
                    }
                    if ((j >= trackBar1.Value) && (j <= 15))
                    {
                        //сделать кнопку недоступной
                        i.Enabled = false;
                    }
                }
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void историяToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HistoryForm history = new HistoryForm();
            history.Show();
            if (ctl.his.Count() == 0)
            {
                history.textBox1.AppendText("История пуста");
                return;
            }
            //Ообразить историю.
            for (int i = 0; i < ctl.his.Count(); i++)
                history.textBox1.AppendText(ctl.his.SearchRecord(i).ToString() + Environment.NewLine);
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox a = new AboutBox();
            a.Show();
        }
    }
}
