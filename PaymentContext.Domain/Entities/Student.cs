using System.Collections.Generic;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public sealed class Student : Entity
    {
        public Name Name {get; private set;}
        public Document Document {get; private set;}
        public Email Email {get; private set;}
        public Address Address {get; private set;}

        private List<Subscription> _listSubscriptions;
        public IReadOnlyCollection<Subscription> ListSubscription { get {return _listSubscriptions.ToArray(); } }

        public Student(Name name, Document document, Email email)
        {
            this.Name = name;
            this.Document = document;
            this.Email = email;
            _listSubscriptions = new List<Subscription>();

            AddNotifications(this.Name, this.Document, this.Email);
        }

        public void AddSubscription(Subscription subscription)
        {
            bool hasSubscriptionActive = false;
            
            foreach(var sub in _listSubscriptions){
                if(sub.Active)
                    hasSubscriptionActive = true;
            }

            AddNotifications(new Contract()
                .Requires()
                .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "Você já tem uma inscrição")
                .AreEquals(0, subscription.ListPayment.Count, "student.Subscription.Payment", "Esta assinatura não possui pagamentos")
            );
            // Alternativa
            // if(hasSubscriptionActive)
            //     AddNotification("Student.Subscriptions", "Você já tem uma assinatura");
            
            // Cancelar todas as outras assinaturas e manter apenas esta como principal
            // foreach(var sub in this.ListSubscription)
            //     sub.Inactivate();

            // _listSubscription.Add(subscription);
        }        
    }
}