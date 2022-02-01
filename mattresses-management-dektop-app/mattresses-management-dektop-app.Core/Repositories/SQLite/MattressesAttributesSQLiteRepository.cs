using mattresses_management_dektop_app.Core.Models.entities;
using mattresses_management_dektop_app.Core.Repositories.Api;
using SQLite;
using System.Collections.Generic;
using Attribute = mattresses_management_dektop_app.Core.Models.entities.Attribute;

namespace mattresses_management_dektop_app.Core.Repositories.SQLite
{
    public class MattressesAttributesSQLiteRepository : AbstractSQLiteRepository<MattressAttribute, int>, IMattressAttributesRepository
    {
        public MattressesAttributesSQLiteRepository(SQLiteConnection connectionPool) : base(connectionPool)
        {
        }

        public List<MattressAttribute> FindByMattress(Mattress mattress)
        {
            return this.connectionPool
                .Query<MattressAttribute>(
                    "SELECT * FROM " + MattressAttribute.TableName +
                " WHERE " + MattressAttribute.MattressKey + " = ?",
                    mattress.Id
                );
        }

        public List<Attribute> GetTheAttributesOfTheMattresses(Mattress mattress)
        {
            return this.connectionPool.Query<Attribute>(
                "SELECT * FROM " + Attribute.TableName +
                " WHERE " + Attribute.KeyName + " IN (" +
                "                   SELECT " + MattressAttribute.AttributeKey + " FROM " + MattressAttribute.TableName +
                                    " WHERE " + MattressAttribute.MattressKey + "= ?" +
                                     ")",
                mattress.Id
            );
        }
    }
}