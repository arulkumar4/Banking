using Banking.Business.Contracts;
using Banking.Business.Models.Bank;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Banking.WebApi.Controllers
{
    [EnableCors("http://localhost:4200", "*", "GET,POST,PUT,DELETE")]
    public class BranchController : ApiController
    {
        private readonly IBranchBl _branchbl;
        public BranchController(IBranchBl branchbl)
        {
            _branchbl = branchbl;
        }
        [Route("api/AddBranch")]
        [HttpPost]
        public IHttpActionResult AddBranch([FromBody]Branch branch)
        {
            return Ok(_branchbl.AddBranch(branch));
        }
        [Route("api/GetBranch")]
        [HttpGet]
        public IHttpActionResult GetBranch()
        {
            return Ok(_branchbl.GetBranch());
        }
        [Route("api/GetBranch/{branchid}")]
        [HttpGet]
        public IHttpActionResult GetBranch(int branchid)
        {
            return Ok(_branchbl.GetBranchById(branchid));
        }
        [Route("api/UpdateBranch")]
        [HttpPut]
        public IHttpActionResult UpdateBranch(Branch branch)
        {
            return Ok(_branchbl.UpdateBranchById(branch));
        }
        [Route("api/DeleteBranch/{branchid}")]
        [HttpDelete]
        public IHttpActionResult DeleteBranch(int branchid)
        {
            return Ok(_branchbl.DeleteBranchById(branchid));
        }

    }
}
