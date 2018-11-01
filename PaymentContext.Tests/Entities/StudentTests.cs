using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Student _student;
        private readonly Subscription _subscription;
        private readonly Email _email;

        public StudentTests()
        {
            _name = new Name("wellington", "fernandes");
            _document = new Document("09319308632", EDocumentType.CPF);
            _email = new Email("wellington@gmail.com");
            _address = new Address("Rua teste", "10", "nei", "state", "Coun", "9393");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
        }

        [TestMethod]
        public void ReturnErrorWhenHadActiveSubscription()
        {
            PayPalPayment payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 20, _address, _document, "payer", _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);
           
           Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ReturnErrorWhenSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_subscription);
           
            Assert.IsTrue(_student.Invalid);
        }


        [TestMethod]
        public void ReturnSuccessWhenAddSubscription()
        {
           PayPalPayment payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 20, _address, _document, "payer", _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
           
           Assert.IsTrue(_student.Valid);
        }
    }
}