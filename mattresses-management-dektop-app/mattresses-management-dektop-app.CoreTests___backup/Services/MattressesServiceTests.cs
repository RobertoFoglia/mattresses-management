using Microsoft.VisualStudio.TestTools.UnitTesting;
using mattresses_management_dektop_app.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using mattresses_management_dektop_app.Core.Repositories.SQLite;
using NUnit.Framework;
using mattresses_management_dektop_app.Core.Models.entities;

namespace mattresses_management_dektop_app.Core.Services.Tests
{
    [TestFixture]
    public class MattressesServiceTests
    {
        private MattressesService service = new MattressesService(null, null, null, null);
        private Mattress mattress;

        [SetUp]
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

        [Test]
        public void CalculateTheAttributesTest()
        {
            mattress.Products.Add(
                new Product()
                {
                    Number = 2,
                    Price = 10.4
                });
            mattress.Products.Add(
            new Product()
            {
                Number = 4,
                Price = 5.4
            });
            service.CalculateTheAttributes(mattress);

            Microsoft.VisualStudio.TestTools.
                UnitTesting.Assert.IsTrue(checkFields(mattress, 0.848));
        }

        public Boolean checkFields(Mattress mattress, Double materiaPrima) {

            var mattMateriaPrima = mattress.Attributes.Find(attribute => attribute.Name.Equals("2% su materia prima")).Price;

            if (mattMateriaPrima != materiaPrima)
                return false;

            return true;
        }
    }
}