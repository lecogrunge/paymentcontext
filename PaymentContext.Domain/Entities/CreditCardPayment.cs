using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public sealed class CreditCardPayment : Payment
    {
        public CreditCardPayment(string cardHolderName, string cardLastNumbers, string lastTranscationNumber, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, Address address, Document document, string payer, Email email)
                                : base(paidDate, expireDate, total, totalPaid, address, document, payer, email)
        {
            this.CardHolderName = cardHolderName;
            this.CardLastNumbers = cardLastNumbers;
            this.LastTranscationNumber = lastTranscationNumber;
        }

        public string CardHolderName {get;private set;}
        public string CardLastNumbers {get;private set;}
        public string LastTranscationNumber {get;private set;}
    }
}