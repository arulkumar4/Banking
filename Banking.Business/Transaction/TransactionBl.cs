﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Business.Contracts.Transaction;
using Banking.Business.Models.TransactionModels;
using Banking.DataAccess.Contracts.ITransaction;


namespace Banking.Business.Transaction
{
    public class TransactionBl : ITransactionBl
    {
        public readonly ITransactionDAL _transactionDal;
        public TransactionBl(ITransactionDAL transactionDal) => _transactionDal = transactionDal;
        public List<MTransaction> DebitTransaction(MTransaction transaction)
        {
            return _transactionDal.DebitTransaction(transaction);
        }

        public List<MTransaction> GetAllAccountTransfers(string AccountId)
        {
            return _transactionDal.GetAllAccountTransfers(AccountId);
        }

        public List<MTransaction> GetAllTransactions(string AccountId)
        {
            return _transactionDal.GetAllTransactions(AccountId);
        }
    }
}
