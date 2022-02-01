using System.Globalization;

namespace mattresses_management_dektop_app.Core.Utils
{
    public class PriceUtils
    {
        private static CultureInfo culture = CultureInfo.CreateSpecificCulture("it-IT");

        public static string FormatPrice(decimal price)
        {
            return price.ToString("C", culture);
        }

        public static decimal ParsePrice(string price)
        {
            if (!decimal.TryParse(price.Replace("€", "").Replace(" ", ""), out decimal convertedPrice))
                convertedPrice = 0;
            return convertedPrice;
        }
    }
}