using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOnSQLConnections
{
    class StudentService : IStudentService
    {
        StudentSQL_Connection std = new StudentSQL_Connection();
        public void AddStudent(string name, string id, byte age, byte standard, string city)
        {
            if(std.InsertData(name, id, age, standard, city))
            {
                Console.WriteLine("Student Details Added Successfully!");
            }
            else
            {
                Console.WriteLine("Failed To Add Student Details");
            }
        }

        

        public void UpdateStudentAge(string id, byte age)
        {
            if (std.GetNumberOfRecords() != 0)
            {
                if(std.UpdateAge(id, age))
                {
                    Console.WriteLine("Student Details Updated Successfully!");
                }
                else
                {
                    Console.WriteLine("\nStudent Not Found");
                }
            }
            else
            {
                Console.WriteLine("\nStudent Not Found");
            }

        }

        public void UpdateStudentCity(string id, string city)
        {
            if (std.GetNumberOfRecords() != 0)
            {
                if(std.UpdateCity(id, city))
                {
                    Console.WriteLine("Student Details Updated Successfully!");
                }
                else
                {
                    Console.WriteLine("\nStudent Not Found");
                }
            }

            else
            {
                Console.WriteLine("\nStudent Not Found");
            }
        }

        public void DisplayAll()
        {
            if (std.GetNumberOfRecords() != 0)
            {
                Console.WriteLine("All Students Details Are Shown Below:");
                std.ReadData();
            }

            else
            {
                Console.WriteLine("No Data Found, First Add Some Students");
            }
        }
        public bool DeleteStudent(string id)
        {
            if (std.GetNumberOfRecords() > 0)
            {
                if (std.DeleteData(id))
                {
                    Console.WriteLine("Student Details Deleted Successfully!");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


    }
}
