using mattresses_management_dektop_app.Core.Models.entities;
using mattresses_management_dektop_app.Core.Repositories.Api;
using mattresses_management_dektop_app.Core.Services.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mattresses_management_dektop_app.Core.Services
{
    public class MattressesService : AbstractCRUDService<Mattress, int>, IMattressesService
    {
        private readonly IMattressesRepository MattressesRepository;
        private readonly IMattressProductsRepository MattressProductsRepository;

        public MattressesService(
            IMattressesRepository mattressesRepository,
            IMattressProductsRepository mattressProductsRepository
            )
            : base(mattressesRepository)
        {
            this.MattressesRepository = mattressesRepository;
            this.MattressProductsRepository = mattressProductsRepository;
        }

        public Mattress SetProducts(Mattress mattress)
        {
            if (mattress == null)
            {
                mattress = new Mattress();
            }
            mattress.Products =
                MattressProductsRepository.GetTheProductsOfTheMattresses(mattress);
            var dictionary = MattressProductsRepository.FindByMattress(mattress)
                .ToDictionary<MattressProduct, int>(mattressProduct => mattressProduct.IdProduct);

            mattress.Products.ForEach(
                product =>
                {
                    MattressProduct mattressProduct;
                    dictionary.TryGetValue(product.Id, out mattressProduct);
                    product.Number = mattressProduct.Number;

                    if (mattressProduct.Unitary_Price >= 0)
                    {
                        product.Price = mattressProduct.Unitary_Price;
                    }
                }
                );

            return mattress;
        }
    }
}
