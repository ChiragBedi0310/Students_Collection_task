using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TaskOnSQLConnections
{
    class StudentSQL_Connection
    {
        SqlConnection conn;

        public StudentSQL_Connection()
        {
            conn = new SqlConnection("Server = DEL1-LHP-N82143\\MSSQLSERVER01; Database = Student_Details; Integrated Security = SSPI");
        }

        public void ReadData()
        {
            SqlDataReader reader = null;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from Student", conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("ID Name Age Standard City");
                    for(int i = 0; i < reader.FieldCount; i++)
                    { 
                        Console.Write(reader[i] + " ");
                    }
                    Console.WriteLine("");
                }
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public bool InsertData(string name, string id,byte age,byte standard,string city)
        {
            try
            {
                conn.Open();
                string insertString = $@"insert into Student(Name,Id,Age,Standard,City)
                                    values({name},@Id,@Age,@Standard,@City)";

                SqlCommand cmd = new SqlCommand(insertString, conn);
                //SqlParameter Name = new SqlParameter();
                //Name.ParameterName = "@Name";
                //Name.Value = name;
                SqlParameter Id = new SqlParameter();
                Id.ParameterName = "@Id";
                Id.Value = id;
                SqlParameter Age = new SqlParameter();
                Age.ParameterName = "@Age";
                Age.Value = age;
                SqlParameter Standard = new SqlParameter();
                Standard.ParameterName = "@Standard";
                Standard.Value = standard;
                SqlParameter City = new SqlParameter();
                City.ParameterName = "@City";
                City.Value = city;


                //cmd.Parameters.Add(Name);
                cmd.Parameters.Add(Id);
                cmd.Parameters.Add(Age);
                cmd.Parameters.Add(Standard);
                cmd.Parameters.Add(City);

                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public bool UpdateAge(string id, int age)
        {
            try
            {
                conn.Open();

                string UpdateString = @"update Student
                                        set Age = @Age
                                        where Id = @Id";

                SqlCommand cmd = new SqlCommand(UpdateString,conn);
                SqlParameter Age = new SqlParameter();
                Age.ParameterName = "@Age";
                Age.Value = age;
                SqlParameter Id = new SqlParameter();
                Id.ParameterName = "@Id";
                Id.Value = id;

                cmd.Parameters.Add(Age);
                cmd.Parameters.Add(Id);

                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public bool UpdateCity(string id, string city)
        {
            try
            {
                conn.Open();

                string UpdateString = @"update Student
                                        set Age = @City
                                        where Id = @Id";

                SqlCommand cmd = new SqlCommand(UpdateString, conn);
                SqlParameter City = new SqlParameter();
                City.ParameterName = "@City";
                City.Value = city;
                SqlParameter Id = new SqlParameter();
                Id.ParameterName = "@Id";
                Id.Value = id;

                cmd.Parameters.Add(City);
                cmd.Parameters.Add(Id);

                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public bool DeleteData(string id)
        {
            try
            {
                conn.Open();

                string DeleteString = @"delete from Student
                                        where Id = @Id";

                SqlCommand cmd = new SqlCommand(DeleteString,conn);
                SqlParameter Id = new SqlParameter();
                Id.ParameterName = "@Id";
                Id.Value = id;

                cmd.Parameters.Add(Id);

                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public int GetNumberOfRecords()
        {
            int count = -1;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select count(*) from Student", conn);

                count = (int)cmd.ExecuteScalar();
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return count;
        }
    }
}
