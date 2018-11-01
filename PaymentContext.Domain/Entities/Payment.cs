using System;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment : Entity
    {
        protected Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, Address address, Document document, string payer, Email email)
        {
            this.Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            this.PaidDate = paidDate;
            this.ExpireDate = expireDate;
            this.Total = total;
            this.TotalPaid = totalPaid;
            this.Address = address;
            this.Document = document;
            this.Payer = payer;
            this.Email = email;

            AddNotifications(new Contract()
                .Requires()
                .IsLowerOrEqualsThan(0, Total, "Payment.Total", "O total não pode ser zero")
                .IsGreaterOrEqualsThan(Total, totalPaid, "Payment.TotalPaid", "")
            );
        }

        public string Number {get;private set;}
        public DateTime PaidDate {get; private set;}
        public DateTime ExpireDate {get;private set;}
        public decimal Total {get;private set;}
        public decimal TotalPaid {get;private set;}
        public Address Address {get;private set;}
        public Document Document {get;private set;}
        public string Payer {get;private set;}
        public Email Email {get;private set;}
    }
}