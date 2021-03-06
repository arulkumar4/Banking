﻿using System;
using System.Web.Http;
using Banking.Business.Contracts.Transaction;
using Banking.Business.Models.TransactionModels;

namespace Banking.WebApi.Controllers.Transaction
{
    [RoutePrefix("Payment")]
    public class PaymentController : ApiController
    {
        private readonly IpaymentBl _paymentBl;
        public PaymentController() { }
        public PaymentController(IpaymentBl paymentBl) => _paymentBl = paymentBl;

        [Route("DoPayment")]
        [HttpGet]
        public IHttpActionResult GetTransactionTypes(Payment payment )
                    => Ok(_paymentBl.DoPayment(payment));

        [Route("GetAllPayments")]
        [HttpGet]
        public IHttpActionResult GetAllPayments(String accountId)
                    => Ok(_paymentBl.GetAllPayments(accountId));

    }
}