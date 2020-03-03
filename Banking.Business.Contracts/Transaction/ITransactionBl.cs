using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Business.Models.TransactionModels;

namespace Banking.Business.Contracts.Transaction
{
    public interface ITransactionBl
    {
        List<MTransaction> DebitTransaction(MTransaction transaction);
        List<MTransaction> GetAllTransactions(string AccountId);
    }
}
