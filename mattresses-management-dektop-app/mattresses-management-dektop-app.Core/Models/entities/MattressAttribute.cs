using SQLite;

namespace mattresses_management_dektop_app.Core.Models.entities
{
    [Table(MattressAttribute.TableName)]
    public class MattressAttribute
    {
        public const string TableName = "Mattress_Attributes";
        public const string KeyName = "Id";
        public const string MattressKey = "IdMattress";
        public const string AttributeKey = "IdAttribute";

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        [Indexed]
        public int IdMattress { get; set; }
        [NotNull]
        public int IdAttribute { get; set; }

        public decimal Price { get; set; }
        public decimal Percentage { get; set; }

        [Ignore]
        public Mattress Mattress { get; set; }
        [Ignore]
        public Attribute Attribute { get; set; }
    }
}
