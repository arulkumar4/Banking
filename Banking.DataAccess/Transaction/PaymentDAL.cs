using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Business.Models.TransactionModels;
using Banking.DataAccess.Contracts.ITransaction;
using System.Data;
using System.Data.SqlClient;

namespace Banking.DataAccess.Transaction
{
    public class PaymentDAL : BaseDal,IpaymentDAL
    {
        public List<Payment> DoPayment(Payment payment)
        {
            List<Payment> _payment = new List<Payment>();

            var dataset = GetDataset(ProcedureNames.Transaction.DoPayment,  
                                          new SqlParameter("@TransferAmmount", payment.TransferAmount),
                                          new SqlParameter("@SenderName", payment.SenderName),
                                          new SqlParameter("@ReciverName", payment.ReciverName),
                                          new SqlParameter("@AccountId", payment.AccountId),
                                          new SqlParameter("@Type", payment.Type));

            using (dataset)
            {
                var Paymenttable = dataset.Tables[0];
                var PaymenttableDetail = Paymenttable.AsEnumerable();

                foreach (var typeRow in PaymenttableDetail)
                {
                    _payment.Add(PopulateData<Payment>(typeRow));
                }
            }
            return _payment;
        }

        public List<Payment> GetAllPayments(string accountId)
        {
            List<Payment> payments = new List<Payment>();


            using (var dataset = GetDataset(ProcedureNames.Transaction.GetAllPayments,
                                                    new SqlParameter("@AccountId", accountId)))
            {
                var PaymentTable = dataset.Tables[0];
                var PaymenttableDetail = PaymentTable.AsEnumerable();

                foreach (var typeRow in PaymenttableDetail)
                {
                    payments.Add(PopulateData<Payment>(typeRow));
                }
            }
            return payments;
        }
    }
}
