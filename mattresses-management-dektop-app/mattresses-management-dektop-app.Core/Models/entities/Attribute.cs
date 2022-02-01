using mattresses_management_dektop_app.Core.Utils;
using SQLite;
using System;

namespace mattresses_management_dektop_app.Core.Models.entities
{
    [Table(Attribute.TableName)]
    public class Attribute
    {
        public const string TableName = "Attributes";
        public const string KeyName = "Id";

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        [Unique]
        public string Name { get; set; }

        [NotNull]
        [Unique]
        public string Code { get; set; }

        public decimal Price { get; set; }

        public string PriceInEuro
        {
            get => PriceUtils.FormatPrice(this.Price);
        }

        public decimal Percentage { get; set; }
        public Boolean Default { get; set; }

        [Ignore]
        public Boolean IsCalculated { get; set; }

        [Ignore]
        public bool IsReadOnly { get; set; } = true;
    }
}