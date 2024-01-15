namespace Domain.Shared;

public sealed record Money(decimal Amount, Currency Currency)
{
    public static Money operator +(Money m1, Money m2)
        => m1.Currency == m2.Currency
            ? new(m1.Amount + m2.Amount, m1.Currency)
                : throw new ArgumentException("Para birimleri birbirinden farklı değerlerle işlem yapılamaz!");

    public static Money Zero() => new(0, Currency.None);
    public static Money Zero(Currency currency) => new(0, currency);
    public bool IsZero() => this == Zero(Currency);
}