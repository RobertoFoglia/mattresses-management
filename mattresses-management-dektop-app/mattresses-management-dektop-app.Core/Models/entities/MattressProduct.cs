using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mattresses_management_dektop_app.Core.Models.entities
{
    [Table(MattressProduct.TableName)]
    public class MattressProduct
    {
        public const string TableName = "Mattress_Products";
        public const string MattressKey = "IdMattress";
        public const string ProductKey = "IdProduct";

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        [Indexed]
        public int IdMattress { get; set; }
        [NotNull]
        public int IdProduct { get; set; }
        public double Number { get; set; }
        public Double Unitary_Price { get; set; }

        [Ignore]
        public Mattress Mattress { get; set; }
        [Ignore]
        public Product Product { get; set; }
    }
}
