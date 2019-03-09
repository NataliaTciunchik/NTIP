using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationSetInt
{
    class SetInt
    {
        List<int> Set;
        /*Операция Элемент. Возвращает элемент множества с индексом i.*/
        public int this[int i]
        {
            get { return Set[i]; }
        }
        /*Конструктор класса. Создаёт множество и инициализирует поле Set пустым списком*/
        public SetInt()
        {
            Set = new List<int>();
        }
        /*Операция МножествоВСтроку. Формирует строку из элементов множества.*/
        public string ToSting()
        {
            string s = "";
            for (int i = 0; i < Set.Count; i++)
            {
                if (s != "") { s += "; " + Set[i]; }
                else { s += Set[i]; }
            }
            return s;
        }
        //Операция Добавить. Включает заданный элемент во множество.
        public void AddTo(int x)
        {
            Set.Add(x);
        }
        //Операция Удалить. Удаляет заданный элемент из множества.
        public void DeleteFrom(int x)
        {
            while(this.Belong(x))
                this.Set.Remove(x);
        }
        //Операция Элементов. Возвращает число элементов во множестве.
        public int Count()
        {
            return Set.Count;
        }
        //Операция Опустошить. Удаляет из множества все элементы.
        public void Clear()
        {
            Set.Clear();
        }
        //Операция Пусто. проверяет пусто ли множество.
        public bool IsEmpty()
        {
            if (Set.Count == 0)
                return true;
            else
                return false;
        }
        //Операция Объединить. Создаёт множество, полученное объединением элементов двух множеств.
        public static SetInt operator +(SetInt a, SetInt b)
        {
            SetInt c = new SetInt();
            for (int i = 0; i < a.Set.Count; i++)
                if (!c.Belong(a.Set[i]))
                    c.AddTo(a.Set[i]);
            for (int i = 0; i < b.Set.Count; i++)
                if(!c.Belong(b.Set[i]))
                    c.AddTo(b.Set[i]);
            return c;
        }
        //Операция Умножить. Создаёт множество, полученное путём пересечения двух множеств.
        public static SetInt operator *(SetInt a, SetInt b)
        {
            SetInt c = new SetInt();
            for(int i = 0; i < a.Set.Count; i++)
                for(int j = 0; j < b.Set.Count; j++)
                    if (a.Set[i] == b.Set[i] && !c.Belong(a.Set[i]))
                        c.AddTo(a.Set[i]);
            return c;
        }
        //Операция Вычесть. Создаёт множество, полученное вычитанием из одного множества другого.
        public static SetInt operator -(SetInt a, SetInt b)
        {
            SetInt c = new SetInt();
            for (int i = 0; i < a.Set.Count; i++)
                if (b.Belong(a.Set[i]))
                    continue;
                else
                    if (!c.Belong(a.Set[i]))
                        c.AddTo(a.Set[i]);

            for (int i = 0; i < b.Set.Count; i++)
                if (a.Belong(b.Set[i]))
                    continue;
                else
                    if (!c.Belong(b.Set[i]))
                        c.AddTo(b.Set[i]);
            return c;
        }
        //Операция Равно. Проверяет два множества на совпадение их элементов
        public static bool operator ==(SetInt a, SetInt b)
        {
            if (a.Set.Count == b.Set.Count)
            {
                a.Set.Sort();
                b.Set.Sort();
                for (int i = 0; i < a.Set.Count; i++)
                    if (a.Set[i] != b.Set[i])
                        return false;
                return true;
            }
            else
                return false;
        }
        //Операция Неравно. Проверяет два множества на не совпадение их элементов
        public static bool operator !=(SetInt a, SetInt b)
        {
            return !(a == b);
        }
        //Операция Принадлежит. Проверяет элемент x на принадлежность множеству.
        public bool Belong(int x)
        {
            for (int i = 0; i < this.Set.Count; i++)
                if (this.Set[i] == x)
                    return true;
            return false;
        }
    }
}
