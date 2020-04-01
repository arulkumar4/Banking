using Banking.Business.Models;
using System.Collections.Generic;

namespace Banking.Business.Contracts
{
    public interface IEmployeeBl
    {
        int AddEmployee(Employee employee);
        List<Employee> GetEmployees();
        List<Employee> GetEmployeeById(int employeeid);
        int UpdateEmployee(Employee employee);
        int DeleteEmployee(int employeeid);
        int GetEmployeeId(string mail);
        List<Employee> GetEmployeesByKeyword(string keyword);
    }
}
