using Flunt.Validations;

namespace PaymentContext.Domain.ValueObjects
{
    public sealed class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(this.FirstName, 3, "Name.FirstName", "Nome de conter pelo menos 3 caracteres.")
                .HasMinLen(this.LastName, 3, "Name.LastName", "Sobrenome deve conter pelo menos 3 caracteres.")
                .HasMaxLen(this.FirstName, 40, "Name.FirstName", "Nome deve conter até 40 caracteres.")
            );
        }

        public string FirstName {get; private set;}
        public string LastName {get;private set;}
    }
}