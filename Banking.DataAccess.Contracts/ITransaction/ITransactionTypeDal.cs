﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Business.Models.Transaction;

namespace Banking.DataAccess.Contracts.ITransaction
{
    public interface ITransactionTypeDal
    {
        List<TransactionType> GetTransactionTypes();
        bool InsertTransactionType(TransactionType transactionType);
        bool UpdateTransactionType(TransactionType transactionType, TransactionType transactiontype);
        
    }
}