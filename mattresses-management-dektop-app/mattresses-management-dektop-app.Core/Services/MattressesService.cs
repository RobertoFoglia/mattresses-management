using mattresses_management_dektop_app.Core.Models.entities;
using mattresses_management_dektop_app.Core.Repositories.Api;
using mattresses_management_dektop_app.Core.Services.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Attribute = mattresses_management_dektop_app.Core.Models.entities.Attribute;

namespace mattresses_management_dektop_app.Core.Services
{
    public class MattressesService : AbstractCRUDService<Mattress, int>, IMattressesService
    {
        private readonly IMattressesRepository MattressesRepository;
        private readonly IMattressProductsRepository MattressProductsRepository;
        private readonly IMattressAttributesRepository MattressAttributesRepository;
        private readonly IAttributesService attributesService;

        public MattressesService(
            IMattressesRepository mattressesRepository,
            IMattressProductsRepository mattressProductsRepository,
            IMattressAttributesRepository mattressAttributesRepository,
            IAttributesService attributesService
            )
            : base(mattressesRepository)
        {
            this.MattressesRepository = mattressesRepository;
            this.MattressProductsRepository = mattressProductsRepository;
            this.MattressAttributesRepository = mattressAttributesRepository;
            this.attributesService = attributesService;
        }

        public Mattress GetAttributes(Mattress mattress) {
            if (mattress == null)
            {
                mattress = new Mattress();
            }
            mattress.Attributes = MattressAttributesRepository.GetTheAttributesOfTheMattresses(mattress);

            var dictionary = MattressAttributesRepository.FindByMattress(mattress)
                .ToDictionary<MattressAttribute, int>(mattressAttribute => mattressAttribute.IdAttribute);

            mattress.Attributes.ForEach(attribute => {
                MattressAttribute mattressAttribute;
                dictionary.TryGetValue(attribute.Id, out mattressAttribute);

                if (mattressAttribute.Price >= 0) {
                    attribute.Price = mattressAttribute.Price;
                }

                if (mattressAttribute.Percentage >= 0) {
                    attribute.Percentage = mattressAttribute.Percentage;
                }
            });

            mattress.Attributes = CalculateAndOrderTheAttributes(mattress);

            return mattress;
        }

        private List<Attribute> CalculateAndOrderTheAttributes(Mattress mattress)
        {
            var tmp = new List<Attribute>();
            Attribute[] array = { new Attribute(), new Attribute(), new Attribute() };

            Attribute assicurazione = null;

            double productsSum = 0;
            productsSum += mattress.Products.Sum<Product>(product => product.TotalPrice);
            var attributesForTheGain = 0.0;

            mattress.Attributes.ForEach(
                attribute =>
                {
                    if (attribute.Name.ToUpper().Contains("PRIMA"))
                    {
                        array[2] = attribute;
                        attribute.Price = productsSum * attribute.Percentage / 100;
                        return;
                    }
                    if (attribute.Name.ToUpper().Contains("MANODOPERA"))
                    {
                        array[1] = attribute;
                        return;
                    }
                    if (attribute.Name.ToUpper().Contains("GESTIONE"))
                    {
                        array[0] = attribute;
                        return;
                    }
                    if (attribute.Name.ToUpper().Contains("ASSICURAZIONE"))
                    {
                        assicurazione = attribute;
                        assicurazione.Price = mattress.Price * attribute.Percentage / 100;
                        attributesForTheGain += attribute.Price;
                        return;
                    }
                    tmp.Add(attribute);
                    attributesForTheGain += attribute.Price;
                });

            tmp.Insert(0,
                new Attribute()
                {
                    Name = "Costo materasso",
                    Price = productsSum + array.ToList().Sum<Attribute>(attribute => attribute.Price)
                }
            );
            tmp.Insert(1,
                new Attribute()
                {
                    Name = "Prezzo di vendita",
                    Price = mattress.Price
                }
            );
            tmp.Insert(2, assicurazione);

            array.ToList().ForEach(attribute => tmp.Insert(0, attribute));

            tmp.Add(
                new Attribute()
                {
                    Name = "RICAVO",
                    Price = mattress.Price - attributesForTheGain
                }
                );

            return tmp;
        }

        public Mattress GetProducts(Mattress mattress)
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

        public Mattress GetDefaultAttributes(Mattress mattress)
        {
            if (mattress == null)
            {
                mattress = new Mattress();
            }

            if (mattress.Products == null) {
                mattress.Products = new List<Product>();
            }

            mattress.Attributes = attributesService.GetDefaultAttributes();
            mattress.Attributes = CalculateAndOrderTheAttributes(mattress);
            return mattress;
        }
    }
}
