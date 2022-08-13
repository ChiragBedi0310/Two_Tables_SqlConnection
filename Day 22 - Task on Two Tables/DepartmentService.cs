using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOnSQLConnections
{
    class DepartmentService
    {
        DepartmentSQL_Connection dept = new DepartmentSQL_Connection();

        public void AddDepartment(string id, string deptName, string manager)
        {
            if (dept.InsertDataIntoDept(id, deptName, manager))
            {
                Console.WriteLine("Department Details Added Successfully!");
            }
            else
            {
                Console.WriteLine("Failed To Add Department Details");
            }
        }

        public bool DeleteDepartment(string id)
        {
            if (dept.GetNumberOfRecords() > 0)
            {
                if (dept.DeleteDataFromDept(id))
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
