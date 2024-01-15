namespace Domain.Users;

public sealed record Email
{
    public string Value { get; init; }
    public Email(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException("Email alanı boş olamaz");
        if (value.Length < 3)
            throw new ArgumentException("Email alanı 3 karakterden küçük olamaz");
        if (!value.Contains("@"))
            throw new ArgumentException("Geçerli bir mail adresi giriniz");

        Value = value;
    }
}
