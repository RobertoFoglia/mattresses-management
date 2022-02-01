using mattresses_management_dektop_app.Core.Models.entities;
using System.Collections.Generic;

namespace mattresses_management_dektop_app.Core.Repositories.Api
{
    public interface IProductsRepository : IRepository<Product, int>
    {
        List<Product> FindByALikeWithNameAndDescription(string name, string description);
    }
}