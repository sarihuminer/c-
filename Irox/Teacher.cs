using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Irox
{
    class Teacher:Person
    {
        private double salary;

        public Teacher(string id, string name, int phone,double salary):base(id, name, phone)
        {
            this.salary = salary;
        }

        public override void printDetails()
        {
            base.print(this);
            Console.WriteLine(" salary "+this.salary);
        }

        public override string ToString()
        {
            return base.ToString()+" salary "+salary;
        }
        public static Teacher operator +(Teacher s1, Teacher s2)
        {
            Teacher newTt = new Teacher("00000", "zaza", 1231231,s1.salary+s2.salary);
            return newTt;
        }
    }
}
