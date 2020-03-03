using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Business.Models.TransactionModels;
using Banking.DataAccess.Contracts.ITransaction;
using System.Data;
using System.Data.SqlClient;


namespace Banking.DataAccess.Transaction
{
    public class TransactionDAL : BaseDal, ITransactionDAL
    {
        public List<MTransaction> DebitTransaction(MTransaction transaction)
        {
            List<MTransaction> _transaction = new List<MTransaction>();
            var dataset = GetDataset(ProcedureNames.Transaction.DebitTransaction, 
                                        new SqlParameter("@TransferAmmount", transaction.TransferAmount),
                                        new SqlParameter("@SenderName", transaction.SenderName), 
                                        new SqlParameter("@ReciverName", transaction.ReceiverName),
                                        new SqlParameter("@AccountId", transaction.AccountId),
                                        new SqlParameter("@TransactionTypeId", transaction.TransactionTypeId),
                                        new SqlParameter("@ReciverAccountId", transaction.ReciverAccountId));

            using (dataset)
            {
                var transactiontable = dataset.Tables[0];
                var transactiontableDetail = transactiontable.AsEnumerable();

                foreach (var typeRow in transactiontableDetail)
                {
                    _transaction.Add(PopulateData<MTransaction>(typeRow));
                }
            }
            return _transaction;
        }

        public List<MTransaction> GetAllAccountTransfers(string AccountId)
        {
            List<MTransaction> _transaction = new List<MTransaction>();


            using (var dataset = GetDataset(ProcedureNames.Transaction.GetAllAccountTransfers, 
                                                        new SqlParameter("@AccountId", AccountId)))
            {
                var transactiontable = dataset.Tables[0];
                var transactiontableDetail = transactiontable.AsEnumerable();

                foreach (var typeRow in transactiontableDetail)
                {
                    _transaction.Add(PopulateData<MTransaction>(typeRow));
                }
            }
            return _transaction;
        }

        public List<MTransaction> GetAllTransactions(string AccountId)
        {
            List<MTransaction> _transaction = new List<MTransaction>();
           

            using (var dataset = GetDataset(ProcedureNames.Transaction.GetAllTransactions, new SqlParameter("@AccountId",AccountId)))
            {
                var transactiontable = dataset.Tables[0];
                var transactiontableDetail = transactiontable.AsEnumerable();

                foreach (var typeRow in transactiontableDetail)
                {
                    _transaction.Add(PopulateData<MTransaction>(typeRow));
                }
            }
            return _transaction;
        }
    }
}
