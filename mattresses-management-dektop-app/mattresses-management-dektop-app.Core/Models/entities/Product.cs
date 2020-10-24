using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mattresses_management_dektop_app.Core.Models.entities
{
    [Table(Product.TableName)]
    public class Product
    {
        public const string TableName = "Products";
        public const string KeyName = "Id";

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull][Unique]
        public string Name { get; set; }
        public String Description { get; set; }
        public Double Price { get; set; }
        [NotNull]
        public String MeasureUnit { get; set; }
    }
}
