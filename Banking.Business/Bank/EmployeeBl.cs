using Banking.Business.Contracts;
using Banking.Business.Models;
using Banking.DataAccess.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Banking.Business
{
    public class EmployeeBl : IEmployeeBl
    {
        private readonly IEmployeeDal _employeedal;
        public EmployeeBl(IEmployeeDal employeedal)
        {
            _employeedal = employeedal;
        }

        public int AddEmployee(Employee employee)
        {
            return _employeedal.AddEmployee(employee);
        }

        public int DeleteEmployee(int employeeid)
        {
            return _employeedal.DeleteEmployee(employeeid);
        }

        public List<Employee> GetEmployeeById(int employeeid)
        {
            return _employeedal.GetEmployeeById(employeeid);
        }

        public int GetEmployeeId(string mail)
        {
            return _employeedal.GetEmployeeId(mail);

        }

        public List<Employee> GetEmployees()
        {
            return _employeedal.GetEmployees();
            
        }

        public List<Employee> GetEmployeesByKeyword(string keyword)
        {
            return _employeedal.GetEmployeesByKeyword(keyword);
        }

        public int UpdateEmployee(Employee employee)
        {
            return _employeedal.UpdateEmployee(employee);
        }
    }
}
