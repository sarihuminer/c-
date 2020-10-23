using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Irox
{
   public abstract  class Person:UpdateDetails
    {
        private readonly string id;
        private string name;
        private int phone;

        public string Id
        {
            get => id;
            
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public int Phone
        {
            get => phone;
            set => phone = value;
        }
        public Person(string id,string name,int phone)
        {
            this.id = id;
            this.name = name;
            this.phone = phone;
        }
        
        public override string ToString()
        {
            string x;
            x = "id "+ this.id+" name " + this.name+" phone "+ this.phone;
            return x;
        }

        public void UpdateBaseDetails(string name, int phone)
        {
            this.name = name;
            this.phone = phone;
        }

        public void print(Person p)
        {
            if (p is Teacher)
                Console.Write("teacher ");
            else {
                if(p is Student)
                    Console.Write("student ");
                else
                    Console.Write("manager");
            }
            Console.Write("id {0} name {1} phone {2} ", p.id, p.name, p.phone);
        }
        public abstract void printDetails();
    }
}
