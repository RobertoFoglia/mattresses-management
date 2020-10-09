using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mattresses_management_dektop_app.Core.Models.entities
{
    [Table("Attributes")]
    public class Attribute
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        [Unique]
        public string Name { get; set; }

        public Double Price { get; set; }
        public Double Percentage { get; set; }
    }
}
