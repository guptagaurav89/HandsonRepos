using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExamples
{
    /*Various group key are modified to group.key.deptName originally only group.key was used
     */
    class ComplexLinqQueries
    {
        static void Main(string[] args)
        {
            #region GroupBySingleKey
            var Employeegroup = from emp in Employee.GetEmployees()
                                group emp by emp.Department into egroups
                                orderby egroups.Key
                                select new
                                {
                                    Key = egroups.Key.DeptName,
                                    Employees = egroups.OrderBy(x => x.EmpName)
                                };

            foreach (var group in Employeegroup)
            {
                Console.WriteLine(" {0} -- {1}", group.Key, group.Employees.Count());
                Console.WriteLine("-----------------");
                foreach (var employee in group.Employees)
                {
                    Console.WriteLine(employee.EmpName + " " + employee.Department.DeptName);
                }
                Console.WriteLine();
            }
            #endregion

            #region GroupByMultipleKeys
            var EmployeeGroup = Employee.GetEmployees().GroupBy(x => new { x.Department, x.Gender })
                                .OrderBy(g => g.Key.Department).ThenBy(g => g.Key.Gender);
            foreach (var group in EmployeeGroup)
            {
                Console.WriteLine(" {0} --has {1} {2} Employees", group.Key.Department.DeptName, group.Count(), group.Key.Gender);
                Console.WriteLine("-----------------");
                foreach (var employee in group)
                {
                    Console.WriteLine(employee.EmpName + " " + employee.Department.DeptName);
                }
                Console.WriteLine();
            }
            #endregion

            #region GroupJoin
            // Uses Keyword GroupJoin method or uses into egroups query

            //var EmployeebyDept = Department.getAllDepartments()
            //                             .GroupJoin(Employee.GetEmployees(),
            //                                    d => d.DeptId,
            //                                    e => e.Department,
            //                                    (dept, employee) => new
            //                                    {
            //                                        Department = dept,
            //                                        Employee = employee
            //                                    });
            //var grpres = from d in Department.getAllDepartments()
            //             join e in Employee.GetEmployees() 
            //             on d.DeptId equals e.Department into egroups
            //             select new
            //                 {
            //                     Department = d.DeptName,
            //                     Employees = egroups
            //                 };

            //foreach (var res in grpres)
            //{
            //    Console.WriteLine(res.Department);
            //    foreach (var emp in res.Employees)
            //        Console.WriteLine(emp.EmpName + " " + emp.Salary);
            //}

            //foreach (var dept in EmployeebyDept)
            //{
            //    Console.WriteLine(dept.Department.DeptName);
            //    foreach (var emp in dept.Employee)
            //    {
            //        Console.WriteLine(" " + emp.EmpName);
            //    }
            //    Console.WriteLine();
            //}
            #endregion

            //#region InnerJoin
            ////uses only Join Method or keyword

            //var EmployeebyDept = from e in Employee.GetEmployees()
            //                     join d in Department.getAllDepartments()
            //                     on e.Department equals d.DeptId 
            //                     select new
            //                     {
            //                         Employee = e.EmpName,
            //                         Department = d.DeptName
            //                     };
            //foreach (var emp in EmployeebyDept)
            //{
            //    Console.WriteLine(emp.Employee + " " + emp.Department);                
            //}
            //#endregion


            //#region LeftJoin
            ////uses only Join Method or keyword

            //var EMployees = from e in Employee.GetEmployees()
            //                     join d in Department.getAllDepartments()
            //                     on e.Department equals d.DeptId
            //                     into empdept
            //                from list in empdept.DefaultIfEmpty(new Department{DeptName= "Left Company"})
            //                     select new
            //                     {
            //                         Employee = e.EmpName,
            //                         Department = list.DeptName
            //                     };
            //foreach (var emp in EMployees)
            //{
            //    Console.WriteLine(emp.Employee + " " + emp.Department);
            //}
            //#endregion

            #region InnerQuery

            //var innerquery = from d in Department.getAllDepartments()
            //                 where d.DeptId < 3
            ////                 select d.DeptId;
            //var result = from emp in Employee.GetEmployees()
            //             let innerquery = from d in Department.getAllDepartments()
            //                              where d.DeptId < 3
            //                              select d.DeptId
            //             where innerquery.Contains(emp.Department)
            //             select emp;

            //foreach (var emp in result)
            //{
            //    Console.WriteLine(emp.EmpName + " " + emp.Department);
            //}

            #endregion

            //////var values = intermediateValues
            ////////.GroupBy(x => new {x.Rate, x.ExpiryDate })
            //////.GroupBy(r => new { Rate = ((int)(r.Rate / BucketSize)) * BucketSize, ExpiryDate = r.ExpiryDate })
            //////.Select(y => new FXOptionScatterplotValue
            //////{
            //////    Volume = y.Sum(z => z.TransactionType == "TERMINATION" ? -z.Volume : z.Volume),
            //////    Rate = y.Key.Rate,
            //////    ExpiryDate = y.Key.ExpiryDate,
            //////    Count = y.Count()
            //////}).ToArray();

            Console.ReadKey();

        }
    }

    public class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public Department Department { get; set; }
        public string Gender { get; set; }
        public static List<Employee> GetEmployees()
        {
            return new List<Employee> { new Employee{ EmpID = 1, EmpName = "Gaurav" , Department = new Department { DeptId = 1, DeptName = "Xuber"},Gender = "M" } };
        }
    }

    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public static List<Department> getAllDepartments()
        {
            throw new NotImplementedException();
        }
    }
}
