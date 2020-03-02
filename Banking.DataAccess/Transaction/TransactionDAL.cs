using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Business.Models.Transaction;
using Banking.DataAccess.Contracts.ITransaction;
using System.Data;
using System.Data.SqlClient;


namespace Banking.DataAccess.Transaction
{
    public class TransactionDAL : BaseDal, ITransactionDAL
    {
        public List<TransactionClass> DebitTransaction(TransactionClass transaction)
        {
            List<TransactionClass> transactionClass = new List<TransactionClass>();
            var dataset = GetDataset(ProcedureNames.Transaction.DebitTransaction, new SqlParameter("@TransferAmmount", transaction.TransferAmount)
                                        , new SqlParameter("@SenderName", transaction.SenderName), 
                                        new SqlParameter("@ReciverName", transaction.ReceiverName),
                                         new SqlParameter("@AccountId", transaction.AccountId),
                                          new SqlParameter("@TransactionTypeId", transaction.TransactionTypeId));

            using (dataset)
            {
                var transactiontable = dataset.Tables[0];
                var transactiontableDetail = transactiontable.AsEnumerable();

                foreach (var typeRow in transactiontableDetail)
                {
                    transactionClass.Add(PopulateData<TransactionClass>(typeRow));
                }
            }
            return transactionClass;
        }

        public List<TransactionClass> GetAllTransactions(string AccountId)
        {
            List<TransactionClass> transactionClass = new List<TransactionClass>();
           

            using (var dataset = GetDataset(ProcedureNames.Transaction.GetAllTransactions, new SqlParameter("@AccountId",AccountId)))
            {
                var transactiontable = dataset.Tables[0];
                var transactiontableDetail = transactiontable.AsEnumerable();

                foreach (var typeRow in transactiontableDetail)
                {
                    transactionClass.Add(PopulateData<TransactionClass>(typeRow));
                }
            }
            return transactionClass;
        }
    }
}
