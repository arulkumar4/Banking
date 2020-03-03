using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.DataAccess.Contracts.ITransaction;
using Banking.Business.Models;
using Banking.Business.Models.TransactionModels;
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

        public int InsertTransactionType(TransactionType transactionType)
        {
            
           
            var res = GetValue<int>(ProcedureNames.Transaction.InsertTransactionType, new SqlParameter("@TType", transactionType.Type));
           
            return res;
        }

        public int UpdateTransactionType(TransactionType[] transactionType)
        {
           

            int res = GetValue<int>(ProcedureNames.Transaction.UpdateTransactionType, new SqlParameter("@oldType", transactionType[0].Type), new SqlParameter("@newType", transactionType[1].Type));
           
            return res;
        }
    }
}
