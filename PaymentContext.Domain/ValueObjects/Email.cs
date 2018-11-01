using Flunt.Validations;

namespace PaymentContext.Domain.ValueObjects
{
    public sealed class Email : ValueObject
    {
        public Email(string address)
        {
            this.Address = address;

            AddNotifications(new Contract()
                .Requires()
                .IsEmail(this.Address, "Email.Address", "E-mail inválido")
            );
        }

        public string Address {get; private set;}
    }
}