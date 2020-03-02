using Banking.Business.Models.Bank;
using System.Collections.Generic;

namespace Banking.DataAccess.Contracts
{
    public interface IBranchDal
    {
        int AddBranch(Branch branch);
        List<Branch> GetBranch();
        List<Branch> GetBranchById(int branchid);
        int UpdateBranchById(Branch branch);
        int DeleteBranchById(int branchid);
    }
}
