using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOnSQLConnections
{
    interface IStudentService
    {
        void AddStudent(string name, string id, byte age, byte standard, string city);
        void UpdateStudentAge(string id, byte age);
        void UpdateStudentCity(string id, string city);
        void DisplayAll();
        bool DeleteStudent(string id);

    }
}
