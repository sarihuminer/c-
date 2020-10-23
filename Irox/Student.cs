using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
namespace Irox
{
    public struct test
    {
        private string name;
        private int mark;

        public string Name
        {
            get => name;
            set => name = value;
        }


        public int Mark
        {
            get => mark;
            set => mark = value;
        }
        public test(string namen, int markn)
        {
            name = namen;
            mark = markn;

        }
    }
    class Student : Person,IEnumerable,IEnumerator
    {
        public static int cnt;
        private int grade;
        private test[] test = new test[10];
        private int currenti = 0;
        public int Currenti
        {
            get => currenti;
            set => currenti = value;
        }

        public test[] Test
        {
            get => test;
            set => test = value;
        }
        public int Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public object Current =>test[currenti].Name;

        static Student()
        {
            cnt = 0;
        }
        public Student(string id, string name, int phone, int grade) : base(id, name, phone)
        {
            this.grade = grade;
            // this.test = new test[10];
            cnt++;
        }
        public void AddTest( test t)
        {
            int l = this.test.Length;
            if (this.currenti >= l)
            {
                throw new Exception( "no place for test");
            }
            else
            {
                test[currenti++] = t;
            }
               
        }
        public override string ToString()
        {
            return base.ToString() + " grede " + this.grade;
        }

        
        public override void printDetails()
        {
            base.print(this);
            Console.WriteLine(" grade "+this.grade);
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            if (currenti < test.Length - 1)
            {
                ++currenti;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            currenti = -1;
        }
        public void printTest()
        {
            foreach (test t in test)
            {
                Console.WriteLine(t.Name);
            }
        }
    }
}
