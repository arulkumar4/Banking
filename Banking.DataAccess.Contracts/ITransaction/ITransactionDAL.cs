﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Business.Models.TransactionModels;

namespace Banking.DataAccess.Contracts.ITransaction
{
   public interface ITransactionDAL
    {
        MTransaction DebitTransaction(MTransaction transaction);
        List<MTransaction> GetAllTransactions(string AccountId);
        List<MTransaction> GetAllAccountTransfers(string AccountId);
    }
}
