using Banking.Business.Models.Bank;
using Banking.DataAccess.Contracts;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Banking.DataAccess
{
    public class BranchDal : BaseDal, IBranchDal
    {
        public int AddBranch(Branch branch)
        {
            var branchId = GetValue<int>(ProcedureNames.Branch.AddBranch,
                new SqlParameter("name", branch.Name),
                new SqlParameter("contactnumber", branch.ContactNumber),
                new SqlParameter("cityid", branch.CityId),
                new SqlParameter("Address", branch.Address)
                );
            return branchId;
        }

        public int DeleteBranchById(int branchid)
        {
            var status = GetValue<int>(ProcedureNames.Branch.DeleteBranch,
               new SqlParameter("id", branchid)
               );
            return status;
        }

        public List<Branch> GetBranch()
        {
            List<Branch> Branches = new List<Branch>();
            using (var dataset = GetDataset(ProcedureNames.Branch.GetBranch))
            {
                var branchtable = dataset.Tables[0];
                var branchtableDetail = branchtable.AsEnumerable();

                foreach (var branchRow in branchtableDetail)
                {
                    Branches.Add(PopulateData<Branch>(branchRow));
                }
            }
            return Branches;

        }
        public List<Branch> GetBranchById(int branchid)
        {
            List<Branch> Branches = new List<Branch>();
            using (var dataset = GetDataset(ProcedureNames.Branch.GetBranchbyid,branchid))
            {
                var branchtable = dataset.Tables[0];
                var branchtableDetail = branchtable.AsEnumerable();

                foreach (var branchRow in branchtableDetail)
                {
                    Branches.Add(PopulateData<Branch>(branchRow));
                }
            }
            return Branches;
        }

        public int UpdateBranchById(Branch branch)
        {
            var status = GetValue<int>(ProcedureNames.Branch.UpdateBranch,
                new SqlParameter("Id", branch.Id),
                new SqlParameter("name", branch.Name),
                new SqlParameter("contactnumber", branch.ContactNumber),
                new SqlParameter("cityid", branch.CityId),
                new SqlParameter("Address", branch.Address)
                );
            return status;
        }
    }
}
