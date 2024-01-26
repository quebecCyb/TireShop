
using TireShop.Schemas.Enums;

namespace TireShop.Utils
{
    public static class GetEnum
    {
        public static Currencies Currency(string cur)
        {
            return cur.ToUpper() switch
            {
                "USD" => Currencies.USD,
                "UAH" => Currencies.UAH,
                "RUB" => Currencies.RUB,
                "GBP" => Currencies.GBP,
                "EUR" => Currencies.EUR,
                _ => Currencies.USD,
            };
        }

        public static CountryCode Country(string country)
        {
            return country.ToUpper() switch
            {
                "US" => CountryCode.US,
                "CA" => CountryCode.CA,
                "DE" => CountryCode.DE,
                "UA" => CountryCode.UA,
                _ => CountryCode.UNKNOWN,
            };
        }
    }
}
