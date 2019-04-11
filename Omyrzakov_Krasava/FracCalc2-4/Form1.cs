using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FracCalc1_4
{
    public partial class Form1 : Form
    {
        Control_ ctl = new Control_();

        public Form1()
        {
            InitializeComponent();
        }

        private void FracCalc_Load(object sender, EventArgs e)
        {
            ActiveBox();
        }

        private void buttonClick(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            int cmd = Convert.ToInt16(but.Tag.ToString());
            DoCmd(cmd);
        }

        private void DoCmd(int cmd)
        {
            switch(cmd)
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
                case 14:
                case 16:
                case 18:
                    if (ctl.St == Control_.State.FirstNumEnter)
                        FirstNumBox.Text = ctl.DoCmd(cmd);
                    if (ctl.St == Control_.State.SecondNumEnter)
                        SecondNumBox.Text = ctl.DoCmd(cmd);
                    break;
                case 10:
                case 11:
                case 12:
                case 13:
                    OperatorBox.Text = ctl.DoCmd(cmd);
                    ctl.DoCmd(19);
                    break;
                case 17:
                    if(OperatorBox.Text.Length != 0)
                        ResultNumBox.Text = ctl.DoCmd(cmd);
                    break;
                case 15:
                    ctl.DoCmd(cmd);
                    FirstNumBox.Text = "";
                    SecondNumBox.Text = "";
                    ResultNumBox.Text = "";
                    break;
                case 19:
                    ctl.DoCmd(cmd);
                    break;
                default:
                    break;
            }
            ActiveBox();
        }

        private void FracCalcKeyPress(object sender, KeyPressEventArgs e)
        {
            int i = -1;
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                i = (int)e.KeyChar - '0';
            if ((int)e.KeyChar == 43)
                i = 10;
            if ((int)e.KeyChar == 45)
                i = 11;
            if ((int)e.KeyChar == 42)
                i = 12;
            if ((int)e.KeyChar == 47)
                i = 13;
            DoCmd(i);
        }

        private void ActiveBox()
        {
            if (ctl.St == Control_.State.FirstNumEnter)
            {
                FirstNumBox.BackColor = Color.Aqua;
                SecondNumBox.BackColor = Color.White;
            }
            if (ctl.St == Control_.State.SecondNumEnter)
            {
                FirstNumBox.BackColor = Color.White;
                SecondNumBox.BackColor = Color.Aqua;
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.Show();
        }
    }
}
