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
        public override string ToString()
        {
            return base.ToString()+" salary "+salary;
        }
    }
}
