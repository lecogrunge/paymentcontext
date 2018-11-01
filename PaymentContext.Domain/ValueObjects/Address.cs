using Flunt.Validations;

namespace PaymentContext.Domain.ValueObjects
{
    public sealed class Address : ValueObject
    {
        public Address(string street, string number, string neighborhood, string state, string country, string zipCode)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            State = state;
            Country = country;
            ZipCode = zipCode;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(this.Street, 3, "Adderss.Street", "Nome da rua deve conter pelo menos 3 caracteres.")
                
            );
        }

        public string Street { get; private set; }
        public string Number {get; private set;}
        public string Neighborhood {get; private set;}
        public string State {get; private set;}
        public string Country {get; private set;}
        public string ZipCode {get; private set;}
    }
}