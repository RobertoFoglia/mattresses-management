using mattresses_management_dektop_app.Core.Models.entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace mattresses_management_dektop_app.Core.Services.Api
{
    public interface IProductsService : ICRUDService<Product, int>
    {
        Product findByUniqueFieldsInAList(Product searchParamenter, Collection<Product> products);

        bool BelongsToAMattress(Product entity);

        List<Product> FindByALikeWithNameAndDescription(string name, string description);
    }
}