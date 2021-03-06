﻿using Banking.Business.Models.Bank;
using System.Collections.Generic;

namespace Banking.Business.Contracts
{
    public interface IBranchBl
    {
        int AddBranch(Branch branch);
        List<Branch> GetBranch();
        List<Branch> GetBranchById(int branchid);
        int UpdateBranchById(Branch branch);
        int DeleteBranchById(int branchid);
    }
}
