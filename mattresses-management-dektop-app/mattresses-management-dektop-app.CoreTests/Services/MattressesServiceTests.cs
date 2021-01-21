using Microsoft.VisualStudio.TestTools.UnitTesting;
using mattresses_management_dektop_app.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace mattresses_management_dektop_app.Core.Services.Tests
{
    [TestClass()]
    public class MattressesServiceTests
    {
        [TestMethod()]
        public void CalculateTheAttributesTest()
        {
            var service = new MattressesService(null, null, null, null);
            var mattress = new Models.entities.Mattress();
            mattress.Attributes = new List<Models.entities.Attribute>();
            mattress.Products = new List<Models.entities.Product>();
            mattress.Products.Add(new Models.entities.Product());
            service.CalculateTheAttributes(mattress);
            Assert.Fail();
        }
    }
}