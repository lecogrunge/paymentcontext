using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handler;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new MockStudentRepository(), new MockEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "Bruce";
            command.LastName = "Wayne";
            command.Document = "99999999999";
            command.Email = "hello@gmail.com";
            command.DocumentNumber = "123456789";
            command.DocumentType = EDocumentType.CPF;   
            command.BarCode = "111001";
            command.BoletoNumber = "454654";
            command.PaymentNumber = "455465";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "Wayner Corp";
            command.Street = "stre";
            command.AddressNumber = "15";
            command.Neighborhood = "neig";
            command.State = "mg";
            command.Country = "br";
            command.ZipCode = "00050555";

            handler.Handler(command);
            Assert.AreEqual(false, handler.Valid);
        }
    }
}