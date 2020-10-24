using mattresses_management_dektop_app.Core.Models.entities;
using mattresses_management_dektop_app.Core.Repositories.Api;
using mattresses_management_dektop_app.Core.Services.Api;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace mattresses_management_dektop_app.Core.Services
{
    public class ProductsService: AbstractCRUDService<Product, int>, IProductsService
    {
        private readonly IProductsRepository ProductsRepository;
        private readonly IMattressProductsRepository MattressProductsRepository;

        public ProductsService(
            IProductsRepository productsRepository, IMattressProductsRepository mattressProductsRepository
            ) : base(productsRepository)
        {
            this.ProductsRepository = productsRepository;
            this.MattressProductsRepository = mattressProductsRepository;
        }

        public Product findByUniqueFieldsInAList(Product searchParamenter, Collection<Product> products)
        {
            var productSearch = from product in products
                           where product.Name.Equals(searchParamenter.Name)
                           select product;
            if (productSearch.Count() > 1) throw new ArgumentException("In the products list, there are duplicates.");
            return productSearch.First();
        }

        public new int Delete(Product entity)
        {
            if (entity == null) {
                throw new System.ArgumentException("Devi passare un argomento diverso da null");
            }
            return this.ProductsRepository.Delete(entity);
        }
    }
}
