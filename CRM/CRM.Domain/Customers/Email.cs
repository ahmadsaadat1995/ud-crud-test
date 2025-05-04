namespace CRM.Domain.Customers
{
    // CRM.Domain/Customers/Email.cs
    public record Email
    {
        public string Value { get; }

        private Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                throw new ArgumentException("ایمیل نامعتبر است", nameof(value));

            Value = value;
        }

        public static Email Create(string value) => new Email(value);
    }

}

