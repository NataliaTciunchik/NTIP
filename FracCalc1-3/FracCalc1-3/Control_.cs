using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FracCalc1_4
{
    class Control_
    {
        Editor FirstNum = new Editor();

        Editor SecondNum = new Editor();

        public enum State { FirstNumEnter, SecondNumEnter, Execute };

        public State St { get; set; }

        public enum Operation { Add, Substract, Multiply, Devide, Undefined };

        public Operation Op { get; set; }

        public Control_()
        {
            St = State.FirstNumEnter;
            Op = Operation.Undefined;
        }

        public string DoCmd(int cmd)
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
                case 15:
                case 16:
                case 18:
                    if (St == State.FirstNumEnter)
                        return FirstNum.DoEdit(cmd);
                    if (St == State.SecondNumEnter)
                        return SecondNum.DoEdit(cmd);
                    break;
                case 10:
                    Op = Operation.Add;
                    return "+";
                case 11:
                    Op = Operation.Substract;
                    return "-";
                case 12:
                    Op = Operation.Multiply;
                    return "*";
                case 13:
                    Op = Operation.Devide;
                    return "/";
                case 17:
                    if (FirstNum.Number.Length == 0 || SecondNum.Number.Length == 0)
                        break;

                    bool isFracFirst = false;
                    bool isFracSecond = false;
                    for (int i = 0; i < FirstNum.Number.Length; i++)
                        if (FirstNum.Number[i] == FirstNum.delim && i != FirstNum.Number.Length - 1)
                            isFracFirst = true;
                    for (int i = 0; i < SecondNum.Number.Length; i++)
                        if (SecondNum.Number[i] == SecondNum.delim && i != SecondNum.Number.Length - 1)
                            isFracSecond = true;

                    if (!isFracFirst || !isFracSecond)
                        break;

                    St = State.Execute;
                    Frac a = new Frac(FirstNum.Number);
                    Frac b = new Frac(SecondNum.Number);
                    string result = "";
                    switch(Op)
                    {
                        case Operation.Add:
                            result = (a + b).ToString();
                            break;
                        case Operation.Substract:
                            result = (a - b).ToString();
                            break;
                        case Operation.Multiply:
                            result = (a * b).ToString();
                            break;
                        case Operation.Devide:
                            result = (a / b).ToString();
                            break;
                        default:
                            break;
                    }
                    St = State.FirstNumEnter;
                    return result;
                case 19:
                    if (St == State.FirstNumEnter)
                        St = State.SecondNumEnter;
                    else
                        St = State.FirstNumEnter;
                    break;
                default:
                    break;
            }
            return "";
        }
    }
}
