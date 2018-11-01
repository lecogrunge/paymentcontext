using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public sealed class PayPalPayment : Payment
    {
        public PayPalPayment(string transactionCode, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, Address address, Document document, string payer, Email email)
                            :  base(paidDate, expireDate, total, totalPaid, address, document, payer, email)
        {
            this.TransactionCode = transactionCode;
        }

        public string TransactionCode {  get;private set;}
    }
}