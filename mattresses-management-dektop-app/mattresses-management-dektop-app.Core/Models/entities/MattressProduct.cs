using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mattresses_management_dektop_app.Core.Models.entities
{
    [Table("Mattress_Products")]
    public class MattressProduct
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        [Indexed]
        public int IdMattress { get; set; }
        [NotNull]
        public int IdProduct { get; set; }
        public int Number { get; set; }
        public Double Unitary_Price { get; set; }

        [Ignore]
        public Mattress Mattress { get; set; }
        [Ignore]
        public Product Product { get; set; }
    }
}
