using Banking.Business.Contracts;
using Banking.Business.Models;
using System.Web.Http;

namespace Banking.WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeBl _employeebl;
        public EmployeeController(IEmployeeBl employeebl)
        {
            _employeebl = employeebl;
        }
        [Route("api/AddEmployee")]
        [HttpPost]
        public IHttpActionResult AddEmployee([FromBody]Employee employee)
        {
            return Ok(_employeebl.AddEmployee(employee));
        }
        [Route("api/GetEmployee")]
        [HttpGet]
        public IHttpActionResult GetEmployee()
        {
            return Ok(_employeebl.GetEmployees());
        }
        [Route("api/GetEmployee/{employeeid}")]
        [HttpGet]
        public IHttpActionResult GetBranch(int employeeid)
        {
            return Ok(_employeebl.GetEmployeeById(employeeid));
        }
        [Route("api/UpdateEmployee")]
        [HttpPut]
        public IHttpActionResult UpdateEmployee(Employee employee)
        {
            return Ok(_employeebl.UpdateEmployee(employee));
        }
        [Route("api/DeleteEmployee/{employeeid}")]
        [HttpDelete]
        public IHttpActionResult DeleteBranch(int employeeid)
        {
            return Ok(_employeebl.DeleteEmployee(employeeid));
        }

    }
}
