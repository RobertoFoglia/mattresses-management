using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mattresses_management_dektop_app.Core.Models.entities
{
    [Table(TableName)]
    public class Mattress
    {
        public const string TableName = "Mattresses";
        public const string NameOfName = "Name";

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        [Unique]
        public string Name { get; set; }
        [Ignore]
        public List<Product> Products { get; set; }
        [Ignore]
        public List<Attribute> Attributes { get; set; }
        public decimal Price { get; set; }
        [Ignore]
        public String FormattedPrice { 
            get { return String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", Price); } 
        }
    }
}
