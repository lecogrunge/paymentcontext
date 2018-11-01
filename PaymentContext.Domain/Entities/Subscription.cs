using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public sealed class Subscription : Entity
    {
        private IList<Payment> _payments;

        public Subscription(DateTime? expireDate)
        {
            this.CreateDate = DateTime.Now;
            this.LastUpdate = DateTime.Now;
            this.ExpireDate = expireDate;
            this.Active = true;

            _payments = new List<Payment>();
        }

        public DateTime CreateDate {get; private set;}
        public DateTime LastUpdate {get; private set;}
        public DateTime? ExpireDate {get; private set;}
        public bool Active {get; private set;}

        public IReadOnlyCollection<Payment> ListPayment {get {return _payments.ToArray();} }

        public void AddPayment(Payment payment)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(DateTime.Now, payment.PaidDate, "Subscription.Payments", "A data")
            );

            if(Valid)
                _payments.Add(payment);
        }

        public void Activate()
        {
            Active = true;
            LastUpdate = DateTime.Now;
        }

        public void Inactivate()
        {
            Active = false;
            LastUpdate = DateTime.Now;
        }
    }
}