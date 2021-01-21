using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace mattresses_management_dektop_app.Core.Utils
{
    public class PriceUtils
    {
        private static CultureInfo culture = CultureInfo.CreateSpecificCulture("it-IT");

        public static string FormatPrice(double price)
        {
            return price.ToString("C", culture);
        }

        public static Double ParsePrice(string price) {
            if (!Double.TryParse(price.Replace("€", "").Replace(" ", ""), out double convertedPrice))
                convertedPrice = 0;
            return convertedPrice;
        }
    }
}
