using mattresses_management_dektop_app.Core.Models.entities;
using mattresses_management_dektop_app.Core.Repositories.Api;
using mattresses_management_dektop_app.Core.Services.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace mattresses_management_dektop_app.Core.Services
{
    public class ProductsService: IProductsService
    {
        private readonly IProductsRepository productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public Product Find(int id) {
            return this.productsRepository.Find<Product>(id);
        }
    }
}
