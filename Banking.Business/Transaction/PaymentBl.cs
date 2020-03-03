using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Business.Contracts.Transaction;
using Banking.Business.Models.TransactionModels;
using Banking.DataAccess.Contracts.ITransaction;


namespace Banking.Business.Transaction
{
    public class PaymentBl:IpaymentBl
    {
        public readonly IpaymentDAL _paymentDAL;
        public PaymentBl(IpaymentDAL paymentDAL) => _paymentDAL = paymentDAL;

        public List<Payment> DoPayment(Payment payment)
        {
            return _paymentDAL.DoPayment(payment);
        }

        public List<Payment> GetAllPayments(string accountId)
        {
            return _paymentDAL.GetAllPayments(accountId);
        }
    }
}
