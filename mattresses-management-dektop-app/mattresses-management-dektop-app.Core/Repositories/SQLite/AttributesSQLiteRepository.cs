using mattresses_management_dektop_app.Core.Exceptions;
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
        public AttributesSQLiteRepository(SQLiteConnection connectionPool) : base(connectionPool) { }

        public override CreateTableResult InitTable()
        {
            var result = base.InitTable();
            if (result.Equals(CreateTableResult.Created))
            {
                var defaultAttributes = new List<Attribute> {
                    new Attribute {
                        Name = "Manodopera",
                        Price = 8,
                        Percentage = -1,
                        Default = true
                    },
                    new Attribute {
                        Name = "Gestione",
                        Price = 3,
                        Percentage = -1,
                        Default = true
                    },
                    new Attribute {
                        Name = "2% su materia prima",
                        Price = -1,
                        Percentage = 2,
                        Default = true
                    },
                    new Attribute {
                        Name = "Assicurazione 2%",
                        Price = -1,
                        Percentage = 2,
                        Default = true
                    },
                    new Attribute {
                        Name = "Trasporto",
                        Price = 7,
                        Percentage = -1,
                        Default = true
                    },
                };

                if (this.connectionPool.InsertAll(defaultAttributes, true) == 0)
                {
                    throw new InvalidInitializationException("The attributes table was not initialized.");
                }
            }
            return result;
        }
    }
}
