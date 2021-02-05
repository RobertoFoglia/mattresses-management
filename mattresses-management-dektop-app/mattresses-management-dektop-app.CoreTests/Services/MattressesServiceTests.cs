using Microsoft.VisualStudio.TestTools.UnitTesting;
using mattresses_management_dektop_app.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using mattresses_management_dektop_app.Core.Models.entities;
using mattresses_management_dektop_app.Core.Repositories.SQLite;

namespace mattresses_management_dektop_app.Core.Services.Tests
{
    [TestClass()]
    public class MattressesServiceTests
    {
        private MattressesService service = new MattressesService(null, null, null, null);
        private Mattress mattress;

        public void setup()
        {
            mattress = new Mattress();
            mattress.Attributes = AttributesSQLiteRepository.getDefaultAttributes();
            mattress.Attributes.Add(
                new Models.entities.Attribute
                {
                    Name = "Prezzo di vendita",
                    Price = 0,
                    Percentage = -1,
                    Default = false,
                    IsCalculated = true
                }
                );
            mattress.Products = new List<Product>();
            mattress.Products.Add(new Product());
        }

        [TestMethod()]
        public void CalculateTheAttributesTest()
        {
            this.setup();
            mattress.Products.Add(
                new Product()
                {
                    Number = 2,
                    Price = 10.4m
                });
            mattress.Products.Add(
            new Product()
            {
                Number = 4,
                Price = 5.4m
            });
            service.CalculateTheAttributes(mattress);

            Assert.IsTrue(checkFields(mattress, 0.848m));
        }

        public Boolean checkFields(Mattress mattress, decimal materiaPrima)
        {

            var mattMateriaPrima = mattress.Attributes.Find(attribute => attribute.Name.Equals("2% su materia prima")).Price;

            if (mattMateriaPrima != materiaPrima)
                return false;

            return true;
        }
    }
}