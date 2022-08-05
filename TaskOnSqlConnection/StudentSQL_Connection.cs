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
                string insertString = $"Insert into Student values('{id}','{name}','{age}','{standard}','{city}')";

                SqlCommand cmd = new SqlCommand(insertString, conn);

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

                string UpdateString = $"update Student set Age = '{age}' where Id = '{id}";

                SqlCommand cmd = new SqlCommand(UpdateString,conn);

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

                string UpdateString = $"update Student set City = '{city}' where Id = '{id}'";

                SqlCommand cmd = new SqlCommand(UpdateString, conn);

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

                string DeleteString = $"delete from Student where Id = '{id}'";

                SqlCommand cmd = new SqlCommand(DeleteString,conn);

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
