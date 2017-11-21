using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF4Concepts
{
    public class Class1
    {
        TestEFEntities db;

        public void GetDepartmentDetails()
        {
            try
            {

                db = new TestEFEntities();
                var dept = from d in db.Departments
                           select d;

                foreach (var dd in dept)
                    Console.WriteLine("Department Name : " + dd.DeptName + " Department Head Id " + dd.EmployeeReference.EntityKey.EntityKeyValues.First().Value);
                //Console.WriteLine("Department Name : " + dd.DeptName + " Department Head Id ");// + dd.Employee.Empid);
            }
            catch (Exception)
            {
                Console.Write("Err");
            }
        }

        public void GetDepartmentDetails(int deptid)
        {
            try
            {
                db = new TestEFEntities();
                var dept = (from d in db.Departments
                            where d.DeptId == deptid
                            select d).FirstOrDefault();

                Console.WriteLine("Department Name : " + dept.DeptName + " Department Head Id " + dept.EmployeeReference.EntityKey.EntityKeyValues.First().Value);
                //Console.WriteLine("Department Name : " + dept.DeptName + " Department Head Id ");// + dept.Employee.Empid);
            }
            catch (Exception)
            {
                Console.Write("Err");
            }
        }
    }
}
