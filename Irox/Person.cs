using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Irox
{
   public class Person
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
        public virtual   void  EditDetails( string name,int phone)
        {
           this.name = name;
            this.phone = phone;

        }
        public override string ToString()
        {
            string x;
            x = "id "+ this.id+" name " + this.name+" phone "+ this.phone;
            return x;
        }
    }
}
