using Banking.Business.Contracts;
using Banking.Business.Models;
using Banking.DataAccess.Contracts;
using System;
using System.Collections.Generic;

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

        public List<Employee> GetEmployees()
        {
            return _employeedal.GetEmployees();
        }

        public int UpdateEmployee(Employee employee)
        {
            return _employeedal.UpdateEmployee(employee);
        }
    }
}
