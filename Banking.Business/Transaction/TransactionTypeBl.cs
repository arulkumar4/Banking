using Banking.Business.Contracts.Transaction;
using Banking.Business.Models.TransactionModels;
using Banking.DataAccess.Contracts.ITransaction;
using System.Collections.Generic;

namespace Banking.Business.Transaction
{
    public class TransactionTypeBl : ITransactionTypeBl
    {
        public readonly ITransactionTypeDal _transactionTypeDal;
        public TransactionTypeBl(ITransactionTypeDal transactionTypeDal) => _transactionTypeDal = transactionTypeDal;

        public List<TransactionType> GetTransactionTypes() =>_transactionTypeDal.GetTransactionTypes();
        

        public int InsertTransactionType(TransactionType transactionType) =>                                                        _transactionTypeDal.InsertTransactionType(transactionType);
       
        public int UpdateTransactionType(TransactionType[] transactionType) =>
                               _transactionTypeDal.UpdateTransactionType(transactionType);
       
    }
}
