using Banking.Business.Contracts;
using Banking.Business.Models.Bank;
using Banking.DataAccess.Contracts;
using System.Collections.Generic;

namespace Banking.Business
{
    public class BranchBl : IBranchBl
    {
        private readonly IBranchDal _branchDal;
        public BranchBl(IBranchDal branchDal)
        {
            _branchDal = branchDal;
        }
        public int AddBranch(Branch branch)
        {
            return _branchDal.AddBranch(branch);
        }

        public int DeleteBranchById(int branchid)
        {
            return _branchDal.DeleteBranchById(branchid);
        }

        public List<Branch> GetBranch()
        {
            return _branchDal.GetBranch();
        }

        public List<Branch> GetBranchById(int branchid)
        {
            return _branchDal.GetBranchById(branchid);
        }

        public int UpdateBranchById(Branch branch)
        {
            return _branchDal.UpdateBranchById(branch);
        }
    }
}
