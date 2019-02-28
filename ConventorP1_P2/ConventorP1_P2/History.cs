using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventorP1_P2
{
    public struct Record
    {
        int p1;
        int p2;
        string number1;
        string number2;
        public Record(int p1, int p2, string n1, string n2)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.number1 = n1;
            this.number2 = n2;
        }

        public override string ToString()
        {
            return "Число " + this.number1 + " в с. сч " + this.p1 + " равняется " + this.number2 + " в с.сч " + this.p2;
        }
    }

    class History
    {
        private List<Record> L = new List<Record>();
        public Record SearchRecord(int i)
        {
            return this.L[i];
        }
        public void AddRecord(int p1, int p2, string n1, string n2)
        {
            this.L.Add(new Record(p1, p2, n1, n2));
        }
        public void Clear()
        {
            this.L.Clear();
        }
        public int Count()
        {
            return this.L.Count();
        }
        public History()
        {
            this.L.Clear();
        }
    }
}
