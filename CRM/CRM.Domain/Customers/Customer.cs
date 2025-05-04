using CRM.Domain.Common;
using CRM.Domain.Customers.Events;
using CRM.Domain.Interface;

namespace CRM.Domain.Customers
{
    // CRM.Domain/Customers/Customer.cs
    public class Customer : BaseEntity<Guid>, IAggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public NationalCode NationalCode { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Email Email { get; private set; }
        public bool IsDeleted { get; private set; }


        private Customer() { } // for EF

        public Customer(string firstName, string lastName, Email email, PhoneNumber phoneNumber)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;

            AddDomainEvent(new CustomerCreatedEvent(this));
        }

        public void UpdateName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            UpdatedAt = DateTime.UtcNow;
        }

        public static Customer Create(string firstName, string lastName, string nationalCode, string phoneNumber, string email)
        {
            return new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                NationalCode = NationalCode.Create(nationalCode),
                PhoneNumber = PhoneNumber.Create(phoneNumber),
                Email = Email.Create(email),
                CreatedAt = DateTime.UtcNow
            };
        }

        public void Update(string firstName, string lastName, string nationalCode, string phoneNumber, string email)
        {
            if (!string.IsNullOrEmpty(firstName))
                FirstName = firstName;

            if (!string.IsNullOrEmpty(lastName))
                LastName = lastName;

            if (!string.IsNullOrEmpty(nationalCode))
                NationalCode = NationalCode.Create(nationalCode);

            if (!string.IsNullOrEmpty(phoneNumber))
                PhoneNumber = PhoneNumber.Create(phoneNumber);
            if (!string.IsNullOrEmpty(email))
                Email = Email.Create(email);

            UpdatedAt = DateTime.UtcNow;

            AddDomainEvent(new CustomerCreatedEvent(this));
        }

        public void Delete()
        {
            IsDeleted = true;
            UpdatedAt = DateTime.UtcNow;
            AddDomainEvent(new CustomerDeletedEvent(this)); // در صورت نیاز
        }

        public void Restore()
        {
            IsDeleted = false;
            UpdatedAt = DateTime.UtcNow;
            AddDomainEvent(new CustomerRestoredEvent(this)); // در صورت نیاز
        }

    }

}

