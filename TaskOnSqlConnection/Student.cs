using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOnSQLConnections
{
    class Student
    {
        string name, city,id;
        byte standard, age;

       public Student(string name, string id, byte age, byte standard, string city)
        {
            this.name = name;
            this.city = city;
            this.age = age;
            this.id = id;
            this.standard = standard;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public byte Standard
        {
            get { return standard; }
            set { standard = value; }
        }
        public byte Age
        {
            get { return age; }
            set { age = value; }
        }
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
    }
}
