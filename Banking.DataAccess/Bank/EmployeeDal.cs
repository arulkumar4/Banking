using Banking.Business.Models;
using Banking.DataAccess.Contracts;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Banking.DataAccess
{
    public class EmployeeDal : BaseDal, IEmployeeDal
    {
        public int AddEmployee(Employee employee)
        {
            var EmployeeId = GetValue<int>(ProcedureNames.Employee.InsertEmployee,
               new SqlParameter("Firstname", employee.FirstName),
               new SqlParameter("Lastname", employee.LastName),
               new SqlParameter("Fullname", employee.FullName),
               new SqlParameter("contactnumber", employee.ContactNumber),
               new SqlParameter("mail", employee.Mail),
               new SqlParameter("dob", employee.DOB),
               new SqlParameter("ManagerId",employee.ManagerId)
               );
            return EmployeeId;
        }

        public int DeleteEmployee(int employeeid)
        {
            var status = GetValue<int>(ProcedureNames.Employee.DeleteEmployee,
                new SqlParameter("EmployeeId", employeeid)
                );
            return status;
        }

        public List<Employee> GetEmployeeById(int employeeid)
        {
            List<Employee> Employees = new List<Employee>();
            using (var dataset = GetDataset(ProcedureNames.Employee.GetEmployeeById,
                                    new SqlParameter("id", employeeid)))
            {
                var employeetable = dataset.Tables[0];
                var employeetableDetail = employeetable.AsEnumerable();
                foreach (var employeeRow in employeetableDetail)
                {
                    Employees.Add(PopulateData<Employee>(employeeRow));
                }
            }
            return Employees;
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> Employees = new List<Employee>();
            using (var dataset = GetDataset(ProcedureNames.Employee.GetEmployees))
            {
                var employeetable = dataset.Tables[0];
                var employeetableDetail = employeetable.AsEnumerable();
                foreach (var employeeRow in employeetableDetail)
                {
                    Employees.Add(PopulateData<Employee>(employeeRow));
                }
            }
            return Employees;
        }

        public int UpdateEmployee(Employee employee)
        {
            var status = GetValue<int>(ProcedureNames.Employee.UpdateEmployeeById,
               new SqlParameter("id", employee.Id),
               new SqlParameter("Firstname", employee.FirstName),
               new SqlParameter("Lastname", employee.LastName),
               new SqlParameter("Fullname", employee.FullName),
               new SqlParameter("contactnumber", employee.ContactNumber),
               new SqlParameter("mail", employee.Mail),
               new SqlParameter("dob", employee.DOB),
               new SqlParameter("ManagerId", employee.ManagerId)
               );
            return status;
        }
    }
}
