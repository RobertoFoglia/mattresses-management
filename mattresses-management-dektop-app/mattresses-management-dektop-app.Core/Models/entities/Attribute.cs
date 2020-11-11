using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

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

        public Double Price { get; set; }
        public Double Percentage { get; set; }
        public Boolean Default { get; set; }

        [Ignore]
        public Boolean IsCalculated { get; set; }
    }
}
