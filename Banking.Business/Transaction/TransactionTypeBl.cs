using Banking.Business.Contracts.Transaction;
using Banking.Business.Models.Transaction;
using Banking.DataAccess.Contracts.ITransaction;
using System.Collections.Generic;

namespace Banking.Business.Transaction
{
    public class TransactionTypeBl : ITransactionTypeBl
    {
        public readonly ITransactionTypeDal _transactionTypeDal;
        public TransactionTypeBl(ITransactionTypeDal transactionTypeDal) => _transactionTypeDal = transactionTypeDal;

        public List<TransactionType> GetTransactionTypes()
        {
            return _transactionTypeDal.GetTransactionTypes();
        }

        public bool InsertTransactionType(TransactionType transactionType)
        {
           return _transactionTypeDal.InsertTransactionType(transactionType);
        }

        public bool UpdateTransactionType(TransactionType transactionType, TransactionType transactiontype)
        {
            return _transactionTypeDal.UpdateTransactionType(transactionType , transactiontype);
        }
    }
}
