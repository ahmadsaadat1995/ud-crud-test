namespace CRM.Domain.Customers
{
    // CRM.Domain/Customers/PhoneNumber.cs
    public record PhoneNumber
    {
        public string Value { get; }

        private PhoneNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 8)
                throw new ArgumentException("شماره تلفن نامعتبر است", nameof(value));

            Value = value;
        }

        public static PhoneNumber Create(string value) => new PhoneNumber(value);
    }



}

