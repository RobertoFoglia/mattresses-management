﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mattresses_management_dektop_app.Core.Models.entities
{
    [Table("Products")]
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull][Unique]
        public string Name { get; set; }
        public String Description { get; set; }
        public Double Price { get; set; }
        [NotNull]
        public String Measure_Unit { get; set; }
    }
}
