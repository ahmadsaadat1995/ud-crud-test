
// CRM.Domain/Customers/NationalCode.cs
public record NationalCode
{
    public string Value { get; }

    private NationalCode(string value)
    {
        // اعتبارسنجی داخلی
        if (string.IsNullOrWhiteSpace(value) || value.Length != 10)
            throw new ArgumentException("کد ملی نامعتبر است", nameof(value));

        Value = value;
    }

    public static NationalCode Create(string value) => new NationalCode(value);
}

