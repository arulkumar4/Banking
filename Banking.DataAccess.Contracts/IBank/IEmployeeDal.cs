using Banking.Business.Models;
using System.Collections.Generic;

namespace Banking.DataAccess.Contracts
{
    public interface IEmployeeDal
    {
        int AddEmployee(Employee employee);
        List<Employee> GetEmployees();
        List<Employee> GetEmployeeById(int employeeid);
        int UpdateEmployee(Employee employee);
        int DeleteEmployee(int employeeid);
        List<Employee> GetEmployeesByKeyword(string keyword);
        int GetEmployeeId(string mail);

    }
}
