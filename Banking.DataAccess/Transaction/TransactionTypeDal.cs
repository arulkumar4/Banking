using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.DataAccess.Contracts.ITransaction;
using Banking.Business.Models;
using Banking.Business.Models.Transaction;
using System.Data;
using System.Data.SqlClient;

namespace Banking.DataAccess.Transaction
{
    public class TransactionTypeDal : BaseDal, ITransactionTypeDal
    {
        public List<TransactionType> GetTransactionTypes()
        {
            List<TransactionType> transactionTypes = new List<TransactionType>();
            using (var dataset = GetDataset(ProcedureNames.Transaction.GetTransactionTypes))
            {
                var typetable = dataset.Tables[0];
                var typetableDetail = typetable.AsEnumerable();

                foreach (var typeRow in typetableDetail)
                {
                    transactionTypes.Add(PopulateData<TransactionType>(typeRow));
                }
            }
            return transactionTypes;
         
        }

        public bool InsertTransactionType(TransactionType transactionType)
        {
            bool result = false;
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Type",transactionType.Type);
            int res = GetResult(ProcedureNames.Transaction.InsertTransactionType, p);
            if (res > 0)
            {
                result = true;
            }
            return result;
        }

        public bool UpdateTransactionType(TransactionType transactionType, TransactionType transactiontype)
        {
            bool result = false;
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@Type", transactionType.Type);
            p[1] = new SqlParameter("@Type", transactiontype.Type);
            int res = GetResult(ProcedureNames.Transaction.UpdateTransactionType, p);
            if (res > 0)
            {
                result = true;
            }
            return result;
        }
    }
}
