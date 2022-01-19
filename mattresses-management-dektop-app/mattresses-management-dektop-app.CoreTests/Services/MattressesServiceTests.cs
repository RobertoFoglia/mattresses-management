using mattresses_management_dektop_app.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using mattresses_management_dektop_app.Core.Models.entities;
using mattresses_management_dektop_app.Core.Repositories.SQLite;
using NUnit.Framework;
using mattresses_management_dektop_app.Core.Repositories.Api;
using mattresses_management_dektop_app.Core.Services.Api;
using Moq;
using AutoFixture;

namespace mattresses_management_dektop_app.Core.Services.Tests
{
    [TestFixture]
    public class MattressesServiceTests
    {

        private Mock<IMattressesRepository> mattressesRepositoryMock;
        private Mock<IMattressProductsRepository> mattressProductsRepositoryMock;
        private Mock<IMattressAttributesRepository> mattressAttributesRepositoryMock;
        private Mock<IAttributesService> attributesService;
        private MattressesService service;
        private Mattress mattress;
        private Fixture fixtures;

        [OneTimeSetUp]
        public void Init()
        {
            mattressesRepositoryMock = new Mock<IMattressesRepository>();
            mattressAttributesRepositoryMock = new Mock<IMattressAttributesRepository>();
            mattressProductsRepositoryMock = new Mock<IMattressProductsRepository>();
            mattressAttributesRepositoryMock = new Mock<IMattressAttributesRepository>();
            attributesService = new Mock<IAttributesService>();
            service = new MattressesService(mattressesRepositoryMock.Object, mattressProductsRepositoryMock.Object, mattressAttributesRepositoryMock.Object, attributesService.Object);

            fixtures = new Fixture();
        }

        [SetUp]
        public void Setup()
        {
            mattress = fixtures.Create<Mattress>();
            mattress.Attributes = AttributesSQLiteRepository.getDefaultAttributes();

            mattress.Attributes.Add(new Models.entities.Attribute
            {
                Name = "Prezzo di vendita",
                Price = 0,
                Percentage = -1,
                Default = false,
                IsCalculated = true
            });
            mattress.Products = new List<Product>();
        }

        [Test]
        public void CalculateTheAttributesTest()
        {
            mattress.Products.Add(new Product()
            {
                Number = 2,
                Price = 10.4m
            });
            mattress.Products.Add(new Product()
            {
                Number = 4,
                Price = 5.4m
            });
            service.CalculateTheAttributes(mattress);

            // 2% on the primary material
            Assert.AreEqual(mattress.Attributes.Find(attribute => attribute.Id == 3).Price, 0.848m);
            // products total + 2% sulle materie prime + labour + assicuration
            Assert.AreEqual(mattress.Attributes.Find(attribute => "Costo materasso".Equals(attribute.Name)).Price, 42.4m + 0.848m + 8m + 3m);

        }
    }
}