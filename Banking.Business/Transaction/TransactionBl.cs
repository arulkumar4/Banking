using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Business.Contracts.Transaction;
using Banking.Business.Models.Transaction;
using Banking.DataAccess.Contracts.ITransaction;


namespace Banking.Business.Transaction
{
    public class TransactionBl : ITransactionBl
    {
        public readonly ITransactionDAL _transactionDal;
        public TransactionBl(ITransactionDAL transactionDal) => _transactionDal = transactionDal;
        public List<TransactionClass> DebitTransaction(TransactionClass transaction)
        {
            return _transactionDal.DebitTransaction(transaction);
        }

        public List<TransactionClass> GetAllTransactions(string AccountId)
        {
            return _transactionDal.GetAllTransactions(AccountId);
        }
    }
}
