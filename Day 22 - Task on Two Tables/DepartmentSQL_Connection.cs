using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TaskOnSQLConnections
{
    class DepartmentSQL_Connection
    {
        SqlConnection conn;

        public DepartmentSQL_Connection()
        {
            conn = new SqlConnection("Server = DEL1-LHP-N82143\\MSSQLSERVER01; Database = Student_Details; Integrated Security = SSPI");
        }


        public bool InsertDataIntoDept(string id, string deptName, string manager)
        {
            try
            {
                conn.Open();
                string insertString = $"Insert into Department values('{id}','{deptName}','{manager}')";

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

        public bool DeleteDataFromDept(string id)
        {
            try
            {
                conn.Open();

                string DeleteString = $"delete from Department where Id = '{id}'";

                SqlCommand cmd = new SqlCommand(DeleteString, conn);

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

        public int GetNumberOfRecords()
        {
            int count = -1;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select count(*) from Department", conn);

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
