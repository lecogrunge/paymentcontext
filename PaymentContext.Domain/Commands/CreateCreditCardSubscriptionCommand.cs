using System;
using PaymentContext.Domain.Enums;

namespace PaymentContext.Domain.Commands
{
    public class CreateCreditCardSubscriptionCommand
    {
        public string FirstName {get;  set;}
        public string LastName {get; set;}
        public string Document {get;set;}
        public string Email {get;set;}
        public string DocumentNumber {get;  set;}
        public EDocumentType DocumentType {get;  set;}        
        public string CardHolderName {get; set;}
        public string CardLastNumbers {get; set;}
        public string LastTranscationNumber {get; set;}
        public string PaymentNumber {get; set;}
        public DateTime PaidDate {get;  set;}
        public DateTime ExpireDate {get; set;}
        public decimal Total {get; set;}
        public decimal TotalPaid {get; set;}
        public string Payer {get; set;}
        public string Street { get;  set; }
        public string AddressNumber {get;  set;}
        public string Neighborhood {get;  set;}
        public string State {get;  set;}
        public string Country {get;  set;}
        public string ZipCode {get;  set;}
    }
}