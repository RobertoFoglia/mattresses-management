using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mattresses_management_dektop_app.Core.Models.entities
{
    [Table("Mattresses")]
    public class Mattress
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        [Unique]
        public string Name { get; set; }
        [Ignore]
        public List<Product> products { get; set; }
        public Double Price { get; set; }
    }
}
