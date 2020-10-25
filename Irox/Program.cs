using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;

namespace Irox
{
    class Program
    {
        //xml
        public static void ReadXmlFile(string namefieldTOSort, string orderby, string filterField, string value, char o)
        {
            try
            {

                string spath = @"C:\Users\sari\Documents\year3\Irox\Irox\XMLFile1.xml";
                string spath_New = @"C:\Users\sari\Documents\year3\Irox\Irox\XMLFile2.xml";

                XDocument doc = XDocument.Load(spath);
                var parent = doc.Descendants("products").Single().Elements();
                List<XElement> xmlFiltr = new List<XElement>();
                switch (o)
                {
                    case '<':
                        xmlFiltr = parent.Where(q => int.Parse(q.Attribute(filterField).Value) < int.Parse(value)).ToList();
                        break;
                    case '>':
                        xmlFiltr = parent.Where(q => int.Parse(q.Attribute(filterField).Value) > int.Parse(value)).ToList();
                        break;
                    case '=':
                        xmlFiltr = parent.Where(q => q.Attribute(filterField).Value == value).ToList();
                        break;

                }

                if (orderby == "acending")
                    xmlFiltr = xmlFiltr.OrderBy(tuple => tuple.Element(namefieldTOSort).Value).ToList();
                else
                    xmlFiltr = xmlFiltr.OrderByDescending(tuple => tuple.Element(namefieldTOSort).Value).ToList();

                //write to file
                XDocument doc2 = XDocument.Load(spath_New);
                doc2.Descendants("products").Single().Add(xmlFiltr);
                doc2.Save(spath_New);
            }
            catch
            {

            }


        }




        public static void printStudents(List<Student> sl)
        {
            foreach (Student s in sl)
            {
                Console.WriteLine(s);
            }
        }

        static void isAstring(Object obj)
        {
            if (obj.GetType().Equals(typeof(System.String)))
                Console.WriteLine("the obj {0} is string", obj);
            else
                Console.WriteLine("the obj is NOT string!");
        }

        static void Rreflection()
        {
            //reflection

            isAstring("sari");
            isAstring(1);

            Assembly assembly = Assembly.LoadFrom("System.dll");

            //all classes
            foreach (Type type in assembly.GetTypes())
            {
                //methods
                foreach (MemberInfo method in type.GetMethods())
                {
                    Console.WriteLine("\t==Method:{0}", method.Name);
                }
                //properties
                foreach (PropertyInfo property in type.GetProperties())
                {
                    Console.WriteLine("\t==property:{0}", property.Name);
                }
            }

        }

        public delegate void Mydelegate();
        static void Main(string[] args)
        {
            //xml
            ReadXmlFile("name", "acending", "id", "2", '>');


            //reflection
            //Rreflection();

            //students
            Console.ForegroundColor = ConsoleColor.Magenta;
            List<Student> listStud = new List<Student>();
            Student s = new Student("1231", "sarit", 45, 1);
            Student s1 = new Student("1111", "dasi", 77778, 2);
            Student s2 = new Student("1232221", "shoshi", 7897979, 1);
            Student s3 = new Student("888", "nechama", 45646546, 1);
            Student s4 = new Student("99", "sarita", 213131, 3);


            //test
            test test1 = new test("c#", 100);
            test test2 = new test("sql", 90);
            test test3 = new test("c++", 70);

            s.AddTest(test1);
            s.AddTest(test2);
            s.AddTest(test3);

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            //ienumurable//enamurator
            s.printTest();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.Black;

            //teachers
            Teacher t = new Teacher("315013565", "moria", 035793876, 800000);
            Teacher t1 = new Teacher("2222222", "sani", 84984984, 9600);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(t);
            Console.WriteLine(t1);

            Console.ForegroundColor = ConsoleColor.Gray;
            Teacher t2 = t + t1;
            Console.WriteLine(t2);

            listStud.Add(s);
            listStud.Add(s1);
            listStud.Add(s2);
            listStud.Add(s3);
            listStud.Add(s4);

            //print students
            foreach (Student student in listStud)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                student.printDetails();
                //Console.WriteLine("id {0} name {1} phone {2} grade {3}", student.Id, student.Name, student.Phone, student.Grade);
                for (int i = 0; i < student.Test.Length && student.Test[i].Name != null; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;

                    Console.WriteLine(" subject " + student.Test[i].Name + " mark " + student.Test[i].Mark);


                }

            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("the studets sum is {0} ", Student.cnt);
            Console.ForegroundColor = ConsoleColor.Magenta;
            //edit details student
            Console.WriteLine("the studet is before {0} ", s);

            s.UpdateBaseDetails("sari", 054859755);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("the studet is after {0} ", s);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            printStudents(listStud);

            Console.ForegroundColor = ConsoleColor.Red;
            //delegate
            Console.WriteLine("*****************************delegate************");
            Mydelegate d = new Mydelegate(s.printDetails);
            Mydelegate d1 = new Mydelegate(s.printTest);
            d += d1;

            d();
            Console.Read();
            // Person p = new Person();
        }
    }
}
