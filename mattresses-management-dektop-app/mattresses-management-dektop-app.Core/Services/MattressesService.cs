using mattresses_management_dektop_app.Core.Models.entities;
using mattresses_management_dektop_app.Core.Repositories.Api;
using mattresses_management_dektop_app.Core.Services.Api;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Mattress GetAttributes(Mattress mattress)
        {
            if (mattress == null)
            {
                mattress = new Mattress();
            }
            mattress.Attributes = MattressAttributesRepository.GetTheAttributesOfTheMattresses(mattress);

            var dictionary = MattressAttributesRepository.FindByMattress(mattress)
                .ToDictionary<MattressAttribute, int>(mattressAttribute => mattressAttribute.IdAttribute);

            mattress.Attributes.ForEach(attribute =>
            {
                MattressAttribute mattressAttribute;
                dictionary.TryGetValue(attribute.Id, out mattressAttribute);

                if (mattressAttribute.Price >= 0)
                {
                    attribute.Price = mattressAttribute.Price;
                }

                if (mattressAttribute.Percentage >= 0)
                {
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

            decimal productsSum = 0;
            productsSum += mattress.Products.Sum<Product>(product => product.TotalPrice);
            var attributesForTheGain = 0.0m;

            mattress.Attributes.ForEach(
                attribute =>
                {
                    if (attribute.Id == (int)CommonAttributesEnum.PERCENT_ON_PRIMARY_MATERIAL)
                    {
                        attribute.Price = productsSum * attribute.Percentage / 100;
                        array[2] = attribute;
                        return;
                    }
                    if (attribute.Id == (int)CommonAttributesEnum.MAN_POWER)
                    {
                        array[1] = attribute;
                        return;
                    }
                    if (attribute.Id == (int)CommonAttributesEnum.MANAGEMENT)
                    {
                        array[0] = attribute;
                        return;
                    }
                    if (attribute.Id == (int)CommonAttributesEnum.ASSICURATION)
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
                    Id = (int)CommonAttributesEnum.MATTRESS_PRICE,
                    Code = nameof(CommonAttributesEnum.MATTRESS_PRICE),
                    Name = "Costo materasso",
                    Price = productsSum + array.ToList().Sum<Attribute>(attribute => attribute.Price),
                    IsCalculated = true
                }
            );

            tmp.Insert(1, CraeteSellingPriceAttribute(mattress.Price));
            tmp.Insert(2, assicurazione);

            array.ToList().ForEach(attribute => tmp.Insert(0, attribute));

            tmp.Add(
                new Attribute()
                {
                    Id = (int)CommonAttributesEnum.REVENUE,
                    Code = nameof(CommonAttributesEnum.REVENUE),
                    Name = "RICAVO",
                    Price = mattress.Price - attributesForTheGain,
                    IsCalculated = true
                }
                );

            return tmp;
        }

        public Attribute CraeteSellingPriceAttribute(decimal price) {
            return new Attribute()
            {
                Id = (int)CommonAttributesEnum.SELLING_PRICE,
                Code = nameof(CommonAttributesEnum.SELLING_PRICE),
                Name = "Prezzo di vendita",
                Price = price,
                IsCalculated = true,
                IsReadOnly = false
            };
        }

        public void CalculateTheAttributes(Mattress mattress)
        {
            decimal priceToSave = 0;
            if (mattress.Attributes.Count != 0)
            {
                List<Attribute> cancelledAttributes = mattress.Attributes.FindAll(attribute => attribute.IsCalculated);
                               priceToSave = (from attribute in cancelledAttributes
                               where GetPredicateToFindSellingPriceAttribute().Invoke(attribute)
                               select attribute).First().Price;
                mattress.Attributes.RemoveAll(attribute => attribute.IsCalculated);
            }

            mattress.Attributes = CalculateAndOrderTheAttributes(mattress);
            var attributeToChange = mattress.Attributes.Find(GetPredicateToFindSellingPriceAttribute());
            attributeToChange.Price = priceToSave;

            attributeToChange = mattress.Attributes.Find(GetPredicateToFindSellingPriceAttribute());
            attributeToChange.Price += priceToSave;
        }

        public Predicate<Attribute> GetPredicateToFindSellingPriceAttribute()
        {
            return attribute => nameof(CommonAttributesEnum.SELLING_PRICE).Equals(attribute.Code);
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

            if (mattress.Products == null)
            {
                mattress.Products = new List<Product>();
            }

            mattress.Attributes = attributesService.GetDefaultAttributes();
            mattress.Attributes = CalculateAndOrderTheAttributes(mattress);
            return mattress;
        }

        public new int Insert(Mattress mattress)
        {
            // TODO validation
            // - name is unique
            // - quantity is number
            // - price is a number (attributes)

            // throw the UserOperationException
            return 0;
        }
    }
}