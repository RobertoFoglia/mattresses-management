﻿using mattresses_management_dektop_app.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using mattresses_management_dektop_app.Core.Models.entities;
using mattresses_management_dektop_app.Core.Repositories.SQLite;
using NUnit.Framework;

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
            mattress = new Mattress
            {
                Attributes = AttributesSQLiteRepository.getDefaultAttributes()
            };
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
            mattress.Products = new List<Product>
            {
                new Product()
            };
        }

        [Test]
        public void CalculateTheAttributesTest()
        {
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

            var mattMateriaPrima = mattress.Attributes.Find(attribute => attribute.Id == 3).Price;

            if (mattMateriaPrima != materiaPrima)
                return false;

            return true;
        }
    }
}