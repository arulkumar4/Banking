﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Business.Models.TransactionModels;

namespace Banking.DataAccess.Contracts.ITransaction
{
   public interface IpaymentDAL
    {
        List<Payment> DoPayment(Payment payment);
        List<Payment> GetAllPayments(string accountId);

    }
}
