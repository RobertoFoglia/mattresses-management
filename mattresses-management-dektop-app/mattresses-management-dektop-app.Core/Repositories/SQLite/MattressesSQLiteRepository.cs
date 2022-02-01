using mattresses_management_dektop_app.Core.Models.entities;
using mattresses_management_dektop_app.Core.Repositories.Api;
using SQLite;
using System;

namespace mattresses_management_dektop_app.Core.Repositories.SQLite
{
    public class MattressesSQLiteRepository : AbstractSQLiteRepository<Mattress, int>, IMattressesRepository
    {
        private MattressesAttributesSQLiteRepository MattressesAttributesSQLiteRepository;
        private MattressProductsSQLiteRepository MattressProductsSQLiteRepository;

        public MattressesSQLiteRepository(
            SQLiteConnection connectionPool,
            MattressesAttributesSQLiteRepository MattressesAttributesSQLiteRepository,
            MattressProductsSQLiteRepository MattressProductsSQLiteRepository
            ) : base(connectionPool)
        {
        }

        public new int Insert(Mattress item)
        {
            this.connectionPool.BeginTransaction();

            try
            {
                this.Insert(item);

                var addedMattress = FindByName(item.Name);

                if (item.Attributes != null)
                {
                    MattressesAttributesSQLiteRepository.InsertAll(
                    item.Attributes.FindAll(attribute => !attribute.IsCalculated)
                    .ConvertAll(
                        attribute =>
                        new MattressAttribute()
                        {
                            IdAttribute = attribute.Id,
                            IdMattress = addedMattress.Id,
                            Percentage = attribute.Percentage,
                            Price = attribute.Price
                        })
                     );
                }

                if (item.Products != null)
                {
                    MattressProductsSQLiteRepository.InsertAll(
                        item.Products.ConvertAll<MattressProduct>(
                            product =>
                                new MattressProduct()
                                {
                                    IdMattress = item.Id,
                                    IdProduct = product.Id,
                                    Number = product.Number,
                                    Unitary_Price = product.Price
                                }
                            )
                        );
                }

                this.connectionPool.Commit();

                return 1;
            }
            catch (Exception ex)
            {
                this.connectionPool.Rollback();
                throw ex;
            }
        }

        public Mattress FindByName(string mattressName)
        {
            return this.connectionPool.Query<Mattress>(
                $"SELECT * FROM {Mattress.TableName} WHERE {Mattress.TableName} = ?", mattressName)[0];
        }
    }
}