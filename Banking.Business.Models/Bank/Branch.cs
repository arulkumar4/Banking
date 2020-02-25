using System.Collections.Generic;

namespace Banking.Business.Models.Bank
{
    public class Branch
    {
        public Branch() { }
        public Branch(int branchId) => BranchId = branchId;
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string ContactNumber { get; set; }
        public List<Address> AddressList { get; set; }
    }
}
