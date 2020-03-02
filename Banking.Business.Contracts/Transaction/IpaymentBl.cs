using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Business.Models.Transaction;

namespace Banking.Business.Contracts.Transaction
{
    public interface IpaymentBl
    {
        List<PaymentClass> DoPayment(PaymentClass payment);
    }
}
