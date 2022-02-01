using mattresses_management_dektop_app.Core.Exceptions;
using mattresses_management_dektop_app.Core.Logging;
using mattresses_management_dektop_app.Core.Models.entities;
using mattresses_management_dektop_app.Core.Repositories.Api;
using SQLite;
using System.Collections.Generic;
using Attribute = mattresses_management_dektop_app.Core.Models.entities.Attribute;

namespace mattresses_management_dektop_app.Core.Repositories.SQLite
{
    public class AttributesSQLiteRepository : AbstractSQLiteRepository<Attribute, int>, IAttributesRepository
    {
        private static readonly Log LOG = LogFactory.CreateNewIstance(typeof(AttributesSQLiteRepository));

        public AttributesSQLiteRepository(SQLiteConnection connectionPool) : base(connectionPool)
        {
        }

        public override CreateTableResult InitTable()
        {
            var result = base.InitTable();
            if (result.Equals(CreateTableResult.Created))
            {
                var defaultAttributes = getDefaultAttributes();

                if (this.connectionPool.InsertAll(defaultAttributes, true) == 0)
                {
                    throw new InvalidInitializationException("The attributes table was not initialized.");
                }

                LOG.Information("Table Attributes has been created.");
            }
            return result;
        }

        public static List<Attribute> getDefaultAttributes()
        {
            return new List<Attribute> {
                    new Attribute {
                        Id = (int) CommonAttributesEnum.MAN_POWER,
                        Code = nameof(CommonAttributesEnum.MAN_POWER),
                        Name = "Manodopera",
                        Price = 8,
                        Percentage = -1,
                        Default = true
                    },
                    new Attribute {
                        Id = (int) CommonAttributesEnum.MANAGEMENT,
                        Code = nameof(CommonAttributesEnum.MANAGEMENT),
                        Name = "Gestione",
                        Price = 3,
                        Percentage = -1,
                        Default = true
                    },
                    new Attribute {
                        Id = (int) CommonAttributesEnum.PERCENT_ON_PRIMARY_MATERIAL,
                        Code = nameof(CommonAttributesEnum.PERCENT_ON_PRIMARY_MATERIAL),
                        Name = "2% su materia prima",
                        Price = -1,
                        Percentage = 2,
                        Default = true
                    },
                    new Attribute {
                        Id = (int) CommonAttributesEnum.ASSICURATION,
                        Code = nameof(CommonAttributesEnum.ASSICURATION),
                        Name = "Assicurazione 2%",
                        Price = -1,
                        Percentage = 2,
                        Default = true
                    },
                    new Attribute {
                        Id = (int) CommonAttributesEnum.DELIVERY,
                        Code = nameof(CommonAttributesEnum.DELIVERY),
                        Name = "Trasporto",
                        Price = 7,
                        Percentage = -1,
                        Default = true
                    }
                };
        }
    }
}