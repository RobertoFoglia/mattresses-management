using SQLite;
using System;

namespace mattresses_management_dektop_app.Core.Models.entities
{
    [Table(Product.TableName)]
    public class Product
    {
        public const string TableName = "Products";
        public const string KeyName = "Id";
        public const string NameOfName = "Name";
        public const string DescriptionName = "Description";

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        [Unique]
        public string Name { get; set; }
        public String Description { get; set; }
        public decimal Price { get; set; }
        [NotNull]
        public String MeasureUnit { get; set; }

        [Ignore]
        public decimal Number { get; set; }
        [Ignore]
        public decimal TotalPrice
        {
            get { return Price * Number; }
        }
    }
}
