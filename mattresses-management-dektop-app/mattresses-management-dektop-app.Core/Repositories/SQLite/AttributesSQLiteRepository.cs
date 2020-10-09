using mattresses_management_dektop_app.Core.Models.entities;
using mattresses_management_dektop_app.Core.Repositories.Api;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Attribute = mattresses_management_dektop_app.Core.Models.entities.Attribute;

namespace mattresses_management_dektop_app.Core.Repositories.SQLite
{
    public class AttributesSQLiteRepository : AbstractSQLiteRepository<Attribute, int>, IAttributesRepository
    {
        public AttributesSQLiteRepository(SQLiteConnection connectionPool) : base(connectionPool)
        {
        }
    }
}
