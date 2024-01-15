namespace Domain.Shared;

public sealed record Currency
{
    internal static readonly Currency None = new("");

    public static readonly Currency Usd = new("USD");
    public static readonly Currency Try = new("TRY");
    public string CurrencyCode { get; init; }
    private Currency(string currencyCode)
        => CurrencyCode = currencyCode;

    public static Currency FromCode(string currencyCode)
        => All.FirstOrDefault(x => x.CurrencyCode == currencyCode) ??
            throw new ArgumentException("Geçerli bir para birimi girin");

    public static readonly IReadOnlyCollection<Currency> All = new[] { Usd, Try };
}
