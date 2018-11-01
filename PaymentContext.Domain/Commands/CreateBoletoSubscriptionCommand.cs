using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CreateBoletoSubscriptionCommand : Notifiable, ICommand
    {
        public string FirstName {get;  set;}
        public string LastName {get; set;}
        public string Document {get;set;}
        public string Email {get;set;}
        public string DocumentNumber {get;  set;}
        public EDocumentType DocumentType {get;  set;}        
        public string BarCode {get;set;}
        public string BoletoNumber {get;set; }
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

        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()
            .HasMinLen(this.FirstName, 3, "Name.FirstName", "Nome de conter pelo menos 3 caracteres.")
            .HasMinLen(this.LastName, 3, "Name.LastName", "Sobrenome deve conter pelo menos 3 caracteres.")
            .HasMaxLen(this.FirstName, 40, "Name.FirstName", "Nome deve conter até 40 caracteres."));
        }
    }
}