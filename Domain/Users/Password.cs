namespace Domain.Users;

public sealed record Password
{
    public string Value { get; init; }
    public Password(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException("Password alanı boş olamaz");
        if (value.Length < 3)
            throw new ArgumentException("Email alanı 6 karakterden küçük olamaz");

        Value = value;
    }
}
