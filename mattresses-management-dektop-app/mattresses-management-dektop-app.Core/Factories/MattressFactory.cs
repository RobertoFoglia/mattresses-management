using mattresses_management_dektop_app.Core.Models.entities;
using mattresses_management_dektop_app.Core.Services.Api;
using System.Collections.Generic;

namespace mattresses_management_dektop_app.Core.Factories
{
    public class MattressFactory
    {
        private readonly IMattressesService mattressesService;

        public MattressFactory(IMattressesService mattressesService)
        {
            this.mattressesService = mattressesService;
        }

        public Mattress GetNewMattressInstances()
        {
            var mattress = new Mattress
            {
                Name = "",
                Price = 0,
                Products = new List<Product>(),
            };

            mattressesService.GetDefaultAttributes(mattress);

            return mattress;
        }
    }
}