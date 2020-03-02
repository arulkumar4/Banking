using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Business.Models.Transaction;
using Banking.DataAccess.Contracts.ITransaction;
using System.Data;
using System.Data.SqlClient;

namespace Banking.DataAccess.Transaction
{
    public class PaymentDAL : BaseDal,IpaymentDAL
    {
        public List<PaymentClass> DoPayment(PaymentClass payment)
        {
            List<PaymentClass> paymentClass = new List<PaymentClass>();

            var dataset = GetDataset(ProcedureNames.Transaction.DoPayment, new SqlParameter("@TransferAmmount", payment.TransferAmount)
                                        , new SqlParameter("@SenderName", payment.SenderName),
                                        new SqlParameter("@ReciverName", payment.ReciverName),
                                         new SqlParameter("@AccountId", payment.AccountId),
                                          new SqlParameter("@Type", payment.Type));

            using (dataset)
            {
                var Paymenttable = dataset.Tables[0];
                var PaymenttableDetail = Paymenttable.AsEnumerable();

                foreach (var typeRow in PaymenttableDetail)
                {
                    paymentClass.Add(PopulateData<PaymentClass>(typeRow));
                }
            }
            return paymentClass;
        }
    }
}
